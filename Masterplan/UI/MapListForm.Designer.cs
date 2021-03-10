namespace Masterplan.UI
{
	partial class MapListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapListForm));
			this.MapList = new System.Windows.Forms.ListView();
			this.MapHdr = new System.Windows.Forms.ColumnHeader();
			this.ListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ListContextAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.ListContextRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.ListContextEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.ListContextCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.ListContextDelve = new System.Windows.Forms.ToolStripMenuItem();
			this.ListContextBreakdown = new System.Windows.Forms.ToolStripMenuItem();
			this.ListToolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.AddBuild = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.AddImport = new System.Windows.Forms.ToolStripMenuItem();
			this.AddImportProject = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.AddTile = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.MapView = new Masterplan.Controls.MapView();
			this.MapToolbar = new System.Windows.Forms.ToolStrip();
			this.PrintMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.PrintMap = new System.Windows.Forms.ToolStripMenuItem();
			this.PrintBlank = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.ToolsCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsBreakdown = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolsScreenshot = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsPlayerView = new System.Windows.Forms.ToolStripMenuItem();
			this.DelveBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.DelveAutoBuild = new System.Windows.Forms.ToolStripMenuItem();
			this.DelveAdvanced = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.DelveDeck = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.AreaLbl = new System.Windows.Forms.ToolStripLabel();
			this.AreaBox = new System.Windows.Forms.ToolStripComboBox();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.ListContext.SuspendLayout();
			this.ListToolbar.SuspendLayout();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.MapToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// MapList
			// 
			this.MapList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MapHdr});
			this.MapList.ContextMenuStrip = this.ListContext;
			this.MapList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapList.FullRowSelect = true;
			this.MapList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.MapList.HideSelection = false;
			this.MapList.Location = new System.Drawing.Point(0, 25);
			this.MapList.MultiSelect = false;
			this.MapList.Name = "MapList";
			this.MapList.Size = new System.Drawing.Size(199, 317);
			this.MapList.TabIndex = 1;
			this.MapList.UseCompatibleStateImageBehavior = false;
			this.MapList.View = System.Windows.Forms.View.Details;
			this.MapList.SelectedIndexChanged += new System.EventHandler(this.MapList_SelectedIndexChanged);
			this.MapList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// MapHdr
			// 
			this.MapHdr.Text = "Map";
			this.MapHdr.Width = 172;
			// 
			// ListContext
			// 
			this.ListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ListContextAdd,
            this.ListContextRemove,
            this.ListContextEdit,
            this.toolStripMenuItem1,
            this.ListContextCategory,
            this.toolStripMenuItem2,
            this.ListContextDelve,
            this.ListContextBreakdown});
			this.ListContext.Name = "ListContext";
			this.ListContext.Size = new System.Drawing.Size(160, 148);
			// 
			// ListContextAdd
			// 
			this.ListContextAdd.Name = "ListContextAdd";
			this.ListContextAdd.Size = new System.Drawing.Size(159, 22);
			this.ListContextAdd.Text = "Add...";
			// 
			// ListContextRemove
			// 
			this.ListContextRemove.Name = "ListContextRemove";
			this.ListContextRemove.Size = new System.Drawing.Size(159, 22);
			this.ListContextRemove.Text = "Remove";
			this.ListContextRemove.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// ListContextEdit
			// 
			this.ListContextEdit.Name = "ListContextEdit";
			this.ListContextEdit.Size = new System.Drawing.Size(159, 22);
			this.ListContextEdit.Text = "Edit";
			this.ListContextEdit.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(156, 6);
			// 
			// ListContextCategory
			// 
			this.ListContextCategory.Name = "ListContextCategory";
			this.ListContextCategory.Size = new System.Drawing.Size(159, 22);
			this.ListContextCategory.Text = "Set Category...";
			this.ListContextCategory.Click += new System.EventHandler(this.ToolsCategory_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(156, 6);
			// 
			// ListContextDelve
			// 
			this.ListContextDelve.Name = "ListContextDelve";
			this.ListContextDelve.Size = new System.Drawing.Size(159, 22);
			this.ListContextDelve.Text = "Delve AutoBuild";
			this.ListContextDelve.Click += new System.EventHandler(this.DelveBtn_Click);
			// 
			// ListContextBreakdown
			// 
			this.ListContextBreakdown.Name = "ListContextBreakdown";
			this.ListContextBreakdown.Size = new System.Drawing.Size(159, 22);
			this.ListContextBreakdown.Text = "Tile Breakdown";
			this.ListContextBreakdown.Click += new System.EventHandler(this.ToolsBreakdown_Click);
			// 
			// ListToolbar
			// 
			this.ListToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn});
			this.ListToolbar.Location = new System.Drawing.Point(0, 0);
			this.ListToolbar.Name = "ListToolbar";
			this.ListToolbar.Size = new System.Drawing.Size(199, 25);
			this.ListToolbar.TabIndex = 0;
			this.ListToolbar.Text = "toolStrip1";
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBuild,
            this.toolStripSeparator5,
            this.AddImport,
            this.AddImportProject,
            this.toolStripSeparator3,
            this.AddTile});
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(42, 22);
			this.AddBtn.Text = "Add";
			// 
			// AddBuild
			// 
			this.AddBuild.Name = "AddBuild";
			this.AddBuild.Size = new System.Drawing.Size(209, 22);
			this.AddBuild.Text = "Build a Map...";
			this.AddBuild.Click += new System.EventHandler(this.AddBuild_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(206, 6);
			// 
			// AddImport
			// 
			this.AddImport.Name = "AddImport";
			this.AddImport.Size = new System.Drawing.Size(209, 22);
			this.AddImport.Text = "Import Map Image...";
			this.AddImport.Click += new System.EventHandler(this.AddImport_Click);
			// 
			// AddImportProject
			// 
			this.AddImportProject.Name = "AddImportProject";
			this.AddImportProject.Size = new System.Drawing.Size(209, 22);
			this.AddImportProject.Text = "Import from Project File...";
			this.AddImportProject.Click += new System.EventHandler(this.AddImportProject_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(206, 6);
			// 
			// AddTile
			// 
			this.AddTile.Name = "AddTile";
			this.AddTile.Size = new System.Drawing.Size(209, 22);
			this.AddTile.Text = "Use Map Tile...";
			this.AddTile.Click += new System.EventHandler(this.AddTile_Click);
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
			// Splitter
			// 
			this.Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Splitter.Location = new System.Drawing.Point(12, 12);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.MapList);
			this.Splitter.Panel1.Controls.Add(this.ListToolbar);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.MapView);
			this.Splitter.Panel2.Controls.Add(this.MapToolbar);
			this.Splitter.Size = new System.Drawing.Size(750, 342);
			this.Splitter.SplitterDistance = 199;
			this.Splitter.TabIndex = 11;
			// 
			// MapView
			// 
			this.MapView.AllowDrawing = false;
			this.MapView.AllowDrop = true;
			this.MapView.AllowLinkCreation = false;
			this.MapView.AllowScrolling = false;
			this.MapView.BackgroundMap = null;
			this.MapView.BorderSize = 1;
			this.MapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MapView.Caption = "";
			this.MapView.Cursor = System.Windows.Forms.Cursors.Default;
			this.MapView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapView.Encounter = null;
			this.MapView.FrameType = Masterplan.Controls.MapDisplayType.Dimmed;
			//this.MapView.HeroData = null;
			this.MapView.HighlightAreas = false;
			this.MapView.HoverToken = null;
			this.MapView.LineOfSight = false;
			this.MapView.Location = new System.Drawing.Point(0, 25);
			this.MapView.Map = null;
			this.MapView.Mode = Masterplan.Controls.MapViewMode.Thumbnail;
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
			this.MapView.ShowGrid = Masterplan.Controls.MapGridMode.None;
			this.MapView.ShowGridLabels = false;
			this.MapView.ShowHealthBars = false;
			this.MapView.ShowPictureTokens = true;
			this.MapView.Size = new System.Drawing.Size(547, 317);
			this.MapView.TabIndex = 0;
			this.MapView.Tactical = false;
			this.MapView.TokenLinks = null;
			this.MapView.Viewpoint = new System.Drawing.Rectangle(0, 0, 0, 0);
			// 
			// MapToolbar
			// 
			this.MapToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintMenu,
            this.ToolsBtn,
            this.DelveBtn,
            this.toolStripSeparator2,
            this.AreaLbl,
            this.AreaBox});
			this.MapToolbar.Location = new System.Drawing.Point(0, 0);
			this.MapToolbar.Name = "MapToolbar";
			this.MapToolbar.Size = new System.Drawing.Size(547, 25);
			this.MapToolbar.TabIndex = 1;
			this.MapToolbar.Text = "toolStrip1";
			// 
			// PrintMenu
			// 
			this.PrintMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PrintMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintMap,
            this.PrintBlank});
			this.PrintMenu.Image = ((System.Drawing.Image)(resources.GetObject("PrintMenu.Image")));
			this.PrintMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PrintMenu.Name = "PrintMenu";
			this.PrintMenu.Size = new System.Drawing.Size(45, 22);
			this.PrintMenu.Text = "Print";
			// 
			// PrintMap
			// 
			this.PrintMap.Name = "PrintMap";
			this.PrintMap.Size = new System.Drawing.Size(156, 22);
			this.PrintMap.Text = "Print Map...";
			this.PrintMap.Click += new System.EventHandler(this.PrintMap_Click);
			// 
			// PrintBlank
			// 
			this.PrintBlank.Name = "PrintBlank";
			this.PrintBlank.Size = new System.Drawing.Size(156, 22);
			this.PrintBlank.Text = "Print Blank Grid";
			this.PrintBlank.Click += new System.EventHandler(this.PrintBlank_Click);
			// 
			// ToolsBtn
			// 
			this.ToolsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolsBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsCategory,
            this.ToolsBreakdown,
            this.toolStripSeparator1,
            this.ToolsScreenshot,
            this.ToolsPlayerView});
			this.ToolsBtn.Image = ((System.Drawing.Image)(resources.GetObject("ToolsBtn.Image")));
			this.ToolsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolsBtn.Name = "ToolsBtn";
			this.ToolsBtn.Size = new System.Drawing.Size(49, 22);
			this.ToolsBtn.Text = "Tools";
			// 
			// ToolsCategory
			// 
			this.ToolsCategory.Name = "ToolsCategory";
			this.ToolsCategory.Size = new System.Drawing.Size(177, 22);
			this.ToolsCategory.Text = "Set Category...";
			this.ToolsCategory.Click += new System.EventHandler(this.ToolsCategory_Click);
			// 
			// ToolsBreakdown
			// 
			this.ToolsBreakdown.Name = "ToolsBreakdown";
			this.ToolsBreakdown.Size = new System.Drawing.Size(177, 22);
			this.ToolsBreakdown.Text = "Tile Breakdown";
			this.ToolsBreakdown.Click += new System.EventHandler(this.ToolsBreakdown_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
			// 
			// ToolsScreenshot
			// 
			this.ToolsScreenshot.Name = "ToolsScreenshot";
			this.ToolsScreenshot.Size = new System.Drawing.Size(177, 22);
			this.ToolsScreenshot.Text = "Export Map";
			this.ToolsScreenshot.Click += new System.EventHandler(this.ToolsExport_Click);
			// 
			// ToolsPlayerView
			// 
			this.ToolsPlayerView.Name = "ToolsPlayerView";
			this.ToolsPlayerView.Size = new System.Drawing.Size(177, 22);
			this.ToolsPlayerView.Text = "Send to Player View";
			this.ToolsPlayerView.Click += new System.EventHandler(this.ToolsPlayerView_Click);
			// 
			// DelveBtn
			// 
			this.DelveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DelveBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelveAutoBuild,
            this.DelveAdvanced,
            this.toolStripSeparator4,
            this.DelveDeck});
			this.DelveBtn.Image = ((System.Drawing.Image)(resources.GetObject("DelveBtn.Image")));
			this.DelveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DelveBtn.Name = "DelveBtn";
			this.DelveBtn.Size = new System.Drawing.Size(105, 22);
			this.DelveBtn.Text = "Delve AutoBuild";
			// 
			// DelveAutoBuild
			// 
			this.DelveAutoBuild.Name = "DelveAutoBuild";
			this.DelveAutoBuild.Size = new System.Drawing.Size(245, 22);
			this.DelveAutoBuild.Text = "Build a Delve";
			this.DelveAutoBuild.Click += new System.EventHandler(this.DelveBtn_Click);
			// 
			// DelveAdvanced
			// 
			this.DelveAdvanced.Name = "DelveAdvanced";
			this.DelveAdvanced.Size = new System.Drawing.Size(245, 22);
			this.DelveAdvanced.Text = "Advanced Options...";
			this.DelveAdvanced.Click += new System.EventHandler(this.DelveAdvanced_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(242, 6);
			// 
			// DelveDeck
			// 
			this.DelveDeck.Name = "DelveDeck";
			this.DelveDeck.Size = new System.Drawing.Size(245, 22);
			this.DelveDeck.Text = "Build Using an Encounter Deck...";
			this.DelveDeck.Click += new System.EventHandler(this.DelveDeck_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// AreaLbl
			// 
			this.AreaLbl.Name = "AreaLbl";
			this.AreaLbl.Size = new System.Drawing.Size(39, 22);
			this.AreaLbl.Text = "Show:";
			// 
			// AreaBox
			// 
			this.AreaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AreaBox.Name = "AreaBox";
			this.AreaBox.Size = new System.Drawing.Size(121, 25);
			this.AreaBox.SelectedIndexChanged += new System.EventHandler(this.AreaBox_SelectedIndexChanged);
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(687, 360);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 12;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// MapListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(774, 395);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.Splitter);
			this.MinimizeBox = false;
			this.Name = "MapListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tactical Maps";
			this.ListContext.ResumeLayout(false);
			this.ListToolbar.ResumeLayout(false);
			this.ListToolbar.PerformLayout();
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel1.PerformLayout();
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.Panel2.PerformLayout();
			this.Splitter.ResumeLayout(false);
			this.MapToolbar.ResumeLayout(false);
			this.MapToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView MapList;
		private System.Windows.Forms.ColumnHeader MapHdr;
		private System.Windows.Forms.ToolStrip ListToolbar;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private Masterplan.Controls.MapView MapView;
		private System.Windows.Forms.ToolStrip MapToolbar;
		private System.Windows.Forms.ToolStripComboBox AreaBox;
		private System.Windows.Forms.ToolStripLabel AreaLbl;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton ToolsBtn;
		private System.Windows.Forms.ToolStripMenuItem ToolsBreakdown;
		private System.Windows.Forms.ToolStripMenuItem ToolsScreenshot;
		private System.Windows.Forms.ContextMenuStrip ListContext;
		private System.Windows.Forms.ToolStripMenuItem ListContextAdd;
		private System.Windows.Forms.ToolStripMenuItem ListContextRemove;
		private System.Windows.Forms.ToolStripMenuItem ListContextEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem ListContextCategory;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem ListContextDelve;
		private System.Windows.Forms.ToolStripMenuItem ListContextBreakdown;
		private System.Windows.Forms.ToolStripMenuItem ToolsCategory;
		private System.Windows.Forms.ToolStripDropDownButton PrintMenu;
		private System.Windows.Forms.ToolStripMenuItem PrintMap;
		private System.Windows.Forms.ToolStripMenuItem PrintBlank;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ToolsPlayerView;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ToolStripDropDownButton DelveBtn;
		private System.Windows.Forms.ToolStripMenuItem DelveAutoBuild;
		private System.Windows.Forms.ToolStripMenuItem DelveAdvanced;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem DelveDeck;
		private System.Windows.Forms.ToolStripDropDownButton AddBtn;
		private System.Windows.Forms.ToolStripMenuItem AddBuild;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem AddImport;
		private System.Windows.Forms.ToolStripMenuItem AddImportProject;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem AddTile;
	}
}