using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
	partial class LevelAdjustmentForm : Form
	{
		const string LEVEL_UP = "More difficult";
		const string LEVEL_DOWN = "Less difficult";

		public LevelAdjustmentForm()
		{
			InitializeComponent();

			DirectionBox.Items.Add(LEVEL_UP);
			DirectionBox.Items.Add(LEVEL_DOWN);

			DirectionBox.SelectedIndex = 0;
		}

		public int LevelAdjustment
		{
			get
			{
				int levels = (int)LevelBox.Value;

				if (DirectionBox.SelectedItem.ToString() == LEVEL_DOWN)
					levels *= -1;

				return levels;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
