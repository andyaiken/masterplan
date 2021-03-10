using System;
using System.Collections.Generic;

using Utils;
using Utils.Wizards;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.Wizards
{
	class EncounterTemplateWizard : Wizard
	{
        public EncounterTemplateWizard(List<Pair<EncounterTemplateGroup, EncounterTemplate>> templates, Encounter enc, int party_level)
			: base("Encounter Templates")
		{
			fData.Templates = templates;
			fData.PartyLevel = party_level;
			fEncounter = enc;

			fData.TabulaRasa = (fEncounter.Count == 0);
		}

		public override object Data
		{
			get { return fData; }
			set { fData = value as AdviceData; }
		}
		AdviceData fData = new AdviceData();

		Encounter fEncounter = null;

		public override void AddPages()
		{
			Pages.Add(new EncounterTemplatePage());
			Pages.Add(new EncounterSelectionPage());
		}

		public override int NextPageIndex(int current_page)
		{
			return base.NextPageIndex(current_page);
		}

		public override int BackPageIndex(int current_page)
		{
			return base.BackPageIndex(current_page);
		}

		public override void OnFinish()
		{
			foreach (EncounterTemplateSlot template_slot in fData.SelectedTemplate.Slots)
			{
				if (fData.FilledSlots.ContainsKey(template_slot))
				{
					EncounterSlot slot = new EncounterSlot();
					slot.Card = fData.FilledSlots[template_slot];

					for (int n = 0; n != template_slot.Count; ++n)
						slot.CombatData.Add(new CombatData());

					fEncounter.Slots.Add(slot);
				}
			}
		}

		public override void OnCancel()
		{
		}
	}

	class AdviceData
	{
		public bool TabulaRasa = true;
		public int PartyLevel = Session.Project.Party.Level;
        public List<Pair<EncounterTemplateGroup, EncounterTemplate>> Templates = new List<Pair<EncounterTemplateGroup, EncounterTemplate>>();
		public EncounterTemplate SelectedTemplate = null;
		public Dictionary<EncounterTemplateSlot, EncounterCard> FilledSlots = new Dictionary<EncounterTemplateSlot, EncounterCard>();
	}
}
