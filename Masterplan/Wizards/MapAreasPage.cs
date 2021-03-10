using System;
using System.Windows.Forms;

using Utils.Wizards;

using Masterplan.Tools.Generators;

namespace Masterplan.Wizards
{
	partial class MapAreasPage : UserControl, IWizardPage
	{
		public MapAreasPage()
		{
			InitializeComponent();
		}

		MapBuilderData fData = null;

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
			get { return true; }
		}

		public void OnShown(object data)
		{
			if (fData == null)
			{
				fData = data as MapBuilderData;
				MaxAreasBox.Value = fData.MaxAreaCount;
				MinAreasBox.Value = fData.MinAreaCount;
			}
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
			fData.MaxAreaCount = (int)MaxAreasBox.Value;
			fData.MinAreaCount = (int)MinAreasBox.Value;
			return true;
		}

		#endregion

		private void MaxAreasBox_ValueChanged(object sender, EventArgs e)
		{
			MinAreasBox.Maximum = MaxAreasBox.Value;
		}
	}
}
