using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionRitualForm : Form
	{
		public OptionRitualForm(Ritual ritual)
		{
			InitializeComponent();

			Array cats = Enum.GetValues(typeof(RitualCategory));
			foreach (RitualCategory cat in cats)
				CatBox.Items.Add(cat);

			fRitual = ritual.Copy();

			NameBox.Text = fRitual.Name;
			LevelBox.Value = fRitual.Level;
			CatBox.SelectedItem = fRitual.Category;

			TimeBox.Text = fRitual.Time;
			DurationBox.Text = fRitual.Duration;
			ComponentBox.Text = fRitual.ComponentCost;
			MarketBox.Text = fRitual.MarketPrice;
			SkillBox.Text = fRitual.KeySkill;

			DetailsBox.Text = fRitual.Details;
			ReadAloudBox.Text = fRitual.ReadAloud;
		}

		public Ritual Ritual
		{
			get { return fRitual; }
		}
		Ritual fRitual = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fRitual.Name = NameBox.Text;

			fRitual.Level = (int)LevelBox.Value;
			fRitual.Category = (RitualCategory)CatBox.SelectedItem;

			fRitual.Time = TimeBox.Text;
			fRitual.Duration = DurationBox.Text;
			fRitual.ComponentCost = ComponentBox.Text;
			fRitual.MarketPrice = MarketBox.Text;
			fRitual.KeySkill = SkillBox.Text;

			fRitual.Details = DetailsBox.Text;
			fRitual.ReadAloud = ReadAloudBox.Text;
		}

		private void CatBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			RitualCategory cat = (RitualCategory)CatBox.SelectedItem;

			SkillBox.Items.Clear();
			switch (cat)
			{
				case RitualCategory.Binding:
					SkillBox.Items.Add("Arcana");
					SkillBox.Items.Add("Religion");
					break;
				case RitualCategory.Creation:
					SkillBox.Items.Add("Arcana");
					SkillBox.Items.Add("Religion");
					break;
				case RitualCategory.Deception:
					SkillBox.Items.Add("Arcana");
					break;
				case RitualCategory.Divination:
					SkillBox.Items.Add("Arcana");
					SkillBox.Items.Add("Nature");
					SkillBox.Items.Add("Religion");
					break;
				case RitualCategory.Exploration:
					SkillBox.Items.Add("Arcana");
					SkillBox.Items.Add("Nature");
					SkillBox.Items.Add("Religion");
					break;
				case RitualCategory.Restoration:
					SkillBox.Items.Add("Heal");
					break;
				case RitualCategory.Scrying:
					SkillBox.Items.Add("Arcana");
					break;
				case RitualCategory.Travel:
					SkillBox.Items.Add("Arcana");
					break;
				case RitualCategory.Warding:
					SkillBox.Items.Add("Arcana");
					break;
			}
		}
	}
}
