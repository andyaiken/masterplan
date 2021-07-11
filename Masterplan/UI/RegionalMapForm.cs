using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Controls;
using Masterplan.Data;

namespace Masterplan.UI
{
	partial class RegionalMapForm : Form
	{
		public RegionalMapForm(RegionalMap map, MapLocation loc)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fMap = map.Copy();

			NameBox.Text = fMap.Name;
			MapPanel.Map = fMap;

			if (loc != null)
			{
				// Disable editing

				NameBox.Enabled = false;
				Toolbar.Visible = false;

				OKBtn.Visible = false;
				CancelBtn.Text = "Close";

				MapPanel.Mode = MapViewMode.Plain;
				MapPanel.HighlightedLocation = loc;
			}
		}

		~RegionalMapForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			PasteBtn.Enabled = Clipboard.ContainsImage();
			RemoveBtn.Enabled = (MapPanel.SelectedLocation != null);
			EditBtn.Enabled = (MapPanel.SelectedLocation != null);
			EntryBtn.Enabled = (MapPanel.SelectedLocation != null);
		}

		public RegionalMap Map
		{
			get { return fMap; }
		}
		RegionalMap fMap = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fMap.Name = NameBox.Text;
		}

		private void BrowseBtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog open_dlg = new OpenFileDialog();
			open_dlg.Filter = Program.ImageFilter;
			if (open_dlg.ShowDialog() != DialogResult.OK)
				return;

			MapPanel.Map.Image = Image.FromFile(open_dlg.FileName);
			Program.SetResolution(MapPanel.Map.Image);
			MapPanel.Invalidate();
		}

		private void PasteBtn_Click(object sender, EventArgs e)
		{
			if (Clipboard.ContainsImage())
			{
				MapPanel.Map.Image = Clipboard.GetImage();
				Program.SetResolution(MapPanel.Map.Image);
				MapPanel.Invalidate();
			}
		}

		private void MapContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			set_click_location();

			MapContextAddLocation.Enabled = (fRightClickLocation != PointF.Empty);
			MapContextRemove.Enabled = (MapPanel.SelectedLocation != null);
			MapContextEdit.Enabled = (MapPanel.SelectedLocation != null);
		}

		private void MapContextAddLocation_Click(object sender, EventArgs e)
		{
			if (fRightClickLocation == PointF.Empty)
				return;

			MapLocation loc = new MapLocation();
			loc.Name = "New Location";
			loc.Point = fRightClickLocation;

			MapLocationForm dlg = new MapLocationForm(loc);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fMap.Locations.Add(loc);
				MapPanel.Invalidate();

				Session.Modified = true;
			}
		}

		private void MapContextRemove_Click(object sender, EventArgs e)
		{
			if (MapPanel.SelectedLocation != null)
			{
				MapPanel.Map.Locations.Remove(MapPanel.SelectedLocation);
				MapPanel.Invalidate();

				Session.Modified = true;
			}
		}

		private void MapContextEdit_Click(object sender, EventArgs e)
		{
			if (MapPanel.SelectedLocation != null)
			{
				int index = fMap.Locations.IndexOf(MapPanel.SelectedLocation);

				MapLocationForm dlg = new MapLocationForm(MapPanel.SelectedLocation);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fMap.Locations[index] = dlg.MapLocation;
					MapPanel.Invalidate();

					Session.Modified = true;
				}
			}
		}

		private void MapPanel_DoubleClick(object sender, EventArgs e)
		{
			if (MapPanel.SelectedLocation == null)
			{
				set_click_location();
				MapContextAddLocation_Click(sender, e);
			}
			else
			{
				MapContextEdit_Click(sender, e);
			}
		}

		PointF fRightClickLocation = PointF.Empty;

		void set_click_location()
		{
			fRightClickLocation = PointF.Empty;

			Point mouse = MapPanel.PointToClient(Cursor.Position);
			RectangleF rect = MapPanel.MapRectangle;
			if (rect.Contains(mouse))
			{
				float dx = (mouse.X - rect.X) / rect.Width;
				float dy = (mouse.Y - rect.Y) / rect.Height;

				fRightClickLocation = new PointF(dx, dy);
			}
		}

		private void EntryBtn_Click(object sender, EventArgs e)
		{
			if (MapPanel.SelectedLocation == null)
				return;

			EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(MapPanel.SelectedLocation.ID);

			if (entry == null)
			{
				// If there is no entry, ask to create it
				string msg = "There is no encyclopedia entry associated with this location.";
				msg += Environment.NewLine;
				msg += "Would you like to create one now?";
				if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;

				entry = new EncyclopediaEntry();
				entry.Name = MapPanel.SelectedLocation.Name;
				entry.AttachmentID = MapPanel.SelectedLocation.ID;
				entry.Category = MapPanel.SelectedLocation.Category;
				if (entry.Category == "")
					entry.Category = "Places";

				Session.Project.Encyclopedia.Entries.Add(entry);
				Session.Modified = true;
			}

			// Edit the entry
			int index = Session.Project.Encyclopedia.Entries.IndexOf(entry);
			EncyclopediaEntryForm dlg = new EncyclopediaEntryForm(entry);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Encyclopedia.Entries[index] = dlg.Entry;
				Session.Modified = true;
			}
		}
	}
}
