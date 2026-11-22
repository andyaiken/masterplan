#nullable disable

using Masterplan.Data;
using Masterplan.Extensibility;
using Masterplan.Tools;
using Masterplan.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Masterplan
{
    enum SearchType
    {
        Project,
        External,
        Global
    }

    class Session
    {
        #region Properties

        public static Project Project
        {
            get { return fProject; }
            set { fProject = value; }
        }
        static Project fProject = null;

        public static Preferences Preferences
        {
            get { return fPreferences; }
            set { fPreferences = value; }
        }
        static Preferences fPreferences = new Preferences();

        public static PlayerViewForm PlayerView
        {
            get { return fPlayerView; }
            set { fPlayerView = value; }
        }
        static PlayerViewForm fPlayerView = null;

        public static bool Modified
        {
            get { return fModified; }
            set { fModified = value; }
        }
        static bool fModified = false;

        public static string FileName
        {
            get { return fFileName; }
            set { fFileName = value; }
        }
        static string fFileName = "";

        public static Random Random
        {
            get { return fRandom; }
        }
        static Random fRandom = new Random();

        public static List<IAddIn> AddIns
        {
            get { return fAddIns; }
        }
        static List<IAddIn> fAddIns = new List<IAddIn>();

        #endregion

        #region Libraries

        public static string LibraryFolder
        {
            get
            {
                // AppPaths finds the exe's folder in both normal and single-file mode
                // (Assembly.Location is "" in single-file mode); see Tools/AppPaths.cs.
                return Tools.AppPaths.AppFolder + "Libraries\\";
            }
        }

        public static List<Library> Libraries = new List<Library>();

        /// <summary>
        /// The full path of a library's file in the Libraries folder (always the .mpxlib format).
        /// Every library save, rename and delete builds on this, so it is the single place that decides
        /// where library files live and what they are called.
        /// </summary>
        public static string GetLibraryFilename(Library lib)
        {
            DirectoryInfo di = new DirectoryInfo(LibraryFolder);

            string filename = Tools.FileName.TrimInvalidCharacters(lib.Name);

            return di + filename + LegacyFiles.LibraryExtension;
        }

        /// <summary>
        /// The path an OLD-format (.library) copy of this library would have in the Libraries folder.
        /// Only used to delete that old copy when the user explicitly deletes or renames the library;
        /// otherwise it would be reported as "not converted" at every startup.
        /// </summary>
        public static string GetLegacyLibraryFilename(Library lib)
        {
            return Path.ChangeExtension(GetLibraryFilename(lib), LegacyFiles.LegacyLibraryExtension);
        }

        /// <summary>
        /// Saves a library to its .mpxlib file in the Libraries folder.
        /// Use this for EVERY library save so they all use the same format and the safe .tmp-then-swap
        /// save in Serialisation.Save.
        /// </summary>
        /// <returns>True if the file was written.</returns>
        public static bool SaveLibrary(Library lib)
        {
            if (lib == null)
                return false;

            return Serialisation<Library>.Save(GetLibraryFilename(lib), lib, SerialisationMode.MessagePack);
        }

        /// <summary>
        /// Old-format files (.library / .masterplan with no converted copy) found while the program was
        /// starting up. They cannot be shown in a message during startup (the splash screen is up), so
        /// they are collected here and MainForm_Shown shows them once the main window is visible.
        /// </summary>
        public static List<string> SkippedLegacyFiles = new List<string>();

        public static Library FindLibrary(string name)
        {
            string filename = Tools.FileName.TrimInvalidCharacters(name);

            foreach (Library lib in Libraries)
            {
                if (lib.Name == name)
                    return lib;

                string lib_filename = Tools.FileName.TrimInvalidCharacters(lib.Name);
                if (lib_filename == filename)
                    return lib;
            }

            return null;
        }

        /// <summary>
        /// Loads a library and adds it to <see cref="Libraries"/>.
        /// </summary>
        /// <remarks>
        /// Only the .mpxlib format is read. Whatever extension is passed in, the .mpxlib file with the
        /// same name is loaded (so passing "X.library" loads "X.mpxlib" if it has been converted).
        /// If there is no .mpxlib, null is returned. Callers that may be given an old .library file should
        /// check <see cref="LegacyFiles.IsLegacyLibrary"/> and tell the user to convert it.
        /// </remarks>
        /// <param name="filename">Path of the library file.</param>
        /// <returns>The loaded library, or null if it could not be loaded.</returns>
        public static Library LoadLibrary(string filename)
        {
            try
            {
                if (Program.SplashScreen != null)
                {
                    Program.SplashScreen.CurrentSubAction = "Loading: " + Tools.FileName.Name(filename);
                    Program.SplashScreen.Progress += 1;
                }

                string mpxFilename = Path.ChangeExtension(filename, LegacyFiles.LibraryExtension);

                Library lib = null;
                if (File.Exists(mpxFilename))
                {
                    lib = Serialisation<Library>.Load(mpxFilename, SerialisationMode.MessagePack);
                }

                if (lib != null)
                {
                    lib.Name = Tools.FileName.Name(filename);
                    lib.Update();
                    Session.Libraries.Add(lib);
                }
                else
                {
                    LogSystem.Trace("Could not load " + Tools.FileName.Name(filename));
                }

                return lib;
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }

            return null;
        }

        /// <summary>
        /// Loads a project. Only the .mpxplan format is read.
        /// </summary>
        /// <remarks>
        /// Whatever extension is passed in, the .mpxplan file with the same name is loaded (so passing
        /// "X.masterplan" loads "X.mpxplan" if it has been converted). If there is no .mpxplan, null is
        /// returned. Use <see cref="GetProjectFilename"/> to get the path that was actually read, and
        /// <see cref="LegacyFiles.IsLegacyProject"/> to detect an unconverted old file.
        /// </remarks>
        /// <returns>The project, or null if it could not be loaded.</returns>
        public static Project LoadProject(string filename)
        {
            try
            {
                string mpxFilename = GetProjectFilename(filename);

                Project p = null;
                if (File.Exists(mpxFilename))
                {
                    p = Serialisation<Project>.Load(mpxFilename, SerialisationMode.MessagePack);
                }

                return p;
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
                return null;
            }
        }

        /// <summary>
        /// Loads a project that the user picked in a file dialog for IMPORTING something from it
        /// (Tools > Import Project, importing maps or regional maps), and tells the user if it fails.
        /// </summary>
        /// <remarks>
        /// Use this instead of calling Serialisation directly, so every import screen gives the same
        /// messages: the migration-tool message for an unconverted old file, or "could not be opened".
        /// (Opening a project as the CURRENT project is done by MainForm.open_file, which also handles
        /// backups and passwords.)
        /// </remarks>
        /// <param name="owner">Window that owns any message box.</param>
        /// <param name="filename">The file the user chose.</param>
        /// <returns>The project, or null (a message has already been shown).</returns>
        public static Project LoadProjectForImport(IWin32Window owner, string filename)
        {
            string mpx_filename = GetProjectFilename(filename);
            if (!File.Exists(mpx_filename) && LegacyFiles.IsLegacyProject(filename))
            {
                LegacyFiles.ShowSkipped(owner, new List<string> { filename });
                return null;
            }

            Project p = LoadProject(mpx_filename);
            if (p == null)
            {
                string msg = "The file '" + Tools.FileName.Name(filename) + "' could not be opened.";
                MessageBox.Show(owner, msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return p;
        }

        /// <summary>
        /// The .mpxplan path for a project file name, whatever extension it was given with
        /// (e.g. "C:\Adventures\Keep.masterplan" becomes "C:\Adventures\Keep.mpxplan").
        /// Projects are only ever saved and loaded under this name.
        /// </summary>
        public static string GetProjectFilename(string filename)
        {
            return Path.ChangeExtension(filename, LegacyFiles.ProjectExtension);
        }

        /// <summary>
        /// Deletes a library's files and removes it from <see cref="Libraries"/>.
        /// </summary>
        /// <remarks>
        /// Deletes the .mpxlib AND any old .library of the same name in the Libraries folder.
        /// This is one of only two places (with renaming) where M14 touches an old file: the user has
        /// explicitly asked to delete the library, and leaving the old file behind would make it show
        /// up as "not converted" at every startup.
        /// </remarks>
        public static void DeleteLibrary(Library lib)
        {
            string[] files = { GetLibraryFilename(lib), GetLegacyLibraryFilename(lib) };
            foreach (string file in files)
            {
                if (File.Exists(file))
                    File.Delete(file);
            }

            Session.Libraries.Remove(lib);
        }

        #endregion

        #region Find library by item

        public static Library FindLibrary(Creature c)
        {
            if (c == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (Creature item in lib.Creatures)
                {
                    if (item == null)
                        continue;

                    if (item.ID == c.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (Creature item in fProject.Library.Creatures)
                {
                    if (item == null)
                        continue;

                    if (item.ID == c.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(CreatureTemplate ct)
        {
            if (ct == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (CreatureTemplate item in lib.Templates)
                {
                    if (item == null)
                        continue;

                    if (item.ID == ct.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (CreatureTemplate item in fProject.Library.Templates)
                {
                    if (item == null)
                        continue;

                    if (item.ID == ct.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(MonsterTheme mt)
        {
            if (mt == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (MonsterTheme item in lib.Themes)
                {
                    if (item == null)
                        continue;

                    if (item.ID == mt.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (MonsterTheme item in fProject.Library.Themes)
                {
                    if (item == null)
                        continue;

                    if (item.ID == mt.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(Trap t)
        {
            if (t == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (Trap item in lib.Traps)
                {
                    if (item == null)
                        continue;

                    if (item.ID == t.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (Trap item in fProject.Library.Traps)
                {
                    if (item == null)
                        continue;

                    if (item.ID == t.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(SkillChallenge sc)
        {
            if (sc == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (SkillChallenge item in lib.SkillChallenges)
                {
                    if (item == null)
                        continue;

                    if (item.ID == sc.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (SkillChallenge item in fProject.Library.SkillChallenges)
                {
                    if (item == null)
                        continue;

                    if (item.ID == sc.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(MagicItem mi)
        {
            if (mi == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (MagicItem item in lib.MagicItems)
                {
                    if (item == null)
                        continue;

                    if (item.ID == mi.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (MagicItem item in fProject.Library.MagicItems)
                {
                    if (item == null)
                        continue;

                    if (item.ID == mi.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(Artifact a)
        {
            if (a == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (Artifact item in lib.Artifacts)
                {
                    if (item == null)
                        continue;

                    if (item.ID == a.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (Artifact item in fProject.Library.Artifacts)
                {
                    if (item == null)
                        continue;

                    if (item.ID == a.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(Tile t)
        {
            if (t == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (Tile item in lib.Tiles)
                {
                    if (item == null)
                        continue;

                    if (item.ID == t.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (Tile item in fProject.Library.Tiles)
                {
                    if (item == null)
                        continue;

                    if (item.ID == t.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        public static Library FindLibrary(TerrainPower tp)
        {
            if (tp == null)
                return null;

            foreach (Library lib in Libraries)
            {
                foreach (TerrainPower item in lib.TerrainPowers)
                {
                    if (item == null)
                        continue;

                    if (item.ID == tp.ID)
                        return lib;
                }
            }

            if (fProject != null)
            {
                foreach (TerrainPower item in fProject.Library.TerrainPowers)
                {
                    if (item == null)
                        continue;

                    if (item.ID == tp.ID)
                        return fProject.Library;
                }
            }

            return null;
        }

        #endregion

        #region Find item in libraries

        public static ICreature FindCreature(Guid creature_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    Creature creature = lib.FindCreature(creature_id);
                    if (creature != null)
                        return creature;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    Creature creature = Project.Library.FindCreature(creature_id);
                    if (creature != null)
                        return creature;

                    CustomCreature cc = Project.FindCustomCreature(creature_id);
                    if (cc != null)
                        return cc;

                    NPC npc = Project.FindNPC(creature_id);
                    if (npc != null)
                        return npc;
                }
            }

            return null;
        }

        public static CreatureTemplate FindTemplate(Guid template_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    CreatureTemplate template = lib.FindTemplate(template_id);
                    if (template != null)
                        return template;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    CreatureTemplate template = Project.Library.FindTemplate(template_id);
                    if (template != null)
                        return template;
                }
            }

            return null;
        }

        public static MonsterTheme FindTheme(Guid theme_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    MonsterTheme theme = lib.FindTheme(theme_id);
                    if (theme != null)
                        return theme;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    MonsterTheme theme = Project.Library.FindTheme(theme_id);
                    if (theme != null)
                        return theme;
                }
            }

            return null;
        }

        public static Trap FindTrap(Guid trap_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    Trap trap = lib.FindTrap(trap_id);
                    if (trap != null)
                        return trap;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    Trap trap = Project.Library.FindTrap(trap_id);
                    if (trap != null)
                        return trap;
                }
            }

            return null;
        }

        public static SkillChallenge FindSkillChallenge(Guid sc_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    SkillChallenge sc = lib.FindSkillChallenge(sc_id);
                    if (sc != null)
                        return sc;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    SkillChallenge sc = Project.Library.FindSkillChallenge(sc_id);
                    if (sc != null)
                        return sc;
                }
            }

            return null;
        }

        public static MagicItem FindMagicItem(Guid item_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    MagicItem item = lib.FindMagicItem(item_id);
                    if (item != null)
                        return item;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    MagicItem item = Project.Library.FindMagicItem(item_id);
                    if (item != null)
                        return item;
                }
            }

            return null;
        }

        public static Artifact FindArtifact(Guid artifact_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    Artifact item = lib.FindArtifact(artifact_id);
                    if (item != null)
                        return item;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    Artifact item = Project.Library.FindArtifact(artifact_id);
                    if (item != null)
                        return item;
                }
            }

            return null;
        }

        public static Tile FindTile(Guid tile_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    Tile t = lib.FindTile(tile_id);
                    if (t != null)
                        return t;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    Tile t = Project.Library.FindTile(tile_id);
                    if (t != null)
                        return t;
                }
            }

            return null;
        }

        public static TerrainPower FindTerrainPower(Guid power_id, SearchType search_type)
        {
            if ((search_type == SearchType.External) || (search_type == SearchType.Global))
            {
                foreach (Library lib in Libraries)
                {
                    TerrainPower tp = lib.FindTerrainPower(power_id);
                    if (tp != null)
                        return tp;
                }
            }

            if ((search_type == SearchType.Project) || (search_type == SearchType.Global))
            {
                if (Project != null)
                {
                    TerrainPower tp = Project.Library.FindTerrainPower(power_id);
                    if (tp != null)
                        return tp;
                }
            }

            return null;
        }

        #endregion

        #region List all items

        public static List<Creature> Creatures
        {
            get
            {
                List<Creature> list = new List<Creature>();

                foreach (Library lib in Libraries)
                {
                    foreach (Creature item in lib.Creatures)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (Creature item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (Creature item in fProject.Library.Creatures)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<CreatureTemplate> Templates
        {
            get
            {
                List<CreatureTemplate> list = new List<CreatureTemplate>();

                foreach (Library lib in Libraries)
                {
                    foreach (CreatureTemplate item in lib.Templates)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (CreatureTemplate item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (CreatureTemplate item in fProject.Library.Templates)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<MonsterTheme> Themes
        {
            get
            {
                List<MonsterTheme> list = new List<MonsterTheme>();

                foreach (Library lib in Libraries)
                {
                    foreach (MonsterTheme item in lib.Themes)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (MonsterTheme item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (MonsterTheme item in fProject.Library.Themes)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<Trap> Traps
        {
            get
            {
                List<Trap> list = new List<Trap>();

                foreach (Library lib in Libraries)
                {
                    foreach (Trap item in lib.Traps)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (Trap item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (Trap item in fProject.Library.Traps)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<SkillChallenge> SkillChallenges
        {
            get
            {
                List<SkillChallenge> list = new List<SkillChallenge>();

                foreach (Library lib in Libraries)
                    list.AddRange(lib.SkillChallenges);

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (SkillChallenge item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (SkillChallenge item in fProject.Library.SkillChallenges)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<MagicItem> MagicItems
        {
            get
            {
                List<MagicItem> list = new List<MagicItem>();

                foreach (Library lib in Libraries)
                {
                    foreach (MagicItem item in lib.MagicItems)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (MagicItem item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (MagicItem item in fProject.Library.MagicItems)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<Artifact> Artifacts
        {
            get
            {
                List<Artifact> list = new List<Artifact>();

                foreach (Library lib in Libraries)
                {
                    foreach (Artifact item in lib.Artifacts)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (Artifact item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (Artifact item in fProject.Library.Artifacts)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<Tile> Tiles
        {
            get
            {
                List<Tile> list = new List<Tile>();

                foreach (Library lib in Libraries)
                {
                    foreach (Tile item in lib.Tiles)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (Tile item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (Tile item in fProject.Library.Tiles)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        public static List<TerrainPower> TerrainPowers
        {
            get
            {
                List<TerrainPower> list = new List<TerrainPower>();

                foreach (Library lib in Libraries)
                {
                    foreach (TerrainPower item in lib.TerrainPowers)
                    {
                        if (item == null)
                            continue;

                        list.Add(item);
                    }
                }

                if (fProject != null)
                {
                    BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();
                    foreach (TerrainPower item in list)
                    {
                        if (item == null)
                            continue;

                        bst.Add(item.ID);
                    }

                    foreach (TerrainPower item in fProject.Library.TerrainPowers)
                    {
                        if (item == null)
                            continue;

                        if (!bst.Contains(item.ID))
                            list.Add(item);
                    }
                }

                return list;
            }
        }

        #endregion

        //#endregion

        #region Project Backup

        public static void CreateBackup(string filename)
        {
            try
            {
                // The Backup folder beside the exe (AppPaths works in single-file mode too).
                string dir = Tools.AppPaths.AppFolder + "Backup\\";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string new_name = dir + Tools.FileName.Name(filename);
                File.Copy(filename, new_name, true);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        public static Project LoadBackup(string filename)
        {
            Project p = null;

            try
            {
                // Same Backup folder as CreateBackup (AppPaths works in single-file mode too).
                string dir = Tools.AppPaths.AppFolder + "Backup\\";

                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                string backup_name = dir + Tools.FileName.Name(filename);
                if (File.Exists(backup_name))
                {
                    p = LoadProject(backup_name);
                    if (p != null)
                    {
                        string str = "There was a problem opening this project; it has been recovered from its most recent backup version.";
                        MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }

            return p;
        }

        #endregion

        public static int Dice(int throws, int sides)
        {
            int result = 0;

            for (int n = 0; n != throws; ++n)
            {
                int roll = 1 + fRandom.Next() % sides;
                result += roll;
            }

            return result;
        }

        public static bool CheckPassword(Project p)
        {
            if ((p.Password == null) || (p.Password == ""))
                return true;

            PasswordCheckForm dlg = new PasswordCheckForm(p.Password, p.PasswordHint);
            return (dlg.ShowDialog() == DialogResult.OK);
        }

        public static MainForm MainForm
        {
            get { return fMainForm; }
            set { fMainForm = value; }
        }
        static MainForm fMainForm = null;

        public static Encounter CurrentEncounter
        {
            get { return fCurrentEncounter; }
            set { fCurrentEncounter = value; }
        }
        static Encounter fCurrentEncounter = null;

        public static List<string> DisabledLibraries
        {
            get { return fDisabledLibraries; }
            set { fDisabledLibraries = value; }
        }
        static List<string> fDisabledLibraries = new List<string>();
    }
}
