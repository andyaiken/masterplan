#nullable disable

using Masterplan.Data;
using Masterplan.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Masterplan.Controls
{
    partial class TokenPanel : UserControl
    {
        public TokenPanel()
        {
            InitializeComponent();

            Application.Idle += new EventHandler(Application_Idle);
        }

        ~TokenPanel()
        {
            Application.Idle -= Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            ImageClear.Enabled = (fImage != null);
        }

        public Size TileSize
        {
            get { return fTileSize; }
            set { fTileSize = value; }
        }
        Size fTileSize = new Size(2, 2);

        public Image Image
        {
            get { return fImage; }
            set
            {
                fImage = value;
                update_picture();
            }
        }
        Image fImage = null;

        public Color Colour
        {
            get { return fColour; }
            set
            {
                fColour = value;
                update_picture();
            }
        }
        Color fColour = Color.Blue;

        private void ImageSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = Program.ImageFilter;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // If the file is not a usable picture the user is told and we keep the old picture.
                Image picture = Tools.PictureFiles.LoadOrWarn(FindForm(), dlg.FileName);
                if (picture == null)
                    return;

                fImage = picture;
                update_picture();
            }
        }

        private void ImageSelectTile_Click(object sender, EventArgs e)
        {
            TileSelectForm dlg = new TileSelectForm(fTileSize, TileCategory.Feature);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fImage = dlg.Tile.Image;

                // A plain tile has no picture (Image is null): the token then has no picture either
                // (it shows its colour). Only a real picture can be rotated; new Bitmap(null) crashed
                // here before 14.1.0.12 when a plain tile with the swapped size (e.g. 2x1 for a 1x2
                // token) was chosen. M142 has handled this since its stage 4e rewrite.
                if (fImage != null &&
                    ((dlg.Tile.Size.Width != fTileSize.Width) || (dlg.Tile.Size.Height != fTileSize.Height)))
                {
                    // Rotate once
                    fImage = new Bitmap(fImage);
                    fImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }

                update_picture();
            }
        }

        private void ImageSelectColour_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = true;
            dlg.Color = ImageBox.BackColor;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fImage = null;
                fColour = dlg.Color;
                update_picture();
            }
        }

        private void ImageClear_Click(object sender, EventArgs e)
        {
            fImage = null;
            update_picture();
        }

        void update_picture()
        {
            if (fImage != null)
            {
                ImageBox.BackColor = Color.Transparent;
                ImageBox.Image = fImage;
            }
            else
            {
                ImageBox.BackColor = fColour;
                ImageBox.Image = null;
            }
        }
    }
}
