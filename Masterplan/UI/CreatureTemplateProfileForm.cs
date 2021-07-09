using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CreatureTemplateProfileForm : Form
	{
		public CreatureTemplateProfileForm(CreatureTemplate t)
		{
			InitializeComponent();

			TypeBox.Items.Add(CreatureTemplateType.Functional);
			TypeBox.Items.Add(CreatureTemplateType.Class);

			RoleBox.Items.Add(RoleType.Artillery);
			RoleBox.Items.Add(RoleType.Brute);
			RoleBox.Items.Add(RoleType.Controller);
			RoleBox.Items.Add(RoleType.Lurker);
			RoleBox.Items.Add(RoleType.Skirmisher);
			RoleBox.Items.Add(RoleType.Soldier);

			fTemplate = t.Copy();

			NameBox.Text = fTemplate.Name;
			TypeBox.SelectedItem = fTemplate.Type;
			RoleBox.SelectedItem = fTemplate.Role;
			LeaderBox.Checked = fTemplate.Leader;
		}

		public CreatureTemplate Template
		{
			get { return fTemplate; }
		}
		CreatureTemplate fTemplate = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fTemplate.Name = NameBox.Text;
			fTemplate.Type = (CreatureTemplateType)TypeBox.SelectedItem;
			fTemplate.Role = (RoleType)RoleBox.SelectedItem;
			fTemplate.Leader = LeaderBox.Checked;
		}
	}
}
