using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class OptionWeaponForm : Form
	{
		public OptionWeaponForm(Weapon weapon)
		{
			InitializeComponent();

			Array cats = Enum.GetValues(typeof(WeaponCategory));
			foreach (WeaponCategory cat in cats)
				CatBox.Items.Add(cat);

			Array types = Enum.GetValues(typeof(WeaponType));
			foreach (WeaponType type in types)
				TypeBox.Items.Add(type);

			GroupBox.Items.Add("Axe");
			GroupBox.Items.Add("Box");
			GroupBox.Items.Add("Crossbow");
			GroupBox.Items.Add("Flail");
			GroupBox.Items.Add("Hammer");
			GroupBox.Items.Add("Heavy Blade");
			GroupBox.Items.Add("Light Blade");
			GroupBox.Items.Add("Mace");
			GroupBox.Items.Add("Pick");
			GroupBox.Items.Add("Polearm");
			GroupBox.Items.Add("Sling");
			GroupBox.Items.Add("Spear");
			GroupBox.Items.Add("Staff");
			GroupBox.Items.Add("Unarmed");

			PropertiesBox.Items.Add("Brutal 1");
			PropertiesBox.Items.Add("Brutal 2");
			PropertiesBox.Items.Add("Defensive");
			PropertiesBox.Items.Add("Heavy Thrown");
			PropertiesBox.Items.Add("High Crit");
			PropertiesBox.Items.Add("Light Thrown");
			PropertiesBox.Items.Add("Load Free");
			PropertiesBox.Items.Add("Load Minor");
			PropertiesBox.Items.Add("Off-Hand");
			PropertiesBox.Items.Add("Reach");
			PropertiesBox.Items.Add("Small");
			PropertiesBox.Items.Add("Stout");
			PropertiesBox.Items.Add("Versatile");

			fWeapon = weapon.Copy();

			NameBox.Text = fWeapon.Name;
			CatBox.SelectedItem = fWeapon.Category;
			TypeBox.SelectedItem = fWeapon.Type;
			TwoHandBox.Checked = fWeapon.TwoHanded;
			ProfBox.Value = fWeapon.Proficiency;
			DamageBox.Text = fWeapon.Damage;
			RangeBox.Text = fWeapon.Range;
			PriceBox.Text = fWeapon.Price;
			WeightBox.Text = fWeapon.Weight;
			GroupBox.Text = fWeapon.Group;
			PropertiesBox.Text = fWeapon.Properties;
			DetailsBox.Text = fWeapon.Description;
		}

		public Weapon Weapon
		{
			get { return fWeapon; }
		}
		Weapon fWeapon = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fWeapon.Name = NameBox.Text;
			fWeapon.Category = (WeaponCategory)CatBox.SelectedItem;
			fWeapon.Type = (WeaponType)TypeBox.SelectedItem;
			fWeapon.TwoHanded = TwoHandBox.Checked;
			fWeapon.Proficiency = (int)ProfBox.Value;
			fWeapon.Damage = DamageBox.Text;
			fWeapon.Range = RangeBox.Text;
			fWeapon.Price = PriceBox.Text;
			fWeapon.Weight = WeightBox.Text;
			fWeapon.Group = GroupBox.Text;
			fWeapon.Properties = PropertiesBox.Text;
			fWeapon.Description = DetailsBox.Text;
		}
	}
}
