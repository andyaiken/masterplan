namespace Masterplan.Controls
{
	partial class TokenPanel
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TokenPanel));
			this.ImageBox = new System.Windows.Forms.PictureBox();
			this.PictureToolbar = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.ImageSelectFile = new System.Windows.Forms.ToolStripMenuItem();
			this.ImageSelectTile = new System.Windows.Forms.ToolStripMenuItem();
			this.ImageSelectColour = new System.Windows.Forms.ToolStripMenuItem();
			this.ImageClear = new System.Windows.Forms.ToolStripLabel();
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
			this.PictureToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// ImageBox
			// 
			this.ImageBox.BackColor = System.Drawing.Color.Transparent;
			this.ImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImageBox.Location = new System.Drawing.Point(0, 25);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.Size = new System.Drawing.Size(237, 205);
			this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.ImageBox.TabIndex = 3;
			this.ImageBox.TabStop = false;
			// 
			// PictureToolbar
			// 
			this.PictureToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.ImageClear});
			this.PictureToolbar.Location = new System.Drawing.Point(0, 0);
			this.PictureToolbar.Name = "PictureToolbar";
			this.PictureToolbar.Size = new System.Drawing.Size(237, 25);
			this.PictureToolbar.TabIndex = 2;
			this.PictureToolbar.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageSelectFile,
            this.ImageSelectTile,
            this.ImageSelectColour});
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(51, 22);
			this.toolStripButton1.Text = "Select";
			// 
			// ImageSelectFile
			// 
			this.ImageSelectFile.Name = "ImageSelectFile";
			this.ImageSelectFile.Size = new System.Drawing.Size(160, 22);
			this.ImageSelectFile.Text = "From File...";
			this.ImageSelectFile.Click += new System.EventHandler(this.ImageSelectFile_Click);
			// 
			// ImageSelectTile
			// 
			this.ImageSelectTile.Name = "ImageSelectTile";
			this.ImageSelectTile.Size = new System.Drawing.Size(160, 22);
			this.ImageSelectTile.Text = "From Map Tile...";
			this.ImageSelectTile.Click += new System.EventHandler(this.ImageSelectTile_Click);
			// 
			// ImageSelectColour
			// 
			this.ImageSelectColour.Name = "ImageSelectColour";
			this.ImageSelectColour.Size = new System.Drawing.Size(160, 22);
			this.ImageSelectColour.Text = "Plain Colour...";
			this.ImageSelectColour.Click += new System.EventHandler(this.ImageSelectColour_Click);
			// 
			// ImageClear
			// 
			this.ImageClear.IsLink = true;
			this.ImageClear.Name = "ImageClear";
			this.ImageClear.Size = new System.Drawing.Size(34, 22);
			this.ImageClear.Text = "Clear";
			this.ImageClear.Click += new System.EventHandler(this.ImageClear_Click);
			// 
			// TilePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ImageBox);
			this.Controls.Add(this.PictureToolbar);
			this.Name = "TilePanel";
			this.Size = new System.Drawing.Size(237, 230);
			((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
			this.PictureToolbar.ResumeLayout(false);
			this.PictureToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox ImageBox;
		private System.Windows.Forms.ToolStrip PictureToolbar;
		private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
		private System.Windows.Forms.ToolStripMenuItem ImageSelectFile;
		private System.Windows.Forms.ToolStripMenuItem ImageSelectTile;
		private System.Windows.Forms.ToolStripMenuItem ImageSelectColour;
		private System.Windows.Forms.ToolStripLabel ImageClear;
	}
}
