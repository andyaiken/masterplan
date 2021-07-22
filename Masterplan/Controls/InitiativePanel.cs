using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using Masterplan.Tools;

namespace Masterplan.Controls
{
	partial class InitiativePanel : UserControl
	{
		public InitiativePanel()
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

		#region Fields

		int fHoveredInit = int.MinValue;

		StringFormat fCentred = new StringFormat();

		const int BORDER = 8;

		Pen fTickPen = new Pen(Color.Gray, 0.5f);

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the list of initiative scores.
		/// </summary>
		public List<int> InitiativeScores
		{
			get { return fInitiatives; }
			set
			{
				fInitiatives = value;
				Invalidate();
			}
		}
		List<int> fInitiatives = new List<int>();

		/// <summary>
		/// Gets or sets the current initiative score.
		/// </summary>
		public int CurrentInitiative
		{
			get { return fCurrent; }
			set
			{
				fCurrent = value;
				Invalidate();
			}
		}
		int fCurrent = 0;

		/// <summary>
		/// Gets the maximum initiative score.
		/// </summary>
		public int Minimum
		{
			get
			{
				Pair<int, int> range = get_range();
				return range.First;
			}
		}

		/// <summary>
		/// Gets the mimimum initiative score.
		/// </summary>
		public int Maximum
		{
			get
			{
				Pair<int, int> range = get_range();
				return range.Second;
			}
		}

		#endregion

		#region Events

		public event EventHandler InitiativeChanged;

		protected void OnInitiativeChanged()
		{
			if (InitiativeChanged != null)
				InitiativeChanged(this, new EventArgs());
		}

		#endregion

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			e.Graphics.FillRectangle(Brushes.White, ClientRectangle);

			float x_line = ClientRectangle.Right - BORDER;

			// Initiative line
			PointF top = new PointF(x_line, BORDER);
			PointF bottom = new PointF(x_line, ClientRectangle.Bottom - BORDER);
			e.Graphics.DrawLine(Pens.Black, top, bottom);

			// Ticks
			Pair<int, int> range = get_range();
			for (int n = range.First; n <= range.Second; ++n)
			{
				if (n % 5 == 0)
				{
					// Draw a tick
					float y = get_y(n);
					PointF left = new PointF(x_line - 5, y);
					PointF right = new PointF(x_line, y);
					e.Graphics.DrawLine(fTickPen, left, right);
				}
			}

			// Combatants
			foreach (int score in fInitiatives)
			{
				// Draw a marker
				float y = get_y(score);
				PointF pt1 = new PointF(x_line, y);
				PointF pt2 = new PointF(x_line - 10, y - 5);
				PointF pt3 = new PointF(x_line - 10, y + 5);
				e.Graphics.FillPolygon(Brushes.White, new PointF[] { pt1, pt2, pt3 });
				e.Graphics.DrawPolygon(Pens.Gray, new PointF[] { pt1, pt2, pt3 });
			}

			// Current init
			if (fCurrent != int.MinValue)
			{
				float y_current = get_y(fCurrent);
				RectangleF current_rect = new RectangleF(BORDER, y_current - BORDER, ClientRectangle.Width - (BORDER * 2), BORDER * 2);
				using (Brush b = new LinearGradientBrush(current_rect, Color.Blue, Color.DarkBlue, LinearGradientMode.Vertical))
				{
					e.Graphics.FillRectangle(b, current_rect);
					e.Graphics.DrawRectangle(Pens.Black, current_rect.X, current_rect.Y, current_rect.Width, current_rect.Height);
					e.Graphics.DrawString(fCurrent.ToString(), Font, Brushes.White, current_rect, fCentred);
				}
			}

			// Hovered init
			if ((fHoveredInit != int.MinValue) && (fHoveredInit != fCurrent))
			{
				float y_hover = get_y(fHoveredInit);
				RectangleF hover_rect = new RectangleF(BORDER, y_hover - BORDER, ClientRectangle.Width - (BORDER * 2), BORDER * 2);
				e.Graphics.FillRectangle(Brushes.White, hover_rect);
				e.Graphics.DrawRectangle(Pens.Gray, hover_rect.X, hover_rect.Y, hover_rect.Width, hover_rect.Height);
				e.Graphics.DrawString(fHoveredInit.ToString(), Font, Brushes.Gray, hover_rect, fCentred);
			}
		}

		#region Mouse

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			Point mouse = PointToClient(Cursor.Position);
			fCurrent = get_score(mouse.Y);

			OnInitiativeChanged();
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			Point mouse = PointToClient(Cursor.Position);
			fHoveredInit = get_score(mouse.Y);
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			fHoveredInit = int.MinValue;
			Invalidate();
		}

		#endregion

		#region Helper methods

		Pair<int, int> get_range()
		{
			int min = int.MaxValue;
			int max = int.MinValue;

			foreach (int score in fInitiatives)
			{
				min = Math.Min(min, score);
				max = Math.Max(max, score);
			}

			if (fCurrent != int.MinValue)
			{
				min = Math.Min(min, fCurrent);
				max = Math.Max(max, fCurrent);
			}

			if (min == int.MaxValue)
				min = 0;

			if (max == int.MinValue)
				max = 20;

			if (min == max)
			{
				min -= 5;
				max += 5;
			}

			return new Pair<int, int>(min, max);
		}

		float get_y(int score)
		{
			RectangleF rect = get_rect(score);
			return rect.Top + (rect.Height / 2);
		}

		RectangleF get_rect(int score)
		{
			Pair<int, int> range = get_range();

			int count = range.Second - range.First + 1;

			int total_height = ClientRectangle.Height - (2 * BORDER);
			float height = total_height / count;

			int n = score - range.First;
			float y = ClientRectangle.Height - BORDER;
			y -= n * height;
			y -= height;

			return new RectangleF(0, y, ClientRectangle.Width, height);
		}

		int get_score(int y)
		{
			Pair<int, int> range = get_range();
			for (int score = range.First; score <= range.Second; ++score)
			{
				RectangleF rect = get_rect(score);
				if ((rect.Top <= y) && (rect.Bottom >= y))
					return score;
			}

			return int.MinValue;
		}

		#endregion
	}
}
