using System.Collections.Generic;

using Masterplan.Data;

namespace Masterplan.Tools
{
	class Workspace
	{
		public static List<List<PlotPoint>> FindLayers(Plot plot)
		{
			List<List<PlotPoint>> layers = new List<List<PlotPoint>>();

			List<PlotPoint> unused = new List<PlotPoint>(plot.Points);

			while (unused.Count > 0)
			{
				List<PlotPoint> layer = new List<PlotPoint>();

				// Find all unused points which are not linked to by unused points
				foreach (PlotPoint pp in unused)
				{
					bool top_level = true;

					foreach (PlotPoint point in unused)
					{
						if (point == pp)
							continue;

						if (point.Links.Contains(pp.ID))
						{
							top_level = false;
							break;
						}
					}

					if (top_level)
						layer.Add(pp);
				}

				if (layer.Count == 0)
				{
					// There's been a problem; just add all unused points
					layer.AddRange(unused);
				}

				layers.Add(layer);

				foreach (PlotPoint pp in layer)
					unused.Remove(pp);
			}

			return layers;
		}

		public static int GetTotalXP(PlotPoint pp)
		{
            int xp = Session.Project.Party.XP * Session.Project.Party.Size;

			while (true)
			{
				// Add the XP value for all previous plot points in this plot

				Plot plot = Session.Project.FindParent(pp);
				if (plot == null)
					break;

				List<List<PlotPoint>> layers = FindLayers(plot);
				foreach (List<PlotPoint> layer in layers)
				{
					bool in_layer = false;
					foreach (PlotPoint point in layer)
					{
						if (point.ID == pp.ID)
						{
							in_layer = true;
							break;
						}
					}

					if (in_layer)
						break;

					int layer_xp = GetLayerXP(layer);
					xp += layer_xp;
				}

				pp = Session.Project.FindParent(plot);
				if (pp == null)
					break;
			}

			return xp;
		}

		public static int GetLayerXP(List<PlotPoint> layer)
		{
			int gained_xp = 0;
			int total_xp = 0;
			int points = 0;

			foreach (PlotPoint pp in layer)
			{
				if (pp == null)
					continue;

				switch (pp.State)
				{
					case PlotPointState.Normal:
						total_xp += pp.GetXP();
						points += 1;
						break;
					case PlotPointState.Skipped:
						// Do nothing
						break;
					case PlotPointState.Completed:
						gained_xp += pp.GetXP();
						break;
				}
			}

			int predicted_xp = total_xp;
			if (!Session.Preferences.AllXP)
			{
				predicted_xp = (points != 0) ? total_xp / points : 0;
			}

			return gained_xp + predicted_xp;
		}

		public static int GetPartyLevel(PlotPoint pp)
		{
			int total_xp = GetTotalXP(pp);
			int xp_per_player = total_xp / Session.Project.Party.Size;

			return Experience.GetHeroLevel(xp_per_player);
		}
	}
}
