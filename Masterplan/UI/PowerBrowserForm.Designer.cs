namespace Masterplan.UI
{
	partial class PowerBrowserForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerBrowserForm));
			this.Splitter = new System.Windows.Forms.SplitContainer();
			this.CreatureList = new System.Windows.Forms.ListView();
			this.CreatureHdr = new System.Windows.Forms.ColumnHeader();
			this.CreatureInfoHdr = new System.Windows.Forms.ColumnHeader();
			this.FilterPanel = new Masterplan.Controls.FilterPanel();
			this.CreatureListToolbar = new System.Windows.Forms.ToolStrip();
			this.ModeBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.ModeAll = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeSelection = new System.Windows.Forms.ToolStripMenuItem();
			this.DisplayPanel = new System.Windows.Forms.Panel();
			this.PowerDisplay = new System.Windows.Forms.WebBrowser();
			this.PowerToolbar = new System.Windows.Forms.ToolStrip();
			this.StatsBtn = new System.Windows.Forms.ToolStripButton();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.Splitter.Panel1.SuspendLayout();
			this.Splitter.Panel2.SuspendLayout();
			this.Splitter.SuspendLayout();
			this.CreatureListToolbar.SuspendLayout();
			this.DisplayPanel.SuspendLayout();
			this.PowerToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// Splitter
			// 
			this.Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.Splitter.Location = new System.Drawing.Point(12, 12);
			this.Splitter.Name = "Splitter";
			// 
			// Splitter.Panel1
			// 
			this.Splitter.Panel1.Controls.Add(this.CreatureList);
			this.Splitter.Panel1.Controls.Add(this.FilterPanel);
			this.Splitter.Panel1.Controls.Add(this.CreatureListToolbar);
			// 
			// Splitter.Panel2
			// 
			this.Splitter.Panel2.Controls.Add(this.DisplayPanel);
			this.Splitter.Size = new System.Drawing.Size(734, 377);
			this.Splitter.SplitterDistance = 379;
			this.Splitter.TabIndex = 14;
			// 
			// CreatureList
			// 
			this.CreatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CreatureHdr,
            this.CreatureInfoHdr});
			this.CreatureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CreatureList.FullRowSelect = true;
			this.CreatureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CreatureList.HideSelection = false;
			this.CreatureList.Location = new System.Drawing.Point(0, 47);
			this.CreatureList.Name = "CreatureList";
			this.CreatureList.Size = new System.Drawing.Size(379, 330);
			this.CreatureList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.CreatureList.TabIndex = 2;
			this.CreatureList.UseCompatibleStateImageBehavior = false;
			this.CreatureList.View = System.Windows.Forms.View.Details;
			this.CreatureList.SelectedIndexChanged += new System.EventHandler(this.CreatureList_SelectedIndexChanged);
			// 
			// CreatureHdr
			// 
			this.CreatureHdr.Text = Session.I18N.Creature;
			this.CreatureHdr.Width = 218;
			// 
			// CreatureInfoHdr
			// 
			this.CreatureInfoHdr.Text = "Info";
			this.CreatureInfoHdr.Width = 123;
			// 
			// FilterPanel
			// 
			this.FilterPanel.AutoSize = true;
			this.FilterPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.FilterPanel.Location = new System.Drawing.Point(0, 25);
			this.FilterPanel.Mode = Masterplan.UI.ListMode.Creatures;
			this.FilterPanel.Name = "FilterPanel";
			this.FilterPanel.PartyLevel = 0;
			this.FilterPanel.Size = new System.Drawing.Size(379, 22);
			this.FilterPanel.TabIndex = 17;
			this.FilterPanel.FilterChanged += new System.EventHandler(this.FilterPanel_FilterChanged);
			// 
			// CreatureListToolbar
			// 
			this.CreatureListToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModeBtn});
			this.CreatureListToolbar.Location = new System.Drawing.Point(0, 0);
			this.CreatureListToolbar.Name = "CreatureListToolbar";
			this.CreatureListToolbar.Size = new System.Drawing.Size(379, 25);
			this.CreatureListToolbar.TabIndex = 15;
			this.CreatureListToolbar.Text = Session.I18N.toolStrip1;
			// 
			// ModeBtn
			// 
			this.ModeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ModeBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModeAll,
            this.ModeSelection});
			this.ModeBtn.Image = ((System.Drawing.Image)(resources.GetObject("ModeBtn.Image")));
			this.ModeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ModeBtn.Name = "ModeBtn";
			this.ModeBtn.Size = new System.Drawing.Size(51, 22);
			this.ModeBtn.Text = "Mode";
			// 
			// ModeAll
			// 
			this.ModeAll.Name = "ModeAll";
			this.ModeAll.Size = new System.Drawing.Size(290, 22);
			this.ModeAll.Text = "List Powers from All Creatures";
			this.ModeAll.Click += new System.EventHandler(this.ModeAll_Click);
			// 
			// ModeSelection
			// 
			this.ModeSelection.Name = "ModeSelection";
			this.ModeSelection.Size = new System.Drawing.Size(290, 22);
			this.ModeSelection.Text = "List Powers from Selected Creatures Only";
			this.ModeSelection.Click += new System.EventHandler(this.ModeSelection_Click);
			// 
			// DisplayPanel
			// 
			this.DisplayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.DisplayPanel.Controls.Add(this.PowerDisplay);
			this.DisplayPanel.Controls.Add(this.PowerToolbar);
			this.DisplayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DisplayPanel.Location = new System.Drawing.Point(0, 0);
			this.DisplayPanel.Name = "DisplayPanel";
			this.DisplayPanel.Size = new System.Drawing.Size(351, 377);
			this.DisplayPanel.TabIndex = 0;
			// 
			// PowerDisplay
			// 
			this.PowerDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PowerDisplay.IsWebBrowserContextMenuEnabled = false;
			this.PowerDisplay.Location = new System.Drawing.Point(0, 25);
			this.PowerDisplay.MinimumSize = new System.Drawing.Size(20, 20);
			this.PowerDisplay.Name = "PowerDisplay";
			this.PowerDisplay.ScriptErrorsSuppressed = true;
			this.PowerDisplay.Size = new System.Drawing.Size(349, 350);
			this.PowerDisplay.TabIndex = 2;
			this.PowerDisplay.WebBrowserShortcutsEnabled = false;
			this.PowerDisplay.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.PowerDisplay_Navigating);
			// 
			// PowerToolbar
			// 
			this.PowerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatsBtn});
			this.PowerToolbar.Location = new System.Drawing.Point(0, 0);
			this.PowerToolbar.Name = "PowerToolbar";
			this.PowerToolbar.Size = new System.Drawing.Size(349, 25);
			this.PowerToolbar.TabIndex = 3;
			this.PowerToolbar.Text = Session.I18N.toolStrip1;
			// 
			// StatsBtn
			// 
			this.StatsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.StatsBtn.Image = ((System.Drawing.Image)(resources.GetObject("StatsBtn.Image")));
			this.StatsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StatsBtn.Name = "StatsBtn";
			this.StatsBtn.Size = new System.Drawing.Size(93, 22);
			this.StatsBtn.Text = "Power Statistics";
			this.StatsBtn.Click += new System.EventHandler(this.StatsBtn_Click);
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(671, 395);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 15;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// PowerBrowserForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CloseBtn;
			this.ClientSize = new System.Drawing.Size(758, 430);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.Splitter);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PowerBrowserForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Power Browser";
			this.Splitter.Panel1.ResumeLayout(false);
			this.Splitter.Panel1.PerformLayout();
			this.Splitter.Panel2.ResumeLayout(false);
			this.Splitter.ResumeLayout(false);
			this.CreatureListToolbar.ResumeLayout(false);
			this.CreatureListToolbar.PerformLayout();
			this.DisplayPanel.ResumeLayout(false);
			this.DisplayPanel.PerformLayout();
			this.PowerToolbar.ResumeLayout(false);
			this.PowerToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer Splitter;
		private System.Windows.Forms.ListView CreatureList;
		private System.Windows.Forms.ColumnHeader CreatureHdr;
		private System.Windows.Forms.WebBrowser PowerDisplay;
		private System.Windows.Forms.ToolStrip CreatureListToolbar;
		private System.Windows.Forms.ColumnHeader CreatureInfoHdr;
		private System.Windows.Forms.Panel DisplayPanel;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ToolStrip PowerToolbar;
		private System.Windows.Forms.ToolStripDropDownButton ModeBtn;
		private System.Windows.Forms.ToolStripMenuItem ModeAll;
		private System.Windows.Forms.ToolStripMenuItem ModeSelection;
		private System.Windows.Forms.ToolStripButton StatsBtn;
		private Masterplan.Controls.FilterPanel FilterPanel;
	}
}