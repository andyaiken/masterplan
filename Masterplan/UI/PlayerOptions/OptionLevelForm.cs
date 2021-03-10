using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionLevelForm : Form
	{
		public OptionLevelForm(LevelData level, bool show_features)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fLevel = level.Copy();
			Text = "Level " + fLevel.Level;

			if (!show_features)
				Pages.TabPages.Remove(FeaturesPage);

			update_features();
			update_powers();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			FeatureRemoveBtn.Enabled = (SelectedFeature != null);
			FeatureEditBtn.Enabled = (SelectedFeature != null);

			PowerRemoveBtn.Enabled = (SelectedPower != null);
			PowerEditBtn.Enabled = (SelectedPower != null);
		}

		public LevelData Level
		{
			get { return fLevel; }
		}
		LevelData fLevel = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		public Feature SelectedFeature
		{
			get
			{
				if (FeatureList.SelectedItems.Count != 0)
					return FeatureList.SelectedItems[0].Tag as Feature;

				return null;
			}
		}

		private void FeatureAddBtn_Click(object sender, EventArgs e)
		{
			Feature ft = new Feature();
			ft.Name = "New Feature";

			OptionFeatureForm dlg = new OptionFeatureForm(ft);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fLevel.Features.Add(dlg.Feature);
				update_features();
			}
		}

		private void FeatureRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedFeature != null)
			{
				fLevel.Features.Remove(SelectedFeature);
				update_features();
			}
		}

		private void FeatureEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedFeature != null)
			{
				int index = fLevel.Features.IndexOf(SelectedFeature);

				OptionFeatureForm dlg = new OptionFeatureForm(SelectedFeature);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fLevel.Features[index] = dlg.Feature;
					update_features();
				}
			}
		}

		void update_features()
		{
			FeatureList.Items.Clear();
			foreach (Feature ft in fLevel.Features)
			{
				ListViewItem lvi = FeatureList.Items.Add(ft.Name);
				lvi.Tag = ft;
			}

			if (fLevel.Features.Count == 0)
			{
				ListViewItem lvi = FeatureList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		public PlayerPower SelectedPower
		{
			get
			{
				if (PowerList.SelectedItems.Count != 0)
					return PowerList.SelectedItems[0].Tag as PlayerPower;

				return null;
			}
		}

		private void PowerAddBtn_Click(object sender, EventArgs e)
		{
			PlayerPower power = new PlayerPower();
			power.Name = "New Power";

			OptionPowerForm dlg = new OptionPowerForm(power);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fLevel.Powers.Add(dlg.Power);
				update_powers();
			}
		}

		private void PowerRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPower != null)
			{
				fLevel.Powers.Remove(SelectedPower);
				update_powers();
			}
		}

		private void PowerEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPower != null)
			{
				int index = fLevel.Powers.IndexOf(SelectedPower);

				OptionPowerForm dlg = new OptionPowerForm(SelectedPower);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fLevel.Powers[index] = dlg.Power;
					update_powers();
				}
			}
		}

		void update_powers()
		{
			PowerList.Items.Clear();
			foreach (PlayerPower power in fLevel.Powers)
			{
				ListViewItem lvi = PowerList.Items.Add(power.Name);
				lvi.Tag = power;
			}

			if (fLevel.Powers.Count == 0)
			{
				ListViewItem lvi = PowerList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
