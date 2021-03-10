using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;
using System.Drawing;

namespace Masterplan.UI
{
	partial class CreatureSkillsForm : Form
	{
		class SkillData
		{
			public string SkillName;
			public bool Trained = false;
			public int Ability = 0;
			public int Level = 0;
			public int Misc = 0;

			public bool Show
			{
				get
				{
					return (Trained || (Misc != 0));
				}
			}

			public int Total
			{
				get
				{
					int training = Trained ? 5 : 0;
					return training + Ability + Level + Misc;
				}
			}

			public override string ToString()
			{
				string sign = (Total < 0) ? "-" : "";
				return SkillName + " " + sign + Total;
			}
		}

		public CreatureSkillsForm(ICreature creature)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fCreature = creature;

			Dictionary<string, int> skills = CreatureHelper.ParseSkills(fCreature.Skills);
			foreach (string skill_name in Skills.GetSkillNames())
			{
				int level = fCreature.Level / 2;
				int ability = 0;

				string ability_name = Skills.GetKeyAbility(skill_name);
				switch (ability_name)
				{
					case "Strength":
						ability = fCreature.Strength.Modifier;
						break;
					case "Constitution":
						ability = fCreature.Constitution.Modifier;
						break;
					case "Dexterity":
						ability = fCreature.Dexterity.Modifier;
						break;
					case "Intelligence":
						ability = fCreature.Intelligence.Modifier;
						break;
					case "Wisdom":
						ability = fCreature.Wisdom.Modifier;
						break;
					case "Charisma":
						ability = fCreature.Charisma.Modifier;
						break;
				}

				SkillData sd = new SkillData();
				sd.SkillName = skill_name;
				sd.Ability = ability;
				sd.Level = level;

				if (skills.ContainsKey(skill_name))
				{
					int total = skills[skill_name];
					int misc = total - (ability + level);
					if (misc > 3)
					{
						sd.Trained = true;
						misc -= 5;
					}

					sd.Misc = misc;
				}

				fSkills.Add(sd);
			}

			update_list();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			TrainedBtn.Enabled = (SelectedSkill != null);
			TrainedBtn.Checked = ((SelectedSkill != null) && (SelectedSkill.Trained));
			EditSkillBtn.Enabled = (SelectedSkill != null);
		}

		ICreature fCreature = null;
		List<SkillData> fSkills = new List<SkillData>();

		SkillData SelectedSkill
		{
			get
			{
				if (SkillList.SelectedItems.Count != 0)
					return SkillList.SelectedItems[0].Tag as SkillData;

				return null;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			string skills = "";
			foreach (SkillData sd in fSkills)
			{
				if (!sd.Show)
					continue;

				if (skills != "")
					skills += "; ";

				skills += sd.ToString();
			}

			fCreature.Skills = skills;
		}

		void update_list()
		{
			SkillList.BeginUpdate();

			SkillList.Items.Clear();

			List<ListViewItem> items = new List<ListViewItem>();
			foreach (SkillData sd in fSkills)
			{
				ListViewItem lvi = new ListViewItem(sd.SkillName);
				lvi.SubItems.Add(sd.Trained ? "Yes" : "");
				lvi.SubItems.Add(sd.Ability.ToString());
				lvi.SubItems.Add((sd.Misc != 0) ? sd.Misc.ToString() : "");
				lvi.SubItems.Add(sd.Total.ToString());

				if (!sd.Show)
				{
					lvi.ForeColor = SystemColors.GrayText;
					lvi.UseItemStyleForSubItems = false;
				}

				lvi.Tag = sd;

				items.Add(lvi);
			}

			SkillList.Items.AddRange(items.ToArray());

			SkillList.EndUpdate();
		}

		private void SkillList_DoubleClick(object sender, EventArgs e)
		{
			TrainedBtn_Click(sender, e);
		}

		private void TrainedBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSkill == null)
				return;

			SelectedSkill.Trained = !SelectedSkill.Trained;
			update_list();
		}

		private void EditSkillBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSkill == null)
				return;

			string ability = Skills.GetKeyAbility(SelectedSkill.SkillName);
			CreatureSkillForm dlg = new CreatureSkillForm(SelectedSkill.SkillName, ability, SelectedSkill.Ability, SelectedSkill.Level, SelectedSkill.Trained, SelectedSkill.Misc);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedSkill.Trained = dlg.Trained;
				SelectedSkill.Misc = dlg.Misc;

				update_list();
			}
		}
	}
}
