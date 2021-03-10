using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Masterplan.Data
{
	/// <summary>
	/// Type of tile.
	/// </summary>
	public enum TileCategory
	{
		/// <summary>
		/// Open space.
		/// </summary>
		Plain,

		/// <summary>
		/// A door or curtain etc.
		/// </summary>
		Doorway,
		
		/// <summary>
		/// A stairway or other way of travelling between levels.
		/// </summary>
		Stairway,
		
		/// <summary>
		/// Decoration, furniture etc.
		/// </summary>
		Feature,
		
		/// <summary>
		/// Miscellaneous tiles.
		/// </summary>
		Special,

		/// <summary>
		/// Tiles which are full maps.
		/// </summary>
		Map
	}

	/// <summary>
	/// Class representing a map tile.
	/// </summary>
	[Serializable]
	public class Tile
	{
		/// <summary>
		/// Gets or sets the unique ID of the tile.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the tile category.
		/// </summary>
		public TileCategory Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		TileCategory fCategory = TileCategory.Special;

		/// <summary>
		/// Gets or sets the dimensions of the tile, in squares.
		/// </summary>
		public Size Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		Size fSize = new Size(2, 2);

		/// <summary>
		/// Gets or sets the tile image.
		/// </summary>
		public Image Image
		{
			get
			{
				return fImage;
			}
			set
			{
				fImage = value;

				/*
				MemoryStream ms = new MemoryStream();
				value.Save(ms, ImageFormat.Jpeg);
				ms.Close();

				fImage = Image.FromStream(ms);
				*/
			}
		}
		Image fImage = null;

		/// <summary>
		/// Gets or sets the colour of tiles with no Image.
		/// </summary>
		public Color BlankColour
		{
			get { return fBlankColour; }
			set { fBlankColour = value; }
		}
		Color fBlankColour = Color.White;

		/// <summary>
		/// Gets or sets the tile's keywords.
		/// </summary>
		public string Keywords
		{
			get { return fKeywords; }
			set { fKeywords = value; }
		}
		string fKeywords = "";

		/// <summary>
		/// Gets the area of the tile, in squares.
		/// </summary>
		public int Area
		{
			get { return fSize.Width * fSize.Height; }
		}

		/// <summary>
		/// Gets a plain image for this tile.
		/// </summary>
		public Image BlankImage
		{
			get
			{
				int square_size = 32;

				int width = (fSize.Width * square_size) + 1;
				int height = (fSize.Height * square_size) + 1;

				Bitmap img = new Bitmap(width, height);

				for (int x = 0; x != width; ++x)
				{
					for (int y = 0; y != height; ++y)
					{
						Color c = fBlankColour;
						if ((x % square_size == 0) || (y % square_size == 0))
							c = Color.DarkGray;

						img.SetPixel(x, y, c);
					}
				}

				return img;
			}
		}

		/// <summary>
		/// [width] x [height]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fSize.Width + " x " + fSize.Height;
		}

		/// <summary>
		/// Creates a copy of the tile.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Tile Copy()
		{
			Tile tile = new Tile();

			tile.ID = fID;
			tile.Category = fCategory;
			tile.Size = new Size(fSize.Width, fSize.Height);
			tile.Image = fImage;
			tile.Keywords = fKeywords;

			return tile;
		}
	}
}
