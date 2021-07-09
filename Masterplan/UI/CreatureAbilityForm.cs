using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CreatureAbilityForm : Form
	{
		public CreatureAbilityForm(ICreature c)
		{
			InitializeComponent();

			fCreature = c;

			StrBox.Value = fCreature.Strength.Score;
			ConBox.Value = fCreature.Constitution.Score;
			DexBox.Value = fCreature.Dexterity.Score;
			IntBox.Value = fCreature.Intelligence.Score;
			WisBox.Value = fCreature.Wisdom.Score;
			ChaBox.Value = fCreature.Charisma.Score;
		}

		public ICreature Creature
		{
			get { return fCreature; }
		}
		ICreature fCreature = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fCreature.Strength.Score = (int)StrBox.Value;
			fCreature.Constitution.Score = (int)ConBox.Value;
			fCreature.Dexterity.Score = (int)DexBox.Value;
			fCreature.Intelligence.Score = (int)IntBox.Value;
			fCreature.Wisdom.Score = (int)WisBox.Value;
			fCreature.Charisma.Score = (int)ChaBox.Value;
		}

		private void StrBox_ValueChanged(object sender, EventArgs e)
		{
			update_mods();
		}

		void update_mods()
		{
			int halflevel = fCreature.Level / 2;

			StrModBox.Text = get_text((int)StrBox.Value);
			ConModBox.Text = get_text((int)ConBox.Value);
			DexModBox.Text = get_text((int)DexBox.Value);
			IntModBox.Text = get_text((int)IntBox.Value);
			WisModBox.Text = get_text((int)WisBox.Value);
			ChaModBox.Text = get_text((int)ChaBox.Value);
		}

		string get_text(int score)
		{
			int bonus = Ability.GetModifier(score);
			int mod = bonus + (fCreature.Level / 2);

			string bonus_str = bonus.ToString();
			if (bonus >= 0)
				bonus_str = "+" + bonus_str;

			string mod_str = mod.ToString();
			if (mod >= 0)
				mod_str = "+" + mod_str;

			return bonus_str + " / " + mod_str;
		}
	}
}
