using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class ThemeForm : Form
	{
		public ThemeForm(EncounterCard card)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			Browser.DocumentText = "";

			fCard = card.Copy();

			if (fCard.ThemeID != Guid.Empty)
			{
				MonsterTheme mt = Session.FindTheme(fCard.ThemeID, SearchType.Global);
				update_selected_theme(mt, false);

				ThemePowerData attack = mt.FindPower(fCard.ThemeAttackPowerID);
				AttackBox.SelectedItem = attack;

				ThemePowerData utility = mt.FindPower(fCard.ThemeUtilityPowerID);
				UtilityBox.SelectedItem = utility;
			}
			else
			{
				update_selected_theme(null, true);
			}
		}

		void Application_Idle(object sender, EventArgs e)
		{
			SelectThemeBtn.Enabled = (Session.Themes.Count != 0);
			ClearThemeBtn.Enabled = (fCard.ThemeID != Guid.Empty);
		}

		public EncounterCard Card
		{
			get { return fCard; }
		}
		EncounterCard fCard = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			//
		}

		private void SelectThemeBtn_Click(object sender, EventArgs e)
		{
			MonsterThemeSelectForm dlg = new MonsterThemeSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
				update_selected_theme(dlg.MonsterTheme, true);
		}

		private void CreateThemeBtn_Click(object sender, EventArgs e)
		{
			MonsterTheme mt = new MonsterTheme();
			mt.Name = "New Theme";

			MonsterThemeForm dlg = new MonsterThemeForm(mt);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Library.Themes.Add(dlg.Theme);
				Session.Modified = true;

				update_selected_theme(dlg.Theme, true);
			}
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			update_selected_theme(null, true);
		}

		private void AttackBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ThemePowerData tpd = AttackBox.SelectedItem as ThemePowerData;
			fCard.ThemeAttackPowerID = (tpd != null) ? tpd.Power.ID : Guid.Empty;

			update_browser();
		}

		private void UtilityBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ThemePowerData tpd = UtilityBox.SelectedItem as ThemePowerData;
			fCard.ThemeUtilityPowerID = (tpd != null) ? tpd.Power.ID : Guid.Empty;

			update_browser();
		}

		void update_selected_theme(MonsterTheme theme, bool reset_powers)
		{
			if (theme != null)
			{
				ThemeNameLbl.Text = theme.Name;
				fCard.ThemeID = theme.ID;
			}
			else
			{
				ThemeNameLbl.Text = "None";
				fCard.ThemeID = Guid.Empty;
			}

			AttackBox.Items.Clear();
			AttackBox.Items.Add("(no attack power)");

			UtilityBox.Items.Clear();
			UtilityBox.Items.Add("(no utility power)");

			if (theme != null)
			{
				List<ThemePowerData> attacks = theme.ListPowers(fCard.Roles, PowerType.Attack);
				foreach (ThemePowerData tpd in attacks)
					AttackBox.Items.Add(tpd);

				List<ThemePowerData> utilities = theme.ListPowers(fCard.Roles, PowerType.Utility);
				foreach (ThemePowerData tpd in utilities)
					UtilityBox.Items.Add(tpd);
			}

			if (reset_powers)
			{
				AttackBox.SelectedIndex = 0;
				UtilityBox.SelectedIndex = 0;
			}

			AttackBox.Enabled = (AttackBox.Items.Count > 1);
			UtilityBox.Enabled = (UtilityBox.Items.Count > 1);

			update_browser();
		}

		void update_browser()
		{
			Browser.Document.OpenNew(true);
			Browser.Document.Write(HTML.StatBlock(fCard, null, null, true, false, true, CardMode.View, Session.Preferences.TextSize));
		}
	}
}
