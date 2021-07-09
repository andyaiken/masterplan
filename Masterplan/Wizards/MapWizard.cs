using Utils.Wizards;

using Masterplan.Tools.Generators;

namespace Masterplan.Wizards
{
	class MapWizard : Wizard
	{
		public MapWizard(bool delve_only)
			: base("AutoBuild Map")
		{
			fData.DelveOnly = delve_only;
		}

		public override object Data
		{
			get { return fData; }
			set { fData = value as MapBuilderData; }
		}
		static MapBuilderData fData = new MapBuilderData();

		public override void AddPages()
		{
			if (!fData.DelveOnly)
				Pages.Add(new MapTypePage());

			Pages.Add(new MapLibrariesPage());
			Pages.Add(new MapAreasPage());
			Pages.Add(new MapSizePage());
		}

		public override int NextPageIndex(int current_page)
		{
			if (current_page == 1)
			{
				switch (fData.Type)
				{
					case MapAutoBuildType.Warren:
						return 2;
					case MapAutoBuildType.FilledArea:
					case MapAutoBuildType.Freeform:
						return 3;
				}
			}

			return base.NextPageIndex(current_page);
		}

		public override int BackPageIndex(int current_page)
		{
			if ((current_page == 2) || (current_page == 3))
				return 1;

			return base.BackPageIndex(current_page);
		}

		public override void OnFinish()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
