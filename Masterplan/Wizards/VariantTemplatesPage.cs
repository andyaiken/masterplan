using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils.Wizards;

using Masterplan.Data;
using Masterplan.UI;

namespace Masterplan.Wizards
{
	partial class VariantTemplatesPage : UserControl, IWizardPage
	{
		public VariantTemplatesPage()
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
			{
				fData = data as VariantData;

				List<CreatureTemplate> templates = Session.Templates;
				foreach (CreatureTemplate ct in templates)
				{
					ListViewItem lvi = TemplateList.Items.Add(ct.Name);
					lvi.SubItems.Add(ct.Info);
					lvi.Tag = ct;
				}
			}
		}

		public bool OnBack()
		{
			return true;
		}

		public bool OnNext()
		{
			int steps = 0;
			ComplexRole role = fData.BaseCreature.Role as ComplexRole;
			switch (role.Flag)
			{
				case RoleFlag.Elite:
					steps = 1;
					break;
				case RoleFlag.Solo:
					steps = 2;
					break;
			}

			steps += TemplateList.CheckedItems.Count;

			if (steps > 2)
			{
				string str = "You can not normally apply that many templates to this creature.";
				str += Environment.NewLine;
				str += "Are you sure you want to continue?";

				DialogResult dr = MessageBox.Show(str, "Creature Builder", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return false;
			}

			// Set templates
			fData.Templates.Clear();
			foreach (ListViewItem lvi in TemplateList.CheckedItems)
				fData.Templates.Add(lvi.Tag as CreatureTemplate);

			return true;
		}

		public bool OnFinish()
		{
			return false;
		}

		#endregion

		private void TemplateList_DoubleClick(object sender, EventArgs e)
		{
			if (TemplateList.SelectedItems.Count != 0)
			{
				CreatureTemplate ct = TemplateList.SelectedItems[0].Tag as CreatureTemplate;
				if (ct != null)
				{
					CreatureTemplateDetailsForm dlg = new CreatureTemplateDetailsForm(ct);
					dlg.ShowDialog();
				}
			}
		}
	}
}
