using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class EncounterNoteForm : Form
	{
        public EncounterNoteForm(EncounterNote bg)
		{
			InitializeComponent();

			fNote = bg.Copy();

			TitleBox.Text = fNote.Title;
			DetailsBox.Text = fNote.Contents;
		}

        public EncounterNote Note
		{
			get { return fNote; }
		}
        EncounterNote fNote = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fNote.Title = TitleBox.Text;
			fNote.Contents = (DetailsBox.Text != DetailsBox.DefaultText) ? DetailsBox.Text : "";
		}
	}
}
