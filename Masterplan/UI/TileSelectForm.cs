using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TileSelectForm : Form
	{
		enum GroupBy
		{
			Library,
			Category
		}

		public TileSelectForm(Size tilesize, TileCategory category)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fTileSize = tilesize;
			fCategory = category;

			MatchCatBtn.Text = "Show only tiles in category: " + fCategory;

			update_tiles();
		}

		~TileSelectForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (Tile != null);

			LibraryBtn.Checked = (fGroupBy == GroupBy.Library);
			CategoryBtn.Checked = (fGroupBy == GroupBy.Category);

			MatchCatBtn.Checked = fMatchCategory;
		}

		public Tile Tile
		{
			get
			{
				if (TileList.SelectedItems.Count != 0)
					return TileList.SelectedItems[0].Tag as Tile;

				return null;
			}
		}

		Size fTileSize = Size.Empty;
		TileCategory fCategory = TileCategory.Map;

		GroupBy fGroupBy = GroupBy.Library;
		bool fMatchCategory = true;

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (Tile != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void LibraryBtn_Click(object sender, EventArgs e)
		{
			fGroupBy = GroupBy.Library;
			update_tiles();
		}

		private void CategoryBtn_Click(object sender, EventArgs e)
		{
			fGroupBy = GroupBy.Category;
			update_tiles();
		}

		private void MatchCatBtn_Click(object sender, EventArgs e)
		{
			fMatchCategory = !fMatchCategory;
			update_tiles();
		}

		void update_tiles()
		{
			List<Tile> tiles = new List<Tile>();
			foreach (Library lib in Session.Libraries)
			{
				foreach (Tile t in lib.Tiles)
				{
					if (fMatchCategory)
					{
						if (fCategory != t.Category)
							continue;
					}

					bool same_size = false;

					if (fTileSize != Size.Empty)
					{
						if ((t.Size.Width == fTileSize.Width) && (t.Size.Height == fTileSize.Height))
							same_size = true;

						if ((t.Size.Width == fTileSize.Height) && (t.Size.Height == fTileSize.Width))
							same_size = true;
					}
					else
					{
						same_size = true;
					}

					if (same_size)
						tiles.Add(t);
				}
			}

			TileList.Groups.Clear();
			switch (fGroupBy)
			{
				case GroupBy.Library:
					{
						foreach (Library lib in Session.Libraries)
							TileList.Groups.Add(lib.Name, lib.Name);
					}
					break;
				case GroupBy.Category:
					{
						Array cats = Enum.GetValues(typeof(TileCategory));
						foreach (TileCategory cat in cats)
							TileList.Groups.Add(cat.ToString(), cat.ToString());
					}
					break;
			}

			TileList.BeginUpdate();

			TileList.LargeImageList = new ImageList();
			TileList.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
			TileList.LargeImageList.ImageSize = new Size(64, 64);

			List<ListViewItem> item_list = new List<ListViewItem>();

			foreach (Tile t in tiles)
			{
				ListViewItem lvi = new ListViewItem(t.ToString());
				lvi.Tag = t;

				switch (fGroupBy)
				{
					case GroupBy.Library:
						{
							Library lib = Session.FindLibrary(t);
							lvi.Group = TileList.Groups[lib.Name];
						}
						break;
					case GroupBy.Category:
						{
							lvi.Group = TileList.Groups[t.Category.ToString()];
						}
						break;
				}

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

				item_list.Add(lvi);
			}

			TileList.Items.Clear();
			TileList.Items.AddRange(item_list.ToArray());

			TileList.EndUpdate();
		}
	}
}
