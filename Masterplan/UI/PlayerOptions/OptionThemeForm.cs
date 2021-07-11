using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionThemeForm : Form
	{
		public OptionThemeForm(Theme theme)
		{
			InitializeComponent();

			RoleBox.Items.Add("Controller");
			RoleBox.Items.Add("Defender");
			RoleBox.Items.Add("Leader");
			RoleBox.Items.Add("Striker");

			SourceBox.Items.Add("Martial");
			SourceBox.Items.Add("Arcane");
			SourceBox.Items.Add("Divine");
			SourceBox.Items.Add("Primal");
			SourceBox.Items.Add("Psionic");
			SourceBox.Items.Add("Shadow");
			SourceBox.Items.Add("Elemental");

			Application.Idle += new EventHandler(Application_Idle);

			fTheme = theme.Copy();

			NameBox.Text = fTheme.Name;
			PrereqBox.Text = fTheme.Prerequisites;
			RoleBox.Text = fTheme.SecondaryRole;
			SourceBox.Text = fTheme.PowerSource;
			DetailsBox.Text = fTheme.Details;
			QuoteBox.Text = fTheme.Quote;

			update_levels();
		}

		~OptionThemeForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			LevelEditBtn.Enabled = (SelectedLevel != null);
		}

		public Theme Theme
		{
			get { return fTheme; }
		}
		Theme fTheme = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fTheme.Name = NameBox.Text;
			fTheme.Prerequisites = PrereqBox.Text;
			fTheme.Details = DetailsBox.Text;
			fTheme.Quote = QuoteBox.Text;
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
				int index = fTheme.Levels.IndexOf(SelectedLevel);

				OptionLevelForm dlg = new OptionLevelForm(SelectedLevel, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fTheme.Levels[index] = dlg.Level;
					update_levels();
				}
			}
		}

		void update_levels()
		{
			LevelList.Items.Clear();
			foreach (LevelData ld in fTheme.Levels)
			{
				ListViewItem lvi = LevelList.Items.Add(ld.ToString());
				lvi.Tag = ld;

				if (ld.Count == 0)
					lvi.ForeColor = SystemColors.GrayText;
			}
		}

		private void PowerBtn_Click(object sender, EventArgs e)
		{
			OptionPowerForm dlg = new OptionPowerForm(fTheme.GrantedPower);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fTheme.GrantedPower = dlg.Power;
			}
		}
	}
}
