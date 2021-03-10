using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class MergeLibrariesForm : Form
	{
		public MergeLibrariesForm()
		{
			InitializeComponent();

            foreach (Library lib in Session.Libraries)
			{
				ListViewItem lvi = ThemeList.Items.Add(lib.Name);
				lvi.Tag = lib;
			}

			NameBox.Text = "Merged Library";

			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (SelectedLibraries.Count >= 2);
		}

        public List<Library> SelectedLibraries
		{
			get
			{
				List<Library> list = new List<Library>();

				foreach (ListViewItem lvi in ThemeList.CheckedItems)
				{
					Library lib = lvi.Tag as Library;
					if (lib != null)
						list.Add(lib);
				}

				return list;
			}
		}

		public string LibraryName
		{
			get { return NameBox.Text; }
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
		}
	}
}
