#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class BackgroundForm : Form
    {
        public BackgroundForm(Background bg)
        {
            InitializeComponent();

            fBackground = bg.Copy();

            TitleBox.Text = fBackground.Title;
            string parsedBRText = HTML.ConvertBRToLineBreaks(fBackground.Details);
            DetailsBox.Text = parsedBRText;
        }

        public Background Background
        {
            get { return fBackground; }
        }
        Background fBackground = null;

        private void OKBtn_Click(object sender, EventArgs e)
        {
            fBackground.Title = TitleBox.Text;
            fBackground.Details = (DetailsBox.Text != DetailsBox.DefaultText) ? DetailsBox.Text : "";
            fBackground.Details = HTML.ConvertLineBreaksToHtml(fBackground.Details);
        }
    }
}
