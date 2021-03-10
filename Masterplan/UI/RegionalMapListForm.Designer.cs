namespace Masterplan.UI
{
	partial class RegionalMapListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionalMapListForm));
			this.MapList = new System.Windows.Forms.ListView();
			this.MapHdr = new System.Windows.Forms.ColumnHeader();
			this.ListToolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.AddImportProject = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.MapPanel = new Masterplan.Controls.RegionalMapPanel();
			this.MapToolbar = new System.Windows.Forms.ToolStrip();
			this.LocationMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.LocationEntry = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.ToolsScreenshot = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsPlayerView = new System.Windows.Forms.ToolStripMenuItem();
			this.CloseBtn = new System.Windows.Forms.Button();
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
			this.MapList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapList.FullRowSelect = true;
			this.MapList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.MapList.HideSelection = false;
			this.MapList.Location = new System.Drawing.Point(0, 25);
			this.MapList.MultiSelect = false;
			this.MapList.Name = "MapList";
			this.MapList.Size = new System.Drawing.Size(205, 374);
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
			// ListToolbar
			// 
			this.ListToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn});
			this.ListToolbar.Location = new System.Drawing.Point(0, 0);
			this.ListToolbar.Name = "ListToolbar";
			this.ListToolbar.Size = new System.Drawing.Size(205, 25);
			this.ListToolbar.TabIndex = 0;
			this.ListToolbar.Text = "toolStrip1";
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddImportProject});
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(45, 22);
			this.AddBtn.Text = "Add";
			this.AddBtn.ButtonClick += new System.EventHandler(this.AddBtn_Click);
			// 
			// AddImportProject
			// 
			this.AddImportProject.Name = "AddImportProject";
			this.AddImportProject.Size = new System.Drawing.Size(209, 22);
			this.AddImportProject.Text = "Import from Project File...";
			this.AddImportProject.Click += new System.EventHandler(this.AddImportProject_Click);
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
			this.Splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
			this.Splitter.Panel2.Controls.Add(this.MapPanel);
			this.Splitter.Panel2.Controls.Add(this.MapToolbar);
			this.Splitter.Size = new System.Drawing.Size(726, 399);
			this.Splitter.SplitterDistance = 205;
			this.Splitter.TabIndex = 11;
			// 
			// MapPanel
			// 
			this.MapPanel.AllowEditing = false;
			this.MapPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapPanel.HighlightedLocation = null;
			this.MapPanel.Location = new System.Drawing.Point(0, 25);
			this.MapPanel.Map = null;
			this.MapPanel.Mode = Masterplan.Controls.MapViewMode.Thumbnail;
			this.MapPanel.Name = "MapPanel";
			this.MapPanel.Plot = null;
			this.MapPanel.SelectedLocation = null;
			this.MapPanel.ShowLocations = true;
			this.MapPanel.Size = new System.Drawing.Size(517, 374);
			this.MapPanel.TabIndex = 2;
			this.MapPanel.DoubleClick += new System.EventHandler(this.LocationEntry_Click);
			// 
			// MapToolbar
			// 
			this.MapToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocationMenu,
            this.ToolsMenu});
			this.MapToolbar.Location = new System.Drawing.Point(0, 0);
			this.MapToolbar.Name = "MapToolbar";
			this.MapToolbar.Size = new System.Drawing.Size(517, 25);
			this.MapToolbar.TabIndex = 1;
			this.MapToolbar.Text = "toolStrip1";
			// 
			// LocationMenu
			// 
			this.LocationMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LocationMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocationEntry});
			this.LocationMenu.Image = ((System.Drawing.Image)(resources.GetObject("LocationMenu.Image")));
			this.LocationMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LocationMenu.Name = "LocationMenu";
			this.LocationMenu.Size = new System.Drawing.Size(66, 22);
			this.LocationMenu.Text = "Location";
			// 
			// LocationEntry
			// 
			this.LocationEntry.Name = "LocationEntry";
			this.LocationEntry.Size = new System.Drawing.Size(183, 22);
			this.LocationEntry.Text = "Encyclopedia Entry...";
			this.LocationEntry.Click += new System.EventHandler(this.LocationEntry_Click);
			// 
			// ToolsMenu
			// 
			this.ToolsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsScreenshot,
            this.ToolsPlayerView});
			this.ToolsMenu.Image = ((System.Drawing.Image)(resources.GetObject("ToolsMenu.Image")));
			this.ToolsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ToolsMenu.Name = "ToolsMenu";
			this.ToolsMenu.Size = new System.Drawing.Size(49, 22);
			this.ToolsMenu.Text = "Tools";
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
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(663, 417);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 12;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// RegionalMapListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(750, 452);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.Splitter);
			this.MinimizeBox = false;
			this.Name = "RegionalMapListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Regional Maps";
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
		private System.Windows.Forms.ToolStrip MapToolbar;
		private System.Windows.Forms.ToolStripDropDownButton ToolsMenu;
		private System.Windows.Forms.ToolStripMenuItem ToolsScreenshot;
		private System.Windows.Forms.ToolStripMenuItem ToolsPlayerView;
		private System.Windows.Forms.Button CloseBtn;
		private Masterplan.Controls.RegionalMapPanel MapPanel;
		private System.Windows.Forms.ToolStripSplitButton AddBtn;
		private System.Windows.Forms.ToolStripMenuItem AddImportProject;
		private System.Windows.Forms.ToolStripDropDownButton LocationMenu;
		private System.Windows.Forms.ToolStripMenuItem LocationEntry;
	}
}