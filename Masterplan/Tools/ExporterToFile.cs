#nullable enable

using System;
using System.Threading.Tasks;

namespace Masterplan.Tools
{
    /// <summary>
    /// This class contains reusable business logic for the export feature.
    /// Expanded to cover JPG format in addition to the original PNG Export (11/25/2025)
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
            Console.WriteLine("\n--- PNG Export Initiated (Receiving HTML Content) ---");
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

    /// <summary>
    /// Handles the specific logic for exporting HTML content to JPG format.
    /// Added 11/25/2025
    /// </summary>
    public class JpgExporter
    {
        /// <summary>
        /// CORE EXPORT METHOD: Async export process for JPG format.
        /// </summary>
        /// <param name="htmlToExport">The HTML string of the table to render.</param>
        public async Task<byte[]> StartJPGExport(string htmlToExport)
        {
            Console.WriteLine("\n--- JPG Export Initiated (Receiving HTML Content) ---");
            try
            {
                var exporter = new HtmlTableExporter();
                // Assumes HtmlTableExporter has been updated with an ExportTableToJpg method
                byte[]? imageBytes = await exporter.ExportTableToJpg(htmlToExport);

                if (imageBytes == null)
                {
                    Console.WriteLine("\nFAILURE: Image generation failed in the service layer.");
                    throw new InvalidOperationException("Image generation failed. Check the console for details.");
                }

                return imageBytes;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed during the JPG export process.", ex);
            }
        }
    }
}