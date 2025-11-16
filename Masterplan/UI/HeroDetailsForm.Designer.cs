namespace Masterplan.UI
{
	partial class HeroDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeroDetailsForm));
            Browser = new System.Windows.Forms.WebBrowser();
            Toolbar = new System.Windows.Forms.ToolStrip();
            ExportMenu = new System.Windows.Forms.ToolStripDropDownButton();
            ExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            ExportHero = new System.Windows.Forms.ToolStripMenuItem();
            PlayerViewBtn = new System.Windows.Forms.ToolStripButton();
            Toolbar.SuspendLayout();
            SuspendLayout();
            // 
            // Browser
            // 
            Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            Browser.Location = new System.Drawing.Point(0, 27);
            Browser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Browser.MinimumSize = new System.Drawing.Size(27, 31);
            Browser.Name = "Browser";
            Browser.Size = new System.Drawing.Size(496, 531);
            Browser.TabIndex = 1;
            // 
            // Toolbar
            // 
            Toolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ExportMenu, PlayerViewBtn });
            Toolbar.Location = new System.Drawing.Point(0, 0);
            Toolbar.Name = "Toolbar";
            Toolbar.Size = new System.Drawing.Size(496, 27);
            Toolbar.TabIndex = 4;
            Toolbar.Text = "toolStrip1";
            // 
            // ExportMenu
            // 
            ExportMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ExportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ExportHTML, ExportHero });
            ExportMenu.Image = (System.Drawing.Image)resources.GetObject("ExportMenu.Image");
            ExportMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            ExportMenu.Name = "ExportMenu";
            ExportMenu.Size = new System.Drawing.Size(66, 24);
            ExportMenu.Text = "Export";
            // 
            // ExportHTML
            // 
            ExportHTML.Name = "ExportHTML";
            ExportHTML.Size = new System.Drawing.Size(224, 26);
            ExportHTML.Text = "Export to HTML";
            ExportHTML.Click += ExportHTML_Click;
            // 
            // ExportHero
            // 
            ExportHero.Name = "ExportHero";
            ExportHero.Size = new System.Drawing.Size(224, 26);
            ExportHero.Text = "(Beta) Export Hero";
            ExportHero.ToolTipText = "Export PC to an Importable format";
            ExportHero.Click += ExportHero_Click;
            // 
            // PlayerViewBtn
            // 
            PlayerViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            PlayerViewBtn.Image = (System.Drawing.Image)resources.GetObject("PlayerViewBtn.Image");
            PlayerViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            PlayerViewBtn.Name = "PlayerViewBtn";
            PlayerViewBtn.Size = new System.Drawing.Size(144, 24);
            PlayerViewBtn.Text = "Send to Player View";
            PlayerViewBtn.Click += PlayerViewBtn_Click;
            // 
            // HeroDetailsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(496, 558);
            Controls.Add(Browser);
            Controls.Add(Toolbar);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MinimizeBox = false;
            Name = "HeroDetailsForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "PC Details";
            Toolbar.ResumeLayout(false);
            Toolbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser Browser;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton PlayerViewBtn;
		private System.Windows.Forms.ToolStripDropDownButton ExportMenu;
		private System.Windows.Forms.ToolStripMenuItem ExportHTML;
        private System.Windows.Forms.ToolStripMenuItem ExportHero;
    }
}