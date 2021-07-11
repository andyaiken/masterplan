using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class EndedEffectsForm : Form
	{
		public EndedEffectsForm(List<Pair<CombatData, OngoingCondition>> conditions, Encounter enc)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fEndedConditions = conditions;
			fExtendedConditions = new List<Pair<CombatData, OngoingCondition>>();
			fEncounter = enc;

			update_list();
		}

		~EndedEffectsForm()
		{
			Application.Idle -= Application_Idle;
		}

		public Pair<CombatData, OngoingCondition> SelectedCondition
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return EffectList.SelectedItems[0].Tag as Pair<CombatData, OngoingCondition>;

				return null;
			}
		}

		public List<Pair<CombatData, OngoingCondition>> EndedConditions
		{
			get { return fEndedConditions; }
			set { fEndedConditions = value; }
		}
		List<Pair<CombatData, OngoingCondition>> fEndedConditions = null;

		public List<Pair<CombatData, OngoingCondition>> ExtendedConditions
		{
			get { return fExtendedConditions; }
			set { fExtendedConditions = value; }
		}
		List<Pair<CombatData, OngoingCondition>> fExtendedConditions = null;

		Encounter fEncounter = null;

		void Application_Idle(object sender, EventArgs e)
		{
			ExtendBtn.Enabled = (SelectedCondition != null);

			if (SelectedCondition != null)
			{
				if (fEndedConditions.Contains(SelectedCondition))
					ExtendBtn.Text = "Extend this effect";
				else
					ExtendBtn.Text = "End this effect";
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			foreach (Pair<CombatData, OngoingCondition> pair in fEndedConditions)
				pair.First.Conditions.Remove(pair.Second);
		}

		private void ExtendBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCondition == null)
				return;

			if (fEndedConditions.Contains(SelectedCondition))
			{
				fEndedConditions.Remove(SelectedCondition);
				fExtendedConditions.Add(SelectedCondition);
			}
			else if (fExtendedConditions.Contains(SelectedCondition))
			{
				fExtendedConditions.Remove(SelectedCondition);
				fEndedConditions.Add(SelectedCondition);
			}

			update_list();
		}

		void update_list()
		{
			EffectList.Items.Clear();

			foreach (Pair<CombatData, OngoingCondition> condition in fEndedConditions)
			{
				ListViewItem lvi = EffectList.Items.Add(condition.First.ToString());
				lvi.SubItems.Add(condition.Second.ToString(fEncounter, false));
				lvi.Group = EffectList.Groups[0];
				lvi.Tag = condition;
			}

			if (fEndedConditions.Count == 0)
			{
				ListViewItem lvi = EffectList.Items.Add("(none)");
				lvi.Group = EffectList.Groups[0];
				lvi.ForeColor = SystemColors.GrayText;
			}

			foreach (Pair<CombatData, OngoingCondition> condition in fExtendedConditions)
			{
				ListViewItem lvi = EffectList.Items.Add(condition.First.ToString());
				lvi.SubItems.Add(condition.Second.ToString(fEncounter, false));
				lvi.Group = EffectList.Groups[1];
				lvi.Tag = condition;
			}

			if (fExtendedConditions.Count == 0)
			{
				ListViewItem lvi = EffectList.Items.Add("(none)");
				lvi.Group = EffectList.Groups[1];
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
