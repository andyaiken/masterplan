using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class EncyclopediaImageForm : Form
	{
		public EncyclopediaImageForm(EncyclopediaImage img)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fImage = img.Copy();

			NameBox.Text = fImage.Name;
			PictureBox.Image = fImage.Image;
		}

		~EncyclopediaImageForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			PasteBtn.Enabled = Clipboard.ContainsImage();
			PlayerViewBtn.Enabled = (fImage.Image != null);
		}

		public EncyclopediaImage Image
		{
			get { return fImage; }
		}
		EncyclopediaImage fImage = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fImage.Name = NameBox.Text;
		}

		private void BrowseBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog open_dlg = new OpenFileDialog();
			open_dlg.Filter = Program.ImageFilter;
			if (open_dlg.ShowDialog() != DialogResult.OK)
				return;

			fImage.Image = System.Drawing.Image.FromFile(open_dlg.FileName);
			Program.SetResolution(fImage.Image);
			PictureBox.Image = fImage.Image;
		}

		private void PasteBtn_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				fImage.Image = Clipboard.GetImage();
				Program.SetResolution(fImage.Image);
				PictureBox.Image = fImage.Image;
			}
		}

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowImage(fImage.Image);
		}
	}
}
