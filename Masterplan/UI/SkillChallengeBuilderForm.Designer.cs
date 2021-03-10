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
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.StdDCHdr = new System.Windows.Forms.ColumnHeader();
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
			this.SkillHdr = new System.Windows.Forms.ColumnHeader();
			this.DCHdr = new System.Windows.Forms.ColumnHeader();
			this.SkillSourceList = new System.Windows.Forms.ListView();
			this.SkillSourceHdr = new System.Windows.Forms.ColumnHeader();
			this.AbilityHdr = new System.Windows.Forms.ColumnHeader();
			this.SkillsToolbar = new System.Windows.Forms.ToolStrip();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.BreakdownBtn = new System.Windows.Forms.ToolStripButton();
			this.InfoPage = new System.Windows.Forms.TabPage();
			this.InfoSplitter = new System.Windows.Forms.SplitContainer();
			this.VictoryBox = new Utils.Controls.DefaultTextBox();
			this.VictoryToolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.DefeatBox = new Utils.Controls.DefaultTextBox();
			this.DefeatButton = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.NotesPage = new System.Windows.Forms.TabPage();
			this.NotesBox = new Utils.Controls.DefaultTextBox();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.NameLbl = new System.Windows.Forms.Label();
			this.Pages.SuspendLayout();
			this.OverviewPage.SuspendLayout();
			this.OverviewSplitter.Panel1.SuspendLayout();
			this.OverviewSplitter.Panel2.SuspendLayout();
			this.OverviewSplitter.SuspendLayout();
			this.LevelGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.CompGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.CompBox)).BeginInit();
			this.Toolbar.SuspendLayout();
			this.SkillsPage.SuspendLayout();
			this.SkillSplitter.Panel1.SuspendLayout();
			this.SkillSplitter.Panel2.SuspendLayout();
			this.SkillSplitter.SuspendLayout();
			this.SkillsToolbar.SuspendLayout();
			this.InfoPage.SuspendLayout();
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
			this.OKBtn.Location = new System.Drawing.Point(352, 359);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(433, 359);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
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
			this.Pages.Location = new System.Drawing.Point(12, 38);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(496, 315);
			this.Pages.TabIndex = 2;
			// 
			// OverviewPage
			// 
			this.OverviewPage.Controls.Add(this.OverviewSplitter);
			this.OverviewPage.Controls.Add(this.Toolbar);
			this.OverviewPage.Location = new System.Drawing.Point(4, 22);
			this.OverviewPage.Name = "OverviewPage";
			this.OverviewPage.Padding = new System.Windows.Forms.Padding(3);
			this.OverviewPage.Size = new System.Drawing.Size(488, 289);
			this.OverviewPage.TabIndex = 5;
			this.OverviewPage.Text = "Overview";
			this.OverviewPage.UseVisualStyleBackColor = true;
			// 
			// OverviewSplitter
			// 
			this.OverviewSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OverviewSplitter.Location = new System.Drawing.Point(3, 28);
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
			this.OverviewSplitter.Size = new System.Drawing.Size(482, 258);
			this.OverviewSplitter.SplitterDistance = 237;
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
			this.LevelGroup.Location = new System.Drawing.Point(4, 87);
			this.LevelGroup.Name = "LevelGroup";
			this.LevelGroup.Size = new System.Drawing.Size(230, 78);
			this.LevelGroup.TabIndex = 10;
			this.LevelGroup.TabStop = false;
			this.LevelGroup.Text = "Level";
			// 
			// XPLbl
			// 
			this.XPLbl.AutoSize = true;
			this.XPLbl.Location = new System.Drawing.Point(69, 48);
			this.XPLbl.Name = "XPLbl";
			this.XPLbl.Size = new System.Drawing.Size(24, 13);
			this.XPLbl.TabIndex = 10;
			this.XPLbl.Text = "[xp]";
			// 
			// XPInfoLbl
			// 
			this.XPInfoLbl.AutoSize = true;
			this.XPInfoLbl.Location = new System.Drawing.Point(6, 48);
			this.XPInfoLbl.Name = "XPInfoLbl";
			this.XPInfoLbl.Size = new System.Drawing.Size(24, 13);
			this.XPInfoLbl.TabIndex = 9;
			this.XPInfoLbl.Text = "XP:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(72, 19);
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
			this.LevelBox.Size = new System.Drawing.Size(152, 20);
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
			this.LevelLbl.Location = new System.Drawing.Point(6, 21);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
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
			this.CompGroup.Location = new System.Drawing.Point(3, 3);
			this.CompGroup.Name = "CompGroup";
			this.CompGroup.Size = new System.Drawing.Size(231, 78);
			this.CompGroup.TabIndex = 9;
			this.CompGroup.TabStop = false;
			this.CompGroup.Text = "Complexity / Length";
			// 
			// LengthLbl
			// 
			this.LengthLbl.AutoSize = true;
			this.LengthLbl.Location = new System.Drawing.Point(69, 49);
			this.LengthLbl.Name = "LengthLbl";
			this.LengthLbl.Size = new System.Drawing.Size(42, 13);
			this.LengthLbl.TabIndex = 5;
			this.LengthLbl.Text = "[length]";
			// 
			// LengthInfoLbl
			// 
			this.LengthInfoLbl.AutoSize = true;
			this.LengthInfoLbl.Location = new System.Drawing.Point(6, 49);
			this.LengthInfoLbl.Name = "LengthInfoLbl";
			this.LengthInfoLbl.Size = new System.Drawing.Size(43, 13);
			this.LengthInfoLbl.TabIndex = 4;
			this.LengthInfoLbl.Text = "Length:";
			// 
			// CompBox
			// 
			this.CompBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CompBox.Location = new System.Drawing.Point(72, 19);
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
			this.CompBox.Size = new System.Drawing.Size(153, 20);
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
			this.CompLbl.Location = new System.Drawing.Point(6, 21);
			this.CompLbl.Name = "CompLbl";
			this.CompLbl.Size = new System.Drawing.Size(60, 13);
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
			this.InfoList.MultiSelect = false;
			this.InfoList.Name = "InfoList";
			this.InfoList.Size = new System.Drawing.Size(241, 258);
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
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.toolStripSeparator2,
            this.SuccessCountLbl,
            this.FailureCountLbl,
            this.ResetProgressBtn});
			this.Toolbar.Location = new System.Drawing.Point(3, 3);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(482, 25);
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
			this.FileMenu.Size = new System.Drawing.Size(38, 22);
			this.FileMenu.Text = "File";
			// 
			// FileExport
			// 
			this.FileExport.Name = "FileExport";
			this.FileExport.Size = new System.Drawing.Size(152, 22);
			this.FileExport.Text = "Export...";
			this.FileExport.Click += new System.EventHandler(this.FileExport_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// SuccessCountLbl
			// 
			this.SuccessCountLbl.Name = "SuccessCountLbl";
			this.SuccessCountLbl.Size = new System.Drawing.Size(66, 22);
			this.SuccessCountLbl.Text = "[successes]";
			// 
			// FailureCountLbl
			// 
			this.FailureCountLbl.Name = "FailureCountLbl";
			this.FailureCountLbl.Size = new System.Drawing.Size(53, 22);
			this.FailureCountLbl.Text = "[failures]";
			// 
			// ResetProgressBtn
			// 
			this.ResetProgressBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ResetProgressBtn.Image = ((System.Drawing.Image)(resources.GetObject("ResetProgressBtn.Image")));
			this.ResetProgressBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ResetProgressBtn.Name = "ResetProgressBtn";
			this.ResetProgressBtn.Size = new System.Drawing.Size(39, 22);
			this.ResetProgressBtn.Text = "Reset";
			this.ResetProgressBtn.Click += new System.EventHandler(this.ResetProgressBtn_Click);
			// 
			// SkillsPage
			// 
			this.SkillsPage.Controls.Add(this.SkillSplitter);
			this.SkillsPage.Controls.Add(this.SkillsToolbar);
			this.SkillsPage.Location = new System.Drawing.Point(4, 22);
			this.SkillsPage.Name = "SkillsPage";
			this.SkillsPage.Padding = new System.Windows.Forms.Padding(3);
			this.SkillsPage.Size = new System.Drawing.Size(488, 289);
			this.SkillsPage.TabIndex = 3;
			this.SkillsPage.Text = "Skills";
			this.SkillsPage.UseVisualStyleBackColor = true;
			// 
			// SkillSplitter
			// 
			this.SkillSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SkillSplitter.Location = new System.Drawing.Point(3, 28);
			this.SkillSplitter.Name = "SkillSplitter";
			// 
			// SkillSplitter.Panel1
			// 
			this.SkillSplitter.Panel1.Controls.Add(this.SkillList);
			// 
			// SkillSplitter.Panel2
			// 
			this.SkillSplitter.Panel2.Controls.Add(this.SkillSourceList);
			this.SkillSplitter.Size = new System.Drawing.Size(482, 258);
			this.SkillSplitter.SplitterDistance = 283;
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
			this.SkillList.MultiSelect = false;
			this.SkillList.Name = "SkillList";
			this.SkillList.Size = new System.Drawing.Size(283, 258);
			this.SkillList.TabIndex = 1;
			this.SkillList.UseCompatibleStateImageBehavior = false;
			this.SkillList.View = System.Windows.Forms.View.Details;
			this.SkillList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			this.SkillList.DragOver += new System.Windows.Forms.DragEventHandler(this.SkillList_DragOver);
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
			this.SkillSourceList.MultiSelect = false;
			this.SkillSourceList.Name = "SkillSourceList";
			this.SkillSourceList.Size = new System.Drawing.Size(195, 258);
			this.SkillSourceList.TabIndex = 0;
			this.SkillSourceList.UseCompatibleStateImageBehavior = false;
			this.SkillSourceList.View = System.Windows.Forms.View.Details;
			this.SkillSourceList.DoubleClick += new System.EventHandler(this.SkillSourceList_DoubleClick);
			this.SkillSourceList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.SkillSourceList_ItemDrag);
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
			this.SkillsToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator1,
            this.BreakdownBtn});
			this.SkillsToolbar.Location = new System.Drawing.Point(3, 3);
			this.SkillsToolbar.Name = "SkillsToolbar";
			this.SkillsToolbar.Size = new System.Drawing.Size(482, 25);
			this.SkillsToolbar.TabIndex = 0;
			this.SkillsToolbar.Text = "toolStrip1";
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = "Edit";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// BreakdownBtn
			// 
			this.BreakdownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.BreakdownBtn.Image = ((System.Drawing.Image)(resources.GetObject("BreakdownBtn.Image")));
			this.BreakdownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BreakdownBtn.Name = "BreakdownBtn";
			this.BreakdownBtn.Size = new System.Drawing.Size(107, 22);
			this.BreakdownBtn.Text = "Ability Breakdown";
			this.BreakdownBtn.Click += new System.EventHandler(this.BreakdownBtn_Click);
			// 
			// InfoPage
			// 
			this.InfoPage.Controls.Add(this.InfoSplitter);
			this.InfoPage.Location = new System.Drawing.Point(4, 22);
			this.InfoPage.Name = "InfoPage";
			this.InfoPage.Padding = new System.Windows.Forms.Padding(3);
			this.InfoPage.Size = new System.Drawing.Size(488, 289);
			this.InfoPage.TabIndex = 4;
			this.InfoPage.Text = "Victory / Defeat Details";
			this.InfoPage.UseVisualStyleBackColor = true;
			// 
			// InfoSplitter
			// 
			this.InfoSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InfoSplitter.Location = new System.Drawing.Point(3, 3);
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
			this.InfoSplitter.Size = new System.Drawing.Size(482, 283);
			this.InfoSplitter.SplitterDistance = 237;
			this.InfoSplitter.TabIndex = 0;
			// 
			// VictoryBox
			// 
			this.VictoryBox.AcceptsReturn = true;
			this.VictoryBox.AcceptsTab = true;
			this.VictoryBox.DefaultText = "(enter victory information here)";
			this.VictoryBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.VictoryBox.Location = new System.Drawing.Point(0, 25);
			this.VictoryBox.Multiline = true;
			this.VictoryBox.Name = "VictoryBox";
			this.VictoryBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.VictoryBox.Size = new System.Drawing.Size(237, 258);
			this.VictoryBox.TabIndex = 1;
			this.VictoryBox.Text = "(enter victory information here)";
			// 
			// VictoryToolbar
			// 
			this.VictoryToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
			this.VictoryToolbar.Location = new System.Drawing.Point(0, 0);
			this.VictoryToolbar.Name = "VictoryToolbar";
			this.VictoryToolbar.Size = new System.Drawing.Size(237, 25);
			this.VictoryToolbar.TabIndex = 0;
			this.VictoryToolbar.Text = "toolStrip1";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
			this.toolStripLabel1.Text = "Victory:";
			// 
			// DefeatBox
			// 
			this.DefeatBox.AcceptsReturn = true;
			this.DefeatBox.AcceptsTab = true;
			this.DefeatBox.DefaultText = "(enter defeat information here)";
			this.DefeatBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DefeatBox.Location = new System.Drawing.Point(0, 25);
			this.DefeatBox.Multiline = true;
			this.DefeatBox.Name = "DefeatBox";
			this.DefeatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DefeatBox.Size = new System.Drawing.Size(241, 258);
			this.DefeatBox.TabIndex = 2;
			this.DefeatBox.Text = "(enter defeat information here)";
			// 
			// DefeatButton
			// 
			this.DefeatButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
			this.DefeatButton.Location = new System.Drawing.Point(0, 0);
			this.DefeatButton.Name = "DefeatButton";
			this.DefeatButton.Size = new System.Drawing.Size(241, 25);
			this.DefeatButton.TabIndex = 0;
			this.DefeatButton.Text = "toolStrip2";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(44, 22);
			this.toolStripLabel2.Text = "Defeat:";
			// 
			// NotesPage
			// 
			this.NotesPage.Controls.Add(this.NotesBox);
			this.NotesPage.Location = new System.Drawing.Point(4, 22);
			this.NotesPage.Name = "NotesPage";
			this.NotesPage.Padding = new System.Windows.Forms.Padding(3);
			this.NotesPage.Size = new System.Drawing.Size(488, 289);
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
			this.NotesBox.Location = new System.Drawing.Point(3, 3);
			this.NotesBox.Multiline = true;
			this.NotesBox.Name = "NotesBox";
			this.NotesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.NotesBox.Size = new System.Drawing.Size(482, 283);
			this.NotesBox.TabIndex = 3;
			this.NotesBox.Text = "(enter details here)";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(56, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(452, 20);
			this.NameBox.TabIndex = 5;
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 4;
			this.NameLbl.Text = "Name:";
			// 
			// SkillChallengeBuilderForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(520, 394);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
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
			this.SkillSplitter.ResumeLayout(false);
			this.SkillsToolbar.ResumeLayout(false);
			this.SkillsToolbar.PerformLayout();
			this.InfoPage.ResumeLayout(false);
			this.InfoSplitter.Panel1.ResumeLayout(false);
			this.InfoSplitter.Panel1.PerformLayout();
			this.InfoSplitter.Panel2.ResumeLayout(false);
			this.InfoSplitter.Panel2.PerformLayout();
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
		private Utils.Controls.DefaultTextBox VictoryBox;
		private System.Windows.Forms.ToolStrip VictoryToolbar;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private Utils.Controls.DefaultTextBox DefeatBox;
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
		private Utils.Controls.DefaultTextBox NotesBox;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripDropDownButton FileMenu;
		private System.Windows.Forms.ToolStripMenuItem FileExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel SuccessCountLbl;
		private System.Windows.Forms.ToolStripLabel FailureCountLbl;
		private System.Windows.Forms.ToolStripButton ResetProgressBtn;
	}
}