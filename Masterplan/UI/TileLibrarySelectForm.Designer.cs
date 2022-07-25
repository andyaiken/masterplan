namespace Masterplan.UI
{
	partial class TileLibrarySelectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileLibrarySelectForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.LibraryList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.ListPanel = new System.Windows.Forms.Panel();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.SelectAllBtn = new System.Windows.Forms.ToolStripButton();
			this.DeselectAllBtn = new System.Windows.Forms.ToolStripButton();
			this.ListPanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(192, 312);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 1;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// LibraryList
			// 
			this.LibraryList.CheckBoxes = true;
			this.LibraryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr});
			this.LibraryList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LibraryList.FullRowSelect = true;
			this.LibraryList.HideSelection = false;
			this.LibraryList.Location = new System.Drawing.Point(0, 25);
			this.LibraryList.MultiSelect = false;
			this.LibraryList.Name = "LibraryList";
			this.LibraryList.Size = new System.Drawing.Size(336, 269);
			this.LibraryList.TabIndex = 0;
			this.LibraryList.UseCompatibleStateImageBehavior = false;
			this.LibraryList.View = System.Windows.Forms.View.Details;
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Library";
			this.NameHdr.Width = 300;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(273, 312);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// ListPanel
			// 
			this.ListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ListPanel.Controls.Add(this.LibraryList);
			this.ListPanel.Controls.Add(this.Toolbar);
			this.ListPanel.Location = new System.Drawing.Point(12, 12);
			this.ListPanel.Name = "ListPanel";
			this.ListPanel.Size = new System.Drawing.Size(336, 294);
			this.ListPanel.TabIndex = 3;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectAllBtn,
            this.DeselectAllBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(336, 25);
			this.Toolbar.TabIndex = 1;
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
			// TileLibrarySelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(360, 347);
			this.Controls.Add(this.ListPanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TileLibrarySelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Tile Libraries";
			this.ListPanel.ResumeLayout(false);
			this.ListPanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.ListView LibraryList;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.Panel ListPanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton SelectAllBtn;
		private System.Windows.Forms.ToolStripButton DeselectAllBtn;
	}
}