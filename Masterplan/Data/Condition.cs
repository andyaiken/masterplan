using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Ongoing condition / damage.
	/// </summary>
	public enum OngoingType
	{
		/// <summary>
		/// Ongoing condition.
		/// </summary>
		Condition,

		/// <summary>
		/// Ongoing damage.
		/// </summary>
		Damage,

		/// <summary>
		/// Modifier to defences.
		/// </summary>
		DefenceModifier,

		/// <summary>
		/// Damage resistance, vulnerability or immunity.
		/// </summary>
		DamageModifier,

		/// <summary>
		/// Regeneration.
		/// </summary>
		Regeneration,

		/// <summary>
		/// An aura.
		/// </summary>
		Aura
	}

	/// <summary>
	/// Specifies how an ongoing condition can end.
	/// </summary>
	public enum DurationType
	{
		/// <summary>
		/// Lasts for the duration of the encounter.
		/// </summary>
		Encounter,

		/// <summary>
		/// Lasts until a successful save is made.
		/// </summary>
		SaveEnds,

		/// <summary>
		/// Lasts until the beginning of a creature's / PC's turn.
		/// </summary>
		BeginningOfTurn,

		/// <summary>
		/// Lasts until the end of a creature's / PC's turn.
		/// </summary>
		EndOfTurn
	}

	/// <summary>
	/// Class representing an ongoing combat effect.
	/// </summary>
	[Serializable]
	public class OngoingCondition : IComparable<OngoingCondition>
	{
		/// <summary>
		/// Gets or sets the type of condition.
		/// </summary>
		public OngoingType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		OngoingType fType = OngoingType.Condition;

		#region Condition

		/// <summary>
		/// Gets or sets the condition.
		/// </summary>
		public string Data
		{
			get { return fData; }
			set { fData = value; }
		}
		string fData = "";

		#endregion

		#region Ongoing damage

		/// <summary>
		/// Gets or sets the type of the damage.
		/// </summary>
		public DamageType DamageType
		{
			get { return fDamageType; }
			set { fDamageType = value; }
		}
		DamageType fDamageType = DamageType.Untyped;

		/// <summary>
		/// Gets or sets the value of the damage.
		/// </summary>
		public int Value
		{
			get { return fValue; }
			set { fValue = value; }
		}
		int fValue = 2;

		#endregion

		#region Defence mods

		/// <summary>
		/// Gets or sets the value of the defence modifier.
		/// </summary>
		public int DefenceMod
		{
			get { return fDefenceMod; }
			set { fDefenceMod = value; }
		}
		int fDefenceMod = 2;

		/// <summary>
		/// Gets or sets the defences to be modified.
		/// </summary>
		public List<DefenceType> Defences
		{
			get { return fDefences; }
			set { fDefences = value; }
		}
		List<DefenceType> fDefences = new List<DefenceType>();

		#endregion

		#region Regeneration

		/// <summary>
		/// Gets or sets the regeneration.
		/// </summary>
		public Regeneration Regeneration
		{
			get { return fRegeneration; }
			set { fRegeneration = value; }
		}
		Regeneration fRegeneration = new Regeneration();

		#endregion

		#region Damage modifier

		/// <summary>
		/// Gets or sets the damage modifier.
		/// </summary>
		public DamageModifier DamageModifier
		{
			get { return fDamageModifier; }
			set { fDamageModifier = value; }
		}
		DamageModifier fDamageModifier = new DamageModifier();

		#endregion

		#region Aura

		/// <summary>
		/// Gets or sets the aura.
		/// </summary>
		public Aura Aura
		{
			get { return fAura; }
			set { fAura = value; }
		}
		Aura fAura = new Aura();

		#endregion

		#region Duration

		/// <summary>
		/// Gets or sets the duration of the condition.
		/// </summary>
		public DurationType Duration
		{
			get { return fDuration; }
			set { fDuration = value; }
		}
		DurationType fDuration = DurationType.SaveEnds;

		/// <summary>
		/// Gets or sets the creature the condition is dependent on.
		/// This is one of the following:
		/// The ID of the CombatData representing the creature
		/// The ID of the Hero representing the PC
		/// The ID of the Trap
		/// </summary>
		public Guid DurationCreatureID
		{
			get { return fDurationCreatureID; }
			set { fDurationCreatureID = value; }
		}
		Guid fDurationCreatureID = Guid.Empty;

		/// <summary>
		/// Gets or sets the minimum round on which durations will end.
		/// This is used for beginning of turn / end of turn durations.
		/// </summary>
		public int DurationRound
		{
			get { return fDurationRound; }
			set { fDurationRound = value; }
		}
		int fDurationRound = int.MinValue;

		/// <summary>
		/// Gets or sets the saving throw modifier.
		/// </summary>
		public int SavingThrowModifier
		{
			get { return fSavingThrowModifier; }
			set { fSavingThrowModifier = value; }
		}
		int fSavingThrowModifier = 0;

		/// <summary>
		/// Returns the duration of the effect as a string.
		/// </summary>
		/// <param name="enc">The encounter.</param>
		/// <returns></returns>
		public string GetDuration(Encounter enc)
		{
			string str = "";

			switch (fDuration)
			{
				case DurationType.Encounter:
					// Effectively, does not end
					break;
				case DurationType.SaveEnds:
					{
						str = "save ends";

						if (SavingThrowModifier != 0)
						{
							string sign = (SavingThrowModifier >= 0) ? "+" : "";
							str += " with " + sign + SavingThrowModifier + " mod";
						}
					}
					break;
				case DurationType.BeginningOfTurn:
					{
						string name = "";
						if (fDurationCreatureID == Guid.Empty)
						{
							name = "someone else's";
						}
						else
						{
							if (enc != null)
							{
								name = enc.WhoIs(fDurationCreatureID) + "'s";
							}
							else
							{
								name = "my";
							}
						}

						str += "until the start of " + name + " next turn";
					}
					break;
				case DurationType.EndOfTurn:
					{
						string name = "";
						if (fDurationCreatureID == Guid.Empty)
						{
							name = "someone else's";
						}
						else
						{
							if (enc != null)
							{
								name = enc.WhoIs(fDurationCreatureID) + "'s";
							}
							else
							{
								name = "my";
							}
						}

						str += "until the end of " + name + " next turn";
					}
					break;
			}

			return str;
		}

		#endregion

		/// <summary>
		/// [blinded / marked / etc]
		/// or
		/// N ongoing [fire / cold etc] damage
		/// or
		/// +N to [defences]
		/// or
		/// Regeneration N
		/// or
		/// [Resist / Vulnerable / Immune] N [fire / cold etc]
		/// plus end condition data
		/// </summary>
		/// <param name="enc">The encounter.</param>
		/// <param name="html">Whether the string should include HTML tags.</param>
		/// <returns></returns>
		public string ToString(Encounter enc, bool html)
		{
			string str = ToString();

			if (html)
				str = "<B>" + str + "</B>";

			string duration = GetDuration(enc);
			if (duration != "")
				str += " (" + duration + ")";

			return str;
		}

		/// <summary>
		/// [blinded / marked / etc]
		/// or
		/// N ongoing [fire / cold etc] damage
		/// or
		/// +N to [defences]
		/// or
		/// Regeneration N
		/// or
		/// [Resist / Vulnerable / Immune] N [fire / cold etc]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string str = "";

			switch (fType)
			{
				case OngoingType.Condition:
					str = fData;
					break;
				case OngoingType.Damage:
					{
						if (fDamageType == DamageType.Untyped)
						{
							str = fValue + " " + Session.I18N.OngoingDamage;
						}
						else
						{
							string dmg = fDamageType.ToString().ToLower();
							str = fValue + " " + Session.I18N.Ongoing + " " + dmg + " " + Session.I18N.Damage;
						}
					}
					break;
				case OngoingType.DefenceModifier:
					{
						str = fDefenceMod.ToString();
						if (fDefenceMod >= 0)
							str = "+" + str;

						string defences = "";
						if (fDefences.Count == 4)
						{
							defences = Session.I18N.OngoingDefences;
						}
						else
						{
							foreach (DefenceType type in fDefences)
							{
								if (defences != "")
									defences += ", ";

								defences += type.ToString();
							}
						}

						str += " " + Session.I18N.To + " " + defences;
					}
					break;
				case OngoingType.DamageModifier:
					str = fDamageModifier.ToString();
					break;
				case OngoingType.Regeneration:
					str = Session.I18N.Regeneration + " " + fRegeneration.Value;
					break;
				case OngoingType.Aura:
					str = Session.I18N.Aura + " " + fAura.Radius + ": " + fAura.Description;
					break;
			}

			return str;
		}

		/// <summary>
		/// Creates a copy of the condition.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public OngoingCondition Copy()
		{
			OngoingCondition oc = new OngoingCondition();

			oc.Type = fType;

			oc.Data = fData;
			
			oc.DamageType = fDamageType;
			oc.Value = fValue;
			
			oc.DefenceMod = fDefenceMod;
			oc.Defences = new List<DefenceType>();
			foreach (DefenceType type in fDefences)
				oc.fDefences.Add(type);

			oc.Regeneration = (fRegeneration != null) ? fRegeneration.Copy() : null;
			oc.DamageModifier = (fDamageModifier != null) ? fDamageModifier.Copy() : null;
			oc.Aura = (fAura != null) ? fAura.Copy() : null;

			oc.Duration = fDuration;
			oc.DurationCreatureID = fDurationCreatureID;
			oc.DurationRound = fDurationRound;
			oc.SavingThrowModifier = fSavingThrowModifier;

			return oc;
		}

		/// <summary>
		/// Compares this condition to another.
		/// </summary>
		/// <param name="rhs">The other condition.</param>
		/// <returns>Returns -1 if this condition should be sorted before the other, +1 if the other should be sorted before this; 0 otherwise.</returns>
		public int CompareTo(OngoingCondition rhs)
		{
			return ToString().CompareTo(rhs.ToString());
		}
	}
}
