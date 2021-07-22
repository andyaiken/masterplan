using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;

namespace Masterplan.UI
{
	enum OverviewType
	{
		Encounters,
		Traps,
		SkillChallenges,
		Treasure
	}

	partial class OverviewForm : Form
	{
		public OverviewForm()
		{
			InitializeComponent();

			Application.Idle += new EventHandler(Application_Idle);

			add_points(null);

			update_list();
		}

		~OverviewForm()
		{
			Application.Idle -= Application_Idle;
		}

		void Application_Idle(object sender, EventArgs e)
		{
			EncounterBtn.Checked = (fType == OverviewType.Encounters);
			TrapBtn.Checked = (fType == OverviewType.Traps);
			ChallengeBtn.Checked = (fType == OverviewType.SkillChallenges);
			TreasureBtn.Checked = (fType == OverviewType.Treasure);
		}

		OverviewType fType = OverviewType.Encounters;

		private void EncounterBtn_Click(object sender, EventArgs e)
		{
			fType = OverviewType.Encounters;
			update_list();
		}

		private void TrapBtn_Click(object sender, EventArgs e)
		{
			fType = OverviewType.Traps;
			update_list();
		}

		private void ChallengeBtn_Click(object sender, EventArgs e)
		{
			fType = OverviewType.SkillChallenges;
			update_list();
		}

		private void TreasureBtn_Click(object sender, EventArgs e)
		{
			fType = OverviewType.Treasure;
			update_list();
		}

		void update_list()
		{
			ItemList.Items.Clear();

			switch (fType)
			{
				case OverviewType.Encounters:
					{
						foreach (PlotPoint pp in fPoints)
						{
							if (pp.Element == null)
								continue;

							if (pp.Element is Encounter)
							{
								Encounter enc = pp.Element as Encounter;

								string creatures = "";
								foreach (EncounterSlot slot in enc.AllSlots)
								{
									if (creatures != "")
										creatures += ", ";

									creatures += slot.Card.Title;
									if (slot.CombatData.Count != 1)
										creatures += " (x" + slot.CombatData.Count + ")";
								}

								foreach (Trap trap in enc.Traps)
								{
									if (creatures != "")
										creatures += ", ";

									creatures += trap.Name;
								}

								ListViewItem lvi = ItemList.Items.Add(pp.Name);
								lvi.SubItems.Add(enc.GetXP() + " XP; " + creatures);
								lvi.Tag = new Pair<PlotPoint, Encounter>(pp, enc);
							}
						}
					}
					break;
				case OverviewType.Traps:
					{
						foreach (PlotPoint pp in fPoints)
						{
							if (pp.Element == null)
								continue;

							if (pp.Element is TrapElement)
							{
								TrapElement te = pp.Element as TrapElement;

								ListViewItem lvi = ItemList.Items.Add(pp.Name);
								lvi.SubItems.Add(Experience.GetCreatureXP(te.Trap.Level) + " XP; " + te.Trap.Name);
								lvi.Tag = new Pair<PlotPoint, Trap>(pp, te.Trap);
							}

							if (pp.Element is Encounter)
							{
								Encounter enc = pp.Element as Encounter;

								foreach (Trap trap in enc.Traps)
								{
									ListViewItem lvi = ItemList.Items.Add(pp.Name);
									lvi.SubItems.Add(Experience.GetCreatureXP(trap.Level) + " XP; " + trap.Name);
									lvi.Tag = new Pair<PlotPoint, Trap>(pp, trap);
								}
							}
						}
					}
					break;
				case OverviewType.SkillChallenges:
					{
						foreach (PlotPoint pp in fPoints)
						{
							if (pp.Element == null)
								continue;

							if (pp.Element is SkillChallenge)
							{
								SkillChallenge sc = pp.Element as SkillChallenge;

								ListViewItem lvi = ItemList.Items.Add(pp.Name);
								lvi.SubItems.Add(sc.GetXP() + " XP");
								lvi.Tag = new Pair<PlotPoint, SkillChallenge>(pp, sc);
							}

							if (pp.Element is Encounter)
							{
								Encounter enc = pp.Element as Encounter;

								foreach (SkillChallenge sc in enc.SkillChallenges)
								{
									ListViewItem lvi = ItemList.Items.Add(pp.Name);
									lvi.SubItems.Add(sc.GetXP() + " XP");
									lvi.Tag = new Pair<PlotPoint, SkillChallenge>(pp, sc);
								}
							}
						}
					}
					break;
				case OverviewType.Treasure:
					{
						foreach (PlotPoint pp in fPoints)
						{
							foreach (Parcel parcel in pp.Parcels)
							{
								string name = (parcel.Name != "") ? parcel.Name : "(undefined parcel)";

								ListViewItem lvi = ItemList.Items.Add(pp.Name);
								lvi.SubItems.Add(name + ": " + parcel.Details);
								lvi.Tag = new Pair<PlotPoint, Parcel>(pp, parcel);
							}
						}
					}
					break;
			}

			if (ItemList.Items.Count == 0)
			{
				ListViewItem lvi = ItemList.Items.Add("(no items)");
				lvi.ForeColor = SystemColors.GrayText;
			}

			ItemList.Sort();
		}

		List<PlotPoint> fPoints = new List<PlotPoint>();

		void add_points(Plot plot)
		{
			List<PlotPoint> points = (plot != null) ? plot.Points : Session.Project.Plot.Points;

			fPoints.AddRange(points);

			foreach (PlotPoint pp in points)
				add_points(pp.Subplot);
		}

		public Pair<PlotPoint, Encounter> SelectedEncounter
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as Pair<PlotPoint, Encounter>;

				return null;
			}
		}

		public Pair<PlotPoint, Trap> SelectedTrap
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as Pair<PlotPoint, Trap>;

				return null;
			}
		}

		public Pair<PlotPoint, SkillChallenge> SelectedChallenge
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as Pair<PlotPoint, SkillChallenge>;

				return null;
			}
		}

		public Pair<PlotPoint, Parcel> SelectedParcel
		{
			get
			{
				if (ItemList.SelectedItems.Count != 0)
					return ItemList.SelectedItems[0].Tag as Pair<PlotPoint, Parcel>;

				return null;
			}
		}

		private void ItemList_DoubleClick(object sender, EventArgs e)
		{
			switch (fType)
			{
				case OverviewType.Encounters:
					{
						if (SelectedEncounter != null)
						{
							int level = Workspace.GetPartyLevel(SelectedEncounter.First);

							EncounterBuilderForm dlg = new EncounterBuilderForm(SelectedEncounter.Second, level, false);
							if (dlg.ShowDialog() == DialogResult.OK)
							{
								SelectedEncounter.First.Element = dlg.Encounter;
								Session.Modified = true;

								update_list();
							}

							return;
						}
					}
					break;
				case OverviewType.Traps:
					{
						if (SelectedTrap != null)
						{
							if (SelectedTrap.First.Element is TrapElement)
							{
								TrapElement te = SelectedTrap.First.Element as TrapElement;

								TrapBuilderForm dlg = new TrapBuilderForm(SelectedTrap.Second);
								//TrapForm dlg = new TrapForm(SelectedTrap.Second);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									te.Trap = dlg.Trap;
									Session.Modified = true;

									update_list();
								}

								return;
							}

							if (SelectedTrap.First.Element is Encounter)
							{
								Encounter enc = SelectedTrap.First.Element as Encounter;
								int index = enc.Traps.IndexOf(SelectedTrap.Second);

								TrapBuilderForm dlg = new TrapBuilderForm(SelectedTrap.Second);
								//TrapForm dlg = new TrapForm(SelectedTrap.Second);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									enc.Traps[index] = dlg.Trap;
									Session.Modified = true;

									update_list();
								}

								return;
							}
						}
					}
					break;
				case OverviewType.SkillChallenges:
					{
						if (SelectedChallenge != null)
						{
							if (SelectedChallenge.First.Element is SkillChallenge)
							{
								SkillChallenge sc = SelectedChallenge.First.Element as SkillChallenge;

								SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(SelectedChallenge.Second);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									sc.Name = dlg.SkillChallenge.Name;
									sc.Level = dlg.SkillChallenge.Level;
									sc.Complexity = dlg.SkillChallenge.Complexity;
									sc.Success = dlg.SkillChallenge.Success;
									sc.Failure = dlg.SkillChallenge.Failure;

									sc.Skills.Clear();
									foreach (SkillChallengeData scd in dlg.SkillChallenge.Skills)
										sc.Skills.Add(scd.Copy());

									Session.Modified = true;

									update_list();
								}

								return;
							}

							if (SelectedChallenge.First.Element is Encounter)
							{
								Encounter enc = SelectedChallenge.First.Element as Encounter;
								int index = enc.SkillChallenges.IndexOf(SelectedChallenge.Second);

								SkillChallengeBuilderForm dlg = new SkillChallengeBuilderForm(SelectedChallenge.Second);
								if (dlg.ShowDialog() == DialogResult.OK)
								{
									enc.SkillChallenges[index] = dlg.SkillChallenge;
									Session.Modified = true;

									update_list();
								}

								return;
							}
						}
					}
					break;
				case OverviewType.Treasure:
					{
						if (SelectedParcel != null)
						{
							int index = SelectedParcel.First.Parcels.IndexOf(SelectedParcel.Second);

							ParcelForm dlg = new ParcelForm(SelectedParcel.Second);
							if (dlg.ShowDialog() == DialogResult.OK)
							{
								SelectedParcel.First.Parcels[index] = dlg.Parcel;
								Session.Modified = true;

								update_list();
							}

							return;
						}
					}
					break;
			}
		}
	}
}
