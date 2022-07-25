namespace Masterplan.UI
{
	partial class HeroListForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeroListForm));
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("PCs", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Inactive PCs", System.Windows.Forms.HorizontalAlignment.Left);
			this.Toolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripSplitButton();
			this.AddRandomCharacter = new System.Windows.Forms.ToolStripMenuItem();
			this.AddRandomParty = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.AddSuggest = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ActiveBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.PlayerViewBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.StatBlockBtn = new System.Windows.Forms.ToolStripButton();
			this.EntryBtn = new System.Windows.Forms.ToolStripButton();
			this.HeroList = new System.Windows.Forms.ListView();
			this.NameHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CharHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.InsightHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.PercHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.PartySizeLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.OverviewPage = new System.Windows.Forms.TabPage();
			this.BreakdownPnl = new Masterplan.Controls.BreakdownPanel();
			this.ParcelPage = new System.Windows.Forms.TabPage();
			this.ParcelList = new System.Windows.Forms.ListView();
			this.ParcelHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ParcelDetailsHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CloseBtn = new System.Windows.Forms.Button();
			this.ImportCB = new System.Windows.Forms.ToolStripMenuItem();
			this.Toolbar.SuspendLayout();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.StatusBar.SuspendLayout();
			this.OverviewPage.SuspendLayout();
			this.ParcelPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// Toolbar
			// 
			this.Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn,
            this.toolStripSeparator2,
            this.ActiveBtn,
            this.toolStripSeparator3,
            this.PlayerViewBtn,
            this.toolStripSeparator5,
            this.StatBlockBtn,
            this.EntryBtn});
			this.Toolbar.Location = new System.Drawing.Point(3, 3);
			this.Toolbar.Name = "Toolbar";
			this.Toolbar.Size = new System.Drawing.Size(562, 25);
			this.Toolbar.TabIndex = 0;
			this.Toolbar.Text = Session.I18N.toolStrip1;
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportCB,
            this.AddRandomCharacter,
            this.AddRandomParty,
            this.toolStripSeparator6,
            this.AddSuggest});
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(45, 22);
			this.AddBtn.Text = Session.I18N.Add;
			this.AddBtn.ButtonClick += new System.EventHandler(this.AddBtn_Click);
			// 
			// AddRandomCharacter
			// 
			this.AddRandomCharacter.Name = "AddRandomCharacter";
			this.AddRandomCharacter.Size = new System.Drawing.Size(242, 22);
			this.AddRandomCharacter.Text = "Random Character";
			this.AddRandomCharacter.Click += new System.EventHandler(this.RandomPC_Click);
			// 
			// AddRandomParty
			// 
			this.AddRandomParty.Name = "AddRandomParty";
			this.AddRandomParty.Size = new System.Drawing.Size(242, 22);
			this.AddRandomParty.Text = "Random Party";
			this.AddRandomParty.Click += new System.EventHandler(this.RandomParty_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(239, 6);
			// 
			// AddSuggest
			// 
			this.AddSuggest.Name = "AddSuggest";
			this.AddSuggest.Size = new System.Drawing.Size(242, 22);
			this.AddSuggest.Text = "Suggest a Character";
			this.AddSuggest.Click += new System.EventHandler(this.AddSuggest_Click);
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
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// ActiveBtn
			// 
			this.ActiveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ActiveBtn.Image = ((System.Drawing.Image)(resources.GetObject("ActiveBtn.Image")));
			this.ActiveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ActiveBtn.Name = "ActiveBtn";
			this.ActiveBtn.Size = new System.Drawing.Size(44, 22);
			this.ActiveBtn.Text = "Active";
			this.ActiveBtn.Click += new System.EventHandler(this.ActiveBtn_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// PlayerViewBtn
			// 
			this.PlayerViewBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayerViewBtn.Image = ((System.Drawing.Image)(resources.GetObject("PlayerViewBtn.Image")));
			this.PlayerViewBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayerViewBtn.Name = "PlayerViewBtn";
			this.PlayerViewBtn.Size = new System.Drawing.Size(114, 22);
			this.PlayerViewBtn.Text = Session.I18N.SendPlayerView;
			this.PlayerViewBtn.Click += new System.EventHandler(this.PlayerViewBtn_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
			// EntryBtn
			// 
			this.EntryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EntryBtn.Image = ((System.Drawing.Image)(resources.GetObject("EntryBtn.Image")));
			this.EntryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EntryBtn.Name = "EntryBtn";
			this.EntryBtn.Size = new System.Drawing.Size(111, 22);
			this.EntryBtn.Text = Session.I18N.EncyclopediaEntry;
			this.EntryBtn.Click += new System.EventHandler(this.EntryBtn_Click);
			// 
			// HeroList
			// 
			this.HeroList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameHdr,
            this.CharHdr,
            this.InsightHdr,
            this.PercHdr});
			this.HeroList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.HeroList.FullRowSelect = true;
			listViewGroup1.Header = "PCs";
			listViewGroup1.Name = "listViewGroup1";
			listViewGroup2.Header = "Inactive PCs";
			listViewGroup2.Name = "listViewGroup2";
			this.HeroList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
			this.HeroList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.HeroList.HideSelection = false;
			this.HeroList.Location = new System.Drawing.Point(3, 28);
			this.HeroList.MultiSelect = false;
			this.HeroList.Name = "HeroList";
			this.HeroList.Size = new System.Drawing.Size(562, 209);
			this.HeroList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.HeroList.TabIndex = 1;
			this.HeroList.UseCompatibleStateImageBehavior = false;
			this.HeroList.View = System.Windows.Forms.View.Details;
			this.HeroList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// NameHdr
			// 
			this.NameHdr.Text = "Name";
			this.NameHdr.Width = 180;
			// 
			// CharHdr
			// 
			this.CharHdr.Text = "Character";
			this.CharHdr.Width = 200;
			// 
			// InsightHdr
			// 
			this.InsightHdr.Text = "Insight";
			this.InsightHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.InsightHdr.Width = 75;
			// 
			// PercHdr
			// 
			this.PercHdr.Text = "Perception";
			this.PercHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PercHdr.Width = 75;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.OverviewPage);
			this.Pages.Controls.Add(this.ParcelPage);
			this.Pages.Location = new System.Drawing.Point(12, 12);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(576, 288);
			this.Pages.TabIndex = 2;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.HeroList);
			this.DetailsPage.Controls.Add(this.StatusBar);
			this.DetailsPage.Controls.Add(this.Toolbar);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(568, 262);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// StatusBar
			// 
			this.StatusBar.BackColor = System.Drawing.Color.Transparent;
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PartySizeLbl});
			this.StatusBar.Location = new System.Drawing.Point(3, 237);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(562, 22);
			this.StatusBar.SizingGrip = false;
			this.StatusBar.TabIndex = 2;
			// 
			// PartySizeLbl
			// 
			this.PartySizeLbl.IsLink = true;
			this.PartySizeLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.PartySizeLbl.Name = "PartySizeLbl";
			this.PartySizeLbl.Size = new System.Drawing.Size(216, 17);
			this.PartySizeLbl.Text = "Your campaign is set up for a party of N";
			// 
			// OverviewPage
			// 
			this.OverviewPage.Controls.Add(this.BreakdownPnl);
			this.OverviewPage.Location = new System.Drawing.Point(4, 22);
			this.OverviewPage.Name = "OverviewPage";
			this.OverviewPage.Padding = new System.Windows.Forms.Padding(3);
			this.OverviewPage.Size = new System.Drawing.Size(568, 262);
			this.OverviewPage.TabIndex = 1;
			this.OverviewPage.Text = "Class Role Overview";
			this.OverviewPage.UseVisualStyleBackColor = true;
			// 
			// BreakdownPnl
			// 
			this.BreakdownPnl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BreakdownPnl.Heroes = null;
			this.BreakdownPnl.Location = new System.Drawing.Point(3, 3);
			this.BreakdownPnl.Name = "BreakdownPnl";
			this.BreakdownPnl.Size = new System.Drawing.Size(562, 256);
			this.BreakdownPnl.TabIndex = 0;
			// 
			// ParcelPage
			// 
			this.ParcelPage.Controls.Add(this.ParcelList);
			this.ParcelPage.Location = new System.Drawing.Point(4, 22);
			this.ParcelPage.Name = "ParcelPage";
			this.ParcelPage.Padding = new System.Windows.Forms.Padding(3);
			this.ParcelPage.Size = new System.Drawing.Size(568, 262);
			this.ParcelPage.TabIndex = 2;
			this.ParcelPage.Text = Session.I18N.TreasureParcels;
			this.ParcelPage.UseVisualStyleBackColor = true;
			// 
			// ParcelList
			// 
			this.ParcelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ParcelHdr,
            this.ParcelDetailsHdr});
			this.ParcelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ParcelList.FullRowSelect = true;
			this.ParcelList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.ParcelList.HideSelection = false;
			this.ParcelList.Location = new System.Drawing.Point(3, 3);
			this.ParcelList.MultiSelect = false;
			this.ParcelList.Name = "ParcelList";
			this.ParcelList.Size = new System.Drawing.Size(562, 256);
			this.ParcelList.TabIndex = 0;
			this.ParcelList.UseCompatibleStateImageBehavior = false;
			this.ParcelList.View = System.Windows.Forms.View.Details;
			this.ParcelList.DoubleClick += new System.EventHandler(this.ParcelList_DoubleClick);
			// 
			// ParcelHdr
			// 
			this.ParcelHdr.Text = "Treasure Parcel";
			this.ParcelHdr.Width = 185;
			// 
			// ParcelDetailsHdr
			// 
			this.ParcelDetailsHdr.Text = "Details";
			this.ParcelDetailsHdr.Width = 339;
			// 
			// CloseBtn
			// 
			this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.CloseBtn.Location = new System.Drawing.Point(513, 306);
			this.CloseBtn.Name = "CloseBtn";
			this.CloseBtn.Size = new System.Drawing.Size(75, 23);
			this.CloseBtn.TabIndex = 3;
			this.CloseBtn.Text = "Close";
			this.CloseBtn.UseVisualStyleBackColor = true;
			// 
			// ImportCB
			// 
			this.ImportCB.Name = "ImportCB";
			this.ImportCB.Size = new System.Drawing.Size(242, 22);
			this.ImportCB.Text = "Import from Character Builder...";
			this.ImportCB.Click += new System.EventHandler(this.Import_CB_Click);
			// 
			// HeroListForm
			// 
			this.AcceptButton = this.CloseBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(600, 341);
			this.Controls.Add(this.CloseBtn);
			this.Controls.Add(this.Pages);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HeroListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.PlayerCharacters;
			this.Toolbar.ResumeLayout(false);
			this.Toolbar.PerformLayout();
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.OverviewPage.ResumeLayout(false);
			this.ParcelPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip Toolbar;
		private System.Windows.Forms.ListView HeroList;
		private System.Windows.Forms.ColumnHeader NameHdr;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ColumnHeader CharHdr;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TabPage OverviewPage;
		private Masterplan.Controls.BreakdownPanel BreakdownPnl;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton PlayerViewBtn;
		private System.Windows.Forms.ColumnHeader InsightHdr;
		private System.Windows.Forms.ColumnHeader PercHdr;
		private System.Windows.Forms.Button CloseBtn;
		private System.Windows.Forms.ToolStripSplitButton AddBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton StatBlockBtn;
		private System.Windows.Forms.ToolStripMenuItem AddRandomCharacter;
		private System.Windows.Forms.ToolStripMenuItem AddRandomParty;
		private System.Windows.Forms.ToolStripButton ActiveBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem AddSuggest;
		private System.Windows.Forms.ToolStripButton EntryBtn;
		private System.Windows.Forms.TabPage ParcelPage;
		private System.Windows.Forms.ListView ParcelList;
		private System.Windows.Forms.ColumnHeader ParcelHdr;
		private System.Windows.Forms.ColumnHeader ParcelDetailsHdr;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel PartySizeLbl;
		private System.Windows.Forms.ToolStripMenuItem ImportCB;
	}
}