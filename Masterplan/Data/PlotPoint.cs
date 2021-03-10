using System;
using System.Collections.Generic;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Interface for a game element.
	/// </summary>
	public interface IElement
	{
		/// <summary>
		/// Calculates the XP value of the game element.
		/// </summary>
		/// <returns>Returns the XP value.</returns>
		int GetXP();

		/// <summary>
		/// Calculates the difficulty of the game element.
		/// </summary>
		/// <param name="party_level">The party level.</param>
		/// <param name="party_size">The party size.</param>
		/// <returns>Returns the difficulty.</returns>
		Difficulty GetDifficulty(int party_level, int party_size);

		/// <summary>
		/// Creates a copy of the game element.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		IElement Copy();
	}

	/// <summary>
	/// Enumeration containing types of plot point state.
	/// </summary>
	public enum PlotPointState
	{
		/// <summary>
		/// The default state; the plot point is upcoming or in progress.
		/// </summary>
		Normal,

		/// <summary>
		/// The plot point has been played.
		/// </summary>
		Completed,

		/// <summary>
		/// The plot point was skipped.
		/// </summary>
		Skipped
	}

	/// <summary>
	/// Enumeration containing allowed plot point colours.
	/// </summary>
	public enum PlotPointColour
	{
		/// <summary>
		/// Yellow.
		/// </summary>
		Yellow,

		/// <summary>
		/// Blue.
		/// </summary>
		Blue,

		/// <summary>
		/// Green.
		/// </summary>
		Green,

		/// <summary>
		/// Purple.
		/// </summary>
		Purple,

		/// <summary>
		/// Orange.
		/// </summary>
		Orange,

		/// <summary>
		/// Brown.
		/// </summary>
		Brown,

		/// <summary>
		/// Grey.
		/// </summary>
		Grey
	}

	/// <summary>
	/// Class representing a plot point.
	/// </summary>
	[Serializable]
	public class PlotPoint
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public PlotPoint()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">The name of the point.</param>
		public PlotPoint(string name)
		{
			fName = name;
		}

		/// <summary>
		/// Gets or sets the point's unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the point's name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the point's state.
		/// </summary>
		public PlotPointState State
		{
			get { return fState; }
			set { fState = value; }
		}
		PlotPointState fState = PlotPointState.Normal;

		/// <summary>
		/// Gets or sets the point's colour.
		/// </summary>
		public PlotPointColour Colour
		{
			get { return fColour; }
			set { fColour = value; }
		}
		PlotPointColour fColour = PlotPointColour.Yellow;

		/// <summary>
		/// Gets or sets the point's details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the point's read-aloud text.
		/// </summary>
		public string ReadAloud
		{
			get { return fReadAloud; }
			set { fReadAloud = value; }
		}
		string fReadAloud = "";

		/// <summary>
		/// Gets or sets the list of the IDs of the plot points to which this point is linked.
		/// </summary>
		public List<Guid> Links
		{
			get { return fLinks; }
			set { fLinks = value; }
		}
		List<Guid> fLinks = new List<Guid>();

		/// <summary>
		/// Gets or sets the subplot for this point.
		/// </summary>
		public Plot Subplot
		{
			get { return fSubplot; }
			set { fSubplot = value; }
		}
		Plot fSubplot = new Plot();

		/// <summary>
		/// Gets or sets this point's game element.
		/// </summary>
		public IElement Element
		{
			get { return fElement; }
			set { fElement = value; }
		}
		IElement fElement = null;

        /// <summary>
        /// Gets or sets the list of treasure parcels held in this point.
        /// </summary>
        public List<Parcel> Parcels
        {
            get { return fParcels; }
            set { fParcels = value; }
        }
        List<Parcel> fParcels = new List<Parcel>();

        /// <summary>
        /// Gets or sets the list of encyclopedia entry IDs.
        /// </summary>
        public List<Guid> EncyclopediaEntryIDs
        {
            get { return fEncyclopediaEntries; }
            set { fEncyclopediaEntries = value; }
        }
        List<Guid> fEncyclopediaEntries = new List<Guid>();

        /// <summary>
        /// Gets or sets the date of this plot point.
        /// </summary>
        public CalendarDate Date
        {
            get { return fDate; }
            set { fDate = value; }
        }
        CalendarDate fDate = null;

		/// <summary>
		/// Gets or sets the ID of the regional map where the plot point takes place.
		/// </summary>
		public Guid RegionalMapID
		{
			get { return fRegionalMapID; }
			set { fRegionalMapID = value; }
		}
		Guid fRegionalMapID = Guid.Empty;

		/// <summary>
		/// Gets or sets the ID of the map location where the plot point takes place.
		/// </summary>
		public Guid MapLocationID
		{
			get { return fMapLocationID; }
			set { fMapLocationID = value; }
		}
		Guid fMapLocationID = Guid.Empty;

		/// <summary>
		/// Gets or sets the additional XP granted by this point.
		/// </summary>
		public int AdditionalXP
		{
			get { return fAdditionalXP; }
			set { fAdditionalXP = value; }
		}
		int fAdditionalXP = 0;

		/// <summary>
		/// Calculates the XP value of this plot point.
		/// </summary>
		/// <returns>Returns the XP value.</returns>
		public int GetXP()
		{
			int xp = fAdditionalXP;

			if (fElement != null)
				xp += fElement.GetXP();

			if (fSubplot.Points.Count != 0)
			{
				List<List<PlotPoint>> layers = Workspace.FindLayers(fSubplot);

				foreach (List<PlotPoint> layer in layers)
					xp += Workspace.GetLayerXP(layer);
			}

			return xp;
		}

		/// <summary>
		/// Returns the list of plot points leading from this point.
		/// </summary>
		public List<PlotPoint> Subtree
		{
			get
			{
				List<PlotPoint> points = new List<PlotPoint>();

				points.Add(this);
				foreach (PlotPoint pp in fSubplot.Points)
					points.AddRange(pp.Subtree);

				return points;
			}
		}

		/// <summary>
		/// Gets the tactical map and map area associated with the point, if any.
		/// </summary>
		/// <param name="map">The map associated with the point.</param>
		/// <param name="map_area">The map area associated with the point.</param>
		public void GetTacticalMapArea(ref Map map, ref MapArea map_area)
		{
			Guid map_id = Guid.Empty;
			Guid map_area_id = Guid.Empty;

			Encounter enc = fElement as Encounter;
			if (enc != null)
			{
				map_id = enc.MapID;
				map_area_id = enc.MapAreaID;
			}

			SkillChallenge sc = fElement as SkillChallenge;
			if (sc != null)
			{
				map_id = sc.MapID;
				map_area_id = sc.MapAreaID;
			}

			TrapElement te = fElement as TrapElement;
			if (te != null)
			{
				map_id = te.MapID;
				map_area_id = te.MapAreaID;
			}

			MapElement me = fElement as MapElement;
			if (me != null)
			{
				map_id = me.MapID;
				map_area_id = me.MapAreaID;
			}

			if ((map_id != Guid.Empty) && (map_area_id != Guid.Empty))
			{
				map = Session.Project.FindTacticalMap(map_id);
				if (map != null)
					map_area = map.FindArea(map_area_id);
			}
		}

		/// <summary>
		/// Gets the regional map and location associated with the point, if any.
		/// </summary>
		/// <param name="map">The map associated with the point.</param>
		/// <param name="map_location">The map location associated with the point.</param>
		/// <param name="project">The current project.</param>
		public void GetRegionalMapArea(ref RegionalMap map, ref MapLocation map_location, Project project)
		{
			if ((fRegionalMapID != Guid.Empty) && (fMapLocationID != Guid.Empty))
			{
				map = Session.Project.FindRegionalMap(fRegionalMapID);
				if (map != null)
					map_location = map.FindLocation(fMapLocationID);
			}
		}

		/// <summary>
		/// Returns the name of the point.
		/// </summary>
		/// <returns>Returns the name of the point.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Creates a copy of the point.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public PlotPoint Copy()
		{
			PlotPoint pp = new PlotPoint();

			pp.ID = fID;
			pp.Name = fName;
			pp.State = fState;
			pp.Colour = fColour;
			pp.Details = fDetails;
			pp.ReadAloud = fReadAloud;
			pp.Links.AddRange(fLinks);
			pp.Subplot = fSubplot.Copy();
			pp.Element = (fElement != null) ? fElement.Copy() : null;
			pp.Date = (fDate != null) ? fDate.Copy() : null;
			pp.RegionalMapID = fRegionalMapID;
			pp.MapLocationID = fMapLocationID;
			pp.AdditionalXP = fAdditionalXP;

			foreach (Parcel parcel in fParcels)
				pp.Parcels.Add(parcel.Copy());

            foreach (Guid entry_id in fEncyclopediaEntries)
                pp.EncyclopediaEntryIDs.Add(entry_id);

			return pp;
		}
	}
}
