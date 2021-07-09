using System.Collections.Generic;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class OddsForm : Form
    {
		public OddsForm()
		{
			InitializeComponent();

			DiceGraph.Dice = new List<int>(new int[] { 4, 6, 8, 10 });
		}

		public OddsForm(List<int> dice, int constant, string title)
		{
			InitializeComponent();

			DiceGraph.Dice = dice;
			DiceGraph.Constant = constant;
			DiceGraph.Title = title;
		}
	}
}
