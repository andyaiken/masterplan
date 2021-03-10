using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TileChecklistForm : Form
	{
		public TileChecklistForm()
		{
			InitializeComponent();

			update_tree();
			if (PlotTree.Nodes[0].Nodes.Count == 0)
				Splitter.Panel1Collapsed = true;

			PlotTree.SelectedNode = PlotTree.Nodes[0];
		}

		private void PlotTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Plot plot = e.Node.Tag as Plot;
			if (plot != null)
				update_list(plot);
		}

		void update_tree()
		{
			add_navigation_node(null, null);
			PlotTree.ExpandAll();
		}

		void add_navigation_node(PlotPoint pp, TreeNode parent)
		{
			try
			{
				string name = (pp != null) ? pp.Name : Session.Project.Name;

				TreeNodeCollection tnc = (parent != null) ? parent.Nodes : PlotTree.Nodes;
				TreeNode node = tnc.Add(name);

				Plot p = (pp != null) ? pp.Subplot : Session.Project.Plot;
				node.Tag = p;

				List<PlotPoint> list = (pp != null) ? pp.Subplot.Points : Session.Project.Plot.Points;
				foreach (PlotPoint child in list)
				{
					if (child.Subplot.Points.Count != 0)
						add_navigation_node(child, node);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void update_list(Plot plot)
		{
			List<Map> maps = new List<Map>();

			List<PlotPoint> points = plot.AllPlotPoints;
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
		}
	}
}
