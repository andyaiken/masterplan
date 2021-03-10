using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class DisplayNameForm : Form
	{
		public DisplayNameForm(List<CombatData> combatants, Encounter enc)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fCombatants = combatants;
			fEncounter = enc;

			Map map = null;
			if (fEncounter.MapID != Guid.Empty)
				map = Session.Project.FindTacticalMap(fEncounter.MapID);

			if (map == null)
				Pages.TabPages.Remove(MapPage);
			else
			{
				Map.Map = map;
				Map.Encounter = fEncounter;
			}

			update_list();
			update_stat_block();
			update_map_area();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			NameBox.Enabled = (SelectedCombatant != null);
			SetNameBtn.Enabled = ((NameBox.Text != "") && (SelectedCombatant != null) && (NameBox.Text != SelectedCombatant.DisplayName));
		}

		public List<CombatData> Combatants
		{
			get { return fCombatants; }
		}
		List<CombatData> fCombatants = null;

		Encounter fEncounter = null;

		public CombatData SelectedCombatant
		{
			get
			{
				if (CombatantList.SelectedItems.Count != 0)
					return CombatantList.SelectedItems[0].Tag as CombatData;

				return null;
			}
		}

		private void CombatantList_SelectedIndexChanged(object sender, EventArgs e)
		{
			NameBox.Text = (SelectedCombatant != null) ? SelectedCombatant.DisplayName : "";

			update_stat_block();
			update_map_area();
		}

		void update_list()
		{
			CombatantList.Items.Clear();

			foreach (CombatData cd in fCombatants)
			{
				ListViewItem lvi = CombatantList.Items.Add(cd.DisplayName);
				lvi.Tag = cd;
			}
		}

		void update_stat_block()
		{
			EncounterSlot slot = fEncounter.FindSlot(SelectedCombatant);
			EncounterCard card = slot != null ? slot.Card : null;
			Browser.DocumentText = HTML.StatBlock(card, SelectedCombatant, fEncounter, true, false, true, CardMode.View, DisplaySize.Small);
		}

		void update_map_area()
		{
			Rectangle view = Rectangle.Empty;

			Map.BoxedTokens.Clear();

			if ((SelectedCombatant != null) && (SelectedCombatant.Location != CombatData.NoPoint))
			{
				EncounterSlot slot = fEncounter.FindSlot(SelectedCombatant);
				Map.BoxedTokens.Add(new CreatureToken(slot.ID, SelectedCombatant));
				Map.MapChanged();

				ICreature creature = Session.FindCreature(slot.Card.CreatureID, SearchType.Global);
				int size = Creature.GetSize(creature.Size);

				int dx = 7;
				int dy = 4;

				int left = SelectedCombatant.Location.X - dx;
				int top = SelectedCombatant.Location.Y - dy;
				int width = dx + size + dx;
				int height = dy + size + dy;

				view = new Rectangle(left, top, width, height);
			}
			else if (fEncounter.MapAreaID != Guid.Empty)
			{
				MapArea ma = Map.Map.FindArea(fEncounter.MapAreaID);
				if (ma != null)
					view = ma.Region;
			}

			Map.Viewpoint = view;
		}

		private void SetNameBtn_Click(object sender, EventArgs e)
		{
			if (SelectedCombatant != null)
			{
				SelectedCombatant.DisplayName = NameBox.Text;

				update_list();
				update_stat_block();
				update_map_area();
			}
		}
	}
}
