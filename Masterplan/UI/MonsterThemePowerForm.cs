using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class MonsterThemePowerForm : Form
	{
		public MonsterThemePowerForm(ThemePowerData power)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			Array types = Enum.GetValues(typeof(PowerType));
			foreach (PowerType type in types)
				TypeBox.Items.Add(type);

			fPower = power.Copy();

			TypeBox.SelectedItem = fPower.Type;

			ArtilleryBox.Checked = fPower.Roles.Contains(RoleType.Artillery);
			BruteBox.Checked = fPower.Roles.Contains(RoleType.Brute);
			ControllerBox.Checked = fPower.Roles.Contains(RoleType.Controller);
			LurkerBox.Checked = fPower.Roles.Contains(RoleType.Lurker);
			SkirmisherBox.Checked = fPower.Roles.Contains(RoleType.Skirmisher);
			SoldierBox.Checked = fPower.Roles.Contains(RoleType.Soldier);
		}

		~MonsterThemePowerForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			List<RoleType> roles = get_roles();
			OKBtn.Enabled = (roles.Count != 0);
		}

		public ThemePowerData Power
		{
			get { return fPower; }
		}
		ThemePowerData fPower = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fPower.Type = (PowerType)TypeBox.SelectedItem;
			fPower.Roles = get_roles();
		}

		List<RoleType> get_roles()
		{
			List<RoleType> roles = new List<RoleType>();

			if (ArtilleryBox.Checked)
				roles.Add(RoleType.Artillery);

			if (BruteBox.Checked)
				roles.Add(RoleType.Brute);

			if (ControllerBox.Checked)
				roles.Add(RoleType.Controller);

			if (LurkerBox.Checked)
				roles.Add(RoleType.Lurker);

			if (SkirmisherBox.Checked)
				roles.Add(RoleType.Skirmisher);

			if (SoldierBox.Checked)
				roles.Add(RoleType.Soldier);

			return roles;
		}
	}
}
