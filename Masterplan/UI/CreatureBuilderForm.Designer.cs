namespace Masterplan.UI
{
	partial class CreatureBuilderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatureBuilderForm));
            this.Toolbar = new System.Windows.Forms.ToolStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.FileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.OptionsImport = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsVariant = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsPowerBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.LevelDownBtn = new System.Windows.Forms.ToolStripButton();
            this.LevelUpBtn = new System.Windows.Forms.ToolStripButton();
            this.LevelLbl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.AdviceBtn = new System.Windows.Forms.ToolStripButton();
            this.PowersBtn = new System.Windows.Forms.ToolStripButton();
            this.PreviewBtn = new System.Windows.Forms.ToolStripButton();
            this.BtnPnl = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.Pages = new System.Windows.Forms.TabControl();
            this.StatBlockPage = new System.Windows.Forms.TabPage();
            this.StatBlockBrowser = new System.Windows.Forms.WebBrowser();
            this.PicturePage = new System.Windows.Forms.TabPage();
            this.PictureToolbar = new System.Windows.Forms.ToolStrip();
            this.PictureBrowseBtn = new System.Windows.Forms.ToolStripButton();
            this.PicturePasteBtn = new System.Windows.Forms.ToolStripButton();
            this.PictureClearBtn = new System.Windows.Forms.ToolStripButton();
            this.PortraitBox = new System.Windows.Forms.PictureBox();
            this.EntryPage = new System.Windows.Forms.TabPage();
            this.EntryBrowser = new System.Windows.Forms.WebBrowser();
            this.Toolbar.SuspendLayout();
            this.BtnPnl.SuspendLayout();
            this.Pages.SuspendLayout();
            this.StatBlockPage.SuspendLayout();
            this.PicturePage.SuspendLayout();
            this.PictureToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortraitBox)).BeginInit();
            this.EntryPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // Toolbar
            // 
            this.Toolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OptionsMenu,
            this.LevelDownBtn,
            this.LevelUpBtn,
            this.LevelLbl,
            this.toolStripSeparator3,
            this.AdviceBtn,
            this.PowersBtn,
            this.PreviewBtn});
            this.Toolbar.Location = new System.Drawing.Point(0, 0);
            this.Toolbar.Name = "Toolbar";
            this.Toolbar.Size = new System.Drawing.Size(912, 27);
            this.Toolbar.TabIndex = 0;
            this.Toolbar.Text = "toolStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileExport});
            this.FileMenu.Image = ((System.Drawing.Image)(resources.GetObject("FileMenu.Image")));
            this.FileMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(46, 24);
            this.FileMenu.Text = "File";
            // 
            // FileExport
            // 
            this.FileExport.Name = "FileExport";
            this.FileExport.Size = new System.Drawing.Size(144, 26);
            this.FileExport.Text = "Export...";
            this.FileExport.Click += new System.EventHandler(this.FileExport_Click);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsImport,
            this.OptionsVariant,
            this.OptionsRandom,
            this.toolStripSeparator1,
            this.OptionsEntry,
            this.toolStripSeparator2,
            this.OptionsPowerBrowser});
            this.OptionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("OptionsMenu.Image")));
            this.OptionsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(75, 24);
            this.OptionsMenu.Text = "Options";
            // 
            // OptionsImport
            // 
            this.OptionsImport.Name = "OptionsImport";
            this.OptionsImport.Size = new System.Drawing.Size(304, 26);
            this.OptionsImport.Text = "Import from Adventure Tools...";
            this.OptionsImport.Click += new System.EventHandler(this.OptionsImport_Click);
            // 
            // OptionsVariant
            // 
            this.OptionsVariant.Name = "OptionsVariant";
            this.OptionsVariant.Size = new System.Drawing.Size(304, 26);
            this.OptionsVariant.Text = "Copy an Existing Creature...";
            this.OptionsVariant.Click += new System.EventHandler(this.OptionsVariant_Click);
            // 
            // OptionsRandom
            // 
            this.OptionsRandom.Name = "OptionsRandom";
            this.OptionsRandom.Size = new System.Drawing.Size(304, 26);
            this.OptionsRandom.Text = "Generate a Random Creature...";
            this.OptionsRandom.Click += new System.EventHandler(this.OptionsRandom_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(301, 6);
            // 
            // OptionsEntry
            // 
            this.OptionsEntry.Name = "OptionsEntry";
            this.OptionsEntry.Size = new System.Drawing.Size(304, 26);
            this.OptionsEntry.Text = "Create / Edit Encyclopedia Entry";
            this.OptionsEntry.Click += new System.EventHandler(this.OptionsEntry_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(301, 6);
            // 
            // OptionsPowerBrowser
            // 
            this.OptionsPowerBrowser.Name = "OptionsPowerBrowser";
            this.OptionsPowerBrowser.Size = new System.Drawing.Size(304, 26);
            this.OptionsPowerBrowser.Text = "Power Browser";
            this.OptionsPowerBrowser.Click += new System.EventHandler(this.OptionsPowerBrowser_Click);
            // 
            // LevelDownBtn
            // 
            this.LevelDownBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LevelDownBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LevelDownBtn.Image = ((System.Drawing.Image)(resources.GetObject("LevelDownBtn.Image")));
            this.LevelDownBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LevelDownBtn.Name = "LevelDownBtn";
            this.LevelDownBtn.Size = new System.Drawing.Size(29, 24);
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
            this.LevelUpBtn.Size = new System.Drawing.Size(29, 24);
            this.LevelUpBtn.Text = "+";
            this.LevelUpBtn.ToolTipText = "Level Up";
            this.LevelUpBtn.Click += new System.EventHandler(this.LevelUpBtn_Click);
            // 
            // LevelLbl
            // 
            this.LevelLbl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LevelLbl.Name = "LevelLbl";
            this.LevelLbl.Size = new System.Drawing.Size(46, 24);
            this.LevelLbl.Text = "Level:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // AdviceBtn
            // 
            this.AdviceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AdviceBtn.Image = ((System.Drawing.Image)(resources.GetObject("AdviceBtn.Image")));
            this.AdviceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AdviceBtn.Name = "AdviceBtn";
            this.AdviceBtn.Size = new System.Drawing.Size(58, 24);
            this.AdviceBtn.Text = "Advice";
            this.AdviceBtn.Click += new System.EventHandler(this.AdviceBtn_Click);
            // 
            // PowersBtn
            // 
            this.PowersBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PowersBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowersBtn.Image")));
            this.PowersBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PowersBtn.Name = "PowersBtn";
            this.PowersBtn.Size = new System.Drawing.Size(59, 24);
            this.PowersBtn.Text = "Powers";
            this.PowersBtn.Click += new System.EventHandler(this.PowersBtn_Click);
            // 
            // PreviewBtn
            // 
            this.PreviewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PreviewBtn.Image = ((System.Drawing.Image)(resources.GetObject("PreviewBtn.Image")));
            this.PreviewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviewBtn.Name = "PreviewBtn";
            this.PreviewBtn.Size = new System.Drawing.Size(64, 24);
            this.PreviewBtn.Text = "Preview";
            this.PreviewBtn.Click += new System.EventHandler(this.PreviewBtn_Click);
            // 
            // BtnPnl
            // 
            this.BtnPnl.Controls.Add(this.CancelBtn);
            this.BtnPnl.Controls.Add(this.OKBtn);
            this.BtnPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnPnl.Location = new System.Drawing.Point(0, 545);
            this.BtnPnl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnPnl.Name = "BtnPnl";
            this.BtnPnl.Size = new System.Drawing.Size(912, 43);
            this.BtnPnl.TabIndex = 2;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(796, 7);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 28);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(688, 7);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(100, 28);
            this.OKBtn.TabIndex = 0;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // Pages
            // 
            this.Pages.Controls.Add(this.StatBlockPage);
            this.Pages.Controls.Add(this.PicturePage);
            this.Pages.Controls.Add(this.EntryPage);
            this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pages.Location = new System.Drawing.Point(0, 27);
            this.Pages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pages.Name = "Pages";
            this.Pages.SelectedIndex = 0;
            this.Pages.Size = new System.Drawing.Size(912, 518);
            this.Pages.TabIndex = 3;
            // 
            // StatBlockPage
            // 
            this.StatBlockPage.Controls.Add(this.StatBlockBrowser);
            this.StatBlockPage.Location = new System.Drawing.Point(4, 25);
            this.StatBlockPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatBlockPage.Name = "StatBlockPage";
            this.StatBlockPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatBlockPage.Size = new System.Drawing.Size(904, 489);
            this.StatBlockPage.TabIndex = 0;
            this.StatBlockPage.Text = "Stat Block";
            this.StatBlockPage.UseVisualStyleBackColor = true;
            // 
            // StatBlockBrowser
            // 
            this.StatBlockBrowser.AllowWebBrowserDrop = false;
            this.StatBlockBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatBlockBrowser.IsWebBrowserContextMenuEnabled = false;
            this.StatBlockBrowser.Location = new System.Drawing.Point(4, 4);
            this.StatBlockBrowser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatBlockBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.StatBlockBrowser.Name = "StatBlockBrowser";
            this.StatBlockBrowser.ScriptErrorsSuppressed = true;
            this.StatBlockBrowser.Size = new System.Drawing.Size(896, 481);
            this.StatBlockBrowser.TabIndex = 2;
            this.StatBlockBrowser.WebBrowserShortcutsEnabled = false;
            this.StatBlockBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.Browser_Navigating);
            // 
            // PicturePage
            // 
            this.PicturePage.Controls.Add(this.PictureToolbar);
            this.PicturePage.Controls.Add(this.PortraitBox);
            this.PicturePage.Location = new System.Drawing.Point(4, 25);
            this.PicturePage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PicturePage.Name = "PicturePage";
            this.PicturePage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PicturePage.Size = new System.Drawing.Size(904, 485);
            this.PicturePage.TabIndex = 1;
            this.PicturePage.Text = "Picture";
            this.PicturePage.UseVisualStyleBackColor = true;
            // 
            // PictureToolbar
            // 
            this.PictureToolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PictureToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PictureBrowseBtn,
            this.PicturePasteBtn,
            this.PictureClearBtn});
            this.PictureToolbar.Location = new System.Drawing.Point(4, 4);
            this.PictureToolbar.Name = "PictureToolbar";
            this.PictureToolbar.Size = new System.Drawing.Size(896, 27);
            this.PictureToolbar.TabIndex = 6;
            this.PictureToolbar.Text = "toolStrip1";
            // 
            // PictureBrowseBtn
            // 
            this.PictureBrowseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PictureBrowseBtn.Image = ((System.Drawing.Image)(resources.GetObject("PictureBrowseBtn.Image")));
            this.PictureBrowseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PictureBrowseBtn.Name = "PictureBrowseBtn";
            this.PictureBrowseBtn.Size = new System.Drawing.Size(61, 24);
            this.PictureBrowseBtn.Text = "Browse";
            this.PictureBrowseBtn.Click += new System.EventHandler(this.PictureBrowseBtn_Click);
            // 
            // PicturePasteBtn
            // 
            this.PicturePasteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PicturePasteBtn.Image = ((System.Drawing.Image)(resources.GetObject("PicturePasteBtn.Image")));
            this.PicturePasteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PicturePasteBtn.Name = "PicturePasteBtn";
            this.PicturePasteBtn.Size = new System.Drawing.Size(47, 24);
            this.PicturePasteBtn.Text = "Paste";
            this.PicturePasteBtn.Click += new System.EventHandler(this.PicturePasteBtn_Click);
            // 
            // PictureClearBtn
            // 
            this.PictureClearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.PictureClearBtn.Image = ((System.Drawing.Image)(resources.GetObject("PictureClearBtn.Image")));
            this.PictureClearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PictureClearBtn.Name = "PictureClearBtn";
            this.PictureClearBtn.Size = new System.Drawing.Size(47, 24);
            this.PictureClearBtn.Text = "Clear";
            this.PictureClearBtn.Click += new System.EventHandler(this.PictureClearBtn_Click);
            // 
            // PortraitBox
            // 
            this.PortraitBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PortraitBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PortraitBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortraitBox.Location = new System.Drawing.Point(4, 4);
            this.PortraitBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PortraitBox.Name = "PortraitBox";
            this.PortraitBox.Size = new System.Drawing.Size(896, 477);
            this.PortraitBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PortraitBox.TabIndex = 4;
            this.PortraitBox.TabStop = false;
            this.PortraitBox.DoubleClick += new System.EventHandler(this.PictureBrowseBtn_Click);
            // 
            // EntryPage
            // 
            this.EntryPage.Controls.Add(this.EntryBrowser);
            this.EntryPage.Location = new System.Drawing.Point(4, 25);
            this.EntryPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EntryPage.Name = "EntryPage";
            this.EntryPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EntryPage.Size = new System.Drawing.Size(904, 485);
            this.EntryPage.TabIndex = 2;
            this.EntryPage.Text = "Encyclopedia Entry";
            this.EntryPage.UseVisualStyleBackColor = true;
            // 
            // EntryBrowser
            // 
            this.EntryBrowser.AllowWebBrowserDrop = false;
            this.EntryBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntryBrowser.IsWebBrowserContextMenuEnabled = false;
            this.EntryBrowser.Location = new System.Drawing.Point(4, 4);
            this.EntryBrowser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EntryBrowser.MinimumSize = new System.Drawing.Size(27, 25);
            this.EntryBrowser.Name = "EntryBrowser";
            this.EntryBrowser.ScriptErrorsSuppressed = true;
            this.EntryBrowser.Size = new System.Drawing.Size(896, 477);
            this.EntryBrowser.TabIndex = 0;
            this.EntryBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // CreatureBuilderForm
            // 
            this.AcceptButton = this.OKBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(912, 588);
            this.Controls.Add(this.Pages);
            this.Controls.Add(this.BtnPnl);
            this.Controls.Add(this.Toolbar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "CreatureBuilderForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creature Builder";
            this.Toolbar.ResumeLayout(false);
            this.Toolbar.PerformLayout();
            this.BtnPnl.ResumeLayout(false);
            this.Pages.ResumeLayout(false);
            this.StatBlockPage.ResumeLayout(false);
            this.PicturePage.ResumeLayout(false);
            this.PicturePage.PerformLayout();
            this.PictureToolbar.ResumeLayout(false);
            this.PictureToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortraitBox)).EndInit();
            this.EntryPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.Panel BtnPnl;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage StatBlockPage;
		private System.Windows.Forms.WebBrowser StatBlockBrowser;
		private System.Windows.Forms.TabPage PicturePage;
		private System.Windows.Forms.ToolStripDropDownButton OptionsMenu;
		private System.Windows.Forms.ToolStripMenuItem OptionsImport;
		private System.Windows.Forms.ToolStripMenuItem OptionsVariant;
		private System.Windows.Forms.PictureBox PortraitBox;
		private System.Windows.Forms.ToolStrip PictureToolbar;
		private System.Windows.Forms.ToolStripButton PictureBrowseBtn;
		private System.Windows.Forms.ToolStripButton PicturePasteBtn;
		private System.Windows.Forms.ToolStripButton PictureClearBtn;
		private System.Windows.Forms.TabPage EntryPage;
		private System.Windows.Forms.WebBrowser EntryBrowser;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem OptionsEntry;
		private System.Windows.Forms.ToolStripButton LevelDownBtn;
		private System.Windows.Forms.ToolStripButton LevelUpBtn;
		private System.Windows.Forms.ToolStripLabel LevelLbl;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem OptionsPowerBrowser;
		private System.Windows.Forms.ToolStripMenuItem OptionsRandom;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton AdviceBtn;
		private System.Windows.Forms.ToolStripButton PowersBtn;
		private System.Windows.Forms.ToolStripDropDownButton FileMenu;
		private System.Windows.Forms.ToolStripMenuItem FileExport;
		private System.Windows.Forms.ToolStripButton PreviewBtn;
	}
}