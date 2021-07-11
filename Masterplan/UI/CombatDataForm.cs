using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CombatDataForm : Form
	{
		public CombatDataForm(CombatData data, EncounterCard card, Encounter enc, CombatData current_actor, int current_round, bool allow_name_edit)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);
			EffectList_SizeChanged(null, null);

			fData = data.Copy();
			fCard = card;
			fEncounter = enc;

			fCurrentActor = current_actor;
			fCurrentRound = current_round;

			if (fData.Initiative == int.MinValue)
				fData.Initiative = 0;

			Text = fData.DisplayName;
			LabelBox.Text = fData.DisplayName;

			if (!allow_name_edit)
				LabelBox.Enabled = false;

			update_hp();
			InitBox.Value = fData.Initiative;
			AltitudeBox.Value = fData.Altitude;
			update_effects();
		}

		~CombatDataForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			bool damage = false;
			foreach (OngoingCondition oc in fData.Conditions)
			{
				if ((oc.Type == OngoingType.Damage) && (oc.Value > 0))
				{
					damage = true;
					break;
				}
			}

			RemoveBtn.Enabled = (SelectedCondition != null);
			EditBtn.Enabled = (SelectedCondition != null);
			SavesBtn.Enabled = (fData.Conditions.Count > 0);
			DmgBtn.Enabled = damage;
		}

		public CombatData Data
		{
			get { return fData; }
		}
		CombatData fData = null;

		EncounterCard fCard = null;
		Encounter fEncounter = null;

		CombatData fCurrentActor = null;
		int fCurrentRound = int.MinValue;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fData.DisplayName = LabelBox.Text;
			fData.Initiative = (int)InitBox.Value;
			fData.Altitude = (int)AltitudeBox.Value;
		}

		private void DamageBox_ValueChanged(object sender, EventArgs e)
		{
			fData.Damage = (int)DamageBox.Value;

			update_hp();
		}

		private void TempHPBox_ValueChanged(object sender, EventArgs e)
		{
			fData.TempHP = (int)TempHPBox.Value;

			update_hp();
		}

		public OngoingCondition SelectedCondition
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return EffectList.SelectedItems[0].Tag as OngoingCondition;

				return null;
			}
		}

		#region Toolbar

		private void AddBtn_Click(object sender, EventArgs e)
		{
			OngoingCondition oc = new OngoingCondition();

			EffectForm dlg = new EffectForm(oc, fEncounter, fCurrentActor, fCurrentRound);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fData.Conditions.Add(dlg.Effect);
				update_effects();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCondition != null)
			{
				fData.Conditions.Remove(SelectedCondition);
				update_effects();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCondition != null)
			{
				int index = fData.Conditions.IndexOf(SelectedCondition);

				EffectForm dlg = new EffectForm(SelectedCondition, fEncounter, fCurrentActor, fCurrentRound);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fData.Conditions[index] = dlg.Effect;
					update_effects();
				}
			}
		}

		private void DmgBtn_Click(object sender, EventArgs e)
		{
			OngoingDamageForm dlg = new OngoingDamageForm(fData, fCard, fEncounter);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				update_hp();
			}
		}

		private void SavesBtn_Click(object sender, EventArgs e)
		{
			SavingThrowForm dlg = new SavingThrowForm(fData, fCard, fEncounter);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				update_effects();
			}
		}

		#endregion

		#region Updating

		void update_hp()
		{
			DamageBox.Value = fData.Damage;
			TempHPBox.Value = fData.TempHP;

			int max_hp = 0;
			if (fCard != null)
			{
				max_hp = fCard.HP;
			}
			else
			{
				// Must be a hero
				foreach (Hero h in Session.Project.Heroes)
				{
					if (fData.DisplayName == h.Name)
						max_hp = h.HP;
				}
			}
			int current_hp = max_hp - fData.Damage;

			HPBox.Text = current_hp + " HP";
			if (fData.TempHP > 0)
				HPBox.Text += "; " + fData.TempHP + " temp HP";

			if (current_hp + fData.TempHP <= 0)
				HPBox.Text += " (dead)";
			else if (current_hp <= max_hp / 2)
				HPBox.Text += " (bloodied)";

			HPGauge.FullHP = max_hp;
			HPGauge.Damage = fData.Damage;
			HPGauge.TempHP = fData.TempHP;
		}

		void update_effects()
		{
			EffectList.Items.Clear();
			EffectList.ShowGroups = true;

			foreach (OngoingCondition oc in fData.Conditions)
			{
				string effect = oc.ToString();
				string duration = oc.GetDuration(fEncounter);
				if (duration == "")
					duration = "until the end of the encounter";

				ListViewItem lvi = EffectList.Items.Add(effect);
				lvi.SubItems.Add(duration);

				lvi.Tag = oc;
				lvi.Group = EffectList.Groups[(oc.Type == OngoingType.Condition) ? 0 : 1];
			}

			if (fData.Conditions.Count == 0)
			{
				EffectList.ShowGroups = false;

				ListViewItem lvi = EffectList.Items.Add("(no ongoing effects)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		private void EffectList_SizeChanged(object sender, EventArgs e)
		{
			int width = EffectList.Width - (SystemInformation.VerticalScrollBarWidth + 6);
			EffectList.TileSize = new Size(width, EffectList.TileSize.Height);
		}
	}
}
