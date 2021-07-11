using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class AttackRollForm : Form
	{
		public AttackRollForm(CreaturePower power, Encounter enc)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fPower = power;
			fEncounter = enc;
			//fHeroData = hero_data;

			add_attack_roll(null);

			update_damage();
			RollDamageBtn_Click(null, null);
		}

		~AttackRollForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ApplyDamageBox.Visible = fAddedCombatant;
		}

		CreaturePower fPower = null;
		Encounter fEncounter = null;
		//Dictionary<Guid, CombatData> fHeroData = null;

		bool fAddedCombatant = false;

		List<Pair<CombatData, int>> fRolls = new List<Pair<CombatData, int>>();

		public Pair<CombatData, int> SelectedRoll
		{
			get
			{
				if (RollList.SelectedItems.Count != 0)
					return RollList.SelectedItems[0].Tag as Pair<CombatData, int>;

				return null;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if (ApplyDamageBox.Visible && ApplyDamageBox.Checked)
				apply_damage();
		}

		private void PowerBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "opponent")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				CombatData cd = fEncounter.FindCombatData(id);

				add_attack_roll(cd);
			}

			if (e.Url.Scheme == "hero")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				Hero hero = Session.Project.FindHero(id);
				//CombatData cd = fHeroData[id];
				if (hero != null)
				{
					CombatData cd = hero.CombatData;

					add_attack_roll(cd);
				}
			}

			if (e.Url.Scheme == "target")
			{
				e.Cancel = true;

				add_attack_roll(null);
			}
		}

		private void RollList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedRoll != null)
			{
				int roll = Session.Dice(1, 20);
				SelectedRoll.Second = roll;
				update_list();
			}
		}

		private void RollDamageBtn_Click(object sender, EventArgs e)
		{
			DiceExpression exp = DiceExpression.Parse(DamageExpLbl.Text);
			if (exp != null)
			{
				int roll = exp.Evaluate();
				DamageBox.Value = roll;
			}
		}

		private void DamageBox_ValueChanged(object sender, EventArgs e)
		{
			int roll = (int)DamageBox.Value;
			int miss = roll / 2;
			MissValueLbl.Text = miss.ToString();
		}

		void update_power()
		{
			List<string> lines = new List<string>();

			lines.AddRange(HTML.GetHead(fPower.Name, "", Session.Preferences.TextSize));

			lines.Add("<BODY>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");
			lines.AddRange(fPower.AsHTML(null, CardMode.View, false));
			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("<P class=instruction align=left>");
			lines.Add("Click to add an attack roll for:");
			string heroes = "";
			foreach (Hero hero in Session.Project.Heroes)
			{
				//CombatData cd = fHeroData[hero.ID];
				CombatData cd = hero.CombatData;

				if ((!roll_exists(hero.ID)) && (hero.GetState(cd.Damage) != CreatureState.Defeated))
				{
					if (heroes != "")
						heroes += " | ";

					heroes += "<A href=hero:" + hero.ID + ">" + hero.Name + "</A>";
				}
			}
			if (heroes != "")
			{
				lines.Add("<BR>");
				lines.Add(heroes);
			}
			string creatures = "";
			foreach (EncounterSlot slot in fEncounter.Slots)
			{
				foreach (CombatData cd in slot.CombatData)
				{
					if ((!roll_exists(cd.ID)) && (slot.GetState(cd) != CreatureState.Defeated))
					{
						if (creatures != "")
							creatures += " | ";

						creatures += "<A href=opponent:" + cd.ID + ">" + cd.DisplayName + "</A>";
					}
				}
			}
			if (creatures != "")
			{
				lines.Add("<BR>");
				lines.Add(creatures);
			}
			lines.Add("<BR>");
			lines.Add("<A href=target:blank>An unnamed target</A>");
			lines.Add("</P>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			PowerBrowser.DocumentText = HTML.Concatenate(lines);
		}

		void update_list()
		{
			RollList.Items.Clear();

			foreach (Pair<CombatData, int> roll in fRolls)
			{
				int die = roll.Second;
				int bonus = (fPower.Attack != null) ? fPower.Attack.Bonus : 0;
				int total = die + bonus;

				ListViewItem lvi = RollList.Items.Add(roll.First != null ? roll.First.DisplayName : "Roll");
				lvi.SubItems.Add(die.ToString());
				lvi.SubItems.Add(bonus.ToString());
				lvi.SubItems.Add(total.ToString());

				bool hit = true;
				if ((roll.First != null) && (fPower.Attack != null))
				{
					// Work out whether we've hit the defence
					int defence = 0;
					Hero hero = Session.Project.FindHero(roll.First.ID);
					if (hero != null)
					//if (fHeroData.ContainsKey(roll.First.ID))
					{
						//Hero hero = Session.Project.FindHero(roll.First.ID);

						switch (fPower.Attack.Defence)
						{
							case DefenceType.AC:
								defence = hero.AC;
								break;
							case DefenceType.Fortitude:
								defence = hero.Fortitude;
								break;
							case DefenceType.Reflex:
								defence = hero.Reflex;
								break;
							case DefenceType.Will:
								defence = hero.Will;
								break;
						}
					}
					else
					{
						EncounterSlot slot = fEncounter.FindSlot(roll.First);

						switch (fPower.Attack.Defence)
						{
							case DefenceType.AC:
								defence = slot.Card.AC;
								break;
							case DefenceType.Fortitude:
								defence = slot.Card.Fortitude;
								break;
							case DefenceType.Reflex:
								defence = slot.Card.Reflex;
								break;
							case DefenceType.Will:
								defence = slot.Card.Will;
								break;
						}
					}

					// Take account of defence-boosting conditions
					foreach (OngoingCondition oc in roll.First.Conditions)
					{
						if (oc.Type != OngoingType.DefenceModifier)
							continue;

						if (oc.Defences.Contains(fPower.Attack.Defence))
							defence += oc.DefenceMod;
					}

					hit = (total >= defence);
				}

				if (die == 20)
					lvi.Font = new Font(lvi.Font, lvi.Font.Style | FontStyle.Bold);
				else if (die == 1)
					lvi.ForeColor = Color.Red;
				else if (!hit)
					lvi.ForeColor = SystemColors.GrayText;

				lvi.Tag = roll;
			}
		}

		void update_damage()
		{
			string dmg_str = fPower.Damage;
			if (dmg_str == "")
			{
				Pages.TabPages.Remove(DamagePage);
			}
			else
			{
				DiceExpression exp = DiceExpression.Parse(dmg_str);
				
				DamageExpLbl.Text = dmg_str;
				CritValueLbl.Text = exp.Maximum.ToString();
			}
		}

		void add_attack_roll(CombatData cd)
		{
			if (cd != null)
			{
				if ((fRolls.Count == 1) && (fRolls[0].First == null))
					fRolls.Clear();
			}

			int roll = Session.Dice(1, 20);
			fRolls.Add(new Pair<CombatData, int>(cd, roll));

			if (cd != null)
				fAddedCombatant = true;

			update_list();
			update_power();
		}

		bool roll_exists(Guid id)
		{
			foreach (Pair<CombatData, int> roll in fRolls)
			{
				if ((roll.First != null) && (roll.First.ID == id))
					return true;
			}

			return false;
		}

		void apply_damage()
		{
			foreach (ListViewItem lvi in RollList.Items)
			{
				Pair<CombatData, int> roll = lvi.Tag as Pair<CombatData, int>;
				if (roll.First == null)
					continue;

				int damage = 0;
				if (roll.Second == 20)
				{
					damage = int.Parse(CritValueLbl.Text);
				}
				else if (lvi.ForeColor == SystemColors.WindowText)
				{
					// Hit
					damage = (int)DamageBox.Value;
				}
				else
				{
					// Miss
					// TODO: Does the power do half damage on a miss?
					// Remember that minions are unaffected by this
				}

				if (damage == 0)
					continue;

				// Determine damage type(s)
				Array array = Enum.GetValues(typeof(DamageType));
				List<DamageType> types = new List<DamageType>();
				foreach (DamageType type in array)
				{
					string details = fPower.Details.ToLower();
					string dmg = type.ToString().ToLower();
					if (details.Contains(dmg))
						types.Add(type);
				}

				EncounterSlot slot = fEncounter.FindSlot(roll.First);
				EncounterCard card = (slot != null) ? slot.Card : null;

				DamageForm.DoDamage(roll.First, card, damage, types, false);
			}
		}
	}
}
