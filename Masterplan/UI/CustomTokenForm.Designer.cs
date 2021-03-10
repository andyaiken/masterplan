namespace Masterplan.UI
{
	partial class CustomTokenForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomTokenForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.PicturePage = new System.Windows.Forms.TabPage();
			this.TilePanel = new Masterplan.Controls.TokenPanel();
			this.TerrainPowerPage = new System.Windows.Forms.TabPage();
			this.PowerBrowser = new System.Windows.Forms.WebBrowser();
			this.TerrainPowerToolbar = new System.Windows.Forms.ToolStrip();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SelectBtn = new System.Windows.Forms.ToolStripButton();
			this.SizeBox = new System.Windows.Forms.ComboBox();
			this.SizeLbl = new System.Windows.Forms.Label();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.PicturePage.SuspendLayout();
			this.TerrainPowerPage.SuspendLayout();
			this.TerrainPowerToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(58, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(304, 20);
			this.NameBox.TabIndex = 1;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(206, 283);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 8;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(287, 283);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 9;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.PicturePage);
			this.Pages.Controls.Add(this.TerrainPowerPage);
			this.Pages.Location = new System.Drawing.Point(15, 65);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(350, 212);
			this.Pages.TabIndex = 7;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(342, 186);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(3, 3);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(336, 180);
			this.DetailsBox.TabIndex = 0;
			// 
			// PicturePage
			// 
			this.PicturePage.Controls.Add(this.TilePanel);
			this.PicturePage.Location = new System.Drawing.Point(4, 22);
			this.PicturePage.Name = "PicturePage";
			this.PicturePage.Padding = new System.Windows.Forms.Padding(3);
			this.PicturePage.Size = new System.Drawing.Size(317, 186);
			this.PicturePage.TabIndex = 1;
			this.PicturePage.Text = "Picture";
			this.PicturePage.UseVisualStyleBackColor = true;
			// 
			// TilePanel
			// 
			this.TilePanel.Colour = System.Drawing.Color.Transparent;
			this.TilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TilePanel.Image = null;
			this.TilePanel.Location = new System.Drawing.Point(3, 3);
			this.TilePanel.Name = "TilePanel";
			this.TilePanel.Size = new System.Drawing.Size(311, 180);
			this.TilePanel.TabIndex = 0;
			this.TilePanel.TileSize = new System.Drawing.Size(2, 2);
			// 
			// TerrainPowerPage
			// 
			this.TerrainPowerPage.Controls.Add(this.PowerBrowser);
			this.TerrainPowerPage.Controls.Add(this.TerrainPowerToolbar);
			this.TerrainPowerPage.Location = new System.Drawing.Point(4, 22);
			this.TerrainPowerPage.Name = "TerrainPowerPage";
			this.TerrainPowerPage.Padding = new System.Windows.Forms.Padding(3);
			this.TerrainPowerPage.Size = new System.Drawing.Size(317, 186);
			this.TerrainPowerPage.TabIndex = 2;
			this.TerrainPowerPage.Text = "Terrain Power";
			this.TerrainPowerPage.UseVisualStyleBackColor = true;
			// 
			// PowerBrowser
			// 
			this.PowerBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PowerBrowser.Location = new System.Drawing.Point(3, 28);
			this.PowerBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.PowerBrowser.Name = "PowerBrowser";
			this.PowerBrowser.Size = new System.Drawing.Size(311, 155);
			this.PowerBrowser.TabIndex = 1;
			// 
			// TerrainPowerToolbar
			// 
			this.TerrainPowerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditBtn,
            this.RemoveBtn,
            this.toolStripSeparator1,
            this.SelectBtn});
			this.TerrainPowerToolbar.Location = new System.Drawing.Point(3, 3);
			this.TerrainPowerToolbar.Name = "TerrainPowerToolbar";
			this.TerrainPowerToolbar.Size = new System.Drawing.Size(311, 25);
			this.TerrainPowerToolbar.TabIndex = 0;
			this.TerrainPowerToolbar.Text = "toolStrip1";
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = "Edit";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
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
			// SelectBtn
			// 
			this.SelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectBtn.Image")));
			this.SelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SelectBtn.Name = "SelectBtn";
			this.SelectBtn.Size = new System.Drawing.Size(116, 22);
			this.SelectBtn.Text = "Use Standard Power";
			this.SelectBtn.Click += new System.EventHandler(this.SelectBtn_Click);
			// 
			// SizeBox
			// 
			this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SizeBox.FormattingEnabled = true;
			this.SizeBox.Location = new System.Drawing.Point(58, 38);
			this.SizeBox.Name = "SizeBox";
			this.SizeBox.Size = new System.Drawing.Size(304, 21);
			this.SizeBox.TabIndex = 3;
			this.SizeBox.SelectedIndexChanged += new System.EventHandler(this.SizeBox_SelectedIndexChanged);
			// 
			// SizeLbl
			// 
			this.SizeLbl.AutoSize = true;
			this.SizeLbl.Location = new System.Drawing.Point(12, 41);
			this.SizeLbl.Name = "SizeLbl";
			this.SizeLbl.Size = new System.Drawing.Size(30, 13);
			this.SizeLbl.TabIndex = 2;
			this.SizeLbl.Text = "Size:";
			// 
			// CustomTokenForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(374, 318);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.SizeBox);
			this.Controls.Add(this.SizeLbl);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomTokenForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Custom Map Token";
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.PicturePage.ResumeLayout(false);
			this.TerrainPowerPage.ResumeLayout(false);
			this.TerrainPowerPage.PerformLayout();
			this.TerrainPowerToolbar.ResumeLayout(false);
			this.TerrainPowerToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
        private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.ComboBox SizeBox;
		private System.Windows.Forms.Label SizeLbl;
		private System.Windows.Forms.TabPage PicturePage;
		private Masterplan.Controls.TokenPanel TilePanel;
		private System.Windows.Forms.TabPage TerrainPowerPage;
		private System.Windows.Forms.WebBrowser PowerBrowser;
		private System.Windows.Forms.ToolStrip TerrainPowerToolbar;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton SelectBtn;
	}
}