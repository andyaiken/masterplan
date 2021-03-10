using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.Controls
{
    partial class EncounterGauge : UserControl
    {
        public EncounterGauge()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint, true);

            Height = CONTROL_HEIGHT;
        }

        public Party Party
        {
            get { return fParty; }
            set
            {
                fParty = value;
                Invalidate();
            }
        }
        Party fParty = null;

        public int XP
        {
            get { return fXP; }
            set
            {
                fXP = value;
                Invalidate();
            }
        }
        int fXP = 0;

        const int CONTROL_HEIGHT = 20;

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            Height = CONTROL_HEIGHT;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = CONTROL_HEIGHT;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (fParty == null)
                return;

            Font f = new Font(Font.FontFamily, 7);

            // Draw XP gauge
            const int delta_y = 4;
            Rectangle rect = new Rectangle(0, delta_y, get_x(fXP), Height - (2 * delta_y));
            if (rect.Width > 0)
            {
                Brush b = new LinearGradientBrush(rect, SystemColors.Control, SystemColors.ControlDark, LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(b, rect);
            }

            int min_lvl = Math.Max(get_min_level(), 1);
            int max_lvl = get_max_level();

            for (int level = min_lvl; level != max_lvl; ++level)
            {
                int xp = Experience.GetCreatureXP(level) * fParty.Size;

                int x = get_x(xp);
                e.Graphics.DrawLine(Pens.Black, new Point(x, 1), new Point(x, Height - 3));
                e.Graphics.DrawString(level.ToString(), f, SystemBrushes.WindowText, new PointF(x, 1));
            }
        }

        int get_min_level()
        {
            int current_level = Experience.GetCreatureLevel(fXP / fParty.Size);
            int min = Math.Min(fParty.Level - 3, current_level);

            return Math.Max(min, 0);
        }

        int get_max_level()
        {
            int current_level = Experience.GetCreatureLevel(fXP / fParty.Size);
            return Math.Max(fParty.Level + 5, current_level + 1);
        }

        int get_x(int xp)
        {
            int trivial = Experience.GetCreatureXP(get_min_level()) * fParty.Size;
            int extreme = Experience.GetCreatureXP(get_max_level()) * fParty.Size;

            int min = Math.Min(fXP, trivial);
            int max = Math.Max(fXP, extreme);
            int range = max - min;

            int delta = xp - min;
            return (delta * Width) / range;
       }
    }
}
