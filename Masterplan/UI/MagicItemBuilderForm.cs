#nullable disable

using Masterplan.Data;
using Masterplan.Tools;
using System;
using System.Windows.Forms;

namespace Masterplan.UI
{
    partial class MagicItemBuilderForm : Form
    {
        public MagicItemBuilderForm(MagicItem item)
        {
            InitializeComponent();

            fMagicItem = item.Copy();

            update_statblock();
        }

        public MagicItem MagicItem
        {
            get { return fMagicItem; }
        }
        MagicItem fMagicItem = null;

        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.Scheme == "build")
            {
                if (e.Url.LocalPath == "profile")
                {
                    e.Cancel = true;

                    MagicItemProfileForm dlg = new MagicItemProfileForm(fMagicItem);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fMagicItem.Name = dlg.MagicItem.Name;
                        fMagicItem.Level = dlg.MagicItem.Level;
                        fMagicItem.Type = dlg.MagicItem.Type;
                        fMagicItem.Rarity = dlg.MagicItem.Rarity;

                        update_statblock();
                    }
                }

                if (e.Url.LocalPath == "desc")
                {
                    e.Cancel = true;

                    DetailsForm dlg = new DetailsForm(fMagicItem.Description, "Description", null);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        fMagicItem.Description = dlg.Details;
                        update_statblock();
                    }
                }
            }

            if (e.Url.Scheme == "section")
            {
                e.Cancel = true;

                if (e.Url.LocalPath == "new")
                {
                    MagicItemSection section = new MagicItemSection();
                    section.Header = "New Section";

                    SectionForm dlg = new SectionForm(section.Header, section.Details, "Magic Item Section", new string[] { "Price", "Enhancement", "Property", "Power", "Critical" });
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        section.Header = dlg.Header;
                        section.Details = dlg.Details;

                        fMagicItem.Sections.Add(section);
                        update_statblock();
                    }
                }
            }

            if (e.Url.Scheme == "edit")
            {
                e.Cancel = true;

                int index = int.Parse(e.Url.LocalPath);
                MagicItemSection section = fMagicItem.Sections[index];

                SectionForm dlg = new SectionForm(section.Header, section.Details, "Magic Item Section", new string[] { "Price", "Enhancement", "Property", "Power", "Critical" });
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    section.Header = dlg.Header;
                    section.Details = dlg.Details;

                    update_statblock();
                }
            }

            if (e.Url.Scheme == "remove")
            {
                e.Cancel = true;

                int index = int.Parse(e.Url.LocalPath);

                fMagicItem.Sections.RemoveAt(index);
                update_statblock();
            }

            if (e.Url.Scheme == "moveup")
            {
                e.Cancel = true;

                int index = int.Parse(e.Url.LocalPath);

                MagicItemSection tmp = fMagicItem.Sections[index - 1];
                fMagicItem.Sections[index - 1] = fMagicItem.Sections[index];
                fMagicItem.Sections[index] = tmp;

                update_statblock();
            }

            if (e.Url.Scheme == "movedown")
            {
                e.Cancel = true;

                int index = int.Parse(e.Url.LocalPath);

                MagicItemSection tmp = fMagicItem.Sections[index + 1];
                fMagicItem.Sections[index + 1] = fMagicItem.Sections[index];
                fMagicItem.Sections[index] = tmp;

                update_statblock();
            }
        }

        private void OptionsVariant_Click(object sender, EventArgs e)
        {
            MagicItemSelectForm dlg = new MagicItemSelectForm(fMagicItem.Level);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fMagicItem = dlg.MagicItem.Copy();
                fMagicItem.ID = Guid.NewGuid();

                update_statblock();
            }
        }

        void update_statblock()
        {
            StatBlockBrowser.DocumentText = HTML.MagicItem(fMagicItem, Session.Preferences.TextSize, true, true);
        }

        private void FileExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Export Magic Item";
            dlg.FileName = fMagicItem.Name;
            dlg.Filter = Program.MagicItemFilter;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Export file = a small library holding just this item, saved as MessagePack
                // (see Tools/ItemFiles.cs). The old BinaryFormatter save always failed on .NET 10.
                // NOTE: before M14 this wrote a single MagicItem while the library import expected a
                // List<MagicItem>, so builder exports could never be imported. Both now use the same
                // small-library format.
                bool ok = ItemFiles.Save(dlg.FileName, ItemFiles.Wrap(fMagicItem));

                if (!ok)
                {
                    string error = "The magic item could not be exported.";
                    MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
