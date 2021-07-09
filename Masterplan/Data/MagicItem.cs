using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Rarities for magic items.
	/// </summary>
	public enum MagicItemRarity
	{
		/// <summary>
		/// Common items.
		/// </summary>
		Common,

		/// <summary>
		/// Uncommon items.
		/// </summary>
		Uncommon,

		/// <summary>
		/// Rare items.
		/// </summary>
		Rare,

		/// <summary>
		/// Unique items.
		/// </summary>
		Unique
	}

	/// <summary>
	/// Class representing a magic item.
	/// </summary>
	[Serializable]
	public class MagicItem : IComparable<MagicItem>
	{
		/// <summary>
		/// Gets or sets the unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the item type.
		/// </summary>
		public string Type
		{
			get { return fType; }
			set { fType = value; }
		}
		string fType = "Weapon";

		/// <summary>
		/// Gets or sets the item type.
		/// </summary>
		public MagicItemRarity Rarity
		{
			get { return fRarity; }
			set { fRarity = value; }
		}
		MagicItemRarity fRarity = MagicItemRarity.Uncommon;

		/// <summary>
		/// Gets or sets the item level.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = 1;

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description
		{
			get { return fDescription; }
			set { fDescription = value; }
		}
		string fDescription = "";

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public List<MagicItemSection> Sections
		{
			get { return fSections; }
			set { fSections = value; }
		}
		List<MagicItemSection> fSections = new List<MagicItemSection>();

		/// <summary>
		/// Level N [type]
		/// </summary>
		public string Info
		{
			get
			{
				return "Level " + fLevel + " " + fType.ToLower();
			}
		}

		/// <summary>
		/// Creates a copy of the creature.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public MagicItem Copy()
		{
			MagicItem mi = new MagicItem();

			mi.ID = fID;
			mi.Name = fName;
			mi.Type = fType;
			mi.Rarity = fRarity;
			mi.Level = fLevel;
			mi.Description = fDescription;

			foreach (MagicItemSection section in fSections)
				mi.Sections.Add(section.Copy());

			return mi;
		}

		/// <summary>
		/// Compares this item to another.
		/// </summary>
		/// <param name="rhs">The other item.</param>
		/// <returns>Returns -1 if this item should be sorted before the other, +1 if the other should be sorted before this; 0 otherwise.</returns>
		public int CompareTo(MagicItem rhs)
		{
			return fName.CompareTo(rhs.Name);
		}
	}

	/// <summary>
	/// Class to hold information about a magic item property or power.
	/// </summary>
	[Serializable]
	public class MagicItemSection
	{
		/// <summary>
		/// Gets or sets the header.
		/// </summary>
		public string Header
		{
			get { return fHeader; }
			set { fHeader = value; }
		}
		string fHeader = "";

		/// <summary>
		/// Gets or sets the details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Creates a copy of the section.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public MagicItemSection Copy()
		{
			MagicItemSection section = new MagicItemSection();

			section.Header = fHeader;
			section.Details = fDetails;

			return section;
		}

		/// <summary>
		/// [header]: [details]
		/// </summary>
		public override string ToString()
		{
			if (fDetails != "")
				return fHeader + ": " + fDetails;
			else
				return fHeader;
		}
	}
}
