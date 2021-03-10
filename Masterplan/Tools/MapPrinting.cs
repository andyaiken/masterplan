using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

using Utils;

using Masterplan.Controls;
using Masterplan.Data;

namespace Masterplan.Tools
{
	class MapPrinting
	{
		public static void Print(MapView mapview, bool poster, PrinterSettings settings)
		{
			fMap = mapview.Map;
			fViewpoint = mapview.Viewpoint;
			fEncounter = mapview.Encounter;
			fShowGridlines = (mapview.ShowGrid == MapGridMode.Overlay);
			fPosterMode = poster;

			PrintDocument doc = new PrintDocument();
			doc.DocumentName = fMap.Name;
			doc.PrinterSettings = settings;

			fPages = null;

			doc.PrintPage += new PrintPageEventHandler(print_map_page);
			doc.Print();
		}

		static Map fMap = null;
		static Rectangle fViewpoint = Rectangle.Empty;
		static Encounter fEncounter = null;
		static bool fShowGridlines = false;
		static bool fPosterMode = false;

		static List<Rectangle> fPages = null;

		static void print_map_page(object sender, PrintPageEventArgs e)
		{
			MapView ctrl = new MapView();
			ctrl.Map = fMap;
			ctrl.Viewpoint = fViewpoint;
			ctrl.Encounter = fEncounter;
            ctrl.LineOfSight = false;
			ctrl.Mode = MapViewMode.Plain;
			ctrl.Size = e.PageBounds.Size;
			ctrl.BorderSize = 1;

			if (fShowGridlines)
				ctrl.ShowGrid = MapGridMode.Overlay;

			if (fPages == null)
			{
				if (fPosterMode)
				{
					int square_count_h = e.PageSettings.PaperSize.Width / 100;
					int square_count_v = e.PageSettings.PaperSize.Height / 100;

					fPages = get_pages(ctrl, square_count_h, square_count_v);
				}
				else
				{
					fPages = new List<Rectangle>();
					fPages.Add(ctrl.Viewpoint);
				}
			}

			ctrl.Viewpoint = fPages[0];
			fPages.RemoveAt(0);

			bool map_wider = (ctrl.LayoutData.Width > ctrl.LayoutData.Height);
			bool page_wider = (e.PageBounds.Width > e.PageBounds.Height);
			bool rotate = (map_wider != page_wider);

			if (rotate)
			{
				ctrl.Width = e.PageBounds.Height;
				ctrl.Height = e.PageBounds.Width;
			}

			Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
			ctrl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

			if (rotate)
			{
				bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
			}

			e.Graphics.DrawImage(bmp, e.PageBounds);

			e.HasMorePages = (fPages.Count != 0);
		}

		static List<Rectangle> get_pages(MapView ctrl, int square_count_h, int square_count_v)
		{
			int width = Math.Max(square_count_h, square_count_v);
			int height = Math.Min(square_count_h, square_count_v);

			List<Point> squares = new List<Point>();
			for (int x = ctrl.LayoutData.MinX; x <= ctrl.LayoutData.MaxX; ++x)
			{
				for (int y = ctrl.LayoutData.MinY; y <= ctrl.LayoutData.MaxY; ++y )
				{
					Point pt = new Point(x, y);
					TileData td = ctrl.LayoutData.GetTileAtSquare(pt);
					if (td != null)
						squares.Add(pt);
				}
			}

			List<Rectangle> pages = new List<Rectangle>();

			for (int x = ctrl.LayoutData.MinX; x <= ctrl.LayoutData.MaxX; x += width)
			{
				for (int y = ctrl.LayoutData.MinY; y <= ctrl.LayoutData.MaxY; y += height)
				{
					Rectangle rect = new Rectangle(x, y, width, height);

					bool contains_tile = false;
					foreach (Point square in squares)
					{
						if (rect.Contains(square))
						{
							contains_tile = true;
							break;
						}
					}

					if (contains_tile)
						pages.Add(rect);
				}
			}

			return pages;
		}
	}

	class BlankMap
	{
		public static void Print()
		{
			PrintDialog dlg = new PrintDialog();
			dlg.AllowPrintToFile = false;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				PrintDocument doc = new PrintDocument();
				doc.DocumentName = "Blank Grid";
				doc.PrinterSettings = dlg.PrinterSettings;

				for (int page = 0; page != dlg.PrinterSettings.Copies; ++page)
				{
					doc.PrintPage += new PrintPageEventHandler(print_blank_page);
					doc.Print();
				}
			}
		}

		static void print_blank_page(object sender, PrintPageEventArgs e)
		{
			int square_count_h = e.PageSettings.PaperSize.Width / 100;
			int square_count_v = e.PageSettings.PaperSize.Height / 100;

			int square_size_h = e.PageBounds.Width / square_count_h;
			int square_size_v = e.PageBounds.Height / square_count_v;
			int square_size = Math.Min(square_size_h, square_size_v);

			int width = (square_count_h * square_size) + 1;
			int height = (square_count_v * square_size) + 1;

			Bitmap img = new Bitmap(width, height);

			for (int x = 0; x != width; ++x)
			{
				for (int y = 0; y != height; ++y)
				{
					if ((x % square_size == 0) || (y % square_size == 0))
						img.SetPixel(x, y, Color.DarkGray);
				}
			}

			int x_offset = (e.PageBounds.Width - width) / 2;
			int y_offset = (e.PageBounds.Height - height) / 2;
			Rectangle rect = new Rectangle(x_offset, y_offset, width, height);

			e.Graphics.DrawRectangle(Pens.Black, rect);
			e.Graphics.DrawImage(img, rect);
		}
	}
}
