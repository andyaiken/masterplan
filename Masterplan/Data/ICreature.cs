using System;
using System.Collections.Generic;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Enumeration containing the possible creature sizes
	/// </summary>
	public enum CreatureSize
	{
		/// <summary>
		/// Tiny size.
		/// </summary>
		Tiny,

		/// <summary>
		/// Small size.
		/// </summary>
		Small,

		/// <summary>
		/// Medium size.
		/// </summary>
		Medium,

		/// <summary>
		/// Large size.
		/// </summary>
		Large,

		/// <summary>
		/// Huge size.
		/// </summary>
		Huge,

		/// <summary>
		/// Gargantuan size.
		/// </summary>
		Gargantuan
	}

	/// <summary>
	/// Creature origins.
	/// </summary>
	public enum CreatureOrigin
	{
		/// <summary>
		/// Aberrant origin.
		/// </summary>
		Aberrant,

		/// <summary>
		/// Elemental origin.
		/// </summary>
		Elemental,

		/// <summary>
		/// Fey origin.
		/// </summary>
		Fey,

		/// <summary>
		/// Immortal origin.
		/// </summary>
		Immortal,

		/// <summary>
		/// Natural origin.
		/// </summary>
		Natural,

		/// <summary>
		/// Shadow origin.
		/// </summary>
		Shadow
	}

	/// <summary>
	/// Creature types.
	/// </summary>
	public enum CreatureType
	{
		/// <summary>
		/// Animate type.
		/// </summary>
		Animate,

		/// <summary>
		/// Beast type.
		/// </summary>
		Beast,

		/// <summary>
		/// Humanoid type.
		/// </summary>
		Humanoid,

		/// <summary>
		/// Magical beast type.
		/// </summary>
		MagicalBeast
	}

	/// <summary>
	/// Class to hold creature regeneration information.
	/// </summary>
	[Serializable]
	public class Regeneration
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public Regeneration()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="value">Value</param>
		/// <param name="details">Details</param>
		public Regeneration(int value, string details)
		{
			fValue = value;
			fDetails = details;
		}

		/// <summary>
		/// Gets or sets the regeneration value.
		/// </summary>
		public int Value
		{
			get { return fValue; }
			set { fValue = value; }
		}
		int fValue = 2;

		/// <summary>
		/// Gets or sets the regeneration details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Returns the regeneration information.
		/// </summary>
		/// <returns>Returns the regeneration information.</returns>
		public override string ToString()
		{
			String str = fValue.ToString();

			if (fDetails != "")
			{
				bool brackets = (str != "");

				if (brackets)
					str += " (";

				str += fDetails;

				if (brackets)
					str += ")";
			}

			return str;
		}

		/// <summary>
		/// Creates a copy of the regeneration data.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Regeneration Copy()
		{
			Regeneration r = new Regeneration();

			r.Value = fValue;
			r.Details = fDetails;

			return r;
		}
	}

	/// <summary>
	/// Interface for a creature.
	/// Implemented by Creature, CustomCreature and NPC classes.
	/// </summary>
	public interface ICreature : IComparable<ICreature>
	{
		/// <summary>
		/// Gets or sets the unique ID of the creature.
		/// </summary>
		Guid ID { get; set; }

		/// <summary>
		/// Gets or sets the name of the creature.
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets the size of the creature.
		/// </summary>
		CreatureSize Size { get; set; }

		/// <summary>
		/// Gets or sets the creature origin.
		/// </summary>
		CreatureOrigin Origin { get; set; }

		/// <summary>
		/// Gets or sets the creature type.
		/// </summary>
		CreatureType Type { get; set; }

		/// <summary>
		/// Gets or sets the creature keywords.
		/// </summary>
		string Keywords { get; set; }

		/// <summary>
		/// Gets or sets the level of the creature.
		/// </summary>
		int Level { get; set; }

		/// <summary>
		/// Gets or sets the role of the creature.
		/// </summary>
		IRole Role { get; set; }

		/// <summary>
		/// Gets or sets the creature's senses.
		/// </summary>
		string Senses { get; set; }

		/// <summary>
		/// Gets or sets the creature's movement.
		/// </summary>
		string Movement { get; set; }

		/// <summary>
		/// Gets or sets the creature's alignment.
		/// </summary>
		string Alignment { get; set; }

		/// <summary>
		/// Gets or sets the creature's languages.
		/// </summary>
		string Languages { get; set; }

		/// <summary>
		/// Gets or sets the creature's skills.
		/// </summary>
		string Skills { get; set; }

		/// <summary>
		/// Gets or sets the creature's equipment.
		/// </summary>
		string Equipment { get; set; }

		/// <summary>
		/// Gets or sets the creature details.
		/// </summary>
		string Details { get; set; }

		/// <summary>
		/// Gets or sets the creature category.
		/// </summary>
		string Category { get; set; }

		/// <summary>
		/// Gets or sets the creature's Strength.
		/// </summary>
		Ability Strength { get; set; }

		/// <summary>
		/// Gets or sets the creature's Constitution.
		/// </summary>
		Ability Constitution { get; set; }

		/// <summary>
		/// Gets or sets the creature's Dexterity.
		/// </summary>
		Ability Dexterity { get; set; }

		/// <summary>
		/// Gets or sets the creature's Intelligence.
		/// </summary>
		Ability Intelligence { get; set; }

		/// <summary>
		/// Gets o sets the creature's Wisdom.
		/// </summary>
		Ability Wisdom { get; set; }

		/// <summary>
		/// Gets or sets the creature's Charisma.
		/// </summary>
		Ability Charisma { get; set; }

		/// <summary>
		/// Gets or sets the creature's HP total.
		/// </summary>
		int HP { get; set; }

		/// <summary>
		/// Gets or sets the creature's Initiative bonus.
		/// </summary>
		int Initiative { get; set; }

		/// <summary>
		/// Gets or sets the creature's AC defence.
		/// </summary>
		int AC { get; set; }

		/// <summary>
		/// Gets or sets the creature's Fortitude defence.
		/// </summary>
		int Fortitude { get; set; }

		/// <summary>
		/// Gets or sets the creature's Reflex defence.
		/// </summary>
		int Reflex { get; set; }

		/// <summary>
		/// Gets or sets the creature's Will defence.
		/// </summary>
		int Will { get; set; }

		/// <summary>
		/// Gets or sets the creature's regeneration.
		/// </summary>
		Regeneration Regeneration { get; set; }

		/// <summary>
		/// Gets or sets the list of the creature's auras.
		/// </summary>
		List<Aura> Auras { get; set; }

		/// <summary>
		/// Gets or sets the list of the creature's powers.
		/// </summary>
		List<CreaturePower> CreaturePowers { get; set; }

		/// <summary>
		/// Gets or sets the list of the creature's damage modifiers.
		/// </summary>
		List<DamageModifier> DamageModifiers { get; set; }

		/// <summary>
		/// Gets or sets the creature's resistances.
		/// </summary>
		string Resist { get; set; }

		/// <summary>
		/// Gets or sets the creature's vulnerabilities.
		/// </summary>
		string Vulnerable { get; set; }

		/// <summary>
		/// Gets or sets the creature's immunities.
		/// </summary>
		string Immune { get; set; }

		/// <summary>
		/// Gets or sets the creature's tactics.
		/// </summary>
		string Tactics { get; set; }

		/// <summary>
		/// Gets or sets the picture to display on the map.
		/// </summary>
		Image Image { get; set; }

        /// <summary>
        /// Level N [role] [(L)]
        /// </summary>
        string Info { get; }

        /// <summary>
        /// [type] [origin] [keywords]
        /// </summary>
        string Phenotype { get; }
    }
}
