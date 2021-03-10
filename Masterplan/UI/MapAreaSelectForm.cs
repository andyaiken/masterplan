using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
    partial class MapAreaSelectForm : Form
    {
        public MapAreaSelectForm(Guid map_id, Guid map_area_id)
        {
            InitializeComponent();

            Application.Idle += new EventHandler(Application_Idle);

			UseTileBtn.Visible = map_tiles_exist();

            MapBox.Items.Add("(no map)");
            foreach (Map m in Session.Project.Maps)
                MapBox.Items.Add(m);

            Map map = Session.Project.FindTacticalMap(map_id);
            if (map != null)
            {
                MapBox.SelectedItem = map;

                MapArea ma = map.FindArea(map_area_id);
                if (ma != null)
                {
                    AreaBox.SelectedItem = ma;
                }
                else
                {
                    AreaBox.SelectedIndex = 0;
                }
            }
            else
            {
                MapBox.SelectedIndex = 0;

				AreaBox.Items.Add("(no map)");
				AreaBox.SelectedIndex = 0;
            }
        }

		bool map_tiles_exist()
		{
			List<Library> libs = new List<Library>();
			libs.AddRange(Session.Libraries);
			if (Session.Project != null)
				libs.Add(Session.Project.Library);
			foreach (Library lib in libs)
			{
				foreach (Tile tile in lib.Tiles)
				{
					if (tile.Category == TileCategory.Map)
						return true;
				}
			}

			return false;
		}

        void Application_Idle(object sender, EventArgs e)
        {
			MapLbl.Enabled = (Session.Project.Maps.Count != 0);
			MapBox.Enabled = (Session.Project.Maps.Count != 0);

            Map m = MapBox.SelectedItem as Map;
            bool areas = ((m != null) && (m.Areas.Count != 0));

            AreaLbl.Enabled = areas;
            AreaBox.Enabled = areas;
        }

        public Map Map
        {
            get { return MapBox.SelectedItem as Map; }
        }

        public MapArea MapArea
        {
            get { return AreaBox.SelectedItem as MapArea; }
        }

        private void MapBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaBox.Items.Clear();

            Map m = MapBox.SelectedItem as Map;
			if (m != null)
			{
				AreaBox.Items.Add("(entire map)");

				foreach (MapArea ma in m.Areas)
					AreaBox.Items.Add(ma);

				AreaBox.SelectedIndex = 0;
			}

            show_map();
        }

        private void AreaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_map();
        }

        void show_map()
        {
            Map m = MapBox.SelectedItem as Map;
            if (m != null)
            {
                MapView.Map = m;

                MapArea ma = AreaBox.SelectedItem as MapArea;
                if (ma != null)
                {
                    MapView.Viewpoint = ma.Region;
                }
                else
                {
                    MapView.Viewpoint = Rectangle.Empty;
                }
            }
            else
            {
                MapView.Map = null;
            }
        }

		private void NewBtn_Click(object sender, EventArgs e)
		{
			Map m = new Map();
			m.Name = "New Map";

			MapBuilderForm dlg = new MapBuilderForm(m, false);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Maps.Add(dlg.Map);
				Session.Modified = true;

				MapBox.Items.Add(dlg.Map);
				MapBox.SelectedItem = dlg.Map;
			}
		}

		private void ImportBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog open_dlg = new OpenFileDialog();
			open_dlg.Filter = Program.ImageFilter;
			if (open_dlg.ShowDialog() != DialogResult.OK)
				return;

			Image img = Image.FromFile(open_dlg.FileName);
			if (img == null)
				return;

			Tile tile = new Tile();
			tile.Image = img;
			tile.Category = TileCategory.Map;

			TileForm tile_dlg = new TileForm(tile);
			if (tile_dlg.ShowDialog() != DialogResult.OK)
				return;

			Session.Project.Library.Tiles.Add(tile_dlg.Tile);

			TileData td = new TileData();
			td.TileID = tile.ID;

			Map map = new Map();
			map.Name = Utils.FileName.Name(open_dlg.FileName);
			map.Tiles.Add(td);

			Session.Project.Maps.Add(map);
			Session.Modified = true;

			MapBox.Items.Add(map);
			MapBox.SelectedItem = map;
		}

		private void UseTileBtn_Click(object sender, EventArgs e)
		{
			TileSelectForm dlg = new TileSelectForm(Size.Empty, TileCategory.Map);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				TileData td = new TileData();
				td.TileID = dlg.Tile.ID;

				Map map = new Map();
				map.Name = Utils.FileName.Name("New Map");
				map.Tiles.Add(td);

				Session.Project.Maps.Add(map);
				Session.Modified = true;

				MapBox.Items.Add(map);
				MapBox.SelectedItem = map;
			}
		}
	}
}
