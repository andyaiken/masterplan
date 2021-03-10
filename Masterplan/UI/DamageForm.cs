using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	internal partial class DamageForm : Form
	{
		public class Token
		{
			public Token(CombatData data, EncounterCard card)
			{
				Data = data;
				Card = card;
			}

			public CombatData Data = null;
			public EncounterCard Card = null;
			public int Modifier = 0;
		}

		public DamageForm(List<Pair<CombatData, EncounterCard>> tokens, int value)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fData = new List<Token>();
			foreach (Pair<CombatData, EncounterCard> token in tokens)
				fData.Add(new Token(token.First, token.Second));

			DmgBox.Value = value;

			if ((fData.Count == 1) && (fData[0].Card != null))
				HalveBtn.Checked = fData[0].Card.Resist.ToLower().Contains("insubstantial");

			update_type();
			update_modifier();
			update_value();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ResetBtn.Enabled = (DmgBox.Value != 0);

			AcidBtn.Checked = fTypes.Contains(DamageType.Acid);
			ColdBtn.Checked = fTypes.Contains(DamageType.Cold);
			FireBtn.Checked = fTypes.Contains(DamageType.Fire);
			ForceBtn.Checked = fTypes.Contains(DamageType.Force);
			LightningBtn.Checked = fTypes.Contains(DamageType.Lightning);
			NecroticBtn.Checked = fTypes.Contains(DamageType.Necrotic);
			PoisonBtn.Checked = fTypes.Contains(DamageType.Poison);
			PsychicBtn.Checked = fTypes.Contains(DamageType.Psychic);
			RadiantBtn.Checked = fTypes.Contains(DamageType.Radiant);
			ThunderBtn.Checked = fTypes.Contains(DamageType.Thunder);

			TypeLbl.Enabled = (fTypes.Count != 0);
			TypeBox.Enabled = (fTypes.Count != 0);
			ModLbl.Enabled = (fTypes.Count != 0);
			ModBox.Enabled = (fTypes.Count != 0);
		}

		List<Token> fData = null;

		public List<DamageType> Types
		{
			get { return fTypes; }
		}
		List<DamageType> fTypes = new List<DamageType>();

		private void DamageForm_Shown(object sender, EventArgs e)
		{
			DmgBox.Select(0, 1);
		}

		private void DmgBox_ValueChanged(object sender, EventArgs e)
		{
			update_value();
		}

		private void HalveBtn_CheckedChanged(object sender, EventArgs e)
		{
			update_value();
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			foreach (Token token in fData)
				DoDamage(token.Data, token.Card, (int)DmgBox.Value, fTypes, HalveBtn.Checked);
		}

		internal static void DoDamage(CombatData data, EncounterCard card, int damage, List<DamageType> types, bool halve_damage)
		{
			int modifier = 0;
			if (card != null)
				modifier = card.GetDamageModifier(types, data);

			int value = get_value(damage, modifier, halve_damage);

			// Take damage off temp HP first
			if (data.TempHP > 0)
			{
				int n = Math.Min(data.TempHP, value);

				data.TempHP -= n;
				value -= n;
			}

			data.Damage += value;
		}

		void update_type()
		{
			string str = "";
			foreach (DamageType dt in fTypes)
			{
				if (str != "")
					str += ", ";

				str += dt.ToString();
			}
			if (str == "")
				str = "(untyped)";
			TypeBox.Text = str;
		}

		void update_modifier()
		{
			foreach (Token token in fData)
			{
				if (token.Card != null)
					token.Modifier = token.Card.GetDamageModifier(fTypes, token.Data);
			}

			if (fData.Count == 1)
			{
				Token token = fData[0];

				if (token.Modifier == int.MinValue)
				{
					ModBox.Text = "Immune";
				}
				else if (token.Modifier > 0)
				{
					ModBox.Text = "Vulnerable " + token.Modifier;
				}
				else if (token.Modifier < 0)
				{
					ModBox.Text = "Resist " + Math.Abs(token.Modifier);
				}
				else
				{
					ModBox.Text = "(none)";
				}
			}
			else
			{
				ModBox.Text = "(multiple tokens)";
			}
		}

		void update_value()
		{
			if (fData.Count == 1)
			{
				int value = get_value((int)DmgBox.Value, fData[0].Modifier, HalveBtn.Checked);
				ValBox.Text = value.ToString();
			}
			else
			{
				ValBox.Text = "(multiple tokens)";
			}
		}

		static int get_value(int initial_value, int modifier, bool halve_damage)
		{
			int value = initial_value;

			if (modifier != 0)
			{
				if (modifier == int.MinValue)
				{
					value = 0;
				}
				else
				{
					value += modifier;
					value = Math.Max(value, 0);
				}
			}

			if (halve_damage)
				value /= 2;

			return value;
		}

		#region Amounts

		private void Dmg1_Click(object sender, EventArgs e)
		{
			damage(1);
		}

		private void Dmg2_Click(object sender, EventArgs e)
		{
			damage(2);
		}

		private void Dmg5_Click(object sender, EventArgs e)
		{
			damage(5);
		}

		private void Dmg10_Click(object sender, EventArgs e)
		{
			damage(10);
		}

		private void Dmg20_Click(object sender, EventArgs e)
		{
			damage(20);
		}

		private void Dmg50_Click(object sender, EventArgs e)
		{
			damage(50);
		}

		private void Dmg100_Click(object sender, EventArgs e)
		{
			damage(100);
		}

		void damage(int n)
		{
			DmgBox.Value += n;
		}

		private void ResetBtn_Click(object sender, EventArgs e)
		{
			DmgBox.Value = 0;
		}

		#endregion

		#region Types

		private void AcidBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Acid);
		}

		private void ColdBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Cold);
		}

		private void FireBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Fire);
		}

		private void ForceBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Force);
		}

		private void LightningBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Lightning);
		}

		private void NecroticBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Necrotic);
		}

		private void PoisonBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Poison);
		}

		private void PsychicBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Psychic);
		}

		private void RadiantBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Radiant);
		}

		private void ThunderBtn_Click(object sender, EventArgs e)
		{
			add_type(DamageType.Thunder);
		}

		void add_type(DamageType type)
		{
			if (fTypes.Contains(type))
			{
				fTypes.Remove(type);
			}
			else
			{
				fTypes.Add(type);
				fTypes.Sort();
			}

			update_type();
			update_modifier();
			update_value();
		}

		#endregion
	}
}
