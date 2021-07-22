using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.UI;

namespace Masterplan.Wizards
{
	partial class EncounterSelectionPage : UserControl, IWizardPage
	{
		public EncounterSelectionPage()
		{
			InitializeComponent();
		}

		AdviceData fData = null;

		public EncounterTemplateSlot SelectedSlot
		{
			get
			{
				if (SlotList.SelectedItems.Count != 0)
					return SlotList.SelectedItems[0].Tag as EncounterTemplateSlot;

				return null;
			}
		}

		#region IWizardPage Members

		public bool AllowNext
		{
			get { return false; }
		}

		public bool AllowBack
		{
			get { return true; }
		}

		public bool AllowFinish
		{
			get
			{
				foreach (EncounterTemplateSlot slot in fData.SelectedTemplate.Slots)
				{
					if (!fData.FilledSlots.ContainsKey(slot))
						return false;
				}

				return true;
			}
		}

		public void OnShown(object data)
		{
			if (fData == null)
				fData = data as AdviceData;

			update_list();
		}

		public bool OnBack()
		{
			return true;
		}

		public bool OnNext()
		{
			return true;
		}

		public bool OnFinish()
		{
			return true;
		}

		#endregion

		private void SlotList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedSlot != null)
			{
				CreatureSelectForm dlg = new CreatureSelectForm(SelectedSlot, fData.PartyLevel);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fData.FilledSlots[SelectedSlot] = dlg.Creature;
					update_list();
				}
			}
		}

		void update_list()
		{
			SlotList.Items.Clear();

			foreach (EncounterTemplateSlot slot in fData.SelectedTemplate.Slots)
			{
				ListViewItem lvi = SlotList.Items.Add(slot_info(slot));
				if (fData.FilledSlots.ContainsKey(slot))
					lvi.SubItems.Add(fData.FilledSlots[slot].Title);
				else
					lvi.SubItems.Add("(not filled)");

				lvi.Tag = slot;
			}

			if (SlotList.Items.Count == 0)
			{
				ListViewItem lvi = SlotList.Items.Add("(no unused slots)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		string slot_info(EncounterTemplateSlot slot)
		{
			int level = fData.PartyLevel + slot.LevelAdjustment;
			string flag = (slot.Flag != RoleFlag.Standard) ? " " + slot.Flag : "";

			string roles = "";
			foreach (RoleType role in slot.Roles)
			{
				if (roles != "")
					roles += " / ";

				roles += role.ToString().ToLower();
			}
			if (roles == "")
				roles = "any role";
            if (slot.Minions)
                roles += ", minion";

			string count = "";
			if (slot.Count != 1)
				count = " (x" + slot.Count + ")";

			return "Level " + level + flag + " " + roles + count;
		}
	}
}
