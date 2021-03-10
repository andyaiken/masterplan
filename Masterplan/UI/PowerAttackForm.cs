using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class PowerAttackForm : Form
	{
		public PowerAttackForm(PowerAttack attack, bool functional_template, int level, IRole role)
		{
			InitializeComponent();

			Array defences = Enum.GetValues(typeof(DefenceType));
			foreach (DefenceType defence in defences)
				DefenceBox.Items.Add(defence);

			Application.Idle += new EventHandler(Application_Idle);

			fAttack = attack.Copy();
			fFunctionalTemplate = functional_template;
			fLevel = level;
			fRole = role;

			BonusBox.Value = fAttack.Bonus;
			DefenceBox.SelectedItem = fAttack.Defence;

			set_suggestion();

			if (!fFunctionalTemplate)
			{
				InfoLbl.Visible = false;
				Height -= InfoLbl.Height;
			}
		}

		void Application_Idle(object sender, EventArgs e)
		{
			DefenceType dt = (DefenceType)DefenceBox.SelectedItem;
			int suggested = Statistics.AttackBonus(dt, fLevel, fRole);
			int current = (int)BonusBox.Value;

			SuggestBtn.Enabled = (current != suggested);
		}

		public PowerAttack Attack
		{
			get { return fAttack; }
		}
		PowerAttack fAttack = null;

		bool fFunctionalTemplate = false;
		int fLevel = 0;
		IRole fRole = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fAttack.Bonus = (int)BonusBox.Value;
			fAttack.Defence = (DefenceType)DefenceBox.SelectedItem;
		}

		private void SuggestBtn_Click(object sender, EventArgs e)
		{
			DefenceType dt = (DefenceType)DefenceBox.SelectedItem;
			BonusBox.Value = Statistics.AttackBonus(dt, fLevel, fRole);
		}

		private void DefenceBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			set_suggestion();
		}

		void set_suggestion()
		{
			DefenceType dt = (DefenceType)DefenceBox.SelectedItem;
			int bonus = Statistics.AttackBonus(dt, fLevel, fRole);
			SuggestBtn.Text = (bonus >= 0) ? "+" + bonus : bonus.ToString();

			if (fFunctionalTemplate)
				SuggestBtn.Text = "Level " + SuggestBtn.Text;
		}
	}
}
