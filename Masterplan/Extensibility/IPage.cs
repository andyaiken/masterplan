using System;
using System.Windows.Forms;

namespace Masterplan.Extensibility
{
	/// <summary>
	/// Interface for an add-in page.
	/// </summary>
	public interface IPage
	{
		/// <summary>
		/// Gets the name of the page.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the control to be shown on the new page.
		/// </summary>
		Control Control { get; }

		/// <summary>
		/// Sent by the application when the page should be updated.
		/// </summary>
		void UpdateView();
	}
}
