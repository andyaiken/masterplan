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
using System.Windows.Forms;

namespace Masterplan
{
    static class Program
    {
        internal static bool fIsBeta = false;

        [STAThread]
        public static void Main(string[] args)
        {
            // Set up MessagePack options before any library loading occurs.
            SetupMessagePackResolvers();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
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
        /// Sets up MessagePack for Masterplan's files (.mpxlib, .mpxplan, rules, heroes) and the clipboard.
        /// </summary>
        /// <remarks>
        /// THE FILE FORMAT DEPENDS ON THIS (for new developers). Only the DTOs (Dto\DtoModels.cs) are ever
        /// serialised, and every file written since M14.1 uses two non-standard value forms. NEVER remove
        /// them or move them after StandardResolver:
        ///   - NativeDateTimeResolver: a DateTime is .NET's binary form (DateTime.ToBinary). Standard
        ///     MessagePack writes a timestamp instead and cannot read this form: without it, combat states
        ///     and combat logs in existing projects could not be loaded.
        ///   - ForceInt32BlockFormatter / NullableForceInt32BlockFormatter: an int (and an int?) is
        ///     always a 5-byte block. int and int? are the only number types in the DTOs; the test
        ///     Every_DTO_member_has_a_type_the_file_format_can_store fails if another one is added, so
        ///     its form can be decided then.
        /// Up to 14.1.0.10 these came in through MessagePack's "typeless" resolver, which could also
        /// create any .NET type named in a file (the same risk as BinaryFormatter). It was never needed,
        /// since no DTO has an object or interface member, and was removed in 14.1.0.11, together with
        /// the unused Color/Bitmap formatters and the contractless resolver.
        /// UntrustedData: files are shared between users, so reading uses MessagePack's protection against
        /// hostile files (hash-collision-safe dictionaries, a depth limit of 500).
        /// Masterplan.Tests\MessagePackFormatTests proves the bytes are the same as with the 14.1 settings.
        /// internal (not private) so the tests and the sample builder use exactly the same setup.
        /// </remarks>
        internal static void SetupMessagePackResolvers()
        {
            try
            {
                var resolver = CompositeResolver.Create(
                    new IMessagePackFormatter[] {
                        ForceInt32BlockFormatter.Instance,
                        NullableForceInt32BlockFormatter.Instance
                    },
                    new IFormatterResolver[] {
                        NativeDateTimeResolver.Instance,
                        StandardResolver.Instance
                    });

                MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard
                    .WithResolver(resolver)
                    .WithSecurity(MessagePackSecurity.UntrustedData);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        static void Init_logging()
        {
            // The Log folder beside the exe. AppPaths is the one place that finds the exe's folder
            // (works in normal and single-file mode); see Tools/AppPaths.cs.
            string mp_dir = AppPaths.AppFolder;
            string logdir = mp_dir + "Log" + Path.DirectorySeparatorChar;

            if (!Directory.Exists(logdir))
            {
                try
                {
                    DirectoryInfo di = Directory.CreateDirectory(logdir);
                    if (di == null)
                        throw new UnauthorizedAccessException();
                }
                catch
                {
                }
            }

            string logfile = logdir + DateTime.Now.Ticks + ".log";
            LogSystem.LogFile = logfile;
        }

        static void Load_preferences()
        {
            try
            {
                // Preferences.xml beside the exe. Assembly.Location (used before) is "" in
                // single-file mode, which would have read the file from the current folder.
                string filename = AppPaths.AppFolder + "Preferences.xml";

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
                // Saved to the same place Load_preferences reads from (see AppPaths).
                string filename = AppPaths.AppFolder + "Preferences.xml";

                Serialisation<Preferences>.Save(filename, Session.Preferences, SerialisationMode.XML);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        static void Load_libraries()
        {
            // Libraries are loaded relative to the folder Masterplan.exe is in
            // (AppPaths works in normal and single-file mode).
            Load_libraries(AppPaths.AppFolder);
        }

        /// <summary>
        /// Moves library files found in <paramref name="root_dir"/> into its Libraries subfolder, loads
        /// every .mpxlib there, and lists unconverted .library files in Session.SkippedLegacyFiles.
        /// </summary>
        /// <remarks>
        /// The folder is a parameter (instead of always the exe's folder) so the automated tests can run
        /// this against a temporary folder. The splash screen only exists during a real startup, so
        /// every use of it is null-checked.
        /// </remarks>
        /// <param name="root_dir">The folder that holds (or will hold) the Libraries subfolder.</param>
        internal static void Load_libraries(string root_dir)
        {
            try
            {
                if (SplashScreen != null)
                    SplashScreen.CurrentAction = "Working on libraries...";

                if (!root_dir.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    root_dir += Path.DirectorySeparatorChar;
                string lib_dir = root_dir + "Libraries" + Path.DirectorySeparatorChar;

                if (!Directory.Exists(lib_dir))
                    Directory.CreateDirectory(lib_dir);

                // Convenience: library files dropped next to Masterplan.exe are moved into the Libraries
                // folder, because libraries are only ever loaded from there.
                //  - .mpxlib files are moved so they get loaded.
                //  - old .library files are moved too (unchanged, just relocated) so they sit where the
                //    startup check below finds them and the user is told to convert them. The migration
                //    tool then writes the .mpxlib beside them, in the Libraries folder.
                // A file is never moved over an existing file of the same name.
                List<string> root_files = new List<string>();
                root_files.AddRange(Directory.GetFiles(root_dir, "*" + LegacyFiles.LibraryExtension));
                root_files.AddRange(Directory.GetFiles(root_dir, "*" + LegacyFiles.LegacyLibraryExtension));
                foreach (string filename in root_files)
                {
                    try
                    {
                        string lib_name = lib_dir + Path.GetFileName(filename);
                        if (!File.Exists(lib_name))
                            File.Move(filename, lib_name);
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Trace(ex);
                    }
                }

                // Load every .mpxlib in the Libraries folder (only that folder, no subfolders).
                string[] mpx_files = Directory.GetFiles(lib_dir, "*" + LegacyFiles.LibraryExtension);
                if (SplashScreen != null)
                    SplashScreen.Actions = mpx_files.Length;

                foreach (string filename in mpx_files)
                    Session.LoadLibrary(filename);

                // Find old .library files that have NOT been converted (no .mpxlib with the same name).
                // They are left where they are. They are listed so MainForm can tell the user to run the
                // migration tool. A .library that already has a .mpxlib beside it is fine and ignored.
                foreach (string filename in Directory.GetFiles(lib_dir, "*" + LegacyFiles.LegacyLibraryExtension))
                {
                    string converted = Path.ChangeExtension(filename, LegacyFiles.LibraryExtension);
                    if (!File.Exists(converted))
                        Session.SkippedLegacyFiles.Add(filename);
                }

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

                    // A project passed on the command line (e.g. by double-clicking a file) may be an
                    // old .masterplan. LoadProject reads the .mpxplan of the same name if it exists.
                    string mpx_filename = Session.GetProjectFilename(arg);
                    if (!File.Exists(mpx_filename) && LegacyFiles.IsLegacyProject(arg))
                    {
                        // Not converted yet: MainForm_Shown will tell the user (no message boxes
                        // while the splash screen is showing).
                        Session.SkippedLegacyFiles.Add(arg);
                        return;
                    }

                    Project p = Session.LoadProject(mpx_filename);
                    if (p != null)
                    {
                        // Back up and remember the file actually read (.mpxplan), so later saves go there.
                        Session.CreateBackup(mpx_filename);
                        if (Session.CheckPassword(p))
                        {
                            Session.Project = p;
                            Session.FileName = mpx_filename;

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

        /// <summary>
        /// BETA ONLY (called on exit when IsBeta): if an ERROR was logged in this session, ask whether
        /// to open the Log folder so the tester can send the log to the developers.
        /// </summary>
        /// <remarks>
        /// It used to open the folder whenever any log file existed. That never worked before
        /// ShellOpen (Process.Start(folder) fails on .NET 10); once it did, the folder opened after
        /// almost every session, because informational messages create the log file too. Now it only
        /// asks when LogSystem.ErrorLogged is set (an exception was logged), and the user decides.
        /// </remarks>
        static void Check_for_logs()
        {
            if (!LogSystem.ErrorLogged)
                return;

            string logfile = LogSystem.LogFile;
            if (string.IsNullOrEmpty(logfile) || !File.Exists(logfile))
                return;

            string msg = "Masterplan logged an error during this session." + Environment.NewLine + Environment.NewLine
                + "Would you like to open the Log folder so you can send the log file to the developers?";
            if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Opens the Log folder in Explorer. (Process.Start(folder) fails on .NET 10; see ShellOpen.)
            ShellOpen.Open(FileName.Directory(logfile));
        }

        #endregion

        #region Stats

        private static void Run_creature_stats()
        {
            List<Creature> creatures = Session.Creatures;
            bool[] is_minion_options = { false, true };
            bool[] is_leader_options = { false, true };

            string datafile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Creatures.csv";
            StreamWriter sw = new StreamWriter(datafile);
            try
            {
                sw.Write("Level,Flag,Role,Minion,Leader,Tier,TierX,Creatures,Powers");
                foreach (string condition in Conditions.GetConditions())
                    sw.Write("," + condition);
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

                                    string tier = (level < 11) ? "heroic" : (level < 21) ? "paragon" : "epic";
                                    string tierx = GetTierX(level);

                                    sw.Write(level + "," + flag + "," + role + "," + is_minion + "," + is_leader + "," + tier + "," + tierx + "," + list.Count + "," + powers.Count);

                                    foreach (string condition in Conditions.GetConditions())
                                    {
                                        int count = 0;
                                        string str = condition.ToLower();
                                        foreach (CreaturePower power in powers)
                                            if (power.Details.ToLower().Contains(str))
                                                count += 1;

                                        double pc = (powers.Count != 0) ? (double)count / powers.Count : 0;
                                        sw.Write("," + pc);
                                    }

                                    foreach (DamageType damage in Enum.GetValues(typeof(DamageType)))
                                    {
                                        int count = 0;
                                        string str = damage.ToString().ToLower();
                                        foreach (CreaturePower power in powers)
                                            if (power.Details.ToLower().Contains(str))
                                                count += 1;

                                        double pc = (powers.Count != 0) ? (double)count / powers.Count : 0;
                                        sw.Write("," + pc);
                                    }
                                    sw.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { LogSystem.Trace(ex); }
            finally { sw.Close(); }
        }

        private static string GetTierX(int level)
        {
            if (level < 4) return "early heroic";
            if (level < 8) return "mid heroic";
            if (level < 11) return "late heroic";
            if (level < 14) return "early paragon";
            if (level < 18) return "mid paragon";
            if (level < 21) return "late paragon";
            if (level < 24) return "early epic";
            if (level < 28) return "mid epic";
            if (level < 31) return "late epic";
            return "epic plus";
        }

        private static List<Creature> Get_creatures(List<Creature> creatures, int level, bool is_minion, bool is_leader, RoleType role, RoleFlag flag)
        {
            List<Creature> list = new List<Creature>();
            foreach (Creature c in creatures)
            {
                if (c.Level != level) continue;

                ComplexRole cr = c.Role as ComplexRole;
                Minion m = c.Role as Minion;

                if ((m != null) && (!m.HasRole)) continue;

                if ((m != null) != is_minion) continue;
                bool leader = (cr != null && cr.Leader);
                if (leader != is_leader) continue;

                RoleType rt = RoleType.Blaster;
                RoleFlag rf = RoleFlag.Standard;
                if (cr != null) { rt = cr.Type; rf = cr.Flag; }
                if (m != null) { rt = m.Type; rf = RoleFlag.Standard; }

                if (rt != role || rf != flag) continue;

                list.Add(c);
            }
            return list;
        }

        #endregion

        #region Security
        internal static bool IsBeta => fIsBeta;
        #endregion

        internal static void SetResolution(Image img)
        {
            if (img is Bitmap bmp)
            {
                try
                {
                    float x_dpi = Math.Min(bmp.HorizontalResolution, 96);
                    float y_dpi = Math.Min(bmp.VerticalResolution, 96);
                    bmp.SetResolution(x_dpi, y_dpi);
                }
                catch { }
            }
        }

        public static ProgressScreen SplashScreen = null;

        // SAVE dialogs: only the current formats. Old .masterplan/.library files are never written.
        public static string ProjectFilter = "Masterplan Project|*.mpxplan";
        public static string LibraryFilter = "Masterplan Library|*.mpxlib";

        // OPEN dialogs: the current AND the old formats, so users can also find their old files.
        // Picking an old file shows "Convert now?" (LegacyFiles.ShowSkipped), which starts
        // "MasterplanXP Migration Tool"; a converted project is then opened automatically.
        public static string ProjectOpenFilter =
            "Masterplan Projects (*.mpxplan, *.masterplan)|*.mpxplan;*.masterplan"
            + "|New format (*.mpxplan)|*.mpxplan"
            + "|Old format, needs converting (*.masterplan)|*.masterplan";
        public static string LibraryOpenFilter =
            "Masterplan Libraries (*.mpxlib, *.library)|*.mpxlib;*.library"
            + "|New format (*.mpxlib)|*.mpxlib"
            + "|Old format, needs converting (*.library)|*.library";
        public static string EncounterFilter = "Masterplan Encounter|*.encounter";
        public static string BackgroundFilter = "Masterplan Campaign Background|*.background";
        public static string EncyclopediaFilter = "Masterplan Campaign Encyclopedia|*.encyclopedia";
        // Rules and single-item exports use the MessagePack formats written by Tools/ItemFiles.cs.
        // The old BinaryFormatter extensions (.crunch, .creature, .trap, ...) are no longer offered:
        // those files cannot be read on .NET 10 and are not converted by the migration tool.
        // The extensions here must match the constants in ItemFiles.
        public static string RulesFilter = "Masterplan Rules|*" + ItemFiles.RulesExtension;

        // .monster is the Adventure Tools XML format, which is still supported (read via AppImport).
        public static string CreatureAndMonsterFilter = "Creatures|*" + ItemFiles.CreatureExtension + ";*.monster";
        public static string MonsterFilter = "Adventure Tools Creatures|*.monster";
        public static string CreatureFilter = "Creatures|*" + ItemFiles.CreatureExtension;
        public static string CreatureTemplateFilter = "Creature Template|*" + ItemFiles.CreatureTemplateExtension;
        public static string ThemeFilter = "Themes|*" + ItemFiles.ThemeExtension;
        public static string CreatureTemplateAndThemeFilter = "Creature Templates and Themes|*" + ItemFiles.CreatureTemplateExtension + ";*" + ItemFiles.ThemeExtension;
        public static string TrapFilter = "Traps|*" + ItemFiles.TrapExtension;
        public static string SkillChallengeFilter = "Skill Challenges|*" + ItemFiles.SkillChallengeExtension;
        public static string MagicItemFilter = "Magic Items|*" + ItemFiles.MagicItemExtension;
        public static string ArtifactFilter = "Artifacts|*" + ItemFiles.ArtifactExtension;
        public static string MapTileFilter = "Map Tiles|*" + ItemFiles.MapTileExtension;
        public static string TerrainPowerFilter = "Terrain Powers|*" + ItemFiles.TerrainPowerExtension;

        public static string HTMLFilter = "HTML File|*.htm";
        public static string ImageFilter = "Image File|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tga";
        public static string PNGFilter = "Image File|*.png";
        // Hero and party files (M14.1): MessagePack, written by ItemFiles.SaveHeroes. The old .hero
        // (XML) export never worked, so it is not offered. Extensions must match ItemFiles.
        public static string HeroAndPCFilter = "Hero File|*" + ItemFiles.HeroExtension;
        public static string PartyFilter = "Party File|*" + ItemFiles.PartyExtension;
        public static string HeroOrPartyFilter = "Hero and Party Files|*" + ItemFiles.HeroExtension + ";*" + ItemFiles.PartyExtension;

    }
}
