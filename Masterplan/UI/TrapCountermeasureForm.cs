using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TrapCountermeasureForm : Form
	{
		public TrapCountermeasureForm(string cm, int level)
		{
			InitializeComponent();

			DetailsBox.Text = cm;
			fLevel = level;

			update_advice();
		}

		public string Countermeasure
		{
			get { return (DetailsBox.Text != DetailsBox.DefaultText) ? DetailsBox.Text : ""; }
		}

		int fLevel = 1;

		void update_advice()
		{
			ListViewItem lvi_easy = AdviceList.Items.Add("Skill DC (easy)");
			lvi_easy.SubItems.Add(AI.GetSkillDC(Difficulty.Easy, fLevel).ToString());
			lvi_easy.Group = AdviceList.Groups[0];

			ListViewItem lvi_mod = AdviceList.Items.Add("Skill DC (moderate)");
			lvi_mod.SubItems.Add(AI.GetSkillDC(Difficulty.Moderate, fLevel).ToString());
			lvi_mod.Group = AdviceList.Groups[0];

			ListViewItem lvi_hard = AdviceList.Items.Add("Skill DC (hard)");
			lvi_hard.SubItems.Add(AI.GetSkillDC(Difficulty.Hard, fLevel).ToString());
			lvi_hard.Group = AdviceList.Groups[0];
		}

		private void TrapCountermeasureForm_Shown(object sender, EventArgs e)
		{
			DetailsBox.Focus();
			DetailsBox.SelectAll();
		}
	}
}
