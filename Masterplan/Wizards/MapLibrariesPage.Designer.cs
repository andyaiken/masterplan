namespace Masterplan.Wizards
{
	partial class MapLibrariesPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapLibrariesPage));
			this.InfoLbl = new System.Windows.Forms.Label();
			this.LibraryList = new System.Windows.Forms.ListView();
			this.LibHdr = new System.Windows.Forms.ColumnHeader();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.SelectAllBtn = new System.Windows.Forms.ToolStripButton();
			this.DeselectAllBtn = new System.Windows.Forms.ToolStripButton();
			this.InfoLinkLbl = new System.Windows.Forms.LinkLabel();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// InfoLbl
			// 
			this.InfoLbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.InfoLbl.Location = new System.Drawing.Point(0, 0);
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(372, 40);
			this.InfoLbl.TabIndex = 1;
			this.InfoLbl.Text = "Select the libraries you want to use to create the map.";
			// 
			// LibraryList
			// 
			this.LibraryList.CheckBoxes = true;
			this.LibraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LibHdr});
			this.LibraryList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LibraryList.FullRowSelect = true;
			this.LibraryList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LibraryList.HideSelection = false;
			this.LibraryList.Location = new System.Drawing.Point(0, 65);
			this.LibraryList.MultiSelect = false;
			this.LibraryList.Name = "LibraryList";
			this.LibraryList.Size = new System.Drawing.Size(372, 158);
			this.LibraryList.TabIndex = 2;
			this.LibraryList.UseCompatibleStateImageBehavior = false;
			this.LibraryList.View = System.Windows.Forms.View.Details;
			// 
			// LibHdr
			// 
			this.LibHdr.Text = "Library";
			this.LibHdr.Width = 300;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAllBtn,
            this.DeselectAllBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 40);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(372, 25);
			this.Toolbar.TabIndex = 3;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// SelectAllBtn
			// 
			this.SelectAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectAllBtn.Image")));
			this.SelectAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SelectAllBtn.Name = "SelectAllBtn";
			this.SelectAllBtn.Size = new System.Drawing.Size(59, 22);
			this.SelectAllBtn.Text = "Select All";
			this.SelectAllBtn.Click += new System.EventHandler(this.SelectAllBtn_Click);
			// 
			// DeselectAllBtn
			// 
			this.DeselectAllBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DeselectAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("DeselectAllBtn.Image")));
			this.DeselectAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DeselectAllBtn.Name = "DeselectAllBtn";
			this.DeselectAllBtn.Size = new System.Drawing.Size(72, 22);
			this.DeselectAllBtn.Text = "Deselect All";
			this.DeselectAllBtn.Click += new System.EventHandler(this.DeselectAllBtn_Click);
			// 
			// InfoLinkLbl
			// 
			this.InfoLinkLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.InfoLinkLbl.Location = new System.Drawing.Point(0, 223);
			this.InfoLinkLbl.Name = "InfoLinkLbl";
			this.InfoLinkLbl.Size = new System.Drawing.Size(372, 23);
			this.InfoLinkLbl.TabIndex = 4;
			this.InfoLinkLbl.TabStop = true;
			this.InfoLinkLbl.Text = "Why are my libraries not shown?";
			this.InfoLinkLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.InfoLinkLbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.InfoLinkLbl_LinkClicked);
			// 
			// MapLibrariesPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.LibraryList);
			this.Controls.Add(this.Toolbar);
			this.Controls.Add(this.InfoLinkLbl);
			this.Controls.Add(this.InfoLbl);
			this.Name = "MapLibrariesPage";
			this.Size = new System.Drawing.Size(372, 246);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label InfoLbl;
		private System.Windows.Forms.ListView LibraryList;
		private System.Windows.Forms.ColumnHeader LibHdr;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton SelectAllBtn;
		private System.Windows.Forms.ToolStripButton DeselectAllBtn;
		private System.Windows.Forms.LinkLabel InfoLinkLbl;
	}
}
