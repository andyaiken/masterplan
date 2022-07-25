namespace Masterplan.UI
{
	partial class TrapBuilderForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrapBuilderForm));
			this.BtnPnl = new System.Windows.Forms.Panel();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.OKBtn = new System.Windows.Forms.Button();
			this.StatBlockBrowser = new System.Windows.Forms.WebBrowser();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.FileMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.FileExport = new System.Windows.Forms.ToolStripMenuItem();
			this.OptionsMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.OptionsCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.LevelDownBtn = new System.Windows.Forms.ToolStripButton();
			this.LevelUpBtn = new System.Windows.Forms.ToolStripButton();
			this.LevelLbl = new System.Windows.Forms.ToolStripLabel();
			this.BtnPnl.SuspendLayout();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// BtnPnl
			// 
			this.BtnPnl.Controls.Add(this.CancelBtn);
			this.BtnPnl.Controls.Add(this.OKBtn);
			this.BtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.BtnPnl.Location = new System.Drawing.Point(0, 443);
			this.BtnPnl.Name = "BtnPnl";
			this.BtnPnl.Size = new System.Drawing.Size(664, 35);
			this.BtnPnl.TabIndex = 2;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(577, 6);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 1;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(496, 6);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 0;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// StatBlockBrowser
			// 
			this.StatBlockBrowser.AllowWebBrowserDrop = false;
			this.StatBlockBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StatBlockBrowser.IsWebBrowserContextMenuEnabled = false;
			this.StatBlockBrowser.Location = new System.Drawing.Point(0, 25);
			this.StatBlockBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.StatBlockBrowser.Name = "StatBlockBrowser";
			this.StatBlockBrowser.ScriptErrorsSuppressed = true;
			this.StatBlockBrowser.Size = new System.Drawing.Size(664, 418);
			this.StatBlockBrowser.TabIndex = 2;
			this.StatBlockBrowser.WebBrowserShortcutsEnabled = false;
			this.StatBlockBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.Browser_Navigating);
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OptionsMenu,
            this.LevelDownBtn,
            this.LevelUpBtn,
            this.LevelLbl});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(664, 25);
			this.Toolbar.TabIndex = 3;
			this.Toolbar.Text = "Toolbar";
			// 
			// FileMenu
			// 
			this.FileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExport});
			this.FileMenu.Image = ((System.Drawing.Image)(resources.GetObject("FileMenu.Image")));
			this.FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FileMenu.Name = "FileMenu";
			this.FileMenu.Size = new System.Drawing.Size(38, 22);
			this.FileMenu.Text = Session.I18N.File;
			// 
			// FileExport
			// 
			this.FileExport.Name = "FileExport";
			this.FileExport.Size = new System.Drawing.Size(152, 22);
			this.FileExport.Text = "Export...";
			this.FileExport.Click += new System.EventHandler(this.FileExport_Click);
			// 
			// OptionsMenu
			// 
			this.OptionsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsCopy});
			this.OptionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("OptionsMenu.Image")));
			this.OptionsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.OptionsMenu.Name = "OptionsMenu";
			this.OptionsMenu.Size = new System.Drawing.Size(62, 22);
			this.OptionsMenu.Text = "Options";
			// 
			// OptionsCopy
			// 
			this.OptionsCopy.Name = "OptionsCopy";
			this.OptionsCopy.Size = new System.Drawing.Size(197, 22);
			this.OptionsCopy.Text = "Copy an Existing Trap...";
			this.OptionsCopy.Click += new System.EventHandler(this.OptionsCopy_Click);
			// 
			// LevelDownBtn
			// 
			this.LevelDownBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.LevelDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LevelDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("LevelDownBtn.Image")));
			this.LevelDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LevelDownBtn.Name = "LevelDownBtn";
			this.LevelDownBtn.Size = new System.Drawing.Size(23, 22);
			this.LevelDownBtn.Text = "-";
			this.LevelDownBtn.ToolTipText = "Level Down";
			this.LevelDownBtn.Click += new System.EventHandler(this.LevelDownBtn_Click);
			// 
			// LevelUpBtn
			// 
			this.LevelUpBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.LevelUpBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LevelUpBtn.Image = ((System.Drawing.Image)(resources.GetObject("LevelUpBtn.Image")));
			this.LevelUpBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LevelUpBtn.Name = "LevelUpBtn";
			this.LevelUpBtn.Size = new System.Drawing.Size(23, 22);
			this.LevelUpBtn.Text = "+";
			this.LevelUpBtn.ToolTipText = "Level Up";
			this.LevelUpBtn.Click += new System.EventHandler(this.LevelUpBtn_Click);
			// 
			// LevelLbl
			// 
			this.LevelLbl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.LevelLbl.Name = "LevelLbl";
			this.LevelLbl.Size = new System.Drawing.Size(37, 22);
			this.LevelLbl.Text = "Level:";
			// 
			// TrapBuilderForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(664, 478);
			this.Controls.Add(this.StatBlockBrowser);
			this.Controls.Add(this.Toolbar);
			this.Controls.Add(this.BtnPnl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrapBuilderForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Trap / Hazard Builder";
			this.BtnPnl.ResumeLayout(false);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel BtnPnl;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.WebBrowser StatBlockBrowser;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripDropDownButton OptionsMenu;
		private System.Windows.Forms.ToolStripMenuItem OptionsCopy;
		private System.Windows.Forms.ToolStripButton LevelDownBtn;
		private System.Windows.Forms.ToolStripButton LevelUpBtn;
		private System.Windows.Forms.ToolStripLabel LevelLbl;
		private System.Windows.Forms.ToolStripDropDownButton FileMenu;
		private System.Windows.Forms.ToolStripMenuItem FileExport;
	}
}