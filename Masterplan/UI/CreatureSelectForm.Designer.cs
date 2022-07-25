namespace Masterplan.UI
{
	partial class CreatureSelectForm
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
			this.OKBtn = new System.Windows.Forms.Button();
			this.CreatureList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.NamePanel = new System.Windows.Forms.Panel();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.NameLbl = new System.Windows.Forms.Label();
			this.BrowserPanel = new System.Windows.Forms.Panel();
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.NamePanel.SuspendLayout();
			this.BrowserPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(549, 354);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 1;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			// 
			// CreatureList
			// 
			this.CreatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.InfoHdr});
			this.CreatureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CreatureList.FullRowSelect = true;
			this.CreatureList.HideSelection = false;
			this.CreatureList.Location = new System.Drawing.Point(0, 27);
			this.CreatureList.MultiSelect = false;
			this.CreatureList.Name = "CreatureList";
			this.CreatureList.Size = new System.Drawing.Size(330, 309);
			this.CreatureList.TabIndex = 0;
			this.CreatureList.UseCompatibleStateImageBehavior = false;
			this.CreatureList.View = System.Windows.Forms.View.Details;
			this.CreatureList.SelectedIndexChanged += new System.EventHandler(this.CreatureList_SelectedIndexChanged);
			this.CreatureList.DoubleClick += new System.EventHandler(this.TileList_DoubleClick);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = Session.I18N.Creature;
			this.NameHdr.Width = 150;
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = "Info";
			this.InfoHdr.Width = 150;
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(630, 354);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// Splitter
			// 
			this.Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Splitter.Location = new System.Drawing.Point(12, 12);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.CreatureList);
			this.Splitter.Panel1.Controls.Add(this.NamePanel);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.BrowserPanel);
			this.Splitter.Size = new System.Drawing.Size(693, 336);
			this.Splitter.SplitterDistance = 330;
			this.Splitter.TabIndex = 0;
			// 
			// NamePanel
			// 
			this.NamePanel.Controls.Add(this.NameBox);
			this.NamePanel.Controls.Add(this.NameLbl);
			this.NamePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.NamePanel.Location = new System.Drawing.Point(0, 0);
			this.NamePanel.Name = "NamePanel";
			this.NamePanel.Size = new System.Drawing.Size(330, 27);
			this.NamePanel.TabIndex = 0;
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(47, 3);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(280, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(3, 6);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// BrowserPanel
			// 
			this.BrowserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BrowserPanel.Controls.Add(this.Browser);
			this.BrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BrowserPanel.Location = new System.Drawing.Point(0, 0);
			this.BrowserPanel.Name = "BrowserPanel";
			this.BrowserPanel.Size = new System.Drawing.Size(359, 336);
			this.BrowserPanel.TabIndex = 0;
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
			this.Browser.Size = new System.Drawing.Size(357, 334);
			this.Browser.TabIndex = 0;
			this.Browser.WebBrowserShortcutsEnabled = false;
			// 
			// CreatureSelectForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(717, 389);
			this.Controls.Add(this.Splitter);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreatureSelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select a Creature";
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.NamePanel.ResumeLayout(false);
			this.NamePanel.PerformLayout();
			this.BrowserPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.ListView CreatureList;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.Panel BrowserPanel;
		private System.Windows.Forms.WebBrowser Browser;
		private System.Windows.Forms.Panel NamePanel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label NameLbl;
	}
}