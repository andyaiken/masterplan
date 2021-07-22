using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class HandoutForm : Form
	{
		public HandoutForm()
		{
			InitializeComponent();
			Browser.DocumentText = "";

			fTypes.Add(typeof(Background));
			fTypes.Add(typeof(EncyclopediaEntry));
			fTypes.Add(typeof(Race));
			fTypes.Add(typeof(Class));
			fTypes.Add(typeof(Theme));
			fTypes.Add(typeof(ParagonPath));
			fTypes.Add(typeof(EpicDestiny));
			fTypes.Add(typeof(PlayerBackground));
			fTypes.Add(typeof(Feat));
			fTypes.Add(typeof(Weapon));
			fTypes.Add(typeof(Artifact));
			fTypes.Add(typeof(Ritual));
			fTypes.Add(typeof(CreatureLore));
			fTypes.Add(typeof(Disease));
			fTypes.Add(typeof(Poison));

			update_source_list();
			update_item_list();
			update_handout();

			Application.Idle += new EventHandler(Application_Idle);
		}

		~HandoutForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			AddBtn.Enabled = (SelectedSource != null);
			AddAllBtn.Enabled = SourceList.ShowGroups;
			RemoveBtn.Enabled = (SelectedItem != null);
			ClearBtn.Enabled = (fItems.Count != 0);

			UpBtn.Enabled = ((SelectedItem != null) && (fItems.IndexOf(SelectedItem) != 0));
			DownBtn.Enabled = ((SelectedItem != null) && (fItems.IndexOf(SelectedItem) != fItems.Count - 1));

			ExportBtn.Enabled = (fItems.Count != 0);
			PlayerViewBtn.Enabled = (fItems.Count != 0);

			bool has_dm_entries = false;
			foreach (object item in fItems)
			{
				if (item is EncyclopediaEntry)
				{
					EncyclopediaEntry entry = item as EncyclopediaEntry;
					if (entry.DMInfo != "")
					{
						has_dm_entries = true;
						break;
					}
				}
			}

			DMInfoBtn.Enabled = has_dm_entries;
			DMInfoBtn.Checked = fShowDMInfo;
		}

		List<object> fItems = new List<object>();
		List<Type> fTypes = new List<Type>();
		bool fShowDMInfo = false;

		public object SelectedSource
		{
			get
			{
				if (SourceList.SelectedItems.Count != 0)
					return SourceList.SelectedItems[0].Tag;

				return null;
			}
		}

		public object SelectedItem
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag;

				return null;
			}
		}

		public void AddBackgroundEntries()
		{
			foreach (ListViewItem lvi in SourceList.Items)
			{
				object item = lvi.Tag;

				if (item is Background)
					fItems.Add(item);
			}

			update_source_list();
			update_item_list();
			update_handout();
		}

		public void AddEncyclopediaEntries()
		{
			foreach (ListViewItem lvi in SourceList.Items)
			{
				object item = lvi.Tag;

				if (item is EncyclopediaEntry)
					fItems.Add(item);
			}

			update_source_list();
			update_item_list();
			update_handout();
		}

		public void AddRulesEntries()
		{
			foreach (ListViewItem lvi in SourceList.Items)
			{
				object item = lvi.Tag;

				if (item is IPlayerOption)
					fItems.Add(item);
			}

			update_source_list();
			update_item_list();
			update_handout();
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSource == null)
				return;

			if (fItems.Contains(SelectedSource))
				return;

			fItems.Add(SelectedSource);

			update_source_list();
			update_item_list();
			update_handout();
		}

		private void AddAllBtn_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem lvi in SourceList.Items)
			{
				object item = lvi.Tag;

				if (fItems.Contains(item))
					return;

				fItems.Add(item);
			}

			update_source_list();
			update_item_list();
			update_handout();
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedItem == null)
				return;

			fItems.Remove(SelectedItem);

			update_source_list();
			update_item_list();
			update_handout();
		}

		private void RemoveAll_Click(object sender, EventArgs e)
		{
			fItems.Clear();

			update_source_list();
			update_item_list();
			update_handout();
		}

		private void UpBtn_Click(object sender, EventArgs e)
		{
			if (SelectedItem == null)
				return;

			int index = fItems.IndexOf(SelectedItem);
			if (index == 0)
				return;

			object tmp = fItems[index - 1];
			fItems[index - 1] = SelectedItem;
			fItems[index] = tmp;

			update_item_list();
			update_handout();

			ItemList.SelectedIndices.Add(index - 1);
		}

		private void DownBtn_Click(object sender, EventArgs e)
		{
			if (SelectedItem == null)
				return;

			int index = fItems.IndexOf(SelectedItem);
			if (index == fItems.Count - 1)
				return;

			object tmp = fItems[index + 1];
			fItems[index + 1] = SelectedItem;
			fItems[index] = tmp;

			update_item_list();
			update_handout();

			ItemList.SelectedIndices.Add(index + 1);
		}

		private void ExportBtn_Click(object sender, EventArgs e)
		{
			if (fItems.Count == 0)
				return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = Program.HTMLFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				File.WriteAllText(dlg.FileName, Browser.DocumentText);
				System.Diagnostics.Process.Start(dlg.FileName);
			}
		}

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowHandout(fItems, fShowDMInfo);
		}

		void update_source_list()
		{
			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			foreach (EncyclopediaEntry entry in Session.Project.Encyclopedia.Entries)
			{
				if ((entry.Category != null) && (entry.Category != ""))
					bst.Add(entry.Category);
			}
			List<string> cats = bst.SortedList;
			cats.Insert(0, "Background Items");
			cats.Add("Miscellaneous");
			cats.Add("Player Options");

			SourceList.Groups.Clear();
			foreach (string cat in cats)
				SourceList.Groups.Add(cat, cat);
			SourceList.ShowGroups = true;

			SourceList.Items.Clear();

			foreach (Background bg in Session.Project.Backgrounds)
			{
				if (fItems.Contains(bg))
					continue;

				if (bg.Details == "")
					continue;

				ListViewItem lvi = SourceList.Items.Add(bg.Title);
				lvi.Tag = bg;
				lvi.Group = SourceList.Groups["Background Items"];
			}

			foreach (EncyclopediaEntry entry in Session.Project.Encyclopedia.Entries)
			{
				if (fItems.Contains(entry))
					continue;

				if (entry.Details == "")
					continue;

				ListViewItem lvi = SourceList.Items.Add(entry.Name);
				lvi.Tag = entry;

				if ((entry.Category != null) && (entry.Category != ""))
					lvi.Group = SourceList.Groups[entry.Category];
				else
					lvi.Group = SourceList.Groups["Miscellaneous"];
			}

			foreach (IPlayerOption option in Session.Project.PlayerOptions)
			{
				if (fItems.Contains(option))
					continue;

				ListViewItem lvi = SourceList.Items.Add(option.Name);
				lvi.Tag = option;
				lvi.Group = SourceList.Groups["Player Options"];
			}

			if (SourceList.Items.Count == 0)
			{
				SourceList.ShowGroups = false;
				ListViewItem lvi = SourceList.Items.Add("(no items)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void update_item_list()
		{
			ItemList.Items.Clear();

			foreach (object item in fItems)
			{
				ListViewItem lvi = ItemList.Items.Add(item.ToString());
				lvi.Tag = item;
			}

			if (ItemList.Items.Count == 0)
			{
				ListViewItem lvi = ItemList.Items.Add("(no items)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void update_handout()
		{
			Browser.Document.OpenNew(true);
			Browser.Document.Write(HTML.Handout(fItems, Session.Preferences.TextSize, fShowDMInfo));
		}

		private void SourceList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedSource == null)
				return;

			DoDragDrop(SelectedSource, DragDropEffects.Move);
		}

		private void SourceList_DragOver(object sender, DragEventArgs e)
		{
			foreach (Type type in fTypes)
			{
				object obj = e.Data.GetData(type);
				if ((obj != null) && (fItems.Contains(obj)))
				{
					e.Effect = DragDropEffects.Move;
					return;
				}
			}
		}

		private void SourceList_DragDrop(object sender, DragEventArgs e)
		{
			foreach (Type type in fTypes)
			{
				object obj = e.Data.GetData(type);
				if ((obj != null) && (fItems.Contains(obj)))
				{
					fItems.Remove(obj);

					update_source_list();
					update_item_list();
					update_handout();

					return;
				}
			}
		}

		private void ItemList_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedItem == null)
				return;

			DoDragDrop(SelectedItem, DragDropEffects.Move);
		}

		private void ItemList_DragOver(object sender, DragEventArgs e)
		{
			foreach (Type type in fTypes)
			{
				object obj = e.Data.GetData(type);
				if ((obj != null) && (!fItems.Contains(obj)))
				{
					e.Effect = DragDropEffects.Move;
					return;
				}
			}
		}

		private void ItemList_DragDrop(object sender, DragEventArgs e)
		{
			foreach (Type type in fTypes)
			{
				object obj = e.Data.GetData(type);
				if ((obj != null) && (!fItems.Contains(obj)))
				{
					fItems.Add(obj);

					update_source_list();
					update_item_list();
					update_handout();

					return;
				}
			}
		}

		private void DMInfoBtn_Click(object sender, EventArgs e)
		{
			fShowDMInfo = !fShowDMInfo;
			update_handout();
		}
	}
}
