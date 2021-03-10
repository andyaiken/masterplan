using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CategoryListForm : Form
	{
		public CategoryListForm(List<string> categories)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

            BinarySearchTree<string> bst = new BinarySearchTree<string>();
            foreach (Creature c in Session.Creatures)
            {
                if (c.Category != "")
                    bst.Add(c.Category);
            }

            List<string> all_categories = bst.SortedList;

			List<string> letters = new List<string>();
			foreach (string cat in all_categories)
			{
				string letter = cat.Substring(0, 1);
				if (!letters.Contains(letter))
					letters.Add(letter);
			}
			foreach (string letter in letters)
				CatList.Groups.Add(letter, letter);

			foreach (string cat in all_categories)
			{
				string letter = cat.Substring(0, 1);

				ListViewItem lvi = CatList.Items.Add(cat);
				lvi.Checked = ((categories == null) || categories.Contains(cat));
				lvi.Group = CatList.Groups[letter];
			}
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (CatList.CheckedItems.Count != 0);
		}

		public List<string> Categories
		{
			get
			{
				if (CatList.CheckedItems.Count == CatList.Items.Count)
					return null;

				List<string> cats = new List<string>();

				foreach (ListViewItem lvi in CatList.CheckedItems)
					cats.Add(lvi.Text);

				return cats;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		private void SelectBtn_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in CatList.Items)
				lvi.Checked = true;
		}

		private void DeselectBtn_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in CatList.Items)
				lvi.Checked = false;
		}
	}
}
