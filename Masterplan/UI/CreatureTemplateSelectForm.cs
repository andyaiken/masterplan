using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class CreatureTemplateSelectForm : Form
	{
		public CreatureTemplateSelectForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_list();

			Browser.DocumentText = "";
			CreatureList_SelectedIndexChanged(null, null);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (Template != null);
		}

		public CreatureTemplate Template
		{
			get
			{
				if (CreatureList.SelectedItems.Count != 0)
					return CreatureList.SelectedItems[0].Tag as CreatureTemplate;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (Template != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private void CreatureList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string html = "";
			if (Template == null)
			{
				List<string> lines = new List<string>();

				lines.AddRange(HTML.GetHead("", "", DisplaySize.Small));
				lines.Add("<BODY>");
				lines.Add("<P class=instruction>");
				lines.Add("(select a template from the list to see its details here)");
				lines.Add("</P>");
				lines.Add("</BODY>");
				lines.Add("</HTML>");

				html = HTML.Concatenate(lines);
			}
			else
			{
				html = HTML.CreatureTemplate(Template, DisplaySize.Small, false);
			}

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}

		void update_list()
		{
			CreatureList.Items.Clear();

			List<CreatureTemplate> templates = Session.Templates;
			foreach (CreatureTemplate ct in templates)
			{
				if (!match(ct, NameBox.Text))
					continue;

				ListViewItem lvi = CreatureList.Items.Add(ct.Name);
				lvi.SubItems.Add(ct.Info);
				lvi.Tag = ct;

				switch (ct.Type)
				{
					case CreatureTemplateType.Functional:
						lvi.Group = CreatureList.Groups[0];
						break;
					case CreatureTemplateType.Class:
						lvi.Group = CreatureList.Groups[1];
						break;
				}
			}
		}

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			update_list();
			CreatureList_SelectedIndexChanged(null, null);
		}

		bool match(CreatureTemplate ct, string query)
		{
			string[] tokens = query.ToLower().Split();

			foreach (string token in tokens)
			{
				if (!match_token(ct, token))
					return false;
			}

			return true;
		}

		bool match_token(CreatureTemplate ct, string token)
		{
			if (ct.Name.ToLower().Contains(token))
				return true;

			if (ct.Info.ToLower().Contains(token))
				return true;

			return false;
		}
	}
}
