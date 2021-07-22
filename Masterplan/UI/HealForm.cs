using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class HealForm : Form
	{
		public HealForm(List<Pair<CombatData, EncounterCard>> tokens)
		{
			InitializeComponent();

			fTokens = tokens;
		}

		List<Pair<CombatData, EncounterCard>> fTokens = null;

		private void DamageForm_Shown(object sender, EventArgs e)
		{
			SurgeBox.Select(0, 1);
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			int surges = (int)SurgeBox.Value;
			int hp = (int)HPBox.Value;

			foreach (Pair<CombatData, EncounterCard> token in fTokens)
			{
				int max_hp = 0;
				if (token.Second != null)
				{
					// It's a creature
					max_hp = token.Second.HP;
				}
				else
				{
					// It's a hero
					Hero hero = Session.Project.FindHero(token.First.ID);
					if (hero != null)
						max_hp = hero.HP;
				}

				int surge_value = max_hp / 4;
				int heal_value = (surge_value * surges) + hp;

				if (TempHPBox.Checked)
				{
					// Top up temp HP
					token.First.TempHP = Math.Max(heal_value, token.First.TempHP);
				}
				else
				{
					// Start from 0 HP
					if (token.First.Damage > max_hp)
						token.First.Damage = max_hp;

					// Heal
					token.First.Damage -= heal_value;

					// Don't heal past max HP
					if (token.First.Damage < 0)
						token.First.Damage = 0;
				}
			}
		}
	}
}
