using System;
using System.Drawing;

namespace Masterplan.Data
{
	/// <summary>
	/// Interface for map tokens.
	/// </summary>
	public interface IToken
	{
	}

	/// <summary>
	/// A map token for a creature.
	/// </summary>
	[Serializable]
	public class CreatureToken : IToken
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CreatureToken()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="slot_id">The ID of the EncounterSlot.</param>
		/// <param name="data">The CombatData for this creature.</param>
		public CreatureToken(Guid slot_id, CombatData data)
		{
			SlotID = slot_id;
			Data = data;
		}

		/// <summary>
		/// The ID of the encounter slot.
		/// </summary>
		public Guid SlotID = Guid.Empty;

		/// <summary>
		/// The CombatData for this creature.
		/// </summary>
		public CombatData Data = null;
	}

	/// <summary>
	/// Types of custom token.
	/// </summary>
	public enum CustomTokenType
	{
		/// <summary>
		/// The custom token is shown as a token.
		/// </summary>
		Token,

		/// <summary>
		/// The custom token is shown as a translucent overlay.
		/// </summary>
		Overlay
	}

	/// <summary>
	/// Types of overlay style.
	/// </summary>
	public enum OverlayStyle
	{
		/// <summary>
		/// A rounded, translucent overlay.
		/// </summary>
		Rounded,

		/// <summary>
		/// A rectangular, opaque overlay.
		/// </summary>
		Block
	}

	/// <summary>
	/// A custom map token or overlay.
	/// </summary>
	[Serializable]
	public class CustomToken : IToken
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
		/// Gets or sets the token type.
		/// </summary>
		public CustomTokenType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		CustomTokenType fType = CustomTokenType.Token;

		/// <summary>
		/// Gets or sets the token name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the token details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

        /// <summary>
        /// Gets or sets the size of the token.
        /// </summary>
        public CreatureSize TokenSize
        {
            get { return fTokenSize; }
            set { fTokenSize = value; }
        }
        CreatureSize fTokenSize = CreatureSize.Medium;

        /// <summary>
        /// Gets or sets the size of the overlay.
        /// </summary>
        public Size OverlaySize
        {
            get { return fOverlaySize; }
            set { fOverlaySize = value; }
        }
        Size fOverlaySize = new Size(3, 3);

		/// <summary>
		/// Gets or sets the style of the overlay.
		/// </summary>
		public OverlayStyle OverlayStyle
		{
			get { return fOverlayStyle; }
			set { fOverlayStyle = value; }
		}
		OverlayStyle fOverlayStyle = OverlayStyle.Rounded;

        /// <summary>
        /// Gets or sets the colour of the token.
        /// </summary>
        public Color Colour
        {
            get { return fColour; }
            set { fColour = value; }
        }
        Color fColour = Color.DarkBlue;

		/// <summary>
		/// Gets or sets the token / overlay image.
		/// </summary>
		public Image Image
		{
			get { return fImage; }
			set { fImage = value; }
		}
		Image fImage = null;

        /// <summary>
        /// Gets or sets whether the overlay represents difficult terrain.
        /// </summary>
        public bool DifficultTerrain
        {
            get { return fDifficultTerrain; }
            set { fDifficultTerrain = value; }
        }
        bool fDifficultTerrain = false;

        /// <summary>
        /// Gets or sets whether the overlay obscures line of sight.
        /// </summary>
        public bool Opaque
        {
            get { return fOpaque; }
            set { fOpaque = value; }
        }
        bool fOpaque = false;

        /// <summary>
        /// Gets or sets the CombatData for this token.
        /// </summary>
        public CombatData Data
        {
            get { return fData; }
            set { fData = value; }
        }
        CombatData fData = new CombatData();

        /// <summary>
        /// Gets or sets the terrain power for this overlay.
        /// </summary>
        public TerrainPower TerrainPower
        {
            get { return fTerrainPower; }
            set { fTerrainPower = value; }
        }
        TerrainPower fTerrainPower = null;

		/// <summary>
		/// The ID of the creature or hero on which the token is centred.
		/// </summary>
		public Guid CreatureID
		{
			get { return fCreatureID; }
			set { fCreatureID = value; }
		}
		Guid fCreatureID = Guid.Empty;

		/// <summary>
		/// Creates a copy of the CustomToken.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public CustomToken Copy()
		{
			CustomToken ct = new CustomToken();

			ct.ID = fID;
			ct.Type = fType;
			ct.Name = fName;
			ct.Details = fDetails;
			ct.TokenSize = fTokenSize;
            ct.OverlaySize = fOverlaySize;
			ct.OverlayStyle = fOverlayStyle;
			ct.Colour = fColour;
			ct.Image = fImage;
            ct.DifficultTerrain = fDifficultTerrain;
            ct.Opaque = fOpaque;
            ct.Data = fData.Copy();
            ct.TerrainPower = (fTerrainPower != null) ? fTerrainPower.Copy() : null;
			ct.CreatureID = fCreatureID;

			return ct;
		}
	}

    /// <summary>
    /// Types of terrain power.
    /// </summary>
    public enum TerrainPowerType
    {
        /// <summary>
        /// The terrain power can be used more than once.
        /// </summary>
        AtWill,

        /// <summary>
        /// The terrain power can be used once.
        /// </summary>
        SingleUse
    }

    /// <summary>
    /// A terrain power.
    /// </summary>
    [Serializable]
    public class TerrainPower
    {
		/// <summary>
		/// Gets or sets the power's ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the power name.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
        /// Gets or sets the power type.
        /// </summary>
        public TerrainPowerType Type
        {
            get { return fType; }
            set { fType = value; }
        }
        TerrainPowerType fType = TerrainPowerType.SingleUse;

        /// <summary>
        /// Gets or sets the flavour text
        /// </summary>
        public string FlavourText
        {
            get { return fFlavourText; }
            set { fFlavourText = value; }
        }
        string fFlavourText = "";

        /// <summary>
        /// Gets or sets the power's required action.
        /// </summary>
        public ActionType Action
        {
            get { return fAction; }
            set { fAction = value; }
        }
        ActionType fAction = ActionType.Standard;

        /// <summary>
        /// Gets or sets the power's requirement.
        /// </summary>
        public string Requirement
        {
            get { return fRequirement; }
            set { fRequirement = value; }
        }
        string fRequirement = "";

        /// <summary>
        /// Gets or sets the power's check details.
        /// </summary>
        public string Check
        {
            get { return fCheck; }
            set { fCheck = value; }
        }
        string fCheck = "";

        /// <summary>
        /// Gets or sets the power's success details.
        /// </summary>
        public string Success
        {
            get { return fSuccess; }
            set { fSuccess = value; }
        }
        string fSuccess = "";

        /// <summary>
        /// Gets or sets the power's failure details.
        /// </summary>
        public string Failure
        {
            get { return fFailure; }
            set { fFailure = value; }
        }
        string fFailure = "";

        /// <summary>
        /// Gets or sets the power's target.
        /// </summary>
        public string Target
        {
            get { return fTarget; }
            set { fTarget = value; }
        }
        string fTarget = "";

        /// <summary>
        /// Gets or sets the power's attack details.
        /// </summary>
        public string Attack
        {
            get { return fAttack; }
            set { fAttack = value; }
        }
        string fAttack = "";

        /// <summary>
        /// Gets or sets the power's hit details.
        /// </summary>
        public string Hit
        {
            get { return fHit; }
            set { fHit = value; }
        }
        string fHit = "";

        /// <summary>
        /// Gets or sets the power's miss details.
        /// </summary>
        public string Miss
        {
            get { return fMiss; }
            set { fMiss = value; }
        }
        string fMiss = "";

        /// <summary>
        /// Gets or sets the power's effect details.
        /// </summary>
        public string Effect
        {
            get { return fEffect; }
            set { fEffect = value; }
        }
        string fEffect = "";

        /// <summary>
        /// Creates a copy of the terrain power.
        /// </summary>
        /// <returns>Returns the copy.</returns>
        public TerrainPower Copy()
        {
            TerrainPower tp = new TerrainPower();

			tp.ID = fID;
            tp.Name = fName;
            tp.Type = fType;
            tp.FlavourText = fFlavourText;
            tp.Action = fAction;
            tp.Requirement = fRequirement;
            tp.Check = fCheck;
            tp.Success = fSuccess;
            tp.Failure = fFailure;
            tp.Target = fTarget;
            tp.Attack = fAttack;
            tp.Hit = fHit;
            tp.Miss = fMiss;
            tp.Effect = fEffect;

            return tp;
        }
    }
}
