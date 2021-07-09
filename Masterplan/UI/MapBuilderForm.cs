using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Events;
using Masterplan.Tools;
using Masterplan.Tools.Generators;
using Masterplan.Wizards;

namespace Masterplan.UI
{
    /// <summary>
    /// Enumeration containing ways in which tiles can be grouped.
    /// </summary>
	public enum TileView
    {
        /// <summary>
        /// Sort tiles by library.
        /// </summary>
        Library,

        /// <summary>
        /// Sort tiles by size.
        /// </summary>
        Size,

        /// <summary>
        /// Sort tiles by category.
        /// </summary>
        Category
    }

    /// <summary>
    /// Enumeration containing tile display sizes.
    /// </summary>
	public enum TileSize
    {
        /// <summary>
        /// Small size.
        /// </summary>
        Small,

        /// <summary>
        /// Medium size.
        /// </summary>
        Medium,

        /// <summary>
        /// Large size.
        /// </summary>
        Large
    }

	partial class MapBuilderForm : Form
	{
		public MapBuilderForm(Map m, bool autobuild)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			List<Library> libs = new List<Library>();
			libs.AddRange(Session.Libraries);
			if (Session.Project != null)
				libs.Add(Session.Project.Library);
			int tiles_shown = 0;
			foreach (Library lib in libs)
			{
				if (Session.Preferences.TileLibraries != null)
					fTileSets[lib.ID] = Session.Preferences.TileLibraries.Contains(lib.ID);
				else
					fTileSets[lib.ID] = true;

				if (fTileSets[lib.ID])
					tiles_shown = lib.Tiles.Count;
			}
			if (tiles_shown == 0)
			{
				foreach (Library lib in libs)
					fTileSets[lib.ID] = true;
			}

			MapFilterPanel.Visible = false;
			populate_tiles();

			fMap = m.Copy();
			MapView.Map = fMap;
			NameBox.Text = fMap.Name;

			if (autobuild)
			{
				Cursor.Current = Cursors.WaitCursor;

				ToolsAutoBuild_Click(null, null);

				foreach (MapArea area in fMap.Areas)
				{
					area.Name = RoomBuilder.Name();
					area.Details = RoomBuilder.Details();
				}

				Cursor.Current = Cursors.Default;
			}

			update_areas();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = ((MapView.SelectedTiles != null) && (MapView.SelectedTiles.Count != 0));
            RotateLeftBtn.Enabled = ((MapView.SelectedTiles != null) && (MapView.SelectedTiles.Count != 0));
            RotateRightBtn.Enabled = ((MapView.SelectedTiles != null) && (MapView.SelectedTiles.Count != 0));
            OrderingBtn.Enabled = ((MapView.SelectedTiles != null) && (MapView.SelectedTiles.Count == 1));

			ToolsHighlightAreas.Checked = MapView.HighlightAreas;
			ToolsNavigate.Checked = MapView.AllowScrolling;
			ToolsClearBackground.Enabled = (MapView.BackgroundMap != null);

			AreaRemoveBtn.Enabled = (SelectedArea != null);
			AreaEditBtn.Enabled = (SelectedArea != null);
            FullMapBtn.Enabled = (MapView.Viewpoint != Rectangle.Empty);

			GroupByTileSet.Checked = (Session.Preferences.TileView == TileView.Library);
            GroupBySize.Checked = (Session.Preferences.TileView == TileView.Size);

            SizeSmall.Checked = (Session.Preferences.TileSize == TileSize.Small);
            SizeMedium.Checked = (Session.Preferences.TileSize == TileSize.Medium);
            SizeLarge.Checked = (Session.Preferences.TileSize == TileSize.Large);

			FilterBtn.Checked = MapFilterPanel.Visible;

			OKBtn.Enabled = ((fMap.Name != "") && (fMap.Tiles.Count != 0));
		}

		private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Session.Preferences.TileLibraries = new List<Guid>();
			foreach (Guid id in fTileSets.Keys)
			{
				if (fTileSets[id])
					Session.Preferences.TileLibraries.Add(id);
			}
		}

		protected override bool IsInputKey(Keys key)
		{
			return base.IsInputKey(key) || MapView.HandleKey(key);
		}

		#region Properties

		public Map Map
		{
			get { return fMap; }
		}
		Map fMap = null;

		public Tile SelectedTile
		{
			get
			{
				if (TileList.SelectedItems.Count != 0)
					return TileList.SelectedItems[0].Tag as Tile;

				return null;
			}
		}

		public MapArea SelectedArea
		{
			get
			{
				if (AreaList.SelectedItems.Count != 0)
					return AreaList.SelectedItems[0].Tag as MapArea;

				return null;
			}
		}

		Dictionary<Guid, bool> fTileSets = new Dictionary<Guid, bool>();

		#endregion

		#region Map toolbar

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTiles.Count != 0)
			{
				foreach (TileData td in MapView.SelectedTiles)
					fMap.Tiles.Remove(td);
				MapView.SelectedTiles.Clear();

				MapView.MapChanged();
			}
		}

		#region Rotate

		private void RotateLeftBtn_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTiles.Count != 0)
			{
				// Rotate selected tile
				foreach (TileData td in MapView.SelectedTiles)
					td.Rotations -= 1;

				MapView.MapChanged();
			}
		}

		private void RotateRightBtn_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTiles.Count != 0)
			{
				// Rotate selected tile
				foreach (TileData td in MapView.SelectedTiles)
					td.Rotations += 1;

				MapView.MapChanged();
			}
		}

		#endregion

		#region Ordering

		private void OrderingFront_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTiles.Count == 1)
			{
				TileData td = MapView.SelectedTiles[0];
				fMap.Tiles.Remove(td);
				fMap.Tiles.Add(td);

				MapView.MapChanged();
			}
		}

		private void OrderingBack_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTiles.Count == 1)
			{
				TileData td = MapView.SelectedTiles[0];
				fMap.Tiles.Remove(td);
				fMap.Tiles.Insert(0, td);

				MapView.MapChanged();
			}
		}

		#endregion

		#region Tools

		private void RotateMapLeft_Click(object sender, EventArgs e)
		{
			// Rotate whole map
			foreach (TileData td in fMap.Tiles)
			{
				if (!MapView.LayoutData.Tiles.ContainsKey(td))
					continue;

				// Change location
				int x = td.Location.X - MapView.LayoutData.MinX;
				int y = td.Location.Y - MapView.LayoutData.MinY;
				Tile t = MapView.LayoutData.Tiles[td];
				int tilewidth = (td.Rotations % 2 == 0) ? t.Size.Width : t.Size.Height;
				td.Location = new Point(y, MapView.LayoutData.Width - x - tilewidth + 1);

				// Rotate
				td.Rotations -= 1;
			}

			// Rotate areas
			foreach (MapArea area in fMap.Areas)
			{
				int x = area.Region.X - MapView.LayoutData.MinX;
				int y = area.Region.Y - MapView.LayoutData.MinY;
				Point loc = new Point(y, MapView.LayoutData.Width - x - area.Region.Width + 1);
				Size size = new Size(area.Region.Height, area.Region.Width);
				area.Region = new Rectangle(loc, size);
			}

			if (SelectedArea != null)
				MapView.Viewpoint = SelectedArea.Region;

			MapView.MapChanged();
		}

		private void RotateMapRight_Click(object sender, EventArgs e)
		{
			// Rotate whole map
			foreach (TileData td in fMap.Tiles)
			{
				if (!MapView.LayoutData.Tiles.ContainsKey(td))
					continue;

				// Change location
				int x = td.Location.X - MapView.LayoutData.MinX;
				int y = td.Location.Y - MapView.LayoutData.MinY;
				Tile t = MapView.LayoutData.Tiles[td];
				int tileheight = (td.Rotations % 2 == 0) ? t.Size.Height : t.Size.Width;
				td.Location = new Point(MapView.LayoutData.Height - y - tileheight + 1, x);

				// Rotate
				td.Rotations += 1;
			}

			// Rotate areas
			foreach (MapArea area in fMap.Areas)
			{
				int x = area.Region.X - MapView.LayoutData.MinX;
				int y = area.Region.Y - MapView.LayoutData.MinY;
				Point loc = new Point(MapView.LayoutData.Height - y - area.Region.Height + 1, x);
				Size size = new Size(area.Region.Height, area.Region.Width);
				area.Region = new Rectangle(loc, size);
			}

			if (SelectedArea != null)
				MapView.Viewpoint = SelectedArea.Region;

			MapView.MapChanged();
		}

		private void ToolsHighlightAreas_Click(object sender, EventArgs e)
		{
			MapView.HighlightAreas = !MapView.HighlightAreas;
		}

		private void ToolsClearAll_Click(object sender, EventArgs e)
		{
			fMap.Tiles.Clear();

			MapView.MapChanged();
		}

		#endregion

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			fMap.Name = NameBox.Text;
		}

		#endregion

		#region Area list

		private void AreaRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedArea != null)
			{
				fMap.Areas.Remove(SelectedArea);
				update_areas();

				MapView.Viewpoint = Rectangle.Empty;
			}
		}

		private void AreaEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedArea != null)
			{
				int index = fMap.Areas.IndexOf(SelectedArea);

				MapAreaForm dlg = new MapAreaForm(SelectedArea, fMap);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fMap.Areas[index] = dlg.Area;
					update_areas();

					MapView.Viewpoint = fMap.Areas[index].Region;
				}
			}
		}

        private void FullMapBtn_Click(object sender, EventArgs e)
        {
            MapView.Viewpoint = Rectangle.Empty;
        }

		private void AreaList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedArea != null)
				MapView.Viewpoint = SelectedArea.Region;
			else
				MapView.Viewpoint = Rectangle.Empty;
		}

		#endregion

		#region Tile list

		void TileSet_Click(object sender, EventArgs e)
		{
			// Show / hide this tile set
			ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
			Library lib = tsmi.Tag as Library;

			fTileSets[lib.ID] = !fTileSets[lib.ID];
			tsmi.Checked = fTileSets[lib.ID];

			populate_tiles();
		}

		private void GroupByTileSet_Click(object sender, EventArgs e)
		{
            Session.Preferences.TileView = TileView.Library;

            populate_tiles();
		}

		private void GroupBySize_Click(object sender, EventArgs e)
		{
            Session.Preferences.TileView = TileView.Size;

            populate_tiles();
		}

		private void GroupByCategory_Click(object sender, EventArgs e)
		{
            Session.Preferences.TileView = TileView.Category;

            populate_tiles();
		}

		private void TileList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedTile != null)
				DoDragDrop(SelectedTile, DragDropEffects.All);
		}

		#endregion

		#region Updating

		void populate_tiles()
		{
			List<Library> libraries = new List<Library>();
			libraries.AddRange(Session.Libraries);
			libraries.Add(Session.Project.Library);

			List<string> sets = new List<string>();
            switch (Session.Preferences.TileView)
			{
				case TileView.Library:
					{
						foreach (Library lib in libraries)
						{
							if (!fTileSets[lib.ID])
								continue;

							if (!sets.Contains(lib.Name))
								sets.Add(lib.Name);
						}

						sets.Sort();
					}
					break;
				case TileView.Size:
					{
						List<int> areas = new List<int>();
						foreach (Library lib in libraries)
						{
							foreach (Tile t in lib.Tiles)
							{
								if (!areas.Contains(t.Area))
									areas.Add(t.Area);
							}
						}

						areas.Sort();

						foreach (int area in areas)
							sets.Add("Size: " + area);
					}
					break;
				case TileView.Category:
					{
						foreach (TileCategory cat in Enum.GetValues(typeof(TileCategory)))
							sets.Add(cat.ToString());
					}
					break;
			}

			int size = 32;
            switch (Session.Preferences.TileSize)
			{
				case TileSize.Small:
					size = 16;
					break;
				case TileSize.Medium:
					size = 32;
					break;
				case TileSize.Large:
					size = 64;
					break;
			}

			TileList.BeginUpdate();

			TileList.Groups.Clear();
			foreach (string set in sets)
				TileList.Groups.Add(set, set);

			TileList.ShowGroups = (TileList.Groups.Count != 0);

			List<ListViewItem> item_list = new List<ListViewItem>();
			List<Image> image_list = new List<Image>();

			foreach (Library lib in libraries)
			{
				if (!fTileSets[lib.ID])
					continue;

				foreach (Tile t in lib.Tiles)
				{
					if (!match(t, SearchBox.Text))
						continue;

					ListViewItem lvi = new ListViewItem(t.ToString());
					lvi.Tag = t;

                    switch (Session.Preferences.TileView)
					{
						case TileView.Library:
							lvi.Group = TileList.Groups[lib.Name];
							break;
						case TileView.Size:
							lvi.Group = TileList.Groups["Size: " + t.Area];
							break;
						case TileView.Category:
							lvi.Group = TileList.Groups[t.Category.ToString()];
							break;
					}

					// Get tile image
					Image img = (t.Image != null) ? t.Image : t.BlankImage;
					if (img == null)
						continue;

					try
					{
						Bitmap bmp = new Bitmap(size, size);
						if (t.Size.Width > t.Size.Height)
						{
							int height = (t.Size.Height * size) / t.Size.Width;
							Rectangle rect = new Rectangle(0, (size - height) / 2, size, height);

							Graphics g = Graphics.FromImage(bmp);
							g.DrawImage(img, rect);
						}
						else
						{
							int width = (t.Size.Width * size) / t.Size.Height;
							Rectangle rect = new Rectangle((size - width) / 2, 0, width, size);

							Graphics g = Graphics.FromImage(bmp);
							g.DrawImage(img, rect);
						}

						image_list.Add(bmp);
						lvi.ImageIndex = image_list.Count - 1;

						item_list.Add(lvi);
					}
					catch (Exception ex)
					{
						LogSystem.Trace(ex);
					}
				}
			}

			TileList.LargeImageList = new ImageList();
			TileList.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
			TileList.LargeImageList.ImageSize = new Size(size, size);
			TileList.LargeImageList.Images.AddRange(image_list.ToArray());

			TileList.Items.Clear();
			TileList.Items.AddRange(item_list.ToArray());

			if (TileList.Items.Count == 0)
			{
				ListViewItem lvi = TileList.Items.Add("(no tiles)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			TileList.EndUpdate();
		}

		bool match(Tile t, string query)
		{
			string[] tokens = query.ToLower().Split();
			foreach (string token in tokens)
			{
				if (!match_token(t, token))
					return false;
			}

			return true;
		}

		bool match_token(Tile t, string token)
		{
			return t.Keywords.ToLower().Contains(token);
		}

		void update_areas()
		{
			AreaList.Items.Clear();

			foreach (MapArea area in fMap.Areas)
			{
				ListViewItem lvi = AreaList.Items.Add(area.Name);
				lvi.Tag = area;
			}

			if (AreaList.Items.Count == 0)
			{
				ListViewItem lvi = AreaList.Items.Add("(no areas defined)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		private void MapView_ItemDropped(object sender, EventArgs e)
		{
		}

		private void MapView_ItemMoved(object sender, MovementEventArgs e)
		{
		}

		private void MapView_ItemRemoved(object sender, EventArgs e)
		{
		}

		private void MapView_RegionSelected(object sender, EventArgs e)
		{
			Point mouse = MapView.PointToClient(Cursor.Position);
			MapContextMenu.Show(MapView, mouse);
		}

		private void MapView_TileContext(object sender, EventArgs e)
		{
			Point mouse = MapView.PointToClient(Cursor.Position);
			TileContextMenu.Show(MapView, mouse);
		}

		private void ContextCreate_Click(object sender, EventArgs e)
		{
			try
			{
				if (MapView.Selection != Rectangle.Empty)
				{
					MapArea area = new MapArea();
					area.Name = "New Area";
					area.Region = MapView.Selection;

					MapAreaForm dlg = new MapAreaForm(area, fMap);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fMap.Areas.Add(dlg.Area);
						update_areas();

						MapView.Selection = Rectangle.Empty;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ContextClear_Click(object sender, EventArgs e)
		{
			try
			{
				List<TileData> obsolete = new List<TileData>();
				foreach (TileData td in fMap.Tiles)
				{
					if (!MapView.LayoutData.TileSquares.ContainsKey(td))
						continue;

					Rectangle rect = MapView.LayoutData.TileSquares[td];

					if (MapView.Selection.IntersectsWith(rect))
						obsolete.Add(td);
				}

				foreach (TileData td in obsolete)
					fMap.Tiles.Remove(td);

				MapView.Selection = Rectangle.Empty;
				MapView.MapChanged();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ContextSelect_Click(object sender, EventArgs e)
		{
			try
			{
				MapView.SelectedTiles.Clear();
				foreach (TileData td in fMap.Tiles)
				{
					if (!MapView.LayoutData.TileSquares.ContainsKey(td))
						continue;

					Rectangle rect = MapView.LayoutData.TileSquares[td];

					if (MapView.Selection.IntersectsWith(rect))
						MapView.SelectedTiles.Add(td);
				}

				MapView.Selection = Rectangle.Empty;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsAutoBuild_Click(object sender, EventArgs e)
		{
			bool delve_only = (sender == null);
			MapWizard wizard = new MapWizard(delve_only);
			if (sender == null)
			{
				MapBuilderData mbd = wizard.Data as MapBuilderData;
				mbd.MaxAreaCount = 3;
				mbd.MinAreaCount = 3;
			}

			if (wizard.Show() == DialogResult.OK)
			{
				MapBuilderData data = wizard.Data as MapBuilderData;

				MapView.Viewpoint = Rectangle.Empty;

				int attempts = 0;
				while (attempts != 20)
				{
					attempts += 1;

					MapBuilder.BuildMap(data, fMap, new EventHandler(OnAutoBuild));

					if ((data.Type == MapAutoBuildType.FilledArea) || (data.Type == MapAutoBuildType.Freeform))
						break;

					if (fMap.Areas.Count >= data.MinAreaCount)
						break;
				}

				if ((data.Type == MapAutoBuildType.Warren) && (MapView.LayoutData.Height > MapView.LayoutData.Width))
					RotateMapLeft_Click(null, null);

				MapView.MapChanged();
				update_areas();
			}
		}

		void OnAutoBuild(object sender, EventArgs e)
		{
			MapView.MapChanged();
			Application.DoEvents();
		}

		private void MapView_HoverAreaChanged(object sender, EventArgs e)
		{
			string title = "";
			string info = "";

			if (MapView.HighlightedArea != null)
			{
				title = MapView.HighlightedArea.Name;
				info = TextHelper.Wrap(MapView.HighlightedArea.Details);

				if (info != "")
					info += Environment.NewLine;

				info += MapView.HighlightedArea.Region.Width + " sq x " + MapView.HighlightedArea.Region.Height + " sq";
			}

			Tooltip.ToolTipTitle = title;
			Tooltip.ToolTipIcon = ToolTipIcon.Info;
			Tooltip.SetToolTip(MapView, info);
		}

		private void SizeSmall_Click(object sender, EventArgs e)
		{
            Session.Preferences.TileSize = TileSize.Small;

			populate_tiles();
		}

		private void SizeMedium_Click(object sender, EventArgs e)
		{
            Session.Preferences.TileSize = TileSize.Medium;

            populate_tiles();
		}

		private void SizeLarge_Click(object sender, EventArgs e)
		{
            Session.Preferences.TileSize = TileSize.Large;

            populate_tiles();
		}

		private void MapForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
				RemoveBtn_Click(sender, e);

			switch (e.KeyCode)
			{
				case Keys.Delete:
					RemoveBtn_Click(sender, e);
					break;
				case Keys.Up:
				case Keys.Down:
				case Keys.Left:
				case Keys.Right:
					MapView.Nudge(e);
					break;
			}
		}

		private void ZoomGauge_Scroll(object sender, EventArgs e)
		{
			double max = 10.0;
			double mid = 1.0;
			double min = 0.1;

			double x = (double)(ZoomGauge.Value - ZoomGauge.Minimum) / (ZoomGauge.Maximum - ZoomGauge.Minimum);
			if (x >= 0.5)
			{
				x -= 0.5;
				x *= 2;
				MapView.ScalingFactor = mid + (x * (max - mid));
			}
			else
			{
				x *= 2;
				MapView.ScalingFactor = min + (x * (mid - min));
			}

			MapView.MapChanged();
		}

		private void ToolsNavigate_Click(object sender, EventArgs e)
		{
			MapView.AllowScrolling = !MapView.AllowScrolling;
			ZoomGauge.Visible = MapView.AllowScrolling;
		}

		private void ToolsReset_Click(object sender, EventArgs e)
		{
			ZoomGauge.Value = 50;
			MapView.ScalingFactor = 1.0;
			MapView.Viewpoint = Rectangle.Empty;

			MapView.MapChanged();
		}

		private void TileContextSwap_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTiles.Count != 1)
				return;

			TileData td = MapView.SelectedTiles[0];
			Tile t = Session.FindTile(td.TileID, SearchType.Global);
			TileSelectForm dlg = new TileSelectForm(t.Size, t.Category);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				// Swap tile
				int width = (td.Rotations % 2 == 0) ? t.Size.Width : t.Size.Height;
				int height = (td.Rotations % 2 == 0) ? t.Size.Height : t.Size.Width;

				int rot = 0;
				if ((dlg.Tile.Size.Width != width) || (dlg.Tile.Size.Height != height))
					rot = 1;

				td.TileID = dlg.Tile.ID;
				td.Rotations = rot;

				MapView.MapChanged();
			}
		}

		private void TileContextDuplicate_Click(object sender, EventArgs e)
		{
			if (MapView.SelectedTiles.Count != 1)
				return;

			TileData td = MapView.SelectedTiles[0];
			td = td.Copy();
			td.ID = Guid.NewGuid();
			td.Location = new Point(td.Location.X + 1, td.Location.Y + 1);

			fMap.Tiles.Add(td);

			MapView.MapChanged();
		}

		private void ViewSelectLibraries_Click(object sender, EventArgs e)
		{
			List<Library> libraries = new List<Library>();
			libraries.AddRange(Session.Libraries);
			libraries.Add(Session.Project.Library);

			List<Library> libs = new List<Library>();
			foreach (Library lib in libraries)
			{
				if (fTileSets[lib.ID])
					libs.Add(lib);
			}

			TileLibrarySelectForm dlg = new TileLibrarySelectForm(libs);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				foreach (Library lib in libraries)
					fTileSets[lib.ID] = dlg.Libraries.Contains(lib);

				populate_tiles();
			}
		}

		private void ToolsSelectBackground_Click(object sender, EventArgs e)
		{
			List<Guid> exclude = new List<Guid>();
			exclude.Add(fMap.ID);

			MapSelectForm dlg = new MapSelectForm(Session.Project.Maps, exclude, false);
			if (dlg.ShowDialog() == DialogResult.OK)
				MapView.BackgroundMap = dlg.Map;
		}

		private void ToolsClearBackground_Click(object sender, EventArgs e)
		{
			MapView.BackgroundMap = null;
		}

		private void MapView_AreaActivated(object sender, Masterplan.Events.MapAreaEventArgs e)
		{
			int index = fMap.Areas.IndexOf(e.MapArea);

			MapAreaForm dlg = new MapAreaForm(e.MapArea, fMap);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fMap.Areas[index] = dlg.Area;
				update_areas();
			}
		}

		private void ToolsImportMap_Click(object sender, EventArgs e)
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

			TileForm tile_dlg = new TileForm(tile);
			if (tile_dlg.ShowDialog() != DialogResult.OK)
				return;

			Session.Project.Library.Tiles.Add(tile_dlg.Tile);

			TileData td = new TileData();
			td.TileID = tile.ID;

			fMap.Tiles.Add(td);
			MapView.MapChanged();
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedTile != null)
			{
				Library lib = Session.FindLibrary(SelectedTile);
				int index = lib.Tiles.IndexOf(SelectedTile);

				TileForm dlg = new TileForm(SelectedTile);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					lib.Tiles[index] = dlg.Tile;
					populate_tiles();
				}
			}
		}

		private void MapForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
				return;

			if (fMap.Tiles.Count == 0)
				return;

			if (Session.Project.FindTacticalMap(fMap.ID) != null)
				return;

			string msg = "Do you want to save this new map?";
			if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				DialogResult = DialogResult.OK;
		}

		private void MapView_MouseZoomed(object sender, MouseEventArgs e)
		{
			ZoomGauge.Visible = true;
			ZoomGauge.Value -= Math.Sign(e.Delta);
			ZoomGauge_Scroll(sender, e);
		}

		private void FilterBtn_Click(object sender, EventArgs e)
		{
			MapFilterPanel.Visible = !MapFilterPanel.Visible;
		}

		private void SearchBox_TextChanged(object sender, EventArgs e)
		{
			populate_tiles();
		}
	}
}
