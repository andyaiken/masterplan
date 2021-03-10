namespace Masterplan.UI
{
	partial class CompendiumItemForm
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
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Panel = new System.Windows.Forms.Panel();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.CompendiumBrowser = new System.Windows.Forms.WebBrowser();
			this.ItemBrowser = new System.Windows.Forms.WebBrowser();
			this.OKBtn = new System.Windows.Forms.Button();
			this.Panel.SuspendLayout();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(894, 365);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 0;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// Panel
			// 
			this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Panel.Controls.Add(this.Splitter);
			this.Panel.Location = new System.Drawing.Point(12, 12);
			this.Panel.Name = "Panel";
			this.Panel.Size = new System.Drawing.Size(957, 347);
			this.Panel.TabIndex = 1;
			// 
			// Splitter
			// 
			this.Splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Splitter.Location = new System.Drawing.Point(0, 0);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.CompendiumBrowser);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.ItemBrowser);
			this.Splitter.Size = new System.Drawing.Size(957, 347);
			this.Splitter.SplitterDistance = 614;
			this.Splitter.TabIndex = 0;
			// 
			// CompendiumBrowser
			// 
			this.CompendiumBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CompendiumBrowser.IsWebBrowserContextMenuEnabled = false;
			this.CompendiumBrowser.Location = new System.Drawing.Point(0, 0);
			this.CompendiumBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.CompendiumBrowser.Name = "CompendiumBrowser";
			this.CompendiumBrowser.ScriptErrorsSuppressed = true;
			this.CompendiumBrowser.Size = new System.Drawing.Size(612, 345);
			this.CompendiumBrowser.TabIndex = 0;
			this.CompendiumBrowser.WebBrowserShortcutsEnabled = false;
			this.CompendiumBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.CompendiumBrowser_DocumentCompleted);
			// 
			// ItemBrowser
			// 
			this.ItemBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemBrowser.IsWebBrowserContextMenuEnabled = false;
			this.ItemBrowser.Location = new System.Drawing.Point(0, 0);
			this.ItemBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.ItemBrowser.Name = "ItemBrowser";
			this.ItemBrowser.ScriptErrorsSuppressed = true;
			this.ItemBrowser.Size = new System.Drawing.Size(337, 345);
			this.ItemBrowser.TabIndex = 0;
			this.ItemBrowser.WebBrowserShortcutsEnabled = false;
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(813, 365);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 2;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CompendiumItemForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(981, 400);
			this.Controls.Add(this.Panel);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CompendiumItemForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Compendium Item";
			this.Shown += new System.EventHandler(this.CompendiumItemForm_Shown);
			this.Panel.ResumeLayout(false);
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Panel Panel;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.WebBrowser CompendiumBrowser;
		private System.Windows.Forms.WebBrowser ItemBrowser;
		private System.Windows.Forms.Button OKBtn;
	}
}