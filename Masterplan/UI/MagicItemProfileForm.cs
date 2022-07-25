using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class MagicItemProfileForm : Form
	{
		public MagicItemProfileForm(MagicItem item)
		{
			InitializeComponent();

			TypeBox.Items.Add("Armour");
			TypeBox.Items.Add(Session.I18N.Weapon);
			TypeBox.Items.Add("Ammunition");
			TypeBox.Items.Add("Item Slot (head)");
			TypeBox.Items.Add("Item Slot (neck)");
			TypeBox.Items.Add("Item Slot (waist)");
			TypeBox.Items.Add("Item Slot (arms)");
			TypeBox.Items.Add("Item Slot (hands)");
			TypeBox.Items.Add("Item Slot (feet)");
			TypeBox.Items.Add("Item Slot (ring)");
			TypeBox.Items.Add("Implement");
			TypeBox.Items.Add("Alchemical Item");
			TypeBox.Items.Add("Divine Boon");
			TypeBox.Items.Add("Grandmaster Training");
			TypeBox.Items.Add("Potion");
			TypeBox.Items.Add("Reagent");
			TypeBox.Items.Add("Whetstone");
			TypeBox.Items.Add("Wondrous Item");

			Array rarities = Enum.GetValues(typeof(MagicItemRarity));
			foreach (MagicItemRarity mir in rarities)
				RarityBox.Items.Add(mir);

			fItem = item.Copy();

			NameBox.Text = fItem.Name;
			LevelBox.Value = fItem.Level;
			TypeBox.Text = fItem.Type;
			RarityBox.SelectedItem = fItem.Rarity;
		}

		public MagicItem MagicItem
		{
			get { return fItem; }
		}
		MagicItem fItem = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fItem.Name = NameBox.Text;
			fItem.Level = (int)LevelBox.Value;
			fItem.Type = TypeBox.Text;
			fItem.Rarity = (MagicItemRarity)RarityBox.SelectedItem;
		}
	}
}
