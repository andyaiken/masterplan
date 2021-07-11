using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class ParcelForm : Form
	{
		public ParcelForm(Parcel p)
		{
			InitializeComponent();

			fParcel = p.Copy();

			set_controls();
		}

		public Parcel Parcel
		{
			get { return fParcel; }
		}
		Parcel fParcel = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if ((fParcel.MagicItemID == Guid.Empty) && (fParcel.ArtifactID == Guid.Empty))
			{
				fParcel.Name = NameBox.Text;
				fParcel.Details = DetailsBox.Text;
			}
		}

		private void ChangeToMundaneParcel_Click(object sender, EventArgs e)
		{
			fParcel.MagicItemID = Guid.Empty;
			fParcel.ArtifactID = Guid.Empty;

			fParcel.Name = "";
			fParcel.Details = "";

			set_controls();
		}

		private void ChangeToMagicItem_Click(object sender, EventArgs e)
		{
			// Browse for another item
			MagicItemSelectForm dlg = new MagicItemSelectForm(fParcel.FindItemLevel());
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fParcel.SetAsMagicItem(dlg.MagicItem);

				NameBox.Text = fParcel.Name;
				DetailsBox.Text = fParcel.Details;

				set_controls();
			}
		}

		private void ChangeToArtifact_Click(object sender, EventArgs e)
		{
			// Browse for another artifact
			ArtifactSelectForm dlg = new ArtifactSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fParcel.SetAsArtifact(dlg.Artifact);

				NameBox.Text = fParcel.Name;
				DetailsBox.Text = fParcel.Details;

				set_controls();
			}
		}

		private void SelectBtn_Click(object sender, EventArgs e)
		{
			if (fParcel.MagicItemID != Guid.Empty)
			{
				ChangeToMagicItem_Click(this, e);
			}
			else if (fParcel.ArtifactID != Guid.Empty)
			{
				ChangeToArtifact_Click(this, e);
			}
			else
			{
			}
		}

		private void RandomiseBtn_Click(object sender, EventArgs e)
		{
			if (fParcel.MagicItemID != Guid.Empty)
			{
				// Select a random item
				MagicItem item = Treasure.RandomMagicItem(fParcel.FindItemLevel());
				if (item != null)
					fParcel.SetAsMagicItem(item);

				set_controls();
			}
			else if (fParcel.ArtifactID != Guid.Empty)
			{
				// Select a random artifact
				Artifact item = Treasure.RandomArtifact(fParcel.FindItemTier());
				if (item != null)
					fParcel.SetAsArtifact(item);

				set_controls();
			}
			else
			{
				int value = fParcel.Value;
				if (value == 0)
					value = Treasure.GetItemValue(Session.Project.Party.Level);

				// Create random parcel of this value
				fParcel = Treasure.CreateParcel(value, false);

				NameBox.Text = fParcel.Name;
				DetailsBox.Text = fParcel.Details;

				set_controls();
			}
		}

		void set_controls()
		{
			bool magic = fParcel.MagicItemID != Guid.Empty;
			bool artifact = fParcel.ArtifactID != Guid.Empty;
			bool mundane = !magic && !artifact;

			ChangeToMundaneParcel.Enabled = !mundane;
			ChangeToMagicItem.Enabled = !magic && (Session.MagicItems.Count != 0);
			ChangeToArtifact.Enabled = !artifact && (Session.Artifacts.Count != 0);

			Browser.Visible = !mundane;
			DetailsPanel.Visible = mundane;

			SelectBtn.Enabled = magic || artifact;

			if (mundane)
			{
				NameBox.Text = fParcel.Name;
				DetailsBox.Text = fParcel.Details;
			}
			else
			{
				MagicItem item = Session.FindMagicItem(fParcel.MagicItemID, SearchType.Global);
				if (item != null)
				{
					string html = HTML.MagicItem(item, Session.Preferences.TextSize, false, true);
					Browser.DocumentText = html;
				}

				Artifact a = Session.FindArtifact(fParcel.ArtifactID, SearchType.Global);
				if (a != null)
				{
					string html = HTML.Artifact(a, Session.Preferences.TextSize, false, true);
					Browser.DocumentText = html;
				}
			}
		}
	}
}
