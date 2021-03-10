using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;
using System.Diagnostics;

namespace Masterplan.UI
{
	partial class CompendiumForm : Form
	{
		public CompendiumForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_books();
			update_items();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			ItemList.Enabled = (SelectedBook != null) ;
		}

		private void SourceBookListForm_Shown(object sender, EventArgs e)
		{
			Application.DoEvents();

			Cursor.Current = Cursors.WaitCursor;

			Dictionary<string, CompendiumHelper.SourceBook> books = get_data();
			fBooks.Clear();
			fBooks.AddRange(books.Values);

			update_books();
			update_items();

			Cursor.Current = Cursors.Default;
		}

		public CompendiumHelper.SourceBook SelectedBook
		{
			get
			{
				if (BookList.SelectedItems.Count != 0)
					return BookList.SelectedItems[0].Tag as CompendiumHelper.SourceBook;

				return null;
			}
		}

		public CompendiumHelper.CompendiumItem SelectedItem
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as CompendiumHelper.CompendiumItem;

				return null;
			}
		}

		List<CompendiumHelper.SourceBook> fBooks = new List<CompendiumHelper.SourceBook>();

		private void BookList_SelectedIndexChanged(object sender, EventArgs e)
		{
			update_items();
		}

		private void ItemList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedItem != null)
			{
				CompendiumItemForm dlg = new CompendiumItemForm(SelectedItem);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Library lib = Session.FindLibrary(SelectedItem.SourceBook);
					if (lib == null)
					{
						lib = new Library();
						lib.Name = SelectedItem.SourceBook;
						Session.Libraries.Add(lib);
					}

					switch (SelectedItem.Type)
					{
						case CompendiumHelper.ItemType.Creature:
							{
								Creature c = dlg.Result as Creature;

								// Does it exist already?
								Creature original = lib.FindCreature(c.Name, c.Level);
								if (original != null)
								{
									// Keep ID and category
									c.ID = original.ID;
									c.Category = original.Category;

									lib.Creatures.Remove(original);
								}

								lib.Creatures.Add(c);
							}
							break;
						case CompendiumHelper.ItemType.Trap:
							{
								Trap t = dlg.Result as Trap;

								// Does it exist already?
								Trap original = lib.FindTrap(t.Name, t.Level, t.Role.ToString());
								if (original != null)
								{
									// Keep ID
									t.ID = original.ID;

									lib.Traps.Remove(original);
								}

								lib.Traps.Add(t);
							}
							break;
						case CompendiumHelper.ItemType.MagicItem:
							{
								MagicItem mi = dlg.Result as MagicItem;

								// Does it exist already?
								MagicItem original = lib.FindMagicItem(mi.Name, mi.Level);
								if (original != null)
								{
									// Keep ID
									mi.ID = original.ID;

									lib.MagicItems.Remove(original);
								}

								lib.MagicItems.Add(mi);
							}
							break;
					}

					// Save the library
					string filename = Session.GetLibraryFilename(lib);
					Serialisation<Library>.Save(filename, lib, SerialisationMode.Binary);
				}
			}
		}

		Dictionary<string, CompendiumHelper.SourceBook> get_data()
		{
			List<CompendiumHelper.CompendiumItem> creatures = CompendiumHelper.GetCreatures();
			List<CompendiumHelper.CompendiumItem> traps = CompendiumHelper.GetTraps();
			List<CompendiumHelper.CompendiumItem> magic_items = CompendiumHelper.GetMagicItems();

			List<CompendiumHelper.CompendiumItem> items = new List<CompendiumHelper.CompendiumItem>();
			if (creatures != null)
				items.AddRange(creatures);
			if (traps != null)
				items.AddRange(traps);
			if (magic_items != null)
				items.AddRange(magic_items);

			Dictionary<string, CompendiumHelper.SourceBook> books = new Dictionary<string, CompendiumHelper.SourceBook>();
			foreach (CompendiumHelper.CompendiumItem ci in items)
			{
				if (!books.ContainsKey(ci.SourceBook))
				{
					CompendiumHelper.SourceBook sb = new CompendiumHelper.SourceBook();
					sb.Name = ci.SourceBook;

					books[ci.SourceBook] = sb;
				}

				CompendiumHelper.SourceBook book = books[ci.SourceBook];

				if (creatures.Contains(ci))
					book.Creatures.Add(ci);

				if (traps.Contains(ci))
					book.Traps.Add(ci);

				if (magic_items.Contains(ci))
					book.MagicItems.Add(ci);
			}

			return books;
		}

		void update_books()
		{
			BookList.ShowGroups = true;

			List<ListViewItem> items = new List<ListViewItem>();
			foreach (CompendiumHelper.SourceBook book in fBooks)
			{
				ListViewItem lvi = new ListViewItem(book.Name);
				lvi.Tag = book;

				lvi.Group = BookList.Groups[0];
				if (book.Name.ToLower().StartsWith("dragon magazine"))
					lvi.Group = BookList.Groups[1];
				if (book.Name.ToLower().StartsWith("dungeon magazine"))
					lvi.Group = BookList.Groups[2];
				if (book.Name.ToLower().StartsWith("rpga"))
					lvi.Group = BookList.Groups[3];

				items.Add(lvi);
			}

			BookList.Items.Clear();
			BookList.Items.AddRange(items.ToArray());

			if (fBooks.Count == 0)
			{
				BookList.ShowGroups = false;

				ListViewItem lvi = BookList.Items.Add("(loading)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void update_items()
		{
			if (SelectedBook == null)
			{
				ItemList.Items.Clear();
			}
			else
			{
				ItemList.BeginUpdate();

				List<ListViewItem> items = new List<ListViewItem>();

				foreach (CompendiumHelper.CompendiumItem ci in SelectedBook.Creatures)
				{
					ListViewItem lvi = new ListViewItem(ci.Name);
					lvi.SubItems.Add(ci.Info);
					lvi.Tag = ci;
					lvi.Group = ItemList.Groups[0];

					items.Add(lvi);
				}
				if (SelectedBook.Creatures.Count == 0)
				{
					ListViewItem lvi = new ListViewItem("(none)");
					lvi.ForeColor = SystemColors.GrayText;
					lvi.Group = ItemList.Groups[0];

					items.Add(lvi);
				}

				foreach (CompendiumHelper.CompendiumItem ci in SelectedBook.Traps)
				{
					ListViewItem lvi = new ListViewItem(ci.Name);
					lvi.SubItems.Add(ci.Info);
					lvi.Tag = ci;
					lvi.Group = ItemList.Groups[1];

					items.Add(lvi);
				}
				if (SelectedBook.Traps.Count == 0)
				{
					ListViewItem lvi = new ListViewItem("(none)");
					lvi.ForeColor = SystemColors.GrayText;
					lvi.Group = ItemList.Groups[1];

					items.Add(lvi);
				}

				foreach (CompendiumHelper.CompendiumItem ci in SelectedBook.MagicItems)
				{
					ListViewItem lvi = new ListViewItem(ci.Name);
					lvi.SubItems.Add(ci.Info);
					lvi.Tag = ci;
					lvi.Group = ItemList.Groups[2];

					items.Add(lvi);
				}
				if (SelectedBook.MagicItems.Count == 0)
				{
					ListViewItem lvi = new ListViewItem("(none)");
					lvi.ForeColor = SystemColors.GrayText;
					lvi.Group = ItemList.Groups[2];

					items.Add(lvi);
				}

				ItemList.Items.Clear();
				ItemList.Items.AddRange(items.ToArray());

				ItemList.EndUpdate();
			}
		}
	}
}
