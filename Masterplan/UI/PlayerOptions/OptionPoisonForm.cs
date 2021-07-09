using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionPoisonForm : Form
	{
		public OptionPoisonForm(Poison poison)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fPoison = poison.Copy();

			NameBox.Text = fPoison.Name;
			LevelBox.Value = fPoison.Level;
			DetailsBox.Text = fPoison.Details;

			update_sections();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			int index = fPoison.Sections.IndexOf(SelectedSection);

			SectionRemoveBtn.Enabled = (SelectedSection != null);
			SectionEditBtn.Enabled = (SelectedSection != null);

			SectionUpBtn.Enabled = ((SelectedSection != null) && (index != 0));
			SectionDownBtn.Enabled = ((SelectedSection != null) && (index != fPoison.Sections.Count - 1));

			SectionLeftBtn.Enabled = ((SelectedSection != null) && (SelectedSection.Indent > 0));
			SectionRightBtn.Enabled = false;
			if (index > 0)
			{
				PlayerPowerSection prev = fPoison.Sections[index - 1];
				SectionRightBtn.Enabled = ((SelectedSection != null) && (SelectedSection.Indent <= prev.Indent));
			}
		}

		public Poison Poison
		{
			get { return fPoison; }
		}
		Poison fPoison = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fPoison.Name = NameBox.Text;
			fPoison.Level = (int)LevelBox.Value;
			fPoison.Details = DetailsBox.Text;
		}

		public PlayerPowerSection SelectedSection
		{
			get
			{
				if (SectionList.SelectedItems.Count != 0)
					return SectionList.SelectedItems[0].Tag as PlayerPowerSection;

				return null;
			}
		}

		private void SectionAddBtn_Click(object sender, EventArgs e)
		{
			PlayerPowerSection section = new PlayerPowerSection();

			OptionPowerSectionForm dlg = new OptionPowerSectionForm(section);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fPoison.Sections.Add(dlg.Section);
				update_sections();
			}
		}

		private void SectionRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				fPoison.Sections.Remove(SelectedSection);
				update_sections();
			}
		}

		private void SectionEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPoison.Sections.IndexOf(SelectedSection);

				OptionPowerSectionForm dlg = new OptionPowerSectionForm(SelectedSection);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fPoison.Sections[index] = dlg.Section;
					update_sections();
				}
			}
		}

		private void SectionUpBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPoison.Sections.IndexOf(SelectedSection);

				PlayerPowerSection tmp = fPoison.Sections[index - 1];
				fPoison.Sections[index - 1] = SelectedSection;
				fPoison.Sections[index] = tmp;

				update_sections();

				SectionList.SelectedIndices.Add(index - 1);
			}
		}

		private void SectionDownBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPoison.Sections.IndexOf(SelectedSection);

				PlayerPowerSection tmp = fPoison.Sections[index + 1];
				fPoison.Sections[index + 1] = SelectedSection;
				fPoison.Sections[index] = tmp;

				update_sections();

				SectionList.SelectedIndices.Add(index + 1);
			}
		}

		private void SectionLeftBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPoison.Sections.IndexOf(SelectedSection);

				SelectedSection.Indent -= 1;
				update_sections();

				SectionList.SelectedIndices.Add(index);
			}
		}

		private void SectionRightBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPoison.Sections.IndexOf(SelectedSection);

				SelectedSection.Indent += 1;
				update_sections();

				SectionList.SelectedIndices.Add(index);
			}
		}

		void update_sections()
		{
			SectionList.Items.Clear();
			foreach (PlayerPowerSection section in fPoison.Sections)
			{
				string str = "";
				for (int n = 0; n != section.Indent; ++n)
					str += "    ";
				str += section.Header + ": " + section.Details;

				ListViewItem lvi = SectionList.Items.Add(str);
				lvi.Tag = section;
			}

			if (fPoison.Sections.Count == 0)
			{
				ListViewItem lvi = SectionList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
