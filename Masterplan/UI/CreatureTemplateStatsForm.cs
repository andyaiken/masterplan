using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CreatureTemplateStatsForm : Form
	{
		public CreatureTemplateStatsForm(CreatureTemplate t)
		{
			InitializeComponent();

			fTemplate = t.Copy();

			HPBox.Value = fTemplate.HP;
			InitBox.Value = fTemplate.Initiative;
			ACBox.Value = fTemplate.AC;
			FortBox.Value = fTemplate.Fortitude;
			RefBox.Value = fTemplate.Reflex;
			WillBox.Value = fTemplate.Will;
		}

		public CreatureTemplate Template
		{
			get { return fTemplate; }
		}
		CreatureTemplate fTemplate = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fTemplate.HP = (int)HPBox.Value;
			fTemplate.Initiative = (int)InitBox.Value;
			fTemplate.AC = (int)ACBox.Value;
			fTemplate.Fortitude = (int)FortBox.Value;
			fTemplate.Reflex = (int)RefBox.Value;
			fTemplate.Will = (int)WillBox.Value;
		}
	}
}
