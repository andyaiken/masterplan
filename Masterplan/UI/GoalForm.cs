using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class GoalForm : Form
	{
		public GoalForm(Goal goal)
		{
			InitializeComponent();

			fGoal = goal.Copy();

			NameBox.Text = fGoal.Name;
			DetailsBox.Text = fGoal.Details;
		}

		public Goal Goal
		{
			get { return fGoal; }
		}
		Goal fGoal = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fGoal.Name = NameBox.Text;
			fGoal.Details = (DetailsBox.Text != DetailsBox.DefaultText) ? DetailsBox.Text : "";
		}
	}
}
