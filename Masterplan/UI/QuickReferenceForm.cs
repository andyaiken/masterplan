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

            DamageList.EndUpdate();
		}

		#endregion
	}
}
