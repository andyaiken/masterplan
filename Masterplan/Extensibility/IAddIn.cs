using System;
using System.Collections.Generic;

namespace Masterplan.Extensibility
{
	/// <summary>
	/// Interface implemented by add-ins.
	/// </summary>
	public interface IAddIn
	{
		/// <summary>
		/// Method which is called when the add-in is loaded into the editor.
		/// </summary>
		/// <param name="app">The Masterplan application interface</param>
		/// <returns>Returns true if the add-in initialised correctly; false otherwise.</returns>
		bool Initialise(IApplication app);

		/// <summary>
		/// Gets the name of the add-in.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the description of the add-in.
		/// </summary>
		string Description { get; }

		/// <summary>
		/// Gets the version number of the add-in.
		/// </summary>
		Version Version { get; }

		/// <summary>
		/// Gets the list of commands supplied by the add-in.
		/// </summary>
		List<ICommand> Commands { get; }

		/// <summary>
		/// Gets the list of combat commands supplied by the add-in.
		/// </summary>
		List<ICommand> CombatCommands { get; }

        /// <summary>
        /// Gets the list of tab pages supplied by the add-in.
        /// </summary>
        List<IPage> Pages { get; }

        /// <summary>
        /// Gets the list of quick reference tab pages supplied by the add-in.
        /// </summary>
        List<IPage> QuickReferencePages { get; }
    }
}
