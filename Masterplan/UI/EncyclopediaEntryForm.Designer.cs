namespace Masterplan.UI
{
	partial class EncyclopediaEntryForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncyclopediaEntryForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.TitleLbl = new System.Windows.Forms.Label();
			this.TitleBox = new System.Windows.Forms.TextBox();
			this.DetailsBox = new Masterplan.Controls.DefaultTextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.PlayerStatusbar = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.DMPage = new System.Windows.Forms.TabPage();
			this.DMBox = new Masterplan.Controls.DefaultTextBox();
			this.DMStatusBar = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.LinksPage = new System.Windows.Forms.TabPage();
			this.EntryList = new System.Windows.Forms.ListView();
			this.EntryHdr = new System.Windows.Forms.ColumnHeader();
			this.ImagesTab = new System.Windows.Forms.TabPage();
			this.PictureList = new System.Windows.Forms.ListView();
			this.PictureToolbar = new System.Windows.Forms.ToolStrip();
			this.AddBtn = new System.Windows.Forms.ToolStripButton();
			this.RemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.CatLbl = new System.Windows.Forms.Label();
			this.CatBox = new System.Windows.Forms.ComboBox();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.PlayerStatusbar.SuspendLayout();
			this.DMPage.SuspendLayout();
			this.DMStatusBar.SuspendLayout();
			this.LinksPage.SuspendLayout();
			this.ImagesTab.SuspendLayout();
			this.PictureToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(438, 359);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 5;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(519, 359);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// TitleLbl
			// 
			this.TitleLbl.AutoSize = true;
			this.TitleLbl.Location = new System.Drawing.Point(12, 15);
			this.TitleLbl.Name = "TitleLbl";
			this.TitleLbl.Size = new System.Drawing.Size(30, 13);
			this.TitleLbl.TabIndex = 0;
			this.TitleLbl.Text = "Title:";
			// 
			// TitleBox
			// 
			this.TitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TitleBox.Location = new System.Drawing.Point(70, 12);
			this.TitleBox.Name = "TitleBox";
			this.TitleBox.Size = new System.Drawing.Size(524, 20);
			this.TitleBox.TabIndex = 1;
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.DefaultText = "(enter details here)";
			this.DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DetailsBox.Location = new System.Drawing.Point(3, 25);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(568, 234);
			this.DetailsBox.TabIndex = 1;
			this.DetailsBox.Text = "(enter details here)";
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.DMPage);
			this.Pages.Controls.Add(this.LinksPage);
			this.Pages.Controls.Add(this.ImagesTab);
			this.Pages.Location = new System.Drawing.Point(12, 65);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(582, 288);
			this.Pages.TabIndex = 4;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Controls.Add(this.PlayerStatusbar);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(574, 262);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Public Information";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// PlayerStatusbar
			// 
			this.PlayerStatusbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.PlayerStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.PlayerStatusbar.Location = new System.Drawing.Point(3, 3);
			this.PlayerStatusbar.Name = "PlayerStatusbar";
			this.PlayerStatusbar.Size = new System.Drawing.Size(568, 22);
			this.PlayerStatusbar.SizingGrip = false;
			this.PlayerStatusbar.TabIndex = 0;
			this.PlayerStatusbar.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(202, 17);
			this.toolStripStatusLabel1.Text = "Note: HTML tags are supported here.";
			// 
			// DMPage
			// 
			this.DMPage.Controls.Add(this.DMBox);
			this.DMPage.Controls.Add(this.DMStatusBar);
			this.DMPage.Location = new System.Drawing.Point(4, 22);
			this.DMPage.Name = "DMPage";
			this.DMPage.Padding = new System.Windows.Forms.Padding(3);
			this.DMPage.Size = new System.Drawing.Size(503, 211);
			this.DMPage.TabIndex = 2;
			this.DMPage.Text = "DM Information";
			this.DMPage.UseVisualStyleBackColor = true;
			// 
			// DMBox
			// 
			this.DMBox.AcceptsReturn = true;
			this.DMBox.AcceptsTab = true;
			this.DMBox.DefaultText = "(enter details here)";
			this.DMBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DMBox.Location = new System.Drawing.Point(3, 25);
			this.DMBox.Multiline = true;
			this.DMBox.Name = "DMBox";
			this.DMBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DMBox.Size = new System.Drawing.Size(497, 183);
			this.DMBox.TabIndex = 3;
			this.DMBox.Text = "(enter details here)";
			// 
			// DMStatusBar
			// 
			this.DMStatusBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.DMStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
			this.DMStatusBar.Location = new System.Drawing.Point(3, 3);
			this.DMStatusBar.Name = "DMStatusBar";
			this.DMStatusBar.Size = new System.Drawing.Size(497, 22);
			this.DMStatusBar.SizingGrip = false;
			this.DMStatusBar.TabIndex = 2;
			this.DMStatusBar.Text = "statusStrip1";
			// 
			// toolStripStatusLabel2
			// 
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new System.Drawing.Size(202, 17);
			this.toolStripStatusLabel2.Text = "Note: HTML tags are supported here.";
			// 
			// LinksPage
			// 
			this.LinksPage.Controls.Add(this.EntryList);
			this.LinksPage.Location = new System.Drawing.Point(4, 22);
			this.LinksPage.Name = "LinksPage";
			this.LinksPage.Padding = new System.Windows.Forms.Padding(3);
			this.LinksPage.Size = new System.Drawing.Size(503, 211);
			this.LinksPage.TabIndex = 1;
			this.LinksPage.Text = "See Also";
			this.LinksPage.UseVisualStyleBackColor = true;
			// 
			// EntryList
			// 
			this.EntryList.CheckBoxes = true;
			this.EntryList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EntryHdr});
			this.EntryList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EntryList.FullRowSelect = true;
			this.EntryList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.EntryList.HideSelection = false;
			this.EntryList.Location = new System.Drawing.Point(3, 3);
			this.EntryList.MultiSelect = false;
			this.EntryList.Name = "EntryList";
			this.EntryList.Size = new System.Drawing.Size(497, 205);
			this.EntryList.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.EntryList.TabIndex = 0;
			this.EntryList.UseCompatibleStateImageBehavior = false;
			this.EntryList.View = System.Windows.Forms.View.Details;
			// 
			// EntryHdr
			// 
			this.EntryHdr.Text = "Entry";
			this.EntryHdr.Width = 300;
			// 
			// ImagesTab
			// 
			this.ImagesTab.Controls.Add(this.PictureList);
			this.ImagesTab.Controls.Add(this.PictureToolbar);
			this.ImagesTab.Location = new System.Drawing.Point(4, 22);
			this.ImagesTab.Name = "ImagesTab";
			this.ImagesTab.Padding = new System.Windows.Forms.Padding(3);
			this.ImagesTab.Size = new System.Drawing.Size(503, 211);
			this.ImagesTab.TabIndex = 3;
			this.ImagesTab.Text = "Pictures";
			this.ImagesTab.UseVisualStyleBackColor = true;
			// 
			// PictureList
			// 
			this.PictureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PictureList.Location = new System.Drawing.Point(3, 28);
			this.PictureList.Name = "PictureList";
			this.PictureList.Size = new System.Drawing.Size(497, 180);
			this.PictureList.TabIndex = 1;
			this.PictureList.UseCompatibleStateImageBehavior = false;
			this.PictureList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// PictureToolbar
			// 
			this.PictureToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBtn,
            this.RemoveBtn,
            this.EditBtn});
			this.PictureToolbar.Location = new System.Drawing.Point(3, 3);
			this.PictureToolbar.Name = "PictureToolbar";
			this.PictureToolbar.Size = new System.Drawing.Size(497, 25);
			this.PictureToolbar.TabIndex = 0;
			this.PictureToolbar.Text = Session.I18N.toolStrip1;
			// 
			// AddBtn
			// 
			this.AddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AddBtn.Image = ((System.Drawing.Image)(resources.GetObject("AddBtn.Image")));
			this.AddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AddBtn.Name = "AddBtn";
			this.AddBtn.Size = new System.Drawing.Size(33, 22);
			this.AddBtn.Text = Session.I18N.Add;
			this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
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
			// CatLbl
			// 
			this.CatLbl.AutoSize = true;
			this.CatLbl.Location = new System.Drawing.Point(12, 41);
			this.CatLbl.Name = "CatLbl";
			this.CatLbl.Size = new System.Drawing.Size(52, 13);
			this.CatLbl.TabIndex = 2;
			this.CatLbl.Text = "Category:";
			// 
			// CatBox
			// 
			this.CatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CatBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
			this.CatBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.CatBox.FormattingEnabled = true;
			this.CatBox.Location = new System.Drawing.Point(70, 38);
			this.CatBox.Name = "CatBox";
			this.CatBox.Size = new System.Drawing.Size(524, 21);
			this.CatBox.TabIndex = 3;
			// 
			// EncyclopediaEntryForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(606, 394);
			this.Controls.Add(this.CatBox);
			this.Controls.Add(this.CatLbl);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.TitleBox);
			this.Controls.Add(this.TitleLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MinimizeBox = false;
			this.Name = "EncyclopediaEntryForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.EncyclopediaEntry;
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.PlayerStatusbar.ResumeLayout(false);
			this.PlayerStatusbar.PerformLayout();
			this.DMPage.ResumeLayout(false);
			this.DMPage.PerformLayout();
			this.DMStatusBar.ResumeLayout(false);
			this.DMStatusBar.PerformLayout();
			this.LinksPage.ResumeLayout(false);
			this.ImagesTab.ResumeLayout(false);
			this.ImagesTab.PerformLayout();
			this.PictureToolbar.ResumeLayout(false);
			this.PictureToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label TitleLbl;
		private System.Windows.Forms.TextBox TitleBox;
		private Masterplan.Controls.DefaultTextBox DetailsBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TabPage LinksPage;
		private System.Windows.Forms.ListView EntryList;
		private System.Windows.Forms.ColumnHeader EntryHdr;
		private System.Windows.Forms.StatusStrip PlayerStatusbar;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.Label CatLbl;
		private System.Windows.Forms.ComboBox CatBox;
		private System.Windows.Forms.TabPage DMPage;
		private Masterplan.Controls.DefaultTextBox DMBox;
		private System.Windows.Forms.StatusStrip DMStatusBar;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.TabPage ImagesTab;
		private System.Windows.Forms.ToolStrip PictureToolbar;
		private System.Windows.Forms.ToolStripButton AddBtn;
		private System.Windows.Forms.ToolStripButton RemoveBtn;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.ListView PictureList;

	}
}