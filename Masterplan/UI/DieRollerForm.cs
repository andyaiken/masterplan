using System.Windows.Forms;

using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class DieRollerForm : Form
	{
		public DieRollerForm()
		{
			InitializeComponent();

			DicePanel.UpdateView();
		}

		public DiceExpression Expression
		{
			get { return DicePanel.Expression; }
			set { DicePanel.Expression = value; }
		}
	}
}
