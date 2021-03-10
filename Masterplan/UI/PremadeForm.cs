using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Xml;

using Utils;
using Utils.Forms;

namespace Masterplan.UI
{
	partial class PremadeForm : Form
	{
		public class Adventure
		{
			public string Name = "";

			public int PartyLevel = 0;
			public int PartySize = 0;

			public string URL = "";
		}

		public PremadeForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			WebClient wc = new WebClient();
			wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(downloaded_html);
			wc.DownloadStringAsync(new Uri("http://www.habitualindolence.net/masterplan/adventures.htm"));

			update_list();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (SelectedAdventure != null);
		}

		public Adventure SelectedAdventure
		{
			get
			{
				if (AdventureList.SelectedItems.Count != 0)
					return AdventureList.SelectedItems[0].Tag as Adventure;

				return null;
			}
		}

		public string DownloadedFileName
		{
			get { return fDownloadedFileName; }
		}
		string fDownloadedFileName = "";

		void downloaded_html(object sender, DownloadStringCompletedEventArgs e)
		{
			try
			{
				fAdventures = new List<Adventure>();
				string lc = e.Result.ToLower();

				const string tr_start = "<tr>";
				const string tr_end = "</tr>";

				int index = 0;
				while (true)
				{
					int start = lc.IndexOf(tr_start, index);
					if (start == -1)
						break;

					int end = lc.IndexOf(tr_end, start);
					if (end == -1)
						break;

					end = end + tr_end.Length;
					string row = e.Result.Substring(start, end - start);
					index = end;

					Adventure adv = get_adventure(row);
					if (adv != null)
						fAdventures.Add(adv);
				}
			}
			catch
			{
			}

			update_list();
		}

		Adventure get_adventure(string html)
		{
			try
			{
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(html);

				XmlNode root = doc.DocumentElement;
				if (root == null)
					return null;

				Adventure adv = new Adventure();

				XmlNode main_node = root.FirstChild;
				adv.Name = main_node.InnerText;

				XmlNode link_node = main_node.FirstChild;
				adv.URL = XMLHelper.GetAttribute(link_node, "href");
				adv.URL = "http://www.habitualindolence.net/masterplan/" + adv.URL;

				XmlNode level_node = main_node.NextSibling;
				string level_str = level_node.InnerText;
				level_str = level_str.Replace("Level", "");
				level_str = level_str.Replace("level", "");
				level_str = level_str.Replace(" ", "");
				adv.PartyLevel = int.Parse(level_str);

				XmlNode size_node = level_node.NextSibling;
				string size_str = size_node.InnerText;
				size_str = size_str.Replace("PCs", "");
				size_str = size_str.Replace("pcs", "");
				size_str = size_str.Replace("heroes", "");
				size_str = size_str.Replace(" ", "");
				adv.PartySize = int.Parse(size_str);

				return adv;
			}
			catch
			{
			}

			return null;
		}

		List<Adventure> fAdventures = null;
		ProgressScreen fProgressScreen = null;

		void update_list()
		{
			AdventureList.Items.Clear();
			AdventureList.Enabled = false;

			if (fAdventures == null)
			{
				ListViewItem lvi = AdventureList.Items.Add("Downloading adventure list...");
				lvi.ForeColor = SystemColors.GrayText;
			}
			else
			{
				if (fAdventures.Count != 0)
				{
					AdventureList.Enabled = true;

					foreach (Adventure adv in fAdventures)
					{
						ListViewItem lvi = AdventureList.Items.Add(adv.Name);
						lvi.SubItems.Add("Level " + adv.PartyLevel);
						lvi.SubItems.Add(adv.PartySize + " PCs");

						lvi.Tag = adv;
					}
				}
				else
				{
					ListViewItem lvi = AdventureList.Items.Add("(could not download adventures)");
					lvi.ForeColor = SystemColors.GrayText;
				}
			}
		}

		private void PremadeForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (fProgressScreen != null)
				e.Cancel = true;
		}

		private void AdventureList_DoubleClick(object sender, EventArgs e)
		{
			OKBtn_Click(sender, e);
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if (SelectedAdventure != null)
				get_file_name(SelectedAdventure);
		}

		void get_file_name(Adventure adv)
		{
			string filename = FileName.Name(adv.Name);
			filename = FileName.TrimInvalidCharacters(filename);
			filename += ".masterplan";

			SaveFileDialog save_dlg = new SaveFileDialog();
			save_dlg.Filter = Program.ProjectFilter;
			save_dlg.FileName = filename;

			if (save_dlg.ShowDialog() == DialogResult.OK)
				start_download(adv, save_dlg.FileName);
		}

		void start_download(Adventure adv, string filename)
		{
			fProgressScreen = new ProgressScreen("Downloading Adventure...", 100);
			fProgressScreen.CurrentSubAction = adv.Name;
			fProgressScreen.Show();

			WebClient wc = new WebClient();
			wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progress_changed);
			wc.DownloadFileCompleted += new AsyncCompletedEventHandler(download_completed);
			wc.DownloadFileAsync(new Uri(adv.URL), filename);

			fDownloadedFileName = filename;
		}

		void progress_changed(object sender, DownloadProgressChangedEventArgs e)
		{
			fProgressScreen.Progress = e.ProgressPercentage;
		}

		void download_completed(object sender, AsyncCompletedEventArgs e)
		{
			fProgressScreen.Hide();
			fProgressScreen = null;

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
