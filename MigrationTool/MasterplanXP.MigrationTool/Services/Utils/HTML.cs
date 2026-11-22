#nullable disable

using System;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    /// <summary>
    /// A thinned-down version of the legacy HTML utility class.
    /// Provides passthrough methods to allow legacy models to compile.
    /// </summary>
    public static class HTML
    {
        /// <summary>
        /// Passthrough for the legacy HTML processing. 
        /// In the migration tool, we don't need to perform actual HTML conversion.
        /// </summary>
        public static string Process(string text, bool convert_newlines)
        {
            return text;
        }
    }
}
