using System;
using System.Collections.Generic;

using Utils;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a plot structure.
	/// </summary>
	[Serializable]
	public class Plot
	{
		/// <summary>
		/// Gets or sets the list of plot points in the plot.
		/// </summary>
		public List<PlotPoint> Points
		{
			get { return fPoints; }
			set { fPoints = value; }
		}
		List<PlotPoint> fPoints = new List<PlotPoint>();

		/// <summary>
		/// Finds the plot point with the given ID.
		/// </summary>
		/// <param name="id">The ID of the desired plot point.</param>
		/// <returns>Returns the plot point.</returns>
		public PlotPoint FindPoint(Guid id)
		{
			foreach (PlotPoint pp in fPoints)
			{
				if (pp.ID == id)
					return pp;
			}

			return null;
		}

		/// <summary>
		/// Removes the specified plot point, and all references to it.
		/// </summary>
		/// <param name="point">The plot point.</param>
		public void RemovePoint(PlotPoint point)
		{
			List<Guid> links_to = new List<Guid>();
			foreach (PlotPoint pp in fPoints)
			{
				if (pp.Links.Contains(point.ID))
				{
					// Remove the reference to this point
					while (pp.Links.Contains(point.ID))
						pp.Links.Remove(point.ID);

					// Link this to all points on the other side
					foreach (Guid point_id in point.Links)
					{
						if (pp.Links.Contains(point_id))
							continue;

						pp.Links.Add(point_id);
					}
				}
			}

			fPoints.Remove(point);
		}

		/// <summary>
		/// Find all points in this plot which lead to the point with the specified ID.
		/// </summary>
		/// <param name="point_id">The ID of the plot point.</param>
		/// <returns>Returns the list of points.</returns>
		public List<PlotPoint> FindPrerequisites(Guid point_id)
		{
			List<PlotPoint> points = new List<PlotPoint>();

			foreach (PlotPoint pp in fPoints)
			{
				if (pp.Links.Contains(point_id))
					points.Add(pp);
			}

			return points;
		}

		/// <summary>
		/// Find all points in this plot which lead from the point with the specified ID.
		/// </summary>
		/// <param name="pp">The ID of the plot point.</param>
		/// <returns>Returns the list of points.</returns>
		public List<PlotPoint> FindSubtree(PlotPoint pp)
		{
			List<PlotPoint> subtree = new List<PlotPoint>();
			subtree.Add(pp);

			foreach (Guid id in pp.Links)
			{
				PlotPoint child = FindPoint(id);
				List<PlotPoint> branch = FindSubtree(child);

				subtree.AddRange(branch);
			}

			return subtree;
		}

		/// <summary>
		/// Returns the plot point which is associated with the specified map and map area.
		/// Does not recurse into subplots.
		/// </summary>
		/// <param name="map">The map.</param>
		/// <param name="area">The map area.</param>
		/// <returns>The plot point, if one exists; false otherwise.</returns>
		public PlotPoint FindPointForMapArea(Map map, MapArea area)
		{
			foreach (PlotPoint point in fPoints)
			{
				Map m = null;
				MapArea ma = null;
				point.GetTacticalMapArea(ref m, ref ma);
				if ((m == map) && (ma == area))
					return point;
			}

			return null;
		}

		/// <summary>
		/// Finds the list of tactical maps which are used in this plot.
		/// </summary>
		/// <returns>Returns the list of IDs of maps.</returns>
		public List<Guid> FindTacticalMaps()
		{
			BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();

			foreach (PlotPoint pp in fPoints)
			{
				if (pp.Element != null)
				{
					if (pp.Element is Encounter)
					{
						Encounter enc = pp.Element as Encounter;

						if ((enc.MapID != Guid.Empty) && (enc.MapAreaID != Guid.Empty))
							bst.Add(enc.MapID);
					}

					if (pp.Element is TrapElement)
					{
						TrapElement te = pp.Element as TrapElement;

						if ((te.MapID != Guid.Empty) && (te.MapAreaID != Guid.Empty))
							bst.Add(te.MapID);
					}

					if (pp.Element is SkillChallenge)
					{
						SkillChallenge sc = pp.Element as SkillChallenge;

						if ((sc.MapID != Guid.Empty) && (sc.MapAreaID != Guid.Empty))
							bst.Add(sc.MapID);
					}

					if (pp.Element is MapElement)
					{
						MapElement me = pp.Element as MapElement;

						if (me.MapID != Guid.Empty)
							bst.Add(me.MapID);
					}
				}
			}

			List<Guid> list = bst.SortedList;
			list.Remove(Guid.Empty);

			return list;
		}

		/// <summary>
		/// Finds the list of regional maps which are used in this plot.
		/// </summary>
		/// <returns>Returns the list of IDs of maps.</returns>
		public List<Guid> FindRegionalMaps()
		{
			BinarySearchTree<Guid> bst = new BinarySearchTree<Guid>();

			foreach (PlotPoint pp in fPoints)
			{
				if ((pp.RegionalMapID != Guid.Empty) && (pp.MapLocationID != Guid.Empty))
					bst.Add(pp.RegionalMapID);
			}

			List<Guid> list = bst.SortedList;
			list.Remove(Guid.Empty);

			return list;
		}

		/// <summary>
		/// Returns a list containing all the plot points in this plot and its subplots.
		/// </summary>
		public List<PlotPoint> AllPlotPoints
		{
			get
			{
				List<PlotPoint> points = new List<PlotPoint>();

				foreach (PlotPoint pp in fPoints)
				{
					points.Add(pp);
					points.AddRange(pp.Subplot.AllPlotPoints);
				}

				return points;
			}
		}

		/// <summary>
		/// Creates a copy of the plot.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Plot Copy()
		{
			Plot p = new Plot();

			foreach (PlotPoint pp in fPoints)
				p.Points.Add(pp.Copy());

			return p;
		}
	}
}
