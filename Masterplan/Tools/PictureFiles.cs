#nullable disable

using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// Loading a picture file the user picked (creature/hero/tile pictures, map imports, ...).
    /// </summary>
    /// <remarks>
    /// Before 14.1.0.7 every picker called Image.FromFile directly, so picking a file that is not a
    /// usable picture (damaged, not an image, or open in another program) crashed Masterplan.
    /// The loading itself is unchanged (still Image.FromFile), so new pictures are still compressed
    /// when they are saved, exactly as before. (Do NOT use ImageCompression.Decode here: it remembers
    /// the file's bytes, so the picture would be saved back uncompressed.)
    ///
    /// On the M142 branch (M14.2) the converted pickers use StoredImages.FromFileOrWarn instead,
    /// with the same message.
    /// </remarks>
    public static class PictureFiles
    {
        /// <summary>
        /// Loads a picture file the USER picked. If the file cannot be used, this tells the user and
        /// returns null instead of throwing.
        /// </summary>
        /// <remarks>
        /// Callers must keep the old picture when this returns null (the user has already been told),
        /// and must not save or create anything.
        /// </remarks>
        /// <param name="owner">The window the message belongs to.</param>
        /// <param name="path">The file the user picked.</param>
        /// <returns>The picture, or null if the file is not a usable picture.</returns>
        public static Image LoadOrWarn(IWin32Window owner, string path)
        {
            try
            {
                return Image.FromFile(path);
            }
            catch (Exception ex) when (IsUnusableFile(ex))
            {
                LogSystem.Trace(ex);

                // One message for every cause: we cannot always tell which it is, and the user's next
                // step is the same. The formats listed are the ones Windows can read (most .tga files
                // offered by Program.ImageFilter cannot be read).
                string nl = Environment.NewLine;
                string msg = "The file '" + Path.GetFileName(path) + "' could not be used as a picture." + nl + nl
                           + "It may be damaged, not a valid image, or open in another program." + nl + nl
                           + "Please choose a different picture file (PNG, JPG, GIF or BMP).";
                MessageBox.Show(owner, msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        /// <summary>
        /// True for the exceptions Image.FromFile throws when a file is not a usable picture.
        /// </summary>
        /// <remarks>
        /// GDI+ reports "this is not a valid image" as an OutOfMemoryException (a long-standing GDI+
        /// quirk, not a real memory problem). The others mean the file could not be read: missing
        /// (FileNotFoundException is an IOException), locked by another program, no access, a bad path
        /// (ArgumentException) or another GDI+ error (ExternalException).
        /// </remarks>
        public static bool IsUnusableFile(Exception ex)
        {
            return (ex is OutOfMemoryException) || (ex is IOException) || (ex is UnauthorizedAccessException)
                || (ex is ArgumentException) || (ex is ExternalException);
        }
    }
}
