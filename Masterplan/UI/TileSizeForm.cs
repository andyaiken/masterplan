using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TileSizeForm : Form
	{
		public TileSizeForm(List<Tile> tiles)
		{
			InitializeComponent();

			fTiles = tiles;

			int x = 0;
			int y = 0;
			foreach (Tile t in fTiles)
			{
				x += t.Size.Width;
				y += t.Size.Height;
			}
			x /= fTiles.Count;
			y /= fTiles.Count;

			WidthBox.Value = x;
			HeightBox.Value = y;
		}

		List<Tile> fTiles = null;

		public Size TileSize
		{
			get { return fSize; }
		}
		Size fSize = new Size(2, 2);

		private void OKBtn_Click(object sender, EventArgs e)
		{
			int width = (int)WidthBox.Value;
			int height = (int)HeightBox.Value;

			fSize = new Size(width, height);
		}
	}
}
