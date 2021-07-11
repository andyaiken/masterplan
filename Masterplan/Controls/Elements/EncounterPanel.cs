using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.UI;

namespace Masterplan.Controls
{
	partial class EncounterPanel : UserControl
	{
		public EncounterPanel()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);
		}

		~EncounterPanel()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RunBtn.Enabled = ((fEncounter.Count != 0) || (fEncounter.Traps.Count != 0) || (fEncounter.SkillChallenges.Count != 0));
		}

		public void Edit()
		{
			EditBtn_Click(null, null);
		}

		public Encounter Encounter
		{
			get { return fEncounter; }
			set
			{
				fEncounter = value;
				update_view();
			}
		}
		Encounter fEncounter = null;

		public int PartyLevel
		{
			get { return fPartyLevel; }
			set
			{
				fPartyLevel = value;
				update_view();
			}
		}
		int fPartyLevel = Session.Project.Party.Level;

		public EncounterSlot SelectedSlot
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as EncounterSlot;

				return null;
			}
		}

		public Trap SelectedTrap
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as Trap;

				return null;
			}
		}

		public SkillChallenge SelectedChallenge
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as SkillChallenge;

				return null;
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			EncounterBuilderForm dlg = new EncounterBuilderForm(fEncounter, fPartyLevel, false);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fEncounter.Slots = dlg.Encounter.Slots;
				fEncounter.Traps = dlg.Encounter.Traps;
				fEncounter.SkillChallenges = dlg.Encounter.SkillChallenges;
                fEncounter.CustomTokens = dlg.Encounter.CustomTokens;
				fEncounter.MapID = dlg.Encounter.MapID;
				fEncounter.MapAreaID = dlg.Encounter.MapAreaID;
                fEncounter.Notes = dlg.Encounter.Notes;
				fEncounter.Waves = dlg.Encounter.Waves;

				update_view();
			}
		}

		private void RunBtn_Click(object sender, EventArgs e)
		{
			CombatState cs = new CombatState();
			cs.Encounter = fEncounter;
			cs.PartyLevel = fPartyLevel;

			CombatForm dlg = new CombatForm(cs);
			dlg.Show();
		}

		void update_view()
		{
			ItemList.Items.Clear();

			foreach (EncounterSlot slot in fEncounter.Slots)
			{
				ListViewItem lvi = ItemList.Items.Add(slot.Card.Title);
				lvi.SubItems.Add(slot.Card.Info);
				lvi.SubItems.Add(slot.CombatData.Count.ToString());
				lvi.SubItems.Add(slot.XP.ToString());
				lvi.Tag = slot;

				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				Difficulty diff = AI.GetThreatDifficulty(creature.Level + slot.Card.LevelAdjustment, fPartyLevel);
				if (diff == Difficulty.Trivial)
					lvi.ForeColor = Color.Green;
				if (diff == Difficulty.Extreme)
					lvi.ForeColor = Color.Red;
			}

			foreach (Trap trap in fEncounter.Traps)
			{
				ListViewItem lvi = ItemList.Items.Add(trap.Name);
				lvi.SubItems.Add(trap.Info);
				lvi.SubItems.Add("1");
				lvi.SubItems.Add(Experience.GetCreatureXP(trap.Level).ToString());
				lvi.Tag = trap;
			}

			foreach (SkillChallenge sc in fEncounter.SkillChallenges)
			{
				ListViewItem lvi = ItemList.Items.Add(sc.Name);
				lvi.SubItems.Add(sc.Info);
				lvi.SubItems.Add("1");
				lvi.SubItems.Add(sc.GetXP().ToString());
				lvi.Tag = sc;
			}

			if (ItemList.Items.Count == 0)
			{
				ListViewItem lvi = ItemList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			ItemList.Sort();

			XPLbl.Text = fEncounter.GetXP() + " XP";
			DiffLbl.Text = "Difficulty: " + fEncounter.GetDifficulty(fPartyLevel, Session.Project.Party.Size);
		}

		private void CreatureList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedSlot != null)
			{
				CreatureDetailsForm dlg = new CreatureDetailsForm(SelectedSlot.Card);
				dlg.ShowDialog();
			}

			if (SelectedTrap != null)
			{
				TrapDetailsForm dlg = new TrapDetailsForm(SelectedTrap);
				dlg.ShowDialog();
			}

			if (SelectedChallenge != null)
			{
				SkillChallengeDetailsForm dlg = new SkillChallengeDetailsForm(SelectedChallenge);
				dlg.ShowDialog();
			}
		}
	}
}
