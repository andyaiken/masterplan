#nullable disable

using Masterplan.Tools;
using MessagePack; // Added for resolver initialization
using MessagePack.Formatters;
using MessagePack.Resolvers; // <-- ADDED for CompositeResolver
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Masterplan.Tools
{
    /// <summary>
    /// Enumeration defining the supported serialisation modes.
    /// </summary>
    public enum SerialisationMode
    {
        /// <summary>
        /// Binary file format (deprecated).
        /// </summary>
        Binary,

        /// <summary>
        /// XML text format.
        /// </summary>
        XML,

        /// <summary>
        /// MessagePack binary format (new).
        /// </summary>
        MessagePack // Added new mode
    }

    /// <summary>
    /// Class containing static methods for serialising (loading and saving) an object.
    /// </summary>
    /// <typeparam name="T">The type of object to be serialised.</typeparam>
    public class Serialisation<T>
    {
        /// <summary>
        /// Loads an object of type T from a file.
        /// </summary>
        /// <param name="filename">The full path of the file.</param>
        /// <param name="mode">The mode in which the object was saved.</param>
        /// <returns>Returns the loaded object, or default(T) if the object could not be loaded.</returns>
        public static T Load(string filename, SerialisationMode mode)
        {
            T result = default(T);

            try
            {
                switch (mode)
                {
                    case SerialisationMode.Binary:
                        {
                            // Load using BinaryFormatter (deprecated format)
                            try
                            {
                                FileStream stream = new(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                                BinaryFormatter s = new();
                                result = (T)s.Deserialize(stream);
                                stream.Close();
                            }
                            catch (Exception)
                            {
                                // Binary load failed, attempt XML load for backwards compatibility
                                result = Load(filename, SerialisationMode.XML);
                            }
                        }
                        break;
                    case SerialisationMode.XML:
                        {
                            // Load using XmlSerializer
                            try
                            {
                                XmlTextReader reader = new(filename);
                                XmlSerializer s = new(typeof(T));
                                result = (T)s.Deserialize(reader);
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                LogSystem.Trace(ex);
                            }
                        }
                        break;
                    case SerialisationMode.MessagePack:
                        {
                            // Load using MessagePack (new, preferred format)
                            try
                            {
                                byte[] bytes = File.ReadAllBytes(filename);
                                result = MessagePackSerializer.Deserialize<T>(bytes);
                            }
                            catch (Exception ex)
                            {
                                LogSystem.Trace(ex);
                                // MessagePack load failed, attempt Binary load for backwards compatibility
                                result = Load(filename, SerialisationMode.Binary);
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {
            }

            return result;
        }

        /// <summary>
        /// Saves an object of type T to a file.
        /// </summary>
        /// <param name="filename">The full path of the file.</param>
        /// <param name="obj">The object to be saved.</param>
        /// <param name="mode">The mode in which the object will be saved.</param>
        /// <returns>Returns true if the object was saved successfully, and false otherwise.</returns>
        public static bool Save(string filename, T obj, SerialisationMode mode)
        {
            string temp_filename = filename + ".tmp";
            bool ok = false;

            try
            {
                switch (mode)
                {
                    case SerialisationMode.Binary:
                        {
                            // Save using BinaryFormatter (deprecated format)
                            FileStream stream = new(temp_filename, FileMode.Create, FileAccess.Write, FileShare.None);

                            try
                            {
                                BinaryFormatter s = new();
                                s.Serialize(stream, obj);

                                ok = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                LogSystem.Trace(ex);
                                ok = false;
                            }

                            stream.Close();
                        }
                        break;
                    case SerialisationMode.XML:
                        {
                            // Save using XmlSerializer
                            XmlTextWriter writer = new(temp_filename, Encoding.UTF8)
                            {
                                Formatting = Formatting.Indented
                            };

                            try
                            {
                                XmlSerializer s = new(typeof(T));
                                s.Serialize(writer, obj);
                                writer.Flush();

                                ok = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                LogSystem.Trace(ex);
                                ok = false;
                            }

                            writer.Close();
                        }
                        break;
                    case SerialisationMode.MessagePack:
                        {
                            // Save using MessagePack (new, preferred format)
                            try
                            {
                                // Serialize the object to a byte array
                                byte[] bytes = MessagePackSerializer.Serialize(obj);

                                // --- FIX FOR CS7036 ERROR: Using explicit FileStream with FileShare ---
                                // Replaced File.WriteAllBytes to avoid conflict with FileSystemAclExtensions
                                using (FileStream fs = new(
                                    temp_filename,
                                    FileMode.Create, // Create the file
                                    FileAccess.Write,
                                    FileShare.Read // <-- Explicitly specify FileShare
                                ))
                                {
                                    fs.Write(bytes, 0, bytes.Length);
                                }
                                // --- END FIX ---

                                ok = true;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                LogSystem.Trace(ex);
                                ok = false;
                            }
                        }
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
                // Atomically replace the target file with the temporary file
                if (File.Exists(filename))
                    File.Delete(filename);

                File.Move(temp_filename, filename);
            }
            else if (File.Exists(temp_filename))
            {
                // Clean up temp file on failure
                File.Delete(temp_filename);
            }

            return ok;
        }
    }
}