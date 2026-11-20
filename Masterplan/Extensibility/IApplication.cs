#nullable disable

using Masterplan.Data;
using System.Collections.Generic;

namespace Masterplan.Extensibility
{
    /// <summary>
    /// Masterplan's interface for add-ins, given to <see cref="IAddIn.Initialise"/>: the current
    /// project, encounter and libraries, and ways to refresh the view and save a library.
    /// </summary>
    /// <remarks>
    /// Use it only on the UI thread (Masterplan calls add-ins on the UI thread).
    /// The data classes it returns (<see cref="Masterplan.Data.Project"/>, <see cref="Masterplan.Data.Encounter"/>, <see cref="Masterplan.Data.Library"/>,
    /// ...) are Masterplan's own and may change between versions, so rebuild add-ins for new versions.
    /// </remarks>
    public interface IApplication
    {
        /// <summary>
        /// The open project, or null if none is open. Read it each time you need it: the user can open,
        /// close or switch projects at any time.
        /// </summary>
        /// <remarks>
        /// Setting it replaces the open project without asking to save the current one; call
        /// <see cref="UpdateView"/> afterwards. To keep your own data in the project, use
        /// <see cref="Masterplan.Data.Project.AddInData"/> (keys prefixed with your add-in's name) and set
        /// <see cref="ProjectModified"/> to true.
        /// </remarks>
        Project Project { get; set; }

        /// <summary>
        /// The plot point selected in the main window's plot view, or null if none is selected.
        /// </summary>
        PlotPoint SelectedPoint { get; }

        /// <summary>
        /// The encounter being run in the combat screen, or null when no combat screen is open.
        /// </summary>
        Encounter CurrentEncounter { get; }

        /// <summary>
        /// The full path of the open project's file (.mpxplan), or an empty string if the project has
        /// not been saved yet.
        /// </summary>
        string ProjectFile { get; set; }

        /// <summary>
        /// True if the open project has unsaved changes. Set it to true after changing the project, so
        /// Masterplan asks the user to save it.
        /// </summary>
        bool ProjectModified { get; set; }

        /// <summary>
        /// The libraries currently loaded (from the Libraries folder beside Masterplan.exe).
        /// Do not add or remove items in this list.
        /// </summary>
        List<Library> Libraries { get; }

        /// <summary>
        /// The add-ins currently loaded, including this one. Do not add or remove items in this list.
        /// </summary>
        List<IAddIn> AddIns { get; }

        /// <summary>
        /// Asks Masterplan to refresh its main window (and the add-ins' pages) after the add-in has
        /// changed the project.
        /// </summary>
        void UpdateView();

        /// <summary>
        /// Saves a library the add-in has changed, as <c>&lt;Libraries folder&gt;\&lt;library name&gt;.mpxlib</c>.
        /// </summary>
        /// <param name="lib">One of the loaded <see cref="Libraries"/>.</param>
        void SaveLibrary(Library lib);
    }
}
