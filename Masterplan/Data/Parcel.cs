using System;

using Masterplan.Tools.Generators;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a treasure parcel.
	/// </summary>
	[Serializable]
	public class Parcel
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Parcel()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="item">The magic item to create the parcel with.</param>
		public Parcel(MagicItem item)
		{
			SetAsMagicItem(item);
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="artifact">The artifact to create the parcel with.</param>
		public Parcel(Artifact artifact)
		{
			SetAsArtifact(artifact);
		}

		/// <summary>
		/// Gets or sets the name of the parcel.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the parcel details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the value of the parcel in GP.
		/// </summary>
		public int Value
		{
			get { return fValue; }
			set { fValue = value; }
		}
		int fValue = 0;

		/// <summary>
		/// Gets or sets the ID of the magic item.
		/// </summary>
		public Guid MagicItemID
		{
			get { return fMagicItemID; }
			set { fMagicItemID = value; }
		}
		Guid fMagicItemID = Guid.Empty;

		/// <summary>
		/// Gets or sets the ID of the artifact.
		/// </summary>
		public Guid ArtifactID
		{
			get { return fArtifactID; }
			set { fArtifactID = value; }
		}
		Guid fArtifactID = Guid.Empty;

		/// <summary>
		/// Gets or sets the ID of the PC to whom the item has been given.
		/// </summary>
		public Guid HeroID
		{
			get { return fHeroID; }
			set { fHeroID = value; }
		}
		Guid fHeroID = Guid.Empty;

		/// <summary>
		/// Sets the parcel to contain the given magic item.
		/// </summary>
		/// <param name="item">The magic item.</param>
		public void SetAsMagicItem(MagicItem item)
		{
			fName = item.Name;
			fDetails = item.Description;
			fMagicItemID = item.ID;
			fArtifactID = Guid.Empty;
			fValue = Treasure.GetItemValue(item.Level);
		}

		/// <summary>
		/// Sets the parcel to contain the given magic item.
		/// </summary>
		/// <param name="artifact">The magic item.</param>
		public void SetAsArtifact(Artifact artifact)
		{
			fName = artifact.Name;
			fDetails = artifact.Description;
			fMagicItemID = Guid.Empty;
			fArtifactID = artifact.ID;
			fValue = 0;
		}

		/// <summary>
		/// Calculates the level of the contained magic item.
		/// </summary>
		/// <returns>Returns the level.</returns>
		public int FindItemLevel()
		{
			MagicItem item = Session.FindMagicItem(fMagicItemID, SearchType.Global);
			if (item != null)
				return item.Level;

			int index = Treasure.PlaceholderIDs.IndexOf(fMagicItemID);
			if (index != -1)
				return index + 1;

			if (fValue > 0)
			{
				for (int level = 30; level >= 1; --level)
				{
					int value = Treasure.GetItemValue(level);
					if (value < fValue)
						return level;
				}
			}

			return -1;
		}

		/// <summary>
		/// Calculates the tier of the contained artifact.
		/// </summary>
		/// <returns>Returns the tier.</returns>
		public Tier FindItemTier()
		{
			Artifact artifact = Session.FindArtifact(fArtifactID, SearchType.Global);
			if (artifact != null)
				return artifact.Tier;

			int index = Treasure.PlaceholderIDs.IndexOf(fMagicItemID);
			switch (index)
			{
				case 0:
					return Tier.Heroic;
				case 1:
					return Tier.Paragon;
				case 2:
					return Tier.Epic;
			}

			return Tier.Heroic;
		}

		/// <summary>
		/// Creates a copy of the parcel.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Parcel Copy()
		{
			Parcel p = new Parcel();

			p.Name = fName;
			p.Details = fDetails;
			p.Value = fValue;
			p.MagicItemID = fMagicItemID;
			p.ArtifactID = fArtifactID;
			p.HeroID = fHeroID;

			return p;
		}
	}
}
