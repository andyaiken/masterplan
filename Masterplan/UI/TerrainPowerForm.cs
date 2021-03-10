using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
    partial class TerrainPowerForm : Form
    {
        public TerrainPowerForm(TerrainPower power)
        {
            InitializeComponent();

            Array types = Enum.GetValues(typeof(TerrainPowerType));
            foreach (TerrainPowerType type in types)
                TypeBox.Items.Add(type);

            Array actions = Enum.GetValues(typeof(ActionType));
            foreach (ActionType action in actions)
                ActionBox.Items.Add(action);

            fPower = power.Copy();

            NameBox.Text = fPower.Name;
            TypeBox.SelectedItem = fPower.Type;
            ActionBox.SelectedItem = fPower.Action;

            FlavourBox.Text = fPower.FlavourText;
            RequirementBox.Text = fPower.Requirement;

            CheckBox.Text = fPower.Check;
            SuccessBox.Text = fPower.Success;
            FailureBox.Text = fPower.Failure;

            AttackBox.Text = fPower.Attack;
            TargetBox.Text = fPower.Target;
            HitBox.Text = fPower.Hit;
            MissBox.Text = fPower.Miss;
            EffectBox.Text = fPower.Effect;
        }

        public TerrainPower Power
        {
            get { return fPower; }
        }
        TerrainPower fPower = null;

        private void OKBtn_Click(object sender, EventArgs e)
        {
            fPower.Name = NameBox.Text;
            fPower.Type = (TerrainPowerType)TypeBox.SelectedItem;
            fPower.Action = (ActionType)ActionBox.SelectedItem;

            fPower.FlavourText = FlavourBox.Text;
            fPower.Requirement = RequirementBox.Text;

            fPower.Check = CheckBox.Text;
            fPower.Success = SuccessBox.Text;
            fPower.Failure = FailureBox.Text;

            fPower.Attack = AttackBox.Text;
            fPower.Target = TargetBox.Text;
            fPower.Hit = HitBox.Text;
            fPower.Miss = MissBox.Text;
            fPower.Effect = EffectBox.Text;
        }
    }
}
