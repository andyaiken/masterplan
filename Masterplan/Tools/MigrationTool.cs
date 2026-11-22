using Masterplan.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// What the migration tool produced, worked out by Masterplan after the tool has closed.
    /// </summary>
    public class MigrationResult
    {
        /// <summary>New libraries found in the Libraries folder and loaded.</summary>
        public List<Library> LoadedLibraries { get; } = new List<Library>();

        /// <summary>Full paths of the .mpxplan files now present for the old .masterplan files the
        /// user asked to convert (the tool writes each one beside its original).</summary>
        public List<string> ConvertedProjects { get; } = new List<string>();

        /// <summary>Full paths of .mpxlib files converted OUTSIDE the Libraries folder (an old
        /// .library picked elsewhere in Libraries > File > Open). They are not loaded automatically;
        /// the user adds them with File > Open, which offers to copy them into the Libraries folder.</summary>
        public List<string> ConvertedLibrariesElsewhere { get; } = new List<string>();
    }

    /// <summary>
    /// Finds and starts the separate "MasterplanXP Migration Tool" tool, which converts old
    /// Masterplan files (.library / .masterplan) to the M14 formats (.mpxlib / .mpxplan).
    /// </summary>
    /// <remarks>
    /// HOW IT FITS TOGETHER (for new developers):
    /// M14 runs on .NET 10, which cannot read the old BinaryFormatter files at all (see LegacyFiles).
    /// The migration tool is a separate program (Avalonia, .NET 8, published self-contained) that is
    /// shipped in the "MigrationTool" subfolder next to Masterplan.exe. It is started:
    ///   - by the Convert button in the Libraries window, and
    ///   - by answering Yes to "Convert now?" in the old-files message (LegacyFiles.ShowSkipped).
    /// The folder to convert is passed on the command line, so the tool opens with the old files in
    /// that folder already listed; the user stages them and clicks Migrate. The tool writes each
    /// converted file beside the original.
    /// Masterplan stays usable while the tool runs. When the tool closes, any new .mpxlib in the
    /// Libraries folder is loaded straight away (no restart needed), the .mpxplan of each old project
    /// the user asked to convert is looked for, and the user is told what was converted
    /// (MigrationResult). The caller's callback can then act on it; MainForm opens a converted project
    /// automatically, the Libraries window refreshes its list.
    /// </remarks>
    public static class MigrationTool
    {
        /// <summary>The tool's exe file name.</summary>
        public const string ExeName = "MasterplanXP.MigrationTool.exe";

        /// <summary>The subfolder (next to Masterplan.exe) the release ships the tool in.</summary>
        public const string SubFolder = "MigrationTool";

        /// <summary>
        /// The tool's exe, or null if it cannot be found. Looks, in order, at:
        /// the path the user chose earlier (Preferences.MigrationToolPath),
        /// &lt;exe folder&gt;\MigrationTool\, and the exe folder itself.
        /// </summary>
        public static string? Find()
        {
            string? saved = Session.Preferences?.MigrationToolPath;
            if (!string.IsNullOrEmpty(saved) && File.Exists(saved))
                return saved;

            string[] candidates =
            {
                Path.Combine(AppPaths.AppFolder, SubFolder, ExeName),
                Path.Combine(AppPaths.AppFolder, ExeName),
            };

            return candidates.FirstOrDefault(File.Exists);
        }

        /// <summary>
        /// Starts the migration tool on <paramref name="folder"/>. If the tool cannot be found, the user
        /// is offered a file picker to locate it (the choice is remembered). Never throws: problems are
        /// shown to the user and logged.
        /// </summary>
        /// <param name="owner">Window that owns the messages (may be null).</param>
        /// <param name="folder">Folder whose old files the tool should list; null or missing = none.</param>
        /// <param name="requestedFiles">Optional: the old files the user wants converted (e.g. the
        /// .masterplan they tried to open). After the tool closes, Masterplan checks which of the
        /// projects among them now have a .mpxplan. A copy is kept, so the caller may clear its list.</param>
        /// <param name="onFinished">Optional: called on the UI thread after the tool has closed and
        /// the user has seen the summary, with what was converted.</param>
        /// <returns>True if the tool was started.</returns>
        public static bool Launch(IWin32Window? owner, string? folder, IEnumerable<string>? requestedFiles = null,
            Action<MigrationResult>? onFinished = null)
        {
            string? exe = FindOrAsk(owner);
            if (exe == null)
                return false;

            // Our own copy: e.g. the startup list (Session.SkippedLegacyFiles) is cleared right after
            // the message is shown, long before the tool closes.
            List<string> requested = (requestedFiles ?? Enumerable.Empty<string>()).ToList();

            // The Libraries folder message only makes sense when the tool was opened on that folder.
            bool librariesFolder = false;
            try
            {
                librariesFolder = !string.IsNullOrEmpty(folder)
                    && string.Equals(Path.GetFullPath(folder).TrimEnd('\\'), Path.GetFullPath(Session.LibraryFolder).TrimEnd('\\'),
                                     StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex); // a malformed path: just treat it as "not the Libraries folder"
            }

            try
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = exe,
                    UseShellExecute = false,
                    WorkingDirectory = Path.GetDirectoryName(exe) ?? ""
                };

                // ArgumentList quotes the path correctly (spaces, trailing backslash).
                if (!string.IsNullOrEmpty(folder) && Directory.Exists(folder))
                    info.ArgumentList.Add(folder);

                Process? process = Process.Start(info);
                if (process == null)
                    throw new InvalidOperationException("The process did not start.");

                LogSystem.Trace("MigrationTool: started " + exe + " on " + (folder ?? "(no folder)"));

                // Exited is raised on a background thread; the follow-up work (loading libraries,
                // messages, refreshing windows) must run on the UI thread, so it is handed to the main
                // window with BeginInvoke. The main window exists for the app's whole lifetime.
                process.EnableRaisingEvents = true;
                process.Exited += (sender, e) =>
                {
                    process.Dispose();
                    try
                    {
                        Form? ui = Session.MainForm;
                        if (ui != null && ui.IsHandleCreated && !ui.IsDisposed)
                            ui.BeginInvoke((Action)(() => OnToolClosed(owner, requested, librariesFolder, onFinished)));
                    }
                    catch (Exception ex)
                    {
                        LogSystem.Trace(ex); // app is closing
                    }
                };

                return true;
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
                MessageBox.Show(GetOwner(owner), LegacyFiles.MigrationApp + " could not be started:" + Environment.NewLine
                    + ex.Message, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Find(), or, if the tool is not found, asks the user to locate it and remembers the choice.
        /// Returns null if the user does not locate it.
        /// </summary>
        private static string? FindOrAsk(IWin32Window? owner)
        {
            string? exe = Find();
            if (exe != null)
                return exe;

            string msg = LegacyFiles.MigrationApp + " was not found." + Environment.NewLine + Environment.NewLine
                + "It is normally in the \"" + SubFolder + "\" folder next to Masterplan." + Environment.NewLine
                + "Do you want to locate " + ExeName + " now?";
            if (MessageBox.Show(GetOwner(owner), msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return null;

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Locate " + LegacyFiles.MigrationApp;
                dlg.Filter = LegacyFiles.MigrationApp + "|" + ExeName + "|Programs (*.exe)|*.exe";
                if (dlg.ShowDialog(GetOwner(owner)) != DialogResult.OK)
                    return null;

                if (Session.Preferences != null)
                    Session.Preferences.MigrationToolPath = dlg.FileName; // saved with the other preferences

                return dlg.FileName;
            }
        }

        /// <summary>
        /// Runs on the UI thread after the tool has closed: loads new libraries, finds converted
        /// projects, tells the user what was converted, then calls the caller's callback.
        /// </summary>
        /// <param name="owner">The window that started the tool (messages belong to it if it is still open).</param>
        /// <param name="requested">The old files the user asked to convert (may be empty).</param>
        /// <param name="librariesFolder">True if the tool was opened on the Libraries folder.</param>
        /// <param name="onFinished">The caller's callback; if given, it is expected to open a
        /// converted project itself, so the message does not tell the user to look for it.</param>
        private static void OnToolClosed(IWin32Window? owner, List<string> requested, bool librariesFolder,
            Action<MigrationResult>? onFinished)
        {
            try
            {
                MigrationResult result = new MigrationResult();
                result.LoadedLibraries.AddRange(LoadNewLibraries());

                // The old files the user asked to convert: the tool writes Name.mpxplan / Name.mpxlib
                // beside each one (the old .library itself is then moved into LibraryArchive).
                foreach (string file in requested)
                {
                    if (!Path.IsPathRooted(file))
                        continue;

                    if (LegacyFiles.IsLegacyProject(file))
                    {
                        string mpx = Path.ChangeExtension(file, LegacyFiles.ProjectExtension);
                        if (File.Exists(mpx))
                            result.ConvertedProjects.Add(mpx);
                    }
                    else if (LegacyFiles.IsLegacyLibrary(file))
                    {
                        // Libraries in the Libraries folder were just loaded (LoadNewLibraries); report
                        // only the ones converted somewhere else.
                        string mpx = Path.ChangeExtension(file, LegacyFiles.LibraryExtension);
                        bool inLibrariesFolder = string.Equals(Path.GetDirectoryName(Path.GetFullPath(mpx))?.TrimEnd('\\'),
                            Path.GetFullPath(Session.LibraryFolder).TrimEnd('\\'), StringComparison.OrdinalIgnoreCase);
                        if (!inLibrariesFolder && File.Exists(mpx))
                            result.ConvertedLibrariesElsewhere.Add(mpx);
                    }
                }

                string nl = Environment.NewLine;
                List<string> parts = new List<string>();

                if (result.LoadedLibraries.Count != 0)
                {
                    int n = result.LoadedLibraries.Count;
                    string part = (n == 1) ? "1 converted library was loaded:" + nl : n + " converted libraries were loaded:" + nl;
                    foreach (Library lib in result.LoadedLibraries.Take(10))
                        part += "    " + lib.Name + nl;
                    if (n > 10)
                        part += "    ...and " + (n - 10) + " more" + nl;
                    parts.Add(part.TrimEnd());
                }

                if (result.ConvertedLibrariesElsewhere.Count != 0)
                {
                    string part = "Converted outside the Libraries folder (not loaded yet):" + nl;
                    foreach (string mpx in result.ConvertedLibrariesElsewhere)
                        part += "    " + mpx + nl;
                    part += "Add them with Libraries > File > Open.";
                    parts.Add(part.TrimEnd());
                }

                if (result.ConvertedProjects.Count != 0)
                {
                    string part = (result.ConvertedProjects.Count == 1) ? "Converted project:" + nl : "Converted projects:" + nl;
                    foreach (string mpx in result.ConvertedProjects)
                        part += "    " + Path.GetFileName(mpx) + nl;

                    // With a callback, the caller opens the project itself (MainForm); otherwise
                    // (e.g. an import screen) the user picks it again.
                    part += (onFinished != null)
                        ? "It will be opened now."
                        : "Choose the converted " + LegacyFiles.ProjectExtension + " file to use it.";
                    parts.Add(part.TrimEnd());
                }

                if (parts.Count == 0)
                {
                    parts.Add(librariesFolder
                        ? "No new converted libraries were found in the Libraries folder."
                        : "No files were converted.");
                }

                MessageBox.Show(GetOwner(owner), string.Join(nl + nl, parts), "Masterplan",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                onFinished?.Invoke(result);
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        /// <summary>
        /// Loads every .mpxlib in the Libraries folder that is not loaded yet (the tool has just written
        /// them). Same steps as File > Open in the Libraries window. Returns the libraries loaded.
        /// </summary>
        private static List<Library> LoadNewLibraries()
        {
            List<Library> loaded = new List<Library>();

            string folder = Session.LibraryFolder;
            if (!Directory.Exists(folder))
                return loaded;

            foreach (string file in Directory.GetFiles(folder, "*" + LegacyFiles.LibraryExtension).OrderBy(f => f, StringComparer.OrdinalIgnoreCase))
            {
                // A library's Name is its file name without the extension (see Session.LoadLibrary).
                if (Session.FindLibrary(FileName.Name(file)) != null)
                    continue; // already loaded

                Library lib = Session.LoadLibrary(file);
                if (lib != null)
                    loaded.Add(lib);
            }

            if (loaded.Count != 0)
            {
                if (Session.Project != null)
                    Session.Project.SimplifyProjectLibrary();

                Session.Libraries.Sort();
            }

            return loaded;
        }

        /// <summary>The window to own messages: the caller's window if it is still open, otherwise the main window.</summary>
        private static IWin32Window? GetOwner(IWin32Window? owner)
        {
            if (owner is Control control && !control.IsDisposed)
                return owner;

            return Session.MainForm;
        }
    }
}
