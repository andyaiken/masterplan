namespace Masterplan.UI
{
	partial class EncyclopediaEntryDetailsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncyclopediaEntryDetailsForm));
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.DMBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ExportMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.ExportHTML = new System.Windows.Forms.ToolStripMenuItem();
			this.PlayerViewBtn = new System.Windows.Forms.ToolStripButton();
			this.Toolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Browser
			// 
			this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Browser.IsWebBrowserContextMenuEnabled = false;
			this.Browser.Location = new System.Drawing.Point(0, 25);
			this.Browser.Name = "Browser";
			this.Browser.ScriptErrorsSuppressed = true;
			this.Browser.Size = new System.Drawing.Size(372, 337);
			this.Browser.TabIndex = 2;
			this.Browser.WebBrowserShortcutsEnabled = false;
			this.Browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.Browser_Navigating);
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DMBtn,
            this.toolStripSeparator2,
            this.ExportMenu,
            this.PlayerViewBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(372, 25);
			this.Toolbar.TabIndex = 3;
			this.Toolbar.Text = "toolStrip1";
			// 
			// DMBtn
			// 
			this.DMBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.DMBtn.Image = ((System.Drawing.Image)(resources.GetObject("DMBtn.Image")));
			this.DMBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.DMBtn.Name = "DMBtn";
			this.DMBtn.Size = new System.Drawing.Size(86, 22);
			this.DMBtn.Text = "Show DM Info";
			this.DMBtn.Click += new System.EventHandler(this.DMBtn_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// ExportMenu
			// 
			this.ExportMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ExportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportHTML});
			this.ExportMenu.Image = ((System.Drawing.Image)(resources.GetObject("ExportMenu.Image")));
			this.ExportMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ExportMenu.Name = "ExportMenu";
			this.ExportMenu.Size = new System.Drawing.Size(53, 22);
			this.ExportMenu.Text = "Export";
			// 
			// ExportHTML
			// 
			this.ExportHTML.Name = "ExportHTML";
			this.ExportHTML.Size = new System.Drawing.Size(157, 22);
			this.ExportHTML.Text = "Export to HTML";
			this.ExportHTML.Click += new System.EventHandler(this.ExportHTML_Click);
			// 
			// PlayerViewBtn
			// 
			this.PlayerViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewBtn.Image")));
			this.PlayerViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewBtn.Name = "PlayerViewBtn";
			this.PlayerViewBtn.Size = new System.Drawing.Size(114, 22);
			this.PlayerViewBtn.Text = "Send to Player View";
			this.PlayerViewBtn.Click += new System.EventHandler(this.PlayerViewBtn_Click);
			// 
			// EncyclopediaEntryDetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 362);
			this.Controls.Add(this.Browser);
			this.Controls.Add(this.Toolbar);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EncyclopediaEntryDetailsForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encyclopedia Entry";
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser Browser;
		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ToolStripButton PlayerViewBtn;
		private System.Windows.Forms.ToolStripButton DMBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripDropDownButton ExportMenu;
		private System.Windows.Forms.ToolStripMenuItem ExportHTML;

	}
}