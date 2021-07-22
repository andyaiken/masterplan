using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Tools;
using Masterplan.UI;

namespace Masterplan.Controls
{
	partial class DicePanel : UserControl
	{
		public DicePanel()
		{
			InitializeComponent();

			Application.Idle += Application_Idle;

			fCentred.Alignment = StringAlignment.Center;
			fCentred.LineAlignment = StringAlignment.Center;
		}

		~DicePanel()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RollBtn.Enabled = (fDice.Count != 0);
			ClearBtn.Enabled = (fDice.Count != 0);
			OddsBtn.Enabled = (fDice.Count != 0);
		}

		public void UpdateView()
		{
			update_dice_source();
			update_dice_rolls();
			update_dice_result();
		}

		public DiceExpression Expression
		{
			get { return DiceExpression.Parse(ExpressionBox.Text); }
			set { ExpressionBox.Text = value != null ? value.ToString() : ""; }
		}

		public Pair<int, int> SelectedDie
		{
			get
			{
				if (DiceSourceList.SelectedItems.Count != 0)
					return DiceSourceList.SelectedItems[0].Tag as Pair<int, int>;

				return null;
			}
		}

		public Pair<int, int> SelectedRoll
		{
			get
			{
				if (DiceList.SelectedItems.Count != 0)
					return DiceList.SelectedItems[0].Tag as Pair<int, int>;

				return null;
			}
		}

		const int DIE_SIZE = 32;
		StringFormat fCentred = new StringFormat();
		List<Pair<int, int>> fDice = new List<Pair<int, int>>();
		int fConstant = 0;
		bool fUpdating = false;

		private void RollBtn_Click(object sender, EventArgs e)
		{
			// Roll dice
			foreach (Pair<int, int> die in fDice)
			{
				int roll = Session.Dice(1, die.First);
				die.Second = roll;
			}

			fDice.Sort(new DiceSorter());

			update_dice_rolls();
			update_dice_result();
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			fDice.Clear();
			fConstant = 0;

			update_dice_rolls();
			update_dice_result();
		}

		private void OddsBtn_Click(object sender, EventArgs e)
		{
			List<int> sides = new List<int>();
			foreach (Pair<int, int> die in fDice)
				sides.Add(die.First);

			OddsForm dlg = new OddsForm(sides, fConstant, ExpressionBox.Text);
			dlg.ShowDialog();
		}

		private void DiceSourceList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedDie != null)
			{
				DragDropEffects fx = DoDragDrop(SelectedDie, DragDropEffects.Move);
				if (fx == DragDropEffects.Move)
					add_die(SelectedDie.First);
			}
		}

		private void DiceList_DragOver(object sender, DragEventArgs e)
		{
			Pair<int, int> die = e.Data.GetData(typeof(Pair<int, int>)) as Pair<int, int>;
			if (die != null)
				e.Effect = DragDropEffects.Move;
		}

		private void DiceSourceList_DoubleClick(object sender, EventArgs e)
		{
			// Add selected die
			if (SelectedDie != null)
				add_die(SelectedDie.First);
		}

		private void DiceList_DoubleClick(object sender, EventArgs e)
		{
			// Reroll selected die
			if (SelectedRoll != null)
			{
				SelectedRoll.Second = Session.Dice(1, SelectedRoll.First);
				update_dice_rolls();
				update_dice_result();
			}
		}

		private void ExpressionBox_TextChanged(object sender, EventArgs e)
		{
			if (fUpdating)
				return;

			DiceExpression exp = DiceExpression.Parse(ExpressionBox.Text);
			if (exp != null)
			{
				fUpdating = true;

				ClearBtn_Click(sender, e);

				fConstant = exp.Constant;

				for (int n = 0; n != exp.Throws; ++n)
					add_die(exp.Sides);

				fUpdating = false;
			}
		}

		void update_dice_source()
		{
			DiceSourceList.Items.Clear();

			List<int> sides = new List<int>();
			sides.Add(4);
			sides.Add(6);
			sides.Add(8);
			sides.Add(10);
			sides.Add(12);
			sides.Add(20);

			DiceSourceList.LargeImageList = new ImageList();
			DiceSourceList.LargeImageList.ImageSize = new System.Drawing.Size(DIE_SIZE, DIE_SIZE);

			foreach (int die in sides)
			{
				string str = "d" + die;

				ListViewItem lvi = DiceSourceList.Items.Add("");
				lvi.Tag = new Pair<int, int>(die, -1);

				DiceSourceList.LargeImageList.Images.Add(get_image(die, str));
				lvi.ImageIndex = DiceSourceList.LargeImageList.Images.Count - 1;
			}
		}

		void update_dice_rolls()
		{
			DiceList.Items.Clear();

			DiceList.LargeImageList = new ImageList();
			DiceList.LargeImageList.ImageSize = new System.Drawing.Size(DIE_SIZE, DIE_SIZE);

			List<int> sides = new List<int>();

			foreach (Pair<int, int> die in fDice)
			{
				ListViewItem lvi = DiceList.Items.Add("");
				lvi.Tag = die;

				DiceList.LargeImageList.Images.Add(get_image(die.First, die.Second.ToString()));
				lvi.ImageIndex = DiceList.LargeImageList.Images.Count - 1;

				sides.Add(die.First);
			}

			if (!fUpdating)
			{
				fUpdating = true;
				ExpressionBox.Text = (fDice.Count != 0) ? DiceStatistics.Expression(sides, fConstant) : "";
				fUpdating = false;
			}
		}

		void update_dice_result()
		{
			if (fDice.Count != 0)
			{
				int result = fConstant;

				foreach (Pair<int, int> die in fDice)
					result += die.Second;

				DiceLbl.ForeColor = SystemColors.WindowText;
				DiceLbl.Text = result.ToString();
			}
			else
			{
				DiceLbl.ForeColor = SystemColors.GrayText;
				DiceLbl.Text = "-";
			}
		}

		void add_die(int sides)
		{
			int roll = Session.Dice(1, sides);

			fDice.Add(new Pair<int, int>(sides, roll));
			fDice.Sort(new DiceSorter());

			update_dice_rolls();
			update_dice_result();
		}

		Image get_image(int sides, string caption)
		{
			Bitmap bmp = new Bitmap(DIE_SIZE, DIE_SIZE);

			Graphics g = Graphics.FromImage(bmp);
			RectangleF rect = new RectangleF(0, 0, DIE_SIZE - 1, DIE_SIZE - 1);

			switch (sides)
			{
				case 4:
					{
						float delta = rect.Width / 6;
						PointF left = new PointF(rect.Left, rect.Bottom - delta);
						PointF right = new PointF(rect.Right, rect.Bottom - delta);
						PointF top = new PointF(rect.Left + (rect.Width / 2), rect.Top);

						g.FillPolygon(Brushes.LightGray, new PointF[] { left, right, top });
						g.DrawPolygon(Pens.Gray, new PointF[] { left, right, top });
					}
					break;
				case 6:
					{
						float delta = rect.Width / 8;
						RectangleF die_rect = new RectangleF(rect.X + delta, rect.Y + delta, rect.Width - (2 * delta), rect.Height - (2 * delta));

						g.FillRectangle(Brushes.LightGray, die_rect);
						g.DrawRectangle(Pens.Gray, die_rect.X, die_rect.Y, die_rect.Width, die_rect.Height);
					}
					break;
				case 8:
					{
						float delta = rect.Width / 8;
						PointF left = new PointF(rect.Left + delta, rect.Top + (rect.Height / 2));
						PointF right = new PointF(rect.Right - delta, rect.Top + (rect.Height / 2));
						PointF top = new PointF(rect.Left + (rect.Width / 2), rect.Top);
						PointF bottom = new PointF(rect.Left + (rect.Width / 2), rect.Bottom);

						g.FillPolygon(Brushes.LightGray, new PointF[] { left, bottom, right, top });
						g.DrawPolygon(Pens.Gray, new PointF[] { left, bottom, right, top });
					}
					break;
				case 10:
					{
						float mid_x = rect.Left + (rect.Width / 2);
						float mid_y = rect.Top + (rect.Height / 2);

						List<PointF> points = new List<PointF>();
						for (int n = 0; n != 10; ++n)
						{
							float radius = (rect.Width / 2);
							double theta = n * (2 * Math.PI) / 10;

							double dx = radius * Math.Sin(theta);
							double dy = radius * Math.Cos(theta);

							points.Add(new PointF((float)(mid_x + dx), (float)(mid_y + dy)));
						}

						g.FillPolygon(Brushes.LightGray, points.ToArray());
						g.DrawPolygon(Pens.Gray, points.ToArray());
					}
					break;
				case 12:
					{
						float delta = rect.Width / 3;
						PointF left = new PointF(rect.Left, rect.Top + (rect.Height / 2));
						PointF right = new PointF(rect.Right, rect.Top + (rect.Height / 2));
						PointF topleft = new PointF(rect.Left + delta, rect.Top);
						PointF topright = new PointF(rect.Right - delta, rect.Top);
						PointF bottomleft = new PointF(rect.Left + delta, rect.Bottom);
						PointF bottomright = new PointF(rect.Right - delta, rect.Bottom);

						g.FillPolygon(Brushes.LightGray, new PointF[] { left, topleft, topright, right, bottomright, bottomleft });
						g.DrawPolygon(Pens.Gray, new PointF[] { left, topleft, topright, right, bottomright, bottomleft });
					}
					break;
				case 20:
					{
						float delta = rect.Width / 5;
						PointF lefttop = new PointF(rect.Left, rect.Top + delta);
						PointF leftbottom = new PointF(rect.Left, rect.Bottom - delta);
						PointF righttop = new PointF(rect.Right, rect.Top + delta);
						PointF rightbottom = new PointF(rect.Right, rect.Bottom - delta);
						PointF top = new PointF(rect.Left + (rect.Width / 2), rect.Top);
						PointF bottom = new PointF(rect.Left + (rect.Width / 2), rect.Bottom);

						g.FillPolygon(Brushes.LightGray, new PointF[] { lefttop, leftbottom, bottom, rightbottom, righttop, top });
						g.DrawPolygon(Pens.Gray, new PointF[] { lefttop, leftbottom, bottom, rightbottom, righttop, top });
					}
					break;
			}

			g.DrawString(caption, Font, SystemBrushes.WindowText, rect, fCentred);

			return bmp;
		}

		class DiceSorter : IComparer<Pair<int, int>>
		{
			public int Compare(Pair<int, int> lhs, Pair<int, int> rhs)
			{
				int result = lhs.First.CompareTo(rhs.First);

				if (result == 0)
					result = lhs.Second.CompareTo(rhs.Second);

				return result;
			}
		}
	}
}
