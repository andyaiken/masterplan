#nullable enable

using PuppeteerSharp;
using System;
using System.Threading.Tasks;

namespace Masterplan.Tools
{
    /// <summary>
    /// Service class responsible for rendering HTML content into PNG or JPG files using a headless browser.
    /// </summary>
    public class HtmlTableExporter
    {
        private const string TableSelector = "table"; // CSS selector for the element we want to screenshot

        /// <summary>
        /// Renders a given HTML string using a headless Chrome instance and returns the PNG image data.
        /// </summary>
        /// <param name="htmlContent">The full HTML content to render (including CSS/Style tags).</param>
        /// <returns>A Task representing the asynchronous operation, returning a byte array containing the PNG image data, or null on failure.</returns>
        public async Task<byte[]?> ExportTableToPng(string htmlContent)
        {
            // Call the internal helper with PNG type
            return await ExportTableInternal(htmlContent, ScreenshotType.Png);
        }

        /// <summary>
        /// Renders a given HTML string using a headless Chrome instance and returns the JPG image data.
        /// Required by the JpgExporter class.
        /// </summary>
        /// <param name="htmlContent">The full HTML content to render.</param>
        /// <returns>A Task representing the asynchronous operation, returning a byte array containing the JPG image data, or null on failure.</returns>
        public async Task<byte[]?> ExportTableToJpg(string htmlContent)
        {
            // Call the internal helper with JPEG type
            return await ExportTableInternal(htmlContent, ScreenshotType.Jpeg);
        }

        /// <summary>
        /// Internal helper method containing the shared Puppeteer logic for both PNG and JPG exports.
        /// </summary>
        /// <param name="htmlContent">The HTML to render.</param>
        /// <param name="type">The type of screenshot (PNG or JPEG).</param>
        private async Task<byte[]?> ExportTableInternal(string htmlContent, ScreenshotType type)
        {
            // Progress and errors go to the log file (LogSystem): a WinForms app has no console, so
            // the Console.WriteLine calls that used to be here were never seen by anyone.
            try
            {
                // 1. Start the headless browser: Edge or Chrome if installed, otherwise our own
                //    Chromium copy (downloaded once). See HeadlessBrowser for the details.
                //    (This used to download Chromium into the app's folder before every export.)
                await using var browser = await HeadlessBrowser.LaunchAsync(1000, 800);

                await using var page = await browser.NewPageAsync();

                // 2. Load the HTML into the page.
                await page.SetContentAsync(htmlContent);

                // 3. Find the table to capture (the first <table> is the item's main table).
                var tableElement = await page.QuerySelectorAsync(TableSelector);

                if (tableElement == null)
                {
                    LogSystem.Trace($"HtmlTableExporter: no element matches '{TableSelector}'; nothing to capture.");
                    return null; // Return null on failure
                }

                // 4. Default width for callers that do not fix the width themselves (e.g. the
                //    "Export to PNG" button in the creature stat block window, CreatureDetailsForm).
                //    These are plain inline styles, so the export dialog's fixed width
                //    (ExportOptionsForm.ApplyFixedExportWidth uses !important) still overrides them.
                await page.EvaluateExpressionAsync($@"
                    const table = document.querySelector('{TableSelector}');
                    if (table) {{
                        // Force max-width to 400px and set width to 100% to ensure it scales correctly within that limit.
                        table.style.maxWidth = '400px';
                        table.style.width = '99%';
                        console.log('Forcing max-width: 400px applied successfully.');
                    }}
                ");
                // ---------------------------------------------

                // 5. Capture the table as an image.
                var screenshotOptions = new ElementScreenshotOptions
                {
                    Type = type,
                    OmitBackground = false
                };

                // JPG supports quality settings (0-100). 
                // We set it to 90 for a good balance of quality and size.
                if (type == ScreenshotType.Jpeg)
                {
                    screenshotOptions.Quality = 90;
                }

                // Take a screenshot and get the result as a Base64 encoded string.
                string base64Image = await tableElement.ScreenshotBase64Async(screenshotOptions);

                // Convert the Base64 string back into a byte array for the caller to save.
                return Convert.FromBase64String(base64Image);
            }
            catch (Exception ex)
            {
                LogSystem.Trace("HtmlTableExporter: export failed.");
                LogSystem.Trace(ex);
                return null; // Return null on exception (the caller shows the error)
            }
        }
    }
}