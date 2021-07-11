using System;
using System.Windows.Forms;

using Masterplan.Data;

namespace Masterplan.UI
{
    partial class MapLocationSelectForm : Form
    {
		public MapLocationSelectForm(Guid map_id, Guid map_location_id)
        {
            InitializeComponent();

            Application.Idle += new EventHandler(Application_Idle);

            MapBox.Items.Add("(no map)");
            foreach (RegionalMap m in Session.Project.RegionalMaps)
                MapBox.Items.Add(m);

            RegionalMap map = Session.Project.FindRegionalMap(map_id);
            if (map != null)
            {
                MapBox.SelectedItem = map;

				MapLocation loc = map.FindLocation(map_location_id);
                if (loc != null)
                {
                    LocationBox.SelectedItem = loc;
                }
                else
                {
                    LocationBox.SelectedIndex = 0;
                }
            }
            else
            {
                MapBox.SelectedIndex = 0;

				LocationBox.Items.Add("(no map)");
				LocationBox.SelectedIndex = 0;
            }
        }

        ~MapLocationSelectForm()
        {
            Application.Idle -= Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
			MapLbl.Enabled = (Session.Project.RegionalMaps.Count != 0);
			MapBox.Enabled = (Session.Project.RegionalMaps.Count != 0);

			RegionalMap m = MapBox.SelectedItem as RegionalMap;
            bool locations = ((m != null) && (m.Locations.Count != 0));

            LocationLbl.Enabled = locations;
            LocationBox.Enabled = locations;

			OKBtn.Enabled = (MapLocation != null);
        }

		public RegionalMap Map
        {
			get { return MapBox.SelectedItem as RegionalMap; }
        }

        public MapLocation MapLocation
        {
            get { return LocationBox.SelectedItem as MapLocation; }
        }

        private void MapBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocationBox.Items.Clear();

			RegionalMap m = MapBox.SelectedItem as RegionalMap;
			if (m != null)
			{
				LocationBox.Items.Add("(entire map)");

				foreach (MapLocation loc in m.Locations)
					LocationBox.Items.Add(loc);

				LocationBox.SelectedIndex = 0;
			}

            show_map();
        }

        private void AreaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            show_map();
        }

        void show_map()
        {
			RegionalMap m = MapBox.SelectedItem as RegionalMap;
            if (m != null)
            {
                MapPanel.Map = m;

                MapLocation loc = LocationBox.SelectedItem as MapLocation;
				MapPanel.HighlightedLocation = loc;
            }
            else
            {
                MapPanel.Map = null;
            }
        }
	}
}
