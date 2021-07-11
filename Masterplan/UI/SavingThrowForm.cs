using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class SavingThrowForm : Form
	{
		public SavingThrowForm(CombatData data, EncounterCard card, Encounter enc)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fData = data;
			fCard = card;
			fEncounter = enc;

			Text = "Saving Throws: " + fData.DisplayName;

			foreach (OngoingCondition oc in fData.Conditions)
			{
				if (oc.Duration != DurationType.SaveEnds)
					continue;

				int roll = (fCard != null) ? Session.Dice(1, 20) : 0;
				fRolls[oc] = roll;
			}

			int save_modifier = 0;
			if (fCard != null)
			{
				switch (fCard.Flag)
				{
					case RoleFlag.Elite:
						save_modifier = 2;
						break;
					case RoleFlag.Solo:
						save_modifier = 5;
						break;
				}
			}
			ModBox.Value = save_modifier;

			update_list();
		}

		~SavingThrowForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			AddBtn.Enabled = (SelectedEffect != null);
			SubtractBtn.Enabled = (SelectedEffect != null);
			RollBtn.Enabled = (SelectedEffect != null);

			if (SelectedEffect == null)
			{
				SavedBtn.Enabled = false;
				NotSavedBtn.Enabled = false;
			}
			else
			{
				int roll = fRolls[SelectedEffect];

				SavedBtn.Enabled = (roll != int.MaxValue);
				NotSavedBtn.Enabled = (roll != int.MinValue);
			}
		}

		CombatData fData = null;
		EncounterCard fCard = null;
		Encounter fEncounter = null;

		Dictionary<OngoingCondition, int> fRolls = new Dictionary<OngoingCondition, int>();

		public OngoingCondition SelectedEffect
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return EffectList.SelectedItems[0].Tag as OngoingCondition;

				return null;
			}
		}

		private void ModBox_ValueChanged(object sender, EventArgs e)
		{
			update_list();
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			int mod = (int)ModBox.Value;

			List<OngoingCondition> obsolete = new List<OngoingCondition>();
			foreach (OngoingCondition oc in fData.Conditions)
			{
				if (oc.Duration != DurationType.SaveEnds)
					continue;

				int save = fRolls[oc];
				if (save == 0)
					continue;

				int result = save + mod;
				if (result >= 10)
					obsolete.Add(oc);
			}
			foreach (OngoingCondition oc in obsolete)
			{
				fData.Conditions.Remove(oc);
			}
		}

		private void update_list()
		{
			OngoingCondition selection = SelectedEffect;

			EffectList.BeginUpdate();
			EffectList.Items.Clear();
			foreach (OngoingCondition oc in fData.Conditions)
			{
				if (oc.Duration != DurationType.SaveEnds)
					continue;

				int mod = (int)ModBox.Value;
				int roll = fRolls[oc];

				ListViewItem lvi = EffectList.Items.Add(oc.ToString(fEncounter, false));
				lvi.Tag = oc;
				if (oc == selection)
					lvi.Selected = true;

				if (roll == 0)
				{
					lvi.SubItems.Add("(not rolled)");
					lvi.SubItems.Add("(not rolled)");

					lvi.ForeColor = SystemColors.GrayText;
				}
				else if (roll == int.MinValue)
				{
					lvi.SubItems.Add("-");
					lvi.SubItems.Add("Not saved");
				}
				else if (roll == int.MaxValue)
				{
					lvi.SubItems.Add("-");
					lvi.SubItems.Add("Saved");
					lvi.ForeColor = SystemColors.GrayText;
				}
				else
				{
					int result = roll + oc.SavingThrowModifier + mod;

					if (result == roll)
					{
						lvi.SubItems.Add(roll.ToString());
					}
					else
					{
						lvi.SubItems.Add(roll + " => " + result);
					}

					if (result >= 10)
					{
						lvi.SubItems.Add("Saved");
						lvi.ForeColor = SystemColors.GrayText;
					}
					else
					{
						lvi.SubItems.Add("Not saved");
					}
				}
			}

			if (EffectList.Items.Count == 0)
			{
				ListViewItem lvi = EffectList.Items.Add("(no conditions)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			EffectList.EndUpdate();
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				fRolls[SelectedEffect] += 1;
				update_list();
			}
		}

		private void SubtractBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				fRolls[SelectedEffect] -= 1;
				fRolls[SelectedEffect] = Math.Max(fRolls[SelectedEffect], 0);
				update_list();
			}
		}

		private void RollBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				fRolls[SelectedEffect] = Session.Dice(1, 20);
				update_list();
			}
		}

		private void SavedBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				fRolls[SelectedEffect] = int.MaxValue;
				update_list();
			}
		}

		private void NotSavedBtn_Click(object sender, EventArgs e)
		{
			if (SelectedEffect != null)
			{
				fRolls[SelectedEffect] = int.MinValue;
				update_list();
			}
		}
	}
}
