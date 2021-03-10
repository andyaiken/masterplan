using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class PowerRangeForm : Form
	{
		public PowerRangeForm(CreaturePower power)
		{
			InitializeComponent();

			RangeBox.Items.Add("Melee");
			RangeBox.Items.Add("Melee Touch");
			RangeBox.Items.Add("Melee Weapon");
            RangeBox.Items.Add("Melee N");
            RangeBox.Items.Add("Reach N");
            RangeBox.Items.Add("Ranged N");
			RangeBox.Items.Add("Close Blast N");
			RangeBox.Items.Add("Close Burst N");
			RangeBox.Items.Add("Area Burst N within N");
			RangeBox.Items.Add("Personal");

			RangeBox.Text = power.Range;
		}

		public string PowerRange
		{
			get { return RangeBox.Text; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
