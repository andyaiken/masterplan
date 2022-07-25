namespace Masterplan.UI
{
	partial class CustomOverlayForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomOverlayForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.TilePanel = new Masterplan.Controls.TokenPanel();
			this.OptionsPage = new System.Windows.Forms.TabPage();
			this.StyleBox = new System.Windows.Forms.ComboBox();
			this.StyleLbl = new System.Windows.Forms.Label();
			this.OpaqueBox = new System.Windows.Forms.CheckBox();
			this.DifficultBox = new System.Windows.Forms.CheckBox();
			this.TerrainPowerPage = new System.Windows.Forms.TabPage();
			this.PowerBrowser = new System.Windows.Forms.WebBrowser();
			this.TerrainPowerToolbar = new System.Windows.Forms.ToolStrip();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.SelectBtn = new System.Windows.Forms.ToolStripButton();
			this.WidthBox = new System.Windows.Forms.NumericUpDown();
			this.HeightBox = new System.Windows.Forms.NumericUpDown();
			this.WidthLbl = new System.Windows.Forms.Label();
			this.HeightLbl = new System.Windows.Forms.Label();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.OptionsPage.SuspendLayout();
			this.TerrainPowerPage.SuspendLayout();
			this.TerrainPowerToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).BeginInit();
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
			this.NameBox.Location = new System.Drawing.Point(59, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(303, 20);
			this.NameBox.TabIndex = 1;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(206, 311);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 10;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(287, 311);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.tabPage1);
			this.Pages.Controls.Add(this.OptionsPage);
			this.Pages.Controls.Add(this.TerrainPowerPage);
			this.Pages.Location = new System.Drawing.Point(15, 90);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(350, 215);
			this.Pages.TabIndex = 9;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(342, 189);
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
			this.DetailsBox.Size = new System.Drawing.Size(336, 183);
			this.DetailsBox.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.TilePanel);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(317, 189);
			this.tabPage1.TabIndex = 1;
			this.tabPage1.Text = "Picture";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// TilePanel
			// 
			this.TilePanel.Colour = System.Drawing.Color.Blue;
			this.TilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TilePanel.Image = null;
			this.TilePanel.Location = new System.Drawing.Point(3, 3);
			this.TilePanel.Name = "TilePanel";
			this.TilePanel.Size = new System.Drawing.Size(311, 183);
			this.TilePanel.TabIndex = 0;
			this.TilePanel.TileSize = new System.Drawing.Size(2, 2);
			// 
			// OptionsPage
			// 
			this.OptionsPage.Controls.Add(this.StyleBox);
			this.OptionsPage.Controls.Add(this.StyleLbl);
			this.OptionsPage.Controls.Add(this.OpaqueBox);
			this.OptionsPage.Controls.Add(this.DifficultBox);
			this.OptionsPage.Location = new System.Drawing.Point(4, 22);
			this.OptionsPage.Name = "OptionsPage";
			this.OptionsPage.Padding = new System.Windows.Forms.Padding(3);
			this.OptionsPage.Size = new System.Drawing.Size(317, 189);
			this.OptionsPage.TabIndex = 2;
			this.OptionsPage.Text = "Display Options";
			this.OptionsPage.UseVisualStyleBackColor = true;
			// 
			// StyleBox
			// 
			this.StyleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.StyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.StyleBox.FormattingEnabled = true;
			this.StyleBox.Location = new System.Drawing.Point(45, 6);
			this.StyleBox.Name = "StyleBox";
			this.StyleBox.Size = new System.Drawing.Size(266, 21);
			this.StyleBox.TabIndex = 1;
			// 
			// StyleLbl
			// 
			this.StyleLbl.AutoSize = true;
			this.StyleLbl.Location = new System.Drawing.Point(6, 9);
			this.StyleLbl.Name = "StyleLbl";
			this.StyleLbl.Size = new System.Drawing.Size(33, 13);
			this.StyleLbl.TabIndex = 0;
			this.StyleLbl.Text = "Style:";
			// 
			// OpaqueBox
			// 
			this.OpaqueBox.AutoSize = true;
			this.OpaqueBox.Location = new System.Drawing.Point(9, 71);
			this.OpaqueBox.Name = "OpaqueBox";
			this.OpaqueBox.Size = new System.Drawing.Size(173, 17);
			this.OpaqueBox.TabIndex = 3;
			this.OpaqueBox.Text = "This overlay blocks line of sight";
			this.OpaqueBox.UseVisualStyleBackColor = true;
			// 
			// DifficultBox
			// 
			this.DifficultBox.AutoSize = true;
			this.DifficultBox.Location = new System.Drawing.Point(9, 48);
			this.DifficultBox.Name = "DifficultBox";
			this.DifficultBox.Size = new System.Drawing.Size(153, 17);
			this.DifficultBox.TabIndex = 2;
			this.DifficultBox.Text = "Add difficult terrain markers";
			this.DifficultBox.UseVisualStyleBackColor = true;
			// 
			// TerrainPowerPage
			// 
			this.TerrainPowerPage.Controls.Add(this.PowerBrowser);
			this.TerrainPowerPage.Controls.Add(this.TerrainPowerToolbar);
			this.TerrainPowerPage.Location = new System.Drawing.Point(4, 22);
			this.TerrainPowerPage.Name = "TerrainPowerPage";
			this.TerrainPowerPage.Padding = new System.Windows.Forms.Padding(3);
			this.TerrainPowerPage.Size = new System.Drawing.Size(317, 189);
			this.TerrainPowerPage.TabIndex = 3;
			this.TerrainPowerPage.Text = "Terrain Power";
			this.TerrainPowerPage.UseVisualStyleBackColor = true;
			// 
			// PowerBrowser
			// 
			this.PowerBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PowerBrowser.Location = new System.Drawing.Point(3, 28);
			this.PowerBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.PowerBrowser.Name = "PowerBrowser";
			this.PowerBrowser.Size = new System.Drawing.Size(311, 158);
			this.PowerBrowser.TabIndex = 2;
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
			this.TerrainPowerToolbar.TabIndex = 1;
			this.TerrainPowerToolbar.Text = Session.I18N.toolStrip1;
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = Session.I18N.Edit;
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = Session.I18N.Remove;
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
			// WidthBox
			// 
			this.WidthBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WidthBox.Location = new System.Drawing.Point(59, 38);
			this.WidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WidthBox.Name = "WidthBox";
			this.WidthBox.Size = new System.Drawing.Size(303, 20);
			this.WidthBox.TabIndex = 3;
			this.WidthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.WidthBox.ValueChanged += new System.EventHandler(this.WidthBox_ValueChanged);
			// 
			// HeightBox
			// 
			this.HeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HeightBox.Location = new System.Drawing.Point(59, 64);
			this.HeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.HeightBox.Name = "HeightBox";
			this.HeightBox.Size = new System.Drawing.Size(303, 20);
			this.HeightBox.TabIndex = 5;
			this.HeightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.HeightBox.ValueChanged += new System.EventHandler(this.HeightBox_ValueChanged);
			// 
			// WidthLbl
			// 
			this.WidthLbl.AutoSize = true;
			this.WidthLbl.Location = new System.Drawing.Point(12, 40);
			this.WidthLbl.Name = "WidthLbl";
			this.WidthLbl.Size = new System.Drawing.Size(38, 13);
			this.WidthLbl.TabIndex = 2;
			this.WidthLbl.Text = "Width:";
			// 
			// HeightLbl
			// 
			this.HeightLbl.AutoSize = true;
			this.HeightLbl.Location = new System.Drawing.Point(12, 66);
			this.HeightLbl.Name = "HeightLbl";
			this.HeightLbl.Size = new System.Drawing.Size(41, 13);
			this.HeightLbl.TabIndex = 4;
			this.HeightLbl.Text = "Height:";
			// 
			// CustomOverlayForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(374, 346);
			this.Controls.Add(this.HeightLbl);
			this.Controls.Add(this.WidthLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.HeightBox);
			this.Controls.Add(this.WidthBox);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomOverlayForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Custom Overlay";
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.OptionsPage.ResumeLayout(false);
			this.OptionsPage.PerformLayout();
			this.TerrainPowerPage.ResumeLayout(false);
			this.TerrainPowerPage.PerformLayout();
			this.TerrainPowerToolbar.ResumeLayout(false);
			this.TerrainPowerToolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.WidthBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HeightBox)).EndInit();
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
        private System.Windows.Forms.NumericUpDown WidthBox;
        private System.Windows.Forms.NumericUpDown HeightBox;
        private System.Windows.Forms.Label WidthLbl;
		private System.Windows.Forms.Label HeightLbl;
		private System.Windows.Forms.TabPage tabPage1;
		private Masterplan.Controls.TokenPanel TilePanel;
		private System.Windows.Forms.TabPage OptionsPage;
		private System.Windows.Forms.ComboBox StyleBox;
		private System.Windows.Forms.Label StyleLbl;
		private System.Windows.Forms.CheckBox OpaqueBox;
		private System.Windows.Forms.CheckBox DifficultBox;
		private System.Windows.Forms.TabPage TerrainPowerPage;
		private System.Windows.Forms.ToolStrip TerrainPowerToolbar;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton SelectBtn;
		private System.Windows.Forms.WebBrowser PowerBrowser;
	}
}