#nullable disable
// Legacy WinForms form: nullable checking is off here, as in the other legacy files (see CLAUDE.md).

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class CreatureDetailsForm : Form
    {
        // Instance of the core export logic service
        private readonly PngExporter _exporter;

        public CreatureDetailsForm(EncounterCard card)
        {
            InitializeComponent();

            fCard = card;

            Browser.DocumentText = HTML.StatBlock(fCard, null, null, true, false, true, CardMode.View, Session.Preferences.TextSize);

            // Initialize the exporter logic
            _exporter = new PngExporter();

            // This window can export to PNG (Export menu), which needs a headless browser. This window
            // opens from many places (Encounter Builder, Deck Builder, NPCs, plot encounters, the
            // variant wizard), not only from Libraries, so it also starts the one-time Chromium
            // download in the background if it is needed, and shows the progress in the title.
            HeadlessBrowser.StartBackgroundDownload();
            HeadlessBrowser.ShowProgressInTitle(this);

        }

        EncounterCard fCard = null;






        private void PlayerViewBtn_Click(object sender, EventArgs e)
        {
            if (fCard != null)
            {
                if (Session.PlayerView == null)
                    Session.PlayerView = new PlayerViewForm(this);

                Session.PlayerView.ShowEncounterCard(fCard);
            }
        }

        private void ExportHTML_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = fCard.Title;
            dlg.Filter = Program.HTMLFilter;

            if (dlg.ShowDialog() == DialogResult.OK)
                System.IO.File.WriteAllText(dlg.FileName, Browser.DocumentText);
        }


        /// <summary>
        /// ASYNC EVENT HANDLER: This method is connected to the button's Click event.
        /// It retrieves the HTML content and passes it to the core exporter logic.
        /// </summary>
        private async void ExportToPNG_Click(object sender, EventArgs e)
        {
            Console.WriteLine("\n--- CreatureDetailsForm Button Clicked: Starting Export ---");
            try
            {
                // Retrieve the static HTML content from its dedicated location
                string htmlContent = Browser.DocumentText;

                string message = "The Export to PNG might take a while.  You can continue working until the save dialog appears.";
                if (HeadlessBrowser.IsDownloading)
                {
                    // The export will wait for the background download to finish (progress in the title).
                    message += Environment.NewLine + Environment.NewLine
                        + "(First time: the export component is still being downloaded, "
                        + HeadlessBrowser.DownloadPercent + "% done.)";
                }
                MessageBox.Show(message);

                // Pass the HTML content to the core exporter logic.
                // await _exporter.StartPNGExport(htmlContent);
                byte[] imageBytes = await _exporter.StartPNGExport(htmlContent); // (no "?": nullable is off in this file)

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = fCard.Title;
                dlg.Filter = Program.PNGFilter;

                if (dlg.ShowDialog() == DialogResult.OK)
                    System.IO.File.WriteAllBytes(dlg.FileName, imageBytes);

            }
            catch (Exception ex)
            {
                // Catching the exception in 'async void' prevents the app from crashing.
                Console.WriteLine($"\nCRITICAL UI ERROR: Export process failed: {ex.Message}");
                MessageBox.Show($"Export Failed: {ex.InnerException?.Message ?? ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
