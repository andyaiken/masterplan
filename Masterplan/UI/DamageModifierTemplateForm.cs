using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DamageModifierTemplateForm : Form
	{
		public DamageModifierTemplateForm(DamageModifierTemplate dmt)
		{
			InitializeComponent();

			foreach (DamageType type in Enum.GetValues(typeof(DamageType)))
			{
				if (type == DamageType.Untyped)
					continue;

				DamageTypeBox.Items.Add(type);
			}

			TypeBox.Items.Add("Immunity to this damage type");
			TypeBox.Items.Add("Resistance to this damage type");
			TypeBox.Items.Add("Vulnerability to this damage type");

			fMod = dmt.Copy();

			if (fMod.Type == DamageType.Untyped)
			{
				DamageTypeBox.SelectedIndex = 0;
			}
			else
			{
				DamageTypeBox.SelectedItem = fMod.Type;
			}

			int total_mod = fMod.HeroicValue + fMod.ParagonValue + fMod.EpicValue;
			if (total_mod == 0)
			{
				TypeBox.SelectedIndex = 0;
			}
			if (total_mod < 0)
			{
				TypeBox.SelectedIndex = 1;
			}
			if (total_mod > 0)
			{
				TypeBox.SelectedIndex = 2;
			}

			HeroicBox.Value = Math.Abs(fMod.HeroicValue);
			ParagonBox.Value = Math.Abs(fMod.ParagonValue);
			EpicBox.Value = Math.Abs(fMod.EpicValue);
		}

		public DamageModifierTemplate Modifier
		{
			get { return fMod; }
		}
		DamageModifierTemplate fMod = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fMod.Type = (DamageType)DamageTypeBox.SelectedItem;

			switch (TypeBox.SelectedIndex)
			{
				case 0:
					fMod.HeroicValue = 0;
					fMod.ParagonValue = 0;
					fMod.EpicValue = 0;
					break;
				case 1:
					fMod.HeroicValue = -(int)HeroicBox.Value;
					fMod.ParagonValue = -(int)ParagonBox.Value;
					fMod.EpicValue = -(int)EpicBox.Value;
					break;
				case 2:
					fMod.HeroicValue = (int)HeroicBox.Value;
					fMod.ParagonValue = (int)ParagonBox.Value;
					fMod.EpicValue = (int)EpicBox.Value;
					break;
			}
		}

		private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			HeroicLbl.Enabled = (TypeBox.SelectedIndex != 0);
			HeroicBox.Enabled = (TypeBox.SelectedIndex != 0);

			ParagonLbl.Enabled = (TypeBox.SelectedIndex != 0);
			ParagonBox.Enabled = (TypeBox.SelectedIndex != 0);
			
			EpicLbl.Enabled = (TypeBox.SelectedIndex != 0);
			EpicBox.Enabled = (TypeBox.SelectedIndex != 0);
		}
	}
}
