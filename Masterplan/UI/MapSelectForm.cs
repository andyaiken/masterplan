using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class MapSelectForm : Form
	{
		public MapSelectForm(List<Map> maps, List<Guid> exclude, bool multi_select)
		{
			InitializeComponent();

			// Categories
			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			foreach (Map map in maps)
			{
				if ((map.Category != null) && (map.Category != ""))
					bst.Add(map.Category);
			}
			List<string> cats = bst.SortedList;
			cats.Add("Miscellaneous Maps");

			foreach (string cat in cats)
				MapList.Groups.Add(cat, cat);

			foreach (Map map in maps)
			{
				if ((exclude != null) && (exclude.Contains(map.ID)))
					continue;

				ListViewItem lvi = MapList.Items.Add(map.Name);
				lvi.Tag = map;

				if ((map.Category != null) && (map.Category != ""))
					lvi.Group = MapList.Groups[map.Category];
				else
					lvi.Group = MapList.Groups["Miscellaneous Maps"];
			}

			if (multi_select)
			{
				MapList.CheckBoxes = true;
			}

			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			if (MapList.CheckBoxes)
			{
				OKBtn.Enabled = (MapList.CheckedItems.Count != 0);
			}
			else
			{
				OKBtn.Enabled = (Map != null);
			}
		}

		public Map Map
		{
			get
			{
				if (MapList.SelectedItems.Count != 0)
					return MapList.SelectedItems[0].Tag as Map;

				return null;
			}
		}

		public List<Map> Maps
		{
			get
			{
				List<Map> maps = new List<Map>();

				foreach (ListViewItem lvi in MapList.CheckedItems)
				{
					Map map = lvi.Tag as Map;
					if (map != null)
						maps.Add(map);
				}

				return maps;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (Map != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
