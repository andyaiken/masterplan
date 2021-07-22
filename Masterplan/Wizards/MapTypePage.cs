using System.Windows.Forms;

using Masterplan.Tools.Generators;

namespace Masterplan.Wizards
{
	partial class MapTypePage : UserControl, IWizardPage
	{
		public MapTypePage()
		{
			InitializeComponent();
		}

		MapBuilderData fData = null;

		#region IWizardPage Members

		public bool AllowNext
		{
			get { return true; }
		}

		public bool AllowBack
		{
			get { return false; }
		}

		public bool AllowFinish
		{
			get { return false; }
		}

		public void OnShown(object data)
		{
			if (fData == null)
			{
				fData = data as MapBuilderData;

				switch (fData.Type)
				{
					case MapAutoBuildType.Warren:
						DungeonBtn.Checked = true;
						break;
					case MapAutoBuildType.FilledArea:
						AreaBtn.Checked = true;
						break;
					case MapAutoBuildType.Freeform:
						FreeformBtn.Checked = true;
						break;
				}
			}
		}

		public bool OnBack()
		{
			return true;
		}

		public bool OnNext()
		{
			set_data();
			return true;
		}

		public bool OnFinish()
		{
			set_data();
			return true;
		}

		#endregion

		void set_data()
		{
			if (DungeonBtn.Checked)
				fData.Type = MapAutoBuildType.Warren;

			if (AreaBtn.Checked)
				fData.Type = MapAutoBuildType.FilledArea;

			if (FreeformBtn.Checked)
				fData.Type = MapAutoBuildType.Freeform;
		}
	}
}
