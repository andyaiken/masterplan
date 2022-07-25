namespace Masterplan.UI
{
	partial class OptionRaceForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionRaceForm));
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.TraitsPage = new System.Windows.Forms.TabPage();
			this.SkillBonusBox = new System.Windows.Forms.TextBox();
			this.LanguageBox = new System.Windows.Forms.TextBox();
			this.VisionBox = new System.Windows.Forms.TextBox();
			this.SpeedBox = new System.Windows.Forms.TextBox();
			this.SizeBox = new System.Windows.Forms.ComboBox();
			this.AbilityScoreBox = new System.Windows.Forms.TextBox();
			this.WeightBox = new System.Windows.Forms.TextBox();
			this.HeightBox = new System.Windows.Forms.TextBox();
			this.SkillBonusLbl = new System.Windows.Forms.Label();
			this.LanguageLbl = new System.Windows.Forms.Label();
			this.VisionLbl = new System.Windows.Forms.Label();
			this.SpeedLbl = new System.Windows.Forms.Label();
			this.SizeLbl = new System.Windows.Forms.Label();
			this.AbilityScoreLbl = new System.Windows.Forms.Label();
			this.WeightLbl = new System.Windows.Forms.Label();
			this.HeightLbl = new System.Windows.Forms.Label();
			this.DetailsPage = new System.Windows.Forms.TabPage();
			this.DetailsBox = new System.Windows.Forms.TextBox();
			this.FeaturesPage = new System.Windows.Forms.TabPage();
			this.FeatureList = new System.Windows.Forms.ListView();
			this.FeatureHdr = new System.Windows.Forms.ColumnHeader();
			this.FeatureToolbar = new System.Windows.Forms.ToolStrip();
			this.FeatureAddBtn = new System.Windows.Forms.ToolStripButton();
			this.FeatureRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.FeatureEditBtn = new System.Windows.Forms.ToolStripButton();
			this.PowersPage = new System.Windows.Forms.TabPage();
			this.PowerList = new System.Windows.Forms.ListView();
			this.PowerHdr = new System.Windows.Forms.ColumnHeader();
			this.PowerToolbar = new System.Windows.Forms.ToolStrip();
			this.PowerAddBtn = new System.Windows.Forms.ToolStripButton();
			this.PowerRemoveBtn = new System.Windows.Forms.ToolStripButton();
			this.PowerEditBtn = new System.Windows.Forms.ToolStripButton();
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.QuoteLbl = new System.Windows.Forms.Label();
			this.QuoteBox = new System.Windows.Forms.TextBox();
			this.Pages.SuspendLayout();
			this.TraitsPage.SuspendLayout();
			this.DetailsPage.SuspendLayout();
			this.FeaturesPage.SuspendLayout();
			this.FeatureToolbar.SuspendLayout();
			this.PowersPage.SuspendLayout();
			this.PowerToolbar.SuspendLayout();
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
			this.NameBox.Location = new System.Drawing.Point(56, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(305, 20);
			this.NameBox.TabIndex = 1;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.TraitsPage);
			this.Pages.Controls.Add(this.DetailsPage);
			this.Pages.Controls.Add(this.FeaturesPage);
			this.Pages.Controls.Add(this.PowersPage);
			this.Pages.Location = new System.Drawing.Point(12, 38);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(349, 248);
			this.Pages.TabIndex = 2;
			// 
			// TraitsPage
			// 
			this.TraitsPage.Controls.Add(this.SkillBonusBox);
			this.TraitsPage.Controls.Add(this.LanguageBox);
			this.TraitsPage.Controls.Add(this.VisionBox);
			this.TraitsPage.Controls.Add(this.SpeedBox);
			this.TraitsPage.Controls.Add(this.SizeBox);
			this.TraitsPage.Controls.Add(this.AbilityScoreBox);
			this.TraitsPage.Controls.Add(this.WeightBox);
			this.TraitsPage.Controls.Add(this.HeightBox);
			this.TraitsPage.Controls.Add(this.SkillBonusLbl);
			this.TraitsPage.Controls.Add(this.LanguageLbl);
			this.TraitsPage.Controls.Add(this.VisionLbl);
			this.TraitsPage.Controls.Add(this.SpeedLbl);
			this.TraitsPage.Controls.Add(this.SizeLbl);
			this.TraitsPage.Controls.Add(this.AbilityScoreLbl);
			this.TraitsPage.Controls.Add(this.WeightLbl);
			this.TraitsPage.Controls.Add(this.HeightLbl);
			this.TraitsPage.Location = new System.Drawing.Point(4, 22);
			this.TraitsPage.Name = "TraitsPage";
			this.TraitsPage.Padding = new System.Windows.Forms.Padding(3);
			this.TraitsPage.Size = new System.Drawing.Size(341, 222);
			this.TraitsPage.TabIndex = 1;
			this.TraitsPage.Text = "Racial Traits";
			this.TraitsPage.UseVisualStyleBackColor = true;
			// 
			// SkillBonusBox
			// 
			this.SkillBonusBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SkillBonusBox.Location = new System.Drawing.Point(99, 189);
			this.SkillBonusBox.Name = "SkillBonusBox";
			this.SkillBonusBox.Size = new System.Drawing.Size(236, 20);
			this.SkillBonusBox.TabIndex = 15;
			// 
			// LanguageBox
			// 
			this.LanguageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.LanguageBox.Location = new System.Drawing.Point(99, 163);
			this.LanguageBox.Name = "LanguageBox";
			this.LanguageBox.Size = new System.Drawing.Size(236, 20);
			this.LanguageBox.TabIndex = 13;
			// 
			// VisionBox
			// 
			this.VisionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.VisionBox.Location = new System.Drawing.Point(99, 137);
			this.VisionBox.Name = "VisionBox";
			this.VisionBox.Size = new System.Drawing.Size(236, 20);
			this.VisionBox.TabIndex = 11;
			// 
			// SpeedBox
			// 
			this.SpeedBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SpeedBox.Location = new System.Drawing.Point(99, 111);
			this.SpeedBox.Name = "SpeedBox";
			this.SpeedBox.Size = new System.Drawing.Size(236, 20);
			this.SpeedBox.TabIndex = 9;
			// 
			// SizeBox
			// 
			this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.SizeBox.FormattingEnabled = true;
			this.SizeBox.Location = new System.Drawing.Point(99, 84);
			this.SizeBox.Name = "SizeBox";
			this.SizeBox.Size = new System.Drawing.Size(236, 21);
			this.SizeBox.TabIndex = 7;
			// 
			// AbilityScoreBox
			// 
			this.AbilityScoreBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.AbilityScoreBox.Location = new System.Drawing.Point(99, 58);
			this.AbilityScoreBox.Name = "AbilityScoreBox";
			this.AbilityScoreBox.Size = new System.Drawing.Size(236, 20);
			this.AbilityScoreBox.TabIndex = 5;
			// 
			// WeightBox
			// 
			this.WeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WeightBox.Location = new System.Drawing.Point(99, 32);
			this.WeightBox.Name = "WeightBox";
			this.WeightBox.Size = new System.Drawing.Size(236, 20);
			this.WeightBox.TabIndex = 3;
			// 
			// HeightBox
			// 
			this.HeightBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HeightBox.Location = new System.Drawing.Point(99, 6);
			this.HeightBox.Name = "HeightBox";
			this.HeightBox.Size = new System.Drawing.Size(236, 20);
			this.HeightBox.TabIndex = 1;
			// 
			// SkillBonusLbl
			// 
			this.SkillBonusLbl.AutoSize = true;
			this.SkillBonusLbl.Location = new System.Drawing.Point(6, 192);
			this.SkillBonusLbl.Name = "SkillBonusLbl";
			this.SkillBonusLbl.Size = new System.Drawing.Size(73, 13);
			this.SkillBonusLbl.TabIndex = 14;
			this.SkillBonusLbl.Text = "Skill Bonuses:";
			// 
			// LanguageLbl
			// 
			this.LanguageLbl.AutoSize = true;
			this.LanguageLbl.Location = new System.Drawing.Point(6, 166);
			this.LanguageLbl.Name = "LanguageLbl";
			this.LanguageLbl.Size = new System.Drawing.Size(63, 13);
			this.LanguageLbl.TabIndex = 12;
			this.LanguageLbl.Text = "Languages:";
			// 
			// VisionLbl
			// 
			this.VisionLbl.AutoSize = true;
			this.VisionLbl.Location = new System.Drawing.Point(6, 140);
			this.VisionLbl.Name = "VisionLbl";
			this.VisionLbl.Size = new System.Drawing.Size(38, 13);
			this.VisionLbl.TabIndex = 10;
			this.VisionLbl.Text = "Vision:";
			// 
			// SpeedLbl
			// 
			this.SpeedLbl.AutoSize = true;
			this.SpeedLbl.Location = new System.Drawing.Point(6, 114);
			this.SpeedLbl.Name = "SpeedLbl";
			this.SpeedLbl.Size = new System.Drawing.Size(41, 13);
			this.SpeedLbl.TabIndex = 8;
			this.SpeedLbl.Text = "Speed:";
			// 
			// SizeLbl
			// 
			this.SizeLbl.AutoSize = true;
			this.SizeLbl.Location = new System.Drawing.Point(6, 87);
			this.SizeLbl.Name = "SizeLbl";
			this.SizeLbl.Size = new System.Drawing.Size(30, 13);
			this.SizeLbl.TabIndex = 6;
			this.SizeLbl.Text = "Size:";
			// 
			// AbilityScoreLbl
			// 
			this.AbilityScoreLbl.AutoSize = true;
			this.AbilityScoreLbl.Location = new System.Drawing.Point(6, 61);
			this.AbilityScoreLbl.Name = "AbilityScoreLbl";
			this.AbilityScoreLbl.Size = new System.Drawing.Size(73, 13);
			this.AbilityScoreLbl.TabIndex = 4;
			this.AbilityScoreLbl.Text = "Ability Scores:";
			// 
			// WeightLbl
			// 
			this.WeightLbl.AutoSize = true;
			this.WeightLbl.Location = new System.Drawing.Point(6, 35);
			this.WeightLbl.Name = "WeightLbl";
			this.WeightLbl.Size = new System.Drawing.Size(87, 13);
			this.WeightLbl.TabIndex = 2;
			this.WeightLbl.Text = "Average Weight:";
			// 
			// HeightLbl
			// 
			this.HeightLbl.AutoSize = true;
			this.HeightLbl.Location = new System.Drawing.Point(6, 9);
			this.HeightLbl.Name = "HeightLbl";
			this.HeightLbl.Size = new System.Drawing.Size(84, 13);
			this.HeightLbl.TabIndex = 0;
			this.HeightLbl.Text = "Average Height:";
			// 
			// DetailsPage
			// 
			this.DetailsPage.Controls.Add(this.QuoteBox);
			this.DetailsPage.Controls.Add(this.QuoteLbl);
			this.DetailsPage.Controls.Add(this.DetailsBox);
			this.DetailsPage.Location = new System.Drawing.Point(4, 22);
			this.DetailsPage.Name = "DetailsPage";
			this.DetailsPage.Padding = new System.Windows.Forms.Padding(3);
			this.DetailsPage.Size = new System.Drawing.Size(341, 222);
			this.DetailsPage.TabIndex = 0;
			this.DetailsPage.Text = "Details";
			this.DetailsPage.UseVisualStyleBackColor = true;
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
			this.DetailsBox.Size = new System.Drawing.Size(329, 184);
			this.DetailsBox.TabIndex = 0;
			// 
			// FeaturesPage
			// 
			this.FeaturesPage.Controls.Add(this.FeatureList);
			this.FeaturesPage.Controls.Add(this.FeatureToolbar);
			this.FeaturesPage.Location = new System.Drawing.Point(4, 22);
			this.FeaturesPage.Name = "FeaturesPage";
			this.FeaturesPage.Padding = new System.Windows.Forms.Padding(3);
			this.FeaturesPage.Size = new System.Drawing.Size(341, 222);
			this.FeaturesPage.TabIndex = 2;
			this.FeaturesPage.Text = "Features";
			this.FeaturesPage.UseVisualStyleBackColor = true;
			// 
			// FeatureList
			// 
			this.FeatureList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FeatureHdr});
			this.FeatureList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FeatureList.FullRowSelect = true;
			this.FeatureList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.FeatureList.HideSelection = false;
			this.FeatureList.Location = new System.Drawing.Point(3, 28);
			this.FeatureList.MultiSelect = false;
			this.FeatureList.Name = "FeatureList";
			this.FeatureList.Size = new System.Drawing.Size(335, 191);
			this.FeatureList.TabIndex = 1;
			this.FeatureList.UseCompatibleStateImageBehavior = false;
			this.FeatureList.View = System.Windows.Forms.View.Details;
			this.FeatureList.DoubleClick += new System.EventHandler(this.FeatureEditBtn_Click);
			// 
			// FeatureHdr
			// 
			this.FeatureHdr.Text = "Feature";
			this.FeatureHdr.Width = 300;
			// 
			// FeatureToolbar
			// 
			this.FeatureToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FeatureAddBtn,
            this.FeatureRemoveBtn,
            this.FeatureEditBtn});
			this.FeatureToolbar.Location = new System.Drawing.Point(3, 3);
			this.FeatureToolbar.Name = "FeatureToolbar";
			this.FeatureToolbar.Size = new System.Drawing.Size(335, 25);
			this.FeatureToolbar.TabIndex = 0;
			this.FeatureToolbar.Text = Session.I18N.toolStrip1;
			// 
			// FeatureAddBtn
			// 
			this.FeatureAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FeatureAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("FeatureAddBtn.Image")));
			this.FeatureAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FeatureAddBtn.Name = "FeatureAddBtn";
			this.FeatureAddBtn.Size = new System.Drawing.Size(33, 22);
			this.FeatureAddBtn.Text = Session.I18N.Add;
			this.FeatureAddBtn.Click += new System.EventHandler(this.FeatureAddBtn_Click);
			// 
			// FeatureRemoveBtn
			// 
			this.FeatureRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FeatureRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("FeatureRemoveBtn.Image")));
			this.FeatureRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FeatureRemoveBtn.Name = "FeatureRemoveBtn";
			this.FeatureRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.FeatureRemoveBtn.Text = Session.I18N.Remove;
			this.FeatureRemoveBtn.Click += new System.EventHandler(this.FeatureRemoveBtn_Click);
			// 
			// FeatureEditBtn
			// 
			this.FeatureEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.FeatureEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("FeatureEditBtn.Image")));
			this.FeatureEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FeatureEditBtn.Name = "FeatureEditBtn";
			this.FeatureEditBtn.Size = new System.Drawing.Size(31, 22);
			this.FeatureEditBtn.Text = Session.I18N.Edit;
			this.FeatureEditBtn.Click += new System.EventHandler(this.FeatureEditBtn_Click);
			// 
			// PowersPage
			// 
			this.PowersPage.Controls.Add(this.PowerList);
			this.PowersPage.Controls.Add(this.PowerToolbar);
			this.PowersPage.Location = new System.Drawing.Point(4, 22);
			this.PowersPage.Name = "PowersPage";
			this.PowersPage.Padding = new System.Windows.Forms.Padding(3);
			this.PowersPage.Size = new System.Drawing.Size(341, 222);
			this.PowersPage.TabIndex = 3;
			this.PowersPage.Text = "Powers";
			this.PowersPage.UseVisualStyleBackColor = true;
			// 
			// PowerList
			// 
			this.PowerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PowerHdr});
			this.PowerList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PowerList.FullRowSelect = true;
			this.PowerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.PowerList.HideSelection = false;
			this.PowerList.Location = new System.Drawing.Point(3, 28);
			this.PowerList.MultiSelect = false;
			this.PowerList.Name = "PowerList";
			this.PowerList.Size = new System.Drawing.Size(335, 191);
			this.PowerList.TabIndex = 2;
			this.PowerList.UseCompatibleStateImageBehavior = false;
			this.PowerList.View = System.Windows.Forms.View.Details;
			this.PowerList.DoubleClick += new System.EventHandler(this.PowerEditBtn_Click);
			// 
			// PowerHdr
			// 
			this.PowerHdr.Text = "Feature";
			this.PowerHdr.Width = 300;
			// 
			// PowerToolbar
			// 
			this.PowerToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PowerAddBtn,
            this.PowerRemoveBtn,
            this.PowerEditBtn});
			this.PowerToolbar.Location = new System.Drawing.Point(3, 3);
			this.PowerToolbar.Name = "PowerToolbar";
			this.PowerToolbar.Size = new System.Drawing.Size(335, 25);
			this.PowerToolbar.TabIndex = 1;
			this.PowerToolbar.Text = "toolStrip2";
			// 
			// PowerAddBtn
			// 
			this.PowerAddBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerAddBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerAddBtn.Image")));
			this.PowerAddBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerAddBtn.Name = "PowerAddBtn";
			this.PowerAddBtn.Size = new System.Drawing.Size(33, 22);
			this.PowerAddBtn.Text = Session.I18N.Add;
			this.PowerAddBtn.Click += new System.EventHandler(this.PowerAddBtn_Click);
			// 
			// PowerRemoveBtn
			// 
			this.PowerRemoveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerRemoveBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerRemoveBtn.Image")));
			this.PowerRemoveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerRemoveBtn.Name = "PowerRemoveBtn";
			this.PowerRemoveBtn.Size = new System.Drawing.Size(54, 22);
			this.PowerRemoveBtn.Text = Session.I18N.Remove;
			this.PowerRemoveBtn.Click += new System.EventHandler(this.PowerRemoveBtn_Click);
			// 
			// PowerEditBtn
			// 
			this.PowerEditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PowerEditBtn.Image = ((System.Drawing.Image)(resources.GetObject("PowerEditBtn.Image")));
			this.PowerEditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PowerEditBtn.Name = "PowerEditBtn";
			this.PowerEditBtn.Size = new System.Drawing.Size(31, 22);
			this.PowerEditBtn.Text = Session.I18N.Edit;
			this.PowerEditBtn.Click += new System.EventHandler(this.PowerEditBtn_Click);
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(205, 292);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 3;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(286, 292);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 4;
			this.CancelBtn.Text = Session.I18N.Cancel;
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// QuoteLbl
			// 
			this.QuoteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.QuoteLbl.AutoSize = true;
			this.QuoteLbl.Location = new System.Drawing.Point(6, 199);
			this.QuoteLbl.Name = "QuoteLbl";
			this.QuoteLbl.Size = new System.Drawing.Size(39, 13);
			this.QuoteLbl.TabIndex = 1;
			this.QuoteLbl.Text = "Quote:";
			// 
			// QuoteBox
			// 
			this.QuoteBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.QuoteBox.Location = new System.Drawing.Point(51, 196);
			this.QuoteBox.Name = "QuoteBox";
			this.QuoteBox.Size = new System.Drawing.Size(284, 20);
			this.QuoteBox.TabIndex = 2;
			// 
			// OptionRaceForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(373, 327);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLbl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionRaceForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = Session.I18N.Race;
			this.Pages.ResumeLayout(false);
			this.TraitsPage.ResumeLayout(false);
			this.TraitsPage.PerformLayout();
			this.DetailsPage.ResumeLayout(false);
			this.DetailsPage.PerformLayout();
			this.FeaturesPage.ResumeLayout(false);
			this.FeaturesPage.PerformLayout();
			this.FeatureToolbar.ResumeLayout(false);
			this.FeatureToolbar.PerformLayout();
			this.PowersPage.ResumeLayout(false);
			this.PowersPage.PerformLayout();
			this.PowerToolbar.ResumeLayout(false);
			this.PowerToolbar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage DetailsPage;
		private System.Windows.Forms.TextBox DetailsBox;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.TabPage TraitsPage;
		private System.Windows.Forms.TabPage FeaturesPage;
		private System.Windows.Forms.TabPage PowersPage;
		private System.Windows.Forms.ListView FeatureList;
		private System.Windows.Forms.ColumnHeader FeatureHdr;
		private System.Windows.Forms.ToolStrip FeatureToolbar;
		private System.Windows.Forms.ToolStripButton FeatureAddBtn;
		private System.Windows.Forms.ToolStripButton FeatureRemoveBtn;
		private System.Windows.Forms.ToolStripButton FeatureEditBtn;
		private System.Windows.Forms.ListView PowerList;
		private System.Windows.Forms.ColumnHeader PowerHdr;
		private System.Windows.Forms.ToolStrip PowerToolbar;
		private System.Windows.Forms.ToolStripButton PowerAddBtn;
		private System.Windows.Forms.ToolStripButton PowerRemoveBtn;
		private System.Windows.Forms.ToolStripButton PowerEditBtn;
		private System.Windows.Forms.Label AbilityScoreLbl;
		private System.Windows.Forms.Label WeightLbl;
		private System.Windows.Forms.Label HeightLbl;
		private System.Windows.Forms.Label SpeedLbl;
		private System.Windows.Forms.Label SizeLbl;
		private System.Windows.Forms.TextBox SkillBonusBox;
		private System.Windows.Forms.TextBox LanguageBox;
		private System.Windows.Forms.TextBox VisionBox;
		private System.Windows.Forms.TextBox SpeedBox;
		private System.Windows.Forms.ComboBox SizeBox;
		private System.Windows.Forms.TextBox AbilityScoreBox;
		private System.Windows.Forms.TextBox WeightBox;
		private System.Windows.Forms.TextBox HeightBox;
		private System.Windows.Forms.Label SkillBonusLbl;
		private System.Windows.Forms.Label LanguageLbl;
		private System.Windows.Forms.Label VisionLbl;
		private System.Windows.Forms.TextBox QuoteBox;
		private System.Windows.Forms.Label QuoteLbl;
	}
}