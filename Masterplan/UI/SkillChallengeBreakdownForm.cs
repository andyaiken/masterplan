using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class SkillChallengeBreakdownForm : Form
	{
		public SkillChallengeBreakdownForm(SkillChallenge sc)
		{
			InitializeComponent();

			AbilitiesPanel.Analyse(sc);
		}
	}
}
