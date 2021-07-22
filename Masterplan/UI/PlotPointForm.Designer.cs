namespace Masterplan.UI
{
	partial class PlotPointForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlotPointForm));
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Links To This Point", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Links From This Point", System.Windows.Forms.HorizontalAlignment.Left);
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.TextSplitter = new System.Windows.Forms.SplitContainer();
			this.DetailsBox = new Masterplan.Controls.DefaultTextBox();
			this.ReadAloudBox = new Masterplan.Controls.DefaultTextBox();
			this.MainToolbar = new System.Windows.Forms.ToolStrip();
			this.SettingsMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.SettingsColour = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsState = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.StartXPLbl = new System.Windows.Forms.ToolStripLabel();
			this.XPSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.LocationBtn = new System.Windows.Forms.ToolStripButton();
			this.ClearLocationLbl = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.DateBtn = new System.Windows.Forms.ToolStripButton();
			this.ClearDateLbl = new System.Windows.Forms.ToolStripLabel();
			this.RPGPage = new System.Windows.Forms.TabPage();
			this.RPGPanel = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.CutElementBtn = new System.Windows.Forms.Button();
			this.CopyElementBtn = new System.Windows.Forms.Button();
			this.XPLbl = new System.Windows.Forms.Label();
			this.XPBox = new System.Windows.Forms.NumericUpDown();
			this.RemoveElementBtn = new System.Windows.Forms.Button();
			this.ParcelsPage = new System.Windows.Forms.TabPage();
			this.ParcelList = new System.Windows.Forms.ListView();
			this.ParcelHdr = new System.Windows.Forms.ColumnHeader();
			this.ParcelDetailsHdr = new System.Windows.Forms.ColumnHeader();
			this.ParcelHeroHdr = new System.Windows.Forms.ColumnHeader();
			this.ParcelToolbar = new System.Windows.Forms.ToolStrip();
			this.ParcelAddBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.ParcelAddParcel = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ParcelAddPredefined = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ParcelAddItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ParcelAddArtifact = new System.Windows.Forms.ToolStripMenuItem();
			this.ParcelRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.ParcelEditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ChangeItemBtn = new System.Windows.Forms.ToolStripButton();
			this.ItemStatBlockBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.AllocateBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.heroesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EncyclopediaPage = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.EncyclopediaList = new System.Windows.Forms.ListView();
			this.EncHdr = new System.Windows.Forms.ColumnHeader();
			this.EncyclopediaToolbar = new System.Windows.Forms.ToolStrip();
			this.EncyclopediaAddBtn = new System.Windows.Forms.ToolStripButton();
			this.EncyclopediaRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EncBrowserPanel = new System.Windows.Forms.Panel();
			this.EncBrowser = new System.Windows.Forms.WebBrowser();
			this.EncBrowserToolbar = new System.Windows.Forms.ToolStrip();
			this.EncPlayerViewBtn = new System.Windows.Forms.ToolStripButton();
			this.LinksPage = new System.Windows.Forms.TabPage();
			this.LinkList = new System.Windows.Forms.ListView();
			this.LinkHdr = new System.Windows.Forms.ColumnHeader();
			this.LinkDetailsHdr = new System.Windows.Forms.ColumnHeader();
			this.LinkToolbar = new System.Windows.Forms.ToolStrip();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.InfoBtn = new System.Windows.Forms.Button();
			this.DieRollerBtn = new System.Windows.Forms.Button();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.TextSplitter.Panel1.SuspendLayout();
			this.TextSplitter.Panel2.SuspendLayout();
			this.TextSplitter.SuspendLayout();
			this.MainToolbar.SuspendLayout();
			this.RPGPage.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.XPBox)).BeginInit();
			this.ParcelsPage.SuspendLayout();
			this.ParcelToolbar.SuspendLayout();
			this.EncyclopediaPage.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.EncyclopediaToolbar.SuspendLayout();
			this.EncBrowserPanel.SuspendLayout();
			this.EncBrowserToolbar.SuspendLayout();
			this.LinksPage.SuspendLayout();
			this.LinkToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(9, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(53, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(584, 20);
			this.NameBox.TabIndex = 1;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(481, 338);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(562, 338);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.RPGPage);
			this.Pages.Controls.Add(this.ParcelsPage);
			this.Pages.Controls.Add(this.EncyclopediaPage);
			this.Pages.Controls.Add(this.LinksPage);
			this.Pages.Location = new System.Drawing.Point(12, 38);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(625, 294);
			this.Pages.TabIndex = 2;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.TextSplitter);
			this.DetailsPage.Controls.Add(this.MainToolbar);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(617, 268);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// TextSplitter
			// 
			this.TextSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TextSplitter.Location = new System.Drawing.Point(3, 28);
			this.TextSplitter.Name = "TextSplitter";
			// 
			// TextSplitter.Panel1
			// 
			this.TextSplitter.Panel1.Controls.Add(this.DetailsBox);
			// 
			// TextSplitter.Panel2
			// 
			this.TextSplitter.Panel2.Controls.Add(this.ReadAloudBox);
			this.TextSplitter.Size = new System.Drawing.Size(611, 237);
			this.TextSplitter.SplitterDistance = 374;
			this.TextSplitter.TabIndex = 1;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.DefaultText = "(no details)";
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(0, 0);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(374, 237);
			this.DetailsBox.TabIndex = 0;
			this.DetailsBox.Text = "(no details)";
			// 
			// ReadAloudBox
			// 
			this.ReadAloudBox.AcceptsReturn = true;
			this.ReadAloudBox.AcceptsTab = true;
			this.ReadAloudBox.DefaultText = "(no read-aloud text)";
			this.ReadAloudBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ReadAloudBox.Location = new System.Drawing.Point(0, 0);
			this.ReadAloudBox.Multiline = true;
			this.ReadAloudBox.Name = "ReadAloudBox";
			this.ReadAloudBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ReadAloudBox.Size = new System.Drawing.Size(233, 237);
			this.ReadAloudBox.TabIndex = 0;
			this.ReadAloudBox.Text = "(no read-aloud text)";
			// 
			// MainToolbar
			// 
			this.MainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenu,
            this.toolStripSeparator2,
            this.StartXPLbl,
            this.XPSeparator,
            this.LocationBtn,
            this.ClearLocationLbl,
            this.toolStripSeparator6,
            this.DateBtn,
            this.ClearDateLbl});
			this.MainToolbar.Location = new System.Drawing.Point(3, 3);
			this.MainToolbar.Name = "MainToolbar";
			this.MainToolbar.Size = new System.Drawing.Size(611, 25);
			this.MainToolbar.TabIndex = 0;
			this.MainToolbar.Text = "toolStrip1";
			// 
			// SettingsMenu
			// 
			this.SettingsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SettingsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsColour,
            this.SettingsState});
			this.SettingsMenu.Image = ((System.Drawing.Image)(resources.GetObject("SettingsMenu.Image")));
			this.SettingsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SettingsMenu.Name = "SettingsMenu";
			this.SettingsMenu.Size = new System.Drawing.Size(62, 22);
			this.SettingsMenu.Text = "Settings";
			this.SettingsMenu.DropDownOpening += new System.EventHandler(this.SettingsMenu_DropDownOpening);
			// 
			// SettingsColour
			// 
			this.SettingsColour.Name = "SettingsColour";
			this.SettingsColour.Size = new System.Drawing.Size(110, 22);
			this.SettingsColour.Text = "Colour";
			// 
			// SettingsState
			// 
			this.SettingsState.Name = "SettingsState";
			this.SettingsState.Size = new System.Drawing.Size(110, 22);
			this.SettingsState.Text = "State";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// StartXPLbl
			// 
			this.StartXPLbl.Name = "StartXPLbl";
			this.StartXPLbl.Size = new System.Drawing.Size(27, 22);
			this.StartXPLbl.Text = "[xp]";
			// 
			// XPSeparator
			// 
			this.XPSeparator.Name = "XPSeparator";
			this.XPSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// LocationBtn
			// 
			this.LocationBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LocationBtn.Image = ((System.Drawing.Image)(resources.GetObject("LocationBtn.Image")));
			this.LocationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LocationBtn.Name = "LocationBtn";
			this.LocationBtn.Size = new System.Drawing.Size(76, 22);
			this.LocationBtn.Text = "Set Location";
			this.LocationBtn.Click += new System.EventHandler(this.LocationBtn_Click);
			// 
			// ClearLocationLbl
			// 
			this.ClearLocationLbl.IsLink = true;
			this.ClearLocationLbl.Name = "ClearLocationLbl";
			this.ClearLocationLbl.Size = new System.Drawing.Size(34, 22);
			this.ClearLocationLbl.Text = "Clear";
			this.ClearLocationLbl.Click += new System.EventHandler(this.ClearLocationLbl_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// DateBtn
			// 
			this.DateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DateBtn.Image = ((System.Drawing.Image)(resources.GetObject("DateBtn.Image")));
			this.DateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DateBtn.Name = "DateBtn";
			this.DateBtn.Size = new System.Drawing.Size(54, 22);
			this.DateBtn.Text = "Set Date";
			this.DateBtn.Click += new System.EventHandler(this.DateBtn_Click);
			// 
			// ClearDateLbl
			// 
			this.ClearDateLbl.IsLink = true;
			this.ClearDateLbl.Name = "ClearDateLbl";
			this.ClearDateLbl.Size = new System.Drawing.Size(34, 22);
			this.ClearDateLbl.Text = "Clear";
			this.ClearDateLbl.Click += new System.EventHandler(this.ClearDateLbl_Click);
			// 
			// RPGPage
			// 
			this.RPGPage.Controls.Add(this.RPGPanel);
			this.RPGPage.Controls.Add(this.panel1);
			this.RPGPage.Location = new System.Drawing.Point(4, 22);
			this.RPGPage.Name = "RPGPage";
			this.RPGPage.Padding = new System.Windows.Forms.Padding(3);
			this.RPGPage.Size = new System.Drawing.Size(617, 268);
			this.RPGPage.TabIndex = 2;
			this.RPGPage.Text = "Game Element";
			this.RPGPage.UseVisualStyleBackColor = true;
			// 
			// RPGPanel
			// 
			this.RPGPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.RPGPanel.Location = new System.Drawing.Point(3, 3);
			this.RPGPanel.Name = "RPGPanel";
			this.RPGPanel.Size = new System.Drawing.Size(611, 231);
			this.RPGPanel.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.CutElementBtn);
			this.panel1.Controls.Add(this.CopyElementBtn);
			this.panel1.Controls.Add(this.XPLbl);
			this.panel1.Controls.Add(this.XPBox);
			this.panel1.Controls.Add(this.RemoveElementBtn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 234);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(611, 31);
			this.panel1.TabIndex = 1;
			// 
			// CutElementBtn
			// 
			this.CutElementBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CutElementBtn.Location = new System.Drawing.Point(543, 5);
			this.CutElementBtn.Name = "CutElementBtn";
			this.CutElementBtn.Size = new System.Drawing.Size(65, 23);
			this.CutElementBtn.TabIndex = 4;
			this.CutElementBtn.Text = "Cut";
			this.CutElementBtn.UseVisualStyleBackColor = true;
			this.CutElementBtn.Click += new System.EventHandler(this.CutElementBtn_Click);
			// 
			// CopyElementBtn
			// 
			this.CopyElementBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CopyElementBtn.Location = new System.Drawing.Point(472, 5);
			this.CopyElementBtn.Name = "CopyElementBtn";
			this.CopyElementBtn.Size = new System.Drawing.Size(65, 23);
			this.CopyElementBtn.TabIndex = 3;
			this.CopyElementBtn.Text = "Copy";
			this.CopyElementBtn.UseVisualStyleBackColor = true;
			this.CopyElementBtn.Click += new System.EventHandler(this.CopyElementBtn_Click);
			// 
			// XPLbl
			// 
			this.XPLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.XPLbl.AutoSize = true;
			this.XPLbl.Location = new System.Drawing.Point(3, 10);
			this.XPLbl.Name = "XPLbl";
			this.XPLbl.Size = new System.Drawing.Size(112, 13);
			this.XPLbl.TabIndex = 0;
			this.XPLbl.Text = "Additional XP granted:";
			// 
			// XPBox
			// 
			this.XPBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.XPBox.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.XPBox.Location = new System.Drawing.Point(121, 8);
			this.XPBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.XPBox.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
			this.XPBox.Name = "XPBox";
			this.XPBox.Size = new System.Drawing.Size(155, 20);
			this.XPBox.TabIndex = 1;
			// 
			// RemoveElementBtn
			// 
			this.RemoveElementBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveElementBtn.Location = new System.Drawing.Point(330, 5);
			this.RemoveElementBtn.Name = "RemoveElementBtn";
			this.RemoveElementBtn.Size = new System.Drawing.Size(136, 23);
			this.RemoveElementBtn.TabIndex = 2;
			this.RemoveElementBtn.Text = "Remove Game Element";
			this.RemoveElementBtn.UseVisualStyleBackColor = true;
			this.RemoveElementBtn.Click += new System.EventHandler(this.RemoveElementBtn_Click);
			// 
			// ParcelsPage
			// 
			this.ParcelsPage.Controls.Add(this.ParcelList);
			this.ParcelsPage.Controls.Add(this.ParcelToolbar);
			this.ParcelsPage.Location = new System.Drawing.Point(4, 22);
			this.ParcelsPage.Name = "ParcelsPage";
			this.ParcelsPage.Padding = new System.Windows.Forms.Padding(3);
			this.ParcelsPage.Size = new System.Drawing.Size(617, 268);
			this.ParcelsPage.TabIndex = 3;
			this.ParcelsPage.Text = "Treasure Parcels";
			this.ParcelsPage.UseVisualStyleBackColor = true;
			// 
			// ParcelList
			// 
			this.ParcelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ParcelHdr,
            this.ParcelDetailsHdr,
            this.ParcelHeroHdr});
			this.ParcelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ParcelList.FullRowSelect = true;
			this.ParcelList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ParcelList.HideSelection = false;
			this.ParcelList.Location = new System.Drawing.Point(3, 28);
			this.ParcelList.MultiSelect = false;
			this.ParcelList.Name = "ParcelList";
			this.ParcelList.Size = new System.Drawing.Size(611, 237);
			this.ParcelList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ParcelList.TabIndex = 1;
			this.ParcelList.TileSize = new System.Drawing.Size(200, 50);
			this.ParcelList.UseCompatibleStateImageBehavior = false;
			this.ParcelList.View = System.Windows.Forms.View.Tile;
			this.ParcelList.SizeChanged += new System.EventHandler(this.ParcelList_SizeChanged);
			this.ParcelList.DoubleClick += new System.EventHandler(this.ParcelEditBtn_Click);
			// 
			// ParcelHdr
			// 
			this.ParcelHdr.Text = "Parcel";
			this.ParcelHdr.Width = 200;
			// 
			// ParcelDetailsHdr
			// 
			this.ParcelDetailsHdr.Text = "Details";
			this.ParcelDetailsHdr.Width = 250;
			// 
			// ParcelHeroHdr
			// 
			this.ParcelHeroHdr.Text = "PC";
			this.ParcelHeroHdr.Width = 150;
			// 
			// ParcelToolbar
			// 
			this.ParcelToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParcelAddBtn,
            this.ParcelRemoveBtn,
            this.ParcelEditBtn,
            this.toolStripSeparator1,
            this.ChangeItemBtn,
            this.ItemStatBlockBtn,
            this.toolStripSeparator5,
            this.AllocateBtn});
			this.ParcelToolbar.Location = new System.Drawing.Point(3, 3);
			this.ParcelToolbar.Name = "ParcelToolbar";
			this.ParcelToolbar.Size = new System.Drawing.Size(611, 25);
			this.ParcelToolbar.TabIndex = 0;
			this.ParcelToolbar.Text = "toolStrip1";
			// 
			// ParcelAddBtn
			// 
			this.ParcelAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ParcelAddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParcelAddParcel,
            this.toolStripSeparator3,
            this.ParcelAddPredefined,
            this.toolStripSeparator4,
            this.ParcelAddItem,
            this.ParcelAddArtifact});
			this.ParcelAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("ParcelAddBtn.Image")));
			this.ParcelAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ParcelAddBtn.Name = "ParcelAddBtn";
			this.ParcelAddBtn.Size = new System.Drawing.Size(42, 22);
			this.ParcelAddBtn.Text = "Add";
			// 
			// ParcelAddParcel
			// 
			this.ParcelAddParcel.Name = "ParcelAddParcel";
			this.ParcelAddParcel.Size = new System.Drawing.Size(186, 22);
			this.ParcelAddParcel.Text = "Parcel";
			this.ParcelAddParcel.Click += new System.EventHandler(this.ParcelAddParcel_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
			// 
			// ParcelAddPredefined
			// 
			this.ParcelAddPredefined.Name = "ParcelAddPredefined";
			this.ParcelAddPredefined.Size = new System.Drawing.Size(186, 22);
			this.ParcelAddPredefined.Text = "Predefined Parcel";
			this.ParcelAddPredefined.Click += new System.EventHandler(this.ParcelAddPredefined_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(183, 6);
			// 
			// ParcelAddItem
			// 
			this.ParcelAddItem.Name = "ParcelAddItem";
			this.ParcelAddItem.Size = new System.Drawing.Size(186, 22);
			this.ParcelAddItem.Text = "Select a Magic Item...";
			this.ParcelAddItem.Click += new System.EventHandler(this.ParcelAddItem_Click);
			// 
			// ParcelAddArtifact
			// 
			this.ParcelAddArtifact.Name = "ParcelAddArtifact";
			this.ParcelAddArtifact.Size = new System.Drawing.Size(186, 22);
			this.ParcelAddArtifact.Text = "Select an Artifact...";
			this.ParcelAddArtifact.Click += new System.EventHandler(this.ParcelAddArtifact_Click);
			// 
			// ParcelRemoveBtn
			// 
			this.ParcelRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ParcelRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("ParcelRemoveBtn.Image")));
			this.ParcelRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ParcelRemoveBtn.Name = "ParcelRemoveBtn";
			this.ParcelRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.ParcelRemoveBtn.Text = "Remove";
			this.ParcelRemoveBtn.Click += new System.EventHandler(this.ParcelRemoveBtn_Click);
			// 
			// ParcelEditBtn
			// 
			this.ParcelEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ParcelEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("ParcelEditBtn.Image")));
			this.ParcelEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ParcelEditBtn.Name = "ParcelEditBtn";
			this.ParcelEditBtn.Size = new System.Drawing.Size(31, 22);
			this.ParcelEditBtn.Text = "Edit";
			this.ParcelEditBtn.Click += new System.EventHandler(this.ParcelEditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// ChangeItemBtn
			// 
			this.ChangeItemBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ChangeItemBtn.Image = ((System.Drawing.Image)(resources.GetObject("ChangeItemBtn.Image")));
			this.ChangeItemBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ChangeItemBtn.Name = "ChangeItemBtn";
			this.ChangeItemBtn.Size = new System.Drawing.Size(115, 22);
			this.ChangeItemBtn.Text = "Change Magic Item";
			this.ChangeItemBtn.Click += new System.EventHandler(this.ChangeItemBtn_Click);
			// 
			// ItemStatBlockBtn
			// 
			this.ItemStatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ItemStatBlockBtn.Image = ((System.Drawing.Image)(resources.GetObject("ItemStatBlockBtn.Image")));
			this.ItemStatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ItemStatBlockBtn.Name = "ItemStatBlockBtn";
			this.ItemStatBlockBtn.Size = new System.Drawing.Size(63, 22);
			this.ItemStatBlockBtn.Text = "Stat Block";
			this.ItemStatBlockBtn.Click += new System.EventHandler(this.ItemStatBlockBtn_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// AllocateBtn
			// 
			this.AllocateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AllocateBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heroesToolStripMenuItem});
			this.AllocateBtn.Image = ((System.Drawing.Image)(resources.GetObject("AllocateBtn.Image")));
			this.AllocateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AllocateBtn.Name = "AllocateBtn";
			this.AllocateBtn.Size = new System.Drawing.Size(95, 22);
			this.AllocateBtn.Text = "Allocate to PC";
			this.AllocateBtn.DropDownOpening += new System.EventHandler(this.AllocateBtn_DropDownOpening);
			// 
			// heroesToolStripMenuItem
			// 
			this.heroesToolStripMenuItem.Name = "heroesToolStripMenuItem";
			this.heroesToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
			this.heroesToolStripMenuItem.Text = "(heroes)";
			// 
			// EncyclopediaPage
			// 
			this.EncyclopediaPage.Controls.Add(this.splitContainer1);
			this.EncyclopediaPage.Location = new System.Drawing.Point(4, 22);
			this.EncyclopediaPage.Name = "EncyclopediaPage";
			this.EncyclopediaPage.Padding = new System.Windows.Forms.Padding(3);
			this.EncyclopediaPage.Size = new System.Drawing.Size(617, 268);
			this.EncyclopediaPage.TabIndex = 4;
			this.EncyclopediaPage.Text = "Encyclopedia Entries";
			this.EncyclopediaPage.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.EncyclopediaList);
			this.splitContainer1.Panel1.Controls.Add(this.EncyclopediaToolbar);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.EncBrowserPanel);
			this.splitContainer1.Panel2.Controls.Add(this.EncBrowserToolbar);
			this.splitContainer1.Size = new System.Drawing.Size(611, 262);
			this.splitContainer1.SplitterDistance = 331;
			this.splitContainer1.TabIndex = 2;
			// 
			// EncyclopediaList
			// 
			this.EncyclopediaList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EncHdr});
			this.EncyclopediaList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncyclopediaList.FullRowSelect = true;
			this.EncyclopediaList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EncyclopediaList.HideSelection = false;
			this.EncyclopediaList.Location = new System.Drawing.Point(0, 25);
			this.EncyclopediaList.MultiSelect = false;
			this.EncyclopediaList.Name = "EncyclopediaList";
			this.EncyclopediaList.Size = new System.Drawing.Size(331, 237);
			this.EncyclopediaList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.EncyclopediaList.TabIndex = 1;
			this.EncyclopediaList.UseCompatibleStateImageBehavior = false;
			this.EncyclopediaList.View = System.Windows.Forms.View.Details;
			this.EncyclopediaList.SelectedIndexChanged += new System.EventHandler(this.EncyclopediaList_SelectedIndexChanged);
			// 
			// EncHdr
			// 
			this.EncHdr.Text = "Entry";
			this.EncHdr.Width = 300;
			// 
			// EncyclopediaToolbar
			// 
			this.EncyclopediaToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EncyclopediaAddBtn,
            this.EncyclopediaRemoveBtn});
			this.EncyclopediaToolbar.Location = new System.Drawing.Point(0, 0);
			this.EncyclopediaToolbar.Name = "EncyclopediaToolbar";
			this.EncyclopediaToolbar.Size = new System.Drawing.Size(331, 25);
			this.EncyclopediaToolbar.TabIndex = 0;
			this.EncyclopediaToolbar.Text = "toolStrip1";
			// 
			// EncyclopediaAddBtn
			// 
			this.EncyclopediaAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EncyclopediaAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("EncyclopediaAddBtn.Image")));
			this.EncyclopediaAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EncyclopediaAddBtn.Name = "EncyclopediaAddBtn";
			this.EncyclopediaAddBtn.Size = new System.Drawing.Size(33, 22);
			this.EncyclopediaAddBtn.Text = "Add";
			this.EncyclopediaAddBtn.Click += new System.EventHandler(this.EncyclopediaAddBtn_Click);
			// 
			// EncyclopediaRemoveBtn
			// 
			this.EncyclopediaRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EncyclopediaRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("EncyclopediaRemoveBtn.Image")));
			this.EncyclopediaRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EncyclopediaRemoveBtn.Name = "EncyclopediaRemoveBtn";
			this.EncyclopediaRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.EncyclopediaRemoveBtn.Text = "Remove";
			this.EncyclopediaRemoveBtn.Click += new System.EventHandler(this.EncyclopediaRemoveBtn_Click);
			// 
			// EncBrowserPanel
			// 
			this.EncBrowserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.EncBrowserPanel.Controls.Add(this.EncBrowser);
			this.EncBrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncBrowserPanel.Location = new System.Drawing.Point(0, 25);
			this.EncBrowserPanel.Name = "EncBrowserPanel";
			this.EncBrowserPanel.Size = new System.Drawing.Size(276, 237);
			this.EncBrowserPanel.TabIndex = 1;
			// 
			// EncBrowser
			// 
			this.EncBrowser.AllowNavigation = false;
			this.EncBrowser.AllowWebBrowserDrop = false;
			this.EncBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EncBrowser.IsWebBrowserContextMenuEnabled = false;
			this.EncBrowser.Location = new System.Drawing.Point(0, 0);
			this.EncBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.EncBrowser.Name = "EncBrowser";
			this.EncBrowser.ScriptErrorsSuppressed = true;
			this.EncBrowser.Size = new System.Drawing.Size(274, 235);
			this.EncBrowser.TabIndex = 0;
			this.EncBrowser.WebBrowserShortcutsEnabled = false;
			// 
			// EncBrowserToolbar
			// 
			this.EncBrowserToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EncPlayerViewBtn});
			this.EncBrowserToolbar.Location = new System.Drawing.Point(0, 0);
			this.EncBrowserToolbar.Name = "EncBrowserToolbar";
			this.EncBrowserToolbar.Size = new System.Drawing.Size(276, 25);
			this.EncBrowserToolbar.TabIndex = 1;
			this.EncBrowserToolbar.Text = "toolStrip1";
			// 
			// EncPlayerViewBtn
			// 
			this.EncPlayerViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EncPlayerViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("EncPlayerViewBtn.Image")));
			this.EncPlayerViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EncPlayerViewBtn.Name = "EncPlayerViewBtn";
			this.EncPlayerViewBtn.Size = new System.Drawing.Size(114, 22);
			this.EncPlayerViewBtn.Text = "Send to Player View";
			this.EncPlayerViewBtn.Click += new System.EventHandler(this.EncPlayerViewBtn_Click);
			// 
			// LinksPage
			// 
			this.LinksPage.Controls.Add(this.LinkList);
			this.LinksPage.Controls.Add(this.LinkToolbar);
			this.LinksPage.Location = new System.Drawing.Point(4, 22);
			this.LinksPage.Name = "LinksPage";
			this.LinksPage.Padding = new System.Windows.Forms.Padding(3);
			this.LinksPage.Size = new System.Drawing.Size(617, 268);
			this.LinksPage.TabIndex = 1;
			this.LinksPage.Text = "Plot Connections";
			this.LinksPage.UseVisualStyleBackColor = true;
			// 
			// LinkList
			// 
			this.LinkList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LinkHdr,
            this.LinkDetailsHdr});
			this.LinkList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LinkList.FullRowSelect = true;
			listViewGroup3.Header = "Links To This Point";
			listViewGroup3.Name = "listViewGroup1";
			listViewGroup4.Header = "Links From This Point";
			listViewGroup4.Name = "listViewGroup2";
			this.LinkList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
			this.LinkList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LinkList.HideSelection = false;
			this.LinkList.Location = new System.Drawing.Point(3, 28);
			this.LinkList.MultiSelect = false;
			this.LinkList.Name = "LinkList";
			this.LinkList.Size = new System.Drawing.Size(611, 237);
			this.LinkList.TabIndex = 1;
			this.LinkList.TileSize = new System.Drawing.Size(500, 30);
			this.LinkList.UseCompatibleStateImageBehavior = false;
			this.LinkList.View = System.Windows.Forms.View.Tile;
			this.LinkList.SizeChanged += new System.EventHandler(this.LinkList_SizeChanged);
			// 
			// LinkHdr
			// 
			this.LinkHdr.Text = "Plot Point";
			this.LinkHdr.Width = 200;
			// 
			// LinkDetailsHdr
			// 
			this.LinkDetailsHdr.Text = "Details";
			this.LinkDetailsHdr.Width = 300;
			// 
			// LinkToolbar
			// 
			this.LinkToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveBtn});
			this.LinkToolbar.Location = new System.Drawing.Point(3, 3);
			this.LinkToolbar.Name = "LinkToolbar";
			this.LinkToolbar.Size = new System.Drawing.Size(611, 25);
			this.LinkToolbar.TabIndex = 0;
			this.LinkToolbar.Text = "toolStrip1";
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
			// InfoBtn
			// 
			this.InfoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.InfoBtn.Location = new System.Drawing.Point(12, 338);
			this.InfoBtn.Name = "InfoBtn";
			this.InfoBtn.Size = new System.Drawing.Size(75, 23);
			this.InfoBtn.TabIndex = 3;
			this.InfoBtn.Text = "Information";
			this.InfoBtn.UseVisualStyleBackColor = true;
			this.InfoBtn.Click += new System.EventHandler(this.InfoBtn_Click);
			// 
			// DieRollerBtn
			// 
			this.DieRollerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.DieRollerBtn.Location = new System.Drawing.Point(93, 338);
			this.DieRollerBtn.Name = "DieRollerBtn";
			this.DieRollerBtn.Size = new System.Drawing.Size(75, 23);
			this.DieRollerBtn.TabIndex = 4;
			this.DieRollerBtn.Text = "Die Roller";
			this.DieRollerBtn.UseVisualStyleBackColor = true;
			this.DieRollerBtn.Click += new System.EventHandler(this.DieRollerBtn_Click);
			// 
			// PlotPointForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(649, 373);
			this.Controls.Add(this.DieRollerBtn);
			this.Controls.Add(this.InfoBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MinimizeBox = false;
			this.Name = "PlotPointForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Plot Point";
			this.Shown += new System.EventHandler(this.PlotPointForm_Shown);
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.TextSplitter.Panel1.ResumeLayout(false);
			this.TextSplitter.Panel1.PerformLayout();
			this.TextSplitter.Panel2.ResumeLayout(false);
			this.TextSplitter.Panel2.PerformLayout();
			this.TextSplitter.ResumeLayout(false);
			this.MainToolbar.ResumeLayout(false);
			this.MainToolbar.PerformLayout();
			this.RPGPage.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.XPBox)).EndInit();
			this.ParcelsPage.ResumeLayout(false);
			this.ParcelsPage.PerformLayout();
			this.ParcelToolbar.ResumeLayout(false);
			this.ParcelToolbar.PerformLayout();
			this.EncyclopediaPage.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.EncyclopediaToolbar.ResumeLayout(false);
			this.EncyclopediaToolbar.PerformLayout();
			this.EncBrowserPanel.ResumeLayout(false);
			this.EncBrowserToolbar.ResumeLayout(false);
			this.EncBrowserToolbar.PerformLayout();
			this.LinksPage.ResumeLayout(false);
			this.LinksPage.PerformLayout();
			this.LinkToolbar.ResumeLayout(false);
			this.LinkToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TabPage LinksPage;
		private System.Windows.Forms.ListView LinkList;
		private System.Windows.Forms.ColumnHeader LinkHdr;
		private System.Windows.Forms.ToolStrip LinkToolbar;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.TabPage RPGPage;
		private System.Windows.Forms.Button RemoveElementBtn;
		private System.Windows.Forms.Panel RPGPanel;
		private System.Windows.Forms.TabPage ParcelsPage;
		private System.Windows.Forms.ListView ParcelList;
		private System.Windows.Forms.ColumnHeader ParcelHdr;
		private System.Windows.Forms.ToolStrip ParcelToolbar;
		private System.Windows.Forms.ToolStripButton ParcelRemoveBtn;
		private System.Windows.Forms.ToolStripButton ParcelEditBtn;
		private System.Windows.Forms.ToolStrip MainToolbar;
		private System.Windows.Forms.ToolStripButton DateBtn;
		private System.Windows.Forms.ToolStripLabel ClearDateLbl;
		private System.Windows.Forms.SplitContainer TextSplitter;
		private Masterplan.Controls.DefaultTextBox ReadAloudBox;
		private Masterplan.Controls.DefaultTextBox DetailsBox;
        private System.Windows.Forms.TabPage EncyclopediaPage;
        private System.Windows.Forms.ListView EncyclopediaList;
        private System.Windows.Forms.ToolStrip EncyclopediaToolbar;
        private System.Windows.Forms.ColumnHeader EncHdr;
        private System.Windows.Forms.ToolStripButton EncyclopediaAddBtn;
		private System.Windows.Forms.ToolStripButton EncyclopediaRemoveBtn;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.WebBrowser EncBrowser;
		private System.Windows.Forms.Panel EncBrowserPanel;
		private System.Windows.Forms.ColumnHeader ParcelDetailsHdr;
		private System.Windows.Forms.ToolStrip EncBrowserToolbar;
		private System.Windows.Forms.ToolStripButton EncPlayerViewBtn;
		private System.Windows.Forms.ColumnHeader LinkDetailsHdr;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ChangeItemBtn;
		private System.Windows.Forms.ToolStripButton ItemStatBlockBtn;
		private System.Windows.Forms.ToolStripButton LocationBtn;
		private System.Windows.Forms.ToolStripLabel ClearLocationLbl;
		private System.Windows.Forms.NumericUpDown XPBox;
		private System.Windows.Forms.Label XPLbl;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStripDropDownButton ParcelAddBtn;
		private System.Windows.Forms.ToolStripMenuItem ParcelAddPredefined;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ParcelAddParcel;
		private System.Windows.Forms.ToolStripMenuItem ParcelAddItem;
		private System.Windows.Forms.ToolStripLabel StartXPLbl;
		private System.Windows.Forms.ColumnHeader ParcelHeroHdr;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripDropDownButton AllocateBtn;
		private System.Windows.Forms.ToolStripMenuItem heroesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripSeparator XPSeparator;
		private System.Windows.Forms.ToolStripDropDownButton SettingsMenu;
		private System.Windows.Forms.ToolStripMenuItem SettingsColour;
		private System.Windows.Forms.ToolStripMenuItem SettingsState;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Button InfoBtn;
		private System.Windows.Forms.Button DieRollerBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem ParcelAddArtifact;
		private System.Windows.Forms.Button CopyElementBtn;
		private System.Windows.Forms.Button CutElementBtn;
	}
}