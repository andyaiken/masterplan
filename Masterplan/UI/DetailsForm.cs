using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DetailsForm : Form
	{
		public DetailsForm(ICreature c, DetailsField field, string hint)
		{
			InitializeComponent();

			fCreature = c;
			fField = field;

			if ((hint != null) && (hint != ""))
			{
				HintLbl.Text = hint;
			}
			else
			{
				HintStatusbar.Visible = false;
			}

			switch (fField)
			{
				case DetailsField.Alignment:
					Text = "Alignment";
					DetailsBox.Text = fCreature.Alignment;
					break;
				case DetailsField.Description:
					Text = "Description";
					DetailsBox.Text = fCreature.Details;
					break;
				case DetailsField.Equipment:
					Text = "Equipment";
					DetailsBox.Text = fCreature.Equipment;
					break;
				case DetailsField.Languages:
					Text = "Languages";
					DetailsBox.Text = fCreature.Languages;
					break;
				case DetailsField.Movement:
					Text = "Movement";
					DetailsBox.Text = fCreature.Movement;
					break;
				case DetailsField.Senses:
					Text = "Senses";
					DetailsBox.Text = fCreature.Senses;
					break;
				case DetailsField.Skills:
					Text = "Skills";
					DetailsBox.Text = fCreature.Skills;
					break;
				case DetailsField.Resist:
					Text = Session.I18N.Resist;
					DetailsBox.Text = fCreature.Resist;
					break;
				case DetailsField.Immune:
					Text = "Immune";
					DetailsBox.Text = fCreature.Immune;
					break;
				case DetailsField.Vulnerable:
					Text = Session.I18N.Vulnerable;
					DetailsBox.Text = fCreature.Vulnerable;
					break;
				case DetailsField.Tactics:
					Text = Session.I18N.Tactics;
					DetailsBox.Text = fCreature.Tactics;
					break;
			}
		}

		public DetailsForm(string str, string title, string hint)
		{
			InitializeComponent();

			Text = title;
			DetailsBox.Text = str;

			if ((hint != null) && (hint != ""))
			{
				HintLbl.Text = hint;
			}
			else
			{
				HintStatusbar.Visible = false;
			}
		}

		ICreature fCreature = null;
		DetailsField fField = DetailsField.None;

		public string Details
		{
			get { return DetailsBox.Text; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			switch (fField)
			{
				case DetailsField.Alignment:
					fCreature.Alignment = DetailsBox.Text;
					break;
				case DetailsField.Description:
					fCreature.Details = DetailsBox.Text;
					break;
				case DetailsField.Equipment:
					fCreature.Equipment = DetailsBox.Text;
					break;
				case DetailsField.Languages:
					fCreature.Languages = DetailsBox.Text;
					break;
				case DetailsField.Movement:
					fCreature.Movement = DetailsBox.Text;
					break;
				case DetailsField.Senses:
					fCreature.Senses = DetailsBox.Text;
					break;
				case DetailsField.Skills:
					fCreature.Skills = DetailsBox.Text;
					break;
				case DetailsField.Resist:
					fCreature.Resist = DetailsBox.Text;
					break;
				case DetailsField.Immune:
					fCreature.Immune = DetailsBox.Text;
					break;
				case DetailsField.Vulnerable:
					fCreature.Vulnerable = DetailsBox.Text;
					break;
				case DetailsField.Tactics:
					fCreature.Tactics = DetailsBox.Text;
					break;
			}
		}
	}
}
