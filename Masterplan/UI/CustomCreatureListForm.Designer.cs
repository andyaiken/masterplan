namespace Masterplan.UI
{
	partial class CustomCreatureListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomCreatureListForm));
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Custom Creatures", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("NPCs", System.Windows.Forms.HorizontalAlignment.Left);
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripDropDownButton();
			this.AddCreature = new System.Windows.Forms.ToolStripMenuItem();
			this.AddNPC = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.StatBlockBtn = new System.Windows.Forms.ToolStripButton();
			this.EncEntryBtn = new System.Windows.Forms.ToolStripButton();
			this.CreatureList = new System.Windows.Forms.ListView();
			this.NameHdr = new System.Windows.Forms.ColumnHeader();
			this.InfoHdr = new System.Windows.Forms.ColumnHeader();
			this.StatsHdr = new System.Windows.Forms.ColumnHeader();
			this.Statusbar = new System.Windows.Forms.StatusStrip();
			this.InfoLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.CloseBtn = new System.Windows.Forms.Button();
			this.Toolbar.SuspendLayout();
			this.Statusbar.SuspendLayout();
			this.MainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator1,
            this.StatBlockBtn,
            this.EncEntryBtn});
			this.Toolbar.Location = new System.Drawing.Point(0, 0);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(776, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCreature,
            this.AddNPC});
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(42, 22);
			this.AddBtn.Text = Session.I18N.Add;
			// 
			// AddCreature
			// 
			this.AddCreature.Name = "AddCreature";
			this.AddCreature.Size = new System.Drawing.Size(155, 22);
			this.AddCreature.Text = "New Creature...";
			this.AddCreature.Click += new System.EventHandler(this.AddCreature_Click);
			// 
			// AddNPC
			// 
			this.AddNPC.Name = "AddNPC";
			this.AddNPC.Size = new System.Drawing.Size(155, 22);
			this.AddNPC.Text = "New NPC...";
			this.AddNPC.Click += new System.EventHandler(this.AddNPC_Click);
			// 
			// RemoveBtn
			// 
			this.RemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.RemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("RemoveBtn.Image")));
			this.RemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RemoveBtn.Name = "RemoveBtn";
			this.RemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.RemoveBtn.Text = Session.I18N.Remove;
			this.RemoveBtn.Click += new System.EventHandler(this.RemoveBtn_Click);
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = Session.I18N.Edit;
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// StatBlockBtn
			// 
			this.StatBlockBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.StatBlockBtn.Image = ((System.Drawing.Image)(resources.GetObject("StatBlockBtn.Image")));
			this.StatBlockBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StatBlockBtn.Name = "StatBlockBtn";
			this.StatBlockBtn.Size = new System.Drawing.Size(63, 22);
			this.StatBlockBtn.Text = "Stat Block";
			this.StatBlockBtn.Click += new System.EventHandler(this.StatBlockBtn_Click);
			// 
			// EncEntryBtn
			// 
			this.EncEntryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EncEntryBtn.Image = ((System.Drawing.Image)(resources.GetObject("EncEntryBtn.Image")));
			this.EncEntryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EncEntryBtn.Name = "EncEntryBtn";
			this.EncEntryBtn.Size = new System.Drawing.Size(111, 22);
			this.EncEntryBtn.Text = Session.I18N.EncyclopediaEntry;
			this.EncEntryBtn.Click += new System.EventHandler(this.EncEntryBtn_Click);
			// 
			// CreatureList
			// 
			this.CreatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.InfoHdr,
            this.StatsHdr});
			this.CreatureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CreatureList.FullRowSelect = true;
			listViewGroup1.Header = "Custom Creatures";
			listViewGroup1.Name = "CustomGroup";
			listViewGroup2.Header = "NPCs";
			listViewGroup2.Name = "NPCGroup";
			this.CreatureList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.CreatureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.CreatureList.HideSelection = false;
			this.CreatureList.Location = new System.Drawing.Point(0, 25);
			this.CreatureList.MultiSelect = false;
			this.CreatureList.Name = "CreatureList";
			this.CreatureList.Size = new System.Drawing.Size(776, 219);
			this.CreatureList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.CreatureList.TabIndex = 1;
			this.CreatureList.UseCompatibleStateImageBehavior = false;
			this.CreatureList.View = System.Windows.Forms.View.Details;
			this.CreatureList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = Session.I18N.Creature;
			this.NameHdr.Width = 287;
			// 
			// InfoHdr
			// 
			this.InfoHdr.Text = Session.I18N.Information;
			this.InfoHdr.Width = 150;
			// 
			// StatsHdr
			// 
			this.StatsHdr.Text = "Statistics";
			this.StatsHdr.Width = 311;
			// 
			// Statusbar
			// 
			this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoLbl});
			this.Statusbar.Location = new System.Drawing.Point(0, 244);
			this.Statusbar.Name = "Statusbar";
			this.Statusbar.Size = new System.Drawing.Size(776, 22);
			this.Statusbar.SizingGrip = false;
			this.Statusbar.TabIndex = 2;
			this.Statusbar.Text = "statusStrip1";
			// 
			// InfoLbl
			// 
			this.InfoLbl.Name = "InfoLbl";
			this.InfoLbl.Size = new System.Drawing.Size(696, 17);
			this.InfoLbl.Text = "This screen is for adding NPCs and unusual creatures to this project only. For re" +
				"usable creatures, go to Libraries on the Tools menu.";
			// 
			// MainPanel
			// 
			this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.MainPanel.Controls.Add(this.CreatureList);
			this.MainPanel.Controls.Add(this.Toolbar);
			this.MainPanel.Controls.Add(this.Statusbar);
			this.MainPanel.Location = new System.Drawing.Point(12, 12);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(776, 266);
			this.MainPanel.TabIndex = 3;
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(713, 284);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 4;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// CustomCreatureListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 319);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.MainPanel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CustomCreatureListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.CustomCreaturesNPC;
			this.Shown += new System.EventHandler(this.CustomCreatureListForm_Shown);
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.Statusbar.ResumeLayout(false);
			this.Statusbar.PerformLayout();
			this.MainPanel.ResumeLayout(false);
			this.MainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ListView CreatureList;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ColumnHeader InfoHdr;
		private System.Windows.Forms.ColumnHeader StatsHdr;
		private System.Windows.Forms.StatusStrip Statusbar;
		private System.Windows.Forms.ToolStripStatusLabel InfoLbl;
		private System.Windows.Forms.ToolStripDropDownButton AddBtn;
		private System.Windows.Forms.ToolStripMenuItem AddNPC;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton StatBlockBtn;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ToolStripButton EncEntryBtn;
		private System.Windows.Forms.ToolStripMenuItem AddCreature;

	}
}