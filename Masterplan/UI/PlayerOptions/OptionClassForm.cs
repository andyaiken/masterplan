using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionClassForm : Form
	{
		public OptionClassForm(Class c)
		{
			InitializeComponent();

			fClass = c.Copy();

			NameBox.Text = fClass.Name;
			RoleBox.Text = fClass.Role;
			PowerSourceBox.Text = fClass.PowerSource;
			KeyAbilityBox.Text = fClass.KeyAbilities;
			HPFirstBox.Value = fClass.HPFirst;
			HPSubsequentBox.Value = fClass.HPSubsequent;
			SurgeBox.Value = fClass.HealingSurges;

			ArmourBox.Text = fClass.ArmourProficiencies;
			WeaponBox.Text = fClass.WeaponProficiencies;
			ImplementBox.Text = fClass.Implements;
			DefencesBox.Text = fClass.DefenceBonuses;
			SkillBox.Text = fClass.TrainedSkills;

			DescBox.Text = fClass.Description;
			QuoteBox.Text = fClass.Quote;

			CharacteristicsBox.Text = fClass.OverviewCharacteristics;
			ReligionBox.Text = fClass.OverviewReligion;
			RacesBox.Text = fClass.OverviewRaces;

			update_levels();
		}

		public Class Class
		{
			get { return fClass; }
		}
		Class fClass = null;

		public LevelData SelectedLevel
		{
			get
			{
				if (LevelList.SelectedItems.Count != 0)
					return LevelList.SelectedItems[0].Tag as LevelData;

				return null;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fClass.Name = NameBox.Text;
			fClass.Role = RoleBox.Text;
			fClass.PowerSource = PowerSourceBox.Text;
			fClass.KeyAbilities = KeyAbilityBox.Text;
			fClass.HPFirst = (int)HPFirstBox.Value;
			fClass.HPSubsequent = (int)HPSubsequentBox.Value;
			fClass.HealingSurges = (int)SurgeBox.Value;

			fClass.ArmourProficiencies = ArmourBox.Text;
			fClass.WeaponProficiencies = WeaponBox.Text;
			fClass.Implements = ImplementBox.Text;
			fClass.DefenceBonuses = DefencesBox.Text;
			fClass.TrainedSkills = SkillBox.Text;

			fClass.Description = DescBox.Text;
			fClass.Quote = QuoteBox.Text;

			fClass.OverviewCharacteristics = CharacteristicsBox.Text;
			fClass.OverviewReligion = ReligionBox.Text;
			fClass.OverviewRaces = RacesBox.Text;
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLevel != null)
			{
				int index = fClass.Levels.IndexOf(SelectedLevel);
				bool class_features = (index == -1);

				OptionLevelForm dlg = new OptionLevelForm(SelectedLevel, class_features);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					if (class_features)
						fClass.FeatureData = dlg.Level;
					else
						fClass.Levels[index] = dlg.Level;

					update_levels();
				}
			}
		}

		void update_levels()
		{
			LevelList.Items.Clear();

			add_level(fClass.FeatureData);

			foreach (LevelData ld in fClass.Levels)
				add_level(ld);
		}

		void add_level(LevelData ld)
		{
			ListViewItem lvi = LevelList.Items.Add(ld.ToString());
			lvi.Tag = ld;

			if (ld.Count == 0)
				lvi.ForeColor = SystemColors.GrayText;

			if (ld == fClass.FeatureData)
			{
				lvi.Group = LevelList.Groups[0];
			}
			else
			{
				int tier = (ld.Level - 1) / 10;
				lvi.Group = LevelList.Groups[tier + 1];
			}
		}
	}
}
