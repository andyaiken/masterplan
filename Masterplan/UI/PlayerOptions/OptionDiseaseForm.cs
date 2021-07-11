using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionDiseaseForm : Form
	{
		public OptionDiseaseForm(Disease disease)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fDisease = disease.Copy();

			NameBox.Text = fDisease.Name;
			LevelBox.Text = fDisease.Level;
			ImproveBox.Text = fDisease.ImproveDC;
			MaintainBox.Text = fDisease.MaintainDC;

			DetailsBox.Text = fDisease.Details;

			update_list();
		}

		~OptionDiseaseForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedLevel != null);
			EditBtn.Enabled = (SelectedLevel != null);
			UpBtn.Enabled = ((SelectedLevel != null) && (fDisease.Levels[0] != SelectedLevel));
			DownBtn.Enabled = ((SelectedLevel != null) && (fDisease.Levels[fDisease.Levels.Count - 1] != SelectedLevel));
		}

		public Disease Disease
		{
			get { return fDisease; }
		}
		Disease fDisease = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fDisease.Name = NameBox.Text;
			fDisease.Level = LevelBox.Text;
			fDisease.ImproveDC = ImproveBox.Text;
			fDisease.MaintainDC = MaintainBox.Text;

			fDisease.Details = DetailsBox.Text;
		}

		public string SelectedLevel
		{
			get
			{
				if (LevelList.SelectedItems.Count != 0)
					return LevelList.SelectedItems[0].Tag as string;

				return null;
			}
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			string level = "New Disease Level";

			OptionDiseaseLevelForm dlg = new OptionDiseaseLevelForm(level);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fDisease.Levels.Add(dlg.DiseaseLevel);
				update_list();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLevel != null)
			{
				fDisease.Levels.Remove(SelectedLevel);
				update_list();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLevel != null)
			{
				int index = fDisease.Levels.IndexOf(SelectedLevel);

				OptionDiseaseLevelForm dlg = new OptionDiseaseLevelForm(SelectedLevel);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fDisease.Levels[index] = dlg.DiseaseLevel;
					update_list();
				}
			}
		}

		private void UpBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLevel != null)
			{
				int index = fDisease.Levels.IndexOf(SelectedLevel);
				string temp = fDisease.Levels[index - 1];

				fDisease.Levels[index - 1] = SelectedLevel;
				fDisease.Levels[index] = temp;

				update_list();
			}
		}

		private void DownBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLevel != null)
			{
				int index = fDisease.Levels.IndexOf(SelectedLevel);
				string temp = fDisease.Levels[index + 1];

				fDisease.Levels[index + 1] = SelectedLevel;
				fDisease.Levels[index] = temp;

				update_list();
			}
		}

		void update_list()
		{
			LevelList.Items.Clear();

			LevelList.Items.Add("The target is cured.");
			foreach (string level in fDisease.Levels)
			{
				string display_level = level;
				if (fDisease.Levels.Count > 1)
				{
					int index = fDisease.Levels.IndexOf(level);
					if (index == 0)
						display_level = "Initial state: " + display_level;
					if (index == fDisease.Levels.Count - 1)
						display_level = "Final state: " + display_level;
				}

				ListViewItem lvi = LevelList.Items.Add(display_level);
				lvi.Tag = level;
			}
		}
	}
}
