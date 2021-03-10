using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.UI;

namespace Masterplan.Controls
{
	partial class TrapElementPanel : UserControl
	{
		public TrapElementPanel()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_view();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ChooseBtn.Enabled = (Session.Traps.Count != 0);
		}

		public TrapElement Trap
		{
			get { return fTrapElement; }
			set
			{
				fTrapElement = value;
				update_view();
			}
		}
		TrapElement fTrapElement = null;

		public TrapSkillData SelectedSkill
		{
			get
			{
				if (TrapList.SelectedItems.Count != 0)
					return TrapList.SelectedItems[0].Tag as TrapSkillData;

				return null;
			}
		}

		public string SelectedCountermeasure
		{
			get
			{
				if (TrapList.SelectedItems.Count != 0)
					return TrapList.SelectedItems[0].Tag as string;

				return null;
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			TrapBuilderForm dlg = new TrapBuilderForm(fTrapElement.Trap);
			//TrapForm dlg = new TrapForm(fTrapElement.Trap);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fTrapElement.Trap = dlg.Trap;
				update_view();
			}
		}

        private void LocationBtn_Click(object sender, EventArgs e)
        {
            MapAreaSelectForm dlg = new MapAreaSelectForm(fTrapElement.MapID, fTrapElement.MapAreaID);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fTrapElement.MapID = (dlg.Map != null) ? dlg.Map.ID : Guid.Empty;
                fTrapElement.MapAreaID = (dlg.MapArea != null) ? dlg.MapArea.ID : Guid.Empty;

                update_view();
            }
        }

		private void ChooseBtn_Click(object sender, EventArgs e)
		{
			// Choose a standard trap
			TrapSelectForm dlg = new TrapSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fTrapElement.Trap = dlg.Trap.Copy();
				update_view();
			}
		}

		private void TrapList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedSkill != null)
			{
				int index = fTrapElement.Trap.Skills.IndexOf(SelectedSkill);

				TrapSkillForm dlg = new TrapSkillForm(SelectedSkill, fTrapElement.Trap.Level);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fTrapElement.Trap.Skills[index] = dlg.SkillData;
					update_view();
				}
			}

			if (SelectedCountermeasure != null)
			{
				int index = fTrapElement.Trap.Countermeasures.IndexOf(SelectedCountermeasure);

				TrapCountermeasureForm dlg = new TrapCountermeasureForm(SelectedCountermeasure, fTrapElement.Trap.Level);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fTrapElement.Trap.Countermeasures[index] = dlg.Countermeasure;
					update_view();
				}
			}
		}

		void update_view()
		{
			TrapList.Items.Clear();

			if (fTrapElement == null)
				return;

			ListViewItem name_lvi = TrapList.Items.Add(fTrapElement.Trap.Name + ": " + fTrapElement.GetXP() + " XP");
			name_lvi.Group = TrapList.Groups[0];

			ListViewItem info_lvi = TrapList.Items.Add(fTrapElement.Trap.Info);
			info_lvi.Group = TrapList.Groups[0];

            if (fTrapElement.MapID != Guid.Empty)
            {
                Map m = Session.Project.FindTacticalMap(fTrapElement.MapID);
                MapArea ma = m.FindArea(fTrapElement.MapAreaID);

                string str = "Location: " + m.Name;
                if (ma != null)
                    str += " (" + ma.Name + ")";

                ListViewItem lvi_loc = TrapList.Items.Add(str);
                lvi_loc.Group = TrapList.Groups[0];
            }

			foreach (TrapSkillData tsd in fTrapElement.Trap.Skills)
			{
				ListViewItem lvi = TrapList.Items.Add(tsd.ToString());
				lvi.Group = TrapList.Groups[1];
				lvi.Tag = tsd;
			}

			if (fTrapElement.Trap.Skills.Count == 0)
			{
				ListViewItem lvi = TrapList.Items.Add("(no skills)");
				lvi.Group = TrapList.Groups[1];
				lvi.ForeColor = SystemColors.GrayText;
			}

			foreach (string cm in fTrapElement.Trap.Countermeasures)
			{
				ListViewItem lvi = TrapList.Items.Add(cm);
				lvi.Group = TrapList.Groups[2];
				lvi.Tag = cm;
			}

			if (fTrapElement.Trap.Countermeasures.Count == 0)
			{
				ListViewItem lvi = TrapList.Items.Add("(no countermeasures)");
				lvi.Group = TrapList.Groups[2];
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		private void AddLibraryBtn_Click(object sender, EventArgs e)
		{
			LibrarySelectForm dlg = new LibrarySelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Library lib = dlg.SelectedLibrary;

				lib.Traps.Add(fTrapElement.Trap.Copy());
			}
		}
	}
}
