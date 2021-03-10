using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.Controls
{
	#region Enumerations

	/// <summary>
	/// Different types of information that can be shown in a DemographicsPanel control.
	/// </summary>
	public enum DemographicsSource
	{
		/// <summary>
		/// Show creature breakdown.
		/// </summary>
		Creatures,

		/// <summary>
		/// Show trap breakdown.
		/// </summary>
		Traps,

		/// <summary>
		/// Show magic item breakdown.
		/// </summary>
		MagicItems
	}

	/// <summary>
	/// Different types of breakdown that can be used in a DemographicsPanel control.
	/// </summary>
	public enum DemographicsMode
	{
		/// <summary>
		/// Show breakdown by level.
		/// </summary>
		Level,

		/// <summary>
		/// Show breakdown by role.
		/// </summary>
		Role,

		/// <summary>
		/// Show breakdown by standard / elite / solo / minion.
		/// </summary>
		Status
	}

	#endregion

	/// <summary>
	/// Panel to show various breakdowns of creatures in a library.
	/// </summary>
	public partial class DemographicsPanel : UserControl
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public DemographicsPanel()
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

		#region Properties

		/// <summary>
		/// Gets or sets the library to display.
		/// </summary>
		[Category("Data"), Description("The library to display.")]
		public Library Library
		{
			get { return fLibrary; }
			set
			{
				fLibrary = value;
				fBreakdown = null;

				Invalidate();
			}
		}
		Library fLibrary = null;

		/// <summary>
		/// Gets or sets the category of information to show.
		/// </summary>
		[Category("Appearance"), Description("The category of information to show.")]
		public DemographicsSource Source
		{
			get { return fSource; }
			set
			{
				fSource = value;
				fBreakdown = null;

				Invalidate();
			}
		}
		DemographicsSource fSource = DemographicsSource.Creatures;

		/// <summary>
		/// Gets or sets the type of breakdown to show.
		/// </summary>
		[Category("Appearance"), Description("The type of breakdown to show.")]
		public DemographicsMode Mode
		{
			get { return fMode; }
			set
			{
				fMode = value;
				fBreakdown = null;

				Invalidate();
			}
		}
		DemographicsMode fMode = DemographicsMode.Level;

		#endregion

		internal void ShowTable(ReportTable table)
		{
			fBreakdown = new Dictionary<string, int>();

			foreach (ReportRow row in table.Rows)
			{
				fBreakdown[row.Heading] = row.Total;
			}

			Invalidate();
		}

		StringFormat fCentred = new StringFormat();

		Dictionary<string, int> fBreakdown = null;

		/// <summary>
		/// Called in response to the Paint event.
		/// </summary>
		/// <param name="e">The event data.</param>
		protected override void OnPaint(PaintEventArgs e)
		{
			if (fBreakdown == null)
				analyse_data();

			e.Graphics.FillRectangle(Brushes.White, ClientRectangle);

			int column_count = fBreakdown.Keys.Count;
			if (column_count == 0)
				return;

			int min_value = 0;
			int max_value = 0;
			foreach (string key in fBreakdown.Keys)
			{
				int value = fBreakdown[key];

				max_value = Math.Max(max_value, value);
				min_value = Math.Min(min_value, value);
			}
			int range = max_value - min_value;
			if (range == 0)
				return;

			int border = 20;
			Rectangle rect = new Rectangle(border, border, ClientRectangle.Width - (2 * border), ClientRectangle.Height - (3 * border));
			float bar_width = (float)rect.Width / column_count;

			List<string> labels = new List<string>();
			labels.AddRange(fBreakdown.Keys);

			using (Font count_font = new Font(Font.FontFamily, Font.Size * 0.8f))
			{
				for (int column_index = 0; column_index != labels.Count; ++column_index)
				{
					string label = labels[column_index];

					float x = bar_width * column_index;
					RectangleF label_rect = new RectangleF(rect.Left + x, rect.Bottom, bar_width, border);
					e.Graphics.DrawString(label, count_font, Brushes.Black, label_rect, fCentred);

					int value = fBreakdown[label];
					if (value != 0)
					{
						Color top_colour = (value >= 0) ? Color.LightGray : Color.White;
						Color bottom_colour = (value >= 0) ? Color.White : Color.LightGray;

						int top = Math.Max(value, 0);
						int bottom = Math.Min(value, 0);

						int top_y = rect.Bottom - ((rect.Height - border) * (top - min_value) / range);
						int height = (rect.Height - border) * (top - bottom) / range;
						RectangleF bar = new RectangleF(rect.Left + x, top_y, bar_width, height);

						using (Brush bar_fill = new LinearGradientBrush(bar, top_colour, bottom_colour, LinearGradientMode.Vertical))
						{
							e.Graphics.FillRectangle(bar_fill, bar);
							e.Graphics.DrawRectangle(Pens.Gray, bar.X, bar.Y, bar.Width, bar.Height);
						}

						RectangleF count_rect = new RectangleF(rect.Left + x, rect.Top, bar_width, border);
						e.Graphics.DrawString(value.ToString(), count_font, Brushes.Gray, count_rect, fCentred);
					}
				}
			}

			int zero_y = rect.Bottom - ((rect.Height - border) * (0 - min_value) / range);

			e.Graphics.DrawLine(Pens.Black, rect.Left, zero_y, rect.Right, zero_y);
			e.Graphics.DrawLine(Pens.Black, rect.Left, rect.Bottom, rect.Left, rect.Top);
		}

		void analyse_data()
		{
			try
			{
				List<Library> libraries = new List<Library>();
				if (fLibrary == null)
					libraries.AddRange(Session.Libraries);
				else
					libraries.Add(fLibrary);

				fBreakdown = new Dictionary<string, int>();

				set_labels(libraries);

				foreach (Library lib in libraries)
					add_library(lib);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void set_labels(List<Library> libraries)
		{
			switch (fMode)
			{
				case DemographicsMode.Level:
					{
						int max_level = find_max_level(fSource, libraries);
						for (int n = 1; n <= max_level; ++n)
							fBreakdown[n.ToString()] = 0;
					}
					break;
				case DemographicsMode.Role:
					{
						switch (fSource)
						{
							case DemographicsSource.Creatures:
								{
									fBreakdown["Artillery"] = 0;
									fBreakdown["Brute"] = 0;
									fBreakdown["Controller"] = 0;
									fBreakdown["Lurker"] = 0;
									fBreakdown["Skirmisher"] = 0;
									fBreakdown["Soldier"] = 0;
								}
								break;
							case DemographicsSource.Traps:
								{
									fBreakdown["Blaster"] = 0;
									fBreakdown["Lurker"] = 0;
									fBreakdown["Obstacle"] = 0;
									fBreakdown["Warder"] = 0;
								}
								break;
						}
					}
					break;
				case DemographicsMode.Status:
					{
						fBreakdown["Standard"] = 0;
						fBreakdown["Elite"] = 0;
						fBreakdown["Solo"] = 0;
						fBreakdown["Minion"] = 0;
						fBreakdown["Leader"] = 0;
					}
					break;
			}
		}

		int find_max_level(DemographicsSource source, List<Library> libraries)
		{
			int max_level = 0;

			foreach (Library lib in libraries)
			{
				switch (source)
				{
					case DemographicsSource.Creatures:
						{
							foreach (Creature c in lib.Creatures)
							{
								if (c.Level > max_level)
									max_level = c.Level;
							}
						}
						break;
					case DemographicsSource.Traps:
						{
							foreach (Trap t in lib.Traps)
							{
								if (t.Level > max_level)
									max_level = t.Level;
							}
						}
						break;
					case DemographicsSource.MagicItems:
						{
							foreach (MagicItem mi in lib.MagicItems)
							{
								if (mi.Level > max_level)
									max_level = mi.Level;
							}
						}
						break;
				}
			}

			return max_level;
		}

		void add_library(Library library)
		{
			switch (fSource)
			{
				case DemographicsSource.Creatures:
					{
						foreach (Creature c in library.Creatures)
						{
							switch (fMode)
							{
								case DemographicsMode.Level:
									{
										add(c.Level.ToString());
									}
									break;
								case DemographicsMode.Role:
								case DemographicsMode.Status:
									{
										analyse_role(c.Role);
									}
									break;
							}
						}
					}
					break;
				case DemographicsSource.Traps:
					{
						foreach (Trap t in library.Traps)
						{
							switch (fMode)
							{
								case DemographicsMode.Level:
									{
										add(t.Level.ToString());
									}
									break;
								case DemographicsMode.Role:
								case DemographicsMode.Status:
									{
										analyse_role(t.Role);
									}
									break;
							}
						}
					}
					break;
				case DemographicsSource.MagicItems:
					{
						foreach (MagicItem mi in library.MagicItems)
						{
							switch (fMode)
							{
								case DemographicsMode.Level:
									{
										add(mi.Level.ToString());
									}
									break;
							}
						}
					}
					break;
			}
		}

		void analyse_role(IRole role)
		{
			ComplexRole cr = role as ComplexRole;
			if (cr != null)
			{
				switch (fMode)
				{
					case DemographicsMode.Role:
						{
							add(cr.Type.ToString());
						}
						break;
					case DemographicsMode.Status:
						{
							add(cr.Flag.ToString());

							if (cr.Leader)
								add("Leader");
						}
						break;
				}
			}

			Minion m = role as Minion;
			if (m != null)
			{
				switch (fMode)
				{
					case DemographicsMode.Role:
						{
							if (m.HasRole)
								add(m.Type.ToString());
						}
						break;
					case DemographicsMode.Status:
						{
							add("Minion");
						}
						break;
				}
			}
		}

		void add(string label)
		{
			if (fBreakdown.ContainsKey(label))
				fBreakdown[label] += 1;
		}
	}
}
