using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Utils;

using Masterplan.Data;

namespace Masterplan.UI
{
	partial class MiniChecklistForm : Form
	{
		public MiniChecklistForm()
		{
			InitializeComponent();

			update_tree();
			if (PlotTree.Nodes[0].Nodes.Count == 0)
				Splitter.Panel1Collapsed = true;

			PlotTree.SelectedNode = PlotTree.Nodes[0];

		}

		private void PlotTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			Plot plot = e.Node.Tag as Plot;
			if (plot != null)
				update_list(plot);
		}

		void update_tree()
		{
			add_navigation_node(null, null);
			PlotTree.ExpandAll();
		}

		void add_navigation_node(PlotPoint pp, TreeNode parent)
		{
			try
			{
				string name = (pp != null) ? pp.Name : Session.Project.Name;

				TreeNodeCollection tnc = (parent != null) ? parent.Nodes : PlotTree.Nodes;
				TreeNode node = tnc.Add(name);

				Plot p = (pp != null) ? pp.Subplot : Session.Project.Plot;
				node.Tag = p;

				List<PlotPoint> list = (pp != null) ? pp.Subplot.Points : Session.Project.Plot.Points;
				foreach (PlotPoint child in list)
				{
					if (child.Subplot.Points.Count != 0)
						add_navigation_node(child, node);
				}
			}
			catch (Exception ex)
			{
				LogSystem.Trace(ex);
			}
		}

		void update_list(Plot plot)
		{
			List<Encounter> encounters = new List<Encounter>();

			List<PlotPoint> points = plot.AllPlotPoints;
			foreach (PlotPoint pp in points)
			{
				Encounter enc = pp.Element as Encounter;
				if (enc != null)
				{
					encounters.Add(enc);
				}
			}

			Dictionary<Guid, int> creatures = new Dictionary<Guid, int>();

			foreach (Encounter enc in encounters)
			{
				// Get the mini breakdown for this encounter
				Dictionary<Guid, int> enc_creatures = new Dictionary<Guid, int>();
				foreach (EncounterSlot slot in enc.Slots)
				{
					if (!enc_creatures.ContainsKey(slot.Card.CreatureID))
						enc_creatures[slot.Card.CreatureID] = 0;

					enc_creatures[slot.Card.CreatureID] += slot.CombatData.Count;
				}

				// Update the running total
				foreach (Guid creature_id in enc_creatures.Keys)
				{
					if (!creatures.ContainsKey(creature_id))
						creatures[creature_id] = 0;

					if (enc_creatures[creature_id] > creatures[creature_id])
						creatures[creature_id] = enc_creatures[creature_id];
				}
			}

			TileList.Items.Clear();
			foreach (Guid creature_id in creatures.Keys)
			{
				ICreature c = Session.FindCreature(creature_id, SearchType.Global);
				int count = creatures[creature_id];

				if (c != null)
				{
					ListViewItem lvi = TileList.Items.Add(c.Name);

					string info = c.Size + " size";
					if (c.Keywords != "")
						info += ", " + c.Keywords;
					foreach (CreaturePower cp in c.CreaturePowers)
						info += ", " + cp.Name;
					lvi.SubItems.Add(info);

					if (count > 1)
						lvi.SubItems.Add("x" + count);
					else
						lvi.SubItems.Add("");
				}
			}
		}
	}
}
