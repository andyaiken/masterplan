using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class EffectForm : Form
	{
		const string ENCOUNTER = "Lasts until the end of the encounter";
		const string SAVE_ENDS = "Save ends";
		const string START = "Lasts until the start of someone's next turn";
		const string END = "Lasts until the end of someone's next turn";

		const string BLANK_EFFECT = "(enter effect name)";

		const string SOMEONE_ELSE = "(someone else)";

		const string RESIST = "Resist";
		const string VULNERABLE = "Vulnerable";
		const string IMMUNE = "Immune";

		const int MIN_HEIGHT = 25;

		Dictionary<RadioButton, int> fHeights = new Dictionary<RadioButton, int>();

		public EffectForm(OngoingCondition condition, Encounter enc, CombatData current_actor, int current_round)
		{
			InitializeComponent();

			foreach (string c in Conditions.GetConditions())
				ConditionBox.Items.Add(c);

			foreach (DamageType dt in Enum.GetValues(typeof(DamageType)))
			{
				DamageTypeBox.Items.Add(dt);
				DamageModTypeBox.Items.Add(dt);
			}

			DamageModDirBox.Items.Add(RESIST);
			DamageModDirBox.Items.Add(VULNERABLE);
			DamageModDirBox.Items.Add(IMMUNE);

			DurationBox.Items.Add(ENCOUNTER);
			DurationBox.Items.Add(SAVE_ENDS);
			DurationBox.Items.Add(START);
			DurationBox.Items.Add(END);

			foreach (EncounterSlot slot in enc.Slots)
			{
				foreach (CombatData cd in slot.CombatData)
					DurationCreatureBox.Items.Add(cd);
			}
			foreach (Hero hero in Session.Project.Heroes)
				DurationCreatureBox.Items.Add(hero);
			foreach (Trap trap in enc.Traps)
				DurationCreatureBox.Items.Add(trap);

			Application.Idle += new EventHandler(Application_Idle);

			init(condition, current_actor, current_round);
		}

		~EffectForm()
		{
			Application.Idle -= Application_Idle;
		}

		public EffectForm(OngoingCondition condition, Hero hero)
		{
			InitializeComponent();

			foreach (string c in Conditions.GetConditions())
				ConditionBox.Items.Add(c);

			foreach (DamageType dt in Enum.GetValues(typeof(DamageType)))
			{
				DamageTypeBox.Items.Add(dt);
				DamageModTypeBox.Items.Add(dt);
			}

			DamageModDirBox.Items.Add(RESIST);
			DamageModDirBox.Items.Add(VULNERABLE);
			DamageModDirBox.Items.Add(IMMUNE);

			DurationBox.Items.Add(ENCOUNTER);
			DurationBox.Items.Add(SAVE_ENDS);
			DurationBox.Items.Add(START);
			DurationBox.Items.Add(END);

			DurationCreatureBox.Items.Add(hero);
			DurationCreatureBox.Items.Add(SOMEONE_ELSE);

			Application.Idle += new EventHandler(Application_Idle);

			init(condition, null, -1);
		}

		void init(OngoingCondition condition, CombatData current_actor, int current_round)
		{
			fHeights[ConditionBtn] = ConditionPanel.Height;
			fHeights[DamageBtn] = DamagePanel.Height;
			fHeights[DefenceBtn] = DefencePanel.Height;
			fHeights[DamageModBtn] = DamageModPanel.Height;
			fHeights[RegenBtn] = RegenPanel.Height;
			fHeights[AuraBtn] = AuraPanel.Height;

			fCondition = condition.Copy();
			fCurrentActor = current_actor;
			fCurrentRound = current_round;

			ConditionBtn.Checked = (fCondition.Type == OngoingType.Condition);
			ConditionBox.Text = (fCondition.Data != "") ? fCondition.Data : BLANK_EFFECT;

			DamageBtn.Checked = (fCondition.Type == OngoingType.Damage);
			DamageBox.Value = fCondition.Value;
			DamageTypeBox.SelectedItem = fCondition.DamageType;

			DefenceBtn.Checked = (fCondition.Type == OngoingType.DefenceModifier);
			DefenceModBox.Value = fCondition.DefenceMod;
			if (fCondition.Defences.Count == 0)
				fCondition.Defences.Add(DefenceType.AC);
			ACBox.Checked = fCondition.Defences.Contains(DefenceType.AC);
			FortBox.Checked = fCondition.Defences.Contains(DefenceType.Fortitude);
			RefBox.Checked = fCondition.Defences.Contains(DefenceType.Reflex);
			WillBox.Checked = fCondition.Defences.Contains(DefenceType.Will);

			if (fCondition.DamageModifier.Value < 0)
				DamageModDirBox.SelectedItem = RESIST;
			if (fCondition.DamageModifier.Value > 0)
				DamageModDirBox.SelectedItem = VULNERABLE;
			if (fCondition.DamageModifier.Value == 0)
				DamageModDirBox.SelectedItem = IMMUNE;
			DamageModValueBox.Value = Math.Abs(fCondition.DamageModifier.Value);
			DamageModTypeBox.SelectedItem = fCondition.DamageModifier.Type;

			RegenValueBox.Value = fCondition.Regeneration.Value;
			RegenConditionsBox.Text = fCondition.Regeneration.Details;

			AuraRadiusBox.Value = fCondition.Aura.Radius;
			AuraDetailsBox.Text = fCondition.Aura.Description;

			switch (fCondition.Duration)
			{
				case DurationType.Encounter:
					DurationBox.SelectedItem = ENCOUNTER;
					break;
				case DurationType.SaveEnds:
					DurationBox.SelectedItem = SAVE_ENDS;
					ModBox.Value = fCondition.SavingThrowModifier;
					break;
				case DurationType.BeginningOfTurn:
					DurationBox.SelectedItem = START;
					break;
				case DurationType.EndOfTurn:
					DurationBox.SelectedItem = END;
					break;
			}

			if (fCondition.DurationCreatureID != Guid.Empty)
			{
				DurationCreatureBox.SelectedItem = get_item(fCondition.DurationCreatureID);
			}
			else
			{
				if (fCurrentActor != null)
					DurationCreatureBox.SelectedItem = get_item(fCurrentActor.ID);
				else
					DurationCreatureBox.SelectedItem = DurationCreatureBox.Items[0];
			}
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ConditionBox.Enabled = ConditionBtn.Checked;

			DamageLbl.Enabled = DamageBtn.Checked;
			DamageBox.Enabled = DamageBtn.Checked;
			TypeLbl.Enabled = DamageBtn.Checked;
			DamageTypeBox.Enabled = DamageBtn.Checked;

			DefenceModLbl.Enabled = DefenceBtn.Checked;
			DefenceModBox.Enabled = DefenceBtn.Checked;
			ACBox.Enabled = DefenceBtn.Checked;
			FortBox.Enabled = DefenceBtn.Checked;
			RefBox.Enabled = DefenceBtn.Checked;
			WillBox.Enabled = DefenceBtn.Checked;
			AllDefencesLbl.Enabled = DefenceBtn.Checked;
			NoDefencesLbl.Enabled = DefenceBtn.Checked;

			DamageModDirBox.Enabled = DamageModBtn.Checked;
			DamageModValueLbl.Enabled = DamageModBtn.Checked && (DamageModDirBox.SelectedItem.ToString() != IMMUNE);
			DamageModValueBox.Enabled = DamageModBtn.Checked && (DamageModDirBox.SelectedItem.ToString() != IMMUNE);
			DamageModTypeLbl.Enabled = DamageModBtn.Checked;
			DamageModTypeBox.Enabled = DamageModBtn.Checked;

			RegenValueLbl.Enabled = RegenBtn.Checked;
			RegenValueBox.Enabled = RegenBtn.Checked;
			RegenConditionsLbl.Enabled = RegenBtn.Checked;
			RegenConditionsBox.Enabled = RegenBtn.Checked;

			AuraRadiusLbl.Enabled = AuraBtn.Checked;
			AuraRadiusBox.Enabled = AuraBtn.Checked;
			AuraDetailsLbl.Enabled = AuraBtn.Checked;
			AuraDetailsBox.Enabled = AuraBtn.Checked;

			string str = DurationBox.SelectedItem as string;

			DurationCreatureBox.Enabled = ((str == START) || (str == END));
			CreatureLbl.Enabled = DurationCreatureBox.Enabled;

			ModBox.Enabled = (str == SAVE_ENDS);
			ModLbl.Enabled = ModBox.Enabled;

			if (ConditionBtn.Checked)
				OKBtn.Enabled = ((ConditionBox.Text != "") && (ConditionBox.Text != BLANK_EFFECT));
			else
				OKBtn.Enabled = true;
		}

		private void EffectForm_Shown(object sender, EventArgs e)
		{
			if (ConditionBtn.Checked)
			{
				ConditionBox.Focus();
				ConditionBox.SelectAll();
			}

			if (DamageBtn.Checked)
			{
				DamageBox.Focus();
				DamageBox.Select(0, 1);
			}

			if (DefenceBtn.Checked)
			{
				DefenceModBox.Focus();
				DefenceModBox.Select(0, 1);
			}

			// Damage mods - do nothing

			if (RegenBtn.Checked)
			{
				RegenValueBox.Focus();
				RegenValueBox.Select(0, 1);
			}

			if (AuraBtn.Checked)
			{
				AuraRadiusBox.Focus();
				AuraRadiusBox.Select(0, 1);
			}
		}

		public OngoingCondition Effect
		{
			get { return fCondition; }
		}
		OngoingCondition fCondition = null;

		CombatData fCurrentActor = null;
		int fCurrentRound = int.MinValue;

		private void DurationBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (fCondition.DurationCreatureID == Guid.Empty)
			{
				if (fCurrentActor != null)
					DurationCreatureBox.SelectedItem = get_item(fCurrentActor.ID);
				else
					DurationCreatureBox.SelectedItem = DurationCreatureBox.Items[0];
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if (ConditionBtn.Checked)
				fCondition.Type = OngoingType.Condition;
			if (DamageBtn.Checked)
				fCondition.Type = OngoingType.Damage;
			if (DefenceBtn.Checked)
				fCondition.Type = OngoingType.DefenceModifier;
			if (DamageModBtn.Checked)
				fCondition.Type = OngoingType.DamageModifier;
			if (RegenBtn.Checked)
				fCondition.Type = OngoingType.Regeneration;
			if (AuraBtn.Checked)
				fCondition.Type = OngoingType.Aura;

			fCondition.Data = ConditionBox.Text;

			fCondition.Value = (int)DamageBox.Value;
			fCondition.DamageType = (DamageType)DamageTypeBox.SelectedItem;

			fCondition.DefenceMod = (int)DefenceModBox.Value;
			fCondition.Defences.Clear();
			if (ACBox.Checked)
				fCondition.Defences.Add(DefenceType.AC);
			if (FortBox.Checked)
				fCondition.Defences.Add(DefenceType.Fortitude);
			if (RefBox.Checked)
				fCondition.Defences.Add(DefenceType.Reflex);
			if (WillBox.Checked)
				fCondition.Defences.Add(DefenceType.Will);

			int damage_mod_amount = (int)DamageModValueBox.Value;
			switch (DamageModDirBox.SelectedIndex)
			{
				case 0:
					// Resist
					fCondition.DamageModifier.Value = damage_mod_amount * -1;
					break;
				case 1:
					// Vulnerable
					fCondition.DamageModifier.Value = damage_mod_amount;
					break;
				case 2:
					// Immune
					fCondition.DamageModifier.Value = 0;
					break;
			}
			fCondition.DamageModifier.Type = (DamageType)DamageModTypeBox.SelectedItem;

			fCondition.Regeneration.Value = (int)RegenValueBox.Value;
			fCondition.Regeneration.Details = RegenConditionsBox.Text;

			int aura_radius = (int)AuraRadiusBox.Value;
			fCondition.Aura.Details = aura_radius + ": " + AuraDetailsBox.Text;

			string str = DurationBox.SelectedItem as string;
			if (str == ENCOUNTER)
			{
				fCondition.Duration = DurationType.Encounter;
			}
			else if (str == SAVE_ENDS)
			{
				fCondition.Duration = DurationType.SaveEnds;
				fCondition.SavingThrowModifier = (int)ModBox.Value;
			}
			else if (str == START)
			{
				fCondition.Duration = DurationType.BeginningOfTurn;
				fCondition.DurationCreatureID = get_id(DurationCreatureBox.SelectedItem);
			}
			else if (str == END)
			{
				fCondition.Duration = DurationType.EndOfTurn;
				fCondition.DurationCreatureID = get_id(DurationCreatureBox.SelectedItem);
			}

			if ((str == START) || (str == END))
			{
				fCondition.DurationRound = fCurrentRound;

				if (fCurrentActor != null)
				{
					if (fCondition.DurationCreatureID == fCurrentActor.ID)
						fCondition.DurationRound += 1;
				}
			}
		}

		object get_item(Guid id)
		{
			foreach (object obj in DurationCreatureBox.Items)
			{
				if (obj is CombatData)
				{
					CombatData cd = obj as CombatData;
					if (cd.ID == id)
						return obj;
				}

				if (obj is Hero)
				{
					Hero hero = obj as Hero;
					if (hero.ID == id)
						return obj;
				}

				if (obj is Trap)
				{
					Trap trap = obj as Trap;
					if (trap.ID == id)
						return obj;
				}
			}

			return null;
		}

		Guid get_id(object obj)
		{
			if (obj is CombatData)
			{
				CombatData cd = obj as CombatData;
				return cd.ID;
			}

			if (obj is Hero)
			{
				Hero hero = obj as Hero;
				return hero.ID;
			}

			if (obj is Trap)
			{
				Trap trap = obj as Trap;
				return trap.ID;
			}

			return Guid.Empty;
		}

		private void AllDefencesLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			set_defences(true);
		}

		private void NoDefencesLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			set_defences(false);
		}

		private void set_defences(bool enabled)
		{
			ACBox.Checked = enabled;
			FortBox.Checked = enabled;
			RefBox.Checked = enabled;
			WillBox.Checked = enabled;
		}

		private void EffectTypeChanged(object sender, EventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			if (rb == null)
				return;

			if (rb.Checked == false)
				return;

			List<RadioButton> buttons = new List<RadioButton>();
			buttons.Add(ConditionBtn);
			buttons.Add(DamageBtn);
			buttons.Add(DefenceBtn);
			buttons.Add(DamageModBtn);
			buttons.Add(RegenBtn);
			buttons.Add(AuraBtn);

			buttons.Remove(rb);
			foreach (RadioButton btn in buttons)
				btn.Checked = false;

			ConditionPanel.Height = (rb == ConditionBtn) ? fHeights[rb] : MIN_HEIGHT;
			DamagePanel.Height = (rb == DamageBtn) ? fHeights[rb] : MIN_HEIGHT;
			DefencePanel.Height = (rb == DefenceBtn) ? fHeights[rb] : MIN_HEIGHT;
			DamageModPanel.Height = (rb == DamageModBtn) ? fHeights[rb] : MIN_HEIGHT;
			RegenPanel.Height = (rb == RegenBtn) ? fHeights[rb] : MIN_HEIGHT;
			AuraPanel.Height = (rb == AuraBtn) ? fHeights[rb] : MIN_HEIGHT;

			int topmargin = PropertiesPanel.Top;
			int middlemargin = DurationGroup.Top - PropertiesPanel.Bottom;
			int bottommargin = Height - DurationGroup.Bottom;
			Height = topmargin + ConditionPanel.Height + DamagePanel.Height + DefencePanel.Height + DamageModPanel.Height + RegenPanel.Height + AuraPanel.Height + middlemargin + DurationGroup.Height + bottommargin;
		}
	}
}
