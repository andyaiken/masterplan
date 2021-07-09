namespace Utils.Wizards
{
	/// <summary>
	/// Interface defining a page in a wizard.
	/// Controls must implement this interface to be used with the Utils.Wizard class.
	/// </summary>
	public interface IWizardPage
	{
		/// <summary>
		/// Gets a value indicating whether the Next button is currently enabled for this page.
		/// </summary>
		bool AllowNext { get; }

		/// <summary>
		/// Gets a value indicating whether the Back button is currently enabled for this page.
		/// </summary>
		bool AllowBack { get; }

		/// <summary>
		/// Gets a value indicating whether the Finish button is currently enabled for this page.
		/// </summary>
		bool AllowFinish { get; }

		/// <summary>
		/// This method is called each time the page is made visible in the wizard.
		/// </summary>
		/// <param name="data">The object from Wizard.Data.</param>
		void OnShown(object data);

		/// <summary>
		/// This method is called when the user presses the Back button on this page.
		/// </summary>
		/// <returns>Returns true if the wizard is allowed to navigate away from this page; false to stay on this page.</returns>
		bool OnBack();

		/// <summary>
		/// This method is called when the user presses the Next button on this page.
		/// </summary>
		/// <returns>Returns true if the wizard is allowed to navigate away from this page; false to stay on this page.</returns>
		bool OnNext();

		/// <summary>
		/// This method is called when the user presses the Finish button on this page.
		/// </summary>
		/// <returns>Returns true if the wizard is allowed to finish; false to keep the wizard active and stay on this page.</returns>
		bool OnFinish();
	}
}
