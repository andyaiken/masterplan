using System;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionCreatureLoreForm : Form
	{
		public OptionCreatureLoreForm(CreatureLore cl)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			SkillBox.Items.Add("Arcana");
			SkillBox.Items.Add("Dungeoneering");
			SkillBox.Items.Add("History");
			SkillBox.Items.Add("Nature");
			SkillBox.Items.Add("Religion");

			fCreatureLore = cl.Copy();

			NameBox.Text = fCreatureLore.Name;
			SkillBox.Text = fCreatureLore.SkillName;

			update_information();
		}

		~OptionCreatureLoreForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedInformation != null);
			EditBtn.Enabled = (SelectedInformation != null);
		}

		public CreatureLore CreatureLore
		{
			get { return fCreatureLore; }
		}
		CreatureLore fCreatureLore = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fCreatureLore.Name = NameBox.Text;
			fCreatureLore.SkillName = SkillBox.Text;
		}

		public Pair<int, string> SelectedInformation
		{
			get
			{
				if (InfoList.SelectedItems.Count != 0)
					return InfoList.SelectedItems[0].Tag as Pair<int, string>;

				return null;
			}
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			Pair<int, string> information = new Pair<int, string>();
			information.First = 10;
			information.Second = "";

			OptionInformationForm dlg = new OptionInformationForm(information);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCreatureLore.Information.Add(dlg.Information);
				update_information();
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedInformation != null)
			{
				fCreatureLore.Information.Remove(SelectedInformation);
				update_information();
			}
		}

		private void FeatureEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedInformation != null)
			{
				int index = fCreatureLore.Information.IndexOf(SelectedInformation);

				OptionInformationForm dlg = new OptionInformationForm(SelectedInformation);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCreatureLore.Information[index] = dlg.Information;
					update_information();
				}
			}
		}

		void update_information()
		{
			fCreatureLore.Information.Sort();

			InfoList.Items.Clear();
			foreach (Pair<int, string> info in fCreatureLore.Information)
			{
				string str = "DC " + info.First + ": " + info.Second;

				ListViewItem lvi = InfoList.Items.Add(str);
				lvi.Tag = info;
			}
		}
	}
}
