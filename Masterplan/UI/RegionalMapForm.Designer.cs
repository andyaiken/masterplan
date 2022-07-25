namespace Masterplan.UI
{
	partial class RegionalMapForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionalMapForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Panel = new System.Windows.Forms.Panel();
			this.MapPanel = new Masterplan.Controls.RegionalMapPanel();
			this.MapContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.MapContextAddLocation = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.MapContextRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.MapContextEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.BrowseBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.EntryBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.PasteBtn = new System.Windows.Forms.ToolStripButton();
			this.Panel.SuspendLayout();
			this.MapContext.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(62, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Map Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(80, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(515, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Panel
			// 
			this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Panel.Controls.Add(this.MapPanel);
			this.Panel.Controls.Add(this.Toolbar);
			this.Panel.Location = new System.Drawing.Point(12, 38);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(583, 352);
			this.Panel.TabIndex = 2;
			// 
			// MapPanel
			// 
			this.MapPanel.AllowEditing = true;
			this.MapPanel.ContextMenuStrip = this.MapContext;
			this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapPanel.HighlightedLocation = null;
			this.MapPanel.Location = new System.Drawing.Point(0, 25);
			this.MapPanel.Map = null;
			this.MapPanel.Mode = Masterplan.Controls.MapViewMode.Normal;
			this.MapPanel.Name = "MapPanel";
			this.MapPanel.Plot = null;
			this.MapPanel.SelectedLocation = null;
			this.MapPanel.ShowLocations = true;
			this.MapPanel.Size = new System.Drawing.Size(581, 325);
			this.MapPanel.TabIndex = 1;
			this.MapPanel.DoubleClick += new System.EventHandler(this.MapPanel_DoubleClick);
			// 
			// MapContext
			// 
			this.MapContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MapContextAddLocation,
            this.toolStripSeparator2,
            this.MapContextRemove,
            this.MapContextEdit});
			this.MapContext.Name = "MapContext";
			this.MapContext.Size = new System.Drawing.Size(183, 76);
			this.MapContext.Opening += new System.ComponentModel.CancelEventHandler(this.MapContext_Opening);
			// 
			// MapContextAddLocation
			// 
			this.MapContextAddLocation.Name = "MapContextAddLocation";
			this.MapContextAddLocation.Size = new System.Drawing.Size(182, 22);
			this.MapContextAddLocation.Text = "Add Location Here...";
			this.MapContextAddLocation.Click += new System.EventHandler(this.MapContextAddLocation_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
			// 
			// MapContextRemove
			// 
			this.MapContextRemove.Name = "MapContextRemove";
			this.MapContextRemove.Size = new System.Drawing.Size(182, 22);
			this.MapContextRemove.Text = "Remove Location";
			this.MapContextRemove.Click += new System.EventHandler(this.MapContextRemove_Click);
			// 
			// MapContextEdit
			// 
			this.MapContextEdit.Name = "MapContextEdit";
			this.MapContextEdit.Size = new System.Drawing.Size(182, 22);
			this.MapContextEdit.Text = "Edit Location";
			this.MapContextEdit.Click += new System.EventHandler(this.MapContextEdit_Click);
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BrowseBtn,
            this.PasteBtn,
            this.toolStripSeparator1,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator3,
            this.EntryBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(581, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// BrowseBtn
			// 
			this.BrowseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.BrowseBtn.Image = ((System.Drawing.Image)(resources.GetObject("BrowseBtn.Image")));
			this.BrowseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BrowseBtn.Name = "BrowseBtn";
			this.BrowseBtn.Size = new System.Drawing.Size(105, 22);
			this.BrowseBtn.Text = "Select Map Image";
			this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(103, 22);
			this.RemoveBtn.Text = "Remove Location";
			this.RemoveBtn.Click += new System.EventHandler(this.MapContextRemove_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(80, 22);
			this.EditBtn.Text = "Edit Location";
			this.EditBtn.Click += new System.EventHandler(this.MapContextEdit_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// EntryBtn
			// 
			this.EntryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EntryBtn.Image = ((System.Drawing.Image)(resources.GetObject("EntryBtn.Image")));
			this.EntryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EntryBtn.Name = "EntryBtn";
			this.EntryBtn.Size = new System.Drawing.Size(111, 22);
			this.EntryBtn.Text = Session.I18N.EncyclopediaEntry;
			this.EntryBtn.Click += new System.EventHandler(this.EntryBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(439, 396);
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
			this.CancelBtn.Location = new System.Drawing.Point(520, 396);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// PasteBtn
			// 
			this.PasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PasteBtn.Image = ((System.Drawing.Image)(resources.GetObject("PasteBtn.Image")));
			this.PasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PasteBtn.Name = "PasteBtn";
			this.PasteBtn.Size = new System.Drawing.Size(102, 22);
			this.PasteBtn.Text = "Paste Map Image";
			this.PasteBtn.Click += new System.EventHandler(this.PasteBtn_Click);
			// 
			// RegionalMapForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(607, 431);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MinimizeBox = false;
			this.Name = "RegionalMapForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Regional Map";
			this.Panel.ResumeLayout(false);
			this.Panel.PerformLayout();
			this.MapContext.ResumeLayout(false);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Panel Panel;
		private Masterplan.Controls.RegionalMapPanel MapPanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton BrowseBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ContextMenuStrip MapContext;
		private System.Windows.Forms.ToolStripMenuItem MapContextAddLocation;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MapContextRemove;
		private System.Windows.Forms.ToolStripMenuItem MapContextEdit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton EntryBtn;
		private System.Windows.Forms.ToolStripButton PasteBtn;
	}
}