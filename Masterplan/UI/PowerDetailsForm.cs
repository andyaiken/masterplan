using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class PowerDetailsForm : Form
	{
		public PowerDetailsForm(string str, ICreature creature)
		{
			InitializeComponent();

			DetailsBox.Text = str;
			fCreature = creature;

			int level = (fCreature != null) ? fCreature.Level : 0;
			IRole role = (fCreature != null) ? fCreature.Role : null;

			string damage = "1d8 + 2";
			if (role != null)
			{
				if (role is Minion)
				{
					damage = Statistics.Damage(level, DamageExpressionType.Minion);
				}
				else
				{
					damage = Statistics.Damage(level, DamageExpressionType.Normal);
				}
			}

			List<string> examples = new List<string>();
			examples.Add(damage + " damage");
			examples.Add(damage + " damage, and the target is knocked prone");
			examples.Add("The target is slowed (save ends)");
			examples.Add("The target is immobilised until the start of your next turn");

			List<string> lines = HTML.GetHead(null, null, Session.Preferences.TextSize);
			lines.Add("<BODY>");

			lines.Add("<P class=table>");
			lines.Add("<TABLE>");

			lines.Add("<TR class=heading>");
			lines.Add("<TD><B>Examples</B></TD>");
			lines.Add("</TR>");

			foreach (string example in examples)
			{
				lines.Add("<TR>");
				lines.Add("<TD>" + example + "</TD>");
				lines.Add("</TR>");
			}

			lines.Add("</TABLE>");
			lines.Add("</P>");

			lines.Add("</BODY>");
			lines.Add("</HTML>");

			Browser.DocumentText = HTML.Concatenate(lines);
		}

		ICreature fCreature = null;

		public string Details
		{
			get { return DetailsBox.Text; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
