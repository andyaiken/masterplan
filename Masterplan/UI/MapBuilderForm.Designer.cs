namespace Masterplan.UI
{
	partial class MapBuilderForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapBuilderForm));
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.MapView = new Masterplan.Controls.MapView();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.RemoveBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.clearMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RotateLeftBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.rotateMapLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RotateRightBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.rotateMapRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.OrderingBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.OrderingFront = new System.Windows.Forms.ToolStripMenuItem();
			this.OrderingBack = new System.Windows.Forms.ToolStripMenuItem();
			this.at = new System.Windows.Forms.ToolStripDropDownButton();
			this.ToolsNavigate = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsReset = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsHighlightAreas = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsSelectBackground = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsClearBackground = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsImportMap = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsAutoBuild = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.NameLbl = new System.Windows.Forms.ToolStripLabel();
			this.NameBox = new System.Windows.Forms.ToolStripTextBox();
			this.ZoomGauge = new System.Windows.Forms.TrackBar();
			this.Pages = new System.Windows.Forms.TabControl();
			this.TilesPage = new System.Windows.Forms.TabPage();
			this.TileList = new System.Windows.Forms.ListView();
			this.TileHdr = new System.Windows.Forms.ColumnHeader();
			this.MapFilterPanel = new System.Windows.Forms.Panel();
			this.SelectLibrariesBtn = new System.Windows.Forms.Button();
			this.SearchBox = new System.Windows.Forms.TextBox();
			this.SearchLbl = new System.Windows.Forms.Label();
			this.TileToolbar = new System.Windows.Forms.ToolStrip();
			this.TilesViewBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.ViewGroupBy = new System.Windows.Forms.ToolStripMenuItem();
			this.GroupByTileSet = new System.Windows.Forms.ToolStripMenuItem();
			this.GroupBySize = new System.Windows.Forms.ToolStripMenuItem();
			this.GroupByCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewSize = new System.Windows.Forms.ToolStripMenuItem();
			this.SizeSmall = new System.Windows.Forms.ToolStripMenuItem();
			this.SizeMedium = new System.Windows.Forms.ToolStripMenuItem();
			this.SizeLarge = new System.Windows.Forms.ToolStripMenuItem();
			this.FilterBtn = new System.Windows.Forms.ToolStripButton();
			this.AreasPage = new System.Windows.Forms.TabPage();
			this.AreaList = new System.Windows.Forms.ListView();
			this.AreaHdr = new System.Windows.Forms.ColumnHeader();
			this.AreaToolbar = new System.Windows.Forms.ToolStrip();
			this.AreaRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.AreaEditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.FullMapBtn = new System.Windows.Forms.ToolStripButton();
			this.MapContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ContextSelect = new System.Windows.Forms.ToolStripMenuItem();
			this.ContextClear = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.ContextCreate = new System.Windows.Forms.ToolStripMenuItem();
			this.Tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.TileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.TileContextRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.TileContextSwap = new System.Windows.Forms.ToolStripMenuItem();
			this.TileContextDuplicate = new System.Windows.Forms.ToolStripMenuItem();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.Toolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZoomGauge)).BeginInit();
			this.Pages.SuspendLayout();
			this.TilesPage.SuspendLayout();
			this.MapFilterPanel.SuspendLayout();
			this.TileToolbar.SuspendLayout();
			this.AreasPage.SuspendLayout();
			this.AreaToolbar.SuspendLayout();
			this.MapContextMenu.SuspendLayout();
			this.TileContextMenu.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Splitter
			// 
			this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.Splitter.Location = new System.Drawing.Point(0, 0);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.MapView);
			this.Splitter.Panel1.Controls.Add(this.Toolbar);
			this.Splitter.Panel1.Controls.Add(this.ZoomGauge);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.Pages);
			this.Splitter.Size = new System.Drawing.Size(882, 401);
			this.Splitter.SplitterDistance = 675;
			this.Splitter.TabIndex = 0;
			// 
			// MapView
			// 
			this.MapView.AllowDrawing = false;
			this.MapView.AllowDrop = true;
			this.MapView.AllowLinkCreation = false;
			this.MapView.AllowScrolling = false;
			this.MapView.BackgroundMap = null;
			this.MapView.BorderSize = 3;
			this.MapView.Caption = "";
			this.MapView.Cursor = System.Windows.Forms.Cursors.Default;
			this.MapView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapView.Encounter = null;
			this.MapView.FrameType = Masterplan.Controls.MapDisplayType.Dimmed;
			//this.MapView.HeroData = null;
			this.MapView.HighlightAreas = true;
			this.MapView.HoverToken = null;
			this.MapView.LineOfSight = false;
			this.MapView.Location = new System.Drawing.Point(0, 25);
			this.MapView.Map = null;
			this.MapView.Mode = Masterplan.Controls.MapViewMode.Normal;
			this.MapView.Name = "MapView";
			this.MapView.Plot = null;
			this.MapView.ScalingFactor = 1;
			this.MapView.SelectedArea = null;
			this.MapView.SelectedTiles = null;
			this.MapView.Selection = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.ShowAuras = true;
			this.MapView.ShowConditions = true;
			this.MapView.ShowCreatureLabels = true;
			this.MapView.ShowCreatures = Masterplan.Controls.CreatureViewMode.All;
			this.MapView.ShowGrid = Masterplan.Controls.MapGridMode.Behind;
			this.MapView.ShowGridLabels = false;
			this.MapView.ShowHealthBars = false;
			this.MapView.ShowPictureTokens = true;
			this.MapView.Size = new System.Drawing.Size(675, 331);
			this.MapView.TabIndex = 0;
			this.MapView.Tactical = false;
			this.MapView.TokenLinks = null;
			this.MapView.Viewpoint = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.MapView.ItemDropped += new System.EventHandler(this.MapView_ItemDropped);
			this.MapView.RegionSelected += new System.EventHandler(this.MapView_RegionSelected);
			this.MapView.HighlightedAreaChanged += new System.EventHandler(this.MapView_HoverAreaChanged);
			this.MapView.TileContext += new System.EventHandler(this.MapView_TileContext);
			this.MapView.MouseZoomed += new System.Windows.Forms.MouseEventHandler(this.MapView_MouseZoomed);
			this.MapView.ItemRemoved += new System.EventHandler(this.MapView_ItemRemoved);
			this.MapView.ItemMoved += new Masterplan.Events.MovementEventHandler(this.MapView_ItemMoved);
			this.MapView.AreaActivated += new Masterplan.Events.MapAreaEventHandler(this.MapView_AreaActivated);
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RemoveBtn,
            this.RotateLeftBtn,
            this.RotateRightBtn,
            this.toolStripSeparator1,
            this.OrderingBtn,
            this.at,
            this.toolStripSeparator3,
            this.NameLbl,
            this.NameBox});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(675, 25);
			this.Toolbar.TabIndex = 1;
			this.Toolbar.Text = "toolStrip1";
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMapToolStripMenuItem});
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(66, 22);
			this.RemoveBtn.Text = "Remove";
			this.RemoveBtn.ButtonClick += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// clearMapToolStripMenuItem
			// 
			this.clearMapToolStripMenuItem.Name = "clearMapToolStripMenuItem";
			this.clearMapToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
			this.clearMapToolStripMenuItem.Text = "Clear All Tiles";
			this.clearMapToolStripMenuItem.Click += new System.EventHandler(this.ToolsClearAll_Click);
			// 
			// RotateLeftBtn
			// 
			this.RotateLeftBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RotateLeftBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateMapLeftToolStripMenuItem});
			this.RotateLeftBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateLeftBtn.Image")));
			this.RotateLeftBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RotateLeftBtn.Name = "RotateLeftBtn";
			this.RotateLeftBtn.Size = new System.Drawing.Size(80, 22);
			this.RotateLeftBtn.Text = "Rotate Left";
			this.RotateLeftBtn.ButtonClick += new System.EventHandler(this.RotateLeftBtn_Click);
			// 
			// rotateMapLeftToolStripMenuItem
			// 
			this.rotateMapLeftToolStripMenuItem.Name = "rotateMapLeftToolStripMenuItem";
			this.rotateMapLeftToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.rotateMapLeftToolStripMenuItem.Text = "Rotate Map Left";
			this.rotateMapLeftToolStripMenuItem.Click += new System.EventHandler(this.RotateMapLeft_Click);
			// 
			// RotateRightBtn
			// 
			this.RotateRightBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RotateRightBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rotateMapRightToolStripMenuItem});
			this.RotateRightBtn.Image = ((System.Drawing.Image)(resources.GetObject("RotateRightBtn.Image")));
			this.RotateRightBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RotateRightBtn.Name = "RotateRightBtn";
			this.RotateRightBtn.Size = new System.Drawing.Size(88, 22);
			this.RotateRightBtn.Text = "Rotate Right";
			this.RotateRightBtn.ButtonClick += new System.EventHandler(this.RotateRightBtn_Click);
			// 
			// rotateMapRightToolStripMenuItem
			// 
			this.rotateMapRightToolStripMenuItem.Name = "rotateMapRightToolStripMenuItem";
			this.rotateMapRightToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.rotateMapRightToolStripMenuItem.Text = "Rotate Map Right";
			this.rotateMapRightToolStripMenuItem.Click += new System.EventHandler(this.RotateMapRight_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// OrderingBtn
			// 
			this.OrderingBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.OrderingBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderingFront,
            this.OrderingBack});
			this.OrderingBtn.Image = ((System.Drawing.Image)(resources.GetObject("OrderingBtn.Image")));
			this.OrderingBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OrderingBtn.Name = "OrderingBtn";
			this.OrderingBtn.Size = new System.Drawing.Size(67, 22);
			this.OrderingBtn.Text = "Ordering";
			// 
			// OrderingFront
			// 
			this.OrderingFront.Name = "OrderingFront";
			this.OrderingFront.Size = new System.Drawing.Size(147, 22);
			this.OrderingFront.Text = "Bring to Front";
			this.OrderingFront.Click += new System.EventHandler(this.OrderingFront_Click);
			// 
			// OrderingBack
			// 
			this.OrderingBack.Name = "OrderingBack";
			this.OrderingBack.Size = new System.Drawing.Size(147, 22);
			this.OrderingBack.Text = "Send to Back";
			this.OrderingBack.Click += new System.EventHandler(this.OrderingBack_Click);
			// 
			// at
			// 
			this.at.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.at.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsNavigate,
            this.ToolsReset,
            this.toolStripSeparator6,
            this.ToolsHighlightAreas,
            this.toolStripSeparator2,
            this.ToolsSelectBackground,
            this.ToolsClearBackground,
            this.toolStripMenuItem2,
            this.ToolsImportMap,
            this.toolStripSeparator8,
            this.ToolsAutoBuild});
			this.at.Image = ((System.Drawing.Image)(resources.GetObject("at.Image")));
			this.at.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.at.Name = "at";
			this.at.Size = new System.Drawing.Size(49, 22);
			this.at.Text = "Tools";
			// 
			// ToolsNavigate
			// 
			this.ToolsNavigate.Name = "ToolsNavigate";
			this.ToolsNavigate.Size = new System.Drawing.Size(208, 22);
			this.ToolsNavigate.Text = "Scroll and Zoom";
			this.ToolsNavigate.Click += new System.EventHandler(this.ToolsNavigate_Click);
			// 
			// ToolsReset
			// 
			this.ToolsReset.Name = "ToolsReset";
			this.ToolsReset.Size = new System.Drawing.Size(208, 22);
			this.ToolsReset.Text = "Reset View";
			this.ToolsReset.Click += new System.EventHandler(this.ToolsReset_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(205, 6);
			// 
			// ToolsHighlightAreas
			// 
			this.ToolsHighlightAreas.Name = "ToolsHighlightAreas";
			this.ToolsHighlightAreas.Size = new System.Drawing.Size(208, 22);
			this.ToolsHighlightAreas.Text = "Highlight Areas";
			this.ToolsHighlightAreas.Click += new System.EventHandler(this.ToolsHighlightAreas_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
			// 
			// ToolsSelectBackground
			// 
			this.ToolsSelectBackground.Name = "ToolsSelectBackground";
			this.ToolsSelectBackground.Size = new System.Drawing.Size(208, 22);
			this.ToolsSelectBackground.Text = "Select Background Map...";
			this.ToolsSelectBackground.Click += new System.EventHandler(this.ToolsSelectBackground_Click);
			// 
			// ToolsClearBackground
			// 
			this.ToolsClearBackground.Name = "ToolsClearBackground";
			this.ToolsClearBackground.Size = new System.Drawing.Size(208, 22);
			this.ToolsClearBackground.Text = "Clear Background Map";
			this.ToolsClearBackground.Click += new System.EventHandler(this.ToolsClearBackground_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(205, 6);
			// 
			// ToolsImportMap
			// 
			this.ToolsImportMap.Name = "ToolsImportMap";
			this.ToolsImportMap.Size = new System.Drawing.Size(208, 22);
			this.ToolsImportMap.Text = "Import Map Image...";
			this.ToolsImportMap.Click += new System.EventHandler(this.ToolsImportMap_Click);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(205, 6);
			// 
			// ToolsAutoBuild
			// 
			this.ToolsAutoBuild.Name = "ToolsAutoBuild";
			this.ToolsAutoBuild.Size = new System.Drawing.Size(208, 22);
			this.ToolsAutoBuild.Text = "AutoBuild...";
			this.ToolsAutoBuild.Click += new System.EventHandler(this.ToolsAutoBuild_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// NameLbl
			// 
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(69, 22);
			this.NameLbl.Text = "Map Name:";
			// 
			// NameBox
			// 
			this.NameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(200, 25);
			this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
			// 
			// ZoomGauge
			// 
			this.ZoomGauge.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.ZoomGauge.Location = new System.Drawing.Point(0, 356);
			this.ZoomGauge.Maximum = 100;
			this.ZoomGauge.Name = "ZoomGauge";
			this.ZoomGauge.Size = new System.Drawing.Size(675, 45);
			this.ZoomGauge.TabIndex = 2;
			this.ZoomGauge.TickFrequency = 10;
			this.ZoomGauge.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.ZoomGauge.Value = 50;
			this.ZoomGauge.Visible = false;
			this.ZoomGauge.Scroll += new System.EventHandler(this.ZoomGauge_Scroll);
			// 
			// Pages
			// 
			this.Pages.Controls.Add(this.TilesPage);
			this.Pages.Controls.Add(this.AreasPage);
			this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Pages.Location = new System.Drawing.Point(0, 0);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(203, 401);
			this.Pages.TabIndex = 3;
			// 
			// TilesPage
			// 
			this.TilesPage.Controls.Add(this.TileList);
			this.TilesPage.Controls.Add(this.MapFilterPanel);
			this.TilesPage.Controls.Add(this.TileToolbar);
			this.TilesPage.Location = new System.Drawing.Point(4, 22);
			this.TilesPage.Name = "TilesPage";
			this.TilesPage.Padding = new System.Windows.Forms.Padding(3);
			this.TilesPage.Size = new System.Drawing.Size(195, 375);
			this.TilesPage.TabIndex = 0;
			this.TilesPage.Text = "Tiles";
			this.TilesPage.UseVisualStyleBackColor = true;
			// 
			// TileList
			// 
			this.TileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TileHdr});
			this.TileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TileList.FullRowSelect = true;
			this.TileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.TileList.HideSelection = false;
			this.TileList.Location = new System.Drawing.Point(3, 87);
			this.TileList.MultiSelect = false;
			this.TileList.Name = "TileList";
			this.TileList.Size = new System.Drawing.Size(189, 285);
			this.TileList.TabIndex = 1;
			this.TileList.UseCompatibleStateImageBehavior = false;
			this.TileList.DoubleClick += new System.EventHandler(this.TileList_DoubleClick);
			this.TileList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.TileList_ItemDrag);
			// 
			// TileHdr
			// 
			this.TileHdr.Text = "Tile";
			this.TileHdr.Width = 120;
			// 
			// MapFilterPanel
			// 
			this.MapFilterPanel.Controls.Add(this.SelectLibrariesBtn);
			this.MapFilterPanel.Controls.Add(this.SearchBox);
			this.MapFilterPanel.Controls.Add(this.SearchLbl);
			this.MapFilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.MapFilterPanel.Location = new System.Drawing.Point(3, 28);
			this.MapFilterPanel.Name = "MapFilterPanel";
			this.MapFilterPanel.Size = new System.Drawing.Size(189, 59);
			this.MapFilterPanel.TabIndex = 3;
			// 
			// SelectLibrariesBtn
			// 
			this.SelectLibrariesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SelectLibrariesBtn.Location = new System.Drawing.Point(53, 29);
			this.SelectLibrariesBtn.Name = "SelectLibrariesBtn";
			this.SelectLibrariesBtn.Size = new System.Drawing.Size(133, 23);
			this.SelectLibrariesBtn.TabIndex = 2;
			this.SelectLibrariesBtn.Text = "Select Libraries";
			this.SelectLibrariesBtn.UseVisualStyleBackColor = true;
			this.SelectLibrariesBtn.Click += new System.EventHandler(this.ViewSelectLibraries_Click);
			// 
			// SearchBox
			// 
			this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SearchBox.Location = new System.Drawing.Point(53, 3);
			this.SearchBox.Name = "SearchBox";
			this.SearchBox.Size = new System.Drawing.Size(133, 20);
			this.SearchBox.TabIndex = 1;
			this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
			// 
			// SearchLbl
			// 
			this.SearchLbl.AutoSize = true;
			this.SearchLbl.Location = new System.Drawing.Point(3, 6);
			this.SearchLbl.Name = "SearchLbl";
			this.SearchLbl.Size = new System.Drawing.Size(44, 13);
			this.SearchLbl.TabIndex = 0;
			this.SearchLbl.Text = "Search:";
			// 
			// TileToolbar
			// 
			this.TileToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TilesViewBtn,
            this.FilterBtn});
			this.TileToolbar.Location = new System.Drawing.Point(3, 3);
			this.TileToolbar.Name = "TileToolbar";
			this.TileToolbar.Size = new System.Drawing.Size(189, 25);
			this.TileToolbar.TabIndex = 2;
			this.TileToolbar.Text = "toolStrip1";
			// 
			// TilesViewBtn
			// 
			this.TilesViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.TilesViewBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ViewGroupBy,
            this.ViewSize});
			this.TilesViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("TilesViewBtn.Image")));
			this.TilesViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TilesViewBtn.Name = "TilesViewBtn";
			this.TilesViewBtn.Size = new System.Drawing.Size(45, 22);
			this.TilesViewBtn.Text = "View";
			// 
			// ViewGroupBy
			// 
			this.ViewGroupBy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GroupByTileSet,
            this.GroupBySize,
            this.GroupByCategory});
			this.ViewGroupBy.Name = "ViewGroupBy";
			this.ViewGroupBy.Size = new System.Drawing.Size(152, 22);
			this.ViewGroupBy.Text = "Group By";
			// 
			// GroupByTileSet
			// 
			this.GroupByTileSet.Name = "GroupByTileSet";
			this.GroupByTileSet.Size = new System.Drawing.Size(152, 22);
			this.GroupByTileSet.Text = "Library";
			this.GroupByTileSet.Click += new System.EventHandler(this.GroupByTileSet_Click);
			// 
			// GroupBySize
			// 
			this.GroupBySize.Name = "GroupBySize";
			this.GroupBySize.Size = new System.Drawing.Size(152, 22);
			this.GroupBySize.Text = "Tile Size";
			this.GroupBySize.Click += new System.EventHandler(this.GroupBySize_Click);
			// 
			// GroupByCategory
			// 
			this.GroupByCategory.Name = "GroupByCategory";
			this.GroupByCategory.Size = new System.Drawing.Size(152, 22);
			this.GroupByCategory.Text = "Tile Category";
			this.GroupByCategory.Click += new System.EventHandler(this.GroupByCategory_Click);
			// 
			// ViewSize
			// 
			this.ViewSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SizeSmall,
            this.SizeMedium,
            this.SizeLarge});
			this.ViewSize.Name = "ViewSize";
			this.ViewSize.Size = new System.Drawing.Size(152, 22);
			this.ViewSize.Text = "Size";
			// 
			// SizeSmall
			// 
			this.SizeSmall.Name = "SizeSmall";
			this.SizeSmall.Size = new System.Drawing.Size(119, 22);
			this.SizeSmall.Text = "Small";
			this.SizeSmall.Click += new System.EventHandler(this.SizeSmall_Click);
			// 
			// SizeMedium
			// 
			this.SizeMedium.Name = "SizeMedium";
			this.SizeMedium.Size = new System.Drawing.Size(119, 22);
			this.SizeMedium.Text = "Medium";
			this.SizeMedium.Click += new System.EventHandler(this.SizeMedium_Click);
			// 
			// SizeLarge
			// 
			this.SizeLarge.Name = "SizeLarge";
			this.SizeLarge.Size = new System.Drawing.Size(119, 22);
			this.SizeLarge.Text = "Large";
			this.SizeLarge.Click += new System.EventHandler(this.SizeLarge_Click);
			// 
			// FilterBtn
			// 
			this.FilterBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FilterBtn.Image = ((System.Drawing.Image)(resources.GetObject("FilterBtn.Image")));
			this.FilterBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FilterBtn.Name = "FilterBtn";
			this.FilterBtn.Size = new System.Drawing.Size(83, 22);
			this.FilterBtn.Text = "Filter This List";
			this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
			// 
			// AreasPage
			// 
			this.AreasPage.Controls.Add(this.AreaList);
			this.AreasPage.Controls.Add(this.AreaToolbar);
			this.AreasPage.Location = new System.Drawing.Point(4, 22);
			this.AreasPage.Name = "AreasPage";
			this.AreasPage.Padding = new System.Windows.Forms.Padding(3);
			this.AreasPage.Size = new System.Drawing.Size(195, 375);
			this.AreasPage.TabIndex = 1;
			this.AreasPage.Text = "Map Areas";
			this.AreasPage.UseVisualStyleBackColor = true;
			// 
			// AreaList
			// 
			this.AreaList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AreaHdr});
			this.AreaList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AreaList.FullRowSelect = true;
			this.AreaList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.AreaList.HideSelection = false;
			this.AreaList.Location = new System.Drawing.Point(3, 28);
			this.AreaList.MultiSelect = false;
			this.AreaList.Name = "AreaList";
			this.AreaList.Size = new System.Drawing.Size(189, 344);
			this.AreaList.TabIndex = 1;
			this.AreaList.UseCompatibleStateImageBehavior = false;
			this.AreaList.View = System.Windows.Forms.View.Details;
			this.AreaList.SelectedIndexChanged += new System.EventHandler(this.AreaList_SelectedIndexChanged);
			this.AreaList.DoubleClick += new System.EventHandler(this.AreaEditBtn_Click);
			// 
			// AreaHdr
			// 
			this.AreaHdr.Text = "Area Name";
			this.AreaHdr.Width = 150;
			// 
			// AreaToolbar
			// 
			this.AreaToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AreaRemoveBtn,
            this.AreaEditBtn,
            this.toolStripSeparator7,
            this.FullMapBtn});
			this.AreaToolbar.Location = new System.Drawing.Point(3, 3);
			this.AreaToolbar.Name = "AreaToolbar";
			this.AreaToolbar.Size = new System.Drawing.Size(189, 25);
			this.AreaToolbar.TabIndex = 0;
			this.AreaToolbar.Text = "toolStrip1";
			// 
			// AreaRemoveBtn
			// 
			this.AreaRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AreaRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("AreaRemoveBtn.Image")));
			this.AreaRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AreaRemoveBtn.Name = "AreaRemoveBtn";
			this.AreaRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.AreaRemoveBtn.Text = "Remove";
			this.AreaRemoveBtn.Click += new System.EventHandler(this.AreaRemoveBtn_Click);
			// 
			// AreaEditBtn
			// 
			this.AreaEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AreaEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("AreaEditBtn.Image")));
			this.AreaEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AreaEditBtn.Name = "AreaEditBtn";
			this.AreaEditBtn.Size = new System.Drawing.Size(31, 22);
			this.AreaEditBtn.Text = "Edit";
			this.AreaEditBtn.Click += new System.EventHandler(this.AreaEditBtn_Click);
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
			// 
			// FullMapBtn
			// 
			this.FullMapBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FullMapBtn.Image = ((System.Drawing.Image)(resources.GetObject("FullMapBtn.Image")));
			this.FullMapBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FullMapBtn.Name = "FullMapBtn";
			this.FullMapBtn.Size = new System.Drawing.Size(57, 22);
			this.FullMapBtn.Text = "Full Map";
			this.FullMapBtn.Click += new System.EventHandler(this.FullMapBtn_Click);
			// 
			// MapContextMenu
			// 
			this.MapContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSelect,
            this.ContextClear,
            this.toolStripMenuItem1,
            this.ContextCreate});
			this.MapContextMenu.Name = "MapContextMenu";
			this.MapContextMenu.Size = new System.Drawing.Size(172, 76);
			// 
			// ContextSelect
			// 
			this.ContextSelect.Name = "ContextSelect";
			this.ContextSelect.Size = new System.Drawing.Size(171, 22);
			this.ContextSelect.Text = "Select Tiles";
			this.ContextSelect.Click += new System.EventHandler(this.ContextSelect_Click);
			// 
			// ContextClear
			// 
			this.ContextClear.Name = "ContextClear";
			this.ContextClear.Size = new System.Drawing.Size(171, 22);
			this.ContextClear.Text = "Clear Tiles";
			this.ContextClear.Click += new System.EventHandler(this.ContextClear_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
			// 
			// ContextCreate
			// 
			this.ContextCreate.Name = "ContextCreate";
			this.ContextCreate.Size = new System.Drawing.Size(171, 22);
			this.ContextCreate.Text = "Create Map Area...";
			this.ContextCreate.Click += new System.EventHandler(this.ContextCreate_Click);
			// 
			// TileContextMenu
			// 
			this.TileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TileContextRemove,
            this.TileContextSwap,
            this.TileContextDuplicate});
			this.TileContextMenu.Name = "TileContextMenu";
			this.TileContextMenu.Size = new System.Drawing.Size(147, 70);
			// 
			// TileContextRemove
			// 
			this.TileContextRemove.Name = "TileContextRemove";
			this.TileContextRemove.Size = new System.Drawing.Size(146, 22);
			this.TileContextRemove.Text = "Remove Tile";
			this.TileContextRemove.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// TileContextSwap
			// 
			this.TileContextSwap.Name = "TileContextSwap";
			this.TileContextSwap.Size = new System.Drawing.Size(146, 22);
			this.TileContextSwap.Text = "Swap Tile";
			this.TileContextSwap.Click += new System.EventHandler(this.TileContextSwap_Click);
			// 
			// TileContextDuplicate
			// 
			this.TileContextDuplicate.Name = "TileContextDuplicate";
			this.TileContextDuplicate.Size = new System.Drawing.Size(146, 22);
			this.TileContextDuplicate.Text = "Duplicate Tile";
			this.TileContextDuplicate.Click += new System.EventHandler(this.TileContextDuplicate_Click);
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.Controls.Add(this.Splitter);
			this.MainPanel.Location = new System.Drawing.Point(12, 12);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(882, 401);
			this.MainPanel.TabIndex = 3;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(738, 419);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(819, 419);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 5;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// MapForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(906, 454);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MinimizeBox = false;
			this.Name = "MapForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Map Editor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapForm_FormClosed);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapForm_FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapForm_KeyDown);
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel1.PerformLayout();
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ZoomGauge)).EndInit();
			this.Pages.ResumeLayout(false);
			this.TilesPage.ResumeLayout(false);
			this.TilesPage.PerformLayout();
			this.MapFilterPanel.ResumeLayout(false);
			this.MapFilterPanel.PerformLayout();
			this.TileToolbar.ResumeLayout(false);
			this.TileToolbar.PerformLayout();
			this.AreasPage.ResumeLayout(false);
			this.AreasPage.PerformLayout();
			this.AreaToolbar.ResumeLayout(false);
			this.AreaToolbar.PerformLayout();
			this.MapContextMenu.ResumeLayout(false);
			this.TileContextMenu.ResumeLayout(false);
			this.MainPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.ListView TileList;
		private System.Windows.Forms.ColumnHeader TileHdr;
		private Masterplan.Controls.MapView MapView;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripLabel NameLbl;
		private System.Windows.Forms.ToolStripTextBox NameBox;
		private System.Windows.Forms.ToolStripDropDownButton OrderingBtn;
		private System.Windows.Forms.ToolStripMenuItem OrderingFront;
		private System.Windows.Forms.ToolStripMenuItem OrderingBack;
		private System.Windows.Forms.ToolStripDropDownButton at;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStrip TileToolbar;
		private System.Windows.Forms.ToolStripMenuItem ToolsHighlightAreas;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage TilesPage;
		private System.Windows.Forms.TabPage AreasPage;
		private System.Windows.Forms.ToolStrip AreaToolbar;
		private System.Windows.Forms.ListView AreaList;
		private System.Windows.Forms.ToolStripButton AreaRemoveBtn;
		private System.Windows.Forms.ToolStripButton AreaEditBtn;
		private System.Windows.Forms.ColumnHeader AreaHdr;
		private System.Windows.Forms.ToolStripDropDownButton TilesViewBtn;
		private System.Windows.Forms.ToolStripMenuItem ViewGroupBy;
		private System.Windows.Forms.ToolStripMenuItem GroupByTileSet;
		private System.Windows.Forms.ToolStripMenuItem GroupBySize;
		private System.Windows.Forms.ContextMenuStrip MapContextMenu;
		private System.Windows.Forms.ToolStripMenuItem ContextCreate;
		private System.Windows.Forms.ToolStripMenuItem ContextClear;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem GroupByCategory;
		private System.Windows.Forms.ToolStripMenuItem ToolsAutoBuild;
		private System.Windows.Forms.ToolTip Tooltip;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TrackBar ZoomGauge;
		private System.Windows.Forms.ToolStripMenuItem ToolsNavigate;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem ToolsReset;
		private System.Windows.Forms.ToolStripMenuItem ContextSelect;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip TileContextMenu;
		private System.Windows.Forms.ToolStripMenuItem TileContextRemove;
		private System.Windows.Forms.ToolStripMenuItem TileContextSwap;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ToolsSelectBackground;
		private System.Windows.Forms.ToolStripMenuItem ToolsClearBackground;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton FullMapBtn;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ToolStripMenuItem ToolsImportMap;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem TileContextDuplicate;
		private System.Windows.Forms.ToolStripSplitButton RemoveBtn;
		private System.Windows.Forms.ToolStripSplitButton RotateLeftBtn;
		private System.Windows.Forms.ToolStripSplitButton RotateRightBtn;
		private System.Windows.Forms.ToolStripMenuItem clearMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rotateMapLeftToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rotateMapRightToolStripMenuItem;
		private System.Windows.Forms.Panel MapFilterPanel;
		private System.Windows.Forms.ToolStripMenuItem ViewSize;
		private System.Windows.Forms.ToolStripMenuItem SizeSmall;
		private System.Windows.Forms.ToolStripMenuItem SizeMedium;
		private System.Windows.Forms.ToolStripMenuItem SizeLarge;
		private System.Windows.Forms.ToolStripButton FilterBtn;
		private System.Windows.Forms.Button SelectLibrariesBtn;
		private System.Windows.Forms.TextBox SearchBox;
		private System.Windows.Forms.Label SearchLbl;
	}
}