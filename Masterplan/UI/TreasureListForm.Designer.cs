namespace Masterplan.UI
{
	partial class TreasureListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreasureListForm));
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.PlotTree = new System.Windows.Forms.TreeView();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.ItemList = new System.Windows.Forms.ListView();
			this.ItemHdr = new System.Windows.Forms.ColumnHeader();
			this.PagesLbl = new System.Windows.Forms.Label();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.SelectAll = new System.Windows.Forms.ToolStripButton();
			this.SelectNone = new System.Windows.Forms.ToolStripButton();
			this.ExportBtn = new System.Windows.Forms.Button();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CancelBtn.Location = new System.Drawing.Point(422, 396);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = "Cancel";
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
			this.Splitter.Panel1.Controls.Add(this.InfoLbl);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.ItemList);
			this.Splitter.Panel2.Controls.Add(this.PagesLbl);
			this.Splitter.Panel2.Controls.Add(this.Toolbar);
			this.Splitter.Size = new System.Drawing.Size(485, 378);
			this.Splitter.SplitterDistance = 231;
			this.Splitter.TabIndex = 0;
			// 
			// PlotTree
			// 
			this.PlotTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PlotTree.HideSelection = false;
			this.PlotTree.Location = new System.Drawing.Point(0, 38);
			this.PlotTree.Name = "PlotTree";
			this.PlotTree.Size = new System.Drawing.Size(231, 340);
			this.PlotTree.TabIndex = 0;
			this.PlotTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.PlotTree_AfterSelect);
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(231, 38);
			this.InfoLbl.TabIndex = 1;
			this.InfoLbl.Text = "Select a plot point here to see treasure parcels from that subplot";
			this.InfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ItemList
			// 
			this.ItemList.CheckBoxes = true;
			this.ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ItemHdr});
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemList.FullRowSelect = true;
			this.ItemList.Location = new System.Drawing.Point(0, 25);
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(250, 337);
			this.ItemList.TabIndex = 0;
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
			this.PagesLbl.Location = new System.Drawing.Point(0, 362);
			this.PagesLbl.Name = "PagesLbl";
			this.PagesLbl.Size = new System.Drawing.Size(250, 16);
			this.PagesLbl.TabIndex = 2;
			this.PagesLbl.Text = "Note that this will require multiple pages";
			this.PagesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAll,
            this.SelectNone});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(250, 25);
			this.Toolbar.TabIndex = 1;
			this.Toolbar.Text = "toolStrip1";
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
			// ExportBtn
			// 
			this.ExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.ExportBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ExportBtn.Location = new System.Drawing.Point(341, 396);
			this.ExportBtn.Name = "ExportBtn";
			this.ExportBtn.Size = new System.Drawing.Size(75, 23);
			this.ExportBtn.TabIndex = 1;
			this.ExportBtn.Text = "Export";
			this.ExportBtn.UseVisualStyleBackColor = true;
			this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
			// 
			// TreasureListForm
			// 
			this.AcceptButton = this.ExportBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(509, 431);
			this.Controls.Add(this.ExportBtn);
			this.Controls.Add(this.Splitter);
			this.Controls.Add(this.CancelBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TreasureListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Treasure List";
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.Panel2.PerformLayout();
			this.Splitter.ResumeLayout(false);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.TreeView PlotTree;
		private System.Windows.Forms.ListView ItemList;
		private System.Windows.Forms.ColumnHeader ItemHdr;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton SelectAll;
		private System.Windows.Forms.ToolStripButton SelectNone;
		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.Label PagesLbl;
		private System.Windows.Forms.Button ExportBtn;
	}
}