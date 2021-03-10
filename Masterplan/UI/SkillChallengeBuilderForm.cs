using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class SkillChallengeBuilderForm : Form
	{
		public SkillChallengeBuilderForm(SkillChallenge sc)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fChallenge = sc.Copy() as SkillChallenge;

			update_all();

			List<string> skill_names = Skills.GetSkillNames();
			foreach (string skill in skill_names)
			{
				string ability = Skills.GetKeyAbility(skill).Substring(0, 3);
				string abbr = ability.Substring(0, 3);

				ListViewItem lvi = SkillSourceList.Items.Add(skill);
				ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(abbr);
				lvi.UseItemStyleForSubItems = false;
				lvsi.ForeColor = SystemColors.GrayText;
				lvi.Group = SkillSourceList.Groups[0];
			}

			List<string> ability_names = Skills.GetAbilityNames();
			foreach (string ability in ability_names)
			{
				string abbr = ability.Substring(0, 3);

				ListViewItem lvi = SkillSourceList.Items.Add(ability);
				ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(abbr);
				lvi.UseItemStyleForSubItems = false;
				lvsi.ForeColor = SystemColors.GrayText;
				lvi.Group = SkillSourceList.Groups[1];
			}

			// Custom
			ListViewItem lvi_custom = SkillSourceList.Items.Add("(custom skill)");
			ListViewItem.ListViewSubItem lvsi_custom = lvi_custom.SubItems.Add("");
			lvi_custom.UseItemStyleForSubItems = false;
			lvsi_custom.ForeColor = SystemColors.GrayText;
			lvi_custom.Group = SkillSourceList.Groups[2];
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedSkill != null);
			EditBtn.Enabled = (SelectedSkill != null);

			BreakdownBtn.Enabled = (fChallenge.Skills.Count != 0);

			SkillChallengeResult results = fChallenge.Results;
			ResetProgressBtn.Enabled = (results.Successes + results.Fails != 0);
		}

		public SkillChallenge SkillChallenge
		{
			get { return fChallenge; }
		}
		SkillChallenge fChallenge = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fChallenge.Name = NameBox.Text;
			fChallenge.Complexity = (int)CompBox.Value;

			if (LevelBox.Enabled)
				fChallenge.Level = (int)LevelBox.Value;

			fChallenge.Success = (VictoryBox.Text != VictoryBox.DefaultText) ? VictoryBox.Text : "";
			fChallenge.Failure = (DefeatBox.Text != DefeatBox.DefaultText) ? DefeatBox.Text : "";
			fChallenge.Notes = (NotesBox.Text != NotesBox.DefaultText) ? NotesBox.Text : "";
		}

		public void update_all()
		{
			NameBox.Text = fChallenge.Name;
			CompBox.Value = fChallenge.Complexity;
			VictoryBox.Text = fChallenge.Success;
			DefeatBox.Text = fChallenge.Failure;
			NotesBox.Text = fChallenge.Notes;

			if (fChallenge.Level != -1)
			{
				LevelBox.Value = fChallenge.Level;
			}
			else
			{
				LevelBox.Enabled = false;
			}

			update_view();
			update_skills();
		}

		#region First page

		private void LevelBox_ValueChanged(object sender, EventArgs e)
		{
			update_view();
		}

		private void CompBox_ValueChanged(object sender, EventArgs e)
		{
			update_view();
		}

		void update_view()
		{
			int level = (int)LevelBox.Value;
			int complexity = (int)CompBox.Value;

			LengthLbl.Text = SkillChallenge.GetSuccesses(complexity) + " successes before 3 failures";

			InfoList.Items.Clear();
			if (fChallenge.Level != -1)
			{
				ListViewItem lvi_easy = InfoList.Items.Add("Easy");
				lvi_easy.SubItems.Add("DC " + AI.GetSkillDC(Difficulty.Easy, level));
				lvi_easy.Group = InfoList.Groups[0];

				ListViewItem lvi_mod = InfoList.Items.Add("Moderate");
				lvi_mod.SubItems.Add("DC " + AI.GetSkillDC(Difficulty.Moderate, level));
				lvi_mod.Group = InfoList.Groups[0];

				ListViewItem lvi_hard = InfoList.Items.Add("Hard");
				lvi_hard.SubItems.Add("DC " + AI.GetSkillDC(Difficulty.Hard, level));
				lvi_hard.Group = InfoList.Groups[0];

				XPLbl.Text = SkillChallenge.GetXP(level, complexity) + " XP";
			}
			else
			{
				ListViewItem lvi = InfoList.Items.Add("DCs");
				ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add("(varies by level)");
				lvi.UseItemStyleForSubItems = false;
				lvsi.ForeColor = SystemColors.GrayText;
				lvi.Group = InfoList.Groups[0];

				XPLbl.Text = "(XP varies by level)";
			}

			SkillChallengeResult results = fChallenge.Results;
			SuccessCountLbl.Text = "Successes: " + results.Successes;
			FailureCountLbl.Text = "Failures: " + results.Fails;
		}

		#endregion

		#region Skills

		public SkillChallengeData SelectedSkill
		{
			get
			{
				if (SkillList.SelectedItems.Count != 0)
					return SkillList.SelectedItems[0].Tag as SkillChallengeData;

				return null;
			}
		}

		public string SelectedSourceSkill
		{
			get
			{
				if (SkillSourceList.SelectedItems.Count != 0)
					return SkillSourceList.SelectedItems[0].Text;

				return "";
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSkill != null)
			{
				fChallenge.Skills.Remove(SelectedSkill);

				update_view();
				update_skills();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSkill != null)
			{
				int index = fChallenge.Skills.IndexOf(SelectedSkill);

				SkillChallengeSkillForm dlg = new SkillChallengeSkillForm(SelectedSkill);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fChallenge.Skills[index] = dlg.SkillData;
					fChallenge.Skills.Sort();

					update_view();
					update_skills();
				}
			}
		}

		void update_skills()
		{
			SkillList.Items.Clear();

			foreach (SkillChallengeData scd in fChallenge.Skills)
			{
				string diff = scd.Difficulty + " DCs";
				if (scd.DCModifier != 0)
				{
					if (scd.DCModifier > 0)
						diff += " +" + scd.DCModifier;
					else
						diff += " " + scd.DCModifier;
				}

				ListViewItem lvi = SkillList.Items.Add(scd.SkillName);
				lvi.SubItems.Add(diff);
				lvi.Tag = scd;

				switch (scd.Type)
				{
					case SkillType.Primary:
						lvi.Group = SkillList.Groups[0];
						break;
					case SkillType.Secondary:
						lvi.Group = SkillList.Groups[1];
						break;
					case SkillType.AutoFail:
						lvi.Group = SkillList.Groups[2];
						break;
				}

				if ((scd.Details == "") && (scd.Success == "") && (scd.Failure == ""))
					lvi.ForeColor = SystemColors.GrayText;

				if ((scd.Difficulty == Difficulty.Trivial) || (scd.Difficulty == Difficulty.Extreme))
				{
					lvi.UseItemStyleForSubItems = false;
					lvi.SubItems[1].ForeColor = Color.Red;
				}
			}

			if (SkillList.Groups[0].Items.Count == 0)
			{
				ListViewItem lvi = SkillList.Items.Add("(none)");
				lvi.Group = SkillList.Groups[0];
				lvi.ForeColor = SystemColors.GrayText;
			}

			if (SkillList.Groups[1].Items.Count == 0)
			{
				ListViewItem lvi = SkillList.Items.Add("(none)");
				lvi.Group = SkillList.Groups[1];
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		private void SkillSourceList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			ListViewItem lvi = e.Item as ListViewItem;
			if (lvi != null)
			{
				string skill_name = lvi.Text;

				DragDropEffects fx = DoDragDrop(skill_name, DragDropEffects.Copy);

				if (fx == DragDropEffects.Copy)
					add_skill(skill_name);
			}
		}

		private void SkillList_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.None;

			string skill = e.Data.GetData(typeof(string)) as string;
			if ((skill != null) && (skill != ""))
				e.Effect = DragDropEffects.Copy;
		}

		private void SkillSourceList_DoubleClick(object sender, EventArgs e)
		{
			string skill_name = SelectedSourceSkill;

			if (skill_name != "")
				add_skill(skill_name);
		}

		void add_skill(string skill_name)
		{
			SkillChallengeData scd = new SkillChallengeData();
			scd.SkillName = skill_name;

			SkillChallengeSkillForm dlg = new SkillChallengeSkillForm(scd);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fChallenge.Skills.Add(dlg.SkillData);
				fChallenge.Skills.Sort();

				update_view();
				update_skills();
			}
		}

		private void BreakdownBtn_Click(object sender, EventArgs e)
		{
			// Show breakdown
			SkillChallengeBreakdownForm dlg = new SkillChallengeBreakdownForm(fChallenge);
			dlg.ShowDialog();
		}

		private void ResetProgressBtn_Click(object sender, EventArgs e)
		{
			foreach (SkillChallengeData scd in fChallenge.Skills)
			{
				scd.Results.Successes = 0;
				scd.Results.Fails = 0;
			}

			update_view();
		}

		private void FileExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Export Skill Challenge";
			dlg.FileName = fChallenge.Name;
			dlg.Filter = Program.SkillChallengeFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				bool ok = Serialisation<SkillChallenge>.Save(dlg.FileName, fChallenge, SerialisationMode.Binary);

				if (!ok)
				{
					string error = "The skill challenge could not be exported.";
					MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
