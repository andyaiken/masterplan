using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Wizards;

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

					MagicItemSectionForm dlg = new MagicItemSectionForm(section);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fMagicItem.Sections.Add(dlg.Section);
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "edit")
			{
				e.Cancel = true;

				int index = int.Parse(e.Url.LocalPath);

				MagicItemSectionForm dlg = new MagicItemSectionForm(fMagicItem.Sections[index]);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fMagicItem.Sections[index] = dlg.Section;
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
			StatBlockBrowser.DocumentText = HTML.MagicItem(fMagicItem, DisplaySize.Small, true, true);
		}

		private void FileExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Export Magic Item";
			dlg.FileName = fMagicItem.Name;
			dlg.Filter = Program.MagicItemFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				bool ok = Serialisation<MagicItem>.Save(dlg.FileName, fMagicItem, SerialisationMode.Binary);

				if (!ok)
				{
					string error = "The magic item could not be exported.";
					MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
