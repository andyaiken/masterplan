using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class PowerBuilderForm : Form
	{
		public PowerBuilderForm(CreaturePower power, ICreature creature, bool functional_template)
		{
			InitializeComponent();

			fPower = power;
			fCreature = creature;
			fFromFunctionalTemplate = functional_template;

			refresh_examples();
			update_statblock();
		}

		public CreaturePower Power
		{
			get { return fPower; }
		}
		CreaturePower fPower = null;

		ICreature fCreature = null;
		bool fFromFunctionalTemplate = false;

		private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "power")
			{
				if (e.Url.LocalPath == "info")
				{
					e.Cancel = true;

					PowerInfoForm dlg = new PowerInfoForm(fPower);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fPower.Name = dlg.PowerName;
						fPower.Keywords = dlg.PowerKeywords;

						update_statblock();
					}
				}

				if (e.Url.LocalPath == Session.I18N.Action)
				{
					e.Cancel = true;

					PowerAction action = fPower.Action;
					PowerActionForm dlg = new PowerActionForm(action);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fPower.Action = dlg.Action;

						refresh_examples();
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "prerequisite")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fPower.Condition, "Power Prerequisite", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fPower.Condition = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "range")
				{
					e.Cancel = true;

					PowerRangeForm dlg = new PowerRangeForm(fPower);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fPower.Range = dlg.PowerRange;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "attack")
				{
					e.Cancel = true;

					PowerAttack attack = fPower.Attack;
					if (attack == null)
						attack = new PowerAttack();

					int level = (fCreature != null) ? fCreature.Level : 0;
					IRole role = (fCreature != null) ? fCreature.Role : null;
					PowerAttackForm dlg = new PowerAttackForm(attack, fFromFunctionalTemplate, level, role);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fPower.Attack = dlg.Attack;

						refresh_examples();
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "clearattack")
				{
					e.Cancel = true;

					fPower.Attack = null;

					refresh_examples();
					update_statblock();
				}

				if (e.Url.LocalPath == "details")
				{
					e.Cancel = true;

					PowerDetailsForm dlg = new PowerDetailsForm(fPower.Details, fCreature);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fPower.Details = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "desc")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fPower.Description, "Power Description", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fPower.Description = dlg.Details;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "details")
			{
				if (e.Url.LocalPath == "refresh")
				{
					e.Cancel = true;

					refresh_examples();
					update_statblock();
				}

				try
				{
					int index = int.Parse(e.Url.LocalPath);
					e.Cancel = true;

					fPower.Details = fExamples[index];
					fExamples.RemoveAt(index);

					if (fExamples.Count == 0)
						refresh_examples();

					update_statblock();
				}
				catch
				{
					// Not a number
				}
			}
		}

		List<string> fExamples = new List<string>();

		void refresh_examples()
		{
			fExamples.Clear();

			List<string> all_examples = new List<string>();

			if (fCreature != null)
			{
				List<ICreature> creatures = new List<ICreature>();
				foreach (Creature creature in Session.Creatures)
				{
					if (creature == null)
						continue;

					if ((creature.Level == fCreature.Level) && (creature.Role.ToString() == fCreature.Role.ToString()))
						creatures.Add(creature);
				}
				if (Session.Project != null)
				{
					foreach (CustomCreature creature in Session.Project.CustomCreatures)
					{
						if (creature == null)
							continue;

						if ((creature.Level == fCreature.Level) && (creature.Role.ToString() == fCreature.Role.ToString()))
							creatures.Add(creature);
					}
				}

				foreach (ICreature creature in creatures)
				{
					foreach (CreaturePower cp in creature.CreaturePowers)
					{
						if (fPower.Category != cp.Category)
							continue;

						if (cp.Details == "")
							continue;

						all_examples.Add(cp.Details);
					}
				}
			}

			if (all_examples.Count != 0)
			{
				for (int n = 0; n != 5; ++n)
				{
					if (all_examples.Count == 0)
						break;

					int index = Session.Random.Next(all_examples.Count);
					string example = all_examples[index];
					all_examples.RemoveAt(index);

					fExamples.Add(example);
				}
			}
		}

		void update_statblock()
		{
			int level = (fCreature != null) ? fCreature.Level : 0;
			IRole role = (fCreature != null) ? fCreature.Role : null;

			List<string> lines = HTML.GetHead(null, null, Session.Preferences.TextSize);
			lines.Add("<BODY>");

			lines.Add("<TABLE class=clear>");
			lines.Add("<TR class=clear>");
			lines.Add("<TD class=clear>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");
			lines.AddRange(fPower.AsHTML(null, CardMode.Build, fFromFunctionalTemplate));
			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</TD>");
			lines.Add("<TD class=clear>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2><B>Power Advice</B></TD>");
			lines.Add("</TR>");

			lines.Add("<TR class=shaded>");
			lines.Add("<TD colspan=2><B>Attack Bonus</B></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Attack vs Armour Class</TD>");
			lines.Add("<TD align=center>+" + Statistics.AttackBonus(DefenceType.AC, level, role) + "</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Attack vs Other Defence</TD>");
			lines.Add("<TD align=center>+" + Statistics.AttackBonus(DefenceType.Fortitude, level, role) + "</TD>");
			lines.Add("</TR>");

			if (role != null)
			{
				lines.Add("<TR class=shaded>");
				lines.Add("<TD colspan=2><B>Damage</B></TD>");
				lines.Add("</TR>");

				if (role is Minion)
				{
					lines.Add("<TR>");
					lines.Add("<TD>Minion Damage</TD>");
					lines.Add("<TD align=center>" + Statistics.Damage(level, DamageExpressionType.Minion) + "</TD>");
					lines.Add("</TR>");
				}
				else
				{
					lines.Add("<TR>");
					lines.Add("<TD>Damage vs Single Targets</TD>");
					lines.Add("<TD align=center>" + Statistics.Damage(level, DamageExpressionType.Normal) + "</TD>");
					lines.Add("</TR>");

					lines.Add("<TR>");
					lines.Add("<TD>Damage vs Multiple Targets</TD>");
					lines.Add("<TD align=center>" + Statistics.Damage(level, DamageExpressionType.Multiple) + "</TD>");
					lines.Add("</TR>");
				}

				if (fExamples.Count != 0)
				{
					lines.Add("<TR class=shaded>");
					lines.Add("<TD><B>Example Power Details</B></TD>");
					lines.Add("<TD align=center><A href=details:refresh>(refresh)</A></TD>");
					lines.Add("</TR>");

					foreach (string example in fExamples)
					{
						int index = fExamples.IndexOf(example);

						lines.Add("<TR>");
						lines.Add("<TD colspan=2>" + example + " <A href=details:" + index + ">(use this)</A></TD>");
						lines.Add("</TR>");
					}
				}
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</TD>");
			lines.Add("</TR>");
			lines.Add("</TABLE>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			StatBlockBrowser.DocumentText = HTML.Concatenate(lines);
		}

		private void PowerBrowserBtn_Click(object sender, EventArgs e)
		{
			int level = (fCreature != null) ? fCreature.Level : 0;
			IRole role = (fCreature != null) ? fCreature.Role : null;

			PowerBrowserForm dlg = new PowerBrowserForm(null, level, role, null);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				if (dlg.SelectedPower != null)
				{
					fPower = dlg.SelectedPower.Copy();
					fPower.ID = Guid.NewGuid();

					update_statblock();
				}
			}
		}
	}
}
