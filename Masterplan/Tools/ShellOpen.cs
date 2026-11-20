using System;
using System.Diagnostics;
using System.IO;

namespace Masterplan.Tools
{
    /// <summary>
    /// Opens a file or folder the way double-clicking it in Explorer would: a .pdf in the PDF reader,
    /// an .htm file in the web browser, a folder in Explorer, and so on.
    /// </summary>
    /// <remarks>
    /// WHY THIS EXISTS (for new developers):
    /// In .NET Framework, Process.Start("C:\...\Manual.pdf") opened the file with its program,
    /// because ProcessStartInfo.UseShellExecute defaulted to TRUE. In .NET Core / .NET 5+ (and so in
    /// .NET 10) it defaults to FALSE, which means "run this file as a program". A .pdf, .htm or a
    /// folder is not a program, so the call throws (Win32Exception) and nothing opens.
    /// The fix is to set UseShellExecute = true, which hands the path to the Windows shell.
    /// Use ShellOpen.Open(path) instead of Process.Start(path) whenever you open a document or folder.
    /// </remarks>
    public static class ShellOpen
    {
        /// <summary>
        /// Opens <paramref name="path"/> with its default Windows program.
        /// Never throws: a missing path or a failure is written to the log and false is returned,
        /// so a caller that does not care can simply ignore the result.
        /// </summary>
        /// <param name="path">Full path of a file or folder.</param>
        /// <returns>True if Windows was asked to open it; false if it does not exist or failed.</returns>
        public static bool Open(string? path)
        {
            if (string.IsNullOrEmpty(path) || (!File.Exists(path) && !Directory.Exists(path)))
            {
                LogSystem.Trace("ShellOpen: nothing to open at '" + path + "'");
                return false;
            }

            try
            {
                ProcessStartInfo info = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true // open with the associated program (see remarks above)
                };

                // Process.Start may return null when an already-running program (e.g. the browser)
                // takes the file; that still counts as success. We do not keep the Process object.
                using (Process.Start(info))
                {
                }

                return true;
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
                return false;
            }
        }
    }
}
