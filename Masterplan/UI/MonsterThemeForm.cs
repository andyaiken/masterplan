using System;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
    partial class MonsterThemeForm : Form
    {
        public MonsterThemeForm(MonsterTheme theme)
        {
            InitializeComponent();

            Application.Idle += new EventHandler(Application_Idle);

            fTheme = theme.Copy();

            foreach (string skill_name in Skills.GetSkillNames())
            {
                ListViewItem lvi = SkillList.Items.Add(skill_name);

                bool present = false;
                foreach (Pair<string, int> pair in fTheme.SkillBonuses)
                {
                    if (pair.First == skill_name)
                        present = true;
                }
                lvi.Checked = present;
            }

            NameBox.Text = fTheme.Name;

            update_powers();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            PowerRemoveBtn.Enabled = (SelectedPower != null);
            PowerEditBtn.Enabled = (SelectedPower != null);
        }

        public MonsterTheme Theme
        {
            get { return fTheme; }
        }
        MonsterTheme fTheme = null;

        private void OKBtn_Click(object sender, EventArgs e)
        {
            fTheme.Name = NameBox.Text;

            fTheme.SkillBonuses.Clear();
            foreach (ListViewItem lvi in SkillList.CheckedItems)
                fTheme.SkillBonuses.Add(new Pair<string, int>(lvi.Text, 2));
        }

        public ThemePowerData SelectedPower
        {
            get
            {
                if (PowerList.SelectedItems.Count != 0)
                    return PowerList.SelectedItems[0].Tag as ThemePowerData;

                return null;
            }
        }

        private void PowerAddBtn_Click(object sender, EventArgs e)
        {
            CreaturePower power = new CreaturePower();
            power.Name = "New Power";

            //PowerForm dlg = new PowerForm(power, false);
			PowerBuilderForm dlg = new PowerBuilderForm(power, null, false);
            if (dlg.ShowDialog() == DialogResult.OK)
                add_power(dlg.Power);
        }

        private void PowerBrowse_Click(object sender, EventArgs e)
        {
            PowerBrowserForm dlg = new PowerBrowserForm(NameBox.Text, 0, null, add_power);
            dlg.ShowDialog();
        }

        void add_power(CreaturePower power)
        {
            ThemePowerData tpd = new ThemePowerData();
            tpd.Power = power;

            fTheme.Powers.Add(tpd);
            update_powers();
        }

        private void PowerRemoveBtn_Click(object sender, EventArgs e)
        {
            if (SelectedPower != null)
            {
                fTheme.Powers.Remove(SelectedPower);
                update_powers();
            }
        }

        private void PowerEditBtn_Click(object sender, EventArgs e)
        {
            if (SelectedPower != null)
            {
                int index = fTheme.Powers.IndexOf(SelectedPower);

                //PowerForm dlg = new PowerForm(SelectedPower.Power, false);
				PowerBuilderForm dlg = new PowerBuilderForm(SelectedPower.Power, null, false);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fTheme.Powers[index].Power = dlg.Power;
                    update_powers();
                }
            }
        }

		private void EditClassification_Click(object sender, EventArgs e)
		{
			if (SelectedPower != null)
			{
				int index = fTheme.Powers.IndexOf(SelectedPower);

				MonsterThemePowerForm dlg = new MonsterThemePowerForm(SelectedPower);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fTheme.Powers[index] = dlg.Power;
					update_powers();
				}
			}
		}

        void update_powers()
        {
            PowerList.ShowGroups = true;

            PowerList.Items.Clear();
            foreach (ThemePowerData p in fTheme.Powers)
            {
                string role_str = "";
				if (p.Roles.Count == 6)
				{
					role_str = "(any)";
				}
				else
				{
					foreach (RoleType rt in p.Roles)
					{
						if (role_str != "")
							role_str += ", ";

						role_str += rt.ToString();
					}
				}

                ListViewItem lvi = PowerList.Items.Add(p.Power.Name);
                lvi.SubItems.Add(role_str);
                lvi.Tag = p;

				switch (p.Type)
				{
					case PowerType.Attack:
						lvi.Group = PowerList.Groups[0];
						break;
					case PowerType.Utility:
						lvi.Group = PowerList.Groups[1];
						break;
				}
            }

            if (PowerList.Items.Count == 0)
            {
                PowerList.ShowGroups = false;

                ListViewItem lvi = PowerList.Items.Add("(no powers)");
                lvi.ForeColor = SystemColors.GrayText;
            }
        }
    }
}
