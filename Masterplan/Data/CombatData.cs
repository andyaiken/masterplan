using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Enumeration describing the combat state of a creature.
	/// </summary>
	public enum CreatureState
	{
		/// <summary>
		/// The creature has over half its HP remaining.
		/// </summary>
		Active,

		/// <summary>
		/// The creature has no more than half its HP remaining.
		/// </summary>
		Bloodied,

		/// <summary>
		/// The creature is at or below 0 HP.
		/// </summary>
		Defeated
	}

	/// <summary>
	/// Class containing data about a creature in combat.
	/// </summary>
	[Serializable]
	public class CombatData : IComparable<CombatData>
	{
		/// <summary>
		/// Used by the Location property to specify that the token is not on the map.
		/// </summary>
		public static Point NoPoint = new Point(int.MinValue, int.MinValue);

		/// <summary>
		/// Gets or sets the unique ID of this token.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name to be displayed for this token.
		/// </summary>
		public string DisplayName
		{
			get { return fDisplayName; }
			set { fDisplayName = value; }
		}
		string fDisplayName = "";

		/// <summary>
		/// Gets or sets the token location.
		/// </summary>
		public Point Location
		{
			get { return fLocation; }
			set { fLocation = value; }
		}
		Point fLocation = NoPoint;

		/// <summary>
		/// Gets or sets a value indicating whether the token is visible to the PCs.
		/// </summary>
		public bool Visible
		{
			get { return fVisible; }
			set { fVisible = value; }
		}
		bool fVisible = true;

		/// <summary>
		/// Gets or sets the token's initiative score.
		/// </summary>
		public int Initiative
		{
			get { return fInitiative; }
			set { fInitiative = value; }
		}
		int fInitiative = int.MinValue;

		/// <summary>
		/// Gets or sets a value indicating whether the token is delaying / readying its action.
		/// </summary>
		public bool Delaying
		{
			get { return fDelaying; }
			set { fDelaying = value; }
		}
		bool fDelaying = false;

		/// <summary>
		/// Gets or sets the total hit point damage taken by the token.
		/// </summary>
		public int Damage
		{
			get { return fDamage; }
			set { fDamage = value; }
		}
		int fDamage = 0;

		/// <summary>
		/// Gets or sets the token's temporary hit points.
		/// </summary>
		public int TempHP
		{
			get { return fTempHP; }
			set { fTempHP = value; }
		}
		int fTempHP = 0;

		/// <summary>
		/// Gets or sets the token's altitude.
		/// </summary>
		public int Altitude
		{
			get { return fAltitude; }
			set { fAltitude = value; }
		}
		int fAltitude = 0;

		/// <summary>
		/// Gets or sets the list of expended powers.
		/// </summary>
		public List<Guid> UsedPowers
		{
			get { return fUsedPowers; }
			set { fUsedPowers = value; }
		}
		List<Guid> fUsedPowers = new List<Guid>();

		/// <summary>
		/// Gets or sets the list of conditions affecting the token.
		/// </summary>
		public List<OngoingCondition> Conditions
		{
			get { return fConditions; }
			set { fConditions = value; }
		}
		List<OngoingCondition> fConditions = new List<OngoingCondition>();

		/// <summary>
		/// Resets the CombatData for a new encounter.
		/// </summary>
		/// <param name="reset_damage">True to reset damage, false otherwise</param>
		public void Reset(bool reset_damage)
		{
			fLocation = CombatData.NoPoint;
			fVisible = true;
			fInitiative = int.MinValue;
			fDelaying = false;
			fTempHP = 0;
			fAltitude = 0;

			fUsedPowers.Clear();
			fConditions.Clear();

			if (reset_damage)
				fDamage = 0;
		}

		/// <summary>
		/// Creates a copy of the CombatData.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public CombatData Copy()
		{
			CombatData data = new CombatData();

			data.ID = fID;
			data.DisplayName = fDisplayName;
			data.Location = new Point(fLocation.X, fLocation.Y);
			data.Visible = fVisible;
			data.Initiative = fInitiative;
			data.Delaying = fDelaying;
			data.Damage = fDamage;
			data.TempHP = fTempHP;
			data.Altitude = fAltitude;

			foreach (Guid power_id in fUsedPowers)
				data.UsedPowers.Add(power_id);

			foreach (OngoingCondition c in fConditions)
				data.Conditions.Add(c.Copy());

			return data;
		}

		/// <summary>
		/// Returns the display name.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return fDisplayName;
		}

		/// <summary>
		/// Compares this CombatData to another.
		/// </summary>
		/// <param name="rhs">The CombatData to compare to.</param>
		/// <returns>Returns -1 if this CombatData should be sorted before the other, +1 if the other should be sorted first, 0 otherwise.</returns>
		public int CompareTo(CombatData rhs)
		{
			return fDisplayName.CompareTo(rhs.DisplayName);
		}
	}
}
