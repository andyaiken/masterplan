using Svg.Skia;
using System;
using System.IO;
using System.Reflection;

namespace Masterplan.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public static class SvgRenderer
    {
        // Null until first use, and stays null if the resource cannot be loaded (hence SKSvg?).
        private static SKSvg? fMasterPlanSvg;

        // IMPORTANT: The resource name must match the fully qualified name of the embedded resource.
        // Assuming the file is named masterplan.svg and the root namespace is Masterplan.
        private const string MasterPlanResourceName = "Masterplan.Resources.masterplan_scroll.svg";

        /// <summary>
        /// The Masterplan scroll SVG (loaded on first use), or null if it could not be loaded.
        /// </summary>
        public static SKSvg? MasterPlanSvg
        {
            get
            {
                if (fMasterPlanSvg == null)
                {
                    LoadSvg(MasterPlanResourceName, ref fMasterPlanSvg);
                }
                return fMasterPlanSvg;
            }
        }

        private static void LoadSvg(string resourceName, ref SKSvg? svgField)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                // GetManifestResourceStream returns null if the resource is missing (checked below).
                using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (stream != null)
                    {
                        svgField = new SKSvg();
                        svgField.Load(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                // Use the application's logging system if available
                System.Diagnostics.Debug.WriteLine($"Error loading SVG resource '{resourceName}': {ex.Message}");
                LogSystem.Trace(ex);
            }
        }
    }
}