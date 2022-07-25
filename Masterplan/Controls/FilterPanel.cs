using System;
using System.Windows.Forms;

using Masterplan.Data;
using Masterplan.Tools;
using Masterplan.UI;

namespace Masterplan.Controls
{
	partial class FilterPanel : UserControl
	{
		public FilterPanel()
		{
			InitializeComponent();

			Array roles = Enum.GetValues(typeof(RoleType));
			foreach (RoleType role in roles)
				FilterRoleBox.Items.Add(role);
			FilterRoleBox.SelectedIndex = 0;

			FilterModBox.Items.Add("Standard");
			FilterModBox.Items.Add(Session.I18N.Elite);
			FilterModBox.Items.Add("Solo");
			FilterModBox.Items.Add("Minion");
			FilterModBox.SelectedIndex = 0;

			Array origins = Enum.GetValues(typeof(CreatureOrigin));
			foreach (CreatureOrigin origin in origins)
				FilterOriginBox.Items.Add(origin);
			if (FilterOriginBox.Items.Count != 0)
				FilterOriginBox.SelectedIndex = 0;

			Array types = Enum.GetValues(typeof(CreatureType));
			foreach (CreatureType type in types)
				FilterTypeBox.Items.Add(type);
			if (FilterTypeBox.Items.Count != 0)
				FilterTypeBox.SelectedIndex = 0;

			foreach (Library lib in Session.Libraries)
				FilterSourceBox.Items.Add(lib);
			if (FilterSourceBox.Items.Count != 0)
				FilterSourceBox.SelectedIndex = 0;

			update_allowed_filters();
			update_option_state();

			open_close_editor(false);
		}

		#region Properties

		public ListMode Mode
		{
			get { return fMode; }
			set
			{
				fMode = value;
				update_allowed_filters();
			}
		}
		ListMode fMode = ListMode.Creatures;

		public int PartyLevel
		{
			get { return fPartyLevel; }
			set { fPartyLevel = value; }
		}
		int fPartyLevel = 0;

		#endregion

		#region Fields

		string[] fNameTokens = null;
		string[] fCatTokens = null;
		string[] fKeyTokens = null;

		bool fSuppressEvents = false;

		#endregion

		#region Methods

		public bool AllowItem(object obj, out Difficulty diff)
		{
			diff = Difficulty.Moderate;

			if (obj is ICreature)
			{
				ICreature c = obj as ICreature;

				#region Creature

				bool outlier = false;
				diff = AI.GetThreatDifficulty(c.Level, fPartyLevel);
				if ((diff == Difficulty.Trivial) || (diff == Difficulty.Extreme))
					outlier = true;

				if (outlier && FilterLevelAppropriateToggle.Checked)
					return false;

				if (FilterNameToggle.Checked && (fNameTokens != null))
				{
					string name = c.Name.ToLower();

					foreach (string token in fNameTokens)
					{
						if (!name.Contains(token))
							return false;
					}
				}

				if (FilterCatToggle.Checked && (fCatTokens != null))
				{
					string cat = c.Category.ToLower();

					foreach (string token in fCatTokens)
					{
						if (!cat.Contains(token))
							return false;
					}
				}

				if (FilterRoleToggle.Checked)
				{
					RoleType role = (RoleType)FilterRoleBox.SelectedItem;

					if (c.Role is ComplexRole)
					{
						ComplexRole cr = c.Role as ComplexRole;
						if (cr.Type != role)
							return false;
					}

					if (c.Role is Minion)
					{
						Minion m = c.Role as Minion;
						if ((!m.HasRole) || (m.Type != role))
							return false;
					}
				}

				if (FilterModToggle.Checked)
				{
					RoleFlag flag = RoleFlag.Standard;
					bool minion = false;

					if (FilterModBox.Text == "Standard")
					{
					}

					if (FilterModBox.Text == Session.I18N.Elite)
					{
						flag = RoleFlag.Elite;
					}

					if (FilterModBox.Text == "Solo")
					{
						flag = RoleFlag.Solo;
					}

					if (FilterModBox.Text == "Minion")
					{
						minion = true;
					}

					ComplexRole cr = c.Role as ComplexRole;
					if (cr != null)
					{
						if (minion)
							return false;

						if (flag != cr.Flag)
							return false;
					}

					Minion m = c.Role as Minion;
					if (m != null)
					{
						if (!minion)
							return false;
					}
				}

				if (FilterOriginToggle.Checked)
				{
					CreatureOrigin origin = (CreatureOrigin)FilterOriginBox.SelectedItem;

					if (c.Origin != origin)
						return false;
				}

				if (FilterTypeToggle.Checked)
				{
					CreatureType type = (CreatureType)FilterTypeBox.SelectedItem;

					if (c.Type != type)
						return false;
				}

				if (FilterKeywordToggle.Checked && (fKeyTokens != null))
				{
					string keywords = (c.Keywords != null) ? c.Keywords.ToLower() : "";

					foreach (string token in fKeyTokens)
					{
						if (!keywords.Contains(token))
							return false;
					}
				}

				if (FilterLevelToggle.Checked)
				{
					if ((c.Level < LevelFromBox.Value) || (c.Level > LevelToBox.Value))
						return false;
				}

				if (FilterSourceToggle.Checked)
				{
					Creature creature = c as Creature;
					if (creature == null)
						return false;

					Library lib = FilterSourceBox.SelectedItem as Library;
					if (!lib.Creatures.Contains(creature))
						return false;
				}

				#endregion

				return true;
			}

			if (obj is CreatureTemplate)
			{
				CreatureTemplate ct = obj as CreatureTemplate;

				#region Template

				if (FilterNameToggle.Checked && (fNameTokens != null))
				{
					string name = ct.Name.ToLower();

					foreach (string token in fNameTokens)
					{
						if (!name.Contains(token))
							return false;
					}
				}

				if (FilterCatToggle.Checked && (fCatTokens != null))
				{
					// Ignore category for templates
				}

				if (FilterRoleToggle.Checked)
				{
					// Match on role
					RoleType role = (RoleType)FilterRoleBox.SelectedItem;
					if (ct.Role != role)
						return false;
				}

				if (FilterOriginToggle.Checked)
				{
					// Ignore origin for templates
				}

				if (FilterTypeToggle.Checked)
				{
					// Ignore type for templates
				}

				if (FilterKeywordToggle.Checked && (fKeyTokens != null))
				{
					// Ignore keywords for templates
				}

				if (FilterSourceToggle.Checked)
				{
					Library lib = FilterSourceBox.SelectedItem as Library;
					if (!lib.Templates.Contains(ct))
						return false;
				}

				return true;
			}

			if (obj is NPC)
			{
				NPC npc = obj as NPC;

				bool outlier = false;
				diff = AI.GetThreatDifficulty(npc.Level, fPartyLevel);
				if ((diff == Difficulty.Trivial) || (diff == Difficulty.Extreme))
					outlier = true;

				if (outlier && FilterLevelAppropriateToggle.Checked)
					return false;

				if (FilterNameToggle.Checked && (fNameTokens != null))
				{
					string name = npc.Name.ToLower();

					foreach (string token in fNameTokens)
					{
						if (!name.Contains(token))
							return false;
					}
				}

				if (FilterCatToggle.Checked && (fCatTokens != null))
				{
					string cat = npc.Category.ToLower();

					foreach (string token in fCatTokens)
					{
						if (!cat.Contains(token))
							return false;
					}
				}

				if (FilterRoleToggle.Checked)
				{
					// Match on role
					RoleType role = (RoleType)FilterRoleBox.SelectedItem;

					if (npc.Role is ComplexRole)
					{
						ComplexRole cr = npc.Role as ComplexRole;
						if (cr.Type != role)
							return false;
					}

					if (npc.Role is Minion)
					{
						Minion m = npc.Role as Minion;
						if ((!m.HasRole) || (m.Type != role))
							return false;
					}
				}

				if (FilterOriginToggle.Checked)
				{
					CreatureOrigin origin = (CreatureOrigin)FilterOriginBox.SelectedItem;

					if (npc.Origin != origin)
						return false;
				}

				if (FilterTypeToggle.Checked)
				{
					CreatureType type = (CreatureType)FilterTypeBox.SelectedItem;

					if (npc.Type != type)
						return false;
				}

				if (FilterKeywordToggle.Checked && (fKeyTokens != null))
				{
					string keywords = (npc.Keywords != null) ? npc.Keywords.ToLower() : "";

					foreach (string token in fKeyTokens)
					{
						if (!keywords.Contains(token))
							return false;
					}
				}

				if (FilterLevelToggle.Checked)
				{
					if ((npc.Level < LevelFromBox.Value) || (npc.Level > LevelToBox.Value))
						return false;
				}

				#endregion

				return true;
			}

			if (obj is Trap)
			{
				Trap trap = obj as Trap;

				#region Trap

				bool outlier = false;
				diff = AI.GetThreatDifficulty(trap.Level, fPartyLevel);
				if ((diff == Difficulty.Trivial) || (diff == Difficulty.Extreme))
					outlier = true;

				if (outlier && FilterLevelAppropriateToggle.Checked)
					return false;

				if (FilterNameToggle.Checked && (fNameTokens != null))
				{
					string name = trap.Name.ToLower();

					foreach (string token in fNameTokens)
					{
						if (!name.Contains(token))
							return false;
					}
				}

				if (FilterCatToggle.Checked && (fCatTokens != null))
				{
					// Ignore category for traps
				}

				if (FilterRoleToggle.Checked)
				{
					// Match on role
					RoleType role = (RoleType)FilterRoleBox.SelectedItem;

					if (trap.Role is ComplexRole)
					{
						ComplexRole cr = trap.Role as ComplexRole;
						if (cr.Type != role)
							return false;
					}

					if (trap.Role is Minion)
					{
						Minion m = trap.Role as Minion;
						if ((!m.HasRole) || (m.Type != role))
							return false;
					}
				}

				if (FilterModToggle.Checked)
				{
					RoleFlag flag = RoleFlag.Standard;
					bool minion = false;

					if (FilterModBox.Text == "Standard")
					{
					}

					if (FilterModBox.Text == Session.I18N.Elite)
					{
						flag = RoleFlag.Elite;
					}

					if (FilterModBox.Text == "Solo")
					{
						flag = RoleFlag.Solo;
					}

					if (FilterModBox.Text == "Minion")
					{
						minion = true;
					}

					ComplexRole cr = trap.Role as ComplexRole;
					if (cr != null)
					{
						if (minion)
							return false;

						if (flag != cr.Flag)
							return false;
					}

					Minion m = trap.Role as Minion;
					if (m != null)
					{
						if (!minion)
							return false;
					}
				}

				if (FilterOriginToggle.Checked)
				{
					// Ignore origin for traps
				}

				if (FilterTypeToggle.Checked)
				{
					// Ignore type for traps
				}

				if (FilterKeywordToggle.Checked && (fKeyTokens != null))
				{
					// Ignore keywords for traps
				}

				if (FilterLevelToggle.Checked)
				{
					if ((trap.Level < LevelFromBox.Value) || (trap.Level > LevelToBox.Value))
						return false;
				}

				if (FilterSourceToggle.Checked)
				{
					Library lib = FilterSourceBox.SelectedItem as Library;
					if (!lib.Traps.Contains(trap))
						return false;
				}

				#endregion

				return true;
			}

			if (obj is SkillChallenge)
			{
				SkillChallenge sc = obj as SkillChallenge;

				#region Skill challenge

				if (FilterNameToggle.Checked && (fNameTokens != null))
				{
					string name = sc.Name.ToLower();

					foreach (string token in fNameTokens)
					{
						if (!name.Contains(token))
							return false;
					}
				}

				if (FilterCatToggle.Checked && (fCatTokens != null))
				{
					// Ignore category for skill challenges
				}

				if (FilterRoleToggle.Checked)
				{
					// Ignore roles for skill challenges
				}

				if (FilterOriginToggle.Checked)
				{
					// Ignore origin for skill challenges
				}

				if (FilterTypeToggle.Checked)
				{
					// Ignore type for skill challenges
				}

				if (FilterKeywordToggle.Checked && (fKeyTokens != null))
				{
					// Ignore keywords for skill challenges
				}

				if (FilterSourceToggle.Checked)
				{
					Library lib = FilterSourceBox.SelectedItem as Library;
					if (!lib.SkillChallenges.Contains(sc))
						return false;
				}

				#endregion

				return true;
			}

			return false;
		}

		public void Collapse()
		{
			open_close_editor(false);
		}

		public void Expand()
		{
			open_close_editor(true);
		}

		public void FilterByPartyLevel()
		{
			FilterLevelAppropriateToggle.Checked = true;
			OnFilterChanged();

			if (!FilterPnl.Visible)
				InfoLbl.Text = get_filter_string();
		}

		public bool SetFilter(int level, IRole role)
		{
			fSuppressEvents = true;

			bool set_filter = false;

			if (level != 0)
			{
				FilterLevelToggle.Checked = true;
				LevelFromBox.Value = level;
				LevelToBox.Value = level;

				set_filter = true;
			}

			if (role != null)
			{
				if (role is ComplexRole)
				{
					ComplexRole cr = role as ComplexRole;

					FilterRoleToggle.Checked = true;
					FilterRoleBox.SelectedItem = cr.Type;

					FilterModToggle.Checked = true;
					FilterModBox.SelectedItem = cr.Flag.ToString();

					set_filter = true;
				}

				if (role is Minion)
				{
					Minion minion = role as Minion;

					if (minion.HasRole)
					{
						FilterRoleToggle.Checked = true;
						FilterRoleBox.SelectedItem = minion.Type;
					}

					FilterModToggle.Checked = true;
					FilterModBox.SelectedItem = "Minion";

					set_filter = true;
				}
			}

			fSuppressEvents = false;

			if (set_filter)
			{
				update_option_state();

				OnFilterChanged();

				if (!FilterPnl.Visible)
					InfoLbl.Text = get_filter_string();
			}

			return set_filter;
		}

		#endregion

		#region Events

		public event EventHandler FilterChanged;

		protected void OnFilterChanged()
		{
			if (fSuppressEvents)
				return;

			if (FilterChanged != null)
				FilterChanged(this, new EventArgs());
		}

		#endregion

		#region Event handlers

		private void ToggleChanged(object sender, EventArgs e)
		{
			update_option_state();

			if ((sender == FilterNameToggle) && (FilterNameBox.Text == ""))
				return;

			if ((sender == FilterCatToggle) && (FilterCatBox.Text == ""))
				return;

			if ((sender == FilterKeywordToggle) && (FilterKeywordBox.Text == ""))
				return;

			if (sender == FilterLevelToggle)
				FilterLevelAppropriateToggle.Checked = false;

			if (sender == FilterLevelAppropriateToggle)
				FilterLevelToggle.Checked = false;

			OnFilterChanged();
		}

		private void TextOptionChanged(object sender, EventArgs e)
		{
			fNameTokens = FilterNameBox.Text.ToLower().Split(null);
			if (fNameTokens.Length == 0)
				fNameTokens = null;

			fCatTokens = FilterCatBox.Text.ToLower().Split(null);
			if (fCatTokens.Length == 0)
				fCatTokens = null;

			fKeyTokens = FilterKeywordBox.Text.ToLower().Split(null);
			if (fKeyTokens.Length == 0)
				fKeyTokens = null;

			OnFilterChanged();
		}

		private void DropdownOptionChanged(object sender, EventArgs e)
		{
			OnFilterChanged();
		}

		private void NumericOptionChanged(object sender, EventArgs e)
		{
			if (sender == LevelFromBox)
				LevelToBox.Minimum = LevelFromBox.Value;
			if (sender == LevelToBox)
				LevelFromBox.Maximum = LevelToBox.Value;

			OnFilterChanged();
		}

		private void EditLbl_Click(object sender, EventArgs e)
		{
			// Open / close the editor
			open_close_editor(!FilterPnl.Visible);
		}

		#endregion

		void update_allowed_filters()
		{
			FilterCatToggle.Enabled = ((fMode == ListMode.Creatures) || (fMode == ListMode.NPCs));
			FilterRoleToggle.Enabled = (fMode != ListMode.SkillChallenges);
			FilterModToggle.Enabled = ((fMode == ListMode.Creatures) || (fMode == ListMode.Traps));
			FilterOriginToggle.Enabled = ((fMode == ListMode.Creatures) || (fMode == ListMode.NPCs));
			FilterTypeToggle.Enabled = ((fMode == ListMode.Creatures) || (fMode == ListMode.NPCs));
			FilterKeywordToggle.Enabled = ((fMode == ListMode.Creatures) || (fMode == ListMode.NPCs));
			FilterLevelToggle.Enabled = ((fMode == ListMode.Creatures) || (fMode == ListMode.NPCs) || (fMode == ListMode.Traps));
			FilterLevelAppropriateToggle.Enabled = ((fPartyLevel != 0) && ((fMode == ListMode.Creatures) || (fMode == ListMode.NPCs) || (fMode == ListMode.Traps)));
			FilterSourceToggle.Enabled = ((Session.Libraries.Count != 0) && ((fMode == ListMode.Creatures) || (fMode == ListMode.Templates) || (fMode == ListMode.Traps) || (fMode == ListMode.SkillChallenges)));
		}

		void update_option_state()
		{
			FilterNameBox.Enabled = FilterNameToggle.Checked;
			FilterCatBox.Enabled = (FilterCatToggle.Enabled && FilterCatToggle.Checked);
			FilterRoleBox.Enabled = (FilterRoleToggle.Enabled && FilterRoleToggle.Checked);
			FilterModBox.Enabled = (FilterModToggle.Enabled && FilterModToggle.Checked);
			FilterOriginBox.Enabled = (FilterOriginToggle.Enabled && FilterOriginToggle.Checked);
			FilterTypeBox.Enabled = (FilterTypeToggle.Enabled && FilterTypeToggle.Checked);
			FilterKeywordBox.Enabled = (FilterKeywordToggle.Enabled && FilterKeywordToggle.Checked);
			FilterSourceBox.Enabled = (FilterSourceToggle.Enabled && FilterSourceToggle.Checked);

			FromLbl.Enabled = (FilterLevelToggle.Enabled && FilterLevelToggle.Checked);
			ToLbl.Enabled = (FilterLevelToggle.Enabled && FilterLevelToggle.Checked);
			LevelFromBox.Enabled = (FilterLevelToggle.Enabled && FilterLevelToggle.Checked);
			LevelToBox.Enabled = (FilterLevelToggle.Enabled && FilterLevelToggle.Checked);
		}

		void open_close_editor(bool open)
		{
			if (open)
			{
				FilterPnl.Visible = true;

				InfoLbl.Text = "";
				EditLbl.Text = "Collapse";
			}
			else
			{
				FilterPnl.Visible = false;

				InfoLbl.Text = get_filter_string();
				EditLbl.Text = "Expand";
			}
		}

		string get_filter_string()
		{
			string str = "";

			if (FilterNameToggle.Checked && FilterNameToggle.Enabled && (FilterNameBox.Text != ""))
			{
				if (str != "")
					str += "; ";

				str += "Name: " + FilterNameBox.Text;
			}

			if (FilterCatToggle.Checked && FilterCatToggle.Enabled && (FilterCatBox.Text != ""))
			{
				if (str != "")
					str += "; ";

				str += "Category: " + FilterCatBox.Text;
			}

			string role = "";
			if (FilterModToggle.Checked && FilterModToggle.Enabled)
			{
				role += FilterModBox.SelectedItem;
			}
			if (FilterRoleToggle.Checked && FilterRoleToggle.Enabled)
			{
				if (role != "")
					role += " ";

				role += FilterRoleBox.SelectedItem;
			}
			if (role != "")
			{
				if (str != "")
					str += "; ";

				str += "Role: " + role;
			}

			if (FilterTypeToggle.Checked && FilterTypeToggle.Enabled)
			{
				if (str != "")
					str += "; ";

				str += "Type: " + FilterTypeBox.SelectedItem;
			}

			if (FilterOriginToggle.Checked && FilterOriginToggle.Enabled)
			{
				if (str != "")
					str += "; ";

				str += "Origin: " + FilterOriginBox.SelectedItem;
			}

			if (FilterKeywordToggle.Checked && FilterKeywordToggle.Enabled && (FilterKeywordBox.Text != ""))
			{
				if (str != "")
					str += "; ";

				str += "Keywords: " + FilterKeywordBox.Text;
			}

			if (FilterLevelToggle.Checked && FilterLevelToggle.Enabled)
			{
				if (str != "")
					str += "; ";

				int lvl_from = (int)LevelFromBox.Value;
				int lvl_to = (int)LevelToBox.Value;
				if (lvl_from == lvl_to)
					str += "Level: " + lvl_from;
				else
					str += "Level: " + lvl_from + "-" + lvl_to;
			}

			if (FilterLevelAppropriateToggle.Checked && FilterLevelAppropriateToggle.Enabled)
			{
				if (str != "")
					str += "; ";

				str += "Level-appropriate only";
			}

			if (FilterSourceToggle.Checked && FilterSourceToggle.Enabled)
			{
				if (str != "")
					str += "; ";

				str += "Source: " + FilterSourceBox.SelectedItem;
			}

			return str;
		}
	}
}
