using System;
using System.Collections.Generic;

using Utils.Wizards;

using Masterplan.Data;

namespace Masterplan.Wizards
{
	class VariantWizard : Wizard
	{
		public VariantWizard()
			: base("Select Creature")
		{
		}

		public override object Data
		{
			get { return fData; }
			set { fData = value as VariantData; }
		}
		VariantData fData = new VariantData();

		public override void AddPages()
		{
			Pages.Add(new VariantBasePage());
			Pages.Add(new VariantTemplatesPage());
			Pages.Add(new VariantRolePage());
			Pages.Add(new VariantFinishPage());
		}

		public override int NextPageIndex(int current_page)
		{
			if (current_page == 0)
				return (fData.BaseCreature.Role is Minion) ? 3 : 1;

			if (current_page == 1)
				return (fData.Roles.Count == 1) ? 3 : 2;

			return base.NextPageIndex(current_page);
		}

		public override int BackPageIndex(int current_page)
		{
			if (current_page == 3)
			{
				if (fData.BaseCreature.Role is Minion)
					return 0;

				return (fData.Roles.Count == 1) ? 1 : 2;
			}

			return base.BackPageIndex(current_page);
		}

		public override void OnFinish()
		{
		}

		public override void OnCancel()
		{
		}
	}

	class VariantData
	{
		public ICreature BaseCreature = null;
		public List<CreatureTemplate> Templates = new List<CreatureTemplate>();

		public List<RoleType> Roles
		{
			get
			{
				List<RoleType> roles = new List<RoleType>();

				if ((BaseCreature != null) && (BaseCreature.Role is ComplexRole))
				{
					ComplexRole cr = BaseCreature.Role as ComplexRole;
					roles.Add(cr.Type);
				}

				foreach (CreatureTemplate ct in Templates)
				{
					if (!roles.Contains(ct.Role))
						roles.Add(ct.Role);
				}

				roles.Sort();

				return roles;
			}
		}

		public int SelectedRoleIndex = 0;
	}
}
