using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class NPCForm : Form
	{
		public NPCForm(NPC cc, bool unused)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			List<Guid> template_ids = new List<Guid>();
			foreach (CreatureTemplate template in Session.Templates)
			{
				if (template.Type == CreatureTemplateType.Class)
					template_ids.Add(template.ID);
			}

			foreach (CreatureTemplate template in Session.Project.Library.Templates)
			{
				if (template.Type == CreatureTemplateType.Class)
				{
					if (template_ids.Contains(template.ID))
						continue;

					template_ids.Add(template.ID);
				}
			}

			foreach (Guid template_id in template_ids)
			{
				CreatureTemplate template = Session.FindTemplate(template_id, SearchType.Global);
				TemplateBox.Items.Add(template);
			}

			fNPC = cc.Copy();

			fUpdating = true;

			NameBox.Text = fNPC.Name;
			LevelBox.Value = fNPC.Level;
			InfoBtn.Text = fNPC.Phenotype;

			CreatureTemplate ct = Session.FindTemplate(fNPC.TemplateID, SearchType.Global);
			if (ct != null)
				TemplateBox.SelectedItem = ct;
			else
				TemplateBox.SelectedIndex = 0;

			StrBox.Value = fNPC.Strength.Score;
			ConBox.Value = fNPC.Constitution.Score;
			DexBox.Value = fNPC.Dexterity.Score;
			IntBox.Value = fNPC.Intelligence.Score;
			WisBox.Value = fNPC.Wisdom.Score;
			ChaBox.Value = fNPC.Charisma.Score;

			InitModBox.Value = fNPC.InitiativeModifier;
			HPModBox.Value = fNPC.HPModifier;
			ACModBox.Value = fNPC.ACModifier;
			FortModBox.Value = fNPC.FortitudeModifier;
			RefModBox.Value = fNPC.ReflexModifier;
			WillModBox.Value = fNPC.WillModifier;

			fUpdating = false;

			update_fields();
			update_powers_list();
			update_aura_list();
			update_damage_list();
			update_details();

			if (fNPC.Image != null)
				PortraitBox.Image = fNPC.Image;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			PowerRemoveBtn.Enabled = (SelectedPower != null);
			PowerEditBtn.Enabled = (SelectedPower != null);

			PowerUpBtn.Enabled = ((SelectedPower != null) && (fNPC.CreaturePowers.IndexOf(SelectedPower) != 0));
			PowerDownBtn.Enabled = ((SelectedPower != null) && (fNPC.CreaturePowers.IndexOf(SelectedPower) != fNPC.CreaturePowers.Count - 1));

			AuraRemoveBtn.Enabled = (SelectedAura != null);
			AuraEditBtn.Enabled = (SelectedAura != null);

			RemoveDmgBtn.Enabled = (SelectedDamageMod != null);
			EditDmgBtn.Enabled = (SelectedDamageMod != null);

			ClearRegenLbl.Visible = (fNPC.Regeneration != null);

			DetailsEditBtn.Enabled = (SelectedField != DetailsField.None);
		}

		#region Properties

		public NPC NPC
		{
			get { return fNPC; }
		}
		NPC fNPC = null;

		bool fUpdating = false;

		#endregion

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fNPC.Name = NameBox.Text;
		}

		private void TemplateBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreatureTemplate ct = TemplateBox.SelectedItem as CreatureTemplate;
			fNPC.TemplateID = (ct != null) ? ct.ID : Guid.Empty;

			update_fields();
		}

		private void ParameterChanged(object sender, EventArgs e)
		{
			update_fields();
		}

		void update_fields()
		{
			if (fUpdating)
				return;

			fNPC.Level = (int)LevelBox.Value;

			fNPC.Strength.Score = (int)StrBox.Value;
			fNPC.Constitution.Score = (int)ConBox.Value;
			fNPC.Dexterity.Score = (int)DexBox.Value;
			fNPC.Intelligence.Score = (int)IntBox.Value;
			fNPC.Wisdom.Score = (int)WisBox.Value;
			fNPC.Charisma.Score = (int)ChaBox.Value;

			// Count point-buy cost
			int cost = fNPC.AbilityCost;
			CostBox.Text = (cost != -1) ? cost.ToString() : "(n/a)";

			fNPC.InitiativeModifier = (int)InitModBox.Value;
			fNPC.HPModifier = (int)HPModBox.Value;
			fNPC.ACModifier = (int)ACModBox.Value;
			fNPC.FortitudeModifier = (int)FortModBox.Value;
			fNPC.ReflexModifier = (int)RefModBox.Value;
			fNPC.WillModifier = (int)WillModBox.Value;

			int level = fNPC.Level / 2;

			int strength = fNPC.Strength.Modifier;
			StrModBox.Text = strength + " / " + (strength + level);

			int constitution = fNPC.Constitution.Modifier;
			ConModBox.Text = constitution + " / " + (constitution + level);

			int dexterity = fNPC.Dexterity.Modifier;
			DexModBox.Text = dexterity + " / " + (dexterity + level);

			int intelligence = fNPC.Intelligence.Modifier;
			IntModBox.Text = intelligence + " / " + (intelligence + level);

			int wisdom = fNPC.Wisdom.Modifier;
			WisModBox.Text = wisdom + " / " + (wisdom + level);

			int charisma = fNPC.Charisma.Modifier;
			ChaModBox.Text = charisma + " / " + (charisma + level);

			InitBox.Text = fNPC.Initiative.ToString();
			HPBox.Text = fNPC.HP.ToString();
			ACBox.Text = fNPC.AC.ToString();
			FortBox.Text = fNPC.Fortitude.ToString();
			RefBox.Text = fNPC.Reflex.ToString();
			WillBox.Text = fNPC.Will.ToString();
		}

		#region Powers

		public CreaturePower SelectedPower
		{
			get
			{
				if (PowerList.SelectedItems.Count != 0)
					return PowerList.SelectedItems[0].Tag as CreaturePower;

				return null;
			}
		}

		private void PowerAddBtn_Click(object sender, EventArgs e)
		{
			CreaturePower p = new CreaturePower();
			p.Name = "New Power";

			//PowerForm dlg = new PowerForm(p, false);
			PowerBuilderForm dlg = new PowerBuilderForm(p, fNPC, false);
			//dlg.ShowAdvicePage((int)LevelBox.Value, fNPC.Role);

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fNPC.CreaturePowers.Add(dlg.Power);
				update_powers_list();
			}
		}

		private void PowerRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPower != null)
			{
				fNPC.CreaturePowers.Remove(SelectedPower);
				update_powers_list();
			}
		}

		private void PowerEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPower != null)
			{
				int index = fNPC.CreaturePowers.IndexOf(SelectedPower);

				//PowerForm dlg = new PowerForm(SelectedPower, false);
				PowerBuilderForm dlg = new PowerBuilderForm(SelectedPower, fNPC, false);
				//dlg.ShowAdvicePage((int)LevelBox.Value, fNPC.Role);

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fNPC.CreaturePowers[index] = dlg.Power;
					update_powers_list();
				}
			}
		}

		void update_powers_list()
		{
			PowerList.Items.Clear();
			foreach (CreaturePower p in fNPC.CreaturePowers)
			{
				ListViewItem lvi = PowerList.Items.Add(p.Name);
				lvi.Tag = p;
			}

			if (PowerList.Items.Count == 0)
			{
				ListViewItem lvi = PowerList.Items.Add("(no powers)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		#region Damage mods

		public DamageModifier SelectedDamageMod
		{
			get
			{
				if (DamageList.SelectedItems.Count != 0)
					return DamageList.SelectedItems[0].Tag as DamageModifier;

				return null;
			}
		}

		private void AddDmgBtn_Click(object sender, EventArgs e)
		{
			DamageModifier dm = new DamageModifier();

			DamageModifierForm dlg = new DamageModifierForm(dm);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fNPC.DamageModifiers.Add(dlg.Modifier);
				update_damage_list();
			}
		}

		private void RemoveDmgBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDamageMod != null)
			{
				fNPC.DamageModifiers.Remove(SelectedDamageMod);
				update_damage_list();
			}
		}

		private void EditDmgBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDamageMod != null)
			{
				int index = fNPC.DamageModifiers.IndexOf(SelectedDamageMod);

				DamageModifierForm dlg = new DamageModifierForm(SelectedDamageMod);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fNPC.DamageModifiers[index] = dlg.Modifier;
					update_damage_list();
				}
			}
		}

		void update_damage_list()
		{
			DamageList.Items.Clear();
			DamageList.ShowGroups = true;

			foreach (DamageModifier dm in fNPC.DamageModifiers)
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

			if (fNPC.DamageModifiers.Count == 0)
			{
				DamageList.ShowGroups = false;

				ListViewItem lvi = DamageList.Items.Add("(none)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		#region Auras

		public Aura SelectedAura
		{
			get
			{
				if (AuraList.SelectedItems.Count != 0)
					return AuraList.SelectedItems[0].Tag as Aura;

				return null;
			}
		}

		private void AuraAddBtn_Click(object sender, EventArgs e)
		{
			Aura a = new Aura();
			a.Name = "New Aura";

			AuraForm dlg = new AuraForm(a);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fNPC.Auras.Add(dlg.Aura);
				update_aura_list();
			}
		}

		private void AuraRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedAura != null)
			{
				fNPC.Auras.Remove(SelectedAura);
				update_aura_list();
			}
		}

		private void AuraEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedAura != null)
			{
				int index = fNPC.Auras.IndexOf(SelectedAura);

				AuraForm dlg = new AuraForm(SelectedAura);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fNPC.Auras[index] = dlg.Aura;
					update_aura_list();
				}
			}
		}

		void update_aura_list()
		{
			AuraList.Items.Clear();
			foreach (Aura a in fNPC.Auras)
			{
				ListViewItem lvi = AuraList.Items.Add(a.Name);
				lvi.Tag = a;
			}

			if (AuraList.Items.Count == 0)
			{
				ListViewItem lvi = AuraList.Items.Add("(no auras)");
				lvi.ForeColor = SystemColors.GrayText;
			}
		}

		#endregion

		#region Details

		public DetailsField SelectedField
		{
			get
			{
				if (DetailsList.SelectedItems.Count != 0)
					return (DetailsField)DetailsList.SelectedItems[0].Tag;

				return DetailsField.None;
			}
		}

		private void DetailsEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedField != DetailsField.None)
			{
				DetailsForm dlg = new DetailsForm(fNPC, SelectedField, null);
				if (dlg.ShowDialog() == DialogResult.OK)
					update_details();
			}
		}

		void update_details()
		{
			DetailsList.Items.Clear();

			ListViewItem senses = DetailsList.Items.Add("Senses");
			senses.SubItems.Add(fNPC.Senses);
			senses.Tag = DetailsField.Senses;

			ListViewItem move = DetailsList.Items.Add("Movement");
			move.SubItems.Add(fNPC.Movement);
			move.Tag = DetailsField.Movement;

			ListViewItem resist = DetailsList.Items.Add("Resist");
			resist.SubItems.Add(fNPC.Resist);
			resist.Tag = DetailsField.Resist;

			ListViewItem vuln = DetailsList.Items.Add("Vulnerable");
			vuln.SubItems.Add(fNPC.Vulnerable);
			vuln.Tag = DetailsField.Vulnerable;

			ListViewItem immune = DetailsList.Items.Add("Immune");
			immune.SubItems.Add(fNPC.Immune);
			immune.Tag = DetailsField.Immune;

			ListViewItem align = DetailsList.Items.Add("Alignment");
			align.SubItems.Add(fNPC.Alignment);
			align.Tag = DetailsField.Alignment;

			ListViewItem lang = DetailsList.Items.Add("Languages");
			lang.SubItems.Add(fNPC.Languages);
			lang.Tag = DetailsField.Languages;

			ListViewItem skills = DetailsList.Items.Add("Skills");
			skills.SubItems.Add(fNPC.Skills);
			skills.Tag = DetailsField.Skills;

			ListViewItem equip = DetailsList.Items.Add("Equipment");
			equip.SubItems.Add(fNPC.Equipment);
			equip.Tag = DetailsField.Equipment;

			ListViewItem desc = DetailsList.Items.Add("Description");
			desc.SubItems.Add(fNPC.Details);
			desc.Tag = DetailsField.Description;

			ListViewItem tactics = DetailsList.Items.Add("Tactics");
			tactics.SubItems.Add(fNPC.Tactics);
			tactics.Tag = DetailsField.Tactics;
		}

		#endregion

		private void SelectPowerBtn_Click(object sender, EventArgs e)
		{
			PowerBrowserForm dlg = new PowerBrowserForm(NameBox.Text, (int)LevelBox.Value, fNPC.Role, add_power);
			dlg.ShowDialog();
		}

		void add_power(CreaturePower power)
		{
			fNPC.CreaturePowers.Add(power);
			update_powers_list();
		}

		private void PortraitBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.ImageFilter;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fNPC.Image = Image.FromFile(dlg.FileName);
				image_changed();
			}
		}

		private void PortraitClear_Click(object sender, EventArgs e)
		{
			fNPC.Image = null;
			image_changed();
		}

		void image_changed()
		{
			PortraitBox.Image = fNPC.Image;
		}

		private void InfoBtn_Click(object sender, EventArgs e)
		{
			CreatureClassForm dlg = new CreatureClassForm(fNPC);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fNPC.Size = dlg.CreatureSize;
				fNPC.Origin = dlg.Origin;
				fNPC.Type = dlg.Type;
				fNPC.Keywords = dlg.Keywords;

				InfoBtn.Text = fNPC.Phenotype;
			}
		}

		private void PowerUpBtn_Click(object sender, EventArgs e)
		{
			int index = fNPC.CreaturePowers.IndexOf(SelectedPower);
			CreaturePower tmp = fNPC.CreaturePowers[index - 1];

			fNPC.CreaturePowers[index - 1] = SelectedPower;
			fNPC.CreaturePowers[index] = tmp;

			update_powers_list();
			PowerList.Items[index - 1].Selected = true;
		}

		private void PowerDownBtn_Click(object sender, EventArgs e)
		{
			int index = fNPC.CreaturePowers.IndexOf(SelectedPower);
			CreaturePower tmp = fNPC.CreaturePowers[index + 1];

			fNPC.CreaturePowers[index + 1] = SelectedPower;
			fNPC.CreaturePowers[index] = tmp;

			update_powers_list();
			PowerList.Items[index + 1].Selected = true;
		}

		private void RegenBtn_Click(object sender, EventArgs e)
		{
			Regeneration regen = fNPC.Regeneration;
			if (regen == null)
				regen = new Regeneration();

			RegenerationForm dlg = new RegenerationForm(regen);
			if (dlg.ShowDialog() == DialogResult.OK)
				fNPC.Regeneration = dlg.Regeneration;
		}

		private void ClearRegenLbl_Click(object sender, EventArgs e)
		{
			fNPC.Regeneration = null;
		}
	}
}
