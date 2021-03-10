using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class RandomCreatureForm : Form
	{
		public RandomCreatureForm(int level, IRole role)
		{
			InitializeComponent();

			fRole = role;

			LevelBox.Value = level;
			RoleBtn.Text = fRole.ToString();
		}

		public int Level
		{
			get { return (int)LevelBox.Value; }
		}

		public IRole Role
		{
			get { return fRole; }
		}
		IRole fRole = null;

		private void RoleBtn_Click(object sender, EventArgs e)
		{
			RoleForm dlg = new RoleForm(fRole, ThreatType.Creature);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fRole = dlg.Role;
				RoleBtn.Text = fRole.ToString();
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
