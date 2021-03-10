namespace Masterplan.UI
{
	partial class ThemeForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.AttackLbl = new System.Windows.Forms.Label();
			this.AttackBox = new System.Windows.Forms.ComboBox();
			this.UtilityLbl = new System.Windows.Forms.Label();
			this.UtilityBox = new System.Windows.Forms.ComboBox();
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.BrowserPanel = new System.Windows.Forms.Panel();
			this.ThemeLbl = new System.Windows.Forms.Label();
			this.ThemeNameLbl = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.SelectThemeBtn = new System.Windows.Forms.ToolStripButton();
			this.CreateThemeBtn = new System.Windows.Forms.ToolStripButton();
			this.ClearThemeBtn = new System.Windows.Forms.ToolStripButton();
			this.BrowserPanel.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(202, 379);
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
			this.CancelBtn.Location = new System.Drawing.Point(283, 379);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 11;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// AttackLbl
			// 
			this.AttackLbl.AutoSize = true;
			this.AttackLbl.Location = new System.Drawing.Point(12, 61);
			this.AttackLbl.Name = "AttackLbl";
			this.AttackLbl.Size = new System.Drawing.Size(73, 13);
			this.AttackLbl.TabIndex = 5;
			this.AttackLbl.Text = "Attack power:";
			// 
			// AttackBox
			// 
			this.AttackBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AttackBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AttackBox.FormattingEnabled = true;
			this.AttackBox.Location = new System.Drawing.Point(91, 58);
			this.AttackBox.Name = "AttackBox";
			this.AttackBox.Size = new System.Drawing.Size(267, 21);
			this.AttackBox.TabIndex = 6;
			this.AttackBox.SelectedIndexChanged += new System.EventHandler(this.AttackBox_SelectedIndexChanged);
			// 
			// UtilityLbl
			// 
			this.UtilityLbl.AutoSize = true;
			this.UtilityLbl.Location = new System.Drawing.Point(12, 88);
			this.UtilityLbl.Name = "UtilityLbl";
			this.UtilityLbl.Size = new System.Drawing.Size(67, 13);
			this.UtilityLbl.TabIndex = 7;
			this.UtilityLbl.Text = "Utility power:";
			// 
			// UtilityBox
			// 
			this.UtilityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.UtilityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.UtilityBox.FormattingEnabled = true;
			this.UtilityBox.Location = new System.Drawing.Point(91, 85);
			this.UtilityBox.Name = "UtilityBox";
			this.UtilityBox.Size = new System.Drawing.Size(267, 21);
			this.UtilityBox.TabIndex = 8;
			this.UtilityBox.SelectedIndexChanged += new System.EventHandler(this.UtilityBox_SelectedIndexChanged);
			// 
			// Browser
			// 
			this.Browser.AllowNavigation = false;
			this.Browser.AllowWebBrowserDrop = false;
			this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Browser.IsWebBrowserContextMenuEnabled = false;
			this.Browser.Location = new System.Drawing.Point(0, 0);
			this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.Browser.Name = "Browser";
			this.Browser.ScriptErrorsSuppressed = true;
			this.Browser.Size = new System.Drawing.Size(344, 259);
			this.Browser.TabIndex = 0;
			this.Browser.WebBrowserShortcutsEnabled = false;
			// 
			// BrowserPanel
			// 
			this.BrowserPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.BrowserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BrowserPanel.Controls.Add(this.Browser);
			this.BrowserPanel.Location = new System.Drawing.Point(12, 112);
			this.BrowserPanel.Name = "BrowserPanel";
			this.BrowserPanel.Size = new System.Drawing.Size(346, 261);
			this.BrowserPanel.TabIndex = 9;
			// 
			// ThemeLbl
			// 
			this.ThemeLbl.AutoSize = true;
			this.ThemeLbl.Location = new System.Drawing.Point(12, 32);
			this.ThemeLbl.Name = "ThemeLbl";
			this.ThemeLbl.Size = new System.Drawing.Size(43, 13);
			this.ThemeLbl.TabIndex = 0;
			this.ThemeLbl.Text = "Theme:";
			// 
			// ThemeNameLbl
			// 
			this.ThemeNameLbl.AutoSize = true;
			this.ThemeNameLbl.Location = new System.Drawing.Point(88, 32);
			this.ThemeNameLbl.Name = "ThemeNameLbl";
			this.ThemeNameLbl.Size = new System.Drawing.Size(42, 13);
			this.ThemeNameLbl.TabIndex = 12;
			this.ThemeNameLbl.Text = "[theme]";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectThemeBtn,
            this.CreateThemeBtn,
            this.ClearThemeBtn});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(370, 25);
			this.toolStrip1.TabIndex = 13;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// SelectThemeBtn
			// 
			this.SelectThemeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.SelectThemeBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectThemeBtn.Image")));
			this.SelectThemeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.SelectThemeBtn.Name = "SelectThemeBtn";
			this.SelectThemeBtn.Size = new System.Drawing.Size(82, 22);
			this.SelectThemeBtn.Text = "Select Theme";
			this.SelectThemeBtn.Click += new System.EventHandler(this.SelectThemeBtn_Click);
			// 
			// CreateThemeBtn
			// 
			this.CreateThemeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.CreateThemeBtn.Image = ((System.Drawing.Image)(resources.GetObject("CreateThemeBtn.Image")));
			this.CreateThemeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.CreateThemeBtn.Name = "CreateThemeBtn";
			this.CreateThemeBtn.Size = new System.Drawing.Size(112, 22);
			this.CreateThemeBtn.Text = "Create New Theme";
			this.CreateThemeBtn.Click += new System.EventHandler(this.CreateThemeBtn_Click);
			// 
			// ClearThemeBtn
			// 
			this.ClearThemeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ClearThemeBtn.Image = ((System.Drawing.Image)(resources.GetObject("ClearThemeBtn.Image")));
			this.ClearThemeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ClearThemeBtn.Name = "ClearThemeBtn";
			this.ClearThemeBtn.Size = new System.Drawing.Size(78, 22);
			this.ClearThemeBtn.Text = "Clear Theme";
			this.ClearThemeBtn.Click += new System.EventHandler(this.ClearBtn_Click);
			// 
			// ThemeForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(370, 411);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.ThemeNameLbl);
			this.Controls.Add(this.BrowserPanel);
			this.Controls.Add(this.UtilityBox);
			this.Controls.Add(this.UtilityLbl);
			this.Controls.Add(this.AttackBox);
			this.Controls.Add(this.AttackLbl);
			this.Controls.Add(this.ThemeLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ThemeForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Set Theme";
			this.BrowserPanel.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label AttackLbl;
		private System.Windows.Forms.ComboBox AttackBox;
		private System.Windows.Forms.Label UtilityLbl;
		private System.Windows.Forms.ComboBox UtilityBox;
		private System.Windows.Forms.WebBrowser Browser;
		private System.Windows.Forms.Panel BrowserPanel;
		private System.Windows.Forms.Label ThemeLbl;
		private System.Windows.Forms.Label ThemeNameLbl;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton SelectThemeBtn;
		private System.Windows.Forms.ToolStripButton CreateThemeBtn;
		private System.Windows.Forms.ToolStripButton ClearThemeBtn;
	}
}