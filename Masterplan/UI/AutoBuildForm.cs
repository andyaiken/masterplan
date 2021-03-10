using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class AutoBuildForm : Form
	{
		const string RANDOM = "Random";

		public enum Mode { Encounter, Delve, Deck }

		public AutoBuildForm(Mode mode)
		{
			InitializeComponent();

			fData = new AutoBuildData();
			fMode = mode;

            init_options();

			switch (fMode)
			{
				case Mode.Encounter:
					{
						TemplateBox.Items.Add(RANDOM);
						List<string> names = EncounterBuilder.FindTemplateNames();
						foreach (string name in names)
							TemplateBox.Items.Add(name);
						TemplateBox.SelectedItem = (fData.Type != "") ? fData.Type : RANDOM;

						DiffBox.Items.Add(Difficulty.Random);
						DiffBox.Items.Add(Difficulty.Easy);
						DiffBox.Items.Add(Difficulty.Moderate);
						DiffBox.Items.Add(Difficulty.Hard);
						DiffBox.SelectedItem = fData.Difficulty;

						LevelBox.Value = fData.Level;
						update_cats();
					}
					break;
				case Mode.Delve:
					{
						TemplateLbl.Enabled = false;
						TemplateBox.Enabled = false;
						TemplateBox.Items.Add("(not applicable)");
						TemplateBox.SelectedIndex = 0;

						DiffLbl.Enabled = false;
						DiffBox.Enabled = false;
						DiffBox.Items.Add("(not applicable)");
						DiffBox.SelectedIndex = 0;

						LevelBox.Value = fData.Level;
						update_cats();
					}
					break;
				case Mode.Deck:
					{
						TemplateLbl.Enabled = false;
						TemplateBox.Enabled = false;
						TemplateBox.Items.Add("(not applicable)");
						TemplateBox.SelectedIndex = 0;

						DiffLbl.Enabled = false;
						DiffBox.Enabled = false;
						DiffBox.Items.Add("(not applicable)");
						DiffBox.SelectedIndex = 0;

						LevelBox.Value = fData.Level;
						update_cats();
					}
					break;
			}
		}

        void init_options()
        {
            BinarySearchTree<string> category_tree = new BinarySearchTree<string>();
            BinarySearchTree<string> keyword_tree = new BinarySearchTree<string>();

            foreach (Creature c in Session.Creatures)
            {
                if ((c.Category != null) && (c.Category != ""))
                    category_tree.Add(c.Category);

                if ((c.Keywords != null) && (c.Keywords != ""))
                {
                    string[] tokens = c.Keywords.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string token in tokens)
                        keyword_tree.Add(token.Trim().ToLower());
                }
            }

            if (category_tree.Count == 0)
            {
                CatLbl.Enabled = false;
                CatBtn.Enabled = false;
            }

            List<string> keywords = keyword_tree.SortedList;
            foreach (string keyword in keywords)
                KeywordBox.Items.Add(keyword);
        }

		public AutoBuildData Data
		{
			get { return fData; }
		}
		AutoBuildData fData = null;

		Mode fMode = Mode.Encounter;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			string[] tokens = KeywordBox.Text.ToLower().Split(null);
			fData.Keywords.Clear();
			foreach (string token in tokens)
			{
				if (token != "")
					fData.Keywords.Add(token);
			}

			switch (fMode)
			{
				case Mode.Encounter:
					{
						fData.Type = (TemplateBox.Text != RANDOM) ? TemplateBox.Text : "";
						fData.Difficulty = (Difficulty)DiffBox.SelectedItem;
						fData.Level = (int)LevelBox.Value;
					}
					break;
				case Mode.Delve:
					{
						fData.Type = "";
						fData.Difficulty = Difficulty.Random;
						fData.Level = (int)LevelBox.Value;
					}
					break;
				case Mode.Deck:
					{
						fData.Type = "";
						fData.Difficulty = Difficulty.Random;
						fData.Level = (int)LevelBox.Value;
					}
					break;
			}
		}

		private void CatBtn_Click(object sender, EventArgs e)
		{
			CategoryListForm dlg = new CategoryListForm(fData.Categories);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fData.Categories = dlg.Categories;
				update_cats();
			}
		}

		void update_cats()
		{
			CatBtn.Text = (fData.Categories == null) ? "All Categories" : fData.Categories.Count + " Categories";
		}
	}
}
