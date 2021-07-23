using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;

using Masterplan.Tools;

namespace Masterplan.Controls
{
	partial class TitlePanel : UserControl
	{
		public enum TitlePanelMode
		{
			WelcomeScreen,
			PlayerView
		}

		public TitlePanel()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);

			fFormat.Alignment = StringAlignment.Center;
			fFormat.LineAlignment = StringAlignment.Center;
			fFormat.Trimming = StringTrimming.EllipsisWord;

			FadeTimer.Enabled = true;
		}

		[Category("Appearance")]
		public string Title
		{
			get { return fTitle; }
			set { fTitle = value; }
		}
		string fTitle = "";

		[Category("Layout")]
		public TitlePanelMode Mode
		{
			get { return fMode; }
			set
			{
				fMode = value;
				Invalidate();
			}
		}
		TitlePanelMode fMode = TitlePanelMode.WelcomeScreen;

		[Category("Behavior")]
		public bool Zooming
		{
			get { return fZooming; }
			set { fZooming = value; }
		}
		bool fZooming = false;

		string fVersion = get_version_string();

		Rectangle fTitleRect = Rectangle.Empty;
		Rectangle fVersionRect = Rectangle.Empty;

		StringFormat fFormat = new StringFormat();

		int fAlpha = 0;
		const int MAX_ALPHA = 255;
		const int MAX_COLOR = 60;

		public event EventHandler FadeFinished;

		protected void OnFadeFinished()
		{
			if (FadeFinished != null)
				FadeFinished(this, new EventArgs());
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			reset_view();
		}

		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);
			reset_view();
		}

		void reset_view()
		{
			fTitleRect = Rectangle.Empty;
			fVersionRect = Rectangle.Empty;

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			try
			{
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

				if (fTitleRect == Rectangle.Empty)
				{
					Rectangle rect = ClientRectangle;
					SizeF version_size = e.Graphics.MeasureString(fVersion, Font);
					double version_height = version_size.Height + (Height / 10);

					fTitleRect = new Rectangle(rect.Left, rect.Top, rect.Width - 1, (int)(rect.Height - version_height - 1));
					fVersionRect = new Rectangle(rect.Left, fTitleRect.Bottom, rect.Width - 1, (int)version_height);
				}

				if (fMode == TitlePanelMode.WelcomeScreen)
				{
					ColorMatrix cm = new ColorMatrix();
					cm.Matrix33 = (0.25F * fAlpha) / MAX_ALPHA;

					ImageAttributes ia = new ImageAttributes();
					ia.SetColorMatrix(cm);

					Image scroll_img = Masterplan.Properties.Resources.Scroll;

					int y = ClientRectangle.Y + (int)(ClientRectangle.Height * 0.1);
					int img_height = (int)(ClientRectangle.Height * 0.8);
					int img_width = scroll_img.Width * img_height / scroll_img.Height;
					if (img_width > ClientRectangle.Width)
					{
						img_width = ClientRectangle.Width;
						img_height = scroll_img.Height * img_width / scroll_img.Width;
					}
					int x = ClientRectangle.X + ((ClientRectangle.Width - img_width) / 2);

					Rectangle img_rect = new Rectangle(x, y, img_width, img_height);
					e.Graphics.DrawImage(scroll_img, img_rect, 0, 0, scroll_img.Width, scroll_img.Height, GraphicsUnit.Pixel, ia);
				}

				using (Brush title_brush = new SolidBrush(Color.FromArgb(fAlpha, ForeColor)))
				{
					float text_height = fTitleRect.Height / 2F;
					float text_width = fTitleRect.Width / fTitle.Length;
					float text_size = Math.Min(text_height, text_width);

					if (fZooming)
					{
						float delta = 0.1F * fAlpha / MAX_ALPHA;
						text_size *= (0.9F + delta);
					}

					if (text_height > 0)
					{
						using (Font title_font = new Font(Font.FontFamily, text_size))
						{
							e.Graphics.DrawString(fTitle, title_font, title_brush, fTitleRect, fFormat);
						}
					}

					if (fMode == TitlePanelMode.WelcomeScreen)
						e.Graphics.DrawString(fVersion, Font, title_brush, fVersionRect, fFormat);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void FadeTimer_Tick(object sender, EventArgs e)
		{
			fAlpha = Math.Min(fAlpha + 4, MAX_ALPHA);

			Invalidate();

			if (fAlpha == MAX_ALPHA)
			{
				FadeTimer.Enabled = false;
				OnFadeFinished();

				if (fMode == TitlePanelMode.PlayerView)
				{
					PulseTimer.Enabled = true;
				}
			}
		}

		private void PulseTimer_Tick(object sender, EventArgs e)
		{
			fAlpha = Math.Max(fAlpha - 1, 0);

			if (Session.Random.Next() % 10 == 0)
				BackColor = change_colour(BackColor);

			Invalidate();
		}

		public void Wake()
		{
			if (PulseTimer.Enabled)
			{
				PulseTimer.Enabled = false;
				FadeTimer.Enabled = true;
			}
		}

		static string get_version_string()
		{
			string str = "Adventure Design Studio";

			Assembly ass = Assembly.GetEntryAssembly();
			if (ass != null)
			{
				Version version = ass.GetName().Version;
				if (version != null)
				{
					if (str != "")
						str += Environment.NewLine;

					str += "Version " + version.Major;

					if (version.Build != 0)
					{
						str += "." + version.Minor + "." + version.Build;
					}
					else if (version.Minor != 0)
					{
						str += "." + version.Minor;
					}
				}
			}

			if (Program.IsBeta)
			{
				if (str != "")
					str += Environment.NewLine + Environment.NewLine;

				str += "BETA";
			}

			return str;
		}

		Color change_colour(Color colour)
		{
			int r = colour.R;
			int g = colour.G;
			int b = colour.B;

			switch (Session.Random.Next() % 4)
			{
				case 0:
					r = Math.Min(MAX_COLOR, r + 1);
					break;
				case 1:
					g = Math.Min(MAX_COLOR, g + 1);
					break;
				case 2:
					b = Math.Min(MAX_COLOR, b + 1);
					break;
				case 3:
					r = Math.Max(0, r - 1);
					break;
				case 4:
					g = Math.Max(0, g - 1);
					break;
				case 5:
					b = Math.Max(0, b - 1);
					break;
			}

			return Color.FromArgb(r, g, b);
		}
	}
}
