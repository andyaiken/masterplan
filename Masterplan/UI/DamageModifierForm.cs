using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class DamageModifierForm : Form
	{
		public DamageModifierForm(DamageModifier dm)
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

			fMod = dm.Copy();

			if (fMod.Type == DamageType.Untyped)
			{
				DamageTypeBox.SelectedIndex = 0;
			}
			else
			{
				DamageTypeBox.SelectedItem = fMod.Type;
			}

			if (fMod.Value == 0)
			{
				TypeBox.SelectedIndex = 0;
			}
			if (fMod.Value < 0)
			{
				TypeBox.SelectedIndex = 1;
				ValueBox.Value = Math.Abs(fMod.Value);
			}
			if (fMod.Value > 0)
			{
				TypeBox.SelectedIndex = 2;
				ValueBox.Value = fMod.Value;
			}
		}

		public DamageModifier Modifier
		{
			get { return fMod; }
		}
		DamageModifier fMod = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fMod.Type = (DamageType)DamageTypeBox.SelectedItem;

			switch (TypeBox.SelectedIndex)
			{
				case 0:
					fMod.Value = 0;
					break;
				case 1:
					int val = (int)ValueBox.Value;
					fMod.Value = -val;
					break;
				case 2:
					fMod.Value = (int)ValueBox.Value;
					break;
			}
		}

		private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ValueLbl.Enabled = (TypeBox.SelectedIndex != 0);
			ValueBox.Enabled = (TypeBox.SelectedIndex != 0);
		}
	}
}
