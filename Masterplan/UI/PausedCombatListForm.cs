using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class PausedCombatListForm : Form
	{
		public PausedCombatListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_list();
			set_map();
		}

		public CombatState SelectedCombat
		{
			get
			{
				if (EncounterList.SelectedItems.Count != 0)
					return EncounterList.SelectedItems[0].Tag as CombatState;

				return null;
			}
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RunBtn.Enabled = (SelectedCombat != null);
			RemoveBtn.Enabled = (SelectedCombat != null);
		}

		public void UpdateEncounters()
		{
			update_list();
			set_map();
		}

		private void RunBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCombat != null)
			{
				Session.Project.SavedCombats.Remove(SelectedCombat);
				Session.Modified = true;

				Close();

				CombatForm dlg = new CombatForm(SelectedCombat);
				dlg.Show();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCombat != null)
			{
				Session.Project.SavedCombats.Remove(SelectedCombat);
				Session.Modified = true;

				update_list();
				set_map();
			}
		}

		private void EncounterList_SelectedIndexChanged(object sender, EventArgs e)
		{
			set_map();
		}

		void update_list()
		{
			EncounterList.Items.Clear();

			foreach (CombatState cs in Session.Project.SavedCombats)
			{
				ListViewItem lvi = EncounterList.Items.Add(cs.ToString());
				lvi.Tag = cs;
			}

			if (Session.Project.SavedCombats.Count == 0)
			{
				ListViewItem lvi = EncounterList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		void set_map()
		{
			if (SelectedCombat != null)
			{
				Map m = Session.Project.FindTacticalMap(SelectedCombat.Encounter.MapID);

				MapView.Map = m;
				MapView.Viewpoint = SelectedCombat.Viewpoint;
				MapView.Encounter = SelectedCombat.Encounter;
				//MapView.HeroData = SelectedCombat.HeroData;
				MapView.TokenLinks = SelectedCombat.TokenLinks;

				MapView.Sketches.Clear();
				foreach (MapSketch sketch in SelectedCombat.Sketches)
					MapView.Sketches.Add(sketch.Copy());
			}
			else
			{
				MapView.Map = null;
			}
		}
	}
}
