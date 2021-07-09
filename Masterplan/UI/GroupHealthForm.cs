using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class GroupHealthForm : Form
	{
		public GroupHealthForm()
		{
			InitializeComponent();

			fPlaceholder.Text = "Select a PC from the list to set its current HP";
			fPlaceholder.TextAlign = ContentAlignment.MiddleCenter;
			fPlaceholder.Dock = DockStyle.Fill;
			HPPanel.Controls.Add(fPlaceholder);
			fPlaceholder.BringToFront();

			update_list();
		}

		public Hero SelectedHero
		{
			get
			{
				if (CombatantList.SelectedItems.Count != 0)
					return CombatantList.SelectedItems[0].Tag as Hero;

				return null;
			}
		}

		bool fUpdating = false;
		Label fPlaceholder = new Label();

		private void CombatantList_SelectedIndexChanged(object sender, EventArgs e)
		{
			fUpdating = true;

			update_hp_panel();

			fUpdating = false;

			//if (SelectedHero != null)
			//{
			//    int index = Session.Project.Heroes.IndexOf(SelectedHero);
			//    HeroHPForm dlg = new HeroHPForm(SelectedHero);
			//    if (dlg.ShowDialog() == DialogResult.OK)
			//    {
			//        Session.Project.Heroes[index] = dlg.Hero;
			//        Session.Modified = true;

			//        update_list();
			//    }
			//}
		}

		private void CombatantList_DoubleClick(object sender, EventArgs e)
		{
		}

		private void MaxHPBox_ValueChanged(object sender, EventArgs e)
		{
			if (fUpdating)
				return;

			SelectedHero.HP = (int)MaxHPBox.Value;
			Session.Modified = true;

			CurrentHPBox.Maximum = SelectedHero.HP;

			update_hp_panel();
			update_list_hp(SelectedHero);
		}

		private void CurrentHPBox_ValueChanged(object sender, EventArgs e)
		{
			if (fUpdating)
				return;

			int damage = SelectedHero.HP - (int)CurrentHPBox.Value;

			SelectedHero.CombatData.Damage = damage;
			Session.Modified = true;

			update_hp_panel();
			update_list_hp(SelectedHero);
		}

		private void TempHPBox_ValueChanged(object sender, EventArgs e)
		{
			if (fUpdating)
				return;

			SelectedHero.CombatData.TempHP = (int)TempHPBox.Value;
			Session.Modified = true;

			update_hp_panel();
			update_list_hp(SelectedHero);
		}

		private void FullHealBtn_Click(object sender, EventArgs e)
		{
			if (SelectedHero != null)
			{
				SelectedHero.CombatData.Damage = 0;
				Session.Modified = true;

				update_hp_panel();
				update_list_hp(SelectedHero);
			}
		}

		void update_list()
		{
			CombatantList.Items.Clear();

			foreach (Hero hero in Session.Project.Heroes)
			{
				if (hero.HP == 0)
					continue;

				ListViewItem lvi = CombatantList.Items.Add(hero.Name);
				lvi.SubItems.Add("");
				lvi.Tag = hero;
			}

			foreach (Hero hero in Session.Project.Heroes)
				update_list_hp(hero);
		}

		void update_hp_panel()
		{
			if (SelectedHero != null)
			{
				fPlaceholder.Visible = false;

				HeroNameLbl.Text = SelectedHero.Name;

				MaxHPBox.Value = SelectedHero.HP;
				CurrentHPBox.Value = SelectedHero.HP - SelectedHero.CombatData.Damage;
				TempHPBox.Value = SelectedHero.CombatData.TempHP;

				HPGauge.FullHP = SelectedHero.HP;
				HPGauge.Damage = SelectedHero.CombatData.Damage;
				HPGauge.TempHP = SelectedHero.CombatData.TempHP;

				FullHealBtn.Enabled = (SelectedHero.CombatData.Damage != 0);
			}
			else
			{
				fPlaceholder.Visible = true;
			}
		}

		void update_list_hp(Hero hero)
		{
			string str = hero.HP.ToString();
			if (hero.CombatData.Damage > 0)
			{
				int current = hero.HP - hero.CombatData.Damage;
				str = current + " / " + hero.HP;
			}
			if (hero.CombatData.TempHP > 0)
				str += " (+" + hero.CombatData.TempHP + ")";

			ListViewItem hero_lvi = null;
			foreach (ListViewItem lvi in CombatantList.Items)
			{
				if (lvi.Tag == hero)
				{
					hero_lvi = lvi;
					break;
				}
			}
			if (hero_lvi != null)
				hero_lvi.SubItems[1].Text = str;
		}
	}
}
