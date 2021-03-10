using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
	partial class LevelForm : Form
	{
		public LevelForm(int score)
		{
			InitializeComponent();

			if (score == int.MinValue)
				score = 0;

			LevelBox.Value = score;
		}

		public int Level
		{
			get { return (int)LevelBox.Value; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
