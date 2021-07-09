using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Utils;

using Masterplan.Controls;
using Masterplan.Data;

namespace Masterplan.UI
{
	partial class LibraryListForm : Form
	{
		public LibraryListForm()
		{
			InitializeComponent();

			CreatureSearchToolbar.Visible = false;

			foreach (Library lib in Session.Libraries)
				fModified[lib] = false;

			Application.Idle += new EventHandler(Application_Idle);

			update_libraries();
		}

		#region Properties

		public Library SelectedLibrary
		{
			get
			{
				if (LibraryTree.SelectedNode != null)
					return LibraryTree.SelectedNode.Tag as Library;

				return null;
			}
			set
			{
				List<TreeNode> nodes = new List<TreeNode>();
				foreach (TreeNode tn in LibraryTree.Nodes)
					get_nodes(tn, nodes);

				foreach (TreeNode tn in nodes)
				{
					if (tn.Tag == value)
					{
						LibraryTree.SelectedNode = tn;
						break;
					}
				}
			}
		}

		void get_nodes(TreeNode tn, List<TreeNode> nodes)
		{
			nodes.Add(tn);

			foreach (TreeNode child in tn.Nodes)
				get_nodes(child, nodes);
		}

		public List<Creature> SelectedCreatures
		{
			get
			{
				List<Creature> list = new List<Creature>();

				foreach (ListViewItem lvi in CreatureList.SelectedItems)
				{
					Creature c = lvi.Tag as Creature;
					if (c != null)
						list.Add(c);
				}

				return list;
			}
		}

        public List<CreatureTemplate> SelectedTemplates
        {
            get
            {
                List<CreatureTemplate> list = new List<CreatureTemplate>();

                foreach (ListViewItem lvi in TemplateList.SelectedItems)
                {
                    CreatureTemplate ct = lvi.Tag as CreatureTemplate;
                    if (ct != null)
                        list.Add(ct);
                }

                return list;
            }
        }

        public List<MonsterTheme> SelectedThemes
        {
            get
            {
                List<MonsterTheme> list = new List<MonsterTheme>();

                foreach (ListViewItem lvi in TemplateList.SelectedItems)
                {
                    MonsterTheme mt = lvi.Tag as MonsterTheme;
                    if (mt != null)
                        list.Add(mt);
                }

                return list;
            }
        }

		public List<Trap> SelectedTraps
		{
			get
			{
				List<Trap> list = new List<Trap>();

				foreach (ListViewItem lvi in TrapList.SelectedItems)
				{
					Trap t = lvi.Tag as Trap;
					if (t != null)
						list.Add(t);
				}

				return list;
			}
		}

		public List<SkillChallenge> SelectedChallenges
		{
			get
			{
				List<SkillChallenge> list = new List<SkillChallenge>();

				foreach (ListViewItem lvi in ChallengeList.SelectedItems)
				{
					SkillChallenge sc = lvi.Tag as SkillChallenge;
					if (sc != null)
						list.Add(sc);
				}

				return list;
			}
		}

		public string SelectedMagicItemSet
		{
			get
			{
				if (MagicItemList.SelectedItems.Count != 0)
					return MagicItemList.SelectedItems[0].Text;

				return "";
			}
		}

		public List<MagicItem> SelectedMagicItems
		{
			get
			{
				List<MagicItem> list = new List<MagicItem>();

				foreach (ListViewItem lvi in MagicItemVersionList.SelectedItems)
				{
					MagicItem item = lvi.Tag as MagicItem;
					if (item != null)
						list.Add(item);
				}

				return list;
			}
		}

		public List<Tile> SelectedTiles
		{
			get
			{
				List<Tile> list = new List<Tile>();

				foreach (ListViewItem lvi in TileList.SelectedItems)
				{
					Tile t = lvi.Tag as Tile;
					if (t != null)
						list.Add(t);
				}

				return list;
			}
		}

		public List<TerrainPower> SelectedTerrainPowers
		{
			get
			{
				List<TerrainPower> list = new List<TerrainPower>();

				foreach (ListViewItem lvi in TerrainPowerList.SelectedItems)
				{
					TerrainPower tp = lvi.Tag as TerrainPower;
					if (tp != null)
						list.Add(tp);
				}

				return list;
			}
		}

		public List<Artifact> SelectedArtifacts
		{
			get
			{
				List<Artifact> list = new List<Artifact>();

				foreach (ListViewItem lvi in ArtifactList.SelectedItems)
				{
					Artifact a = lvi.Tag as Artifact;
					if (a != null)
						list.Add(a);
				}

				return list;
			}
		}

		Dictionary<Library, bool> fModified = new Dictionary<Library, bool>();

		List<TabPage> fCleanPages = new List<TabPage>();

		#endregion

		#region Event handlers

		void Application_Idle(object sender, EventArgs e)
		{
			HelpBtn.Text = (HelpPanel.Visible) ? "Hide Help" : "Show Help";

			if ((SelectedLibrary != null) && (Session.Project != null) && (SelectedLibrary == Session.Project.Library))
			{
				LibraryRemoveBtn.Enabled = false;
				LibraryEditBtn.Enabled = false;

				CreatureAddBtn.Enabled = false;
				OppRemoveBtn.Enabled = false;
				OppEditBtn.Enabled = false;
				CreatureCopyBtn.Enabled = (SelectedCreatures.Count != 0);
				CreatureCutBtn.Enabled = false;
				CreaturePasteBtn.Enabled = false;
				CreatureStatBlockBtn.Enabled = (SelectedCreatures.Count == 1);
				CreatureToolsExport.Enabled = (SelectedCreatures.Count == 1);

				TemplateAddBtn.Enabled = false;
				TemplateRemoveBtn.Enabled = false;
				TemplateEditBtn.Enabled = false;
				TemplateCopyBtn.Enabled = (SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0);
				TemplateCutBtn.Enabled = false;
				TemplatePasteBtn.Enabled = false;
				TemplateStatBlock.Enabled = (SelectedTemplates.Count == 1) || (SelectedThemes.Count == 1);
				TemplateToolsExport.Enabled = (SelectedTemplates.Count == 1) || (SelectedThemes.Count == 1);

				TrapAdd.Enabled = false;
				TrapRemoveBtn.Enabled = false;
				TrapEditBtn.Enabled = false;
				TrapCopyBtn.Enabled = (SelectedTraps.Count != 0);
				TrapCutBtn.Enabled = false;
				TrapPasteBtn.Enabled = false;
				TrapStatBlockBtn.Enabled = (SelectedTraps.Count == 1);
				TrapToolsExport.Enabled = (SelectedTraps.Count == 1);

				ChallengeAdd.Enabled = false;
				ChallengeRemoveBtn.Enabled = false;
				ChallengeEditBtn.Enabled = false;
				ChallengeCopyBtn.Enabled = (SelectedChallenges.Count != 0);
				ChallengeCutBtn.Enabled = false;
				ChallengePasteBtn.Enabled = false;
				ChallengeStatBlockBtn.Enabled = (SelectedChallenges.Count == 1);
				ChallengeToolsExport.Enabled = (SelectedChallenges.Count == 1);

				MagicItemAdd.Enabled = false;
				MagicItemRemoveBtn.Enabled = false;
				MagicItemEditBtn.Enabled = false;
				MagicItemCopyBtn.Enabled = (SelectedMagicItems.Count != 0);
				MagicItemCutBtn.Enabled = false;
				MagicItemPasteBtn.Enabled = false;
				MagicItemStatBlockBtn.Enabled = (SelectedMagicItems.Count == 1);
				MagicItemToolsExport.Enabled = (SelectedMagicItemSet != "");

				TileAddBtn.Enabled = false;
				TileRemoveBtn.Enabled = false;
				TileEditBtn.Enabled = false;
				TileCopyBtn.Enabled = (SelectedTiles.Count != 0);
				TileCutBtn.Enabled = false;
				TilePasteBtn.Enabled = false;
				TileToolsExport.Enabled = (SelectedTiles.Count == 1);

				TPAdd.Enabled = false;
				TPRemoveBtn.Enabled = false;
				TPEditBtn.Enabled = false;
				TPCopyBtn.Enabled = (SelectedTerrainPowers.Count != 0);
				TPCutBtn.Enabled = false;
				TPPasteBtn.Enabled = false;
				TPStatBlockBtn.Enabled = (SelectedTerrainPowers.Count == 1);
				TPToolsExport.Enabled = (SelectedTerrainPowers.Count == 1);

				ArtifactAdd.Enabled = false;
				ArtifactRemove.Enabled = false;
				ArtifactEdit.Enabled = false;
				ArtifactCopy.Enabled = (SelectedArtifacts.Count != 0);
				ArtifactCut.Enabled = false;
				ArtifactPaste.Enabled = false;
				ArtifactStatBlockBtn.Enabled = (SelectedArtifacts.Count == 1);
				ArtifactToolsExport.Enabled = (SelectedArtifacts.Count == 1);
			}
			else
			{
				LibraryRemoveBtn.Enabled = (SelectedLibrary != null);
				LibraryEditBtn.Enabled = (SelectedLibrary != null);

				CreatureAddBtn.Enabled = (SelectedLibrary != null);
				OppRemoveBtn.Enabled = (SelectedCreatures.Count != 0);
				OppEditBtn.Enabled = (SelectedCreatures.Count == 1);
				CreatureCopyBtn.Enabled = (SelectedCreatures.Count != 0);
				CreatureCutBtn.Enabled = (SelectedCreatures.Count != 0);
				CreaturePasteBtn.Enabled = ((SelectedLibrary != null) && Clipboard.ContainsData(typeof(List<Creature>).ToString()));
				CreatureStatBlockBtn.Enabled = (SelectedCreatures.Count == 1);
				CreatureToolsExport.Enabled = (SelectedCreatures.Count == 1);

				TemplateAddBtn.Enabled = (SelectedLibrary != null);
				TemplateRemoveBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplateEditBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplateCopyBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplateCutBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplatePasteBtn.Enabled = ((SelectedLibrary != null) && ((Clipboard.ContainsData(typeof(List<CreatureTemplate>).ToString())) || (Clipboard.ContainsData(typeof(List<MonsterTheme>).ToString()))));
				TemplateStatBlock.Enabled = (SelectedTemplates.Count == 1);
				TemplateToolsExport.Enabled = (SelectedTemplates.Count == 1) || (SelectedThemes.Count == 1);

				TrapAdd.Enabled = (SelectedLibrary != null);
				TrapRemoveBtn.Enabled = (SelectedTraps.Count != 0);
				TrapEditBtn.Enabled = (SelectedTraps.Count == 1);
				TrapCopyBtn.Enabled = (SelectedTraps.Count != 0);
				TrapCutBtn.Enabled = (SelectedTraps.Count != 0);
				TrapPasteBtn.Enabled = ((SelectedLibrary != null) && Clipboard.ContainsData(typeof(List<Trap>).ToString()));
				TrapStatBlockBtn.Enabled = (SelectedTraps.Count == 1);
				TrapToolsExport.Enabled = (SelectedTraps.Count == 1);

				ChallengeAdd.Enabled = (SelectedLibrary != null);
				ChallengeRemoveBtn.Enabled = (SelectedChallenges.Count != 0);
				ChallengeEditBtn.Enabled = (SelectedChallenges.Count == 1);
				ChallengeCopyBtn.Enabled = (SelectedChallenges.Count != 0);
				ChallengeCutBtn.Enabled = (SelectedChallenges.Count != 0);
				ChallengePasteBtn.Enabled = ((SelectedLibrary != null) && Clipboard.ContainsData(typeof(List<SkillChallenge>).ToString()));
				ChallengeStatBlockBtn.Enabled = (SelectedChallenges.Count == 1);
				ChallengeToolsExport.Enabled = (SelectedChallenges.Count == 1);

				MagicItemAdd.Enabled = (SelectedLibrary != null);
				MagicItemRemoveBtn.Enabled = (SelectedMagicItems.Count != 0);
				MagicItemEditBtn.Enabled = (SelectedMagicItems.Count == 1);
				MagicItemCopyBtn.Enabled = (SelectedMagicItems.Count != 0);
				MagicItemCutBtn.Enabled = (SelectedMagicItems.Count != 0);
				MagicItemPasteBtn.Enabled = ((SelectedLibrary != null) && Clipboard.ContainsData(typeof(List<MagicItem>).ToString()));
				MagicItemStatBlockBtn.Enabled = (SelectedMagicItems.Count == 1);
				MagicItemToolsExport.Enabled = (SelectedMagicItemSet != "");

				TileAddBtn.Enabled = (SelectedLibrary != null);
				TileRemoveBtn.Enabled = (SelectedTiles.Count != 0);
				TileEditBtn.Enabled = (SelectedTiles.Count == 1);
				TileCopyBtn.Enabled = (SelectedTiles.Count != 0);
				TileCutBtn.Enabled = (SelectedTiles.Count != 0);
				TilePasteBtn.Enabled = ((SelectedLibrary != null) && Clipboard.ContainsData(typeof(List<Tile>).ToString()));
				TileToolsExport.Enabled = (SelectedTiles.Count == 1);

				TPAdd.Enabled = (SelectedLibrary != null);
				TPRemoveBtn.Enabled = (SelectedTerrainPowers.Count != 0);
				TPEditBtn.Enabled = (SelectedTerrainPowers.Count == 1);
				TPCopyBtn.Enabled = (SelectedTerrainPowers.Count != 0);
				TPCutBtn.Enabled = (SelectedTerrainPowers.Count != 0);
				TPPasteBtn.Enabled = ((SelectedLibrary != null) && Clipboard.ContainsData(typeof(List<TerrainPower>).ToString()));
				TPStatBlockBtn.Enabled = (SelectedTerrainPowers.Count == 1);
				TPToolsExport.Enabled = (SelectedTerrainPowers.Count == 1);

				ArtifactAdd.Enabled = (SelectedLibrary != null);
				ArtifactRemove.Enabled = (SelectedArtifacts.Count != 0);
				ArtifactEdit.Enabled = (SelectedArtifacts.Count == 1);
				ArtifactCopy.Enabled = (SelectedArtifacts.Count != 0);
				ArtifactCut.Enabled = (SelectedArtifacts.Count != 0);
				ArtifactPaste.Enabled = ((SelectedLibrary != null) && Clipboard.ContainsData(typeof(List<Artifact>).ToString()));
				ArtifactStatBlockBtn.Enabled = (SelectedArtifacts.Count == 1);
				ArtifactToolsExport.Enabled = (SelectedArtifacts.Count == 1);
			}

			CreatureToolsFilterList.Checked = CreatureSearchToolbar.Visible;
			CategorisedBtn.Checked = fShowCategorised;
			UncategorisedBtn.Checked = fShowUncategorised;

			CreatureContextRemove.Enabled = (SelectedCreatures.Count != 0);
			CreatureContextCategory.Enabled = (SelectedCreatures.Count != 0);

			TemplateContextRemove.Enabled = (SelectedTemplates.Count != 0);
			TemplateContextType.Enabled = (SelectedTemplates.Count != 0);

			TrapContextRemove.Enabled = (SelectedTraps.Count != 0);
			TrapContextType.Enabled = (SelectedTraps.Count != 0);

			ChallengeContextRemove.Enabled = (SelectedChallenges.Count != 0);

			MagicItemContextRemove.Enabled = (SelectedMagicItems.Count != 0);

			TileContextRemove.Enabled = (SelectedTiles.Count != 0);
			TileContextCategory.Enabled = (SelectedTiles.Count != 0);
			TileContextSize.Enabled = (SelectedTiles.Count != 0);

			TPContextRemove.Enabled = (SelectedTerrainPowers.Count != 0);

			ArtifactContextRemove.Enabled = (SelectedArtifacts.Count != 0);
		}

		private void LibrariesForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			foreach (Library lib in Session.Libraries)
			{
				if ((fModified.ContainsKey(lib)) && (!fModified[lib]))
					continue;

				save(lib);
			}
		}

		private void FileNew_Click(object sender, EventArgs e)
		{
			Library lib = new Library();
			lib.Name = "New Library";

			LibraryForm dlg = new LibraryForm(lib);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Libraries.Add(dlg.Library);
				Session.Libraries.Sort();

				save(dlg.Library);
				fModified[dlg.Library] = true;

				update_libraries();

				SelectedLibrary = dlg.Library;
				update_content(true);
			}
		}

		private void FileOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.LibraryFilter;
			dlg.Multiselect = true;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				// If any are not in the Libraries folder, offer to copy them

				string lib_folder = Session.LibraryFolder;

				List<string> foreign_files = new List<string>();
				foreach (string filename in dlg.FileNames)
				{
					string dir = FileName.Directory(filename);
					if (!dir.Contains(lib_folder))
						foreign_files.Add(filename);
				}
				if (foreign_files.Count != 0)
				{
					string msg = "Do you want to move these libraries into the Libraries folder?";
					msg += Environment.NewLine;
					msg += "They will then be loaded automatically the next time Masterplan starts up.";

					DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.Yes)
					{
						foreach (string filename in foreign_files)
						{
							string new_filename = lib_folder + FileName.Name(filename) + ".library";
							File.Copy(filename, new_filename);
						}
					}
				}

				foreach (string filename in dlg.FileNames)
				{
					if (foreign_files.Contains(filename))
						continue;

					Library lib = Session.LoadLibrary(filename);
					fModified[lib] = false;
				}

				foreach (string filename in foreign_files)
				{
					Library lib = Session.LoadLibrary(filename);
					fModified[lib] = false;
				}

				if (Session.Project != null)
					Session.Project.SimplifyProjectLibrary();

				Session.Libraries.Sort();
				update_libraries();
				update_content(true);
			}
		}

		private void FileClose_Click(object sender, EventArgs e)
		{
			if (Session.Project != null)
				Session.Project.PopulateProjectLibrary();

			foreach (Library lib in Session.Libraries)
			{
				lib.Creatures.Clear();
				lib.Templates.Clear();
				lib.Themes.Clear();
				lib.Traps.Clear();
				lib.SkillChallenges.Clear();
				lib.MagicItems.Clear();
				lib.Tiles.Clear();
				lib.TerrainPowers.Clear();
				lib.Artifacts.Clear();
			}

			Session.Libraries.Clear();

			if (Session.Project != null)
				Session.Project.SimplifyProjectLibrary();

			update_libraries();
			update_content(true);

			GC.Collect();
		}

		private void LibraryRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				string str = "You are about to delete a library; are you sure you want to do this?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				Session.DeleteLibrary(SelectedLibrary);
				update_libraries();

				SelectedLibrary = null;
				update_content(true);
			}
		}

		private void LibraryEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				int index = Session.Libraries.IndexOf(SelectedLibrary);
				string old_filename = Session.GetLibraryFilename(SelectedLibrary);

				if (!File.Exists(old_filename))
				{
					string str = "This library cannot be renamed.";
					MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);

					return;
				}

				LibraryForm dlg = new LibraryForm(SelectedLibrary);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Libraries[index] = dlg.Library;
					Session.Libraries.Sort();

					// Has the name changed?
					string new_filename = Session.GetLibraryFilename(dlg.Library);
					if (old_filename != new_filename)
					{
						// Move the file
						FileInfo fi = new FileInfo(old_filename);
						fi.MoveTo(new_filename);
					}

					fModified[dlg.Library] = true;

					update_libraries();
					update_content(true);
				}
			}
		}

		private void LibraryMergeBtn_Click(object sender, EventArgs e)
		{
			MergeLibrariesForm dlg = new MergeLibrariesForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Library newlib = new Library();
				newlib.Name = dlg.LibraryName;

				foreach (Library lib in dlg.SelectedLibraries)
				{
					newlib.Import(lib);
					Session.DeleteLibrary(lib);
				}

				Session.Libraries.Add(newlib);
				Session.Libraries.Sort();

				save(newlib);
				update_libraries();

				SelectedLibrary = newlib;
				update_content(true);
			}
		}

		private void LibraryTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			update_content(true);
		}

		private void LibraryList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			Library lib = SelectedLibrary;
			if (lib == null)
				return;

			if ((Session.Project != null) && (Session.Project.Library == lib))
				return;

			DoDragDrop(lib, DragDropEffects.Move);
		}

		private void HelpBtn_Click(object sender, EventArgs e)
		{
			show_help(!HelpPanel.Visible);
		}

		private void Pages_SelectedIndexChanged(object sender, EventArgs e)
		{
			update_content(false);
		}

		#endregion

		#region Drag and drop

		private void LibraryList_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.None;

			// What library are we over?
			Point mouse = LibraryTree.PointToClient(Cursor.Position);
			TreeNode tn = LibraryTree.GetNodeAt(mouse);
			LibraryTree.SelectedNode = tn;

			if (SelectedLibrary == null)
				return;

			// Can't add to the project library
			if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
				return;

			// Only allow the move if it's not already in this library

			Library lib = e.Data.GetData(typeof(Library)) as Library;
			if (lib != null)
			{
				if (lib != SelectedLibrary)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<Creature> creatures = e.Data.GetData(typeof(List<Creature>)) as List<Creature>;
			if (creatures != null)
			{
				bool ok = false;
				foreach (Creature c in creatures)
				{
					if (!SelectedLibrary.Creatures.Contains(c))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<CreatureTemplate> templates = e.Data.GetData(typeof(List<CreatureTemplate>)) as List<CreatureTemplate>;
			if (templates != null)
			{
				bool ok = false;
				foreach (CreatureTemplate ct in templates)
				{
					if (!SelectedLibrary.Templates.Contains(ct))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<Trap> traps = e.Data.GetData(typeof(List<Trap>)) as List<Trap>;
			if (traps != null)
			{
				bool ok = false;
				foreach (Trap t in traps)
				{
					if (!SelectedLibrary.Traps.Contains(t))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<SkillChallenge> challenges = e.Data.GetData(typeof(List<SkillChallenge>)) as List<SkillChallenge>;
			if (challenges != null)
			{
				bool ok = false;
				foreach (SkillChallenge sc in challenges)
				{
					if (!SelectedLibrary.SkillChallenges.Contains(sc))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<MagicItem> magic_items = e.Data.GetData(typeof(List<MagicItem>)) as List<MagicItem>;
			if (challenges != null)
			{
				bool ok = false;
				foreach (MagicItem mi in magic_items)
				{
					if (!SelectedLibrary.MagicItems.Contains(mi))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<Tile> tiles = e.Data.GetData(typeof(List<Tile>)) as List<Tile>;
			if (tiles != null)
			{
				bool ok = false;
				foreach (Tile t in tiles)
				{
					if (!SelectedLibrary.Tiles.Contains(t))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<TerrainPower> terrainpowers = e.Data.GetData(typeof(List<TerrainPower>)) as List<TerrainPower>;
			if (terrainpowers != null)
			{
				bool ok = false;
				foreach (TerrainPower tp in terrainpowers)
				{
					if (!SelectedLibrary.TerrainPowers.Contains(tp))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			List<Artifact> artifacts = e.Data.GetData(typeof(List<Artifact>)) as List<Artifact>;
			if (artifacts != null)
			{
				bool ok = false;
				foreach (Artifact a in artifacts)
				{
					if (!SelectedLibrary.Artifacts.Contains(a))
					{
						ok = true;
						break;
					}
				}

				if (ok)
					e.Effect = DragDropEffects.Move;

				return;
			}

			return;
		}

		private void LibraryList_DragDrop(object sender, DragEventArgs e)
		{
			// What library are we over?
			Point mouse = LibraryTree.PointToClient(Cursor.Position);
			TreeNode tn = LibraryTree.GetNodeAt(mouse);
			LibraryTree.SelectedNode = tn;

			if (SelectedLibrary == null)
				return;

			Library dragged_lib = e.Data.GetData(typeof(Library)) as Library;
			if (dragged_lib != null)
			{
				SelectedLibrary.Import(dragged_lib);

				fModified[SelectedLibrary] = true;

				Session.DeleteLibrary(dragged_lib);

				update_content(true);
			}

			List<Creature> creatures = e.Data.GetData(typeof(List<Creature>)) as List<Creature>;
			if (creatures != null)
			{
				foreach (Creature c in creatures)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.Creatures.Contains(c))
						{
							lib.Creatures.Remove(c);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.Creatures.Add(c);
					fModified[SelectedLibrary] = true;
				}

				update_creatures();
			}

			List<CreatureTemplate> templates = e.Data.GetData(typeof(List<CreatureTemplate>)) as List<CreatureTemplate>;
			if (templates != null)
			{
				foreach (CreatureTemplate ct in templates)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.Templates.Contains(ct))
						{
							lib.Templates.Remove(ct);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.Templates.Add(ct);
					fModified[SelectedLibrary] = true;
				}

				update_templates();
			}

			List<Trap> traps = e.Data.GetData(typeof(List<Trap>)) as List<Trap>;
			if (traps != null)
			{
				foreach (Trap t in traps)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.Traps.Contains(t))
						{
							lib.Traps.Remove(t);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.Traps.Add(t);
					fModified[SelectedLibrary] = true;
				}

				update_traps();
			}

			List<SkillChallenge> challenges = e.Data.GetData(typeof(List<SkillChallenge>)) as List<SkillChallenge>;
			if (challenges != null)
			{
				foreach (SkillChallenge sc in challenges)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.SkillChallenges.Contains(sc))
						{
							lib.SkillChallenges.Remove(sc);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.SkillChallenges.Add(sc);
					fModified[SelectedLibrary] = true;
				}

				update_challenges();
			}

			List<MagicItem> magic_items = e.Data.GetData(typeof(List<MagicItem>)) as List<MagicItem>;
			if (magic_items != null)
			{
				foreach (MagicItem sc in magic_items)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.MagicItems.Contains(sc))
						{
							lib.MagicItems.Remove(sc);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.MagicItems.Add(sc);
					fModified[SelectedLibrary] = true;
				}

				update_magic_item_sets();
			}

			List<Tile> tiles = e.Data.GetData(typeof(List<Tile>)) as List<Tile>;
			if (tiles != null)
			{
				foreach (Tile t in tiles)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.Tiles.Contains(t))
						{
							lib.Tiles.Remove(t);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.Tiles.Add(t);
					fModified[SelectedLibrary] = true;
				}

				update_tiles();
			}

			List<TerrainPower> terrainpowers = e.Data.GetData(typeof(List<TerrainPower>)) as List<TerrainPower>;
			if (terrainpowers != null)
			{
				foreach (TerrainPower tp in terrainpowers)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.TerrainPowers.Contains(tp))
						{
							lib.TerrainPowers.Remove(tp);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.TerrainPowers.Add(tp);
					fModified[SelectedLibrary] = true;
				}

				update_terrain_powers();
			}

			List<Artifact> artifacts = e.Data.GetData(typeof(List<Artifact>)) as List<Artifact>;
			if (artifacts != null)
			{
				foreach (Artifact a in artifacts)
				{
					// Remove from the source library
					foreach (Library lib in Session.Libraries)
					{
						if (lib.Artifacts.Contains(a))
						{
							lib.Artifacts.Remove(a);
							fModified[lib] = true;
						}
					}

					// Add it to the new book
					SelectedLibrary.Artifacts.Add(a);
					fModified[SelectedLibrary] = true;
				}

				update_artifacts();
			}
		}

		#endregion

		#region Creatures page

		bool fShowCategorised = true;
		bool fShowUncategorised = true;

		private void CreatureAddBtn_Click(object sender, EventArgs e)
		{
			Creature c = new Creature();
			c.Name = "New Creature";

			CreatureBuilderForm dlg = new CreatureBuilderForm(c);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.Creatures.Add(dlg.Creature as Creature);
				fModified[SelectedLibrary] = true;

				update_content(true);
			}
		}

		private void CreatureImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.CreatureFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						Creature c = null;
						if (filename.EndsWith("creature"))
						{
							c = Serialisation<Creature>.Load(filename, SerialisationMode.Binary);
						}

						if (c != null)
						{
							Creature previous = SelectedLibrary.FindCreature(c.Name, c.Level);
							if (previous != null)
							{
								c.ID = previous.ID;
								c.Category = previous.Category;

								SelectedLibrary.Creatures.Remove(previous);
							}

							SelectedLibrary.Creatures.Add(c);
							fModified[SelectedLibrary] = true;

							update_content(true);
						}
					}
				}
			}
		}

		private void OppRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCreatures.Count != 0)
			{
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (Creature c in SelectedCreatures)
				{
					Library lib = SelectedLibrary;
					if (lib == null)
						lib = Session.FindLibrary(c);

					lib.Creatures.Remove(c);
					fModified[lib] = true;
				}

                update_content(true);
			}
		}

		private void OppEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCreatures.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedCreatures[0]);
				if (lib == null)
					return;

				int index = lib.Creatures.IndexOf(SelectedCreatures[0]);

				CreatureBuilderForm dlg = new CreatureBuilderForm(SelectedCreatures[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.Creatures[index] = dlg.Creature as Creature;
					fModified[lib] = true;

                    update_content(true);
				}
			}
		}

		private void CreatureCutBtn_Click(object sender, EventArgs e)
		{
			CreatureCopyBtn_Click(sender, e);
			OppRemoveBtn_Click(sender, e);
		}

		private void CreatureCopyBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCreatures.Count != 0)
			{
				Clipboard.SetData(typeof(List<Creature>).ToString(), SelectedCreatures);
			}
		}

		private void CreaturePasteBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

			if (Clipboard.ContainsData(typeof(List<Creature>).ToString()))
			{
				List<Creature> creatures = Clipboard.GetData(typeof(List<Creature>).ToString()) as List<Creature>;
				foreach (Creature c in creatures)
				{
					// Make a copy with a new ID
					Creature creature = c.Copy();
					creature.ID = Guid.NewGuid();

					SelectedLibrary.Creatures.Add(creature);
					fModified[SelectedLibrary] = true;
				}

                update_content(true);
			}
		}

		private void CreatureStatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCreatures.Count != 1)
				return;

			EncounterCard card = new EncounterCard();
			card.CreatureID = SelectedCreatures[0].ID;

			CreatureDetailsForm dlg = new CreatureDetailsForm(card);
			dlg.ShowDialog();
		}

		private void CreatureDemoBtn_Click(object sender, EventArgs e)
		{
			try
			{
				DemographicsForm dlg = new DemographicsForm(SelectedLibrary, DemographicsSource.Creatures);
				dlg.ShowDialog();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PowerStatsBtn_Click(object sender, EventArgs e)
		{
			List<CreaturePower> powers = new List<CreaturePower>();
			int creatures = 0;

			if (SelectedLibrary == null)
			{
				foreach (Library lib in Session.Libraries)
				{
					creatures += lib.Creatures.Count;

					foreach (Creature creature in lib.Creatures)
						powers.AddRange(creature.CreaturePowers);
				}
			}
			else
			{
				creatures = SelectedLibrary.Creatures.Count;

				foreach (ICreature creature in SelectedLibrary.Creatures)
				{
					if (creature != null)
						powers.AddRange(creature.CreaturePowers);
				}

				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
				{
					creatures += Session.Project.CustomCreatures.Count;
					foreach (ICreature creature in Session.Project.CustomCreatures)
					{
						if (creature != null)
							powers.AddRange(creature.CreaturePowers);
					}
				}
			}

			PowerStatisticsForm dlg = new PowerStatisticsForm(powers, creatures);
			dlg.ShowDialog();
		}

		private void FilterBtn_Click(object sender, EventArgs e)
		{
			CreatureSearchToolbar.Visible = !CreatureSearchToolbar.Visible;
			update_content(true);
		}

		private void CreatureToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedCreatures.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.CreatureFilter;
				dlg.FileName = SelectedCreatures[0].Name;

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<Creature>.Save(dlg.FileName, SelectedCreatures[0], SerialisationMode.Binary);
			}
		}

		private void SearchBox_TextChanged(object sender, EventArgs e)
		{
			update_content(true);
		}

		private void CreatureFilterCategorised_Click(object sender, EventArgs e)
		{
			fShowCategorised = !fShowCategorised;

			update_content(true);
		}

		private void CreatureFilterUncategorised_Click(object sender, EventArgs e)
		{
			fShowUncategorised = !fShowUncategorised;

			update_content(true);
		}

		private void OppList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedCreatures.Count != 0)
				DoDragDrop(SelectedCreatures, DragDropEffects.Move);
		}

		private void CreatureContextRemove_Click(object sender, EventArgs e)
		{
			OppRemoveBtn_Click(sender, e);
		}

		private void CreatureContextCategory_Click(object sender, EventArgs e)
		{
			List<string> cats = new List<string>();
			foreach (Creature c in Session.Creatures)
			{
				if ((c.Category == null) || (c.Category == ""))
					continue;

				if (cats.Contains(c.Category))
					continue;

				cats.Add(c.Category);
			}

			List<string> selected_cats = new List<string>();
			foreach (Creature c in SelectedCreatures)
			{
				if ((c.Category == null) || (c.Category == ""))
					continue;

				if (selected_cats.Contains(c.Category))
					continue;

				selected_cats.Add(c.Category);
			}

			string selected = "";
			if (selected_cats.Count == 1)
			{
				selected = selected_cats[0];
			}
			if (selected_cats.Count == 0)
			{
				if (SelectedCreatures.Count == 1)
				{
					selected = SelectedCreatures[0].Name;
				}
				else
				{
					const int MIN_NAME_LENGTH = 3;
					Dictionary<string, int> suggestions = new Dictionary<string, int>();

					for (int x = 0; x != SelectedCreatures.Count; ++x)
					{
						string name_x = SelectedCreatures[x].Name;

						for (int y = x + 1; y != SelectedCreatures.Count; ++y)
						{
							string name_y = SelectedCreatures[y].Name;

							string lcs = StringHelper.LongestCommonToken(name_x, name_y);
							if (lcs.Length >= MIN_NAME_LENGTH)
							{
								if (!suggestions.ContainsKey(lcs))
									suggestions[lcs] = 0;

								suggestions[lcs] += 1;
							}
						}
					}

					if (suggestions.Keys.Count != 0)
					{
						foreach (string token in suggestions.Keys)
						{
							int current = (suggestions.ContainsKey(selected)) ? suggestions[selected] : 0;
							if (suggestions[token] > current)
								selected = token;
						}

						if (!cats.Contains(selected))
							cats.Add(selected);
					}
				}
			}

			CategoryForm dlg = new CategoryForm(cats, selected);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				foreach (Creature c in SelectedCreatures)
				{
					c.Category = dlg.Category;

					Library lib = Session.FindLibrary(c);
					if (lib != null)
						fModified[lib] = true;
				}

				update_creatures();
			}
		}

		void update_creatures()
		{
			Cursor.Current = Cursors.WaitCursor;

			CreatureList.BeginUpdate();
			ListState state = ListState.GetState(CreatureList);

			List<Creature> creatures = new List<Creature>();
			if (SelectedLibrary != null)
			{
				creatures.AddRange(SelectedLibrary.Creatures);

				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
				{
					// Add all project custom creatures
					foreach (CustomCreature cc in Session.Project.CustomCreatures)
					{
						Creature c = new Creature(cc);
						creatures.Add(c);
					}

					// Add all project NPCs
					foreach (NPC npc in Session.Project.NPCs)
					{
						Creature c = new Creature(npc);
						creatures.Add(c);
					}
				}
			}
			else
			{
				creatures.AddRange(Session.Creatures);
			}

			BinarySearchTree<string> categories = new BinarySearchTree<string>();
			foreach (Creature c in creatures)
			{
				if (c == null)
					continue;

				if (c.Category != "")
					categories.Add(c.Category);
			}

			List<string> cats = categories.SortedList;
			cats.Insert(0, "Custom Creatures");
			cats.Insert(1, "NPCs");
			cats.Add("Miscellaneous Creatures");

			CreatureList.Groups.Clear();
			foreach (string cat in cats)
				CreatureList.Groups.Add(cat, cat);
			CreatureList.ShowGroups = true;

			List<ListViewItem> list_items = new List<ListViewItem>();

			foreach (Creature c in creatures)
			{
				if (c == null)
					continue;

				if (CreatureSearchToolbar.Visible)
				{
					if (SearchBox.Text != "")
					{
						string search = SearchBox.Text.ToLower();
						bool matched = c.Name.ToLower().Contains(search);

						if (!matched && (c.Category != null) && c.Category.ToLower().Contains(search))
							matched = true;

						if (!matched)
							continue;
					}

					bool show = false;
					bool categorised = ((c.Category != null) && (c.Category != ""));

					if (fShowCategorised && categorised)
						show = true;
					if (fShowUncategorised && !categorised)
						show = true;

					if (!show)
						continue;
				}

				ListViewItem lvi = new ListViewItem(c.Name);
				lvi.SubItems.Add(c.Info);
				lvi.Tag = c;

				if (c.Category != "")
					lvi.Group = CreatureList.Groups[c.Category];
				else
					lvi.Group = CreatureList.Groups["Miscellaneous Creatures"];

				list_items.Add(lvi);
			}

			CreatureList.Items.Clear();
			CreatureList.Items.AddRange(list_items.ToArray());

			if (CreatureList.Items.Count == 0)
			{
				CreatureList.ShowGroups = false;

				ListViewItem lvi = CreatureList.Items.Add("(no creatures)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			CreatureList.Sort();

			ListState.SetState(CreatureList, state);
			CreatureList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Templates page

		private void TemplateAddBtn_Click(object sender, EventArgs e)
		{
			CreatureTemplate ct = new CreatureTemplate();
			ct.Name = "New Template";

			CreatureTemplateBuilderForm dlg = new CreatureTemplateBuilderForm(ct);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.Templates.Add(dlg.Template);
				fModified[SelectedLibrary] = true;

                update_content(true);
			}
		}

        private void TemplateAddTheme_Click(object sender, EventArgs e)
        {
            MonsterTheme mt = new MonsterTheme();
            mt.Name = "New Theme";

            MonsterThemeForm dlg = new MonsterThemeForm(mt);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SelectedLibrary.Themes.Add(dlg.Theme);
                fModified[SelectedLibrary] = true;

                update_content(true);
            }
        }

		private void TemplateImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.CreatureTemplateAndThemeFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						if (filename.EndsWith("creaturetemplate"))
						{
							CreatureTemplate ct = Serialisation<CreatureTemplate>.Load(filename, SerialisationMode.Binary);
							if (ct != null)
							{
								SelectedLibrary.Templates.Add(ct);
								fModified[SelectedLibrary] = true;

								update_content(true);
							}
						}

						if (filename.EndsWith("theme"))
						{
							MonsterTheme theme = Serialisation<MonsterTheme>.Load(filename, SerialisationMode.Binary);
							if (theme != null)
							{
								SelectedLibrary.Themes.Add(theme);
								fModified[SelectedLibrary] = true;

								update_content(true);
							}
						}
					}
				}
			}
		}

		private void TemplateRemoveBtn_Click(object sender, EventArgs e)
		{
            if (SelectedTemplates.Count != 0)
            {
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (CreatureTemplate ct in SelectedTemplates)
                {
                    Library lib = SelectedLibrary;
                    if (lib == null)
                        lib = Session.FindLibrary(ct);

                    lib.Templates.Remove(ct);
                    fModified[lib] = true;
                }

                update_content(true);
            }

            if (SelectedThemes.Count != 0)
            {
                foreach (MonsterTheme mt in SelectedThemes)
                {
                    Library lib = SelectedLibrary;
                    if (lib == null)
                        lib = Session.FindLibrary(mt);

                    lib.Themes.Remove(mt);
                    fModified[lib] = true;
                }

                update_content(true);
            }
        }

		private void TemplateEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTemplates.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedTemplates[0]);
				if (lib == null)
					return;

				int index = lib.Templates.IndexOf(SelectedTemplates[0]);

				CreatureTemplateBuilderForm dlg = new CreatureTemplateBuilderForm(SelectedTemplates[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.Templates[index] = dlg.Template;
					fModified[lib] = true;

                    update_content(true);
				}
			}

            if (SelectedThemes.Count == 1)
            {
                Library lib = Session.FindLibrary(SelectedThemes[0]);
                if (lib == null)
                    return;

                int index = lib.Themes.IndexOf(SelectedThemes[0]);

                MonsterThemeForm dlg = new MonsterThemeForm(SelectedThemes[0]);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lib.Themes[index] = dlg.Theme;
                    fModified[lib] = true;

                    update_content(true);
                }
            }
		}

		private void TemplateCutBtn_Click(object sender, EventArgs e)
		{
			TemplateCopyBtn_Click(sender, e);
			TemplateRemoveBtn_Click(sender, e);
		}

		private void TemplateCopyBtn_Click(object sender, EventArgs e)
		{
            if (SelectedTemplates.Count != 0)
            {
                Clipboard.SetData(typeof(List<CreatureTemplate>).ToString(), SelectedTemplates);
            }

            if (SelectedThemes.Count != 0)
            {
                Clipboard.SetData(typeof(List<MonsterTheme>).ToString(), SelectedThemes);
            }
        }

		private void TemplatePasteBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

            if (Clipboard.ContainsData(typeof(List<CreatureTemplate>).ToString()))
            {
                List<CreatureTemplate> templates = Clipboard.GetData(typeof(List<CreatureTemplate>).ToString()) as List<CreatureTemplate>;
                foreach (CreatureTemplate ct in templates)
                {
                    // Make a copy with a new ID
                    CreatureTemplate template = ct.Copy();
                    template.ID = Guid.NewGuid();

                    SelectedLibrary.Templates.Add(template);
                    fModified[SelectedLibrary] = true;
                }

                update_content(true);
            }

            if (Clipboard.ContainsData(typeof(List<MonsterTheme>).ToString()))
            {
                List<MonsterTheme> themes = Clipboard.GetData(typeof(List<MonsterTheme>).ToString()) as List<MonsterTheme>;
                foreach (MonsterTheme mt in themes)
                {
                    // Make a copy with a new ID
                    MonsterTheme theme = mt.Copy();
                    theme.ID = Guid.NewGuid();

                    SelectedLibrary.Themes.Add(theme);
                    fModified[SelectedLibrary] = true;
                }

                update_content(true);
            }
        }

		private void TemplateStatBlock_Click(object sender, EventArgs e)
		{
			if (SelectedTemplates.Count != 1)
				return;

			CreatureTemplateDetailsForm dlg = new CreatureTemplateDetailsForm(SelectedTemplates[0]);
			dlg.ShowDialog();
		}

		private void TemplateToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedTemplates.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.CreatureTemplateFilter;
				dlg.FileName = SelectedTemplates[0].Name;

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<CreatureTemplate>.Save(dlg.FileName, SelectedTemplates[0], SerialisationMode.Binary);
			}
			else if (SelectedThemes.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.ThemeFilter;
				dlg.FileName = SelectedThemes[0].Name;

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<MonsterTheme>.Save(dlg.FileName, SelectedThemes[0], SerialisationMode.Binary);
			}
		}

		private void TemplateList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedTemplates.Count != 0)
				DoDragDrop(SelectedTemplates, DragDropEffects.Move);
		}

		private void TemplateContextRemove_Click(object sender, EventArgs e)
		{
			TemplateRemoveBtn_Click(sender, e);
		}

		private void TemplateFunctional_Click(object sender, EventArgs e)
		{
			foreach (CreatureTemplate ct in SelectedTemplates)
			{
				ct.Type = CreatureTemplateType.Functional;

				Library lib = Session.FindLibrary(ct);
				if (lib != null)
					fModified[lib] = true;
			}

			update_templates();
		}

		private void TemplateClass_Click(object sender, EventArgs e)
		{
			foreach (CreatureTemplate ct in SelectedTemplates)
			{
				ct.Type = CreatureTemplateType.Class;

				Library lib = Session.FindLibrary(ct);
				if (lib != null)
					fModified[lib] = true;
			}

			update_templates();
		}

		void update_templates()
		{
			Cursor.Current = Cursors.WaitCursor;

			TemplateList.BeginUpdate();
			ListState state = ListState.GetState(TemplateList);

			List<CreatureTemplate> templates = new List<CreatureTemplate>();
            List<MonsterTheme> themes = new List<MonsterTheme>();
			if (SelectedLibrary != null)
			{
				templates.AddRange(SelectedLibrary.Templates);
                themes.AddRange(SelectedLibrary.Themes);
			}
			else
			{
				foreach (Library lib in Session.Libraries)
				{
					templates.AddRange(lib.Templates);
                    themes.AddRange(lib.Themes);
				}
			}

			TemplateList.Items.Clear();

			TemplateList.ShowGroups = true;

            foreach (CreatureTemplate ct in templates)
            {
                if (ct == null)
                    continue;

                ListViewItem lvi = TemplateList.Items.Add(ct.Name);
                lvi.SubItems.Add(ct.Info);
                lvi.Tag = ct;
                lvi.Group = TemplateList.Groups[(ct.Type == CreatureTemplateType.Functional) ? 0 : 1];
            }

            foreach (MonsterTheme mt in themes)
            {
                if (mt == null)
                    continue;

                ListViewItem lvi = TemplateList.Items.Add(mt.Name);
                //lvi.SubItems.Add("Theme");
                lvi.Tag = mt;
                lvi.Group = TemplateList.Groups[2];
            }

			if (TemplateList.Items.Count == 0)
			{
				TemplateList.ShowGroups = false;

				ListViewItem lvi = TemplateList.Items.Add("(no templates or themes)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			TemplateList.Sort();

			ListState.SetState(TemplateList, state);
			TemplateList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Traps page

		private void TrapAddBtn_Click(object sender, EventArgs e)
		{
			Trap t = new Trap();
			t.Name = "New Trap";
			t.Attacks.Add(new TrapAttack());

			TrapBuilderForm dlg = new TrapBuilderForm(t);
			//TrapForm dlg = new TrapForm(t);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.Traps.Add(dlg.Trap);
				fModified[SelectedLibrary] = true;

                update_content(true);
			}
		}

		private void TrapAddImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.TrapFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						Trap t = Serialisation<Trap>.Load(filename, SerialisationMode.Binary);
						if (t != null)
						{
							Trap previous = SelectedLibrary.FindTrap(t.Name, t.Level, t.Role.ToString());
							if (previous != null)
							{
								t.ID = previous.ID;

								SelectedLibrary.Traps.Remove(previous);
							}

							SelectedLibrary.Traps.Add(t);
							fModified[SelectedLibrary] = true;

							update_content(true);
						}
					}
				}
			}
		}

		private void TrapRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTraps.Count != 0)
			{
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (Trap t in SelectedTraps)
				{
					Library lib = SelectedLibrary;
					if (lib == null)
						lib = Session.FindLibrary(t);

					lib.Traps.Remove(t);
					fModified[lib] = true;
				}

                update_content(true);
			}
		}

		private void TrapEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTraps.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedTraps[0]);
				if (lib == null)
					return;

				int index = lib.Traps.IndexOf(SelectedTraps[0]);

				TrapBuilderForm dlg = new TrapBuilderForm(SelectedTraps[0]);
				//TrapForm dlg = new TrapForm(SelectedTraps[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.Traps[index] = dlg.Trap;
					fModified[lib] = true;

                    update_content(true);
				}
			}
		}

		private void TrapCutBtn_Click(object sender, EventArgs e)
		{
			TrapCopyBtn_Click(sender, e);
			TrapRemoveBtn_Click(sender, e);
		}

		private void TrapCopyBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTraps.Count != 0)
			{
				Clipboard.SetData(typeof(List<Trap>).ToString(), SelectedTraps);
			}
		}

		private void TrapPasteBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

			if (Clipboard.ContainsData(typeof(List<Trap>).ToString()))
			{
				List<Trap> traps = Clipboard.GetData(typeof(List<Trap>).ToString()) as List<Trap>;
				foreach (Trap t in traps)
				{
					// Make a copy with a new ID
					Trap trap = t.Copy();
					trap.ID = Guid.NewGuid();

					SelectedLibrary.Traps.Add(trap);
					fModified[SelectedLibrary] = true;
				}

                update_content(true);
			}
		}

		private void TrapStatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTraps.Count != 1)
				return;

			TrapDetailsForm dlg = new TrapDetailsForm(SelectedTraps[0]);
			dlg.ShowDialog();
		}

		private void TrapDemoBtn_Click(object sender, EventArgs e)
		{
			try
			{
				DemographicsForm dlg = new DemographicsForm(SelectedLibrary, DemographicsSource.Traps);
				dlg.ShowDialog();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void TrapToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedTraps.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.TrapFilter;
				dlg.FileName = SelectedTraps[0].Name;

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<Trap>.Save(dlg.FileName, SelectedTraps[0], SerialisationMode.Binary);
			}
		}

		private void TrapList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedTraps.Count != 0)
				DoDragDrop(SelectedTraps, DragDropEffects.Move);
		}

		private void TrapContextRemove_Click(object sender, EventArgs e)
		{
			TrapRemoveBtn_Click(sender, e);
		}

		private void TrapTrap_Click(object sender, EventArgs e)
		{
			foreach (Trap t in SelectedTraps)
			{
				t.Type = TrapType.Trap;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_traps();
		}

		private void TrapHazard_Click(object sender, EventArgs e)
		{
			foreach (Trap t in SelectedTraps)
			{
				t.Type = TrapType.Hazard;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_traps();
		}

		void update_traps()
		{
			Cursor.Current = Cursors.WaitCursor;

			TrapList.BeginUpdate();
			ListState state = ListState.GetState(TrapList);

			List<Trap> traps = new List<Trap>();
			if (SelectedLibrary != null)
			{
				traps.AddRange(SelectedLibrary.Traps);

				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
				{
					List<PlotPoint> points = Session.Project.AllPlotPoints;
					foreach (PlotPoint pp in points)
					{
						if (pp.Element is Encounter)
						{
							Encounter enc = pp.Element as Encounter;
							traps.AddRange(enc.Traps);
						}

						if (pp.Element is Trap)
							traps.Add(pp.Element as Trap);
					}
				}
			}
			else
			{
				foreach (Library lib in Session.Libraries)
				{
					traps.AddRange(lib.Traps);
				}
			}

			TrapList.Items.Clear();

			TrapList.ShowGroups = true;

			List<ListViewItem> list_items = new List<ListViewItem>();

			foreach (Trap t in traps)
			{
				if (t == null)
					continue;

				ListViewItem lvi = new ListViewItem(t.Name);
				lvi.SubItems.Add(t.Info);
				lvi.Tag = t;
				lvi.Group = TrapList.Groups[(t.Type == TrapType.Trap) ? 0 : 1];

				list_items.Add(lvi);
			}

			TrapList.Items.AddRange(list_items.ToArray());

			if (TrapList.Items.Count == 0)
			{
				TrapList.ShowGroups = false;

				ListViewItem lvi = TrapList.Items.Add("(no traps)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			TrapList.Sort();

			ListState.SetState(TrapList, state);
			TrapList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Skill Challenges page

		private void ChallengeAddBtn_Click(object sender, EventArgs e)
		{
			SkillChallenge t = new SkillChallenge();
			t.Name = "New Skill Challenge";

			SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(t);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.SkillChallenges.Add(dlg.SkillChallenge);
				fModified[SelectedLibrary] = true;

                update_content(true);
			}
		}

		private void ChallengeAddImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.SkillChallengeFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						SkillChallenge c = Serialisation<SkillChallenge>.Load(filename, SerialisationMode.Binary);
						if (c != null)
						{
							SelectedLibrary.SkillChallenges.Add(c);
							fModified[SelectedLibrary] = true;

							update_content(true);
						}
					}
				}
			}
		}

		private void ChallengeRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedChallenges.Count != 0)
			{
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (SkillChallenge sc in SelectedChallenges)
				{
					Library lib = SelectedLibrary;
					if (lib == null)
						lib = Session.FindLibrary(sc);

					lib.SkillChallenges.Remove(sc);
					fModified[lib] = true;
				}

                update_content(true);
			}
		}

		private void ChallengeEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedChallenges.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedChallenges[0]);
				if (lib == null)
					return;

				int index = lib.SkillChallenges.IndexOf(SelectedChallenges[0]);

				SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(SelectedChallenges[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.SkillChallenges[index] = dlg.SkillChallenge;
					fModified[lib] = true;

                    update_content(true);
				}
			}
		}

		private void ChallengeCutBtn_Click(object sender, EventArgs e)
		{
			ChallengeCopyBtn_Click(sender, e);
			ChallengeRemoveBtn_Click(sender, e);
		}

		private void ChallengeCopyBtn_Click(object sender, EventArgs e)
		{
			if (SelectedChallenges != null)
			{
				Clipboard.SetData(typeof(List<SkillChallenge>).ToString(), SelectedChallenges);
			}
		}

		private void ChallengePasteBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

			if (Clipboard.ContainsData(typeof(List<SkillChallenge>).ToString()))
			{
				List<SkillChallenge> challenges = Clipboard.GetData(typeof(List<SkillChallenge>).ToString()) as List<SkillChallenge>;
				foreach (SkillChallenge sc in challenges)
				{
					// Make a copy with a new ID
					SkillChallenge challenge = sc.Copy() as SkillChallenge;
					challenge.ID = Guid.NewGuid();

					SelectedLibrary.SkillChallenges.Add(challenge);
					fModified[SelectedLibrary] = true;
				}

                update_content(true);
			}
		}

		private void ChallengeStatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedChallenges.Count != 1)
				return;

			SkillChallengeDetailsForm dlg = new SkillChallengeDetailsForm(SelectedChallenges[0]);
			dlg.ShowDialog();
		}

		private void ChallengeToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedChallenges.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.SkillChallengeFilter;
				dlg.FileName = SelectedChallenges[0].Name;

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<SkillChallenge>.Save(dlg.FileName, SelectedChallenges[0], SerialisationMode.Binary);
			}
		}

		private void ChallengeList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedChallenges.Count != 0)
				DoDragDrop(SelectedChallenges, DragDropEffects.Move);
		}

		private void ChallengeContextRemove_Click(object sender, EventArgs e)
		{
			ChallengeRemoveBtn_Click(sender, e);
		}

		void update_challenges()
		{
			Cursor.Current = Cursors.WaitCursor;

			ChallengeList.BeginUpdate();
			ListState state = ListState.GetState(ChallengeList);

			List<SkillChallenge> challenges = new List<SkillChallenge>();
			if (SelectedLibrary != null)
			{
				challenges.AddRange(SelectedLibrary.SkillChallenges);

				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
				{
					List<PlotPoint> points = Session.Project.AllPlotPoints;
					foreach (PlotPoint pp in points)
					{
						if (pp.Element is Encounter)
						{
							Encounter enc = pp.Element as Encounter;
							challenges.AddRange(enc.SkillChallenges);
						}

						if (pp.Element is SkillChallenge)
							challenges.Add(pp.Element as SkillChallenge);
					}
				}
			}
			else
			{
				foreach (Library lib in Session.Libraries)
				{
					challenges.AddRange(lib.SkillChallenges);
				}
			}

			ChallengeList.Items.Clear();

			ChallengeList.ShowGroups = false;

			foreach (SkillChallenge sc in challenges)
			{
				if (sc == null)
					continue;

				ListViewItem lvi = ChallengeList.Items.Add(sc.Name);
				lvi.SubItems.Add(sc.Info);
				lvi.Tag = sc;
			}

			if (ChallengeList.Items.Count == 0)
			{
				ListViewItem lvi = ChallengeList.Items.Add("(no skill challenges)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			ChallengeList.Sort();

			ListState.SetState(ChallengeList, state);
			ChallengeList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Magic Items page

		private void MagicItemAddBtn_Click(object sender, EventArgs e)
		{
			MagicItem mi = new MagicItem();
			mi.Name = "New Magic Item";

			MagicItemBuilderForm dlg = new MagicItemBuilderForm(mi);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.MagicItems.Add(dlg.MagicItem);
				fModified[SelectedLibrary] = true;

				update_content(true);
			}
		}

		private void MagicItemAddImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.MagicItemFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						List<MagicItem> list = Serialisation<List<MagicItem>>.Load(filename, SerialisationMode.Binary);
						foreach (MagicItem mi in list)
						{
							if (mi != null)
							{
								MagicItem previous = SelectedLibrary.FindMagicItem(mi.Name, mi.Level);
								if (previous != null)
								{
									mi.ID = previous.ID;

									SelectedLibrary.MagicItems.Remove(previous);
								}

								SelectedLibrary.MagicItems.Add(mi);
								fModified[SelectedLibrary] = true;

								update_content(true);
							}
						}
					}
				}
			}
		}

		private void MagicItemRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMagicItems.Count != 0)
			{
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (MagicItem mi in SelectedMagicItems)
				{
					Library lib = SelectedLibrary;
					if (lib == null)
						lib = Session.FindLibrary(mi);

					lib.MagicItems.Remove(mi);
					fModified[lib] = true;
				}

				update_content(true);
			}
		}

		private void MagicItemEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMagicItems.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedMagicItems[0]);
				if (lib == null)
					return;

				int index = lib.MagicItems.IndexOf(SelectedMagicItems[0]);

				MagicItemBuilderForm dlg = new MagicItemBuilderForm(SelectedMagicItems[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.MagicItems[index] = dlg.MagicItem;
					fModified[lib] = true;

					update_content(true);
				}
			}
		}

		private void MagicItemCutBtn_Click(object sender, EventArgs e)
		{
			MagicItemCopyBtn_Click(sender, e);
			MagicItemRemoveBtn_Click(sender, e);
		}

		private void MagicItemCopyBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMagicItems.Count != 0)
			{
				Clipboard.SetData(typeof(List<MagicItem>).ToString(), SelectedMagicItems);
			}
		}

		private void MagicItemPasteBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

			if (Clipboard.ContainsData(typeof(List<MagicItem>).ToString()))
			{
				List<MagicItem> items = Clipboard.GetData(typeof(List<MagicItem>).ToString()) as List<MagicItem>;
				foreach (MagicItem mi in items)
				{
					// Make a copy with a new ID
					MagicItem item = mi.Copy();
					item.ID = Guid.NewGuid();

					SelectedLibrary.MagicItems.Add(item);
					fModified[SelectedLibrary] = true;
				}

				update_content(true);
			}
		}

		private void MagicItemStatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMagicItems.Count != 1)
				return;

			MagicItemDetailsForm dlg = new MagicItemDetailsForm(SelectedMagicItems[0]);
			dlg.ShowDialog();
		}

		private void MagicItemDemoBtn_Click(object sender, EventArgs e)
		{
			try
			{
				DemographicsForm dlg = new DemographicsForm(SelectedLibrary, DemographicsSource.MagicItems);
				dlg.ShowDialog();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MagicItemList_SelectedIndexChanged(object sender, EventArgs e)
		{
			update_magic_item_versions();
		}

		private void MagicItemsToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedMagicItemSet != "")
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.MagicItemFilter;
				dlg.FileName = SelectedMagicItemSet;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					List<MagicItem> items = new List<MagicItem>();
					if (SelectedLibrary != null)
					{
						items.AddRange(SelectedLibrary.MagicItems);
					}
					else
					{
						foreach (Library lib in Session.Libraries)
						{
							items.AddRange(lib.MagicItems);
						}
					}

					List<MagicItem> list = new List<MagicItem>();
					foreach (MagicItem item in items)
					{
						if (item.Name == SelectedMagicItemSet)
							list.Add(item);
					}

					Serialisation<List<MagicItem>>.Save(dlg.FileName, list, SerialisationMode.Binary);
				}
			}
		}

		private void MagicItemList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedMagicItems.Count != 0)
				DoDragDrop(SelectedMagicItems, DragDropEffects.Move);
		}

		private void MagicItemContextRemove_Click(object sender, EventArgs e)
		{
			MagicItemRemoveBtn_Click(sender, e);
		}

		void update_magic_item_sets()
		{
			Cursor.Current = Cursors.WaitCursor;

			MagicItemList.BeginUpdate();
			ListState state = ListState.GetState(MagicItemList);

			List<MagicItem> items = new List<MagicItem>();
			if (SelectedLibrary != null)
			{
				items.AddRange(SelectedLibrary.MagicItems);
			}
			else
			{
				foreach (Library lib in Session.Libraries)
				{
					items.AddRange(lib.MagicItems);
				}
			}

			Dictionary<string, BinarySearchTree<string>> categorised_items = new Dictionary<string, BinarySearchTree<string>>();
			foreach (MagicItem item in items)
			{
				string cat = item.Type;
				if (cat == "")
					cat = "Miscallaneous Items";

				if (!categorised_items.ContainsKey(cat))
					categorised_items[cat] = new BinarySearchTree<string>();

				categorised_items[cat].Add(item.Name);
			}

			List<string> categories = new List<string>();
			categories.AddRange(categorised_items.Keys);
			categories.Sort();
			int misc_index = categories.IndexOf("Miscellaneous Items");
			if (misc_index != -1)
			{
				categories.RemoveAt(misc_index);
				categories.Add("Miscellaneous Items");
			}

			MagicItemList.Groups.Clear();
			MagicItemList.ShowGroups = true;

			List<ListViewItem> list_items = new List<ListViewItem>();

			foreach (string cat in categories)
			{
				ListViewGroup lvg = MagicItemList.Groups.Add(cat, cat);

				List<string> item_names = categorised_items[cat].SortedList;

				foreach (string item in item_names)
				{
					ListViewItem lvi = new ListViewItem(item);
					lvi.Group = lvg;

					list_items.Add(lvi);
				}
			}

			MagicItemList.Items.Clear();
			MagicItemList.Items.AddRange(list_items.ToArray());

			if (MagicItemList.Items.Count == 0)
			{
				MagicItemList.ShowGroups = false;

				ListViewItem lvi = MagicItemList.Items.Add("(no magic items)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			ListState.SetState(MagicItemList, state);
			MagicItemList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		void update_magic_item_versions()
		{
			if (SelectedMagicItemSet != "")
			{
				MagicItemVersionList.Enabled = true;
				MagicItemVersionList.ShowGroups = true;

				MagicItemVersionList.Items.Clear();

				List<MagicItem> items = new List<MagicItem>();
				if (SelectedLibrary != null)
				{
					items.AddRange(SelectedLibrary.MagicItems);
				}
				else
				{
					foreach (Library lib in Session.Libraries)
					{
						items.AddRange(lib.MagicItems);
					}
				}

				foreach (MagicItem item in items)
				{
					if (item.Name != SelectedMagicItemSet)
						continue;

					ListViewItem lvi = MagicItemVersionList.Items.Add("Level " + item.Level);
					lvi.Tag = item;

					if (item.Level < 11)
						lvi.Group = MagicItemVersionList.Groups[0];
					else if (item.Level < 21)
						lvi.Group = MagicItemVersionList.Groups[1];
					else
						lvi.Group = MagicItemVersionList.Groups[2];
				}
			}
			else
			{
				MagicItemVersionList.Enabled = false;
				MagicItemVersionList.ShowGroups = false;

				MagicItemVersionList.Items.Clear();
			}
		}

		#endregion

		#region Tiles page

		private void TileAddBtn_Click(object sender, EventArgs e)
		{
			Tile t = new Tile();

			TileForm dlg = new TileForm(t);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.Tiles.Add(dlg.Tile);
				fModified[SelectedLibrary] = true;

                update_content(true);
			}
		}

		private void TileAddFolderBtn_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "Choose the folder to open.";
			dlg.ShowNewFolderButton = false;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				DirectoryInfo dir = new DirectoryInfo(dlg.SelectedPath);

				List<string> extensions = new List<string>();
				extensions.Add("jpg");
				extensions.Add("jpeg");
				extensions.Add("bmp");
				extensions.Add("gif");
				extensions.Add("png");
				extensions.Add("tga");

				List<FileInfo> files = new List<FileInfo>();
				foreach (string ext in extensions)
					files.AddRange(dir.GetFiles("*." + ext));

				int min_width = int.MaxValue;
				int min_height = int.MaxValue;
				foreach (FileInfo fi in files)
				{
					Image img = Image.FromFile(fi.FullName);

					if (img.Width < min_width)
						min_width = img.Width;

					if (img.Height < min_height)
						min_height = img.Height;
				}

				int min = Math.Min(min_width, min_height);

				foreach (FileInfo fi in files)
				{
					Tile t = new Tile();
					t.Image = Image.FromFile(fi.FullName);
					t.Size = new Size(t.Image.Width / min, t.Image.Height / min);

					Program.SetResolution(t.Image);

					SelectedLibrary.Tiles.Add(t);
				}

				fModified[SelectedLibrary] = true;

                update_content(true);
			}
		}

		private void TileAddImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.MapTileFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						Tile tile = Serialisation<Tile>.Load(filename, SerialisationMode.Binary);
						if (tile != null)
						{
							SelectedLibrary.Tiles.Add(tile);
							fModified[SelectedLibrary] = true;

							update_content(true);
						}
					}
				}
			}
		}

		private void TileSetRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTiles.Count != 0)
			{
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (Tile t in SelectedTiles)
				{
					Library lib = SelectedLibrary;
					if (lib == null)
						lib = Session.FindLibrary(t);

					lib.Tiles.Remove(t);
					fModified[lib] = true;
				}

                update_content(true);
			}
		}

		private void TileSetEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTiles.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedTiles[0]);
				if (lib == null)
					return;

				int index = lib.Tiles.IndexOf(SelectedTiles[0]);

				TileForm dlg = new TileForm(SelectedTiles[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.Tiles[index] = dlg.Tile;
					fModified[lib] = true;

                    update_content(true);
				}
			}
		}

		private void TileCutBtn_Click(object sender, EventArgs e)
		{
			TileCopyBtn_Click(sender, e);
			TileSetRemoveBtn_Click(sender, e);
		}

		private void TileCopyBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTiles.Count != 0)
			{
				Clipboard.SetData(typeof(List<Tile>).ToString(), SelectedTiles);
			}
		}

		private void TileToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedTiles.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.MapTileFilter;
				dlg.FileName = SelectedTiles[0].ToString();

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<Tile>.Save(dlg.FileName, SelectedTiles[0], SerialisationMode.Binary);
			}
		}

		private void TilePasteBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

			if (Clipboard.ContainsData(typeof(List<Tile>).ToString()))
			{
				List<Tile> tiles = Clipboard.GetData(typeof(List<Tile>).ToString()) as List<Tile>;
				foreach (Tile t in tiles)
				{
					// Make a copy with a new ID
					Tile tile = t.Copy();
					tile.ID = Guid.NewGuid();

					SelectedLibrary.Tiles.Add(tile);
					fModified[SelectedLibrary] = true;
				}

                update_content(true);
			}
		}

		private void TileSetView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedTiles.Count != 0)
				DoDragDrop(SelectedTiles, DragDropEffects.Move);
		}

		private void TileContextRemove_Click(object sender, EventArgs e)
		{
			TileSetRemoveBtn_Click(sender, e);
		}

		private void TilePlain_Click(object sender, EventArgs e)
		{
			foreach (Tile t in SelectedTiles)
			{
				t.Category = TileCategory.Plain;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_tiles();
		}

		private void TileDoorway_Click(object sender, EventArgs e)
		{
			foreach (Tile t in SelectedTiles)
			{
				t.Category = TileCategory.Doorway;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_tiles();
		}

		private void TileStairway_Click(object sender, EventArgs e)
		{
			foreach (Tile t in SelectedTiles)
			{
				t.Category = TileCategory.Stairway;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_tiles();
		}

		private void TileFeature_Click(object sender, EventArgs e)
		{
			foreach (Tile t in SelectedTiles)
			{
				t.Category = TileCategory.Feature;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_tiles();
		}

		private void TileMap_Click(object sender, EventArgs e)
		{
			foreach (Tile t in SelectedTiles)
			{
				t.Category = TileCategory.Map;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_tiles();
		}

		private void TileSpecial_Click(object sender, EventArgs e)
		{
			foreach (Tile t in SelectedTiles)
			{
				t.Category = TileCategory.Special;

				Library lib = Session.FindLibrary(t);
				if (lib != null)
					fModified[lib] = true;
			}

			update_tiles();
		}

		private void TileContextSize_Click(object sender, EventArgs e)
		{
			TileSizeForm dlg = new TileSizeForm(SelectedTiles);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				foreach (Tile t in SelectedTiles)
				{
					t.Size = dlg.TileSize;

					Library lib = Session.FindLibrary(t);
					if (lib != null)
						fModified[lib] = true;
				}

				update_tiles();
			}
		}

		void update_tiles()
		{
			Cursor.Current = Cursors.WaitCursor;

			TileList.BeginUpdate();

			List<Tile> tiles = new List<Tile>();
			if (SelectedLibrary != null)
			{
				tiles.AddRange(SelectedLibrary.Tiles);
			}
			else
			{
				foreach (Library lib in Session.Libraries)
				{
					tiles.AddRange(lib.Tiles);
				}
			}

			TileList.Groups.Clear();
			TileList.ShowGroups = true;
			Array categories = Enum.GetValues(typeof(TileCategory));
			foreach (TileCategory cat in categories)
				TileList.Groups.Add(cat.ToString(), cat.ToString());

			TileList.Items.Clear();

			const int TILE_SIZE = 32;

			List<ListViewItem> list_items = new List<ListViewItem>();

			TileList.LargeImageList = new ImageList();
			TileList.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
			TileList.LargeImageList.ImageSize = new Size(TILE_SIZE, TILE_SIZE);

			foreach (Tile t in tiles)
			{
				ListViewItem lvi = new ListViewItem(t.ToString());
				lvi.Tag = t;
				lvi.Group = TileList.Groups[t.Category.ToString()];

				// Get tile image
				Image img = t.Image != null ? t.Image : t.BlankImage;

				Image bmp = new Bitmap(TILE_SIZE, TILE_SIZE);
				Graphics g = Graphics.FromImage(bmp);
				if (t.Size.Width > t.Size.Height)
				{
					int height = (t.Size.Height * TILE_SIZE) / t.Size.Width;
					Rectangle rect = new Rectangle(0, (TILE_SIZE - height) / 2, TILE_SIZE, height);

					g.DrawImage(img, rect);
				}
				else
				{
					int width = (t.Size.Width * TILE_SIZE) / t.Size.Height;
					Rectangle rect = new Rectangle((TILE_SIZE - width) / 2, 0, width, TILE_SIZE);

					g.DrawImage(img, rect);
				}

				TileList.LargeImageList.Images.Add(bmp);
				lvi.ImageIndex = TileList.LargeImageList.Images.Count - 1;

				list_items.Add(lvi);
			}

			TileList.Items.AddRange(list_items.ToArray());

			if (TileList.Items.Count == 0)
			{
				TileList.ShowGroups = false;

				ListViewItem lvi = TileList.Items.Add("(no tiles)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			TileList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Terrain Powers page

		private void TPAddBtn_Click(object sender, EventArgs e)
		{
			TerrainPower t = new TerrainPower();
			t.Name = "New Terrain Power";

			TerrainPowerForm dlg = new TerrainPowerForm(t);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.TerrainPowers.Add(dlg.Power);
				fModified[SelectedLibrary] = true;

				update_content(true);
			}
		}

		private void TPAddImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.TerrainPowerFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						TerrainPower c = Serialisation<TerrainPower>.Load(filename, SerialisationMode.Binary);
						if (c != null)
						{
							SelectedLibrary.TerrainPowers.Add(c);
							fModified[SelectedLibrary] = true;

							update_content(true);
						}
					}
				}
			}
		}

		private void TPRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTerrainPowers.Count != 0)
			{
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (TerrainPower sc in SelectedTerrainPowers)
				{
					Library lib = SelectedLibrary;
					if (lib == null)
						lib = Session.FindLibrary(sc);

					lib.TerrainPowers.Remove(sc);
					fModified[lib] = true;
				}

				update_content(true);
			}
		}

		private void TPEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTerrainPowers.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedTerrainPowers[0]);
				if (lib == null)
					return;

				int index = lib.TerrainPowers.IndexOf(SelectedTerrainPowers[0]);

				TerrainPowerForm dlg = new TerrainPowerForm(SelectedTerrainPowers[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.TerrainPowers[index] = dlg.Power;
					fModified[lib] = true;

					update_content(true);
				}
			}
		}

		private void TPCutBtn_Click(object sender, EventArgs e)
		{
			TPCopyBtn_Click(sender, e);
			TPRemoveBtn_Click(sender, e);
		}

		private void TPCopyBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTerrainPowers != null)
			{
				Clipboard.SetData(typeof(List<TerrainPower>).ToString(), SelectedTerrainPowers);
			}
		}

		private void TPPasteBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

			if (Clipboard.ContainsData(typeof(List<TerrainPower>).ToString()))
			{
				List<TerrainPower> challenges = Clipboard.GetData(typeof(List<TerrainPower>).ToString()) as List<TerrainPower>;
				foreach (TerrainPower sc in challenges)
				{
					// Make a copy with a new ID
					TerrainPower challenge = sc.Copy();
					challenge.ID = Guid.NewGuid();

					SelectedLibrary.TerrainPowers.Add(challenge);
					fModified[SelectedLibrary] = true;
				}

				update_content(true);
			}
		}

		private void TPStatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedTerrainPowers.Count != 1)
				return;

			TerrainPowerDetailsForm dlg = new TerrainPowerDetailsForm(SelectedTerrainPowers[0]);
			dlg.ShowDialog();
		}

		private void TPToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedTerrainPowers.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.TerrainPowerFilter;
				dlg.FileName = SelectedTerrainPowers[0].Name;

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<TerrainPower>.Save(dlg.FileName, SelectedTerrainPowers[0], SerialisationMode.Binary);
			}
		}

		private void TPList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedTerrainPowers.Count != 0)
				DoDragDrop(SelectedTerrainPowers, DragDropEffects.Move);
		}

		private void TPContextRemove_Click(object sender, EventArgs e)
		{
			TPRemoveBtn_Click(sender, e);
		}

		void update_terrain_powers()
		{
			Cursor.Current = Cursors.WaitCursor;

			TerrainPowerList.BeginUpdate();
			ListState state = ListState.GetState(TerrainPowerList);

			List<TerrainPower> challenges = new List<TerrainPower>();
			if (SelectedLibrary != null)
			{
				challenges.AddRange(SelectedLibrary.TerrainPowers);

				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
				{
					List<PlotPoint> points = Session.Project.AllPlotPoints;
					foreach (PlotPoint pp in points)
					{
						if (pp.Element is Encounter)
						{
							Encounter enc = pp.Element as Encounter;
							foreach (CustomToken ct in enc.CustomTokens)
							{
								if (ct.TerrainPower != null)
									challenges.Add(ct.TerrainPower);
							}
						}
					}
				}
			}
			else
			{
				foreach (Library lib in Session.Libraries)
				{
					challenges.AddRange(lib.TerrainPowers);
				}
			}

			TerrainPowerList.Items.Clear();

			TerrainPowerList.ShowGroups = false;

			foreach (TerrainPower sc in challenges)
			{
				if (sc == null)
					continue;

				ListViewItem lvi = TerrainPowerList.Items.Add(sc.Name);
				lvi.SubItems.Add(sc.Type.ToString());
				lvi.Tag = sc;
			}

			if (TerrainPowerList.Items.Count == 0)
			{
				ListViewItem lvi = TerrainPowerList.Items.Add("(no terrain powers)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			TerrainPowerList.Sort();

			ListState.SetState(TerrainPowerList, state);
			TerrainPowerList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		#region Artifacts

		private void ArtifactAddAdd_Click(object sender, EventArgs e)
		{
			Artifact a = new Artifact();
			a.Name = "New Artifact";

			ArtifactBuilderForm dlg = new ArtifactBuilderForm(a);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedLibrary.Artifacts.Add(dlg.Artifact);
				fModified[SelectedLibrary] = true;

				update_content(true);
			}
		}

		private void ArtifactAddImport_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.ArtifactFilter;
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
					{
						Artifact a = Serialisation<Artifact>.Load(filename, SerialisationMode.Binary);
						if (a != null)
						{
							SelectedLibrary.Artifacts.Add(a);
							fModified[SelectedLibrary] = true;

							update_content(true);
						}
					}
				}
			}
		}

		private void ArtifactRemove_Click(object sender, EventArgs e)
		{
			if (SelectedArtifacts.Count != 0)
			{
				string str = "Are you sure you want to delete your selection?";
				if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
					return;

				foreach (Artifact a in SelectedArtifacts)
				{
					Library lib = SelectedLibrary;
					if (lib == null)
						lib = Session.FindLibrary(a);

					lib.Artifacts.Remove(a);
					fModified[lib] = true;
				}

				update_content(true);
			}
		}

		private void ArtifactEdit_Click(object sender, EventArgs e)
		{
			if (SelectedArtifacts.Count == 1)
			{
				Library lib = Session.FindLibrary(SelectedArtifacts[0]);
				if (lib == null)
					return;

				int index = lib.Artifacts.IndexOf(SelectedArtifacts[0]);

				ArtifactBuilderForm dlg = new ArtifactBuilderForm(SelectedArtifacts[0]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.Artifacts[index] = dlg.Artifact;
					fModified[lib] = true;

					update_content(true);
				}
			}
		}

		private void ArtifactCut_Click(object sender, EventArgs e)
		{
			ArtifactCopy_Click(sender, e);
			ArtifactRemove_Click(sender, e);
		}

		private void ArtifactCopy_Click(object sender, EventArgs e)
		{
			if (SelectedArtifacts != null)
			{
				Clipboard.SetData(typeof(List<Artifact>).ToString(), SelectedArtifacts);
			}
		}

		private void ArtifactPaste_Click(object sender, EventArgs e)
		{
			if (SelectedLibrary == null)
				return;

			if (Clipboard.ContainsData(typeof(List<Artifact>).ToString()))
			{
				List<Artifact> artifacts = Clipboard.GetData(typeof(List<Artifact>).ToString()) as List<Artifact>;
				foreach (Artifact a in artifacts)
				{
					// Make a copy with a new ID
					Artifact artifact = a.Copy();
					artifact.ID = Guid.NewGuid();

					SelectedLibrary.Artifacts.Add(artifact);
					fModified[SelectedLibrary] = true;
				}

				update_content(true);
			}
		}

		private void ArtifactStatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedArtifacts.Count != 1)
				return;

			ArtifactDetailsForm dlg = new ArtifactDetailsForm(SelectedArtifacts[0]);
			dlg.ShowDialog();
		}

		private void ArtifactToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedArtifacts.Count == 1)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Title = "Export";
				dlg.Filter = Program.ArtifactFilter;
				dlg.FileName = SelectedArtifacts[0].Name;

				if (dlg.ShowDialog() == DialogResult.OK)
					Serialisation<Artifact>.Save(dlg.FileName, SelectedArtifacts[0], SerialisationMode.Binary);
			}
		}

		private void ArtifactList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedArtifacts.Count != 0)
				DoDragDrop(SelectedArtifacts, DragDropEffects.Move);
		}

		void update_artifacts()
		{
			Cursor.Current = Cursors.WaitCursor;

			ArtifactList.BeginUpdate();
			ListState state = ListState.GetState(ArtifactList);

			List<Artifact> challenges = new List<Artifact>();
			if (SelectedLibrary != null)
			{
				challenges.AddRange(SelectedLibrary.Artifacts);

				if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
				{
					// Add all from unassigned parcels
					foreach (Parcel parcel in Session.Project.TreasureParcels)
					{
						if (parcel.ArtifactID != Guid.Empty)
						{
							Artifact a = Session.FindArtifact(parcel.ArtifactID, SearchType.Global);
							if (a != null)
								challenges.Add(a);
						}
					}

					List<PlotPoint> points = Session.Project.AllPlotPoints;
					foreach (PlotPoint pp in points)
					{
						// Add all from plot points
						foreach (Parcel parcel in pp.Parcels)
						{
							if (parcel.ArtifactID != Guid.Empty)
							{
								Artifact a = Session.FindArtifact(parcel.ArtifactID, SearchType.Global);
								if (a != null)
									challenges.Add(a);
							}
						}
					}
				}
			}
			else
			{
				foreach (Library lib in Session.Libraries)
				{
					challenges.AddRange(lib.Artifacts);
				}
			}

			ArtifactList.Items.Clear();

			ArtifactList.ShowGroups = false;

			foreach (Artifact sc in challenges)
			{
				if (sc == null)
					continue;

				ListViewItem lvi = ArtifactList.Items.Add(sc.Name);
				lvi.SubItems.Add(sc.Tier.ToString());
				lvi.Tag = sc;
			}

			if (ArtifactList.Items.Count == 0)
			{
				ListViewItem lvi = ArtifactList.Items.Add("(no artifacts)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			ArtifactList.Sort();

			ListState.SetState(ArtifactList, state);
			ArtifactList.EndUpdate();

			Cursor.Current = Cursors.Default;
		}

		#endregion

		void save(Library lib)
		{
			GC.Collect();

			string filename = Session.GetLibraryFilename(lib);
			Serialisation<Library>.Save(filename, lib, SerialisationMode.Binary);
		}

		void show_help(bool show)
		{
			HelpPanel.Visible = show;
		}

		void update_libraries()
		{
			LibraryTree.Nodes.Clear();

			if (Session.Libraries.Count != 0)
			{
				TreeNode tn_all = LibraryTree.Nodes.Add("All Libraries");
				tn_all.ImageIndex = 0;

				foreach (Library lib in Session.Libraries)
				{
					TreeNode lvi = tn_all.Nodes.Add(lib.Name);
					lvi.Tag = lib;
				}

				tn_all.Expand();
			}
			else
			{
				if (Session.Project == null)
				{
					TreeNode lvi = LibraryTree.Nodes.Add("(no libraries installed)");
					lvi.ForeColor = SystemColors.GrayText;

					show_help(true);
				}
			}

			if (Session.Project != null)
			{
				TreeNode lvi = LibraryTree.Nodes.Add(Session.Project.Name);
				lvi.Tag = Session.Project.Library;
			}
		}

		void update_content(bool force_refresh)
		{
			if (force_refresh)
				fCleanPages.Clear();

			if (Pages.SelectedTab == CreaturesPage)
			{
				if (!fCleanPages.Contains(CreaturesPage))
				{
					update_creatures();
					fCleanPages.Add(CreaturesPage);
				}
			}

			if (Pages.SelectedTab == TemplatesPage)
			{
				if (!fCleanPages.Contains(TemplatesPage))
				{
					update_templates();
					fCleanPages.Add(TemplatesPage);
				}
			}

			if (Pages.SelectedTab == TrapsPage)
			{
				if (!fCleanPages.Contains(TrapsPage))
				{
					update_traps();
					fCleanPages.Add(TrapsPage);
				}
			}

			if (Pages.SelectedTab == ChallengePage)
			{
				if (!fCleanPages.Contains(ChallengePage))
				{
					update_challenges();
					fCleanPages.Add(ChallengePage);
				}
			}

			if (Pages.SelectedTab == MagicItemsPage)
			{
				if (!fCleanPages.Contains(MagicItemsPage))
				{
					update_magic_item_sets();
					update_magic_item_versions();
					fCleanPages.Add(MagicItemsPage);
				}
			}

			if (Pages.SelectedTab == TilesPage)
			{
				if (!fCleanPages.Contains(TilesPage))
				{
					update_tiles();
					fCleanPages.Add(TilesPage);
				}
			}

			if (Pages.SelectedTab == TerrainPowersPage)
			{
				if (!fCleanPages.Contains(TerrainPowersPage))
				{
					update_terrain_powers();
					fCleanPages.Add(TerrainPowersPage);
				}
			}

			if (Pages.SelectedTab == ArtifactPage)
			{
				if (!fCleanPages.Contains(ArtifactPage))
				{
					update_artifacts();
					fCleanPages.Add(ArtifactPage);
				}
			}
		}
	}
}
