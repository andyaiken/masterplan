#nullable disable

namespace Masterplan.Extensibility
{
    /// <summary>
    /// A menu item supplied by an add-in (see <see cref="IAddIn.Commands"/> and
    /// <see cref="IAddIn.CombatCommands"/>).
    /// </summary>
    /// <remarks>
    /// Masterplan reads <see cref="Name"/>, <see cref="Description"/>, <see cref="Available"/> and
    /// <see cref="Active"/> each time the menu opens, so they can change while Masterplan runs.
    /// </remarks>
    public interface ICommand
    {
        /// <summary>
        /// The menu item's text.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The menu item's tooltip.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// True if the menu item is enabled (for example: only while a project is open).
        /// </summary>
        bool Available { get; }

        /// <summary>
        /// True to show a tick next to the menu item (for a command that switches something on/off).
        /// </summary>
        bool Active { get; }

        /// <summary>
        /// Runs the command when the user clicks the menu item. If it throws, Masterplan shows the
        /// error to the user and logs it; Masterplan itself carries on.
        /// </summary>
        void Execute();
    }
}
