using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class RechargeForm : Form
	{
		public RechargeForm(CombatData data, EncounterCard card)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fData = data;
			fCard = card;

			Text = "Power Recharging: " + fData.DisplayName;

			foreach (Guid power_id in fData.UsedPowers)
			{
				CreaturePower power = get_power(power_id);
				if ((power == null) || (power.Action == null) || (power.Action.Recharge == ""))
					continue;

				fRolls[power_id] = Session.Dice(1, 6);
			}

			update_list();
		}

		~RechargeForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RollBtn.Enabled = (SelectedPowerID != Guid.Empty);

			if (SelectedPowerID == Guid.Empty)
			{
				SavedBtn.Enabled = false;
				NotSavedBtn.Enabled = false;
			}
			else
			{
				int roll = fRolls[SelectedPowerID];

				SavedBtn.Enabled = (roll != int.MaxValue);
				NotSavedBtn.Enabled = (roll != int.MinValue);
			}
		}

		CombatData fData = null;
		EncounterCard fCard = null;

		Dictionary<Guid, int> fRolls = new Dictionary<Guid, int>();

		public Guid SelectedPowerID
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return (Guid)EffectList.SelectedItems[0].Tag;

				return Guid.Empty;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			List<Guid> obsolete = new List<Guid>();
			foreach (Guid power_id in fRolls.Keys)
			{
				if (!fRolls.ContainsKey(power_id))
					continue;

				int roll = fRolls[power_id];

				CreaturePower power = get_power(power_id);
				if ((power == null) || (power.Action == null) || (power.Action.Recharge == ""))
					continue;

				int min = get_minimum(power.Action.Recharge);
				if ((min != 0) && (roll >= min))
					obsolete.Add(power_id);
			}
			foreach (Guid power_id in obsolete)
			{
				fData.UsedPowers.Remove(power_id);
			}
		}

		private void RollBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPowerID != Guid.Empty)
			{
				fRolls[SelectedPowerID] = Session.Dice(1, 6);
				update_list();
			}
		}

		private void SavedBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPowerID != Guid.Empty)
			{
				fRolls[SelectedPowerID] = int.MaxValue;
				update_list();
			}
		}

		private void NotSavedBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPowerID != Guid.Empty)
			{
				fRolls[SelectedPowerID] = int.MinValue;
				update_list();
			}
		}

		private void update_list()
		{
			Guid selection = SelectedPowerID;

			EffectList.BeginUpdate();
			EffectList.Items.Clear();
			foreach (Guid power_id in fData.UsedPowers)
			{
				if (!fRolls.ContainsKey(power_id))
					continue;

				CreaturePower power = get_power(power_id);
				if (power == null)
					continue;

				int roll = fRolls[power_id];

				ListViewItem lvi = EffectList.Items.Add(power.Name);
				lvi.SubItems.Add(power.Action.Recharge);
				lvi.Tag = power.ID;
				if (power_id == selection)
					lvi.Selected = true;

				if (roll == int.MinValue)
				{
					lvi.SubItems.Add("-");
					lvi.SubItems.Add("Not recharged");
				}
				else if (roll == int.MaxValue)
				{
					lvi.SubItems.Add("-");
					lvi.SubItems.Add("Recharged");
					lvi.ForeColor = SystemColors.GrayText;
				}
				else
				{
					int min = get_minimum(power.Action.Recharge);
					if (min == int.MaxValue)
					{
						lvi.SubItems.Add("Not rolled");
						lvi.SubItems.Add("Not rolled");
					}
					else
					{
						lvi.SubItems.Add(roll.ToString());

						if (roll >= min)
						{
							lvi.SubItems.Add("Recharged");
							lvi.ForeColor = SystemColors.GrayText;
						}
						else
						{
							lvi.SubItems.Add("Not recharged");
						}
					}
				}
			}

			if (EffectList.Items.Count == 0)
			{
				ListViewItem lvi = EffectList.Items.Add("(no rechargable powers)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			EffectList.EndUpdate();
		}

		CreaturePower get_power(Guid power_id)
		{
			List<CreaturePower> powers = fCard.CreaturePowers;
			foreach (CreaturePower power in powers)
			{
				if (power.ID == power_id)
					return power;
			}

			return null;
		}

		int get_minimum(string recharge_str)
		{
			int min = int.MaxValue;

			if (recharge_str.Contains("6"))
				min = 6;

			if (recharge_str.Contains("5"))
				min = 5;

			if (recharge_str.Contains("4"))
				min = 4;

			if (recharge_str.Contains("3"))
				min = 3;

			if (recharge_str.Contains("2"))
				min = 2;

			return min;
		}
	}
}
