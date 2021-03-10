using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class TileLibrarySelectForm : Form
	{
		public TileLibrarySelectForm(List<Library> selected_libraries)
		{
			InitializeComponent();

			List<Library> libraries = new List<Library>();
			libraries.AddRange(Session.Libraries);
			libraries.Add(Session.Project.Library);

			foreach (Library lib in libraries)
			{
				if (lib.Tiles.Count == 0)
					continue;

				ListViewItem lvi = LibraryList.Items.Add(lib.Name);
				lvi.Tag = lib;

				lvi.Checked = selected_libraries.Contains(lib);
			}

			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (Libraries.Count != 0);
		}

		public List<Library> Libraries
		{
			get
			{
				List<Library> libs = new List<Library>();

				foreach (ListViewItem lvi in LibraryList.CheckedItems)
				{
					Library lib = lvi.Tag as Library;

					if (lib != null)
						libs.Add(lib);
				}

				return libs;
			}
		}

		private void SelectAllBtn_Click(object sender, EventArgs e)
		{
			LibraryList.BeginUpdate();

			foreach (ListViewItem lvi in LibraryList.Items)
				lvi.Checked = true;

			LibraryList.EndUpdate();
		}

		private void DeselectAllBtn_Click(object sender, EventArgs e)
		{
			LibraryList.BeginUpdate();

			foreach (ListViewItem lvi in LibraryList.Items)
				lvi.Checked = false;

			LibraryList.EndUpdate();
		}
	}
}
