using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
	partial class PasswordSetForm : Form
	{
		public PasswordSetForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			PasswordBox.Text = Session.Project.Password;
			RetypeBox.Text = Session.Project.Password;
			HintBox.Text = Session.Project.PasswordHint;

			ClearBtn.Visible = (Session.Project.Password != "");
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (PasswordBox.Text.ToLower() == RetypeBox.Text.ToLower());
		}

		public string Password
		{
			get { return PasswordBox.Text.ToLower(); }
		}

		public string PasswordHint
		{
			get { return HintBox.Text; }
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			Session.Project.Password = "";
			Session.Project.PasswordHint = "";

			Session.Modified = true;

			DialogResult = DialogResult.Ignore;
			Close();
		}
	}
}
