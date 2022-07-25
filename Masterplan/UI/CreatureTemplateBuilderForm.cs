using System;
using System.Windows.Forms;

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

				if (e.Url.LocalPath == Session.I18N.Damage)
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

					DetailsForm dlg = new DetailsForm(fTemplate.Tactics, Session.I18N.Tactics, "");
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
			}

			if (e.Url.Scheme == "powerdown")
			{
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
		}

		#endregion

		#region Updating

		void update_statblock()
		{
			StatBlockBrowser.DocumentText = HTML.CreatureTemplate(fTemplate, Session.Preferences.TextSize, true);
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
