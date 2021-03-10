namespace Masterplan.UI
{
	partial class DeckBuilderForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeckBuilderForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.LevelLbl = new System.Windows.Forms.Label();
			this.LevelBox = new System.Windows.Forms.NumericUpDown();
			this.panel1 = new System.Windows.Forms.Panel();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.DeckSplitter = new System.Windows.Forms.SplitContainer();
			this.DeckView = new Masterplan.Controls.DeckGrid();
			this.PropertiesPanel = new System.Windows.Forms.Panel();
			this.CardList = new System.Windows.Forms.ListView();
			this.CardHdr = new System.Windows.Forms.ColumnHeader();
			this.CardInfoHdr = new System.Windows.Forms.ColumnHeader();
			this.DeckToolbar = new System.Windows.Forms.ToolStrip();
			this.DuplicateBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.RefreshBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ViewBtn = new System.Windows.Forms.ToolStripButton();
			this.CreatureList = new System.Windows.Forms.ListView();
			this.CreatureHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoLbl = new System.Windows.Forms.Label();
			this.AutoBuildBtn = new System.Windows.Forms.Button();
			this.RefillBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).BeginInit();
			this.panel1.SuspendLayout();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.DeckSplitter.Panel1.SuspendLayout();
			this.DeckSplitter.Panel2.SuspendLayout();
			this.DeckSplitter.SuspendLayout();
			this.PropertiesPanel.SuspendLayout();
			this.DeckToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(542, 397);
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
			this.CancelBtn.Location = new System.Drawing.Point(623, 397);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(3, 6);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(47, 3);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(420, 20);
			this.NameBox.TabIndex = 1;
			// 
			// LevelLbl
			// 
			this.LevelLbl.AutoSize = true;
			this.LevelLbl.Location = new System.Drawing.Point(3, 31);
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(36, 13);
			this.LevelLbl.TabIndex = 2;
			this.LevelLbl.Text = "Level:";
			// 
			// LevelBox
			// 
			this.LevelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LevelBox.Location = new System.Drawing.Point(47, 29);
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
			this.LevelBox.Size = new System.Drawing.Size(420, 20);
			this.LevelBox.TabIndex = 3;
			this.LevelBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LevelBox.ValueChanged += new System.EventHandler(this.LevelBox_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.Splitter);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(686, 379);
			this.panel1.TabIndex = 0;
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
			this.Splitter.Panel1.Controls.Add(this.DeckSplitter);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.CreatureList);
			this.Splitter.Panel2.Controls.Add(this.InfoLbl);
			this.Splitter.Size = new System.Drawing.Size(686, 379);
			this.Splitter.SplitterDistance = 470;
			this.Splitter.TabIndex = 0;
			// 
			// DeckSplitter
			// 
			this.DeckSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DeckSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.DeckSplitter.Location = new System.Drawing.Point(0, 0);
			this.DeckSplitter.Name = "DeckSplitter";
			this.DeckSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// DeckSplitter.Panel1
			// 
			this.DeckSplitter.Panel1.Controls.Add(this.DeckView);
			this.DeckSplitter.Panel1.Controls.Add(this.PropertiesPanel);
			// 
			// DeckSplitter.Panel2
			// 
			this.DeckSplitter.Panel2.Controls.Add(this.CardList);
			this.DeckSplitter.Panel2.Controls.Add(this.DeckToolbar);
			this.DeckSplitter.Size = new System.Drawing.Size(470, 379);
			this.DeckSplitter.SplitterDistance = 203;
			this.DeckSplitter.TabIndex = 0;
			// 
			// DeckView
			// 
			this.DeckView.AllowDrop = true;
			this.DeckView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DeckView.Deck = null;
			this.DeckView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DeckView.Location = new System.Drawing.Point(0, 54);
			this.DeckView.Name = "DeckView";
			this.DeckView.Size = new System.Drawing.Size(470, 149);
			this.DeckView.TabIndex = 1;
			this.DeckView.DragOver += new System.Windows.Forms.DragEventHandler(this.DeckView_DragOver);
			this.DeckView.CellActivated += new System.EventHandler(this.DeckView_CellActivated);
			this.DeckView.DragDrop += new System.Windows.Forms.DragEventHandler(this.DeckView_DragDrop);
			this.DeckView.SelectedCellChanged += new System.EventHandler(this.DeckView_SelectedCellChanged);
			// 
			// PropertiesPanel
			// 
			this.PropertiesPanel.Controls.Add(this.NameBox);
			this.PropertiesPanel.Controls.Add(this.LevelLbl);
			this.PropertiesPanel.Controls.Add(this.NameLbl);
			this.PropertiesPanel.Controls.Add(this.LevelBox);
			this.PropertiesPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.PropertiesPanel.Location = new System.Drawing.Point(0, 0);
			this.PropertiesPanel.Name = "PropertiesPanel";
			this.PropertiesPanel.Size = new System.Drawing.Size(470, 54);
			this.PropertiesPanel.TabIndex = 0;
			// 
			// CardList
			// 
			this.CardList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CardHdr,
            this.CardInfoHdr});
			this.CardList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CardList.FullRowSelect = true;
			this.CardList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CardList.HideSelection = false;
			this.CardList.Location = new System.Drawing.Point(0, 25);
			this.CardList.MultiSelect = false;
			this.CardList.Name = "CardList";
			this.CardList.Size = new System.Drawing.Size(470, 147);
			this.CardList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.CardList.TabIndex = 1;
			this.CardList.UseCompatibleStateImageBehavior = false;
			this.CardList.View = System.Windows.Forms.View.Details;
			this.CardList.DoubleClick += new System.EventHandler(this.CardList_DoubleClick);
			// 
			// CardHdr
			// 
			this.CardHdr.Text = "Creature";
			this.CardHdr.Width = 227;
			// 
			// CardInfoHdr
			// 
			this.CardInfoHdr.Text = "Info";
			this.CardInfoHdr.Width = 196;
			// 
			// DeckToolbar
			// 
			this.DeckToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DuplicateBtn,
            this.RemoveBtn,
            this.toolStripSeparator1,
            this.RefreshBtn,
            this.toolStripSeparator2,
            this.ViewBtn});
			this.DeckToolbar.Location = new System.Drawing.Point(0, 0);
			this.DeckToolbar.Name = "DeckToolbar";
			this.DeckToolbar.Size = new System.Drawing.Size(470, 25);
			this.DeckToolbar.TabIndex = 0;
			this.DeckToolbar.Text = "toolStrip1";
			// 
			// DuplicateBtn
			// 
			this.DuplicateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DuplicateBtn.Image = ((System.Drawing.Image)(resources.GetObject("DuplicateBtn.Image")));
			this.DuplicateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DuplicateBtn.Name = "DuplicateBtn";
			this.DuplicateBtn.Size = new System.Drawing.Size(61, 22);
			this.DuplicateBtn.Text = "Duplicate";
			this.DuplicateBtn.Click += new System.EventHandler(this.DuplicateBtn_Click);
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
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// RefreshBtn
			// 
			this.RefreshBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RefreshBtn.Image = ((System.Drawing.Image)(resources.GetObject("RefreshBtn.Image")));
			this.RefreshBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RefreshBtn.Name = "RefreshBtn";
			this.RefreshBtn.Size = new System.Drawing.Size(51, 22);
			this.RefreshBtn.Text = "Re-Add";
			this.RefreshBtn.Click += new System.EventHandler(this.RefreshBtn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// ViewBtn
			// 
			this.ViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("ViewBtn.Image")));
			this.ViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ViewBtn.Name = "ViewBtn";
			this.ViewBtn.Size = new System.Drawing.Size(69, 22);
			this.ViewBtn.Text = "View Cards";
			this.ViewBtn.Click += new System.EventHandler(this.ViewBtn_Click);
			// 
			// CreatureList
			// 
			this.CreatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CreatureHdr});
			this.CreatureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CreatureList.FullRowSelect = true;
			this.CreatureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CreatureList.HideSelection = false;
			this.CreatureList.Location = new System.Drawing.Point(0, 0);
			this.CreatureList.MultiSelect = false;
			this.CreatureList.Name = "CreatureList";
			this.CreatureList.Size = new System.Drawing.Size(212, 340);
			this.CreatureList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.CreatureList.TabIndex = 0;
			this.CreatureList.UseCompatibleStateImageBehavior = false;
			this.CreatureList.View = System.Windows.Forms.View.Details;
			this.CreatureList.DoubleClick += new System.EventHandler(this.CreatureList_DoubleClick);
			this.CreatureList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.CreatureList_ItemDrag);
			// 
			// CreatureHdr
			// 
			this.CreatureHdr.Text = "Creature";
			this.CreatureHdr.Width = 180;
			// 
			// InfoLbl
			// 
			this.InfoLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.InfoLbl.Location = new System.Drawing.Point(0, 340);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(212, 39);
			this.InfoLbl.TabIndex = 1;
			this.InfoLbl.Text = "[info]";
			this.InfoLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AutoBuildBtn
			// 
			this.AutoBuildBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AutoBuildBtn.Location = new System.Drawing.Point(12, 397);
			this.AutoBuildBtn.Name = "AutoBuildBtn";
			this.AutoBuildBtn.Size = new System.Drawing.Size(100, 23);
			this.AutoBuildBtn.TabIndex = 1;
			this.AutoBuildBtn.Text = "AutoBuild";
			this.AutoBuildBtn.UseVisualStyleBackColor = true;
			this.AutoBuildBtn.Click += new System.EventHandler(this.AutoBuildBtn_Click);
			// 
			// RefillBtn
			// 
			this.RefillBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.RefillBtn.Location = new System.Drawing.Point(118, 397);
			this.RefillBtn.Name = "RefillBtn";
			this.RefillBtn.Size = new System.Drawing.Size(100, 23);
			this.RefillBtn.TabIndex = 2;
			this.RefillBtn.Text = "Refill Deck";
			this.RefillBtn.UseVisualStyleBackColor = true;
			this.RefillBtn.Click += new System.EventHandler(this.RefillBtn_Click);
			// 
			// DeckBuilderForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(710, 432);
			this.Controls.Add(this.RefillBtn);
			this.Controls.Add(this.AutoBuildBtn);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeckBuilderForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encounter Deck Builder";
			((System.ComponentModel.ISupportInitialize)(this.LevelBox)).EndInit();
			this.panel1.ResumeLayout(false);
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.DeckSplitter.Panel1.ResumeLayout(false);
			this.DeckSplitter.Panel2.ResumeLayout(false);
			this.DeckSplitter.Panel2.PerformLayout();
			this.DeckSplitter.ResumeLayout(false);
			this.PropertiesPanel.ResumeLayout(false);
			this.PropertiesPanel.PerformLayout();
			this.DeckToolbar.ResumeLayout(false);
			this.DeckToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label LevelLbl;
		private System.Windows.Forms.NumericUpDown LevelBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.SplitContainer DeckSplitter;
		private Masterplan.Controls.DeckGrid DeckView;
		private System.Windows.Forms.ToolStrip DeckToolbar;
		private System.Windows.Forms.ListView CardList;
		private System.Windows.Forms.ListView CreatureList;
		private System.Windows.Forms.Button AutoBuildBtn;
		private System.Windows.Forms.ColumnHeader CardHdr;
		private System.Windows.Forms.ColumnHeader CardInfoHdr;
		private System.Windows.Forms.ColumnHeader CreatureHdr;
		private System.Windows.Forms.Panel PropertiesPanel;
		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ToolStripButton DuplicateBtn;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ViewBtn;
		private System.Windows.Forms.Button RefillBtn;
		private System.Windows.Forms.ToolStripButton RefreshBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}