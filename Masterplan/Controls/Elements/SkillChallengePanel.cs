using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.UI;

namespace Masterplan.Controls
{
	partial class SkillChallengePanel : UserControl
	{
		public SkillChallengePanel()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ChooseBtn.Enabled = (Session.SkillChallenges.Count != 0);
		}

		public void Edit()
		{
			EditBtn_Click(null, null);
		}

		public SkillChallenge Challenge
		{
			get { return fChallenge; }
			set
			{
				fChallenge = value;
				update_view();
			}
		}
		SkillChallenge fChallenge = null;

		public int PartyLevel
		{
			get { return fPartyLevel; }
			set
			{
				fPartyLevel = value;
				update_view();
			}
		}
		int fPartyLevel = Session.Project.Party.Level;

		public SkillChallengeData SelectedSkill
		{
			get
			{
				if (SkillList.SelectedItems.Count != 0)
					return SkillList.SelectedItems[0].Tag as SkillChallengeData;

				return null;
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(fChallenge);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fChallenge.Name = dlg.SkillChallenge.Name;
				fChallenge.Complexity = dlg.SkillChallenge.Complexity;
				fChallenge.Level = dlg.SkillChallenge.Level;
				fChallenge.Success = dlg.SkillChallenge.Success;
				fChallenge.Failure = dlg.SkillChallenge.Failure;
				fChallenge.Notes = dlg.SkillChallenge.Notes;

				fChallenge.Skills.Clear();
				foreach (SkillChallengeData scd in dlg.SkillChallenge.Skills)
					fChallenge.Skills.Add(scd.Copy());

				update_view();
			}
		}

        private void LocationBtn_Click(object sender, EventArgs e)
        {
            MapAreaSelectForm dlg = new MapAreaSelectForm(fChallenge.MapID, fChallenge.MapAreaID);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fChallenge.MapID = (dlg.Map != null) ? dlg.Map.ID : Guid.Empty;
                fChallenge.MapAreaID = (dlg.MapArea != null) ? dlg.MapArea.ID : Guid.Empty;

                update_view();
            }
        }

		private void ChooseBtn_Click(object sender, EventArgs e)
		{
			SkillChallengeSelectForm dlg = new SkillChallengeSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fChallenge.Name = dlg.SkillChallenge.Name;
				fChallenge.Complexity = dlg.SkillChallenge.Complexity;
				fChallenge.Success = dlg.SkillChallenge.Success;
				fChallenge.Failure = dlg.SkillChallenge.Failure;

				fChallenge.Skills.Clear();
				foreach (SkillChallengeData scd in dlg.SkillChallenge.Skills)
					fChallenge.Skills.Add(scd.Copy());

				fChallenge.Level = fPartyLevel;

				update_view();
			}
		}

		private void SkillList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedSkill != null)
			{
				int index = fChallenge.Skills.IndexOf(SelectedSkill);

				SkillChallengeSkillForm dlg = new SkillChallengeSkillForm(SelectedSkill);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fChallenge.Skills[index] = dlg.SkillData;
					update_view();
				}
			}
		}

		void update_view()
		{
			SkillList.Items.Clear();

			ListViewItem name_lvi = SkillList.Items.Add(fChallenge.Name + ": " + fChallenge.GetXP() + " XP");
			name_lvi.Group = SkillList.Groups[0];

			ListViewItem info_lvi = SkillList.Items.Add(fChallenge.Info);
			info_lvi.Group = SkillList.Groups[0];

            if (fChallenge.MapID != Guid.Empty)
            {
                Map m = Session.Project.FindTacticalMap(fChallenge.MapID);
				if (m != null)
				{
					MapArea ma = m.FindArea(fChallenge.MapAreaID);
					if (ma != null)
					{
						string str = "Location: " + m.Name;
						if (ma != null)
							str += " (" + ma.Name + ")";

						ListViewItem lvi_loc = SkillList.Items.Add(str);
						lvi_loc.Group = SkillList.Groups[0];
					}
				}
            }

			foreach (SkillChallengeData scd in fChallenge.Skills)
			{
				string diff = scd.Difficulty.ToString().ToLower() + " DCs";
				if (scd.DCModifier != 0)
				{
					if (scd.DCModifier > 0)
						diff += " +" + scd.DCModifier;
					else
						diff += " " + scd.DCModifier;
				}

				string str = scd.SkillName + " (" + diff + ")";
				if (scd.Details != "")
					str += ": " + scd.Details;

				ListViewItem lvi = SkillList.Items.Add(str);
				lvi.Tag = scd;

				switch (scd.Type)
				{
					case SkillType.Primary:
						lvi.Group = SkillList.Groups[1];
						break;
					case SkillType.Secondary:
						lvi.Group = SkillList.Groups[2];
						break;
					case SkillType.AutoFail:
						lvi.Group = SkillList.Groups[3];
						break;
				}

				if ((scd.Difficulty == Difficulty.Trivial) || (scd.Difficulty == Difficulty.Extreme))
					lvi.ForeColor = Color.Red;
			}

			if (SkillList.Groups[1].Items.Count == 0)
			{
				ListViewItem lvi = SkillList.Items.Add("(none)");
				lvi.Group = SkillList.Groups[1];
				lvi.ForeColor = SystemColors.GrayText;
			}

			if (SkillList.Groups[2].Items.Count == 0)
			{
				ListViewItem lvi = SkillList.Items.Add("(none)");
				lvi.Group = SkillList.Groups[2];
				lvi.ForeColor = SystemColors.GrayText;
			}

			SkillList.Sort();
		}

		private void AddLibraryBtn_Click(object sender, EventArgs e)
		{
			LibrarySelectForm dlg = new LibrarySelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Library lib = dlg.SelectedLibrary;

				lib.SkillChallenges.Add(fChallenge.Copy() as SkillChallenge);
			}
		}
	}
}
