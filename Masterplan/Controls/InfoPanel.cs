using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.UI;

namespace Masterplan.Controls
{
	partial class InfoPanel : UserControl
	{
		public InfoPanel()
		{
			InitializeComponent();

			update_list();
		}

		public int Level
		{
			get { return (int)LevelBox.Value; }
			set { LevelBox.Value = value; }
		}

		private void LevelBox_ValueChanged(object sender, EventArgs e)
		{
			update_list();
		}

		void update_list()
		{
			int level = (int)LevelBox.Value;

			int aid_another = 10 + (level / 2);

			string normal = Statistics.NormalDamage(level);
			string multiple = Statistics.MultipleDamage(level);
			string minion = Statistics.MinionDamage(level).ToString();

			SkillList.BeginUpdate();
			SkillList.Items.Clear();

			#region Skill DCs

			ListViewItem lvi_easy = SkillList.Items.Add("Easy");
			lvi_easy.SubItems.Add("DC " + AI.GetSkillDC(Difficulty.Easy, level));
			lvi_easy.Group = SkillList.Groups[0];

			ListViewItem lvi_moderate = SkillList.Items.Add("Moderate");
			lvi_moderate.SubItems.Add("DC " + AI.GetSkillDC(Difficulty.Moderate, level));
			lvi_moderate.Group = SkillList.Groups[0];

			ListViewItem lvi_hard = SkillList.Items.Add("Hard");
			lvi_hard.SubItems.Add("DC " + AI.GetSkillDC(Difficulty.Hard, level));
			lvi_hard.Group = SkillList.Groups[0];

			#endregion

			#region Aid Another

			ListViewItem lvi_aid = SkillList.Items.Add("Aid Another");
			lvi_aid.SubItems.Add("DC " + aid_another);
			lvi_aid.Group = SkillList.Groups[1];

			#endregion

			#region Damage

			ListViewItem lvi_damage = SkillList.Items.Add("Against a single target");
			lvi_damage.SubItems.Add(normal);
			lvi_damage.Tag = DiceExpression.Parse(normal);
			lvi_damage.Group = SkillList.Groups[2];

			ListViewItem lvi_multiple = SkillList.Items.Add("Against multiple targets");
			lvi_multiple.SubItems.Add(multiple);
			lvi_multiple.Tag = DiceExpression.Parse(multiple);
			lvi_multiple.Group = SkillList.Groups[2];

			ListViewItem lvi_minion = SkillList.Items.Add("From a minion");
			lvi_minion.SubItems.Add(minion);
			lvi_minion.Tag = DiceExpression.Parse(minion);
			lvi_minion.Group = SkillList.Groups[2];

			#endregion

			#region Monster Knowledge

			ListViewItem lvi_aberrant = SkillList.Items.Add("Aberrant");
			lvi_aberrant.SubItems.Add("Dungeoneering");
			lvi_aberrant.Group = SkillList.Groups[3];

			ListViewItem lvi_elemental = SkillList.Items.Add("Elemental");
			lvi_elemental.SubItems.Add("Arcana");
			lvi_elemental.Group = SkillList.Groups[3];

			ListViewItem lvi_fey = SkillList.Items.Add("Fey");
			lvi_fey.SubItems.Add("Arcana");
			lvi_fey.Group = SkillList.Groups[3];

			ListViewItem lvi_immortal = SkillList.Items.Add("Immortal");
			lvi_immortal.SubItems.Add("Religion");
			lvi_immortal.Group = SkillList.Groups[3];

			ListViewItem lvi_natural = SkillList.Items.Add("Natural");
			lvi_natural.SubItems.Add("Nature");
			lvi_natural.Group = SkillList.Groups[3];

			ListViewItem lvi_shadow = SkillList.Items.Add("Shadow");
			lvi_shadow.SubItems.Add("Arcana");
			lvi_shadow.Group = SkillList.Groups[3];

			ListViewItem lvi_undead = SkillList.Items.Add("Undead keyword");
			lvi_undead.SubItems.Add("Religion");
			lvi_undead.Group = SkillList.Groups[3];

			#endregion

			SkillList.EndUpdate();
		}

		private void DamageList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedDamageExpression != null)
			{
				DieRollerForm dlg = new DieRollerForm();
				dlg.Expression = SelectedDamageExpression;
				dlg.ShowDialog();
			}
		}

		public DiceExpression SelectedDamageExpression
		{
			get
			{
				if (SkillList.SelectedItems.Count != 0)
					return SkillList.SelectedItems[0].Tag as DiceExpression;

				return null;
			}
		}
	}
}
