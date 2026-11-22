#nullable disable

using Masterplan.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Masterplan.Tools
{
    /// <summary>
    /// Reads and writes the small "share" files: single-item exports (.mpxcreature, .mpxtrap, ...) and
    /// rules files (.mpxcrunch).
    /// </summary>
    /// <remarks>
    /// BACKGROUND FOR NEW DEVELOPERS:
    /// Before M14 each export file was one object written with .NET's BinaryFormatter (.creature,
    /// .trap, .crunch, ...). BinaryFormatter does not exist on .NET 10, so those files can be neither
    /// written nor read any more, and the "MasterplanXP Migration Tool" tool does NOT convert them
    /// (it only converts whole libraries and projects).
    ///
    /// HOW THE NEW FORMAT WORKS:
    ///   - A single-item file is simply a small LIBRARY that holds only the exported item(s). It is
    ///     written by exactly the same code as a .mpxlib (Library -> LibraryDto -> MessagePack, see
    ///     LibraryConversionService), only with a different extension. So:
    ///       * there is no extra DTO to maintain: a field added to a library DTO is exported too;
    ///       * importing just means "load the small library and copy its items across";
    ///       * the extension only tells the user (and the file dialog) what is inside.
    ///     Use the Wrap(...) helpers to build that one-item library.
    ///   - A rules file is a list of PlayerOptionDto (the same DTO a .mpxplan uses for its rules),
    ///     written by LibraryConversionService.SaveXRules.
    ///
    /// ERROR HANDLING RULES (please keep them when adding a new export/import):
    ///   - An export that fails must tell the user (ShowExportFailed). Never fail silently.
    ///   - An import must never crash on a bad file. Load the file with LoadForImport, skip it if it
    ///     returns null, and call ImportProblems.Show(...) once after the loop so the user learns which
    ///     files were skipped and why.
    /// </remarks>
    static class ItemFiles
    {
        #region Extensions

        // New (MessagePack) extensions. "mpx" marks the M14 / MasterplanXP family, like .mpxlib.
        public const string CreatureExtension = ".mpxcreature";
        public const string CreatureTemplateExtension = ".mpxcreaturetemplate";
        public const string ThemeExtension = ".mpxtheme";
        public const string TrapExtension = ".mpxtrap";
        public const string SkillChallengeExtension = ".mpxskillchallenge";
        public const string MagicItemExtension = ".mpxmagicitem";
        public const string ArtifactExtension = ".mpxartifact";
        public const string MapTileExtension = ".mpxmaptile";
        public const string TerrainPowerExtension = ".mpxterrainpower";
        public const string RulesExtension = ".mpxcrunch";

        // Heroes (M14.1). Both use the same layout (a list of heroes); the extension only tells the
        // user whether it holds one hero or a whole party. The import accepts either.
        public const string HeroExtension = ".mpxhero";
        public const string PartyExtension = ".mpxparty";

        /// <summary>
        /// The OLD BinaryFormatter extensions. Only used to recognise an old file the user picked
        /// (for example by typing its name or choosing "All files"), so they get a clear message
        /// instead of a generic "could not be read".
        /// </summary>
        static readonly string[] LegacyExtensions =
        {
            ".creature", ".creaturetemplate", ".theme", ".trap", ".skillchallenge",
            ".magicitem", ".artifact", ".maptile", ".terrainpower", ".crunch"
        };

        /// <summary>True if the file has one of the old BinaryFormatter single-item/rules extensions.</summary>
        public static bool IsLegacy(string filename)
        {
            string ext = Path.GetExtension(filename ?? "");
            foreach (string legacy in LegacyExtensions)
            {
                if (string.Equals(ext, legacy, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// True if the file name ends with the given extension (ignoring case).
        /// Use this instead of filename.EndsWith("...") so "Goblin.MPXCREATURE" also works.
        /// </summary>
        public static bool HasExtension(string filename, string extension)
        {
            return string.Equals(Path.GetExtension(filename ?? ""), extension, StringComparison.OrdinalIgnoreCase);
        }

        #endregion

        #region Single-item files (a small library)

        /// <summary>
        /// Writes a single-item file. <paramref name="container"/> is a small library holding only the
        /// item(s) to export; build it with one of the Wrap(...) helpers.
        /// </summary>
        /// <returns>True if the file was written.</returns>
        public static bool Save(string filename, Library container)
        {
            if (container == null)
                return false;

            // Same safe save as a .mpxlib (writes filename.tmp first, then swaps it in).
            return Serialisation<Library>.Save(filename, container, SerialisationMode.MessagePack);
        }

        /// <summary>
        /// Saves a single-item file and shows an error message if that fails.
        /// </summary>
        /// <param name="owner">The window that owns the message box.</param>
        /// <param name="filename">The file chosen in the Save dialog.</param>
        /// <param name="container">The small library to write (see Wrap).</param>
        /// <param name="what">What is being exported, for the message, e.g. "creature".</param>
        /// <returns>True if the file was written.</returns>
        public static bool Export(IWin32Window owner, string filename, Library container, string what)
        {
            bool ok = Save(filename, container);
            if (!ok)
                ShowExportFailed(owner, what);

            return ok;
        }

        /// <summary>
        /// Loads a single-item file for importing. Never throws.
        /// </summary>
        /// <param name="filename">The file chosen in the Open dialog.</param>
        /// <param name="problems">
        /// Collects the files that could not be loaded (old format, or unreadable) so the caller can
        /// report them all in one message after its loop.
        /// </param>
        /// <returns>The small library inside the file, or null if it could not be loaded.</returns>
        public static Library LoadForImport(string filename, ImportProblems problems)
        {
            if (IsLegacy(filename))
            {
                problems?.AddLegacy(filename);
                return null;
            }

            Library container = null;
            if (File.Exists(filename))
                container = Serialisation<Library>.Load(filename, SerialisationMode.MessagePack);

            if (container == null)
                problems?.AddUnreadable(filename);

            return container;
        }

        // ---------------------------------------------------------------------------------------
        // Wrap(...) helpers: build the one-item library that an export file contains.
        // The library name is only informational (it is not used when importing).
        // ---------------------------------------------------------------------------------------

        public static Library Wrap(Creature item)
        {
            Library lib = new Library { Name = item.Name };
            lib.Creatures.Add(item);
            return lib;
        }

        public static Library Wrap(CreatureTemplate item)
        {
            Library lib = new Library { Name = item.Name };
            lib.Templates.Add(item);
            return lib;
        }

        public static Library Wrap(MonsterTheme item)
        {
            Library lib = new Library { Name = item.Name };
            lib.Themes.Add(item);
            return lib;
        }

        public static Library Wrap(Trap item)
        {
            Library lib = new Library { Name = item.Name };
            lib.Traps.Add(item);
            return lib;
        }

        public static Library Wrap(SkillChallenge item)
        {
            Library lib = new Library { Name = item.Name };
            lib.SkillChallenges.Add(item);
            return lib;
        }

        public static Library Wrap(MagicItem item)
        {
            Library lib = new Library { Name = item.Name };
            lib.MagicItems.Add(item);
            return lib;
        }

        /// <summary>
        /// Magic items are exported as a "set": every level of the same item (e.g. Flaming Weapon
        /// +1 to +6) goes into one file.
        /// </summary>
        public static Library Wrap(string set_name, IEnumerable<MagicItem> items)
        {
            Library lib = new Library { Name = set_name };
            lib.MagicItems.AddRange(items);
            return lib;
        }

        public static Library Wrap(Artifact item)
        {
            Library lib = new Library { Name = item.Name };
            lib.Artifacts.Add(item);
            return lib;
        }

        public static Library Wrap(Tile item)
        {
            // Tiles have no name; ToString() gives the same text the export dialog suggests.
            Library lib = new Library { Name = item.ToString() };
            lib.Tiles.Add(item);
            return lib;
        }

        public static Library Wrap(TerrainPower item)
        {
            Library lib = new Library { Name = item.Name };
            lib.TerrainPowers.Add(item);
            return lib;
        }

        // ---------------------------------------------------------------------------------------
        // Multi-item Wrap(...) helpers, used by Copy in the Libraries window (several items can be
        // selected at once). Templates and themes share one container so they can be copied together.
        // ---------------------------------------------------------------------------------------

        public static Library Wrap(IEnumerable<Creature> items)
        {
            Library lib = new Library { Name = "Creatures" };
            lib.Creatures.AddRange(items);
            return lib;
        }

        public static Library Wrap(IEnumerable<CreatureTemplate> templates, IEnumerable<MonsterTheme> themes)
        {
            Library lib = new Library { Name = "Templates and themes" };
            lib.Templates.AddRange(templates);
            lib.Themes.AddRange(themes);
            return lib;
        }

        public static Library Wrap(IEnumerable<Trap> items)
        {
            Library lib = new Library { Name = "Traps" };
            lib.Traps.AddRange(items);
            return lib;
        }

        public static Library Wrap(IEnumerable<SkillChallenge> items)
        {
            Library lib = new Library { Name = "Skill challenges" };
            lib.SkillChallenges.AddRange(items);
            return lib;
        }

        public static Library Wrap(IEnumerable<MagicItem> items)
        {
            Library lib = new Library { Name = "Magic items" };
            lib.MagicItems.AddRange(items);
            return lib;
        }

        public static Library Wrap(IEnumerable<Artifact> items)
        {
            Library lib = new Library { Name = "Artifacts" };
            lib.Artifacts.AddRange(items);
            return lib;
        }

        public static Library Wrap(IEnumerable<Tile> items)
        {
            Library lib = new Library { Name = "Tiles" };
            lib.Tiles.AddRange(items);
            return lib;
        }

        public static Library Wrap(IEnumerable<TerrainPower> items)
        {
            Library lib = new Library { Name = "Terrain powers" };
            lib.TerrainPowers.AddRange(items);
            return lib;
        }

        #endregion

        // NOTE: the clipboard code that used to be here (copy/paste of library items and plot point
        // elements) moved to Tools/MasterplanClipboard.cs, which now also handles plot points,
        // encyclopedia entries and notes. The Wrap(...) helpers above are still used to build the small
        // library that library items are copied in.

        #region Rules files

        /// <summary>
        /// Saves the project's rules (player options) as a .mpxcrunch file.
        /// </summary>
        /// <returns>True if the file was written.</returns>
        public static bool SaveRules(string filename, List<IPlayerOption> rules)
        {
            // Serialisation routes List<IPlayerOption> to LibraryConversionService.SaveXRules and adds
            // the safe .tmp-then-swap step.
            return Serialisation<List<IPlayerOption>>.Save(filename, rules ?? new List<IPlayerOption>(), SerialisationMode.MessagePack);
        }

        /// <summary>
        /// Loads a .mpxcrunch rules file for importing. Never throws.
        /// </summary>
        /// <returns>The rules, or null if the file could not be loaded (recorded in <paramref name="problems"/>).</returns>
        public static List<IPlayerOption> LoadRulesForImport(string filename, ImportProblems problems)
        {
            if (IsLegacy(filename))
            {
                problems?.AddLegacy(filename);
                return null;
            }

            List<IPlayerOption> rules = null;
            if (File.Exists(filename))
                rules = Serialisation<List<IPlayerOption>>.Load(filename, SerialisationMode.MessagePack);

            if (rules == null)
                problems?.AddUnreadable(filename);

            return rules;
        }

        #endregion

        #region Hero and party files

        /// <summary>
        /// Saves one or more heroes as a .mpxhero (one hero) or .mpxparty (several) file.
        /// </summary>
        /// <returns>True if the file was written.</returns>
        public static bool SaveHeroes(string filename, IEnumerable<Hero> heroes)
        {
            List<Hero> list = new List<Hero>(heroes ?? new List<Hero>());

            // Serialisation routes List<Hero> to LibraryConversionService.SaveXHeroes and adds the safe
            // .tmp-then-swap step.
            return Serialisation<List<Hero>>.Save(filename, list, SerialisationMode.MessagePack);
        }

        /// <summary>
        /// Loads a .mpxhero or .mpxparty file for importing. Never throws.
        /// </summary>
        /// <returns>
        /// The heroes, or null if the file could not be read (recorded in <paramref name="problems"/>).
        /// A file that was read but holds no heroes is recorded as empty.
        /// </returns>
        public static List<Hero> LoadHeroesForImport(string filename, ImportProblems problems)
        {
            List<Hero> heroes = null;
            if (File.Exists(filename))
                heroes = Serialisation<List<Hero>>.Load(filename, SerialisationMode.MessagePack);

            if (heroes == null)
            {
                // NOTE: the pre-M14.1 .hero export never worked (it showed "pending" and its XML save
                // failed on the portrait), so there are no old hero files to recognise specially.
                problems?.AddUnreadable(filename);
                return null;
            }

            if (heroes.Count == 0)
                problems?.AddEmpty(filename);

            return heroes;
        }

        #endregion

        #region Messages

        /// <summary>Shows "The X could not be exported." as an error message.</summary>
        public static void ShowExportFailed(IWin32Window owner, string what)
        {
            string msg = "The " + what + " could not be exported.";
            MessageBox.Show(owner, msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }

    /// <summary>
    /// Collects the files an import could not use, so the user sees ONE message after a multi-file
    /// import instead of one message per file (or, as before M14, nothing at all).
    /// </summary>
    /// <remarks>
    /// Typical use:
    /// <code>
    /// ImportProblems problems = new ImportProblems();
    /// foreach (string filename in dlg.FileNames)
    /// {
    ///     Library container = ItemFiles.LoadForImport(filename, problems);
    ///     if (container == null)
    ///         continue;
    ///     if (container.Traps.Count == 0)
    ///         problems.AddEmpty(filename);
    ///     ... copy container.Traps into the target library ...
    /// }
    /// problems.Show(this, "trap");
    /// </code>
    /// </remarks>
    class ImportProblems
    {
        readonly List<string> fLegacy = new List<string>();
        readonly List<string> fUnreadable = new List<string>();
        readonly List<string> fEmpty = new List<string>();

        /// <summary>The file is an old BinaryFormatter export (.creature, .trap, ...).</summary>
        public void AddLegacy(string filename) { fLegacy.Add(filename); }

        /// <summary>The file is missing, damaged, or not a Masterplan export file.</summary>
        public void AddUnreadable(string filename) { fUnreadable.Add(filename); }

        /// <summary>The file was read but holds nothing of the kind being imported.</summary>
        public void AddEmpty(string filename) { fEmpty.Add(filename); }

        // Read-only counts per reason. Used by the automated tests (..\Masterplan.Tests) to check WHY
        // a file was skipped, without the message box that Show() displays.

        /// <summary>Number of old-format (BinaryFormatter) files skipped.</summary>
        public int LegacyCount { get { return fLegacy.Count; } }

        /// <summary>Number of files that could not be read.</summary>
        public int UnreadableCount { get { return fUnreadable.Count; } }

        /// <summary>Number of files that were read but held nothing of the kind being imported.</summary>
        public int EmptyCount { get { return fEmpty.Count; } }

        /// <summary>True if any file was skipped.</summary>
        public bool Any
        {
            get { return (fLegacy.Count + fUnreadable.Count + fEmpty.Count) != 0; }
        }

        /// <summary>
        /// Shows one message listing every skipped file and the reason. Does nothing if no file was
        /// skipped, so it can be called unconditionally after the import loop.
        /// </summary>
        /// <param name="owner">The window that owns the message box.</param>
        /// <param name="what">What was being imported, e.g. "creatures" (used in the "empty" reason).</param>
        public void Show(IWin32Window owner, string what)
        {
            if (!Any)
                return;

            string nl = Environment.NewLine;
            string msg = "Some files could not be imported." + nl;

            if (fLegacy.Count != 0)
            {
                // NOTE: the migration tool converts libraries and projects only, not single-item files,
                // so we do not tell the user to convert these. The useful advice is to convert the old
                // LIBRARY the item came from instead.
                msg += nl + "Old Masterplan format (cannot be converted):" + nl;
                msg += list(fLegacy);
                msg += "If these items are in one of your old libraries, convert that library with "
                     + LegacyFiles.MigrationApp + " instead." + nl;
            }

            if (fUnreadable.Count != 0)
            {
                msg += nl + "Could not be read (damaged, or not a Masterplan file):" + nl;
                msg += list(fUnreadable);
            }

            if (fEmpty.Count != 0)
            {
                msg += nl + "Contain no " + what + ":" + nl;
                msg += list(fEmpty);
            }

            MessageBox.Show(owner, msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Lists file names (not full paths), at most 10, one per line.</summary>
        static string list(List<string> files)
        {
            const int max = 10;
            string text = "";

            int listed = Math.Min(files.Count, max);
            for (int n = 0; n != listed; ++n)
                text += "    " + Path.GetFileName(files[n]) + Environment.NewLine;

            if (files.Count > listed)
                text += "    ...and " + (files.Count - listed) + " more" + Environment.NewLine;

            return text;
        }
    }
}
