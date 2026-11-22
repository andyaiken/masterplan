#nullable disable

using Masterplan.Controls;
using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class LibraryListForm : Form
    {
        private Timer timerAutoSave;

        public LibraryListForm()
        {
            // LAYOUT NOTE (left-hand column, Splitter.Panel1), set in LibraryListForm.Designer.cs:
            // every control in the column is docked, so the column fills the form at any size:
            //   LibraryToolbar = Top, panel1 (Autosave row) = Top, HelpBtn = Bottom, LibraryTree = Fill.
            // WinForms docks controls in REVERSE order of Controls.Add (the last one added is docked
            // first), and a Fill control must be docked last so it only takes the space left over.
            // That is why LibraryTree is the FIRST control added to Splitter.Panel1.Controls.
            // If the tree is given a fixed size/anchor again, or added after panel1, the list either
            // stops short of the Help button when the form is maximised or slides under the Autosave row.
            // (The comment lives here because the Designer removes comments from InitializeComponent.)
            InitializeComponent();
            InitializeAutoSave();

            // Exports from this window (PNG, JPG, PDF) need a headless browser. If the Export Browser
            // preference is "Downloaded Chromium" and it is not downloaded yet, start the one-time
            // download (~250 MB) in the background now, so it is usually ready before the first
            // export. While it runs, the title shows "Libraries - preparing export component... 45%".
            HeadlessBrowser.StartBackgroundDownload();
            HeadlessBrowser.ShowProgressInTitle(this);


            CreatureSearchToolbar.Visible = false;

            foreach (Library lib in Session.Libraries)
                fModified[lib] = false;

            Application.Idle += new EventHandler(Application_Idle);

            Update_libraries();
        }

        private void InitializeAutoSave()
        {
            // Initialize Timer
            timerAutoSave = new Timer();
            timerAutoSave.Interval = 500000; // 10 minutes for testing
            timerAutoSave.Tick += TimerAutoSave_Tick;

        }
        private void ChkAutoSave_CheckedChanged(object sender, EventArgs e)
        {


            if (chkAutoSave.Checked)
            {
                // Start the timer when checked
                timerAutoSave.Start();
            }
            else
            {
                // Stop the timer when unchecked
                timerAutoSave.Stop();
            }
        }
        private void TimerAutoSave_Tick(object sender, EventArgs e)
        {
            // Stop timer immediately to prevent recursive ticks during save
            timerAutoSave.Stop();

            try
            {
                foreach (Library lib in Session.Libraries)
                {
                    if ((fModified.ContainsKey(lib)) && (!fModified[lib]))
                        continue;

                    PerformSave(lib);
                }


            }
            catch (Exception ex)
            {
                // Handle save errors appropriately
                MessageBox.Show("Save failed: " + ex.Message);
            }
            finally
            {
                // Restart timer if auto-save is still enabled
                if (chkAutoSave.Checked)
                {
                    timerAutoSave.Start();
                }
            }
        }

        private void PerformSave(Library lib)
        {
            // Implement your save logic here
            // Example: Save settings, save file, update database
            GC.Collect();

            // Save as .mpxlib only, using the safe .tmp-then-swap save (see Session.SaveLibrary).
            Session.SaveLibrary(lib);

            // Simple informational popup
            MessageBox.Show("Auto-saving data...", "Autosave");
            //System.Diagnostics.Debug.WriteLine("Auto-saving data...");

            // Example: Save a checkbox state to user settings
            // Properties.Settings.Default.MySetting = true;
            // Properties.Settings.Default.Save();
        }

        ~LibraryListForm()
        {
            Application.Idle -= Application_Idle;
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
                    Get_nodes(tn, nodes);

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

        void Get_nodes(TreeNode tn, List<TreeNode> nodes)
        {
            nodes.Add(tn);

            foreach (TreeNode child in tn.Nodes)
                Get_nodes(child, nodes);
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
                CreatureUniExportBtn.Enabled = (SelectedCreatures.Count == 1);

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
                // Paste buttons: MasterplanClipboard.Has only checks the clipboard format name (no decoding).
                CreaturePasteBtn.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.Creatures));
                CreatureStatBlockBtn.Enabled = (SelectedCreatures.Count == 1);
                CreatureToolsExport.Enabled = (SelectedCreatures.Count == 1);
                CreatureUniExportBtn.Enabled = (SelectedCreatures.Count == 1);

                TemplateAddBtn.Enabled = (SelectedLibrary != null);
                TemplateRemoveBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplateEditBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplateCopyBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplateCutBtn.Enabled = ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0));
                TemplatePasteBtn.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.TemplatesAndThemes));
                TemplateStatBlock.Enabled = (SelectedTemplates.Count == 1);
                TemplateToolsExport.Enabled = (SelectedTemplates.Count == 1) || (SelectedThemes.Count == 1);

                TrapAdd.Enabled = (SelectedLibrary != null);
                TrapRemoveBtn.Enabled = (SelectedTraps.Count != 0);
                TrapEditBtn.Enabled = (SelectedTraps.Count == 1);
                TrapCopyBtn.Enabled = (SelectedTraps.Count != 0);
                TrapCutBtn.Enabled = (SelectedTraps.Count != 0);
                TrapPasteBtn.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.Traps));
                TrapStatBlockBtn.Enabled = (SelectedTraps.Count == 1);
                TrapToolsExport.Enabled = (SelectedTraps.Count == 1);

                ChallengeAdd.Enabled = (SelectedLibrary != null);
                ChallengeRemoveBtn.Enabled = (SelectedChallenges.Count != 0);
                ChallengeEditBtn.Enabled = (SelectedChallenges.Count == 1);
                ChallengeCopyBtn.Enabled = (SelectedChallenges.Count != 0);
                ChallengeCutBtn.Enabled = (SelectedChallenges.Count != 0);
                ChallengePasteBtn.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.SkillChallenges));
                ChallengeStatBlockBtn.Enabled = (SelectedChallenges.Count == 1);
                ChallengeToolsExport.Enabled = (SelectedChallenges.Count == 1);

                MagicItemAdd.Enabled = (SelectedLibrary != null);
                MagicItemRemoveBtn.Enabled = (SelectedMagicItems.Count != 0);
                MagicItemEditBtn.Enabled = (SelectedMagicItems.Count == 1);
                MagicItemCopyBtn.Enabled = (SelectedMagicItems.Count != 0);
                MagicItemCutBtn.Enabled = (SelectedMagicItems.Count != 0);
                MagicItemPasteBtn.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.MagicItems));
                MagicItemStatBlockBtn.Enabled = (SelectedMagicItems.Count == 1);
                MagicItemToolsExport.Enabled = (SelectedMagicItemSet != "");

                TileAddBtn.Enabled = (SelectedLibrary != null);
                TileRemoveBtn.Enabled = (SelectedTiles.Count != 0);
                TileEditBtn.Enabled = (SelectedTiles.Count == 1);
                TileCopyBtn.Enabled = (SelectedTiles.Count != 0);
                TileCutBtn.Enabled = (SelectedTiles.Count != 0);
                TilePasteBtn.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.Tiles));
                TileToolsExport.Enabled = (SelectedTiles.Count == 1);

                TPAdd.Enabled = (SelectedLibrary != null);
                TPRemoveBtn.Enabled = (SelectedTerrainPowers.Count != 0);
                TPEditBtn.Enabled = (SelectedTerrainPowers.Count == 1);
                TPCopyBtn.Enabled = (SelectedTerrainPowers.Count != 0);
                TPCutBtn.Enabled = (SelectedTerrainPowers.Count != 0);
                TPPasteBtn.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.TerrainPowers));
                TPStatBlockBtn.Enabled = (SelectedTerrainPowers.Count == 1);
                TPToolsExport.Enabled = (SelectedTerrainPowers.Count == 1);

                ArtifactAdd.Enabled = (SelectedLibrary != null);
                ArtifactRemove.Enabled = (SelectedArtifacts.Count != 0);
                ArtifactEdit.Enabled = (SelectedArtifacts.Count == 1);
                ArtifactCopy.Enabled = (SelectedArtifacts.Count != 0);
                ArtifactCut.Enabled = (SelectedArtifacts.Count != 0);
                ArtifactPaste.Enabled = ((SelectedLibrary != null) && MasterplanClipboard.Has(MasterplanClipboard.Artifacts));
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
            if (timerAutoSave.Enabled)
            {
                //MessageBox.Show("Shutting down auto-save before exit...", "Masterplan");
                timerAutoSave.Stop();
                timerAutoSave.Dispose();
            }

            foreach (Library lib in Session.Libraries)
            {
                if ((fModified.ContainsKey(lib)) && (!fModified[lib]))
                    continue;

                Save(lib);
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

                Save(dlg.Library);
                fModified[dlg.Library] = true;

                Update_libraries();

                SelectedLibrary = dlg.Library;
                Update_content(true);
            }
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = Program.LibraryOpenFilter; // new and old formats (old ones offer "Convert now?")
            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // STEP 1: Work out which .mpxlib file to read for each chosen file.
                // The dialog lists both .mpxlib and old .library files (LibraryOpenFilter).
                // If an old file has a converted .mpxlib beside it, we use that; if not, it is skipped
                // and reported with "Convert now?" (the old file is left where it is).
                List<string> files = new List<string>();
                List<string> skipped = new List<string>();
                foreach (string filename in dlg.FileNames)
                {
                    string mpx_filename = Path.ChangeExtension(filename, LegacyFiles.LibraryExtension);
                    if (File.Exists(mpx_filename))
                        files.Add(mpx_filename);
                    else if (LegacyFiles.IsLegacyLibrary(filename))
                        skipped.Add(filename);
                    else
                        files.Add(filename); // LoadLibrary will log that it could not be read
                }

                // If the user chooses "Convert now", refresh this window once the tool has closed.
                LegacyFiles.ShowSkipped(this, skipped, Libraries_converted);

                // STEP 2: If any are not in the Libraries folder, offer to copy them there,
                // because only that folder is loaded at startup.
                string lib_folder = Session.LibraryFolder;

                List<string> foreign_files = new List<string>();
                foreach (string filename in files)
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
                            // Keep the file's own name AND extension (.mpxlib).
                            // (The old code always added ".library", which renamed .mpxlib copies so
                            // they could no longer be loaded.)
                            string new_filename = lib_folder + Path.GetFileName(filename);

                            // Do not overwrite a library that is already in the Libraries folder.
                            if (!File.Exists(new_filename))
                                File.Copy(filename, new_filename);
                        }
                    }
                }

                // STEP 3: Load them. LoadLibrary returns null if a file cannot be read; skip those,
                // because a null key in the fModified dictionary would throw.
                foreach (string filename in files)
                {
                    Library lib = Session.LoadLibrary(filename);
                    if (lib != null)
                        fModified[lib] = false;
                }

                if (Session.Project != null)
                    Session.Project.SimplifyProjectLibrary();

                Session.Libraries.Sort();
                Update_libraries();
                Update_content(true);
            }
        }

        private void FileClose_Click(object sender, EventArgs e)
        {
            // Close All Libraries only unloads the libraries from memory. A library with changes that
            // were not saved yet would lose them without a word: this window saves modified libraries
            // when IT closes, but by then these are no longer in the list. So ask first (14.1.0.17).
            // Same rule as LibrariesForm_FormClosed: a library is skipped only if it is KNOWN to be unmodified.
            List<Library> unsaved = new List<Library>();
            foreach (Library lib in Session.Libraries)
            {
                if ((fModified.ContainsKey(lib)) && (!fModified[lib]))
                    continue;

                unsaved.Add(lib);
            }

            if (unsaved.Count != 0)
            {
                const int MAX_NAMES = 10;
                string str = "These libraries have changes that have not been saved:" + Environment.NewLine + Environment.NewLine;
                for (int n = 0; (n != unsaved.Count) && (n != MAX_NAMES); ++n)
                    str += "    " + unsaved[n].Name + Environment.NewLine;
                if (unsaved.Count > MAX_NAMES)
                    str += "    ... and " + (unsaved.Count - MAX_NAMES) + " more" + Environment.NewLine;
                str += Environment.NewLine;
                str += "Do you want to save them before closing all libraries?" + Environment.NewLine;
                str += "Choose No to close them without saving; those changes will be lost.";

                DialogResult dr = MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                    return;

                if (dr == DialogResult.Yes)
                {
                    List<string> failed = new List<string>();
                    foreach (Library lib in unsaved)
                    {
                        if (Session.SaveLibrary(lib))
                            fModified[lib] = false;
                        else
                            failed.Add(lib.Name);
                    }

                    if (failed.Count != 0)
                    {
                        // Nothing is closed, so nothing is lost: the user can fix the problem and try again.
                        string msg = "These libraries could not be saved, so no library has been closed:" + Environment.NewLine + Environment.NewLine;
                        foreach (string name in failed)
                            msg += "    " + name + Environment.NewLine;
                        MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

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

            Update_libraries();
            Update_content(true);

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
                Update_libraries();

                SelectedLibrary = null;
                Update_content(true);
            }
        }

        private void LibraryEditBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary != null)
            {
                int index = Session.Libraries.IndexOf(SelectedLibrary);

                // Remember the file names under the CURRENT library name, before the user renames it.
                string mpx_old_filename = Session.GetLibraryFilename(SelectedLibrary);
                string legacy_old_filename = Session.GetLegacyLibraryFilename(SelectedLibrary);

                // Only a library that has a .mpxlib file in the Libraries folder can be renamed
                // (e.g. the project's own library has no file).
                if (!File.Exists(mpx_old_filename))
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
                    string mpx_new_filename = Session.GetLibraryFilename(dlg.Library);

                    if (mpx_old_filename != mpx_new_filename)
                    {
                        // Rename the library file to match the new name.
                        if (File.Exists(mpx_old_filename))
                        {
                            FileInfo fi = new FileInfo(mpx_old_filename);
                            fi.MoveTo(mpx_new_filename);
                        }

                        // Delete any old .library with the OLD name. The user explicitly renamed the
                        // library; if the old file stayed, it would no longer have a matching .mpxlib
                        // and would be reported as "not converted" at every startup.
                        if (File.Exists(legacy_old_filename))
                            File.Delete(legacy_old_filename);
                    }

                    fModified[dlg.Library] = true;

                    Update_libraries();
                    Update_content(true);
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

                Save(newlib);
                Update_libraries();

                SelectedLibrary = newlib;
                Update_content(true);
            }
        }

        private void LibraryTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Update_content(true);
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
            Show_help(!HelpPanel.Visible);
        }

        private void Pages_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update_content(false);
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

                Update_content(true);
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

                Update_tiles();
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

                Update_terrain_powers();
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

                Update_artifacts();
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

                Update_content(true);
            }
        }

        private void CreatureImport_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary != null)
            {
                if ((Session.Project != null) && (SelectedLibrary == Session.Project.Library))
                    return;

                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = Program.CreatureAndMonsterFilter;
                dlg.Multiselect = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Files that cannot be used are collected and reported once, after the loop.
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // One file can hold several creatures, so collect them in a list first.
                        List<Creature> creatures = new List<Creature>();

                        if (ItemFiles.HasExtension(filename, ".monster"))
                        {
                            // Adventure Tools XML format (unchanged).
                            string xml = File.ReadAllText(filename);
                            Creature imported = AppImport.ImportCreature(xml);
                            if (imported != null)
                                creatures.Add(imported);
                            else
                                problems.AddUnreadable(filename);
                        }
                        else
                        {
                            // .mpxcreature: a small library holding the exported creature(s).
                            // LoadForImport returns null (and records why) for old or unreadable files.
                            Library container = ItemFiles.LoadForImport(filename, problems);
                            if (container == null)
                                continue;

                            if (container.Creatures.Count == 0)
                                problems.AddEmpty(filename);

                            creatures.AddRange(container.Creatures);
                        }

                        foreach (Creature c in creatures)
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

                            Update_content(true);
                        }
                    }

                    problems.Show(this, "creatures");
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

                Update_content(true);
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

                    Update_content(true);
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
                // Copied as MessagePack bytes; see Tools/MasterplanClipboard.cs.
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.Creatures, ItemFiles.Wrap(SelectedCreatures));
            }
        }

        private void CreaturePasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.Creatures);
            if (pasted != null)
            {
                foreach (Creature c in pasted.Creatures)
                {
                    // Make a copy with a new ID
                    Creature creature = c.Copy();
                    creature.ID = Guid.NewGuid();

                    SelectedLibrary.Creatures.Add(creature);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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
            Update_content(true);
        }

        private void CreatureToolsExport_Click(object sender, EventArgs e)
        {
            if (SelectedCreatures.Count == 1)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Export";
                dlg.Filter = Program.CreatureFilter;
                dlg.FileName = SelectedCreatures[0].Name;



                // Export shows an error if the file cannot be written (it used to fail silently).
                if (dlg.ShowDialog() == DialogResult.OK)
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedCreatures[0]), "creature");
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            Update_content(true);
        }

        private void CreatureFilterCategorised_Click(object sender, EventArgs e)
        {
            fShowCategorised = !fShowCategorised;

            Update_content(true);
        }

        private void CreatureFilterUncategorised_Click(object sender, EventArgs e)
        {
            fShowUncategorised = !fShowUncategorised;

            Update_content(true);
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

                Update_content(true);
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

                Update_content(true);
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
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // .mpxcreaturetemplate and .mpxtheme files are both small libraries, so one
                        // loader handles both; whatever templates and themes the file holds are added.
                        Library container = ItemFiles.LoadForImport(filename, problems);
                        if (container == null)
                            continue;

                        if ((container.Templates.Count == 0) && (container.Themes.Count == 0))
                            problems.AddEmpty(filename);

                        foreach (CreatureTemplate ct in container.Templates)
                        {
                            SelectedLibrary.Templates.Add(ct);
                            fModified[SelectedLibrary] = true;
                        }

                        foreach (MonsterTheme theme in container.Themes)
                        {
                            SelectedLibrary.Themes.Add(theme);
                            fModified[SelectedLibrary] = true;
                        }

                        Update_content(true);
                    }

                    problems.Show(this, "templates or themes");
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

                Update_content(true);
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

                Update_content(true);
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

                    Update_content(true);
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

                    Update_content(true);
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
            // Templates and themes go on the clipboard TOGETHER in one container.
            // NOTE: the old code made two separate SetData calls; each one replaced the clipboard, so
            // when both templates and themes were selected only the themes were actually copied.
            if ((SelectedTemplates.Count != 0) || (SelectedThemes.Count != 0))
            {
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.TemplatesAndThemes, ItemFiles.Wrap(SelectedTemplates, SelectedThemes));
            }
        }

        private void TemplatePasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.TemplatesAndThemes);
            if (pasted == null)
                return;

            if (pasted.Templates.Count != 0)
            {
                foreach (CreatureTemplate ct in pasted.Templates)
                {
                    // Make a copy with a new ID
                    CreatureTemplate template = ct.Copy();
                    template.ID = Guid.NewGuid();

                    SelectedLibrary.Templates.Add(template);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
            }

            if (pasted.Themes.Count != 0)
            {
                foreach (MonsterTheme mt in pasted.Themes)
                {
                    // Make a copy with a new ID
                    MonsterTheme theme = mt.Copy();
                    theme.ID = Guid.NewGuid();

                    SelectedLibrary.Themes.Add(theme);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedTemplates[0]), "creature template");
            }
            else if (SelectedThemes.Count == 1)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Export";
                dlg.Filter = Program.ThemeFilter;
                dlg.FileName = SelectedThemes[0].Name;

                if (dlg.ShowDialog() == DialogResult.OK)
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedThemes[0]), "theme");
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
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SelectedLibrary.Traps.Add(dlg.Trap);
                fModified[SelectedLibrary] = true;

                Update_content(true);
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
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // .mpxtrap: a small library holding the exported trap(s).
                        Library container = ItemFiles.LoadForImport(filename, problems);
                        if (container == null)
                            continue;

                        if (container.Traps.Count == 0)
                            problems.AddEmpty(filename);

                        foreach (Trap t in container.Traps)
                        {
                            // A trap with the same name, level and role replaces the existing one
                            // (keeping its ID so encounters that use it still find it).
                            Trap previous = SelectedLibrary.FindTrap(t.Name, t.Level, t.Role.ToString());
                            if (previous != null)
                            {
                                t.ID = previous.ID;

                                SelectedLibrary.Traps.Remove(previous);
                            }

                            SelectedLibrary.Traps.Add(t);
                            fModified[SelectedLibrary] = true;

                            Update_content(true);
                        }
                    }

                    problems.Show(this, "traps");
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

                Update_content(true);
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
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lib.Traps[index] = dlg.Trap;
                    fModified[lib] = true;

                    Update_content(true);
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
                // Copied as MessagePack bytes; see Tools/MasterplanClipboard.cs.
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.Traps, ItemFiles.Wrap(SelectedTraps));
            }
        }

        private void TrapPasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.Traps);
            if (pasted != null)
            {
                foreach (Trap t in pasted.Traps)
                {
                    // Make a copy with a new ID
                    Trap trap = t.Copy();
                    trap.ID = Guid.NewGuid();

                    SelectedLibrary.Traps.Add(trap);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedTraps[0]), "trap");
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

                Update_content(true);
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
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // .mpxskillchallenge: a small library holding the exported skill challenge(s).
                        Library container = ItemFiles.LoadForImport(filename, problems);
                        if (container == null)
                            continue;

                        if (container.SkillChallenges.Count == 0)
                            problems.AddEmpty(filename);

                        foreach (SkillChallenge c in container.SkillChallenges)
                        {
                            SelectedLibrary.SkillChallenges.Add(c);
                            fModified[SelectedLibrary] = true;

                            Update_content(true);
                        }
                    }

                    problems.Show(this, "skill challenges");
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

                Update_content(true);
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

                    Update_content(true);
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
                // Copied as MessagePack bytes; see Tools/MasterplanClipboard.cs.
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.SkillChallenges, ItemFiles.Wrap(SelectedChallenges));
            }
        }

        private void ChallengePasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.SkillChallenges);
            if (pasted != null)
            {
                foreach (SkillChallenge sc in pasted.SkillChallenges)
                {
                    // Make a copy with a new ID
                    SkillChallenge challenge = sc.Copy() as SkillChallenge;
                    challenge.ID = Guid.NewGuid();

                    SelectedLibrary.SkillChallenges.Add(challenge);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedChallenges[0]), "skill challenge");
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

                Update_content(true);
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
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // .mpxmagicitem: a small library holding one magic item set (all its levels).
                        // NOTE: the old code did "foreach (MagicItem mi in list)" without checking for
                        // null, so an unreadable file crashed with the unhandled-exception dialog.
                        Library container = ItemFiles.LoadForImport(filename, problems);
                        if (container == null)
                            continue;

                        if (container.MagicItems.Count == 0)
                            problems.AddEmpty(filename);

                        foreach (MagicItem mi in container.MagicItems)
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

                                Update_content(true);
                            }
                        }
                    }

                    problems.Show(this, "magic items");
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

                Update_content(true);
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

                    Update_content(true);
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
                // Copied as MessagePack bytes; see Tools/MasterplanClipboard.cs.
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.MagicItems, ItemFiles.Wrap(SelectedMagicItems));
            }
        }

        private void MagicItemPasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.MagicItems);
            if (pasted != null)
            {
                foreach (MagicItem mi in pasted.MagicItems)
                {
                    // Make a copy with a new ID
                    MagicItem item = mi.Copy();
                    item.ID = Guid.NewGuid();

                    SelectedLibrary.MagicItems.Add(item);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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
            Update_magic_item_versions();
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

                    // All levels of the selected item go into one file.
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedMagicItemSet, list), "magic item");
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

        void Update_magic_item_versions()
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

                Update_content(true);
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

                // Read every file ONCE. A file that is not a usable picture (damaged, or a format
                // Windows cannot read, e.g. most .tga files) is skipped and listed in one message at the
                // end; before 14.1.0.7 a single such file crashed the whole import.
                List<Tile> tiles = new List<Tile>();
                List<string> skipped = new List<string>();
                foreach (FileInfo fi in files)
                {
                    try
                    {
                        Tile t = new Tile();
                        t.Image = Image.FromFile(fi.FullName);
                        tiles.Add(t);
                    }
                    catch (Exception ex) when (Tools.PictureFiles.IsUnusableFile(ex))
                    {
                        LogSystem.Trace(ex);
                        skipped.Add(fi.Name);
                    }
                }

                // The smallest side of all the pictures is one grid square.
                int min_width = int.MaxValue;
                int min_height = int.MaxValue;
                foreach (Tile t in tiles)
                {
                    if (t.Image.Width < min_width)
                        min_width = t.Image.Width;

                    if (t.Image.Height < min_height)
                        min_height = t.Image.Height;
                }

                int min = Math.Min(min_width, min_height);

                foreach (Tile t in tiles)
                {
                    t.Size = new Size(t.Image.Width / min, t.Image.Height / min);

                    Program.SetResolution(t.Image);

                    SelectedLibrary.Tiles.Add(t);
                }

                if (tiles.Count > 0)
                    fModified[SelectedLibrary] = true;

                Update_content(true);

                if (skipped.Count > 0)
                {
                    // Same causes as PictureFiles.LoadOrWarn's message for a single file.
                    // List at most 10 names, so the message box stays on the screen.
                    const int MAX_LISTED = 10;
                    string msg = "Some files could not be used as pictures and were skipped." + Environment.NewLine
                               + "They may be damaged, not valid images, or open in another program." + Environment.NewLine;
                    for (int i = 0; (i < skipped.Count) && (i < MAX_LISTED); i++)
                        msg += Environment.NewLine + skipped[i];
                    if (skipped.Count > MAX_LISTED)
                        msg += Environment.NewLine + "... and " + (skipped.Count - MAX_LISTED) + " more";

                    MessageBox.Show(this, msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // .mpxmaptile: a small library holding the exported tile(s).
                        Library container = ItemFiles.LoadForImport(filename, problems);
                        if (container == null)
                            continue;

                        if (container.Tiles.Count == 0)
                            problems.AddEmpty(filename);

                        foreach (Tile tile in container.Tiles)
                        {
                            SelectedLibrary.Tiles.Add(tile);
                            fModified[SelectedLibrary] = true;

                            Update_content(true);
                        }
                    }

                    problems.Show(this, "map tiles");
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

                Update_content(true);
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

                    Update_content(true);
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
                // Copied as MessagePack bytes; see Tools/MasterplanClipboard.cs.
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.Tiles, ItemFiles.Wrap(SelectedTiles));
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
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedTiles[0]), "map tile");
            }
        }

        private void TilePasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.Tiles);
            if (pasted != null)
            {
                foreach (Tile t in pasted.Tiles)
                {
                    // Make a copy with a new ID
                    Tile tile = t.Copy();
                    tile.ID = Guid.NewGuid();

                    SelectedLibrary.Tiles.Add(tile);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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

            Update_tiles();
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

            Update_tiles();
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

            Update_tiles();
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

            Update_tiles();
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

            Update_tiles();
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

            Update_tiles();
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

                Update_tiles();
            }
        }

        void Update_tiles()
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

                Update_content(true);
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
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // .mpxterrainpower: a small library holding the exported terrain power(s).
                        Library container = ItemFiles.LoadForImport(filename, problems);
                        if (container == null)
                            continue;

                        if (container.TerrainPowers.Count == 0)
                            problems.AddEmpty(filename);

                        foreach (TerrainPower c in container.TerrainPowers)
                        {
                            SelectedLibrary.TerrainPowers.Add(c);
                            fModified[SelectedLibrary] = true;

                            Update_content(true);
                        }
                    }

                    problems.Show(this, "terrain powers");
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

                Update_content(true);
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

                    Update_content(true);
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
                // Copied as MessagePack bytes; see Tools/MasterplanClipboard.cs.
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.TerrainPowers, ItemFiles.Wrap(SelectedTerrainPowers));
            }
        }

        private void TPPasteBtn_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.TerrainPowers);
            if (pasted != null)
            {
                foreach (TerrainPower sc in pasted.TerrainPowers)
                {
                    // Make a copy with a new ID
                    TerrainPower challenge = sc.Copy();
                    challenge.ID = Guid.NewGuid();

                    SelectedLibrary.TerrainPowers.Add(challenge);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedTerrainPowers[0]), "terrain power");
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

        void Update_terrain_powers()
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
            a.AddStandardConcordanceLevels();

            ArtifactBuilderForm dlg = new ArtifactBuilderForm(a);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SelectedLibrary.Artifacts.Add(dlg.Artifact);
                fModified[SelectedLibrary] = true;

                Update_content(true);
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
                    ImportProblems problems = new ImportProblems();

                    foreach (string filename in dlg.FileNames)
                    {
                        // .mpxartifact: a small library holding the exported artifact(s).
                        Library container = ItemFiles.LoadForImport(filename, problems);
                        if (container == null)
                            continue;

                        if (container.Artifacts.Count == 0)
                            problems.AddEmpty(filename);

                        foreach (Artifact a in container.Artifacts)
                        {
                            SelectedLibrary.Artifacts.Add(a);
                            fModified[SelectedLibrary] = true;

                            Update_content(true);
                        }
                    }

                    problems.Show(this, "artifacts");
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

                Update_content(true);
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

                    Update_content(true);
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
                // Copied as MessagePack bytes; see Tools/MasterplanClipboard.cs.
                MasterplanClipboard.CopyLibraryItems(MasterplanClipboard.Artifacts, ItemFiles.Wrap(SelectedArtifacts));
            }
        }

        private void ArtifactPaste_Click(object sender, EventArgs e)
        {
            if (SelectedLibrary == null)
                return;

            // The clipboard holds MessagePack bytes, not .NET objects (see
            // Tools/MasterplanClipboard.cs). PasteLibraryItems returns null if there is nothing usable,
            // which used to crash here with NullReferenceException.
            Library pasted = MasterplanClipboard.PasteLibraryItems(MasterplanClipboard.Artifacts);
            if (pasted != null)
            {
                foreach (Artifact a in pasted.Artifacts)
                {
                    // Make a copy with a new ID
                    Artifact artifact = a.Copy();
                    artifact.ID = Guid.NewGuid();

                    SelectedLibrary.Artifacts.Add(artifact);
                    fModified[SelectedLibrary] = true;
                }

                Update_content(true);
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
                    ItemFiles.Export(this, dlg.FileName, ItemFiles.Wrap(SelectedArtifacts[0]), "artifact");
            }
        }

        private void ArtifactList_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (SelectedArtifacts.Count != 0)
                DoDragDrop(SelectedArtifacts, DragDropEffects.Move);
        }

        void Update_artifacts()
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

        void Save(Library lib)
        {
            GC.Collect();

            // Save as .mpxlib only, using the safe .tmp-then-swap save (see Session.SaveLibrary).
            Session.SaveLibrary(lib);
        }
        void Show_help(bool show)
        {
            HelpPanel.Visible = show;
        }

        void Update_libraries()
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

                    Show_help(true);
                }
            }

            if (Session.Project != null)
            {
                TreeNode lvi = LibraryTree.Nodes.Add(Session.Project.Name);
                lvi.Tag = Session.Project.Library;
            }
        }

        void Update_content(bool force_refresh)
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
                    Update_magic_item_versions();
                    fCleanPages.Add(MagicItemsPage);
                }
            }

            if (Pages.SelectedTab == TilesPage)
            {
                if (!fCleanPages.Contains(TilesPage))
                {
                    Update_tiles();
                    fCleanPages.Add(TilesPage);
                }
            }

            if (Pages.SelectedTab == TerrainPowersPage)
            {
                if (!fCleanPages.Contains(TerrainPowersPage))
                {
                    Update_terrain_powers();
                    fCleanPages.Add(TerrainPowersPage);
                }
            }

            if (Pages.SelectedTab == ArtifactPage)
            {
                if (!fCleanPages.Contains(ArtifactPage))
                {
                    Update_artifacts();
                    fCleanPages.Add(ArtifactPage);
                }
            }
        }


        /// <summary>
        /// Convert button: opens "MasterplanXP Migration Tool" on the Libraries folder, where old
        /// .library files are kept (Masterplan moves them there at startup). When the tool closes,
        /// the converted libraries are loaded and this window refreshes (Libraries_converted).
        /// See Tools/MigrationTool.cs.
        /// </summary>
        private void LibraryBtnConvert_Click(object sender, EventArgs e)
        {
            MigrationTool.Launch(this, Session.LibraryFolder, null, Libraries_converted);
        }

        /// <summary>
        /// Called (on the UI thread) after the migration tool closes, with what was converted.
        /// Registers the libraries Masterplan loaded in fModified (every loaded library needs an
        /// entry, as the constructor does for the others) and refreshes the library list.
        /// </summary>
        private void Libraries_converted(MigrationResult result)
        {
            if (IsDisposed)
                return; // this window was closed while the tool was running

            foreach (Library lib in result.LoadedLibraries)
                fModified[lib] = false;

            Update_libraries();
            Update_content(true);
        }


        // ---------------------------------------------------------------------------------------------
        // "Export" buttons (one per section): open the export dialog (PNG, JPG, PDF, DOCX, HTM) for the
        // ONE selected item. Each builds the item's HTML with the same HTML.* call its Stat Block window
        // uses, so the exported file looks like what the user sees there, and passes the item's name as
        // the suggested file name.
        // (The creature button used to export a hard-coded test stat block, so it always exported the
        // same creature; the other buttons only said "BETA - Coming Feature".)
        // Width: exports are ExportOptionsForm.DefaultExportTableWidth (350px) wide, except skill
        // challenges and artifacts, which use WideExportWidth because they have more text per row.
        // ---------------------------------------------------------------------------------------------

        // Export width (pixels) for skill challenges and artifacts.
        private const int WideExportWidth = 600;

        private void CreatureUniExportBtn_Click(object sender, EventArgs e)
        {
            if (SelectedCreatures.Count != 1)
                return;

            // Same as CreatureStatBlockBtn_Click / CreatureDetailsForm: wrap the creature in an
            // EncounterCard and build its full stat block, including the STYLE block.
            Creature creature = SelectedCreatures[0];
            EncounterCard card = new EncounterCard();
            card.CreatureID = creature.ID;
            string htm = HTML.StatBlock(card, null, null, true, false, true, CardMode.View, Session.Preferences.TextSize);

            show_export_dialog(htm, creature.Name);
        }

        private void TemplateUniExportBtn_Click(object sender, EventArgs e)
        {
            if (SelectedTemplates.Count != 1)
                return;

            // Same HTML as CreatureTemplateDetailsForm.
            CreatureTemplate template = SelectedTemplates[0];
            string htm = HTML.CreatureTemplate(template, Session.Preferences.TextSize, false);

            show_export_dialog(htm, template.Name);
        }

        private void TrapUniExportBtn_Click(object sender, EventArgs e)
        {
            if (SelectedTraps.Count != 1)
                return;

            // Same HTML as TrapDetailsForm.
            Trap trap = SelectedTraps[0];
            string htm = HTML.Trap(trap, null, true, false, false, Session.Preferences.TextSize);

            show_export_dialog(htm, trap.Name);
        }

        private void SkillChallengeUniExportBtn_Click(object sender, EventArgs e)
        {
            if (SelectedChallenges.Count != 1)
                return;

            // Same HTML as SkillChallengeDetailsForm (no clickable links: they mean nothing in a file).
            SkillChallenge challenge = SelectedChallenges[0];
            string htm = HTML.SkillChallenge(challenge, false, true, Session.Preferences.TextSize);

            show_export_dialog(htm, challenge.Name, WideExportWidth);
        }

        private void MagicItemUniExportBtn_Click(object sender, EventArgs e)
        {
            if (SelectedMagicItems.Count != 1)
                return;

            // Same HTML as MagicItemDetailsForm.
            MagicItem item = SelectedMagicItems[0];
            string htm = HTML.MagicItem(item, Session.Preferences.TextSize, false, true);

            show_export_dialog(htm, item.Name);
        }

        private void ArtifactUniExportBtn_Click(object sender, EventArgs e)
        {
            if (SelectedArtifacts.Count != 1)
                return;

            // Same HTML as ArtifactDetailsForm.
            Artifact artifact = SelectedArtifacts[0];
            string htm = HTML.Artifact(artifact, Session.Preferences.TextSize, false, true);

            show_export_dialog(htm, artifact.Name, WideExportWidth);
        }

        /// <summary>
        /// Opens the export dialog for one item's HTML. Shared by all the "Export" buttons above.
        /// </summary>
        /// <param name="htm">Complete HTML page for the item.</param>
        /// <param name="name">The item's name, offered as the file name in the Save dialog.</param>
        /// <param name="width">Width in pixels of the item's main table in the export.</param>
        private void show_export_dialog(string htm, string name, int width = ExportOptionsForm.DefaultExportTableWidth)
        {
            using (ExportOptionsForm dlg = new ExportOptionsForm(htm, name, width))
                dlg.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LibraryListForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
