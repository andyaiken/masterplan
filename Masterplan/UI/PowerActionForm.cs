using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class PowerActionForm : Form
	{
		public PowerActionForm(PowerAction action)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			RechargeBox.Items.Add(PowerAction.RECHARGE_2);
			RechargeBox.Items.Add(PowerAction.RECHARGE_3);
			RechargeBox.Items.Add(PowerAction.RECHARGE_4);
			RechargeBox.Items.Add(PowerAction.RECHARGE_5);
			RechargeBox.Items.Add(PowerAction.RECHARGE_6);

			Array actions = Enum.GetValues(typeof(ActionType));
			foreach (ActionType a in actions)
			{
				ActionBox.Items.Add(a);
				SustainBox.Items.Add(a);
			}

			if (action != null)
				fAction = action.Copy();

			if (fAction != null)
			{
				fAction = action.Copy();

				TraitBox.Checked = false;

				switch (fAction.Use)
				{
					case PowerUseType.AtWill:
						AtWillBtn.Checked = true;
						BasicAttackBtn.Checked = false;
						break;
					case PowerUseType.Basic:
						AtWillBtn.Checked = true;
						BasicAttackBtn.Checked = true;
						break;
					case PowerUseType.Encounter:
						EncounterBtn.Checked = true;
						RechargeBox.Text = fAction.Recharge;
						break;
					case PowerUseType.Daily:
						DailyBtn.Checked = true;
						break;
				}

				ActionBox.SelectedItem = fAction.Action;
				TriggerBox.Text = fAction.Trigger;
				SustainBox.SelectedItem = fAction.SustainAction;
			}
			else
			{
				TraitBox.Checked = true;

				AtWillBtn.Checked = true;
				BasicAttackBtn.Checked = false;
				ActionBox.SelectedItem = ActionType.Standard;
				SustainBox.SelectedItem = ActionType.None;
			}
		}

		~PowerActionForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			bool is_trait = TraitBox.Checked;

			UsageGroup.Enabled = !is_trait;
			BasicAttackBtn.Enabled = UsageGroup.Enabled && AtWillBtn.Checked;
			RechargeLbl.Enabled = UsageGroup.Enabled && EncounterBtn.Checked;
			RechargeBox.Enabled = UsageGroup.Enabled && EncounterBtn.Checked;
			ActionLbl.Enabled = !is_trait;
			ActionBox.Enabled = !is_trait;
			TriggerLbl.Enabled = !is_trait;
			TriggerBox.Enabled = !is_trait;
			SustainLbl.Enabled = !is_trait;
			SustainBox.Enabled = !is_trait;
		}

		public PowerAction Action
		{
			get { return fAction; }
		}
		PowerAction fAction = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if (TraitBox.Checked)
			{
				fAction = null;
			}
			else
			{
				if (fAction == null)
					fAction = new PowerAction();

				if (AtWillBtn.Checked)
				{
					fAction.Use = BasicAttackBtn.Checked ? PowerUseType.Basic : PowerUseType.AtWill;
				}

				if (EncounterBtn.Checked)
				{
					fAction.Use = PowerUseType.Encounter;
					fAction.Recharge = RechargeBox.Text;
				}

				if (DailyBtn.Checked)
				{
					fAction.Use = PowerUseType.Daily;
				}

				fAction.Action = (ActionType)ActionBox.SelectedItem;
				fAction.Trigger = TriggerBox.Text;
				fAction.SustainAction = (ActionType)SustainBox.SelectedItem;
			}
		}
	}
}
