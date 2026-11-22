#nullable disable

using System.Windows.Forms;

namespace Masterplan.Extensibility
{
    /// <summary>
    /// A tab supplied by an add-in (see <see cref="IAddIn.Pages"/> and
    /// <see cref="IAddIn.QuickReferencePages"/>).
    /// </summary>
    public interface IPage
    {
        /// <summary>
        /// The tab's title.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The control shown in the tab; Masterplan docks it to fill the tab.
        /// </summary>
        /// <remarks>
        /// Create it once and always return the same instance: Masterplan adds it to its tab at
        /// start-up, and a WinForms control can only be in one place at a time.
        /// </remarks>
        Control Control { get; }

        /// <summary>
        /// Called whenever Masterplan refreshes its view (for example after a project is opened or
        /// changed): update the control from the current project here. If it throws, the error is
        /// logged and Masterplan carries on.
        /// </summary>
        void UpdateView();
    }
}
