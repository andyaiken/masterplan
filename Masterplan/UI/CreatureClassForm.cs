using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class CreatureClassForm : Form
	{
		public CreatureClassForm(ICreature c)
		{
			InitializeComponent();

			// Populate size
			foreach (CreatureSize size in Enum.GetValues(typeof(CreatureSize)))
				SizeBox.Items.Add(size);

			// Populate origin
			Array origins = Enum.GetValues(typeof(CreatureOrigin));
			foreach (CreatureOrigin origin in origins)
				OriginBox.Items.Add(origin);

			// Populate type
			Array types = Enum.GetValues(typeof(CreatureType));
			foreach (CreatureType type in types)
				TypeBox.Items.Add(type);

			fCreature = c;

			SizeBox.SelectedItem = fCreature.Size;
			OriginBox.SelectedItem = fCreature.Origin;
			TypeBox.SelectedItem = fCreature.Type;
			KeywordBox.Text = fCreature.Keywords;
		}

		ICreature fCreature = null;

		public CreatureSize CreatureSize
		{
			get { return (CreatureSize)SizeBox.SelectedItem; }
		}

		public CreatureOrigin Origin
		{
			get { return (CreatureOrigin)OriginBox.SelectedItem; }
		}

		public CreatureType Type
		{
			get { return (CreatureType)TypeBox.SelectedItem; }
		}

		public string Keywords
		{
			get { return KeywordBox.Text; }
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}
	}
}
