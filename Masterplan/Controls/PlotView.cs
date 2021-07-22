using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.Controls
{
	/// <summary>
	/// Settings for displaying plot points on a PlotView control.
	/// </summary>
	public enum PlotViewMode
	{
		/// <summary>
		/// Display all plot points.
		/// </summary>
		Normal,

		/// <summary>
		/// Display all plot points on a plain background.
		/// </summary>
		Plain,

		/// <summary>
		/// Highlight the selected plot point and those connected to it.
		/// </summary>
		HighlightSelected,

		/// <summary>
		/// Highight plot points containing encounters.
		/// </summary>
		HighlightEncounter,

		/// <summary>
		/// Highight plot points containing traps.
		/// </summary>
		HighlightTrap,

		/// <summary>
		/// Highight plot points containing skill challenges.
		/// </summary>
		HighlightChallenge,

		/// <summary>
		/// Highight plot points containing quests.
		/// </summary>
		HighlightQuest,

		/// <summary>
		/// Highight plot points containing treasure parcels.
		/// </summary>
		HighlightParcel
	}

	/// <summary>
	/// Settings for displaying plot point links.
	/// </summary>
	public enum PlotViewLinkStyle
	{
		/// <summary>
		/// Curved links.
		/// </summary>
		Curved,

		/// <summary>
		/// Angled links.
		/// </summary>
		Angled,

		/// <summary>
		/// Straight links.
		/// </summary>
		Straight
	}

	/// <summary>
	/// A control for displaying the structure of a Plot object
	/// </summary>
	public partial class PlotView : UserControl
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public PlotView()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint
				| ControlStyles.Selectable, true);

			fCentred.Alignment = StringAlignment.Center;
			fCentred.LineAlignment = StringAlignment.Center;
			fCentred.Trimming = StringTrimming.EllipsisWord;
		}

		#region Fields

		PlotPoint fHoverPoint = null;

		StringFormat fCentred = new StringFormat();

		List<List<PlotPoint>> fLayers = null;
		Dictionary<Guid, RectangleF> fRegions = null;
		Dictionary<Guid, Dictionary<Guid, List<PointF>>> fLinkPaths = null;

		Rectangle fUpRect = Rectangle.Empty;
		Rectangle fDownRect = Rectangle.Empty;

		const int ARROW_SIZE = 6;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the Plot to be displayed.
		/// </summary>
		[Category("Data"), Description("The plot to display.")]
		public Plot Plot
		{
			get { return fPlot; }
			set
			{
				if (fPlot != value)
				{
					fPlot = value;
					fSelectedPoint = null;
					fHoverPoint = null;

					RecalculateLayout();
					Invalidate();

					OnSelectionChanged();
				}
			}
		}
		Plot fPlot = null;

		/// <summary>
		/// Gets or sets the plot display mode.
		/// </summary>
		[Category("Appearance"), Description("How the plot should be displayed.")]
		public PlotViewMode Mode
		{
			get { return fMode; }
			set
			{
				fMode = value;

				Invalidate();
			}
		}
		PlotViewMode fMode = PlotViewMode.Normal;

		/// <summary>
		/// Gets or sets the link display mode.
		/// </summary>
		[Category("Appearance"), Description("How plot point links should be displayed.")]
		public PlotViewLinkStyle LinkStyle
		{
			get { return fLinkStyle; }
			set
			{
				fLinkStyle = value;

				RecalculateLayout();
				Invalidate();
			}
		}
		PlotViewLinkStyle fLinkStyle = PlotViewLinkStyle.Curved;

		/// <summary>
		/// Gets or sets the plot point filter.
		/// Plot points which do not contain this text will not be shown.
		/// </summary>
		[Category("Behavior"), Description("Plot points which do not contain this text are not shown.")]
		public string Filter
		{
			get { return fFilter; }
			set
			{
				fFilter = value;
				Invalidate();
			}
		}
		string fFilter = "";

		/// <summary>
		/// Gets or sets a value indicating whether levelling information is shown on the control.
		/// </summary>
		[Category("Appearance"), Description("Determines whether levelling information is shown.")]
		public bool ShowLevels
		{
			get { return fShowLevels; }
			set
			{
				fShowLevels = value;
				Invalidate();
			}
		}
		bool fShowLevels = true;

		/// <summary>
		/// Gets or sets the selected plot point.
		/// </summary>
		[Category("Behavior"), Description("The selected point.")]
		public PlotPoint SelectedPoint
		{
			get { return fSelectedPoint; }
			set
			{
				if (fSelectedPoint != value)
				{
					fSelectedPoint = value;

					Invalidate();

					OnSelectionChanged();
				}
			}
		}
		PlotPoint fSelectedPoint = null;

		/// <summary>
		/// Gets or sets a value indicating whether plot tooltips should be shown.
		/// </summary>
		[Category("Appearance"), Description("Determines whether tooltips are shown.")]
		public bool ShowTooltips
		{
			get { return fShowTooltips; }
			set { fShowTooltips = value; }
		}
		bool fShowTooltips = true;

		#endregion

		#region Methods

		/// <summary>
		/// Handles keyboard navigation.
		/// </summary>
		/// <param name="key">The keypress to handle.</param>
		/// <returns>Returns true if the key was handled; false otherwise.</returns>
		public bool Navigate(Keys key)
		{
			try
			{
				if (SelectedPoint == null)
					return false;

				List<List<PlotPoint>> layers = Workspace.FindLayers(fPlot);

				int current_layer;
				for (current_layer = 0; current_layer != layers.Count; ++current_layer)
				{
					if (layers[current_layer].Contains(SelectedPoint))
						break;
				}

				if (key == Keys.Up)
				{
					if (current_layer != 0)
					{
						List<PlotPoint> layer = layers[current_layer - 1];

						foreach (PlotPoint pp in layer)
						{
							if (pp.Links.Contains(SelectedPoint.ID))
							{
								SelectedPoint = pp;
								break;
							}
						}
					}

					return true;
				}

				if (key == Keys.Down)
				{
					if (current_layer != layers.Count - 1)
					{
						List<PlotPoint> layer = layers[current_layer + 1];

						foreach (PlotPoint pp in layer)
						{
							if (SelectedPoint.Links.Contains(pp.ID))
							{
								SelectedPoint = layer[0];
								break;
							}
						}
					}

					return true;
				}

				if (key == Keys.Left)
				{
					List<PlotPoint> layer = layers[current_layer];
					int index = layer.IndexOf(SelectedPoint);
					if (index != 0)
						SelectedPoint = layer[index - 1];

					return true;
				}

				if (key == Keys.Right)
				{
					List<PlotPoint> layer = layers[current_layer];
					int index = layer.IndexOf(SelectedPoint);
					if (index != layer.Count - 1)
						SelectedPoint = layer[index + 1];

					return true;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return false;
		}

		/// <summary>
		/// Invalidates all layout calculations
		/// </summary>
		public void RecalculateLayout()
		{
			clear_layout_calculations();
		}

		#endregion

		#region Events

		/// <summary>
		/// Occurs when the selected plot point changes.
		/// </summary>
		[Category("Property Changed"), Description("Occurs when the selected point changes.")]
		public event EventHandler SelectionChanged;

		/// <summary>
		/// Raises the SelectionChanged event.
		/// </summary>
		protected void OnSelectionChanged()
		{
			try
			{
				if (SelectionChanged != null)
					SelectionChanged(this, new EventArgs());
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Occurs when the plot layout changes.
		/// </summary>
		[Category("Property Changed"), Description("Occurs when the plot layout changes.")]
		public event EventHandler PlotLayoutChanged;

		/// <summary>
		/// Raises the PlotChanged event.
		/// </summary>
		protected void OnPlotLayoutChanged()
		{
			try
			{
				if (PlotLayoutChanged != null)
					PlotLayoutChanged(this, new EventArgs());
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Occurs when the current plot changes.
		/// </summary>
		[Category("Property Changed"), Description("Occurs when the current plot changes.")]
		public event EventHandler PlotChanged;

		/// <summary>
		/// Raises the PlotChanged event.
		/// </summary>
		protected void OnPlotChanged()
		{
			try
			{
				if (PlotChanged != null)
					PlotChanged(this, new EventArgs());
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Painting

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

				if (fLayers == null)
					do_layout_calculations();

				#region Background

				// Draw background
				if (fMode == PlotViewMode.Plain)
				{
					e.Graphics.FillRectangle(SystemBrushes.Window, ClientRectangle);
				}
				else
				{
					Color top = Color.FromArgb(240, 240, 240);
					Color bottom = Color.FromArgb(170, 170, 170);
					using (Brush background = new LinearGradientBrush(ClientRectangle, top, bottom, LinearGradientMode.Vertical))
					{
						e.Graphics.FillRectangle(background, ClientRectangle);
					}

					Point mouse = PointToClient(Cursor.Position);

					PlotPoint pp = Session.Project.FindParent(fPlot);
					if (pp != null)
					{
						using (Font f = new Font(Font.FontFamily, Font.Size * 2))
							e.Graphics.DrawString(pp.Name, f, Brushes.DarkGray, ClientRectangle.Left + 10, ClientRectangle.Top + 10);
					}

					Color up_btn = (pp == null) ? Color.DarkGray : Color.Black;
					Color down_btn = (fSelectedPoint == null) ? Color.DarkGray : Color.Black;

					using (Pen up_pen = new Pen(up_btn))
					{
						using (Pen down_pen = new Pen(down_btn))
						{
							using (Brush up_brush = new SolidBrush(up_btn))
							{
								using (Brush down_brush = new SolidBrush(down_btn))
								{
									// Draw 'up' arrow
									Point bottom_left = new Point(fUpRect.Left + 5, fUpRect.Bottom - 5);
									Point bottom_right = new Point(fUpRect.Right - 5, fUpRect.Bottom - 5);
									Point top_centre = new Point((fUpRect.Right + fUpRect.Left) / 2, fUpRect.Top + 5);
									if (fUpRect.Contains(mouse))
										e.Graphics.FillPolygon(up_brush, new Point[] { bottom_left, bottom_right, top_centre });
									else
										e.Graphics.DrawPolygon(up_pen, new Point[] { bottom_left, bottom_right, top_centre });

									// Draw 'down' arrow
									Point top_left = new Point(fDownRect.Left + 5, fDownRect.Top + 5);
									Point top_right = new Point(fDownRect.Right - 5, fDownRect.Top + 5);
									Point bottom_centre = new Point((fDownRect.Right + fDownRect.Left) / 2, fDownRect.Bottom - 5);
									if (fDownRect.Contains(mouse))
										e.Graphics.FillPolygon(down_brush, new Point[] { top_left, top_right, bottom_centre });
									else
										e.Graphics.DrawPolygon(down_pen, new Point[] { top_left, top_right, bottom_centre });
								}
							}
						}
					}
				}

				if (Session.Project == null)
				{
					string str = "(no project)";
					e.Graphics.DrawString(str, Font, SystemBrushes.WindowText, ClientRectangle, fCentred);

					return;
				}

				if ((fPlot == null) || (fPlot.Points.Count == 0))
				{
					string str = "(no plot points)";
					e.Graphics.DrawString(str, Font, SystemBrushes.WindowText, ClientRectangle, fCentred);

					return;
				}

				#endregion

				#region Dragged point

				if ((fDragLocation != null) && (fHoverPoint == null))
				{
					float midpoint = fDragLocation.Rect.Left + (fDragLocation.Rect.Width / 2);
					using (Pen p2 = new Pen(Color.DarkBlue, 2))
					{
						e.Graphics.DrawLine(p2, midpoint, fDragLocation.Rect.Top, midpoint, fDragLocation.Rect.Bottom);
					}

					float x_delta = 3;

					using (Pen p = new Pen(Color.DarkBlue, 1))
					{
						PointF tl = new PointF(midpoint - x_delta, fDragLocation.Rect.Top);
						PointF tr = new PointF(midpoint + x_delta, fDragLocation.Rect.Top);
						e.Graphics.DrawLine(p, tl, tr);

						PointF bl = new PointF(midpoint - x_delta, fDragLocation.Rect.Bottom);
						PointF br = new PointF(midpoint + x_delta, fDragLocation.Rect.Bottom);
						e.Graphics.DrawLine(p, bl, br);
					}
				}

				#endregion

				#region Level-up lines

				// Draw level up lines
				if (fShowLevels)
				{
					for (int layer_index = 0; layer_index != fLayers.Count; ++layer_index)
					{
						List<PlotPoint> layer = fLayers[layer_index];

						int start_xp = Workspace.GetTotalXP(layer[0]);
						int end_xp = start_xp + Workspace.GetLayerXP(layer);

						int start_level = Experience.GetHeroLevel(start_xp / Session.Project.Party.Size);
						int end_level = Experience.GetHeroLevel(end_xp / Session.Project.Party.Size);

						if (start_level != end_level)
						{
							// Draw a line under this layer

							PlotPoint first_point = layer[0];
							RectangleF first_rect = fRegions[first_point.ID];

							int index = fLayers.IndexOf(layer);
							float y = first_rect.Height * ((index * 2) + 2.5F);

							PointF start = new PointF(0F, y);
							PointF end = new PointF(Width, y);
							e.Graphics.DrawLine(SystemPens.ControlDarkDark, start, end);

							PointF text = new PointF(0F, y - Font.Height);
							e.Graphics.DrawString("Level " + end_level, Font, SystemBrushes.WindowText, text);
						}
					}
				}

				#endregion

				#region Links

				// Draw links
				foreach (PlotPoint pp in fPlot.Points)
				{
					if (!fRegions.ContainsKey(pp.ID))
						continue;

					foreach (Guid id in pp.Links)
					{
						if (!fRegions.ContainsKey(id))
							continue;

						// Draw this link

						RectangleF from_rect = fRegions[pp.ID];
						RectangleF to_rect = fRegions[id];

						PointF from_delta = new PointF(from_rect.X + (from_rect.Width / 2), from_rect.Bottom);
						PointF from_pt = new PointF(from_rect.X + (from_rect.Width / 2), from_rect.Bottom + (ARROW_SIZE * 2));
						PointF to_pt = new PointF(to_rect.X + (to_rect.Width / 2), to_rect.Top - (ARROW_SIZE * 2));
						PointF to_delta = new PointF(to_pt.X, to_pt.Y + ARROW_SIZE);
						PointF to_end = new PointF(to_rect.X + (to_rect.Width / 2), to_rect.Top);

						int link_alpha = 130;
						float link_width = 2;

						PlotPoint to_pp = fPlot.FindPoint(id);
						if (draw_link(pp, to_pp))
						{
							PointF left = new PointF(to_delta.X - ARROW_SIZE, to_delta.Y);
							PointF right = new PointF(to_delta.X + ARROW_SIZE, to_delta.Y);
							PointF bottom = new PointF(to_delta.X, to_delta.Y + ARROW_SIZE);

							e.Graphics.FillPolygon(SystemBrushes.Window, new PointF[] { left, right, bottom });
							e.Graphics.DrawPolygon(Pens.Maroon, new PointF[] { left, right, bottom });
						}
						else
						{
							link_alpha = 60;
							link_width = 0.5F;
							to_delta = new PointF(to_pt.X, to_rect.Top);
						}

						using (Pen link_pen = new Pen(Color.FromArgb(link_alpha, Color.Maroon), link_width))
						{
							e.Graphics.DrawLine(link_pen, from_delta, from_pt);
							e.Graphics.DrawLine(link_pen, to_pt, to_delta);

							switch (fLinkStyle)
							{
								case PlotViewLinkStyle.Curved:
									{
										bool drawn = false;

										if (fLinkPaths.ContainsKey(pp.ID))
										{
											Dictionary<Guid, List<PointF>> link_paths = fLinkPaths[pp.ID];
											if (link_paths.ContainsKey(id))
											{
												List<PointF> path = link_paths[id];
												e.Graphics.DrawCurve(link_pen, path.ToArray());
												drawn = true;
											}
										}

										if (!drawn)
											e.Graphics.DrawLine(link_pen, from_pt, to_pt);
									}
									break;
								case PlotViewLinkStyle.Angled:
									{
										bool drawn = false;

										if (fLinkPaths.ContainsKey(pp.ID))
										{
											Dictionary<Guid, List<PointF>> link_paths = fLinkPaths[pp.ID];
											if (link_paths.ContainsKey(id))
											{
												List<PointF> path = link_paths[id];
												e.Graphics.DrawLines(link_pen, path.ToArray());
												drawn = true;
											}
										}

										if (!drawn)
											e.Graphics.DrawLine(link_pen, from_pt, to_pt);
									}
									break;
								case PlotViewLinkStyle.Straight:
									{
										e.Graphics.DrawLine(link_pen, from_pt, to_pt);
									}
									break;
							}
						}
					}
				}

				#endregion

				#region Plot points

				// Draw plot points
				foreach (PlotPoint pp in fPlot.Points)
				{
					if (!fRegions.ContainsKey(pp.ID))
						continue;

					RectangleF point_rect = fRegions[pp.ID];

					int alpha = 255;
					if (pp.State != PlotPointState.Normal)
						alpha = 50;

					Brush point_background = null;
					if (pp == fSelectedPoint)
					{
						point_background = Brushes.White;
					}
					else
					{
						Pair<Color, Color> gradient = GetColourGradient(pp.Colour, alpha);
						point_background = new LinearGradientBrush(point_rect, gradient.First, gradient.Second, LinearGradientMode.Vertical);
					}

					Pen outline = (pp == fHoverPoint) ? SystemPens.Highlight : SystemPens.WindowText;
					Font font = (pp != fSelectedPoint) ? Font : new Font(Font, Font.Style | FontStyle.Bold);
					if (pp.State == PlotPointState.Skipped)
						font = new Font(font, Font.Style | FontStyle.Strikeout);

					#region Check difficulty

					if (pp.Element != null)
					{
						int level = Workspace.GetPartyLevel(pp);

						Difficulty diff = pp.Element.GetDifficulty(level, Session.Project.Party.Size);
						if ((diff == Difficulty.Trivial) || (diff == Difficulty.Extreme))
						{
							if (pp != fSelectedPoint)
							{
								point_background = new SolidBrush(Color.FromArgb(alpha, Color.Pink));
								outline = Pens.Red;
							}
						}
					}

					#endregion

					if (draw_point(pp))
					{
						#region Draw point

						Brush text = SystemBrushes.WindowText;

						if (pp.State == PlotPointState.Normal)
						{
							// Draw shadow
							RectangleF shadow = new RectangleF(point_rect.Location, point_rect.Size);
							shadow.Offset(3, 4);
							using (Brush shadow_brush = new SolidBrush(Color.FromArgb(100, Color.Black)))
							{
								e.Graphics.FillRectangle(shadow_brush, shadow);
							}
						}
						else
						{
							if (pp != fSelectedPoint)
								text = new SolidBrush(Color.FromArgb(alpha, Color.Black));
						}

						// Draw plot point
						e.Graphics.FillRectangle(point_background, point_rect);
						e.Graphics.DrawRectangle(outline, point_rect.X, point_rect.Y, point_rect.Width, point_rect.Height);

						float font_size = font.Size;
						while (e.Graphics.MeasureString(pp.Name, font, (int)point_rect.Width).Height > point_rect.Height)
						{
							font_size *= 0.95F;
							font = new Font(font.FontFamily, font_size, font.Style);
						}
						e.Graphics.DrawString(pp.Name, font, text, point_rect, fCentred);

						if (pp.Subplot.Points.Count > 0)
						{
							point_rect = RectangleF.Inflate(point_rect, -2, -2);
							e.Graphics.DrawRectangle(outline, point_rect.X, point_rect.Y, point_rect.Width, point_rect.Height);
						}

						if ((pp.Details != "") || (pp.ReadAloud != ""))
						{
							const int delta_x = 20;
							const int delta_y = 5;

							double theta = Math.Atan((double)delta_y / delta_x) * 2;
							float dx = delta_x - (float)(delta_x * Math.Cos(theta));
							float dy = (float)(delta_x * Math.Sin(theta));

							PointF bottom = new PointF(point_rect.Right - delta_x, point_rect.Bottom);
							PointF right = new PointF(point_rect.Right, point_rect.Bottom - delta_y);
							PointF top = new PointF(point_rect.Right - dx, point_rect.Bottom - dy);
							PointF corner = new PointF(point_rect.Right, point_rect.Bottom);

							e.Graphics.DrawPolygon(Pens.Gray, new PointF[] { top, right, bottom });
							using (Brush b = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
							{
								e.Graphics.FillPolygon(b, new PointF[] { right, bottom, corner });
							}
						}

						#endregion
					}
					else
					{
						// Draw outline only
						using (Pen p = new Pen(Color.FromArgb(60, outline.Color)))
						{
							e.Graphics.DrawRectangle(outline, point_rect.X, point_rect.Y, point_rect.Width, point_rect.Height);
						}
					}
				}

				#endregion
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void clear_layout_calculations()
		{
			fUpRect = Rectangle.Empty;
			fDownRect = Rectangle.Empty;

			fLayers = null;
			fRegions = null;
			fLinkPaths = null;
		}

		void do_layout_calculations()
		{
			try
			{
				clear_layout_calculations();

				fUpRect = new Rectangle(ClientRectangle.Right - 35, ClientRectangle.Top + 15, 25, 20);
				fDownRect = new Rectangle(ClientRectangle.Right - 35, ClientRectangle.Top + 40, 25, 20);

				// Start by determining layers
				fLayers = Workspace.FindLayers(fPlot);

				#region Plot point locations

				// Determine plot point locations
				fRegions = new Dictionary<Guid, RectangleF>();
				int levels = (fLayers.Count * 2) + 1;
				float height = (float)(ClientRectangle.Height - 1) / levels;
				foreach (List<PlotPoint> layer in fLayers)
				{
					int layer_index = (fLayers.IndexOf(layer) * 2) + 1;

					float y = layer_index * height;
					RectangleF layer_rect = new RectangleF(ClientRectangle.X, y, ClientRectangle.Width, height);

					int layer_spaces = (layer.Count * 2) + 1;
					float width = layer_rect.Width / layer_spaces;

					foreach (PlotPoint pp in layer)
					{
						int point_index = (layer.IndexOf(pp) * 2) + 1;

						float x = point_index * width;
						RectangleF point_rect = new RectangleF(x, y, width, height);

						fRegions[pp.ID] = point_rect;
					}
				}

				#endregion

				#region Link paths

				// Calculate link paths
				if (fLinkStyle != PlotViewLinkStyle.Straight)
				{
					fLinkPaths = new Dictionary<Guid, Dictionary<Guid, List<PointF>>>();
					foreach (PlotPoint pp in fPlot.Points)
					{
						if (!fRegions.ContainsKey(pp.ID))
							continue;

						Dictionary<Guid, List<PointF>> link_paths = new Dictionary<Guid, List<PointF>>();

						foreach (Guid id in pp.Links)
						{
							if (!fRegions.ContainsKey(id))
								continue;

							RectangleF from = fRegions[pp.ID];
							RectangleF to = fRegions[id];

							PointF from_pt = new PointF(from.X + (from.Width / 2), from.Bottom + (ARROW_SIZE * 2));
							PointF to_pt = new PointF(to.X + (to.Width / 2), to.Top - (ARROW_SIZE * 2));

							List<PointF> points = new List<PointF>();
							points.Add(from_pt);

							bool finished = false;
							while (!finished)
							{
								PlotPoint in_the_way = null;
								int layer_diff = find_layer_index(id, fLayers) - find_layer_index(pp.ID, fLayers);
								if (layer_diff > 1)
									in_the_way = get_blocking_point(from_pt, to_pt);

								if (in_the_way == null)
								{
									finished = true;
								}
								else
								{
									RectangleF point_rect = fRegions[in_the_way.ID];

									int layer_index = find_layer_index(in_the_way.ID, fLayers);
									List<PlotPoint> layer = fLayers[layer_index];

									float delta = point_rect.Width / 3;
									if (layer.Count == 1)
										delta = point_rect.Width / 6;

									float midpoint = (float)Math.Round(point_rect.Left + (point_rect.Width / 2));
									float x = (midpoint >= to_pt.X) ? point_rect.Left - delta : point_rect.Right + delta;

									PointF top = new PointF(x, point_rect.Top);
									PointF bottom = new PointF(x, point_rect.Bottom);

									points.Add(top);
									points.Add(bottom);

									from_pt = bottom;
								}
							}

							points.Add(to_pt);
							link_paths[id] = points;
						}

						fLinkPaths[pp.ID] = link_paths;
					}
				}

				#endregion
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

		}

		#endregion

		/// <summary>
		/// Called in response to the Resize event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnResize(EventArgs e)
		{
			try
			{
				base.OnResize(e);

				clear_layout_calculations();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Mouse

		/// <summary>
		/// Called in response to the MouseLeave event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseLeave(EventArgs e)
		{
			try
			{
				fHoverPoint = null;

				Invalidate();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the MouseDown event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseDown(MouseEventArgs e)
		{
			try
			{
				if (fMode == PlotViewMode.Plain)
					return;

				Point mouse = PointToClient(Cursor.Position);

				if (fUpRect.Contains(mouse))
				{
					// Move up
					PlotPoint parent_point = Session.Project.FindParent(fPlot);
					if (parent_point != null)
					{
						Plot p = Session.Project.FindParent(parent_point);
						if (p != null)
						{
							Plot = p;
							OnPlotChanged();
						}
					}
				}

				if (fDownRect.Contains(mouse))
				{
					// Move down
					if (fSelectedPoint != null)
					{
						Plot = fSelectedPoint.Subplot;
						OnPlotChanged();
					}
				}

				PlotPoint pp = find_point_at(mouse);
				if (fSelectedPoint != pp)
				{
					fSelectedPoint = pp;
					Invalidate();

					OnSelectionChanged();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the MouseMove event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnMouseMove(MouseEventArgs e)
		{
			try
			{
				if (fMode == PlotViewMode.Plain)
					return;

				Point mouse = PointToClient(Cursor.Position);
				PlotPoint hovered = find_point_at(mouse);
				if (fHoverPoint != hovered)
				{
					fHoverPoint = hovered;
					set_tooltip();
				}

				if ((e.Button == MouseButtons.Left) && (fSelectedPoint != null))
					DoDragDrop(fSelectedPoint, DragDropEffects.All);

				Invalidate();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Drag and drop

		#region DragLocation class

		class DragLocation
		{
			public PlotPoint LHS = null;
			public PlotPoint RHS = null;

			public RectangleF Rect = RectangleF.Empty;
		}

		DragLocation fDragLocation = null;

		#endregion

		/// <summary>
		/// Called in response to the DragOver event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnDragOver(DragEventArgs e)
		{
			try
			{
				Point mouse = PointToClient(Cursor.Position);
				fHoverPoint = find_point_at(mouse);

				PlotPoint dragged = e.Data.GetData(typeof(PlotPoint)) as PlotPoint;

				e.Effect = DragDropEffects.None;
				if (fHoverPoint != null)
				{
					if (allow_drop(dragged, fHoverPoint))
						e.Effect = DragDropEffects.Move;
				}
				else
				{
					fDragLocation = allow_drop(dragged, mouse);

					if (fDragLocation != null)
						e.Effect = DragDropEffects.Move;
				}

				Invalidate();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		/// <summary>
		/// Called in response to the DragDrop event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnDragDrop(DragEventArgs e)
		{
			try
			{
				PlotPoint dragged = e.Data.GetData(typeof(PlotPoint)) as PlotPoint;

				if (fHoverPoint != null)
				{
					if (allow_drop(dragged, fHoverPoint))
					{
						// Create link from target to source
						fHoverPoint.Links.Add(dragged.ID);

						OnPlotLayoutChanged();
					}
				}
				else
				{
					if (fDragLocation != null)
					{
						fPlot.Points.Remove(dragged);

						if (fDragLocation.RHS != null)
						{
							int index = fPlot.Points.IndexOf(fDragLocation.RHS);
							fPlot.Points.Insert(index, dragged);

							OnPlotLayoutChanged();
						}
						else
						{
							fPlot.Points.Add(dragged);

							OnPlotLayoutChanged();
						}
					}

					fDragLocation = null;
				}

				do_layout_calculations();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		bool allow_drop(PlotPoint dragged, PlotPoint target)
		{
			try
			{
				// Check that the target is not the same as the dragged point
				if (dragged == target)
					return false;

				// Check that the target is not the parent of the dragged point
				if (target.Links.Contains(dragged.ID))
					return false;

				// Check that the target is not in the dragged point's subtree
				List<PlotPoint> subtree = fPlot.FindSubtree(dragged);
				if (subtree.Contains(target))
					return false;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return true;
		}

		DragLocation allow_drop(PlotPoint dragged, Point pt)
		{
			try
			{
				RectangleF dragged_rect = fRegions[dragged.ID];
				RectangleF layer_rect = new RectangleF(0, dragged_rect.Y, ClientRectangle.Width, dragged_rect.Height);

				if (!layer_rect.Contains(pt))
					return null;

				// Find all the points on this layer
				List<PlotPoint> points = new List<PlotPoint>();
				foreach (PlotPoint pp in fPlot.Points)
				{
					RectangleF point_rect = fRegions[pp.ID];

					if (!layer_rect.Contains(point_rect))
						continue;

					if (point_rect.Contains(pt))
						return null;

					points.Add(pp);
				}

				if (points.Count == 0)
					return null;

				List<Pair<PlotPoint, PlotPoint>> pairs = new List<Pair<PlotPoint, PlotPoint>>();
				foreach (PlotPoint pp in points)
				{
					int index = points.IndexOf(pp);

					if (index == 0)
					{
						pairs.Add(new Pair<PlotPoint, PlotPoint>(null, pp));
					}
					else
					{
						pairs.Add(new Pair<PlotPoint, PlotPoint>(points[index - 1], pp));
					}

					if (index == (points.Count - 1))
						pairs.Add(new Pair<PlotPoint, PlotPoint>(pp, null));
				}

				foreach (Pair<PlotPoint, PlotPoint> pair in pairs)
				{
					if ((pair.First == dragged) || (pair.Second == dragged))
						continue;

					float left = 0;
					float right = ClientRectangle.Width;
					if (pair.First != null)
					{
						RectangleF left_rect = fRegions[pair.First.ID];
						left = left_rect.Right;
					}
					if (pair.Second != null)
					{
						RectangleF right_rect = fRegions[pair.Second.ID];
						right = right_rect.Left;
					}

					RectangleF rect = new RectangleF(left, layer_rect.Y, right - left, layer_rect.Height);
					if (rect.Contains(pt))
					{
						DragLocation db = new DragLocation();
						db.LHS = pair.First;
						db.RHS = pair.Second;
						db.Rect = rect;
						return db;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return null;
		}

		#endregion

		#region Helper methods

		PlotPoint find_point_at(Point pt)
		{
			try
			{
				if (fRegions == null)
					do_layout_calculations();

				foreach (Guid id in fRegions.Keys)
				{
					RectangleF rect = fRegions[id];

					if (rect.Contains(pt))
						return fPlot.FindPoint(id);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return null;
		}

		bool draw_point(PlotPoint pp)
		{
			try
			{
				if (fFilter != "")
					return match_filter(pp);

				if (fMode == PlotViewMode.HighlightSelected)
					return ((fSelectedPoint == null) || (pp == fSelectedPoint) || (fSelectedPoint.Links.Contains(pp.ID) || (pp.Links.Contains(fSelectedPoint.ID))));

				if (fMode == PlotViewMode.HighlightEncounter)
					return ((pp.Element != null) && (pp.Element is Encounter));

				if (fMode == PlotViewMode.HighlightTrap)
				{
					if (pp.Element == null)
						return false;

					if (pp.Element is TrapElement)
						return true;

					if (pp.Element is Encounter)
					{
						Encounter enc = pp.Element as Encounter;
						return (enc.Traps.Count != 0);
					}
				}

				if (fMode == PlotViewMode.HighlightChallenge)
				{
					if (pp.Element == null)
						return false;

					if (pp.Element is SkillChallenge)
						return true;

					if (pp.Element is Encounter)
					{
						Encounter enc = pp.Element as Encounter;
						return (enc.SkillChallenges.Count != 0);
					}
				}

				if (fMode == PlotViewMode.HighlightQuest)
					return ((pp.Element != null) && (pp.Element is Quest));

				if (fMode == PlotViewMode.HighlightParcel)
					return (pp.Parcels.Count != 0);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return true;
		}

		bool draw_link(PlotPoint pp1, PlotPoint pp2)
		{
			try
			{
				if (fFilter != "")
					return (draw_point(pp1) && draw_point(pp2));

				if (fMode == PlotViewMode.HighlightSelected)
					return ((fSelectedPoint == null) || (pp1 == fSelectedPoint) || (pp2 == fSelectedPoint));
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return true;
		}

		bool match_filter(PlotPoint pp)
		{
			try
			{
				string[] tokens = fFilter.Split();

				foreach (string token in tokens)
				{
					if (!match_token(pp, token))
						return false;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return true;
		}

		bool match_token(PlotPoint pp, string token)
		{
			try
			{
				token = token.ToLower();

				if (pp.Name.ToLower().Contains(token))
					return true;

				if (pp.Details.ToLower().Contains(token))
					return true;

				if (pp.ReadAloud.ToLower().Contains(token))
					return true;

				if (pp.Element is Encounter)
				{
					Encounter enc = pp.Element as Encounter;

					foreach (EncounterSlot slot in enc.Slots)
					{
						ICreature t = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
						if (t.Name.ToLower().Contains(token))
							return true;
					}

					foreach (EncounterNote note in enc.Notes)
					{
						if (note.Contents.ToLower().Contains(token))
							return true;
					}
				}

				if (pp.Element is SkillChallenge)
				{
					SkillChallenge sc = pp.Element as SkillChallenge;

					if (sc.Success.ToLower().Contains(token))
						return true;

					if (sc.Failure.ToLower().Contains(token))
						return true;

					foreach (SkillChallengeData scd in sc.Skills)
					{
						if (scd.SkillName.ToLower().Contains(token))
							return true;

						if (scd.Details.ToLower().Contains(token))
							return true;
					}
				}

				if (pp.Element is TrapElement)
				{
					TrapElement te = pp.Element as TrapElement;

					if (te.Trap.Name.ToLower().Contains(token))
						return true;

					foreach (TrapSkillData tsd in te.Trap.Skills)
					{
						if (tsd.SkillName.ToLower().Contains(token))
							return true;

						if (tsd.Details.ToLower().Contains(token))
							return true;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return false;
		}

		void set_tooltip()
		{
			try
			{
				if ((fShowTooltips) && (fHoverPoint != null))
				{
					List<string> contents = new List<string>();

					if (fHoverPoint.Element != null)
					{
						if (fHoverPoint.Element is Encounter)
						{
							Encounter enc = fHoverPoint.Element as Encounter;

							string str = "Encounter: " + enc.GetXP() + " XP";

							foreach (EncounterSlot slot in enc.Slots)
							{
								ICreature t = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);

								if (t != null)
								{
									str += Environment.NewLine + t.Name;
									if (slot.CombatData.Count > 1)
										str += " (x" + slot.CombatData.Count + ")";
								}
							}

							foreach (Trap trap in enc.Traps)
							{
								str += Environment.NewLine + trap.Name + ": " + trap.Info;
							}

							foreach (SkillChallenge sc in enc.SkillChallenges)
							{
								str += Environment.NewLine + sc.Name + ": " + sc.Info;
							}

							contents.Add(str);
						}

						if (fHoverPoint.Element is TrapElement)
						{
							TrapElement te = fHoverPoint.Element as TrapElement;

							string str = te.Trap.Name + ": " + te.GetXP() + " XP";
							str += Environment.NewLine + te.Trap.Info + " " + te.Trap.Type.ToString().ToLower();

							contents.Add(str);
						}

						if (fHoverPoint.Element is SkillChallenge)
						{
							SkillChallenge sc = fHoverPoint.Element as SkillChallenge;

							string str = sc.Name + ": " + sc.GetXP() + " XP";
							str += Environment.NewLine + sc.Info;

							contents.Add(str);
						}

						if (fHoverPoint.Element is Quest)
						{
							Quest q = fHoverPoint.Element as Quest;

							string str = "";
							switch (q.Type)
							{
								case QuestType.Major:
									str = "Major quest: " + q.GetXP() + " XP";
									break;
								case QuestType.Minor:
									str = "Minor quest: " + q.GetXP() + " XP";
									break;
							}

							contents.Add(str);
						}
					}

					string parcels = "";
					foreach (Parcel p in fHoverPoint.Parcels)
					{
						if (parcels != "")
							parcels += ", ";

						parcels += p.Name;
					}
					if (parcels != "")
						contents.Add("Treasure parcels: " + parcels);

					string s = "";
					foreach (string str in contents)
					{
						if (s != "")
							s += Environment.NewLine + Environment.NewLine;

						s += TextHelper.Wrap(str);
					}

					Tooltip.ToolTipTitle = fHoverPoint.Name;
					Tooltip.ToolTipIcon = ToolTipIcon.Info;
					Tooltip.SetToolTip(this, s);
				}
				else
				{
					Tooltip.ToolTipTitle = "";
					Tooltip.ToolTipIcon = ToolTipIcon.None;
					Tooltip.SetToolTip(this, null);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		int find_layer_index(Guid point_id, List<List<PlotPoint>> layers)
		{
			try
			{
				for (int index = 0; index != layers.Count; ++index)
				{
					List<PlotPoint> layer = layers[index];
					foreach (PlotPoint point in layer)
					{
						if (point.ID == point_id)
							return index;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return -1;
		}

		PlotPoint get_blocking_point(PointF from_pt, PointF to_pt)
		{
			try
			{
				// First, work out what layer we're in / about to enter
				List<PlotPoint> layer = find_layer(from_pt.Y);
				List<PlotPoint> target_layer = find_layer(to_pt.Y);
				if ((layer == null) || (layer == target_layer))
					return null;

				if (layer != null)
				{
					int start_index = fLayers.IndexOf(layer);
					int target_index = fLayers.IndexOf(target_layer);

					int max = Math.Min(target_index, fLayers.Count) - 1;
					for (int index = start_index; index <= max; ++index)
					{
						layer = fLayers[index];

						// Work out the x co-ordinates where we enter / leave this layer
						PlotPoint first = layer[0];
						RectangleF first_rect = fRegions[first.ID];
						float y_top = first_rect.Top;
						float y_bottom = first_rect.Bottom;

						float x_dist = to_pt.X - from_pt.X;
						float y_dist = to_pt.Y - from_pt.Y;

						float p_top = (y_top - from_pt.Y) / y_dist;
						float p_bottom = (y_bottom - from_pt.Y) / y_dist;

						float x_top = from_pt.X + (p_top * x_dist);
						float x_bottom = from_pt.X + (p_bottom * x_dist);

						PointF enter = new PointF(x_top, y_top);
						PointF leave = new PointF(x_bottom, y_bottom);

						foreach (PlotPoint point in layer)
						{
							RectangleF rect = fRegions[point.ID];
							RectangleF larger_rect = RectangleF.Inflate(rect, 2, 2);

							if (larger_rect.Contains(enter) || larger_rect.Contains(leave))
								return point;
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return null;
		}

		List<PlotPoint> find_layer(float y)
		{
			try
			{
				foreach (List<PlotPoint> layer in fLayers)
				{
					PlotPoint first = layer[0];
					RectangleF first_rect = fRegions[first.ID];

					if (y < first_rect.Bottom)
						return layer;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return null;
		}

		#endregion

		internal static Pair<Color, Color> GetColourGradient(PlotPointColour colour, int alpha)
		{
			Color top = Color.White;
			Color bottom = Color.Black;

			switch (colour)
			{
				case PlotPointColour.Yellow:
					top = Color.FromArgb(alpha, 255, 255, 215);
					bottom = Color.FromArgb(alpha, 255, 255, 165);
					break;
				case PlotPointColour.Blue:
					top = Color.FromArgb(alpha, 215, 215, 255);
					bottom = Color.FromArgb(alpha, 165, 165, 255);
					break;
				case PlotPointColour.Green:
					top = Color.FromArgb(alpha, 215, 255, 215);
					bottom = Color.FromArgb(alpha, 165, 255, 165);
					break;
				case PlotPointColour.Purple:
					top = Color.FromArgb(alpha, 240, 205, 255);
					bottom = Color.FromArgb(alpha, 240, 150, 255);
					break;
				case PlotPointColour.Orange:
					top = Color.FromArgb(alpha, 255, 240, 210);
					bottom = Color.FromArgb(alpha, 255, 165, 120);
					break;
				case PlotPointColour.Brown:
					top = Color.FromArgb(alpha, 255, 240, 215);
					bottom = Color.FromArgb(alpha, 170, 140, 110);
					break;
				case PlotPointColour.Grey:
					top = Color.FromArgb(alpha, 225, 225, 225);
					bottom = Color.FromArgb(alpha, 175, 175, 175);
					break;
			}

			return new Pair<Color, Color>(top, bottom);
		}
	}
}
