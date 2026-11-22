#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
                // Stat blocks show skills as "Name +N" (or "Name -N"). Total already carries
                // its own minus sign when negative, so we only add "+" for zero and positive values.
                // (Up to 14.1.0.12 this added nothing for positives, so "Perception 11" lost its "+",
                // and an extra "-" for negatives, giving "--2", which ParseSkills read as 0.)
                string sign = (Total >= 0) ? "+" : "";
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

        ~CreatureSkillsForm()
        {
            Application.Idle -= Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            TrainedBtn.Enabled = (SelectedSkill != null);
            TrainedBtn.Checked = ((SelectedSkill != null) && (SelectedSkill.Trained));
            EditSkillBtn.Enabled = (SelectedSkill != null);
        }

        ICreature fCreature = null;
        List<SkillData> fSkills = new List<SkillData>();

        // True once the user has changed something in this dialog (Trained, or Edit). OK only
        // rewrites the skills text when this is true (see OKBtn_Click).
        bool fChanged = false;

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
            // Nothing changed: leave the skills text exactly as it was (14.1.0.15). The grid only
            // knows the 17 standard skills written as "Name +N"; rewriting from it drops anything
            // else, e.g. the official note in "Stealth +22 (+27 in snow or ice)", which was even
            // read as 0 and saved as "Stealth +0" when the user only looked and pressed OK
            // (finding F21; keeping such entries while editing is planned for M14.2, MPX-D38).
            if (!fChanged)
                return;

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
                lvi.SubItems.Add((sd.Level >= 0) ? "+" + sd.Level.ToString() : sd.Level.ToString());
                lvi.SubItems.Add((sd.Ability >= 0) ? "+" + sd.Ability.ToString() : sd.Ability.ToString());
                lvi.SubItems.Add(sd.Trained ? "+5" : "");
                if (sd.Misc != 0)
                {
                    lvi.SubItems.Add((sd.Misc >= 0) ? "+" + sd.Misc.ToString() : sd.Misc.ToString());
                }
                else
                {
                    lvi.SubItems.Add("");
                }
                lvi.SubItems.Add((sd.Total >= 0) ? "+" + sd.Total.ToString() : sd.Total.ToString());

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
            fChanged = true;
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
                fChanged = true;

                update_list();
            }
        }
    }
}
