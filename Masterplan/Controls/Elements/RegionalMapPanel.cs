using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using Utils;
using Utils.Graphics;

using Masterplan.Data;

namespace Masterplan.Controls
{
	/// <summary>
	/// Control for displaying a RegionalMap object.
	/// </summary>
	public partial class RegionalMapPanel : UserControl
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public RegionalMapPanel()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);

			fCentred.Alignment = StringAlignment.Center;
			fCentred.LineAlignment = StringAlignment.Center;
			fCentred.Trimming = StringTrimming.EllipsisWord;
		}

		const float LOCATION_RADIUS = 8;

		#region Properties

		/// <summary>
		/// Gets or sets the map to be displayed.
		/// </summary>
		public RegionalMap Map
		{
			get { return fMap; }
			set
			{
				fMap = value;
				Invalidate();
			}
		}
		RegionalMap fMap = null;

		/// <summary>
		/// Gets or sets the mode in which to display the map.
		/// </summary>
		public MapViewMode Mode
		{
			get { return fMode; }
			set
			{
				fMode = value;
				Invalidate();
			}
		}
		MapViewMode fMode = MapViewMode.Normal;

		/// <summary>
		/// Gets or sets the plot to be used for drawing links.
		/// </summary>
		public Plot Plot
		{
			get { return fPlot; }
			set
			{
				fPlot = value;
				Invalidate();
			}
		}
		Plot fPlot = null;

		/// <summary>
		/// Gets or sets whether to show locations on the map.
		/// </summary>
		public bool ShowLocations
		{
			get { return fShowLocations; }
			set
			{
				fShowLocations = value;
				Invalidate();
			}
		}
		bool fShowLocations = true;

		/// <summary>
		/// Gets or sets whether to allow map locations to be moved.
		/// </summary>
		public bool AllowEditing
		{
			get { return fAllowEditing; }
			set { fAllowEditing = value; }
		}
		bool fAllowEditing = false;

		/// <summary>
		/// Gets the hovered map location.
		/// </summary>
		public MapLocation HoverLocation
		{
			get { return fHoverLocation; }
		}
		MapLocation fHoverLocation = null;

		/// <summary>
		/// Gets or sets the selected map location.
		/// </summary>
		public MapLocation SelectedLocation
		{
			get { return fSelectedLocation; }
			set
			{
				fSelectedLocation = value;
				Invalidate();
			}
		}
		MapLocation fSelectedLocation = null;

		/// <summary>
		/// Gets or sets the highlighted map location.
		/// </summary>
		public MapLocation HighlightedLocation
		{
			get { return fHighlightedLocation; }
			set
			{
				fHighlightedLocation = value;
				Invalidate();
			}
		}
		MapLocation fHighlightedLocation = null;

		StringFormat fCentred = new StringFormat();

		#endregion

		#region Events

		/// <summary>
		/// This is called when the selected location has been modified.
		/// </summary>
		public event EventHandler SelectedLocationModified;

		/// <summary>
		/// Raises the SelectedLocationModified event.
		/// </summary>
		protected void OnSelectedLocationModified()
		{
			if (SelectedLocationModified != null)
				SelectedLocationModified(this, new EventArgs());
		}

		/// <summary>
		/// This is called when a location has been modified.
		/// </summary>
		public event EventHandler LocationModified;

		/// <summary>
		/// Raises the LocationModified event.
		/// </summary>
		protected void OnLocationModified()
		{
			if (LocationModified != null)
				LocationModified(this, new EventArgs());
		}

		#endregion

		/// <summary>
		/// Called in response to the Paint event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			try
			{
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

				#region Background

				switch (fMode)
				{
					case MapViewMode.Normal:
					case MapViewMode.Thumbnail:
						{
							Color top = Color.FromArgb(240, 240, 240);
							Color bottom = Color.FromArgb(170, 170, 170);
							Brush background = new LinearGradientBrush(ClientRectangle, top, bottom, LinearGradientMode.Vertical);

							e.Graphics.FillRectangle(background, ClientRectangle);
						}
						break;
					case MapViewMode.Plain:
						{
							e.Graphics.FillRectangle(Brushes.White, ClientRectangle);
						}
						break;
					case MapViewMode.PlayerView:
						{
							e.Graphics.FillRectangle(Brushes.Black, ClientRectangle);
						}
						break;
				}

				#endregion

				if ((fMap == null) || (fMap.Image == null))
				{
					e.Graphics.DrawString("(no map selected)", Font, Brushes.Black, ClientRectangle, fCentred);
					return;
				}

				#region Map

				RectangleF img_rect = MapRectangle;
				e.Graphics.DrawImage(fMap.Image, img_rect);

				#endregion

				#region Locations

				if (fShowLocations)
				{
					foreach (MapLocation loc in fMap.Locations)
					{
						if (loc == null)
							continue;

						if ((fHighlightedLocation != null) && (loc.ID != fHighlightedLocation.ID))
							continue;

						Color c = Color.White;
						if (loc == fHoverLocation)
							c = Color.Blue;
						if (loc == fSelectedLocation)
							c = Color.Blue;

						RectangleF loc_rect = get_loc_rect(loc, img_rect);
						e.Graphics.DrawEllipse(new Pen(Color.Black, 5), loc_rect);
						e.Graphics.DrawEllipse(new Pen(c, 2), loc_rect);
					}
				}

				#endregion

				#region Plot lines

				if (fPlot != null)
				{
					foreach (PlotPoint pp in fPlot.Points)
					{
						if (pp.RegionalMapID != fMap.ID)
							continue;

						MapLocation source = fMap.FindLocation(pp.MapLocationID);
						if (source == null)
							continue;

						PointF source_pt = get_loc_pt(source, img_rect);

						RectangleF source_rect = get_loc_rect(source, img_rect);
						source_rect.Inflate(-5, -5);

						foreach (Guid link in pp.Links)
						{
							PlotPoint dest_point = fPlot.FindPoint(link);
							if (dest_point == null)
								continue;

							if (dest_point.RegionalMapID != fMap.ID)
								continue;

							MapLocation dest = fMap.FindLocation(dest_point.MapLocationID);
							if (dest == null)
								continue;

							PointF dest_pt = get_loc_pt(dest, img_rect);
							e.Graphics.DrawLine(new Pen(Color.Red, 3), source_pt, dest_pt);

							RectangleF dest_rect = get_loc_rect(dest, img_rect);
							dest_rect.Inflate(-5, -5);

							e.Graphics.FillEllipse(Brushes.Red, source_rect);
							e.Graphics.FillEllipse(Brushes.Red, dest_rect);

							// TODO: Draw an arrow
						}
					}
				}

				#endregion

				#region Location labels

				if (fShowLocations)
				{
					foreach (MapLocation loc in fMap.Locations)
					{
						if ((fHighlightedLocation != null) && (loc != fHighlightedLocation))
							continue;

						if ((loc == fHoverLocation) || (loc == fSelectedLocation) || (loc == fHighlightedLocation))
						{
							bool show_category = ((loc.Category != "") && ((fMode == MapViewMode.Normal) || fMode == MapViewMode.Thumbnail));

							RectangleF loc_rect = get_loc_rect(loc, img_rect);

							SizeF name_size = e.Graphics.MeasureString(loc.Name, Font);
							SizeF cat_size = e.Graphics.MeasureString(loc.Category, Font);
							float text_width = show_category ? Math.Max(name_size.Width, cat_size.Width) : name_size.Width;
							float text_height = show_category ? (name_size.Height + cat_size.Height) : name_size.Height;
							SizeF label_size = new SizeF(text_width, text_height);

							label_size.Width += 2;
							label_size.Height += 2;

							float left = loc_rect.X + (loc_rect.Width / 2) - (label_size.Width / 2);
							float top = loc_rect.Top - label_size.Height - 5;

							// If it's too high, move it below the location
							if (top < ClientRectangle.Top)
								top = loc_rect.Bottom + 5;

							// Move left or right
							left = Math.Max(left, 0);
							float right_overlap = (left + label_size.Width - ClientRectangle.Right);
							if (right_overlap > 0)
								left -= right_overlap;

							RectangleF text_rect = new RectangleF(new PointF(left, top), label_size);

							GraphicsPath path = RoundedRectangle.Create(text_rect, Font.Height * 0.35f);

							e.Graphics.FillPath(Brushes.LightYellow, path);
							e.Graphics.DrawPath(Pens.Black, path);

							if (show_category)
							{
								float height = text_rect.Height / 2;
								float middle = text_rect.Y + height;

								RectangleF name_rect = new RectangleF(text_rect.X, text_rect.Y, text_rect.Width, height);
								RectangleF cat_rect = new RectangleF(text_rect.X, middle, text_rect.Width, height);

								e.Graphics.DrawLine(Pens.Gray, text_rect.X, middle, text_rect.X + text_rect.Width, middle);

								e.Graphics.DrawString(loc.Name, Font, Brushes.Black, name_rect, fCentred);
								e.Graphics.DrawString(loc.Category, Font, Brushes.DarkGray, cat_rect, fCentred);
							}
							else
							{
								e.Graphics.DrawString(loc.Name, Font, Brushes.Black, text_rect, fCentred);
							}
						}
					}
				}

				#endregion

				#region Caption

				if ((fMode == MapViewMode.Normal) && (fMap.Locations.Count == 0))
				{
					string caption = "Double-click on the map to set a location.";

					float delta = 10;
					float width = ClientRectangle.Width - (2 * delta);
					SizeF size = e.Graphics.MeasureString(caption, Font, (int)width);
					float height = size.Height * 2;

					RectangleF rect = new RectangleF(delta, delta, width, height);
					GraphicsPath path = RoundedRectangle.Create(rect, height / 3);
					e.Graphics.FillPath(new SolidBrush(Color.FromArgb(200, Color.Black)), path);
					e.Graphics.DrawPath(Pens.Black, path);
					e.Graphics.DrawString(caption, Font, Brushes.White, rect, fCentred);
				}

				#endregion
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Mouse

		/// <summary>
		/// Called in response to the MouseMove event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if ((fMode == MapViewMode.Plain) || (fMode == MapViewMode.PlayerView))
				return;

			// Get location at mouse
			Point mouse = PointToClient(Cursor.Position);
			fHoverLocation = get_location_at(mouse);

			if (fAllowEditing && (e.Button == MouseButtons.Left) && (fSelectedLocation != null))
			{
				PointF pt = get_point(mouse);
				if (pt == PointF.Empty)
				{
					fSelectedLocation = null;
				}
				else
				{
					fSelectedLocation.Point = pt;
					OnLocationModified();
				}
			}

			Invalidate();
		}

		/// <summary>
		/// Called in response to the MouseDown event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((fMode == MapViewMode.Plain) || (fMode == MapViewMode.PlayerView))
				return;

			fSelectedLocation = fHoverLocation;
			OnSelectedLocationModified();

			Invalidate();
		}

		/// <summary>
		/// Called in response to the MouseLeave event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseLeave(EventArgs e)
		{
			if ((fMode == MapViewMode.Plain) || (fMode == MapViewMode.PlayerView))
				return;

			fHoverLocation = null;
			Invalidate();
		}

		#endregion

		/// <summary>
		/// Gets the rectangle within which the map is drawn.
		/// </summary>
		public RectangleF MapRectangle
		{
			get
			{
				if ((fMap == null) || (fMap.Image == null))
					return RectangleF.Empty;

				double square_x = (double)ClientRectangle.Width / fMap.Image.Width;
				double square_y = (double)ClientRectangle.Height / fMap.Image.Height;
				float square_size = (float)Math.Min(square_x, square_y);

				float img_width = square_size * fMap.Image.Width;
				float img_height = square_size * fMap.Image.Height;

				float dx = (ClientRectangle.Width - img_width) / 2;
				float dy = (ClientRectangle.Height - img_height) / 2;

				return new RectangleF(dx, dy, img_width, img_height);
			}
		}

		#region Helper methods

		PointF get_loc_pt(MapLocation loc, RectangleF img_rect)
		{
			float x = img_rect.X + (img_rect.Width * loc.Point.X);
			float y = img_rect.Y + (img_rect.Height * loc.Point.Y);

			return new PointF(x, y);
		}

		RectangleF get_loc_rect(MapLocation loc, RectangleF img_rect)
		{
			PointF pt = get_loc_pt(loc, img_rect);

			float size = LOCATION_RADIUS;
			return new RectangleF(pt.X - size, pt.Y - size, 2 * size, 2 * size);
		}

		MapLocation get_location_at(Point pt)
		{
			if (fMap == null)
				return null;

			RectangleF img_rect = MapRectangle;
			foreach (MapLocation loc in fMap.Locations)
			{
				RectangleF rect = get_loc_rect(loc, img_rect);
				if (rect.Contains(pt))
					return loc;
			}

			return null;
		}

		PointF get_point(Point pt)
		{
			RectangleF img_rect = MapRectangle;

			if (!img_rect.Contains(pt))
				return PointF.Empty;

			float dx = (pt.X - img_rect.X) / img_rect.Width;
			float dy = (pt.Y - img_rect.Y) / img_rect.Height;

			return new PointF(dx, dy);
		}

		#endregion
	}
}
