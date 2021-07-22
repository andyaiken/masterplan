using System;
using System.Windows.Forms;

namespace Masterplan.Wizards
{
	partial class WizardForm : Form
	{
		public WizardForm(Wizard wiz)
		{
			InitializeComponent();

			fWizard = wiz;
			Text = fWizard.Title;

			// Set size
			if (!fWizard.MaxSize.IsEmpty)
			{
				Width += (Math.Max(fWizard.MaxSize.Width, ContentPnl.Width) - ContentPnl.Width);
				Height += (Math.Max(fWizard.MaxSize.Height, ContentPnl.Height) - ContentPnl.Height);

				ImageBox.Height = ContentPnl.Height;
			}

			Application.Idle += new EventHandler(Application_Idle);

			if (fWizard.Pages.Count != 0)
				set_page(0);
		}

		~WizardForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			IWizardPage page = CurrentPage;
			if (page != null)
			{
				BackBtn.Enabled = page.AllowBack;
				NextBtn.Enabled = page.AllowNext;
				FinishBtn.Enabled = page.AllowFinish;

				if (page.AllowFinish)
					AcceptButton = FinishBtn;
				else if (page.AllowNext)
					AcceptButton = NextBtn;
				else
					AcceptButton = null;
			}
		}

		private Wizard fWizard = null;

		public IWizardPage CurrentPage
		{
			get
			{
				if (ContentPnl.Controls.Count != 0)
					return ContentPnl.Controls[0] as IWizardPage;

				return null;
			}
		}

		private void BackBtn_Click(object sender, EventArgs e)
		{
			if (CurrentPage != null)
			{
				if (!CurrentPage.AllowBack)
					return;

				if (!CurrentPage.OnBack())
					return;

				int current_page = fWizard.Pages.IndexOf(CurrentPage);
				int pageindex = fWizard.BackPageIndex(current_page);

				if (pageindex == -1)
					pageindex = current_page - 1;

				set_page(pageindex);
			}
		}

		private void NextBtn_Click(object sender, EventArgs e)
		{
			if (CurrentPage != null)
			{
				if (!CurrentPage.AllowNext)
					return;

				if (!CurrentPage.OnNext())
					return;

				int current_page = fWizard.Pages.IndexOf(CurrentPage);
				int pageindex = fWizard.NextPageIndex(current_page);

				if (pageindex == -1)
					pageindex = current_page + 1;

				set_page(pageindex);
			}
		}

		private void FinishBtn_Click(object sender, EventArgs e)
		{
			if (CurrentPage != null)
			{
				if (!CurrentPage.AllowFinish)
					return;

				if (!CurrentPage.OnFinish())
					return;

				fWizard.OnFinish();

				Close();
			}
		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			if (CurrentPage != null)
			{
				fWizard.OnCancel();
			}

			Close();
		}

		private void set_page(int pageindex)
		{
			IWizardPage page = fWizard.Pages[pageindex];
			Control ctrl = page as Control;
			if (ctrl != null)
			{
				ContentPnl.Controls.Clear();
				ContentPnl.Controls.Add(ctrl);
				ctrl.Dock = DockStyle.Fill;

				page.OnShown(fWizard.Data);
			}
		}
	}
}