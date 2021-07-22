using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class RegionalMapListForm : Form
	{
		public RegionalMapListForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			update_maps();
		}

		~RegionalMapListForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedMap != null);
			EditBtn.Enabled = (SelectedMap != null);

			LocationMenu.Enabled = (MapPanel.SelectedLocation != null);
			ToolsMenu.Enabled = (SelectedMap != null);
		}

		#region Properties

		public RegionalMap SelectedMap
		{
			get
			{
				if (MapList.SelectedItems.Count != 0)
					return MapList.SelectedItems[0].Tag as RegionalMap;

				return null;
			}
			set
			{
				MapList.SelectedItems.Clear();

				foreach (ListViewItem lvi in MapList.Items)
				{
					if (lvi.Tag == value)
						lvi.Selected = true;
				}
			}
		}

		#endregion

		#region List Toolbar

		private void AddBtn_Click(object sender, EventArgs e)
		{
			RegionalMap m = new RegionalMap();
			m.Name = "New Map";

			RegionalMapForm dlg = new RegionalMapForm(m, null);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.RegionalMaps.Add(dlg.Map);
				Session.Modified = true;

				update_maps();

				SelectedMap = dlg.Map;
			}
		}

		private void AddImportProject_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.ProjectFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Project p = Serialisation<Project>.Load(dlg.FileName, SerialisationMode.Binary);
				if (p != null)
				{
					RegionalMapSelectForm map_dlg = new RegionalMapSelectForm(p.RegionalMaps, null, true);
					if (map_dlg.ShowDialog(this) != DialogResult.OK)
						return;

					Session.Project.RegionalMaps.AddRange(map_dlg.Maps);
					Session.Modified = true;

					update_maps();
				}
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				string msg = "Are you sure you want to delete this map?";
				DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.No)
					return;

				Session.Project.RegionalMaps.Remove(SelectedMap);
				Session.Modified = true;

				update_maps();
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				int index = Session.Project.RegionalMaps.IndexOf(SelectedMap);

				RegionalMapForm dlg = new RegionalMapForm(SelectedMap, null);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.RegionalMaps[index] = dlg.Map;
					Session.Modified = true;

					update_maps();

					SelectedMap = dlg.Map;
				}
			}
		}

		#endregion

		#region Map Toolbar

		private void LocationEntry_Click(object sender, EventArgs e)
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

		private void ToolsExport_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.FileName = SelectedMap.Name;
				dlg.Filter = "Bitmap Image |*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ImageFormat format = ImageFormat.Bmp;
					switch (dlg.FilterIndex)
					{
						case 1:
							format = ImageFormat.Bmp;
							break;
						case 2:
							format = ImageFormat.Jpeg;
							break;
						case 3:
							format = ImageFormat.Gif;
							break;
						case 4:
							format = ImageFormat.Png;
							break;
					}

					MapPanel.Map.Image.Save(dlg.FileName, format);
				}
			}
		}

		private void ToolsPlayerView_Click(object sender, EventArgs e)
		{
			if (SelectedMap != null)
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowRegionalMap(MapPanel);
			}
		}

		#endregion

		private void MapList_SelectedIndexChanged(object sender, EventArgs e)
		{
			MapPanel.Map = SelectedMap;
		}

		void update_maps()
		{
			MapList.Items.Clear();

			foreach (RegionalMap m in Session.Project.RegionalMaps)
			{
				ListViewItem lvi = MapList.Items.Add(m.Name);
				lvi.Tag = m;
			}

			if (MapList.Items.Count == 0)
			{
				ListViewItem lvi = MapList.Items.Add("(no maps)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
