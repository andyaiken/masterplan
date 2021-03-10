using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

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
					MagicItemSectionForm dlg = new MagicItemSectionForm(mis);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fArtifact.Sections.Add(dlg.Section);
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
						MagicItemSectionForm dlg = new MagicItemSectionForm(mis);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							ac.Sections.Add(dlg.Section);
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
					string post = e.Url.LocalPath.Substring(comma);

					try
					{
						int ac_index = int.Parse(pre);
						int section_index = int.Parse(post);

						ArtifactConcordance ac = fArtifact.ConcordanceLevels[ac_index];
						MagicItemSection mis = ac.Sections[section_index];
						MagicItemSectionForm dlg = new MagicItemSectionForm(mis);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							ac.Sections[section_index] = dlg.Section;
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

						MagicItemSectionForm dlg = new MagicItemSectionForm(mis);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							fArtifact.Sections[n] = dlg.Section;
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
			StatBlockBrowser.DocumentText = HTML.Artifact(fArtifact, DisplaySize.Small, true, true);
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
				Artifact a = Serialisation<Artifact>.Load(dlg.FileName, SerialisationMode.Binary);
				if (a != null)
				{
					fArtifact = a;
					update_statblock();
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
				bool ok = Serialisation<Artifact>.Save(dlg.FileName, fArtifact, SerialisationMode.Binary);

				if (!ok)
				{
					string error = "The artifact could not be exported.";
					MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
