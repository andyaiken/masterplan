using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CampaignSettingsForm : Form
	{
		public CampaignSettingsForm(CampaignSettings settings)
		{
			InitializeComponent();

			fSettings = settings;

			HPBox.Value = (int)(fSettings.HP * 100);
			XPBox.Value = (int)(fSettings.XP * 100);
			AttackBox.Value = fSettings.AttackBonus;
			DamageBox.Value = (int)(fSettings.Damage*100);
			ACBox.Value = fSettings.ACBonus;
			DefenceBox.Value = fSettings.NADBonus;
		}

		CampaignSettings fSettings = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fSettings.HP = (double)HPBox.Value / 100;
			fSettings.XP = (double)XPBox.Value / 100;
			fSettings.AttackBonus = (int)AttackBox.Value;
			fSettings.Damage = (double)DamageBox.Value/100.0;
			fSettings.ACBonus = (int)ACBox.Value;
			fSettings.NADBonus = (int)DefenceBox.Value;
		}
	}
}
