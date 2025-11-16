#nullable disable

using Masterplan.Data;
using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class MagicItemSectionForm : Form
    {
        public MagicItemSectionForm(MagicItemSection section)
        {
            InitializeComponent();

            HeaderBox.Items.Add("Price");
            HeaderBox.Items.Add("Enhancement");
            HeaderBox.Items.Add("Property");
            HeaderBox.Items.Add("Power");
            HeaderBox.Items.Add("Critical");

            fSection = section.Copy();

            HeaderBox.Text = fSection.Header;
            DetailsBox.Text = fSection.Details;
        }

        public MagicItemSection Section
        {
            get { return fSection; }
        }
        MagicItemSection fSection = null;

        private void OKBtn_Click(object sender, EventArgs e)
        {
            fSection.Header = HeaderBox.Text;
            fSection.Details = DetailsBox.Text;
        }
    }
}
