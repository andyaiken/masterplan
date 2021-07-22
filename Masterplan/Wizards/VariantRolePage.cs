using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.Wizards
{
	partial class VariantRolePage : UserControl, IWizardPage
	{
		public VariantRolePage()
		{
			InitializeComponent();
		}

		VariantData fData = null;

		#region IWizardPage Members

		public bool AllowNext
		{
			get { return true; }
		}

		public bool AllowBack
		{
			get { return true; }
		}

		public bool AllowFinish
		{
			get { return false; }
		}

		public void OnShown(object data)
		{
			if (fData == null)
				fData = data as VariantData;

			RoleBox.Items.Clear();
			foreach (RoleType role in fData.Roles)
				RoleBox.Items.Add(role);

			RoleBox.SelectedIndex = fData.SelectedRoleIndex;
		}

		public bool OnBack()
		{
			return true;
		}

		public bool OnNext()
		{

			return true;
		}

		public bool OnFinish()
		{
			return false;
		}

		#endregion

		private void RoleBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			fData.SelectedRoleIndex = RoleBox.SelectedIndex;
		}
	}
}
