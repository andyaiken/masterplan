using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class MonsterThemeSelectForm : Form
	{
        public MonsterThemeSelectForm()
		{
			InitializeComponent();

			List<MonsterTheme> themes = Session.Themes;

            foreach (MonsterTheme mt in themes)
			{
				ListViewItem lvi = ThemeList.Items.Add(mt.Name);
				lvi.Tag = mt;
			}

			Application.Idle += new EventHandler(Application_Idle);
		}

		void Application_Idle(object sender, EventArgs e)
		{
			OKBtn.Enabled = (MonsterTheme != null);
		}

        public MonsterTheme MonsterTheme
		{
			get
			{
				if (ThemeList.SelectedItems.Count != 0)
                    return ThemeList.SelectedItems[0].Tag as MonsterTheme;

				return null;
			}
		}

		private void TileList_DoubleClick(object sender, EventArgs e)
		{
			if (MonsterTheme != null)
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}
	}
}
