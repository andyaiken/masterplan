using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CombatantSelectForm : Form
	{
		public CombatantSelectForm(Encounter enc, Dictionary<Guid, CombatData> traps)
		{
			InitializeComponent();

			foreach (EncounterSlot slot in enc.Slots)
			{
				foreach (CombatData cd in slot.CombatData)
				{
					ListViewItem lvi = CombatantList.Items.Add(cd.DisplayName);
					lvi.Tag = cd;
					lvi.Group = CombatantList.Groups[1];
				}
			}
			foreach (Hero hero in Session.Project.Heroes)
			//foreach (CombatData hero in heroes.Values)
			{
				ListViewItem lvi = CombatantList.Items.Add(hero.Name);
				lvi.Tag = hero.CombatData;
				lvi.Group = CombatantList.Groups[0];
			}
			foreach (CombatData trap in traps.Values)
			{
				ListViewItem lvi = CombatantList.Items.Add(trap.DisplayName);
				lvi.Tag = trap;
				lvi.Group = CombatantList.Groups[2];
			}

			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (SelectedCombatant != null);
		}

        public CombatData SelectedCombatant
		{
			get
			{
				if (CombatantList.SelectedItems.Count != 0)
					return CombatantList.SelectedItems[0].Tag as CombatData;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedCombatant != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
