using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class RegionalMapSelectForm : Form
	{
		public RegionalMapSelectForm(List<RegionalMap> maps, List<Guid> exclude, bool multi_select)
		{
			InitializeComponent();

			foreach (RegionalMap map in maps)
			{
				if ((exclude != null) && (exclude.Contains(map.ID)))
					continue;

				ListViewItem lvi = MapList.Items.Add(map.Name);
				lvi.Tag = map;
			}

			if (multi_select)
			{
				MapList.CheckBoxes = true;
			}

			Application.Idle += new EventHandler(Application_Idle);
		}

		~RegionalMapSelectForm()
		{
			Application.Idle -= Application_Idle;
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

		public RegionalMap Map
		{
			get
			{
				if (MapList.SelectedItems.Count != 0)
					return MapList.SelectedItems[0].Tag as RegionalMap;

				return null;
			}
		}

		public List<RegionalMap> Maps
		{
			get
			{
				List<RegionalMap> maps = new List<RegionalMap>();

				foreach (ListViewItem lvi in MapList.CheckedItems)
				{
					RegionalMap map = lvi.Tag as RegionalMap;
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
