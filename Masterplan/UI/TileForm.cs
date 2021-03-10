using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TileForm : Form
	{
		public TileForm(Tile t)
		{
			InitializeComponent();

			foreach (TileCategory cat in Enum.GetValues(typeof(TileCategory)))
				CatBox.Items.Add(cat);

			Application.Idle += new EventHandler(Application_Idle);

			fTile = t.Copy();

			WidthBox.Value = fTile.Size.Width;
			HeightBox.Value = fTile.Size.Height;
			CatBox.SelectedItem = fTile.Category;
			KeywordBox.Text = fTile.Keywords;

			image_changed();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			PasteBtn.Enabled = Clipboard.ContainsImage();
			ClearBtn.Enabled = (fTile.Image != null);
			SetColourBtn.Enabled = (fTile.Image == null);
			GridBtn.Checked = TilePanel.ShowGridlines;
		}

		public Tile Tile
		{
			get { return fTile; }
		}
		Tile fTile = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			int width = (int)WidthBox.Value;
			int height = (int)HeightBox.Value;

			fTile.Size = new Size(width, height);
			fTile.Category = (TileCategory)CatBox.SelectedItem;
			fTile.Keywords = KeywordBox.Text;
		}

		private void WidthBox_ValueChanged(object sender, EventArgs e)
		{
			image_changed();
		}

		private void HeightBox_ValueChanged(object sender, EventArgs e)
		{
			image_changed();
		}

		private void BrowseBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.ImageFilter;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fTile.Image = Image.FromFile(dlg.FileName);
				Program.SetResolution(fTile.Image);
				image_changed();
			}
		}

		private void PasteBtn_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				fTile.Image = Clipboard.GetImage();
				Program.SetResolution(fTile.Image);
				image_changed();
			}
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			fTile.Image = null;
			image_changed();
		}

		private void SetColourBtn_Click(object sender, EventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			dlg.AllowFullOpen = false;
			dlg.Color = fTile.BlankColour;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fTile.BlankColour = dlg.Color;
				image_changed();
			}
		}

		private void GridBtn_Click(object sender, EventArgs e)
		{
			TilePanel.ShowGridlines = !TilePanel.ShowGridlines;
		}

		void image_changed()
		{
			int width = (int)WidthBox.Value;
			int height = (int)HeightBox.Value;

			TilePanel.TileImage = fTile.Image;
			TilePanel.TileColour = fTile.BlankColour;
			TilePanel.TileSize = new Size(width, height);
		}
	}
}
