#nullable disable

using Masterplan.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// Copy and paste of Masterplan objects (library items, plot point elements, plot points,
    /// encyclopedia entries and notes) through the Windows clipboard.
    /// </summary>
    /// <remarks>
    /// WHY THE CLIPBOARD WORKS THIS WAY (background for new developers):
    /// Before M14 the code did Clipboard.SetData("Masterplan.Data.PlotPoint", point) and read it back
    /// with Clipboard.GetData(...) as PlotPoint. The clipboard can only hold bytes, so .NET silently
    /// turned the object into bytes with BinaryFormatter. BinaryFormatter is gone in .NET 10, so GetData
    /// could no longer rebuild the object: Paste did nothing or crashed, and Cut LOST the item (it was
    /// removed, but could never be pasted back).
    ///
    /// Now we do the conversion ourselves:
    ///   1. The object is turned into MessagePack bytes by LibraryConversionService (...ToBytes), using
    ///      exactly the same DTO mapping as the .mpxlib / .mpxplan files.
    ///   2. The bytes go on the clipboard as a MemoryStream. WinForms hands a stream to Windows as raw
    ///      bytes, with no serializer involved, so this works on .NET 10 - and also between two running
    ///      copies of Masterplan.
    ///   3. Paste reads the bytes back and converts them (...FromBytes).
    ///
    /// Each kind of object has its own clipboard FORMAT NAME (the constants below). That lets a Paste
    /// button be enabled only when there is something of its kind on the clipboard, without decoding it.
    ///
    /// RULES (please keep them when adding a new kind):
    ///   - Nothing in this class throws. Copy... returns false and Paste... returns null on any problem
    ///     (for example when another program has the clipboard locked).
    ///   - Cut must check the result of Copy... and only remove the item if it returned true.
    ///   - Paste handlers must null-check the result.
    /// </remarks>
    static class MasterplanClipboard
    {
        #region Format names

        // Library items (Libraries window). Copied as a small Library holding the items; build it with
        // ItemFiles.Wrap(...). Templates and themes share one format so they can be copied together.
        public const string Creatures = "Masterplan.mpx.Creatures";
        public const string TemplatesAndThemes = "Masterplan.mpx.TemplatesAndThemes";
        public const string Traps = "Masterplan.mpx.Traps";
        public const string SkillChallenges = "Masterplan.mpx.SkillChallenges";
        public const string MagicItems = "Masterplan.mpx.MagicItems";
        public const string Tiles = "Masterplan.mpx.Tiles";
        public const string TerrainPowers = "Masterplan.mpx.TerrainPowers";
        public const string Artifacts = "Masterplan.mpx.Artifacts";

        // Project objects (MainForm). Named ...Format so they are not confused with the PlotPoint,
        // EncyclopediaEntry and Note classes.
        // A plot point is copied as a BUNDLE (the plot point plus the maps, tiles and creatures it
        // refers to; see Tools/ClipboardBundle.cs). The name says "Bundle" so a copy made by an older
        // M14.1 build (plot point only) is not mistaken for one.
        public const string PlotPointFormat = "Masterplan.mpx.PlotPointBundle";
        public const string EncyclopediaEntryFormat = "Masterplan.mpx.EncyclopediaEntry";
        public const string NoteFormat = "Masterplan.mpx.Note";

        // Plot point elements (PlotPointForm) use one format per element type, built by ElementFormat():
        // "Masterplan.mpx.ElementBundle.Encounter", "...ElementBundle.SkillChallenge", and so on.
        // Elements are bundled too (with the maps, tiles and creatures they refer to).

        #endregion

        #region Checking

        /// <summary>
        /// True if the clipboard holds data under <paramref name="format"/> (one of the constants above).
        /// Cheap: it only checks the format name, it does not decode anything. Used for the Paste
        /// buttons' Enabled state.
        /// </summary>
        public static bool Has(string format)
        {
            try
            {
                return Clipboard.ContainsData(format);
            }
            catch (Exception ex)
            {
                // The clipboard can be temporarily locked by another program.
                LogSystem.Trace(ex);
                return false;
            }
        }

        #endregion

        #region Library items (Libraries window)

        /// <summary>
        /// Puts library items on the clipboard. <paramref name="container"/> is a small library holding
        /// the items (build it with ItemFiles.Wrap); <paramref name="format"/> says what kind they are.
        /// </summary>
        /// <returns>True if the items are on the clipboard.</returns>
        public static bool CopyLibraryItems(string format, Library container)
        {
            return CopyBytes(format, LibraryConversionService.Instance.LibraryToBytes(container));
        }

        /// <summary>
        /// Reads library items back from the clipboard.
        /// </summary>
        /// <returns>
        /// A small library holding the copied items, or null if there is nothing of that kind on the
        /// clipboard or it cannot be read.
        /// </returns>
        public static Library PasteLibraryItems(string format)
        {
            return LibraryConversionService.Instance.LibraryFromBytes(ReadBytes(format));
        }

        #endregion

        #region Plot point elements (PlotPointForm)

        // Encounter, SkillChallenge, TrapElement, Quest and MapElement. Copied as a ClipboardBundle:
        // the element plus the maps, tiles and creatures it refers to, so it can be pasted into
        // another project.

        /// <summary>The clipboard format for a plot point element type, e.g. "Masterplan.mpx.ElementBundle.Encounter".</summary>
        static string ElementFormat(Type element_type)
        {
            return "Masterplan.mpx.ElementBundle." + element_type.Name;
        }

        /// <summary>Puts a plot point's element on the clipboard.</summary>
        /// <returns>True if the element is on the clipboard (Cut must check this).</returns>
        public static bool CopyElement(IElement element)
        {
            if (element == null)
                return false;

            ClipboardBundle bundle = ClipboardBundle.ForElement(element);
            return CopyBytes(ElementFormat(element.GetType()), LibraryConversionService.Instance.BundleToBytes(bundle));
        }

        /// <summary>True if the clipboard holds a plot point element of type <typeparamref name="T"/>.</summary>
        public static bool HasElement<T>() where T : IElement
        {
            return Has(ElementFormat(typeof(T)));
        }

        /// <summary>
        /// Reads a plot point element of type <typeparamref name="T"/> from the clipboard.
        /// </summary>
        /// <remarks>
        /// When the element is returned, the maps, tiles and creatures it refers to are first added to
        /// the current project if it does not have them (see ClipboardBundle.MergeIntoProject).
        /// Note: they stay in the project even if the user then cancels the plot point form.
        /// </remarks>
        /// <returns>
        /// A new copy of the element (it keeps the original IDs, like the old clipboard did), or null.
        /// </returns>
        public static T PasteElement<T>() where T : class, IElement
        {
            ClipboardBundle bundle = LibraryConversionService.Instance.BundleFromBytes(ReadBytes(ElementFormat(typeof(T))));

            // "as T" also guards against a mismatch between the format name and the data inside.
            T element = (bundle != null) ? bundle.Element as T : null;
            if (element != null)
                merge(bundle);

            return element;
        }

        #endregion

        #region Plot points, encyclopedia entries and notes (MainForm)

        /// <summary>Puts a plot point (with its subplot, element, parcels and links) on the clipboard.</summary>
        /// <returns>True if the plot point is on the clipboard (Cut must check this).</returns>
        public static bool CopyPlotPoint(PlotPoint point)
        {
            if (point == null)
                return false;

            // The plot point travels with the maps, tiles and creatures it (and its subplots) refer to.
            ClipboardBundle bundle = ClipboardBundle.ForPlotPoint(point);
            return CopyBytes(PlotPointFormat, LibraryConversionService.Instance.BundleToBytes(bundle));
        }

        /// <summary>
        /// Reads a plot point from the clipboard; null if there is none or it cannot be read.
        /// When a plot point is returned, the maps, tiles and creatures it refers to have already been
        /// added to the current project if it did not have them.
        /// </summary>
        public static PlotPoint PastePlotPoint()
        {
            ClipboardBundle bundle = LibraryConversionService.Instance.BundleFromBytes(ReadBytes(PlotPointFormat));
            PlotPoint point = (bundle != null) ? bundle.PlotPoint : null;
            if (point != null)
                merge(bundle);

            return point;
        }

        /// <summary>
        /// Adds the bundle's maps, tiles and creatures that the current project is missing, and marks
        /// the project as modified if anything was added.
        /// </summary>
        static void merge(ClipboardBundle bundle)
        {
            try
            {
                if (bundle.MergeIntoProject())
                    Session.Modified = true;
            }
            catch (Exception ex)
            {
                // Never let a merge problem stop the paste itself; the item still pastes, just
                // without whatever could not be added.
                LogSystem.Trace(ex);
            }
        }

        /// <summary>Puts an encyclopedia entry (with its images) on the clipboard.</summary>
        /// <returns>True if the entry is on the clipboard (Cut must check this).</returns>
        public static bool CopyEncyclopediaEntry(EncyclopediaEntry entry)
        {
            return CopyBytes(EncyclopediaEntryFormat, LibraryConversionService.Instance.EncyclopediaEntryToBytes(entry));
        }

        /// <summary>Reads an encyclopedia entry from the clipboard; null if there is none or it cannot be read.</summary>
        public static EncyclopediaEntry PasteEncyclopediaEntry()
        {
            return LibraryConversionService.Instance.EncyclopediaEntryFromBytes(ReadBytes(EncyclopediaEntryFormat));
        }

        /// <summary>Puts a project note on the clipboard.</summary>
        /// <returns>True if the note is on the clipboard (Cut must check this).</returns>
        public static bool CopyNote(Note note)
        {
            return CopyBytes(NoteFormat, LibraryConversionService.Instance.NoteToBytes(note));
        }

        /// <summary>Reads a project note from the clipboard; null if there is none or it cannot be read.</summary>
        public static Note PasteNote()
        {
            return LibraryConversionService.Instance.NoteFromBytes(ReadBytes(NoteFormat));
        }

        #endregion

        #region Messages

        /// <summary>
        /// Warns that Cut did not remove the item because it could not be put on the clipboard.
        /// </summary>
        /// <param name="owner">The window the message belongs to.</param>
        /// <param name="what">What was being cut, e.g. "plot point".</param>
        public static void ShowCutFailed(IWin32Window owner, string what)
        {
            string msg = "The " + what + " could not be copied to the clipboard, so it has not been removed.";
            MessageBox.Show(owner, msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Low-level helpers

        // These only move raw bytes; what the bytes mean is decided by LibraryConversionService.

        /// <summary>
        /// Puts raw bytes on the clipboard under <paramref name="format"/>, replacing whatever was there.
        /// </summary>
        /// <returns>True if the bytes were put on the clipboard.</returns>
        static bool CopyBytes(string format, byte[] bytes)
        {
            if (bytes == null)
                return false;

            try
            {
                // A MemoryStream is handed to Windows as raw bytes; no serializer is involved.
                DataObject data = new DataObject();
                data.SetData(format, new MemoryStream(bytes));

                // copy: true = the data stays on the clipboard after Masterplan closes, so it can be
                // pasted into another copy of Masterplan started later.
                Clipboard.SetDataObject(data, true);
                return true;
            }
            catch (Exception ex)
            {
                // Typically: the clipboard is locked by another program.
                LogSystem.Trace(ex);
                return false;
            }
        }

        /// <summary>
        /// Reads the raw bytes stored under <paramref name="format"/> from the clipboard.
        /// </summary>
        /// <returns>The bytes, or null if there is nothing under that format or it cannot be read.</returns>
        static byte[] ReadBytes(string format)
        {
            try
            {
                IDataObject data = Clipboard.GetDataObject();
                if ((data == null) || !data.GetDataPresent(format))
                    return null;

                object raw = data.GetData(format);

                if (raw is Stream stream)
                {
                    // When copying and pasting inside the same Masterplan, Windows may hand back the very
                    // same MemoryStream object we stored, already read to the end by a previous Paste.
                    // Rewind it first, otherwise the second Paste would read zero bytes.
                    if (stream.CanSeek)
                        stream.Position = 0;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        return ms.ToArray();
                    }
                }

                if (raw is byte[] array)
                    return array;

                return null;
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
                return null;
            }
        }

        #endregion
    }
}
