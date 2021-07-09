using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class EncyclopediaGroupForm : Form
	{
		public EncyclopediaGroupForm(EncyclopediaGroup group)
		{
			InitializeComponent();

			fGroup = group.Copy();

			TitleBox.Text = fGroup.Name;

			foreach (EncyclopediaEntry ee in Session.Project.Encyclopedia.Entries)
			{
				ListViewItem lvi = EntryList.Items.Add(ee.Name);
				lvi.Tag = ee;
				lvi.Checked = fGroup.EntryIDs.Contains(ee.ID);
			}

			if (EntryList.Items.Count == 0)
			{
				ListViewItem lvi = EntryList.Items.Add("(no entries)");
				lvi.ForeColor = SystemColors.GrayText;

                EntryList.CheckBoxes = false;
			}
		}

		public EncyclopediaGroup Group
		{
			get {return fGroup;}
		}
		EncyclopediaGroup fGroup = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fGroup.Name = TitleBox.Text;

			fGroup.EntryIDs.Clear();
			foreach (ListViewItem lvi in EntryList.CheckedItems)
			{
				EncyclopediaEntry ee = lvi.Tag as EncyclopediaEntry;
				fGroup.EntryIDs.Add(ee.ID);
			}
		}
	}
}
