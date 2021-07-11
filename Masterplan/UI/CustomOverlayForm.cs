using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CustomOverlayForm : Form
	{
		const string ROUNDED = "Rounded (translucent)";
		const string BLOCK = "Block (opaque)";

		public CustomOverlayForm(CustomToken ct)
		{
			InitializeComponent();

            Application.Idle += new EventHandler(Application_Idle);

            fToken = ct.Copy();

			NameBox.Text = fToken.Name;

            WidthBox.Value = fToken.OverlaySize.Width;
            HeightBox.Value = fToken.OverlaySize.Height;

            update_power();

			DetailsBox.Text = fToken.Details;

			TilePanel.TileSize = fToken.OverlaySize;
			TilePanel.Image = fToken.Image;
			TilePanel.Colour = fToken.Colour;

			StyleBox.Items.Add(ROUNDED);
			StyleBox.Items.Add(BLOCK);
			switch (fToken.OverlayStyle)
			{
				case OverlayStyle.Rounded:
					StyleBox.Text = ROUNDED;
					break;
				case OverlayStyle.Block:
					StyleBox.Text = BLOCK;
					break;
			}

            DifficultBox.Checked = fToken.DifficultTerrain;
            OpaqueBox.Checked = fToken.Opaque;
		}

        void Application_Idle(object sender, EventArgs e)
        {
            RemoveBtn.Enabled = (fToken.TerrainPower != null);
			SelectBtn.Enabled = (Session.TerrainPowers.Count != 0);
        }

		public CustomToken Token
		{
			get { return fToken; }
		}
		CustomToken fToken = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fToken.Name = NameBox.Text;
            fToken.OverlaySize = new Size((int)WidthBox.Value, (int)HeightBox.Value);

			fToken.Details = DetailsBox.Text;
            fToken.DifficultTerrain = DifficultBox.Checked;
            fToken.Opaque = OpaqueBox.Checked;

			fToken.Image = TilePanel.Image;
			fToken.Colour = TilePanel.Colour;

			fToken.OverlayStyle = (StyleBox.Text == ROUNDED) ? OverlayStyle.Rounded : OverlayStyle.Block;
		}

		private void WidthBox_ValueChanged(object sender, EventArgs e)
		{
			update_tile_size();
		}

		private void HeightBox_ValueChanged(object sender, EventArgs e)
		{
			update_tile_size();
		}

		void update_tile_size()
		{
			TilePanel.TileSize = new Size((int)WidthBox.Value, (int)HeightBox.Value);
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			TerrainPower power = fToken.TerrainPower;
			if (power == null)
			{
				power = new TerrainPower();
				power.Name = NameBox.Text;
			}

			TerrainPowerForm dlg = new TerrainPowerForm(power);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fToken.TerrainPower = dlg.Power;
				NameBox.Text = fToken.TerrainPower.Name;

				update_power();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			fToken.TerrainPower = null;
			update_power();
		}

		private void SelectBtn_Click(object sender, EventArgs e)
		{
			TerrainPowerSelectForm dlg = new TerrainPowerSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fToken.TerrainPower = dlg.TerrainPower.Copy();
				update_power();
			}
		}

		void update_power()
		{
			PowerBrowser.DocumentText = HTML.TerrainPower(fToken.TerrainPower, Session.Preferences.TextSize);
		}
	}
}
