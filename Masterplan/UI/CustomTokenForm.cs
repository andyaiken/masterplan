using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CustomTokenForm : Form
	{
		public CustomTokenForm(CustomToken ct)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

            Array sizes = Enum.GetValues(typeof(CreatureSize));
            foreach (CreatureSize size in sizes)
                SizeBox.Items.Add(size);

            fToken = ct.Copy();

			NameBox.Text = fToken.Name;
			SizeBox.SelectedItem = fToken.TokenSize;

            update_power();

            DetailsBox.Text = fToken.Details;

			int n = Creature.GetSize((CreatureSize)SizeBox.SelectedItem);
			TilePanel.TileSize = new Size(n, n);
			TilePanel.Image = fToken.Image;
			TilePanel.Colour = fToken.Colour;
		}

		~CustomTokenForm()
		{
			Application.Idle -= Application_Idle;
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
			fToken.TokenSize = (CreatureSize)SizeBox.SelectedItem;
			fToken.Details = DetailsBox.Text;

			fToken.Image = TilePanel.Image;
			fToken.Colour = TilePanel.Colour;
		}

		private void SizeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			int n = Creature.GetSize((CreatureSize)SizeBox.SelectedItem);
			TilePanel.TileSize = new Size(n, n);
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
