namespace Masterplan.UI
{
	partial class MagicItemSelectForm
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
			this.CancelBtn = new System.Windows.Forms.Button();
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.ItemList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.LevelRangePanel = new Masterplan.Controls.LevelRangePanel();
			this.BrowserPanel = new System.Windows.Forms.Panel();
			this.Browser = new System.Windows.Forms.WebBrowser();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
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
			this.Splitter.Panel1.Controls.Add(this.ItemList);
			this.Splitter.Panel1.Controls.Add(this.LevelRangePanel);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.BrowserPanel);
			this.Splitter.Size = new System.Drawing.Size(693, 336);
			this.Splitter.SplitterDistance = 330;
			this.Splitter.TabIndex = 5;
			// 
			// ItemList
			// 
			this.ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.InfoHdr});
			this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ItemList.FullRowSelect = true;
			this.ItemList.HideSelection = false;
			this.ItemList.Location = new System.Drawing.Point(0, 80);
			this.ItemList.MultiSelect = false;
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(330, 256);
			this.ItemList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.ItemList.TabIndex = 1;
			this.ItemList.UseCompatibleStateImageBehavior = false;
			this.ItemList.View = System.Windows.Forms.View.Details;
			this.ItemList.SelectedIndexChanged += new System.EventHandler(this.ItemList_SelectedIndexChanged);
			this.ItemList.DoubleClick += new System.EventHandler(this.ItemList_DoubleClick);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Magic Item";
			this.NameHdr.Width = 150;
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = "Info";
			this.InfoHdr.Width = 150;
			// 
			// LevelRangePanel
			// 
			this.LevelRangePanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.LevelRangePanel.Location = new System.Drawing.Point(0, 0);
			this.LevelRangePanel.Name = "LevelRangePanel";
			this.LevelRangePanel.Size = new System.Drawing.Size(330, 80);
			this.LevelRangePanel.TabIndex = 2;
			this.LevelRangePanel.RangeChanged += new System.EventHandler(this.LevelRangePanel_RangeChanged);
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
			// MagicItemSelectForm
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
			this.Name = "MagicItemSelectForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select a Magic Item";
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.BrowserPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.ListView ItemList;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.Panel BrowserPanel;
		private System.Windows.Forms.WebBrowser Browser;
		private Masterplan.Controls.LevelRangePanel LevelRangePanel;
	}
}