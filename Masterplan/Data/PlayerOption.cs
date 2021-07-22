using System;
using System.Collections.Generic;

using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Interface implemented by player option classes.
	/// </summary>
	public interface IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the option.
		/// </summary>
		Guid ID { get; set; }

		/// <summary>
		/// Gets or sets the name of the option.
		/// </summary>
		string Name { get; set; }
	}

	#region Player power

	/// <summary>
	/// At-will / encounter / daily.
	/// </summary>
	public enum PlayerPowerType
	{
		/// <summary>
		/// At-will power.
		/// </summary>
		AtWill,

		/// <summary>
		/// Encounter power.
		/// </summary>
		Encounter,

		/// <summary>
		/// Daily power.
		/// </summary>
		Daily
	}

	/// <summary>
	/// Class representing a player power.
	/// </summary>
	[Serializable]
	public class PlayerPower : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the power.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the power.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the power's usage type.
		/// </summary>
		public PlayerPowerType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		PlayerPowerType fType = PlayerPowerType.Encounter;

		/// <summary>
		/// Gets or sets the power's read-aloud text.
		/// </summary>
		public string ReadAloud
		{
			get { return fReadAloud; }
			set { fReadAloud = value; }
		}
		string fReadAloud = "";

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
		/// Gets or sets the action required to use the power.
		/// </summary>
		public ActionType Action
		{
			get { return fAction; }
			set { fAction = value; }
		}
		ActionType fAction = ActionType.Standard;

		/// <summary>
		/// Gets or sets the power's range.
		/// </summary>
		public string Range
		{
			get { return fRange; }
			set { fRange = value; }
		}
		string fRange = "Melee weapon";

		/// <summary>
		/// Gets or sets the power sections.
		/// </summary>
		public List<PlayerPowerSection> Sections
		{
			get { return fSections; }
			set { fSections = value; }
		}
		List<PlayerPowerSection> fSections = new List<PlayerPowerSection>();

		/// <summary>
		/// Creates a copy of the power.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public PlayerPower Copy()
		{
			PlayerPower power = new PlayerPower();

			power.ID = fID;
			power.Name = fName;
			power.Type = fType;
			power.ReadAloud = fReadAloud;
			power.Keywords = fKeywords;
			power.Action = fAction;
			power.Range = fRange;

			foreach (PlayerPowerSection section in fSections)
				power.Sections.Add(section.Copy());

			return power;
		}

		/// <summary>
		/// Returns the name of the power.
		/// </summary>
		/// <returns>Returns the name of the power.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a section in a player power.
	/// </summary>
	[Serializable]
	public class PlayerPowerSection
	{
		/// <summary>
		/// Gets or sets the unique ID of the power.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the section header.
		/// </summary>
		public string Header
		{
			get { return fHeader; }
			set { fHeader = value; }
		}
		string fHeader = "Effect";

		/// <summary>
		/// Gets or sets the section details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the degree of indent for the section.
		/// </summary>
		public int Indent
		{
			get { return fIndent; }
			set { fIndent = value; }
		}
		int fIndent = 0;

		/// <summary>
		/// Creates a copy of the power section.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public PlayerPowerSection Copy()
		{
			PlayerPowerSection s = new PlayerPowerSection();

			s.ID = fID;
			s.Header = fHeader;
			s.Details = fDetails;
			s.Indent = fIndent;

			return s;
		}
	}

	#endregion

	#region Feat

	/// <summary>
	/// Enumeration for game tiers.
	/// </summary>
	public enum Tier
	{
		/// <summary>
		/// Heroic tier.
		/// </summary>
		Heroic,

		/// <summary>
		/// Paragon tier.
		/// </summary>
		Paragon,

		/// <summary>
		/// Epic tier.
		/// </summary>
		Epic
	}

	/// <summary>
	/// Class representing a feat.
	/// </summary>
	[Serializable]
	public class Feat : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the feat.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the feat.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the feat's tier.
		/// </summary>
		public Tier Tier
		{
			get { return fTier; }
			set { fTier = value; }
		}
		Tier fTier = Tier.Heroic;

		/// <summary>
		/// Gets or sets the prerequisites for the feat.
		/// </summary>
		public string Prerequisites
		{
			get { return fPrerequisites; }
			set { fPrerequisites = value; }
		}
		string fPrerequisites = "";

		/// <summary>
		/// Gets or sets the feat benefits.
		/// </summary>
		public string Benefits
		{
			get { return fBenefits; }
			set { fBenefits = value; }
		}
		string fBenefits = "";

		/// <summary>
		/// Creates a copy of the feat.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Feat Copy()
		{
			Feat ft = new Feat();

			ft.ID = fID;
			ft.Name = fName;
			ft.Tier = fTier;
			ft.Prerequisites = fPrerequisites;
			ft.Benefits = fBenefits;

			return ft;
		}

		/// <summary>
		/// Returns the name of the feat.
		/// </summary>
		/// <returns>Returns the name of the feat.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	#endregion

	/// <summary>
	/// Class representing a player background.
	/// </summary>
	[Serializable]
	public class PlayerBackground : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the background.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the background.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the background details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the associated skills for the background.
		/// </summary>
		public string AssociatedSkills
		{
			get { return fAssociatedSkills; }
			set { fAssociatedSkills = value; }
		}
		string fAssociatedSkills = "";

		/// <summary>
		/// Gets or sets the recommended feats for the background.
		/// </summary>
		public string RecommendedFeats
		{
			get { return fRecommendedFeats; }
			set { fRecommendedFeats = value; }
		}
		string fRecommendedFeats = "";

		/// <summary>
		/// Creates a copy of the background.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public PlayerBackground Copy()
		{
			PlayerBackground bg = new PlayerBackground();

			bg.ID = fID;
			bg.Name = fName;
			bg.Details = fDetails;
			bg.AssociatedSkills = fAssociatedSkills;
			bg.RecommendedFeats = fRecommendedFeats;

			return bg;
		}

		/// <summary>
		/// Returns the name of the background.
		/// </summary>
		/// <returns>Returns the name of the background.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a race.
	/// </summary>
	[Serializable]
	public class Race : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the race.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the race.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the defining quote.
		/// </summary>
		public string Quote
		{
			get { return fQuote; }
			set { fQuote = value; }
		}
		string fQuote = "";

		/// <summary>
		/// Gets or sets the height range of the race.
		/// </summary>
		public string HeightRange
		{
			get { return fHeightRange; }
			set { fHeightRange = value; }
		}
		string fHeightRange = "";

		/// <summary>
		/// Gets or sets the weight range of the race.
		/// </summary>
		public string WeightRange
		{
			get { return fWeightRange; }
			set { fWeightRange = value; }
		}
		string fWeightRange = "";

		/// <summary>
		/// Gets or sets the ability score modifiers for the race.
		/// </summary>
		public string AbilityScores
		{
			get { return fAbilityScores; }
			set { fAbilityScores = value; }
		}
		string fAbilityScores = "";

		/// <summary>
		/// Gets or sets the size of the race.
		/// </summary>
		public CreatureSize Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		CreatureSize fSize = CreatureSize.Medium;

		/// <summary>
		/// Gets or sets the speed of the race.
		/// </summary>
		public string Speed
		{
			get { return fSpeed; }
			set { fSpeed  = value; }
		}
		string fSpeed = "6 squares";

		/// <summary>
		/// Gets or sets the race's vision.
		/// </summary>
		public string Vision
		{
			get { return fVision; }
			set { fVision = value; }
		}
		string fVision = "Normal";

		/// <summary>
		/// Gets or sets the race's starting languages.
		/// </summary>
		public string Languages
		{
			get { return fLanguages; }
			set { fLanguages = value; }
		}
		string fLanguages = "Common";

		/// <summary>
		/// Gets or sets the race's skill bonuses.
		/// </summary>
		public string SkillBonuses
		{
			get { return fSkillBonuses; }
			set { fSkillBonuses = value; }
		}
		string fSkillBonuses = "";

		/// <summary>
		/// Gets or sets the racial features.
		/// </summary>
		public List<Feature> Features
		{
			get { return fFeatures; }
			set { fFeatures = value; }
		}
		List<Feature> fFeatures = new List<Feature>();

		/// <summary>
		/// Gets or sets the racial powers.
		/// </summary>
		public List<PlayerPower> Powers
		{
			get { return fPowers; }
			set { fPowers = value; }
		}
		List<PlayerPower> fPowers = new List<PlayerPower>();

		/// <summary>
		/// Gets or sets the race details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Creates a copy of the race.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Race Copy()
		{
			Race race = new Race();

			race.ID = fID;
			race.Name = fName;
			race.Quote = fQuote;
			race.HeightRange = fHeightRange;
			race.WeightRange = fWeightRange;
			race.AbilityScores = fAbilityScores;
			race.Size = fSize;
			race.Speed = fSpeed;
			race.Vision = fVision;
			race.Languages = fLanguages;
			race.SkillBonuses = fSkillBonuses;
			race.Details = fDetails;

			foreach (Feature ft in fFeatures)
				race.Features.Add(ft.Copy());

			foreach (PlayerPower power in fPowers)
				race.Powers.Add(power.Copy());

			return race;
		}

		/// <summary>
		/// Returns the name of the race.
		/// </summary>
		/// <returns>Returns the name of the race.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a playable class.
	/// </summary>
	[Serializable]
	public class Class : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the class.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the class.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the defining quote.
		/// </summary>
		public string Quote
		{
			get { return fQuote; }
			set { fQuote = value; }
		}
		string fQuote = "";

		/// <summary>
		/// Gets or sets the class role.
		/// </summary>
		public string Role
		{
			get { return fRole; }
			set { fRole = value; }
		}
		string fRole = "";

		/// <summary>
		/// Gets or sets the class's power source.
		/// </summary>
		public string PowerSource
		{
			get { return fPowerSource; }
			set { fPowerSource = value; }
		}
		string fPowerSource = "";

		/// <summary>
		/// Gets or sets the class's key abilities.
		/// </summary>
		public string KeyAbilities
		{
			get { return fKeyAbilities; }
			set { fKeyAbilities = value; }
		}
		string fKeyAbilities = "";

		/// <summary>
		/// Gets or sets the class's armour proficiencies.
		/// </summary>
		public string ArmourProficiencies
		{
			get { return fArmourProficiencies; }
			set { fArmourProficiencies = value; }
		}
		string fArmourProficiencies = "";

		/// <summary>
		/// Gets or sets the class's weapon proficiencies.
		/// </summary>
		public string WeaponProficiencies
		{
			get { return fWeaponProficiencies; }
			set { fWeaponProficiencies = value; }
		}
		string fWeaponProficiencies = "";

		/// <summary>
		/// Gets or sets the class's implement proficiencies.
		/// </summary>
		public string Implements
		{
			get { return fImplements; }
			set { fImplements = value; }
		}
		string fImplements = "";

		/// <summary>
		/// Gets or sets the class's defence bonuses.
		/// </summary>
		public string DefenceBonuses
		{
			get { return fDefenceBonuses; }
			set { fDefenceBonuses = value; }
		}
		string fDefenceBonuses = "";

		/// <summary>
		/// Gets or sets the class's first level HP.
		/// </summary>
		public int HPFirst
		{
			get { return fHPFirst; }
			set { fHPFirst = value; }
		}
		int fHPFirst = 0;

		/// <summary>
		/// Gets or sets the class's HP per level.
		/// </summary>
		public int HPSubsequent
		{
			get { return fHPSubsequent; }
			set { fHPSubsequent = value; }
		}
		int fHPSubsequent = 0;

		/// <summary>
		/// Gets or sets the class's healing surges.
		/// </summary>
		public int HealingSurges
		{
			get { return fHealingSurges; }
			set { fHealingSurges = value; }
		}
		int fHealingSurges = 0;

		/// <summary>
		/// Gets or sets the class's trained skills.
		/// </summary>
		public string TrainedSkills
		{
			get { return fTrainedSkills; }
			set { fTrainedSkills = value; }
		}
		string fTrainedSkills = "";

		/// <summary>
		/// Gets or sets the description for the class.
		/// </summary>
		public string Description
		{
			get { return fDescription; }
			set { fDescription = value; }
		}
		string fDescription = "";

		/// <summary>
		/// Gets or sets the class's overview characteristics.
		/// </summary>
		public string OverviewCharacteristics
		{
			get { return fOverviewCharacteristics; }
			set { fOverviewCharacteristics = value; }
		}
		string fOverviewCharacteristics = "";

		/// <summary>
		/// Gets or sets the class's religion information.
		/// </summary>
		public string OverviewReligion
		{
			get { return fOverviewReligion; }
			set { fOverviewReligion = value; }
		}
		string fOverviewReligion = "";

		/// <summary>
		/// Gets or sets the class's race information.
		/// </summary>
		public string OverviewRaces
		{
			get { return fOverviewRaces; }
			set { fOverviewRaces = value; }
		}
		string fOverviewRaces = "";

		/// <summary>
		/// Gets or sets the class's feature powers.
		/// </summary>
		public LevelData FeatureData
		{
			get { return fFeatureData; }
			set { fFeatureData = value; }
		}
		LevelData fFeatureData = new LevelData();

		/// <summary>
		/// Gets or sets the class's powers.
		/// </summary>
		public List<LevelData> Levels
		{
			get { return fLevels; }
			set { fLevels = value; }
		}
		List<LevelData> fLevels = new List<LevelData>();

		// TODO: Builds

		/// <summary>
		/// Creates a copy of the class.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Class Copy()
		{
			Class c = new Class();

			c.ID = fID;
			c.Name = fName;
			c.Quote = fQuote;

			c.Role = fRole;
			c.PowerSource = fPowerSource;
			c.KeyAbilities = fKeyAbilities;

			c.ArmourProficiencies = fArmourProficiencies;
			c.WeaponProficiencies = fWeaponProficiencies;
			c.Implements = fImplements;
			c.DefenceBonuses = fDefenceBonuses;

			c.HPFirst = fHPFirst;
			c.HPSubsequent = fHPSubsequent;
			c.HealingSurges = fHealingSurges;

			c.TrainedSkills = fTrainedSkills;

			c.Description = fDescription;

			c.OverviewCharacteristics = fOverviewCharacteristics;
			c.OverviewReligion = fOverviewReligion;
			c.OverviewRaces = fOverviewRaces;

			c.FeatureData = fFeatureData.Copy();

			foreach (LevelData ld in fLevels)
				c.Levels.Add(ld.Copy());

			// Builds

			return c;
		}

		/// <summary>
		/// Returns the name of the class.
		/// </summary>
		/// <returns>Returns the name of the class.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a character theme.
	/// </summary>
	[Serializable]
	public class Theme : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the theme.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the theme.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the defining quote.
		/// </summary>
		public string Quote
		{
			get { return fQuote; }
			set { fQuote = value; }
		}
		string fQuote = "";

		/// <summary>
		/// Gets or sets the prerequisites for the theme.
		/// </summary>
		public string Prerequisites
		{
			get { return fPrerequisites; }
			set { fPrerequisites = value; }
		}
		string fPrerequisites = "";

		/// <summary>
		/// Gets or sets the theme's secondary role.
		/// </summary>
		public string SecondaryRole
		{
			get { return fSecondaryRole; }
			set { fSecondaryRole = value; }
		}
		string fSecondaryRole = "";

		/// <summary>
		/// Gets or sets the theme's power source.
		/// </summary>
		public string PowerSource
		{
			get { return fPowerSource; }
			set { fPowerSource = value; }
		}
		string fPowerSource = "";

		/// <summary>
		/// Gets or sets the theme's granted power.
		/// </summary>
		public PlayerPower GrantedPower
		{
			get { return fGrantedPower; }
			set { fGrantedPower = value; }
		}
		PlayerPower fGrantedPower = new PlayerPower();

		/// <summary>
		/// Gets or sets the theme details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the level data.
		/// </summary>
		public List<LevelData> Levels
		{
			get { return fLevels; }
			set { fLevels = value; }
		}
		List<LevelData> fLevels = new List<LevelData>();

		/// <summary>
		/// Creates a copy of the theme.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Theme Copy()
		{
			Theme theme = new Theme();

			theme.ID = fID;
			theme.Name = fName;
			theme.Quote = fQuote;
			theme.Prerequisites = fPrerequisites;
			theme.SecondaryRole = fSecondaryRole;
			theme.PowerSource = fPowerSource;
			theme.GrantedPower = fGrantedPower.Copy();
			theme.Details = fDetails;

			foreach (LevelData ld in fLevels)
				theme.Levels.Add(ld.Copy());

			return theme;
		}

		/// <summary>
		/// Returns the name of the theme.
		/// </summary>
		/// <returns>Returns the name of the theme.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a paragon path.
	/// </summary>
	[Serializable]
	public class ParagonPath : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the paragon path.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the paragon path.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the defining quote.
		/// </summary>
		public string Quote
		{
			get { return fQuote; }
			set { fQuote = value; }
		}
		string fQuote = "";

		/// <summary>
		/// Gets or sets the prerequisites for the paragon path.
		/// </summary>
		public string Prerequisites
		{
			get { return fPrerequisites; }
			set { fPrerequisites = value; }
		}
		string fPrerequisites = "11th level";

		/// <summary>
		/// Gets or sets the paragon path details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the level data.
		/// </summary>
		public List<LevelData> Levels
		{
			get { return fLevels; }
			set { fLevels = value; }
		}
		List<LevelData> fLevels = new List<LevelData>();

		/// <summary>
		/// Creates a copy of the paragon path.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public ParagonPath Copy()
		{
			ParagonPath pp = new ParagonPath();

			pp.ID = fID;
			pp.Name = fName;
			pp.Quote = fQuote;
			pp.Prerequisites = fPrerequisites;
			pp.Details = fDetails;

			foreach (LevelData ld in fLevels)
				pp.Levels.Add(ld.Copy());

			return pp;
		}

		/// <summary>
		/// Returns the name of the paragon path.
		/// </summary>
		/// <returns>Returns the name of the paragon path.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing an epic destiny.
	/// </summary>
	[Serializable]
	public class EpicDestiny : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the epic destiny.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the epic destiny.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the defining quote.
		/// </summary>
		public string Quote
		{
			get { return fQuote; }
			set { fQuote = value; }
		}
		string fQuote = "";

		/// <summary>
		/// Gets or sets the prerequisites for the epic destiny.
		/// </summary>
		public string Prerequisites
		{
			get { return fPrerequisites; }
			set { fPrerequisites = value; }
		}
		string fPrerequisites = "21st level";

		/// <summary>
		/// Gets or sets the epic destiny details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the immortality details for the epic destiny.
		/// </summary>
		public string Immortality
		{
			get { return fImmortality; }
			set { fImmortality = value; }
		}
		string fImmortality = "";

		/// <summary>
		/// Gets or sets the level data.
		/// </summary>
		public List<LevelData> Levels
		{
			get { return fLevels; }
			set { fLevels = value; }
		}
		List<LevelData> fLevels = new List<LevelData>();

		/// <summary>
		/// Creates a copy of the epic destiny.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public EpicDestiny Copy()
		{
			EpicDestiny ed = new EpicDestiny();

			ed.ID = fID;
			ed.Name = fName;
			ed.Quote = fQuote;
			ed.Prerequisites = fPrerequisites;
			ed.Details = fDetails;
			ed.Immortality = fImmortality;

			foreach (LevelData ld in fLevels)
				ed.Levels.Add(ld.Copy());

			return ed;
		}

		/// <summary>
		/// Returns the name of the epic destiny.
		/// </summary>
		/// <returns>Returns the name of the epic destiny.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class holding feature and power information for a level.
	/// </summary>
	[Serializable]
	public class LevelData
	{
		/// <summary>
		/// Gets or sets the level.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = 0;

		/// <summary>
		/// Gets or sets the list of features.
		/// </summary>
		public List<Feature> Features
		{
			get { return fFeatures; }
			set { fFeatures = value; }
		}
		List<Feature> fFeatures = new List<Feature>();

		/// <summary>
		/// Gets or sets the list of powers.
		/// </summary>
		public List<PlayerPower> Powers
		{
			get { return fPowers; }
			set { fPowers = value; }
		}
		List<PlayerPower> fPowers = new List<PlayerPower>();

		/// <summary>
		/// Returns the total number of items in the level.
		/// </summary>
		public int Count
		{
			get { return fFeatures.Count + fPowers.Count; }
		}

		/// <summary>
		/// Creates a copy of the level data.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public LevelData Copy()
		{
			LevelData ld = new LevelData();

			ld.Level = fLevel;

			foreach (Feature ft in fFeatures)
				ld.Features.Add(ft.Copy());

			foreach (PlayerPower pp in fPowers)
				ld.Powers.Add(pp.Copy());

			return ld;
		}

		/// <summary>
		/// Returns a string representation of the level data.
		/// </summary>
		/// <returns>Returns a string representation of the level data.</returns>
		public override string ToString()
		{
			string str = "";

			foreach (Feature ft in fFeatures)
			{
				if (str != "")
					str += "; ";

				str += ft.Name;
			}

			foreach (PlayerPower power in fPowers)
			{
				if (str != "")
					str += "; ";

				str += power.Name;
			}

			if (str == "")
				str = "(empty)";

			if (fLevel >= 1)
				return "Level " + fLevel + ": " + str;
			else
				return str;
		}
	}

	/// <summary>
	/// Class representing a race / paragon path / epic destiny feature.
	/// </summary>
	[Serializable]
	public class Feature
	{
		/// <summary>
		/// Gets or sets the unique ID of the feature.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the featue.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the feature details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Creates a copy of the feature.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Feature Copy()
		{
			Feature f = new Feature();

			f.ID = fID;
			f.Name = fName;
			f.Details = fDetails;

			return f;
		}

		/// <summary>
		/// Returns the name of the feature.
		/// </summary>
		/// <returns>Returns the name of the feature.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	#region Weapon

	/// <summary>
	/// Enumeration containing weapon categories.
	/// </summary>
	public enum WeaponCategory
	{
		/// <summary>
		/// Simple weapons.
		/// </summary>
		Simple,

		/// <summary>
		/// Military weapons.
		/// </summary>
		Military,

		/// <summary>
		/// Superior weapons.
		/// </summary>
		Superior
	}

	/// <summary>
	/// Enumeration containing weapon types.
	/// </summary>
	public enum WeaponType
	{
		/// <summary>
		/// Melee weapons.
		/// </summary>
		Melee,

		/// <summary>
		/// Ranged weapons.
		/// </summary>
		Ranged
	}

	/// <summary>
	/// Class representing a weapon.
	/// </summary>
	[Serializable]
	public class Weapon : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the weapon.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of the weapon.
        /// </summary>
        public string Name
        {
            get { return fName; }
            set { fName = value; }
        }
        string fName = "";

		/// <summary>
		/// Gets or sets the weapon's category.
		/// </summary>
		public WeaponCategory Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		WeaponCategory fCategory = WeaponCategory.Simple;

		/// <summary>
		/// Gets or sets the weapon's type.
		/// </summary>
		public WeaponType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		WeaponType fType = WeaponType.Melee;

		/// <summary>
		/// Gets or sets whether the weapon must be used two-handed.
		/// </summary>
		public bool TwoHanded
		{
			get { return fTwoHanded; }
			set { fTwoHanded = value; }
		}
		bool fTwoHanded = false;

		/// <summary>
        /// Gets or sets the weapon's proficiency bonus.
        /// </summary>
        public int Proficiency
        {
            get { return fProficiency; }
            set { fProficiency = value; }
        }
        int fProficiency = 2;

        /// <summary>
        /// Gets or sets the weapon's damage.
        /// </summary>
        public string Damage
        {
            get { return fDamage; }
            set { fDamage = value; }
        }
        string fDamage = "";

        /// <summary>
        /// Gets or sets the range of the weapon.
        /// </summary>
        public string Range
        {
            get { return fRange; }
            set { fRange = value; }
        }
        string fRange = "";

        /// <summary>
        /// Gets or sets the price of the weapon.
        /// </summary>
        public string Price
        {
            get { return fPrice; }
            set { fPrice = value; }
        }
        string fPrice = "";

        /// <summary>
        /// Gets or sets the weight of the weapon.
        /// </summary>
        public string Weight
        {
            get { return fWeight; }
            set { fWeight = value; }
        }
        string fWeight = "";

        /// <summary>
        /// Gets or sets the weapon group(s).
        /// </summary>
        public string Group
        {
            get { return fGroup; }
            set { fGroup = value; }
        }
        string fGroup = "";

        /// <summary>
        /// Gets or sets the weapon properties.
        /// </summary>
        public string Properties
        {
            get { return fProperties; }
            set { fProperties = value; }
        }
        string fProperties = "";

        /// <summary>
        /// Gets or sets the weapon description.
        /// </summary>
        public string Description
        {
            get { return fDescription; }
            set { fDescription = value; }
        }
        string fDescription = "";

        /// <summary>
        /// Creates a copy of the weapon.
        /// </summary>
        /// <returns>Returns the copy.</returns>
        public Weapon Copy()
        {
            Weapon w = new Weapon();

            w.ID = fID;
            w.Name = fName;
            w.Category = fCategory;
			w.Type = fType;
            w.TwoHanded = fTwoHanded;
            w.Proficiency = fProficiency;
            w.Damage = fDamage;
            w.Range = fRange;
            w.Price = fPrice;
            w.Weight = fWeight;
            w.Group = fGroup;
            w.Properties = fProperties;
            w.Description = fDescription;

            return w;
        }
	}

	#endregion

	#region Ritual

	/// <summary>
	/// Ritual categories.
	/// </summary>
	public enum RitualCategory
	{
		/// <summary>
		/// Binding ritual.
		/// </summary>
		Binding,

		/// <summary>
		/// Creation ritual.
		/// </summary>
		Creation,

		/// <summary>
		/// Deception ritual.
		/// </summary>
		Deception,

		/// <summary>
		/// Divination ritual.
		/// </summary>
		Divination,

		/// <summary>
		/// Exploration ritual.
		/// </summary>
		Exploration,

		/// <summary>
		/// Restoration ritual.
		/// </summary>
		Restoration,

		/// <summary>
		/// Scrying ritual.
		/// </summary>
		Scrying,

		/// <summary>
		/// Travel ritual.
		/// </summary>
		Travel,

		/// <summary>
		/// Warding ritual.
		/// </summary>
		Warding
	}

	/// <summary>
	/// Class representing a ritual.
	/// </summary>
	[Serializable]
	public class Ritual : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the ritual.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the ritual.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the ritual's read-aloud text.
		/// </summary>
		public string ReadAloud
		{
			get { return fReadAloud; }
			set { fReadAloud = value; }
		}
		string fReadAloud = "";

		/// <summary>
		/// Gets or sets the level of the ritual.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = 1;

		/// <summary>
		/// Gets or sets the ritual's category.
		/// </summary>
		public RitualCategory Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		RitualCategory fCategory = RitualCategory.Binding;

		/// <summary>
		/// Gets or sets the time required for the ritual.
		/// </summary>
		public string Time
		{
			get { return fTime; }
			set { fTime = value; }
		}
		string fTime = "";

		/// <summary>
		/// Gets or sets the duration of the ritual.
		/// </summary>
		public string Duration
		{
			get { return fDuration; }
			set { fDuration = value; }
		}
		string fDuration = "";

		/// <summary>
		/// Gets or sets the component cost for the ritual.
		/// </summary>
		public string ComponentCost
		{
			get { return fComponentCost; }
			set { fComponentCost = value; }
		}
		string fComponentCost = "";

		/// <summary>
		/// Gets or sets the market price for the ritual.
		/// </summary>
		public string MarketPrice
		{
			get { return fMarketPrice; }
			set { fMarketPrice = value; }
		}
		string fMarketPrice = "";

		/// <summary>
		/// Gets or sets the ritual's key skill.
		/// </summary>
		public string KeySkill
		{
			get { return fKeySkill; }
			set { fKeySkill = value; }
		}
		string fKeySkill = "";

		/// <summary>
		/// Gets or sets the ritual's details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Creates a copy of he ritual.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Ritual Copy()
		{
			Ritual r = new Ritual();

			r.ID = fID;
			r.Name = fName;
			r.ReadAloud = fReadAloud;
			r.Level = fLevel;
			r.Category = fCategory;
			r.Time = fTime;
			r.Duration = fDuration;
			r.ComponentCost = fComponentCost;
			r.MarketPrice = fMarketPrice;
			r.KeySkill = fKeySkill;
			r.Details = fDetails;

			return r;
		}
	}

	#endregion

	/// <summary>
	/// Class representing a set of information about a creature type.
	/// </summary>
	[Serializable]
	public class CreatureLore : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the creature.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the creature.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the name of the skill to be used.
		/// </summary>
		public string SkillName
		{
			get { return fSkillName; }
			set { fSkillName = value; }
		}
		string fSkillName = "";

		/// <summary>
		/// Gets or sets the creature information.
		/// </summary>
		public List<Pair<int, string>> Information
		{
			get { return fInformation; }
			set { fInformation = value; }
		}
		List<Pair<int, string>> fInformation = new List<Pair<int,string>>();

		/// <summary>
		/// Creates a copy of the creature lore.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public CreatureLore Copy()
		{
			CreatureLore cl = new CreatureLore();

			cl.ID = fID;
			cl.Name = fName;
			cl.SkillName = fSkillName;

			foreach (Pair<int, string> info in fInformation)
				cl.Information.Add(new Pair<int, string>(info.First, info.Second));

			return cl;
		}

		/// <summary>
		/// Returns the name of the creature type.
		/// </summary>
		/// <returns>Returns the name of the creature type.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a disease.
	/// </summary>
	[Serializable]
	public class Disease : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the disease.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the disease.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the level of the disease.
		/// </summary>
		public string Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		string fLevel = "";

		/// <summary>
		/// Gets or sets the disease details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the disease attack details.
		/// </summary>
		public string Attack
		{
			get { return fAttack; }
			set { fAttack = value; }
		}
		string fAttack = "";

		/// <summary>
		/// Gets or sets the endurance DC to improve.
		/// </summary>
		public string ImproveDC
		{
			get { return fImproveDC; }
			set { fImproveDC = value; }
		}
		string fImproveDC = "";

		/// <summary>
		/// Gets or sets the endurance DC to maintain.
		/// </summary>
		public string MaintainDC
		{
			get { return fMaintainDC; }
			set { fMaintainDC = value; }
		}
		string fMaintainDC = "";

		/// <summary>
		/// Gets or sets the disease levels.
		/// </summary>
		public List<string> Levels
		{
			get { return fLevels; }
			set { fLevels = value; }
		}
		List<string> fLevels = new List<string>();

		/// <summary>
		/// Creates a copy of the disease.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Disease Copy()
		{
			Disease d = new Disease();

			d.ID = fID;
			d.Name = fName;
			d.Level = fLevel;
			d.Details = fDetails;
			d.Attack = fAttack;
			d.ImproveDC = fImproveDC;
			d.MaintainDC = fMaintainDC;
			d.Levels.AddRange(fLevels);

			return d;
		}

		/// <summary>
		/// Returns the name of the disease.
		/// </summary>
		/// <returns>Returns the name of the disease.</returns>
		public override string ToString()
		{
			return fName;
		}
	}

	/// <summary>
	/// Class representing a poison.
	/// </summary>
	[Serializable]
	public class Poison : IPlayerOption
	{
		/// <summary>
		/// Gets or sets the unique ID of the poison.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the poison.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the level of the poison.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = 1;

		/// <summary>
		/// Gets or sets the poison details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Gets or sets the poison sections.
		/// </summary>
		public List<PlayerPowerSection> Sections
		{
			get { return fSections; }
			set { fSections = value; }
		}
		List<PlayerPowerSection> fSections = new List<PlayerPowerSection>();

		/// <summary>
		/// Creates a copy of the poison.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Poison Copy()
		{
			Poison poison = new Poison();

			poison.ID = fID;
			poison.Name = fName;
			poison.Level = fLevel;
			poison.Details = fDetails;

			foreach (PlayerPowerSection section in fSections)
				poison.Sections.Add(section.Copy());

			return poison;
		}

		/// <summary>
		/// Returns the name of the poison.
		/// </summary>
		/// <returns>Returns the name of the poison.</returns>
		public override string ToString()
		{
			return fName;
		}
	}
}
