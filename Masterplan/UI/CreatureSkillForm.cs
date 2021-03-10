using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
	partial class CreatureSkillForm : Form
	{
		public CreatureSkillForm(string skill_name, string ability_name, int ability_bonus, int level_bonus, bool trained, int misc_bonus)
		{
			InitializeComponent();

			fAbility = ability_bonus;
			fLevel = level_bonus;

			Text = skill_name;
			AbilityNameLbl.Text = ability_name + " bonus:";
			AbilityBonusLbl.Text = fAbility.ToString();
			LevelBonusLbl.Text = fLevel.ToString();
			TrainedBox.Checked = trained;
			MiscBox.Value = misc_bonus;

			update_total();
		}

		int fAbility = 0;
		int fLevel = 0;

		public bool Trained { get { return TrainedBox.Checked; } }
		public int Misc { get { return (int)MiscBox.Value; } }

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		void update_total()
		{
			int training = TrainedBox.Checked ? 5 : 0;
			int total = fAbility + fLevel + training + Misc;

			TrainingBonusLbl.Text = TrainedBox.Checked ? "5" : "";
			TotalBonusLbl.Text = total.ToString();
		}

		private void TrainedBox_CheckedChanged(object sender, EventArgs e)
		{
			update_total();
		}

		private void MiscBox_ValueChanged(object sender, EventArgs e)
		{
			update_total();
		}
	}
}
