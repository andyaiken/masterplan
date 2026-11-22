using Masterplan.Tools;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Masterplan.Extensibility
{
    /// <summary>
    /// The places where Masterplan's windows call INTO add-ins: building the Add-Ins menus, running a
    /// command, and refreshing add-in pages. Shared by MainForm and CombatForm.
    /// (UI/QuickReferenceForm also shows add-in reference pages, but nothing in Masterplan opens that
    /// window at the moment; if it is ever used again, note that an IPage's Control can only be in one
    /// window at a time, so it must be given back to MainForm's tab when that window closes.)
    /// </summary>
    /// <remarks>
    /// WHY THIS EXISTS (for new developers):
    /// Add-ins are other people's code. If one throws an exception while Masterplan asks for its menu
    /// items or refreshes its page, that must not break Masterplan's own menu or screen. So every call
    /// into an add-in here is made inside its own try: a failing add-in is logged and skipped, and the
    /// others (and Masterplan) carry on. A command that fails when clicked is also shown to the user.
    /// (MainForm and CombatForm used to have two copies of this code without that protection; both
    /// also put the "(no commands)" item in the wrong menu, and CombatForm checked the wrong list.)
    /// </remarks>
    internal static class AddInHost
    {
        /// <summary>
        /// Fills an "Add-Ins" menu: one submenu per add-in, holding its commands (or "(no commands)"),
        /// or "(none)" if no add-ins are loaded.
        /// </summary>
        /// <param name="menu">The Add-Ins menu item to fill (its items are replaced).</param>
        /// <param name="combat">True for the combat screen (the add-ins' CombatCommands), false for the
        /// main window (Commands).</param>
        /// <param name="owner">The window the menu belongs to (owns the message if a command fails).</param>
        public static void FillMenu(ToolStripMenuItem menu, bool combat, IWin32Window owner)
        {
            menu.DropDownItems.Clear();

            foreach (IAddIn addin in Session.AddIns)
            {
                try
                {
                    ToolStripMenuItem addin_item = new ToolStripMenuItem(addin.Name);
                    addin_item.ToolTipText = TextHelper.Wrap(addin.Description);
                    addin_item.Tag = addin;

                    List<ICommand>? commands = combat ? addin.CombatCommands : addin.Commands;
                    if (commands != null)
                    {
                        foreach (ICommand command in commands)
                        {
                            ToolStripMenuItem command_item = new ToolStripMenuItem(command.Name);
                            command_item.ToolTipText = TextHelper.Wrap(command.Description);
                            command_item.Enabled = command.Available;
                            command_item.Checked = command.Active;
                            command_item.Tag = command;
                            command_item.Click += (sender, e) => RunCommand(command, owner);

                            addin_item.DropDownItems.Add(command_item);
                        }
                    }

                    // Under THIS add-in's submenu (it used to be added to the top-level menu).
                    if (addin_item.DropDownItems.Count == 0)
                    {
                        ToolStripItem none = addin_item.DropDownItems.Add("(no commands)");
                        none.Enabled = false;
                    }

                    menu.DropDownItems.Add(addin_item);
                }
                catch (Exception ex)
                {
                    LogSystem.Trace("Add-ins: the menu of '" + SafeName(addin) + "' could not be built:");
                    LogSystem.Trace(ex);
                }
            }

            if (menu.DropDownItems.Count == 0)
            {
                ToolStripItem none = menu.DropDownItems.Add("(none)");
                none.Enabled = false;
            }
        }

        /// <summary>
        /// Runs an add-in command. If it throws, the user is told and the details are logged.
        /// </summary>
        public static void RunCommand(ICommand command, IWin32Window? owner)
        {
            try
            {
                command.Execute();
            }
            catch (Exception ex)
            {
                LogSystem.Trace("Add-ins: the command '" + command.Name + "' failed:");
                LogSystem.Trace(ex);
                MessageBox.Show(owner, "The add-in command '" + command.Name + "' failed:" + Environment.NewLine + Environment.NewLine
                    + ex.Message + Environment.NewLine + Environment.NewLine + "See the log file for details, and contact the add-in's developer.",
                    "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Calls UpdateView on every add-in page selected by <paramref name="pages"/> (e.g. a => a.Pages or
        /// a => a.QuickReferencePages). An add-in whose page throws is logged and skipped.
        /// </summary>
        public static void UpdatePages(Func<IAddIn, List<IPage>> pages)
        {
            foreach (IAddIn addin in Session.AddIns)
            {
                try
                {
                    List<IPage>? list = pages(addin);
                    if (list == null)
                        continue;

                    foreach (IPage page in list)
                        page.UpdateView();
                }
                catch (Exception ex)
                {
                    LogSystem.Trace("Add-ins: a page of '" + SafeName(addin) + "' could not be refreshed:");
                    LogSystem.Trace(ex);
                }
            }
        }

        /// <summary>The add-in's name for messages, even if its Name property itself throws.</summary>
        private static string SafeName(IAddIn addin)
        {
            try
            {
                return addin.Name ?? addin.GetType().FullName ?? "add-in";
            }
            catch
            {
                return addin.GetType().FullName ?? "add-in";
            }
        }
    }
}
