using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class MagicItemSelectForm : Form
	{
		public MagicItemSelectForm(int level)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			if (level > 0)
				LevelRangePanel.SetLevelRange(level, level);

			Browser.DocumentText = "";
			ItemList_SelectedIndexChanged(null, null);
	
			update_list();
		}

		~MagicItemSelectForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (MagicItem != null);
		}

		public MagicItem MagicItem
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as MagicItem;

				return null;
			}
		}

		private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string html = HTML.MagicItem(MagicItem, Session.Preferences.TextSize, false, true);

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}

		private void ItemList_DoubleClick(object sender, EventArgs e)
		{
			if (MagicItem != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void LevelRangePanel_RangeChanged(object sender, EventArgs e)
		{
			update_list();
		}

		void update_list()
		{
			List<MagicItem> selection = new List<MagicItem>();

			List<MagicItem> items = Session.MagicItems;
			foreach (MagicItem item in items)
			{
				if ((item.Level >= LevelRangePanel.MinimumLevel) && (item.Level <= LevelRangePanel.MaximumLevel) && match(item, LevelRangePanel.NameQuery))
					selection.Add(item);
			}

			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			foreach (MagicItem item in selection)
			{
				if (item.Type != "")
					bst.Add(item.Type);
			}

			List<string> cats = bst.SortedList;
			cats.Add("Miscellaneous Items");
			foreach (string cat in cats)
				ItemList.Groups.Add(cat, cat);

			List<ListViewItem> list_items = new List<ListViewItem>();
			foreach (MagicItem item in selection)
			{
				ListViewItem lvi = new ListViewItem(item.Name);
				lvi.SubItems.Add(item.Info);
				lvi.Tag = item;

				if (item.Type != "")
					lvi.Group = ItemList.Groups[item.Type];
				else
					lvi.Group = ItemList.Groups["Miscellaneous Items"];

				list_items.Add(lvi);
			}

			ItemList.BeginUpdate();
			ItemList.Items.Clear();
			ItemList.Items.AddRange(list_items.ToArray());
			ItemList.EndUpdate();
		}

		bool match(MagicItem item, string query)
		{
			string[] tokens = query.ToLower().Split();

			foreach (string token in tokens)
			{
				if (!match_token(item, token))
					return false;
			}

			return true;
		}

		bool match_token(MagicItem item, string token)
		{
			if (item.Name.ToLower().Contains(token))
				return true;

			return false;
		}
	}
}
