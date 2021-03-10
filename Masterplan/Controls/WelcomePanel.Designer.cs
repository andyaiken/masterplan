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
			this.MenuBrowser = new System.Windows.Forms.WebBrowser();
			this.TitlePanel = new Masterplan.Controls.TitlePanel();
			this.SuspendLayout();
			// 
			// MenuBrowser
			// 
			this.MenuBrowser.Dock = System.Windows.Forms.DockStyle.Right;
			this.MenuBrowser.IsWebBrowserContextMenuEnabled = false;
			this.MenuBrowser.Location = new System.Drawing.Point(364, 0);
			this.MenuBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.MenuBrowser.Name = "MenuBrowser";
			this.MenuBrowser.ScriptErrorsSuppressed = true;
			this.MenuBrowser.Size = new System.Drawing.Size(345, 429);
			this.MenuBrowser.TabIndex = 5;
			this.MenuBrowser.WebBrowserShortcutsEnabled = false;
			this.MenuBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.MenuBrowser_Navigating);
			// 
			// TitlePanel
			// 
			this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TitlePanel.Font = new System.Drawing.Font("Calibri", 11F);
			this.TitlePanel.ForeColor = System.Drawing.Color.MidnightBlue;
			this.TitlePanel.Location = new System.Drawing.Point(0, 0);
			this.TitlePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.TitlePanel.Mode = Masterplan.Controls.TitlePanel.TitlePanelMode.WelcomeScreen;
			this.TitlePanel.Name = "TitlePanel";
			this.TitlePanel.Size = new System.Drawing.Size(364, 429);
			this.TitlePanel.TabIndex = 4;
			this.TitlePanel.Title = "Masterplan";
			this.TitlePanel.Zooming = false;
			this.TitlePanel.FadeFinished += new System.EventHandler(this.TitlePanel_FadeFinished);
			// 
			// WelcomePanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.TitlePanel);
			this.Controls.Add(this.MenuBrowser);
			this.Name = "WelcomePanel";
			this.Size = new System.Drawing.Size(709, 429);
			this.ResumeLayout(false);

		}

		#endregion

		private TitlePanel TitlePanel;
        private System.Windows.Forms.WebBrowser MenuBrowser;

	}
}
