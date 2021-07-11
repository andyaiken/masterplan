using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools.Generators;

namespace Masterplan.UI
{
	partial class MapAreaForm : Form
	{
		public MapAreaForm(MapArea area, Map m)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			fArea = area.Copy();
			MapView.Map = m;
			MapView.Viewpoint = fArea.Region;

			NameBox.Text = fArea.Name;
			DetailsBox.Text = fArea.Details;
		}

		~MapAreaForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			LeftLessBtn.Enabled = (MapView.Viewpoint.Width != 1);
			RightLessBtn.Enabled = (MapView.Viewpoint.Width != 1);

			TopLessBtn.Enabled = (MapView.Viewpoint.Height != 1);
			BottomLessBtn.Enabled = (MapView.Viewpoint.Height != 1);
		}

		public MapArea Area
		{
			get { return fArea; }
		}
		MapArea fArea = null;

		private void OKBtn_Click(object sender, EventArgs e)
		{
			fArea.Name = NameBox.Text;
			fArea.Details = DetailsBox.Text;
			fArea.Region = MapView.Viewpoint;
		}

		#region Move

		private void MoveUpBtn_Click(object sender, EventArgs e)
		{
			change(0, -1, 0, 0);
		}

		private void MoveLeftBtn_Click(object sender, EventArgs e)
		{
			change(-1, 0, 0, 0);
		}

		private void MoveRightBtn_Click(object sender, EventArgs e)
		{
			change(1, 0, 0, 0);
		}

		private void MoveDownBtn_Click(object sender, EventArgs e)
		{
			change(0, 1, 0, 0);
		}

		#endregion

		#region Edit

		private void TopMoreBtn_Click(object sender, EventArgs e)
		{
			change(0, -1, 0, 1);
		}

		private void TopLessBtn_Click(object sender, EventArgs e)
		{
			change(0, 1, 0, -1);
		}

		private void LeftMoreBtn_Click(object sender, EventArgs e)
		{
			change(-1, 0, 1, 0);
		}

		private void LeftLessBtn_Click(object sender, EventArgs e)
		{
			change(1, 0, -1, 0);
		}

		private void RightMoreBtn_Click(object sender, EventArgs e)
		{
			change(0, 0, 1, 0);
		}

		private void RightLessBtn_Click(object sender, EventArgs e)
		{
			change(0, 0, -1, 0);
		}

		private void BottomMoreBtn_Click(object sender, EventArgs e)
		{
			change(0, 0, 0, 1);
		}

		private void BottomLessBtn_Click(object sender, EventArgs e)
		{
			change(0, 0, 0, -1);
		}

		#endregion

		void change(int x, int y, int width, int height)
		{
			x += MapView.Viewpoint.X;
			y += MapView.Viewpoint.Y;
			width += MapView.Viewpoint.Width;
			height += MapView.Viewpoint.Height;

			MapView.Viewpoint = new Rectangle(x, y, width, height);
		}

		private void RandomNameBtn_Click(object sender, EventArgs e)
		{
			string name = "";
			while (name == "")
				name = RoomBuilder.Name();

			NameBox.Text = name;
		}

		private void RandomDescBtn_Click(object sender, EventArgs e)
		{
			string details = "";
			while (details == "")
				details = RoomBuilder.Details();

			DetailsBox.Text = details;
		}
	}
}
