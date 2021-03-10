using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.Controls
{
	partial class KeyAbilitiesPanel : UserControl
	{
		public KeyAbilitiesPanel()
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
		Dictionary<string, int> fBreakdown = null;

		public void Analyse(SkillChallenge sc)
		{
			fBreakdown = new Dictionary<string, int>();

			fBreakdown["Strength"] = 0;
			fBreakdown["Constitution"] = 0;
			fBreakdown["Dexterity"] = 0;
			fBreakdown["Intelligence"] = 0;
			fBreakdown["Wisdom"] = 0;
			fBreakdown["Charisma"] = 0;

			foreach (SkillChallengeData scd in sc.Skills)
			{
				if (scd.Type == SkillType.AutoFail)
					continue;

				string ability = "";

				if (Skills.GetAbilityNames().Contains(scd.SkillName))
					ability = scd.SkillName;
				else
					ability = Skills.GetKeyAbility(scd.SkillName);

				if (!fBreakdown.ContainsKey(ability))
					continue;

				fBreakdown[ability] += 1;
			}

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.White, ClientRectangle);

			if (fBreakdown == null)
				return;

			int max_count = 0;
			foreach (string ability in fBreakdown.Keys)
			{
				int count = fBreakdown[ability];
				max_count = Math.Max(count, max_count);
			}

			int border = 20;
			Rectangle rect = new Rectangle(border, border, ClientRectangle.Width - (2 * border), ClientRectangle.Height - (3 * border));
			float bar_width = (float)rect.Width / 6;

			for (int column_index = 0; column_index != 6; ++column_index)
			{
				string label = get_label(column_index);
				if (label == "")
					continue;

				float x = bar_width * column_index;
				RectangleF label_rect = new RectangleF(rect.Left + x, rect.Bottom, bar_width, border);
				e.Graphics.DrawString(label, Font, Brushes.Black, label_rect, fCentred);

				int count = get_count(column_index);
				if (count == 0)
					continue;

				int height = ((rect.Height - border) * count) / max_count;

				RectangleF bar = new RectangleF(rect.Left + x, rect.Bottom - height, bar_width, height);
				using (Brush bar_fill = new LinearGradientBrush(ClientRectangle, Color.LightGray, Color.White, LinearGradientMode.Vertical))
				{
					e.Graphics.FillRectangle(bar_fill, bar);
				}
				e.Graphics.DrawRectangle(Pens.Gray, bar.X, bar.Y, bar.Width, bar.Height);

				RectangleF count_rect = new RectangleF(rect.Left + x, rect.Top, bar_width, border);
				e.Graphics.DrawString(count.ToString(), Font, Brushes.Gray, count_rect, fCentred);
			}

			e.Graphics.DrawLine(Pens.Black, rect.Left, rect.Bottom, rect.Left, rect.Top);
			e.Graphics.DrawLine(Pens.Black, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
		}

		string get_label(int column_index)
		{
			switch (column_index)
			{
				case 0:
					return "Strength";
				case 1:
					return "Constitution";
				case 2:
					return "Dexterity";
				case 3:
					return "Intelligence";
				case 4:
					return "Wisdom";
				case 5:
					return "Charisma";
			}

			return "";
		}

		int get_count(int column_index)
		{
			string column = get_label(column_index);
			return fBreakdown[column];
		}
	}
}
