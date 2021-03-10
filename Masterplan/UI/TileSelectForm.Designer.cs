namespace Masterplan.UI
{
	partial class TileSelectForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileSelectForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.TileList = new System.Windows.Forms.ListView();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.TilePanel = new System.Windows.Forms.Panel();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.LibraryBtn = new System.Windows.Forms.ToolStripButton();
			this.CategoryBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.MatchCatBtn = new System.Windows.Forms.ToolStripButton();
			this.TilePanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(438, 307);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 1;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// TileList
			// 
			this.TileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TileList.FullRowSelect = true;
			this.TileList.HideSelection = false;
			this.TileList.Location = new System.Drawing.Point(0, 25);
			this.TileList.MultiSelect = false;
			this.TileList.Name = "TileList";
			this.TileList.Size = new System.Drawing.Size(582, 264);
			this.TileList.TabIndex = 0;
			this.TileList.UseCompatibleStateImageBehavior = false;
			this.TileList.DoubleClick += new System.EventHandler(this.TileList_DoubleClick);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(519, 307);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TilePanel
			// 
			this.TilePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TilePanel.Controls.Add(this.TileList);
			this.TilePanel.Controls.Add(this.Toolbar);
			this.TilePanel.Location = new System.Drawing.Point(12, 12);
			this.TilePanel.Name = "TilePanel";
			this.TilePanel.Size = new System.Drawing.Size(582, 289);
			this.TilePanel.TabIndex = 3;
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LibraryBtn,
            this.CategoryBtn,
            this.toolStripSeparator1,
            this.MatchCatBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(582, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// LibraryBtn
			// 
			this.LibraryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LibraryBtn.Image = ((System.Drawing.Image)(resources.GetObject("LibraryBtn.Image")));
			this.LibraryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LibraryBtn.Name = "LibraryBtn";
			this.LibraryBtn.Size = new System.Drawing.Size(108, 22);
			this.LibraryBtn.Text = "Arrange by Library";
			this.LibraryBtn.Click += new System.EventHandler(this.LibraryBtn_Click);
			// 
			// CategoryBtn
			// 
			this.CategoryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.CategoryBtn.Image = ((System.Drawing.Image)(resources.GetObject("CategoryBtn.Image")));
			this.CategoryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.CategoryBtn.Name = "CategoryBtn";
			this.CategoryBtn.Size = new System.Drawing.Size(120, 22);
			this.CategoryBtn.Text = "Arrange by Category";
			this.CategoryBtn.Click += new System.EventHandler(this.CategoryBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// MatchCatBtn
			// 
			this.MatchCatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.MatchCatBtn.Image = ((System.Drawing.Image)(resources.GetObject("MatchCatBtn.Image")));
			this.MatchCatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.MatchCatBtn.Name = "MatchCatBtn";
			this.MatchCatBtn.Size = new System.Drawing.Size(96, 22);
			this.MatchCatBtn.Text = "Match Category";
			this.MatchCatBtn.Click += new System.EventHandler(this.MatchCatBtn_Click);
			// 
			// TileSelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(606, 342);
			this.Controls.Add(this.TilePanel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TileSelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Tile";
			this.TilePanel.ResumeLayout(false);
			this.TilePanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.ListView TileList;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Panel TilePanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton LibraryBtn;
		private System.Windows.Forms.ToolStripButton CategoryBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton MatchCatBtn;
	}
}