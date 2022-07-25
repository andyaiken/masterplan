using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

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

		public WelcomePanel()
		{
			InitializeComponent();

			SetStyle(ControlStyles.AllPaintingInWmPaint
				| ControlStyles.OptimizedDoubleBuffer
				| ControlStyles.ResizeRedraw
				| ControlStyles.UserPaint, true);

			MenuBrowser.DocumentText = "";
			RefreshOptions();
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

		#region Events

		[Category("Actions")]
		public event EventHandler NewProjectClicked;

		[Category("Actions")]
		public event EventHandler OpenProjectClicked;

		[Category("Actions")]
		public event EventHandler OpenLastProjectClicked;

		[Category("Actions")]
		public event EventHandler DelveClicked;

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

		#endregion

		public void RefreshOptions()
		{
			List<string> lines = new List<string>();

			lines.Add("<HTML>");
			lines.AddRange(HTML.GetHead("Masterplan", "Main Menu", Session.Preferences.TextSize));
			lines.Add("<BODY>");

			#region Getting Started

			lines.Add("<P class=table>");
			lines.Add("<TABLE class=wide>");
			
			lines.Add("<TR class=heading>");
			lines.Add("<TD>");
			lines.Add("<B>" + Session.I18N.GettingStarted + "</B>");
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

			if (show_delve_option())
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:delve\">Generate a random dungeon delve</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			if (show_manual_option())
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<A href=\"masterplan:manual\">Read the Masterplan user manual</A>");
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

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
			return FileName.Directory(ass.FullName) + "Manual.pdf";
		}
    }
}
