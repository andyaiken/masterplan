using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Damage types.
	/// </summary>
	public enum DamageType
	{
		/// <summary>
		/// Untyped damage.
		/// </summary>
		Untyped,
		
		/// <summary>
		/// Acid damage.
		/// </summary>
		Acid,
		
		/// <summary>
		/// Cold damage.
		/// </summary>
		Cold,
		
		/// <summary>
		/// Fire damage.
		/// </summary>
		Fire,
		
		/// <summary>
		/// Force damage.
		/// </summary>
		Force,
		
		/// <summary>
		/// Lightning damage.
		/// </summary>
		Lightning,

		/// <summary>
		/// Nectoric damage.
		/// </summary>
		Necrotic,
		
		/// <summary>
		/// Poison damage.
		/// </summary>
		Poison,
		
		/// <summary>
		/// Psychic damage.
		/// </summary>
		Psychic,
		
		/// <summary>
		/// Radiant damage.
		/// </summary>
		Radiant,
		
		/// <summary>
		/// Thunder damage.
		/// </summary>
		Thunder
	}

	/// <summary>
	/// Class representing damage resistance / vulnerability / immunity.
	/// </summary>
	[Serializable]
	public class DamageModifier
	{
		/// <summary>
		/// Gets or sets the type of damage.
		/// </summary>
		public DamageType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		DamageType fType = DamageType.Fire;

		/// <summary>
		/// Gets or sets the value of the modifier.
		/// If positive, vulnerable by this amount.
		/// If negative, resistant by this amount.
		/// If 0, immune.
		/// </summary>
		public int Value
		{
			get { return fValue; }
			set { fValue = value; }
		}
		int fValue = -5;

		/// <summary>
		/// Creates a copy of the damage modifier.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public DamageModifier Copy()
		{
			DamageModifier dm = new DamageModifier();

			dm.Type = fType;
			dm.Value = fValue;

			return dm;
		}

		/// <summary>
		/// Immune to [damage type]
		/// or
		/// [Resist / Vulnerable] N [damage type]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (fValue == 0)
				return Session.I18N.ImmuneTo + " " + fType.ToString().ToLower();

			string header = (fValue < 0) ? Session.I18N.Resist : Session.I18N.Vulnerable;
			int val = Math.Abs(fValue);

			return header + " " + val + " " + fType.ToString().ToLower();
		}

		/// <summary>
		/// Creates a DamageModifier object.
		/// </summary>
		/// <param name="damage_type">The damage type as a string.</param>
		/// <param name="value">The modifier value.</param>
		/// <returns>Returns the damage modifier object.</returns>
		public static DamageModifier Parse(string damage_type, int value)
		{
			string[] types = Enum.GetNames(typeof(DamageType));
			List<string> type_list = new List<string>();
			foreach (string type in types)
				type_list.Add(type);

			try
			{
				DamageModifier mod = new DamageModifier();

				mod.Type = (DamageType)Enum.Parse(typeof(DamageType), damage_type, true);
				mod.Value = value;

				return mod;
			}
			catch
			{
			}

			return null;
		}
	}

	/// <summary>
	/// Class representing damage resistance / vulnerability / immunity for a creature template.
	/// </summary>
	[Serializable]
	public class DamageModifierTemplate
	{
		/// <summary>
		/// Gets or sets the type of damage.
		/// </summary>
		public DamageType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		DamageType fType = DamageType.Untyped;

		/// <summary>
		/// Gets or sets the amount of resistance / vulnerability at the heroic tier.
		/// </summary>
		public int HeroicValue
		{
			get { return fHeroicValue; }
			set { fHeroicValue = value; }
		}
		int fHeroicValue = -5;

		/// <summary>
		/// Gets or sets the amount of resistance / vulnerability at the paragon tier.
		/// </summary>
		public int ParagonValue
		{
			get { return fParagonValue; }
			set { fParagonValue = value; }
		}
		int fParagonValue = -10;

		/// <summary>
		/// Gets or sets the amount of resistance / vulnerability at the epic tier.
		/// </summary>
		public int EpicValue
		{
			get { return fEpicValue; }
			set { fEpicValue = value; }
		}
		int fEpicValue = -15;

		/// <summary>
		/// Creates a copy of the DamageModifierTemplate.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public DamageModifierTemplate Copy()
		{
			DamageModifierTemplate dmt = new DamageModifierTemplate();

			dmt.Type = fType;
			dmt.HeroicValue = fHeroicValue;
			dmt.ParagonValue = fParagonValue;
			dmt.EpicValue = fEpicValue;

			return dmt;
		}

		/// <summary>
		/// Immume to [damage type]
		/// or
		/// [Resist / Vulnerable] HH / PP / EE [damage type]
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			int total_mod = fHeroicValue + fParagonValue + fEpicValue;
			if (total_mod == 0)
				return Session.I18N.ImmuneTo + " " + fType.ToString().ToLower();

			string header = (fHeroicValue < 0) ? Session.I18N.Resist : Session.I18N.Vulnerable;
			int heroic = Math.Abs(fHeroicValue);
			int paragon = Math.Abs(fParagonValue);
			int epic = Math.Abs(fEpicValue);

			return header + " " + heroic + " / " + paragon + " / " + epic + " " + fType.ToString().ToLower();
		}
	}
}
