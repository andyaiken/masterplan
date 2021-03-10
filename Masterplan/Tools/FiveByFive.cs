using System;
using System.Collections.Generic;

using Masterplan.Data;

namespace Masterplan.Tools
{
	class FiveByFive
	{
		public static void Build(Plot plot)
		{
			foreach (FiveByFiveColumn col in plot.FiveByFive.Columns)
			{
				PlotPoint previous = null;

				foreach (FiveByFiveItem item in col.Items)
				{
					// Create a plot point
					PlotPoint point = new PlotPoint(item.Details);
					point.Details = item.Details;
					point.Colour = col.Colour;

					plot.Points.Add(point);

					if (previous != null)
					{
						// Link to previous point
						previous.Links.Add(point.ID);
					}

					previous = point;
				}
			}
		}
	}
}
