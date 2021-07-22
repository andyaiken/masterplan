using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.Controls
{
	partial class QuestPanel : UserControl
	{
		public QuestPanel()
		{
			InitializeComponent();

			Array types = Enum.GetValues(typeof(QuestType));
			foreach (QuestType type in types)
				TypeBox.Items.Add(type);
		}

		public Quest Quest
		{
			get { return fQuest; }
			set
			{
				fQuest = value;
				update_view();
			}
		}
		Quest fQuest = null;

		bool fUpdating = false;

		private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (fUpdating)
				return;

			fQuest.Type = (QuestType)TypeBox.SelectedItem;
			update_view();
		}

		private void LevelBox_ValueChanged(object sender, EventArgs e)
		{
			if (fUpdating)
				return;

			fQuest.Level = (int)LevelBox.Value;
			update_view();
		}

		private void XPSlider_Scroll(object sender, EventArgs e)
		{
			if (fUpdating)
				return;

			fQuest.XP = XPSlider.Value;
			update_view();
		}

		void update_view()
		{
			fUpdating = true;

			TypeBox.SelectedItem = fQuest.Type;
			LevelBox.Value = fQuest.Level;

			XPSlider.Visible = (fQuest.Type == QuestType.Minor);
			if (XPSlider.Visible)
			{
				Pair<int, int> range = Experience.GetMinorQuestXP(fQuest.Level);
				XPSlider.SetRange(range.First, range.Second);
				MinMaxLbl.Text = range.First + " - " + range.Second;

				if (fQuest.XP < range.First)
					fQuest.XP = range.First;
				if (fQuest.XP > range.Second)
					fQuest.XP = range.Second;

				XPSlider.Value = fQuest.XP;
			}
			XPBox.Text = fQuest.GetXP() + " XP";

			fUpdating = false;
		}
	}
}
