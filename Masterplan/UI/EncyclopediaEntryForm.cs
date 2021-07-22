using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class EncyclopediaEntryForm : Form
	{
		public EncyclopediaEntryForm(EncyclopediaEntry entry)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			bst.Add("People");
			bst.Add("Places");
			bst.Add("Things");
			bst.Add("History");
			bst.Add("Culture");
			bst.Add("Geography");
			bst.Add("Organisations");

			foreach (EncyclopediaEntry ee in Session.Project.Encyclopedia.Entries)
			{
				if ((ee.Category != null) && (ee.Category != ""))
					bst.Add(ee.Category);
			}
			CatBox.Items.AddRange(bst.SortedList.ToArray());

			fEntry = entry.Copy();

			TitleBox.Text = fEntry.Name;
			CatBox.Text = fEntry.Category;
			DetailsBox.Text = fEntry.Details;
			DMBox.Text = fEntry.DMInfo;

			foreach (EncyclopediaEntry ee in Session.Project.Encyclopedia.Entries)
			{
				if (ee.ID == fEntry.ID)
					continue;

				ListViewItem lvi = EntryList.Items.Add(ee.Name);
				lvi.Tag = ee;
				lvi.Checked = (Session.Project.Encyclopedia.FindLink(fEntry.ID, ee.ID) != null);
			}

			if (EntryList.Items.Count == 0)
			{
				ListViewItem lvi = EntryList.Items.Add("(no entries)");
				lvi.ForeColor = SystemColors.GrayText;

                EntryList.CheckBoxes = false;
			}

			update_pictures();
		}

		~EncyclopediaEntryForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedImage != null);
			EditBtn.Enabled = (SelectedImage != null);
		}

		public EncyclopediaEntry Entry
		{
			get {return fEntry;}
		}
		EncyclopediaEntry fEntry = null;

		public EncyclopediaImage SelectedImage
		{
			get
			{
				if (PictureList.SelectedItems.Count != 0)
					return PictureList.SelectedItems[0].Tag as EncyclopediaImage;

				return null;
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fEntry.Name = TitleBox.Text;
			fEntry.Category = CatBox.Text;
			fEntry.Details = (DetailsBox.Text != DetailsBox.DefaultText) ? DetailsBox.Text : "";
			fEntry.DMInfo = (DMBox.Text != DMBox.DefaultText) ? DMBox.Text : "";

			// Remove all links containing this entry
			List<EncyclopediaLink> obsolete = new List<EncyclopediaLink>();
			foreach (EncyclopediaLink link in Session.Project.Encyclopedia.Links)
			{
				if (link.EntryIDs.Contains(fEntry.ID))
					obsolete.Add(link);
			}
			foreach (EncyclopediaLink link in obsolete)
				Session.Project.Encyclopedia.Links.Remove(link);

			// Add the required links
			foreach (ListViewItem lvi in EntryList.CheckedItems)
			{
				EncyclopediaEntry ee = lvi.Tag as EncyclopediaEntry;

				EncyclopediaLink link = new EncyclopediaLink();
				link.EntryIDs.Add(fEntry.ID);
				link.EntryIDs.Add(ee.ID);

				Session.Project.Encyclopedia.Links.Add(link);
			}
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			EncyclopediaImage img = new EncyclopediaImage();
			img.Name = "(name)";

			EncyclopediaImageForm dlg = new EncyclopediaImageForm(img);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fEntry.Images.Add(dlg.Image);
				update_pictures();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedImage != null)
			{
				fEntry.Images.Remove(SelectedImage);
				update_pictures();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedImage != null)
			{
				int index = fEntry.Images.IndexOf(SelectedImage);

				EncyclopediaImageForm dlg = new EncyclopediaImageForm(SelectedImage);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fEntry.Images[index] = dlg.Image;
					update_pictures();
				}
			}
		}

		void update_pictures()
		{
			PictureList.Items.Clear();
			PictureList.LargeImageList = null;

			const int PICTURE_SIZE = 64;

			ImageList images = new ImageList();
			images.ImageSize = new Size(PICTURE_SIZE, PICTURE_SIZE);
			images.ColorDepth = ColorDepth.Depth32Bit;
			PictureList.LargeImageList = images;

			foreach (EncyclopediaImage img in fEntry.Images)
			{
				ListViewItem lvi = PictureList.Items.Add(img.Name);
				lvi.Tag = img;

				Image bmp = new Bitmap(PICTURE_SIZE, PICTURE_SIZE);
				Graphics g = Graphics.FromImage(bmp);
				if (img.Image.Size.Width > img.Image.Size.Height)
				{
					int height = (img.Image.Size.Height * PICTURE_SIZE) / img.Image.Size.Width;
					Rectangle rect = new Rectangle(0, (PICTURE_SIZE - height) / 2, PICTURE_SIZE, height);

					g.DrawImage(img.Image, rect);
				}
				else
				{
					int width = (img.Image.Size.Width * PICTURE_SIZE) / img.Image.Size.Height;
					Rectangle rect = new Rectangle((PICTURE_SIZE - width) / 2, 0, width, PICTURE_SIZE);

					g.DrawImage(img.Image, rect);
				}

				images.Images.Add(bmp);
				lvi.ImageIndex = images.Images.Count - 1;
			}

			if (PictureList.Items.Count == 0)
			{
				ListViewItem lvi = PictureList.Items.Add("(no images)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
