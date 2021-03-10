namespace Masterplan.UI
{
	partial class OptionClassForm
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
			System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("Class Features", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Heroic Tier", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Paragon Tier", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Epic Tier", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionClassForm));
			this.OKBtn = new System.Windows.Forms.Button();
			this.CancelBtn = new System.Windows.Forms.Button();
			this.NameLbl = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.RoleLbl = new System.Windows.Forms.Label();
			this.RoleBox = new System.Windows.Forms.TextBox();
			this.PowerSourceLbl = new System.Windows.Forms.Label();
			this.PowerSourceBox = new System.Windows.Forms.TextBox();
			this.Pages = new System.Windows.Forms.TabControl();
			this.GeneralPage = new System.Windows.Forms.TabPage();
			this.SurgeBox = new System.Windows.Forms.NumericUpDown();
			this.SurgeLbl = new System.Windows.Forms.Label();
			this.HPSubsequentBox = new System.Windows.Forms.NumericUpDown();
			this.HPSubsequentLbl = new System.Windows.Forms.Label();
			this.HPFirstBox = new System.Windows.Forms.NumericUpDown();
			this.HPFirstLbl = new System.Windows.Forms.Label();
			this.KeyAbilityBox = new System.Windows.Forms.TextBox();
			this.KeyAbilityLbl = new System.Windows.Forms.Label();
			this.ProficiencyPage = new System.Windows.Forms.TabPage();
			this.SkillBox = new System.Windows.Forms.TextBox();
			this.SkillLbl = new System.Windows.Forms.Label();
			this.DefencesBox = new System.Windows.Forms.TextBox();
			this.DefencesLbl = new System.Windows.Forms.Label();
			this.ImplementBox = new System.Windows.Forms.TextBox();
			this.ImplementLbl = new System.Windows.Forms.Label();
			this.WeaponBox = new System.Windows.Forms.TextBox();
			this.WeaponLbl = new System.Windows.Forms.Label();
			this.ArmourBox = new System.Windows.Forms.TextBox();
			this.ArmourLbl = new System.Windows.Forms.Label();
			this.DescriptionPage = new System.Windows.Forms.TabPage();
			this.QuoteBox = new System.Windows.Forms.TextBox();
			this.QuoteLbl = new System.Windows.Forms.Label();
			this.DescBox = new System.Windows.Forms.TextBox();
			this.OverviewPage = new System.Windows.Forms.TabPage();
			this.RacesBox = new System.Windows.Forms.TextBox();
			this.RacesLbl = new System.Windows.Forms.Label();
			this.ReligionBox = new System.Windows.Forms.TextBox();
			this.ReligionLbl = new System.Windows.Forms.Label();
			this.CharacteristicsBox = new System.Windows.Forms.TextBox();
			this.CharacteristicsLbl = new System.Windows.Forms.Label();
			this.LevelPage = new System.Windows.Forms.TabPage();
			this.LevelList = new System.Windows.Forms.ListView();
			this.LevelHdr = new System.Windows.Forms.ColumnHeader();
			this.LevelToolbar = new System.Windows.Forms.ToolStrip();
			this.EditBtn = new System.Windows.Forms.ToolStripButton();
			this.Pages.SuspendLayout();
			this.GeneralPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SurgeBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HPSubsequentBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HPFirstBox)).BeginInit();
			this.ProficiencyPage.SuspendLayout();
			this.DescriptionPage.SuspendLayout();
			this.OverviewPage.SuspendLayout();
			this.LevelPage.SuspendLayout();
			this.LevelToolbar.SuspendLayout();
			this.SuspendLayout();
			// 
			// OKBtn
			// 
			this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OKBtn.Location = new System.Drawing.Point(205, 300);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.Size = new System.Drawing.Size(75, 23);
			this.OKBtn.TabIndex = 1;
			this.OKBtn.Text = "OK";
			this.OKBtn.UseVisualStyleBackColor = true;
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// CancelBtn
			// 
			this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelBtn.Location = new System.Drawing.Point(286, 300);
			this.CancelBtn.Name = "CancelBtn";
			this.CancelBtn.Size = new System.Drawing.Size(75, 23);
			this.CancelBtn.TabIndex = 2;
			this.CancelBtn.Text = "Cancel";
			this.CancelBtn.UseVisualStyleBackColor = true;
			// 
			// NameLbl
			// 
			this.NameLbl.AutoSize = true;
			this.NameLbl.Location = new System.Drawing.Point(6, 9);
			this.NameLbl.Name = "NameLbl";
			this.NameLbl.Size = new System.Drawing.Size(38, 13);
			this.NameLbl.TabIndex = 0;
			this.NameLbl.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.NameBox.Location = new System.Drawing.Point(94, 6);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(224, 20);
			this.NameBox.TabIndex = 1;
			// 
			// RoleLbl
			// 
			this.RoleLbl.AutoSize = true;
			this.RoleLbl.Location = new System.Drawing.Point(6, 35);
			this.RoleLbl.Name = "RoleLbl";
			this.RoleLbl.Size = new System.Drawing.Size(32, 13);
			this.RoleLbl.TabIndex = 2;
			this.RoleLbl.Text = "Role:";
			// 
			// RoleBox
			// 
			this.RoleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RoleBox.Location = new System.Drawing.Point(94, 32);
			this.RoleBox.Multiline = true;
			this.RoleBox.Name = "RoleBox";
			this.RoleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.RoleBox.Size = new System.Drawing.Size(224, 51);
			this.RoleBox.TabIndex = 3;
			// 
			// PowerSourceLbl
			// 
			this.PowerSourceLbl.AutoSize = true;
			this.PowerSourceLbl.Location = new System.Drawing.Point(6, 92);
			this.PowerSourceLbl.Name = "PowerSourceLbl";
			this.PowerSourceLbl.Size = new System.Drawing.Size(77, 13);
			this.PowerSourceLbl.TabIndex = 4;
			this.PowerSourceLbl.Text = "Power Source:";
			// 
			// PowerSourceBox
			// 
			this.PowerSourceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.PowerSourceBox.Location = new System.Drawing.Point(94, 89);
			this.PowerSourceBox.Multiline = true;
			this.PowerSourceBox.Name = "PowerSourceBox";
			this.PowerSourceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.PowerSourceBox.Size = new System.Drawing.Size(224, 51);
			this.PowerSourceBox.TabIndex = 5;
			// 
			// Pages
			// 
			this.Pages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.Pages.Controls.Add(this.GeneralPage);
			this.Pages.Controls.Add(this.ProficiencyPage);
			this.Pages.Controls.Add(this.DescriptionPage);
			this.Pages.Controls.Add(this.OverviewPage);
			this.Pages.Controls.Add(this.LevelPage);
			this.Pages.Location = new System.Drawing.Point(12, 12);
			this.Pages.Name = "Pages";
			this.Pages.SelectedIndex = 0;
			this.Pages.Size = new System.Drawing.Size(349, 282);
			this.Pages.TabIndex = 0;
			// 
			// GeneralPage
			// 
			this.GeneralPage.Controls.Add(this.SurgeBox);
			this.GeneralPage.Controls.Add(this.SurgeLbl);
			this.GeneralPage.Controls.Add(this.HPSubsequentBox);
			this.GeneralPage.Controls.Add(this.HPSubsequentLbl);
			this.GeneralPage.Controls.Add(this.HPFirstBox);
			this.GeneralPage.Controls.Add(this.HPFirstLbl);
			this.GeneralPage.Controls.Add(this.KeyAbilityBox);
			this.GeneralPage.Controls.Add(this.KeyAbilityLbl);
			this.GeneralPage.Controls.Add(this.PowerSourceBox);
			this.GeneralPage.Controls.Add(this.PowerSourceLbl);
			this.GeneralPage.Controls.Add(this.RoleBox);
			this.GeneralPage.Controls.Add(this.RoleLbl);
			this.GeneralPage.Controls.Add(this.NameBox);
			this.GeneralPage.Controls.Add(this.NameLbl);
			this.GeneralPage.Location = new System.Drawing.Point(4, 22);
			this.GeneralPage.Name = "GeneralPage";
			this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
			this.GeneralPage.Size = new System.Drawing.Size(341, 256);
			this.GeneralPage.TabIndex = 0;
			this.GeneralPage.Text = "General";
			this.GeneralPage.UseVisualStyleBackColor = true;
			// 
			// SurgeBox
			// 
			this.SurgeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SurgeBox.Location = new System.Drawing.Point(94, 224);
			this.SurgeBox.Name = "SurgeBox";
			this.SurgeBox.Size = new System.Drawing.Size(224, 20);
			this.SurgeBox.TabIndex = 13;
			// 
			// SurgeLbl
			// 
			this.SurgeLbl.AutoSize = true;
			this.SurgeLbl.Location = new System.Drawing.Point(6, 226);
			this.SurgeLbl.Name = "SurgeLbl";
			this.SurgeLbl.Size = new System.Drawing.Size(82, 13);
			this.SurgeLbl.TabIndex = 12;
			this.SurgeLbl.Text = "Healing Surges:";
			// 
			// HPSubsequentBox
			// 
			this.HPSubsequentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPSubsequentBox.Location = new System.Drawing.Point(94, 198);
			this.HPSubsequentBox.Name = "HPSubsequentBox";
			this.HPSubsequentBox.Size = new System.Drawing.Size(224, 20);
			this.HPSubsequentBox.TabIndex = 11;
			// 
			// HPSubsequentLbl
			// 
			this.HPSubsequentLbl.AutoSize = true;
			this.HPSubsequentLbl.Location = new System.Drawing.Point(6, 200);
			this.HPSubsequentLbl.Name = "HPSubsequentLbl";
			this.HPSubsequentLbl.Size = new System.Drawing.Size(74, 13);
			this.HPSubsequentLbl.TabIndex = 10;
			this.HPSubsequentLbl.Text = "HP (per level):";
			// 
			// HPFirstBox
			// 
			this.HPFirstBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.HPFirstBox.Location = new System.Drawing.Point(94, 172);
			this.HPFirstBox.Name = "HPFirstBox";
			this.HPFirstBox.Size = new System.Drawing.Size(224, 20);
			this.HPFirstBox.TabIndex = 9;
			// 
			// HPFirstLbl
			// 
			this.HPFirstLbl.AutoSize = true;
			this.HPFirstLbl.Location = new System.Drawing.Point(6, 174);
			this.HPFirstLbl.Name = "HPFirstLbl";
			this.HPFirstLbl.Size = new System.Drawing.Size(75, 13);
			this.HPFirstLbl.TabIndex = 8;
			this.HPFirstLbl.Text = "HP (first level):";
			// 
			// KeyAbilityBox
			// 
			this.KeyAbilityBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.KeyAbilityBox.Location = new System.Drawing.Point(94, 146);
			this.KeyAbilityBox.Name = "KeyAbilityBox";
			this.KeyAbilityBox.Size = new System.Drawing.Size(224, 20);
			this.KeyAbilityBox.TabIndex = 7;
			// 
			// KeyAbilityLbl
			// 
			this.KeyAbilityLbl.AutoSize = true;
			this.KeyAbilityLbl.Location = new System.Drawing.Point(6, 149);
			this.KeyAbilityLbl.Name = "KeyAbilityLbl";
			this.KeyAbilityLbl.Size = new System.Drawing.Size(66, 13);
			this.KeyAbilityLbl.TabIndex = 6;
			this.KeyAbilityLbl.Text = "Key Abilities:";
			// 
			// ProficiencyPage
			// 
			this.ProficiencyPage.Controls.Add(this.SkillBox);
			this.ProficiencyPage.Controls.Add(this.SkillLbl);
			this.ProficiencyPage.Controls.Add(this.DefencesBox);
			this.ProficiencyPage.Controls.Add(this.DefencesLbl);
			this.ProficiencyPage.Controls.Add(this.ImplementBox);
			this.ProficiencyPage.Controls.Add(this.ImplementLbl);
			this.ProficiencyPage.Controls.Add(this.WeaponBox);
			this.ProficiencyPage.Controls.Add(this.WeaponLbl);
			this.ProficiencyPage.Controls.Add(this.ArmourBox);
			this.ProficiencyPage.Controls.Add(this.ArmourLbl);
			this.ProficiencyPage.Location = new System.Drawing.Point(4, 22);
			this.ProficiencyPage.Name = "ProficiencyPage";
			this.ProficiencyPage.Padding = new System.Windows.Forms.Padding(3);
			this.ProficiencyPage.Size = new System.Drawing.Size(341, 256);
			this.ProficiencyPage.TabIndex = 1;
			this.ProficiencyPage.Text = "Proficiencies";
			this.ProficiencyPage.UseVisualStyleBackColor = true;
			// 
			// SkillBox
			// 
			this.SkillBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SkillBox.Location = new System.Drawing.Point(91, 185);
			this.SkillBox.Multiline = true;
			this.SkillBox.Name = "SkillBox";
			this.SkillBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.SkillBox.Size = new System.Drawing.Size(237, 65);
			this.SkillBox.TabIndex = 9;
			// 
			// SkillLbl
			// 
			this.SkillLbl.Location = new System.Drawing.Point(6, 188);
			this.SkillLbl.Name = "SkillLbl";
			this.SkillLbl.Size = new System.Drawing.Size(79, 62);
			this.SkillLbl.TabIndex = 8;
			this.SkillLbl.Text = "Trained Skills:";
			// 
			// DefencesBox
			// 
			this.DefencesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DefencesBox.Location = new System.Drawing.Point(91, 159);
			this.DefencesBox.Name = "DefencesBox";
			this.DefencesBox.Size = new System.Drawing.Size(237, 20);
			this.DefencesBox.TabIndex = 7;
			// 
			// DefencesLbl
			// 
			this.DefencesLbl.AutoSize = true;
			this.DefencesLbl.Location = new System.Drawing.Point(6, 162);
			this.DefencesLbl.Name = "DefencesLbl";
			this.DefencesLbl.Size = new System.Drawing.Size(56, 13);
			this.DefencesLbl.TabIndex = 6;
			this.DefencesLbl.Text = "Defences:";
			// 
			// ImplementBox
			// 
			this.ImplementBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ImplementBox.Location = new System.Drawing.Point(91, 108);
			this.ImplementBox.Multiline = true;
			this.ImplementBox.Name = "ImplementBox";
			this.ImplementBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ImplementBox.Size = new System.Drawing.Size(237, 45);
			this.ImplementBox.TabIndex = 5;
			// 
			// ImplementLbl
			// 
			this.ImplementLbl.Location = new System.Drawing.Point(6, 111);
			this.ImplementLbl.Name = "ImplementLbl";
			this.ImplementLbl.Size = new System.Drawing.Size(79, 42);
			this.ImplementLbl.TabIndex = 4;
			this.ImplementLbl.Text = "Implements:";
			// 
			// WeaponBox
			// 
			this.WeaponBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.WeaponBox.Location = new System.Drawing.Point(91, 57);
			this.WeaponBox.Multiline = true;
			this.WeaponBox.Name = "WeaponBox";
			this.WeaponBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.WeaponBox.Size = new System.Drawing.Size(237, 45);
			this.WeaponBox.TabIndex = 3;
			// 
			// WeaponLbl
			// 
			this.WeaponLbl.Location = new System.Drawing.Point(6, 60);
			this.WeaponLbl.Name = "WeaponLbl";
			this.WeaponLbl.Size = new System.Drawing.Size(79, 42);
			this.WeaponLbl.TabIndex = 2;
			this.WeaponLbl.Text = "Weapon Proficiencies:";
			// 
			// ArmourBox
			// 
			this.ArmourBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ArmourBox.Location = new System.Drawing.Point(91, 6);
			this.ArmourBox.Multiline = true;
			this.ArmourBox.Name = "ArmourBox";
			this.ArmourBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ArmourBox.Size = new System.Drawing.Size(237, 45);
			this.ArmourBox.TabIndex = 1;
			// 
			// ArmourLbl
			// 
			this.ArmourLbl.Location = new System.Drawing.Point(6, 9);
			this.ArmourLbl.Name = "ArmourLbl";
			this.ArmourLbl.Size = new System.Drawing.Size(79, 42);
			this.ArmourLbl.TabIndex = 0;
			this.ArmourLbl.Text = "Armour Proficiencies:";
			// 
			// DescriptionPage
			// 
			this.DescriptionPage.Controls.Add(this.QuoteBox);
			this.DescriptionPage.Controls.Add(this.QuoteLbl);
			this.DescriptionPage.Controls.Add(this.DescBox);
			this.DescriptionPage.Location = new System.Drawing.Point(4, 22);
			this.DescriptionPage.Name = "DescriptionPage";
			this.DescriptionPage.Padding = new System.Windows.Forms.Padding(3);
			this.DescriptionPage.Size = new System.Drawing.Size(341, 256);
			this.DescriptionPage.TabIndex = 2;
			this.DescriptionPage.Text = "Description";
			this.DescriptionPage.UseVisualStyleBackColor = true;
			// 
			// QuoteBox
			// 
			this.QuoteBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.QuoteBox.Location = new System.Drawing.Point(51, 230);
			this.QuoteBox.Name = "QuoteBox";
			this.QuoteBox.Size = new System.Drawing.Size(284, 20);
			this.QuoteBox.TabIndex = 5;
			// 
			// QuoteLbl
			// 
			this.QuoteLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.QuoteLbl.AutoSize = true;
			this.QuoteLbl.Location = new System.Drawing.Point(6, 233);
			this.QuoteLbl.Name = "QuoteLbl";
			this.QuoteLbl.Size = new System.Drawing.Size(39, 13);
			this.QuoteLbl.TabIndex = 4;
			this.QuoteLbl.Text = "Quote:";
			// 
			// DescBox
			// 
			this.DescBox.AcceptsReturn = true;
			this.DescBox.AcceptsTab = true;
			this.DescBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.DescBox.Location = new System.Drawing.Point(6, 6);
			this.DescBox.Multiline = true;
			this.DescBox.Name = "DescBox";
			this.DescBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.DescBox.Size = new System.Drawing.Size(329, 218);
			this.DescBox.TabIndex = 3;
			// 
			// OverviewPage
			// 
			this.OverviewPage.Controls.Add(this.RacesBox);
			this.OverviewPage.Controls.Add(this.RacesLbl);
			this.OverviewPage.Controls.Add(this.ReligionBox);
			this.OverviewPage.Controls.Add(this.ReligionLbl);
			this.OverviewPage.Controls.Add(this.CharacteristicsBox);
			this.OverviewPage.Controls.Add(this.CharacteristicsLbl);
			this.OverviewPage.Location = new System.Drawing.Point(4, 22);
			this.OverviewPage.Name = "OverviewPage";
			this.OverviewPage.Padding = new System.Windows.Forms.Padding(3);
			this.OverviewPage.Size = new System.Drawing.Size(341, 256);
			this.OverviewPage.TabIndex = 3;
			this.OverviewPage.Text = "Overview";
			this.OverviewPage.UseVisualStyleBackColor = true;
			// 
			// RacesBox
			// 
			this.RacesBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.RacesBox.Location = new System.Drawing.Point(91, 199);
			this.RacesBox.Multiline = true;
			this.RacesBox.Name = "RacesBox";
			this.RacesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.RacesBox.Size = new System.Drawing.Size(237, 51);
			this.RacesBox.TabIndex = 5;
			// 
			// RacesLbl
			// 
			this.RacesLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.RacesLbl.AutoSize = true;
			this.RacesLbl.Location = new System.Drawing.Point(6, 202);
			this.RacesLbl.Name = "RacesLbl";
			this.RacesLbl.Size = new System.Drawing.Size(41, 13);
			this.RacesLbl.TabIndex = 4;
			this.RacesLbl.Text = "Races:";
			// 
			// ReligionBox
			// 
			this.ReligionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.ReligionBox.Location = new System.Drawing.Point(91, 142);
			this.ReligionBox.Multiline = true;
			this.ReligionBox.Name = "ReligionBox";
			this.ReligionBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.ReligionBox.Size = new System.Drawing.Size(237, 51);
			this.ReligionBox.TabIndex = 3;
			// 
			// ReligionLbl
			// 
			this.ReligionLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ReligionLbl.AutoSize = true;
			this.ReligionLbl.Location = new System.Drawing.Point(6, 145);
			this.ReligionLbl.Name = "ReligionLbl";
			this.ReligionLbl.Size = new System.Drawing.Size(48, 13);
			this.ReligionLbl.TabIndex = 2;
			this.ReligionLbl.Text = "Religion:";
			// 
			// CharacteristicsBox
			// 
			this.CharacteristicsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CharacteristicsBox.Location = new System.Drawing.Point(91, 6);
			this.CharacteristicsBox.Multiline = true;
			this.CharacteristicsBox.Name = "CharacteristicsBox";
			this.CharacteristicsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.CharacteristicsBox.Size = new System.Drawing.Size(237, 130);
			this.CharacteristicsBox.TabIndex = 1;
			// 
			// CharacteristicsLbl
			// 
			this.CharacteristicsLbl.AutoSize = true;
			this.CharacteristicsLbl.Location = new System.Drawing.Point(6, 9);
			this.CharacteristicsLbl.Name = "CharacteristicsLbl";
			this.CharacteristicsLbl.Size = new System.Drawing.Size(79, 13);
			this.CharacteristicsLbl.TabIndex = 0;
			this.CharacteristicsLbl.Text = "Characteristics:";
			// 
			// LevelPage
			// 
			this.LevelPage.Controls.Add(this.LevelList);
			this.LevelPage.Controls.Add(this.LevelToolbar);
			this.LevelPage.Location = new System.Drawing.Point(4, 22);
			this.LevelPage.Name = "LevelPage";
			this.LevelPage.Padding = new System.Windows.Forms.Padding(3);
			this.LevelPage.Size = new System.Drawing.Size(341, 256);
			this.LevelPage.TabIndex = 4;
			this.LevelPage.Text = "Levels";
			this.LevelPage.UseVisualStyleBackColor = true;
			// 
			// LevelList
			// 
			this.LevelList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LevelHdr});
			this.LevelList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LevelList.FullRowSelect = true;
			listViewGroup5.Header = "Class Features";
			listViewGroup5.Name = "listViewGroup1";
			listViewGroup6.Header = "Heroic Tier";
			listViewGroup6.Name = "listViewGroup2";
			listViewGroup7.Header = "Paragon Tier";
			listViewGroup7.Name = "listViewGroup3";
			listViewGroup8.Header = "Epic Tier";
			listViewGroup8.Name = "listViewGroup4";
			this.LevelList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup5,
            listViewGroup6,
            listViewGroup7,
            listViewGroup8});
			this.LevelList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LevelList.HideSelection = false;
			this.LevelList.Location = new System.Drawing.Point(3, 28);
			this.LevelList.MultiSelect = false;
			this.LevelList.Name = "LevelList";
			this.LevelList.Size = new System.Drawing.Size(335, 225);
			this.LevelList.TabIndex = 1;
			this.LevelList.UseCompatibleStateImageBehavior = false;
			this.LevelList.View = System.Windows.Forms.View.Details;
			this.LevelList.DoubleClick += new System.EventHandler(this.EditBtn_Click);
			// 
			// LevelHdr
			// 
			this.LevelHdr.Text = "Level";
			this.LevelHdr.Width = 300;
			// 
			// LevelToolbar
			// 
			this.LevelToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditBtn});
			this.LevelToolbar.Location = new System.Drawing.Point(3, 3);
			this.LevelToolbar.Name = "LevelToolbar";
			this.LevelToolbar.Size = new System.Drawing.Size(335, 25);
			this.LevelToolbar.TabIndex = 0;
			this.LevelToolbar.Text = "toolStrip1";
			// 
			// EditBtn
			// 
			this.EditBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.EditBtn.Image = ((System.Drawing.Image)(resources.GetObject("EditBtn.Image")));
			this.EditBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.EditBtn.Name = "EditBtn";
			this.EditBtn.Size = new System.Drawing.Size(31, 22);
			this.EditBtn.Text = "Edit";
			this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
			// 
			// OptionClassForm
			// 
			this.AcceptButton = this.OKBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelBtn;
			this.ClientSize = new System.Drawing.Size(373, 335);
			this.Controls.Add(this.Pages);
			this.Controls.Add(this.CancelBtn);
			this.Controls.Add(this.OKBtn);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionClassForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Class";
			this.Pages.ResumeLayout(false);
			this.GeneralPage.ResumeLayout(false);
			this.GeneralPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SurgeBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HPSubsequentBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HPFirstBox)).EndInit();
			this.ProficiencyPage.ResumeLayout(false);
			this.ProficiencyPage.PerformLayout();
			this.DescriptionPage.ResumeLayout(false);
			this.DescriptionPage.PerformLayout();
			this.OverviewPage.ResumeLayout(false);
			this.OverviewPage.PerformLayout();
			this.LevelPage.ResumeLayout(false);
			this.LevelPage.PerformLayout();
			this.LevelToolbar.ResumeLayout(false);
			this.LevelToolbar.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button CancelBtn;
		private System.Windows.Forms.Label NameLbl;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label RoleLbl;
		private System.Windows.Forms.TextBox RoleBox;
		private System.Windows.Forms.Label PowerSourceLbl;
		private System.Windows.Forms.TextBox PowerSourceBox;
		private System.Windows.Forms.TabControl Pages;
		private System.Windows.Forms.TabPage GeneralPage;
		private System.Windows.Forms.TabPage ProficiencyPage;
		private System.Windows.Forms.TextBox KeyAbilityBox;
		private System.Windows.Forms.Label KeyAbilityLbl;
		private System.Windows.Forms.TextBox ImplementBox;
		private System.Windows.Forms.Label ImplementLbl;
		private System.Windows.Forms.TextBox WeaponBox;
		private System.Windows.Forms.Label WeaponLbl;
		private System.Windows.Forms.Label ArmourLbl;
		private System.Windows.Forms.TextBox ArmourBox;
		private System.Windows.Forms.NumericUpDown SurgeBox;
		private System.Windows.Forms.Label SurgeLbl;
		private System.Windows.Forms.NumericUpDown HPSubsequentBox;
		private System.Windows.Forms.Label HPSubsequentLbl;
		private System.Windows.Forms.NumericUpDown HPFirstBox;
		private System.Windows.Forms.Label HPFirstLbl;
		private System.Windows.Forms.TextBox SkillBox;
		private System.Windows.Forms.Label SkillLbl;
		private System.Windows.Forms.TabPage DescriptionPage;
		private System.Windows.Forms.TabPage OverviewPage;
		private System.Windows.Forms.TabPage LevelPage;
		private System.Windows.Forms.TextBox RacesBox;
		private System.Windows.Forms.Label RacesLbl;
		private System.Windows.Forms.TextBox ReligionBox;
		private System.Windows.Forms.Label ReligionLbl;
		private System.Windows.Forms.Label CharacteristicsLbl;
		private System.Windows.Forms.TextBox CharacteristicsBox;
		private System.Windows.Forms.ListView LevelList;
		private System.Windows.Forms.ColumnHeader LevelHdr;
		private System.Windows.Forms.ToolStrip LevelToolbar;
		private System.Windows.Forms.ToolStripButton EditBtn;
		private System.Windows.Forms.TextBox DefencesBox;
		private System.Windows.Forms.Label DefencesLbl;
		private System.Windows.Forms.TextBox QuoteBox;
		private System.Windows.Forms.Label QuoteLbl;
		private System.Windows.Forms.TextBox DescBox;
	}
}