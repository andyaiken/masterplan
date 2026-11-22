namespace Masterplan.Controls
{
	partial class WelcomePanel
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
            MenuBrowser = new System.Windows.Forms.WebBrowser();
            TitlePanel = new TitlePanel();
            SuspendLayout();
            // 
            // MenuBrowser
            // 
            MenuBrowser.Dock = System.Windows.Forms.DockStyle.Right;
            MenuBrowser.IsWebBrowserContextMenuEnabled = false;
            MenuBrowser.Location = new System.Drawing.Point(425, 0);
            MenuBrowser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MenuBrowser.MinimumSize = new System.Drawing.Size(23, 23);
            MenuBrowser.Name = "MenuBrowser";
            MenuBrowser.ScriptErrorsSuppressed = true;
            MenuBrowser.Size = new System.Drawing.Size(402, 495);
            MenuBrowser.TabIndex = 5;
            MenuBrowser.WebBrowserShortcutsEnabled = false;
            MenuBrowser.Navigating += MenuBrowser_Navigating;
            // 
            // TitlePanel
            // 
            TitlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            TitlePanel.Font = new System.Drawing.Font("Calibri", 11F);
            TitlePanel.ForeColor = System.Drawing.Color.MidnightBlue;
            TitlePanel.Location = new System.Drawing.Point(0, 0);
            TitlePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            TitlePanel.Mode = TitlePanel.TitlePanelMode.WelcomeScreen;
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new System.Drawing.Size(425, 495);
            TitlePanel.TabIndex = 4;
            TitlePanel.Title = "Masterplan - Transition";
            TitlePanel.Zooming = false;
            TitlePanel.FadeFinished += TitlePanel_FadeFinished;
            TitlePanel.Load += TitlePanel_Load;
            // 
            // WelcomePanel
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            Controls.Add(TitlePanel);
            Controls.Add(MenuBrowser);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "WelcomePanel";
            Size = new System.Drawing.Size(827, 495);
            ResumeLayout(false);

        }

        #endregion

        private TitlePanel TitlePanel;
        private System.Windows.Forms.WebBrowser MenuBrowser;

	}
}
