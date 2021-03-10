using System;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.UI;

namespace Masterplan.Controls
{
	partial class MapElementPanel : UserControl
	{
		public MapElementPanel()
		{
			InitializeComponent();
		}

		public MapElement MapElement
		{
			get { return fMapElement; }
			set
			{
				fMapElement = value;
				update_view();
			}
		}
		MapElement fMapElement = null;

		private void MapSelectBtn_Click(object sender, EventArgs e)
		{
			MapAreaSelectForm dlg = new MapAreaSelectForm(fMapElement.MapID, fMapElement.MapAreaID);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				fMapElement.MapID = (dlg.Map != null) ? dlg.Map.ID : Guid.Empty;
				fMapElement.MapAreaID = (dlg.MapArea != null) ? dlg.MapArea.ID : Guid.Empty;

				update_view();
			}
		}

		void update_view()
		{
			Map map = Session.Project.FindTacticalMap(fMapElement.MapID);
			if (map != null)
			{
				MapView.Map = map;

				MapArea area = map.FindArea(fMapElement.MapAreaID);
				if (area != null)
				{
					MapView.Viewpoint = area.Region;
				}
				else
				{
					MapView.Viewpoint = Rectangle.Empty;
				}
			}
			else
			{
				MapView.Map = null;
				MapView.Viewpoint = Rectangle.Empty;
			}
		}
	}
}
