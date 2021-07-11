using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class ArtifactSelectForm : Form
	{
		public ArtifactSelectForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			Browser.DocumentText = "";
			ItemList_SelectedIndexChanged(null, null);
	
			update_list();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (Artifact != null);
		}

		public Artifact Artifact
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as Artifact;

				return null;
			}
		}

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			update_list();
		}

		private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string html = HTML.Artifact(Artifact, Session.Preferences.TextSize, false, true);

			Browser.Document.OpenNew(true);
			Browser.Document.Write(html);
		}

		private void ItemList_DoubleClick(object sender, EventArgs e)
		{
			if (Artifact != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		void update_list()
		{
			List<Artifact> artifacts = new List<Artifact>();
			foreach (Artifact a in Session.Artifacts)
			{
				if (match(a, NameBox.Text))
					artifacts.Add(a);
			}

			ListViewGroup lvg_heroic = ItemList.Groups.Add("Heroic Tier", "Heroic Tier");
			ListViewGroup lvg_paragon = ItemList.Groups.Add("Paragon Tier", "Paragon Tier");
			ListViewGroup lvg_epic = ItemList.Groups.Add("Epic Tier", "Epic Tier");

			List<ListViewItem> list_items = new List<ListViewItem>();
			foreach (Artifact item in artifacts)
			{
				ListViewItem lvi = new ListViewItem(item.Name);
				lvi.SubItems.Add(item.Tier + " Tier");
				lvi.Tag = item;

				switch (item.Tier)
				{
					case Tier.Heroic:
						lvi.Group = lvg_heroic;
						break;
					case Tier.Paragon:
						lvi.Group = lvg_paragon;
						break;
					case Tier.Epic:
						lvi.Group = lvg_epic;
						break;
				}

				list_items.Add(lvi);
			}

			ItemList.BeginUpdate();
			ItemList.Items.Clear();
			ItemList.Items.AddRange(list_items.ToArray());
			ItemList.EndUpdate();
		}

		bool match(Artifact item, string query)
		{
			string[] tokens = query.ToLower().Split();

			foreach (string token in tokens)
			{
				if (!match_token(item, token))
					return false;
			}

			return true;
		}

		bool match_token(Artifact item, string token)
		{
			if (item.Name.ToLower().Contains(token))
				return true;

			return false;
		}
	}
}
