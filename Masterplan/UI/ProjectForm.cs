using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class ProjectForm : Form
	{
		public ProjectForm(Project p)
		{
			InitializeComponent();

			fProject = p;

			NameBox.Text = fProject.Name;
			AuthorBox.Text = fProject.Author;

			SizeBox.Value = fProject.Party.Size;
			LevelBox.Value = fProject.Party.Level;
            LevelBox_ValueChanged(null, null);

            XPBox.Value = fProject.Party.XP;
		}

		public Project Project
		{
			get { return fProject; }
		}
		Project fProject = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fProject.Name = NameBox.Text;
			fProject.Author = AuthorBox.Text;

			fProject.Party.Size = (int)SizeBox.Value;
			fProject.Party.Level = (int)LevelBox.Value;
            fProject.Party.XP = (int)XPBox.Value;

			fProject.Library.Name = fProject.Name;
		}

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
		}

		private void SizeBox_ValueChanged(object sender, EventArgs e)
		{
		}

        private void LevelBox_ValueChanged(object sender, EventArgs e)
        {
            int level = (int)LevelBox.Value;

            XPBox.Minimum = Experience.GetHeroXP(level);
            XPBox.Maximum = Math.Max(Experience.GetHeroXP(level + 1) - 1, XPBox.Minimum);

            XPBox.Value = XPBox.Minimum;
		}

		private void XPBox_ValueChanged(object sender, EventArgs e)
		{
		}
	}
}
