using System;
using System.Collections.Generic;

using Utils;

using Masterplan.Data;

namespace Masterplan.Tools
{
	class GoalBuilder
	{
		public static void Build(Plot plot)
		{
			Dictionary<Guid, Pair<PlotPoint, PlotPoint>> map = new Dictionary<Guid, Pair<PlotPoint, PlotPoint>>();

			add_points(plot, plot.Goals.Goals, map);
			add_links(plot.Goals.Goals, map);
		}

		static void add_points(Plot plot, List<Goal> goals, Dictionary<Guid, Pair<PlotPoint, PlotPoint>> map)
		{
			foreach (Goal goal in goals)
			{
				PlotPoint pp1 = new PlotPoint("Discover: " + goal.Name);
				pp1.Details = goal.Details;

				PlotPoint pp2 = new PlotPoint("Complete: " + goal.Name);
				pp2.Details = goal.Details;

				plot.Points.Add(pp1);
				plot.Points.Add(pp2);

				map[goal.ID] = new Pair<PlotPoint, PlotPoint>(pp1, pp2);

				add_points(plot, goal.Prerequisites, map);
			}
		}

		static void add_links(List<Goal> goals, Dictionary<Guid, Pair<PlotPoint, PlotPoint>> map)
		{
			foreach (Goal goal in goals)
			{
				Pair<PlotPoint, PlotPoint> goal_points = map[goal.ID];

				foreach (Goal subgoal in goal.Prerequisites)
				{
					Pair<PlotPoint, PlotPoint> subgoal_points = map[subgoal.ID];

					goal_points.First.Links.Add(subgoal_points.First.ID);
					subgoal_points.Second.Links.Add(goal_points.Second.ID);
				}

				if (goal.Prerequisites.Count == 0)
					goal_points.First.Links.Add(goal_points.Second.ID);

				add_links(goal.Prerequisites, map);
			}
		}
	}
}
