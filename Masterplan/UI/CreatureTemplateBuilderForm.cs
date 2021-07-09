using System;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class CreatureTemplateBuilderForm : Form
	{
		public CreatureTemplateBuilderForm(CreatureTemplate template)
		{
			InitializeComponent();

			fTemplate = template.Copy();

			update_statblock();
		}

		public CreatureTemplate Template
		{
			get { return fTemplate; }
		}
		CreatureTemplate fTemplate = null;

		private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "build")
			{
				if (e.Url.LocalPath == "profile")
				{
					e.Cancel = true;

					CreatureTemplateProfileForm dlg = new CreatureTemplateProfileForm(fTemplate);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.Name = dlg.Template.Name;
						fTemplate.Type = dlg.Template.Type;
						fTemplate.Role = dlg.Template.Role;
						fTemplate.Leader = dlg.Template.Leader;

						update_statblock();
					}
				}

				if (e.Url.LocalPath == "combat")
				{
					e.Cancel = true;

					CreatureTemplateStatsForm dlg = new CreatureTemplateStatsForm(fTemplate);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.HP = dlg.Template.HP;
						fTemplate.Initiative = dlg.Template.Initiative;
						fTemplate.AC = dlg.Template.AC;
						fTemplate.Fortitude = dlg.Template.Fortitude;
						fTemplate.Reflex = dlg.Template.Reflex;
						fTemplate.Will = dlg.Template.Will;

						update_statblock();
					}
				}

				if (e.Url.LocalPath == "damage")
				{
					e.Cancel = true;

					DamageModListForm dlg = new DamageModListForm(fTemplate);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "senses")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fTemplate.Senses, "Senses", "");
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.Senses = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "movement")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fTemplate.Movement, "Movement", "");
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.Movement = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "tactics")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fTemplate.Tactics, "Tactics", "");
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.Tactics = dlg.Details;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "power")
			{
				if (e.Url.LocalPath == "addpower")
				{
					e.Cancel = true;

					CreaturePower pwr = new CreaturePower();
					pwr.Name = "New Power";
					pwr.Action = new PowerAction();

					bool functional = fTemplate.Type == CreatureTemplateType.Functional;
					PowerBuilderForm dlg = new PowerBuilderForm(pwr, null, functional);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.CreaturePowers.Add(dlg.Power);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "addtrait")
				{
					e.Cancel = true;

					CreaturePower pwr = new CreaturePower();
					pwr.Name = "New Trait";
					pwr.Action = null;

					bool functional = fTemplate.Type == CreatureTemplateType.Functional;
					PowerBuilderForm dlg = new PowerBuilderForm(pwr, null, functional);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.CreaturePowers.Add(dlg.Power);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "addaura")
				{
					e.Cancel = true;

					Aura aura = new Aura();
					aura.Name = "New Aura";
					aura.Details = "1";

					AuraForm dlg = new AuraForm(aura);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.Auras.Add(dlg.Aura);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "regenedit")
				{
					e.Cancel = true;

					Regeneration regen = fTemplate.Regeneration;
					if (regen == null)
						regen = new Regeneration(5, "");

					RegenerationForm dlg = new RegenerationForm(regen);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.Regeneration = dlg.Regeneration;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "regenremove")
				{
					e.Cancel = true;

					fTemplate.Regeneration = null;
					update_statblock();
				}
			}

			if (e.Url.Scheme == "powerup")
			{
				//CreaturePower pwr = find_power(new Guid(e.Url.LocalPath));
				//if (pwr != null)
				//{
				//    e.Cancel = true;
				//    List<CreaturePower> powers = CreatureHelper.CreaturePowersByCategory(fCreature, pwr.Category);
				//    int index = powers.IndexOf(pwr);

				//    if (index != 0)
				//    {
				//        // Move power up
				//        CreaturePower other = powers[index - 1];
				//        int n = fCreature.CreaturePowers.IndexOf(other);
				//        fCreature.CreaturePowers.Remove(pwr);
				//        fCreature.CreaturePowers.Insert(n, pwr);

				//        update_statblock();
				//    }
				//}
			}

			if (e.Url.Scheme == "powerdown")
			{
				//CreaturePower pwr = find_power(new Guid(e.Url.LocalPath));
				//if (pwr != null)
				//{
				//    e.Cancel = true;
				//    List<CreaturePower> powers = CreatureHelper.CreaturePowersByCategory(fCreature, pwr.Category);
				//    int index = powers.IndexOf(pwr);

				//    if (index != powers.Count - 1)
				//    {
				//        // Move power down
				//        CreaturePower other = powers[index + 1];
				//        int n = fCreature.CreaturePowers.IndexOf(other);
				//        fCreature.CreaturePowers.Remove(pwr);
				//        fCreature.CreaturePowers.Insert(n, pwr);
				//        update_statblock();
				//    }
				//}
			}

			if (e.Url.Scheme == "poweredit")
			{
				CreaturePower pwr = find_power(new Guid(e.Url.LocalPath));
				if (pwr != null)
				{
					e.Cancel = true;
					int index = fTemplate.CreaturePowers.IndexOf(pwr);

					bool functional = fTemplate.Type == CreatureTemplateType.Functional;
					PowerBuilderForm dlg = new PowerBuilderForm(pwr, null, functional);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.CreaturePowers[index] = dlg.Power;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "powerremove")
			{
				CreaturePower pwr = find_power(new Guid(e.Url.LocalPath));
				if (pwr != null)
				{
					e.Cancel = true;

					fTemplate.CreaturePowers.Remove(pwr);
					update_statblock();
				}
			}

			if (e.Url.Scheme == "auraedit")
			{
				Aura aura = find_aura(new Guid(e.Url.LocalPath));
				if (aura != null)
				{
					e.Cancel = true;
					int index = fTemplate.Auras.IndexOf(aura);

					AuraForm dlg = new AuraForm(aura);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTemplate.Auras[index] = dlg.Aura;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "auraremove")
			{
				Aura aura = find_aura(new Guid(e.Url.LocalPath));
				if (aura != null)
				{
					e.Cancel = true;

					fTemplate.Auras.Remove(aura);
					update_statblock();
				}
			}
		}

		CreaturePower find_power(Guid id)
		{
			foreach (CreaturePower pwr in fTemplate.CreaturePowers)
			{
				if (pwr.ID == id)
					return pwr;
			}

			return null;
		}

		Aura find_aura(Guid id)
		{
			foreach (Aura aura in fTemplate.Auras)
			{
				if (aura.ID == id)
					return aura;
			}

			return null;
		}

		void add_power(CreaturePower power)
		{
			fTemplate.CreaturePowers.Add(power);
			update_statblock();
		}

		#region Menu

		private void OptionsVariant_Click(object sender, EventArgs e)
		{
			/*
			VariantWizard wizard = new VariantWizard();
			if (wizard.Show() == DialogResult.OK)
			{
				VariantData data = wizard.Data as VariantData;

				EncounterCard card = new EncounterCard();
				card.CreatureID = data.BaseCreature.ID;
				foreach (CreatureTemplate ct in data.Templates)
					card.TemplateIDs.Add(ct.ID);

				Creature custom = new Creature();

				custom.Name = "Variant " + card.Title;
				custom.Details = data.BaseCreature.Details;
				custom.Size = data.BaseCreature.Size;
				custom.Level = card.Level;
				if (data.BaseCreature.Image != null)
					custom.Image = new Bitmap(data.BaseCreature.Image);

				custom.Senses = card.Senses;
				custom.Movement = card.Movement;
				custom.Resist = card.Resist;
				custom.Vulnerable = card.Vulnerable;
				custom.Immune = card.Immune;

				if (data.BaseCreature.Role is Minion)
				{
					custom.Role = new Minion();
				}
				else
				{
					ComplexRole cr = new ComplexRole();

					cr.Type = data.Roles[data.SelectedRoleIndex];
					cr.Flag = card.Flag;
					cr.Leader = card.Leader;

					custom.Role = cr;
				}

				// Set ability scores
				custom.Strength.Score = data.BaseCreature.Strength.Score;
				custom.Constitution.Score = data.BaseCreature.Constitution.Score;
				custom.Dexterity.Score = data.BaseCreature.Dexterity.Score;
				custom.Intelligence.Score = data.BaseCreature.Intelligence.Score;
				custom.Wisdom.Score = data.BaseCreature.Wisdom.Score;
				custom.Charisma.Score = data.BaseCreature.Charisma.Score;

				// Combat stats
				custom.Initiative = data.BaseCreature.Initiative;
				custom.HP = card.HP;
				custom.AC = card.AC;
				custom.Fortitude = card.Fortitude;
				custom.Reflex = card.Reflex;
				custom.Will = card.Will;

				// Regeneration
				custom.Regeneration = (card.Regeneration != null) ? card.Regeneration : null;

				// Auras
				List<Aura> auras = card.Auras;
				foreach (Aura aura in auras)
					custom.Auras.Add(aura.Copy());

				// Add powers
				List<CreaturePower> powers = card.CreaturePowers;
				foreach (CreaturePower power in powers)
					custom.CreaturePowers.Add(power.Copy());

				// Add damage modifiers
				List<DamageModifier> mods = card.DamageModifiers;
				foreach (DamageModifier mod in mods)
					custom.DamageModifiers.Add(mod.Copy());

				CreatureHelper.CopyFields(custom, fCreature);
				//fCreature = custom;
				update_view();
			}
			*/
		}

		#endregion

		#region Updating

		void update_statblock()
		{
			StatBlockBrowser.DocumentText = HTML.CreatureTemplate(fTemplate, DisplaySize.Small, true);
		}

		#endregion

		private void FileExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Export Creature Template";
			dlg.FileName = fTemplate.Name;
			dlg.Filter = Program.CreatureTemplateFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				bool ok = Serialisation<CreatureTemplate>.Save(dlg.FileName, fTemplate, SerialisationMode.Binary);

				if (!ok)
				{
					string error = "The creature template could not be exported.";
					MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
