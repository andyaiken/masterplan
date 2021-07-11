using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TrapProfileForm : Form
	{
		public TrapProfileForm(Trap trap)
		{
			InitializeComponent();

			Array types = Enum.GetValues(typeof(TrapType));
			foreach (TrapType type in types)
				TypeBox.Items.Add(type);

			Application.Idle += new EventHandler(Application_Idle);

			fTrap = trap.Copy();

			NameBox.Text = fTrap.Name;
			TypeBox.SelectedItem = fTrap.Type;
			LevelBox.Value = fTrap.Level;
			RoleBtn.Text = fTrap.Role.ToString();

			if (fTrap.Initiative == int.MinValue)
			{
				HasInitBox.Checked = false;
				InitBox.Value = 0;
			}
			else
			{
				HasInitBox.Checked = true;
				InitBox.Value = fTrap.Initiative;
			}
		}

		~TrapProfileForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			InitBox.Enabled = HasInitBox.Checked;
		}

		public Trap Trap
		{
			get { return fTrap; }
		}
		Trap fTrap = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fTrap.Name = NameBox.Text;
			fTrap.Type = (TrapType)TypeBox.SelectedItem;
			fTrap.Level = (int)LevelBox.Value;
			fTrap.Initiative = HasInitBox.Checked ? (int)InitBox.Value : int.MinValue;
		}

		private void RoleBtn_Click(object sender, EventArgs e)
		{
			RoleForm dlg = new RoleForm(fTrap.Role, ThreatType.Trap);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fTrap.Role = dlg.Role;
				RoleBtn.Text = fTrap.Role.ToString();
			}
		}
	}
}
