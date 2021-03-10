using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class DamageModListForm : Form
	{
		public DamageModListForm(ICreature creature)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fCreature = creature;

			fModifiers = new List<DamageModifier>();
			foreach (DamageModifier mod in fCreature.DamageModifiers)
				fModifiers.Add(mod.Copy());

			update_damage_list();

			ResistBox.Text = fCreature.Resist;
			VulnerableBox.Text = fCreature.Vulnerable;
			ImmuneBox.Text = fCreature.Immune;
		}

		public DamageModListForm(CreatureTemplate template)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fTemplate = template;

			fModifierTemplates = new List<DamageModifierTemplate>();
			foreach (DamageModifierTemplate mod in fTemplate.DamageModifierTemplates)
				fModifierTemplates.Add(mod.Copy());

			update_damage_list();

			ResistBox.Text = fTemplate.Resist;
			VulnerableBox.Text = fTemplate.Vulnerable;
			ImmuneBox.Text = fTemplate.Immune;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveDmgBtn.Enabled = ((SelectedDamageMod != null) || (SelectedDamageModTemplate != null));
			EditDmgBtn.Enabled = ((SelectedDamageMod != null) || (SelectedDamageModTemplate != null));
		}

		ICreature fCreature = null;
		CreatureTemplate fTemplate = null;

		public List<DamageModifier> Modifiers
		{
			get { return fModifiers; }
		}
		List<DamageModifier> fModifiers = null;

		public List<DamageModifierTemplate> ModifierTemplates
		{
			get { return fModifierTemplates; }
		}
		List<DamageModifierTemplate> fModifierTemplates = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			if (fCreature != null)
			{
				fCreature.DamageModifiers = fModifiers;
				fCreature.Resist = ResistBox.Text;
				fCreature.Vulnerable = VulnerableBox.Text;
				fCreature.Immune = ImmuneBox.Text;
			}

			if (fTemplate != null)
			{
				fTemplate.DamageModifierTemplates = fModifierTemplates;
				fTemplate.Resist = ResistBox.Text;
				fTemplate.Vulnerable = VulnerableBox.Text;
				fTemplate.Immune = ImmuneBox.Text;
			}
		}

		public DamageModifier SelectedDamageMod
		{
			get
			{
				if (DamageList.SelectedItems.Count != 0)
					return DamageList.SelectedItems[0].Tag as DamageModifier;

				return null;
			}
		}

		public DamageModifierTemplate SelectedDamageModTemplate
		{
			get
			{
				if (DamageList.SelectedItems.Count != 0)
					return DamageList.SelectedItems[0].Tag as DamageModifierTemplate;

				return null;
			}
		}

		private void AddDmgBtn_Click(object sender, EventArgs e)
		{
			if (fCreature != null)
			{
				DamageModifier dm = new DamageModifier();

				DamageModifierForm dlg = new DamageModifierForm(dm);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fModifiers.Add(dlg.Modifier);
					update_damage_list();
				}
			}

			if (fTemplate != null)
			{
				DamageModifierTemplate dm = new DamageModifierTemplate();

				DamageModifierTemplateForm dlg = new DamageModifierTemplateForm(dm);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fModifierTemplates.Add(dlg.Modifier);
					update_damage_list();
				}
			}
		}

		private void RemoveDmgBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDamageMod != null)
			{
				fModifiers.Remove(SelectedDamageMod);
				update_damage_list();
			}

			if (SelectedDamageModTemplate != null)
			{
				fModifierTemplates.Remove(SelectedDamageModTemplate);
				update_damage_list();
			}
		}

		private void EditDmgBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDamageMod != null)
			{
				int index = fModifiers.IndexOf(SelectedDamageMod);

				DamageModifierForm dlg = new DamageModifierForm(SelectedDamageMod);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fModifiers[index] = dlg.Modifier;
					update_damage_list();
				}
			}

			if (SelectedDamageModTemplate != null)
			{
				int index = fModifierTemplates.IndexOf(SelectedDamageModTemplate);

				DamageModifierTemplateForm dlg = new DamageModifierTemplateForm(SelectedDamageModTemplate);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fModifierTemplates[index] = dlg.Modifier;
					update_damage_list();
				}
			}
		}

		void update_damage_list()
		{
			DamageList.Items.Clear();
			DamageList.ShowGroups = true;

			if (fModifiers != null)
			{
				foreach (DamageModifier dm in fModifiers)
				{
					ListViewItem lvi = DamageList.Items.Add(dm.ToString());
					lvi.Tag = dm;

					if (dm.Value == 0)
						lvi.Group = DamageList.Groups[0];
					if (dm.Value < 0)
						lvi.Group = DamageList.Groups[1];
					if (dm.Value > 0)
						lvi.Group = DamageList.Groups[2];
				}
			}

			if (fModifierTemplates != null)
			{
				foreach (DamageModifierTemplate dm in fModifierTemplates)
				{
					ListViewItem lvi = DamageList.Items.Add(dm.ToString());
					lvi.Tag = dm;

					int value = dm.HeroicValue + dm.ParagonValue + dm.EpicValue;

					if (value == 0)
						lvi.Group = DamageList.Groups[0];
					if (value < 0)
						lvi.Group = DamageList.Groups[1];
					if (value > 0)
						lvi.Group = DamageList.Groups[2];
				}
			}

			if (DamageList.Items.Count == 0)
			{
				DamageList.ShowGroups = false;

				ListViewItem lvi = DamageList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}
	}
}
