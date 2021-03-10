using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.Controls
{
	partial class BreakdownPanel : UserControl
	{
		public BreakdownPanel()
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

		public List<Hero> Heroes
		{
			get { return fHeroes; }
			set { fHeroes = value; }
		}
		List<Hero> fHeroes = null;

		List<HeroRoleType> fRows = null;
		List<string> fColumns = null;
		Dictionary<Point, int> fCells = null;
		Dictionary<int, int> fRowTotals = null;
		Dictionary<int, int> fColumnTotals = null;

		StringFormat fCentred = new StringFormat();

		#endregion

		#region Painting

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (fHeroes == null)
			{
				e.Graphics.DrawString("(no heroes)", Font, SystemBrushes.WindowText, ClientRectangle, fCentred);
				return;
			}

			analyse_party();

			#region Row / column headers

			Font header = new Font(Font, FontStyle.Bold);

			for (int row = 0; row != fRows.Count + 1; ++row)
			{
				string str = "Total";
				if (row != fRows.Count)
				{
					HeroRoleType role = fRows[row];
					str = role.ToString();
				}

				// Draw row header cell
				RectangleF rowhdr = get_rect(0, row + 1);
				e.Graphics.DrawString(str, header, SystemBrushes.WindowText, rowhdr, fCentred);
			}

			for (int col = 0; col != fColumns.Count + 1; ++col)
			{
				string str = "Total";
				if (col != fColumns.Count)
				{
					str = fColumns[col];
				}

				// Draw col header cell
				RectangleF colhdr = get_rect(col + 1, 0);
				e.Graphics.DrawString(str, header, SystemBrushes.WindowText, colhdr, fCentred);
			}

			#endregion

			#region Matrix cells

			for (int row = 0; row != fRows.Count; ++row)
			{
				for (int col = 0; col != fColumns.Count; ++col)
				{
					int heroes = fCells[new Point(row, col)];

					RectangleF rect = get_rect(col + 1, row + 1);
					e.Graphics.DrawString(heroes.ToString(), Font, SystemBrushes.WindowText, rect, fCentred);
				}
			}

			#endregion

			#region Totals

			// Row totals
			for (int row = 0; row != fRows.Count; ++row)
			{
				HeroRoleType role = fRows[row];
				int count = fRowTotals[row];

				// Draw row header cell
				RectangleF rowhdr = get_rect(fColumns.Count + 1, row + 1);
				e.Graphics.DrawString(count.ToString(), header, SystemBrushes.WindowText, rowhdr, fCentred);
			}

			// Column totals
			for (int col = 0; col != fColumns.Count; ++col)
			{
				string source = fColumns[col];
				int count = fColumnTotals[col];

				// Draw col header cell
				RectangleF colhdr = get_rect(col + 1, fRows.Count + 1);
				e.Graphics.DrawString(count.ToString(), header, SystemBrushes.WindowText, colhdr, fCentred);
			}

			// Total
			RectangleF total_rect = get_rect(fColumns.Count + 1, fRows.Count + 1);
			e.Graphics.DrawString(fHeroes.Count.ToString(), header, SystemBrushes.WindowText, total_rect, fCentred);

			#endregion

			#region Grid

			float cellwidth = (float)ClientRectangle.Width / (fColumns.Count + 2);
			float cellheight = (float)ClientRectangle.Height / (fRows.Count + 2);

			Pen p = new Pen(SystemColors.ControlDark);

			// Draw horizontal lines
			for (int row = 0; row != fRows.Count + 1; ++row)
			{
				float y = (row + 1) * cellheight;
				e.Graphics.DrawLine(p, new PointF(ClientRectangle.Left, y), new PointF(ClientRectangle.Right, y));
			}

			// Draw vertical lines
			for (int col = 0; col != fColumns.Count + 1; ++col)
			{
				float x = (col + 1) * cellwidth;
				e.Graphics.DrawLine(p, new PointF(x, ClientRectangle.Top), new PointF(x, ClientRectangle.Bottom));
			}

			#endregion
		}

		#endregion

		void analyse_party()
		{
			if (fHeroes == null)
				return;

			// Rows
			fRows = new List<HeroRoleType>();
			foreach (HeroRoleType role in Enum.GetValues(typeof(HeroRoleType)))
				fRows.Add(role);

			// Columns
			fColumns = new List<string>();
			foreach (Hero h in fHeroes)
			{
				if (!fColumns.Contains(h.PowerSource))
					fColumns.Add(h.PowerSource);
			}
			fColumns.Sort();

			fCells = new Dictionary<Point, int>();
			fRowTotals = new Dictionary<int, int>();
			fColumnTotals = new Dictionary<int, int>();

			for (int row = 0; row != fRows.Count; ++row)
			{
				HeroRoleType role = fRows[row];

				if (!fRowTotals.ContainsKey(row))
					fRowTotals[row] = 0;

				for (int col = 0; col != fColumns.Count; ++col)
				{
					string source = fColumns[col];

					// Get list of heroes for this cell
					int heroes = 0;
					foreach (Hero card in fHeroes)
					{
						if ((card.Role == role) && (card.PowerSource == source))
							heroes += 1;
					}

					fCells[new Point(row, col)] = heroes;

					// Add to row total
					fRowTotals[row] += heroes;

					// Add to column total
					if (!fColumnTotals.ContainsKey(col))
						fColumnTotals[col] = 0;
					fColumnTotals[col] += heroes;
				}
			}
		}

		RectangleF get_rect(int x, int y)
		{
			float width = (float)ClientRectangle.Width / (fColumns.Count + 2);
			float height = (float)ClientRectangle.Height / (fRows.Count + 2);

			return new RectangleF(x * width, y * height, width, height);
		}
	}
}
