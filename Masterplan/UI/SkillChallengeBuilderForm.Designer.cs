namespace Masterplan.UI
{
	partial class SkillChallengeBuilderForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Standard Skill DCs", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillChallengeBuilderForm));
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Primary Skills", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Secondary Skills", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Automatic Failure", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Skills", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Abilities", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Custom", System.Windows.Forms.HorizontalAlignment.Left);
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.Pages = new System.Windows.Forms.TabControl();
            this.OverviewPage = new System.Windows.Forms.TabPage();
            this.OverviewSplitter = new System.Windows.Forms.SplitContainer();
            this.LevelGroup = new System.Windows.Forms.GroupBox();
            this.XPLbl = new System.Windows.Forms.Label();
            this.XPInfoLbl = new System.Windows.Forms.Label();
            this.LevelBox = new System.Windows.Forms.NumericUpDown();
            this.LevelLbl = new System.Windows.Forms.Label();
            this.CompGroup = new System.Windows.Forms.GroupBox();
            this.LengthLbl = new System.Windows.Forms.Label();
            this.LengthInfoLbl = new System.Windows.Forms.Label();
            this.CompBox = new System.Windows.Forms.NumericUpDown();
            this.CompLbl = new System.Windows.Forms.Label();
            this.InfoList = new System.Windows.Forms.ListView();
            this.InfoHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StdDCHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.FileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SuccessCountLbl = new System.Windows.Forms.ToolStripLabel();
            this.FailureCountLbl = new System.Windows.Forms.ToolStripLabel();
            this.ResetProgressBtn = new System.Windows.Forms.ToolStripButton();
            this.SkillsPage = new System.Windows.Forms.TabPage();
            this.SkillSplitter = new System.Windows.Forms.SplitContainer();
            this.SkillList = new System.Windows.Forms.ListView();
            this.SkillHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DCHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SkillSourceList = new System.Windows.Forms.ListView();
            this.SkillSourceHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AbilityHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SkillsToolbar = new System.Windows.Forms.ToolStrip();
            this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
            this.EditBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BreakdownBtn = new System.Windows.Forms.ToolStripButton();
            this.InfoPage = new System.Windows.Forms.TabPage();
            this.InfoSplitter = new System.Windows.Forms.SplitContainer();
            this.VictoryBox = new Masterplan.Controls.DefaultTextBox();
            this.VictoryToolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.DefeatBox = new Masterplan.Controls.DefaultTextBox();
            this.DefeatButton = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.NotesPage = new System.Windows.Forms.TabPage();
            this.NotesBox = new Masterplan.Controls.DefaultTextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.NameLbl = new System.Windows.Forms.Label();
            this.Pages.SuspendLayout();
            this.OverviewPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OverviewSplitter)).BeginInit();
            this.OverviewSplitter.Panel1.SuspendLayout();
            this.OverviewSplitter.Panel2.SuspendLayout();
            this.OverviewSplitter.SuspendLayout();
            this.LevelGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
            this.CompGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompBox)).BeginInit();
            this.Toolbar.SuspendLayout();
            this.SkillsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SkillSplitter)).BeginInit();
            this.SkillSplitter.Panel1.SuspendLayout();
            this.SkillSplitter.Panel2.SuspendLayout();
            this.SkillSplitter.SuspendLayout();
            this.SkillsToolbar.SuspendLayout();
            this.InfoPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoSplitter)).BeginInit();
            this.InfoSplitter.Panel1.SuspendLayout();
            this.InfoSplitter.Panel2.SuspendLayout();
            this.InfoSplitter.SuspendLayout();
            this.VictoryToolbar.SuspendLayout();
            this.DefeatButton.SuspendLayout();
            this.NotesPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(469, 442);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(100, 28);
            this.OKBtn.TabIndex = 3;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(577, 442);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 28);
            this.CancelBtn.TabIndex = 4;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // Pages
            // 
            this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pages.Controls.Add(this.OverviewPage);
            this.Pages.Controls.Add(this.SkillsPage);
            this.Pages.Controls.Add(this.InfoPage);
            this.Pages.Controls.Add(this.NotesPage);
            this.Pages.Location = new System.Drawing.Point(16, 47);
            this.Pages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(661, 388);
            this.Pages.TabIndex = 2;
            // 
            // OverviewPage
            // 
            this.OverviewPage.Controls.Add(this.OverviewSplitter);
            this.OverviewPage.Controls.Add(this.Toolbar);
            this.OverviewPage.Location = new System.Drawing.Point(4, 25);
            this.OverviewPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OverviewPage.Name = "OverviewPage";
            this.OverviewPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OverviewPage.Size = new System.Drawing.Size(653, 359);
            this.OverviewPage.TabIndex = 5;
            this.OverviewPage.Text = "Overview";
            this.OverviewPage.UseVisualStyleBackColor = true;
            // 
            // OverviewSplitter
            // 
            this.OverviewSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OverviewSplitter.Location = new System.Drawing.Point(4, 31);
            this.OverviewSplitter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OverviewSplitter.Name = "OverviewSplitter";
            // 
            // OverviewSplitter.Panel1
            // 
            this.OverviewSplitter.Panel1.Controls.Add(this.LevelGroup);
            this.OverviewSplitter.Panel1.Controls.Add(this.CompGroup);
            // 
            // OverviewSplitter.Panel2
            // 
            this.OverviewSplitter.Panel2.Controls.Add(this.InfoList);
            this.OverviewSplitter.Size = new System.Drawing.Size(645, 324);
            this.OverviewSplitter.SplitterDistance = 317;
            this.OverviewSplitter.SplitterWidth = 5;
            this.OverviewSplitter.TabIndex = 0;
            // 
            // LevelGroup
            // 
            this.LevelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelGroup.Controls.Add(this.XPLbl);
            this.LevelGroup.Controls.Add(this.XPInfoLbl);
            this.LevelGroup.Controls.Add(this.LevelBox);
            this.LevelGroup.Controls.Add(this.LevelLbl);
            this.LevelGroup.Location = new System.Drawing.Point(5, 107);
            this.LevelGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LevelGroup.Name = "LevelGroup";
            this.LevelGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LevelGroup.Size = new System.Drawing.Size(308, 96);
            this.LevelGroup.TabIndex = 10;
            this.LevelGroup.TabStop = false;
            this.LevelGroup.Text = "Level";
            // 
            // XPLbl
            // 
            this.XPLbl.AutoSize = true;
            this.XPLbl.Location = new System.Drawing.Point(92, 59);
            this.XPLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XPLbl.Name = "XPLbl";
            this.XPLbl.Size = new System.Drawing.Size(29, 16);
            this.XPLbl.TabIndex = 10;
            this.XPLbl.Text = "[xp]";
            // 
            // XPInfoLbl
            // 
            this.XPInfoLbl.AutoSize = true;
            this.XPInfoLbl.Location = new System.Drawing.Point(8, 59);
            this.XPInfoLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XPInfoLbl.Name = "XPInfoLbl";
            this.XPInfoLbl.Size = new System.Drawing.Size(27, 16);
            this.XPInfoLbl.TabIndex = 9;
            this.XPInfoLbl.Text = "XP:";
            // 
            // LevelBox
            // 
            this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelBox.Location = new System.Drawing.Point(96, 23);
            this.LevelBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LevelBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.LevelBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LevelBox.Name = "LevelBox";
            this.LevelBox.Size = new System.Drawing.Size(204, 22);
            this.LevelBox.TabIndex = 8;
            this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LevelBox.ValueChanged += new System.EventHandler(this.LevelBox_ValueChanged);
            // 
            // LevelLbl
            // 
            this.LevelLbl.AutoSize = true;
            this.LevelLbl.Location = new System.Drawing.Point(8, 26);
            this.LevelLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LevelLbl.Name = "LevelLbl";
            this.LevelLbl.Size = new System.Drawing.Size(43, 16);
            this.LevelLbl.TabIndex = 7;
            this.LevelLbl.Text = "Level:";
            // 
            // CompGroup
            // 
            this.CompGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompGroup.Controls.Add(this.LengthLbl);
            this.CompGroup.Controls.Add(this.LengthInfoLbl);
            this.CompGroup.Controls.Add(this.CompBox);
            this.CompGroup.Controls.Add(this.CompLbl);
            this.CompGroup.Location = new System.Drawing.Point(4, 4);
            this.CompGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CompGroup.Name = "CompGroup";
            this.CompGroup.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CompGroup.Size = new System.Drawing.Size(309, 96);
            this.CompGroup.TabIndex = 9;
            this.CompGroup.TabStop = false;
            this.CompGroup.Text = "Complexity / Length";
            // 
            // LengthLbl
            // 
            this.LengthLbl.AutoSize = true;
            this.LengthLbl.Location = new System.Drawing.Point(92, 60);
            this.LengthLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LengthLbl.Name = "LengthLbl";
            this.LengthLbl.Size = new System.Drawing.Size(51, 16);
            this.LengthLbl.TabIndex = 5;
            this.LengthLbl.Text = "[length]";
            // 
            // LengthInfoLbl
            // 
            this.LengthInfoLbl.AutoSize = true;
            this.LengthInfoLbl.Location = new System.Drawing.Point(8, 60);
            this.LengthInfoLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LengthInfoLbl.Name = "LengthInfoLbl";
            this.LengthInfoLbl.Size = new System.Drawing.Size(50, 16);
            this.LengthInfoLbl.TabIndex = 4;
            this.LengthInfoLbl.Text = "Length:";
            // 
            // CompBox
            // 
            this.CompBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompBox.Location = new System.Drawing.Point(96, 23);
            this.CompBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CompBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.CompBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CompBox.Name = "CompBox";
            this.CompBox.Size = new System.Drawing.Size(205, 22);
            this.CompBox.TabIndex = 3;
            this.CompBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CompBox.ValueChanged += new System.EventHandler(this.CompBox_ValueChanged);
            // 
            // CompLbl
            // 
            this.CompLbl.AutoSize = true;
            this.CompLbl.Location = new System.Drawing.Point(8, 26);
            this.CompLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CompLbl.Name = "CompLbl";
            this.CompLbl.Size = new System.Drawing.Size(76, 16);
            this.CompLbl.TabIndex = 2;
            this.CompLbl.Text = "Complexity:";
            // 
            // InfoList
            // 
            this.InfoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InfoHdr,
            this.StdDCHdr});
            this.InfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoList.Enabled = false;
            this.InfoList.FullRowSelect = true;
            listViewGroup1.Header = "Standard Skill DCs";
            listViewGroup1.Name = "listViewGroup1";
            this.InfoList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.InfoList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.InfoList.HideSelection = false;
            this.InfoList.Location = new System.Drawing.Point(0, 0);
            this.InfoList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InfoList.MultiSelect = false;
            this.InfoList.Name = "InfoList";
            this.InfoList.Size = new System.Drawing.Size(323, 324);
            this.InfoList.TabIndex = 0;
            this.InfoList.UseCompatibleStateImageBehavior = false;
            this.InfoList.View = System.Windows.Forms.View.Details;
            // 
            // InfoHdr
            // 
            this.InfoHdr.Text = "Difficulty";
            this.InfoHdr.Width = 139;
            // 
            // StdDCHdr
            // 
            this.StdDCHdr.Text = "DC";
            this.StdDCHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.StdDCHdr.Width = 67;
            // 
            // Toolbar
            // 
            this.Toolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.toolStripSeparator2,
            this.SuccessCountLbl,
            this.FailureCountLbl,
            this.ResetProgressBtn});
            this.Toolbar.Location = new System.Drawing.Point(4, 4);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(645, 27);
            this.Toolbar.TabIndex = 1;
            this.Toolbar.Text = "toolStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExport});
            this.FileMenu.Image = ((System.Drawing.Image)(resources.GetObject("FileMenu.Image")));
            this.FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(46, 24);
            this.FileMenu.Text = "File";
            // 
            // FileExport
            // 
            this.FileExport.Name = "FileExport";
            this.FileExport.Size = new System.Drawing.Size(144, 26);
            this.FileExport.Text = "Export...";
            this.FileExport.Click += new System.EventHandler(this.FileExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // SuccessCountLbl
            // 
            this.SuccessCountLbl.Name = "SuccessCountLbl";
            this.SuccessCountLbl.Size = new System.Drawing.Size(81, 24);
            this.SuccessCountLbl.Text = "[successes]";
            // 
            // FailureCountLbl
            // 
            this.FailureCountLbl.Name = "FailureCountLbl";
            this.FailureCountLbl.Size = new System.Drawing.Size(67, 24);
            this.FailureCountLbl.Text = "[failures]";
            // 
            // ResetProgressBtn
            // 
            this.ResetProgressBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ResetProgressBtn.Image = ((System.Drawing.Image)(resources.GetObject("ResetProgressBtn.Image")));
            this.ResetProgressBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ResetProgressBtn.Name = "ResetProgressBtn";
            this.ResetProgressBtn.Size = new System.Drawing.Size(49, 24);
            this.ResetProgressBtn.Text = "Reset";
            this.ResetProgressBtn.Click += new System.EventHandler(this.ResetProgressBtn_Click);
            // 
            // SkillsPage
            // 
            this.SkillsPage.Controls.Add(this.SkillSplitter);
            this.SkillsPage.Controls.Add(this.SkillsToolbar);
            this.SkillsPage.Location = new System.Drawing.Point(4, 25);
            this.SkillsPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SkillsPage.Name = "SkillsPage";
            this.SkillsPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SkillsPage.Size = new System.Drawing.Size(653, 359);
            this.SkillsPage.TabIndex = 3;
            this.SkillsPage.Text = "Skills";
            this.SkillsPage.UseVisualStyleBackColor = true;
            // 
            // SkillSplitter
            // 
            this.SkillSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkillSplitter.Location = new System.Drawing.Point(4, 31);
            this.SkillSplitter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SkillSplitter.Name = "SkillSplitter";
            // 
            // SkillSplitter.Panel1
            // 
            this.SkillSplitter.Panel1.Controls.Add(this.SkillList);
            // 
            // SkillSplitter.Panel2
            // 
            this.SkillSplitter.Panel2.Controls.Add(this.SkillSourceList);
            this.SkillSplitter.Size = new System.Drawing.Size(645, 324);
            this.SkillSplitter.SplitterDistance = 378;
            this.SkillSplitter.SplitterWidth = 5;
            this.SkillSplitter.TabIndex = 2;
            // 
            // SkillList
            // 
            this.SkillList.AllowDrop = true;
            this.SkillList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SkillHdr,
            this.DCHdr});
            this.SkillList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkillList.FullRowSelect = true;
            listViewGroup2.Header = "Primary Skills";
            listViewGroup2.Name = "listViewGroup1";
            listViewGroup3.Header = "Secondary Skills";
            listViewGroup3.Name = "listViewGroup2";
            listViewGroup4.Header = "Automatic Failure";
            listViewGroup4.Name = "listViewGroup3";
            this.SkillList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.SkillList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SkillList.HideSelection = false;
            this.SkillList.Location = new System.Drawing.Point(0, 0);
            this.SkillList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SkillList.MultiSelect = false;
            this.SkillList.Name = "SkillList";
            this.SkillList.Size = new System.Drawing.Size(378, 324);
            this.SkillList.TabIndex = 1;
            this.SkillList.UseCompatibleStateImageBehavior = false;
            this.SkillList.View = System.Windows.Forms.View.Details;
            this.SkillList.DragOver += new System.Windows.Forms.DragEventHandler(this.SkillList_DragOver);
            this.SkillList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
            // 
            // SkillHdr
            // 
            this.SkillHdr.Text = "Skill";
            this.SkillHdr.Width = 135;
            // 
            // DCHdr
            // 
            this.DCHdr.Text = "DC Level";
            this.DCHdr.Width = 103;
            // 
            // SkillSourceList
            // 
            this.SkillSourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SkillSourceHdr,
            this.AbilityHdr});
            this.SkillSourceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkillSourceList.FullRowSelect = true;
            listViewGroup5.Header = "Skills";
            listViewGroup5.Name = "listViewGroup1";
            listViewGroup6.Header = "Abilities";
            listViewGroup6.Name = "listViewGroup2";
            listViewGroup7.Header = "Custom";
            listViewGroup7.Name = "listViewGroup3";
            this.SkillSourceList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6,
            listViewGroup7});
            this.SkillSourceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SkillSourceList.HideSelection = false;
            this.SkillSourceList.Location = new System.Drawing.Point(0, 0);
            this.SkillSourceList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SkillSourceList.MultiSelect = false;
            this.SkillSourceList.Name = "SkillSourceList";
            this.SkillSourceList.Size = new System.Drawing.Size(262, 324);
            this.SkillSourceList.TabIndex = 0;
            this.SkillSourceList.UseCompatibleStateImageBehavior = false;
            this.SkillSourceList.View = System.Windows.Forms.View.Details;
            this.SkillSourceList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.SkillSourceList_ItemDrag);
            this.SkillSourceList.DoubleClick += new System.EventHandler(this.SkillSourceList_DoubleClick);
            // 
            // SkillSourceHdr
            // 
            this.SkillSourceHdr.Text = "Skills";
            this.SkillSourceHdr.Width = 112;
            // 
            // AbilityHdr
            // 
            this.AbilityHdr.Text = "Ability";
            this.AbilityHdr.Width = 49;
            // 
            // SkillsToolbar
            // 
            this.SkillsToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.SkillsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator1,
            this.BreakdownBtn});
            this.SkillsToolbar.Location = new System.Drawing.Point(4, 4);
            this.SkillsToolbar.Name = "SkillsToolbar";
            this.SkillsToolbar.Size = new System.Drawing.Size(645, 27);
            this.SkillsToolbar.TabIndex = 0;
            this.SkillsToolbar.Text = "toolStrip1";
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
            this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(67, 24);
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
            this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(39, 24);
            this.EditBtn.Text = "Edit";
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // BreakdownBtn
            // 
            this.BreakdownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BreakdownBtn.Image = ((System.Drawing.Image)(resources.GetObject("BreakdownBtn.Image")));
            this.BreakdownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BreakdownBtn.Name = "BreakdownBtn";
            this.BreakdownBtn.Size = new System.Drawing.Size(134, 24);
            this.BreakdownBtn.Text = "Ability Breakdown";
            this.BreakdownBtn.Click += new System.EventHandler(this.BreakdownBtn_Click);
            // 
            // InfoPage
            // 
            this.InfoPage.Controls.Add(this.InfoSplitter);
            this.InfoPage.Location = new System.Drawing.Point(4, 25);
            this.InfoPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InfoPage.Name = "InfoPage";
            this.InfoPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InfoPage.Size = new System.Drawing.Size(653, 359);
            this.InfoPage.TabIndex = 4;
            this.InfoPage.Text = "Victory / Defeat Details";
            this.InfoPage.UseVisualStyleBackColor = true;
            // 
            // InfoSplitter
            // 
            this.InfoSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoSplitter.Location = new System.Drawing.Point(4, 4);
            this.InfoSplitter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.InfoSplitter.Name = "InfoSplitter";
            // 
            // InfoSplitter.Panel1
            // 
            this.InfoSplitter.Panel1.Controls.Add(this.VictoryBox);
            this.InfoSplitter.Panel1.Controls.Add(this.VictoryToolbar);
            // 
            // InfoSplitter.Panel2
            // 
            this.InfoSplitter.Panel2.Controls.Add(this.DefeatBox);
            this.InfoSplitter.Panel2.Controls.Add(this.DefeatButton);
            this.InfoSplitter.Size = new System.Drawing.Size(645, 351);
            this.InfoSplitter.SplitterDistance = 317;
            this.InfoSplitter.SplitterWidth = 5;
            this.InfoSplitter.TabIndex = 0;
            // 
            // VictoryBox
            // 
            this.VictoryBox.AcceptsReturn = true;
            this.VictoryBox.AcceptsTab = true;
            this.VictoryBox.DefaultText = "(enter victory information here)";
            this.VictoryBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VictoryBox.Location = new System.Drawing.Point(0, 25);
            this.VictoryBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VictoryBox.Multiline = true;
            this.VictoryBox.Name = "VictoryBox";
            this.VictoryBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.VictoryBox.Size = new System.Drawing.Size(317, 326);
            this.VictoryBox.TabIndex = 1;
            this.VictoryBox.Text = "(enter victory information here)";
            // 
            // VictoryToolbar
            // 
            this.VictoryToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.VictoryToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.VictoryToolbar.Location = new System.Drawing.Point(0, 0);
            this.VictoryToolbar.Name = "VictoryToolbar";
            this.VictoryToolbar.Size = new System.Drawing.Size(317, 25);
            this.VictoryToolbar.TabIndex = 0;
            this.VictoryToolbar.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel1.Text = "Victory:";
            // 
            // DefeatBox
            // 
            this.DefeatBox.AcceptsReturn = true;
            this.DefeatBox.AcceptsTab = true;
            this.DefeatBox.DefaultText = "(enter defeat information here)";
            this.DefeatBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefeatBox.Location = new System.Drawing.Point(0, 25);
            this.DefeatBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DefeatBox.Multiline = true;
            this.DefeatBox.Name = "DefeatBox";
            this.DefeatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DefeatBox.Size = new System.Drawing.Size(323, 326);
            this.DefeatBox.TabIndex = 2;
            this.DefeatBox.Text = "(enter defeat information here)";
            // 
            // DefeatButton
            // 
            this.DefeatButton.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DefeatButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.DefeatButton.Location = new System.Drawing.Point(0, 0);
            this.DefeatButton.Name = "DefeatButton";
            this.DefeatButton.Size = new System.Drawing.Size(323, 25);
            this.DefeatButton.TabIndex = 0;
            this.DefeatButton.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(57, 22);
            this.toolStripLabel2.Text = "Defeat:";
            // 
            // NotesPage
            // 
            this.NotesPage.Controls.Add(this.NotesBox);
            this.NotesPage.Location = new System.Drawing.Point(4, 25);
            this.NotesPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NotesPage.Name = "NotesPage";
            this.NotesPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NotesPage.Size = new System.Drawing.Size(653, 359);
            this.NotesPage.TabIndex = 6;
            this.NotesPage.Text = "Notes";
            this.NotesPage.UseVisualStyleBackColor = true;
            // 
            // NotesBox
            // 
            this.NotesBox.AcceptsReturn = true;
            this.NotesBox.AcceptsTab = true;
            this.NotesBox.DefaultText = "(enter details here)";
            this.NotesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesBox.Location = new System.Drawing.Point(4, 4);
            this.NotesBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NotesBox.Multiline = true;
            this.NotesBox.Name = "NotesBox";
            this.NotesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NotesBox.Size = new System.Drawing.Size(645, 351);
            this.NotesBox.TabIndex = 3;
            this.NotesBox.Text = "(enter details here)";
            // 
            // NameBox
            // 
            this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameBox.Location = new System.Drawing.Point(75, 15);
            this.NameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(601, 22);
            this.NameBox.TabIndex = 5;
            // 
            // NameLbl
            // 
            this.NameLbl.AutoSize = true;
            this.NameLbl.Location = new System.Drawing.Point(16, 18);
            this.NameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLbl.Name = "NameLbl";
            this.NameLbl.Size = new System.Drawing.Size(47, 16);
            this.NameLbl.TabIndex = 4;
            this.NameLbl.Text = "Name:";
            // 
            // SkillChallengeBuilderForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(693, 485);
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.NameLbl);
            this.Controls.Add(this.OKBtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "SkillChallengeBuilderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Skill Challenge Builder";
            this.Pages.ResumeLayout(false);
            this.OverviewPage.ResumeLayout(false);
            this.OverviewPage.PerformLayout();
            this.OverviewSplitter.Panel1.ResumeLayout(false);
            this.OverviewSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OverviewSplitter)).EndInit();
            this.OverviewSplitter.ResumeLayout(false);
            this.LevelGroup.ResumeLayout(false);
            this.LevelGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
            this.CompGroup.ResumeLayout(false);
            this.CompGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompBox)).EndInit();
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.SkillsPage.ResumeLayout(false);
            this.SkillsPage.PerformLayout();
            this.SkillSplitter.Panel1.ResumeLayout(false);
            this.SkillSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SkillSplitter)).EndInit();
            this.SkillSplitter.ResumeLayout(false);
            this.SkillsToolbar.ResumeLayout(false);
            this.SkillsToolbar.PerformLayout();
            this.InfoPage.ResumeLayout(false);
            this.InfoSplitter.Panel1.ResumeLayout(false);
            this.InfoSplitter.Panel1.PerformLayout();
            this.InfoSplitter.Panel2.ResumeLayout(false);
            this.InfoSplitter.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoSplitter)).EndInit();
            this.InfoSplitter.ResumeLayout(false);
            this.VictoryToolbar.ResumeLayout(false);
            this.VictoryToolbar.PerformLayout();
            this.DefeatButton.ResumeLayout(false);
            this.DefeatButton.PerformLayout();
            this.NotesPage.ResumeLayout(false);
            this.NotesPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage SkillsPage;
		private System.Windows.Forms.ListView SkillList;
		private System.Windows.Forms.ColumnHeader SkillHdr;
		private System.Windows.Forms.ColumnHeader DCHdr;
		private System.Windows.Forms.ToolStrip SkillsToolbar;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.SplitContainer SkillSplitter;
		private System.Windows.Forms.ListView SkillSourceList;
		private System.Windows.Forms.ColumnHeader SkillSourceHdr;
		private System.Windows.Forms.TabPage InfoPage;
		private System.Windows.Forms.SplitContainer InfoSplitter;
		private Masterplan.Controls.DefaultTextBox VictoryBox;
		private System.Windows.Forms.ToolStrip VictoryToolbar;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private Masterplan.Controls.DefaultTextBox DefeatBox;
		private System.Windows.Forms.ToolStrip DefeatButton;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.SplitContainer OverviewSplitter;
		private System.Windows.Forms.TabPage OverviewPage;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.Label CompLbl;
		private System.Windows.Forms.NumericUpDown CompBox;
		private System.Windows.Forms.ListView InfoList;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.ColumnHeader StdDCHdr;
		private System.Windows.Forms.GroupBox LevelGroup;
		private System.Windows.Forms.GroupBox CompGroup;
		private System.Windows.Forms.Label XPLbl;
		private System.Windows.Forms.Label XPInfoLbl;
		private System.Windows.Forms.Label LengthLbl;
		private System.Windows.Forms.Label LengthInfoLbl;
		private System.Windows.Forms.ColumnHeader AbilityHdr;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton BreakdownBtn;
		private System.Windows.Forms.TabPage NotesPage;
		private Masterplan.Controls.DefaultTextBox NotesBox;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripDropDownButton FileMenu;
		private System.Windows.Forms.ToolStripMenuItem FileExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel SuccessCountLbl;
		private System.Windows.Forms.ToolStripLabel FailureCountLbl;
		private System.Windows.Forms.ToolStripButton ResetProgressBtn;
	}
}