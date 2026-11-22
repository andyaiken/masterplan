#nullable disable

using System;
using System.Collections.Generic;

namespace Masterplan.Extensibility
{
    /// <summary>
    /// The main interface of a Masterplan add-in. Implement it in a <c>public</c> class with a public
    /// parameterless constructor; Masterplan creates one instance at start-up.
    /// </summary>
    /// <remarks>
    /// <para><b>Installing:</b> copy the add-in into the <c>AddIns</c> folder beside Masterplan.exe,
    /// either as <c>AddIns\MyAddIn.dll</c> or, with its own dependencies, as <c>AddIns\MyAddIn\MyAddIn.dll</c>
    /// (only the DLL named like the folder is loaded as the add-in).</para>
    /// <para><b>Referencing Masterplan:</b> reference it with <c>Private=false</c>, so that no copy of
    /// Masterplan.dll ends up next to your add-in; the add-in must use the Masterplan that is running.</para>
    /// <para><b>Errors:</b> Masterplan calls into add-ins on the UI thread and contains failures: an
    /// exception thrown while loading, building a menu, refreshing a page or running a command is
    /// logged (in <c>Log\</c> beside Masterplan.exe) and the add-in is skipped for that call; the user is
    /// told when loading or a command fails.</para>
    /// <para>The properties are read again whenever Masterplan needs them (for example each time a menu
    /// opens), so they can change while Masterplan runs.</para>
    /// <para>A complete working example is <c>Masterplan.SampleAddIn</c> in the Masterplan repository.</para>
    /// </remarks>
    public interface IAddIn
    {
        /// <summary>
        /// Called once, after Masterplan has created the add-in at start-up. Create your commands and
        /// pages here and keep <paramref name="app"/> for later use.
        /// </summary>
        /// <param name="app">Masterplan's interface for add-ins: the current project, encounter,
        /// libraries, and a way to refresh the view or save a library.</param>
        /// <returns>True to be loaded; false to stay unloaded (for example when something the add-in
        /// needs is missing). Returning false is not reported as an error; throwing is.</returns>
        bool Initialise(IApplication app);

        /// <summary>
        /// The add-in's name: shown as its menu under Tools > Add-Ins. Must be unique among the
        /// installed add-ins; a second add-in with the same name is not loaded.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A short description of the add-in, shown as the tooltip of its menu.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The add-in's version.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Commands shown in the main window under Tools > Add-Ins > (<see cref="Name"/>).
        /// Return an empty list (not null) if there are none.
        /// </summary>
        List<ICommand> Commands { get; }

        /// <summary>
        /// Commands shown in the combat screen under Tools > Add-Ins > (<see cref="Name"/>). Use
        /// <see cref="IApplication.CurrentEncounter"/> to get the encounter being run.
        /// Return an empty list (not null) if there are none.
        /// </summary>
        List<ICommand> CombatCommands { get; }

        /// <summary>
        /// Pages shown as extra tabs in the main window. Added once, at start-up.
        /// Return an empty list (not null) if there are none.
        /// </summary>
        List<IPage> Pages { get; }

        /// <summary>
        /// Pages shown as extra tabs in the main window's reference panel. Added once, at start-up.
        /// Return an empty list (not null) if there are none.
        /// </summary>
        List<IPage> QuickReferencePages { get; }
    }
}
