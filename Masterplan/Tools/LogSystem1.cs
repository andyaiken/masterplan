#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.AccessControl; // ADDED: Required for FileSystemRights and FileSecurity

namespace Masterplan.Tools
{

    /// <summary>
    /// Class containing static methods and properties used for diagnostic logging.
    /// </summary>
    public class LogSystem
    {
        /// <summary>
        /// Sends a message to the console (and also to the logfile if one is defined).\r\n            /// </summary>
        /// <param name="message">The message to be displayed.</param>
        public static void Trace(string message)
        {
            try
            {
                // Indent the message
                string str = "";
                for (int a = 0; a < fIndent; ++a)
                    str += "\t";
                str += message + Environment.NewLine;

                // Write the message
                Console.Write(str);
                if ((fLogFile != null) && (fLogFile != ""))
                {
                    try
                    {
                        string line = DateTime.Now + "\t" + str;

                        // --- FIX FOR CS7036 ERROR: Using explicit FileStream with FileShare ---
                        // This replaces the implicit file append to explicitly use FileShare.Read 
                        // which resolves the conflict with System.IO.FileSystemAclExtensions.
                        using (FileStream fs = new FileStream(
                            fLogFile,
                            FileMode.Append,
                            FileAccess.Write,
                            FileShare.Read // <-- The required 'share' parameter
                        ))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.Write(line);
                        }
                        // --- END FIX ---
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Traces an object to the console (and also to the logfile if one is defined).
        /// </summary>
        /// <param name="obj">The object to be traced.</param>
        public static void Trace(object obj)
        {
            try
            {
                Trace(obj.ToString());
            }
            catch
            {
            }
        }

        /// <summary>
        /// Traces an exception (the exception message, stack trace and inner exceptions) to the console (and also to the logfile if one is defined).
        /// </summary>
        /// <param name="ex">The exception to be traced.</param>
        public static void Trace(Exception ex)
        {
            try
            {
                Trace(ex.Message);
                Trace(ex.StackTrace);

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;

                    Indent += 1;
                    Trace(ex);
                    Indent -= 1;
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Gets or sets the path of the current logfile.
        /// If this is null or empty, no logfile is defined.
        /// </summary>
        public static string LogFile
        {
            get { return fLogFile; }
            set { fLogFile = value; }
        }
        static string fLogFile = "";

        /// <summary>
        /// Gets or sets a value indicating the current level of indentation.
        /// </summary>
        public static int Indent
        {
            get { return fIndent; }
            set { fIndent = value; }
        }
        static int fIndent = 0;
    }
}