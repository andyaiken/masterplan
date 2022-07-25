namespace Masterplan.UI
{
	partial class OptionEpicDestinyForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionEpicDestinyForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.ImmortalityPage = new System.Windows.Forms.TabPage();
			this.ImmortalityBox = new System.Windows.Forms.TextBox();
			this.LevelPage = new System.Windows.Forms.TabPage();
			this.LevelList = new System.Windows.Forms.ListView();
			this.LevelHdr = new System.Windows.Forms.ColumnHeader();
			this.LevelToolbar = new System.Windows.Forms.ToolStrip();
			this.LevelEditBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.PrereqBox = new System.Windows.Forms.TextBox();
			this.PrereqLbl = new System.Windows.Forms.Label();
			this.QuoteBox = new System.Windows.Forms.TextBox();
			this.QuoteLbl = new System.Windows.Forms.Label();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.Pages.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.ImmortalityPage.SuspendLayout();
			this.LevelPage.SuspendLayout();
			this.LevelToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(12, 15);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(88, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(273, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.ImmortalityPage);
			this.Pages.Controls.Add(this.LevelPage);
			this.Pages.Location = new System.Drawing.Point(12, 64);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(349, 265);
			this.Pages.TabIndex = 4;
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.QuoteBox);
			this.DetailsPage.Controls.Add(this.QuoteLbl);
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(341, 239);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
			// 
			// ImmortalityPage
			// 
			this.ImmortalityPage.Controls.Add(this.ImmortalityBox);
			this.ImmortalityPage.Location = new System.Drawing.Point(4, 22);
			this.ImmortalityPage.Name = "ImmortalityPage";
			this.ImmortalityPage.Padding = new System.Windows.Forms.Padding(3);
			this.ImmortalityPage.Size = new System.Drawing.Size(341, 239);
			this.ImmortalityPage.TabIndex = 4;
			this.ImmortalityPage.Text = "Immortality";
			this.ImmortalityPage.UseVisualStyleBackColor = true;
			// 
			// ImmortalityBox
			// 
			this.ImmortalityBox.AcceptsReturn = true;
			this.ImmortalityBox.AcceptsTab = true;
			this.ImmortalityBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ImmortalityBox.Location = new System.Drawing.Point(3, 3);
			this.ImmortalityBox.Multiline = true;
			this.ImmortalityBox.Name = "ImmortalityBox";
			this.ImmortalityBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ImmortalityBox.Size = new System.Drawing.Size(335, 233);
			this.ImmortalityBox.TabIndex = 1;
			// 
			// LevelPage
			// 
			this.LevelPage.Controls.Add(this.LevelList);
			this.LevelPage.Controls.Add(this.LevelToolbar);
			this.LevelPage.Location = new System.Drawing.Point(4, 22);
			this.LevelPage.Name = "LevelPage";
			this.LevelPage.Padding = new System.Windows.Forms.Padding(3);
			this.LevelPage.Size = new System.Drawing.Size(341, 239);
			this.LevelPage.TabIndex = 2;
			this.LevelPage.Text = "Levels";
			this.LevelPage.UseVisualStyleBackColor = true;
			// 
			// LevelList
			// 
			this.LevelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LevelHdr});
			this.LevelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LevelList.FullRowSelect = true;
			this.LevelList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LevelList.HideSelection = false;
			this.LevelList.Location = new System.Drawing.Point(3, 28);
			this.LevelList.MultiSelect = false;
			this.LevelList.Name = "LevelList";
			this.LevelList.Size = new System.Drawing.Size(335, 208);
			this.LevelList.TabIndex = 1;
			this.LevelList.UseCompatibleStateImageBehavior = false;
			this.LevelList.View = System.Windows.Forms.View.Details;
			this.LevelList.DoubleClick += new System.EventHandler(this.LevelEditBtn_Click);
			// 
			// LevelHdr
			// 
			this.LevelHdr.Text = Session.I18N.Level;
			this.LevelHdr.Width = 300;
			// 
			// LevelToolbar
			// 
			this.LevelToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LevelEditBtn});
			this.LevelToolbar.Location = new System.Drawing.Point(3, 3);
			this.LevelToolbar.Name = "LevelToolbar";
			this.LevelToolbar.Size = new System.Drawing.Size(335, 25);
			this.LevelToolbar.TabIndex = 0;
			this.LevelToolbar.Text = Session.I18N.toolStrip1;
			// 
			// LevelEditBtn
			// 
			this.LevelEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.LevelEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("LevelEditBtn.Image")));
			this.LevelEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.LevelEditBtn.Name = "LevelEditBtn";
			this.LevelEditBtn.Size = new System.Drawing.Size(31, 22);
			this.LevelEditBtn.Text = Session.I18N.Edit;
			this.LevelEditBtn.Click += new System.EventHandler(this.LevelEditBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(205, 335);
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
			this.CancelBtn.Location = new System.Drawing.Point(286, 335);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 6;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// PrereqBox
			// 
			this.PrereqBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PrereqBox.Location = new System.Drawing.Point(88, 38);
			this.PrereqBox.Name = "PrereqBox";
			this.PrereqBox.Size = new System.Drawing.Size(273, 20);
			this.PrereqBox.TabIndex = 3;
			// 
			// PrereqLbl
			// 
			this.PrereqLbl.AutoSize = true;
			this.PrereqLbl.Location = new System.Drawing.Point(12, 41);
			this.PrereqLbl.Name = "PrereqLbl";
			this.PrereqLbl.Size = new System.Drawing.Size(70, 13);
			this.PrereqLbl.TabIndex = 2;
			this.PrereqLbl.Text = "Prerequisites:";
			// 
			// QuoteBox
			// 
			this.QuoteBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.QuoteBox.Location = new System.Drawing.Point(51, 213);
			this.QuoteBox.Name = "QuoteBox";
			this.QuoteBox.Size = new System.Drawing.Size(284, 20);
			this.QuoteBox.TabIndex = 5;
			// 
			// QuoteLbl
			// 
			this.QuoteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.QuoteLbl.AutoSize = true;
			this.QuoteLbl.Location = new System.Drawing.Point(6, 216);
			this.QuoteLbl.Name = "QuoteLbl";
			this.QuoteLbl.Size = new System.Drawing.Size(39, 13);
			this.QuoteLbl.TabIndex = 4;
			this.QuoteLbl.Text = "Quote:";
			// 
			// DetailsBox
			// 
			this.DetailsBox.AcceptsReturn = true;
			this.DetailsBox.AcceptsTab = true;
			this.DetailsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DetailsBox.Location = new System.Drawing.Point(6, 6);
			this.DetailsBox.Multiline = true;
			this.DetailsBox.Name = "DetailsBox";
			this.DetailsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DetailsBox.Size = new System.Drawing.Size(329, 201);
			this.DetailsBox.TabIndex = 3;
			// 
			// OptionEpicDestinyForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(373, 370);
			this.Controls.Add(this.PrereqBox);
			this.Controls.Add(this.PrereqLbl);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionEpicDestinyForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.EpicDestiny;
			this.Pages.ResumeLayout(false);
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.ImmortalityPage.ResumeLayout(false);
			this.ImmortalityPage.PerformLayout();
			this.LevelPage.ResumeLayout(false);
			this.LevelPage.PerformLayout();
			this.LevelToolbar.ResumeLayout(false);
			this.LevelToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabPage LevelPage;
		private System.Windows.Forms.ListView LevelList;
		private System.Windows.Forms.ColumnHeader LevelHdr;
		private System.Windows.Forms.ToolStrip LevelToolbar;
		private System.Windows.Forms.ToolStripButton LevelEditBtn;
		private System.Windows.Forms.TextBox PrereqBox;
		private System.Windows.Forms.Label PrereqLbl;
		private System.Windows.Forms.TabPage ImmortalityPage;
		private System.Windows.Forms.TextBox ImmortalityBox;
		private System.Windows.Forms.TextBox QuoteBox;
		private System.Windows.Forms.Label QuoteLbl;
		private System.Windows.Forms.TextBox DetailsBox;
	}
}