#nullable disable

using MasterplanXP.MigrationTool.Models.Legacy;
using MasterplanXP.MigrationTool.Services.Utils;
using MessagePack;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MasterplanXP.MigrationTool.Services
{
    public enum SerialisationMode { Binary, XML, MessagePack, XMLDTO }

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
                    case SerialisationMode.Binary:
                        using (FileStream stream = new(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            // SYSLIB0011 says "BinaryFormatter is obsolete". We know: reading old
                            // .library / .masterplan files (written with BinaryFormatter) is the whole
                            // job of this tool, and LegacySerializationBinder + TypeAllowList limit
                            // which types a file may contain. The warning is switched off for these
                            // lines only, so any NEW BinaryFormatter use elsewhere still warns.
#pragma warning disable SYSLIB0011
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Binder = new LegacySerializationBinder();
                            result = (T)bf.Deserialize(stream);
#pragma warning restore SYSLIB0011
                        }

                        if (result != null)
                        {
                            // DiscoveryService.RunDiscovery(result, filename, "MasterSchema", clearCache: false);
                        }
                        break;

                    case SerialisationMode.XML:
                    case SerialisationMode.XMLDTO:
                        using (XmlTextReader reader = new(filename))
                        {
                            result = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                        }
                        break;

                    case SerialisationMode.MessagePack:
                        if (typeof(T) == typeof(Library))
                        {
                            result = (T)(object)LibraryConversionService.Instance.LoadXLibrary(filename);
                        }
                        else if (typeof(T) == typeof(Project))
                        {
                            result = (T)(object)LibraryConversionService.Instance.LoadXProject(filename);
                        }
                        else
                        {
                            byte[] bytes = File.ReadAllBytes(filename);
                            result = MessagePackSerializer.Deserialize<T>(bytes);
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

        public static bool Save(string filename, T obj, SerialisationMode mode)
        {
            if (obj != null && mode == SerialisationMode.Binary)
            {
                string ext = Path.GetExtension(filename).ToLower();
                string prefix = (ext == ".masterplan") ? "Project" : "Library";
                // DiscoveryService.RunDiscovery(obj, filename, prefix);
            }

            string temp_filename = filename + ".tmp";
            bool ok = false;
            try
            {
                switch (mode)
                {
                    case SerialisationMode.Binary:
                        using (FileStream stream = new(temp_filename, FileMode.Create))
                        {
                            // Old-format save, kept from the original code (see the SYSLIB0011 note in
                            // Load above); the warning is switched off for this line only.
#pragma warning disable SYSLIB0011
                            new BinaryFormatter().Serialize(stream, obj);
#pragma warning restore SYSLIB0011
                        }
                        ok = true;
                        break;
                    case SerialisationMode.MessagePack:
                        if (obj is Library lib)
                        {
                            LibraryConversionService.Instance.SaveXLibrary(lib, temp_filename);
                            ok = true;
                        }
                        else if (obj is Project p)
                        {
                            LibraryConversionService.Instance.SaveXProject(p, temp_filename);
                            ok = true;
                        }
                        else
                        {
                            var mpBytes = MessagePackSerializer.Serialize(obj);
                            File.WriteAllBytes(temp_filename, mpBytes);
                            ok = true;
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
