using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DamageTypesForm : Form
	{
		public DamageTypesForm(List<DamageType> types)
		{
			InitializeComponent();

			fTypes = types;

			Array damage_types = Enum.GetValues(typeof(DamageType));
			foreach (DamageType dt in damage_types)
			{
				if (dt == DamageType.Untyped)
					continue;

				ListViewItem lvi = TypeList.Items.Add(dt.ToString());
				lvi.Checked = fTypes.Contains(dt);
				lvi.Tag = dt;
			}
		}

		public List<DamageType> Types
		{
			get { return fTypes; }
		}
		List<DamageType> fTypes = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			List<DamageType> types = new List<DamageType>();
			foreach (ListViewItem lvi in TypeList.CheckedItems)
			{
				DamageType dt = (DamageType)lvi.Tag;
				types.Add(dt);
			}

			fTypes = types;
		}
	}
}
