#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class EncounterNoteForm : Form
    {
        public EncounterNoteForm(EncounterNote bg)
        {
            InitializeComponent();

            fNote = bg.Copy();

            TitleBox.Text = fNote.Title;
            DetailsBox.Text = HTML.ConvertBRToLineBreaks(fNote.Contents);
        }

        public EncounterNote Note
        {
            get { return fNote; }
        }
        EncounterNote fNote = null;

        private void OKBtn_Click(object sender, EventArgs e)
        {
            fNote.Title = TitleBox.Text;
            fNote.Contents = HTML.ConvertLineBreaksToHtml((DetailsBox.Text != DetailsBox.DefaultText) ? DetailsBox.Text : "");
        }
    }
}
