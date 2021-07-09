using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class InfoForm : Form
    {
		public InfoForm()
        {
            InitializeComponent();

			InfoPanel.Level = (Session.Project != null) ? Session.Project.Party.Level : 1;
        }

		public int Level
		{
			get { return InfoPanel.Level; }
			set { InfoPanel.Level = value; }
		}
    }
}
