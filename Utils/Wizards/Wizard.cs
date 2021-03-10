using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Utils.Wizards
{
	/// <summary>
	/// Abstract class which can be inherited to define a custom wizard.
	/// </summary>
	public abstract class Wizard
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Wizard()
		{
		}

		/// <summary>
		/// Constructor which sets the title of the wizard.
		/// </summary>
		/// <param name="title">The text to be shown in the wizard title bar.</param>
		public Wizard(string title) : this()
		{
			fTitle = title;
		}

		/// <summary>
		/// The text to be shown in the wizard title bar.
		/// </summary>
		public string Title
		{
			get { return fTitle; }
			set { fTitle = value; }
		}
		private string fTitle = "Wizard";

		/// <summary>
		/// The list of IWizardPage objects that make up the wizard.
		/// This list should not be edited directly outside the AddPages() method.
		/// </summary>
		public List<IWizardPage> Pages
		{
			get { return fPages; }
		}
		private List<IWizardPage> fPages = new List<IWizardPage>();

		/// <summary>
		/// The user-defined data that contains whatever data the wizard pages display.
		/// </summary>
		public abstract object Data { get; set;}

		/// <summary>
		/// This method should be overridden to add IWizardPage objects to the Pages list.
		/// It is called before the wizard is shown.
		/// </summary>
		public abstract void AddPages();

		/// <summary>
		/// This method is called when the user presses the Finish button.
		/// </summary>
		public abstract void OnFinish();

		/// <summary>
		/// This method is called when the user presses the Cancel button.
		/// </summary>
		public abstract void OnCancel();

		/// <summary>
		/// Returns the index of the IWizardPage which will be displayed if the user presses the Next button.
		/// If this method returns -1, the wizard will display Pages[current_page + 1].
		/// </summary>
		/// <param name="current_page">The index of the current page.</param>
		/// <returns>The index of the next page to be shown.</returns>
		public virtual int NextPageIndex(int current_page) { return -1; }

		/// <summary>
		/// Returns the index of the IWizardPage which will be displayed if the user presses the Back button.
		/// If this method returns -1, the wizard will display Pages[current_page - 1].
		/// </summary>
		/// <param name="current_page">The index of the current page.</param>
		/// <returns>The index of the next page to be shown.</returns>
		public virtual int BackPageIndex(int current_page) { return -1; }

		/// <summary>
		/// Gets the required size of the display area of the wizard, being the largest width and largest height of each IWizardPage contained in Pages.
		/// </summary>
		public Size MaxSize
		{
			get
			{
				Size maxsize = Size.Empty;

				foreach (IWizardPage page in fPages)
				{
					Control ctrl = page as Control;
					if (ctrl != null)
					{
						maxsize.Height = Math.Max(maxsize.Height, ctrl.Height);
						maxsize.Width = Math.Max(maxsize.Width, ctrl.Width);
					}
				}

				return maxsize;
			}
		}

		/// <summary>
		/// Calls the AddPages() method and displays the wizard dialog, showing the IWizardPage at Pages[0].
		/// </summary>
		/// <returns>DialogResult.OK if the user pressed Finish to exit the wizard; DialogResult.Cancel if the user instead pressed Cancel.</returns>
		public DialogResult Show()
		{
			AddPages();

			WizardForm dlg = new WizardForm(this);
			return dlg.ShowDialog();
		}
	}
}
