using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Masterplan.Controls
{
	partial class HitPointGauge : UserControl
	{
		public HitPointGauge()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);
		}

		public int FullHP
		{
			get { return fFullHP; }
			set
			{
				fFullHP = value;
				Invalidate();
			}
		}
		int fFullHP = 0;

		public int Damage
		{
			get { return fDamage; }
			set
			{
				fDamage = value;
				Invalidate();
			}
		}
		int fDamage = 0;

		public int TempHP
		{
			get { return fTempHP; }
			set
			{
				fTempHP = value;
				Invalidate();
			}
		}
		int fTempHP = 0;

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (fFullHP == 0)
			{
				e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);
				return;
			}

			int current_hp = fFullHP - fDamage;
			int bloodied_hp = fFullHP / 2;

			int midpoint = (int)(Width * 0.8);

			int level_0 = get_level(0);
			int level_bloodied = get_level(bloodied_hp);
			int level_full = get_level(fFullHP);
			int level_current = get_level(current_hp);

			// Normal range bars
			if (fFullHP != 0)
			{
				Rectangle normal_rect = new Rectangle(midpoint, level_full, Width - midpoint, level_0 - level_full);
				Brush normal_brush = new LinearGradientBrush(normal_rect, Color.Black, Color.LightGray, LinearGradientMode.Horizontal);
				e.Graphics.FillRectangle(normal_brush, normal_rect);
			}

			// HP bar
			if (current_hp != 0)
			{
				int min_hp = Math.Min(level_0, level_current);
				int max_hp = Math.Max(level_0, level_current);
				Rectangle current_rect = new Rectangle(0, min_hp, midpoint, max_hp - min_hp);
				Brush hp_brush = null;
				if (current_hp > bloodied_hp)
				{
					hp_brush = new LinearGradientBrush(current_rect, Color.Green, Color.DarkGreen, LinearGradientMode.Vertical);
				}
				else
				{
					hp_brush = new LinearGradientBrush(current_rect, Color.Red, Color.DarkRed, LinearGradientMode.Vertical);
				}
				e.Graphics.FillRectangle(hp_brush, current_rect);
				e.Graphics.DrawRectangle(Pens.DarkGray, current_rect);
			}

			if (fTempHP != 0)
			{
				int top = Math.Max(0, current_hp + fTempHP);
				int level_top = get_level(top);

				int bottom = top - fTempHP;
				int level_bottom = get_level(bottom);

				// Temp HP bar
				Rectangle temp_rect = new Rectangle(0, level_top, midpoint, level_bottom - level_top);
				Brush temp_brush = new LinearGradientBrush(temp_rect, Color.Blue, Color.Navy, LinearGradientMode.Vertical);
				e.Graphics.FillRectangle(temp_brush, temp_rect);
				e.Graphics.DrawRectangle(Pens.DarkGray, temp_rect);
			}

			if (fFullHP != 0)
			{
				// Markers
				e.Graphics.DrawLine(Pens.DarkGray, 0, level_0, midpoint, level_0);
				e.Graphics.DrawLine(Pens.DarkGray, 0, level_bloodied, midpoint, level_bloodied);
				e.Graphics.DrawLine(Pens.DarkGray, 0, level_full, midpoint, level_full);
			}
		}

		int get_level(int value)
		{
			int min = Math.Min(0, fFullHP - fDamage);
			int max = Math.Max(fFullHP + fTempHP - fDamage, fFullHP);

			int hp_range = max - min;
			if (hp_range == 0)
				return 0;

			int delta = max - value;

			return (delta * Height) / hp_range;
		}
	}
}
