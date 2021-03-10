using System;
using System.Drawing;
using System.Windows.Forms;

using Utils;
using Utils.Wizards;

using Masterplan.Data;
using Masterplan.Tools;
using System.Collections.Generic;

namespace Masterplan.Wizards
{
	partial class EncounterTemplatePage : UserControl, IWizardPage
	{
		public EncounterTemplatePage()
		{
			InitializeComponent();
		}

		AdviceData fData = null;

		public EncounterTemplate SelectedTemplate
		{
			get
			{
				if (TemplatesList.SelectedItems.Count != 0)
					return TemplatesList.SelectedItems[0].Tag as EncounterTemplate;

				return null;
			}
		}

		#region IWizardPage Members

		public bool AllowNext
		{
			get { return (SelectedTemplate != null); }
		}

		public bool AllowBack
		{
			get { return false; }
		}

		public bool AllowFinish
		{
			get { return false; }
		}

		public void OnShown(object data)
		{
			if (fData == null)
			{
				fData = data as AdviceData;

				if (fData.TabulaRasa)
				{
					InfoLbl.Text = "The following encounter templates are available. Select one to continue.";
				}
				else
				{
					InfoLbl.Text = "The following encounter templates fit the creatures you have added to the encounter so far. Select one to continue.";
				}

                BinarySearchTree<string> bst = new BinarySearchTree<string>();
                foreach (Pair<EncounterTemplateGroup, EncounterTemplate> template in fData.Templates)
                    bst.Add(template.First.Category);

                List<string> cats = bst.SortedList;
                foreach (string cat in cats)
                    TemplatesList.Groups.Add(cat, cat);

				TemplatesList.Items.Clear();
				foreach (Pair<EncounterTemplateGroup, EncounterTemplate> template in fData.Templates)
				{
					ListViewItem lvi = TemplatesList.Items.Add(template.First.Name + " (" + template.Second.Difficulty.ToString().ToLower() + ")");
					lvi.Tag = template.Second;
                    lvi.Group = TemplatesList.Groups[template.First.Category];
				}

				if (TemplatesList.Items.Count == 0)
				{
                    TemplatesList.ShowGroups = false;

					ListViewItem lvi = TemplatesList.Items.Add("(no templates)");
					lvi.ForeColor = SystemColors.GrayText;
				}
			}
		}

		public bool OnBack()
		{
			return true;
		}

		public bool OnNext()
		{
			if (fData.SelectedTemplate != SelectedTemplate)
			{
				fData.SelectedTemplate = SelectedTemplate;
				fData.FilledSlots.Clear();
			}

			return true;
		}

		public bool OnFinish()
		{
			return true;
		}

		#endregion
	}
}
