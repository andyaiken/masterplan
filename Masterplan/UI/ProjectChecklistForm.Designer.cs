namespace Masterplan.UI
{
	partial class ProjectChecklistForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectChecklistForm));
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.PlotTree = new System.Windows.Forms.TreeView();
			this.Pages = new System.Windows.Forms.TabControl();
			this.MagicItemsPage = new System.Windows.Forms.TabPage();
			this.ItemList = new System.Windows.Forms.ListView();
			this.ItemHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PagesLbl = new System.Windows.Forms.Label();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.SelectAll = new System.Windows.Forms.ToolStripButton();
			this.SelectNone = new System.Windows.Forms.ToolStripButton();
			this.MinisPage = new System.Windows.Forms.TabPage();
			this.MiniList = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.MapTilesPage = new System.Windows.Forms.TabPage();
			this.TileList = new System.Windows.Forms.ListView();
			this.ExportBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.Pages.SuspendLayout();
			this.MagicItemsPage.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.MinisPage.SuspendLayout();
			this.MapTilesPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CancelBtn.Location = new System.Drawing.Point(680, 396);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
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
			this.Splitter.Panel1.Controls.Add(this.PlotTree);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.Pages);
			this.Splitter.Size = new System.Drawing.Size(743, 378);
			this.Splitter.SplitterDistance = 215;
			this.Splitter.TabIndex = 0;
			// 
			// PlotTree
			// 
			this.PlotTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlotTree.HideSelection = false;
			this.PlotTree.Location = new System.Drawing.Point(0, 0);
			this.PlotTree.Name = "PlotTree";
			this.PlotTree.Size = new System.Drawing.Size(215, 378);
			this.PlotTree.TabIndex = 0;
			this.PlotTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PlotTree_AfterSelect);
			// 
			// Pages
			// 
			this.Pages.Controls.Add(this.MagicItemsPage);
			this.Pages.Controls.Add(this.MinisPage);
			this.Pages.Controls.Add(this.MapTilesPage);
			this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Pages.Location = new System.Drawing.Point(0, 0);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(524, 378);
			this.Pages.TabIndex = 3;
			// 
			// MagicItemsPage
			// 
			this.MagicItemsPage.Controls.Add(this.ItemList);
			this.MagicItemsPage.Controls.Add(this.PagesLbl);
			this.MagicItemsPage.Controls.Add(this.Toolbar);
			this.MagicItemsPage.Location = new System.Drawing.Point(4, 22);
			this.MagicItemsPage.Name = "MagicItemsPage";
			this.MagicItemsPage.Padding = new System.Windows.Forms.Padding(3);
			this.MagicItemsPage.Size = new System.Drawing.Size(516, 352);
			this.MagicItemsPage.TabIndex = 0;
			this.MagicItemsPage.Text = "Magic Items";
			this.MagicItemsPage.UseVisualStyleBackColor = true;
			// 
			// ItemList
			// 
			this.ItemList.CheckBoxes = true;
			this.ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemHdr});
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemList.FullRowSelect = true;
			this.ItemList.HideSelection = false;
			this.ItemList.Location = new System.Drawing.Point(3, 28);
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(510, 305);
			this.ItemList.TabIndex = 4;
			this.ItemList.UseCompatibleStateImageBehavior = false;
			this.ItemList.View = System.Windows.Forms.View.Details;
			this.ItemList.DoubleClick += new System.EventHandler(this.ItemList_DoubleClick);
			// 
			// ItemHdr
			// 
			this.ItemHdr.Text = "Parcels";
			this.ItemHdr.Width = 220;
			// 
			// PagesLbl
			// 
			this.PagesLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.PagesLbl.Location = new System.Drawing.Point(3, 333);
			this.PagesLbl.Name = "PagesLbl";
			this.PagesLbl.Size = new System.Drawing.Size(510, 16);
			this.PagesLbl.TabIndex = 3;
			this.PagesLbl.Text = "Note that this will require multiple pages";
			this.PagesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAll,
            this.SelectNone});
			this.Toolbar.Location = new System.Drawing.Point(3, 3);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(510, 25);
			this.Toolbar.TabIndex = 2;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// SelectAll
			// 
			this.SelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectAll.Image = ((System.Drawing.Image)(resources.GetObject("SelectAll.Image")));
			this.SelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SelectAll.Name = "SelectAll";
			this.SelectAll.Size = new System.Drawing.Size(59, 22);
			this.SelectAll.Text = "Select All";
			this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
			// 
			// SelectNone
			// 
			this.SelectNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectNone.Image = ((System.Drawing.Image)(resources.GetObject("SelectNone.Image")));
			this.SelectNone.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SelectNone.Name = "SelectNone";
			this.SelectNone.Size = new System.Drawing.Size(74, 22);
			this.SelectNone.Text = "Select None";
			this.SelectNone.Click += new System.EventHandler(this.SelectNone_Click);
			// 
			// MinisPage
			// 
			this.MinisPage.Controls.Add(this.MiniList);
			this.MinisPage.Location = new System.Drawing.Point(4, 22);
			this.MinisPage.Name = "MinisPage";
			this.MinisPage.Padding = new System.Windows.Forms.Padding(3);
			this.MinisPage.Size = new System.Drawing.Size(516, 352);
			this.MinisPage.TabIndex = 1;
			this.MinisPage.Text = "Minis";
			this.MinisPage.UseVisualStyleBackColor = true;
			// 
			// MiniList
			// 
			this.MiniList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.MiniList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MiniList.FullRowSelect = true;
			this.MiniList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.MiniList.HideSelection = false;
			this.MiniList.Location = new System.Drawing.Point(3, 3);
			this.MiniList.MultiSelect = false;
			this.MiniList.Name = "MiniList";
			this.MiniList.Size = new System.Drawing.Size(510, 346);
			this.MiniList.TabIndex = 2;
			this.MiniList.UseCompatibleStateImageBehavior = false;
			this.MiniList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = Session.I18N.Creature;
			this.columnHeader1.Width = 148;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = Session.I18N.Size;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Info";
			this.columnHeader3.Width = 215;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Count";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// MapTilesPage
			// 
			this.MapTilesPage.Controls.Add(this.TileList);
			this.MapTilesPage.Location = new System.Drawing.Point(4, 22);
			this.MapTilesPage.Name = "MapTilesPage";
			this.MapTilesPage.Padding = new System.Windows.Forms.Padding(3);
			this.MapTilesPage.Size = new System.Drawing.Size(516, 352);
			this.MapTilesPage.TabIndex = 2;
			this.MapTilesPage.Text = "Map Tiles";
			this.MapTilesPage.UseVisualStyleBackColor = true;
			// 
			// TileList
			// 
			this.TileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TileList.FullRowSelect = true;
			this.TileList.HideSelection = false;
			this.TileList.Location = new System.Drawing.Point(3, 3);
			this.TileList.MultiSelect = false;
			this.TileList.Name = "TileList";
			this.TileList.Size = new System.Drawing.Size(510, 346);
			this.TileList.TabIndex = 2;
			this.TileList.UseCompatibleStateImageBehavior = false;
			// 
			// ExportBtn
			// 
			this.ExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ExportBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ExportBtn.Location = new System.Drawing.Point(599, 396);
			this.ExportBtn.Name = "ExportBtn";
			this.ExportBtn.Size = new System.Drawing.Size(75, 23);
			this.ExportBtn.TabIndex = 1;
			this.ExportBtn.Text = Session.I18N.Export;
			this.ExportBtn.UseVisualStyleBackColor = true;
			this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
			// 
			// ProjectChecklistForm
			// 
			this.AcceptButton = this.ExportBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(767, 431);
			this.Controls.Add(this.ExportBtn);
			this.Controls.Add(this.Splitter);
			this.Controls.Add(this.CancelBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProjectChecklistForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.ProjectChecklist;
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
			this.Splitter.ResumeLayout(false);
			this.Pages.ResumeLayout(false);
			this.MagicItemsPage.ResumeLayout(false);
			this.MagicItemsPage.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.MinisPage.ResumeLayout(false);
			this.MapTilesPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.TreeView PlotTree;
		private System.Windows.Forms.Button ExportBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage MagicItemsPage;
		private System.Windows.Forms.ListView ItemList;
		private System.Windows.Forms.ColumnHeader ItemHdr;
		private System.Windows.Forms.Label PagesLbl;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton SelectAll;
		private System.Windows.Forms.ToolStripButton SelectNone;
		private System.Windows.Forms.TabPage MinisPage;
		private System.Windows.Forms.TabPage MapTilesPage;
		private System.Windows.Forms.ListView TileList;
		private System.Windows.Forms.ListView MiniList;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
	}
}