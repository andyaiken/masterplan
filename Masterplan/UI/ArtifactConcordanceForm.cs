using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class ArtifactConcordanceForm : Form
	{
		public ArtifactConcordanceForm(Pair<string, string> concordance)
		{
			InitializeComponent();

			fConcordance = concordance;

			RuleBox.Text = fConcordance.First;
			ValueBox.Text = fConcordance.Second;
		}

		public Pair<string, string> Concordance
		{
			get { return fConcordance; }
		}
		Pair<string, string> fConcordance = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fConcordance.First = RuleBox.Text;
			fConcordance.Second = ValueBox.Text;
		}
	}
}
