using System;
using System.Collections.Generic;
using System.Drawing;

using Masterplan.Controls;
using Masterplan.Data;

namespace Masterplan.Tools
{
	class Screenshot
	{
		public static Bitmap Plot(Plot plot, Size size)
		{
			PlotView ctrl = new PlotView();
			ctrl.Plot = plot;
			ctrl.Mode = PlotViewMode.Plain;
			ctrl.Size = size;

			Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
			ctrl.DrawToBitmap(bmp, ctrl.ClientRectangle);

			return bmp;
		}

		public static Bitmap Map(Map map, Rectangle view, Encounter enc, Dictionary<Guid, CombatData> heroes, List<TokenLink> tokens)
		{
			MapView mapview = new MapView();
			mapview.Map = map;
			mapview.Viewpoint = view;
			mapview.Mode = MapViewMode.Plain;
            mapview.LineOfSight = false;
			mapview.Encounter = enc;
			mapview.TokenLinks = tokens;

			return Map(mapview);
		}

		public static Bitmap Map(MapView mapview)
		{
			// Make it a decent size
			const int square_size = 64;
			if (mapview.Viewpoint != Rectangle.Empty)
			{
				mapview.Size = new Size(mapview.Viewpoint.Width * square_size, mapview.Viewpoint.Height * square_size);
			}
			else
			{
				mapview.Size = new Size(mapview.LayoutData.Width * square_size, mapview.LayoutData.Height * square_size);
			}

			Bitmap bmp = new Bitmap(mapview.Width, mapview.Height);
			mapview.DrawToBitmap(bmp, mapview.ClientRectangle);

			return bmp;
		}

		public static Bitmap Calendar(Calendar calendar, int month_index, int year, Size size)
		{
			CalendarPanel ctrl = new CalendarPanel();
			ctrl.Calendar = calendar;
			ctrl.MonthIndex = month_index;
			ctrl.Year = year;
			ctrl.Size = size;

			Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
			ctrl.DrawToBitmap(bmp, ctrl.ClientRectangle);

			return bmp;
		}
	}
}
