using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Tools;

namespace Masterplan.Controls
{
    partial class DiceGraphPanel : UserControl
    {
        public DiceGraphPanel()
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

        public List<int> Dice
        {
            get { return fDice; }
            set
            {
                fDice = value;

				fDistribution = null;
                Invalidate();
            }
        }
        List<int> fDice = new List<int>();

		public int Constant
		{
			get { return fConstant; }
			set
			{
				fConstant = value;

				fDistribution = null;
				Invalidate();
			}
		}
		int fConstant = 0;

		public string Title
		{
			get { return fTitle; }
			set
			{
				fTitle = value;

				Invalidate();
			}
		}
        string fTitle = "";

        float fRange = 0.5F;

        Dictionary<int, int> fDistribution = null;

        StringFormat fCentred = new StringFormat();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

			try
			{
				if (fDistribution == null)
					fDistribution = DiceStatistics.Odds(fDice, fConstant);

				if ((fDistribution == null) || (fDistribution.Keys.Count == 0))
					return;

				int delta_x = Width / 10;
				int delta_y = Height / 10;
				Rectangle rect = new Rectangle(delta_x, (3 * delta_y), Width - (2 * delta_x), Height - (5 * delta_y));

				if ((fTitle != null) && (fTitle != ""))
				{
					// Draw graph title
					Rectangle title_rect = new Rectangle(rect.X, rect.Y - (2 * delta_y), rect.Width, delta_y);
					e.Graphics.FillRectangle(Brushes.White, title_rect);
					e.Graphics.DrawRectangle(Pens.DarkGray, title_rect);
					e.Graphics.DrawString(fTitle, new Font(Font.FontFamily, delta_y / 3), Brushes.Black, title_rect, fCentred);
				}

				int min_x = int.MaxValue;
				int max_x = int.MinValue;
				int max_y = int.MinValue;
				int sum = 0;
				foreach (int roll in fDistribution.Keys)
				{
					min_x = Math.Min(min_x, roll);
					max_x = Math.Max(max_x, roll);

					max_y = Math.Max(max_y, fDistribution[roll]);
					sum += fDistribution[roll];
				}

				float lower_delta = (1 - fRange) / 2;
				float upper_delta = 1 - lower_delta;

				Point mouse = PointToClient(Cursor.Position);

				int range = max_x - min_x + 1;
				float width = (float)rect.Width / range;

				float size = Math.Min(Font.Size, width / 2);
				Font label_font = new Font(Font.FontFamily, size);

				List<PointF> levels = new List<PointF>();
				int integral = 0;
				foreach (int roll in fDistribution.Keys)
				{
					int index = roll - min_x;
					float x = width * index;
					float height = rect.Height * (max_y - fDistribution[roll]) / max_y;

					RectangleF roll_rect = new RectangleF(x + rect.X, rect.Y + height, width, rect.Height - height);

					integral += fDistribution[roll];
					float fraction = (float)integral / sum;

					bool highlighted = roll_rect.Contains(mouse);
					bool inter_quartile = ((fraction >= lower_delta) && (fraction <= upper_delta));
					inter_quartile = false;

					float midpoint = x + rect.X + (width / 2);
					float y = rect.Y + height;
					levels.Add(new PointF(midpoint, y));

					Pen pen = Pens.Gray;
					if (inter_quartile || highlighted)
						pen = Pens.Black;

					e.Graphics.DrawLine(pen, midpoint, rect.Bottom, midpoint, y);

					RectangleF label_rect = new RectangleF(roll_rect.Left, roll_rect.Bottom, width, delta_y);
					e.Graphics.DrawString(roll.ToString(), label_font, highlighted ? Brushes.Black : Brushes.DarkGray, label_rect, fCentred);
				}

				// Draw x-axis
				e.Graphics.DrawLine(Pens.Black, rect.Left, rect.Bottom, rect.Right, rect.Bottom);

				// Draw curve
				for (int n = 1; n < levels.Count; ++n)
					e.Graphics.DrawLine(new Pen(Color.Red, 2F), levels[n - 1], levels[n]);
			}
			catch
			{
			}
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }
    }
}
