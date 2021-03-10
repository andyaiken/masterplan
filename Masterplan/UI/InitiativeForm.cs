using System;
using System.Windows.Forms;
using Masterplan.Data;

namespace Masterplan.UI
{
	partial class InitiativeForm : Form
	{
		public InitiativeForm(int bonus, int score)
		{
			InitializeComponent();

			if (bonus >= 0)
				BonusValueLbl.Text = "+" + bonus;
			else
				BonusValueLbl.Text = bonus.ToString();

			if (score == int.MinValue)
				score = bonus + 1;

			InitBox.Value = score;
		}

		public int Score
		{
			get { return (int)InitBox.Value; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		private void InitiativeForm_Shown(object sender, EventArgs e)
		{
			int length = 1;
			if (InitBox.Value >= 10)
				length = 2;
			if (InitBox.Value >= 100)
				length = 3;

			InitBox.Select(0, length);
		}
	}
}
