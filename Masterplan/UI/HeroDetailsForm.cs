#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.IO;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class HeroDetailsForm : Form
    {
        public HeroDetailsForm(Hero hero)
        {
            InitializeComponent();

            fHero = hero.Copy();

            Browser.DocumentText = HTML.StatBlock(fHero, null, true, false, false, Session.Preferences.TextSize);
        }

        Hero fHero = null;

        private void PlayerViewBtn_Click(object sender, EventArgs e)
        {
            if (Session.PlayerView == null)
                Session.PlayerView = new PlayerViewForm(this);

            Session.PlayerView.ShowHero(fHero);
        }

        private void ExportHTML_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = fHero.Name;
            dlg.Filter = Program.HTMLFilter;

            if (dlg.ShowDialog() == DialogResult.OK)
                File.WriteAllText(dlg.FileName, Browser.DocumentText);
        }

        private void ExportHero_Click(object sender, EventArgs e)
        {
            //Pending Code
            MessageBox.Show("This Feature is pending.");
            Console.WriteLine("This Feature is pending.");
            

            
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Export";
                dlg.Filter = Program.HeroAndPCFilter;
                dlg.FileName = fHero.Name;

                if (dlg.ShowDialog() == DialogResult.OK)
                    Serialisation<Hero>.Save(dlg.FileName, fHero, SerialisationMode.XML);
            
        }
    }
}
