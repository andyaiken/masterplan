#nullable disable

using System;

namespace MasterplanXP.MigrationTool.Services.Utils
{
    /// <summary>
    /// Thinned-down version of the CssGenerator for migration purposes.
    /// Provides the necessary stubs for EncounterCard compilation.
    /// </summary>
    public class CssGenerator
    {
        private static readonly CssGenerator _instance = new CssGenerator();

        public static CssGenerator Instance => _instance;

        private CssGenerator() { }

        public string GenerateShortStyle()
        {
            return ""; // Stub: Not needed for data migration
        }
    }
}
