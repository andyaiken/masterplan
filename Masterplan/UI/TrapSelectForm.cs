using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TrapSelectForm : Form
	{
		public TrapSelectForm()
		{
			InitializeComponent();

			TrapList.ListViewItemSorter = new TrapSorter();

			Application.Idle += new EventHandler(Application_Idle);

			if (Session.Project != null)
			{
				int min = Math.Max(1, Session.Project.Party.Level - 4);
				int max = Session.Project.Party.Level + 5;
				LevelRangePanel.SetLevelRange(min, max);
			}

			update_list();

			Browser.DocumentText = "";
			TrapList_SelectedIndexChanged(null, null);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (Trap != null);
		}

		public Trap Trap
		{
			get
			{
				if (TrapList.SelectedItems.Count != 0)
					return TrapList.SelectedItems[0].Tag as Trap;

				return null;
			}
		}

		private void TrapList_DoubleClick(object sender, EventArgs e)
		{
			if (Trap != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void TrapList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string html = HTML.Trap(Trap, null, true, false, false, DisplaySize.Small);

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}

		private void TrapList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			TrapSorter sorter = TrapList.ListViewItemSorter as TrapSorter;
			sorter.Set(e.Column);

			TrapList.Sort();
		}

		private void LevelRangePanel_RangeChanged(object sender, EventArgs e)
		{
			update_list();
		}

		void update_list()
		{
			List<Trap> traps = Session.Traps;

			TrapList.BeginUpdate();
			TrapList.Items.Clear();
			foreach (Trap trap in traps)
			{
				// Check level
				if ((trap.Level < LevelRangePanel.MinimumLevel) || (trap.Level > LevelRangePanel.MaximumLevel))
					continue;

				if (!match(trap, LevelRangePanel.NameQuery))
					continue;

				ListViewItem lvi = TrapList.Items.Add(trap.Name);
				lvi.SubItems.Add(trap.Info);
				lvi.Group = TrapList.Groups[trap.Type == TrapType.Trap ? 0 : 1];
				lvi.Tag = trap;
			}
			TrapList.EndUpdate();
		}

		bool match(Trap trap, string query)
		{
			string[] tokens = query.ToLower().Split();

			foreach (string token in tokens)
			{
				if (!match_token(trap, token))
					return false;
			}

			return true;
		}

		bool match_token(Trap trap, string token)
		{
			if (trap.Name.ToLower().Contains(token))
				return true;

			return false;
		}

		public class TrapSorter : IComparer
		{
			public void Set(int column)
			{
				if (fColumn == column)
					fAscending = !fAscending;

				fColumn = column;
			}

			bool fAscending = true;
			int fColumn = 0;

			public int Compare(object x, object y)
			{
				ListViewItem lvi_x = x as ListViewItem;
				ListViewItem lvi_y = y as ListViewItem;

				int result = 0;

				switch (fColumn)
				{
					case 0:
						{
							ListViewItem.ListViewSubItem lvsi_x = lvi_x.SubItems[fColumn];
							ListViewItem.ListViewSubItem lvsi_y = lvi_y.SubItems[fColumn];

							string str_x = lvsi_x.Text;
							string str_y = lvsi_y.Text;

							result = str_x.CompareTo(str_y);
						}
						break;
					case 1:
						{
							Trap trap_x = lvi_x.Tag as Trap;
							Trap trap_y = lvi_y.Tag as Trap;

							int level_x = trap_x.Level;
							int level_y = trap_y.Level;

							result = level_x.CompareTo(level_y);
						}
						break;
				}

				if (!fAscending)
					result *= -1;

				return result;
			}
		}
	}
}
