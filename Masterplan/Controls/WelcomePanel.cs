using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.Controls
{
	partial class WelcomePanel : UserControl
	{
		class Headline : IComparable<Headline>
		{
			public string Title = "";
			public string URL = "";
			public DateTime Date = DateTime.Now;

			public int CompareTo(Headline rhs)
			{
				return Date.CompareTo(rhs.Date) * -1;
			}
		}

		public WelcomePanel(bool show_headlines)
		{
			InitializeComponent();

			fShowHeadlines = show_headlines;

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);

			MenuBrowser.DocumentText = "";
			set_options();

			if (fShowHeadlines)
			{
				DownloadHeadlines("http://www.habitualindolence.net/masterplanblog/feed/");
				//DownloadHeadlines("http://www.facebook.com/feeds/page.php?format=atom10&id=93998019773");
			}
		}

		private void TitlePanel_FadeFinished(object sender, EventArgs e)
		{
		}

		private void MenuBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "masterplan")
			{
				e.Cancel = true;

				if (e.Url.LocalPath == "new")
					OnNewProjectClicked();

				if (e.Url.LocalPath == "open")
					OnOpenProjectClicked();

				if (e.Url.LocalPath == "last")
					OnOpenLastProjectClicked();

				if (e.Url.LocalPath == "delve")
					OnDelveClicked();

				if (e.Url.LocalPath == "premade")
					OnPremadeClicked();

				if (e.Url.LocalPath == "genesis")
				{
					Creature c = new Creature();
					c.Name = "New Creature";

					Masterplan.UI.CreatureBuilderForm dlg = new Masterplan.UI.CreatureBuilderForm(c);
					dlg.ShowDialog();
				}

				if (e.Url.LocalPath == "exodus")
				{
					CreatureTemplate ct = new CreatureTemplate();
					ct.Name = "New Template";

					Masterplan.UI.CreatureTemplateBuilderForm dlg = new Masterplan.UI.CreatureTemplateBuilderForm(ct);
					dlg.ShowDialog();
				}

				if (e.Url.LocalPath == "minos")
				{
					Trap trap = new Trap();
					trap.Name = "New Trap";
					trap.Attacks.Add(new TrapAttack());

					Masterplan.UI.TrapBuilderForm dlg = new Masterplan.UI.TrapBuilderForm(trap);
					dlg.ShowDialog();
				}

				if (e.Url.LocalPath == "excalibur")
				{
					MagicItem mi = new MagicItem();
					mi.Name = "New Magic Item";

					Masterplan.UI.MagicItemBuilderForm dlg = new Masterplan.UI.MagicItemBuilderForm(mi);
					dlg.ShowDialog();
				}

				if (e.Url.LocalPath == "indiana")
				{
					Artifact a = new Artifact();
					a.Name = "New Artifact";

					Masterplan.UI.ArtifactBuilderForm dlg = new Masterplan.UI.ArtifactBuilderForm(a);
					dlg.ShowDialog();
				}

				if (e.Url.LocalPath == "manual")
					open_manual();
			}
		}

		const int MAX_HEADLINES = 10;
		const int MAX_LENGTH = 45;

		List<Headline> fHeadlines = null;

		public bool ShowHeadlines
		{
			get { return fShowHeadlines; }
			set { fShowHeadlines = value; }
		}
		bool fShowHeadlines = false;

		public void DownloadHeadlines(string address)
		{
			try
			{
				WebClient wc = new WebClient();
				wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(downloaded_headlines);
				Uri uri = new Uri(address);
				wc.DownloadStringAsync(uri);
			}
			catch (WebException ex)
			{
				LogSystem.Trace(ex);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void downloaded_headlines(object sender, DownloadStringCompletedEventArgs e)
		{
			try
			{
				fHeadlines = new List<Headline>();

				if (e.Error == null)
				{
					string str = e.Result;
					XmlDocument doc = new XmlDocument();
					doc.LoadXml(str);

					XmlNode root = doc.DocumentElement;
					if (root == null)
						return;

					XmlNode channnel_node = root.FirstChild;
					if (channnel_node == null)
						return;

					foreach (XmlNode node in channnel_node.ChildNodes)
					{
						if (node.Name.ToLower() != "item")
							continue;

						Headline hl = new Headline();

						XmlNode title_node = XMLHelper.FindChild(node, "title");
						if (title_node == null)
							continue;
						hl.Title = title_node.InnerText;

						XmlNode link_node = XMLHelper.FindChild(node, "link");
						if (link_node == null)
							continue;
						hl.URL = link_node.InnerText;

						XmlNode date_node = XMLHelper.FindChild(node, "pubDate");
						if (link_node == null)
							continue;
						hl.Date = DateTime.Parse(date_node.InnerText);

						if (hl.Title.Length > MAX_LENGTH)
							hl.Title = hl.Title.Substring(0, MAX_LENGTH) + "...";

						fHeadlines.Add(hl);
					}
				}

				// Update the options
				set_options();
			}
			catch
			{
			}
		}

		#region Events

		[Category("Actions")]
		public event EventHandler NewProjectClicked;

		[Category("Actions")]
		public event EventHandler OpenProjectClicked;

		[Category("Actions")]
		public event EventHandler OpenLastProjectClicked;

		[Category("Actions")]
		public event EventHandler DelveClicked;

		[Category("Actions")]
		public event EventHandler PremadeClicked;

		protected void OnNewProjectClicked()
		{
			if (NewProjectClicked != null)
				NewProjectClicked(this, new EventArgs());
		}

		protected void OnOpenProjectClicked()
		{
			if (OpenProjectClicked != null)
				OpenProjectClicked(this, new EventArgs());
		}

		protected void OnOpenLastProjectClicked()
		{
			if (OpenLastProjectClicked != null)
				OpenLastProjectClicked(this, new EventArgs());
		}

		protected void OnDelveClicked()
		{
			if (DelveClicked != null)
				DelveClicked(this, new EventArgs());
		}

		protected void OnPremadeClicked()
		{
			if (PremadeClicked != null)
				PremadeClicked(this, new EventArgs());
		}

		#endregion

		void set_options()
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(HTML.GetHead("Masterplan", "Main Menu", DisplaySize.Small));
			lines.Add("<BODY>");

			#region Getting Started

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");
			
			lines.Add("<TR class=heading>");
			lines.Add("<TD>");
			lines.Add("<B>Getting Started</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (show_last_file_option())
			{
				string name = FileName.Name(Session.Preferences.LastFile);

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:last\">Reopen <I>" + name + "</I></A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=\"masterplan:new\">Create a new adventure project</A>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=\"masterplan:open\">Open an existing project</A>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			/*
			lines.Add("</TABLE>");
			lines.Add("</P>");

			#endregion

			#region Advanced

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD>");
			lines.Add("<B>Advanced Options</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");
			*/

			if (show_delve_option())
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:delve\">Generate a random dungeon delve</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=\"masterplan:premade\">Download a premade adventure</A>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("</TABLE>");
			lines.Add("</P>");

			#endregion

			#region Development

			if (Program.IsBeta)
			{
				lines.Add("<P class=table>");
				lines.Add("<TABLE>");

				lines.Add("<TR class=heading>");
				lines.Add("<TD>");
				lines.Add("<B>Development Links</B>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:genesis\">Project Genesis</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:exodus\">Project Exodus</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:minos\">Project Minos</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:excalibur\">Project Excalibur</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:indiana\">Project Indiana</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");

				lines.Add("</TABLE>");
				lines.Add("</P>");
			}

			#endregion

			#region More Information

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD>");
			lines.Add("<B>More Information</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (show_manual_option())
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:manual\">Read the Masterplan user manual</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=\"http://www.habitualindolence.net/masterplan/tutorials.htm\" target=_new>Watch a tutorial video</A>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>");
			lines.Add("<A href=\"http://www.habitualindolence.net/masterplan/\" target=_new>Visit the Masterplan website</A>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			lines.Add("</TABLE>");
			lines.Add("</P>");

			#endregion

			#region Latest News

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD>");
			lines.Add("<B>Latest News</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			if (!fShowHeadlines)
			{
				lines.Add("<TR>");
				lines.Add("<TD class=dimmed>");
				lines.Add("Headlines are disabled");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (fHeadlines == null)
			{
				lines.Add("<TR>");
				lines.Add("<TD class=dimmed>");
				lines.Add("Retrieving headlines...");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else if (fHeadlines.Count == 0)
			{
				lines.Add("<TR>");
				lines.Add("<TD class=dimmed>");
				lines.Add("Could not download headlines");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}
			else
			{
				fHeadlines.Sort();

				int added = 0;
				foreach (Headline item in fHeadlines)
				{
					lines.Add("<TR>");
					lines.Add("<TD>");
					lines.Add(item.Date.ToString("dd MMM") + ":");
					lines.Add("<A href=\"" + item.URL + "\" target=_new>" + item.Title + "</A>");
					lines.Add("</TD>");
					lines.Add("</TR>");

					added += 1;
					if (added == MAX_HEADLINES)
						break;
				}
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			#endregion

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			MenuBrowser.Document.OpenNew(true);
			MenuBrowser.Document.Write(HTML.Concatenate(lines));
		}

		bool show_last_file_option()
		{
			if ((Session.Preferences.LastFile == null) || (Session.Preferences.LastFile == ""))
				return false;

			return File.Exists(Session.Preferences.LastFile);
		}

		bool show_delve_option()
		{
			foreach (Library lib in Session.Libraries)
			{
				if (lib.ShowInAutoBuild)
					return true;
			}

			return false;
		}

		bool show_manual_option()
		{
			string manual_file = get_manual_filename();
			return File.Exists(manual_file);
		}

		void open_manual()
		{
			string manual_file = get_manual_filename();
			if (!File.Exists(manual_file))
				return;

			System.Diagnostics.Process.Start(manual_file);
		}

		string get_manual_filename()
		{
			Assembly ass = Assembly.GetEntryAssembly();
			return Utils.FileName.Directory(ass.FullName) + "Manual.pdf";
		}
    }
}
