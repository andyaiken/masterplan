namespace Masterplan.UI
{
	partial class TileForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.WidthLbl = new System.Windows.Forms.Label();
			this.WidthBox = new System.Windows.Forms.NumericUpDown();
			this.HeightLbl = new System.Windows.Forms.Label();
			this.HeightBox = new System.Windows.Forms.NumericUpDown();
			this.ImagePanel = new System.Windows.Forms.Panel();
			this.TilePanel = new Masterplan.Controls.TilePanel();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.BrowseBtn = new System.Windows.Forms.ToolStripButton();
			this.PasteBtn = new System.Windows.Forms.ToolStripButton();
			this.ClearBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SetColourBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.GridBtn = new System.Windows.Forms.ToolStripButton();
			this.CatLbl = new System.Windows.Forms.Label();
			this.CatBox = new System.Windows.Forms.ComboBox();
			this.KeywordLbl = new System.Windows.Forms.Label();
			this.KeywordBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
			this.ImagePanel.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(169, 391);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 9;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(250, 391);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 10;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// WidthLbl
			// 
			this.WidthLbl.AutoSize = true;
			this.WidthLbl.Location = new System.Drawing.Point(12, 14);
			this.WidthLbl.Name = "WidthLbl";
			this.WidthLbl.Size = new System.Drawing.Size(38, 13);
			this.WidthLbl.TabIndex = 0;
			this.WidthLbl.Text = "Width:";
			// 
			// WidthBox
			// 
			this.WidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WidthBox.Location = new System.Drawing.Point(74, 12);
			this.WidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WidthBox.Name = "WidthBox";
			this.WidthBox.Size = new System.Drawing.Size(251, 20);
			this.WidthBox.TabIndex = 1;
			this.WidthBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.WidthBox.ValueChanged += new System.EventHandler(this.WidthBox_ValueChanged);
			// 
			// HeightLbl
			// 
			this.HeightLbl.AutoSize = true;
			this.HeightLbl.Location = new System.Drawing.Point(12, 40);
			this.HeightLbl.Name = "HeightLbl";
			this.HeightLbl.Size = new System.Drawing.Size(41, 13);
			this.HeightLbl.TabIndex = 2;
			this.HeightLbl.Text = "Height:";
			// 
			// HeightBox
			// 
			this.HeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HeightBox.Location = new System.Drawing.Point(74, 38);
			this.HeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.HeightBox.Name = "HeightBox";
			this.HeightBox.Size = new System.Drawing.Size(251, 20);
			this.HeightBox.TabIndex = 3;
			this.HeightBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.HeightBox.ValueChanged += new System.EventHandler(this.HeightBox_ValueChanged);
			// 
			// ImagePanel
			// 
			this.ImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ImagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ImagePanel.Controls.Add(this.TilePanel);
			this.ImagePanel.Controls.Add(this.Toolbar);
			this.ImagePanel.Location = new System.Drawing.Point(13, 117);
			this.ImagePanel.Name = "ImagePanel";
			this.ImagePanel.Size = new System.Drawing.Size(313, 268);
			this.ImagePanel.TabIndex = 8;
			// 
			// TilePanel
			// 
			this.TilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TilePanel.Location = new System.Drawing.Point(0, 25);
			this.TilePanel.Name = "TilePanel";
			this.TilePanel.ShowGridlines = true;
			this.TilePanel.Size = new System.Drawing.Size(311, 241);
			this.TilePanel.TabIndex = 1;
			this.TilePanel.TileColour = System.Drawing.Color.White;
			this.TilePanel.TileImage = null;
			this.TilePanel.TileSize = new System.Drawing.Size(2, 2);
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BrowseBtn,
            this.PasteBtn,
            this.ClearBtn,
            this.toolStripSeparator1,
            this.SetColourBtn,
            this.toolStripSeparator2,
            this.GridBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(311, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = "toolStrip1";
			// 
			// BrowseBtn
			// 
			this.BrowseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.BrowseBtn.Image = ((System.Drawing.Image)(resources.GetObject("BrowseBtn.Image")));
			this.BrowseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BrowseBtn.Name = "BrowseBtn";
			this.BrowseBtn.Size = new System.Drawing.Size(49, 22);
			this.BrowseBtn.Text = "Browse";
			this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
			// 
			// PasteBtn
			// 
			this.PasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PasteBtn.Image = ((System.Drawing.Image)(resources.GetObject("PasteBtn.Image")));
			this.PasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PasteBtn.Name = "PasteBtn";
			this.PasteBtn.Size = new System.Drawing.Size(39, 22);
			this.PasteBtn.Text = "Paste";
			this.PasteBtn.Click += new System.EventHandler(this.PasteBtn_Click);
			// 
			// ClearBtn
			// 
			this.ClearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("ClearBtn.Image")));
			this.ClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ClearBtn.Name = "ClearBtn";
			this.ClearBtn.Size = new System.Drawing.Size(38, 22);
			this.ClearBtn.Text = "Clear";
			this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// SetColourBtn
			// 
			this.SetColourBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SetColourBtn.Image = ((System.Drawing.Image)(resources.GetObject("SetColourBtn.Image")));
			this.SetColourBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SetColourBtn.Name = "SetColourBtn";
			this.SetColourBtn.Size = new System.Drawing.Size(66, 22);
			this.SetColourBtn.Text = "Set Colour";
			this.SetColourBtn.Click += new System.EventHandler(this.SetColourBtn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// GridBtn
			// 
			this.GridBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.GridBtn.Image = ((System.Drawing.Image)(resources.GetObject("GridBtn.Image")));
			this.GridBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.GridBtn.Name = "GridBtn";
			this.GridBtn.Size = new System.Drawing.Size(57, 22);
			this.GridBtn.Text = "Gridlines";
			this.GridBtn.Click += new System.EventHandler(this.GridBtn_Click);
			// 
			// CatLbl
			// 
			this.CatLbl.AutoSize = true;
			this.CatLbl.Location = new System.Drawing.Point(12, 67);
			this.CatLbl.Name = "CatLbl";
			this.CatLbl.Size = new System.Drawing.Size(52, 13);
			this.CatLbl.TabIndex = 4;
			this.CatLbl.Text = "Category:";
			// 
			// CatBox
			// 
			this.CatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CatBox.FormattingEnabled = true;
			this.CatBox.Location = new System.Drawing.Point(74, 64);
			this.CatBox.Name = "CatBox";
			this.CatBox.Size = new System.Drawing.Size(251, 21);
			this.CatBox.TabIndex = 5;
			// 
			// KeywordLbl
			// 
			this.KeywordLbl.AutoSize = true;
			this.KeywordLbl.Location = new System.Drawing.Point(12, 94);
			this.KeywordLbl.Name = "KeywordLbl";
			this.KeywordLbl.Size = new System.Drawing.Size(56, 13);
			this.KeywordLbl.TabIndex = 6;
			this.KeywordLbl.Text = "Keywords:";
			// 
			// KeywordBox
			// 
			this.KeywordBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeywordBox.Location = new System.Drawing.Point(74, 91);
			this.KeywordBox.Name = "KeywordBox";
			this.KeywordBox.Size = new System.Drawing.Size(251, 20);
			this.KeywordBox.TabIndex = 7;
			// 
			// TileForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(337, 426);
			this.Controls.Add(this.KeywordBox);
			this.Controls.Add(this.KeywordLbl);
			this.Controls.Add(this.CatBox);
			this.Controls.Add(this.CatLbl);
			this.Controls.Add(this.WidthBox);
			this.Controls.Add(this.WidthLbl);
			this.Controls.Add(this.HeightLbl);
			this.Controls.Add(this.ImagePanel);
			this.Controls.Add(this.HeightBox);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TileForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tile";
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
			this.ImagePanel.ResumeLayout(false);
			this.ImagePanel.PerformLayout();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label WidthLbl;
		private System.Windows.Forms.NumericUpDown WidthBox;
		private System.Windows.Forms.Label HeightLbl;
		private System.Windows.Forms.NumericUpDown HeightBox;
		private System.Windows.Forms.Panel ImagePanel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton BrowseBtn;
		private System.Windows.Forms.ToolStripButton ClearBtn;
		private System.Windows.Forms.Label CatLbl;
		private System.Windows.Forms.ComboBox CatBox;
		private System.Windows.Forms.ToolStripButton SetColourBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private Masterplan.Controls.TilePanel TilePanel;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton GridBtn;
		private System.Windows.Forms.ToolStripButton PasteBtn;
		private System.Windows.Forms.Label KeywordLbl;
		private System.Windows.Forms.TextBox KeywordBox;
	}
}