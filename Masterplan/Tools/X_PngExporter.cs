#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masterplan.Tools
{

    /// <summary>
    /// This class contains the reusable business logic for the export feature.
    /// </summary>
    public class PngExporter
    {
        /// <summary>
        /// CORE EXPORT METHOD: This is the reusable, async export process that accepts 
        /// the HTML content from the caller (the Form).
        /// </summary>
        /// <param name="htmlToExport">The HTML string of the table to render.</param>
        public async Task<byte[]> StartPNGExport(string htmlToExport) // Renamed from StartExport
        {
            Console.WriteLine("\n--- Export Initiated (Receiving HTML Content) ---");
            try
            {
                var exporter = new HtmlTableExporter();
                byte[]? imageBytes = await exporter.ExportTableToPng(htmlToExport);

                if (imageBytes == null)
                {
                    Console.WriteLine("\nFAILURE: Image generation failed in the service layer.");
                    // Throwing an exception here ensures the calling async void method catches it.
                    throw new InvalidOperationException("Image generation failed. Check the console for details.");
                }

                // *** NOTE ***
                // Save file logic should go here
                // to separate the save dialog for 
                // png from each of the separate forms                                

                return imageBytes;
            }
            catch (Exception ex)
            {
                // Rethrow the exception so the caller (the WinForms event handler) can handle it.
                throw new InvalidOperationException($"Failed during the export process.", ex);
            }
        }
    }

}
