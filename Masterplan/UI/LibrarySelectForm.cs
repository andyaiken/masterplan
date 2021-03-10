using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class LibrarySelectForm : Form
	{
		public LibrarySelectForm()
		{
			InitializeComponent();

            foreach (Library lib in Session.Libraries)
			{
				ListViewItem lvi = ThemeList.Items.Add(lib.Name);
				lvi.Tag = lib;
			}

			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (SelectedLibrary != null);
		}

        public Library SelectedLibrary
		{
			get
			{
				if (ThemeList.SelectedItems.Count != 0)
					return ThemeList.SelectedItems[0].Tag as Library;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (SelectedLibrary != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
