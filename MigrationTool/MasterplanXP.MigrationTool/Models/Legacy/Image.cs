#nullable disable

using System.Drawing;

namespace MasterplanXP.MigrationTool.Models.Legacy
{
    public class ImageForm
    {
        /// <summary>
        /// Gets or sets the picture to display on a form.
        /// </summary>        
        public Image Img
        {
            get { return fImg; }
            set { fImg = value; }
        }
        Image fImg = null;

    }
}


