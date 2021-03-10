using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Masterplan.Controls
{
	partial class TilePanel : UserControl
	{
		public TilePanel()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);
		}

		public Image TileImage
		{
			get { return fTileImage; }
			set
			{
				fTileImage = value;
				Invalidate();
			}
		}
		Image fTileImage = null;

		public Color TileColour
		{
			get { return fTileColour; }
			set
			{
				fTileColour = value;
				Invalidate();
			}
		}
		Color fTileColour = Color.White;

		public Size TileSize
		{
			get { return fTileSize; }
			set
			{
				fTileSize = value;
				Invalidate();
			}
		}
		Size fTileSize = new Size(2, 2);

		public bool ShowGridlines
		{
			get { return fShowGridlines; }
			set
			{
				fShowGridlines = value;
				Invalidate();
			}
		}
		bool fShowGridlines = true;

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			e.Graphics.FillRectangle(new SolidBrush(BackColor), ClientRectangle);

			double square_x = (double)ClientRectangle.Width / fTileSize.Width;
			double square_y = (double)ClientRectangle.Height / fTileSize.Height;
			float square_size = (float)Math.Min(square_x, square_y);

			float img_width = square_size * fTileSize.Width;
			float img_height = square_size * fTileSize.Height;

			float dx = (ClientRectangle.Width - img_width) / 2;
			float dy = (ClientRectangle.Height - img_height) / 2;

			RectangleF img_rect = new RectangleF(dx, dy, img_width, img_height);

			if (fTileImage != null)
			{
				e.Graphics.DrawImage(fTileImage, img_rect);
			}
			else
			{
				using (Brush b = new SolidBrush(fTileColour))
				{
					e.Graphics.FillRectangle(b, img_rect);
				}

				using (Pen p = new Pen(Color.Black, 2))
				{
					e.Graphics.DrawRectangle(p, img_rect.X, img_rect.Y, img_rect.Width, img_rect.Height);
				}
			}

			if (fShowGridlines)
			{
				using (Pen p = new Pen(Color.DarkGray))
				{
					// Vertical gridlines
					for (int n = 1; n != fTileSize.Width; ++n)
					{
						float x = dx + (n * square_size);
						e.Graphics.DrawLine(p, x, dy, x, dy + img_height);
					}

					// Horizontal gridlines
					for (int n = 1; n != fTileSize.Height; ++n)
					{
						float y = dy + (n * square_size);
						e.Graphics.DrawLine(p, dx, y, dx + img_width, y);
					}
				}
			}
		}
	}
}
