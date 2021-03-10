using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TrapSkillForm : Form
	{
		public TrapSkillForm(TrapSkillData tsd, int level)
		{
			InitializeComponent();

			List<string> skills = Skills.GetSkillNames();
			foreach (string skill in skills)
				SkillBox.Items.Add(skill);

			Application.Idle += new EventHandler(Application_Idle);

			fSkillData = tsd.Copy();
			fLevel = level;

			SkillBox.Text = fSkillData.SkillName;
			DCBtn.Checked = (fSkillData.DC != 0);
			DCBox.Value = fSkillData.DC;
			DetailsBox.Text = fSkillData.Details;

			update_advice();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			DCLbl.Enabled = DCBtn.Checked;
			DCBox.Enabled = DCBtn.Checked;

			OKBtn.Enabled = ((SkillBox.Text != "") && (DetailsBox.Text != ""));
		}

		public TrapSkillData SkillData
		{
			get { return fSkillData; }
		}
		TrapSkillData fSkillData = null;

		int fLevel = 1;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fSkillData.SkillName = SkillBox.Text;
			if (DCBtn.Checked)
				fSkillData.DC = (int)DCBox.Value;
			else
				fSkillData.DC = 0;
			fSkillData.Details = DetailsBox.Text;
		}

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
	}
}
