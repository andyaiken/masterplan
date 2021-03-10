using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class ParcelListForm : Form
	{
		public ParcelListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_list();
		}

		bool fViewAssigned = false;
		bool fViewUnassigned = true;

		void Application_Idle(object sender, EventArgs e)
		{
			AddMagicItem.Enabled = (Session.MagicItems.Count != 0);
			AddArtifact.Enabled = (Session.Artifacts.Count != 0);

			RemoveBtn.Enabled = (SelectedParcel != null);
			EditBtn.Enabled = (SelectedParcel != null);

			RandomiseAllBtn.Enabled = ((Session.Project.TreasureParcels.Count != 0) && (fViewUnassigned));
		}

		public Parcel SelectedParcel
		{
			get
			{
				if (ParcelList.SelectedItems.Count != 0)
					return ParcelList.SelectedItems[0].Tag as Parcel;

				return null;
			}
		}

		#region Adding

		private void AddParcel_Click(object sender, EventArgs e)
		{
			Parcel p = new Parcel();
			p.Name = "New Treasure Parcel";

			ParcelForm dlg = new ParcelForm(p);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.TreasureParcels.Add(dlg.Parcel);
				Session.Modified = true;

				update_list();
			}
		}

		private void AddMagicItem_Click(object sender, EventArgs e)
		{
			MagicItemSelectForm dlg = new MagicItemSelectForm(Session.Project.Party.Level);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Parcel parcel = new Parcel(dlg.MagicItem);

				Session.Project.TreasureParcels.Add(parcel);
				Session.Modified = true;

				update_list();
			}
		}

		private void AddArtifact_Click(object sender, EventArgs e)
		{
			ArtifactSelectForm dlg = new ArtifactSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Parcel parcel = new Parcel(dlg.Artifact);

				Session.Project.TreasureParcels.Add(parcel);
				Session.Modified = true;

				update_list();
			}
		}

		private void AddSet_Click(object sender, EventArgs e)
		{
			LevelForm dlg = new LevelForm(Session.Project.Party.Level);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				List<Parcel> list = Treasure.CreateParcelSet(dlg.Level, Session.Project.Party.Size, true);

				Session.Project.TreasureParcels.AddRange(list);
				Session.Modified = true;

				update_list();
			}
		}

		#endregion

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				List<Parcel> list = get_list_containing(SelectedParcel);

				list.Remove(SelectedParcel);
				Session.Modified = true;

				update_list();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				List<Parcel> list = get_list_containing(SelectedParcel);

				int index = list.IndexOf(SelectedParcel);

				ParcelForm dlg = new ParcelForm(SelectedParcel);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					list[index] = dlg.Parcel;
					Session.Modified = true;

					update_list();
				}
			}
		}

		#region Updating

		void update_list()
		{
			ParcelList.BeginUpdate();
			ParcelList.Items.Clear();

			if (fViewAssigned)
			{
				List<PlotPoint> all_points = Session.Project.AllPlotPoints;
				foreach (PlotPoint pp in all_points)
				{
					add_list(pp.Parcels, 0);
				}
			}

			if (fViewUnassigned)
			{
				add_list(Session.Project.TreasureParcels, 1);
			}

			if ((fViewAssigned) && (ParcelList.Groups[0].Items.Count == 0))
			{
				ListViewItem lvi = ParcelList.Items.Add("(no parcels)");
				lvi.ForeColor = SystemColors.GrayText;
				lvi.Group = ParcelList.Groups[0];
			}

			if ((fViewUnassigned) && (ParcelList.Groups[1].Items.Count == 0))
			{
				ListViewItem lvi = ParcelList.Items.Add("(no parcels)");
				lvi.ForeColor = SystemColors.GrayText;
				lvi.Group = ParcelList.Groups[1];
			}

			ParcelList.Sort();
			ParcelList.EndUpdate();
		}

		List<Parcel> get_list_containing(Parcel p)
		{
			if (Session.Project.TreasureParcels.Contains(p))
			{
				return Session.Project.TreasureParcels;
			}
			else
			{
				List<PlotPoint> all_points = Session.Project.AllPlotPoints;
				foreach (PlotPoint pp in all_points)
				{
					if (pp.Parcels.Contains(p))
						return pp.Parcels;
				}
			}

			return null;
		}

		void add_list(List<Parcel> list, int group_index)
		{
			foreach (Parcel p in list)
			{
				string name = (p.Name != "") ? p.Name : "(undefined parcel)";

				ListViewItem lvi = ParcelList.Items.Add(name);
				lvi.SubItems.Add(p.Details);
				lvi.Tag = p;
				lvi.Group = ParcelList.Groups[group_index];

				Hero hero = null;
				if (p.HeroID != Guid.Empty)
					hero = Session.Project.FindHero(p.HeroID);

				ListViewItem.ListViewSubItem lvsi = lvi.SubItems.Add(hero != null ? hero.Name : "");
				if (hero == null)
				{
					lvsi.ForeColor = SystemColors.GrayText;
					lvi.UseItemStyleForSubItems = false;
				}
			}
		}

		#endregion

		#region View menu

		private void ViewMenu_DropDownOpening(object sender, EventArgs e)
		{
			ViewAssigned.Checked = fViewAssigned;
			ViewUnassigned.Checked = fViewUnassigned;
		}

		private void ViewAssigned_Click(object sender, EventArgs e)
		{
			fViewAssigned = !fViewAssigned;
			update_list();
		}

		private void ViewUnassigned_Click(object sender, EventArgs e)
		{
			fViewUnassigned = !fViewUnassigned;
			update_list();
		}

		#endregion

		private void ChangeItemBtn_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				if (SelectedParcel.MagicItemID != Guid.Empty)
				{
					int level = SelectedParcel.FindItemLevel();
					if (level != -1)
					{
						MagicItemSelectForm dlg = new MagicItemSelectForm(level);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							SelectedParcel.SetAsMagicItem(dlg.MagicItem);
							Session.Modified = true;

							update_list();
						}
					}
				}

				if (SelectedParcel.ArtifactID != Guid.Empty)
				{
					ArtifactSelectForm dlg = new ArtifactSelectForm();
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						SelectedParcel.SetAsArtifact(dlg.Artifact);
						Session.Modified = true;

						update_list();
					}
				}
			}
		}

		private void assign_to_hero(object sender, EventArgs e)
		{
			if (SelectedParcel == null)
				return;

			ToolStripItem tsi = sender as ToolStripItem;
			if (tsi == null)
				return;

			Hero hero = tsi.Tag as Hero;
			SelectedParcel.HeroID = (hero != null) ? hero.ID : Guid.Empty;

			update_list();

			Session.Modified = true;
		}

		#region Randomising

		private void RandomiseBtn_Click(object sender, EventArgs e)
		{
			foreach (Parcel parcel in Session.Project.TreasureParcels)
				randomise_parcel(parcel);

			update_list();

			Session.Modified = true;
		}

		private void RandomiseItem_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				randomise_parcel(SelectedParcel);
				update_list();
			}
		}

		private void ResetItem_Click(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				reset_parcel(SelectedParcel);
				update_list();
			}
		}

		void randomise_parcel(Parcel parcel)
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
			else if (parcel.ArtifactID != Guid.Empty)
			{
				Tier tier = parcel.FindItemTier();
				Artifact new_item = Treasure.RandomArtifact(tier);
				if (new_item != null)
					parcel.SetAsArtifact(new_item);
			}
			else
			{
				if (parcel.Value != 0)
					parcel.Details = Treasure.RandomMundaneItem(parcel.Value);
			}
		}

		void reset_parcel(Parcel parcel)
		{
			if (parcel.MagicItemID != Guid.Empty)
			{
				int level = parcel.FindItemLevel();
				if (level != -1)
				{
					parcel.MagicItemID = Treasure.PlaceholderIDs[level - 1];
					parcel.Name = "Magic item (level " + level + ")";
				}
				else
				{
					parcel.Name = "Magic item";
				}
			}
			else if (parcel.ArtifactID != Guid.Empty)
			{
				Tier tier = parcel.FindItemTier();
				parcel.ArtifactID = Treasure.PlaceholderIDs[(int)tier];
				parcel.Name = "Artifact ( " + tier.ToString().ToLower() + " tier)";
			}
			else
			{
				parcel.Name = "Items worth " + parcel.Value + " GP";
			}

			parcel.Details = "";
		}

		#endregion

		private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ChangeItem.Enabled = ((SelectedParcel != null) && (SelectedParcel.MagicItemID != Guid.Empty));
			ChangeAssign.Enabled = (SelectedParcel != null);
			RandomiseItem.Enabled = (SelectedParcel != null);
			ResetItem.Enabled = (SelectedParcel != null);

			ChangeAssign.DropDownItems.Clear();
			foreach (Hero hero in Session.Project.Heroes)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem(hero.Name);
				tsmi.Tag = hero;
				tsmi.Click += assign_to_hero;

				if (SelectedParcel != null)
					tsmi.Checked = (SelectedParcel.HeroID == hero.ID);

				ChangeAssign.DropDownItems.Add(tsmi);
			}

			if (Session.Project.Heroes.Count != 0)
				ChangeAssign.DropDownItems.Add(new ToolStripSeparator());

			ToolStripMenuItem tsmi_none = new ToolStripMenuItem("Not Allocated");
			tsmi_none.Tag = null;
			tsmi_none.Click += assign_to_hero;

			if (SelectedParcel != null)
				tsmi_none.Checked = (SelectedParcel.HeroID == Guid.Empty);

			ChangeAssign.DropDownItems.Add(tsmi_none);
		}

		private void ParcelListForm_Shown(object sender, EventArgs e)
		{
			// XP bug
			ParcelList.Invalidate();
		}
	}
}
