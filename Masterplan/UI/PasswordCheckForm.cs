using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
	partial class PasswordCheckForm : Form
	{
		public PasswordCheckForm(string password, string hint)
		{
			InitializeComponent();

			fPassword = password;
			fHint = hint;

			HintBtn.Visible = (fHint != "");
			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (PasswordBox.Text.ToLower() == fPassword);
		}

		string fPassword = "";
		string fHint = "";

		private void HintBtn_Click(object sender, EventArgs e)
		{
			string str = "Password hint: " + fHint;
			MessageBox.Show(this, str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
