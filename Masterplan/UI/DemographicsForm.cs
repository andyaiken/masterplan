using System;
using System.Windows.Forms;

using Masterplan.Controls;
using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DemographicsForm : Form
	{
		public DemographicsForm(Library library, DemographicsSource source)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			BreakdownPanel.Library = library;
			BreakdownPanel.Source = source;
		}

		~DemographicsForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RoleBtn.Enabled = (BreakdownPanel.Source != DemographicsSource.MagicItems);
			StatusBtn.Enabled = (BreakdownPanel.Source != DemographicsSource.MagicItems);

			LevelBtn.Checked = (BreakdownPanel.Mode == Masterplan.Controls.DemographicsMode.Level);
			RoleBtn.Checked = (BreakdownPanel.Mode == Masterplan.Controls.DemographicsMode.Role);
			StatusBtn.Checked = (BreakdownPanel.Mode == Masterplan.Controls.DemographicsMode.Status);
		}

		private void LevelBtn_Click(object sender, EventArgs e)
		{
			BreakdownPanel.Mode = DemographicsMode.Level;
		}

		private void RoleBtn_Click(object sender, EventArgs e)
		{
			BreakdownPanel.Mode = DemographicsMode.Role;
		}

		private void StatusBtn_Click(object sender, EventArgs e)
		{
			BreakdownPanel.Mode = DemographicsMode.Status;
		}
	}
}
