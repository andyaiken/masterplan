using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class GroupInitiativeForm : Form
	{
		public GroupInitiativeForm(Dictionary<string, List<CombatData>> combatants, Encounter enc)
		{
			InitializeComponent();

			fCombatants = combatants;
			fEncounter = enc;

			update_list();
		}

		public Dictionary<string, List<CombatData>> Combatants
		{
			get { return fCombatants; }
		}
		Dictionary<string, List<CombatData>> fCombatants = null;

		Encounter fEncounter = null;

		public List<CombatData> SelectedCombatantGroup
		{
			get
			{
				if (CombatantList.SelectedItems.Count != 0)
					return CombatantList.SelectedItems[0].Tag as List<CombatData>;

				return null;
			}
		}

		private void CombatantList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedCombatantGroup != null)
			{
				int bonus = 0;

				CombatData cd = SelectedCombatantGroup[0];
				EncounterSlot slot = fEncounter.FindSlot(cd);
				if (slot != null)
				{
					bonus = slot.Card.Initiative;
				}
				else
				{
					// Hero or trap

					Hero hero = Session.Project.FindHero(cd.ID);
					if (hero != null)
						bonus = hero.InitBonus;

					Trap trap = fEncounter.FindTrap(cd.ID);
					if (trap != null)
						bonus = trap.Initiative;
				}

				InitiativeForm dlg = new InitiativeForm(bonus, cd.Initiative);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (CombatData data in SelectedCombatantGroup)
						data.Initiative = dlg.Score;

					update_list();
				}
			}
		}

		void update_list()
		{
			CombatantList.Items.Clear();

			foreach (string str in fCombatants.Keys)
			{
				ListViewItem lvi = CombatantList.Items.Add(str);

				List<CombatData> list = fCombatants[str];
				CombatData cd = list[0];
				if (cd.Initiative == int.MinValue)
				{
					ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add("(not set)");
					lvsi.ForeColor = SystemColors.GrayText;
				}
				else
				{
					lvi.SubItems.Add(cd.Initiative.ToString());
				}

				lvi.UseItemStyleForSubItems = false;
				lvi.Tag = list;
			}
		}
	}
}
