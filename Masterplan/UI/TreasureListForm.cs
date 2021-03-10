using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TreasureListForm : Form
	{
		public TreasureListForm(Plot plot)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fRootPlot = plot;

			update_plot_tree();
			update_list();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			SelectAll.Enabled = (ItemList.Items.Count != 0);
			SelectNone.Enabled = (ItemList.Items.Count != 0);
			ExportBtn.Enabled = (ItemList.CheckedItems.Count != 0);
			PagesLbl.Visible = (ItemList.CheckedItems.Count > 9);
		}

		Plot fRootPlot = null;

		public Plot SelectedPlot
		{
			get
			{
				if (PlotTree.SelectedNode != null)
					return PlotTree.SelectedNode.Tag as Plot;

				return null;
			}
		}

		public MagicItem SelectedMagicItem
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as MagicItem;

				return null;
			}
		}

		private void PlotTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			update_list();
		}

		private void ItemList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedMagicItem != null)
			{
				MagicItemDetailsForm dlg = new MagicItemDetailsForm(SelectedMagicItem);
				dlg.ShowDialog();
			}
		}

		void update_plot_tree()
		{
			PlotTree.Nodes.Clear();
			int nodes = add_nodes(PlotTree.Nodes, fRootPlot);
			PlotTree.ExpandAll();
			PlotTree.SelectedNode = PlotTree.Nodes[0];

			Splitter.Panel1Collapsed = (nodes == 1);
		}

		int add_nodes(TreeNodeCollection tnc, Plot p)
		{
			int nodes = 1;

			PlotPoint pp = Session.Project.FindParent(p);
			string plot_name = (pp != null) ? pp.Name : Session.Project.Name;

			TreeNode tn = tnc.Add(plot_name);
			tn.Tag = p;

			foreach (PlotPoint child in p.Points)
			{
				if (child.Subplot.Points.Count != 0)
					nodes += add_nodes(tn.Nodes, child.Subplot);
			}

			return nodes;
		}

		void update_list()
		{
			List<MagicItem> items = new List<MagicItem>();

			List<PlotPoint> points = get_points(SelectedPlot);
			foreach (PlotPoint pp in points)
			{
				foreach (Parcel parcel in pp.Parcels)
				{
					if (parcel.MagicItemID == Guid.Empty)
						continue;

					MagicItem mi = Session.FindMagicItem(parcel.MagicItemID, SearchType.Global);
					if ((mi != null) && (!items.Contains(mi)))
						items.Add(mi);
				}
			}

			items.Sort();

			ItemList.Items.Clear();
			foreach (MagicItem mi in items)
			{
				ListViewItem lvi = ItemList.Items.Add(mi.Name);
				lvi.Tag = mi;
			}
		}

		List<PlotPoint> get_points(Plot p)
		{
			List<PlotPoint> points = new List<PlotPoint>();

			points.AddRange(p.Points);

			foreach (PlotPoint pp in p.Points)
				points.AddRange(get_points(pp.Subplot));

			return points;
		}

		private void SelectAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in ItemList.Items)
				lvi.Checked = true;
		}

		private void SelectNone_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in ItemList.Items)
				lvi.Checked = false;
		}

		private void ExportBtn_Click(object sender, EventArgs e)
		{
			Close();

			int pages = ItemList.CheckedItems.Count / 9;
			int remainder = ItemList.CheckedItems.Count % 9;
			if (remainder > 0)
				pages += 1;

			for (int page = 0; page != pages; ++page)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Filter = Program.HTMLFilter;
				dlg.FileName = Session.Project.Name + " Treasure";
				dlg.Title = "Export";
				if (pages != 1)
					dlg.Title += " (page " + (page + 1) + ")";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					List<string> lines = HTML.GetHead("Loot", "", DisplaySize.Small);

					lines.Add("<BODY>");
					lines.Add("<P>");
					lines.Add("<TABLE class=clear height=100%>");

					for (int row = 0; row != 3; ++row)
					{
						lines.Add("<TR class=clear width=33% height=33%>");

						for (int col = 0; col != 3; ++col)
						{
							lines.Add("<TD width=33% height=33%>");

							int index = (page * 9) + (row * 3) + col;
							if (ItemList.CheckedItems.Count > index)
							{
								MagicItem mi = ItemList.CheckedItems[index].Tag as MagicItem;
								if (mi != null)
									lines.Add(HTML.MagicItem(mi, DisplaySize.Small, false, false));
							}

							lines.Add("</TD>");
						}

						lines.Add("</TR>");
					}

					lines.Add("</TABLE>");
					lines.Add("</P>");
					lines.Add("</BODY>");

					lines.Add("</HTML>");

					string html = HTML.Concatenate(lines);
					File.WriteAllText(dlg.FileName, html);
				}
			}
		}
	}
}
