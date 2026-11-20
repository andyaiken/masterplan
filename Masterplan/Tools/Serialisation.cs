#nullable disable

using Masterplan.Data;
using MessagePack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Masterplan.Tools
{
    /// <summary>
    /// File formats understood by <see cref="Serialisation{T}"/>.
    /// </summary>
    /// <remarks>
    /// HISTORY: there used to be a "Binary" member (value 0) for .NET's BinaryFormatter, which was
    /// removed from .NET 9 and later. M14 reads and writes only MessagePack (plus XML for settings), so
    /// the member was deleted. The remaining members keep their old numeric values on purpose, so a
    /// number stored anywhere (or used by an add-in) still means the same format.
    /// Old BinaryFormatter files are handled by Tools/LegacyFiles.cs and Tools/ItemFiles.cs, which tell
    /// the user what to do instead of trying to read them.
    /// </remarks>
    public enum SerialisationMode
    {
        /// <summary>XmlSerializer (used for Preferences.xml, encyclopedia and hero files).</summary>
        XML = 1,

        /// <summary>
        /// MessagePack. Library, Project, List&lt;IPlayerOption&gt; (rules) and List&lt;Hero&gt;
        /// (hero/party files) go through LibraryConversionService (DTO mapping); any other type is
        /// refused (logged; Load returns null, Save returns false), because only those four have a
        /// stable file format. (Before 14.1.0.11 other types were serialised directly.)
        /// </summary>
        MessagePack = 2,

        /// <summary>XmlSerializer for DTO types.</summary>
        XMLDTO = 3
    }

    public class Serialisation<T>
    {
        private static string SafeStr(string s) => string.IsNullOrWhiteSpace(s) ? "nodata" : s;

        public static T Load(string filename, SerialisationMode mode)
        {
            T result = default(T);
            try
            {
                switch (mode)
                {
                    case SerialisationMode.XML:
                    case SerialisationMode.XMLDTO:
                        using (XmlTextReader reader = new(filename))
                        {
                            result = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                        }
                        break;

                    case SerialisationMode.MessagePack:
                        // Library and Project are never serialised directly. They are mapped to DTOs
                        // (Dto/DtoModels.cs) by LibraryConversionService so the file layout is stable.
                        if (typeof(T) == typeof(Library))
                        {
                            result = (T)(object)LibraryConversionService.Instance.LoadXLibrary(filename);
                        }
                        else if (typeof(T) == typeof(Project))
                        {
                            result = (T)(object)LibraryConversionService.Instance.LoadXProject(filename);
                        }
                        else if (typeof(T) == typeof(List<IPlayerOption>))
                        {
                            // Rules files (.mpxcrunch). IPlayerOption is an interface with many
                            // implementations, so it is mapped to PlayerOptionDto rather than
                            // serialised directly.
                            result = (T)(object)LibraryConversionService.Instance.LoadXRules(filename);
                        }
                        else if (typeof(T) == typeof(List<Hero>))
                        {
                            // Hero (.mpxhero) and party (.mpxparty) files: mapped to HeroDto, because
                            // Hero holds things (e.g. the portrait Image) that are not serialised directly.
                            result = (T)(object)LibraryConversionService.Instance.LoadXHeroes(filename);
                        }
                        else
                        {
                            // Only the four types above have a stable file format (DTOs). Anything else
                            // is refused instead of being read in an unstable, direct form.
                            throw new NotSupportedException("No MessagePack file format for " + typeof(T).Name);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
            return result;
        }

        /// <summary>
        /// Saves an object to a file.
        /// </summary>
        /// <remarks>
        /// SAFE SAVE PATTERN: the data is written to "filename.tmp" first. Only if that fully succeeds is
        /// the real file replaced. A crash or error halfway through therefore never corrupts the existing
        /// file; at worst a .tmp file is left behind.
        /// </remarks>
        /// <returns>True if the file was written.</returns>
        public static bool Save(string filename, T obj, SerialisationMode mode)
        {
            string temp_filename = filename + ".tmp";
            bool ok = false;
            try
            {
                switch (mode)
                {
                    case SerialisationMode.MessagePack:
                        if (obj is Library lib)
                        {
                            ok = LibraryConversionService.Instance.SaveXLibrary(lib, temp_filename);
                        }
                        else if (obj is Project p)
                        {
                            ok = LibraryConversionService.Instance.SaveXProject(p, temp_filename);
                        }
                        else if (obj is List<IPlayerOption> rules)
                        {
                            // Rules files (.mpxcrunch): see the matching branch in Load.
                            ok = LibraryConversionService.Instance.SaveXRules(rules, temp_filename);
                        }
                        else if (obj is List<Hero> heroes)
                        {
                            // Hero and party files: see the matching branch in Load.
                            ok = LibraryConversionService.Instance.SaveXHeroes(heroes, temp_filename);
                        }
                        else
                        {
                            // Only the four types above have a stable file format (DTOs). Anything else
                            // is refused instead of being written in an unstable, direct form.
                            throw new NotSupportedException("No MessagePack file format for " + typeof(T).Name);
                        }
                        break;
                    case SerialisationMode.XML:
                        using (XmlTextWriter writer = new(temp_filename, Encoding.UTF8) { Formatting = Formatting.Indented })
                        {
                            new XmlSerializer(typeof(T)).Serialize(writer, obj);
                        }
                        ok = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
                ok = false;
            }

            if (ok)
            {
                if (File.Exists(filename)) File.Delete(filename);
                File.Move(temp_filename, filename);
            }
            return ok;
        }
    }
}
