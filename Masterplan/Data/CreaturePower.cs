using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

using Masterplan.Properties;
using Masterplan.Tools;

namespace Masterplan.Data
{
	#region Enumerations

	/// <summary>
	/// Enumeration containing the possible power categories for stat block grouping.
	/// </summary>
	public enum CreaturePowerCategory
	{
		/// <summary>
		/// Trait.
		/// </summary>
		Trait,

		/// <summary>
		/// Standard action.
		/// </summary>
		Standard,

		/// <summary>
		/// Move action.
		/// </summary>
		Move,

		/// <summary>
		/// Minor action.
		/// </summary>
		Minor,

		/// <summary>
		/// Free action.
		/// </summary>
		Free,

		/// <summary>
		/// Triggered action.
		/// </summary>
		Triggered,

		/// <summary>
		/// Other powers.
		/// </summary>
		Other
	}

	/// <summary>
	/// Enumeration containing the possible defences.
	/// </summary>
	public enum DefenceType
	{
		/// <summary>
		/// Armour Class.
		/// </summary>
		AC,

		/// <summary>
		/// Fortitude.
		/// </summary>
		Fortitude,
		
		/// <summary>
		/// Reflex.
		/// </summary>
		Reflex,
		
		/// <summary>
		/// Will.
		/// </summary>
		Will
	}

	/// <summary>
	/// Enumeration containing the possible action types.
	/// </summary>
	public enum ActionType
	{
		/// <summary>
		/// No action.
		/// </summary>
		None,
		
		/// <summary>
		/// Standard action.
		/// </summary>
		Standard,
		
		/// <summary>
		/// Move action.
		/// </summary>
		Move,
		
		/// <summary>
		/// Minor action.
		/// </summary>
		Minor,
		
		/// <summary>
		/// Immediate reaction.
		/// </summary>
		Reaction,
		
		/// <summary>
		/// Immediate interrupt.
		/// </summary>
		Interrupt,
		
		/// <summary>
		/// Opportunity action.
		/// </summary>
		Opportunity,
		
		/// <summary>
		/// Free action.
		/// </summary>
		Free
	}

	/// <summary>
	/// Normal / limited damage.
	/// </summary>
	public enum DamageCategory
	{
		/// <summary>
		/// Normal damage.
		/// </summary>
		Normal,

		/// <summary>
		/// Limited damage.
		/// </summary>
		Limited
	}

	/// <summary>
	/// Low / medium / high damage.
	/// </summary>
	public enum DamageDegree
	{
		/// <summary>
		/// Low damage.
		/// </summary>
		Low,
		
		/// <summary>
		/// Medium damage.
		/// </summary>
		Medium,
		
		/// <summary>
		/// High damage.
		/// </summary>
		High
	}

	/// <summary>
	/// The usage type for a power.
	/// </summary>
	public enum PowerUseType
	{
		/// <summary>
		/// Per encounter usage.
		/// </summary>
		Encounter,

		/// <summary>
		/// At will usage.
		/// </summary>
		AtWill,

		/// <summary>
		/// Basic attack.
		/// </summary>
		Basic,

		/// <summary>
		/// Daily usage.
		/// </summary>
		Daily
	}

	#endregion

	/// <summary>
	/// Class representing a power.
	/// This class should be used in preference to the Power class.
	/// </summary>
	[Serializable]
	public class CreaturePower : IComparable<CreaturePower>
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CreaturePower()
		{
		}

		/// <summary>
		/// Gets or sets the power's unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the power's name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the action the power requires.
		/// </summary>
		public PowerAction Action
		{
			get { return fAction; }
			set { fAction = value; }
		}
		PowerAction fAction = null;

		/// <summary>
		/// Gets or sets the keywords for the power.
		/// </summary>
		public string Keywords
		{
			get { return fKeywords; }
			set { fKeywords = value; }
		}
		string fKeywords = "";

		/// <summary>
		/// Gets or sets the condition required for the power.
		/// </summary>
		public string Condition
		{
			get { return fCondition; }
			set { fCondition = value; }
		}
		string fCondition = "";

		/// <summary>
		/// Gets or sets the power's range.
		/// </summary>
		public string Range
		{
			get { return fRange; }
			set { fRange = value; }
		}
		string fRange = "";

		/// <summary>
		/// Gets or sets the attack bonus and defence targeted by the power.
		/// </summary>
		public PowerAttack Attack
		{
			get { return fAttack; }
			set { fAttack = value; }
		}
		PowerAttack fAttack = null;

		/// <summary>
		/// Gets or sets the power's read-aloud description.
		/// </summary>
		public string Description
		{
			get { return fDescription; }
			set { fDescription = value; }
		}
		string fDescription = "";

		/// <summary>
		/// Gets or sets the power details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets the power's damage expression.
		/// </summary>
		public string Damage
		{
			get
			{
				return AI.ExtractDamage(fDetails);
			}
		}

		/// <summary>
		/// Creates a copy of the power.
		/// </summary>
		/// <returns></returns>
		public CreaturePower Copy()
		{
			CreaturePower cp = new CreaturePower();

			cp.ID = fID;
			cp.Name = fName;
			cp.Action = (fAction != null) ? fAction.Copy() : null;
			cp.Keywords = fKeywords;
			cp.Condition = fCondition;
			cp.Range = fRange;
			cp.Attack = (fAttack != null) ? fAttack.Copy() : null;
			cp.Description = fDescription;
			cp.Details = fDetails;

			return cp;
		}

		/// <summary>
		/// Gets the category of power for use in grouping actions in the stat block.
		/// </summary>
		public CreaturePowerCategory Category
		{
			get
			{
				if (fAction == null)
					return CreaturePowerCategory.Trait;

				if ((fAction.Trigger != null) && (fAction.Trigger != ""))
					return CreaturePowerCategory.Triggered;

				switch (fAction.Action)
				{
					case ActionType.Interrupt:
					case ActionType.Opportunity:
					case ActionType.Reaction:
						return CreaturePowerCategory.Triggered;
					case ActionType.Free:
						return CreaturePowerCategory.Free;
					case ActionType.Minor:
						return CreaturePowerCategory.Minor;
					case ActionType.Move:
						return CreaturePowerCategory.Move;
					case ActionType.Standard:
						return CreaturePowerCategory.Standard;
				}

				return CreaturePowerCategory.Other;
			}
		}

		/// <summary>
		/// Used for sorting.
		/// </summary>
		/// <param name="rhs">The CreaturePower to compare to.</param>
		/// <returns>Returns -1 if this object should be sorted before rhs, +1 if rhs should be sorted before this, 0 otherwise.</returns>
		public int CompareTo(CreaturePower rhs)
		{
			bool lhs_basic = false;
			bool rhs_basic = false;

			if ((fAction != null) && (fAction.Use == PowerUseType.Basic))
				lhs_basic = true;

			if ((rhs.Action != null) && (rhs.Action.Use == PowerUseType.Basic))
				rhs_basic = true;

			if (lhs_basic != rhs_basic)
			{
				// Sort basic attack power before other powers

				if (lhs_basic)
					return -1;

				if (rhs_basic)
					return 1;
			}

			if (lhs_basic && rhs_basic)
			{
				bool lhs_melee = fRange.ToLower().Contains(Session.I18N.LowerMelee);
				bool rhs_melee = rhs.Range.ToLower().Contains(Session.I18N.LowerMelee);

				if (lhs_melee != rhs_melee)
				{
					// Sort melee basic before ranged basic

					if (lhs_melee)
						return -1;

					if (rhs_melee)
						return 1;
				}
			}

			if (!lhs_basic && !rhs_basic)
			{
				bool lhs_double = fRange.ToLower().Contains(Session.I18N.LowerDouble);
				bool rhs_double = rhs.Range.ToLower().Contains(Session.I18N.LowerDouble);

				if (lhs_double != rhs_double)
				{
					// Sort X before Double X

					if (lhs_double)
						return -1;

					if (rhs_double)
						return 1;
				}
			}

			return fName.CompareTo(rhs.Name);
		}

		/// <summary>
		/// Returns the name of the power.
		/// </summary>
		/// <returns>Returns the name of the power.</returns>
		public override string ToString()
		{
			return fName;
		}

		/// <summary>
		/// Returns the HTML representation of the power.
		/// </summary>
		/// <param name="cd">The CombatData to use.</param>
		/// <param name="mode">The type of HTML to generate</param>
		/// <param name="functional_template">True if this power is from a functional template; false otherwise</param>
		/// <returns>Returns the HTML source code.</returns>
		public List<string> AsHTML(CombatData cd, CardMode mode, bool functional_template)
		{
			bool used = ((mode == CardMode.Combat) && (cd != null) && cd.UsedPowers.Contains(fID));

			string cat = Session.I18N.Actions;
			switch (Category)
			{
				case CreaturePowerCategory.Trait:
					cat = Session.I18N.Traits;
					break;
				case CreaturePowerCategory.Standard:
					cat = Session.I18N.StandardActions;
					break;
				case CreaturePowerCategory.Move:
					cat = Session.I18N.MoveActions;
					break;
				case CreaturePowerCategory.Minor:
					cat = Session.I18N.MinorActions;
					break;
				case CreaturePowerCategory.Free:
					cat = Session.I18N.FreeActions;
					break;
				case CreaturePowerCategory.Triggered:
					cat = Session.I18N.TriggeredActions;
					break;
				case CreaturePowerCategory.Other:
					cat = Session.I18N.OtherActions;
					break;
			}

			List<string> content = new List<string>();

			if (mode == CardMode.Build)
			{
				content.Add("<TR class=creature>");
				content.Add("<TD colspan=3>");
				content.Add("<A href=power:action style=\"color:white\"><B>" + cat + "</B> (" + Session.I18N.LabelChangeAction + ")</A>");
				content.Add("</TD>");
				content.Add("</TR>");
			}

			if (!used)
				content.Add("<TR class=shaded>");
			else
				content.Add("<TR class=shaded_dimmed>");
			content.Add("<TD colspan=3>");
			content.Add(power_topline(cd, mode));
			content.Add("</TD>");
			content.Add("</TR>");

			if (!used)
				content.Add("<TR>");
			else
				content.Add("<TR class=dimmed>");
			content.Add("<TD colspan=3>");
			content.Add(power_content(mode));
			content.Add("</TD>");
			content.Add("</TR>");

			if (mode == CardMode.Combat)
			{
				if (used)
				{
					content.Add("<TR>");
					content.Add("<TD class=indent colspan=3>");
					content.Add("<A href=\"refresh:" + cd.ID + ";" + fID + "\">(" + Session.I18N.LabelRechargePower + ")</A>");
					content.Add("</TD>");
					content.Add("</TR>");
				}
				else
				{
					if (fAction != null)
					{
						if ((fAction.Use == PowerUseType.Encounter) || (fAction.Use == PowerUseType.Daily))
						{
							content.Add("<TR>");
							content.Add("<TD class=indent colspan=3>");
							content.Add("<A href=\"refresh:" + cd.ID + ";" + fID + "\">(" + Session.I18N.LabelUsePower + ")</A>");
							content.Add("</TD>");
							content.Add("</TR>");
						}
					}
				}
			}

			if (functional_template)
			{
				content.Add("<TR class=shaded>");
				content.Add("<TD colspan=3>");
				content.Add("<B>" + Session.I18N.Note + "</B>: " + Session.I18N.LabelNotePower);
				content.Add("</TD>");
				content.Add("</TR>");
			}

			return content;
		}

		string power_topline(CombatData cd, CardMode mode)
		{
			string str = "";

			Image icon = null;
			string rng = fRange.ToLower();
			if (rng.Contains(Session.I18N.LowerMelee))
			{
				if ((fAction != null) && (fAction.Use == PowerUseType.Basic))
					icon = Resources.MeleeBasic;
				else
					icon = Resources.Melee;
			}
			if (rng.Contains(Session.I18N.LowerRanged))
			{
				if ((fAction != null) && (fAction.Use == PowerUseType.Basic))
					icon = Resources.RangedBasic;
				else
					icon = Resources.Ranged;
			}
			if (rng.Contains(Session.I18N.LowerArea))
			{
				icon = Resources.Area;
			}
			if (rng.Contains(Session.I18N.LowerClose))
			{
				icon = Resources.Close;
			}
			if ((icon == null) && (fAttack != null) && (fAction != null))
			{
				if (fAction.Use == PowerUseType.Basic)
					icon = Resources.MeleeBasic;
				else
					icon = Resources.Melee;
			}

			str += "<B>" + HTML.Process(fName, true) + "</B>";
			if ((mode == CardMode.Combat) && (cd != null))
			{
				bool create_link = false;

				if (!cd.UsedPowers.Contains(fID))
				{
					if (fAttack != null)
						create_link = true;

					if ((fAction != null) && (fAction.Use == PowerUseType.Encounter))
						create_link = true;
				}

				if (create_link)
					str = "<A href=\"power:" + cd.ID + ";" + fID + "\">" + str + "</A>";
			}
			if (mode == CardMode.Build)
			{
				str = "<A href=power:info>" + str + "</A>";
			}

			if (icon != null)
			{
				MemoryStream ms = new MemoryStream();
				icon.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
				byte[] byteImage = ms.ToArray();
				string data = Convert.ToBase64String(byteImage);
				if ((data != null) && (data != ""))
					str = "<img src=data:image/png;base64," + data + ">" + str;
			}

			if (fKeywords != "")
			{
				string keywords = HTML.Process(fKeywords, true);
				if (mode == CardMode.Build)
					keywords = "<A href=power:info>" + keywords + "</A>";

				str += " (" + keywords + ")";
			}

			string info = power_parenthesis(mode);
			if (info != "")
				str += " &diams; " + info;

			return str;
		}

		string power_parenthesis(CardMode mode)
		{
			if ((fCondition == "") && (fAction == null))
				return "";

			string info = "";
			if (fAction != null)
			{
				string action = fAction.ToString();
				if (mode == CardMode.Build)
					action = "<A href=power:action>" + action + "</A>";

				info += action;
			}

			return info;
		}

		string power_content(CardMode mode)
		{
			List<string> lines = new List<string>();

			string desc = "";
			if (fDescription != null)
				desc = HTML.Process(fDescription, true);
			if (desc == null)
				desc = "";
			if (mode == CardMode.Build)
			{
				if (desc == "")
					desc = Session.I18N.LabelReadAloud;

				desc = "<A href=power:desc>" + desc + "</A>";
			}
			if (desc != "")
				lines.Add("<I>" + desc + "</I>");

			if (mode == CardMode.Build)
				lines.Add("");

			if ((fAction != null) && (fAction.Trigger != ""))
			{
				string action;
				switch (fAction.Action)
				{
					case ActionType.Interrupt:
						action = Session.I18N.ImmediateInterrupt;
						break;
					case ActionType.None:
						action = Session.I18N.NoAction;
						break;
					case ActionType.Reaction:
						action = Session.I18N.ImmediateReaction;
						break;
					default:
						action = fAction.Action.ToString().ToLower() + " " + Session.I18N.Action;
						break;
				}

				if (mode != CardMode.Build)
				{
					lines.Add("Trigger (" + action + "): " + fAction.Trigger);
				}
				else
				{
					lines.Add("Trigger (<A href=power:action>" + action + "</A>): <A href=power:action>" + fAction.Trigger + "</A>");
				}
			}

			string condition = HTML.Process(fCondition, true);
			if ((condition == "") && (mode == CardMode.Build))
				condition = Session.I18N.NoPrerequisite;
			if (condition != "")
			{
				if (mode == CardMode.Build)
					condition = "<A href=power:prerequisite>" + condition + "</A>";

				condition = Session.I18N.Prerequisite + ": " + condition;

				lines.Add(condition);
			}

			string range = (fRange != null) ? fRange : "";
			string attack = (fAttack != null) ? fAttack.ToString() : "";
			if (mode == CardMode.Build)
			{
				if (range == "")
					range = "<A href=power:range>" + Session.I18N.LabelNoRange + "</A>";
				else
					range = "<A href=power:range>" + range + "</A>";

				if (attack == "")
					attack = "<A href=power:attack>"+ Session.I18N.LabelSetAttack + "</A>";
				else
					attack = "<A href=power:attack>" + attack + "</A> <A href=power:clearattack>(" + Session.I18N.ClearAttack + ")</A>";
			}
			if (range != "")
				lines.Add(Session.I18N.Range + ": " + range);
			if (attack != "")
				lines.Add(Session.I18N.Attack + ": " + attack);

			if (mode == CardMode.Build)
				lines.Add("");

			string details = HTML.Process(fDetails, true);
			if (details == null)
				details = "";
			if (mode == CardMode.Build)
			{
				if (details == "")
					details = Session.I18N.LabelSpecPowEff;

				details = "<A href=power:details>" + details + "</A>";
			}
			if (details != "")
				lines.Add(details);

			if (mode == CardMode.Build)
				lines.Add("");

			if ((fAction != null) && (fAction.SustainAction != ActionType.None))
			{
				string sustain = fAction.SustainAction.ToString();

				if (mode == CardMode.Build)
					sustain = "<A href=power:action>" + sustain + "</A>";

				lines.Add(Session.I18N.Sustain + ": " + sustain);
			}

			string str = "";
			foreach (string line in lines)
			{
				if (str != "")
					str += "<BR>";

				str += line;
			}

			if (str == "")
				str = Session.I18N.NoDetails;

			return str;
		}

		/// <summary>
		/// Parses the power details field to find the attack data (+N vs Defence).
		/// </summary>
		public void ExtractAttackDetails()
		{
			if (fAttack != null)
				return;

			if (!fDetails.Contains("vs"))
				return;

			string[] sections = fDetails.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
			fDetails = "";

			foreach (string section in sections)
			{
				string str = section.Trim();

				bool added_attack = false;

				int index = str.IndexOf("vs");
				if ((index != -1) && (fAttack == null))
				{
					string prefix = str.Substring(0, index);
					string suffix = str.Substring(index);

					string digits = "1234567890";
					int start = prefix.LastIndexOfAny(digits.ToCharArray());
					if (start != -1)
					{
						int bonus = 0;
						DefenceType defence = DefenceType.AC;
						bool found_bonus = false;
						bool found_defence = false;

						if (suffix.Contains(Session.I18N.AC))
						{
							defence = DefenceType.AC;
							found_defence = true;
						}
						if (suffix.Contains(Session.I18N.Fort))
						{
							defence = DefenceType.Fortitude;
							found_defence = true;
						}
						if (suffix.Contains(Session.I18N.Ref))
						{
							defence = DefenceType.Reflex;
							found_defence = true;
						}
						if (suffix.Contains(Session.I18N.Will))
						{
							defence = DefenceType.Will;
							found_defence = true;
						}

						if (found_defence)
						{
							try
							{
								start = Math.Max(0, start - 2);
								string bonus_str = prefix.Substring(start);
								bonus = int.Parse(bonus_str);
								found_bonus = true;
							}
							catch
							{
								found_bonus = false;
							}
						}

						if (found_bonus && found_defence)
						{
							fAttack = new PowerAttack();
							fAttack.Bonus = bonus;
							fAttack.Defence = defence;

							added_attack = true;
						}

					}
				}

				if (!added_attack)
				{
					if (fDetails != "")
						fDetails += "; ";

					fDetails += str;
				}
			}
		}
	}

	/// <summary>
	/// Class containing action / usage data for a CreaturePower.
	/// </summary>
	[Serializable]
	public class PowerAction
	{
		/// <summary>
		/// Recharge 2-6.
		/// </summary>
		public static string RECHARGE_2 = Session.I18N.RechargesOn + "2-6";

		/// <summary>
		/// Recharge 3-6.
		/// </summary>
		public static string RECHARGE_3 = Session.I18N.RechargesOn + "3-6";

		/// <summary>
		/// Recharge 4-6.
		/// </summary>
		public static string RECHARGE_4 = Session.I18N.RechargesOn + "4-6";

		/// <summary>
		/// Recharge 5-6.
		/// </summary>
		public static string RECHARGE_5 = Session.I18N.RechargesOn + "5-6";

		/// <summary>
		/// Recharge 6.
		/// </summary>
		public static string RECHARGE_6 = Session.I18N.RechargesOn + "6";

		/// <summary>
		/// Gets or sets the action required to use the power.
		/// </summary>
		public ActionType Action
		{
			get { return fAction; }
			set { fAction = value; }
		}
		ActionType fAction = ActionType.Standard;

		/// <summary>
		/// Gets or sets the trigger for an immediate reaction or interrupt.
		/// </summary>
		public string Trigger
		{
			get { return fTrigger; }
			set { fTrigger = value; }
		}
		string fTrigger = "";

		/// <summary>
		/// Gets or sets the action required to sustain the power.
		/// </summary>
		public ActionType SustainAction
		{
			get { return fSustainAction; }
			set { fSustainAction = value; }
		}
		ActionType fSustainAction = ActionType.None;

		/// <summary>
		/// Gets or sets the power's type (basic attack, at will, or encounter)
		/// </summary>
		public PowerUseType Use
		{
			get { return fUse; }
			set { fUse = value; }
		}
		PowerUseType fUse = PowerUseType.AtWill;

		/// <summary>
		/// Gets or sets the recharge condition.
		/// </summary>
		public string Recharge
		{
			get { return fRecharge; }
			set { fRecharge = value; }
		}
		string fRecharge = "";

		/// <summary>
		/// Creates a copy of the PowerAttack.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public PowerAction Copy()
		{
			PowerAction pa = new PowerAction();

			pa.Action = fAction;
			pa.Trigger = fTrigger;
			pa.SustainAction = fSustainAction;
			pa.Use = fUse;
			pa.Recharge = fRecharge;

			return pa;
		}

		/// <summary>
		/// Gets a string representation of the PowerAttack.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string str = "";

			if ((fUse == PowerUseType.AtWill) || (fUse == PowerUseType.Basic))
			{
				str = Session.I18N.AtWill;

				if (fUse == PowerUseType.Basic)
					str += " " + Session.I18N.BasicAttack;
			}

			if ((fUse == PowerUseType.Encounter) && (fRecharge == ""))
				str = Session.I18N.Encounter;

			if (fUse == PowerUseType.Daily)
				str = Session.I18N.Daily;

			if (fRecharge != "")
			{
				if (str != "")
					str += "; ";

				str += fRecharge;
			}

			return str;
		}
	}

	/// <summary>
	/// Class containing attack data for a power.
	/// </summary>
	[Serializable]
	public class PowerAttack
	{
		/// <summary>
		/// Gets or sets the attack bonus.
		/// </summary>
		public int Bonus
		{
			get { return fBonus; }
			set { fBonus = value; }
		}
		int fBonus = 0;

		/// <summary>
		/// Gets or sets the targeted defence.
		/// </summary>
		public DefenceType Defence
		{
			get { return fDefence; }
			set { fDefence = value; }
		}
		DefenceType fDefence = DefenceType.AC;

		/// <summary>
		/// Creates a copy of the PowerAttack.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public PowerAttack Copy()
		{
			PowerAttack pa = new PowerAttack();

			pa.Bonus = fBonus;
			pa.Defence = fDefence;

			return pa;
		}

		/// <summary>
		/// [bonus] vs [defence]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string sign = (fBonus >= 0) ? "+" : "";
			return sign + fBonus + " vs " + fDefence;
		}
	}
}
