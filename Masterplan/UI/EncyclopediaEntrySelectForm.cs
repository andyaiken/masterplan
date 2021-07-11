using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class EncyclopediaEntrySelectForm : Form
	{
        public EncyclopediaEntrySelectForm(List<Guid> ignore_ids)
		{
			InitializeComponent();

            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            foreach (EncyclopediaEntry entry in Session.Project.Encyclopedia.Entries)
            {
                if ((entry.Category != null) && (entry.Category != ""))
                    bst.Add(entry.Category);
            }
            List<string> categories = bst.SortedList;
            categories.Insert(0, "Miscellaneous Entries");

            foreach (string cat in categories)
                EntryList.Groups.Add(new ListViewGroup(cat, cat));

			foreach (EncyclopediaEntry entry in Session.Project.Encyclopedia.Entries)
			{
                if (ignore_ids.Contains(entry.ID))
                    continue;

				ListViewItem lvi = EntryList.Items.Add(entry.Name);
				lvi.Tag = entry;

                if ((entry.Category != null) && (entry.Category != ""))
                    lvi.Group = EntryList.Groups[entry.Category];
                else
                    lvi.Group = EntryList.Groups["Miscellaneous Entries"];
			}

            if (EntryList.Items.Count == 0)
            {
                ListViewItem lvi = EntryList.Items.Add("(no entries)");
                lvi.ForeColor = SystemColors.GrayText;
            }

			Application.Idle += new EventHandler(Application_Idle);
		}

		~EncyclopediaEntrySelectForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
            OKBtn.Enabled = (EncyclopediaEntry != null);
		}

        public EncyclopediaEntry EncyclopediaEntry
		{
			get
			{
				if (EntryList.SelectedItems.Count != 0)
                    return EntryList.SelectedItems[0].Tag as EncyclopediaEntry;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
            if (EncyclopediaEntry != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
