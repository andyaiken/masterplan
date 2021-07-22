using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class EffectListForm : Form
	{
		public EffectListForm(Encounter enc, CombatData current_actor, int current_round)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fEncounter = enc;
			fCurrentActor = current_actor;
			fCurrentRound = current_round;

			update_list();
		}

		~EffectListForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedEffect != null);
			EditBtn.Enabled = (SelectedEffect != null);
		}

		Encounter fEncounter = null;
		CombatData fCurrentActor = null;
		int fCurrentRound = int.MinValue;

		public Pair<CombatData, OngoingCondition> SelectedEffect
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return EffectList.SelectedItems[0].Tag as Pair<CombatData, OngoingCondition>;

				return null;
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				CombatData cd = SelectedEffect.First;
				OngoingCondition oc = SelectedEffect.Second;

				cd.Conditions.Remove(oc);
				update_list();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				CombatData cd = SelectedEffect.First;
				OngoingCondition oc = SelectedEffect.Second;

				int index = cd.Conditions.IndexOf(oc);

				EffectForm dlg = new EffectForm(oc, fEncounter, fCurrentActor, fCurrentRound);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					cd.Conditions[index] = dlg.Effect;
					update_list();
				}
			}
		}

		void update_list()
		{
			EffectList.Groups.Clear();
			EffectList.Items.Clear();

			foreach (Hero hero in Session.Project.Heroes)
			{
				CombatData cd = hero.CombatData;

				if (cd.Conditions.Count > 0)
					add_conditions(cd);
			}

			foreach (EncounterSlot slot in fEncounter.Slots)
			{
				foreach (CombatData cd in slot.CombatData)
				{
					if (cd.Conditions.Count > 0)
						add_conditions(cd);
				}
			}
		}

		void add_conditions(CombatData cd)
		{
			ListViewGroup lvg = EffectList.Groups.Add(cd.DisplayName, cd.DisplayName);

			foreach (OngoingCondition oc in cd.Conditions)
			{
				ListViewItem lvi = EffectList.Items.Add(oc.ToString(fEncounter, false));
				lvi.Tag = new Pair<CombatData, OngoingCondition>(cd, oc);
				lvi.Group = lvg;
			}
		}
	}
}
