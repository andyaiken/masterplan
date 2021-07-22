using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class PowerForm : Form
	{
		public PowerForm(CreaturePower power, bool functional_template, bool unused)
		{
			InitializeComponent();

			Pages.TabPages.Remove(AdvicePage);

			RangeBox.Items.Add("Melee");
			RangeBox.Items.Add("Melee Touch");
			RangeBox.Items.Add("Melee Weapon");
            RangeBox.Items.Add("Melee N");
            RangeBox.Items.Add("Reach N");
            RangeBox.Items.Add("Ranged N");
			RangeBox.Items.Add("Close Blast N");
			RangeBox.Items.Add("Close Burst N");
			RangeBox.Items.Add("Area Burst N within N");
			RangeBox.Items.Add("Personal");

			fPower = power.Copy();
			fFunctionalTemplate = functional_template;

			NameBox.Text = fPower.Name;
			KeywordBox.Text = fPower.Keywords;
			ConditionBox.Text = fPower.Condition;
			update_action();
			update_attack();
			RangeBox.Text = fPower.Range;
			DetailsBox.Text = fPower.Details;
			DescBox.Text = fPower.Description;
		}

		public CreaturePower Power
		{
			get { return fPower; }
		}
		CreaturePower fPower = null;

		int fLevel = 0;
		IRole fRole = null;

		bool fFunctionalTemplate = false;

		public void ShowAdvicePage(int level, IRole role)
		{
			fLevel = level;
			fRole = role;

			Pages.TabPages.Add(AdvicePage);
			update_advice();
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fPower.Name = NameBox.Text;
			fPower.Keywords = KeywordBox.Text;
			fPower.Condition = ConditionBox.Text;
			fPower.Range = RangeBox.Text;
			fPower.Details = DetailsBox.Text;
			fPower.Description = DescBox.Text;
		}

		private void ActionBtn_Click(object sender, EventArgs e)
		{
			PowerAction pa = fPower.Action;
			if (pa == null)
				pa = new PowerAction();

			PowerActionForm dlg = new PowerActionForm(pa);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPower.Action = dlg.Action;
				update_action();
				update_advice();
			}
		}

		private void AttackBtn_Click(object sender, EventArgs e)
		{
			PowerAttack pa = fPower.Attack;
			if (pa == null)
				pa = new PowerAttack();

			PowerAttackForm dlg = new PowerAttackForm(pa, fFunctionalTemplate, 0, null);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPower.Attack = dlg.Attack;
				update_attack();
				update_advice();
			}
		}

		private void ActionClearLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			fPower.Action = null;

			update_action();
			update_advice();
		}

		private void AttackClearLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			fPower.Attack = null;

			update_attack();
			update_advice();
		}

		void update_action()
		{
			ActionBtn.Text = (fPower.Action != null) ? fPower.Action.ToString() : "(not defined)";
			ActionClearLbl.Enabled = (fPower.Action != null);
		}

		void update_attack()
		{
			AttackBtn.Text = (fPower.Attack != null) ? fPower.Attack.ToString() : "(not defined)";
			AttackClearLbl.Enabled = (fPower.Attack != null);
		}

		void update_advice()
		{
			if (!Pages.TabPages.Contains(AdvicePage))
				return;

			AdviceList.Items.Clear();

			if ((fPower.Attack != null) && (fPower.Action != null))
			{
				AdviceList.ShowGroups = true;

				// Attack advice

				string defence = (fPower.Attack.Defence == DefenceType.AC) ? "AC" : "non-AC defence";
				ListViewItem lvi_attack = new ListViewItem("Attack vs " + defence + ": ");
				lvi_attack.SubItems.Add("+" + Statistics.AttackBonus(fPower.Attack.Defence, fLevel, fRole));
				lvi_attack.Group = AdviceList.Groups[0];
				AdviceList.Items.Add(lvi_attack);

				// Damage advice

				if (fRole is ComplexRole)
				{
					ListViewItem lvi_dmg = new ListViewItem("Damage:");
					lvi_dmg.SubItems.Add(Statistics.NormalDamage(fLevel));
					lvi_dmg.Group = AdviceList.Groups[1];
					AdviceList.Items.Add(lvi_dmg);
				}
				else if (fRole is Minion)
				{
					ListViewItem lvi_minion = new ListViewItem("Minion damage:");
					lvi_minion.SubItems.Add(Statistics.MinionDamage(fLevel).ToString());
					lvi_minion.Group = AdviceList.Groups[1];
					AdviceList.Items.Add(lvi_minion);
				}
			}

			if (AdviceList.Items.Count == 0)
			{
				AdviceList.ShowGroups = false;

				ListViewItem lvi = new ListViewItem("(no advice)");
				lvi.ForeColor = SystemColors.GrayText;
				AdviceList.Items.Add(lvi);
			}
		}
	}
}
