using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class TrapBuilderForm : Form
	{
		public TrapBuilderForm(Trap trap)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fTrap = trap.Copy();

			update_statblock();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			LevelDownBtn.Enabled = (fTrap.Level > 1);
		}

		public Trap Trap
		{
			get { return fTrap; }
		}
		Trap fTrap = null;

		private void OptionsCopy_Click(object sender, EventArgs e)
		{
			TrapSelectForm dlg = new TrapSelectForm();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fTrap = dlg.Trap.Copy();
				update_statblock();
			}
		}

		private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			if (e.Url.Scheme == "build")
			{
				if (e.Url.LocalPath == "profile")
				{
					e.Cancel = true;

					TrapProfileForm dlg = new TrapProfileForm(fTrap);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.Name = dlg.Trap.Name;
						fTrap.Type = dlg.Trap.Type;
						fTrap.Level = dlg.Trap.Level;
						fTrap.Role = dlg.Trap.Role;
						fTrap.Initiative = dlg.Trap.Initiative;

						update_statblock();
					}
				}

				if (e.Url.LocalPath == "readaloud")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fTrap.ReadAloud, "Read-Aloud Text", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.ReadAloud = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "desc")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fTrap.Description, "Description", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.Description = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "details")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fTrap.Details, "Details", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.Details = dlg.Details;
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "addskill")
				{
					e.Cancel = true;

					TrapSkillData tsd = new TrapSkillData();
					tsd.SkillName = "Perception";
					tsd.DC = AI.GetSkillDC(Difficulty.Moderate, fTrap.Level);

					TrapSkillForm dlg = new TrapSkillForm(tsd, fTrap.Level);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.Skills.Add(dlg.SkillData);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "addattack")
				{
					e.Cancel = true;

					TrapAttack ta = new TrapAttack();
					ta.Name = "Attack";

					fTrap.Attacks.Add(ta);
					update_statblock();
				}

				if (e.Url.LocalPath == "addcm")
				{
					e.Cancel = true;

					string cm = "";
					TrapCountermeasureForm dlg = new TrapCountermeasureForm(cm, fTrap.Level);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.Countermeasures.Add(dlg.Countermeasure);
						update_statblock();
					}
				}

				if (e.Url.LocalPath == "trigger")
				{
					e.Cancel = true;

					DetailsForm dlg = new DetailsForm(fTrap.Trigger, "Trigger", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.Trigger = dlg.Details;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "attackaction")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapAttack attack = fTrap.FindAttack(id);
				if (attack != null)
				{
					TrapActionForm dlg = new TrapActionForm(attack);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						attack.Name = dlg.Attack.Name;
						attack.Action = dlg.Attack.Action;
						attack.Range = dlg.Attack.Range;
						attack.Target = dlg.Attack.Target;

						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "attackremove")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapAttack attack = fTrap.FindAttack(id);
				if (attack != null)
				{
					fTrap.Attacks.Remove(attack);
					update_statblock();
				}
			}

			if (e.Url.Scheme == "attackattack")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapAttack attack = fTrap.FindAttack(id);
				if (attack != null)
				{
					PowerAttackForm dlg = new PowerAttackForm(attack.Attack, false, fTrap.Level, fTrap.Role);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						attack.Attack = dlg.Attack;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "attackhit")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapAttack attack = fTrap.FindAttack(id);
				if (attack != null)
				{
					DetailsForm dlg = new DetailsForm(attack.OnHit, "On Hit", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						attack.OnHit = dlg.Details;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "attackmiss")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapAttack attack = fTrap.FindAttack(id);
				if (attack != null)
				{
					DetailsForm dlg = new DetailsForm(attack.OnMiss, "On Miss", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						attack.OnMiss = dlg.Details;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "attackeffect")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapAttack attack = fTrap.FindAttack(id);
				if (attack != null)
				{
					DetailsForm dlg = new DetailsForm(attack.Effect, "Effect", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						attack.Effect = dlg.Details;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "attacknotes")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapAttack attack = fTrap.FindAttack(id);
				if (attack != null)
				{
					DetailsForm dlg = new DetailsForm(attack.Notes, "Notes", null);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						attack.Notes = dlg.Details;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "skill")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapSkillData tsd = fTrap.FindSkill(id);
				if (tsd != null)
				{
					int index = fTrap.Skills.IndexOf(tsd);

					TrapSkillForm dlg = new TrapSkillForm(tsd, fTrap.Level);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						fTrap.Skills[index] = dlg.SkillData;
						update_statblock();
					}
				}
			}

			if (e.Url.Scheme == "skillremove")
			{
				e.Cancel = true;

				Guid id = new Guid(e.Url.LocalPath);
				TrapSkillData tsd = fTrap.FindSkill(id);
				if (tsd != null)
				{
					fTrap.Skills.Remove(tsd);
					update_statblock();
				}
			}

			if (e.Url.Scheme == "cm")
			{
				e.Cancel = true;

				int index = int.Parse(e.Url.LocalPath);
				string cm = fTrap.Countermeasures[index];

				TrapCountermeasureForm dlg = new TrapCountermeasureForm(cm, fTrap.Level);
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					fTrap.Countermeasures[index] = dlg.Countermeasure;
					update_statblock();
				}
			}
		}

		void update_statblock()
		{
			List<string> lines = HTML.GetHead("Trap", "", Session.Preferences.TextSize);
			lines.Add("<BODY>");

			lines.Add("<TABLE class=clear>");
			lines.Add("<TR class=clear>");
			lines.Add("<TD class=clear>");
			lines.Add("<P class=table>");
			lines.Add(HTML.Trap(fTrap, null, false, false, true, Session.Preferences.TextSize));
			lines.Add("</P>");
			lines.Add("</TD>");
			lines.Add("<TD class=clear>");
			lines.AddRange(get_advice());
			lines.Add("</TD>");
			lines.Add("</TR>");
			lines.Add("</TABLE>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			StatBlockBrowser.DocumentText = HTML.Concatenate(lines);
		}

		List<string> get_advice()
		{
			int init = 2;
			int attack_ac = fTrap.Level + 5;
			int attack_nad = fTrap.Level + 3;

			bool is_elite = false;
			if (fTrap.Role is ComplexRole)
			{
				ComplexRole cr = fTrap.Role as ComplexRole;
				if ((cr.Flag == RoleFlag.Elite) || (cr.Flag == RoleFlag.Solo))
					is_elite = true;
			}
			if (is_elite)
			{
				init += 2;
				attack_ac += 2;
				attack_nad += 2;
			}

			List<string> lines = new List<string>();

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2><B>Initiative Advice</B></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Initiative</TD>");
			lines.Add("<TD align=center>+" + init + "</TD>");
			lines.Add("</TR>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2><B>Attack Advice</B></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Attack vs Armour Class</TD>");
			lines.Add("<TD align=center>+" + attack_ac + "</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Attack vs Other Defence</TD>");
			lines.Add("<TD align=center>+" + attack_nad + "</TD>");
			lines.Add("</TR>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2><B>Damage Advice</B></TD>");
			lines.Add("</TR>");

			if (fTrap.Role is Minion)
			{
				lines.Add("<TR>");
				lines.Add("<TD>Minion Damage</TD>");
				lines.Add("<TD align=center>" + Statistics.Damage(fTrap.Level, DamageExpressionType.Minion) + "</TD>");
				lines.Add("</TR>");
			}
			else
			{
				lines.Add("<TR>");
				lines.Add("<TD>Damage vs Single Targets</TD>");
				lines.Add("<TD align=center>" + Statistics.Damage(fTrap.Level, DamageExpressionType.Normal) + "</TD>");
				lines.Add("</TR>");

				lines.Add("<TR>");
				lines.Add("<TD>Damage vs Multiple Targets</TD>");
				lines.Add("<TD align=center>" + Statistics.Damage(fTrap.Level, DamageExpressionType.Multiple) + "</TD>");
				lines.Add("</TR>");
			}

			lines.Add("<TR class=heading>");
			lines.Add("<TD colspan=2><B>Skill Advice</B></TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Easy DC</TD>");
			lines.Add("<TD align=center>" + AI.GetSkillDC(Difficulty.Easy, fTrap.Level) + "</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Moderate DC</TD>");
			lines.Add("<TD align=center>" + AI.GetSkillDC(Difficulty.Moderate, fTrap.Level) + "</TD>");
			lines.Add("</TR>");

			lines.Add("<TR>");
			lines.Add("<TD>Hard DC</TD>");
			lines.Add("<TD align=center>" + AI.GetSkillDC(Difficulty.Hard, fTrap.Level) + "</TD>");
			lines.Add("</TR>");

			lines.Add("</TABLE>");
			lines.Add("</P>");

			return lines;
		}

		private void LevelUpBtn_Click(object sender, EventArgs e)
		{
			fTrap.AdjustLevel(+1);
			update_statblock();
		}

		private void LevelDownBtn_Click(object sender, EventArgs e)
		{
			fTrap.AdjustLevel(-1);
			update_statblock();
		}

		private void FileExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Title = "Export Trap";
			dlg.FileName = fTrap.Name;
			dlg.Filter = Program.TrapFilter;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				bool ok = Serialisation<Trap>.Save(dlg.FileName, fTrap, SerialisationMode.Binary);

				if (!ok)
				{
					string error = "The trap could not be exported.";
					MessageBox.Show(error, "Masterplan", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
