#nullable disable

using System;
using System.IO;

namespace Masterplan.Tools
{
    /// <summary>
    /// Where Masterplan's own folder is (the folder holding Masterplan.exe), and the files and
    /// folders that live inside it (Libraries, Backup, Log, AddIns, Preferences.xml, ...).
    /// </summary>
    /// <remarks>
    /// WHY THIS EXISTS (for new developers):
    /// The older code found the exe's folder in several different ways, mostly with
    /// Assembly.GetEntryAssembly().Location. When the app is published as a SINGLE FILE (all DLLs
    /// packed inside Masterplan.exe), Location is an empty string. FileName.Directory("") also
    /// returns "", so "Libraries\" became a path relative to the CURRENT folder - whatever folder
    /// Windows started the app in (e.g. the folder of a .mpxplan file that was double-clicked).
    /// Libraries, backups and preferences would then be read and saved in the wrong place, with no
    /// error shown.
    ///
    /// AppContext.BaseDirectory is the .NET-recommended replacement: it is the exe's folder whether
    /// or not the app is a single file, and it is the test project's output folder when the
    /// automated tests run.
    ///
    /// RULES:
    ///   - Always use AppPaths to find the exe's folder; do not use Assembly.Location,
    ///     Application.StartupPath or Application.ExecutablePath for it.
    ///   - Do NOT enable "IncludeAllContentForSelfExtract" when publishing. With it, BaseDirectory
    ///     becomes a temporary extraction folder, and libraries and backups would be saved there.
    ///     ("IncludeNativeLibrariesForSelfExtract" is fine: it does not change BaseDirectory.)
    ///   - Embedded resources (GetManifestResourceStream) and the version/attributes read from the
    ///     assembly work the same in single-file mode, so those do not need AppPaths.
    /// </remarks>
    internal static class AppPaths
    {
        /// <summary>
        /// The exe's folder, always ending in a path separator (the same form FileName.Directory
        /// returns), so existing code can keep writing AppPaths.AppFolder + "Libraries\\".
        /// </summary>
        public static string AppFolder { get; } = WithSeparator(AppContext.BaseDirectory);

        /// <summary>
        /// The full path of a file or folder directly inside the exe's folder,
        /// e.g. AppPaths.InAppFolder("AddIns") or AppPaths.InAppFolder("Preferences.xml").
        /// </summary>
        /// <remarks>The result has no trailing separator; add one if the caller needs it.</remarks>
        public static string InAppFolder(string name)
        {
            return Path.Combine(AppFolder, name);
        }

        /// <summary>Adds a trailing path separator if the folder does not already end with one.</summary>
        static string WithSeparator(string folder)
        {
            if (string.IsNullOrEmpty(folder))
                return "";

            string separator = Path.DirectorySeparatorChar.ToString();
            return folder.EndsWith(separator) ? folder : folder + separator;
        }
    }
}
