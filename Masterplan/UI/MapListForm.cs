using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Masterplan.Controls;
using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class MapListForm : Form
	{
		public MapListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_maps();
		}

		~MapListForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedMap != null);
			EditBtn.Enabled = (SelectedMap != null);

			PrintMap.Enabled = (SelectedMap != null);
			ToolsBtn.Enabled = (SelectedMap != null);
			DelveBtn.Enabled = ((SelectedMap != null) && (SelectedMap.Areas.Count != 0));
			AreaLbl.Enabled = (SelectedMap != null);
			AreaBox.Enabled = (SelectedMap != null);

			ListContextAdd.Enabled = true;
			ListContextRemove.Enabled = RemoveBtn.Enabled;
			ListContextEdit.Enabled = EditBtn.Enabled;
			ListContextCategory.Enabled = (SelectedMap != null);
			ListContextDelve.Enabled = DelveBtn.Enabled;
			ListContextBreakdown.Enabled = (SelectedMap != null);
		}

		#region Properties

		static string FullMap = "(entire map)";

		public Map SelectedMap
		{
			get
			{
				if (MapList.SelectedItems.Count != 0)
					return MapList.SelectedItems[0].Tag as Map;

				return null;
			}
			set
			{
				MapList.SelectedItems.Clear();

				foreach (ListViewItem lvi in MapList.Items)
				{
					if (lvi.Tag == value)
						lvi.Selected = true;
				}
			}
		}

		public MapArea SelectedArea
		{
			get { return AreaBox.SelectedItem as MapArea; }
		}

		#endregion

		#region List Toolbar

		private void AddBuild_Click(object sender, EventArgs e)
		{
			if (Session.Tiles.Count == 0)
			{
				string msg = "You have no libraries containing map tiles.";
				msg += Environment.NewLine;
				msg += "Map tiles are required for map building.";

				MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);

				return;
			}

			Map m = new Map();
			m.Name = "New Map";

			MapBuilderForm dlg = new MapBuilderForm(m, false);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Maps.Add(dlg.Map);
				Session.Modified = true;

				update_maps();
				update_thumbnail();

				SelectedMap = dlg.Map;
			}
		}

		private void AddImport_Click(object sender, EventArgs e)
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
			map.Name = Tools.FileName.Name(open_dlg.FileName);
			map.Tiles.Add(td);

			Session.Project.Maps.Add(map);
			Session.Modified = true;

			update_maps();
		}

		private void AddImportProject_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.ProjectFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Project p = Serialisation<Project>.Load(dlg.FileName, SerialisationMode.Binary);
				if (p != null)
				{
					MapSelectForm map_dlg = new MapSelectForm(p.Maps, null, true);
					if (map_dlg.ShowDialog(this) != DialogResult.OK)
						return;

					Session.Project.PopulateProjectLibrary();
					foreach (Map map in map_dlg.Maps)
					{
						Session.Project.Maps.Add(map);

						foreach (TileData td in map.Tiles)
						{
							if (Session.FindTile(td.TileID, SearchType.Global) == null)
							{
								Tile tile = p.Library.FindTile(td.TileID);
								if (tile != null)
									Session.Project.Library.Tiles.Add(tile);
							}
						}
					}
					Session.Project.SimplifyProjectLibrary();

					Session.Modified = true;

					update_maps();
				}
			}
		}

		private void AddTile_Click(object sender, EventArgs e)
		{
			TileSelectForm dlg = new TileSelectForm(Size.Empty, TileCategory.Map);
			if (dlg.ShowDialog() != DialogResult.OK)
				return;

			TileData td = new TileData();
			td.TileID = dlg.Tile.ID;

			Map map = new Map();
			map.Name = Tools.FileName.Name("New Map");
			map.Tiles.Add(td);

			Session.Project.Maps.Add(map);
			Session.Modified = true;

			update_maps();
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				string msg = "Are you sure you want to delete this map?";
				DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return;

				Session.Project.Maps.Remove(SelectedMap);
				Session.Modified = true;

				update_maps();
				update_thumbnail();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				int index = Session.Project.Maps.IndexOf(SelectedMap);

				MapBuilderForm dlg = new MapBuilderForm(SelectedMap, false);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.Maps[index] = dlg.Map;
					Session.Modified = true;

					update_maps();
					update_thumbnail();

					SelectedMap = dlg.Map;
				}
			}
		}

		#endregion

		#region Map Toolbar

		private void PrintMap_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				MapPrintingForm dlg = new MapPrintingForm(MapView);
				dlg.ShowDialog();
			}
		}

		private void PrintBlank_Click(object sender, EventArgs e)
		{
			BlankMap.Print();
		}

		#region Tools

		private void ToolsCategory_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				List<string> categories = new List<string>();
				foreach (Map m in Session.Project.Maps)
				{
					if ((m.Category == null) || (m.Category == ""))
						continue;

					if (categories.Contains(m.Category))
						continue;

					categories.Add(m.Category);
				}

				CategoryForm dlg = new CategoryForm(categories, SelectedMap.Category);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					SelectedMap.Category = dlg.Category;
					Session.Modified = true;

					update_maps();
				}
			}
		}

		private void ToolsBreakdown_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				TileBreakdownForm dlg = new TileBreakdownForm(SelectedMap);
				dlg.ShowDialog();
			}
		}

		private void ToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.FileName = SelectedMap.Name;
				if (SelectedArea != null)
					dlg.FileName += " - " + SelectedArea.Name;
				dlg.Filter = "Bitmap Image |*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Bmp;
					switch (dlg.FilterIndex)
					{
						case 1:
							format = ImageFormat.Bmp;
							break;
						case 2:
							format = ImageFormat.Jpeg;
							break;
						case 3:
							format = ImageFormat.Gif;
							break;
						case 4:
							format = ImageFormat.Png;
							break;
					}

					Bitmap bmp = Screenshot.Map(MapView.Map, MapView.Viewpoint, null, null, null);
					bmp.Save(dlg.FileName, format);
				}
			}
		}

		private void ToolsPlayerView_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowTacticalMap(MapView, null);
			}
		}

		#endregion

		#region Delve AutoBuild

		private void DelveBtn_Click(object sender, EventArgs e)
		{
			autobuild_delve(false);
		}

		private void DelveAdvanced_Click(object sender, EventArgs e)
		{
			autobuild_delve(true);
		}

		void autobuild_delve(bool advanced)
		{
			AutoBuildData data = null;

			if (advanced)
			{
				AutoBuildForm dlg = new AutoBuildForm(AutoBuildForm.Mode.Delve);
				if (dlg.ShowDialog() == DialogResult.OK)
					data = dlg.Data;
				else
					return;
			}
			else
			{
				data = new AutoBuildData();
			}

			PlotPoint pp = DelveBuilder.AutoBuild(SelectedMap, data);

			Session.Project.Plot.Points.Add(pp);
			Session.Modified = true;

			Close();
		}

		private void DelveDeck_Click(object sender, EventArgs e)
		{
			EncounterDeck deck = new EncounterDeck();
			deck.Name = SelectedMap + " Deck";

			DeckBuilderForm dlg = new DeckBuilderForm(deck);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				deck = dlg.Deck;

				PlotPoint pp = new PlotPoint(SelectedMap.Name + " Delve");
				pp.Element = new MapElement(SelectedMap.ID, Guid.Empty);

				deck.DrawDelve(pp, SelectedMap);

				Session.Project.Plot.Points.Add(pp);
				Session.Modified = true;

				Close();
			}
		}

		#endregion

		private void AreaBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			MapView.Viewpoint = (SelectedArea != null) ? SelectedArea.Region : Rectangle.Empty;
		}

		#endregion

		#region Updating

		void update_maps()
		{
			List<string> categories = new List<string>();
			foreach (Map m in Session.Project.Maps)
			{
				if ((m.Category == null) || (m.Category == ""))
					continue;

				if (categories.Contains(m.Category))
					continue;

				categories.Add(m.Category);
			}
			categories.Sort();
			categories.Add("Miscellaneous Maps");

			MapList.Groups.Clear();
			foreach (string cat in categories)
				MapList.Groups.Add(cat, cat);
			MapList.ShowGroups = true;

			MapList.Items.Clear();

			foreach (Map m in Session.Project.Maps)
			{
				ListViewItem lvi = MapList.Items.Add(m.Name);
				lvi.Tag = m;

				if ((m.Category != null) && (m.Category != ""))
					lvi.Group = MapList.Groups[m.Category];
				else
					lvi.Group = MapList.Groups["Miscellaneous Maps"];
			}

			if (MapList.Items.Count == 0)
			{
				MapList.ShowGroups = false;

				ListViewItem lvi = MapList.Items.Add("(no maps)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void update_thumbnail()
		{
			if (MapView.Map != SelectedMap)
			{
				MapView.Map = SelectedMap;
				AreaBox.Enabled = (MapView.Map != null);

				AreaBox.Items.Clear();
				if (SelectedMap != null)
				{
					AreaBox.Items.Add(FullMap);
					foreach (MapArea area in SelectedMap.Areas)
						AreaBox.Items.Add(area);

					AreaBox.SelectedIndex = 0;
				}
			}
		}

		#endregion

		private void MapList_SelectedIndexChanged(object sender, EventArgs e)
		{
			update_thumbnail();
		}
	}
}
