using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Extensibility;
using Masterplan.Tools;
using Masterplan.UI;

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
				Assembly ass = Assembly.GetEntryAssembly();
				return Tools.FileName.Directory(ass.Location) + "Libraries\\";
			}
		}

		public static List<Library> Libraries = new List<Library>();

		public static string GetLibraryFilename(Library lib)
		{
			DirectoryInfo di = new DirectoryInfo(LibraryFolder);

			string filename = Tools.FileName.TrimInvalidCharacters(lib.Name);

			return di + filename + ".library";
		}

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

		public static Library LoadLibrary(string filename)
		{
			try
			{
				if (Program.SplashScreen != null)
				{
					Program.SplashScreen.CurrentSubAction = Tools.FileName.Name(filename);
					Program.SplashScreen.Progress += 1;
				}

				Library lib = Serialisation<Library>.Load(filename, SerialisationMode.Binary);
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

		public static void DeleteLibrary(Library lib)
		{
			// Delete library file
			string filename = Session.GetLibraryFilename(lib);
			FileInfo fi = new FileInfo(filename);
			fi.Delete();

			Session.Libraries.Remove(lib);
		}

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
					//List<Guid> ids = new List<Guid>();
					//foreach (Creature item in list)
					//	ids.Add(item.ID);

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
                    //List<Guid> ids = new List<Guid>();
                    //foreach (CreatureTemplate item in list)
                    //	ids.Add(item.ID);

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
                    //List<Guid> ids = new List<Guid>();
                    //foreach (MonsterTheme item in list)
                    //	ids.Add(item.ID);

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
					//List<Guid> ids = new List<Guid>();
					//foreach (Trap item in list)
					//	ids.Add(item.ID);

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
					//List<Guid> ids = new List<Guid>();
					//foreach (SkillChallenge item in list)
					//	ids.Add(item.ID);

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
					//List<Guid> ids = new List<Guid>();
					//foreach (SkillChallenge item in list)
					//	ids.Add(item.ID);

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
					//List<Guid> ids = new List<Guid>();
					//foreach (SkillChallenge item in list)
					//	ids.Add(item.ID);

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
					//List<Guid> ids = new List<Guid>();
					//foreach (Tile item in list)
					//	ids.Add(item.ID);

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
					//List<Guid> ids = new List<Guid>();
					//foreach (Tile item in list)
					//	ids.Add(item.ID);

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

		#endregion

		#region Project Backup

		public static void CreateBackup(string filename)
		{
			try
			{
				Assembly ass = Assembly.GetEntryAssembly();
				string dir = Tools.FileName.Directory(ass.Location) + "Backup\\";

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
				Assembly ass = Assembly.GetEntryAssembly();
				string dir = Tools.FileName.Directory(ass.Location) + "Backup\\";

				if (!Directory.Exists(dir))
					Directory.CreateDirectory(dir);

				string backup_name = dir + Tools.FileName.Name(filename);
				if (File.Exists(backup_name))
				{
					p = Serialisation<Project>.Load(backup_name, SerialisationMode.Binary);
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
			get { return fMainForm;}
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
