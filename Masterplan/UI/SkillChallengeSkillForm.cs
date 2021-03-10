using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class SkillChallengeSkillForm : Form
	{
		const string PRIMARY = "This is a primary skill for this challenge";
		const string SECONDARY = "This is a secondary skill for this challenge";
		const string AUTOFAIL = "This skill incurs an automatic failure";

		public SkillChallengeSkillForm(SkillChallengeData scd)
		{
			InitializeComponent();

			List<string> skills = Skills.GetSkillNames();
			foreach (string skill in skills)
				SkillBox.Items.Add(skill);

			DiffBox.Items.Add(Difficulty.Easy);
			DiffBox.Items.Add(Difficulty.Moderate);
			DiffBox.Items.Add(Difficulty.Hard);

			TypeBox.Items.Add(PRIMARY);
			TypeBox.Items.Add(SECONDARY);
			TypeBox.Items.Add(AUTOFAIL);

			fSkillData = scd.Copy();

			SkillBox.Text = fSkillData.SkillName;

			switch (fSkillData.Type)
			{
				case SkillType.Primary:
					TypeBox.SelectedIndex = 0;
					break;
				case SkillType.Secondary:
					TypeBox.SelectedIndex = 1;
					break;
				case SkillType.AutoFail:
					TypeBox.SelectedIndex = 2;
					break;
			}

			DiffBox.SelectedItem = fSkillData.Difficulty;
			ModBox.Value = fSkillData.DCModifier;

			DetailsBox.Text = fSkillData.Details;
			SuccessBox.Text = fSkillData.Success;
			FailureBox.Text = fSkillData.Failure;

			SuccessCountBox.Value = fSkillData.Results.Successes;
			FailureCountBox.Value = fSkillData.Results.Fails;
		}

		public SkillChallengeData SkillData
		{
			get { return fSkillData; }
		}
		SkillChallengeData fSkillData = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fSkillData.SkillName = SkillBox.Text;

			switch (TypeBox.SelectedIndex)
			{
				case 0:
					fSkillData.Type = SkillType.Primary;
					break;
				case 1:
					fSkillData.Type = SkillType.Secondary;
					break;
				case 2:
					fSkillData.Type = SkillType.AutoFail;
					break;
			}

			fSkillData.Difficulty = (Difficulty)DiffBox.SelectedItem;
			fSkillData.DCModifier = (int)ModBox.Value;

			fSkillData.Details = DetailsBox.Text;
			fSkillData.Success = SuccessBox.Text;
			fSkillData.Failure = FailureBox.Text;

			fSkillData.Results.Successes = (int)SuccessCountBox.Value;
			fSkillData.Results.Fails = (int)FailureCountBox.Value;
		}

		private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool autofail = (TypeBox.Text == AUTOFAIL);

			DiffLbl.Enabled = (!autofail);
			DiffBox.Enabled = (!autofail);
			ModLbl.Enabled = (!autofail);
			ModBox.Enabled = (!autofail);

			if (autofail)
			{
				Pages.TabPages.Remove(SuccessPage);
				Pages.TabPages.Remove(FailurePage);
			}
			else
			{
				if (!Pages.TabPages.Contains(SuccessPage))
					Pages.TabPages.Add(SuccessPage);

				if (!Pages.TabPages.Contains(FailurePage))
					Pages.TabPages.Add(FailurePage);
			}
		}
	}
}
