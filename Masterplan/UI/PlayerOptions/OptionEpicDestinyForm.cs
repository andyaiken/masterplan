using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionEpicDestinyForm : Form
	{
		public OptionEpicDestinyForm(EpicDestiny pp)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fEpicDestiny = pp.Copy();

			NameBox.Text = fEpicDestiny.Name;
			PrereqBox.Text = fEpicDestiny.Prerequisites;
			DetailsBox.Text = fEpicDestiny.Details;
			QuoteBox.Text = fEpicDestiny.Quote;
			ImmortalityBox.Text = fEpicDestiny.Immortality;

			update_levels();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			LevelEditBtn.Enabled = (SelectedLevel != null);
		}

		public EpicDestiny EpicDestiny
		{
			get { return fEpicDestiny; }
		}
		EpicDestiny fEpicDestiny = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fEpicDestiny.Name = NameBox.Text;
			fEpicDestiny.Prerequisites = PrereqBox.Text;
			fEpicDestiny.Details = DetailsBox.Text;
			QuoteBox.Text = fEpicDestiny.Quote;
			fEpicDestiny.Immortality = ImmortalityBox.Text;
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

		private void LevelEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLevel != null)
			{
				int index = fEpicDestiny.Levels.IndexOf(SelectedLevel);

				OptionLevelForm dlg = new OptionLevelForm(SelectedLevel, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fEpicDestiny.Levels[index] = dlg.Level;
					update_levels();
				}
			}
		}

		void update_levels()
		{
			LevelList.Items.Clear();
			foreach (LevelData ld in fEpicDestiny.Levels)
			{
				ListViewItem lvi = LevelList.Items.Add(ld.ToString());
				lvi.Tag = ld;

				if (ld.Count == 0)
					lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
