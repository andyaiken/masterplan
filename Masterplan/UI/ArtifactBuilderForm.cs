#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class ArtifactBuilderForm : Form
    {
        public ArtifactBuilderForm(Artifact artifact)
        {
            InitializeComponent();

            fArtifact = artifact.Copy();

            update_statblock();
        }

        public Artifact Artifact
        {
            get { return fArtifact; }
        }
        Artifact fArtifact = null;

        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Scheme == "build")
            {
                if (e.Url.LocalPath == "profile")
                {
                    e.Cancel = true;

                    ArtifactProfileForm dlg = new ArtifactProfileForm(fArtifact);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fArtifact.Name = dlg.Artifact.Name;
                        fArtifact.Tier = dlg.Artifact.Tier;
                        update_statblock();
                    }
                }

                if (e.Url.LocalPath == "description")
                {
                    e.Cancel = true;

                    DetailsForm dlg = new DetailsForm(fArtifact.Description, "Description", null);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fArtifact.Description = dlg.Details;
                        update_statblock();
                    }
                }

                if (e.Url.LocalPath == "details")
                {
                    e.Cancel = true;

                    DetailsForm dlg = new DetailsForm(fArtifact.Details, "Details", null);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fArtifact.Details = dlg.Details;
                        update_statblock();
                    }
                }

                if (e.Url.LocalPath == "goals")
                {
                    e.Cancel = true;

                    DetailsForm dlg = new DetailsForm(fArtifact.Goals, "Goals", null);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fArtifact.Goals = dlg.Details;
                        update_statblock();
                    }
                }

                if (e.Url.LocalPath == "rp")
                {
                    e.Cancel = true;

                    DetailsForm dlg = new DetailsForm(fArtifact.RoleplayingTips, "Roleplaying", null);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fArtifact.RoleplayingTips = dlg.Details;
                        update_statblock();
                    }
                }
            }

            if (e.Url.Scheme == "section")
            {
                if (e.Url.LocalPath == "new")
                {
                    e.Cancel = true;

                    MagicItemSection mis = new MagicItemSection();
                    SectionForm dlg = new SectionForm(mis.Header, mis.Details, "Artifact Section", new string[] { "Body Slot", "Enhancement", "Critical", "Property", "Power (At-Will)", "Power (Encounter)", "Power (Daily)" });
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        mis.Header = dlg.Header;
                        mis.Details = dlg.Details;

                        fArtifact.Sections.Add(mis);
                        update_statblock();
                    }
                }

                if (e.Url.LocalPath.Contains(",new"))
                {
                    e.Cancel = true;

                    try
                    {
                        string str = e.Url.LocalPath.Substring(0, e.Url.LocalPath.IndexOf(","));
                        int n = int.Parse(str);
                        ArtifactConcordance ac = fArtifact.ConcordanceLevels[n];

                        MagicItemSection mis = new MagicItemSection();
                        SectionForm dlg = new SectionForm(mis.Header, mis.Details, "Artifact Section", new string[] { "Body Slot", "Enhancement", "Critical", "Property", "Power (At-Will)", "Power (Encounter)", "Power (Daily)" });
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            mis.Header = dlg.Header;
                            mis.Details = dlg.Details;

                            ac.Sections.Add(mis);
                            update_statblock();
                        }
                    }
                    catch
                    {
                        // Not a number
                    }
                }
            }

            if (e.Url.Scheme == "sectionedit")
            {
                if (e.Url.LocalPath.Contains(","))
                {
                    e.Cancel = true;

                    int comma = e.Url.LocalPath.IndexOf(",");
                    string pre = e.Url.LocalPath.Substring(0, comma);
                    string post = e.Url.LocalPath.Substring(comma + 1);

                    try
                    {
                        int ac_index = int.Parse(pre);
                        int section_index = int.Parse(post);

                        ArtifactConcordance ac = fArtifact.ConcordanceLevels[ac_index];
                        MagicItemSection mis = ac.Sections[section_index];
                        SectionForm dlg = new SectionForm(mis.Header, mis.Details, "Artifact Section", new string[] { "Body Slot", "Enhancement", "Critical", "Property", "Power (At-Will)", "Power (Encounter)", "Power (Daily)" });
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            mis.Header = dlg.Header;
                            mis.Details = dlg.Details;

                            update_statblock();
                        }
                    }
                    catch
                    {
                        // Not a number
                    }
                }
                else
                {
                    e.Cancel = true;

                    try
                    {
                        int n = int.Parse(e.Url.LocalPath);
                        MagicItemSection mis = fArtifact.Sections[n];

                        SectionForm dlg = new SectionForm(mis.Header, mis.Details, "Artifact Section", new string[] { "Body Slot", "Enhancement", "Critical", "Property", "Power (At-Will)", "Power (Encounter)", "Power (Daily)" });
                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            mis.Header = dlg.Header;
                            mis.Details = dlg.Details;

                            update_statblock();
                        }
                    }
                    catch
                    {
                        // Not a number
                    }
                }
            }

            if (e.Url.Scheme == "sectionremove")
            {
                if (e.Url.LocalPath.Contains(","))
                {
                    e.Cancel = true;

                    int comma = e.Url.LocalPath.IndexOf(",");
                    string pre = e.Url.LocalPath.Substring(0, comma);
                    string post = e.Url.LocalPath.Substring(comma);

                    try
                    {
                        int ac_index = int.Parse(pre);
                        int section_index = int.Parse(post);

                        ArtifactConcordance ac = fArtifact.ConcordanceLevels[ac_index];
                        ac.Sections.RemoveAt(section_index);
                        update_statblock();
                    }
                    catch
                    {
                        // Not a number
                    }
                }
                else
                {
                    e.Cancel = true;

                    try
                    {
                        int n = int.Parse(e.Url.LocalPath);

                        fArtifact.Sections.RemoveAt(n);
                        update_statblock();
                    }
                    catch
                    {
                        // Not a number
                    }
                }
            }

            if (e.Url.Scheme == "concordancenew")
            {
                e.Cancel = true;

                ArtifactConcordance ac = new ArtifactConcordance("New Level", "0");
                ConcordanceLevelForm dlg = new ConcordanceLevelForm(ac);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fArtifact.ConcordanceLevels.Add(ac);
                    update_statblock();
                }
            }

            if (e.Url.Scheme == "concordanceedit")
            {
                e.Cancel = true;

                int n = int.Parse(e.Url.LocalPath);
                ArtifactConcordance ac = fArtifact.ConcordanceLevels[n];

                ConcordanceLevelForm dlg = new ConcordanceLevelForm(ac);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    update_statblock();
                }
            }

            if (e.Url.Scheme == "concordanceremove")
            {
                e.Cancel = true;

                int n = int.Parse(e.Url.LocalPath);
                ArtifactConcordance ac = fArtifact.ConcordanceLevels[n];

                string msg = "Are you sure you want to remove this concordance level?";
                if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fArtifact.ConcordanceLevels.Remove(ac);
                    update_statblock();
                }
            }

            if (e.Url.Scheme == "concordancemoveup")
            {
                e.Cancel = true;

                int n = int.Parse(e.Url.LocalPath);
                if (n > 0)
                {
                    ArtifactConcordance ac = fArtifact.ConcordanceLevels[n];
                    fArtifact.ConcordanceLevels.RemoveAt(n);
                    fArtifact.ConcordanceLevels.Insert(n - 1, ac);

                    update_statblock();
                }
            }

            if (e.Url.Scheme == "concordancemovedown")
            {
                e.Cancel = true;

                int n = int.Parse(e.Url.LocalPath);
                if (n < fArtifact.ConcordanceLevels.Count - 1)
                {
                    ArtifactConcordance ac = fArtifact.ConcordanceLevels[n];
                    fArtifact.ConcordanceLevels.RemoveAt(n);
                    fArtifact.ConcordanceLevels.Insert(n + 1, ac);

                    update_statblock();
                }
            }

            if (e.Url.Scheme == "rule")
            {
                e.Cancel = true;

                if (e.Url.LocalPath == "new")
                {
                    Pair<string, string> rule = new Pair<string, string>("", "");
                    ArtifactConcordanceForm dlg = new ArtifactConcordanceForm(rule);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fArtifact.ConcordanceRules.Add(dlg.Concordance);
                        update_statblock();
                    }
                }
            }

            if (e.Url.Scheme == "ruleedit")
            {
                e.Cancel = true;

                try
                {
                    int n = int.Parse(e.Url.LocalPath);
                    Pair<string, string> rule = fArtifact.ConcordanceRules[n];

                    ArtifactConcordanceForm dlg = new ArtifactConcordanceForm(rule);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fArtifact.ConcordanceRules[n] = dlg.Concordance;
                        update_statblock();
                    }
                }
                catch
                {
                    // Not a number
                }
            }

            if (e.Url.Scheme == "ruleremove")
            {
                e.Cancel = true;

                try
                {
                    int n = int.Parse(e.Url.LocalPath);

                    fArtifact.ConcordanceRules.RemoveAt(n);
                    update_statblock();
                }
                catch
                {
                    // Not a number
                }
            }

            if (e.Url.Scheme == "quote")
            {
                e.Cancel = true;

                try
                {
                    int n = int.Parse(e.Url.LocalPath);
                    ArtifactConcordance ac = fArtifact.ConcordanceLevels[n];

                    DetailsForm dlg = new DetailsForm(ac.Quote, "Concordance Quote", null);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ac.Quote = dlg.Details;
                        update_statblock();
                    }
                }
                catch
                {
                    // Not a number
                }
            }

            if (e.Url.Scheme == "desc")
            {
                e.Cancel = true;

                try
                {
                    int n = int.Parse(e.Url.LocalPath);
                    ArtifactConcordance ac = fArtifact.ConcordanceLevels[n];

                    DetailsForm dlg = new DetailsForm(ac.Description, "Concordance Description", null);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        ac.Description = dlg.Details;
                        update_statblock();
                    }
                }
                catch
                {
                    // Not a number
                }
            }
        }

        void update_statblock()
        {
            StatBlockBrowser.DocumentText = HTML.Artifact(fArtifact, Session.Preferences.TextSize, true, true);
        }

        private void FileImport_Click(object sender, EventArgs e)
        {
            string msg = "Importing an artifact file will clear any changes you have made to the item shown.";
            if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Import Artifact";
            dlg.Filter = Program.ArtifactFilter;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // An .mpxartifact file is a small library (see Tools/ItemFiles.cs); take its first artifact.
                // Old BinaryFormatter .artifact files cannot be read and get their own explanation.
                ImportProblems problems = new ImportProblems();
                Library container = ItemFiles.LoadForImport(dlg.FileName, problems);

                if ((container != null) && (container.Artifacts.Count != 0))
                {
                    fArtifact = container.Artifacts[0];
                    update_statblock();
                }
                else if (problems.Any)
                {
                    problems.Show(this, "artifacts");
                }
                else
                {
                    string error = "The artifact could not be imported.";
                    MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FileExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Export Artifact";
            dlg.FileName = fArtifact.Name;
            dlg.Filter = Program.ArtifactFilter;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Export file = a small library holding just this item, saved as MessagePack
                // (see Tools/ItemFiles.cs). The old BinaryFormatter save always failed on .NET 10.
                bool ok = ItemFiles.Save(dlg.FileName, ItemFiles.Wrap(fArtifact));

                if (!ok)
                {
                    string error = "The artifact could not be exported.";
                    MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
