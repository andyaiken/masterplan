#nullable enable

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HtmlToOpenXml;
using Masterplan.Tools;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Masterplan.UI
{
    /// <summary>
    /// Export Options to select export formats
    /// </summary>
    public class ExportOptionsForm : Form
    {
        private RadioButton rbPng;
        private RadioButton rbJpg;
        private RadioButton rbDoc;
        private RadioButton rbHtm;
        private RadioButton rbPdf;
        private Button btnExport;
        private Label lblInstruction;

        // This would be passed in from the parent form/context
        private string _htmlContentToExport;

        // File name (without extension) offered in the Save dialog, e.g. the creature's name.
        // Empty means "no name given", and SaveFileToDisk falls back to Export_<date>_<time>.
        private string _suggestedFileName;

        // The item's name exactly as shown in Masterplan (e.g. "Orc Chieftain: Warlord"), used as the
        // document TITLE of PDF and HTM exports. Unlike the file name it may contain ":" or "?".
        // "Masterplan export" when no name was given.
        private string _itemName;

        // Default width (in pixels) of an exported item's main table, whatever the in-app narrow/wide
        // layout is. A caller can ask for another width per item type (the library list exports skill
        // challenges and artifacts at 600px because they have more text per row).
        public const int DefaultExportTableWidth = 350;

        // The width used by THIS export (PNG, JPG, PDF and HTM via ApplyFixedExportWidth, and DOCX via
        // InlineTableStyles).
        private int _tableWidth;

        /// <summary>
        /// Shows the export options for one item.
        /// </summary>
        /// <param name="htmlContent">The complete HTML page to export (with its STYLE block).</param>
        /// <param name="suggestedFileName">Optional: the item's name, offered as the file name in the
        /// Save dialog. Characters that Windows does not allow in file names are replaced.</param>
        /// <param name="tableWidth">Optional: width in pixels of the item's main table in the export
        /// (default DefaultExportTableWidth, 350).</param>
        public ExportOptionsForm(string htmlContent, string? suggestedFileName = null, int tableWidth = DefaultExportTableWidth)
        {
            // Fix the table width once here, so PNG, JPG, PDF and HTM all get the same width.
            // (DOCX ignores <STYLE> blocks; InlineTableStyles sets the width for it.)
            _tableWidth = tableWidth;
            _htmlContentToExport = ApplyFixedExportWidth(htmlContent, _tableWidth);
            _suggestedFileName = MakeSafeFileName(suggestedFileName);
            _itemName = string.IsNullOrWhiteSpace(suggestedFileName) ? "Masterplan export" : suggestedFileName.Trim();
            InitializeComponent();

            // Set PNG as default selection for convenience
            rbPng.Checked = true;

            // While the one-time Chromium download runs, the title shows its progress in full
            // (the Export button only has room for "Downloading 45%").
            HeadlessBrowser.ShowProgressInTitle(this);
        }

        // MemberNotNull tells the nullable checker that these controls are always created here, so
        // after the constructor calls InitializeComponent they are never null. (Annotation only: it
        // changes no behaviour, it just removes the "must contain a non-null value" warnings.)
        [MemberNotNull(nameof(rbPng), nameof(rbJpg), nameof(rbDoc), nameof(rbHtm), nameof(rbPdf),
                       nameof(btnExport), nameof(lblInstruction))]
        private void InitializeComponent()
        {
            lblInstruction = new Label();
            rbPng = new RadioButton();
            rbJpg = new RadioButton();
            rbDoc = new RadioButton();
            rbHtm = new RadioButton();
            rbPdf = new RadioButton();
            btnExport = new Button();
            SuspendLayout();
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Location = new System.Drawing.Point(12, 9);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new System.Drawing.Size(132, 15);
            lblInstruction.TabIndex = 0;
            lblInstruction.Text = "Select an export format:";
            // 
            // rbPng
            // 
            rbPng.AutoSize = true;
            rbPng.Location = new System.Drawing.Point(78, 33);
            rbPng.Name = "rbPng";
            rbPng.Size = new System.Drawing.Size(49, 19);
            rbPng.TabIndex = 1;
            rbPng.TabStop = true;
            rbPng.Text = "PNG";
            rbPng.UseVisualStyleBackColor = true;
            // 
            // rbJpg
            // 
            rbJpg.AutoSize = true;
            rbJpg.Location = new System.Drawing.Point(78, 58);
            rbJpg.Name = "rbJpg";
            rbJpg.Size = new System.Drawing.Size(44, 19);
            rbJpg.TabIndex = 2;
            rbJpg.TabStop = true;
            rbJpg.Text = "JPG";
            rbJpg.UseVisualStyleBackColor = true;
            // 
            // rbDoc
            // 
            rbDoc.AutoSize = true;
            rbDoc.Location = new System.Drawing.Point(78, 108);
            rbDoc.Name = "rbDoc";
            rbDoc.Size = new System.Drawing.Size(57, 19);
            rbDoc.TabIndex = 4;
            rbDoc.TabStop = true;
            rbDoc.Text = "DOCX";
            rbDoc.UseVisualStyleBackColor = true;
            // 
            // rbHtm
            // 
            rbHtm.AutoSize = true;
            rbHtm.Location = new System.Drawing.Point(78, 83);
            rbHtm.Name = "rbHtm";
            rbHtm.Size = new System.Drawing.Size(52, 19);
            rbHtm.TabIndex = 3;
            rbHtm.TabStop = true;
            rbHtm.Text = "HTM";
            rbHtm.UseVisualStyleBackColor = true;
            // 
            // rbPdf
            // 
            rbPdf.AutoSize = true;
            rbPdf.Location = new System.Drawing.Point(78, 133);
            rbPdf.Name = "rbPdf";
            rbPdf.Size = new System.Drawing.Size(46, 19);
            rbPdf.TabIndex = 5;
            rbPdf.TabStop = true;
            rbPdf.Text = "PDF";
            rbPdf.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Location = new System.Drawing.Point(154, 154);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(120, 23);
            btnExport.TabIndex = 6;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // ExportOptionsForm
            // 
            ClientSize = new System.Drawing.Size(286, 189);
            Controls.Add(btnExport);
            Controls.Add(rbPdf);
            Controls.Add(rbHtm);
            Controls.Add(rbDoc);
            Controls.Add(rbJpg);
            Controls.Add(rbPng);
            Controls.Add(lblInstruction);
            Name = "ExportOptionsForm";
            Text = "Export Options";
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Handles the export button click event.
        /// </summary>
        private async void btnExport_Click(object? sender, EventArgs e)
        {
            byte[]? resultData = null;
            string extension = "";

            btnExport.Enabled = false;

            // If the one-time Chromium download (started in the background when Libraries opened) is
            // still running, a PNG/JPG/PDF export waits for it inside HeadlessBrowser. Show its progress
            // on the button meanwhile: "Downloading 45%", then "Exporting...".
            // The progress event comes from a background thread, so BeginInvoke moves the update
            // onto this form's UI thread.
            EventHandler downloadProgress = (s, a) =>
            {
                try
                {
                    if (IsHandleCreated && !IsDisposed)
                        BeginInvoke((Action)ShowExportProgress);
                }
                catch (Exception)
                {
                    // The dialog closed meanwhile; nothing to update.
                }
            };
            HeadlessBrowser.DownloadProgressChanged += downloadProgress;
            ShowExportProgress();

            try
            {
                if (rbPng.Checked)
                {
                    extension = "png";
                    var exporter = new PngExporter();
                    resultData = await exporter.StartPNGExport(_htmlContentToExport);
                }
                else if (rbJpg.Checked)
                {
                    // JPG has its own exporter. (PNG and JPG used to share the PNG exporter above,
                    // so a ".jpg" file actually contained PNG data.)
                    extension = "jpg";
                    var exporter = new JpgExporter();
                    resultData = await exporter.StartJPGExport(_htmlContentToExport);
                }
                else if (rbDoc.Checked)
                {
                    // Word needs the styles written on each table row (see InlineTableStyles).
                    extension = "docx";
                    string styledHtml = InlineTableStyles(_htmlContentToExport);
                    resultData = GenerateDocxFromHtml(styledHtml);
                }
                else if (rbPdf.Checked)
                {
                    // Use PuppeteerSharp to render the HTML into a PDF byte array
                    extension = "pdf";
                    resultData = await GeneratePdfFromHtmlAsync(_htmlContentToExport); // Must use 'await'
                }
                else if (rbHtm.Checked)
                {
                    extension = "htm";
                    // The HTML as it is, plus a <TITLE> with the item's name, so the browser tab shows
                    // e.g. "Aboleth Lasher" instead of the file name.
                    resultData = Encoding.UTF8.GetBytes(AddHtmlTitle(_htmlContentToExport, _itemName));
                }
                else
                {
                    MessageBox.Show("Please select an export format.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Same for every format: save, and close this dialog once the file has been saved
                // and the user has clicked OK on "File saved successfully!". If the user cancels the
                // Save dialog, this dialog stays open so they can try again or pick another format.
                // (PDF and DOCX used to return early and leave the dialog open, while images closed
                // it even when the save was cancelled.)
                if (resultData != null && resultData.Length > 0)
                {
                    if (SaveFileToDisk(resultData, extension))
                        this.Close();
                }
            }
            catch (Exception ex)
            {
                // (Environment.NewLine: the old "\\n" here showed a literal "\n" in the message.)
                MessageBox.Show($"Export failed: {ex.Message}{Environment.NewLine}{ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                HeadlessBrowser.DownloadProgressChanged -= downloadProgress;
                btnExport.Enabled = true;
                btnExport.Text = "Export";
            }
        }

        /// <summary>
        /// Button text while an export runs: the download progress if the one-time Chromium download
        /// is still running, otherwise "Exporting...".
        /// </summary>
        private void ShowExportProgress()
        {
            if (IsDisposed || btnExport.Enabled)
                return; // closed, or the export has already finished

            // Kept short: the button is only 120px wide. The title bar shows the full message
            // (ShowProgressInTitle in the constructor).
            btnExport.Text = HeadlessBrowser.IsDownloading
                ? $"Downloading {Math.Max(0, HeadlessBrowser.DownloadPercent)}%"
                : "Exporting...";
        }

        private string InlineTableStyles(string htmlContent)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(htmlContent);

            // Map classes to styles based on the original CSS/RtfExporter logic
            var styleMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
    {
        // Dark backgrounds with White Text (color: #FFFFFF)
        {"heading", "background-color: #143D5F; color: #FFFFFF;"},
        {"hero", "background-color: #143D5F; color: #FFFFFF;"},
        {"trap", "background-color: #5B1F34; color: #FFFFFF;"},
        {"artifact", "background-color: #5B1F34; color: #FFFFFF;"},
        {"creature", "background-color: #364F27; color: #FFFFFF;"},
        {"item", "background-color: #D06015; color: #FFFFFF;"},
        {"daily", "background-color: #000000; color: #FFFFFF;"},
        {"encounterlog", "background-color: #000000; color: #FFFFFF;"},
        
        // Light backgrounds with Black Text (default)
        {"shaded", "background-color: #9FA48D;"},
        {"warning", "background-color: #E5A0A0;"},
        {"clear", "background-color: #FFFFFF;"},
        
        // Default table row (light beige)
        // If a TR has no class, it will use the default color. 
        // We handle this by setting the default style on the table itself.
    };

            var tableNode = doc.DocumentNode.SelectSingleNode("//table");
            if (tableNode != null)
            {
                // Set the default table style (light beige)
                // The width is included here because the Word converter reads only inline styles,
                // not the <STYLE> block that ApplyFixedExportWidth adds.
                tableNode.SetAttributeValue("style", $"background-color: #E1E7C5; border: 1px solid #BBBBBB; border-collapse: collapse; width: {_tableWidth}px;");

                // Iterate through all table rows (tr)
                var rows = tableNode.SelectNodes(".//tr");
                if (rows != null)
                {
                    foreach (var rowNode in rows)
                    {
                        string rowClass = rowNode.GetAttributeValue("class", string.Empty).ToLower();
                        string inlineStyle = string.Empty;

                        foreach (var kvp in styleMap)
                        {
                            if (rowClass.Contains(kvp.Key))
                            {
                                inlineStyle = kvp.Value;
                                break;
                            }
                        }

                        if (!string.IsNullOrEmpty(inlineStyle))
                        {
                            // Overwrite any existing style with the correct inline style
                            rowNode.SetAttributeValue("style", inlineStyle);
                        }
                    }
                }
            }

            return doc.DocumentNode.OuterHtml;
        }


        /// <summary>
        /// Converts HTML content to a DOCX byte array using HtmlToOpenXml.
        /// </summary>
        private byte[] GenerateDocxFromHtml(string htmlContent)
        {
            using (MemoryStream generatedDocument = new MemoryStream())
            {
                // Create a WordprocessingDocument
                using (WordprocessingDocument package = WordprocessingDocument.Create(generatedDocument, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                {
                    // Add a main document part
                    MainDocumentPart mainPart = package.AddMainDocumentPart();
                    // Keep the Body we create: reading it back via mainPart.Document.Body gives a
                    // possibly-null value (as far as the compiler knows), although it is this one.
                    Body body = new Body();
                    mainPart.Document = new Document(body);

                    // Initialize the HtmlConverter
                    HtmlConverter converter = new HtmlConverter(mainPart);

                    // Convert the HTML and append it to the document body
                    var paragraphs = converter.Parse(htmlContent);
                    body.Append(paragraphs);
                }

                return generatedDocument.ToArray();
            }
        }


        /// <summary>
        /// Renders HTML content to a PDF byte array using PuppeteerSharp.
        /// </summary>
        private async Task<byte[]> GeneratePdfFromHtmlAsync(string htmlContent)
        {
            // Start the headless browser: Edge or Chrome if installed, otherwise our own Chromium copy
            // (downloaded once). See Tools/HeadlessBrowser.cs. (This used to download Chromium into
            // the app's folder before every export.) The 1000x800 page size helps the table lay out.
            await using var browser = await HeadlessBrowser.LaunchAsync(1000, 800);

            using (var page = await browser.NewPageAsync())
            {
                // Set HTML content
                await page.SetContentAsync(htmlContent);

                // Give the page a title: Chromium copies it into the PDF's Title property, which Acrobat
                // shows in its title bar. Without one, the page's address is used, and a page filled
                // with SetContentAsync has the address "about:blank" - that is what Acrobat showed.
                // The name is passed to the browser as DATA (the function's argument), not pasted into
                // the HTML or the script, so names containing < & " ' cannot break anything.
                await page.EvaluateFunctionAsync("t => { document.title = t; }", _itemName);

                // Wait briefly for CSS/layout to settle before printing
                await Task.Delay(100);

                // Generate the PDF
                var pdfOptions = new PdfOptions
                {
                    Format = PaperFormat.A4,
                    PrintBackground = true, // Ensures colors/backgrounds are printed
                    MarginOptions = new MarginOptions { Top = "0.5in", Bottom = "0.5in", Left = "0.5in", Right = "0.5in" }
                };

                return await page.PdfDataAsync(pdfOptions);
            }
        }


        /// <summary>
        /// Asks where to save the exported file, writes it, and confirms with "File saved successfully!".
        /// Eventually move all save functions to a common save component
        /// </summary>
        /// <param name="data">The exported file contents.</param>
        /// <param name="extension">File extension without the dot (png, jpg, pdf, docx, htm).</param>
        /// <returns>True if the file was saved (the caller then closes the dialog); false if the user
        /// cancelled the Save dialog. A write error is thrown to the caller, which shows it.</returns>
        private bool SaveFileToDisk(byte[] data, string extension)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                // "PNG Image" / "JPG Image" for pictures, "PDF File" / "DOCX File" / "HTM File" otherwise.
                bool isImage = extension == "png" || extension == "jpg";
                string filter = isImage
                    ? $"{extension.ToUpper()} Image|*.{extension}"
                    : $"{extension.ToUpper()} File|*.{extension}";

                sfd.Filter = filter;
                sfd.Title = $"Save Exported {extension.ToUpper()}";
                // Offer the item's name (e.g. "Aboleth Lasher.png") when the caller gave one,
                // otherwise a time-stamped default name.
                string baseName = _suggestedFileName != "" ? _suggestedFileName : $"Export_{DateTime.Now:yyyyMMdd_HHmm}";
                sfd.FileName = $"{baseName}.{extension}";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return false; // cancelled: nothing saved

                File.WriteAllBytes(sfd.FileName, data);
                MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }

        /// <summary>
        /// Makes the item's MAIN table exactly <paramref name="width"/> pixels wide in the exported page.
        /// It adds one extra &lt;STYLE&gt; block just before &lt;BODY&gt;:
        /// - "p.table &gt; table" is the main table (every HTML builder wraps it in &lt;P class=table&gt;);
        ///   "body &gt; table" covers a page without that wrapper. Small tables nested inside cells
        ///   are not matched, so they keep their normal layout.
        /// - "!important" is needed because creature stat blocks put min-width/max-width in an inline
        ///   style on the table, and the normal stylesheet uses max-width: 99% in the wide layout.
        /// The in-app views are not affected; only the HTML handed to this dialog is changed.
        /// </summary>
        private static string ApplyFixedExportWidth(string html, int width)
        {
            string w = $"{width}px";
            string style = "<STYLE type=\"text/css\">\r\n"
                + "/* Exports: fixed width for the item's main table */\r\n"
                + $"p.table > table, body > table {{ width: {w} !important; min-width: {w} !important; max-width: {w} !important; }}\r\n"
                + "</STYLE>\r\n";

            // Insert before the first <BODY> tag (any letter case). If there is none, put the
            // style first; browsers still apply it.
            int body = html.IndexOf("<body", StringComparison.OrdinalIgnoreCase);
            return body >= 0 ? html.Insert(body, style) : style + html;
        }

        /// <summary>
        /// Returns the HTML with a &lt;TITLE&gt; holding <paramref name="title"/> (used for HTM exports).
        /// The title is HTML-encoded, so names with &lt; &amp; or quotes display correctly. It goes just
        /// before &lt;/HEAD&gt; (or &lt;BODY&gt; if there is no head). HTML that already has a title is
        /// returned unchanged.
        /// </summary>
        private static string AddHtmlTitle(string html, string title)
        {
            if (html.IndexOf("<title", StringComparison.OrdinalIgnoreCase) >= 0)
                return html;

            string tag = "<TITLE>" + System.Net.WebUtility.HtmlEncode(title) + "</TITLE>\r\n";

            int pos = html.IndexOf("</head", StringComparison.OrdinalIgnoreCase);
            if (pos < 0)
                pos = html.IndexOf("<body", StringComparison.OrdinalIgnoreCase);

            return pos >= 0 ? html.Insert(pos, tag) : tag + html;
        }

        /// <summary>
        /// Turns an item name into something Windows accepts as a file name: characters such as
        /// \ / : * ? " &lt; &gt; | become "_" and surrounding spaces/dots are trimmed.
        /// Returns "" for a missing or empty name, so the caller can use its default name.
        /// Example: "Orc: Chieftain?" becomes "Orc_ Chieftain_".
        /// </summary>
        private static string MakeSafeFileName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "";

            char[] invalid = Path.GetInvalidFileNameChars();
            StringBuilder sb = new StringBuilder(name.Length);
            foreach (char ch in name)
                sb.Append(Array.IndexOf(invalid, ch) >= 0 ? '_' : ch);

            return sb.ToString().Trim().Trim('.');
        }

    }
}