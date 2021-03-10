using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OngoingDamageForm : Form
	{
		public OngoingDamageForm(CombatData data, EncounterCard card, Encounter enc)
		{
			InitializeComponent();

			fData = data;
			fCard = card;
			fEncounter = enc;

			Text = "Ongoing Damage: " + fData.DisplayName;

			update_list();
		}

		CombatData fData = null;
		EncounterCard fCard = null;
		Encounter fEncounter = null;

		int fTotalDamage = 0;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			int damage_remaining = fTotalDamage;

			if (fData.TempHP > 0)
			{
				int delta = Math.Min(damage_remaining, fData.TempHP);
				fData.TempHP -= delta;
				damage_remaining -= delta;
			}

			fData.Damage += damage_remaining;
		}

		private void update_list()
		{
			DamageList.Items.Clear();
			fTotalDamage = 0;

			foreach (OngoingCondition oc in fData.Conditions)
			{
				if (oc.Type != OngoingType.Damage)
					continue;

				int value = oc.Value;
				DamageModifier dm = find_damage_modifier(oc.DamageType);
				if (dm != null)
				{
					if (dm.Value == 0)
						value = 0;
					else
					{
						value += dm.Value;
						value = Math.Max(value, 0);
					}
				}

				ListViewItem lvi = DamageList.Items.Add(oc.ToString(fEncounter, false));
				lvi.SubItems.Add((dm != null) ? dm.ToString() : "");
				lvi.SubItems.Add(value.ToString());
				lvi.Tag = oc;
				lvi.Group = DamageList.Groups[0];

				fTotalDamage += value;
			}

			ListViewItem lvi_total = DamageList.Items.Add("Total");
			lvi_total.SubItems.Add("");
			lvi_total.SubItems.Add(fTotalDamage.ToString());
			lvi_total.Group = DamageList.Groups[1];
			lvi_total.Font = new Font(Font, Font.Style | FontStyle.Bold);

			if (fData.Conditions.Count == 0)
			{
				ListViewItem lvi = DamageList.Items.Add("(no damage)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		DamageModifier find_damage_modifier(DamageType type)
		{
			if (fCard == null)
				return null;

			List<DamageType> types = new List<DamageType>();
			types.Add(type);
			int value = fCard.GetDamageModifier(types, fData);

			if (value == 0)
			{
				// No modifier
				return null;
			}

			if (value == int.MinValue)
			{
				// Immune
				value = 0;
			}

			DamageModifier mod = new DamageModifier();
			mod.Type = type;
			mod.Value = value;

			return mod;
		}
	}
}
