#nullable disable

using Masterplan.Data;
using System.Windows.Forms;

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
