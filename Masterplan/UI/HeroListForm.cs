using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class HeroListForm : Form
	{
		public HeroListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);
			BreakdownPnl.Heroes = Session.Project.Heroes;

			update_view();
		}

		~HeroListForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedHero != null);
			EditBtn.Enabled = (SelectedHero != null);

			ActiveBtn.Enabled = (SelectedHero != null);
			ActiveBtn.Checked = ((SelectedHero != null) && (Session.Project.Heroes.Contains(SelectedHero)));

			StatBlockBtn.Enabled = (SelectedHero != null);
			EntryBtn.Enabled = (SelectedHero != null);
		}

		public Hero SelectedHero
		{
			get
			{
				if (HeroList.SelectedItems.Count != 0)
					return HeroList.SelectedItems[0].Tag as Hero;

				return null;
			}
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

		#region Toolbar

		#region Add

		private void AddBtn_Click(object sender, EventArgs e)
		{
			Hero hero = new Hero();
			hero.Name = "New Character";

			HeroForm dlg = new HeroForm(hero);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				add_hero(dlg.Hero);
				update_view();
			}
		}

		#region Random

		private void RandomPC_Click(object sender, EventArgs e)
		{
			HeroData hd = HeroData.Create();
			Hero h = hd.ConvertToHero();

			Session.Project.Heroes.Add(h);
			Session.Modified = true;

			update_view();
		}

		private void RandomParty_Click(object sender, EventArgs e)
		{
			if (Session.Project.Heroes.Count != 0)
			{
				string msg = "This will clear the PC list.";
				msg += Environment.NewLine;
				msg += "Are you sure you want to do this?";

				DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return;

				Session.Project.Heroes.Clear();
			}

			HeroGroup group = HeroGroup.CreateGroup(Session.Project.Party.Size);
			foreach (HeroData hd in group.Heroes)
			{
				if (hd == null)
					continue;

				Hero h = hd.ConvertToHero();
				Session.Project.Heroes.Add(h);
			}

			Session.Modified = true;

			update_view();
		}

		#endregion

		private void AddSuggest_Click(object sender, EventArgs e)
		{
			HeroGroup group = new HeroGroup();

			// Set up the group
			foreach (Hero hero in Session.Project.Heroes)
			{
				RaceData rd = Sourcebook.GetRace(hero.Race);
				ClassData cd = Sourcebook.GetClass(hero.Class);

				group.Heroes.Add(new HeroData(rd, cd));
			}

			// Ask for another
			HeroData hd = group.Suggest();
			if (hd != null)
			{
				Hero h = hd.ConvertToHero();
				Session.Project.Heroes.Add(h);
			}

			update_view();
		}

		#endregion

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedHero != null)
			{
				string msg = "Are you sure you want to delete this PC?";
				DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return;

				List<Hero> list = Session.Project.Heroes.Contains(SelectedHero) ? Session.Project.Heroes : Session.Project.InactiveHeroes;
				list.Remove(SelectedHero);

				foreach (Parcel parcel in Session.Project.AllTreasureParcels)
				{
					if (parcel.HeroID == SelectedHero.ID)
						parcel.HeroID = Guid.Empty;
				}

				Session.Modified = true;

				update_view();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedHero != null)
			{
				edit_hero();
			}
		}

		void edit_hero()
		{
			List<Hero> list = Session.Project.Heroes.Contains(SelectedHero) ? Session.Project.Heroes : Session.Project.InactiveHeroes;
			int index = list.IndexOf(SelectedHero);

			HeroForm dlg = new HeroForm(SelectedHero);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				list[index] = dlg.Hero;
				Session.Modified = true;

				update_view();
			}
		}

		private void ActiveBtn_Click(object sender, EventArgs e)
		{
			Hero hero = SelectedHero;
			if (hero == null)
				return;

			if (Session.Project.Heroes.Contains(hero))
			{
				Session.Project.Heroes.Remove(hero);
				Session.Project.InactiveHeroes.Add(hero);
			}
			else
			{
				Session.Project.InactiveHeroes.Remove(hero);
				Session.Project.Heroes.Add(hero);
			}

			Session.Modified = true;

			update_view();
		}

		private void PlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowPCs();
		}

		private void StatBlockBtn_Click(object sender, EventArgs e)
		{
			if (SelectedHero != null)
			{
				HeroDetailsForm dlg = new HeroDetailsForm(SelectedHero);
				dlg.ShowDialog();
			}
		}

		#endregion

		private void EntryBtn_Click(object sender, EventArgs e)
		{
			if (SelectedHero == null)
				return;

			EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(SelectedHero.ID);

			if (entry == null)
			{
				// If there is no entry, ask to create it
				string msg = "There is no encyclopedia entry associated with this PC.";
				msg += Environment.NewLine;
				msg += "Would you like to create one now?";
				if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;

				entry = new EncyclopediaEntry();
				entry.Name = SelectedHero.Name;
				entry.AttachmentID = SelectedHero.ID;
				entry.Category = "People";

				Session.Project.Encyclopedia.Entries.Add(entry);
				Session.Modified = true;
			}

			// Edit the entry
			int index = Session.Project.Encyclopedia.Entries.IndexOf(entry);
			EncyclopediaEntryForm dlg = new EncyclopediaEntryForm(entry);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Encyclopedia.Entries[index] = dlg.Entry;
				Session.Modified = true;
			}
		}

		private void ParcelList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedParcel != null)
			{
				ParcelForm dlg = new ParcelForm(SelectedParcel);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					// Save changes
					SelectedParcel.Name = dlg.Parcel.Name;
					SelectedParcel.Details = dlg.Parcel.Details;
					SelectedParcel.HeroID = dlg.Parcel.HeroID;
					SelectedParcel.MagicItemID = dlg.Parcel.MagicItemID;
					SelectedParcel.ArtifactID = dlg.Parcel.ArtifactID;
					SelectedParcel.Value = dlg.Parcel.Value;

					update_parcels();

					Session.Modified = true;
				}
			}
		}

		void update_view()
		{
			update_heroes();
			update_parcels();
		}

		void update_heroes()
		{
			HeroList.Items.Clear();

			foreach (Hero hero in Session.Project.Heroes)
				add_to_list(hero, true);

			foreach (Hero hero in Session.Project.InactiveHeroes)
				add_to_list(hero, false);

			if (Session.Project.Heroes.Count == 0)
			{
				ListViewItem lvi = HeroList.Items.Add("(no heroes)");
				lvi.ForeColor = SystemColors.GrayText;
				lvi.Group = HeroList.Groups[0];
			}

			StatusBar.Visible = (Session.Project.Heroes.Count > Session.Project.Party.Size);
			PartySizeLbl.Text = "Your project is set up for a party size of " + Session.Project.Party.Size + "; click here to change it";
		}

		void update_parcels()
		{
			ParcelList.Groups.Clear();
			ParcelList.Items.Clear();

			ParcelList.ShowGroups = true;
			foreach (Hero hero in Session.Project.Heroes)
				ParcelList.Groups.Add(hero.Name, hero.Name);

			foreach (Parcel parcel in Session.Project.TreasureParcels)
				add_parcel(parcel);

			foreach (PlotPoint pp in Session.Project.AllPlotPoints)
			{
				foreach (Parcel parcel in pp.Parcels)
					add_parcel(parcel);
			}

			if (ParcelList.Items.Count == 0)
			{
				ParcelList.ShowGroups = false;
				ListViewItem lvi = ParcelList.Items.Add("(none assigned)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void add_parcel(Parcel parcel)
		{
			if (parcel.HeroID == Guid.Empty)
				return;

			Hero hero = Session.Project.FindHero(parcel.HeroID);
			if (hero == null)
				return;

			ListViewItem lvi = ParcelList.Items.Add(parcel.Name);
			lvi.SubItems.Add(parcel.Details);
			lvi.Tag = parcel;
			lvi.Group = ParcelList.Groups[hero.Name];
		}

		void add_to_list(Hero hero, bool active)
		{
			string name_str = (hero.Name != "") ? hero.Name : "(unnamed)";
			if (hero.Player != "")
				name_str += " (" + hero.Player + ")";

			ListViewItem lvi = HeroList.Items.Add(name_str);
			lvi.SubItems.Add(hero.Info);
			lvi.SubItems.Add(hero.PassiveInsight.ToString());
			lvi.SubItems.Add(hero.PassivePerception.ToString());
			lvi.Tag = hero;

			lvi.Group = HeroList.Groups[active ? 0 : 1];
		}

		void add_hero(Hero hero)
		{
			Hero previous = Session.Project.FindHero(hero.Name);
			List<Hero> list = Session.Project.InactiveHeroes.Contains(previous) ? Session.Project.InactiveHeroes : Session.Project.Heroes;

			if (previous != null)
			{
				hero.ID = previous.ID;
				hero.Effects.AddRange(previous.Effects);

				list.Remove(previous);
			}

			list.Add(hero);
			Session.Modified = true;
		}
	}
}
