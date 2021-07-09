using System.Windows.Forms;

using Utils.Wizards;

namespace Masterplan.Wizards
{
	partial class VariantFinishPage : UserControl, IWizardPage
	{
		public VariantFinishPage()
		{
			InitializeComponent();
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
			get { return true; }
		}

		public void OnShown(object data)
		{
		}

		public bool OnBack()
		{
			return true;
		}

		public bool OnNext()
		{
			return false;
		}

		public bool OnFinish()
		{
			return true;
		}

		#endregion
	}
}
