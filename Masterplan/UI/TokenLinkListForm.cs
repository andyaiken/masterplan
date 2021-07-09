using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TokenLinkListForm : Form
	{
		public TokenLinkListForm(List<TokenLink> links)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fLinks = links;

			update_list();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedLink != null);
			EditBtn.Enabled = (SelectedLink != null);
		}

		List<TokenLink> fLinks = null;

		public TokenLink SelectedLink
		{
			get
			{
				if (EffectList.SelectedItems.Count != 0)
					return EffectList.SelectedItems[0].Tag as TokenLink;

				return null;
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLink != null)
			{
				fLinks.Remove(SelectedLink);
				update_list();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedLink != null)
			{
				int index = fLinks.IndexOf(SelectedLink);

				TokenLinkForm dlg = new TokenLinkForm(SelectedLink);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fLinks[index] = dlg.Link;
					update_list();
				}
			}
		}

		void update_list()
		{
			EffectList.Items.Clear();

			foreach (TokenLink link in fLinks)
			{
				string tokens = "";
				foreach (IToken token in link.Tokens)
				{
					string name = "";

					if (token is CreatureToken)
					{
						CreatureToken ct = token as CreatureToken;
						name = ct.Data.DisplayName;
					}

					if (token is Hero)
					{
						Hero hero = token as Hero;
						name = hero.Name;
					}

					if (token is CustomToken)
					{
						CustomToken ct = token as CustomToken;
						name = ct.Name;
					}

					if (name == "")
						name = "(unknown map token)";

					if (tokens != "")
						tokens += ", ";

					tokens += name;
				}

				ListViewItem lvi = EffectList.Items.Add(tokens);
				lvi.SubItems.Add(link.Text);
				lvi.Tag = link;
			}
		}
	}
}
