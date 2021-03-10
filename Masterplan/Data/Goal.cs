using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Class to hold a set of party goals.
	/// </summary>
	[Serializable]
	public class PartyGoals
	{
		/// <summary>
		/// The list of goals.
		/// </summary>
		public List<Goal> Goals
		{
			get { return fGoals; }
			set { fGoals = value; }
		}
		List<Goal> fGoals = new List<Goal>();

		/// <summary>
		/// Returns the containing list for the given goal.
		/// </summary>
		/// <param name="goal">The goal to search for.</param>
		/// <returns>Returns the list containing the goal.</returns>
		public List<Goal> FindList(Goal goal)
		{
			return find_list(goal, fGoals);
		}

		List<Goal> find_list(Goal target, List<Goal> list)
		{
			if (list.Contains(target))
				return list;

			foreach (Goal g in list)
			{
				List<Goal> parent = find_list(target, g.Prerequisites);
				if (parent != null)
					return parent;
			}

			return null;
		}

		/// <summary>
		/// Creates a copy.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public PartyGoals Copy()
		{
			PartyGoals pg = new PartyGoals();

			foreach (Goal goal in fGoals)
				pg.Goals.Add(goal.Copy());

			return pg;
		}
	}

	/// <summary>
	/// Class representing a party goal.
	/// </summary>
	[Serializable]
	public class Goal
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Goal()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="name">The goal's name.</param>
		public Goal(string name)
		{
			fName = name;
		}

		/// <summary>
		/// Gets or sets the goal's unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the goal.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the goal's details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the goal's prerequisite goals.
		/// </summary>
		public List<Goal> Prerequisites
		{
			get { return fPrerequisites; }
			set { fPrerequisites = value; }
		}
		List<Goal> fPrerequisites = new List<Goal>();

		/// <summary>
		/// Gets the list of goals in this subtree.
		/// </summary>
		public List<Goal> Subtree
		{
			get
			{
				List<Goal> subtree = new List<Goal>();

				subtree.Add(this);

				foreach (Goal goal in fPrerequisites)
					subtree.AddRange(goal.Subtree);

				return subtree;
			}
		}

		/// <summary>
		/// Returns the name of the goal.
		/// </summary>
		/// <returns>Returns the name of the goal.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Creates a copy of the goal.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Goal Copy()
		{
			Goal g = new Goal();

			g.ID = fID;
			g.Name = fName;
			g.Details = fDetails;

			foreach (Goal subgoal in fPrerequisites)
				g.Prerequisites.Add(subgoal.Copy());

			return g;
		}
	}

	/// <summary>
	/// Class representing 5x5 data for a plot.
	/// </summary>
	[Serializable]
	public class FiveByFiveData
	{
		/// <summary>
		/// Gets or sets the list of columns.
		/// </summary>
		public List<FiveByFiveColumn> Columns
		{
			get { return fColumns; }
			set { fColumns = value; }
		}
		List<FiveByFiveColumn> fColumns = new List<FiveByFiveColumn>();

		/// <summary>
		/// Sets up a blank 5x5 grid.
		/// </summary>
		public void Initialise()
		{
			fColumns.Clear();

			List<PlotPointColour> colours = new List<PlotPointColour>();
			foreach (PlotPointColour colour in Enum.GetValues(typeof(PlotPointColour)))
				colours.Add(colour);

			for (int index = 0; index != 5; ++index)
			{
				int col_index = index % colours.Count;
				PlotPointColour colour = colours[col_index];

				FiveByFiveColumn column = new FiveByFiveColumn();
				column.Name = colour.ToString();
				column.Colour = colour;

				fColumns.Add(column);

				for (int n = 1; n <= 5; ++n)
				{
					FiveByFiveItem item = new FiveByFiveItem();
					item.Details = column.Name + " " + n;

					column.Items.Add(item);
				}
			}
		}

		/// <summary>
		/// Creates a copy of the data.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public FiveByFiveData Copy()
		{
			FiveByFiveData data = new FiveByFiveData();

			foreach (FiveByFiveColumn plot in fColumns)
				data.Columns.Add(plot.Copy());

			return data;
		}
	}

	/// <summary>
	/// Class representing a 5x5 column.
	/// </summary>
	[Serializable]
	public class FiveByFiveColumn
	{
		/// <summary>
		/// Gets or sets the column's unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the column.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the colour of the column.
		/// </summary>
		public PlotPointColour Colour
		{
			get { return fColour; }
			set { fColour = value; }
		}
		PlotPointColour fColour = PlotPointColour.Yellow;

		/// <summary>
		/// Gets or sets the colum's items.
		/// </summary>
		public List<FiveByFiveItem> Items
		{
			get { return fItems; }
			set { fItems = value; }
		}
		List<FiveByFiveItem> fItems = new List<FiveByFiveItem>();

		/// <summary>
		/// Creates a copy of the column.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public FiveByFiveColumn Copy()
		{
			FiveByFiveColumn col = new FiveByFiveColumn();

			col.ID = fID;
			col.Name = fName;
			col.Colour = fColour;

			foreach (FiveByFiveItem item in fItems)
				col.Items.Add(item.Copy());

			return col;
		}
	}

	/// <summary>
	/// Class representing an item in a 5x5 column.
	/// </summary>
	[Serializable]
	public class FiveByFiveItem
	{
		/// <summary>
		/// Gets or sets the item's unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the item.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the list of ID for link items.
		/// </summary>
		public List<Guid> LinkIDs
		{
			get { return fLinkIDs; }
			set { fLinkIDs = value; }
		}
		List<Guid> fLinkIDs = new List<Guid>();

		/// <summary>
		/// Creates a copy of the item.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public FiveByFiveItem Copy()
		{
			FiveByFiveItem item = new FiveByFiveItem();

			item.ID = fID;
			item.Details = fDetails;

			foreach (Guid link_id in fLinkIDs)
				item.LinkIDs.Add(link_id);

			return item;
		}
	}
}
