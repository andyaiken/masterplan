using System;
using System.Windows.Forms;

namespace Masterplan.Controls
{
	partial class LevelRangePanel : UserControl
	{
		public LevelRangePanel()
		{
			InitializeComponent();
		}

		bool fInitialising = false;

		public int MinimumLevel
		{
			get { return (int)MinBox.Value; }
		}

		public int MaximumLevel
		{
			get { return (int)MaxBox.Value; }
		}

		public string NameQuery
		{
			get
			{
				return NameBox.Text;
			}
		}

		public void SetLevelRange(int minlevel, int maxlevel)
		{
			fInitialising = true;

			MinBox.Value = Math.Max(MinBox.Minimum, minlevel);
			MaxBox.Value = Math.Min(MaxBox.Maximum, maxlevel);

			fInitialising = false;
		}

		public event EventHandler RangeChanged;

		private void MinBox_ValueChanged(object sender, EventArgs e)
		{
			if (fInitialising)
				return;

			fInitialising = true;

			MaxBox.Value = Math.Max(MaxBox.Value, MinBox.Value);

			fInitialising = false;

			if (RangeChanged != null)
				RangeChanged(this, new EventArgs());
		}

		private void MaxBox_ValueChanged(object sender, EventArgs e)
		{
			if (fInitialising)
				return;

			fInitialising = true;

			MinBox.Value = Math.Min(MaxBox.Value, MinBox.Value);

			fInitialising = false;

			if (RangeChanged != null)
				RangeChanged(this, new EventArgs());
		}

		private void NameBox_TextChanged(object sender, EventArgs e)
		{
			if (RangeChanged != null)
				RangeChanged(this, new EventArgs());
		}
	}
}
