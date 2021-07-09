using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Utils;

using Masterplan.Controls;
using Masterplan.Data;
using Masterplan.Events;
using Masterplan.Extensibility;
using Masterplan.Tools;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class MainForm : Form
	{
		public enum ViewType
		{
			Flowchart,
			Delve,
			Map
		}

		public MainForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			#region Initialise web browser controls

			try
			{
				Preview.DocumentText = "";
				BackgroundDetails.DocumentText = "";
				EntryDetails.DocumentText = "";
				RulesBrowser.DocumentText = "";
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			#endregion

			#region Extensibility

			try
			{
				fExtensibility = new ExtensibilityManager(this);
				foreach (IAddIn addin in fExtensibility.AddIns)
				{
					foreach (IPage addin_page in addin.Pages)
					{
						TabPage page = new TabPage(addin_page.Name);
						Pages.TabPages.Add(page);

						page.Controls.Add(addin_page.Control);
						addin_page.Control.Dock = DockStyle.Fill;
					}

					foreach (IPage page in addin.QuickReferencePages)
					{
						TabPage tabpage = new TabPage();
						tabpage.Text = page.Name;

						tabpage.Controls.Add(page.Control);
						page.Control.Dock = DockStyle.Fill;

						ReferencePages.TabPages.Add(tabpage);
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			#endregion

			#region Welcome panel

			try
			{
				if (Session.Project == null)
				{
					Controls.Clear();

					fWelcome = new WelcomePanel();
					fWelcome.Dock = DockStyle.Fill;

					fWelcome.NewProjectClicked += new EventHandler(Welcome_NewProjectClicked);
					fWelcome.OpenProjectClicked += new EventHandler(Welcome_OpenProjectClicked);
					fWelcome.OpenLastProjectClicked += new EventHandler(Welcome_OpenLastProjectClicked);
					fWelcome.DelveClicked += new EventHandler(Welcome_DelveClicked);

					Controls.Add(fWelcome);
					Controls.Add(MainMenu);
				}
				else
				{
					PlotView.Plot = Session.Project.Plot;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			#endregion

			#region User preferences

			try
			{
				NavigationSplitter.Panel1Collapsed = !Session.Preferences.ShowNavigation;
				PreviewSplitter.Panel2Collapsed = !Session.Preferences.ShowPreview;
				PlotView.LinkStyle = Session.Preferences.LinkStyle;
				WorkspaceSearchBar.Visible = false;

				update_encyclopedia_templates();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			#endregion

			#region Set window position

			try
			{
				if (Session.Preferences.Maximised)
				{
					WindowState = FormWindowState.Maximized;
				}
				else if ((Session.Preferences.Size != Size.Empty) && (Session.Preferences.Location != Point.Empty))
				{
					StartPosition = FormStartPosition.Manual;

					int width = Math.Max(Width, Session.Preferences.Size.Width);
					int height = Math.Max(Height, Session.Preferences.Size.Height);
					Size = new Size(width, height);

					int x = Math.Max(Left, Session.Preferences.Location.X);
					int y = Math.Max(Top, Session.Preferences.Location.Y);
					Location = new Point(x, y);
				}
				else
				{
					StartPosition = FormStartPosition.CenterScreen;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			#endregion

			update_title();
			UpdateView();
		}

		#region Properties

		public Background SelectedBackground
		{
			get
			{
				if (BackgroundList.SelectedItems.Count != 0)
					return BackgroundList.SelectedItems[0].Tag as Background;

				return null;
			}
			set
			{
				BackgroundList.SelectedItems.Clear();

				if (value != null)
				{
					foreach (ListViewItem lvi in BackgroundList.Items)
					{
						Background bg = lvi.Tag as Background;
						if ((bg != null) && (bg.ID == value.ID))
							lvi.Selected = true;
					}
				}

				update_background_item();
			}
		}

		public IEncyclopediaItem SelectedEncyclopediaItem
		{
			get
			{
				if (EntryList.SelectedItems.Count != 0)
					return EntryList.SelectedItems[0].Tag as IEncyclopediaItem;

				return null;
			}
			set
			{
				EntryList.SelectedItems.Clear();

				if (value != null)
				{
					foreach (ListViewItem lvi in EntryList.Items)
					{
						IEncyclopediaItem entry = lvi.Tag as IEncyclopediaItem;
						if ((entry != null) && (entry.ID == value.ID))
							lvi.Selected = true;
					}
				}

				update_encyclopedia_entry();
			}
		}

		public EncyclopediaImage SelectedEncyclopediaImage
		{
			get
			{
				if (EntryImageList.SelectedItems.Count != 0)
					return EntryImageList.SelectedItems[0].Tag as EncyclopediaImage;

				return null;
			}
		}

		/*
		public EncyclopediaEntry SelectedEntry
		{
			get
			{
				if (EntryList.SelectedItems.Count != 0)
					return EntryList.SelectedItems[0].Tag as EncyclopediaEntry;

				return null;
			}
			set
			{
				EntryList.SelectedItems.Clear();

				if (value != null)
				{
					foreach (ListViewItem lvi in EntryList.Items)
					{
						EncyclopediaEntry entry = lvi.Tag as EncyclopediaEntry;
						if ((entry != null) && (entry.ID == value.ID))
							lvi.Selected = true;
					}
				}

				update_entry();
			}
		}

		public EncyclopediaGroup SelectedGroup
		{
			get
			{
				if (EntryList.SelectedItems.Count != 0)
					return EntryList.SelectedItems[0].Tag as EncyclopediaGroup;

				return null;
			}
			set
			{
				EntryList.SelectedItems.Clear();

				if (value != null)
				{
					foreach (ListViewItem lvi in EntryList.Items)
					{
						EncyclopediaGroup group = lvi.Tag as EncyclopediaGroup;
						if ((group != null) && (group.ID == value.ID))
							lvi.Selected = true;
					}
				}

				update_entry();
			}
		}
		*/

		public IPlayerOption SelectedRule
		{
			get
			{
				if (RulesList.SelectedItems.Count != 0)
					return RulesList.SelectedItems[0].Tag as IPlayerOption;

				return null;
			}
			set
			{
				RulesList.SelectedItems.Clear();

				if (value != null)
				{
					foreach (ListViewItem lvi in RulesList.Items)
					{
						IPlayerOption n = lvi.Tag as IPlayerOption;
						if ((n != null) && (n.ID == value.ID))
							lvi.Selected = true;
					}
				}
			}
		}

		public List<Attachment> SelectedAttachments
		{
			get
			{
				List<Attachment> attachments = new List<Attachment>();

				foreach (ListViewItem lvi in AttachmentList.SelectedItems)
				{
					Attachment att = lvi.Tag as Attachment;
					if (att != null)
						attachments.Add(att);
				}

				return attachments;
			}
		}

		public Note SelectedNote
		{
			get
			{
				if (NoteList.SelectedItems.Count != 0)
					return NoteList.SelectedItems[0].Tag as Note;

				return null;
			}
			set
			{
				NoteList.SelectedItems.Clear();

				if (value != null)
				{
					foreach (ListViewItem lvi in NoteList.Items)
					{
						Note n = lvi.Tag as Note;
						if ((n != null) && (n.ID == value.ID))
							lvi.Selected = true;
					}
				}
			}
		}

		public IIssue SelectedIssue
		{
			get
			{
				if (NoteList.SelectedItems.Count != 0)
					return NoteList.SelectedItems[0].Tag as IIssue;

				return null;
			}
		}

		WelcomePanel fWelcome = null;
		ExtensibilityManager fExtensibility = null;

		bool fUpdating = false;

		ViewType fView = ViewType.Flowchart;

		MapView fDelveView = null;
		RegionalMapPanel fMapView = null;

		string fPartyBreakdownSecondary = "";

		#endregion

		#region Event handlers

		#region Form

		void Application_Idle(object sender, EventArgs e)
		{
			try
			{
				if (Pages.SelectedTab == WorkspacePage)
				{
					PlotPoint selected_point = get_selected_point();

					RemoveBtn.Enabled = (selected_point != null);
					PlotCutBtn.Enabled = (selected_point != null);
					PlotCopyBtn.Enabled = (selected_point != null);
					PlotPasteBtn.Enabled = (Clipboard.ContainsData(typeof(PlotPoint).ToString()) || Clipboard.ContainsText());
					SearchBtn.Checked = WorkspaceSearchBar.Visible;
					PlotClearBtn.Visible = (PlotSearchBox.Text != "");

					//EditBtn.Enabled = ((fView == ViewType.Flowchart) && (selected_point != null));
					//ExploreBtn.Enabled = ((fView == ViewType.Flowchart) && (selected_point != null));
					EditBtn.Enabled = (selected_point != null);
					ExploreBtn.Enabled = (selected_point != null);
					PlotPointMenu.Enabled = (selected_point != null);
					PlotPointPlayerView.Enabled = ((selected_point != null) && (selected_point.ReadAloud != ""));
					PlotPointExportHTML.Enabled = (selected_point != null);

					ContextRemove.Enabled = RemoveBtn.Enabled;
					ContextEdit.Enabled = EditBtn.Enabled;
					ContextExplore.Enabled = EditBtn.Enabled;
					ContextState.Enabled = (selected_point != null);

					FlowchartAllXP.Checked = Session.Preferences.AllXP;
				}

				if (Pages.SelectedTab == BackgroundPage)
				{
					BackgroundRemoveBtn.Enabled = (SelectedBackground != null);
					BackgroundEditBtn.Enabled = (SelectedBackground != null);

					BackgroundUpBtn.Enabled = ((SelectedBackground != null) && (Session.Project.Backgrounds.IndexOf(SelectedBackground) != 0));
					BackgroundDownBtn.Enabled = ((SelectedBackground != null) && (Session.Project.Backgrounds.IndexOf(SelectedBackground) != Session.Project.Backgrounds.Count - 1));

					BackgroundPlayerViewSelected.Enabled = ((SelectedBackground != null) && (SelectedBackground.Details != ""));
					BackgroundPlayerViewAll.Enabled = ((Session.Project != null) && (Session.Project.Backgrounds.Count != 0));
				}

				if (Pages.SelectedTab == EncyclopediaPage)
				{
					EncAddGroup.Enabled = ((Session.Project != null) && (Session.Project.Encyclopedia.Entries.Count != 0));
					EncRemoveBtn.Enabled = (SelectedEncyclopediaItem != null);
					EncEditBtn.Enabled = (SelectedEncyclopediaItem != null);

					EncCutBtn.Enabled = ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaEntry));
					EncCopyBtn.Enabled = ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaEntry));
					EncPasteBtn.Enabled = (Clipboard.ContainsData(typeof(EncyclopediaEntry).ToString()) || Clipboard.ContainsText());

					EncPlayerView.Enabled = (SelectedEncyclopediaItem != null);

					EncShareExport.Enabled = ((Session.Project != null) && (Session.Project.Encyclopedia.Entries.Count != 0));
					EncSharePublish.Enabled = ((Session.Project != null) && (Session.Project.Encyclopedia.Entries.Count != 0));

					EncClearLbl.Visible = (EncSearchBox.Text != "");
				}

				if (Pages.SelectedTab == RulesPage)
				{
					RulesRemoveBtn.Enabled = (SelectedRule != null);
					RulesEditBtn.Enabled = (SelectedRule != null);

					RulesPlayerViewBtn.Enabled = (SelectedRule != null);
					RuleEncyclopediaBtn.Enabled = (SelectedRule != null);
					//RulesExportBtn.Enabled = (SelectedRule != null);

					RulesShareExport.Enabled = ((Session.Project != null) && (Session.Project.PlayerOptions.Count != 0));
					RulesSharePublish.Enabled = ((Session.Project != null) && (Session.Project.PlayerOptions.Count != 0));
				}

				if (Pages.SelectedTab == AttachmentsPage)
				{
					AttachmentImportBtn.Enabled = true;
					AttachmentRemoveBtn.Enabled = (SelectedAttachments.Count != 0);
					AttachmentExtract.Enabled = (SelectedAttachments.Count != 0);
					AttachmentPlayerView.Enabled = ((SelectedAttachments.Count == 1) && (SelectedAttachments[0].Type != AttachmentType.Miscellaneous));
				}

				if (Pages.SelectedTab == JotterPage)
				{
					NoteRemoveBtn.Enabled = (SelectedNote != null);
					NoteCategoryBtn.Enabled = (SelectedNote != null);

					NoteCutBtn.Enabled = (SelectedNote != null);
					NoteCopyBtn.Enabled = (SelectedNote != null);
					NotePasteBtn.Enabled = (Clipboard.ContainsData(typeof(Note).ToString()) || Clipboard.ContainsText());
					NoteClearLbl.Visible = (NoteSearchBox.Text != "");
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys key)
		{
			if (Session.Project != null)
			{
				if (Pages.SelectedTab == WorkspacePage)
				{
					if (key == (Keys.Control | Keys.A))
					{
						AddBtn_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.X))
					{
						CutBtn_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.C))
					{
						CopyBtn_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.V))
					{
						PasteBtn_Click(null, null);
						return true;
					}
					else
					{
						bool handled = PlotView.Navigate(key);
						if (handled)
							return true;
					}
				}

				if (Pages.SelectedTab == BackgroundPage)
				{
					if (key == (Keys.Control | Keys.A))
					{
						BackgroundAddBtn_Click(null, null);
						return true;
					}
				}

				if (Pages.SelectedTab == EncyclopediaPage)
				{
					if (key == (Keys.Control | Keys.A))
					{
						EncAddEntry_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.X))
					{
						EncCutBtn_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.C))
					{
						EncCopyBtn_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.V))
					{
						EncPasteBtn_Click(null, null);
						return true;
					}
				}

				if (Pages.SelectedTab == AttachmentsPage)
				{
					if (key == (Keys.Control | Keys.A))
					{
						AttachmentImportBtn_Click(null, null);
						return true;
					}
				}

				if (Pages.SelectedTab == JotterPage)
				{
					//if (key == (Keys.Control | Keys.A))
					//{
					//	NoteAddBtn_Click(null, null);
					//	return true;
					//}
					//else
					if (key == (Keys.Control | Keys.X))
					{
						NoteCutBtn_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.C))
					{
						NoteCopyBtn_Click(null, null);
						return true;
					}
					else if (key == (Keys.Control | Keys.V))
					{
						NotePasteBtn_Click(null, null);
						return true;
					}
				}
			}

			return base.ProcessCmdKey(ref msg, key);
		}

		private void MainForm_Layout(object sender, LayoutEventArgs e)
		{
			try
			{
				//
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			try
			{
				Session.MainForm = this;

				if (Program.SplashScreen != null)
				{
					Program.SplashScreen.Close();
					Program.SplashScreen = null;
				}

				PlotView_SelectionChanged(null, null);
				NoteList_SelectedIndexChanged(null, null);

				if ((Session.DisabledLibraries != null) && (Session.DisabledLibraries.Count != 0))
				{
					string str = "Due to copy protection, some libraries were not loaded:";
					str += Environment.NewLine;

					List<string> libs = new List<string>(Session.DisabledLibraries);
					int count = Math.Min(libs.Count, 6);
					for (int n = 0; n != count; ++n)
					{
						int index = Session.Random.Next(libs.Count);
						string item = libs[index];
						libs.Remove(item);

						str += Environment.NewLine;
						str += "* " + item;
					}

					if (libs.Count > 0)
					{
						str += Environment.NewLine + Environment.NewLine;
						str += "... and " + libs.Count + " others.";
					}

					MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

				if ((Session.Project == null) && (Session.Creatures.Count == 0))
				{
					string mp_dir = FileName.Directory(Application.ExecutablePath);
					if (mp_dir.Contains("Program Files"))
					{
						string str = "You're running Masterplan from the Program Files folder.";
						str += Environment.NewLine + Environment.NewLine;
						str += "Although Masterplan will run, this is a protected folder, and Masterplan won't be able to save any changes that you make to your libraries.";
						str += Environment.NewLine + Environment.NewLine;
						str += "If you move Masterplan to a new location (like My Documents or the Desktop), you won't have this problem.";

						MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						//string str = "You do not have any libraries containing creatures. You need these to use Masterplan's encounter building features.";
						//str += Environment.NewLine;
						//str += Environment.NewLine;
						//str += "Would you like to enter details for some creatures now, or load a library file?";

						//if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						//    ToolsLibraries_Click(sender, e);
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (!check_modified())
					e.Cancel = true;

				if (Session.FileName != "")
					Session.Preferences.LastFile = Session.FileName;

				Session.Preferences.Maximised = (WindowState == FormWindowState.Maximized);
				if (!Session.Preferences.Maximised)
				{
					Session.Preferences.Maximised = false;
					Session.Preferences.Size = Size;
					Session.Preferences.Location = Location;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Preview

		private void Preview_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			try
			{
				#region Plot

				if (e.Url.Scheme == "plot")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "add")
						AddBtn_Click(sender, e);

					if (e.Url.LocalPath == "encounter")
					{
						if (PlotView.SelectedPoint == null)
						{
							AddEncounter_Click(sender, e);
						}
						else
						{
							PlotView.SelectedPoint.Element = new Encounter();
							if (!edit_element(null, null))
								PlotView.SelectedPoint.Element = null;
						}
					}

					if (e.Url.LocalPath == "challenge")
					{
						if (PlotView.SelectedPoint == null)
						{
							AddChallenge_Click(sender, e);
						}
						else
						{
							SkillChallenge sc = new SkillChallenge();
							sc.Level = Session.Project.Party.Level;

							PlotView.SelectedPoint.Element = sc;
							if (!edit_element(null, null))
								PlotView.SelectedPoint.Element = null;
						}
					}

					if (e.Url.LocalPath == "edit")
						EditBtn_Click(sender, e);

					if (e.Url.LocalPath == "explore")
						ExploreBtn_Click(sender, e);

					if (e.Url.LocalPath == "properties")
						ProjectProject_Click(sender, e);

					if (e.Url.LocalPath == "up")
					{
						PlotPoint pp = Session.Project.FindParent(PlotView.Plot);
						if (pp != null)
						{
							Plot plot = Session.Project.FindParent(pp);
							if (plot != null)
							{
								if (fView != ViewType.Flowchart)
									flowchart_view();

								PlotView.Plot = plot;
								PlotView.SelectedPoint = pp;

								UpdateView();
							}
						}
					}

					if (e.Url.LocalPath == "element")
						edit_element(sender, e);

					if (e.Url.LocalPath == "run")
						run_encounter(sender, e);

					if (e.Url.LocalPath == "maparea")
					{
						PlotPoint point = get_selected_point();

						Map map = null;
						MapArea map_area = null;
						point.GetTacticalMapArea(ref map, ref map_area);

						edit_map_area(map, map_area, null);
					}

					if (e.Url.LocalPath == "maploc")
					{
						PlotPoint point = get_selected_point();

						RegionalMap map = null;
						MapLocation loc = null;
						point.GetRegionalMapArea(ref map, ref loc, Session.Project);

						show_map_location(map, loc);
					}
				}

				#endregion

				#region Encyclopedia Entry

				if (e.Url.Scheme == "entry")
                {
                    e.Cancel = true;

                    Guid entry_id = new Guid(e.Url.LocalPath);
                    EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntry(entry_id);
                    if (entry != null)
                    {
						EncyclopediaEntryDetailsForm dlg = new EncyclopediaEntryDetailsForm(entry);
						dlg.ShowDialog();
                        //SelectedEncyclopediaItem = entry;
                        //Pages.SelectedTab = EncyclopediaPage;
                    }
				}

				#endregion

				#region Magic Item

				if (e.Url.Scheme == "item")
				{
					e.Cancel = true;

					Guid item_id = new Guid(e.Url.LocalPath);
					MagicItem item = Session.FindMagicItem(item_id, SearchType.Global);
					if (item != null)
					{
						MagicItemDetailsForm dlg = new MagicItemDetailsForm(item);
						dlg.ShowDialog();
					}
				}

				#endregion

				#region Delve View

				if (e.Url.Scheme == "delveview")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "select")
					{
						MapSelectForm dlg = new MapSelectForm(Session.Project.Maps, null, false);
						if (dlg.ShowDialog() == DialogResult.OK)
							delve_view(dlg.Map);
					}
					else if (e.Url.LocalPath == "off")
					{
						flowchart_view();
					}
					else if (e.Url.LocalPath == "edit")
					{
						delve_view_edit();
					}
					else if (e.Url.LocalPath == "build")
					{
						Map m = new Map();
						m.Name = "New Map";

						MapBuilderForm dlg = new MapBuilderForm(m, false);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							Session.Project.Maps.Add(dlg.Map);
							delve_view(dlg.Map);
						}
					}
					else if (e.Url.LocalPath == "playerview")
					{
						MapView view = new MapView();
						view.Map = fDelveView.Map;
						view.Plot = PlotView.Plot;
						view.Mode = MapViewMode.PlayerView;
						view.LineOfSight = false;
						view.BorderSize = 1;
						view.HighlightAreas = false;

						// Show only the explored area
						bool explored = false;
						int left = int.MaxValue;
						int right = int.MinValue;
						int top = int.MaxValue;
						int bottom = int.MinValue;
						foreach (MapArea area in fDelveView.Map.Areas)
						{
							PlotPoint point = PlotView.Plot.FindPointForMapArea(fDelveView.Map, area);
							if (point != null)
							{
								if (point.State == PlotPointState.Completed)
								{
									explored = true;

									left = Math.Min(left, area.Region.Left);
									right = Math.Max(right, area.Region.Right);
									top = Math.Min(top, area.Region.Top);
									bottom = Math.Max(bottom, area.Region.Bottom);
								}
							}
						}
						if (explored)
							view.Viewpoint = new Rectangle(left, top, right - left, bottom - top);

						if (Session.PlayerView == null)
							Session.PlayerView = new PlayerViewForm(this);
						Session.PlayerView.ShowTacticalMap(view, null);
					}
					else
					{
						Guid map_id = new Guid(e.Url.LocalPath);
						Map map = Session.Project.FindTacticalMap(map_id);
						if (map != null)
							delve_view(map);
					}
				}

				#endregion

				#region Map View

				if (e.Url.Scheme == "mapview")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "select")
					{
						RegionalMapSelectForm dlg = new RegionalMapSelectForm(Session.Project.RegionalMaps, null, false);
						if (dlg.ShowDialog() == DialogResult.OK)
							map_view(dlg.Map);
					}
					else if (e.Url.LocalPath == "off")
					{
						flowchart_view();
					}
					else if (e.Url.LocalPath == "edit")
					{
						map_view_edit();
					}
					else if (e.Url.LocalPath == "build")
					{
						RegionalMap m = new RegionalMap();
						m.Name = "New Map";

						RegionalMapForm dlg = new RegionalMapForm(m, null);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							Session.Project.RegionalMaps.Add(dlg.Map);
							map_view(dlg.Map);
						}
					}
					else if (e.Url.LocalPath == "playerview")
					{
						RegionalMapPanel view = new RegionalMapPanel();
						view.Map = fMapView.Map;
						view.Plot = PlotView.Plot;
						view.Mode = MapViewMode.PlayerView;

						if (Session.PlayerView == null)
							Session.PlayerView = new PlayerViewForm(this);
						Session.PlayerView.ShowRegionalMap(view);
					}
					else
					{
						Guid map_id = new Guid(e.Url.LocalPath);
						RegionalMap map = Session.Project.FindRegionalMap(map_id);
						if (map != null)
							map_view(map);
					}
				}

				#endregion

				#region Map Area

				if (e.Url.Scheme == "maparea")
				{
					e.Cancel = true;

					MapView mapview = null;

					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if (ctrl is MapView)
						{
							mapview = ctrl as MapView;
							break;
						}
					}

					if ((mapview == null) || (mapview.SelectedArea == null))
						return;

					if (e.Url.LocalPath == "edit")
					{
						edit_map_area(mapview.Map, mapview.SelectedArea, mapview);
					}

					if (e.Url.LocalPath == "create")
					{
						PlotPoint pp = new PlotPoint(mapview.SelectedArea.Name);
						pp.Element = new MapElement(mapview.Map.ID, mapview.SelectedArea.ID);

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, false);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}

					if (e.Url.LocalPath == "encounter")
					{
						Encounter enc = new Encounter();
						enc.MapID = mapview.Map.ID;
						enc.MapAreaID = mapview.SelectedArea.ID;
						enc.SetStandardEncounterNotes();

						PlotPoint pp = new PlotPoint(mapview.SelectedArea.Name);
						pp.Element = enc;

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}

					if (e.Url.LocalPath == "trap")
					{
						TrapElement te = new TrapElement();
						te.Trap.Name = mapview.SelectedArea.Name;
						te.MapID = mapview.Map.ID;
						te.MapAreaID = mapview.SelectedArea.ID;

						PlotPoint pp = new PlotPoint(mapview.SelectedArea.Name);
						pp.Element = te;

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}

					if (e.Url.LocalPath == "challenge")
					{
						SkillChallenge sc = new SkillChallenge();
						sc.Name = mapview.SelectedArea.Name;
						sc.MapID = mapview.Map.ID;
						sc.MapAreaID = mapview.SelectedArea.ID;
						sc.Level = Session.Project.Party.Level;

						PlotPoint pp = new PlotPoint(mapview.SelectedArea.Name);
						pp.Element = sc;

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}
				}

				#endregion

				#region Map Location

				if (e.Url.Scheme == "maploc")
				{
					e.Cancel = true;

					RegionalMapPanel mapview = null;

					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if (ctrl is RegionalMapPanel)
						{
							mapview = ctrl as RegionalMapPanel;
							break;
						}
					}

					if ((mapview == null) || (mapview.SelectedLocation == null))
						return;

					if (e.Url.LocalPath == "edit")
					{
						edit_map_location(mapview.Map, mapview.SelectedLocation, mapview);
					}

					if (e.Url.LocalPath == "create")
					{
						PlotPoint pp = new PlotPoint(mapview.SelectedLocation.Name);
						pp.RegionalMapID = mapview.Map.ID;
						pp.MapLocationID = mapview.SelectedLocation.ID;

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, false);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}

					if (e.Url.LocalPath == "encounter")
					{
						Encounter enc = new Encounter();
						enc.SetStandardEncounterNotes();

						PlotPoint pp = new PlotPoint(mapview.SelectedLocation.Name);
						pp.RegionalMapID = mapview.Map.ID;
						pp.MapLocationID = mapview.SelectedLocation.ID;
						pp.Element = enc;

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}

					if (e.Url.LocalPath == "trap")
					{
						TrapElement te = new TrapElement();
						te.Trap.Name = mapview.SelectedLocation.Name;

						PlotPoint pp = new PlotPoint(mapview.SelectedLocation.Name);
						pp.RegionalMapID = mapview.Map.ID;
						pp.MapLocationID = mapview.SelectedLocation.ID;
						pp.Element = te;

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}

					if (e.Url.LocalPath == "challenge")
					{
						SkillChallenge sc = new SkillChallenge();
						sc.Name = mapview.SelectedLocation.Name;
						sc.Level = Session.Project.Party.Level;

						PlotPoint pp = new PlotPoint(mapview.SelectedLocation.Name);
						pp.RegionalMapID = mapview.Map.ID;
						pp.MapLocationID = mapview.SelectedLocation.ID;
						pp.Element = sc;

						PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							PlotView.Plot.Points.Add(dlg.PlotPoint);
							UpdateView();

							Session.Modified = true;
						}
					}
				}

				#endregion

				#region Skill Challenge

				if (e.Url.Scheme == "sc")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "reset")
					{
						// Reset
						PlotPoint point = get_selected_point();
						SkillChallenge sc = point.Element as SkillChallenge;
						if (sc != null)
						{
							foreach (SkillChallengeData scd in sc.Skills)
							{
								scd.Results.Successes = 0;
								scd.Results.Fails = 0;

								Session.Modified = true;
								UpdateView();
							}
						}
					}
				}

				if (e.Url.Scheme == "success")
				{
					e.Cancel = true;

					// Success
					PlotPoint point = get_selected_point();
					SkillChallenge sc = point.Element as SkillChallenge;
					if (sc != null)
					{
						SkillChallengeData scd = sc.FindSkill(e.Url.LocalPath);
						scd.Results.Successes += 1;

						Session.Modified = true;
						UpdateView();
					}
				}

				if (e.Url.Scheme == "failure")
				{
					e.Cancel = true;

					// Failure
					PlotPoint point = get_selected_point();
					SkillChallenge sc = point.Element as SkillChallenge;
					if (sc != null)
					{
						SkillChallengeData scd = sc.FindSkill(e.Url.LocalPath);
						scd.Results.Fails += 1;

						Session.Modified = true;
						UpdateView();
					}
				}

				#endregion
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		PlotPoint get_selected_point()
		{
			switch (fView)
			{
				case ViewType.Flowchart:
					return PlotView.SelectedPoint;
				case ViewType.Delve:
					{
						// Work out what map area is selected, and what plot point it corresponds to
						MapView mapview = null;
						foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
						{
							if (ctrl is MapView)
								mapview = ctrl as MapView;
						}

						if (mapview != null)
						{
							MapArea area = mapview.SelectedArea;
							if (area != null)
							{
								foreach (PlotPoint pp in PlotView.Plot.Points)
								{
									if (pp.Element != null)
									{
										if (pp.Element is Encounter)
										{
											Encounter enc = pp.Element as Encounter;
											if ((enc.MapID == mapview.Map.ID) && (enc.MapAreaID == area.ID))
												return pp;
										}

										if (pp.Element is TrapElement)
										{
											TrapElement te = pp.Element as TrapElement;
											if ((te.MapID == mapview.Map.ID) && (te.MapAreaID == area.ID))
												return pp;
										}

										if (pp.Element is SkillChallenge)
										{
											SkillChallenge sc = pp.Element as SkillChallenge;
											if ((sc.MapID == mapview.Map.ID) && (sc.MapAreaID == area.ID))
												return pp;
										}

										if (pp.Element is MapElement)
										{
											MapElement me = pp.Element as MapElement;
											if ((me.MapID == mapview.Map.ID) && (me.MapAreaID == area.ID))
												return pp;
										}
									}
								}
							}
						}
					}
					break;
				case ViewType.Map:
					{
						RegionalMapPanel mapview = null;
						foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
						{
							if (ctrl is RegionalMapPanel)
								mapview = ctrl as RegionalMapPanel;
						}

						if (mapview != null)
						{
							if (mapview.SelectedLocation == null)
								return null;

							foreach (PlotPoint pp in PlotView.Plot.Points)
							{
								if ((pp.RegionalMapID == mapview.Map.ID) && (pp.MapLocationID == mapview.SelectedLocation.ID))
									return pp;
							}
						}
					}
					break;
			}

			return null;
		}

		void set_selected_point(PlotPoint point)
		{
			switch (fView)
			{
				case ViewType.Flowchart:
					{
						PlotView.SelectedPoint = point;
					}
					break;
				case ViewType.Delve:
					{
						MapView mapview = null;
						foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
						{
							if (ctrl is MapView)
								mapview = ctrl as MapView;
						}

						if (mapview != null)
						{
							mapview.SelectedArea = null;

							if (point.Element != null)
							{
								if (point.Element is Encounter)
								{
									Encounter enc = point.Element as Encounter;
									if (enc.MapID == mapview.Map.ID)
									{
										MapArea area = mapview.Map.FindArea(enc.MapAreaID);
										mapview.SelectedArea = area;
									}
								}

								if (point.Element is TrapElement)
								{
									TrapElement te = point.Element as TrapElement;
									if (te.MapID == mapview.Map.ID)
									{
										MapArea area = mapview.Map.FindArea(te.MapAreaID);
										mapview.SelectedArea = area;
									}
								}

								if (point.Element is SkillChallenge)
								{
									SkillChallenge sc = point.Element as SkillChallenge;
									if (sc.MapID == mapview.Map.ID)
									{
										MapArea area = mapview.Map.FindArea(sc.MapAreaID);
										mapview.SelectedArea = area;
									}
								}

								if (point.Element is MapElement)
								{
									MapElement me = point.Element as MapElement;
									if (me.MapID == mapview.Map.ID)
									{
										MapArea area = mapview.Map.FindArea(me.MapAreaID);
										mapview.SelectedArea = area;
									}
								}
							}
						}
					}
					break;
				case ViewType.Map:
					{
						RegionalMapPanel mapview = null;
						foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
						{
							if (ctrl is RegionalMapPanel)
								mapview = ctrl as RegionalMapPanel;
						}

						if (mapview != null)
						{
							mapview.SelectedLocation = null;

							if (point.RegionalMapID != mapview.Map.ID)
							{
								MapLocation loc = mapview.Map.FindLocation(point.MapLocationID);
								mapview.SelectedLocation = loc;
							}
						}
					}
					break;
			}
		}

		void update_preview()
		{
			try
			{
				Preview.Document.OpenNew(true);
				bool show_preview = false;

				PlotPoint point = get_selected_point();

				Map map = null;
				MapArea map_area = null;

				RegionalMap rmap = null;
				MapLocation loc = null;

				if ((point == null) && (fView == ViewType.Delve))
				{
					MapView mapview = null;

					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if (ctrl is MapView)
						{
							mapview = ctrl as MapView;
							break;
						}
					}

					if (mapview != null)
					{
						map = mapview.Map;
						map_area = mapview.SelectedArea;
					}
				}

				if ((point == null) && (fView == ViewType.Map))
				{
					RegionalMapPanel mapview = null;

					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if (ctrl is RegionalMapPanel)
						{
							mapview = ctrl as RegionalMapPanel;
							break;
						}
					}

					if (mapview != null)
					{
						rmap = mapview.Map;
						loc = mapview.SelectedLocation;
					}
				}

				if (map_area != null)
				{
					Preview.Document.Write(HTML.MapArea(map_area, DisplaySize.Small));
				}
				else if (loc != null)
				{
					Preview.Document.Write(HTML.MapLocation(loc, DisplaySize.Small));
				}
				else
				{
					int party_level = (point != null) ? Workspace.GetPartyLevel(point) : 0;
					Preview.Document.Write(HTML.PlotPoint(point, PlotView.Plot, party_level, true, fView, DisplaySize.Small));
				}

				PreviewInfoSplitter.Panel2.Controls.Clear();

				if (point != null)
				{
					if (point.Element is Encounter)
					{
						Encounter enc = point.Element as Encounter;
						if (enc.MapID != Guid.Empty)
						{
							set_tmap_preview(enc.MapID, enc.MapAreaID, enc);
							show_preview = true;
						}
					}

					if (point.Element is MapElement)
					{
						MapElement me = point.Element as MapElement;
						if (me.MapID != Guid.Empty)
						{
							set_tmap_preview(me.MapID, me.MapAreaID, null);
							show_preview = true;
						}
					}

					if (!show_preview)
					{
						RegionalMap regional_map = null;
						MapLocation location = null;
						point.GetRegionalMapArea(ref regional_map, ref location, Session.Project);

						if (location != null)
						{
							set_rmap_preview(regional_map, location);
							show_preview = true;
						}
					}

					if ((!show_preview) && (point.Subplot.Points.Count > 0))
					{
						set_subplot_preview(point.Subplot);
						show_preview = true;
					}
				}
				else if (map_area != null)
				{
					set_tmap_preview(map.ID, map_area.ID, null);
					show_preview = true;
				}

				if (!show_preview)
					PreviewInfoSplitter.Panel2.Controls.Clear();

				PreviewInfoSplitter.Panel2Collapsed = !show_preview;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void set_tmap_preview(Guid map_id, Guid area_id, Encounter enc)
		{
			try
			{
				Map m = Session.Project.FindTacticalMap(map_id);
				if (m == null)
					return;

				MapView mapview = new MapView();
				mapview.Mode = MapViewMode.Plain;
				mapview.FrameType = MapDisplayType.Dimmed;
				mapview.LineOfSight = false;
				mapview.ShowGrid = MapGridMode.None;
				mapview.BorderSize = 1;
				mapview.Map = m;

				if (area_id != Guid.Empty)
				{
					MapArea area = m.FindArea(area_id);
					if (area != null)
						mapview.Viewpoint = area.Region;
				}

				if (enc != null)
				{
					mapview.Encounter = enc;
					mapview.DoubleClick += new EventHandler(run_encounter);
				}
				else
				{
					mapview.DoubleClick += new EventHandler(show_tmap);
				}

				mapview.BorderStyle = BorderStyle.Fixed3D;
				mapview.Dock = DockStyle.Fill;
				PreviewInfoSplitter.Panel2.Controls.Add(mapview);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void set_rmap_preview(RegionalMap map, MapLocation loc)
		{
			try
			{
				RegionalMapPanel mapview = new RegionalMapPanel();
				mapview.Mode = MapViewMode.Plain;
				mapview.Map = map;
				mapview.HighlightedLocation = loc;

				mapview.DoubleClick += new EventHandler(show_rmap);

				mapview.BorderStyle = BorderStyle.Fixed3D;
				mapview.Dock = DockStyle.Fill;
				PreviewInfoSplitter.Panel2.Controls.Add(mapview);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void set_subplot_preview(Plot p)
		{
			try
			{
				PlotView plotview = new PlotView();
				plotview.Plot = p;
				plotview.Mode = PlotViewMode.Plain;
				plotview.LinkStyle = Session.Preferences.LinkStyle;

				plotview.DoubleClick += new EventHandler(ExploreBtn_Click);

				plotview.BorderStyle = BorderStyle.Fixed3D;
				plotview.Dock = DockStyle.Fill;
				PreviewInfoSplitter.Panel2.Controls.Add(plotview);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private bool edit_element(object sender, EventArgs e)
		{
			try
			{
				PlotPoint point = get_selected_point();
				if (point != null)
				{
					int party_level = Workspace.GetPartyLevel(point);

					Encounter enc = point.Element as Encounter;
					if (enc != null)
					{
						EncounterBuilderForm dlg = new EncounterBuilderForm(enc, party_level, false);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							point.Element = dlg.Encounter;
							Session.Modified = true;

							UpdateView();

							return true;
						}
					}

					SkillChallenge sc = point.Element as SkillChallenge;
					if (sc != null)
					{
						SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(sc);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							point.Element = dlg.SkillChallenge;
							Session.Modified = true;

							UpdateView();

							return true;
						}
					}

					TrapElement te = point.Element as TrapElement;
					if (te != null)
					{
						TrapBuilderForm dlg = new TrapBuilderForm(te.Trap);
						//TrapForm dlg = new TrapForm(te.Trap);
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							te.Trap = dlg.Trap;
							Session.Modified = true;

							UpdateView();

							return true;
						}
					}

					// Map - can't edit
					// Quest - can't edit
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return false;
		}

		private void run_encounter(object sender, EventArgs e)
		{
			try
			{
				PlotPoint point = get_selected_point();
				if (point != null)
				{
					Encounter enc = point.Element as Encounter;
					if (enc != null)
					{
						CombatState cs = new CombatState();
						cs.Encounter = enc;
						cs.PartyLevel = Workspace.GetPartyLevel(point);

						CombatForm dlg = new CombatForm(cs);
						dlg.Show();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void edit_map_area(Map map, MapArea map_area, MapView mapview)
		{
			try
			{
				if ((map != null) && (map_area != null))
				{
					int index = map.Areas.IndexOf(map_area);

					MapAreaForm dlg = new MapAreaForm(map_area, map);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						map.Areas[index] = dlg.Area;
						Session.Modified = true;

						if (mapview != null)
							mapview.SelectedArea = dlg.Area;

						UpdateView();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void edit_map_location(RegionalMap map, MapLocation loc, RegionalMapPanel mappanel)
		{
			try
			{
				if ((map != null) && (loc != null))
				{
					int index = map.Locations.IndexOf(loc);

					MapLocationForm dlg = new MapLocationForm(loc);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						map.Locations[index] = dlg.MapLocation;
						Session.Modified = true;

						if (mappanel != null)
							mappanel.SelectedLocation = dlg.MapLocation;

						UpdateView();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void show_map_location(RegionalMap map, MapLocation loc)
		{
			RegionalMapForm dlg = new RegionalMapForm(map, loc);
			dlg.ShowDialog();
		}

		private void show_tmap(object sender, EventArgs e)
		{
			MapView mapview = sender as MapView;

			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowTacticalMap(mapview, null);
		}

		private void show_rmap(object sender, EventArgs e)
		{
			RegionalMapPanel mapview = sender as RegionalMapPanel;

			if (Session.PlayerView == null)
				Session.PlayerView = new PlayerViewForm(this);

			Session.PlayerView.ShowRegionalMap(mapview);
		}

		#endregion

		#region Navigation

		private void NavigationTree_DragOver(object sender, DragEventArgs e)
		{
			try
			{
				e.Effect = DragDropEffects.None;

				PlotPoint pp = e.Data.GetData(typeof(PlotPoint)) as PlotPoint;
				if (pp != null)
				{
					Point mouse = NavigationTree.PointToClient(Cursor.Position);
					TreeNode tn = NavigationTree.GetNodeAt(mouse);

					if (tn == null)
						return;

					Plot target = tn.Tag as Plot;

					if (target.Points.Contains(pp))
						return;

					if (pp == Session.Project.FindParent(target))
						return;

					NavigationTree.SelectedNode = tn;
					e.Effect = DragDropEffects.Move;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NavigationTree_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				PlotPoint pp = e.Data.GetData(typeof(PlotPoint)) as PlotPoint;
				if (pp != null)
				{
					Point mouse = NavigationTree.PointToClient(Cursor.Position);
					TreeNode tn = NavigationTree.GetNodeAt(mouse);

					if (tn == null)
						return;

					Plot target = tn.Tag as Plot;
					NavigationTree.SelectedNode = tn;

					if (target.Points.Contains(pp))
						return;

					if (pp == Session.Project.FindParent(target))
						return;

					// Remove all links to this point in its parent plot
					Plot parent = Session.Project.FindParent(pp);
					parent.RemovePoint(pp);
					pp.Links.Clear();

					// Move the plot point into the target plot
					parent.Points.Remove(pp);
					target.Points.Add(pp);

					Session.Modified = true;
					UpdateView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NavigationTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			try
			{
				if (fUpdating)
					return;

				Plot p = e.Node.Tag as Plot;

				if (PlotView.Plot != p)
				{
					PlotView.Plot = p;
					UpdateView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Welcome screen

		void Welcome_NewProjectClicked(object sender, EventArgs e)
		{
			try
			{
				FileNew_Click(sender, e);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void Welcome_OpenProjectClicked(object sender, EventArgs e)
		{
			try
			{
				FileOpen_Click(sender, e);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void Welcome_OpenLastProjectClicked(object sender, EventArgs e)
		{
			try
			{
				open_file(Session.Preferences.LastFile);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void Welcome_DelveClicked(object sender, EventArgs e)
		{
			try
			{
				AdvancedDelve_Click(null, null);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Plot view

		private void PlotView_DoubleClick(object sender, EventArgs e)
		{
			try
			{
				if (PlotView.SelectedPoint == null)
				{
					// Create new point
					AddBtn_Click(sender, e);
				}
				else
				{
					if ((ModifierKeys & Keys.Shift) == Keys.Shift)
					{
						// Explore point
						ExploreBtn_Click(sender, e);
					}
					else
					{
						// Open point
						EditBtn_Click(sender, e);
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlotView_SelectionChanged(object sender, EventArgs e)
		{
			try
			{
				update_preview();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlotView_PlotLayoutChanged(object sender, EventArgs e)
		{
			Session.Modified = true;
		}

		private void PlotView_PlotChanged(object sender, EventArgs e)
		{
			UpdateView();
		}

		private void PointMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				ContextAddBetween.DropDownItems.Clear();
				ContextDisconnect.DropDownItems.Clear();

				if (PlotView.SelectedPoint != null)
				{
					foreach (PlotPoint pp in PlotView.Plot.Points)
					{
						if (!pp.Links.Contains(PlotView.SelectedPoint.ID))
							continue;

						ToolStripMenuItem tsmi = new ToolStripMenuItem("After \"" + pp.Name + "\"");
						tsmi.Click += new EventHandler(add_between);
						tsmi.Tag = new Pair<PlotPoint, PlotPoint>(pp, PlotView.SelectedPoint);
						ContextAddBetween.DropDownItems.Add(tsmi);

						ToolStripMenuItem tsmi_disconnect = new ToolStripMenuItem(pp.Name);
						tsmi_disconnect.Click += new EventHandler(disconnect_points);
						tsmi_disconnect.Tag = new Pair<PlotPoint, PlotPoint>(pp, PlotView.SelectedPoint);
						ContextDisconnect.DropDownItems.Add(tsmi_disconnect);
					}

					foreach (Guid id in PlotView.SelectedPoint.Links)
					{
						PlotPoint pp = PlotView.Plot.FindPoint(id);

						ToolStripMenuItem tsmi = new ToolStripMenuItem("Before \"" + pp.Name + "\"");
						tsmi.Click += new EventHandler(add_between);
						tsmi.Tag = new Pair<PlotPoint, PlotPoint>(PlotView.SelectedPoint, pp);
						ContextAddBetween.DropDownItems.Add(tsmi);

						ToolStripMenuItem tsmi_disconnect = new ToolStripMenuItem(pp.Name);
						tsmi_disconnect.Click += new EventHandler(disconnect_points);
						tsmi_disconnect.Tag = new Pair<PlotPoint, PlotPoint>(PlotView.SelectedPoint, pp);
						ContextDisconnect.DropDownItems.Add(tsmi_disconnect);
					}
				}

				ContextAddBetween.Enabled = (ContextAddBetween.DropDownItems.Count != 0);

				ContextDisconnect.Enabled = (ContextDisconnect.DropDownItems.Count != 0);
				ContextDisconnectAll.Enabled = ContextDisconnect.Enabled;

				ContextMoveTo.DropDownItems.Clear();

				if (PlotView.SelectedPoint != null)
				{
					foreach (PlotPoint pp in PlotView.Plot.Points)
					{
						if (pp.Links.Contains(PlotView.SelectedPoint.ID))
						{
							ToolStripMenuItem tsmi = new ToolStripMenuItem(pp.Name);
							tsmi.Click += new EventHandler(move_to_subplot);
							tsmi.Tag = new Pair<PlotPoint, PlotPoint>(pp, PlotView.SelectedPoint);
							ContextMoveTo.DropDownItems.Add(tsmi);
						}
					}

					ContextStateNormal.Checked = (PlotView.SelectedPoint.State == PlotPointState.Normal);
					ContextStateCompleted.Checked = (PlotView.SelectedPoint.State == PlotPointState.Completed);
					ContextStateSkipped.Checked = (PlotView.SelectedPoint.State == PlotPointState.Skipped);
				}

				ContextMoveTo.Enabled = (ContextMoveTo.DropDownItems.Count != 0);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Delve view

		void delve_view(Map map)
		{
			if (map == null)
				return;

			foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
				ctrl.Visible = false;

			MapView mapview = new MapView();

			mapview.Map = map;
			mapview.Plot = PlotView.Plot;
			mapview.Mode = MapViewMode.Thumbnail;
			mapview.HighlightAreas = true;
			mapview.LineOfSight = false;
			mapview.BorderSize = 1;
			mapview.BorderStyle = BorderStyle.FixedSingle;
			mapview.Dock = DockStyle.Fill;

			PreviewSplitter.Panel1.Controls.Add(mapview);

			mapview.AreaSelected += new Masterplan.Events.MapAreaEventHandler(select_maparea);
			mapview.DoubleClick += new EventHandler(edit_maparea);

			fDelveView = mapview;
			fView = ViewType.Delve;
			update_preview();
		}

		void delve_view_edit()
		{
			Map map = fDelveView.Map;
			int index = Session.Project.Maps.IndexOf(map);

			MapBuilderForm dlg = new MapBuilderForm(map, false);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.Maps[index] = dlg.Map;
				Session.Modified = true;

				fDelveView.Map = dlg.Map;
			}
		}

		void select_maparea(object sender, MapAreaEventArgs e)
		{
			update_preview();
		}

		void edit_maparea(object sender, EventArgs e)
		{
			if (fDelveView.SelectedArea != null)
			{
				int index = fDelveView.Map.Areas.IndexOf(fDelveView.SelectedArea);

				MapAreaForm dlg = new MapAreaForm(fDelveView.SelectedArea, fDelveView.Map);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fDelveView.Map.Areas[index] = dlg.Area;
					Session.Modified = true;

					fDelveView.MapChanged();
				}
			}
		}

		#endregion

		#region Map view

		void map_view(RegionalMap map)
		{
			if (map == null)
				return;

			foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
				ctrl.Visible = false;

			RegionalMapPanel mapview = new RegionalMapPanel();

			mapview.Map = map;
			mapview.Plot = PlotView.Plot;
			mapview.Mode = MapViewMode.Thumbnail;
			mapview.BorderStyle = BorderStyle.FixedSingle;
			mapview.Dock = DockStyle.Fill;

			PreviewSplitter.Panel1.Controls.Add(mapview);

			mapview.SelectedLocationModified += new EventHandler(select_maplocation);
			mapview.DoubleClick += new EventHandler(edit_maplocation);

			fMapView = mapview;
			fView = ViewType.Map;
			update_preview();
		}

		void map_view_edit()
		{
			RegionalMap map = fMapView.Map;
			int index = Session.Project.RegionalMaps.IndexOf(map);

			RegionalMapForm dlg = new RegionalMapForm(map, null);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.RegionalMaps[index] = dlg.Map;
				Session.Modified = true;

				fMapView.Map = dlg.Map;
			}
		}

		void select_maplocation(object sender, EventArgs e)
		{
			update_preview();
		}

		void edit_maplocation(object sender, EventArgs e)
		{
			if (fMapView.SelectedLocation != null)
			{
				int index = fMapView.Map.Locations.IndexOf(fMapView.SelectedLocation);

				MapLocationForm dlg = new MapLocationForm(fMapView.SelectedLocation);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fMapView.Map.Locations[index] = dlg.MapLocation;
					Session.Modified = true;

					fMapView.Invalidate();
				}
			}
		}

		#endregion

		#region Flowchart view

		void flowchart_view()
		{
			// Turn off delve view / map view

			List<Control> controls = new List<Control>();
			foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
			{
				if (ctrl.Visible)
					controls.Add(ctrl);
			}
			foreach (Control ctrl in controls)
				PreviewSplitter.Panel1.Controls.Remove(ctrl);

			foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
				ctrl.Visible = true;

			fView = ViewType.Flowchart;
			update_preview();
		}

		#endregion

		#region Background

		private void BackgroundList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				update_background_item();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundDetails_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			try
			{
				if (e.Url.Scheme == "background")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "edit")
					{
						BackgroundEditBtn_Click(sender, e);
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Encyclopedia

		private void EntryList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				update_encyclopedia_entry();
				EntryList.Focus();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EntryDetails_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			try
			{
				if (e.Url.Scheme == "entry")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "edit")
					{
						EncEditBtn_Click(sender, e);
					}
					else
					{
						Guid entry_id = new Guid(e.Url.LocalPath);
						SelectedEncyclopediaItem = Session.Project.Encyclopedia.FindEntry(entry_id);
					}
				}
                if (e.Url.Scheme == "missing")
                {
                    e.Cancel = true;

                    // Offer to create entry
                    string name = e.Url.LocalPath;
                    EncyclopediaEntry entry = create_entry(name, "");

					if (entry != null)
					{
						update_encyclopedia_list();
						SelectedEncyclopediaItem = entry;
					}
                }
				if (e.Url.Scheme == "group")
				{
					e.Cancel = true;

					if (e.Url.LocalPath == "edit")
					{
						EncEditBtn_Click(sender, e);
					}
					else
					{
						Guid group_id = new Guid(e.Url.LocalPath);
						SelectedEncyclopediaItem = Session.Project.Encyclopedia.FindGroup(group_id);
					}
				}
				if (e.Url.Scheme == "map")
				{
					e.Cancel = true;

					Guid loc_id = new Guid(e.Url.LocalPath);
					foreach (RegionalMap map in Session.Project.RegionalMaps)
					{
						MapLocation loc = map.FindLocation(loc_id);
						if (loc != null)
						{
							RegionalMapForm dlg = new RegionalMapForm(map, loc);
							dlg.ShowDialog();
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Rules

		private void RulesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			update_selected_rule();
		}

		#endregion

		#region Attachments

		private void AttachmentList_DragOver(object sender, DragEventArgs e)
		{
			try
			{
				string[] filenames = e.Data.GetData("FileDrop") as string[];
				if (filenames != null)
					e.Effect = DragDropEffects.All;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AttachmentList_DragDrop(object sender, DragEventArgs e)
		{
			try
			{
				string[] filenames = e.Data.GetData("FileDrop") as string[];
				if (filenames != null)
				{
					foreach (string filename in filenames)
						add_attachment(filename);

					update_attachments();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Notes

		private void NoteList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				fUpdating = true;

				NoteBox.Text = "(no note selected)";
				NoteBox.Enabled = false;
				NoteBox.ReadOnly = true;

				if (SelectedNote != null)
				{
					NoteBox.Text = SelectedNote.Content;
					NoteBox.Enabled = true;
					NoteBox.ReadOnly = false;
				}

				if (SelectedIssue != null)
				{
					NoteBox.Text = SelectedIssue.ToString();
					NoteBox.Enabled = true;
				}

				fUpdating = false;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NoteBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (fUpdating)
					return;

				if (SelectedNote != null)
				{
					SelectedNote.Content = NoteBox.Text;

					NoteList.SelectedItems[0].Text = SelectedNote.Name;
					NoteList.SelectedItems[0].ForeColor = (SelectedNote.Content != "") ? SystemColors.WindowText : SystemColors.GrayText;
					NoteList.Sort();

					Session.Modified = true;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Reference

		private void PartyBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "party")
			{
				if (e.Url.LocalPath == "edit")
				{
					e.Cancel = true;

					ProjectPlayers_Click(sender, e);
				}
			}

			if (e.Url.Scheme == "show")
			{
				e.Cancel = true;

				fPartyBreakdownSecondary = e.Url.LocalPath;
				update_party();
			}
		}

		private void GeneratorBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "entry")
			{
				e.Cancel = true;

				string name = e.Url.LocalPath;

				EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntry(name);
				if (entry == null)
				{
					entry = new EncyclopediaEntry();
					entry.Name = name;
					entry.Category = "People";
				}

				// Edit the entry
				int index = Session.Project.Encyclopedia.Entries.IndexOf(entry);
				EncyclopediaEntryForm dlg = new EncyclopediaEntryForm(entry);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.Encyclopedia.Entries.Add(dlg.Entry);
					Session.Modified = true;

					update_encyclopedia_list();
				}
			}

			if (e.Url.Scheme == "parcel")
			{
				e.Cancel = true;

				string item = e.Url.LocalPath;

				Parcel p = new Parcel();
				p.Name = "Item";
				p.Details = item;

				Session.Project.TreasureParcels.Add(p);
				Session.Modified = true;

				ParcelListForm dlg = new ParcelListForm();
				dlg.ShowDialog();
			}
		}

		private void ReferencePages_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		#endregion

		#region Plot point state

		private void ContextStateNormal_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlotView.SelectedPoint != null)
				{
					List<PlotPoint> points = PlotView.SelectedPoint.Subtree;
					foreach (PlotPoint pp in points)
						pp.State = PlotPointState.Normal;

					Session.Modified = true;
					update_workspace();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ContextStateCompleted_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlotView.SelectedPoint != null)
				{
					List<PlotPoint> points = PlotView.SelectedPoint.Subtree;
					foreach (PlotPoint pp in points)
						pp.State = PlotPointState.Completed;

					Session.Modified = true;
					update_workspace();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ContextStateSkipped_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlotView.SelectedPoint != null)
				{
					List<PlotPoint> points = PlotView.SelectedPoint.Subtree;
					foreach (PlotPoint pp in points)
						pp.State = PlotPointState.Skipped;

					Session.Modified = true;
					update_workspace();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ContextDisconnectAll_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.SelectedPoint.Links.Clear();

				Guid id = PlotView.SelectedPoint.ID;

				foreach (PlotPoint pp in PlotView.Plot.Points)
				{
					while (pp.Links.Contains(id))
						pp.Links.Remove(id);
				}

				PlotView.RecalculateLayout();
				Session.Modified = true;
				update_workspace();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Opening

		private void FileMenu_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				FileSave.Enabled = (Session.Project != null);
				FileSaveAs.Enabled = (Session.Project != null);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectMenu_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				ProjectProject.Enabled = (Session.Project != null);
				ProjectOverview.Enabled = (Session.Project != null);
				ProjectChecklist.Enabled = (Session.Project != null);
				ProjectCampaignSettings.Enabled = (Session.Project != null);
				ProjectPassword.Enabled = (Session.Project != null);
				ProjectTacticalMaps.Enabled = (Session.Project != null);
				ProjectRegionalMaps.Enabled = (Session.Project != null);
				ProjectPlayers.Enabled = (Session.Project != null);
				ProjectParcels.Enabled = (Session.Project != null);
				ProjectDecks.Enabled = (Session.Project != null);
				ProjectCustomCreatures.Enabled = (Session.Project != null);
				ProjectCalendars.Enabled = (Session.Project != null);
				ProjectEncounters.Enabled = ((Session.Project != null) && (Session.Project.SavedCombats.Count != 0));
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlayerViewMenu_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				PlayerViewShow.Enabled = (Session.Project != null);
				PlayerViewShow.Checked = (Session.PlayerView != null);
				PlayerViewClear.Enabled = ((Session.PlayerView != null) && (Session.PlayerView.Mode != PlayerViewMode.Blank));
				PlayerViewOtherDisplay.Enabled = (Screen.AllScreens.Length > 1);
				PlayerViewOtherDisplay.Checked = ((Screen.AllScreens.Length > 1) && (PlayerViewForm.UseOtherDisplay));
				TextSizeSmall.Checked = (PlayerViewForm.DisplaySize == DisplaySize.Small);
				TextSizeMedium.Checked = (PlayerViewForm.DisplaySize == DisplaySize.Medium);
				TextSizeLarge.Checked = (PlayerViewForm.DisplaySize == DisplaySize.Large);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsMenu_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				ToolsImportProject.Enabled = (Session.Project != null);
				ToolsExportProject.Enabled = (Session.Project != null);
				ToolsExportHandout.Enabled = (Session.Project != null);
				ToolsIssues.Enabled = (Session.Project != null);

				ToolsAddIns.DropDownItems.Clear();
				foreach (IAddIn addin in Session.AddIns)
				{
					ToolStripMenuItem addin_item = new ToolStripMenuItem(addin.Name);
					addin_item.ToolTipText = TextHelper.Wrap(addin.Description);
					addin_item.Tag = addin;

					ToolsAddIns.DropDownItems.Add(addin_item);

					foreach (ICommand command in addin.Commands)
					{
						ToolStripMenuItem command_item = new ToolStripMenuItem(command.Name);
						command_item.ToolTipText = TextHelper.Wrap(command.Description);
						command_item.Enabled = command.Available;
						command_item.Checked = command.Active;
						command_item.Click += new EventHandler(add_in_command_clicked);
						command_item.Tag = command;

						addin_item.DropDownItems.Add(command_item);
					}

					if (addin.Commands.Count == 0)
					{
						ToolStripItem command_item = ToolsAddIns.DropDownItems.Add("(no commands)");
						command_item.Enabled = false;
					}
				}

				if (Session.AddIns.Count == 0)
				{
					ToolStripItem addin_item = ToolsAddIns.DropDownItems.Add("(none)");
					addin_item.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewMenu_DropDownOpening(object sender, EventArgs e)
		{
			ViewDefault.Checked = (PlotView.Mode == PlotViewMode.Normal);
			ViewHighlighting.Checked = (PlotView.Mode == PlotViewMode.HighlightSelected);
			ViewEncounters.Checked = (PlotView.Mode == PlotViewMode.HighlightEncounter);
			ViewTraps.Checked = (PlotView.Mode == PlotViewMode.HighlightTrap);
			ViewChallenges.Checked = (PlotView.Mode == PlotViewMode.HighlightChallenge);
			ViewQuests.Checked = (PlotView.Mode == PlotViewMode.HighlightQuest);
			ViewParcels.Checked = (PlotView.Mode == PlotViewMode.HighlightParcel);
			ViewLevelling.Checked = PlotView.ShowLevels;
			ViewTooltips.Checked = PlotView.ShowTooltips;
			ViewPreview.Checked = !PreviewSplitter.Panel2Collapsed;
			ViewNavigation.Checked = !NavigationSplitter.Panel1Collapsed;
		}

		#endregion

		#endregion

		#region Menu

		#region File

		private void FileNew_Click(object sender, EventArgs e)
		{
			try
			{
				if (fView != ViewType.Flowchart)
					flowchart_view();

				if (!check_modified())
					return;

				Project p = new Project();
				p.Name = (sender != null) ? "Untitled Campaign" : "Random Delve";
				p.Author = Environment.UserName;

				ProjectForm dlg = new ProjectForm(p);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project = p;
					Session.Project.SetStandardBackgroundItems();
					Session.Project.TreasureParcels.AddRange(Treasure.CreateParcelSet(Session.Project.Party.Level, Session.Project.Party.Size, true));

					Session.FileName = "";

					PlotView.Plot = Session.Project.Plot;

					update_title();
					UpdateView();

					if (Controls.Contains(fWelcome))
					{
						Controls.Clear();
						fWelcome = null;

						Controls.Add(Pages);
						Controls.Add(MainMenu);

						Pages.Focus();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void FileOpen_Click(object sender, EventArgs e)
		{
			try
			{
				if (fView != ViewType.Flowchart)
					flowchart_view();

				if (!check_modified())
					return;

				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.ProjectFilter;
				dlg.FileName = Session.FileName;

				if (dlg.ShowDialog() == DialogResult.OK)
					open_file(dlg.FileName);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void open_file(string filename)
		{
			GC.Collect();

			Project p = Serialisation<Project>.Load(filename, SerialisationMode.Binary);
			if (p != null)
			{
				Session.CreateBackup(filename);
			}
			else
			{
				p = Session.LoadBackup(filename);
			}

			if (p != null)
			{
				if (Session.CheckPassword(p))
				{
					Session.Project = p;
					Session.FileName = filename;
					Session.Modified = false;

					Session.Project.Update();
					Session.Project.SimplifyProjectLibrary();

					PlotView.Plot = Session.Project.Plot;

					update_title();
					UpdateView();

					if (Controls.Contains(fWelcome))
					{
						Controls.Clear();
						fWelcome = null;

						Controls.Add(Pages);
						Controls.Add(MainMenu);

						Pages.Focus();
					}
				}
			}
			else
			{
				string msg = "The file '" + FileName.Name(filename) + "' could not be opened.";
				MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void FileSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (Session.FileName == "")
				{
					FileSaveAs_Click(sender, e);
					return;
				}

				GC.Collect();

				Session.Project.PopulateProjectLibrary();

				bool ok = Serialisation<Project>.Save(Session.FileName, Session.Project, SerialisationMode.Binary);
				if (ok)
				{
					Session.Modified = false;
				}
				else
				{
					// Warn that the save failed
					string str = "The file could not be saved; check the filename and drive permissions and try again.";
					MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				Session.Project.SimplifyProjectLibrary();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void FileSaveAs_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Filter = Program.ProjectFilter;
				dlg.FileName = FileName.TrimInvalidCharacters(Session.Project.Name);

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					GC.Collect();

					Session.Project.PopulateProjectLibrary();

					bool ok = Serialisation<Project>.Save(dlg.FileName, Session.Project, SerialisationMode.Binary);
					if (ok)
					{
						Session.FileName = dlg.FileName;
						Session.Modified = false;
					}
					else
					{
						// Warn that the save failed
						string str = "The file could not be saved; check the filename and drive permissions and try again.";
						MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					Session.Project.SimplifyProjectLibrary();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AdvancedDelve_Click(object sender, EventArgs e)
		{
			try
			{
				Project previous_project = Session.Project;
				string previous_filename = Session.FileName;
				ViewType view = fView;

				if (!create_delve())
				{
					Session.Project = previous_project;
					Session.FileName = previous_filename;
					fView = view;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		bool create_delve()
		{
			// Create a new project
			FileNew_Click(null, null);
			if (Session.Project == null)
				return false;

			// Generate 3-room map
			Map map = new Map();
			map.Name = "Random Dungeon";
			MapBuilderForm map_dlg = new MapBuilderForm(map, true);
			if (map_dlg.ShowDialog() != DialogResult.OK)
				return false;

			Cursor.Current = Cursors.WaitCursor;

			map = map_dlg.Map;

			// Build delve
			AutoBuildData abd = new AutoBuildData();
			PlotPoint pp = DelveBuilder.AutoBuild(map, abd);
			if (pp == null)
				return false;

			Session.Project.Maps.Add(map);
			foreach (PlotPoint child in pp.Subplot.Points)
				Session.Project.Plot.Points.Add(child);
			Session.Modified = true;

			UpdateView();

			// Switch to delve view
			delve_view(map);

			Cursor.Current = Cursors.Default;

			return true;
		}

		private void FileExit_Click(object sender, EventArgs e)
		{
			try
			{
				Close();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Project

		private void ProjectProject_Click(object sender, EventArgs e)
		{
			try
			{
				if (Session.Project == null)
					return;

				ProjectForm dlg = new ProjectForm(Session.Project);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Modified = true;

					update_title();
					UpdateView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectOverview_Click(object sender, EventArgs e)
		{
			try
			{
				OverviewForm dlg = new OverviewForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectChecklist_Click(object sender, EventArgs e)
		{
			try
			{
				if (Session.Project != null)
				{
					ProjectChecklistForm dlg = new ProjectChecklistForm();
					dlg.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectCampaignSettings_Click(object sender, EventArgs e)
		{
			try
			{
				if (Session.Project == null)
					return;

				CampaignSettingsForm dlg = new CampaignSettingsForm(Session.Project.CampaignSettings);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Modified = true;
					UpdateView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectPassword_Click(object sender, EventArgs e)
		{
			if (Session.CheckPassword(Session.Project))
			{
				// Set or change the password
				PasswordSetForm dlg = new PasswordSetForm();
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.Password = dlg.Password;
					Session.Project.PasswordHint = dlg.PasswordHint;

					Session.Modified = true;
				}
			}
		}

		private void ProjectPlayers_Click(object sender, EventArgs e)
		{
			try
			{
				HeroListForm dlg = new HeroListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectTacticalMaps_Click(object sender, EventArgs e)
		{
			try
			{
				MapListForm dlg = new MapListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectRegionalMaps_Click(object sender, EventArgs e)
		{
			try
			{
				RegionalMapListForm dlg = new RegionalMapListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectParcels_Click(object sender, EventArgs e)
		{
			try
			{
				ParcelListForm dlg = new ParcelListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectDecks_Click(object sender, EventArgs e)
		{
			try
			{
				DeckListForm dlg = new DeckListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectCustomCreatures_Click(object sender, EventArgs e)
		{
			try
			{
				CustomCreatureListForm dlg = new CustomCreatureListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectCalendars_Click(object sender, EventArgs e)
		{
			try
			{
				CalendarListForm dlg = new CalendarListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ProjectEncounters_Click(object sender, EventArgs e)
		{
			try
			{
				PausedCombatListForm dlg = new PausedCombatListForm();
				dlg.ShowDialog();

				foreach (Form form in Application.OpenForms)
				{
					if (form is CombatForm)
						form.Activate();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Player View

		private void ToolsPlayerView_Click(object sender, EventArgs e)
		{
			try
			{
                if (Session.PlayerView == null)
                {
                    Session.PlayerView = new PlayerViewForm(this);
                    Session.PlayerView.ShowDefault();
                }
                else
                {
                    Session.PlayerView.Close();
                }
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsPlayerViewSecondary_Click(object sender, EventArgs e)
		{
			try
			{
				PlayerViewForm.UseOtherDisplay = !PlayerViewForm.UseOtherDisplay;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsPlayerViewClear_Click(object sender, EventArgs e)
		{
			try
			{
				if (Session.PlayerView != null)
					Session.PlayerView.ShowDefault();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void TextSizeSmall_Click(object sender, EventArgs e)
		{
			try
			{
				PlayerViewForm.DisplaySize = DisplaySize.Small;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void TextSizeMedium_Click(object sender, EventArgs e)
		{
			try
			{
				PlayerViewForm.DisplaySize = DisplaySize.Medium;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void TextSizeLarge_Click(object sender, EventArgs e)
		{
			try
			{
				PlayerViewForm.DisplaySize = DisplaySize.Large;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

        #region Tools

		private void ToolsImportProject_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = Program.ProjectFilter;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					GC.Collect();

					Project p = Serialisation<Project>.Load(dlg.FileName, SerialisationMode.Binary);
					if (p != null)
					{
						Session.Project.PopulateProjectLibrary();
						Session.Project.Import(p);
						Session.Project.SimplifyProjectLibrary();

						Session.Modified = true;

						PlotView.RecalculateLayout();
						UpdateView();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsExportProject_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.Filter = Program.HTMLFilter;
				dlg.FileName = FileName.TrimInvalidCharacters(Session.Project.Name);

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					HTML html = new HTML();
					bool ok = html.ExportProject(dlg.FileName);
					if (ok)
					{
						System.Diagnostics.Process.Start(dlg.FileName);
					}
					else
					{
						// Warn that the save failed
						string str = "The file could not be saved; check the filename and drive permissions and try again.";
						MessageBox.Show(str, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsExportHandout_Click(object sender, EventArgs e)
		{
			try
			{
				HandoutForm dlg = new HandoutForm();
				dlg.ShowDialog();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsIssues_Click(object sender, EventArgs e)
		{
			try
			{
				IssuesForm dlg = new IssuesForm(Session.Project.Plot);
				dlg.ShowDialog();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ToolsLibraries_Click(object sender, EventArgs e)
		{
			try
			{
				LibraryListForm dlg = new LibraryListForm();
				dlg.ShowDialog();

				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void add_in_command_clicked(object sender, EventArgs e)
		{
			try
			{
				ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
				ICommand command = tsmi.Tag as ICommand;

				command.Execute();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Help

		private void HelpManual_Click(object sender, EventArgs e)
		{
			try
			{
				Assembly ass = Assembly.GetEntryAssembly();
				string path = Utils.FileName.Directory(ass.FullName) +"Manual.pdf";

				if (!File.Exists(path))
					return;

				System.Diagnostics.Process.Start(path);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void HelpAbout_Click(object sender, EventArgs e)
		{
			try
			{
				new AboutBox().ShowDialog();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#endregion

		#region Toolbars

		#region Workspace Toolbar

		#region Add

		private void AddBtn_Click(object sender, EventArgs e)
		{
			try
			{
				add_point(null, null);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ContextAdd_Click(object sender, EventArgs e)
		{
			try
			{
				add_point(PlotView.SelectedPoint, null);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void add_point(PlotPoint lhs, PlotPoint rhs)
		{
			try
			{
				PlotPoint pp = new PlotPoint("New Point");

				PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, false);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					PlotView.Plot.Points.Add(dlg.PlotPoint);
					PlotView.RecalculateLayout();

					if ((lhs != null) && (rhs != null))
						lhs.Links.Remove(rhs.ID);

					if (lhs != null)
						lhs.Links.Add(dlg.PlotPoint.ID);

					if (rhs != null)
						dlg.PlotPoint.Links.Add(rhs.ID);

					Session.Modified = true;

					UpdateView();
					PlotView.SelectedPoint = dlg.PlotPoint;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AddEncounter_Click(object sender, EventArgs e)
		{
			try
			{
                Encounter enc = new Encounter();
                enc.SetStandardEncounterNotes();

				PlotPoint pp = new PlotPoint("New Encounter Point");
				pp.Element = enc;

				PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					PlotView.Plot.Points.Add(dlg.PlotPoint);
					PlotView.RecalculateLayout();
					Session.Modified = true;

					UpdateView();
					PlotView.SelectedPoint = dlg.PlotPoint;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AddChallenge_Click(object sender, EventArgs e)
		{
			try
			{
				SkillChallenge sc = new SkillChallenge();
				sc.Name = "Unnamed Skill Challenge";
				sc.Level = Session.Project.Party.Level;

				PlotPoint pp = new PlotPoint("New Skill Challenge Point");
				pp.Element = sc;

				PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					PlotView.Plot.Points.Add(dlg.PlotPoint);
					PlotView.RecalculateLayout();
					Session.Modified = true;

					UpdateView();
					PlotView.SelectedPoint = dlg.PlotPoint;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AddTrap_Click(object sender, EventArgs e)
		{
			try
			{
				TrapElement te = new TrapElement();
				te.Trap.Name = "Unnamed Trap";
				te.Trap.Level = Session.Project.Party.Level;

				PlotPoint pp = new PlotPoint("New Trap / Hazard Point");
				pp.Element = te;

				PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					PlotView.Plot.Points.Add(dlg.PlotPoint);
					PlotView.RecalculateLayout();
					Session.Modified = true;

					UpdateView();
					PlotView.SelectedPoint = dlg.PlotPoint;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AddQuest_Click(object sender, EventArgs e)
		{
			try
			{
				PlotPoint pp = new PlotPoint("New Quest Point");
				pp.Element = new Quest();

				PlotPointForm dlg = new PlotPointForm(pp, PlotView.Plot, true);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					PlotView.Plot.Points.Add(dlg.PlotPoint);
					PlotView.RecalculateLayout();
					Session.Modified = true;

					UpdateView();
					PlotView.SelectedPoint = dlg.PlotPoint;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlotView.SelectedPoint != null)
				{
					string msg = "Are you sure you want to delete this plot point?";
					DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.No)
						return;

					if (PlotView.SelectedPoint.Subplot.Points.Count != 0)
					{
						string subplot_msg = "This plot point has a subplot.";
						subplot_msg += Environment.NewLine;
						subplot_msg += "Do you want to keep the subplot points?";

						dr = MessageBox.Show(subplot_msg, "Masterplan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

						if (dr == DialogResult.Cancel)
							return;

						if (dr == DialogResult.Yes)
						{
							// Keep subplot points
							foreach (PlotPoint pp in PlotView.SelectedPoint.Subplot.Points)
								PlotView.Plot.Points.Add(pp);
						}
					}

					PlotView.Plot.RemovePoint(PlotView.SelectedPoint);
					PlotView.RecalculateLayout();
					PlotView.SelectedPoint = null;

					Session.Modified = true;
					UpdateView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Clipboard

		private void CutBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlotView.SelectedPoint != null)
				{
					Clipboard.SetData(typeof(PlotPoint).ToString(), PlotView.SelectedPoint.Copy());

					PlotView.Plot.RemovePoint(PlotView.SelectedPoint);
					PlotView.RecalculateLayout();
					PlotView.SelectedPoint = null;
					Session.Modified = true;

					PlotView.Invalidate();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void CopyBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (PlotView.SelectedPoint != null)
				{
					Clipboard.SetData(typeof(PlotPoint).ToString(), PlotView.SelectedPoint.Copy());
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PasteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (Clipboard.ContainsData(typeof(PlotPoint).ToString()))
				{
					PlotPoint pp = Clipboard.GetData(typeof(PlotPoint).ToString()) as PlotPoint;
					if (pp != null)
					{
						if (PlotView.Plot.FindPoint(pp.ID) != null)
						{
							// Paste a new copy (with a new ID)
							pp = pp.Copy();
							pp.Links.Clear();
							pp.ID = Guid.NewGuid();
						}

						// Remove links to any point that's not in this subplot
						List<Guid> obsolete = new List<Guid>();
						foreach (Guid link_id in pp.Links)
						{
							if (PlotView.Plot.FindPoint(link_id) == null)
								obsolete.Add(link_id);
						}
						foreach (Guid link_id in obsolete)
							pp.Links.Remove(link_id);

						PlotView.Plot.Points.Add(pp);
						PlotView.RecalculateLayout();
						if (PlotView.SelectedPoint != null)
							PlotView.SelectedPoint.Links.Add(pp.ID);

						Session.Modified = true;

						PlotView.SelectedPoint = pp;
						PlotView.Invalidate();
					}
				}
                else if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();

                    PlotPoint pp = new PlotPoint();
                    pp.Name = text.Trim().Substring(0, 12) + "...";
                    pp.Details = text;

                    PlotView.Plot.Points.Add(pp);
					PlotView.RecalculateLayout();
					if (PlotView.SelectedPoint != null)
                        PlotView.SelectedPoint.Links.Add(pp.ID);

                    Session.Modified = true;

                    PlotView.SelectedPoint = pp;
                    PlotView.Invalidate();
                }
            }
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Search

		private void SearchBtn_Click(object sender, EventArgs e)
		{
			try
			{
				WorkspaceSearchBar.Visible = !WorkspaceSearchBar.Visible;

				if (!WorkspaceSearchBar.Visible)
					PlotSearchBox.Text = "";
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void SearchBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				PlotView.Filter = PlotSearchBox.Text;
				PlotSearchBox.Focus();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			try
			{
				PlotSearchBox.Text = "";
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region View Menu

		private void ViewDefault_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.Mode = PlotViewMode.Normal;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewHighlighting_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.Mode = PlotViewMode.HighlightSelected;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewEncounters_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.Mode = PlotViewMode.HighlightEncounter;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewTraps_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.Mode = PlotViewMode.HighlightTrap;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewChallenges_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.Mode = PlotViewMode.HighlightChallenge;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewQuests_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.Mode = PlotViewMode.HighlightQuest;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewParcels_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.Mode = PlotViewMode.HighlightParcel;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewLevelling_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.ShowLevels = !PlotView.ShowLevels;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewTooltips_Click(object sender, EventArgs e)
		{
			try
			{
				PlotView.ShowTooltips = !PlotView.ShowTooltips;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewPreview_Click(object sender, EventArgs e)
		{
			try
			{
				PreviewSplitter.Panel2Collapsed = !PreviewSplitter.Panel2Collapsed;
                Session.Preferences.ShowPreview = !Session.Preferences.ShowPreview;
            }
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewNavigation_Click(object sender, EventArgs e)
		{
			try
			{
				NavigationSplitter.Panel1Collapsed = !NavigationSplitter.Panel1Collapsed;
                Session.Preferences.ShowNavigation = !Session.Preferences.ShowNavigation;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ViewLinks_DropDownOpening(object sender, EventArgs e)
		{
			ViewLinksCurved.Checked = (PlotView.LinkStyle == PlotViewLinkStyle.Curved);
			ViewLinksAngled.Checked = (PlotView.LinkStyle == PlotViewLinkStyle.Angled);
			ViewLinksStraight.Checked = (PlotView.LinkStyle == PlotViewLinkStyle.Straight);
		}

		private void ViewLinksCurved_Click(object sender, EventArgs e)
		{
			PlotView.LinkStyle = PlotViewLinkStyle.Curved;
			Session.Preferences.LinkStyle = PlotViewLinkStyle.Curved;
		}

		private void ViewLinksAngled_Click(object sender, EventArgs e)
		{
			PlotView.LinkStyle = PlotViewLinkStyle.Angled;
			Session.Preferences.LinkStyle = PlotViewLinkStyle.Angled;
		}

		private void ViewLinksStraight_Click(object sender, EventArgs e)
		{
			PlotView.LinkStyle = PlotViewLinkStyle.Straight;
			Session.Preferences.LinkStyle = PlotViewLinkStyle.Straight;
		}

		#endregion

		#region Flowchart Menu

		private void FlowchartPrint_Click(object sender, EventArgs e)
		{
			try
			{
				PrintDialog dlg = new PrintDialog();
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					PrintDocument doc = new PrintDocument();
					doc.DocumentName = Session.Project.Name;
					doc.PrinterSettings = dlg.PrinterSettings;

					doc.PrintPage += new PrintPageEventHandler(print_page);
					doc.Print();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void FlowchartExport_Click(object sender, EventArgs e)
		{
			try
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.FileName = Session.Project.Name;
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

					Bitmap bmp = Screenshot.Plot(PlotView.Plot, new Size(800, 600));
					bmp.Save(dlg.FileName, format);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void FlowchartAllXP_Click(object sender, EventArgs e)
		{
			Session.Preferences.AllXP = !Session.Preferences.AllXP;

			update_workspace();
			update_preview();
		}

		#endregion

		#region Advanced menu

		private void PlotAdvancedIssues_Click(object sender, EventArgs e)
		{
			IssuesForm dlg = new IssuesForm(PlotView.Plot);
			dlg.ShowDialog();
		}

		private void PlotAdvancedDifficulty_Click(object sender, EventArgs e)
		{
			LevelAdjustmentForm dlg = new LevelAdjustmentForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				int delta = dlg.LevelAdjustment;

				List<PlotPoint> points = PlotView.Plot.AllPlotPoints;
				foreach (PlotPoint point in points)
				{
					if (point.Element is Encounter)
					{
						Encounter enc = point.Element as Encounter;
						foreach (EncounterSlot slot in enc.Slots)
							slot.Card.LevelAdjustment += delta;

						foreach (Trap t in enc.Traps)
						{
							t.AdjustLevel(delta);
						}

						foreach (SkillChallenge sc in enc.SkillChallenges)
						{
							sc.Level += delta;
							sc.Level = Math.Max(1, sc.Level);
						}
					}

					if (point.Element is Trap)
					{
						Trap t = point.Element as Trap;

						t.AdjustLevel(delta);
					}

					if (point.Element is SkillChallenge)
					{
						SkillChallenge sc = point.Element as SkillChallenge;

						sc.Level += delta;
						sc.Level = Math.Max(1, sc.Level);
					}

					if (point.Element is Quest)
					{
						Quest q = point.Element as Quest;

						q.Level += delta;
						q.Level = Math.Max(1, q.Level);
					}
				}

				Session.Modified = true;

				PlotView.Invalidate();
			}
		}

		#endregion

		#endregion

		#region Plot Point Toolbar

		private void EditBtn_Click(object sender, EventArgs e)
		{
			try
			{
				/*
				if (fView != ViewType.Flowchart)
				{
					string msg = "This cannot be done in Delve View or Map View mode.";
					MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);

					return;
				}
				*/

				PlotPoint pp = get_selected_point();
				if (pp != null)
				{
					int index = PlotView.Plot.Points.IndexOf(pp);
					Plot plot = Session.Project.FindParent(pp);

					PlotPointForm dlg = new PlotPointForm(pp, plot, false);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						plot.Points[index] = dlg.PlotPoint;
						Session.Modified = true;

						set_selected_point(dlg.PlotPoint);

						PlotView.RecalculateLayout();
						UpdateView();
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void ExploreBtn_Click(object sender, EventArgs e)
		{
			try
			{
				/*
				if (fView != ViewType.Flowchart)
				{
					string msg = "This cannot be done in Delve View or Map View mode.";
					MessageBox.Show(msg, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Information);

					return;
				}
				*/

				PlotPoint pp = get_selected_point();
				if (pp != null)
				{
					if (fView != ViewType.Flowchart)
						flowchart_view();

					PlotView.Plot = pp.Subplot;
					UpdateView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlotPointPlayerView_Click(object sender, EventArgs e)
		{
			try
			{
				PlotPoint point = get_selected_point();
				if (point != null)
				{
					if (Session.PlayerView == null)
						Session.PlayerView = new PlayerViewForm(this);

					Session.PlayerView.ShowPlotPoint(point);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlotPointExportHTML_Click(object sender, EventArgs e)
		{
			try
			{
				PlotPoint point = get_selected_point();
				if (point != null)
				{
					SaveFileDialog dlg = new SaveFileDialog();
					dlg.FileName = point.Name;
					dlg.Filter = Program.HTMLFilter;

					if (dlg.ShowDialog() == DialogResult.OK)
					{
						int party_level = Workspace.GetPartyLevel(point);
						File.WriteAllText(dlg.FileName, HTML.PlotPoint(point, PlotView.Plot, party_level, false, fView, DisplaySize.Small));
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void PlotPointExportFile_Click(object sender, EventArgs e)
		{
			try
			{
				PlotPoint point = get_selected_point();
				if (point != null)
				{
					Project p = new Project();
					p.Name = point.Name;
					p.Party.Size = Session.Project.Party.Size;
					p.Party.Level = Workspace.GetPartyLevel(point);

					// Add this plot point
					p.Plot.Points.Add(point.Copy());

					foreach (PlotPoint pp in p.AllPlotPoints)
						pp.EncyclopediaEntryIDs.Clear();

					// Add all tactical maps
					List<Guid> tactical_map_ids = p.Plot.FindTacticalMaps();
					foreach (Guid map_id in tactical_map_ids)
					{
						Map m = Session.Project.FindTacticalMap(map_id);
						if (m != null)
							p.Maps.Add(m.Copy());
					}

					// Add all regional maps
					List<Guid> regional_map_ids = p.Plot.FindRegionalMaps();
					foreach (Guid map_id in regional_map_ids)
					{
						RegionalMap m = Session.Project.FindRegionalMap(map_id);
						if (m != null)
							p.RegionalMaps.Add(m.Copy());
					}

					GC.Collect();

					p.PopulateProjectLibrary();

					SaveFileDialog dlg = new SaveFileDialog();
					dlg.FileName = point.Name;
					dlg.Filter = Program.ProjectFilter;

					if (dlg.ShowDialog() == DialogResult.OK)
						Serialisation<Project>.Save(dlg.FileName, p, SerialisationMode.Binary);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Background Toolbar

		private void BackgroundAddBtn_Click(object sender, EventArgs e)
		{
			try
			{
				Background bg = new Background("New Background Item");
				BackgroundForm dlg = new BackgroundForm(bg);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.Backgrounds.Add(dlg.Background);
					Session.Modified = true;

					update_background_list();
					SelectedBackground = dlg.Background;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundRemoveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedBackground != null)
				{
					string msg = "Are you sure you want to delete this background?";
					DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.No)
						return;

					Session.Project.Backgrounds.Remove(SelectedBackground);
					Session.Modified = true;

					update_background_list();
					SelectedBackground = null;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundEditBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedBackground != null)
				{
					int index = Session.Project.Backgrounds.IndexOf(SelectedBackground);

					BackgroundForm dlg = new BackgroundForm(SelectedBackground);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						Session.Project.Backgrounds[index] = dlg.Background;
						Session.Modified = true;

						update_background_list();
						SelectedBackground = dlg.Background;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundUpBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if ((SelectedBackground != null) && (Session.Project.Backgrounds.IndexOf(SelectedBackground) != 0))
				{
					int index = Session.Project.Backgrounds.IndexOf(SelectedBackground);
					Background tmp = Session.Project.Backgrounds[index - 1];
					Session.Project.Backgrounds[index - 1] = SelectedBackground;
					Session.Project.Backgrounds[index] = tmp;

					Session.Modified = true;

					update_background_list();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundDownBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if ((SelectedBackground != null) && (Session.Project.Backgrounds.IndexOf(SelectedBackground) != Session.Project.Backgrounds.Count - 1))
				{
					int index = Session.Project.Backgrounds.IndexOf(SelectedBackground);
					Background tmp = Session.Project.Backgrounds[index + 1];
					Session.Project.Backgrounds[index + 1] = SelectedBackground;
					Session.Project.Backgrounds[index] = tmp;

					Session.Modified = true;

					update_background_list();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundPlayerViewSelected_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedBackground != null)
				{
					if (Session.PlayerView == null)
						Session.PlayerView = new PlayerViewForm(this);

					Session.PlayerView.ShowBackground(SelectedBackground);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundPlayerViewAll_Click(object sender, EventArgs e)
		{
			try
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowBackground(Session.Project.Backgrounds);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void BackgroundShareExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = Program.BackgroundFilter;
			dlg.FileName = Session.Project.Name;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Serialisation<List<Background>>.Save(dlg.FileName, Session.Project.Backgrounds, SerialisationMode.XML);
			}
		}

		private void BackgroundShareImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.BackgroundFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				List<Background> list = Serialisation<List<Background>>.Load(dlg.FileName, SerialisationMode.XML);
				Session.Project.Backgrounds.AddRange(list);
				Session.Modified = true;
				UpdateView();
			}
		}

		private void BackgroundSharePublish_Click(object sender, EventArgs e)
		{
			HandoutForm dlg = new HandoutForm();
			dlg.AddBackgroundEntries();

			dlg.ShowDialog();
		}

		#endregion

		#region Encyclopedia Toolbar

		private void EncAddEntry_Click(object sender, EventArgs e)
		{
            try
            {
                EncyclopediaEntry entry = create_entry("New Entry", "");

				if (entry != null)
				{
					UpdateView();
					SelectedEncyclopediaItem = entry;
				}
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }
        }

        EncyclopediaEntry create_entry(string name, string content)
        {
            try
            {
                EncyclopediaEntry entry = new EncyclopediaEntry();
                entry.Name = name;
				entry.Details = content;

                EncyclopediaEntryForm dlg = new EncyclopediaEntryForm(entry);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Session.Project.Encyclopedia.Entries.Add(dlg.Entry);
					Session.Project.Encyclopedia.Entries.Sort();

                    Session.Modified = true;

                    return dlg.Entry;
                }
            }
            catch (Exception ex)
            {
                LogSystem.Trace(ex);
            }

            return null;
        }

		void encyclopedia_template(object sender, EventArgs e)
		{
			try
			{
				if (sender is ToolStripMenuItem)
				{
					ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
					string filename = tsmi.Tag as string;

					// Create entry with this text
					string name = FileName.Name(filename);
					string text = File.ReadAllText(filename);
					EncyclopediaEntry entry = create_entry(name, text);

					if (entry != null)
					{
						UpdateView();
						SelectedEncyclopediaItem = entry;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EncAddGroup_Click(object sender, EventArgs e)
		{
			try
			{
				EncyclopediaGroup group = new EncyclopediaGroup();
				group.Name = "New Group";

				EncyclopediaGroupForm dlg = new EncyclopediaGroupForm(group);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.Encyclopedia.Groups.Add(dlg.Group);
					Session.Modified = true;

					UpdateView();
					SelectedEncyclopediaItem = group;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EncRemoveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaEntry))
				{
					string msg = "Are you sure you want to delete this encyclopedia entry?";
					DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.No)
						return;

					Session.Project.Encyclopedia.Entries.Remove(SelectedEncyclopediaItem as EncyclopediaEntry);

					// Remove all links to this entry
					List<EncyclopediaLink> obsolete = new List<EncyclopediaLink>();
					foreach (EncyclopediaLink link in Session.Project.Encyclopedia.Links)
					{
						if (link.EntryIDs.Contains(SelectedEncyclopediaItem.ID))
							obsolete.Add(link);
					}
					foreach (EncyclopediaLink link in obsolete)
						Session.Project.Encyclopedia.Links.Remove(link);

					// Remove the entry from groups
					foreach (EncyclopediaGroup group in Session.Project.Encyclopedia.Groups)
					{
						if (group.EntryIDs.Contains(SelectedEncyclopediaItem.ID))
							group.EntryIDs.Remove(SelectedEncyclopediaItem.ID);
					}

					Session.Modified = true;

					update_encyclopedia_list();
					SelectedEncyclopediaItem = null;
				}

				if ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaGroup))
				{
					string msg = "Are you sure you want to delete this encyclopedia group?";
					DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.No)
						return;

					Session.Project.Encyclopedia.Groups.Remove(SelectedEncyclopediaItem as EncyclopediaGroup);

					UpdateView();
					SelectedEncyclopediaItem = null;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EncEditBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaEntry))
				{
					int index = Session.Project.Encyclopedia.Entries.IndexOf(SelectedEncyclopediaItem as EncyclopediaEntry);

					EncyclopediaEntryForm dlg = new EncyclopediaEntryForm(SelectedEncyclopediaItem as EncyclopediaEntry);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						Session.Project.Encyclopedia.Entries[index] = dlg.Entry;
						Session.Modified = true;

						UpdateView();
						SelectedEncyclopediaItem = dlg.Entry;
					}
				}

				if ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaGroup))
				{
					int index = Session.Project.Encyclopedia.Groups.IndexOf(SelectedEncyclopediaItem as EncyclopediaGroup);

					EncyclopediaGroupForm dlg = new EncyclopediaGroupForm(SelectedEncyclopediaItem as EncyclopediaGroup);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						Session.Project.Encyclopedia.Groups[index] = dlg.Group;
						Session.Modified = true;

						UpdateView();
						SelectedEncyclopediaItem = dlg.Group;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EncPlayerView_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedEncyclopediaItem != null)
				{
					if (Session.PlayerView == null)
						Session.PlayerView = new PlayerViewForm(this);

					Session.PlayerView.ShowEncyclopediaItem(SelectedEncyclopediaItem);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Share menu

		private void EncShareExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = Program.EncyclopediaFilter;
			dlg.FileName = Session.Project.Name;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Serialisation<Encyclopedia>.Save(dlg.FileName, Session.Project.Encyclopedia, SerialisationMode.XML);
			}
		}

		private void EncShareImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.EncyclopediaFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Encyclopedia enc = Serialisation<Encyclopedia>.Load(dlg.FileName, SerialisationMode.XML);
				Session.Project.Encyclopedia.Import(enc);
				Session.Modified = true;
				UpdateView();
			}
		}

		private void EncSharePublish_Click(object sender, EventArgs e)
		{
			HandoutForm dlg = new HandoutForm();
			dlg.AddEncyclopediaEntries();

			dlg.ShowDialog();
		}

		#endregion

		#region Clipboard

		private void EncCutBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaEntry))
				{
					EncyclopediaEntry entry = SelectedEncyclopediaItem as EncyclopediaEntry;

					Clipboard.SetData(typeof(EncyclopediaEntry).ToString(), entry.Copy());

					Session.Project.Encyclopedia.Entries.Remove(entry);
					Session.Modified = true;

					update_encyclopedia_list();
					SelectedEncyclopediaItem = null;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EncCopyBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaEntry))
				{
					EncyclopediaEntry entry = SelectedEncyclopediaItem as EncyclopediaEntry;
					Clipboard.SetData(typeof(EncyclopediaEntry).ToString(), entry.Copy());
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EncPasteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (Clipboard.ContainsData(typeof(EncyclopediaEntry).ToString()))
				{
					EncyclopediaEntry entry = Clipboard.GetData(typeof(EncyclopediaEntry).ToString()) as EncyclopediaEntry;
					if (entry != null)
					{
						if (Session.Project.Encyclopedia.FindEntry(entry.ID) != null)
						{
							Guid previous_id = entry.ID;

							// Set a new ID
							entry.ID = Guid.NewGuid();

							List<EncyclopediaLink> new_links = new List<EncyclopediaLink>();
							foreach (EncyclopediaLink link in Session.Project.Encyclopedia.Links)
							{
								if (link.EntryIDs.Contains(previous_id))
								{
									EncyclopediaLink new_link = link.Copy();
									int index = new_link.EntryIDs.IndexOf(previous_id);
									new_link.EntryIDs[index] = entry.ID;

									new_links.Add(new_link);
								}
							}
							Session.Project.Encyclopedia.Links.AddRange(new_links);
						}

						Session.Project.Encyclopedia.Entries.Add(entry);
						Session.Modified = true;

						update_encyclopedia_list();
						SelectedEncyclopediaItem = entry;
					}
				}
                else if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();

                    EncyclopediaEntry entry = new EncyclopediaEntry();
                    entry.Name = text.Trim().Substring(0, 12) + "...";
                    entry.Details = text;

                    Session.Project.Encyclopedia.Entries.Add(entry);
                    Session.Modified = true;

                    update_encyclopedia_list();
					SelectedEncyclopediaItem = entry;
                }
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Search

		private void EncSearchBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				update_encyclopedia_list();

				if (EntryList.Items.Count != 0)
					SelectedEncyclopediaItem = EntryList.Items[0].Tag as EncyclopediaEntry;
				else
					SelectedEncyclopediaItem = null;

				EncSearchBox.Focus();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void EncClearLbl_Click(object sender, EventArgs e)
		{
			try
			{
				EncSearchBox.Text = "";
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		private void EntryImageList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedEncyclopediaImage != null)
			{
				EncyclopediaEntry entry = SelectedEncyclopediaItem as EncyclopediaEntry;
				if (entry == null)
					return;

				int index = entry.Images.IndexOf(SelectedEncyclopediaImage);

				EncyclopediaImageForm dlg = new EncyclopediaImageForm(SelectedEncyclopediaImage);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					entry.Images[index] = dlg.Image;
					update_encyclopedia_images();

					Session.Modified = true;
				}
			}
		}

		#endregion

		#region Rules Toolbar

		#region Add rule

		private void AddRace_Click(object sender, EventArgs e)
		{
			Race race = new Race();
			race.Name = "New Race";

			OptionRaceForm dlg = new OptionRaceForm(race);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Race);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddClass_Click(object sender, EventArgs e)
		{
			Class c = new Class();
			c.Name = "New Class";

			for (int level = 1; level <= 30; ++level)
			{
				LevelData ld = new LevelData();
				ld.Level = level;
				c.Levels.Add(ld);
			}

			OptionClassForm dlg = new OptionClassForm(c);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Class);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddTheme_Click(object sender, EventArgs e)
		{
			Theme theme = new Theme();
			theme.Name = "New Theme";

			for (int level = 1; level <= 10; ++level)
			{
				LevelData ld = new LevelData();
				ld.Level = level;
				theme.Levels.Add(ld);
			}

			OptionThemeForm dlg = new OptionThemeForm(theme);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Theme);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddParagonPath_Click(object sender, EventArgs e)
		{
			ParagonPath pp = new ParagonPath();
			pp.Name = "New Paragon Path";

			for (int level = 11; level <= 20; ++level)
			{
				LevelData ld = new LevelData();
				ld.Level = level;
				pp.Levels.Add(ld);
			}

			OptionParagonPathForm dlg = new OptionParagonPathForm(pp);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.ParagonPath);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddEpicDestiny_Click(object sender, EventArgs e)
		{
			EpicDestiny ed = new EpicDestiny();
			ed.Name = "New Epic Destiny";

			for (int level = 21; level <= 30; ++level)
			{
				LevelData ld = new LevelData();
				ld.Level = level;
				ed.Levels.Add(ld);
			}

			OptionEpicDestinyForm dlg = new OptionEpicDestinyForm(ed);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.EpicDestiny);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddBackground_Click(object sender, EventArgs e)
		{
			PlayerBackground bg = new PlayerBackground();
			bg.Name = "New Background";

			OptionBackgroundForm dlg = new OptionBackgroundForm(bg);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Background);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddFeat_Click(object sender, EventArgs e)
		{
			Feat feat = new Feat();
			feat.Name = "New Feat";

			OptionFeatForm dlg = new OptionFeatForm(feat);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Feat);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddWeapon_Click(object sender, EventArgs e)
		{
			Weapon wpn = new Weapon();
			wpn.Name = "New Weapon";

			OptionWeaponForm dlg = new OptionWeaponForm(wpn);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Weapon);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddRitual_Click(object sender, EventArgs e)
		{
			Ritual ritual = new Ritual();
			ritual.Name = "New Ritual";

			OptionRitualForm dlg = new OptionRitualForm(ritual);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Ritual);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddCreatureLore_Click(object sender, EventArgs e)
		{
			CreatureLore lore = new CreatureLore();
			lore.Name = "Creature";
			lore.SkillName = "Nature";

			OptionCreatureLoreForm dlg = new OptionCreatureLoreForm(lore);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.CreatureLore);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddDisease_Click(object sender, EventArgs e)
		{
			Disease disease = new Disease();
			disease.Name = "New Disease";

			OptionDiseaseForm dlg = new OptionDiseaseForm(disease);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Disease);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void AddPoison_Click(object sender, EventArgs e)
		{
			Poison poison = new Poison();
			poison.Name = "New Poison";

			OptionPoisonForm dlg = new OptionPoisonForm(poison);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Session.Project.PlayerOptions.Add(dlg.Poison);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		#endregion

		private void RulesRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedRule != null)
			{
				Session.Project.PlayerOptions.Remove(SelectedRule);
				Session.Modified = true;

				update_rules_list();
				update_selected_rule();
			}
		}

		private void RulesEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedRule == null)
				return;

			int index = Session.Project.PlayerOptions.IndexOf(SelectedRule);

			if (SelectedRule is Race)
			{
				OptionRaceForm dlg = new OptionRaceForm(SelectedRule as Race);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Race;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is Class)
			{
				OptionClassForm dlg = new OptionClassForm(SelectedRule as Class);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Class;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is Theme)
			{
				OptionThemeForm dlg = new OptionThemeForm(SelectedRule as Theme);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Theme;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is ParagonPath)
			{
				OptionParagonPathForm dlg = new OptionParagonPathForm(SelectedRule as ParagonPath);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.ParagonPath;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is EpicDestiny)
			{
				OptionEpicDestinyForm dlg = new OptionEpicDestinyForm(SelectedRule as EpicDestiny);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.EpicDestiny;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is PlayerBackground)
			{
				OptionBackgroundForm dlg = new OptionBackgroundForm(SelectedRule as PlayerBackground);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Background;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is Feat)
			{
				OptionFeatForm dlg = new OptionFeatForm(SelectedRule as Feat);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Feat;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is Weapon)
			{
				OptionWeaponForm dlg = new OptionWeaponForm(SelectedRule as Weapon);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Weapon;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is Ritual)
			{
				OptionRitualForm dlg = new OptionRitualForm(SelectedRule as Ritual);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Ritual;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is CreatureLore)
			{
				OptionCreatureLoreForm dlg = new OptionCreatureLoreForm(SelectedRule as CreatureLore);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.CreatureLore;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is Disease)
			{
				OptionDiseaseForm dlg = new OptionDiseaseForm(SelectedRule as Disease);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Disease;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}

			if (SelectedRule is Poison)
			{
				OptionPoisonForm dlg = new OptionPoisonForm(SelectedRule as Poison);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					Session.Project.PlayerOptions[index] = dlg.Poison;
					Session.Modified = true;

					update_rules_list();
					update_selected_rule();
				}
			}
		}

		/*
		private void RulesExportBtn_Click(object sender, EventArgs e)
		{
			if (SelectedRule != null)
			{
				SaveFileDialog dlg = new SaveFileDialog();
				dlg.FileName = SelectedRule.Name;
				dlg.Filter = Program.HTMLFilter;

				if (dlg.ShowDialog() == DialogResult.OK)
					File.WriteAllText(dlg.FileName, RulesBrowser.DocumentText);
			}
		}
		*/

		private void RulesPlayerViewBtn_Click(object sender, EventArgs e)
		{
			if (SelectedRule != null)
			{
				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				Session.PlayerView.ShowPlayerOption(SelectedRule);
			}
		}

		private void RuleEncyclopediaBtn_Click(object sender, EventArgs e)
		{
			if (SelectedRule == null)
				return;

			EncyclopediaEntry entry = Session.Project.Encyclopedia.FindEntryForAttachment(SelectedRule.ID);

			if (entry == null)
			{
				// If there is no entry, ask to create it
				string msg = "There is no encyclopedia entry associated with this item.";
				msg += Environment.NewLine;
				msg += "Would you like to create one now?";
				if (MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;

				entry = new EncyclopediaEntry();
				entry.Name = SelectedRule.Name;
				entry.AttachmentID = SelectedRule.ID;
				entry.Category = "";

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

				UpdateView();

				Pages.SelectedTab = EncyclopediaPage;
				SelectedEncyclopediaItem = dlg.Entry;
			}
		}

		#region Share menu

		private void RulesShareExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = Program.RulesFilter;
			dlg.FileName = Session.Project.Name;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				Serialisation<List<IPlayerOption>>.Save(dlg.FileName, Session.Project.PlayerOptions, SerialisationMode.Binary);
			}
		}

		private void RulesShareImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.RulesFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				List<IPlayerOption> rules = Serialisation<List<IPlayerOption>>.Load(dlg.FileName, SerialisationMode.Binary);
				Session.Project.PlayerOptions.AddRange(rules);
				UpdateView();
			}
		}

		private void RulesSharePublish_Click(object sender, EventArgs e)
		{
			HandoutForm dlg = new HandoutForm();
			dlg.AddRulesEntries();

			dlg.ShowDialog();
		}

		#endregion

		#endregion

		#region Attachments Toolbar

		private void AttachmentImportBtn_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog dlg = new OpenFileDialog();
				dlg.Filter = "All Files|*.*";
				dlg.Multiselect = true;

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					foreach (string filename in dlg.FileNames)
						add_attachment(filename);

					update_attachments();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AttachmentRemoveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				List<Attachment> attachments = SelectedAttachments;

				if (attachments.Count != 0)
				{
					string str = "You are about to remove one or more attachments from this project.";
					str += Environment.NewLine;
					str += "Are you sure you want to do this?";

					if (MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
						return;

					foreach (Attachment att in attachments)
						Session.Project.Attachments.Remove(att);

					Session.Modified = true;
					update_attachments();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AttachmentExtractSimple_Click(object sender, EventArgs e)
		{
			try
			{
				List<Attachment> attachments = SelectedAttachments;
				foreach (Attachment att in attachments)
				{
					extract_attachment(att, false);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AttachmentExtractAndRun_Click(object sender, EventArgs e)
		{
			try
			{
				List<Attachment> attachments = SelectedAttachments;
				foreach (Attachment att in attachments)
				{
					extract_attachment(att, true);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void extract_attachment(Attachment att, bool run)
		{
			try
			{
				string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
				if (!desktop.EndsWith("\\"))
					desktop += "\\";

				string filename = desktop + att.Name;

				// Work out unique filename
				int n = 1;
				string unique_file = filename;
				while (File.Exists(unique_file))
				{
					n += 1;
					unique_file = desktop + FileName.Name(filename) + " " + n + "." + FileName.Extension(filename);
				}

				// Create file
				File.WriteAllBytes(unique_file, att.Contents);

				if (run)
				{
					// Open the file
					System.Diagnostics.Process.Start(unique_file);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void AttachmentSendBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedAttachments.Count != 1)
					return;

				Attachment att = SelectedAttachments[0];
				if (att.Type == AttachmentType.Miscellaneous)
					return;

				if (Session.PlayerView == null)
					Session.PlayerView = new PlayerViewForm(this);

				if (att.Type == AttachmentType.PlainText)
					Session.PlayerView.ShowPlainText(att);

				if (att.Type == AttachmentType.RichText)
					Session.PlayerView.ShowRichText(att);

				if (att.Type == AttachmentType.Image)
					Session.PlayerView.ShowImage(att);

				/*
				if (att.Type == AttachmentType.Audio)
				{
					// Can't handle this yet
					//PlayerViewForm.ShowAudio(att);
				}

				if (att.Type == AttachmentType.Video)
				{
					// Can't handle this yet
					//PlayerViewForm.ShowVideo(att);
				}
				*/

				if (att.Type == AttachmentType.URL)
					Session.PlayerView.ShowWebPage(att);

				if (att.Type == AttachmentType.HTML)
					Session.PlayerView.ShowWebPage(att);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Jotter Toolbar

		private void NoteAddBtn_Click(object sender, EventArgs e)
		{
			try
			{
				Note n = new Note();
				//n.Content = "(new note)";

				Session.Project.Notes.Add(n);
				Session.Modified = true;

				update_notes();
				SelectedNote = n;

				NoteBox.Focus();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NoteRemoveBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedNote != null)
				{
					string msg = "Are you sure you want to delete this note?";
					DialogResult dr = MessageBox.Show(msg, "Masterplan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.No)
						return;

					Session.Project.Notes.Remove(SelectedNote);
					Session.Modified = true;

					update_notes();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NoteCategoryBtn_Click(object sender, EventArgs e)
		{
			if (SelectedNote == null)
				return;

			BinarySearchTree<string> bst = new BinarySearchTree<string>();
			foreach (Note n in Session.Project.Notes)
			{
				if (n.Category != "")
					bst.Add(n.Category);
			}

			CategoryForm dlg = new CategoryForm(bst.SortedList, SelectedNote.Category);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				SelectedNote.Category = dlg.Category;
				Session.Modified = true;

				update_notes();
			}
		}

		#region Clipboard

		private void NoteCutBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedNote != null)
				{
					Clipboard.SetData(typeof(Note).ToString(), SelectedNote.Copy());

					Session.Project.Notes.Remove(SelectedNote);
					Session.Modified = true;

					update_notes();
					SelectedNote = null;
				}
				else if (NoteBox.SelectedText !="")
				{
					NoteBox.Cut();

					Session.Modified = true;

					update_notes();
					SelectedNote = null;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NoteCopyBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (SelectedNote != null)
				{
					Clipboard.SetData(typeof(Note).ToString(), SelectedNote.Copy());
				}
				else if (NoteBox.SelectedText != "")
				{
					NoteBox.Copy();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NotePasteBtn_Click(object sender, EventArgs e)
		{
			try
			{
				if (Clipboard.ContainsData(typeof(Note).ToString()))
				{
					Note n = Clipboard.GetData(typeof(Note).ToString()) as Note;
					if (n != null)
					{
						if (Session.Project.FindNote(n.ID) != null)
						{
							// Set a new ID
							n.ID = Guid.NewGuid();
						}

						Session.Project.Notes.Add(n);
						Session.Modified = true;

						update_notes();
						SelectedNote = n;
					}
				}
                else if (Clipboard.ContainsText())
                {
					string text = Clipboard.GetText();

					if ((NoteBox.Focused) && (SelectedNote != null))
					{
						NoteBox.Paste();

						Session.Modified = true;

						update_notes();

						NoteBox.Focus();
					}
					else
					{
						Note n = new Note();
						n.Content = Clipboard.GetText();

						Session.Project.Notes.Add(n);
						Session.Modified = true;

						update_notes();
						SelectedNote = n;
					}
					
                }
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Search

		private void NoteSearchBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				update_notes();

				if (NoteList.Groups[1].Items.Count != 0)
				{
					Note n = NoteList.Groups[1].Items[0].Tag as Note;
					SelectedNote = n;
				}
				else
				{
					SelectedNote = null;
				}

				NoteSearchBox.Focus();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		private void NoteClearLbl_Click(object sender, EventArgs e)
		{
			try
			{
				NoteSearchBox.Text = "";
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#endregion

		#region Reference Toolbar

		private void DieRollerBtn_Click(object sender, EventArgs e)
		{
			DieRollerForm dlg = new DieRollerForm();
			dlg.ShowDialog();
		}

		#region Generators

		private void ElfNameBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>Elvish Names</H3>");

			lines.Add("<P class=instruction>Click on any name to create an encyclopedia entry for it.</P>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD><B>Male</B></TD>");
			lines.Add("<TD><B>Female</B></TD>");
			lines.Add("</TR>");

			for (int n = 0; n != 10; ++n)
			{
				string male = ElfName.MaleName();
				string female = ElfName.FemaleName();

				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + male.Replace(" ", "%20") + ">" + male + "</A></P>");
				lines.Add("</TD>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + female.Replace(" ", "%20") + ">" + female + "</A></P>");
				lines.Add("</TD>");

				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void DwarfNameBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>Dwarvish Names</H3>");

			lines.Add("<P class=instruction>Click on any name to create an encyclopedia entry for it.</P>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD><B>Male</B></TD>");
			lines.Add("<TD><B>Female</B></TD>");
			lines.Add("</TR>");

			for (int n = 0; n != 10; ++n)
			{
				string male = DwarfName.MaleName();
				string female = DwarfName.FemaleName();

				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + male.Replace(" ", "%20") + ">" + male + "</A></P>");
				lines.Add("</TD>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + female.Replace(" ", "%20") + ">" + female + "</A></P>");
				lines.Add("</TD>");

				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void HalflingNameBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>Halfling Names</H3>");

			lines.Add("<P class=instruction>Click on any name to create an encyclopedia entry for it.</P>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD><B>Male</B></TD>");
			lines.Add("<TD><B>Female</B></TD>");
			lines.Add("</TR>");

			for (int n = 0; n != 10; ++n)
			{
				string male = HalflingName.MaleName();
				string female = HalflingName.FemaleName();

				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + male.Replace(" ", "%20") + ">" + male + "</A></P>");
				lines.Add("</TD>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + female.Replace(" ", "%20") + ">" + female + "</A></P>");
				lines.Add("</TD>");

				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void ExoticNameBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>Exotic Names</H3>");

			lines.Add("<P class=instruction>Click on any name to create an encyclopedia entry for it.</P>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2><B>Names</B></TD>");
			lines.Add("</TR>");

			for (int n = 0; n != 10; ++n)
			{
				string name1 = ExoticName.FullName();
				string name2 = ExoticName.FullName();

				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + name1.Replace(" ", "%20") + ">" + name1 + "</A></P>");
				lines.Add("</TD>");

				lines.Add("<TD>");
				lines.Add("<P><A href=entry:" + name2.Replace(" ", "%20") + ">" + name2 + "</A></P>");
				lines.Add("</TD>");

				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void TreasureBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>Art Objects</H3>");

			lines.Add("<P class=instruction>Click on any item to make it available as a treasure parcel.</P>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD><B>Items</B></TD>");
			lines.Add("</TR>");

			for (int n = 0; n != 10; ++n)
			{
				string art = Treasure.ArtObject();

				lines.Add("<TR>");

				lines.Add("<TD>");
				lines.Add("<P><A href=parcel:" + art.Replace(" ", "%20") + ">" + art + "</A></P>");
				lines.Add("</TD>");

				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void BookTitleBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>Book Titles</H3>");

			for (int n = 0; n != 10; ++n)
				lines.Add("<P>" + Book.Title() + "</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void PotionBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>Potions</H3>");

			for (int n = 0; n != 10; ++n)
				lines.Add("<P>" + Potion.Description() + "</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void NPCBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>NPC Description</H3>");
			lines.Add("<P>" + NPCBuilder.Description() + "</P>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=3>");
			lines.Add("<B>NPC Details</B>");
			lines.Add("</TD>");
			lines.Add("</TR>");

			string physical = NPCBuilder.Physical();
			if (physical != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Physical Traits</B>");
				lines.Add("</TD>");
				lines.Add("<TD colspan=2>");
				lines.Add(physical);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string personality = NPCBuilder.Personality();
			if (personality != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Personality</B>");
				lines.Add("</TD>");
				lines.Add("<TD colspan=2>");
				lines.Add(personality);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			string speech = NPCBuilder.Speech();
			if (speech != "")
			{
				lines.Add("<TR>");
				lines.Add("<TD>");
				lines.Add("<B>Speech</B>");
				lines.Add("</TD>");
				lines.Add("<TD colspan=2>");
				lines.Add(speech);
				lines.Add("</TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void RoomBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");
			lines.Add("<H3>" + RoomBuilder.Name() + "</H3>");
			lines.Add("<P>" + RoomBuilder.Details() + "</P>");
			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void ElfTextBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");

			int sentences = Session.Dice(1, 6);
			for (int n = 0; n != sentences; ++n)
				lines.Add("<P>" + ElfName.Sentence() + "</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void DwarfTextBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");

			int sentences = Session.Dice(1, 6);
			for (int n = 0; n != sentences; ++n)
				lines.Add("<P>" + DwarfName.Sentence() + "</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void PrimordialTextBtn_Click(object sender, EventArgs e)
		{
			List<string> lines = HTML.GetHead(null, null, DisplaySize.Small);

			lines.Add("<BODY>");

			int sentences = Session.Dice(1, 6);
			for (int n = 0; n != sentences; ++n)
				lines.Add("<P>" + ExoticName.Sentence() + "</P>");

			lines.Add("</BODY>");

			GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
		}

		#endregion

		#endregion

		#endregion

		#region Updating

		public void UpdateView()
		{
			try
			{
				fUpdating = true;

				update_workspace();

				update_background_list();
				update_background_item();

				update_encyclopedia_list();
				update_encyclopedia_entry();

				update_rules_list();
				update_selected_rule();

				update_attachments();

				update_notes();

				update_reference();

				foreach (IAddIn addin in fExtensibility.AddIns)
				{
					foreach (IPage addin_page in addin.Pages)
						addin_page.UpdateView();
				}

				if (fView == ViewType.Delve)
				{
					// Update delve map
					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if (ctrl is MapView)
						{
							MapView mapview = ctrl as MapView;
							mapview.Map = Session.Project.FindTacticalMap(mapview.Map.ID);

							break;
						}
					}
				}
				if (fView == ViewType.Map)
				{
					// Update regional map
					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if (ctrl is RegionalMapPanel)
						{
							RegionalMapPanel mapview = ctrl as RegionalMapPanel;
							mapview.Map = Session.Project.FindRegionalMap(mapview.Map.ID);

							break;
						}
					}
				}

				fUpdating = false;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Form

		void update_title()
		{
			try
			{
				string title = "Masterplan";
				if (Session.Project != null)
					title = Session.Project.Name + " - Masterplan";

				Text = title;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Workspace

		void update_workspace()
		{
			try
			{
				update_navigation();
				update_preview();
				update_breadcrumbs();

				PlotView.Invalidate();

				if (fView == ViewType.Delve)
				{
					MapView mapview = null;

					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if ((ctrl is MapView) && (ctrl.Visible))
						{
							mapview = ctrl as MapView;
							break;
						}
					}

					if (mapview != null)
						mapview.MapChanged();
				}

				if (fView == ViewType.Map)
				{
					RegionalMapPanel mapview = null;

					foreach (Control ctrl in PreviewSplitter.Panel1.Controls)
					{
						if ((ctrl is RegionalMapPanel) && (ctrl.Visible))
						{
							mapview = ctrl as RegionalMapPanel;
							break;
						}
					}

					if (mapview != null)
						mapview.Invalidate();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#region Navigation

		void update_navigation()
		{
			try
			{
				NavigationTree.BeginUpdate();

				NavigationTree.Nodes.Clear();

				if (Session.Project != null)
				{
					add_navigation_node(null, null);
					NavigationTree.ExpandAll();
				}

				NavigationTree.EndUpdate();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void add_navigation_node(PlotPoint pp, TreeNode parent)
		{
			try
			{
				string name = (pp != null) ? pp.Name : Session.Project.Name;

				TreeNodeCollection tnc = (parent != null) ? parent.Nodes : NavigationTree.Nodes;
				TreeNode node = tnc.Add(name);

				Plot p = (pp != null) ? pp.Subplot : Session.Project.Plot;
				node.Tag = p;

				if (PlotView.Plot == p)
				{
					NavigationTree.SelectedNode = node;
				}

				List<PlotPoint> list = (pp != null) ? pp.Subplot.Points : Session.Project.Plot.Points;
				foreach (PlotPoint child in list)
				{
					if ((child.Subplot.Points.Count != 0) || (child.Subplot == PlotView.Plot))
						add_navigation_node(child, node);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Breadcrumbs

		void update_breadcrumbs()
		{
			try
			{
				BreadcrumbBar.Items.Clear();

				if (Session.Project != null)
				{
					List<PlotPoint> breadcrumbs = new List<PlotPoint>();

					Plot p = PlotView.Plot;
					while (p != null)
					{
						PlotPoint pp = Session.Project.FindParent(p);
						p = (pp != null) ? Session.Project.FindParent(pp) : null;

						breadcrumbs.Add(pp);
					}

					breadcrumbs.Reverse();
					foreach (PlotPoint pp in breadcrumbs)
					{
						// Add breadcrumb for this plot point
						bool link = (breadcrumbs.IndexOf(pp) != breadcrumbs.Count - 1);
						add_breadcrumb(pp, link);
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void add_breadcrumb(PlotPoint pp, bool link)
		{
			try
			{
				string name = (pp != null) ? pp.Name : Session.Project.Name;
				ToolStripLabel tsl = new ToolStripLabel(name);
				tsl.IsLink = link;
				tsl.Tag = pp;
				tsl.Click += new EventHandler(Breadcrumb_Click);

				BreadcrumbBar.Items.Add(tsl);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void Breadcrumb_Click(object sender, EventArgs e)
		{
			try
			{
				ToolStripLabel tsl = sender as ToolStripLabel;
				PlotPoint pp = tsl.Tag as PlotPoint;

				if (pp == null)
				{
					PlotView.Plot = Session.Project.Plot;
					UpdateView();
				}
				else
				{
					PlotView.Plot = pp.Subplot;
					UpdateView();
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#endregion

		#region Background

		void update_background_list()
		{
			try
			{
				Background selection = SelectedBackground;

				BackgroundList.Items.Clear();

				if (Session.Project != null)
				{
					foreach (Background bg in Session.Project.Backgrounds)
					{
						ListViewItem lvi = BackgroundList.Items.Add(bg.Title);
						lvi.Tag = bg;

						if (bg.Details == "")
							lvi.ForeColor = SystemColors.GrayText;

						if (bg == selection)
							lvi.Selected = true;
					}

					if (Session.Project.Backgrounds.Count == 0)
					{
						ListViewItem lvi = BackgroundList.Items.Add("(no backgrounds)");
						lvi.ForeColor = SystemColors.GrayText;
					}
				}
				else
				{
					ListViewItem lvi = BackgroundList.Items.Add("(no project)");
					lvi.ForeColor = SystemColors.GrayText;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void update_background_item()
		{
			try
			{
				BackgroundDetails.Document.OpenNew(true);
				BackgroundDetails.Document.Write(HTML.Background(SelectedBackground, DisplaySize.Small));
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Encyclopedia

		void update_encyclopedia_templates()
		{
			try
			{
				string dir = Application.StartupPath + "\\Encyclopedia";
				if (Directory.Exists(dir))
				{
					List<string> files = new List<string>();
					files.AddRange(Directory.GetFiles(dir, "*.txt"));
					files.AddRange(Directory.GetFiles(dir, "*.htm"));
					files.AddRange(Directory.GetFiles(dir, "*.html"));

					if (files.Count > 0)
					{
						EncAddBtn.DropDownItems.Add(new ToolStripSeparator());

						foreach (string filename in files)
						{
							string name = FileName.Name(filename);
							ToolStripMenuItem tsmi = new ToolStripMenuItem(name);
							tsmi.Tag = filename;
							tsmi.Click += new EventHandler(encyclopedia_template);

							EncAddBtn.DropDownItems.Add(tsmi);
						}
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void update_encyclopedia_list()
		{
			try
			{
				string[] split = null;
				string[] tokens = EncSearchBox.Text.ToLower().Split(split, StringSplitOptions.RemoveEmptyEntries);

				EntryList.BeginUpdate();

				if (Session.Project != null)
				{
					EntryList.ShowGroups = true;

					BinarySearchTree<string> bst = new BinarySearchTree<string>();
					foreach (EncyclopediaEntry entry in Session.Project.Encyclopedia.Entries)
					{
						if ((entry.Category != null) && (entry.Category != ""))
							bst.Add(entry.Category);
					}
					List<string> cats = bst.SortedList;
					cats.Insert(0, "Groups");
					cats.Add("Miscellaneous Entries");

					EntryList.Groups.Clear();
					foreach (string cat in cats)
						EntryList.Groups.Add(cat, cat);

					List<ListViewItem> items = new List<ListViewItem>();

					if (tokens.Length == 0)
					{
						List<EncyclopediaGroup> groups = new List<EncyclopediaGroup>();
						groups.AddRange(Session.Project.Encyclopedia.Groups);
						groups.Sort();

						foreach (EncyclopediaGroup group in groups)
						{
							ListViewItem lvi = new ListViewItem(group.Name);
							lvi.Tag = group;
							lvi.Group = EntryList.Groups["Groups"];

							items.Add(lvi);
						}
					}

					foreach (EncyclopediaEntry entry in Session.Project.Encyclopedia.Entries)
					{
						if (!match(entry, tokens))
							continue;

						ListViewItem lvi = new ListViewItem(entry.Name);
						lvi.Tag = entry;
						if ((entry.Category != null) && (entry.Category != ""))
							lvi.Group = EntryList.Groups[entry.Category];
						else
							lvi.Group = EntryList.Groups["Miscellaneous Entries"];

						if ((entry.Details == "") && (entry.DMInfo == ""))
							lvi.ForeColor = SystemColors.GrayText;

						items.Add(lvi);
					}

					if (items.Count == 0)
					{
						EntryList.ShowGroups = false;

						string str = (EncSearchBox.Text == "") ? "(no entries)" : "(no matching entries)";
						ListViewItem lvi = new ListViewItem(str);
						lvi.ForeColor = SystemColors.GrayText;

						items.Add(lvi);
					}

					EntryList.Items.Clear();
					EntryList.Items.AddRange(items.ToArray());
				}
				else
				{
					ListViewItem lvi = EntryList.Items.Add("(no project)");
					lvi.ForeColor = SystemColors.GrayText;
				}

				EntryList.EndUpdate();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		bool match(EncyclopediaEntry entry, string[] tokens)
		{
			try
			{
				foreach (string token in tokens)
				{
					if (!match(entry, token))
						return false;
				}

				return true;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return false;
		}

		bool match(EncyclopediaEntry entry, string token)
		{
			try
			{
				if (entry.Name.ToLower().Contains(token))
					return true;

				if (entry.Details.ToLower().Contains(token))
					return true;

				return false;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return false;
		}

		void update_encyclopedia_entry()
		{
			try
			{
				Encyclopedia enc = (Session.Project != null) ? Session.Project.Encyclopedia : null;
				string str = "";

				if (SelectedEncyclopediaItem != null)
				{
					if (SelectedEncyclopediaItem is EncyclopediaEntry)
					{
						str = HTML.EncyclopediaEntry(SelectedEncyclopediaItem as EncyclopediaEntry, enc, DisplaySize.Small, true, true, true, false);
					}
					if (SelectedEncyclopediaItem is EncyclopediaGroup)
					{
						str = HTML.EncyclopediaGroup(SelectedEncyclopediaItem as EncyclopediaGroup, enc, DisplaySize.Small, true, true);
					}
				}
				else
				{
					str = HTML.EncyclopediaEntry(null, enc, DisplaySize.Small, true, true, true, false);
				}

				EntryDetails.Document.OpenNew(true);
				EntryDetails.Document.Write(str);

				update_encyclopedia_images();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void update_encyclopedia_images()
		{
			try
			{
				EncyclopediaEntry entry = null;
				if ((SelectedEncyclopediaItem != null) && (SelectedEncyclopediaItem is EncyclopediaEntry))
					entry = SelectedEncyclopediaItem as EncyclopediaEntry;

				bool show_sidebar = false;
				if (entry != null)
					show_sidebar = (entry.Images.Count > 0);

				if (show_sidebar)
				{
					EntryImageList.Items.Clear();
					EntryImageList.LargeImageList = null;

					const int PICTURE_SIZE = 64;

					ImageList images = new ImageList();
					images.ImageSize = new Size(PICTURE_SIZE, PICTURE_SIZE);
					images.ColorDepth = ColorDepth.Depth32Bit;
					EntryImageList.LargeImageList = images;

					foreach (EncyclopediaImage img in entry.Images)
					{
						if (img.Image == null)
							continue;

						ListViewItem lvi = EntryImageList.Items.Add(img.Name);
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

					EncyclopediaEntrySplitter.Panel2Collapsed = false;
				}
				else
				{
					// Clear the sidebar
					EntryImageList.Items.Clear();
					EntryImageList.LargeImageList = null;

					EncyclopediaEntrySplitter.Panel2Collapsed = true;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Rules

		void update_rules_list()
		{
			RulesList.Items.Clear();
			RulesList.ShowGroups = true;

			if (Session.Project != null)
			{
				foreach (IPlayerOption option in Session.Project.PlayerOptions)
				{
					int group_index = 0;
					if (option is Race)
						group_index = 0;
					if (option is Class)
						group_index = 1;
					if (option is Theme)
						group_index = 2;
					if (option is ParagonPath)
						group_index = 3;
					if (option is EpicDestiny)
						group_index = 4;
					if (option is PlayerBackground)
						group_index = 5;
					if (option is Feat)
					{
						Feat ft = option as Feat;
						switch (ft.Tier)
						{
							case Tier.Heroic:
								group_index = 6;
								break;
							case Tier.Paragon:
								group_index = 7;
								break;
							case Tier.Epic:
								group_index = 8;
								break;
						}
					}
					if (option is Weapon)
						group_index = 9;
					if (option is Ritual)
						group_index = 10;
					if (option is CreatureLore)
						group_index = 11;
					if (option is Disease)
						group_index = 12;
					if (option is Poison)
						group_index = 13;

					ListViewItem lvi = RulesList.Items.Add(option.Name);
					lvi.Tag = option;
					lvi.Group = RulesList.Groups[group_index];
				}

				if (RulesList.Items.Count == 0)
				{
					RulesList.ShowGroups = false;

					ListViewItem lvi = RulesList.Items.Add("(none)");
					lvi.ForeColor = SystemColors.GrayText;
				}
			}
		}

		void update_selected_rule()
		{
			if (SelectedRule != null)
			{
				RulesBrowser.Document.OpenNew(true);
				RulesBrowser.Document.Write(HTML.PlayerOption(SelectedRule, DisplaySize.Small));
			}
			else
			{
				List<string> lines = new List<string>();
				lines.Add("<HTML>");
				lines.AddRange(HTML.GetHead(null, null, DisplaySize.Small));
				lines.Add("<BODY>");
				lines.Add("<P class=instruction>On this page you can create and manage campaign-specific rules elements.</P>");
				lines.Add("</BODY>");
				lines.Add("</HTML>");

				RulesBrowser.Document.OpenNew(true);
				RulesBrowser.Document.Write(HTML.Concatenate(lines));
			}
		}

		#endregion

		#region Attachments

		void update_attachments()
		{
			try
			{
				if (Session.Project != null)
				{
					BinarySearchTree<string> categories = new BinarySearchTree<string>();
					foreach (Attachment att in Session.Project.Attachments)
					{
						string cat = FileName.Extension(att.Name).ToUpper() + " Files";
						categories.Add(cat);
					}

					List<string> cats = categories.SortedList;
					AttachmentList.Groups.Clear();
					foreach (string cat in cats)
						AttachmentList.Groups.Add(cat, cat);

					AttachmentList.Items.Clear();
					foreach (Attachment att in Session.Project.Attachments)
					{
						int b = att.Contents.Length;
						string size = b + " B";
						float kb = (float)b / 1024;
						if (kb >= 1)
							size = kb.ToString("F1") + " KB";
						float mb = (float)kb / 1024;
						if (mb >= 1)
							size = mb.ToString("F1") + " MB";
						float gb = (float)mb / 1024;
						if (gb >= 1)
							size = gb.ToString("F1") + " GB";

						string cat = FileName.Extension(att.Name).ToUpper() + " Files";

						ListViewItem lvi = AttachmentList.Items.Add(att.Name);
						lvi.SubItems.Add(size);
						lvi.Group = AttachmentList.Groups[cat];
						lvi.Tag = att;
					}

					if (Session.Project.Attachments.Count == 0)
					{
						ListViewItem lvi = AttachmentList.Items.Add("(no attachments)");
						lvi.ForeColor = SystemColors.GrayText;
					}
				}
				else
				{
					ListViewItem lvi = AttachmentList.Items.Add("(no project)");
					lvi.ForeColor = SystemColors.GrayText;
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion

		#region Jotter

		void update_notes()
		{
			try
			{
				NoteList.BeginUpdate();

				Note selected_note = SelectedNote;

				NoteList.Items.Clear();
				NoteBox.Text = "";

				BinarySearchTree<string> bst = new BinarySearchTree<string>();
				if (Session.Project != null)
				{
					foreach (Note n in Session.Project.Notes)
					{
						if (n.Category != "")
							bst.Add(n.Category);
					}
				}
				List<string> cats = bst.SortedList;
				cats.Add("Notes");

				NoteList.Groups.Clear();
				foreach (string cat in cats)
					NoteList.Groups.Add(cat, cat);

				string[] tokens = NoteSearchBox.Text.ToLower().Split();

				if (Session.Project != null)
				{
					foreach (Note n in Session.Project.Notes)
					{
						if (!match(n, tokens))
							continue;

						ListViewItem lvi = NoteList.Items.Add(n.Name);
						lvi.Tag = n;

						if (n.Category == "")
							lvi.Group = NoteList.Groups["Notes"];
						else
							lvi.Group = NoteList.Groups[n.Category];

						if (n.Content == "")
							lvi.ForeColor = SystemColors.GrayText;

						if (n == selected_note)
							lvi.Selected = true;
					}
				}

				if (NoteList.Groups["Notes"].Items.Count == 0)
				{
					string str = (NoteSearchBox.Text == "") ? "(no notes)" : "(no matching notes)";
					ListViewItem lvi = NoteList.Items.Add(str);
					lvi.ForeColor = SystemColors.GrayText;
					lvi.Group = NoteList.Groups["Notes"];
				}

				NoteList.Sort();
				NoteList.EndUpdate();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		bool match(Note n, string[] tokens)
		{
			try
			{
				foreach (string token in tokens)
				{
					if (!match(n, token))
						return false;
				}

				return true;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return false;
		}

		bool match(Note n, string token)
		{
			try
			{
				return n.Content.ToLower().Contains(token);
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return false;
		}

		#endregion

		#region Reference

		void update_reference()
		{
			if (Session.Project != null)
				InfoPanel.Level = Session.Project.Party.Level;

			update_party();

			if (GeneratorBrowser.DocumentText == "")
			{
				List<string> lines = new List<string>();

				lines.AddRange(HTML.GetHead(null, null, DisplaySize.Small));
				lines.Add("<BODY>");

				lines.Add("<P class=instruction>");
				lines.Add("Use the buttons to the left to generate random names etc.");
				lines.Add("</P>");

				lines.Add("</BODY>");

				GeneratorBrowser.DocumentText = HTML.Concatenate(lines);
			}

			foreach (IAddIn addin in fExtensibility.AddIns)
			{
				foreach (IPage page in addin.QuickReferencePages)
					page.UpdateView();
			}
		}

		void update_party()
		{
			if (PartyBrowser.Document == null)
				PartyBrowser.DocumentText = "";

			PartyBrowser.Document.OpenNew(true);
			PartyBrowser.Document.Write(HTML.PCs(fPartyBreakdownSecondary, DisplaySize.Small));
		}

		#endregion

		#endregion

		#region Helper methods

		void add_between(object sender, EventArgs e)
		{
			try
			{
				ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
				Pair<PlotPoint, PlotPoint> points = tsmi.Tag as Pair<PlotPoint, PlotPoint>;

				// Add point
				add_point(points.First, points.Second);
				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void disconnect_points(object sender, EventArgs e)
		{
			try
			{
				ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
				Pair<PlotPoint, PlotPoint> points = tsmi.Tag as Pair<PlotPoint, PlotPoint>;

				// Disconnect point
				Guid id = points.Second.ID;
				while (points.First.Links.Contains(id))
					points.First.Links.Remove(id);

				PlotView.RecalculateLayout();
				Session.Modified = true;
				update_workspace();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void move_to_subplot(object sender, EventArgs e)
		{
			try
			{
				ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
				Pair<PlotPoint, PlotPoint> points = tsmi.Tag as Pair<PlotPoint, PlotPoint>;

				// Move this to the subplot
				PlotView.Plot.RemovePoint(points.Second);
				//points.Second.Links.Clear();
				points.First.Subplot.Points.Add(points.Second);
				Session.Modified = true;

				PlotView.RecalculateLayout();
				UpdateView();
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void add_attachment(string filename)
		{
			try
			{
				FileInfo fi = new FileInfo(filename);

				Attachment att = new Attachment();
				att.Name = fi.Name;
				att.Contents = File.ReadAllBytes(filename);

				Attachment existing = Session.Project.FindAttachment(att.Name);
				if (existing != null)
				{
					string str = "An attachment with this name already exists.";
					str += Environment.NewLine;
					str += "Do you want to replace it?";

					DialogResult dr = MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					switch (dr)
					{
						case DialogResult.Yes:
							// Replace the existing attachment
							Session.Project.Attachments.Remove(existing);
							break;
						case DialogResult.No:
							// Add a new attachment with a unique name
							{
								int n = 1;
								while (Session.Project.FindAttachment(att.Name) != null)
								{
									n += 1;
									att.Name = FileName.Name(filename) + " " + n + "." + FileName.Extension(filename);
								}
							}
							break;
						case DialogResult.Cancel:
							// Do nothing
							return;
					}
				}

				Session.Project.Attachments.Add(att);
				Session.Project.Attachments.Sort();

				Session.Modified = true;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		bool check_modified()
		{
			try
			{
				if (Session.Modified)
				{
					string str = "The project has been modified.\nDo you want to save it now?";
					DialogResult dr = MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					switch (dr)
					{
						case DialogResult.Yes:
							// Save
							{
								if (Session.FileName != "")
								{
									GC.Collect();

									Session.Project.PopulateProjectLibrary();
									bool ok = Serialisation<Project>.Save(Session.FileName, Session.Project, SerialisationMode.Binary);
									Session.Project.SimplifyProjectLibrary();

									if (!ok)
										return false;

									Session.Modified = false;
								}
								else
								{
									SaveFileDialog dlg = new SaveFileDialog();
									dlg.Filter = Program.ProjectFilter;
									dlg.FileName = Session.Project.Name;
									if (dlg.ShowDialog() == DialogResult.OK)
									{
										GC.Collect();

										Session.Project.PopulateProjectLibrary();
										bool ok = Serialisation<Project>.Save(dlg.FileName, Session.Project, SerialisationMode.Binary);
										Session.Project.SimplifyProjectLibrary();

										if (!ok)
											return false;

										Session.FileName = dlg.FileName;
										Session.Modified = false;
									}
									else
									{
										return false;
									}
								}
							}
							break;
						case DialogResult.No:
							// Don't save
							break;
						case DialogResult.Cancel:
							// Cancel
							return false;
					}
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}

			return true;
		}

		void print_page(object sender, PrintPageEventArgs e)
		{
			try
			{
				Bitmap bmp = Screenshot.Plot(PlotView.Plot, e.MarginBounds.Size);
				e.Graphics.DrawImage(bmp, e.MarginBounds);

				e.HasMorePages = false;
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		#endregion
	}
}
