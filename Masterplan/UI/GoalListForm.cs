using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	partial class GoalListForm : Form
	{
		public GoalListForm(PartyGoals goals)
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			Browser.DocumentText = "";

			fPartyGoals = goals.Copy();

			update_tree();
			update_goal();
		}

		void Application_Idle(object sender, EventArgs e)
		{
			RemoveBtn.Enabled = (SelectedGoal != null);
			EditBtn.Enabled = (SelectedGoal != null);
			ClearBtn.Enabled = (fPartyGoals.Goals.Count != 0);

			OKBtn.Enabled = (fPartyGoals.Goals.Count != 0);
		}

		public PartyGoals Goals
		{
			get { return fPartyGoals; }
		}
		PartyGoals fPartyGoals = null;

		public bool CreatePlot
		{
			get { return fCreatePlot; }
		}
		bool fCreatePlot = false;

		public Goal SelectedGoal
		{
			get
			{
				if (GoalTree.SelectedNode != null)
					return GoalTree.SelectedNode.Tag as Goal;

				return null;
			}
			set
			{
				GoalTree.SelectedNode = find_node(value, GoalTree.Nodes);
			}
		}

		TreeNode find_node(Goal goal, TreeNodeCollection tnc)
		{
			foreach (TreeNode tn in tnc)
			{
				Goal g = tn.Tag as Goal;
				if (g == goal)
					return tn;

				TreeNode node = find_node(goal, tn.Nodes);
				if (node != null)
					return node;
			}

			return null;
		}

		private void GoalListForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (DialogResult == DialogResult.OK)
			{
				// Offer to create a plot
				string str = "Do you want to build a plotline from these goals?";
				DialogResult dr = MessageBox.Show(str, "Masterplan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				switch (dr)
				{
					case DialogResult.Yes:
						fCreatePlot = true;
						break;
					case DialogResult.No:
						fCreatePlot = false;
						break;
					case DialogResult.Cancel:
						e.Cancel = true;
						break;
				}
			}
		}

		private void OKBtn_Click(object sender, EventArgs e)
		{
		}

		private void GoalTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			update_goal();
		}

		private void AddBtn_Click(object sender, EventArgs e)
		{
			GoalForm dlg = new GoalForm(new Goal("New Goal"));
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				List<Goal> list = (SelectedGoal != null) ? SelectedGoal.Prerequisites : fPartyGoals.Goals;
				
				// We only allow a single root goal
				if ((list == fPartyGoals.Goals) && (fPartyGoals.Goals.Count != 0))
					list = fPartyGoals.Goals[0].Prerequisites;

				list.Add(dlg.Goal);

				update_tree();

				SelectedGoal = dlg.Goal;
			}
		}

		private void RemoveBtn_Click(object sender, EventArgs e)
		{
			if (SelectedGoal != null)
			{
				List<Goal> list = fPartyGoals.FindList(SelectedGoal);
				if (list != null)
				{
					list.Remove(SelectedGoal);

					update_tree();
					update_goal();
				}
			}
		}

		private void EditBtn_Click(object sender, EventArgs e)
		{
			if (SelectedGoal != null)
			{
				List<Goal> list = fPartyGoals.FindList(SelectedGoal);
				if (list != null)
				{
					int index = list.IndexOf(SelectedGoal);

					GoalForm dlg = new GoalForm(SelectedGoal);
					if (dlg.ShowDialog() == DialogResult.OK)
					{
						list[index] = dlg.Goal;

						update_tree();

						SelectedGoal = dlg.Goal;
					}
				}
			}
		}

		private void ClearBtn_Click(object sender, EventArgs e)
		{
			fPartyGoals.Goals.Clear();

			update_tree();
			update_goal();
		}

		private void GoalTree_ItemDrag(object sender, ItemDragEventArgs e)
		{
			if (SelectedGoal != null)
			{
				Goal dragged_goal = SelectedGoal;
				if (DoDragDrop(dragged_goal, DragDropEffects.Move) == DragDropEffects.Move)
				{
					List<Goal> list = fPartyGoals.FindList(dragged_goal);

					list.Remove(dragged_goal);
					SelectedGoal.Prerequisites.Add(dragged_goal);

					update_tree();
					update_goal();
				}
			}
		}

		private void GoalTree_DragOver(object sender, DragEventArgs e)
		{
			e.Effect = DragDropEffects.None;

			Goal goal = e.Data.GetData(typeof(Goal)) as Goal;

			Point pt = GoalTree.PointToClient(Cursor.Position);
			TreeNode tn = GoalTree.GetNodeAt(pt);
			if (tn != null)
			{
				GoalTree.SelectedNode = tn;

				// Not onto parent
				if (SelectedGoal.Prerequisites.Contains(goal))
					return;

				// Not onto subtree
				if (goal.Subtree.Contains(SelectedGoal))
					return;

				e.Effect = DragDropEffects.Move;
			}
		}

		private void GoalTree_DragDrop(object sender, DragEventArgs e)
		{
			//
		}

		void update_tree()
		{
			GoalTree.Nodes.Clear();

			foreach (Goal goal in fPartyGoals.Goals)
				add_goal(goal, null);

			if (fPartyGoals.Goals.Count == 0)
			{
				TreeNode tn = GoalTree.Nodes.Add("(none)");
				tn.ForeColor = SystemColors.GrayText;
			}

			GoalTree.ExpandAll();
		}

		void add_goal(Goal goal, TreeNode parent)
		{
			TreeNodeCollection tnc = (parent != null) ? parent.Nodes : GoalTree.Nodes;
			TreeNode tn = tnc.Add(goal.Name);
			tn.Tag = goal;

			foreach (Goal subgoal in goal.Prerequisites)
				add_goal(subgoal, tn);
		}

		void update_goal()
		{
			Browser.Document.OpenNew(true);
			Browser.Document.Write(HTML.Goal(SelectedGoal));
		}

		private void GoalTree_MouseDown(object sender, MouseEventArgs e)
		{
			Point pt = GoalTree.PointToClient(Cursor.Position);
			GoalTree.SelectedNode = GoalTree.GetNodeAt(pt);

			update_goal();
		}
	}
}
