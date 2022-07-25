namespace Masterplan.UI
{
	partial class EncyclopediaImageForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncyclopediaImageForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Panel = new System.Windows.Forms.Panel();
			this.PictureBox = new System.Windows.Forms.PictureBox();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.BrowseBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.PlayerViewBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.PasteBtn = new System.Windows.Forms.ToolStripButton();
			this.Panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(74, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Picture Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(92, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(303, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Panel
			// 
			this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Panel.Controls.Add(this.PictureBox);
			this.Panel.Controls.Add(this.Toolbar);
			this.Panel.Location = new System.Drawing.Point(12, 38);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(383, 305);
			this.Panel.TabIndex = 2;
			// 
			// PictureBox
			// 
			this.PictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureBox.Location = new System.Drawing.Point(0, 25);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Size = new System.Drawing.Size(381, 278);
			this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox.TabIndex = 1;
			this.PictureBox.TabStop = false;
			this.PictureBox.DoubleClick += new System.EventHandler(this.BrowseBtn_Click);
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BrowseBtn,
            this.PasteBtn,
            this.toolStripSeparator1,
            this.PlayerViewBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(381, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// BrowseBtn
			// 
			this.BrowseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.BrowseBtn.Image = ((System.Drawing.Image)(resources.GetObject("BrowseBtn.Image")));
			this.BrowseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BrowseBtn.Name = "BrowseBtn";
			this.BrowseBtn.Size = new System.Drawing.Size(82, 22);
			this.BrowseBtn.Text = "Select Picture";
			this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// PlayerViewBtn
			// 
			this.PlayerViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewBtn.Image")));
			this.PlayerViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewBtn.Name = "PlayerViewBtn";
			this.PlayerViewBtn.Size = new System.Drawing.Size(114, 22);
			this.PlayerViewBtn.Text = Session.I18N.SendPlayerView;
			this.PlayerViewBtn.Click += new System.EventHandler(this.PlayerViewBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(239, 349);
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
			this.CancelBtn.Location = new System.Drawing.Point(320, 349);
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
			this.PasteBtn.Size = new System.Drawing.Size(79, 22);
			this.PasteBtn.Text = "Paste Picture";
			this.PasteBtn.Click += new System.EventHandler(this.PasteBtn_Click);
			// 
			// EncyclopediaImageForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(407, 384);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MinimizeBox = false;
			this.Name = "EncyclopediaImageForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encyclopedia Picture";
			this.Panel.ResumeLayout(false);
			this.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Panel Panel;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton BrowseBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.PictureBox PictureBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton PlayerViewBtn;
		private System.Windows.Forms.ToolStripButton PasteBtn;
	}
}