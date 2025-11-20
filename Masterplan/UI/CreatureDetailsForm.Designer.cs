using Masterplan.Tools;
using System.Threading.Tasks;

namespace Masterplan.UI
{
	partial class CreatureDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatureDetailsForm));
            Browser = new System.Windows.Forms.WebBrowser();
            Toolbar = new System.Windows.Forms.ToolStrip();
            ExportMenu = new System.Windows.Forms.ToolStripDropDownButton();
            ExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            ExportToPNG = new System.Windows.Forms.ToolStripMenuItem();
            PlayerViewBtn = new System.Windows.Forms.ToolStripButton();
            Toolbar.SuspendLayout();
            SuspendLayout();
            // 
            // Browser
            // 
            Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            Browser.IsWebBrowserContextMenuEnabled = false;
            Browser.Location = new System.Drawing.Point(0, 27);
            Browser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Browser.Name = "Browser";
            Browser.ScriptErrorsSuppressed = true;
            Browser.Size = new System.Drawing.Size(496, 531);
            Browser.TabIndex = 2;
            Browser.WebBrowserShortcutsEnabled = false;
            // 
            // Toolbar
            // 
            Toolbar.ImageScalingSize = new System.Drawing.Size(20, 20);
            Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { ExportMenu, PlayerViewBtn });
            Toolbar.Location = new System.Drawing.Point(0, 0);
            Toolbar.Name = "Toolbar";
            Toolbar.Size = new System.Drawing.Size(496, 27);
            Toolbar.TabIndex = 3;
            Toolbar.Text = "toolStrip1";
            // 
            // ExportMenu
            // 
            ExportMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            ExportMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ExportHTML, ExportToPNG });
            ExportMenu.Image = (System.Drawing.Image)resources.GetObject("ExportMenu.Image");
            ExportMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            ExportMenu.Name = "ExportMenu";
            ExportMenu.Size = new System.Drawing.Size(66, 24);
            ExportMenu.Text = "Export";
            // 
            // ExportHTML
            // 
            ExportHTML.Name = "ExportHTML";
            ExportHTML.Size = new System.Drawing.Size(230, 26);
            ExportHTML.Text = "Export to HTML";
            ExportHTML.Click += ExportHTML_Click;
            // 
            // ExportToPNG
            // 
            ExportToPNG.Name = "ExportToPNG";
            ExportToPNG.Size = new System.Drawing.Size(230, 26);
            ExportToPNG.Text = "(Beta) Export to PNG";
            ExportToPNG.ToolTipText = "Exports to a PNG Image the selected item";
            ExportToPNG.Click += this.ExportToPNG_Click;
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
            // CreatureDetailsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(496, 558);
            Controls.Add(Browser);
            Controls.Add(Toolbar);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            MinimizeBox = false;
            Name = "CreatureDetailsForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Creature Details";
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
        private System.Windows.Forms.ToolStripMenuItem ExportToPNG;
    }
}