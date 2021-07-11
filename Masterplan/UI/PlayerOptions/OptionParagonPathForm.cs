using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionParagonPathForm : Form
	{
		public OptionParagonPathForm(ParagonPath pp)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fParagonPath = pp.Copy();

			NameBox.Text = fParagonPath.Name;
			PrereqBox.Text = fParagonPath.Prerequisites;
			DetailsBox.Text = fParagonPath.Details;
			QuoteBox.Text = fParagonPath.Quote;

			update_levels();
		}

		~OptionParagonPathForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			LevelEditBtn.Enabled = (SelectedLevel != null);
		}

		public ParagonPath ParagonPath
		{
			get { return fParagonPath; }
		}
		ParagonPath fParagonPath = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fParagonPath.Name = NameBox.Text;
			fParagonPath.Prerequisites = PrereqBox.Text;
			fParagonPath.Details = DetailsBox.Text;
			fParagonPath.Quote = QuoteBox.Text;
		}

		public LevelData SelectedLevel
		{
			get
			{
				if (LevelList.SelectedItems.Count != 0)
					return LevelList.SelectedItems[0].Tag as LevelData;

				return null;
			}
		}

		private void FeatureEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLevel != null)
			{
				int index = fParagonPath.Levels.IndexOf(SelectedLevel);

				OptionLevelForm dlg = new OptionLevelForm(SelectedLevel, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fParagonPath.Levels[index] = dlg.Level;
					update_levels();
				}
			}
		}

		void update_levels()
		{
			LevelList.Items.Clear();
			foreach (LevelData ld in fParagonPath.Levels)
			{
				ListViewItem lvi = LevelList.Items.Add(ld.ToString());
				lvi.Tag = ld;

				if (ld.Count == 0)
					lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
