using System.Windows.Forms;

using Utils.Wizards;

using Masterplan.Tools.Generators;

namespace Masterplan.Wizards
{
	partial class MapSizePage : UserControl, IWizardPage
	{
		public MapSizePage()
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

				WidthBox.Value = fData.Width;
				HeightBox.Value = fData.Height;
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
			fData.Width = (int)WidthBox.Value;
			fData.Height = (int)HeightBox.Value;

			return true;
		}

		#endregion
	}
}
