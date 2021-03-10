using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Events;

namespace Masterplan.Controls
{
	partial class DeckGrid : UserControl
	{
		public DeckGrid()
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

		public EncounterDeck Deck
		{
			get { return fDeck; }
			set
			{
				fDeck = value;
				fSelectedCell = Point.Empty;

				Invalidate();
			}
		}
		EncounterDeck fDeck = null;

		List<CardCategory> fRows = null;
		List<Difficulty> fColumns = null;
		Dictionary<int, int> fRowTotals = null;
		Dictionary<int, int> fColumnTotals = null;

		Dictionary<Point, int> fCells = null;

		StringFormat fCentred = new StringFormat();

		#endregion

		#region Methods

		public bool InSelectedCell(EncounterCard card)
		{
			if (fSelectedCell == Point.Empty)
				return false;

			int diff_index = fSelectedCell.X - 1;
			Difficulty diff = fColumns[diff_index];

			int cat_index = fSelectedCell.Y - 1;
			CardCategory cat = fRows[cat_index];

			return ((card.Category == cat) && (card.GetDifficulty(fDeck.Level) == diff));
		}

		#endregion

		#region Events

		public event EventHandler SelectedCellChanged;

		protected void OnSelectedCellChanged()
		{
			if (SelectedCellChanged != null)
				SelectedCellChanged(this, new EventArgs());
		}

		public event EventHandler CellActivated;

		protected void OnCellActivated()
		{
			if (CellActivated != null)
				CellActivated(this, new EventArgs());
		}

		#endregion

		#region Painting

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.White, ClientRectangle);

			if (fDeck == null)
			{
				e.Graphics.DrawString("(no deck)", Font, SystemBrushes.WindowText, ClientRectangle, fCentred);
				return;
			}

			analyse_deck();

			#region Grid

			float cellwidth = (float)ClientRectangle.Width / (fColumns.Count + 2);
			float cellheight = (float)ClientRectangle.Height / (fRows.Count + 2);

			using (Pen p = new Pen(SystemColors.ControlDark))
			{
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
			}

			e.Graphics.FillRectangle(Brushes.Black, get_rect(0, 0));

			for (int index = 1; index != fColumns.Count + 2; ++index)
			{
				RectangleF cellrect = get_rect(index, 0);
				e.Graphics.FillRectangle(Brushes.Black, cellrect);
			}
			for (int index = 1; index != fRows.Count + 2; ++index)
			{
				RectangleF cellrect = get_rect(0, index);
				e.Graphics.FillRectangle(Brushes.Black, cellrect);
			}
			using (Brush b = new SolidBrush(Color.FromArgb(30, Color.Gray)))
			{
				for (int index = 1; index != fColumns.Count + 1; ++index)
				{
					RectangleF cellrect = get_rect(index, fRows.Count + 1);
					e.Graphics.FillRectangle(b, cellrect);
				}
				for (int index = 1; index != fRows.Count + 1; ++index)
				{
					RectangleF cellrect = get_rect(fColumns.Count + 1, index);
					e.Graphics.FillRectangle(b, cellrect);
				}
			}

			// Draw highlighted cell
			if (fHoverCell != Point.Empty)
			{
				if ((fHoverCell.X <= fColumns.Count) && (fHoverCell.Y <= fRows.Count))
				{
					RectangleF cellrect = get_rect(fHoverCell.X, fHoverCell.Y);
					e.Graphics.DrawRectangle(SystemPens.Highlight, cellrect.X, cellrect.Y, cellrect.Width, cellrect.Height);

					using (Brush b = new SolidBrush(Color.FromArgb(30, SystemColors.Highlight)))
					{
						e.Graphics.FillRectangle(b, cellrect);
					}
				}
			}

			// Draw selected cell
			if (fSelectedCell != Point.Empty)
			{
				RectangleF cellrect = get_rect(fSelectedCell.X, fSelectedCell.Y);
				using (Brush b = new SolidBrush(Color.FromArgb(100, SystemColors.Highlight)))
				{
					e.Graphics.FillRectangle(b, cellrect);
				}
			}

			#endregion

			#region Row / column headers

			Font header = new Font(Font, FontStyle.Bold);

			for (int row = 0; row != fRows.Count + 1; ++row)
			{
				string str = "Total";
				if (row != fRows.Count)
				{
					CardCategory cat = fRows[row];
					str = cat.ToString();

					if (cat == CardCategory.SoldierBrute)
						str = "Sldr / Brute";
				}

				// Draw row header cell
				RectangleF rowhdr = get_rect(0, row + 1);
				e.Graphics.DrawString(str, header, Brushes.White, rowhdr, fCentred);
			}

			for (int col = 0; col != fColumns.Count + 1; ++col)
			{
				string str = "Total";
				if (col != fColumns.Count)
				{
					switch (fColumns[col])
					{
						case Difficulty.Trivial:
							str = "Lower";
							break;
						case Difficulty.Easy:
							int min = Math.Max(1, fDeck.Level - 1);
							str = "Lvl " + min + " to " + (fDeck.Level + 1);
							break;
						case Difficulty.Moderate:
							str = "Lvl " + (fDeck.Level + 2) + " to " + (fDeck.Level + 3);
							break;
						case Difficulty.Hard:
							str = "Lvl " + (fDeck.Level + 4) + " to " + (fDeck.Level + 5);
							break;
						case Difficulty.Extreme:
							str = "Higher";
							break;
					}
				}

				// Draw col header cell
				RectangleF colhdr = get_rect(col + 1, 0);
				e.Graphics.DrawString(str, header, Brushes.White, colhdr, fCentred);
			}

			#endregion

			#region Matrix cells

			for (int row = 0; row != fRows.Count; ++row)
			{
				for (int col = 0; col != fColumns.Count; ++col)
				{
					Point pt = new Point(row, col);

					int count = fCells[pt];
					if (count == 0)
						continue;

					RectangleF rect = get_rect(col + 1, row + 1);
					e.Graphics.DrawString(count.ToString(), Font, SystemBrushes.WindowText, rect, fCentred);
				}
			}

			#endregion

			#region Totals

			// Row totals
			for (int row = 0; row != fRows.Count; ++row)
			{
				CardCategory cat = fRows[row];
				int count = fRowTotals[row];

				int suggested = 0;
				switch (cat)
				{
					case CardCategory.Artillery:
						suggested = 5;
						break;
					case CardCategory.Controller:
						suggested = 5;
						break;
					case CardCategory.Lurker:
						suggested = 2;
						break;
					case CardCategory.Skirmisher:
						suggested = 14;
						break;
					case CardCategory.SoldierBrute:
						suggested = 18;
						break;
					case CardCategory.Minion:
						suggested = 5;
						break;
					case CardCategory.Solo:
						suggested = 1;
						break;
				}

				// Draw row header cell
				RectangleF rowhdr = get_rect(fColumns.Count + 1, row + 1);
				e.Graphics.DrawString(count + " (" + suggested + ")", header, SystemBrushes.WindowText, rowhdr, fCentred);
			}

			// Column totals
			for (int col = 0; col != fColumns.Count; ++col)
			{
				Difficulty diff = fColumns[col];
				int count = fColumnTotals[col];

				// Draw col header cell
				RectangleF colhdr = get_rect(col + 1, fRows.Count + 1);
				e.Graphics.DrawString(count.ToString(), header, SystemBrushes.WindowText, colhdr, fCentred);
			}

			// Total
			RectangleF total_rect = get_rect(fColumns.Count + 1, fRows.Count + 1);
			e.Graphics.DrawString(fDeck.Cards.Count + " cards", header, SystemBrushes.WindowText, total_rect, fCentred);

			#endregion
		}

		#endregion

		#region Hover

		Point fHoverCell = Point.Empty;

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if ((fColumns == null) || (fRows == null))
				return;

			float width = (float)ClientRectangle.Width / (fColumns.Count + 2);
			float height = (float)ClientRectangle.Height / (fRows.Count + 2);

			Point pt = PointToClient(Cursor.Position);
			int x = (int)(pt.X / width);
			int y = (int)(pt.Y / height);

			if ((x == 0) || (y == 0))
			{
				fHoverCell = Point.Empty;
				Invalidate();
			}
			else if ((x != fHoverCell.X) || (y != fHoverCell.Y))
			{
				fHoverCell = new Point(x, y);
				Invalidate();
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			fHoverCell = Point.Empty;
			Invalidate();
		}

		#endregion

		#region Selection

		public bool IsCellSelected
		{
			get { return fSelectedCell != Point.Empty; }
		}
		Point fSelectedCell = Point.Empty;

		protected override void OnClick(EventArgs e)
		{
			fSelectedCell = fHoverCell;

			if ((fSelectedCell.X > fColumns.Count) || (fSelectedCell.Y > fRows.Count))
				fSelectedCell = Point.Empty;

			Invalidate();

			OnSelectedCellChanged();
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			OnCellActivated();
		}

		#endregion

		#region Helper methods

		void analyse_deck()
		{
			if (fDeck == null)
				return;

			// Rows
			fRows = new List<CardCategory>();
			Array cats = Enum.GetValues(typeof(CardCategory));
			foreach (CardCategory cat in cats)
				fRows.Add(cat);

			// Columns
			fColumns = new List<Difficulty>();
			Array diffs = Enum.GetValues(typeof(Difficulty));
			foreach (Difficulty diff in diffs)
			{
				if ((diff == Difficulty.Trivial) && (fDeck.Level < 3))
					continue;

				if (diff == Difficulty.Random)
					continue;

				fColumns.Add(diff);
			}

			fCells = new Dictionary<Point, int>();

			fRowTotals = new Dictionary<int, int>();
			fColumnTotals = new Dictionary<int, int>();

			for (int row = 0; row != fRows.Count; ++row)
			{
				CardCategory cat = fRows[row];

				for (int col = 0; col != fColumns.Count; ++col)
				{
					Difficulty diff = fColumns[col];

					// Get list of cards for this cell
					int count = 0;
					foreach (EncounterCard card in fDeck.Cards)
					{
						if ((card.Category == cat) && (card.GetDifficulty(fDeck.Level) == diff))
							count += 1;
					}
					fCells[new Point(row, col)] = count;

					// Add to row total
					if (!fRowTotals.ContainsKey(row))
						fRowTotals[row] = 0;
					fRowTotals[row] += count;

					// Add to column total
					if (!fColumnTotals.ContainsKey(col))
						fColumnTotals[col] = 0;
					fColumnTotals[col] += count;
				}
			}
		}

		RectangleF get_rect(int x, int y)
		{
			float width = (float)ClientRectangle.Width / (fColumns.Count + 2);
			float height = (float)ClientRectangle.Height / (fRows.Count + 2);

			return new RectangleF(x * width, y * height, width, height);
		}

		#endregion
	}
}
