#nullable disable

using MasterplanXP.MigrationTool.Services.Utils;
using System;
using System.Collections.Generic;

namespace MasterplanXP.MigrationTool.Models.Legacy
{
    /*
     * JUNIOR DEVELOPER GUIDE:
     * This class represents an Artifact in D&D 4th Edition.
     * Unlike standard Magic Items, Artifacts are often sentient or semi-sentient and possess 
     * a "Concordance" score that measures the wielder's relationship with the item.
     * 
     * Key D&D 4e Concepts:
     * - Tier: The power level suitable for the item (Heroic, Paragon, or Epic).
     * - Concordance: A numeric score (typically 1-20) that changes based on the wielder's actions.
     * - Concordance Levels: Different states of the item (e.g., Pleased, Angered) that grant 
     *   different powers or penalties.
     * - Goals: The artifact's own objectives, which the DM uses to determine concordance changes.
     * 
     * THINNING PROCESS NOTES (MasterplanXP Migration):
     * 1. [Serializable]: Legacy attribute used for BinaryFormatter. Remove in MasterplanXP.
     * 2. Pair<string, string>: Generic utility class. In MPX, use a more descriptive DTO 
     *    (e.g., ConcordanceRuleDTO) or a C# Tuple.
     * 3. MagicItemSection: The artifact inherits/uses sections from the MagicItem system. 
     *    Ensure this dependency is mapped in the Bridge.
     * 4. AddStandardConcordanceLevels: This method seeds default business data. This logic 
     *    should be moved to a Factory or a DefaultDataService in MasterplanXP.Core.
     * 5. Manual Copying: Use AutoMapper or a dedicated mapping service in the new project.
     */

    /// <summary>
    /// Represents a unique, powerful magical artifact with concordance-based progression.
    /// </summary>
    [Serializable]
    public class Artifact
    {
        /// <summary>
        /// Default constructor. Initializes a new instance of the Artifact class.
        /// </summary>
        public Artifact()
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier for the artifact.
        /// </summary>
        public Guid ID
        {
            get { return fID; }
            set { fID = value; }
        }
        Guid fID = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the name of the artifact (e.g., "The Axe of the Dwarvish Lords").
        /// </summary>
        public string Name
        {
            get { return fName; }
            set { fName = value; }
        }
        string fName = "";

        /// <summary>
        /// Gets or sets the tier (Heroic, Paragon, Epic) for which the artifact is designed.
        /// </summary>
        public Tier Tier
        {
            get { return fTier; }
            set { fTier = value; }
        }
        Tier fTier = Tier.Heroic;

        /// <summary>
        /// Gets or sets the artifact's flavor text or visual description.
        /// </summary>
        public string Description
        {
            get { return fDescription; }
            set { fDescription = value; }
        }
        string fDescription = "";

        /// <summary>
        /// Gets or sets the mechanical details and backstory of the artifact.
        /// </summary>
        public string Details
        {
            get { return fDetails; }
            set { fDetails = value; }
        }
        string fDetails = "";

        /// <summary>
        /// Gets or sets the artifact's objectives, which guide concordance changes.
        /// </summary>
        public string Goals
        {
            get { return fGoals; }
            set { fGoals = value; }
        }
        string fGoals = "";

        /// <summary>
        /// Gets or sets roleplaying tips for the DM to use when the artifact "speaks" or influences the wielder.
        /// </summary>
        public string RoleplayingTips
        {
            get { return fRoleplayingTips; }
            set { fRoleplayingTips = value; }
        }
        string fRoleplayingTips = "";

        /// <summary>
        /// Gets or sets the collection of powers and properties associated with the artifact.
        /// </summary>
        public List<MagicItemSection> Sections
        {
            get { return fSections; }
            set { fSections = value; }
        }
        List<MagicItemSection> fSections = new List<MagicItemSection>();

        /// <summary>
        /// Gets or sets the rules that increase or decrease concordance (e.g., "Kill a giant: +1").
        /// THINNING NOTE: Replace Pair<string, string> with a concrete ConcordanceRule class.
        /// </summary>
        public List<Pair<string, string>> ConcordanceRules
        {
            get { return fConcordanceRules; }
            set { fConcordanceRules = value; }
        }
        List<Pair<string, string>> fConcordanceRules = new List<Pair<string, string>>();

        /// <summary>
        /// Gets or sets the various concordance states (Pleased, Satisfied, etc.).
        /// </summary>
        public List<ArtifactConcordance> ConcordanceLevels
        {
            get { return fConcordanceLevels; }
            set { fConcordanceLevels = value; }
        }
        List<ArtifactConcordance> fConcordanceLevels = new List<ArtifactConcordance>();

        /// <summary>
        /// Seeds the artifact with standard D&D 4e concordance levels and value ranges.
        /// THINNING NOTE: Move to a DataFactory in the Core project.
        /// </summary>
        public void AddStandardConcordanceLevels()
        {
            fConcordanceLevels.Clear();
            fConcordanceLevels.Add(new ArtifactConcordance("Pleased", "16-20"));
            fConcordanceLevels.Add(new ArtifactConcordance("Satisfied", "12-15"));
            fConcordanceLevels.Add(new ArtifactConcordance("Normal", "5-11"));
            fConcordanceLevels.Add(new ArtifactConcordance("Unsatisfied", "1-4"));
            fConcordanceLevels.Add(new ArtifactConcordance("Angered", "0 or lower"));
            fConcordanceLevels.Add(new ArtifactConcordance("Moving On", ""));
        }

        /// <summary>
        /// Creates a deep copy of the artifact instance.
        /// </summary>
        /// <returns>A new Artifact instance with copied values.</returns>
        public Artifact Copy()
        {
            Artifact a = new Artifact();

            a.ID = fID;
            a.Name = fName;
            a.Tier = fTier;
            a.Description = fDescription;
            a.Details = fDetails;
            a.Goals = fGoals;
            a.RoleplayingTips = fRoleplayingTips;

            a.Sections.Clear();
            foreach (MagicItemSection mis in fSections)
                a.Sections.Add(mis.Copy());

            a.ConcordanceRules.Clear();
            foreach (Pair<string, string> pair in fConcordanceRules)
            {
                Pair<string, string> rule = new Pair<string, string>(pair.First, pair.Second);
                a.ConcordanceRules.Add(rule);
            }

            a.ConcordanceLevels.Clear();
            foreach (ArtifactConcordance ac in fConcordanceLevels)
                a.ConcordanceLevels.Add(ac.Copy());

            return a;
        }

        /// <summary>
        /// Returns the name of the artifact.
        /// </summary>
        /// <returns>The artifact's name.</returns>
        public override string ToString()
        {
            return fName;
        }
    }

    /// <summary>
    /// Represents a specific state of an artifact's concordance (e.g., "Pleased").
    /// </summary>
    [Serializable]
    public class ArtifactConcordance
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ArtifactConcordance()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArtifactConcordance class.
        /// </summary>
        /// <param name="name">The name of the state (e.g., "Normal").</param>
        /// <param name="value_range">The numeric range for this state (e.g., "5-11").</param>
        public ArtifactConcordance(string name, string value_range)
        {
            fName = name;
            fValueRange = value_range;
        }

        /// <summary>
        /// Gets or sets the name of the concordance level.
        /// </summary>
        public string Name
        {
            get { return fName; }
            set { fName = value; }
        }
        string fName = "";

        /// <summary>
        /// Gets or sets the range of concordance scores that trigger this level (e.g., "16-20").
        /// </summary>
        public string ValueRange
        {
            get { return fValueRange; }
            set { fValueRange = value; }
        }
        string fValueRange = "";

        /// <summary>
        /// Gets or sets a quote from the artifact representing this state.
        /// </summary>
        public string Quote
        {
            get { return fQuote; }
            set { fQuote = value; }
        }
        string fQuote = "";

        /// <summary>
        /// Gets or sets a description of how the wielder feels or how the item's appearance changes.
        /// </summary>
        public string Description
        {
            get { return fDescription; }
            set { fDescription = value; }
        }
        string fDescription = "";

        /// <summary>
        /// Gets or sets the powers or properties unlocked at this level.
        /// </summary>
        public List<MagicItemSection> Sections
        {
            get { return fSections; }
            set { fSections = value; }
        }
        List<MagicItemSection> fSections = new List<MagicItemSection>();

        /// <summary>
        /// Creates a deep copy of the concordance level.
        /// </summary>
        /// <returns>A new ArtifactConcordance instance with copied values.</returns>
        public ArtifactConcordance Copy()
        {
            ArtifactConcordance ac = new ArtifactConcordance();

            ac.Name = fName;
            ac.ValueRange = fValueRange;
            ac.Quote = fQuote;
            ac.Description = fDescription;

            ac.Sections.Clear();
            foreach (MagicItemSection mis in fSections)
                ac.Sections.Add(mis.Copy());

            return ac;
        }
    }
}


