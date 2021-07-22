using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.Controls
{
	partial class CardDeck : UserControl
	{
		public CardDeck()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);

			fCentred.Alignment = StringAlignment.Center;
			fCentred.LineAlignment = StringAlignment.Center;
			fCentred.Trimming = StringTrimming.EllipsisWord;

			fTitle.Alignment = StringAlignment.Near;
			fTitle.LineAlignment = StringAlignment.Center;
			fTitle.Trimming = StringTrimming.Character;

			fInfo.Alignment = StringAlignment.Far;
			fInfo.LineAlignment = StringAlignment.Center;
			fInfo.Trimming = StringTrimming.Character;
		}

		public void SetCards(List<EncounterCard> cards)
		{
			fCards = new List<Pair<EncounterCard, int>>();

			BinarySearchTree<string> titles = new BinarySearchTree<string>();
			foreach (EncounterCard card in cards)
				titles.Add(card.Title);

			List<string> title_list = titles.SortedList;
			foreach (string title in title_list)
			{
				Pair<EncounterCard, int> pair = new Pair<EncounterCard, int>();

				foreach (EncounterCard card in cards)
				{
					if (card.Title == title)
					{
						pair.First = card;
						pair.Second += 1;
					}
				}

				fCards.Add(pair);
			}

			Invalidate();
		}

		public EncounterCard TopCard
		{
			get
			{
				if ((fCards == null) || (fCards.Count == 0))
					return null;

				return fCards[0].First;
			}
		}

		List<Pair<EncounterCard, int>> fCards = null;

		StringFormat fCentred = new StringFormat();
		StringFormat fTitle = new StringFormat();
		StringFormat fInfo = new StringFormat();

		float fRadius = 10;
		int fVisibleCards = 0;

		List<Pair<RectangleF, EncounterCard>> fRegions = null;

		public event EventHandler DeckOrderChanged;

		protected void OnDeckOrderChanged()
		{
			if (DeckOrderChanged != null)
				DeckOrderChanged(this, new EventArgs());
		}

		#region Painting

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.Transparent, ClientRectangle);

			if ((fCards == null) || (fCards.Count == 0))
			{
				e.Graphics.DrawString("(no cards)", Font, Brushes.Black, ClientRectangle, fCentred);
				return;
			}

			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

			RectangleF deck_rect = new RectangleF(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width - 1, ClientRectangle.Height - 1);

			fRegions = new List<Pair<RectangleF, EncounterCard>>();

			float card_delta_y = Font.Height * 1.8f;
			float card_delta_x = card_delta_y * 0.2f;

			float usable_height = Height - (4 * fRadius);
			int max_cards = (int)(usable_height / card_delta_y);
			fVisibleCards = Math.Min(max_cards, fCards.Count);
			if (fVisibleCards + 1 == fCards.Count)
				fVisibleCards += 1;

			bool more_cards = fCards.Count > fVisibleCards;
			int edges = (more_cards) ? fVisibleCards + 1 : fVisibleCards;

			if (more_cards)
			{
				float dx = card_delta_x * fVisibleCards;

				float x = deck_rect.X + dx;
				float y = deck_rect.Y;
				float width = deck_rect.Width - (card_delta_x * (edges - 1));
				float height = deck_rect.Height - y;

				RectangleF card_rect = new RectangleF(x, y, width, height);

				draw_card(null, 0, false, card_rect, e.Graphics);
			}

			for (int index = fVisibleCards - 1; index >= 0; --index)
			{
				float dx = card_delta_x * index;
				float dy = card_delta_y * (edges - index - 1);

				float x = deck_rect.X + dx;
				float y = deck_rect.Y + dy;
				float width = deck_rect.Width - (card_delta_x * (edges - 1));
				float height = deck_rect.Height - y;

				RectangleF card_rect = new RectangleF(x, y, width, height);

				Pair<EncounterCard, int> card_info = fCards[index];
				bool topmost = (index == 0);
				draw_card(card_info.First, card_info.Second, topmost, card_rect, e.Graphics);

				fRegions.Add(new Pair<RectangleF, EncounterCard>(card_rect, card_info.First));
			}
		}

		void draw_card(EncounterCard card, int count, bool topmost, RectangleF rect, Graphics g)
		{
			int alpha = (card != null) ? 255 : 100;

			GraphicsPath gp = RoundedRectangle.Create(rect, fRadius, RoundedRectangle.RectangleCorners.TopLeft | RoundedRectangle.RectangleCorners.TopRight);
			using (Brush b = new SolidBrush(Color.FromArgb(alpha, 54, 79, 39)))
			{
				g.FillPath(b, gp);
			}
			g.DrawPath(Pens.White, gp);

			float card_delta_y = Font.Height * 1.5f;
			RectangleF text_rect = new RectangleF(rect.X + fRadius, rect.Y, rect.Width - (2 * fRadius), card_delta_y);

			if (card != null)
			{
				string title = card.Title;
				if (count > 1)
					title = "(" + count + "x) " + title;

				Color text_colour = (card != fHoverCard) ? Color.White : Color.PaleGreen;
				using (Brush b = new SolidBrush(text_colour))
				{
					using (Font f = new Font(Font, Font.Style | FontStyle.Bold))
					{
						g.DrawString(title, f, b, text_rect, fTitle);
					}

					g.DrawString(card.Info, Font, b, text_rect, fInfo);
				}

				if (topmost)
				{
					float dx = fRadius * 0.2f;
					RectangleF content = new RectangleF(rect.X + dx, rect.Y + text_rect.Height, rect.Width - (2 * dx), rect.Height - text_rect.Height);
					using (Brush b = new SolidBrush(Color.FromArgb(225, 231, 197)))
					{
						g.FillRectangle(b, content);
					}

					string msg = "Click on a card to move it to the front of the deck.";
					g.DrawString(msg, Font, Brushes.Black, content, fCentred);
				}
			}
			else
			{
				int remaining = fCards.Count - fVisibleCards;
				g.DrawString("(" + remaining + " more cards)", Font, Brushes.White, text_rect, fCentred);
			}
		}

		#endregion

		EncounterCard fHoverCard = null;

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (fRegions == null)
				return;

			EncounterCard card = null;

			foreach (Pair<RectangleF, EncounterCard> pair in fRegions)
			{
				if ((pair.First.Top <= e.Location.Y) && (pair.First.Bottom >= e.Location.Y))
					card = pair.Second;
			}

			fHoverCard = card;
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			fHoverCard = null;
			Invalidate();
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (fHoverCard == null)
				return;

			EncounterCard card = fHoverCard;
			fHoverCard = null;

			while (fCards[0].First != card)
			{
				Pair<EncounterCard, int> top_card = fCards[0];

				fCards.RemoveAt(0);
				fCards.Add(top_card);

				Refresh();
			}

			OnDeckOrderChanged();
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				Pair<EncounterCard, int> top_card = fCards[0];

				fCards.RemoveAt(0);
				fCards.Add(top_card);
			}
			else
			{
				Pair<EncounterCard, int> last_card = fCards[fCards.Count - 1];

				fCards.RemoveAt(fCards.Count - 1);
				fCards.Insert(0, last_card);
			}

			fHoverCard = null;
			Refresh();

			OnDeckOrderChanged();
		}
	}
}
