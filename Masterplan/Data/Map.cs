using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a tactical map.
	/// </summary>
	[Serializable]
	public class Map
	{
		/// <summary>
		/// Gets or sets the name of the map.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the unique ID of the map.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the category of the map.
		/// </summary>
		public string Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		string fCategory = "";

		/// <summary>
		/// Gets or sets the list of tiles in the map.
		/// </summary>
		public List<TileData> Tiles
		{
			get { return fTiles; }
			set { fTiles = value; }
		}
		List<TileData> fTiles = new List<TileData>();

		/// <summary>
		/// Gets or sets the list of map areas.
		/// </summary>
		public List<MapArea> Areas
		{
			get { return fAreas; }
			set { fAreas = value; }
		}
		List<MapArea> fAreas = new List<MapArea>();

		/// <summary>
		/// Finds the map area with the given ID.
		/// </summary>
		/// <param name="area_id">The ID to search for.</param>
		/// <returns>Returns the map area, if it exists; null otherwise.</returns>
		public MapArea FindArea(Guid area_id)
		{
			foreach (MapArea area in fAreas)
			{
				if (area.ID == area_id)
					return area;
			}

			return null;
		}

		/// <summary>
		/// Returns the name of the map.
		/// </summary>
		/// <returns>Returns the name of the map.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Creates a copy of the map.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Map Copy()
		{
			Map m = new Map();

			m.Name = fName;
			m.ID = fID;
			m.Category = fCategory;

			foreach (TileData td in fTiles)
				m.Tiles.Add(td.Copy());

			foreach (MapArea area in fAreas)
				m.Areas.Add(area.Copy());

			return m;
		}
	}

	/// <summary>
	/// Class representing a tile on a map.
	/// </summary>
	[Serializable]
	public class TileData
	{
		/// <summary>
		/// Gets or sets the unique ID of this TileData.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the ID of the tile to be used.
		/// </summary>
		public Guid TileID
		{
			get { return fTileID; }
			set { fTileID = value; }
		}
		Guid fTileID = Guid.Empty;

		/// <summary>
		/// Gets or sets the location of the top-left square of the tile.
		/// </summary>
		public Point Location
		{
			get { return fLocation; }
			set { fLocation = value; }
		}
		Point fLocation = new Point(0, 0);

		/// <summary>
		/// Gets or sets the number of 90-degree turns the tile has turned.
		/// </summary>
		public int Rotations
		{
			get { return fRotations; }
			set
			{
				fRotations = value;

				while (fRotations < 0)
					fRotations += 4;

				fRotations = fRotations % 4;
			}
		}
		int fRotations = 0;

		/// <summary>
		/// Creates a copy of the TileData.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public TileData Copy()
		{
			TileData td = new TileData();

			td.ID = fID;
			td.TileID = fTileID;
			td.Location = new Point(fLocation.X, fLocation.Y);
			td.Rotations = fRotations;

			return td;
		}
	}

	/// <summary>
	/// Class representing an area of a map.
	/// </summary>
	[Serializable]
	public class MapArea
	{
		/// <summary>
		/// Gets or sets the area name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the unique ID of the area.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the area details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the area bounds.
		/// </summary>
		public Rectangle Region
		{
			get { return fRegion; }
			set { fRegion = value; }
		}
		Rectangle fRegion = new Rectangle(0, 0, 1, 1);

		/// <summary>
		/// Returns the area name.
		/// </summary>
		/// <returns>Returns the area name.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Creates a copy of the area.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public MapArea Copy()
		{
			MapArea area = new MapArea();

			area.Name = fName;
			area.ID = fID;
			area.Details = fDetails;
			area.Region = new Rectangle(fRegion.X, fRegion.Y, fRegion.Width, fRegion.Height);

			return area;
		}
	}

	/// <summary>
	/// Wrapper class for adding a map to a plot point.
	/// </summary>
	[Serializable]
	public class MapElement : IElement
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public MapElement()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="map_id">The ID of the map.</param>
		/// <param name="map_area_id">The ID of the map area; Guid.Empty for the whole map.</param>
		public MapElement(Guid map_id, Guid map_area_id)
		{
			fMapID = map_id;
			fMapAreaID = map_area_id;
		}

		/// <summary>
		/// Gets or sets the ID of the map.
		/// </summary>
		public Guid MapID
		{
			get { return fMapID; }
			set { fMapID = value; }
		}
		Guid fMapID = Guid.Empty;

		/// <summary>
		/// Gets or sets the ID of the map area.
		/// Guid.Empty for the whole map.
		/// </summary>
		public Guid MapAreaID
		{
			get { return fMapAreaID; }
			set { fMapAreaID = value; }
		}
		Guid fMapAreaID = Guid.Empty;

		/// <summary>
		/// Not used; always returns 0.
		/// </summary>
		/// <returns>Always returns 0.</returns>
		public int GetXP()
		{
			return 0;
		}

		/// <summary>
		/// Not used; always returns Difficulty.Moderate.
		/// </summary>
		/// <param name="party_level">The party level.</param>
		/// <param name="party_size">The party size.</param>
		/// <returns>Always returns Difficulty.Moderate.</returns>
		public Difficulty GetDifficulty(int party_level, int party_size)
		{
			return Difficulty.Moderate;
		}

		/// <summary>
		/// Creates a copy of the MapElement.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public IElement Copy()
		{
			MapElement me = new MapElement();

			me.MapID = fMapID;
			me.MapAreaID = fMapAreaID;

			return me;
		}
	}
}
