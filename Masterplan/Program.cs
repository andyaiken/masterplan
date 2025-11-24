#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.UI;
using MessagePack;
using MessagePack.Formatters;
using MessagePack.Resolvers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Masterplan
{
    static class Program
    {
        internal static bool fIsBeta = true;

        [STAThread]
        public static void Main(string[] args)
        {
            // Set up MessagePack options before any library loading occurs.
            SetupMessagePackResolvers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

          

            try
            {
                // The CS7036 error was fixed by modifying the file creation logic inside LogSystem.cs.
        #region Bootstrapping
                Init_logging();

                SplashScreen = new ProgressScreen("Masterplan", 0);
                SplashScreen.CurrentAction = "Loading...";
                SplashScreen.Show();

                Load_preferences();
                Load_libraries();

                foreach (string arg in args)
                    Handle_arg(arg);

                SplashScreen.CurrentAction = "Starting Masterplan...";
                SplashScreen.Actions = 0;

                try
                {
                    MainForm main_form = new MainForm();
                    Application.Run(main_form);
                }
                catch (Exception ex)
                {
                    LogSystem.Trace(ex);
                }

                List<Form> forms = new List<Form>();
                foreach (Form form in Application.OpenForms)
                    forms.Add(form);
                foreach (Form form in forms)
                    form.Close();

                Save_preferences();

                if (IsBeta)
                    Check_for_logs();
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }


        /// <summary>
        /// Sets up the MessagePack serializer options with custom and composite resolvers.
        /// This ensures System.Drawing.Color, System.Drawing.Bitmap, and polymorphic types are handled correctly.
        /// </summary>
        private static void SetupMessagePackResolvers()
        {
            try
            {
                // Combine custom formatters and standard resolvers into a single chain.
                var resolver = CompositeResolver.Create(
                    // 1. Custom formatters (highest priority)
                    new IMessagePackFormatter[] {
                        ColorFormatter.Instance,
                        BitmapFormatter.Instance // ADDED: Custom formatter for System.Drawing.Bitmap
                    },
                    // 2. Standard resolvers (order matters)
                    new IFormatterResolver[] {
                        NativeDateTimeResolver.Instance,
                        TypelessContractlessStandardResolver.Instance, // For interfaces, Bitmap, and dynamic types
                        StandardResolver.Instance,
                        ContractlessStandardResolver.Instance
                    }
                );

                MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(resolver);
            }
            catch (Exception ex)
            {
                // Log initialization errors without crashing the main thread
                // Console.WriteLine($"Error initializing MessagePack resolver: {ex.Message}");
                LogSystem.Trace(ex);
            }
        }

        // This method's body is external (in LogSystem.cs)
        static void Init_logging()
        {
            // Logging
            string mp_dir = FileName.Directory(Application.ExecutablePath);

            // Make sure the log directory exists
            string logdir = mp_dir + "Log" + Path.DirectorySeparatorChar;

            // FIX 2: Explicitly check for existence before calling CreateDirectory.
            // This works around the conflict with FileSystemAclExtensions.Create(DirectoryInfo, DirectorySecurity).
            if (!Directory.Exists(logdir))
            {
                try
                {
                    // Use the simple overload that doesn't conflict
                    DirectoryInfo di = Directory.CreateDirectory(logdir);
                    if (di == null)
                        throw new UnauthorizedAccessException();
                }
                catch
                {
                    // Ignore directory creation errors if logging will still work to console/default.
                }
            }

            // Begin logging
            string logfile = logdir + DateTime.Now.Ticks + ".log";
            LogSystem.LogFile = logfile;
        }
        static void Load_preferences()
        {
            try
            {
                Assembly ass = Assembly.GetEntryAssembly();
                string root_dir = FileName.Directory(ass.Location);
                string filename = root_dir + "Preferences.xml";

                if (File.Exists(filename))
                {
                    SplashScreen.CurrentAction = "Loading user preferences";

                    Preferences prefs = Serialisation<Preferences>.Load(filename, SerialisationMode.XML);
                    if (prefs != null)
                        Session.Preferences = prefs;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        static void Save_preferences()
        {
            try
            {
                Assembly ass = Assembly.GetEntryAssembly();
                string root_dir = FileName.Directory(ass.Location);
                string filename = root_dir + "Preferences.xml";

                Serialisation<Preferences>.Save(filename, Session.Preferences, SerialisationMode.XML);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        static void Load_libraries()
        {
            try
            {
                SplashScreen.CurrentAction = "Loading libraries...";

                Assembly ass = Assembly.GetEntryAssembly();
                string root_dir = FileName.Directory(ass.Location);

                string lib_dir = root_dir + "Libraries" + Path.DirectorySeparatorChar;

                // FIX 3: Use explicit existence check before creating directories to avoid ACL error.
                if (!Directory.Exists(lib_dir))
                    Directory.CreateDirectory(lib_dir);

                // --- NEW CONVERSION SETUP ---
                // Create directory for converted library files (MessagePack fix)
                string new_lib_dir = lib_dir + "Converted" + Path.DirectorySeparatorChar;

                // FIX 4: Use explicit existence check before creating directories to avoid ACL error.
                if (!Directory.Exists(new_lib_dir))
                    Directory.CreateDirectory(new_lib_dir);
                // ----------------------------

                // Move libraries from root directory
                string[] files = Directory.GetFiles(root_dir, "*.library");
                foreach (string filename in files)
                {
                    try
                    {
                        string lib_name = lib_dir + FileName.Name(filename) + ".library";

                        if (!File.Exists(lib_name))
                            File.Move(filename, lib_name);
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Trace(ex);
                    }
                }

                // Load and convert libraries
                string[] libraries = Directory.GetFiles(lib_dir, "*.library");
                SplashScreen.Actions = libraries.Length;

                // 1. Load all libraries. Session.LoadLibrary will check for the new .xLibrary 
                //    format first for maximum speed on subsequent loads.
                foreach (string filename in libraries)
                {
                    Session.LoadLibrary(filename);
                }

                // 2. Convert old .library files to the new .xLibrary format.
                //    This conversion is necessary to phase out BinaryFormatter.
                // NOT READY FOR RELEASE - COMMENT OUT
                //foreach (string filename in libraries)
                //{
                //    Session.ConvertLibrary(new_lib_dir, filename);
                //}

                Session.Libraries.Sort();
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }





        static void Handle_arg(string arg)
        {
            try
            {
                if (arg == "-creaturestats")
                {
                    Run_creature_stats();
                }

                FileInfo fi = new FileInfo(arg);
                if (fi.Exists)
                {
                    SplashScreen.CurrentAction = "Loading project...";
                    SplashScreen.CurrentSubAction = FileName.Name(fi.Name);

                    // Load file
                    Project p = Serialisation<Project>.Load(arg, SerialisationMode.Binary);
                    if (p != null)
                    {
                        Session.CreateBackup(arg);
                    }
                    else
                    {
                        p = Session.LoadBackup(arg);
                    }

                    if (p != null)
                    {
                        if (Session.CheckPassword(p))
                        {
                            Session.Project = p;
                            Session.FileName = arg;

                            p.Update();
                            p.SimplifyProjectLibrary();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        static void Check_for_logs()
        {
            string logfile = LogSystem.LogFile;

            if ((logfile == null) || (logfile == ""))
                return;

            if (!File.Exists(logfile))
                return;

            string logdir = FileName.Directory(logfile);
            Process.Start(logdir);
        }

#endregion

        #region Stats

        private static void Run_creature_stats()
        {
            // Run stats
            List<Creature> creatures = Session.Creatures;
            bool[] is_minion_options = { false, true };
            bool[] is_leader_options = { false, true };

            string datafile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Creatures.csv";
            StreamWriter sw = new StreamWriter(datafile);
            try
            {
                sw.Write("Level,Flag,Role,Minion,Leader,Tier,TierX,Creatures,Powers");
                // Conditions
                foreach (string condition in Conditions.GetConditions())
                    sw.Write("," + condition);
                // Damage types
                foreach (DamageType damage in Enum.GetValues(typeof(DamageType)))
                    sw.Write("," + damage);
                sw.WriteLine();

                for (int level = 1; level <= 40; ++level)
                {
                    foreach (bool is_minion in is_minion_options)
                    {
                        foreach (bool is_leader in is_leader_options)
                        {
                            foreach (RoleType role in Enum.GetValues(typeof(RoleType)))
                            {
                                foreach (RoleFlag flag in Enum.GetValues(typeof(RoleFlag)))
                                {
                                    List<Creature> list = Get_creatures(creatures, level, is_minion, is_leader, role, flag);

                                    List<CreaturePower> powers = new List<CreaturePower>();
                                    foreach (Creature c in list)
                                        powers.AddRange(c.CreaturePowers);
                                    if (powers.Count == 0)
                                        continue;

                                    string tier = "";
                                    if (level < 11)
                                        tier = "heroic";
                                    else if (level < 21)
                                        tier = "paragon";
                                    else
                                        tier = "epic";

                                    string tierx = "";
                                    if (level < 4)
                                        tierx = "early heroic";
                                    else if (level < 8)
                                        tierx = "mid heroic";
                                    else if (level < 11)
                                        tierx = "late heroic";
                                    else if (level < 14)
                                        tierx = "early paragon";
                                    else if (level < 18)
                                        tierx = "mid paragon";
                                    else if (level < 21)
                                        tierx = "late paragon";
                                    else if (level < 24)
                                        tierx = "early epic";
                                    else if (level < 28)
                                        tierx = "mid epic";
                                    else if (level < 31)
                                        tierx = "late epic";
                                    else
                                        tierx = "epic plus";

                                    sw.Write(level + "," + flag + "," + role + "," + is_minion + "," + is_leader + "," + tier + "," + tierx + "," + list.Count + "," + powers.Count);

                                    foreach (string condition in Conditions.GetConditions())
                                    {
                                        int count = 0;

                                        string str = condition.ToLower();
                                        foreach (CreaturePower power in powers)
                                            if (power.Details.ToLower().Contains(str))
                                                count += 1;

                                        double pc = 0;
                                        if (powers.Count != 0)
                                            pc = (double)count / powers.Count;

                                        sw.Write("," + pc);
                                    }

                                    foreach (DamageType damage in Enum.GetValues(typeof(DamageType)))
                                    {
                                        int count = 0;

                                        string str = damage.ToString().ToLower();
                                        foreach (CreaturePower power in powers)
                                            if (power.Details.ToLower().Contains(str))
                                                count += 1;

                                        double pc = 0;
                                        if (powers.Count != 0)
                                            pc = (double)count / powers.Count;

                                        sw.Write("," + pc);
                                    }

                                    sw.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
            finally
            {
                sw.Close();
            }
        }

        private static List<Creature> Get_creatures(List<Creature> creatures, int level, bool is_minion, bool is_leader, RoleType role, RoleFlag flag)
        {
            List<Creature> list = new List<Creature>();

            foreach (Creature c in creatures)
            {
                if (c.Level != level)
                    continue;

                ComplexRole cr = c.Role as ComplexRole;
                Minion m = c.Role as Minion;

                if ((m != null) && (!m.HasRole))
                    continue;

                bool minion = m != null;
                if (minion != is_minion)
                    continue;

                bool leader = ((cr != null) && (cr.Leader));
                if (leader != is_leader)
                    continue;

                RoleType rt = RoleType.Blaster;
                RoleFlag rf = RoleFlag.Standard;
                if (cr != null)
                {
                    rt = cr.Type;
                    rf = cr.Flag;
                }
                if (m != null)
                {
                    rt = m.Type;
                    rf = RoleFlag.Standard;
                }

                if (rt != role)
                    continue;

                if (rf != flag)
                    continue;

                list.Add(c);
            }

            return list;
        }

        #endregion

        #region Security

        internal static bool IsBeta
        {
            get
            {
                return fIsBeta;
            }
        }

        #endregion

        internal static void SetResolution(Image img)
        {
            Bitmap bmp = img as Bitmap;
            if (bmp != null)
            {
                try
                {
                    float x_dpi = Math.Min(bmp.HorizontalResolution, 96);
                    float y_dpi = Math.Min(bmp.VerticalResolution, 96);

                    bmp.SetResolution(x_dpi, y_dpi);
                }
                catch
                {
                    // Didn't set anything
                }
            }
        }

        public static ProgressScreen SplashScreen = null;

        public static string ProjectFilter = "Masterplan Project|*.masterplan";
        public static string LibraryFilter = "Masterplan Library|*.library;*.xlibrary";
        public static string EncounterFilter = "Masterplan Encounter|*.encounter";
        public static string BackgroundFilter = "Masterplan Campaign Background|*.background";
        public static string EncyclopediaFilter = "Masterplan Campaign Encyclopedia|*.encyclopedia";
        public static string RulesFilter = "Masterplan Rules|*.crunch";

        public static string CreatureAndMonsterFilter = "Creatures|*.creature;*.monster";
        public static string MonsterFilter = "Adventure Tools Creatures|*.monster";
        public static string CreatureFilter = "Creatures|*.creature";
        public static string CreatureTemplateFilter = "Creature Template|*.creaturetemplate";
        public static string ThemeFilter = "Themes|*.theme";
        public static string CreatureTemplateAndThemeFilter = "Creature Templates and Themes|*.creaturetemplate;*.theme";
        public static string TrapFilter = "Traps|*.trap";
        public static string SkillChallengeFilter = "Skill Challenges|*.skillchallenge";
        public static string MagicItemFilter = "Magic Items|*.magicitem";
        public static string ArtifactFilter = "Artifacts|*.artifact";
        public static string MapTileFilter = "Map Tiles|*.maptile";
        public static string TerrainPowerFilter = "Terrain Powers|*.terrainpower";

        public static string HTMLFilter = "HTML File|*.htm";
        public static string ImageFilter = "Image File|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tga";
        public static string PNGFilter = "Image File|*.png";        // Added for the PNG Export
        public static string HeroAndPCFilter = "Hero File|*.hero";  // Added for the Hero Export

    }
}
