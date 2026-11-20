#nullable disable

using Masterplan.Data;
using System;
using System.Windows.Forms;

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

            // An encyclopedia image without a picture is meaningless (and before 14.1.0.8 it crashed
            // the entry form's picture list), so OK stays disabled until a picture has been chosen.
            OKBtn.Enabled = (fImage.Image != null);
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

            // If the file is not a usable picture the user is told and we keep the old picture.
            System.Drawing.Image picture = Tools.PictureFiles.LoadOrWarn(this, open_dlg.FileName);
            if (picture == null)
                return;

            fImage.Image = picture;
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
