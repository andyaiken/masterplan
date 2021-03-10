using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.Controls
{
	partial class FiveByFivePanel : UserControl
	{
		public FiveByFivePanel()
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

		StringFormat fCentred = new StringFormat();

		Guid fSelectedItem = Guid.Empty;
		Guid fHoveredItem = Guid.Empty;

		public FiveByFiveData Data
		{
			get { return fData; }
			set
			{
				fData = value;
				Invalidate();
			}
		}
		FiveByFiveData fData = null;

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			// TODO
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			// TODO
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			// TODO
		}

		protected override void  OnDoubleClick(EventArgs e)
		{
			// TODO
		}
	}
}
