using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a regional map.
	/// </summary>
	[Serializable]
	public class RegionalMap
	{
		/// <summary>
		/// Gets or sets the map name.
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
		/// Gets or sets the map image.
		/// </summary>
		public Image Image
		{
			get { return fImage; }
			set { fImage = value; }
		}
		Image fImage = null;

		/// <summary>
		/// Gets or sets the list of map locations.
		/// </summary>
		public List<MapLocation> Locations
		{
			get { return fLocations; }
			set { fLocations = value; }
		}
		List<MapLocation> fLocations = new List<MapLocation>();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="location_id"></param>
		/// <returns></returns>
		public  MapLocation FindLocation(Guid location_id)
		{
			foreach (MapLocation loc in fLocations)
			{
				if (loc.ID == location_id)
					return loc;
			}

			return null;
		}

		/// <summary>
		/// Creates a copy of the map.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public RegionalMap Copy()
		{
			RegionalMap rm = new RegionalMap();

			rm.Name = fName;
			rm.ID = fID;
			rm.Image = fImage;

			foreach (MapLocation ml in fLocations)
				rm.Locations.Add(ml.Copy());

			return rm;
		}

		/// <summary>
		/// Returns the map name.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a location on a regional map.
	/// </summary>
	[Serializable]
	public class MapLocation
	{
		/// <summary>
		/// Gets or sets the name of the location.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the location category.
		/// </summary>
		public string Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		string fCategory = "";

		/// <summary>
		/// Gets or sets the unique ID of the location.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the location point.
		/// </summary>
		public PointF Point
		{
			get { return fPoint; }
			set { fPoint = value; }
		}
		PointF fPoint = PointF.Empty;

		/// <summary>
		/// Creates a copy of the map location.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public MapLocation Copy()
		{
			MapLocation ml = new MapLocation();

			ml.Name = fName;
			ml.Category = fCategory;
			ml.ID = fID;
			ml.Point = new PointF(fPoint.X, fPoint.Y);

			return ml;
		}

		/// <summary>
		/// Returns the location name.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fName;
		}
	}
}
