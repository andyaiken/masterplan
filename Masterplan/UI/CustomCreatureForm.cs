using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CustomCreatureForm : Form
	{
		public CustomCreatureForm(CustomCreature cc, bool unused)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fCreature = cc.Copy();

			fUpdating = true;

			NameBox.Text = fCreature.Name;
			LevelBox.Value = fCreature.Level;
			RoleBtn.Text = fCreature.Role.ToString();
			InfoBtn.Text = fCreature.Phenotype;

			StrBox.Value = fCreature.Strength.Score;
			ConBox.Value = fCreature.Constitution.Score;
			DexBox.Value = fCreature.Dexterity.Score;
			IntBox.Value = fCreature.Intelligence.Score;
			WisBox.Value = fCreature.Wisdom.Score;
			ChaBox.Value = fCreature.Charisma.Score;

			InitModBox.Value = fCreature.InitiativeModifier;
			HPModBox.Value = fCreature.HPModifier;
			ACModBox.Value = fCreature.ACModifier;
			FortModBox.Value = fCreature.FortitudeModifier;
			RefModBox.Value = fCreature.ReflexModifier;
			WillModBox.Value = fCreature.WillModifier;

			fUpdating = false;

			update_fields();
			update_powers_list();
			update_aura_list();
			update_damage_list();
			update_details();

			if (fCreature.Image != null)
				PortraitBox.Image = fCreature.Image;
		}

		~CustomCreatureForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			PowerRemoveBtn.Enabled = (SelectedPower != null);
			PowerEditBtn.Enabled = (SelectedPower != null);

			PowerUpBtn.Enabled = ((SelectedPower != null) && (fCreature.CreaturePowers.IndexOf(SelectedPower) != 0));
			PowerDownBtn.Enabled = ((SelectedPower != null) && (fCreature.CreaturePowers.IndexOf(SelectedPower) != fCreature.CreaturePowers.Count - 1));

			AuraRemoveBtn.Enabled = (SelectedAura != null);
			AuraEditBtn.Enabled = (SelectedAura != null);

			RemoveDmgBtn.Enabled = (SelectedDamageMod != null);
			EditDmgBtn.Enabled = (SelectedDamageMod != null);

			ClearRegenLbl.Visible = (fCreature.Regeneration != null);

			DetailsEditBtn.Enabled = (SelectedField != DetailsField.None);
		}

		#region Properties

		public CustomCreature Creature
		{
			get { return fCreature; }
		}
		CustomCreature fCreature = null;

		bool fUpdating = false;

		#endregion

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fCreature.Name = NameBox.Text;
		}

		private void ParameterChanged(object sender, EventArgs e)
		{
			update_fields();
		}

		private void RoleBtn_Click(object sender, EventArgs e)
		{
			RoleForm dlg = new RoleForm(fCreature.Role, ThreatType.Creature);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCreature.Role = dlg.Role;
				RoleBtn.Text = fCreature.Role.ToString();

				update_fields();
			}
		}

		void update_fields()
		{
			if (fUpdating)
				return;

			fCreature.Level = (int)LevelBox.Value;

			fCreature.Strength.Score = (int)StrBox.Value;
			fCreature.Constitution.Score = (int)ConBox.Value;
			fCreature.Dexterity.Score = (int)DexBox.Value;
			fCreature.Intelligence.Score = (int)IntBox.Value;
			fCreature.Wisdom.Score = (int)WisBox.Value;
			fCreature.Charisma.Score = (int)ChaBox.Value;

			fCreature.InitiativeModifier = (int)InitModBox.Value;
			fCreature.HPModifier = (int)HPModBox.Value;
			fCreature.ACModifier = (int)ACModBox.Value;
			fCreature.FortitudeModifier = (int)FortModBox.Value;
			fCreature.ReflexModifier = (int)RefModBox.Value;
			fCreature.WillModifier = (int)WillModBox.Value;

			int level = fCreature.Level / 2;

			int strength = fCreature.Strength.Modifier;
			StrModBox.Text = strength + " / " + (strength + level);

			int constitution = fCreature.Constitution.Modifier;
			ConModBox.Text = constitution + " / " + (constitution + level);

			int dexterity = fCreature.Dexterity.Modifier;
			DexModBox.Text = dexterity + " / " + (dexterity + level);

			int intelligence = fCreature.Intelligence.Modifier;
			IntModBox.Text = intelligence + " / " + (intelligence + level);

			int wisdom = fCreature.Wisdom.Modifier;
			WisModBox.Text = wisdom + " / " + (wisdom + level);

			int charisma = fCreature.Charisma.Modifier;
			ChaModBox.Text = charisma + " / " + (charisma + level);

			InitBox.Text = fCreature.Initiative.ToString();
			HPBox.Text = fCreature.HP.ToString();
			ACBox.Text = fCreature.AC.ToString();
			FortBox.Text = fCreature.Fortitude.ToString();
			RefBox.Text = fCreature.Reflex.ToString();
			WillBox.Text = fCreature.Will.ToString();
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

			PowerBuilderForm dlg = new PowerBuilderForm(p, fCreature, false);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCreature.CreaturePowers.Add(dlg.Power);
				update_powers_list();
			}
		}

		private void PowerRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPower != null)
			{
				fCreature.CreaturePowers.Remove(SelectedPower);
				update_powers_list();
			}
		}

		private void PowerEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedPower != null)
			{
				int index = fCreature.CreaturePowers.IndexOf(SelectedPower);

				PowerBuilderForm dlg = new PowerBuilderForm(SelectedPower, fCreature, false);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCreature.CreaturePowers[index] = dlg.Power;
					update_powers_list();
				}
			}
		}

		void update_powers_list()
		{
			PowerList.Items.Clear();
			foreach (CreaturePower p in fCreature.CreaturePowers)
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
				fCreature.Auras.Add(dlg.Aura);
				update_aura_list();
			}
		}

		private void AuraRemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedAura != null)
			{
				fCreature.Auras.Remove(SelectedAura);
				update_aura_list();
			}
		}

		private void AuraEditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedAura != null)
			{
				int index = fCreature.Auras.IndexOf(SelectedAura);

				AuraForm dlg = new AuraForm(SelectedAura);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCreature.Auras[index] = dlg.Aura;
					update_aura_list();
				}
			}
		}

		void update_aura_list()
		{
			AuraList.Items.Clear();
			foreach (Aura a in fCreature.Auras)
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
				fCreature.DamageModifiers.Add(dlg.Modifier);
				update_damage_list();
			}
		}

		private void RemoveDmgBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDamageMod != null)
			{
				fCreature.DamageModifiers.Remove(SelectedDamageMod);
				update_damage_list();
			}
		}

		private void EditDmgBtn_Click(object sender, EventArgs e)
		{
			if (SelectedDamageMod != null)
			{
				int index = fCreature.DamageModifiers.IndexOf(SelectedDamageMod);

				DamageModifierForm dlg = new DamageModifierForm(SelectedDamageMod);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fCreature.DamageModifiers[index] = dlg.Modifier;
					update_damage_list();
				}
			}
		}

		void update_damage_list()
		{
			DamageList.Items.Clear();
			DamageList.ShowGroups = true;

			foreach (DamageModifier dm in fCreature.DamageModifiers)
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

			if (fCreature.DamageModifiers.Count == 0)
			{
				DamageList.ShowGroups = false;

				ListViewItem lvi = DamageList.Items.Add("(none)");
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
				DetailsForm dlg = new DetailsForm(fCreature, SelectedField, null);
				if (dlg.ShowDialog() == DialogResult.OK)
					update_details();
			}
		}

		void update_details()
		{
			DetailsList.Items.Clear();

			ListViewItem senses = DetailsList.Items.Add("Senses");
			senses.SubItems.Add(fCreature.Senses);
			senses.Tag = DetailsField.Senses;

			ListViewItem move = DetailsList.Items.Add("Movement");
			move.SubItems.Add(fCreature.Movement);
			move.Tag = DetailsField.Movement;

			ListViewItem resist = DetailsList.Items.Add("Resist");
			resist.SubItems.Add(fCreature.Resist);
			resist.Tag = DetailsField.Resist;

			ListViewItem vuln = DetailsList.Items.Add("Vulnerable");
			vuln.SubItems.Add(fCreature.Vulnerable);
			vuln.Tag = DetailsField.Vulnerable;

			ListViewItem immune = DetailsList.Items.Add("Immune");
			immune.SubItems.Add(fCreature.Immune);
			immune.Tag = DetailsField.Immune;

			ListViewItem align = DetailsList.Items.Add("Alignment");
			align.SubItems.Add(fCreature.Alignment);
			align.Tag = DetailsField.Alignment;

			ListViewItem lang = DetailsList.Items.Add("Languages");
			lang.SubItems.Add(fCreature.Languages);
			lang.Tag = DetailsField.Languages;

			ListViewItem skills = DetailsList.Items.Add("Skills");
			skills.SubItems.Add(fCreature.Skills);
			skills.Tag = DetailsField.Skills;

			ListViewItem equip = DetailsList.Items.Add("Equipment");
			equip.SubItems.Add(fCreature.Equipment);
			equip.Tag = DetailsField.Equipment;

			ListViewItem desc = DetailsList.Items.Add("Description");
			desc.SubItems.Add(fCreature.Details);
			desc.Tag = DetailsField.Description;

			ListViewItem tactics = DetailsList.Items.Add("Tactics");
			tactics.SubItems.Add(fCreature.Tactics);
			tactics.Tag = DetailsField.Tactics;
		}

		#endregion

		private void SelectPowerBtn_Click(object sender, EventArgs e)
		{
			PowerBrowserForm dlg = new PowerBrowserForm(NameBox.Text, (int)LevelBox.Value, fCreature.Role, add_power);
			dlg.ShowDialog();
		}

		void add_power(CreaturePower power)
		{
			fCreature.CreaturePowers.Add(power);
			update_powers_list();
		}

		private void PortraitBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = Program.ImageFilter;
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCreature.Image = Image.FromFile(dlg.FileName);
				image_changed();
			}
		}

		private void PortraitClear_Click(object sender, EventArgs e)
		{
			fCreature.Image = null;
			image_changed();
		}

		void image_changed()
		{
			PortraitBox.Image = fCreature.Image;
		}

		private void InfoBtn_Click(object sender, EventArgs e)
		{
			CreatureClassForm dlg = new CreatureClassForm(fCreature);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fCreature.Size = dlg.CreatureSize;
				fCreature.Origin = dlg.Origin;
				fCreature.Type = dlg.Type;
				fCreature.Keywords = dlg.Keywords;

				InfoBtn.Text = fCreature.Phenotype;
			}
		}

		private void PowerUpBtn_Click(object sender, EventArgs e)
		{
			int index = fCreature.CreaturePowers.IndexOf(SelectedPower);
			CreaturePower tmp = fCreature.CreaturePowers[index - 1];

			fCreature.CreaturePowers[index - 1] = SelectedPower;
			fCreature.CreaturePowers[index] = tmp;

			update_powers_list();
			PowerList.Items[index - 1].Selected = true;
		}

		private void PowerDownBtn_Click(object sender, EventArgs e)
		{
			int index = fCreature.CreaturePowers.IndexOf(SelectedPower);
			CreaturePower tmp = fCreature.CreaturePowers[index + 1];

			fCreature.CreaturePowers[index + 1] = SelectedPower;
			fCreature.CreaturePowers[index] = tmp;

			update_powers_list();
			PowerList.Items[index + 1].Selected = true;
		}

		private void RegenBtn_Click(object sender, EventArgs e)
		{
			Regeneration regen = fCreature.Regeneration;
			if (regen == null)
				regen = new Regeneration();

			RegenerationForm dlg = new RegenerationForm(regen);
			if (dlg.ShowDialog() == DialogResult.OK)
				fCreature.Regeneration = dlg.Regeneration;
		}

		private void ClearRegenLbl_Click(object sender, EventArgs e)
		{
			fCreature.Regeneration = null;
		}
	}
}
