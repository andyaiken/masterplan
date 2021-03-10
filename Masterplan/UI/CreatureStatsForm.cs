using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CreatureStatsForm : Form
	{
		public CreatureStatsForm(ICreature c)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fCreature = c;

			if ((fCreature.Role != null) && (fCreature.Role is Minion))
			{
				HPBox.Value = 1;
				HPGroup.Enabled = false;
			}
			else
			{
				HPBox.Value = fCreature.HP;
			}

			InitBox.Value = fCreature.Initiative;
			ACBox.Value = fCreature.AC;
			FortBox.Value = fCreature.Fortitude;
			RefBox.Value = fCreature.Reflex;
			WillBox.Value = fCreature.Will;

			update_recommendations();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			HPRecBtn.Enabled = (HPBox.Value != fHP);
			InitRecBtn.Enabled = (InitBox.Value != fInit);
			ACRecBtn.Enabled = (ACBox.Value != fAC);
			FortRecBtn.Enabled = (FortBox.Value != fNAD);
			RefRecBtn.Enabled = (RefBox.Value != fNAD);
			WillRecBtn.Enabled = (WillBox.Value != fNAD);

			DefaultBtn.Enabled = (HPRecBtn.Enabled || InitRecBtn.Enabled || ACRecBtn.Enabled || FortRecBtn.Enabled || RefRecBtn.Enabled || WillRecBtn.Enabled);
		}

		public ICreature Creature
		{
			get { return fCreature; }
		}
		ICreature fCreature = null;

		int fHP = 0;
		int fInit = 0;
		int fAC = 0;
		int fNAD = 0;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if (fCreature.Role is ComplexRole)
			{
				fCreature.HP = (int)HPBox.Value;
			}
			else
			{
				// Minion
			}

			fCreature.Initiative = (int)InitBox.Value;
			fCreature.AC = (int)ACBox.Value;
			fCreature.Fortitude = (int)FortBox.Value;
			fCreature.Reflex = (int)RefBox.Value;
			fCreature.Will = (int)WillBox.Value;
		}

		void update_recommendations()
		{
			bool minion = ((fCreature.Role != null) && (fCreature.Role is Minion));

			fHP = (minion) ? 1 : Statistics.HP(fCreature.Level, fCreature.Role as ComplexRole, fCreature.Constitution.Score);
			fInit = Statistics.Initiative(fCreature.Level, fCreature.Role);
			fAC = Statistics.AC(fCreature.Level, fCreature.Role);
			fNAD = Statistics.NAD(fCreature.Level, fCreature.Role);

			HPRecBtn.Text = (minion) ? "-" : "Recommended: " + fHP;
			InitRecBtn.Text = "Recommended: " + fInit;
			ACRecBtn.Text = "Recommended: " + fAC;
			FortRecBtn.Text = "Recommended: " + fNAD;
			RefRecBtn.Text = "Recommended: " + fNAD;
			WillRecBtn.Text = "Recommended: " + fNAD;
		}

		private void DefaultBtn_Click(object sender, EventArgs e)
		{
			HPBox.Value = fHP;
			InitBox.Value = fInit;
			ACBox.Value = fAC;
			FortBox.Value = fNAD;
			RefBox.Value = fNAD;
			WillBox.Value = fNAD;
		}

		private void HPRecBtn_Click(object sender, EventArgs e)
		{
			HPBox.Value = fHP;
		}

		private void InitRecBtn_Click(object sender, EventArgs e)
		{
			InitBox.Value = fInit;
		}

		private void ACRecBtn_Click(object sender, EventArgs e)
		{
			ACBox.Value = fAC;
		}

		private void FortRecBtn_Click(object sender, EventArgs e)
		{
			FortBox.Value = fNAD;
		}

		private void RefRecBtn_Click(object sender, EventArgs e)
		{
			RefBox.Value = fNAD;
		}

		private void WillRecBtn_Click(object sender, EventArgs e)
		{
			WillBox.Value = fNAD;
		}
	}
}
