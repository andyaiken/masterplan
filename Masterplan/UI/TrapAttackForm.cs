using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TrapAttackForm : Form
	{
		public TrapAttackForm(TrapAttack attack, int level, bool elite)
		{
			InitializeComponent();

			Array actions = Enum.GetValues(typeof(ActionType));
			foreach (ActionType action in actions)
				ActionBox.Items.Add(action);

			Application.Idle += new EventHandler(Application_Idle);

			fAttack = attack.Copy();
			fLevel = level;
			fElite = elite;

			TriggerBox.Text = fAttack.Trigger;
			ActionBox.SelectedItem = fAttack.Action;
			RangeBox.Text = fAttack.Range;
			TargetBox.Text = fAttack.Target;
			InitBtn.Checked = fAttack.HasInitiative;
			InitBox.Value = fAttack.Initiative;
			AttackBtn.Text = fAttack.Attack.ToString();
			HitBox.Text = fAttack.OnHit;
			MissBox.Text = fAttack.OnMiss;
			EffectBox.Text = fAttack.Effect;

			update_advice();
		}

		~TrapAttackForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			InitBox.Enabled = InitBtn.Checked;
		}

		public TrapAttack Attack
		{
			get { return fAttack; }
		}
		TrapAttack fAttack = null;

		int fLevel = 1;
		bool fElite = false;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fAttack.Trigger = TriggerBox.Text;
			fAttack.Action = (ActionType)ActionBox.SelectedItem;
			fAttack.Range = RangeBox.Text;
			fAttack.Target = TargetBox.Text;
			fAttack.HasInitiative = InitBtn.Checked;
			fAttack.Initiative = (int)InitBox.Value;
			fAttack.OnHit = HitBox.Text;
			fAttack.OnMiss = MissBox.Text;
			fAttack.Effect = EffectBox.Text;
		}

		private void AttackBtn_Click(object sender, EventArgs e)
		{
			PowerAttackForm dlg = new PowerAttackForm(fAttack.Attack, false, 0, null);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fAttack.Attack = dlg.Attack;
				AttackBtn.Text = fAttack.Attack.ToString();
			}
		}

		void update_advice()
		{
			int init = 2;
			int attack_ac = fLevel + 5;
			int attack_nad = fLevel + 3;

			if (fElite)
			{
				init += 2;
				attack_ac += 2;
				attack_nad += 2;
			}

			// Init
			ListViewItem lvi_init = AdviceList.Items.Add("Initiative");
			lvi_init.SubItems.Add("+" + init);
			lvi_init.Group = AdviceList.Groups[0];

			// Attack vs AC
			ListViewItem lvi_att_ac = AdviceList.Items.Add("Attack vs AC");
			lvi_att_ac.SubItems.Add("+" + attack_ac);
			lvi_att_ac.Group = AdviceList.Groups[1];

			// Attack vs NAD
			ListViewItem lvi_att_nad = AdviceList.Items.Add("Attack vs other defence");
			lvi_att_nad.SubItems.Add("+" + attack_nad);
			lvi_att_nad.Group = AdviceList.Groups[1];
		}
	}
}
