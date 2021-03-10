using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class ParcelSelectForm : Form
	{
		public ParcelSelectForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_list();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RandomiseBtn.Enabled = (Parcel != null);

			ChangeItemBtn.Enabled = ((Parcel != null) && (Parcel.MagicItemID != Guid.Empty));
			StatBlockBtn.Enabled = ((Parcel != null) && (Parcel.MagicItemID != Guid.Empty) && (!Treasure.PlaceholderIDs.Contains(Parcel.MagicItemID)));

			OKBtn.Enabled = (Parcel != null);
		}

		public Parcel Parcel
		{
			get
			{
				if (ParcelList.SelectedItems.Count != 0)
					return ParcelList.SelectedItems[0].Tag as Parcel;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (Parcel != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void ChangeItemBtn_Click(object sender, EventArgs e)
		{
			if ((Parcel != null) && (Parcel.MagicItemID != Guid.Empty))
			{
				int level = 0;
				MagicItem item = Session.FindMagicItem(Parcel.MagicItemID, SearchType.Global);
				if (item != null)
				{
					level = item.Level;
				}
				else
				{
					int index = Treasure.PlaceholderIDs.IndexOf(Parcel.MagicItemID);
					if (index != -1)
						level = index + 1;
				}

				if (level > 0)
				{
					MagicItemSelectForm dlg = new MagicItemSelectForm(level);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						Parcel.SetAsMagicItem(dlg.MagicItem);
						Session.Modified = true;

						update_list();
					}
				}
			}
		}

		private void StatBlockBtn_Click(object sender, EventArgs e)
		{
			if ((Parcel != null) && (Parcel.MagicItemID != Guid.Empty))
			{
				MagicItem item = Session.FindMagicItem(Parcel.MagicItemID, SearchType.Global);
				if (item != null)
				{
					MagicItemDetailsForm dlg = new MagicItemDetailsForm(item);
					dlg.ShowDialog();
				}
			}
		}

		private void RandomiseBtn_Click(object sender, EventArgs e)
		{
			if (Parcel != null)
			{
				randomise(Parcel);
				update_list();
			}
		}

		private void RandomiseAllBtn_Click(object sender, EventArgs e)
		{
			foreach (Parcel parcel in Session.Project.TreasureParcels)
				randomise(parcel);

			update_list();
		}

		void randomise(Parcel parcel)
		{
			if (parcel.MagicItemID != Guid.Empty)
			{
				int level = parcel.FindItemLevel();
				if (level != -1)
				{
					MagicItem new_item = Treasure.RandomMagicItem(level);
					if (new_item != null)
						parcel.SetAsMagicItem(new_item);
				}
			}
			else
			{
				parcel.Details = Treasure.RandomMundaneItem(parcel.Value);
			}
		}

		void update_list()
		{
			ParcelList.Items.Clear();

			List<Parcel> parcels = Session.Project.TreasureParcels;
			foreach (Parcel parcel in parcels)
			{
				string name = (parcel.Name != "") ? parcel.Name : "(undefined parcel)";
				ListViewItem lvi = ParcelList.Items.Add(name);
				lvi.SubItems.Add(parcel.Details);
				lvi.Tag = parcel;

				int group_index = (parcel.MagicItemID != Guid.Empty) ? 0 : 1;
				lvi.Group = ParcelList.Groups[group_index];
			}

			ParcelList.Sort();
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		private void ParcelSelectForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			/*
			if ((Parcel != null) && (Parcel.MagicItemID != Guid.Empty))
			{
				MagicItem item = Session.FindMagicItem(Parcel.MagicItemID, SearchType.Global);
				if ((item != null) && (Treasure.PlaceholderItems.Contains(item)))
				{
					MagicItemSelectForm dlg = new MagicItemSelectForm(item.Level);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						Parcel.SetAsMagicItem(dlg.MagicItem);
						Session.Modified = true;
					}
				}
			}
			*/
		}
	}
}
