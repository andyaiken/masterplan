using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

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

                MessageBox.Show("The Export to PNG might take a while.  You can continue working until the save dialog appears.");              

                // Pass the HTML content to the core exporter logic.
                // await _exporter.StartPNGExport(htmlContent);
                byte[]? imageBytes = await _exporter.StartPNGExport(htmlContent);

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
