using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TileBreakdownForm : Form
	{
		public TileBreakdownForm(Map map)
		{
			InitializeComponent();

			Dictionary<Guid, int> tiles = new Dictionary<Guid, int>();

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

			List<string> libs = new List<string>();
			foreach (Guid tile_id in tiles.Keys)
			{
				Tile tile = Session.FindTile(tile_id, SearchType.Global);
				Library lib = Session.FindLibrary(tile);

				if (!libs.Contains(lib.Name))
					libs.Add(lib.Name);
			}
			libs.Sort();

			foreach (string lib_name in libs)
				TileList.Groups.Add(lib_name, lib_name);

			TileList.LargeImageList = new ImageList();
			TileList.LargeImageList.ImageSize = new Size(64, 64);

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
