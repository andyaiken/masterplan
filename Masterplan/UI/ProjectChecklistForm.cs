using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class ProjectChecklistForm : Form
	{
		public ProjectChecklistForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_plot_tree();
			update_lists();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			SelectAll.Enabled = (ItemList.Items.Count != 0);
			SelectNone.Enabled = (ItemList.Items.Count != 0);
			ExportBtn.Enabled = (ItemList.CheckedItems.Count != 0) && (Pages.SelectedTab == MagicItemsPage);
			PagesLbl.Visible = (ItemList.CheckedItems.Count > 9);
		}

		Plot fRootPlot = Session.Project.Plot;

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
			update_lists();
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

		void update_lists()
		{
			update_list_items();
			update_list_minis();
			update_list_tiles();
		}

		void update_list_items()
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

			ItemList.CheckBoxes = (ItemList.Items.Count > 0);

			if (items.Count == 0)
			{
				ListViewItem lvi = ItemList.Items.Add("None");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void update_list_minis()
		{
			List<Encounter> encounters = new List<Encounter>();

			List<PlotPoint> points = get_points(SelectedPlot);
			foreach (PlotPoint pp in points)
			{
				Encounter enc = pp.Element as Encounter;
				if (enc != null)
				{
					encounters.Add(enc);
				}
			}

			Dictionary<Guid, int> creatures = new Dictionary<Guid, int>();

			foreach (Encounter enc in encounters)
			{
				// Get the mini breakdown for this encounter
				Dictionary<Guid, int> enc_creatures = new Dictionary<Guid, int>();
				foreach (EncounterSlot slot in enc.Slots)
				{
					if (!enc_creatures.ContainsKey(slot.Card.CreatureID))
						enc_creatures[slot.Card.CreatureID] = 0;

					enc_creatures[slot.Card.CreatureID] += slot.CombatData.Count;
				}

				// Update the running total
				foreach (Guid creature_id in enc_creatures.Keys)
				{
					if (!creatures.ContainsKey(creature_id))
						creatures[creature_id] = 0;

					if (enc_creatures[creature_id] > creatures[creature_id])
						creatures[creature_id] = enc_creatures[creature_id];
				}
			}

			List<ICreature> creature_list = new List<ICreature>();
			foreach (Guid creature_id in creatures.Keys)
			{
				ICreature c = Session.FindCreature(creature_id, SearchType.Global);
				if (c != null)
					creature_list.Add(c);
			}

			creature_list.Sort();

			MiniList.Items.Clear();
			foreach (ICreature c in creature_list)
			{
				ListViewItem lvi = MiniList.Items.Add(c.Name);

				lvi.SubItems.Add(c.Size.ToString());

				string info = "";
				if (c.Keywords != "")
				{
					if (info != "")
						info += "; ";
					info += "Keywords: " + c.Keywords;
				}
				foreach (CreaturePower cp in c.CreaturePowers)
				{
					if (info != "")
						info += ", ";
					info += cp.Name;
				}
				lvi.SubItems.Add(info);

				int count = creatures[c.ID];
				if (count > 1)
					lvi.SubItems.Add("x" + count);
				else
					lvi.SubItems.Add("");
			}

			if (creature_list.Count == 0)
			{
				ListViewItem lvi = MiniList.Items.Add("None");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void update_list_tiles()
		{
			List<Map> maps = new List<Map>();

			List<PlotPoint> points = get_points(SelectedPlot);
			List<Guid> map_ids = new List<Guid>();
			foreach (PlotPoint pp in points)
			{
				Encounter enc = pp.Element as Encounter;
				if (enc != null)
				{
					if (enc.MapID != Guid.Empty)
						map_ids.Add(enc.MapID);
				}

				MapElement me = pp.Element as MapElement;
				if (me != null)
				{
					map_ids.Add(me.MapID);
				}
			}

			foreach (Guid map_id in map_ids)
			{
				Map map = Session.Project.FindTacticalMap(map_id);
				if (map != null)
					maps.Add(map);
			}

			Dictionary<Guid, int> tiles = new Dictionary<Guid, int>();

			foreach (Map map in maps)
			{
				// Get the tile breakdown for this map
				Dictionary<Guid, int> map_tiles = new Dictionary<Guid, int>();
				foreach (TileData td in map.Tiles)
				{
					if (!map_tiles.ContainsKey(td.TileID))
						map_tiles[td.TileID] = 0;

					map_tiles[td.TileID] += 1;
				}

				// Update the running total
				foreach (Guid tile_id in map_tiles.Keys)
				{
					if (!tiles.ContainsKey(tile_id))
						tiles[tile_id] = 0;

					if (map_tiles[tile_id] > tiles[tile_id])
						tiles[tile_id] = map_tiles[tile_id];
				}
			}

			List<string> libs = new List<string>();
			foreach (Guid tile_id in tiles.Keys)
			{
				Tile tile = Session.FindTile(tile_id, SearchType.Global);
				Library lib = Session.FindLibrary(tile);

				if (!libs.Contains(lib.Name))
					libs.Add(lib.Name);
			}
			libs.Sort();

			TileList.Groups.Clear();
			foreach (string lib_name in libs)
				TileList.Groups.Add(lib_name, lib_name);
			TileList.ShowGroups = (TileList.Groups.Count > 0);

			TileList.LargeImageList = new ImageList();
			TileList.LargeImageList.ImageSize = new Size(64, 64);

			TileList.Items.Clear();
			foreach (Guid tile_id in tiles.Keys)
			{
				Tile t = Session.FindTile(tile_id, SearchType.Global);
				Library lib = Session.FindLibrary(t);

				ListViewItem lvi = TileList.Items.Add("x " + tiles[tile_id]);
				lvi.Tag = t;
				lvi.Group = TileList.Groups[lib.Name];

				// Get tile image
				Image img = t.Image != null ? t.Image : t.BlankImage;

				Bitmap bmp = new Bitmap(64, 64);
				if (t.Size.Width > t.Size.Height)
				{
					int height = (t.Size.Height * 64) / t.Size.Width;
					Rectangle rect = new Rectangle(0, (64 - height) / 2, 64, height);

					Graphics g = Graphics.FromImage(bmp);
					g.DrawImage(img, rect);
				}
				else
				{
					int width = (t.Size.Width * 64) / t.Size.Height;
					Rectangle rect = new Rectangle((64 - width) / 2, 0, width, 64);

					Graphics g = Graphics.FromImage(bmp);
					g.DrawImage(img, rect);
				}

				TileList.LargeImageList.Images.Add(bmp);
				lvi.ImageIndex = TileList.LargeImageList.Images.Count - 1;
			}

			if (tiles.Keys.Count == 0)
			{
				ListViewItem lvi = TileList.Items.Add("None");
				lvi.ForeColor = SystemColors.GrayText;
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
