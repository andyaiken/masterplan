using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;
using Utils.Wizards;

using Masterplan.Data;
using Masterplan.UI;

namespace Masterplan.Wizards
{
	partial class VariantBasePage : UserControl, IWizardPage
	{
		public VariantBasePage()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);
		}

		~VariantBasePage()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			SearchClearBtn.Enabled = (SearchBox.Text != "");
		}

		VariantData fData = null;

		#region IWizardPage Members

		public bool AllowNext
		{
			get { return (SelectedCreature != null); }
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
				fData = data as VariantData;
				update_list();
			}
		}

		public bool OnBack()
		{
			return false;
		}

		public bool OnNext()
		{
			// Set base creature
			fData.BaseCreature = SelectedCreature;

			if (fData.BaseCreature.Role is Minion)
				fData.Templates.Clear();

			return true;
		}

		public bool OnFinish()
		{
			return false;
		}

		#endregion

		public Creature SelectedCreature
		{
			get
			{
				if (CreatureList.SelectedItems.Count != 0)
					return CreatureList.SelectedItems[0].Tag as Creature;

				return null;
			}
		}

		private void SearchBox_TextChanged(object sender, EventArgs e)
		{
			update_list();
		}

		private void SearchClearBtn_Click(object sender, EventArgs e)
		{
			SearchBox.Text = "";
			//update_list();
		}

		void update_list()
		{
			List<Creature> creatures = Session.Creatures;

			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			foreach (Creature c in creatures)
			{
				if ((c.Category != null) && (c.Category != ""))
					bst.Add(c.Category);
			}

			List<string> cats = bst.SortedList;
			cats.Add("Miscellaneous Creatures");

			CreatureList.BeginUpdate();

			CreatureList.Groups.Clear();
			foreach (string cat in cats)
				CreatureList.Groups.Add(cat, cat);

			List<ListViewItem> items = new List<ListViewItem>();
			foreach (Creature c in creatures)
			{
				if (match(c, SearchBox.Text))
				{
					ListViewItem lvi = new ListViewItem(c.Name);
					lvi.SubItems.Add("Level " + c.Level + " " + c.Role);
					if ((c.Category != null) && (c.Category != ""))
						lvi.Group = CreatureList.Groups[c.Category];
					else
						lvi.Group = CreatureList.Groups["Miscellaneous Creatures"];
					lvi.Tag = c;

					items.Add(lvi);
				}
			}

			CreatureList.Items.Clear();
			CreatureList.Items.AddRange(items.ToArray());

			CreatureList.EndUpdate();
		}

		bool match(Creature c, string query)
		{
			string[] tokens = query.Split(null);

			foreach (string token in tokens)
			{
				if (!match_token(c, token))
					return false;
			}

			return true;
		}

		bool match_token(Creature c, string token)
		{
			if (c.Name.ToLower().Contains(token.ToLower()))
				return true;

			if (c.Category != null)
			{
				if (c.Category.ToLower().Contains(token.ToLower()))
					return true;
			}

			if (c.Info.ToLower().Contains(token.ToLower()))
				return true;

			if (c.Phenotype.ToLower().Contains(token.ToLower()))
				return true;

			return false;
		}

		private void CreatureList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedCreature != null)
			{
				EncounterCard card = new EncounterCard(SelectedCreature.ID);
				CreatureDetailsForm dlg = new CreatureDetailsForm(card);
				dlg.ShowDialog();
			}
		}
	}
}
