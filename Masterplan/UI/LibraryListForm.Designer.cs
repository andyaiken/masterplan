namespace Masterplan.UI
{
	partial class LibraryListForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryListForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Functional Templates", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Class Templates", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Themes", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Traps", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Hazards", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Traps", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Hazards", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Heroic Tier", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Paragon Tier", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Epic Tier", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("Traps", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("Hazards", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup13 = new System.Windows.Forms.ListViewGroup("Traps", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup14 = new System.Windows.Forms.ListViewGroup("Hazards", System.Windows.Forms.HorizontalAlignment.Left);
            Splitter = new System.Windows.Forms.SplitContainer();
            LibraryTree = new System.Windows.Forms.TreeView();
            LibraryToolbar = new System.Windows.Forms.ToolStrip();
            FileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            FileNew = new System.Windows.Forms.ToolStripMenuItem();
            FileOpen = new System.Windows.Forms.ToolStripMenuItem();
            FileClose = new System.Windows.Forms.ToolStripMenuItem();
            LibraryRemoveBtn = new System.Windows.Forms.ToolStripButton();
            LibraryEditBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            LibraryMergeBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
            LibraryBtnConvert = new System.Windows.Forms.ToolStripButton();
            HelpBtn = new System.Windows.Forms.Button();
            Pages = new System.Windows.Forms.TabControl();
            CreaturesPage = new System.Windows.Forms.TabPage();
            CreatureList = new System.Windows.Forms.ListView();
            CreatureNameHdr = new System.Windows.Forms.ColumnHeader();
            CreatureInfoHdr = new System.Windows.Forms.ColumnHeader();
            CreatureContext = new System.Windows.Forms.ContextMenuStrip(components);
            CreatureContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            CreatureContextCategory = new System.Windows.Forms.ToolStripMenuItem();
            CreatureSearchToolbar = new System.Windows.Forms.ToolStrip();
            SearchLbl = new System.Windows.Forms.ToolStripLabel();
            SearchBox = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            CategorisedBtn = new System.Windows.Forms.ToolStripButton();
            UncategorisedBtn = new System.Windows.Forms.ToolStripButton();
            CreatureToolbar = new System.Windows.Forms.ToolStrip();
            CreatureAddBtn = new System.Windows.Forms.ToolStripDropDownButton();
            CreatureAddSingle = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            CreatureImport = new System.Windows.Forms.ToolStripMenuItem();
            OppRemoveBtn = new System.Windows.Forms.ToolStripButton();
            OppEditBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            CreatureCutBtn = new System.Windows.Forms.ToolStripButton();
            CreatureCopyBtn = new System.Windows.Forms.ToolStripButton();
            CreaturePasteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            CreatureStatBlockBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            CreatureTools = new System.Windows.Forms.ToolStripDropDownButton();
            CreatureToolsDemographics = new System.Windows.Forms.ToolStripMenuItem();
            CreatureToolsPowerStatistics = new System.Windows.Forms.ToolStripMenuItem();
            CreatureToolsFilterList = new System.Windows.Forms.ToolStripMenuItem();
            CreatureToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            TemplatesPage = new System.Windows.Forms.TabPage();
            TemplateList = new System.Windows.Forms.ListView();
            TemplateNameHdr = new System.Windows.Forms.ColumnHeader();
            TemplateInfoHdr = new System.Windows.Forms.ColumnHeader();
            TemplateContext = new System.Windows.Forms.ContextMenuStrip(components);
            TemplateContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            TemplateContextType = new System.Windows.Forms.ToolStripMenuItem();
            TemplateFunctional = new System.Windows.Forms.ToolStripMenuItem();
            TemplateClass = new System.Windows.Forms.ToolStripMenuItem();
            TemplateToolbar = new System.Windows.Forms.ToolStrip();
            TemplateAddBtn = new System.Windows.Forms.ToolStripDropDownButton();
            addTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            TemplateAddTheme = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            TemplateImport = new System.Windows.Forms.ToolStripMenuItem();
            TemplateRemoveBtn = new System.Windows.Forms.ToolStripButton();
            TemplateEditBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            TemplateCutBtn = new System.Windows.Forms.ToolStripButton();
            TemplateCopyBtn = new System.Windows.Forms.ToolStripButton();
            TemplatePasteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            TemplateStatBlock = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            TemplateTools = new System.Windows.Forms.ToolStripDropDownButton();
            TemplateToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            TrapsPage = new System.Windows.Forms.TabPage();
            TrapList = new System.Windows.Forms.ListView();
            TrapNameHdr = new System.Windows.Forms.ColumnHeader();
            TrapInfoHdr = new System.Windows.Forms.ColumnHeader();
            TrapContext = new System.Windows.Forms.ContextMenuStrip(components);
            TrapContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            TrapContextType = new System.Windows.Forms.ToolStripMenuItem();
            TrapTrap = new System.Windows.Forms.ToolStripMenuItem();
            TrapHazard = new System.Windows.Forms.ToolStripMenuItem();
            TrapToolbar = new System.Windows.Forms.ToolStrip();
            TrapAdd = new System.Windows.Forms.ToolStripDropDownButton();
            TrapAddAdd = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            TrapAddImport = new System.Windows.Forms.ToolStripMenuItem();
            TrapRemoveBtn = new System.Windows.Forms.ToolStripButton();
            TrapEditBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            TrapCutBtn = new System.Windows.Forms.ToolStripButton();
            TrapCopyBtn = new System.Windows.Forms.ToolStripButton();
            TrapPasteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            TrapStatBlockBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            TrapTools = new System.Windows.Forms.ToolStripDropDownButton();
            TrapToolsDemographics = new System.Windows.Forms.ToolStripMenuItem();
            TrapToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            ChallengePage = new System.Windows.Forms.TabPage();
            ChallengeList = new System.Windows.Forms.ListView();
            ChallengeNameHdr = new System.Windows.Forms.ColumnHeader();
            ChallengeInfoHdr = new System.Windows.Forms.ColumnHeader();
            ChallengeToolbar = new System.Windows.Forms.ToolStrip();
            ChallengeAdd = new System.Windows.Forms.ToolStripDropDownButton();
            ChallengeAddAdd = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            ChallengeAddImport = new System.Windows.Forms.ToolStripMenuItem();
            ChallengeRemoveBtn = new System.Windows.Forms.ToolStripButton();
            ChallengeEditBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            ChallengeCutBtn = new System.Windows.Forms.ToolStripButton();
            ChallengeCopyBtn = new System.Windows.Forms.ToolStripButton();
            ChallengePasteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            ChallengeStatBlockBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            ChallengeTools = new System.Windows.Forms.ToolStripDropDownButton();
            ChallengeToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            MagicItemsPage = new System.Windows.Forms.TabPage();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            MagicItemList = new System.Windows.Forms.ListView();
            MagicItemHdr = new System.Windows.Forms.ColumnHeader();
            MagicItemContext = new System.Windows.Forms.ContextMenuStrip(components);
            MagicItemContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            MagicItemToolbar = new System.Windows.Forms.ToolStrip();
            MagicItemAdd = new System.Windows.Forms.ToolStripDropDownButton();
            MagicItemAddAdd = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            MagicItemAddImport = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            MagicItemTools = new System.Windows.Forms.ToolStripDropDownButton();
            MagicItemToolsDemographics = new System.Windows.Forms.ToolStripMenuItem();
            MagicItemToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            MagicItemVersionList = new System.Windows.Forms.ListView();
            MagicItemInfoHdr = new System.Windows.Forms.ColumnHeader();
            MagicItemVersionToolbar = new System.Windows.Forms.ToolStrip();
            MagicItemRemoveBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            MagicItemEditBtn = new System.Windows.Forms.ToolStripButton();
            MagicItemCutBtn = new System.Windows.Forms.ToolStripButton();
            MagicItemCopyBtn = new System.Windows.Forms.ToolStripButton();
            MagicItemPasteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            MagicItemStatBlockBtn = new System.Windows.Forms.ToolStripButton();
            TilesPage = new System.Windows.Forms.TabPage();
            TileList = new System.Windows.Forms.ListView();
            TileSetNameHdr = new System.Windows.Forms.ColumnHeader();
            TileContext = new System.Windows.Forms.ContextMenuStrip(components);
            TileContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            TileContextCategory = new System.Windows.Forms.ToolStripMenuItem();
            TilePlain = new System.Windows.Forms.ToolStripMenuItem();
            TileDoorway = new System.Windows.Forms.ToolStripMenuItem();
            TileStairway = new System.Windows.Forms.ToolStripMenuItem();
            TileFeature = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            TileSpecial = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            TileMap = new System.Windows.Forms.ToolStripMenuItem();
            TileContextSize = new System.Windows.Forms.ToolStripMenuItem();
            TileToolbar = new System.Windows.Forms.ToolStrip();
            TileAddBtn = new System.Windows.Forms.ToolStripDropDownButton();
            addTileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            TileAddImport = new System.Windows.Forms.ToolStripMenuItem();
            TileAddFolder = new System.Windows.Forms.ToolStripMenuItem();
            TileRemoveBtn = new System.Windows.Forms.ToolStripButton();
            TileEditBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            TileCutBtn = new System.Windows.Forms.ToolStripButton();
            TileCopyBtn = new System.Windows.Forms.ToolStripButton();
            TilePasteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            TileTools = new System.Windows.Forms.ToolStripDropDownButton();
            TileToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            TerrainPowersPage = new System.Windows.Forms.TabPage();
            TerrainPowerList = new System.Windows.Forms.ListView();
            TPNameHdr = new System.Windows.Forms.ColumnHeader();
            TPInfoHdr = new System.Windows.Forms.ColumnHeader();
            TPContext = new System.Windows.Forms.ContextMenuStrip(components);
            TPContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            TerrainPowerToolbar = new System.Windows.Forms.ToolStrip();
            TPAdd = new System.Windows.Forms.ToolStripDropDownButton();
            TPAddTerrainPower = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            TPAddImport = new System.Windows.Forms.ToolStripMenuItem();
            TPRemoveBtn = new System.Windows.Forms.ToolStripButton();
            TPEditBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            TPCutBtn = new System.Windows.Forms.ToolStripButton();
            TPCopyBtn = new System.Windows.Forms.ToolStripButton();
            TPPasteBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            TPStatBlockBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
            TPTools = new System.Windows.Forms.ToolStripDropDownButton();
            TPToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            ArtifactPage = new System.Windows.Forms.TabPage();
            ArtifactList = new System.Windows.Forms.ListView();
            ArtifactHdr = new System.Windows.Forms.ColumnHeader();
            ArtifactInfoHdr = new System.Windows.Forms.ColumnHeader();
            ArtifactContext = new System.Windows.Forms.ContextMenuStrip(components);
            ArtifactContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            ArtifactToolbar = new System.Windows.Forms.ToolStrip();
            ArtifactAdd = new System.Windows.Forms.ToolStripDropDownButton();
            ArtifactAddAdd = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            ArtifactAddImport = new System.Windows.Forms.ToolStripMenuItem();
            ArtifactRemove = new System.Windows.Forms.ToolStripButton();
            ArtifactEdit = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            ArtifactCut = new System.Windows.Forms.ToolStripButton();
            ArtifactCopy = new System.Windows.Forms.ToolStripButton();
            ArtifactPaste = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            ArtifactStatBlockBtn = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            ArtifactTools = new System.Windows.Forms.ToolStripDropDownButton();
            ArtifactToolsExport = new System.Windows.Forms.ToolStripMenuItem();
            HelpPanel = new Masterplan.Controls.LibraryHelpPanel();
            ChallengeContext = new System.Windows.Forms.ContextMenuStrip(components);
            ChallengeContextRemove = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)Splitter).BeginInit();
            Splitter.Panel1.SuspendLayout();
            Splitter.Panel2.SuspendLayout();
            Splitter.SuspendLayout();
            LibraryToolbar.SuspendLayout();
            Pages.SuspendLayout();
            CreaturesPage.SuspendLayout();
            CreatureContext.SuspendLayout();
            CreatureSearchToolbar.SuspendLayout();
            CreatureToolbar.SuspendLayout();
            TemplatesPage.SuspendLayout();
            TemplateContext.SuspendLayout();
            TemplateToolbar.SuspendLayout();
            TrapsPage.SuspendLayout();
            TrapContext.SuspendLayout();
            TrapToolbar.SuspendLayout();
            ChallengePage.SuspendLayout();
            ChallengeToolbar.SuspendLayout();
            MagicItemsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            MagicItemContext.SuspendLayout();
            MagicItemToolbar.SuspendLayout();
            MagicItemVersionToolbar.SuspendLayout();
            TilesPage.SuspendLayout();
            TileContext.SuspendLayout();
            TileToolbar.SuspendLayout();
            TerrainPowersPage.SuspendLayout();
            TPContext.SuspendLayout();
            TerrainPowerToolbar.SuspendLayout();
            ArtifactPage.SuspendLayout();
            ArtifactContext.SuspendLayout();
            ArtifactToolbar.SuspendLayout();
            ChallengeContext.SuspendLayout();
            SuspendLayout();
            // 
            // Splitter
            // 
            Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            Splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            Splitter.Location = new System.Drawing.Point(0, 0);
            Splitter.Margin = new System.Windows.Forms.Padding(4);
            Splitter.Name = "Splitter";
            // 
            // Splitter.Panel1
            // 
            Splitter.Panel1.Controls.Add(LibraryTree);
            Splitter.Panel1.Controls.Add(LibraryToolbar);
            Splitter.Panel1.Controls.Add(HelpBtn);
            // 
            // Splitter.Panel2
            // 
            Splitter.Panel2.Controls.Add(Pages);
            Splitter.Panel2.Controls.Add(HelpPanel);
            Splitter.Size = new System.Drawing.Size(1026, 329);
            Splitter.SplitterDistance = 290;
            Splitter.TabIndex = 0;
            // 
            // LibraryTree
            // 
            LibraryTree.AllowDrop = true;
            LibraryTree.Dock = System.Windows.Forms.DockStyle.Fill;
            LibraryTree.FullRowSelect = true;
            LibraryTree.HideSelection = false;
            LibraryTree.Location = new System.Drawing.Point(0, 25);
            LibraryTree.Margin = new System.Windows.Forms.Padding(4);
            LibraryTree.Name = "LibraryTree";
            LibraryTree.ShowPlusMinus = false;
            LibraryTree.ShowRootLines = false;
            LibraryTree.Size = new System.Drawing.Size(290, 278);
            LibraryTree.TabIndex = 1;
            LibraryTree.ItemDrag += LibraryList_ItemDrag;
            LibraryTree.AfterSelect += LibraryTree_AfterSelect;
            LibraryTree.DragDrop += LibraryList_DragDrop;
            LibraryTree.DragOver += LibraryList_DragOver;
            LibraryTree.DoubleClick += LibraryEditBtn_Click;
            // 
            // LibraryToolbar
            // 
            LibraryToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            LibraryToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { FileMenu, LibraryRemoveBtn, LibraryEditBtn, toolStripSeparator17, LibraryMergeBtn, toolStripSeparator36, LibraryBtnConvert });
            LibraryToolbar.Location = new System.Drawing.Point(0, 0);
            LibraryToolbar.Name = "LibraryToolbar";
            LibraryToolbar.Size = new System.Drawing.Size(290, 25);
            LibraryToolbar.TabIndex = 0;
            LibraryToolbar.Text = "toolStrip1";
            // 
            // FileMenu
            // 
            FileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { FileNew, FileOpen, FileClose });
            FileMenu.Image = (System.Drawing.Image)resources.GetObject("FileMenu.Image");
            FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            FileMenu.Name = "FileMenu";
            FileMenu.Size = new System.Drawing.Size(38, 22);
            FileMenu.Text = "File";
            // 
            // FileNew
            // 
            FileNew.Name = "FileNew";
            FileNew.Size = new System.Drawing.Size(183, 22);
            FileNew.Text = "Create New Library...";
            FileNew.Click += FileNew_Click;
            // 
            // FileOpen
            // 
            FileOpen.Name = "FileOpen";
            FileOpen.Size = new System.Drawing.Size(183, 22);
            FileOpen.Text = "Open Library...";
            FileOpen.Click += FileOpen_Click;
            // 
            // FileClose
            // 
            FileClose.Name = "FileClose";
            FileClose.Size = new System.Drawing.Size(183, 22);
            FileClose.Text = "Close All Libraries";
            FileClose.Click += FileClose_Click;
            // 
            // LibraryRemoveBtn
            // 
            LibraryRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            LibraryRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("LibraryRemoveBtn.Image");
            LibraryRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            LibraryRemoveBtn.Name = "LibraryRemoveBtn";
            LibraryRemoveBtn.Size = new System.Drawing.Size(54, 22);
            LibraryRemoveBtn.Text = "Remove";
            LibraryRemoveBtn.Click += LibraryRemoveBtn_Click;
            // 
            // LibraryEditBtn
            // 
            LibraryEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            LibraryEditBtn.Image = (System.Drawing.Image)resources.GetObject("LibraryEditBtn.Image");
            LibraryEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            LibraryEditBtn.Name = "LibraryEditBtn";
            LibraryEditBtn.Size = new System.Drawing.Size(31, 22);
            LibraryEditBtn.Text = "Edit";
            LibraryEditBtn.Click += LibraryEditBtn_Click;
            // 
            // toolStripSeparator17
            // 
            toolStripSeparator17.Name = "toolStripSeparator17";
            toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // LibraryMergeBtn
            // 
            LibraryMergeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            LibraryMergeBtn.Image = (System.Drawing.Image)resources.GetObject("LibraryMergeBtn.Image");
            LibraryMergeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            LibraryMergeBtn.Name = "LibraryMergeBtn";
            LibraryMergeBtn.Size = new System.Drawing.Size(45, 22);
            LibraryMergeBtn.Text = "Merge";
            LibraryMergeBtn.Click += LibraryMergeBtn_Click;
            // 
            // toolStripSeparator36
            // 
            toolStripSeparator36.Name = "toolStripSeparator36";
            toolStripSeparator36.Size = new System.Drawing.Size(6, 25);
            // 
            // LibraryBtnConvert
            // 
            LibraryBtnConvert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            LibraryBtnConvert.Image = (System.Drawing.Image)resources.GetObject("LibraryBtnConvert.Image");
            LibraryBtnConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            LibraryBtnConvert.Name = "LibraryBtnConvert";
            LibraryBtnConvert.Size = new System.Drawing.Size(53, 22);
            LibraryBtnConvert.Text = "Convert";
            LibraryBtnConvert.Click += LibraryBtnConvert_Click;
            // 
            // HelpBtn
            // 
            HelpBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            HelpBtn.Location = new System.Drawing.Point(0, 303);
            HelpBtn.Margin = new System.Windows.Forms.Padding(4);
            HelpBtn.Name = "HelpBtn";
            HelpBtn.Size = new System.Drawing.Size(290, 26);
            HelpBtn.TabIndex = 3;
            HelpBtn.Text = "Show Help";
            HelpBtn.UseVisualStyleBackColor = true;
            HelpBtn.Click += HelpBtn_Click;
            // 
            // Pages
            // 
            Pages.Controls.Add(CreaturesPage);
            Pages.Controls.Add(TemplatesPage);
            Pages.Controls.Add(TrapsPage);
            Pages.Controls.Add(ChallengePage);
            Pages.Controls.Add(MagicItemsPage);
            Pages.Controls.Add(TilesPage);
            Pages.Controls.Add(TerrainPowersPage);
            Pages.Controls.Add(ArtifactPage);
            Pages.Dock = System.Windows.Forms.DockStyle.Fill;
            Pages.Location = new System.Drawing.Point(0, 0);
            Pages.Margin = new System.Windows.Forms.Padding(4);
            Pages.Name = "Pages";
            Pages.SelectedIndex = 0;
            Pages.Size = new System.Drawing.Size(732, 145);
            Pages.TabIndex = 2;
            Pages.SelectedIndexChanged += Pages_SelectedIndexChanged;
            // 
            // CreaturesPage
            // 
            CreaturesPage.Controls.Add(CreatureList);
            CreaturesPage.Controls.Add(CreatureSearchToolbar);
            CreaturesPage.Controls.Add(CreatureToolbar);
            CreaturesPage.Location = new System.Drawing.Point(4, 24);
            CreaturesPage.Margin = new System.Windows.Forms.Padding(4);
            CreaturesPage.Name = "CreaturesPage";
            CreaturesPage.Padding = new System.Windows.Forms.Padding(4);
            CreaturesPage.Size = new System.Drawing.Size(724, 117);
            CreaturesPage.TabIndex = 0;
            CreaturesPage.Text = "Creatures";
            CreaturesPage.UseVisualStyleBackColor = true;
            // 
            // CreatureList
            // 
            CreatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { CreatureNameHdr, CreatureInfoHdr });
            CreatureList.ContextMenuStrip = CreatureContext;
            CreatureList.Dock = System.Windows.Forms.DockStyle.Fill;
            CreatureList.FullRowSelect = true;
            CreatureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            CreatureList.Location = new System.Drawing.Point(4, 54);
            CreatureList.Margin = new System.Windows.Forms.Padding(4);
            CreatureList.Name = "CreatureList";
            CreatureList.Size = new System.Drawing.Size(716, 59);
            CreatureList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            CreatureList.TabIndex = 1;
            CreatureList.UseCompatibleStateImageBehavior = false;
            CreatureList.View = System.Windows.Forms.View.Details;
            CreatureList.ItemDrag += OppList_ItemDrag;
            CreatureList.DoubleClick += OppEditBtn_Click;
            // 
            // CreatureNameHdr
            // 
            CreatureNameHdr.Text = "Creature";
            CreatureNameHdr.Width = 300;
            // 
            // CreatureInfoHdr
            // 
            CreatureInfoHdr.Text = "Info";
            CreatureInfoHdr.Width = 150;
            // 
            // CreatureContext
            // 
            CreatureContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            CreatureContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { CreatureContextRemove, CreatureContextCategory });
            CreatureContext.Name = "CreatureContext";
            CreatureContext.Size = new System.Drawing.Size(151, 48);
            // 
            // CreatureContextRemove
            // 
            CreatureContextRemove.Name = "CreatureContextRemove";
            CreatureContextRemove.Size = new System.Drawing.Size(150, 22);
            CreatureContextRemove.Text = "Remove";
            CreatureContextRemove.Click += CreatureContextRemove_Click;
            // 
            // CreatureContextCategory
            // 
            CreatureContextCategory.Name = "CreatureContextCategory";
            CreatureContextCategory.Size = new System.Drawing.Size(150, 22);
            CreatureContextCategory.Text = "Set Category...";
            CreatureContextCategory.Click += CreatureContextCategory_Click;
            // 
            // CreatureSearchToolbar
            // 
            CreatureSearchToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            CreatureSearchToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { SearchLbl, SearchBox, toolStripSeparator11, CategorisedBtn, UncategorisedBtn });
            CreatureSearchToolbar.Location = new System.Drawing.Point(4, 29);
            CreatureSearchToolbar.Name = "CreatureSearchToolbar";
            CreatureSearchToolbar.Size = new System.Drawing.Size(716, 25);
            CreatureSearchToolbar.TabIndex = 2;
            CreatureSearchToolbar.Text = "toolStrip1";
            // 
            // SearchLbl
            // 
            SearchLbl.Name = "SearchLbl";
            SearchLbl.Size = new System.Drawing.Size(45, 22);
            SearchLbl.Text = "Search:";
            // 
            // SearchBox
            // 
            SearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new System.Drawing.Size(174, 25);
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // toolStripSeparator11
            // 
            toolStripSeparator11.Name = "toolStripSeparator11";
            toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // CategorisedBtn
            // 
            CategorisedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CategorisedBtn.Image = (System.Drawing.Image)resources.GetObject("CategorisedBtn.Image");
            CategorisedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            CategorisedBtn.Name = "CategorisedBtn";
            CategorisedBtn.Size = new System.Drawing.Size(74, 22);
            CategorisedBtn.Text = "Categorised";
            CategorisedBtn.Click += CreatureFilterCategorised_Click;
            // 
            // UncategorisedBtn
            // 
            UncategorisedBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            UncategorisedBtn.Image = (System.Drawing.Image)resources.GetObject("UncategorisedBtn.Image");
            UncategorisedBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            UncategorisedBtn.Name = "UncategorisedBtn";
            UncategorisedBtn.Size = new System.Drawing.Size(87, 22);
            UncategorisedBtn.Text = "Uncategorised";
            UncategorisedBtn.Click += CreatureFilterUncategorised_Click;
            // 
            // CreatureToolbar
            // 
            CreatureToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            CreatureToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { CreatureAddBtn, OppRemoveBtn, OppEditBtn, toolStripSeparator1, CreatureCutBtn, CreatureCopyBtn, CreaturePasteBtn, toolStripSeparator4, CreatureStatBlockBtn, toolStripSeparator10, CreatureTools });
            CreatureToolbar.Location = new System.Drawing.Point(4, 4);
            CreatureToolbar.Name = "CreatureToolbar";
            CreatureToolbar.Size = new System.Drawing.Size(716, 25);
            CreatureToolbar.TabIndex = 0;
            CreatureToolbar.Text = "toolStrip2";
            // 
            // CreatureAddBtn
            // 
            CreatureAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CreatureAddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { CreatureAddSingle, toolStripSeparator19, CreatureImport });
            CreatureAddBtn.Image = (System.Drawing.Image)resources.GetObject("CreatureAddBtn.Image");
            CreatureAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            CreatureAddBtn.Name = "CreatureAddBtn";
            CreatureAddBtn.Size = new System.Drawing.Size(42, 22);
            CreatureAddBtn.Text = "Add";
            // 
            // CreatureAddSingle
            // 
            CreatureAddSingle.Name = "CreatureAddSingle";
            CreatureAddSingle.Size = new System.Drawing.Size(162, 22);
            CreatureAddSingle.Text = "Add a Creature...";
            CreatureAddSingle.Click += CreatureAddBtn_Click;
            // 
            // toolStripSeparator19
            // 
            toolStripSeparator19.Name = "toolStripSeparator19";
            toolStripSeparator19.Size = new System.Drawing.Size(159, 6);
            // 
            // CreatureImport
            // 
            CreatureImport.Name = "CreatureImport";
            CreatureImport.Size = new System.Drawing.Size(162, 22);
            CreatureImport.Text = "Import...";
            CreatureImport.Click += CreatureImport_Click;
            // 
            // OppRemoveBtn
            // 
            OppRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            OppRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("OppRemoveBtn.Image");
            OppRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            OppRemoveBtn.Name = "OppRemoveBtn";
            OppRemoveBtn.Size = new System.Drawing.Size(54, 22);
            OppRemoveBtn.Text = "Remove";
            OppRemoveBtn.Click += OppRemoveBtn_Click;
            // 
            // OppEditBtn
            // 
            OppEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            OppEditBtn.Image = (System.Drawing.Image)resources.GetObject("OppEditBtn.Image");
            OppEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            OppEditBtn.Name = "OppEditBtn";
            OppEditBtn.Size = new System.Drawing.Size(31, 22);
            OppEditBtn.Text = "Edit";
            OppEditBtn.Click += OppEditBtn_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CreatureCutBtn
            // 
            CreatureCutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CreatureCutBtn.Image = (System.Drawing.Image)resources.GetObject("CreatureCutBtn.Image");
            CreatureCutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            CreatureCutBtn.Name = "CreatureCutBtn";
            CreatureCutBtn.Size = new System.Drawing.Size(30, 22);
            CreatureCutBtn.Text = "Cut";
            CreatureCutBtn.Click += CreatureCutBtn_Click;
            // 
            // CreatureCopyBtn
            // 
            CreatureCopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CreatureCopyBtn.Image = (System.Drawing.Image)resources.GetObject("CreatureCopyBtn.Image");
            CreatureCopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            CreatureCopyBtn.Name = "CreatureCopyBtn";
            CreatureCopyBtn.Size = new System.Drawing.Size(39, 22);
            CreatureCopyBtn.Text = "Copy";
            CreatureCopyBtn.Click += CreatureCopyBtn_Click;
            // 
            // CreaturePasteBtn
            // 
            CreaturePasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CreaturePasteBtn.Image = (System.Drawing.Image)resources.GetObject("CreaturePasteBtn.Image");
            CreaturePasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            CreaturePasteBtn.Name = "CreaturePasteBtn";
            CreaturePasteBtn.Size = new System.Drawing.Size(39, 22);
            CreaturePasteBtn.Text = "Paste";
            CreaturePasteBtn.Click += CreaturePasteBtn_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // CreatureStatBlockBtn
            // 
            CreatureStatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CreatureStatBlockBtn.Image = (System.Drawing.Image)resources.GetObject("CreatureStatBlockBtn.Image");
            CreatureStatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            CreatureStatBlockBtn.Name = "CreatureStatBlockBtn";
            CreatureStatBlockBtn.Size = new System.Drawing.Size(63, 22);
            CreatureStatBlockBtn.Text = "Stat Block";
            CreatureStatBlockBtn.Click += CreatureStatBlockBtn_Click;
            // 
            // toolStripSeparator10
            // 
            toolStripSeparator10.Name = "toolStripSeparator10";
            toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // CreatureTools
            // 
            CreatureTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            CreatureTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { CreatureToolsDemographics, CreatureToolsPowerStatistics, CreatureToolsFilterList, CreatureToolsExport });
            CreatureTools.Image = (System.Drawing.Image)resources.GetObject("CreatureTools.Image");
            CreatureTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            CreatureTools.Name = "CreatureTools";
            CreatureTools.Size = new System.Drawing.Size(48, 22);
            CreatureTools.Text = "Tools";
            // 
            // CreatureToolsDemographics
            // 
            CreatureToolsDemographics.Name = "CreatureToolsDemographics";
            CreatureToolsDemographics.Size = new System.Drawing.Size(165, 22);
            CreatureToolsDemographics.Text = "Demographics";
            CreatureToolsDemographics.Click += CreatureDemoBtn_Click;
            // 
            // CreatureToolsPowerStatistics
            // 
            CreatureToolsPowerStatistics.Name = "CreatureToolsPowerStatistics";
            CreatureToolsPowerStatistics.Size = new System.Drawing.Size(165, 22);
            CreatureToolsPowerStatistics.Text = "Power Statistics...";
            CreatureToolsPowerStatistics.Click += PowerStatsBtn_Click;
            // 
            // CreatureToolsFilterList
            // 
            CreatureToolsFilterList.Name = "CreatureToolsFilterList";
            CreatureToolsFilterList.Size = new System.Drawing.Size(165, 22);
            CreatureToolsFilterList.Text = "Filter List";
            CreatureToolsFilterList.Click += FilterBtn_Click;
            // 
            // CreatureToolsExport
            // 
            CreatureToolsExport.Name = "CreatureToolsExport";
            CreatureToolsExport.Size = new System.Drawing.Size(165, 22);
            CreatureToolsExport.Text = "Export...";
            CreatureToolsExport.Click += CreatureToolsExport_Click;
            // 
            // TemplatesPage
            // 
            TemplatesPage.Controls.Add(TemplateList);
            TemplatesPage.Controls.Add(TemplateToolbar);
            TemplatesPage.Location = new System.Drawing.Point(4, 24);
            TemplatesPage.Margin = new System.Windows.Forms.Padding(4);
            TemplatesPage.Name = "TemplatesPage";
            TemplatesPage.Padding = new System.Windows.Forms.Padding(4);
            TemplatesPage.Size = new System.Drawing.Size(724, 117);
            TemplatesPage.TabIndex = 1;
            TemplatesPage.Text = "Templates";
            TemplatesPage.UseVisualStyleBackColor = true;
            // 
            // TemplateList
            // 
            TemplateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { TemplateNameHdr, TemplateInfoHdr });
            TemplateList.ContextMenuStrip = TemplateContext;
            TemplateList.Dock = System.Windows.Forms.DockStyle.Fill;
            TemplateList.FullRowSelect = true;
            listViewGroup1.Header = "Functional Templates";
            listViewGroup1.Name = "FunctionalGroup";
            listViewGroup2.Header = "Class Templates";
            listViewGroup2.Name = "ClassGroup";
            listViewGroup3.Header = "Themes";
            listViewGroup3.Name = "ThemeGroup";
            TemplateList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1, listViewGroup2, listViewGroup3 });
            TemplateList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            TemplateList.Location = new System.Drawing.Point(4, 29);
            TemplateList.Margin = new System.Windows.Forms.Padding(4);
            TemplateList.Name = "TemplateList";
            TemplateList.Size = new System.Drawing.Size(716, 84);
            TemplateList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            TemplateList.TabIndex = 2;
            TemplateList.UseCompatibleStateImageBehavior = false;
            TemplateList.View = System.Windows.Forms.View.Details;
            TemplateList.ItemDrag += TemplateList_ItemDrag;
            TemplateList.DoubleClick += TemplateEditBtn_Click;
            // 
            // TemplateNameHdr
            // 
            TemplateNameHdr.Text = "Template";
            TemplateNameHdr.Width = 300;
            // 
            // TemplateInfoHdr
            // 
            TemplateInfoHdr.Text = "Role";
            TemplateInfoHdr.Width = 150;
            // 
            // TemplateContext
            // 
            TemplateContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            TemplateContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TemplateContextRemove, TemplateContextType });
            TemplateContext.Name = "TemplateContext";
            TemplateContext.Size = new System.Drawing.Size(118, 48);
            // 
            // TemplateContextRemove
            // 
            TemplateContextRemove.Name = "TemplateContextRemove";
            TemplateContextRemove.Size = new System.Drawing.Size(117, 22);
            TemplateContextRemove.Text = "Remove";
            TemplateContextRemove.Click += TemplateContextRemove_Click;
            // 
            // TemplateContextType
            // 
            TemplateContextType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TemplateFunctional, TemplateClass });
            TemplateContextType.Name = "TemplateContextType";
            TemplateContextType.Size = new System.Drawing.Size(117, 22);
            TemplateContextType.Text = "Type";
            // 
            // TemplateFunctional
            // 
            TemplateFunctional.Name = "TemplateFunctional";
            TemplateFunctional.Size = new System.Drawing.Size(130, 22);
            TemplateFunctional.Text = "Functional";
            TemplateFunctional.Click += TemplateFunctional_Click;
            // 
            // TemplateClass
            // 
            TemplateClass.Name = "TemplateClass";
            TemplateClass.Size = new System.Drawing.Size(130, 22);
            TemplateClass.Text = "Class";
            TemplateClass.Click += TemplateClass_Click;
            // 
            // TemplateToolbar
            // 
            TemplateToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            TemplateToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TemplateAddBtn, TemplateRemoveBtn, TemplateEditBtn, toolStripSeparator2, TemplateCutBtn, TemplateCopyBtn, TemplatePasteBtn, toolStripSeparator18, TemplateStatBlock, toolStripSeparator21, TemplateTools });
            TemplateToolbar.Location = new System.Drawing.Point(4, 4);
            TemplateToolbar.Name = "TemplateToolbar";
            TemplateToolbar.Size = new System.Drawing.Size(716, 25);
            TemplateToolbar.TabIndex = 1;
            TemplateToolbar.Text = "toolStrip2";
            // 
            // TemplateAddBtn
            // 
            TemplateAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplateAddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { addTemplateToolStripMenuItem, TemplateAddTheme, toolStripSeparator20, TemplateImport });
            TemplateAddBtn.Image = (System.Drawing.Image)resources.GetObject("TemplateAddBtn.Image");
            TemplateAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplateAddBtn.Name = "TemplateAddBtn";
            TemplateAddBtn.Size = new System.Drawing.Size(42, 22);
            TemplateAddBtn.Text = "Add";
            // 
            // addTemplateToolStripMenuItem
            // 
            addTemplateToolStripMenuItem.Name = "addTemplateToolStripMenuItem";
            addTemplateToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            addTemplateToolStripMenuItem.Text = "Add a Template...";
            addTemplateToolStripMenuItem.Click += TemplateAddBtn_Click;
            // 
            // TemplateAddTheme
            // 
            TemplateAddTheme.Name = "TemplateAddTheme";
            TemplateAddTheme.Size = new System.Drawing.Size(166, 22);
            TemplateAddTheme.Text = "Add a Theme...";
            TemplateAddTheme.Click += TemplateAddTheme_Click;
            // 
            // toolStripSeparator20
            // 
            toolStripSeparator20.Name = "toolStripSeparator20";
            toolStripSeparator20.Size = new System.Drawing.Size(163, 6);
            // 
            // TemplateImport
            // 
            TemplateImport.Name = "TemplateImport";
            TemplateImport.Size = new System.Drawing.Size(166, 22);
            TemplateImport.Text = "Import...";
            TemplateImport.Click += TemplateImport_Click;
            // 
            // TemplateRemoveBtn
            // 
            TemplateRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplateRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("TemplateRemoveBtn.Image");
            TemplateRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplateRemoveBtn.Name = "TemplateRemoveBtn";
            TemplateRemoveBtn.Size = new System.Drawing.Size(54, 22);
            TemplateRemoveBtn.Text = "Remove";
            TemplateRemoveBtn.Click += TemplateRemoveBtn_Click;
            // 
            // TemplateEditBtn
            // 
            TemplateEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplateEditBtn.Image = (System.Drawing.Image)resources.GetObject("TemplateEditBtn.Image");
            TemplateEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplateEditBtn.Name = "TemplateEditBtn";
            TemplateEditBtn.Size = new System.Drawing.Size(31, 22);
            TemplateEditBtn.Text = "Edit";
            TemplateEditBtn.Click += TemplateEditBtn_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // TemplateCutBtn
            // 
            TemplateCutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplateCutBtn.Image = (System.Drawing.Image)resources.GetObject("TemplateCutBtn.Image");
            TemplateCutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplateCutBtn.Name = "TemplateCutBtn";
            TemplateCutBtn.Size = new System.Drawing.Size(30, 22);
            TemplateCutBtn.Text = "Cut";
            TemplateCutBtn.Click += TemplateCutBtn_Click;
            // 
            // TemplateCopyBtn
            // 
            TemplateCopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplateCopyBtn.Image = (System.Drawing.Image)resources.GetObject("TemplateCopyBtn.Image");
            TemplateCopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplateCopyBtn.Name = "TemplateCopyBtn";
            TemplateCopyBtn.Size = new System.Drawing.Size(39, 22);
            TemplateCopyBtn.Text = "Copy";
            TemplateCopyBtn.Click += TemplateCopyBtn_Click;
            // 
            // TemplatePasteBtn
            // 
            TemplatePasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplatePasteBtn.Image = (System.Drawing.Image)resources.GetObject("TemplatePasteBtn.Image");
            TemplatePasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplatePasteBtn.Name = "TemplatePasteBtn";
            TemplatePasteBtn.Size = new System.Drawing.Size(39, 22);
            TemplatePasteBtn.Text = "Paste";
            TemplatePasteBtn.Click += TemplatePasteBtn_Click;
            // 
            // toolStripSeparator18
            // 
            toolStripSeparator18.Name = "toolStripSeparator18";
            toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // TemplateStatBlock
            // 
            TemplateStatBlock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplateStatBlock.Image = (System.Drawing.Image)resources.GetObject("TemplateStatBlock.Image");
            TemplateStatBlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplateStatBlock.Name = "TemplateStatBlock";
            TemplateStatBlock.Size = new System.Drawing.Size(63, 22);
            TemplateStatBlock.Text = "Stat Block";
            TemplateStatBlock.Click += TemplateStatBlock_Click;
            // 
            // toolStripSeparator21
            // 
            toolStripSeparator21.Name = "toolStripSeparator21";
            toolStripSeparator21.Size = new System.Drawing.Size(6, 25);
            // 
            // TemplateTools
            // 
            TemplateTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TemplateTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TemplateToolsExport });
            TemplateTools.Image = (System.Drawing.Image)resources.GetObject("TemplateTools.Image");
            TemplateTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            TemplateTools.Name = "TemplateTools";
            TemplateTools.Size = new System.Drawing.Size(48, 22);
            TemplateTools.Text = "Tools";
            // 
            // TemplateToolsExport
            // 
            TemplateToolsExport.Name = "TemplateToolsExport";
            TemplateToolsExport.Size = new System.Drawing.Size(116, 22);
            TemplateToolsExport.Text = "Export...";
            TemplateToolsExport.Click += TemplateToolsExport_Click;
            // 
            // TrapsPage
            // 
            TrapsPage.Controls.Add(TrapList);
            TrapsPage.Controls.Add(TrapToolbar);
            TrapsPage.Location = new System.Drawing.Point(4, 24);
            TrapsPage.Margin = new System.Windows.Forms.Padding(4);
            TrapsPage.Name = "TrapsPage";
            TrapsPage.Padding = new System.Windows.Forms.Padding(4);
            TrapsPage.Size = new System.Drawing.Size(724, 117);
            TrapsPage.TabIndex = 3;
            TrapsPage.Text = "Traps / Hazards";
            TrapsPage.UseVisualStyleBackColor = true;
            // 
            // TrapList
            // 
            TrapList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { TrapNameHdr, TrapInfoHdr });
            TrapList.ContextMenuStrip = TrapContext;
            TrapList.Dock = System.Windows.Forms.DockStyle.Fill;
            TrapList.FullRowSelect = true;
            listViewGroup4.Header = "Traps";
            listViewGroup4.Name = "TrapGroup";
            listViewGroup5.Header = "Hazards";
            listViewGroup5.Name = "HazardGroup";
            TrapList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup4, listViewGroup5 });
            TrapList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            TrapList.Location = new System.Drawing.Point(4, 29);
            TrapList.Margin = new System.Windows.Forms.Padding(4);
            TrapList.Name = "TrapList";
            TrapList.Size = new System.Drawing.Size(716, 84);
            TrapList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            TrapList.TabIndex = 4;
            TrapList.UseCompatibleStateImageBehavior = false;
            TrapList.View = System.Windows.Forms.View.Details;
            TrapList.ItemDrag += TrapList_ItemDrag;
            TrapList.DoubleClick += TrapEditBtn_Click;
            // 
            // TrapNameHdr
            // 
            TrapNameHdr.Text = "Trap";
            TrapNameHdr.Width = 300;
            // 
            // TrapInfoHdr
            // 
            TrapInfoHdr.Text = "Role";
            TrapInfoHdr.Width = 150;
            // 
            // TrapContext
            // 
            TrapContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            TrapContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TrapContextRemove, TrapContextType });
            TrapContext.Name = "TrapContext";
            TrapContext.Size = new System.Drawing.Size(118, 48);
            // 
            // TrapContextRemove
            // 
            TrapContextRemove.Name = "TrapContextRemove";
            TrapContextRemove.Size = new System.Drawing.Size(117, 22);
            TrapContextRemove.Text = "Remove";
            TrapContextRemove.Click += TrapContextRemove_Click;
            // 
            // TrapContextType
            // 
            TrapContextType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TrapTrap, TrapHazard });
            TrapContextType.Name = "TrapContextType";
            TrapContextType.Size = new System.Drawing.Size(117, 22);
            TrapContextType.Text = "Type";
            // 
            // TrapTrap
            // 
            TrapTrap.Name = "TrapTrap";
            TrapTrap.Size = new System.Drawing.Size(111, 22);
            TrapTrap.Text = "Trap";
            TrapTrap.Click += TrapTrap_Click;
            // 
            // TrapHazard
            // 
            TrapHazard.Name = "TrapHazard";
            TrapHazard.Size = new System.Drawing.Size(111, 22);
            TrapHazard.Text = "Hazard";
            TrapHazard.Click += TrapHazard_Click;
            // 
            // TrapToolbar
            // 
            TrapToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            TrapToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TrapAdd, TrapRemoveBtn, TrapEditBtn, toolStripSeparator6, TrapCutBtn, TrapCopyBtn, TrapPasteBtn, toolStripSeparator8, TrapStatBlockBtn, toolStripSeparator13, TrapTools });
            TrapToolbar.Location = new System.Drawing.Point(4, 4);
            TrapToolbar.Name = "TrapToolbar";
            TrapToolbar.Size = new System.Drawing.Size(716, 25);
            TrapToolbar.TabIndex = 3;
            TrapToolbar.Text = "toolStrip2";
            // 
            // TrapAdd
            // 
            TrapAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TrapAddAdd, toolStripSeparator25, TrapAddImport });
            TrapAdd.Image = (System.Drawing.Image)resources.GetObject("TrapAdd.Image");
            TrapAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapAdd.Name = "TrapAdd";
            TrapAdd.Size = new System.Drawing.Size(42, 22);
            TrapAdd.Text = "Add";
            // 
            // TrapAddAdd
            // 
            TrapAddAdd.Name = "TrapAddAdd";
            TrapAddAdd.Size = new System.Drawing.Size(140, 22);
            TrapAddAdd.Text = "Add a Trap...";
            TrapAddAdd.Click += TrapAddBtn_Click;
            // 
            // toolStripSeparator25
            // 
            toolStripSeparator25.Name = "toolStripSeparator25";
            toolStripSeparator25.Size = new System.Drawing.Size(137, 6);
            // 
            // TrapAddImport
            // 
            TrapAddImport.Name = "TrapAddImport";
            TrapAddImport.Size = new System.Drawing.Size(140, 22);
            TrapAddImport.Text = "Import...";
            TrapAddImport.Click += TrapAddImport_Click;
            // 
            // TrapRemoveBtn
            // 
            TrapRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("TrapRemoveBtn.Image");
            TrapRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapRemoveBtn.Name = "TrapRemoveBtn";
            TrapRemoveBtn.Size = new System.Drawing.Size(54, 22);
            TrapRemoveBtn.Text = "Remove";
            TrapRemoveBtn.Click += TrapRemoveBtn_Click;
            // 
            // TrapEditBtn
            // 
            TrapEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapEditBtn.Image = (System.Drawing.Image)resources.GetObject("TrapEditBtn.Image");
            TrapEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapEditBtn.Name = "TrapEditBtn";
            TrapEditBtn.Size = new System.Drawing.Size(31, 22);
            TrapEditBtn.Text = "Edit";
            TrapEditBtn.Click += TrapEditBtn_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // TrapCutBtn
            // 
            TrapCutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapCutBtn.Image = (System.Drawing.Image)resources.GetObject("TrapCutBtn.Image");
            TrapCutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapCutBtn.Name = "TrapCutBtn";
            TrapCutBtn.Size = new System.Drawing.Size(30, 22);
            TrapCutBtn.Text = "Cut";
            TrapCutBtn.Click += TrapCutBtn_Click;
            // 
            // TrapCopyBtn
            // 
            TrapCopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapCopyBtn.Image = (System.Drawing.Image)resources.GetObject("TrapCopyBtn.Image");
            TrapCopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapCopyBtn.Name = "TrapCopyBtn";
            TrapCopyBtn.Size = new System.Drawing.Size(39, 22);
            TrapCopyBtn.Text = "Copy";
            TrapCopyBtn.Click += TrapCopyBtn_Click;
            // 
            // TrapPasteBtn
            // 
            TrapPasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapPasteBtn.Image = (System.Drawing.Image)resources.GetObject("TrapPasteBtn.Image");
            TrapPasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapPasteBtn.Name = "TrapPasteBtn";
            TrapPasteBtn.Size = new System.Drawing.Size(39, 22);
            TrapPasteBtn.Text = "Paste";
            TrapPasteBtn.Click += TrapPasteBtn_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // TrapStatBlockBtn
            // 
            TrapStatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapStatBlockBtn.Image = (System.Drawing.Image)resources.GetObject("TrapStatBlockBtn.Image");
            TrapStatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapStatBlockBtn.Name = "TrapStatBlockBtn";
            TrapStatBlockBtn.Size = new System.Drawing.Size(63, 22);
            TrapStatBlockBtn.Text = "Stat Block";
            TrapStatBlockBtn.Click += TrapStatBlockBtn_Click;
            // 
            // toolStripSeparator13
            // 
            toolStripSeparator13.Name = "toolStripSeparator13";
            toolStripSeparator13.Size = new System.Drawing.Size(6, 25);
            // 
            // TrapTools
            // 
            TrapTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TrapTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TrapToolsDemographics, TrapToolsExport });
            TrapTools.Image = (System.Drawing.Image)resources.GetObject("TrapTools.Image");
            TrapTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            TrapTools.Name = "TrapTools";
            TrapTools.Size = new System.Drawing.Size(48, 22);
            TrapTools.Text = "Tools";
            // 
            // TrapToolsDemographics
            // 
            TrapToolsDemographics.Name = "TrapToolsDemographics";
            TrapToolsDemographics.Size = new System.Drawing.Size(151, 22);
            TrapToolsDemographics.Text = "Demographics";
            TrapToolsDemographics.Click += TrapDemoBtn_Click;
            // 
            // TrapToolsExport
            // 
            TrapToolsExport.Name = "TrapToolsExport";
            TrapToolsExport.Size = new System.Drawing.Size(151, 22);
            TrapToolsExport.Text = "Export...";
            TrapToolsExport.Click += TrapToolsExport_Click;
            // 
            // ChallengePage
            // 
            ChallengePage.Controls.Add(ChallengeList);
            ChallengePage.Controls.Add(ChallengeToolbar);
            ChallengePage.Location = new System.Drawing.Point(4, 24);
            ChallengePage.Margin = new System.Windows.Forms.Padding(4);
            ChallengePage.Name = "ChallengePage";
            ChallengePage.Padding = new System.Windows.Forms.Padding(4);
            ChallengePage.Size = new System.Drawing.Size(724, 117);
            ChallengePage.TabIndex = 4;
            ChallengePage.Text = "Skill Challenges";
            ChallengePage.UseVisualStyleBackColor = true;
            // 
            // ChallengeList
            // 
            ChallengeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ChallengeNameHdr, ChallengeInfoHdr });
            ChallengeList.Dock = System.Windows.Forms.DockStyle.Fill;
            ChallengeList.FullRowSelect = true;
            listViewGroup6.Header = "Traps";
            listViewGroup6.Name = "TrapGroup";
            listViewGroup7.Header = "Hazards";
            listViewGroup7.Name = "HazardGroup";
            ChallengeList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup6, listViewGroup7 });
            ChallengeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            ChallengeList.Location = new System.Drawing.Point(4, 29);
            ChallengeList.Margin = new System.Windows.Forms.Padding(4);
            ChallengeList.Name = "ChallengeList";
            ChallengeList.Size = new System.Drawing.Size(716, 84);
            ChallengeList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            ChallengeList.TabIndex = 6;
            ChallengeList.UseCompatibleStateImageBehavior = false;
            ChallengeList.View = System.Windows.Forms.View.Details;
            ChallengeList.ItemDrag += ChallengeList_ItemDrag;
            ChallengeList.DoubleClick += ChallengeEditBtn_Click;
            // 
            // ChallengeNameHdr
            // 
            ChallengeNameHdr.Text = "Challenge";
            ChallengeNameHdr.Width = 300;
            // 
            // ChallengeInfoHdr
            // 
            ChallengeInfoHdr.Text = "Complexity";
            ChallengeInfoHdr.Width = 150;
            // 
            // ChallengeToolbar
            // 
            ChallengeToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            ChallengeToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ChallengeAdd, ChallengeRemoveBtn, ChallengeEditBtn, toolStripSeparator7, ChallengeCutBtn, ChallengeCopyBtn, ChallengePasteBtn, toolStripSeparator9, ChallengeStatBlockBtn, toolStripSeparator22, ChallengeTools });
            ChallengeToolbar.Location = new System.Drawing.Point(4, 4);
            ChallengeToolbar.Name = "ChallengeToolbar";
            ChallengeToolbar.Size = new System.Drawing.Size(716, 25);
            ChallengeToolbar.TabIndex = 5;
            ChallengeToolbar.Text = "toolStrip2";
            // 
            // ChallengeAdd
            // 
            ChallengeAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengeAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ChallengeAddAdd, toolStripSeparator26, ChallengeAddImport });
            ChallengeAdd.Image = (System.Drawing.Image)resources.GetObject("ChallengeAdd.Image");
            ChallengeAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengeAdd.Name = "ChallengeAdd";
            ChallengeAdd.Size = new System.Drawing.Size(42, 22);
            ChallengeAdd.Text = "Add";
            // 
            // ChallengeAddAdd
            // 
            ChallengeAddAdd.Name = "ChallengeAddAdd";
            ChallengeAddAdd.Size = new System.Drawing.Size(194, 22);
            ChallengeAddAdd.Text = "Add a Skill Challenge...";
            ChallengeAddAdd.Click += ChallengeAddBtn_Click;
            // 
            // toolStripSeparator26
            // 
            toolStripSeparator26.Name = "toolStripSeparator26";
            toolStripSeparator26.Size = new System.Drawing.Size(191, 6);
            // 
            // ChallengeAddImport
            // 
            ChallengeAddImport.Name = "ChallengeAddImport";
            ChallengeAddImport.Size = new System.Drawing.Size(194, 22);
            ChallengeAddImport.Text = "Import...";
            ChallengeAddImport.Click += ChallengeAddImport_Click;
            // 
            // ChallengeRemoveBtn
            // 
            ChallengeRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengeRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("ChallengeRemoveBtn.Image");
            ChallengeRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengeRemoveBtn.Name = "ChallengeRemoveBtn";
            ChallengeRemoveBtn.Size = new System.Drawing.Size(54, 22);
            ChallengeRemoveBtn.Text = "Remove";
            ChallengeRemoveBtn.Click += ChallengeRemoveBtn_Click;
            // 
            // ChallengeEditBtn
            // 
            ChallengeEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengeEditBtn.Image = (System.Drawing.Image)resources.GetObject("ChallengeEditBtn.Image");
            ChallengeEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengeEditBtn.Name = "ChallengeEditBtn";
            ChallengeEditBtn.Size = new System.Drawing.Size(31, 22);
            ChallengeEditBtn.Text = "Edit";
            ChallengeEditBtn.Click += ChallengeEditBtn_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // ChallengeCutBtn
            // 
            ChallengeCutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengeCutBtn.Image = (System.Drawing.Image)resources.GetObject("ChallengeCutBtn.Image");
            ChallengeCutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengeCutBtn.Name = "ChallengeCutBtn";
            ChallengeCutBtn.Size = new System.Drawing.Size(30, 22);
            ChallengeCutBtn.Text = "Cut";
            ChallengeCutBtn.Click += ChallengeCutBtn_Click;
            // 
            // ChallengeCopyBtn
            // 
            ChallengeCopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengeCopyBtn.Image = (System.Drawing.Image)resources.GetObject("ChallengeCopyBtn.Image");
            ChallengeCopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengeCopyBtn.Name = "ChallengeCopyBtn";
            ChallengeCopyBtn.Size = new System.Drawing.Size(39, 22);
            ChallengeCopyBtn.Text = "Copy";
            ChallengeCopyBtn.Click += ChallengeCopyBtn_Click;
            // 
            // ChallengePasteBtn
            // 
            ChallengePasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengePasteBtn.Image = (System.Drawing.Image)resources.GetObject("ChallengePasteBtn.Image");
            ChallengePasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengePasteBtn.Name = "ChallengePasteBtn";
            ChallengePasteBtn.Size = new System.Drawing.Size(39, 22);
            ChallengePasteBtn.Text = "Paste";
            ChallengePasteBtn.Click += ChallengePasteBtn_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // ChallengeStatBlockBtn
            // 
            ChallengeStatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengeStatBlockBtn.Image = (System.Drawing.Image)resources.GetObject("ChallengeStatBlockBtn.Image");
            ChallengeStatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengeStatBlockBtn.Name = "ChallengeStatBlockBtn";
            ChallengeStatBlockBtn.Size = new System.Drawing.Size(63, 22);
            ChallengeStatBlockBtn.Text = "Stat Block";
            ChallengeStatBlockBtn.Click += ChallengeStatBlockBtn_Click;
            // 
            // toolStripSeparator22
            // 
            toolStripSeparator22.Name = "toolStripSeparator22";
            toolStripSeparator22.Size = new System.Drawing.Size(6, 25);
            // 
            // ChallengeTools
            // 
            ChallengeTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ChallengeTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ChallengeToolsExport });
            ChallengeTools.Image = (System.Drawing.Image)resources.GetObject("ChallengeTools.Image");
            ChallengeTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            ChallengeTools.Name = "ChallengeTools";
            ChallengeTools.Size = new System.Drawing.Size(48, 22);
            ChallengeTools.Text = "Tools";
            // 
            // ChallengeToolsExport
            // 
            ChallengeToolsExport.Name = "ChallengeToolsExport";
            ChallengeToolsExport.Size = new System.Drawing.Size(116, 22);
            ChallengeToolsExport.Text = "Export...";
            ChallengeToolsExport.Click += ChallengeToolsExport_Click;
            // 
            // MagicItemsPage
            // 
            MagicItemsPage.Controls.Add(splitContainer1);
            MagicItemsPage.Location = new System.Drawing.Point(4, 24);
            MagicItemsPage.Margin = new System.Windows.Forms.Padding(4);
            MagicItemsPage.Name = "MagicItemsPage";
            MagicItemsPage.Padding = new System.Windows.Forms.Padding(4);
            MagicItemsPage.Size = new System.Drawing.Size(724, 117);
            MagicItemsPage.TabIndex = 6;
            MagicItemsPage.Text = "Magic Items";
            MagicItemsPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(4, 4);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(MagicItemList);
            splitContainer1.Panel1.Controls.Add(MagicItemToolbar);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(MagicItemVersionList);
            splitContainer1.Panel2.Controls.Add(MagicItemVersionToolbar);
            splitContainer1.Size = new System.Drawing.Size(716, 109);
            splitContainer1.SplitterDistance = 360;
            splitContainer1.TabIndex = 7;
            // 
            // MagicItemList
            // 
            MagicItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { MagicItemHdr });
            MagicItemList.ContextMenuStrip = MagicItemContext;
            MagicItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            MagicItemList.FullRowSelect = true;
            MagicItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            MagicItemList.Location = new System.Drawing.Point(0, 25);
            MagicItemList.Margin = new System.Windows.Forms.Padding(4);
            MagicItemList.MultiSelect = false;
            MagicItemList.Name = "MagicItemList";
            MagicItemList.Size = new System.Drawing.Size(360, 84);
            MagicItemList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            MagicItemList.TabIndex = 6;
            MagicItemList.UseCompatibleStateImageBehavior = false;
            MagicItemList.View = System.Windows.Forms.View.Details;
            MagicItemList.SelectedIndexChanged += MagicItemList_SelectedIndexChanged;
            // 
            // MagicItemHdr
            // 
            MagicItemHdr.Text = "Magic Item";
            MagicItemHdr.Width = 273;
            // 
            // MagicItemContext
            // 
            MagicItemContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            MagicItemContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MagicItemContextRemove });
            MagicItemContext.Name = "ChallengeContext";
            MagicItemContext.Size = new System.Drawing.Size(118, 26);
            // 
            // MagicItemContextRemove
            // 
            MagicItemContextRemove.Name = "MagicItemContextRemove";
            MagicItemContextRemove.Size = new System.Drawing.Size(117, 22);
            MagicItemContextRemove.Text = "Remove";
            MagicItemContextRemove.Click += MagicItemContextRemove_Click;
            // 
            // MagicItemToolbar
            // 
            MagicItemToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            MagicItemToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MagicItemAdd, toolStripSeparator14, MagicItemTools });
            MagicItemToolbar.Location = new System.Drawing.Point(0, 0);
            MagicItemToolbar.Name = "MagicItemToolbar";
            MagicItemToolbar.Size = new System.Drawing.Size(360, 25);
            MagicItemToolbar.TabIndex = 5;
            MagicItemToolbar.Text = "toolStrip2";
            // 
            // MagicItemAdd
            // 
            MagicItemAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MagicItemAddAdd, toolStripSeparator27, MagicItemAddImport });
            MagicItemAdd.Image = (System.Drawing.Image)resources.GetObject("MagicItemAdd.Image");
            MagicItemAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemAdd.Name = "MagicItemAdd";
            MagicItemAdd.Size = new System.Drawing.Size(42, 22);
            MagicItemAdd.Text = "Add";
            // 
            // MagicItemAddAdd
            // 
            MagicItemAddAdd.Name = "MagicItemAddAdd";
            MagicItemAddAdd.Size = new System.Drawing.Size(177, 22);
            MagicItemAddAdd.Text = "Add a Magic Item...";
            MagicItemAddAdd.Click += MagicItemAddBtn_Click;
            // 
            // toolStripSeparator27
            // 
            toolStripSeparator27.Name = "toolStripSeparator27";
            toolStripSeparator27.Size = new System.Drawing.Size(174, 6);
            // 
            // MagicItemAddImport
            // 
            MagicItemAddImport.Name = "MagicItemAddImport";
            MagicItemAddImport.Size = new System.Drawing.Size(177, 22);
            MagicItemAddImport.Text = "Import...";
            MagicItemAddImport.Click += MagicItemAddImport_Click;
            // 
            // toolStripSeparator14
            // 
            toolStripSeparator14.Name = "toolStripSeparator14";
            toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // MagicItemTools
            // 
            MagicItemTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { MagicItemToolsDemographics, MagicItemToolsExport });
            MagicItemTools.Image = (System.Drawing.Image)resources.GetObject("MagicItemTools.Image");
            MagicItemTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemTools.Name = "MagicItemTools";
            MagicItemTools.Size = new System.Drawing.Size(48, 22);
            MagicItemTools.Text = "Tools";
            // 
            // MagicItemToolsDemographics
            // 
            MagicItemToolsDemographics.Name = "MagicItemToolsDemographics";
            MagicItemToolsDemographics.Size = new System.Drawing.Size(151, 22);
            MagicItemToolsDemographics.Text = "Demographics";
            MagicItemToolsDemographics.Click += MagicItemDemoBtn_Click;
            // 
            // MagicItemToolsExport
            // 
            MagicItemToolsExport.Name = "MagicItemToolsExport";
            MagicItemToolsExport.Size = new System.Drawing.Size(151, 22);
            MagicItemToolsExport.Text = "Export...";
            MagicItemToolsExport.Click += MagicItemsToolsExport_Click;
            // 
            // MagicItemVersionList
            // 
            MagicItemVersionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { MagicItemInfoHdr });
            MagicItemVersionList.Dock = System.Windows.Forms.DockStyle.Fill;
            MagicItemVersionList.FullRowSelect = true;
            listViewGroup8.Header = "Heroic Tier";
            listViewGroup8.Name = "listViewGroup1";
            listViewGroup9.Header = "Paragon Tier";
            listViewGroup9.Name = "listViewGroup2";
            listViewGroup10.Header = "Epic Tier";
            listViewGroup10.Name = "listViewGroup3";
            MagicItemVersionList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup8, listViewGroup9, listViewGroup10 });
            MagicItemVersionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            MagicItemVersionList.Location = new System.Drawing.Point(0, 25);
            MagicItemVersionList.Margin = new System.Windows.Forms.Padding(4);
            MagicItemVersionList.Name = "MagicItemVersionList";
            MagicItemVersionList.Size = new System.Drawing.Size(352, 84);
            MagicItemVersionList.TabIndex = 1;
            MagicItemVersionList.UseCompatibleStateImageBehavior = false;
            MagicItemVersionList.View = System.Windows.Forms.View.Details;
            MagicItemVersionList.ItemDrag += MagicItemList_ItemDrag;
            MagicItemVersionList.DoubleClick += MagicItemEditBtn_Click;
            // 
            // MagicItemInfoHdr
            // 
            MagicItemInfoHdr.Text = "Version";
            MagicItemInfoHdr.Width = 250;
            // 
            // MagicItemVersionToolbar
            // 
            MagicItemVersionToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            MagicItemVersionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { MagicItemRemoveBtn, toolStripSeparator5, MagicItemEditBtn, MagicItemCutBtn, MagicItemCopyBtn, MagicItemPasteBtn, toolStripSeparator12, MagicItemStatBlockBtn });
            MagicItemVersionToolbar.Location = new System.Drawing.Point(0, 0);
            MagicItemVersionToolbar.Name = "MagicItemVersionToolbar";
            MagicItemVersionToolbar.Size = new System.Drawing.Size(352, 25);
            MagicItemVersionToolbar.TabIndex = 0;
            MagicItemVersionToolbar.Text = "toolStrip1";
            // 
            // MagicItemRemoveBtn
            // 
            MagicItemRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("MagicItemRemoveBtn.Image");
            MagicItemRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemRemoveBtn.Name = "MagicItemRemoveBtn";
            MagicItemRemoveBtn.Size = new System.Drawing.Size(54, 22);
            MagicItemRemoveBtn.Text = "Remove";
            MagicItemRemoveBtn.Click += MagicItemRemoveBtn_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // MagicItemEditBtn
            // 
            MagicItemEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemEditBtn.Image = (System.Drawing.Image)resources.GetObject("MagicItemEditBtn.Image");
            MagicItemEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemEditBtn.Name = "MagicItemEditBtn";
            MagicItemEditBtn.Size = new System.Drawing.Size(31, 22);
            MagicItemEditBtn.Text = "Edit";
            MagicItemEditBtn.Click += MagicItemEditBtn_Click;
            // 
            // MagicItemCutBtn
            // 
            MagicItemCutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemCutBtn.Image = (System.Drawing.Image)resources.GetObject("MagicItemCutBtn.Image");
            MagicItemCutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemCutBtn.Name = "MagicItemCutBtn";
            MagicItemCutBtn.Size = new System.Drawing.Size(30, 22);
            MagicItemCutBtn.Text = "Cut";
            MagicItemCutBtn.Click += MagicItemCutBtn_Click;
            // 
            // MagicItemCopyBtn
            // 
            MagicItemCopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemCopyBtn.Image = (System.Drawing.Image)resources.GetObject("MagicItemCopyBtn.Image");
            MagicItemCopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemCopyBtn.Name = "MagicItemCopyBtn";
            MagicItemCopyBtn.Size = new System.Drawing.Size(39, 22);
            MagicItemCopyBtn.Text = "Copy";
            MagicItemCopyBtn.Click += MagicItemCopyBtn_Click;
            // 
            // MagicItemPasteBtn
            // 
            MagicItemPasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemPasteBtn.Image = (System.Drawing.Image)resources.GetObject("MagicItemPasteBtn.Image");
            MagicItemPasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemPasteBtn.Name = "MagicItemPasteBtn";
            MagicItemPasteBtn.Size = new System.Drawing.Size(39, 22);
            MagicItemPasteBtn.Text = "Paste";
            MagicItemPasteBtn.Click += MagicItemPasteBtn_Click;
            // 
            // toolStripSeparator12
            // 
            toolStripSeparator12.Name = "toolStripSeparator12";
            toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // MagicItemStatBlockBtn
            // 
            MagicItemStatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MagicItemStatBlockBtn.Image = (System.Drawing.Image)resources.GetObject("MagicItemStatBlockBtn.Image");
            MagicItemStatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            MagicItemStatBlockBtn.Name = "MagicItemStatBlockBtn";
            MagicItemStatBlockBtn.Size = new System.Drawing.Size(63, 22);
            MagicItemStatBlockBtn.Text = "Stat Block";
            MagicItemStatBlockBtn.Click += MagicItemStatBlockBtn_Click;
            // 
            // TilesPage
            // 
            TilesPage.Controls.Add(TileList);
            TilesPage.Controls.Add(TileToolbar);
            TilesPage.Location = new System.Drawing.Point(4, 24);
            TilesPage.Margin = new System.Windows.Forms.Padding(4);
            TilesPage.Name = "TilesPage";
            TilesPage.Padding = new System.Windows.Forms.Padding(4);
            TilesPage.Size = new System.Drawing.Size(724, 117);
            TilesPage.TabIndex = 2;
            TilesPage.Text = "Map Tiles";
            TilesPage.UseVisualStyleBackColor = true;
            // 
            // TileList
            // 
            TileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { TileSetNameHdr });
            TileList.ContextMenuStrip = TileContext;
            TileList.Dock = System.Windows.Forms.DockStyle.Fill;
            TileList.FullRowSelect = true;
            TileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            TileList.Location = new System.Drawing.Point(4, 29);
            TileList.Margin = new System.Windows.Forms.Padding(4);
            TileList.Name = "TileList";
            TileList.Size = new System.Drawing.Size(716, 84);
            TileList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            TileList.TabIndex = 4;
            TileList.UseCompatibleStateImageBehavior = false;
            TileList.ItemDrag += TileSetView_ItemDrag;
            TileList.DoubleClick += TileSetEditBtn_Click;
            // 
            // TileSetNameHdr
            // 
            TileSetNameHdr.Text = "Tile Set";
            TileSetNameHdr.Width = 299;
            // 
            // TileContext
            // 
            TileContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            TileContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TileContextRemove, TileContextCategory, TileContextSize });
            TileContext.Name = "TileContext";
            TileContext.Size = new System.Drawing.Size(142, 70);
            // 
            // TileContextRemove
            // 
            TileContextRemove.Name = "TileContextRemove";
            TileContextRemove.Size = new System.Drawing.Size(141, 22);
            TileContextRemove.Text = "Remove";
            TileContextRemove.Click += TileContextRemove_Click;
            // 
            // TileContextCategory
            // 
            TileContextCategory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TilePlain, TileDoorway, TileStairway, TileFeature, toolStripSeparator15, TileSpecial, toolStripSeparator16, TileMap });
            TileContextCategory.Name = "TileContextCategory";
            TileContextCategory.Size = new System.Drawing.Size(141, 22);
            TileContextCategory.Text = "Set Category";
            // 
            // TilePlain
            // 
            TilePlain.Name = "TilePlain";
            TilePlain.Size = new System.Drawing.Size(130, 22);
            TilePlain.Text = "Plain Floor";
            TilePlain.Click += TilePlain_Click;
            // 
            // TileDoorway
            // 
            TileDoorway.Name = "TileDoorway";
            TileDoorway.Size = new System.Drawing.Size(130, 22);
            TileDoorway.Text = "Doorway";
            TileDoorway.Click += TileDoorway_Click;
            // 
            // TileStairway
            // 
            TileStairway.Name = "TileStairway";
            TileStairway.Size = new System.Drawing.Size(130, 22);
            TileStairway.Text = "Stairway";
            TileStairway.Click += TileStairway_Click;
            // 
            // TileFeature
            // 
            TileFeature.Name = "TileFeature";
            TileFeature.Size = new System.Drawing.Size(130, 22);
            TileFeature.Text = "Feature";
            TileFeature.Click += TileFeature_Click;
            // 
            // toolStripSeparator15
            // 
            toolStripSeparator15.Name = "toolStripSeparator15";
            toolStripSeparator15.Size = new System.Drawing.Size(127, 6);
            // 
            // TileSpecial
            // 
            TileSpecial.Name = "TileSpecial";
            TileSpecial.Size = new System.Drawing.Size(130, 22);
            TileSpecial.Text = "Special";
            TileSpecial.Click += TileSpecial_Click;
            // 
            // toolStripSeparator16
            // 
            toolStripSeparator16.Name = "toolStripSeparator16";
            toolStripSeparator16.Size = new System.Drawing.Size(127, 6);
            // 
            // TileMap
            // 
            TileMap.Name = "TileMap";
            TileMap.Size = new System.Drawing.Size(130, 22);
            TileMap.Text = "Full Map";
            TileMap.Click += TileMap_Click;
            // 
            // TileContextSize
            // 
            TileContextSize.Name = "TileContextSize";
            TileContextSize.Size = new System.Drawing.Size(141, 22);
            TileContextSize.Text = "Set Size...";
            TileContextSize.Click += TileContextSize_Click;
            // 
            // TileToolbar
            // 
            TileToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            TileToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TileAddBtn, TileRemoveBtn, TileEditBtn, toolStripSeparator3, TileCutBtn, TileCopyBtn, TilePasteBtn, toolStripSeparator23, TileTools });
            TileToolbar.Location = new System.Drawing.Point(4, 4);
            TileToolbar.Name = "TileToolbar";
            TileToolbar.Size = new System.Drawing.Size(716, 25);
            TileToolbar.TabIndex = 3;
            TileToolbar.Text = "toolStrip2";
            // 
            // TileAddBtn
            // 
            TileAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TileAddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { addTileToolStripMenuItem, toolStripSeparator24, TileAddImport, TileAddFolder });
            TileAddBtn.Image = (System.Drawing.Image)resources.GetObject("TileAddBtn.Image");
            TileAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TileAddBtn.Name = "TileAddBtn";
            TileAddBtn.Size = new System.Drawing.Size(42, 22);
            TileAddBtn.Text = "Add";
            // 
            // addTileToolStripMenuItem
            // 
            addTileToolStripMenuItem.Name = "addTileToolStripMenuItem";
            addTileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            addTileToolStripMenuItem.Text = "Add a Tile...";
            addTileToolStripMenuItem.Click += TileAddBtn_Click;
            // 
            // toolStripSeparator24
            // 
            toolStripSeparator24.Name = "toolStripSeparator24";
            toolStripSeparator24.Size = new System.Drawing.Size(161, 6);
            // 
            // TileAddImport
            // 
            TileAddImport.Name = "TileAddImport";
            TileAddImport.Size = new System.Drawing.Size(164, 22);
            TileAddImport.Text = "Import...";
            TileAddImport.Click += TileAddImport_Click;
            // 
            // TileAddFolder
            // 
            TileAddFolder.Name = "TileAddFolder";
            TileAddFolder.Size = new System.Drawing.Size(164, 22);
            TileAddFolder.Text = "Import a Folder...";
            TileAddFolder.Click += TileAddFolderBtn_Click;
            // 
            // TileRemoveBtn
            // 
            TileRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TileRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("TileRemoveBtn.Image");
            TileRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TileRemoveBtn.Name = "TileRemoveBtn";
            TileRemoveBtn.Size = new System.Drawing.Size(54, 22);
            TileRemoveBtn.Text = "Remove";
            TileRemoveBtn.Click += TileSetRemoveBtn_Click;
            // 
            // TileEditBtn
            // 
            TileEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TileEditBtn.Image = (System.Drawing.Image)resources.GetObject("TileEditBtn.Image");
            TileEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TileEditBtn.Name = "TileEditBtn";
            TileEditBtn.Size = new System.Drawing.Size(31, 22);
            TileEditBtn.Text = "Edit";
            TileEditBtn.Click += TileSetEditBtn_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // TileCutBtn
            // 
            TileCutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TileCutBtn.Image = (System.Drawing.Image)resources.GetObject("TileCutBtn.Image");
            TileCutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TileCutBtn.Name = "TileCutBtn";
            TileCutBtn.Size = new System.Drawing.Size(30, 22);
            TileCutBtn.Text = "Cut";
            TileCutBtn.Click += TileCutBtn_Click;
            // 
            // TileCopyBtn
            // 
            TileCopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TileCopyBtn.Image = (System.Drawing.Image)resources.GetObject("TileCopyBtn.Image");
            TileCopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TileCopyBtn.Name = "TileCopyBtn";
            TileCopyBtn.Size = new System.Drawing.Size(39, 22);
            TileCopyBtn.Text = "Copy";
            TileCopyBtn.Click += TileCopyBtn_Click;
            // 
            // TilePasteBtn
            // 
            TilePasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TilePasteBtn.Image = (System.Drawing.Image)resources.GetObject("TilePasteBtn.Image");
            TilePasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TilePasteBtn.Name = "TilePasteBtn";
            TilePasteBtn.Size = new System.Drawing.Size(39, 22);
            TilePasteBtn.Text = "Paste";
            TilePasteBtn.Click += TilePasteBtn_Click;
            // 
            // toolStripSeparator23
            // 
            toolStripSeparator23.Name = "toolStripSeparator23";
            toolStripSeparator23.Size = new System.Drawing.Size(6, 25);
            // 
            // TileTools
            // 
            TileTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TileTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TileToolsExport });
            TileTools.Image = (System.Drawing.Image)resources.GetObject("TileTools.Image");
            TileTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            TileTools.Name = "TileTools";
            TileTools.Size = new System.Drawing.Size(48, 22);
            TileTools.Text = "Tools";
            // 
            // TileToolsExport
            // 
            TileToolsExport.Name = "TileToolsExport";
            TileToolsExport.Size = new System.Drawing.Size(116, 22);
            TileToolsExport.Text = "Export...";
            TileToolsExport.Click += TileToolsExport_Click;
            // 
            // TerrainPowersPage
            // 
            TerrainPowersPage.Controls.Add(TerrainPowerList);
            TerrainPowersPage.Controls.Add(TerrainPowerToolbar);
            TerrainPowersPage.Location = new System.Drawing.Point(4, 24);
            TerrainPowersPage.Margin = new System.Windows.Forms.Padding(4);
            TerrainPowersPage.Name = "TerrainPowersPage";
            TerrainPowersPage.Padding = new System.Windows.Forms.Padding(4);
            TerrainPowersPage.Size = new System.Drawing.Size(724, 117);
            TerrainPowersPage.TabIndex = 7;
            TerrainPowersPage.Text = "Terrain Powers";
            TerrainPowersPage.UseVisualStyleBackColor = true;
            // 
            // TerrainPowerList
            // 
            TerrainPowerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { TPNameHdr, TPInfoHdr });
            TerrainPowerList.ContextMenuStrip = TPContext;
            TerrainPowerList.Dock = System.Windows.Forms.DockStyle.Fill;
            TerrainPowerList.FullRowSelect = true;
            listViewGroup11.Header = "Traps";
            listViewGroup11.Name = "TrapGroup";
            listViewGroup12.Header = "Hazards";
            listViewGroup12.Name = "HazardGroup";
            TerrainPowerList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup11, listViewGroup12 });
            TerrainPowerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            TerrainPowerList.Location = new System.Drawing.Point(4, 29);
            TerrainPowerList.Margin = new System.Windows.Forms.Padding(4);
            TerrainPowerList.Name = "TerrainPowerList";
            TerrainPowerList.Size = new System.Drawing.Size(716, 84);
            TerrainPowerList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            TerrainPowerList.TabIndex = 6;
            TerrainPowerList.UseCompatibleStateImageBehavior = false;
            TerrainPowerList.View = System.Windows.Forms.View.Details;
            TerrainPowerList.ItemDrag += TPList_ItemDrag;
            TerrainPowerList.DoubleClick += TPEditBtn_Click;
            // 
            // TPNameHdr
            // 
            TPNameHdr.Text = "Terrain Power";
            TPNameHdr.Width = 300;
            // 
            // TPInfoHdr
            // 
            TPInfoHdr.Text = "Info";
            TPInfoHdr.Width = 150;
            // 
            // TPContext
            // 
            TPContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            TPContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TPContextRemove });
            TPContext.Name = "ChallengeContext";
            TPContext.Size = new System.Drawing.Size(118, 26);
            // 
            // TPContextRemove
            // 
            TPContextRemove.Name = "TPContextRemove";
            TPContextRemove.Size = new System.Drawing.Size(117, 22);
            TPContextRemove.Text = "Remove";
            TPContextRemove.Click += TPContextRemove_Click;
            // 
            // TerrainPowerToolbar
            // 
            TerrainPowerToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            TerrainPowerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { TPAdd, TPRemoveBtn, TPEditBtn, toolStripSeparator29, TPCutBtn, TPCopyBtn, TPPasteBtn, toolStripSeparator30, TPStatBlockBtn, toolStripSeparator35, TPTools });
            TerrainPowerToolbar.Location = new System.Drawing.Point(4, 4);
            TerrainPowerToolbar.Name = "TerrainPowerToolbar";
            TerrainPowerToolbar.Size = new System.Drawing.Size(716, 25);
            TerrainPowerToolbar.TabIndex = 5;
            TerrainPowerToolbar.Text = "toolStrip2";
            // 
            // TPAdd
            // 
            TPAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TPAddTerrainPower, toolStripSeparator28, TPAddImport });
            TPAdd.Image = (System.Drawing.Image)resources.GetObject("TPAdd.Image");
            TPAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPAdd.Name = "TPAdd";
            TPAdd.Size = new System.Drawing.Size(42, 22);
            TPAdd.Text = "Add";
            // 
            // TPAddTerrainPower
            // 
            TPAddTerrainPower.Name = "TPAddTerrainPower";
            TPAddTerrainPower.Size = new System.Drawing.Size(189, 22);
            TPAddTerrainPower.Text = "Add a Terrain Power...";
            TPAddTerrainPower.Click += TPAddBtn_Click;
            // 
            // toolStripSeparator28
            // 
            toolStripSeparator28.Name = "toolStripSeparator28";
            toolStripSeparator28.Size = new System.Drawing.Size(186, 6);
            // 
            // TPAddImport
            // 
            TPAddImport.Name = "TPAddImport";
            TPAddImport.Size = new System.Drawing.Size(189, 22);
            TPAddImport.Text = "Import...";
            TPAddImport.Click += TPAddImport_Click;
            // 
            // TPRemoveBtn
            // 
            TPRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPRemoveBtn.Image = (System.Drawing.Image)resources.GetObject("TPRemoveBtn.Image");
            TPRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPRemoveBtn.Name = "TPRemoveBtn";
            TPRemoveBtn.Size = new System.Drawing.Size(54, 22);
            TPRemoveBtn.Text = "Remove";
            TPRemoveBtn.Click += TPRemoveBtn_Click;
            // 
            // TPEditBtn
            // 
            TPEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPEditBtn.Image = (System.Drawing.Image)resources.GetObject("TPEditBtn.Image");
            TPEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPEditBtn.Name = "TPEditBtn";
            TPEditBtn.Size = new System.Drawing.Size(31, 22);
            TPEditBtn.Text = "Edit";
            TPEditBtn.Click += TPEditBtn_Click;
            // 
            // toolStripSeparator29
            // 
            toolStripSeparator29.Name = "toolStripSeparator29";
            toolStripSeparator29.Size = new System.Drawing.Size(6, 25);
            // 
            // TPCutBtn
            // 
            TPCutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPCutBtn.Image = (System.Drawing.Image)resources.GetObject("TPCutBtn.Image");
            TPCutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPCutBtn.Name = "TPCutBtn";
            TPCutBtn.Size = new System.Drawing.Size(30, 22);
            TPCutBtn.Text = "Cut";
            TPCutBtn.Click += TPCutBtn_Click;
            // 
            // TPCopyBtn
            // 
            TPCopyBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPCopyBtn.Image = (System.Drawing.Image)resources.GetObject("TPCopyBtn.Image");
            TPCopyBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPCopyBtn.Name = "TPCopyBtn";
            TPCopyBtn.Size = new System.Drawing.Size(39, 22);
            TPCopyBtn.Text = "Copy";
            TPCopyBtn.Click += TPCopyBtn_Click;
            // 
            // TPPasteBtn
            // 
            TPPasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPPasteBtn.Image = (System.Drawing.Image)resources.GetObject("TPPasteBtn.Image");
            TPPasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPPasteBtn.Name = "TPPasteBtn";
            TPPasteBtn.Size = new System.Drawing.Size(39, 22);
            TPPasteBtn.Text = "Paste";
            TPPasteBtn.Click += TPPasteBtn_Click;
            // 
            // toolStripSeparator30
            // 
            toolStripSeparator30.Name = "toolStripSeparator30";
            toolStripSeparator30.Size = new System.Drawing.Size(6, 25);
            // 
            // TPStatBlockBtn
            // 
            TPStatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPStatBlockBtn.Image = (System.Drawing.Image)resources.GetObject("TPStatBlockBtn.Image");
            TPStatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPStatBlockBtn.Name = "TPStatBlockBtn";
            TPStatBlockBtn.Size = new System.Drawing.Size(63, 22);
            TPStatBlockBtn.Text = "Stat Block";
            TPStatBlockBtn.Click += TPStatBlockBtn_Click;
            // 
            // toolStripSeparator35
            // 
            toolStripSeparator35.Name = "toolStripSeparator35";
            toolStripSeparator35.Size = new System.Drawing.Size(6, 25);
            // 
            // TPTools
            // 
            TPTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            TPTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { TPToolsExport });
            TPTools.Image = (System.Drawing.Image)resources.GetObject("TPTools.Image");
            TPTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            TPTools.Name = "TPTools";
            TPTools.Size = new System.Drawing.Size(48, 22);
            TPTools.Text = "Tools";
            // 
            // TPToolsExport
            // 
            TPToolsExport.Name = "TPToolsExport";
            TPToolsExport.Size = new System.Drawing.Size(116, 22);
            TPToolsExport.Text = "Export...";
            TPToolsExport.Click += TPToolsExport_Click;
            // 
            // ArtifactPage
            // 
            ArtifactPage.Controls.Add(ArtifactList);
            ArtifactPage.Controls.Add(ArtifactToolbar);
            ArtifactPage.Location = new System.Drawing.Point(4, 24);
            ArtifactPage.Margin = new System.Windows.Forms.Padding(4);
            ArtifactPage.Name = "ArtifactPage";
            ArtifactPage.Padding = new System.Windows.Forms.Padding(4);
            ArtifactPage.Size = new System.Drawing.Size(724, 117);
            ArtifactPage.TabIndex = 8;
            ArtifactPage.Text = "Artifacts";
            ArtifactPage.UseVisualStyleBackColor = true;
            // 
            // ArtifactList
            // 
            ArtifactList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ArtifactHdr, ArtifactInfoHdr });
            ArtifactList.ContextMenuStrip = ArtifactContext;
            ArtifactList.Dock = System.Windows.Forms.DockStyle.Fill;
            ArtifactList.FullRowSelect = true;
            listViewGroup13.Header = "Traps";
            listViewGroup13.Name = "TrapGroup";
            listViewGroup14.Header = "Hazards";
            listViewGroup14.Name = "HazardGroup";
            ArtifactList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup13, listViewGroup14 });
            ArtifactList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            ArtifactList.Location = new System.Drawing.Point(4, 29);
            ArtifactList.Margin = new System.Windows.Forms.Padding(4);
            ArtifactList.Name = "ArtifactList";
            ArtifactList.Size = new System.Drawing.Size(716, 84);
            ArtifactList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            ArtifactList.TabIndex = 6;
            ArtifactList.UseCompatibleStateImageBehavior = false;
            ArtifactList.View = System.Windows.Forms.View.Details;
            ArtifactList.ItemDrag += ArtifactList_ItemDrag;
            ArtifactList.DoubleClick += ArtifactEdit_Click;
            // 
            // ArtifactHdr
            // 
            ArtifactHdr.Text = "Artifact";
            ArtifactHdr.Width = 300;
            // 
            // ArtifactInfoHdr
            // 
            ArtifactInfoHdr.Text = "Info";
            ArtifactInfoHdr.Width = 150;
            // 
            // ArtifactContext
            // 
            ArtifactContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            ArtifactContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ArtifactContextRemove });
            ArtifactContext.Name = "ChallengeContext";
            ArtifactContext.Size = new System.Drawing.Size(118, 26);
            // 
            // ArtifactContextRemove
            // 
            ArtifactContextRemove.Name = "ArtifactContextRemove";
            ArtifactContextRemove.Size = new System.Drawing.Size(117, 22);
            ArtifactContextRemove.Text = "Remove";
            ArtifactContextRemove.Click += ArtifactRemove_Click;
            // 
            // ArtifactToolbar
            // 
            ArtifactToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            ArtifactToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ArtifactAdd, ArtifactRemove, ArtifactEdit, toolStripSeparator32, ArtifactCut, ArtifactCopy, ArtifactPaste, toolStripSeparator33, ArtifactStatBlockBtn, toolStripSeparator34, ArtifactTools });
            ArtifactToolbar.Location = new System.Drawing.Point(4, 4);
            ArtifactToolbar.Name = "ArtifactToolbar";
            ArtifactToolbar.Size = new System.Drawing.Size(716, 25);
            ArtifactToolbar.TabIndex = 5;
            ArtifactToolbar.Text = "toolStrip2";
            // 
            // ArtifactAdd
            // 
            ArtifactAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ArtifactAddAdd, toolStripSeparator31, ArtifactAddImport });
            ArtifactAdd.Image = (System.Drawing.Image)resources.GetObject("ArtifactAdd.Image");
            ArtifactAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactAdd.Name = "ArtifactAdd";
            ArtifactAdd.Size = new System.Drawing.Size(42, 22);
            ArtifactAdd.Text = "Add";
            // 
            // ArtifactAddAdd
            // 
            ArtifactAddAdd.Name = "ArtifactAddAdd";
            ArtifactAddAdd.Size = new System.Drawing.Size(163, 22);
            ArtifactAddAdd.Text = "Add an Artifact...";
            ArtifactAddAdd.Click += ArtifactAddAdd_Click;
            // 
            // toolStripSeparator31
            // 
            toolStripSeparator31.Name = "toolStripSeparator31";
            toolStripSeparator31.Size = new System.Drawing.Size(160, 6);
            // 
            // ArtifactAddImport
            // 
            ArtifactAddImport.Name = "ArtifactAddImport";
            ArtifactAddImport.Size = new System.Drawing.Size(163, 22);
            ArtifactAddImport.Text = "Import...";
            ArtifactAddImport.Click += ArtifactAddImport_Click;
            // 
            // ArtifactRemove
            // 
            ArtifactRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactRemove.Image = (System.Drawing.Image)resources.GetObject("ArtifactRemove.Image");
            ArtifactRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactRemove.Name = "ArtifactRemove";
            ArtifactRemove.Size = new System.Drawing.Size(54, 22);
            ArtifactRemove.Text = "Remove";
            ArtifactRemove.Click += ArtifactRemove_Click;
            // 
            // ArtifactEdit
            // 
            ArtifactEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactEdit.Image = (System.Drawing.Image)resources.GetObject("ArtifactEdit.Image");
            ArtifactEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactEdit.Name = "ArtifactEdit";
            ArtifactEdit.Size = new System.Drawing.Size(31, 22);
            ArtifactEdit.Text = "Edit";
            ArtifactEdit.Click += ArtifactEdit_Click;
            // 
            // toolStripSeparator32
            // 
            toolStripSeparator32.Name = "toolStripSeparator32";
            toolStripSeparator32.Size = new System.Drawing.Size(6, 25);
            // 
            // ArtifactCut
            // 
            ArtifactCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactCut.Image = (System.Drawing.Image)resources.GetObject("ArtifactCut.Image");
            ArtifactCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactCut.Name = "ArtifactCut";
            ArtifactCut.Size = new System.Drawing.Size(30, 22);
            ArtifactCut.Text = "Cut";
            ArtifactCut.Click += ArtifactCut_Click;
            // 
            // ArtifactCopy
            // 
            ArtifactCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactCopy.Image = (System.Drawing.Image)resources.GetObject("ArtifactCopy.Image");
            ArtifactCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactCopy.Name = "ArtifactCopy";
            ArtifactCopy.Size = new System.Drawing.Size(39, 22);
            ArtifactCopy.Text = "Copy";
            ArtifactCopy.Click += ArtifactCopy_Click;
            // 
            // ArtifactPaste
            // 
            ArtifactPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactPaste.Image = (System.Drawing.Image)resources.GetObject("ArtifactPaste.Image");
            ArtifactPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactPaste.Name = "ArtifactPaste";
            ArtifactPaste.Size = new System.Drawing.Size(39, 22);
            ArtifactPaste.Text = "Paste";
            ArtifactPaste.Click += ArtifactPaste_Click;
            // 
            // toolStripSeparator33
            // 
            toolStripSeparator33.Name = "toolStripSeparator33";
            toolStripSeparator33.Size = new System.Drawing.Size(6, 25);
            // 
            // ArtifactStatBlockBtn
            // 
            ArtifactStatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactStatBlockBtn.Image = (System.Drawing.Image)resources.GetObject("ArtifactStatBlockBtn.Image");
            ArtifactStatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactStatBlockBtn.Name = "ArtifactStatBlockBtn";
            ArtifactStatBlockBtn.Size = new System.Drawing.Size(63, 22);
            ArtifactStatBlockBtn.Text = "Stat Block";
            ArtifactStatBlockBtn.Click += ArtifactStatBlockBtn_Click;
            // 
            // toolStripSeparator34
            // 
            toolStripSeparator34.Name = "toolStripSeparator34";
            toolStripSeparator34.Size = new System.Drawing.Size(6, 25);
            // 
            // ArtifactTools
            // 
            ArtifactTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ArtifactTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ArtifactToolsExport });
            ArtifactTools.Image = (System.Drawing.Image)resources.GetObject("ArtifactTools.Image");
            ArtifactTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            ArtifactTools.Name = "ArtifactTools";
            ArtifactTools.Size = new System.Drawing.Size(48, 22);
            ArtifactTools.Text = "Tools";
            // 
            // ArtifactToolsExport
            // 
            ArtifactToolsExport.Name = "ArtifactToolsExport";
            ArtifactToolsExport.Size = new System.Drawing.Size(116, 22);
            ArtifactToolsExport.Text = "Export...";
            ArtifactToolsExport.Click += ArtifactToolsExport_Click;
            // 
            // HelpPanel
            // 
            HelpPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            HelpPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            HelpPanel.Location = new System.Drawing.Point(0, 145);
            HelpPanel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            HelpPanel.Name = "HelpPanel";
            HelpPanel.Size = new System.Drawing.Size(732, 184);
            HelpPanel.TabIndex = 3;
            HelpPanel.Visible = false;
            // 
            // ChallengeContext
            // 
            ChallengeContext.ImageScalingSize = new System.Drawing.Size(20, 20);
            ChallengeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ChallengeContextRemove });
            ChallengeContext.Name = "ChallengeContext";
            ChallengeContext.Size = new System.Drawing.Size(118, 26);
            // 
            // ChallengeContextRemove
            // 
            ChallengeContextRemove.Name = "ChallengeContextRemove";
            ChallengeContextRemove.Size = new System.Drawing.Size(117, 22);
            ChallengeContextRemove.Text = "Remove";
            ChallengeContextRemove.Click += ChallengeContextRemove_Click;
            // 
            // LibraryListForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1026, 329);
            Controls.Add(Splitter);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            MinimizeBox = false;
            Name = "LibraryListForm";
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Libraries";
            FormClosed += LibrariesForm_FormClosed;
            Splitter.Panel1.ResumeLayout(false);
            Splitter.Panel1.PerformLayout();
            Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Splitter).EndInit();
            Splitter.ResumeLayout(false);
            LibraryToolbar.ResumeLayout(false);
            LibraryToolbar.PerformLayout();
            Pages.ResumeLayout(false);
            CreaturesPage.ResumeLayout(false);
            CreaturesPage.PerformLayout();
            CreatureContext.ResumeLayout(false);
            CreatureSearchToolbar.ResumeLayout(false);
            CreatureSearchToolbar.PerformLayout();
            CreatureToolbar.ResumeLayout(false);
            CreatureToolbar.PerformLayout();
            TemplatesPage.ResumeLayout(false);
            TemplatesPage.PerformLayout();
            TemplateContext.ResumeLayout(false);
            TemplateToolbar.ResumeLayout(false);
            TemplateToolbar.PerformLayout();
            TrapsPage.ResumeLayout(false);
            TrapsPage.PerformLayout();
            TrapContext.ResumeLayout(false);
            TrapToolbar.ResumeLayout(false);
            TrapToolbar.PerformLayout();
            ChallengePage.ResumeLayout(false);
            ChallengePage.PerformLayout();
            ChallengeToolbar.ResumeLayout(false);
            ChallengeToolbar.PerformLayout();
            MagicItemsPage.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            MagicItemContext.ResumeLayout(false);
            MagicItemToolbar.ResumeLayout(false);
            MagicItemToolbar.PerformLayout();
            MagicItemVersionToolbar.ResumeLayout(false);
            MagicItemVersionToolbar.PerformLayout();
            TilesPage.ResumeLayout(false);
            TilesPage.PerformLayout();
            TileContext.ResumeLayout(false);
            TileToolbar.ResumeLayout(false);
            TileToolbar.PerformLayout();
            TerrainPowersPage.ResumeLayout(false);
            TerrainPowersPage.PerformLayout();
            TPContext.ResumeLayout(false);
            TerrainPowerToolbar.ResumeLayout(false);
            TerrainPowerToolbar.PerformLayout();
            ArtifactPage.ResumeLayout(false);
            ArtifactPage.PerformLayout();
            ArtifactContext.ResumeLayout(false);
            ArtifactToolbar.ResumeLayout(false);
            ArtifactToolbar.PerformLayout();
            ChallengeContext.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.ToolStrip LibraryToolbar;
		private System.Windows.Forms.ToolStripButton LibraryRemoveBtn;
		private System.Windows.Forms.ToolStripButton LibraryEditBtn;
		private System.Windows.Forms.ListView CreatureList;
		private System.Windows.Forms.ToolStrip CreatureToolbar;
		private System.Windows.Forms.ToolStripButton OppRemoveBtn;
		private System.Windows.Forms.ToolStripButton OppEditBtn;
		private System.Windows.Forms.ColumnHeader CreatureNameHdr;
		private System.Windows.Forms.ColumnHeader CreatureInfoHdr;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage CreaturesPage;
		private System.Windows.Forms.TabPage TemplatesPage;
        private System.Windows.Forms.ToolStrip TemplateToolbar;
		private System.Windows.Forms.ToolStripButton TemplateRemoveBtn;
		private System.Windows.Forms.ToolStripButton TemplateEditBtn;
		private System.Windows.Forms.ListView TemplateList;
		private System.Windows.Forms.ColumnHeader TemplateNameHdr;
		private System.Windows.Forms.TabPage TilesPage;
		private System.Windows.Forms.ListView TileList;
		private System.Windows.Forms.ColumnHeader TileSetNameHdr;
		private System.Windows.Forms.ToolStrip TileToolbar;
		private System.Windows.Forms.ToolStripButton TileRemoveBtn;
		private System.Windows.Forms.ToolStripButton TileEditBtn;
		private System.Windows.Forms.ColumnHeader TemplateInfoHdr;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton CreatureCutBtn;
		private System.Windows.Forms.ToolStripButton CreatureCopyBtn;
		private System.Windows.Forms.ToolStripButton CreaturePasteBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton TemplateCutBtn;
		private System.Windows.Forms.ToolStripButton TemplateCopyBtn;
		private System.Windows.Forms.ToolStripButton TemplatePasteBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton TileCutBtn;
		private System.Windows.Forms.ToolStripButton TileCopyBtn;
		private System.Windows.Forms.ToolStripButton TilePasteBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.TabPage TrapsPage;
		private System.Windows.Forms.ListView TrapList;
		private System.Windows.Forms.ColumnHeader TrapNameHdr;
		private System.Windows.Forms.ColumnHeader TrapInfoHdr;
		private System.Windows.Forms.ToolStrip TrapToolbar;
		private System.Windows.Forms.ToolStripButton TrapRemoveBtn;
		private System.Windows.Forms.ToolStripButton TrapEditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripButton TrapCutBtn;
		private System.Windows.Forms.ToolStripButton TrapCopyBtn;
		private System.Windows.Forms.ToolStripButton TrapPasteBtn;
		private System.Windows.Forms.TabPage ChallengePage;
		private System.Windows.Forms.ListView ChallengeList;
		private System.Windows.Forms.ColumnHeader ChallengeNameHdr;
		private System.Windows.Forms.ColumnHeader ChallengeInfoHdr;
		private System.Windows.Forms.ToolStrip ChallengeToolbar;
		private System.Windows.Forms.ToolStripButton ChallengeRemoveBtn;
		private System.Windows.Forms.ToolStripButton ChallengeEditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripButton ChallengeCutBtn;
		private System.Windows.Forms.ToolStripButton ChallengeCopyBtn;
		private System.Windows.Forms.ToolStripButton ChallengePasteBtn;
		private System.Windows.Forms.ContextMenuStrip CreatureContext;
		private System.Windows.Forms.ToolStripMenuItem CreatureContextRemove;
		private System.Windows.Forms.ToolStripMenuItem CreatureContextCategory;
		private System.Windows.Forms.ContextMenuStrip TileContext;
		private System.Windows.Forms.ToolStripMenuItem TileContextRemove;
		private System.Windows.Forms.ToolStripMenuItem TileContextCategory;
		private System.Windows.Forms.ToolStripMenuItem TilePlain;
		private System.Windows.Forms.ToolStripMenuItem TileDoorway;
		private System.Windows.Forms.ToolStripMenuItem TileStairway;
		private System.Windows.Forms.ToolStripMenuItem TileFeature;
		private System.Windows.Forms.ToolStripMenuItem TileSpecial;
		private System.Windows.Forms.ContextMenuStrip TemplateContext;
		private System.Windows.Forms.ToolStripMenuItem TemplateContextRemove;
		private System.Windows.Forms.ToolStripMenuItem TemplateContextType;
		private System.Windows.Forms.ToolStripMenuItem TemplateFunctional;
		private System.Windows.Forms.ToolStripMenuItem TemplateClass;
		private System.Windows.Forms.ContextMenuStrip TrapContext;
		private System.Windows.Forms.ToolStripMenuItem TrapContextRemove;
		private System.Windows.Forms.ToolStripMenuItem TrapContextType;
		private System.Windows.Forms.ToolStripMenuItem TrapTrap;
		private System.Windows.Forms.ToolStripMenuItem TrapHazard;
		private System.Windows.Forms.ContextMenuStrip ChallengeContext;
		private System.Windows.Forms.ToolStripMenuItem ChallengeContextRemove;
		private System.Windows.Forms.ToolStripButton CreatureStatBlockBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripButton TrapStatBlockBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripButton ChallengeStatBlockBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStrip CreatureSearchToolbar;
		private System.Windows.Forms.ToolStripLabel SearchLbl;
		private System.Windows.Forms.ToolStripTextBox SearchBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripButton CategorisedBtn;
		private System.Windows.Forms.ToolStripButton UncategorisedBtn;
		private System.Windows.Forms.TabPage MagicItemsPage;
		private System.Windows.Forms.ListView MagicItemList;
		private System.Windows.Forms.ColumnHeader MagicItemHdr;
		private System.Windows.Forms.ToolStrip MagicItemToolbar;
		private System.Windows.Forms.ContextMenuStrip MagicItemContext;
		private System.Windows.Forms.ToolStripMenuItem MagicItemContextRemove;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView MagicItemVersionList;
		private System.Windows.Forms.ColumnHeader MagicItemInfoHdr;
		private System.Windows.Forms.ToolStrip MagicItemVersionToolbar;
		private System.Windows.Forms.ToolStripButton MagicItemRemoveBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton MagicItemEditBtn;
		private System.Windows.Forms.ToolStripButton MagicItemCutBtn;
		private System.Windows.Forms.ToolStripButton MagicItemCopyBtn;
		private System.Windows.Forms.ToolStripButton MagicItemPasteBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
		private System.Windows.Forms.ToolStripButton MagicItemStatBlockBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
		private System.Windows.Forms.TreeView LibraryTree;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
		private System.Windows.Forms.ToolStripMenuItem TileMap;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
		private System.Windows.Forms.ToolStripMenuItem TileContextSize;
		private System.Windows.Forms.Button HelpBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
		private System.Windows.Forms.ToolStripButton LibraryMergeBtn;
		private System.Windows.Forms.ToolStripDropDownButton FileMenu;
		private System.Windows.Forms.ToolStripMenuItem FileNew;
		private System.Windows.Forms.ToolStripMenuItem FileClose;
		private Masterplan.Controls.LibraryHelpPanel HelpPanel;
		private System.Windows.Forms.ToolStripMenuItem FileOpen;
		private System.Windows.Forms.ToolStripDropDownButton TemplateAddBtn;
		private System.Windows.Forms.ToolStripMenuItem addTemplateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TemplateAddTheme;
		private System.Windows.Forms.ToolStripDropDownButton TileAddBtn;
		private System.Windows.Forms.ToolStripMenuItem addTileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TileAddFolder;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
		private System.Windows.Forms.ToolStripButton TemplateStatBlock;
		private System.Windows.Forms.ToolStripDropDownButton CreatureAddBtn;
		private System.Windows.Forms.ToolStripMenuItem CreatureAddSingle;
		private System.Windows.Forms.ToolStripDropDownButton CreatureTools;
		private System.Windows.Forms.ToolStripMenuItem CreatureToolsDemographics;
		private System.Windows.Forms.ToolStripMenuItem CreatureToolsPowerStatistics;
		private System.Windows.Forms.ToolStripMenuItem CreatureToolsFilterList;
		private System.Windows.Forms.ToolStripDropDownButton TrapTools;
		private System.Windows.Forms.ToolStripMenuItem TrapToolsDemographics;
		private System.Windows.Forms.ToolStripMenuItem CreatureToolsExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
		private System.Windows.Forms.ToolStripMenuItem CreatureImport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
		private System.Windows.Forms.ToolStripMenuItem TemplateImport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
		private System.Windows.Forms.ToolStripDropDownButton TemplateTools;
		private System.Windows.Forms.ToolStripMenuItem TemplateToolsExport;
		private System.Windows.Forms.ToolStripMenuItem TrapToolsExport;
		private System.Windows.Forms.ToolStripDropDownButton TrapAdd;
		private System.Windows.Forms.ToolStripMenuItem TrapAddAdd;
		private System.Windows.Forms.ToolStripMenuItem TrapAddImport;
		private System.Windows.Forms.ToolStripDropDownButton ChallengeAdd;
		private System.Windows.Forms.ToolStripMenuItem ChallengeAddAdd;
		private System.Windows.Forms.ToolStripMenuItem ChallengeAddImport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
		private System.Windows.Forms.ToolStripDropDownButton ChallengeTools;
		private System.Windows.Forms.ToolStripMenuItem ChallengeToolsExport;
		private System.Windows.Forms.ToolStripDropDownButton MagicItemAdd;
		private System.Windows.Forms.ToolStripMenuItem MagicItemAddAdd;
		private System.Windows.Forms.ToolStripMenuItem MagicItemAddImport;
		private System.Windows.Forms.ToolStripDropDownButton MagicItemTools;
		private System.Windows.Forms.ToolStripMenuItem MagicItemToolsDemographics;
		private System.Windows.Forms.ToolStripMenuItem MagicItemToolsExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator24;
		private System.Windows.Forms.ToolStripMenuItem TileAddImport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
		private System.Windows.Forms.ToolStripDropDownButton TileTools;
		private System.Windows.Forms.ToolStripMenuItem TileToolsExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator25;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator26;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator27;
		private System.Windows.Forms.TabPage TerrainPowersPage;
		private System.Windows.Forms.ListView TerrainPowerList;
		private System.Windows.Forms.ColumnHeader TPNameHdr;
		private System.Windows.Forms.ColumnHeader TPInfoHdr;
		private System.Windows.Forms.ToolStrip TerrainPowerToolbar;
		private System.Windows.Forms.ToolStripDropDownButton TPAdd;
		private System.Windows.Forms.ToolStripMenuItem TPAddTerrainPower;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator28;
		private System.Windows.Forms.ToolStripMenuItem TPAddImport;
		private System.Windows.Forms.ToolStripButton TPRemoveBtn;
		private System.Windows.Forms.ToolStripButton TPEditBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator29;
		private System.Windows.Forms.ToolStripButton TPCutBtn;
		private System.Windows.Forms.ToolStripButton TPCopyBtn;
		private System.Windows.Forms.ToolStripButton TPPasteBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator30;
		private System.Windows.Forms.ToolStripDropDownButton TPTools;
		private System.Windows.Forms.ToolStripMenuItem TPToolsExport;
		private System.Windows.Forms.ContextMenuStrip TPContext;
		private System.Windows.Forms.ToolStripMenuItem TPContextRemove;
		private System.Windows.Forms.TabPage ArtifactPage;
		private System.Windows.Forms.ListView ArtifactList;
		private System.Windows.Forms.ColumnHeader ArtifactHdr;
		private System.Windows.Forms.ColumnHeader ArtifactInfoHdr;
		private System.Windows.Forms.ToolStrip ArtifactToolbar;
		private System.Windows.Forms.ToolStripDropDownButton ArtifactAdd;
		private System.Windows.Forms.ToolStripMenuItem ArtifactAddAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator31;
		private System.Windows.Forms.ToolStripMenuItem ArtifactAddImport;
		private System.Windows.Forms.ToolStripButton ArtifactRemove;
		private System.Windows.Forms.ToolStripButton ArtifactEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator32;
		private System.Windows.Forms.ToolStripButton ArtifactCut;
		private System.Windows.Forms.ToolStripButton ArtifactCopy;
		private System.Windows.Forms.ToolStripButton ArtifactPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator33;
		private System.Windows.Forms.ToolStripDropDownButton ArtifactTools;
		private System.Windows.Forms.ToolStripMenuItem ArtifactToolsExport;
		private System.Windows.Forms.ContextMenuStrip ArtifactContext;
		private System.Windows.Forms.ToolStripMenuItem ArtifactContextRemove;
		private System.Windows.Forms.ToolStripButton ArtifactStatBlockBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator34;
		private System.Windows.Forms.ToolStripButton TPStatBlockBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator35;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator36;
        private System.Windows.Forms.ToolStripButton LibraryBtnConvert;
    }
}