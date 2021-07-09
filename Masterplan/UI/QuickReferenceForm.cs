using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Extensibility;
using Masterplan.Tools;

namespace Masterplan.UI
{
    partial class QuickReferenceForm : Form
    {
        public QuickReferenceForm()
        {
            InitializeComponent();

            foreach (IAddIn addin in Session.AddIns)
            {
                foreach (IPage page in addin.QuickReferencePages)
                {
                    TabPage tabpage = new TabPage();
                    tabpage.Text = page.Name;

                    tabpage.Controls.Add(page.Control);
                    page.Control.Dock = DockStyle.Fill;

                    Pages.TabPages.Add(tabpage);
                }
            }

			UpdateView();
        }

        private void QuickReferenceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
		}

		public void UpdateView()
		{
			if (Session.Project != null)
				LevelBox.Value = Session.Project.Party.Level;
			update_skills();

			foreach (IAddIn addin in Session.AddIns)
			{
				foreach (IPage page in addin.QuickReferencePages)
					page.UpdateView();
			}
		}

		#region Skills

		private void LevelBox_ValueChanged(object sender, EventArgs e)
        {
            update_skills();
        }

        void update_skills()
        {
            int level = (int)LevelBox.Value;

            SkillList.BeginUpdate();
            SkillList.Items.Clear();
            
            ListViewItem lvi_easy = SkillList.Items.Add("Easy");
            lvi_easy.SubItems.Add(AI.GetSkillDC(Difficulty.Easy, level).ToString());

            ListViewItem lvi_moderate = SkillList.Items.Add("Moderate");
            lvi_moderate.SubItems.Add(AI.GetSkillDC(Difficulty.Moderate, level).ToString());

            ListViewItem lvi_hard = SkillList.Items.Add("Hard");
            lvi_hard.SubItems.Add(AI.GetSkillDC(Difficulty.Hard, level).ToString());

            SkillList.EndUpdate();

            DamageList.BeginUpdate();
            DamageList.Items.Clear();

			DamageList.ShowGroups = false;

			ListViewItem lvi_damage = DamageList.Items.Add("Against a single target");
			lvi_damage.SubItems.Add(Statistics.NormalDamage(level));
			lvi_damage.Group = DamageList.Groups[0];

			ListViewItem lvi_multiple = DamageList.Items.Add("Against multiple targets");
			lvi_multiple.SubItems.Add(Statistics.MultipleDamage(level));
			lvi_multiple.Group = DamageList.Groups[0];

			/*
			ListViewItem lvi_low_normal = DamageList.Items.Add("Low");
			lvi_low_normal.SubItems.Add(Powers.Damage(DamageDegree.Low, DamageCategory.Normal, level));
			lvi_low_normal.Group = DamageList.Groups[0];

            ListViewItem lvi_medium_normal = DamageList.Items.Add("Medium");
            lvi_medium_normal.SubItems.Add(Powers.Damage(DamageDegree.Medium, DamageCategory.Normal, level));
            lvi_medium_normal.Group = DamageList.Groups[0];

            ListViewItem lvi_high_normal = DamageList.Items.Add("High");
            lvi_high_normal.SubItems.Add(Powers.Damage(DamageDegree.High, DamageCategory.Normal, level));
            lvi_high_normal.Group = DamageList.Groups[0];

            ListViewItem lvi_low_limited = DamageList.Items.Add("Low");
            lvi_low_limited.SubItems.Add(Powers.Damage(DamageDegree.Low, DamageCategory.Limited, level));
            lvi_low_limited.Group = DamageList.Groups[1];

            ListViewItem lvi_medium_limited = DamageList.Items.Add("Medium");
            lvi_medium_limited.SubItems.Add(Powers.Damage(DamageDegree.Medium, DamageCategory.Limited, level));
            lvi_medium_limited.Group = DamageList.Groups[1];

            ListViewItem lvi_high_limited = DamageList.Items.Add("High");
            lvi_high_limited.SubItems.Add(Powers.Damage(DamageDegree.High, DamageCategory.Limited, level));
            lvi_high_limited.Group = DamageList.Groups[1];
			*/

            DamageList.EndUpdate();
		}

		#endregion
	}
}
