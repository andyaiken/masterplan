using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	delegate void PowerCallback(CreaturePower power);

	partial class PowerBrowserForm : Form
	{
		public PowerBrowserForm(string name, int level, IRole role, PowerCallback callback)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fName = name;
			fLevel = level;
			fRole = role;
			fCallback = callback;

			bool set_filter = FilterPanel.SetFilter(fLevel, fRole);

			if (!set_filter)
			{
				update_creature_list();

				if (SelectedCreatures.Count > 100)
					fShowAll = false;

				update_powers();
			}
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ModeAll.Checked = fShowAll;
			ModeSelection.Checked = !fShowAll;
		}

		string fName = "";
		int fLevel = 0;
		IRole fRole = null;
		bool fShowAll = true;

		PowerCallback fCallback = null;

		List<string> fAddedPowers = new List<string>();

		public List<ICreature> SelectedCreatures
		{
			get
			{
				List<ICreature> creatures = new List<ICreature>();

				if (fShowAll)
				{
					foreach (ListViewItem lvi in CreatureList.Items)
					{
						ICreature creature = lvi.Tag as ICreature;
						if (creature != null)
							creatures.Add(creature);
					}
				}
				else
				{
					foreach (ListViewItem lvi in CreatureList.SelectedItems)
					{
						ICreature creature = lvi.Tag as ICreature;
						if (creature != null)
							creatures.Add(creature);
					}
				}

				return creatures;
			}
		}

		public List<CreaturePower> ShownPowers
		{
			get { return fPowers; }
		}
		List<CreaturePower> fPowers = null;

		public CreaturePower SelectedPower
		{
			get { return fSelectedPower; }
		}
		CreaturePower fSelectedPower = null;

		#region Creature toolbar

		private void ModeAll_Click(object sender, EventArgs e)
		{
			fShowAll = true;

			update_powers();
		}

		private void ModeSelection_Click(object sender, EventArgs e)
		{
			fShowAll = false;

			update_powers();
		}

		private void FilterPanel_FilterChanged(object sender, EventArgs e)
		{
			update_creature_list();
			update_powers();
		}

		#endregion

		private void StatsBtn_Click(object sender, EventArgs e)
		{
			PowerStatisticsForm dlg = new PowerStatisticsForm(fPowers, SelectedCreatures.Count);
			dlg.ShowDialog();
		}

		private void CreatureList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!fShowAll)
				update_powers();
		}

		private void PowerDisplay_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "copy")
			{
				Guid id = new Guid(e.Url.LocalPath);
				CreaturePower power = find_power(id);
				if (power != null)
				{
					e.Cancel = true;

					copy_power(power);
				}
			}
		}

		void update_creature_list()
		{
			CreatureList.BeginUpdate();

			List<ICreature> creatures = new List<ICreature>();
			List<Creature> all_creatures = Session.Creatures;
			foreach (ICreature c in all_creatures)
				creatures.Add(c);
			if (Session.Project != null)
			{
				foreach (ICreature c in Session.Project.CustomCreatures)
					creatures.Add(c);
				foreach (ICreature c in Session.Project.NPCs)
					creatures.Add(c);
			}

			BinarySearchTree<string> categories = new BinarySearchTree<string>();
			foreach (ICreature c in creatures)
			{
				if (c.Category != "")
					categories.Add(c.Category);
			}

			List<string> cats = categories.SortedList;
			cats.Insert(0, "Custom Creatures");
			cats.Insert(1, "NPCs");
			cats.Add("Miscellaneous Creatures");

			CreatureList.Groups.Clear();
			foreach (string cat in cats)
				CreatureList.Groups.Add(cat, cat);
			CreatureList.ShowGroups = true;

			List<ListViewItem> item_list = new List<ListViewItem>();

			foreach (ICreature c in creatures)
			{
				if (c == null)
					continue;

				Difficulty diff;
				if (!FilterPanel.AllowItem(c, out diff))
					continue;

				ListViewItem lvi = new ListViewItem(c.Name);
				lvi.SubItems.Add(c.Info);
				lvi.Tag = c;

				if (c.Category != "")
					lvi.Group = CreatureList.Groups[c.Category];
				else
					lvi.Group = CreatureList.Groups["Miscellaneous Creatures"];

				item_list.Add(lvi);
			}

			CreatureList.Items.Clear();
			CreatureList.Items.AddRange(item_list.ToArray());

			if (CreatureList.Items.Count == 0)
			{
				CreatureList.ShowGroups = false;

				ListViewItem lvi = CreatureList.Items.Add("(no creatures)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			CreatureList.EndUpdate();
		}

		bool match(Creature c, string token)
		{
			if (c.Name.ToLower().Contains(token.ToLower()))
				return true;

			if (c.Category.ToLower().Contains(token.ToLower()))
				return true;

			if (c.Info.ToLower().Contains(token.ToLower()))
				return true;

			if (c.Phenotype.ToLower().Contains(token.ToLower()))
				return true;

			return false;
		}

		bool role_matches(IRole role_a, IRole role_b)
		{
			if ((role_a is ComplexRole) && (role_b is ComplexRole))
			{
				ComplexRole cr_a = role_a as ComplexRole;
				ComplexRole cr_b = role_b as ComplexRole;

				return (cr_a.Type == cr_b.Type);
			}

			if ((role_a is Minion) && (role_b is Minion))
			{
				Minion minion_a = role_a as Minion;
				Minion minion_b = role_b as Minion;

				if ((minion_a.HasRole == false) && (minion_b.HasRole == false))
					return true;

				if ((minion_a.HasRole) && (minion_b.HasRole))
					return (minion_a.Type == minion_b.Type);

				return false;
			}

			return false;
		}

		void update_powers()
		{
			Cursor.Current = Cursors.WaitCursor;

			List<string> content = new List<string>();
			fPowers = new List<CreaturePower>();

			content.AddRange(HTML.GetHead(null, null, DisplaySize.Small));
			content.Add("<BODY>");

			List<ICreature> creatures = SelectedCreatures;
			if ((creatures != null) && (creatures.Count != 0))
			{
				content.Add("<P class=instruction>");
				if (fShowAll)
					content.Add("These creatures have the following powers:");
				else
					content.Add("The selected creatures have the following powers:");
				content.Add("</P>");

				Dictionary<CreaturePowerCategory, List<CreaturePower>> powers = new Dictionary<CreaturePowerCategory, List<CreaturePower>>();

				Array power_categories = Enum.GetValues(typeof(CreaturePowerCategory));
				foreach (CreaturePowerCategory cat in power_categories)
					powers[cat] = new List<CreaturePower>();

				foreach (ICreature c in creatures)
				{
					foreach (CreaturePower cp in c.CreaturePowers)
					{
						powers[cp.Category].Add(cp);
						fPowers.Add(cp);
					}
				}

				content.Add("<P class=table>");
				content.Add("<TABLE>");

				foreach (CreaturePowerCategory cat in power_categories)
				{
					int count = powers[cat].Count;
					if (count == 0)
						continue;

					powers[cat].Sort();

					string name = "";
					switch (cat)
					{
						case CreaturePowerCategory.Trait:
							name = "Traits";
							break;
						case CreaturePowerCategory.Standard:
						case CreaturePowerCategory.Move:
						case CreaturePowerCategory.Minor:
						case CreaturePowerCategory.Free:
							name = cat + " Actions";
							break;
						case CreaturePowerCategory.Triggered:
							name = "Triggered Actions";
							break;
						case CreaturePowerCategory.Other:
							name = "Other Actions";
							break;
					}

					content.Add("<TR class=creature>");
					content.Add("<TD colspan=3>");
					content.Add("<B>" + name + "</B>");
					content.Add("</TD>");
					content.Add("</TR>");

					foreach (CreaturePower power in powers[cat])
					{
						content.AddRange(power.AsHTML(null, CardMode.View, false));

						content.Add("<TR>");
						content.Add("<TD colspan=3 align=center>");

						if ((fName != null) && (fName != ""))
							content.Add("<A href=copy:" + power.ID + ">copy this power into " + fName + "</A>");
						else
							content.Add("<A href=copy:" + power.ID + ">select this power</A>");
						
						content.Add("</TD>");
						content.Add("</TR>");
					}
				}

				content.Add("</TABLE>");
				content.Add("</P>");
			}
			else
			{
				content.Add("<P class=instruction>");
				content.Add("(no creatures selected)");
				content.Add("</P>");
			}

			content.Add("</BODY>");
			content.Add("</HTML>");

			PowerDisplay.DocumentText = HTML.Concatenate(content);

			Cursor.Current = Cursors.Default;
		}

		CreaturePower find_power(Guid id)
		{
			foreach (CreaturePower power in fPowers)
			{
				if (power.ID == id)
					return power;
			}

			return null;
		}

		void copy_power(CreaturePower power)
		{
			CreaturePower cp = power.Copy();
			cp.ID = Guid.NewGuid();

			if (fCallback != null)
			{
				fCallback(cp);
				fAddedPowers.Add(cp.Name);

				update_powers();
			}
			else
			{
				fSelectedPower = power;

				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
 