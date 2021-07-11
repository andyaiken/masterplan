using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TrapActionForm : Form
	{
		public TrapActionForm(TrapAttack attack)
		{
			InitializeComponent();

			Array actions = Enum.GetValues(typeof(ActionType));
			foreach (ActionType action in actions)
				ActionBox.Items.Add(action);

			Application.Idle += new EventHandler(Application_Idle);

			fAttack = attack.Copy();

			NameBox.Text = fAttack.Name;
			ActionBox.SelectedItem = fAttack.Action;
			RangeBox.Text = fAttack.Range;
			TargetBox.Text = fAttack.Target;
		}

		~TrapActionForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
		}

		public TrapAttack Attack
		{
			get { return fAttack; }
		}
		TrapAttack fAttack = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fAttack.Name = NameBox.Text;
			fAttack.Action = (ActionType)ActionBox.SelectedItem;
			fAttack.Range = RangeBox.Text;
			fAttack.Target = TargetBox.Text;
		}
	}
}
