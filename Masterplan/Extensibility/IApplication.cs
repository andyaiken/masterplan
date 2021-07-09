using System.Collections.Generic;

using Masterplan.Data;

namespace Masterplan.Extensibility
{
	/// <summary>
	/// Interface through which an add-in can access the main editor form.
	/// </summary>
	public interface IApplication
	{
		/// <summary>
		/// Gets or sets the current project.
		/// </summary>
		Project Project { get; set; }

		/// <summary>
		/// Gets the currently selected plot point.
		/// </summary>
		PlotPoint SelectedPoint { get; }

		/// <summary>
		/// Gets the currently active encounter.
		/// </summary>
		Encounter CurrentEncounter { get; }

		/// <summary>
		/// Gets or sets the location of the current dataset file.
		/// </summary>
		string ProjectFile { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the dataset has been modified.
		/// </summary>
		bool ProjectModified { get; set; }

		/// <summary>
		/// Gets the list of currently loaded libraries.
		/// </summary>
		List<Library> Libraries { get; }

		/// <summary>
		/// Gets the list of currently installed add-ins.
		/// </summary>
		List<IAddIn> AddIns { get; }

		/// <summary>
		/// Prompts the application to reflect project in the UI.
		/// </summary>
		void UpdateView();

		/// <summary>
		/// Prompts the application to save changes to a given library.
		/// </summary>
		void SaveLibrary(Library lib);
	}
}
