#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// One place for everything to do with the OLD (pre-M14) Masterplan file formats.
    /// </summary>
    /// <remarks>
    /// BACKGROUND FOR NEW DEVELOPERS:
    /// Masterplan 12 saved libraries (.library) and projects (.masterplan) with .NET's BinaryFormatter.
    /// BinaryFormatter was removed from .NET 9 and later: every call throws PlatformNotSupportedException.
    /// M14 runs on .NET 10, so it cannot read those files at all. It reads and writes only the
    /// MessagePack formats:
    ///     .mpxlib   = library
    ///     .mpxplan  = project
    /// Old files are converted by a separate tool, "MasterplanXP Migration Tool", which writes the
    /// new file next to the old one (same folder, same name, new extension). It never overwrites an
    /// existing .mpxlib / .mpxplan. After a library converts, the tool moves the old .library into a
    /// "LibraryArchive" subfolder (which M14 does not scan); old projects are left where they are.
    ///
    /// RULES:
    ///   - M14 never modifies or deletes old files while loading. It skips them and tells the user to
    ///     convert them. (The only exception: when the user explicitly deletes or renames a library,
    ///     the old .library beside it is deleted too, so it is not reported as unconverted later.)
    ///   - User messages must name the migration tool (MigrationApp), not an older Masterplan version.
    /// </remarks>
    static class LegacyFiles
    {
        /// <summary>The name of the tool users must run to convert old files.</summary>
        public const string MigrationApp = "MasterplanXP Migration Tool";

        /// <summary>Extension of the old BinaryFormatter library format.</summary>
        public const string LegacyLibraryExtension = ".library";

        /// <summary>Extension of the old BinaryFormatter project format.</summary>
        public const string LegacyProjectExtension = ".masterplan";

        /// <summary>Extension of the current MessagePack library format.</summary>
        public const string LibraryExtension = ".mpxlib";

        /// <summary>Extension of the current MessagePack project format.</summary>
        public const string ProjectExtension = ".mpxplan";

        /// <summary>Most file names listed in one message; the rest are summarised as "...and N more".</summary>
        const int MaxListedFiles = 10;

        /// <summary>True if the path has the old library extension (.library).</summary>
        public static bool IsLegacyLibrary(string path)
        {
            return HasExtension(path, LegacyLibraryExtension);
        }

        /// <summary>True if the path has the old project extension (.masterplan).</summary>
        public static bool IsLegacyProject(string path)
        {
            return HasExtension(path, LegacyProjectExtension);
        }

        /// <summary>True if the path has either old extension.</summary>
        public static bool IsLegacy(string path)
        {
            return IsLegacyLibrary(path) || IsLegacyProject(path);
        }

        /// <summary>
        /// Shows one message listing old-format files that were skipped, and asks whether to convert
        /// them now. Yes starts the migration tool on the folder of the first file (see MigrationTool).
        /// Does nothing if the list is null or empty, so callers can call it unconditionally.
        /// </summary>
        /// <param name="owner">The window the message belongs to (may be null).</param>
        /// <param name="files">Full paths (or names) of the skipped files.</param>
        /// <param name="onFinished">Optional: called after the migration tool closes, with what was
        /// converted (MigrationResult), so the calling window can refresh or open a converted project.
        /// Callers that pass it are expected to open a converted project themselves.</param>
        public static void ShowSkipped(IWin32Window owner, IList<string> files, Action<MigrationResult> onFinished = null)
        {
            if ((files == null) || (files.Count == 0))
                return;

            string msg = (files.Count == 1)
                ? "This file uses the old Masterplan file format and could not be opened:"
                : "These files use the old Masterplan file format and could not be opened:";
            msg += Environment.NewLine + Environment.NewLine;

            int listed = Math.Min(files.Count, MaxListedFiles);
            for (int n = 0; n != listed; ++n)
                msg += "    " + Path.GetFileName(files[n]) + Environment.NewLine;

            if (files.Count > listed)
                msg += "    ...and " + (files.Count - listed) + " more" + Environment.NewLine;

            msg += Environment.NewLine;
            msg += MigrationApp + " converts old files to the new " + LibraryExtension + " / " + ProjectExtension;
            msg += " format, writing each converted file next to the old one. Converted old libraries are";
            msg += " then moved into a LibraryArchive folder; old projects are left where they are.";
            msg += Environment.NewLine + Environment.NewLine;
            msg += (files.Count == 1) ? "Convert it now?" : "Convert them now?";

            if (MessageBox.Show(owner, msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // The tool works on ONE folder. Use the folder of the first old PROJECT if there is one
            // (the project is what the user was trying to open; at startup the list can also contain
            // old libraries, which are in the Libraries folder and can be converted later with the
            // Convert button), otherwise the folder of the first file (the Libraries folder for old
            // libraries). A bare file name (no folder) falls back to the Libraries folder.
            string first = files.FirstOrDefault(f => IsLegacyProject(f) && Path.IsPathRooted(f)) ?? files[0];
            string folder = Path.IsPathRooted(first) ? Path.GetDirectoryName(first) : Session.LibraryFolder;

            // The files are passed on so that, after the tool closes, Masterplan can tell which of
            // the requested projects were converted (and the caller can open it).
            MigrationTool.Launch(owner, folder, files, onFinished);
        }

        static bool HasExtension(string path, string extension)
        {
            if (string.IsNullOrEmpty(path))
                return false;

            return string.Equals(Path.GetExtension(path), extension, StringComparison.OrdinalIgnoreCase);
        }
    }
}
