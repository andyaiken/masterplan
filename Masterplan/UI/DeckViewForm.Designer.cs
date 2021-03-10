namespace Masterplan.UI
{
	partial class DeckViewForm
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
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.DeckView = new Masterplan.Controls.CardDeck();
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// Splitter
			// 
			this.Splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.Splitter.Location = new System.Drawing.Point(0, 0);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.DeckView);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.Browser);
			this.Splitter.Size = new System.Drawing.Size(715, 327);
			this.Splitter.SplitterDistance = 367;
			this.Splitter.TabIndex = 1;
			// 
			// DeckView
			// 
			this.DeckView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DeckView.Location = new System.Drawing.Point(0, 0);
			this.DeckView.Name = "DeckView";
			this.DeckView.Size = new System.Drawing.Size(365, 325);
			this.DeckView.TabIndex = 1;
			this.DeckView.DeckOrderChanged += new System.EventHandler(this.DeckView_DeckOrderChanged);
			// 
			// Browser
			// 
			this.Browser.AllowWebBrowserDrop = false;
			this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Browser.IsWebBrowserContextMenuEnabled = false;
			this.Browser.Location = new System.Drawing.Point(0, 0);
			this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
			this.Browser.Name = "Browser";
			this.Browser.ScriptErrorsSuppressed = true;
			this.Browser.Size = new System.Drawing.Size(342, 325);
			this.Browser.TabIndex = 0;
			this.Browser.WebBrowserShortcutsEnabled = false;
			// 
			// DeckViewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 327);
			this.Controls.Add(this.Splitter);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DeckViewForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encounter Cards";
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer Splitter;
		private Masterplan.Controls.CardDeck DeckView;
		private System.Windows.Forms.WebBrowser Browser;

	}
}