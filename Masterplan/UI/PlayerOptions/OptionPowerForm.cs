using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionPowerForm : Form
	{
		public OptionPowerForm(PlayerPower power)
		{
			InitializeComponent();

			Array types = Enum.GetValues(typeof(PlayerPowerType));
			foreach (PlayerPowerType type in types)
				TypeBox.Items.Add(type);

			Array actions = Enum.GetValues(typeof(ActionType));
			foreach (ActionType action in actions)
				ActionBox.Items.Add(action);

			RangeBox.Items.Add("Personal");
			RangeBox.Items.Add("Melee touch");
			RangeBox.Items.Add("Melee 1");
			RangeBox.Items.Add("Melee weapon");
			RangeBox.Items.Add("Ranged 10");
			RangeBox.Items.Add("Ranged weapon");
			RangeBox.Items.Add("Ranged sight");
			RangeBox.Items.Add("Close burst 1");
			RangeBox.Items.Add("Close blast 3");
			RangeBox.Items.Add("Area burst 3 within 10");
			RangeBox.Items.Add("Area wall 3 within 10");

			Application.Idle += new EventHandler(Application_Idle);

			fPower = power.Copy();

			NameBox.Text = fPower.Name;
			TypeBox.SelectedItem = fPower.Type;
			ActionBox.SelectedItem = fPower.Action;
			KeywordBox.Text = fPower.Keywords;
			RangeBox.Text = fPower.Range;
			ReadAloudBox.Text = fPower.ReadAloud;

			update_sections();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			int index = fPower.Sections.IndexOf(SelectedSection);

			SectionRemoveBtn.Enabled = (SelectedSection != null);
			SectionEditBtn.Enabled = (SelectedSection != null);

			SectionUpBtn.Enabled = ((SelectedSection != null) && (index != 0));
			SectionDownBtn.Enabled = ((SelectedSection != null) && (index != fPower.Sections.Count - 1));

			SectionLeftBtn.Enabled = ((SelectedSection != null) && (SelectedSection.Indent > 0));
			SectionRightBtn.Enabled = false;
			if (index > 0)
			{
				PlayerPowerSection prev = fPower.Sections[index - 1];
				SectionRightBtn.Enabled = ((SelectedSection != null) && (SelectedSection.Indent <= prev.Indent));
			}
		}

		public PlayerPower Power
		{
			get { return fPower; }
		}
		PlayerPower fPower = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fPower.Name = NameBox.Text;
			fPower.Type = (PlayerPowerType)TypeBox.SelectedItem;
			fPower.Action = (ActionType)ActionBox.SelectedItem;
			fPower.Keywords = KeywordBox.Text;
			fPower.Range = RangeBox.Text;
			fPower.ReadAloud = ReadAloudBox.Text;
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
				fPower.Sections.Add(dlg.Section);
				update_sections();
			}
		}

		private void SectionRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				fPower.Sections.Remove(SelectedSection);
				update_sections();
			}
		}

		private void SectionEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPower.Sections.IndexOf(SelectedSection);

				OptionPowerSectionForm dlg = new OptionPowerSectionForm(SelectedSection);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fPower.Sections[index] = dlg.Section;
					update_sections();
				}
			}
		}

		private void SectionUpBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPower.Sections.IndexOf(SelectedSection);

				PlayerPowerSection tmp = fPower.Sections[index - 1];
				fPower.Sections[index - 1] = SelectedSection;
				fPower.Sections[index] = tmp;

				update_sections();

				SectionList.SelectedIndices.Add(index - 1);
			}
		}

		private void SectionDownBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPower.Sections.IndexOf(SelectedSection);

				PlayerPowerSection tmp = fPower.Sections[index + 1];
				fPower.Sections[index + 1] = SelectedSection;
				fPower.Sections[index] = tmp;

				update_sections();

				SectionList.SelectedIndices.Add(index + 1);
			}
		}

		private void SectionLeftBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPower.Sections.IndexOf(SelectedSection);

				SelectedSection.Indent -= 1;
				update_sections();

				SectionList.SelectedIndices.Add(index);
			}
		}

		private void SectionRightBtn_Click(object sender, EventArgs e)
		{
			if (SelectedSection != null)
			{
				int index = fPower.Sections.IndexOf(SelectedSection);

				SelectedSection.Indent += 1;
				update_sections();

				SectionList.SelectedIndices.Add(index);
			}
		}

		void update_sections()
		{
			SectionList.Items.Clear();
			foreach (PlayerPowerSection section in fPower.Sections)
			{
				string str = "";
				for (int n = 0; n != section.Indent; ++n)
					str += "    ";
				str += section.Header + ": " + section.Details;

				ListViewItem lvi = SectionList.Items.Add(str);
				lvi.Tag = section;
			}

			if (fPower.Sections.Count == 0)
			{
				ListViewItem lvi = SectionList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
