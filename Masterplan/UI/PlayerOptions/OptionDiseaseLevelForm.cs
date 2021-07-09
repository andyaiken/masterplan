using System.Windows.Forms;

namespace Masterplan.UI
{
	partial class OptionDiseaseLevelForm : Form
	{
		public OptionDiseaseLevelForm(string level)
		{
			InitializeComponent();

			DetailsBox.Text = level;
		}

		public string DiseaseLevel
		{
			get { return DetailsBox.Text; }
		}
	}
}
