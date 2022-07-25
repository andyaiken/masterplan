using System;
using System.Collections.Generic;
//using System.Drawing;

//using Masterplan.Controls;
//using Masterplan.Tools;
//using Masterplan.UI;

namespace Masterplan
{
    /// <summary>
    /// Class used to store Lang values.
    /// </summary>
	[Serializable]
    public class I18N
	{
		/// <summary>
		/// No Comment default value.
		/// Program.cs
		/// </summary>
		public string Loading
		{
			get { return fLoading; }
			set { fLoading = value; }
		}
		string fLoading = "Loading";

		/// <summary>
		/// No Comment default value.
		/// Program.cs
		/// </summary>
		public string StartingMasterplan
		{
			get { return fStartingMasterplan; }
			set { fStartingMasterplan = value; }
		}
		string fStartingMasterplan = "Starting Masterplan";

		/// <summary>
		/// No Comment default value.
		/// Program.cs
		/// </summary>
		public string LoadingLibraries
		{
			get { return fLoadingLibraries; }
			set { fLoadingLibraries = value; }
		}
		string fLoadingLibraries = "Loading libraries";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Add
		{
			get { return fAdd; }
			set { fAdd = value; }
		}
		string fAdd = "Add";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Encounter
		{
			get { return fEncounter; }
			set { fEncounter = value; }
		}
		string fEncounter = "Encounter";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string SkillChallenge
		{
			get { return fSkillChallenge; }
			set { fSkillChallenge = value; }
		}
		string fSkillChallenge = "Skill Challenge";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string TrapHazzard
		{
			get { return fTrapHazzard; }
			set { fTrapHazzard = value; }
		}
		string fTrapHazzard = "Trap / Hazard";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Quest
		{
			get { return fQuest; }
			set { fQuest = value; }
		}
		string fQuest = "Quest";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Remove
		{
			get { return fRemove; }
			set { fRemove = value; }
		}
		string fRemove = "Remove";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Cut
		{
			get { return fCut; }
			set { fCut = value; }
		}
		string fCut = "Cut";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Copy
		{
			get { return fCopy; }
			set { fCopy = value; }
		}
		string fCopy = "Copy";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Paste
		{
			get { return fPaste; }
			set { fPaste = value; }
		}
		string fPaste = "Paste";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Search
		{
			get { return fSearch; }
			set { fSearch = value; }
		}
		string fSearch = "Search";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string View
		{
			get { return fView; }
			set { fView = value; }
		}
		string fView = "View";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string DefaultView
		{
			get { return fDefaultView; }
			set { fDefaultView = value; }
		}
		string fDefaultView = "Default View";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowEncounters
		{
			get { return fShowEncounters; }
			set { fShowEncounters = value; }
		}
		string fShowEncounters = "Show Encounters";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowTrapsHazards
		{
			get { return fShowTrapsHazards; }
			set { fShowTrapsHazards = value; }
		}
		string fShowTrapsHazards = "Show Traps / Hazards";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowSkillChallenges
		{
			get { return fShowSkillChallenges; }
			set { fShowSkillChallenges = value; }
		}
		string fShowSkillChallenges = "Show Skill Challenges";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowQuests
		{
			get { return fShowQuests; }
			set { fShowQuests = value; }
		}
		string fShowQuests = "Show Quests";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowTreasureParcels
		{
			get { return fShowTreasureParcels; }
			set { fShowTreasureParcels = value; }
		}
		string fShowTreasureParcels = "Show Treasure Parcels";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Highlighting
		{
			get { return fHighlighting; }
			set { fHighlighting = value; }
		}
		string fHighlighting = "Highlighting";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowLinks
		{
			get { return fShowLinks; }
			set { fShowLinks = value; }
		}
		string fShowLinks = "Show Links";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Curved
		{
			get { return fCurved; }
			set { fCurved = value; }
		}
		string fCurved = "Curved";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Angled
		{
			get { return fAngled; }
			set { fAngled = value; }
		}
		string fAngled = "Angled";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Straight
		{
			get { return fStraight; }
			set { fStraight = value; }
		}
		string fStraight = "Straight";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowLevelling
		{
			get { return fShowLevelling; }
			set { fShowLevelling = value; }
		}
		string fShowLevelling = "Show Levelling";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowTooltips
		{
			get { return fShowTooltips; }
			set { fShowTooltips = value; }
		}
		string fShowTooltips = "Show Tooltips";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowNavigation
		{
			get { return fShowNavigation; }
			set { fShowNavigation = value; }
		}
		string fShowNavigation = "Show Navigation";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowPreview
		{
			get { return fShowPreview; }
			set { fShowPreview = value; }
		}
		string fShowPreview = "Show Preview";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Flowchart
		{
			get { return fFlowchart; }
			set { fFlowchart = value; }
		}
		string fFlowchart = "Flowchart";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Print
		{
			get { return fPrint; }
			set { fPrint = value; }
		}
		string fPrint = "Print";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Export
		{
			get { return fExport; }
			set { fExport = value; }
		}
		string fExport = "Export";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string MaximumAvailableXP
		{
			get { return fMaximumAvailableXP; }
			set { fMaximumAvailableXP = value; }
		}
		string fMaximumAvailableXP = "Maximum Available XP";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Advanced
		{
			get { return fAdvanced; }
			set { fAdvanced = value; }
		}
		string fAdvanced = "Advanced";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PlotDesignIssues
		{
			get { return fPlotDesignIssues; }
			set { fPlotDesignIssues = value; }
		}
		string fPlotDesignIssues = "Plot Design Issues";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string AdjustDifficulty
		{
			get { return fAdjustDifficulty; }
			set { fAdjustDifficulty = value; }
		}
		string fAdjustDifficulty = "Adjust Difficulty";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string AddPoint
		{
			get { return fAddPoint; }
			set { fAddPoint = value; }
		}
		string fAddPoint = "Add Point";


		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string DisconnectPoint
		{
			get { return fDisconnectPoint; }
			set { fDisconnectPoint = value; }
		}
		string fDisconnectPoint = "Disconnect Point";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string DisconnectFrom
		{
			get { return fDisconnectFrom; }
			set { fDisconnectFrom = value; }
		}
		string fDisconnectFrom = "Disconnect From";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string MoveToSubplot
		{
			get { return fMoveToSubplot; }
			set { fMoveToSubplot = value; }
		}
		string fMoveToSubplot = "Move To Subplot";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string State
		{
			get { return fState; }
			set { fState = value; }
		}
		string fState = "State";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Normal
		{
			get { return fNormal; }
			set { fNormal = value; }
		}
		string fNormal = "Normal";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Completed
		{
			get { return fCompleted; }
			set { fCompleted = value; }
		}
		string fCompleted = "Completed";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Skipped
		{
			get { return fSkipped; }
			set { fSkipped = value; }
		}
		string fSkipped = "Skipped";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Edit
		{
			get { return fEdit; }
			set { fEdit = value; }
		}
		string fEdit = "Edit";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExploreSubplot
		{
			get { return fExploreSubplot; }
			set { fExploreSubplot = value; }
		}
		string fExploreSubplot = "Explore Subplot";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string File
		{
			get { return fFile; }
			set { fFile = value; }
		}
		string fFile = "File";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string NewProject
		{
			get { return fNewProject; }
			set { fNewProject = value; }
		}
		string fNewProject = "New Project";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string OpenProject
		{
			get { return fOpenProject; }
			set { fOpenProject = value; }
		}
		string fOpenProject = "Open Project";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string SaveProject
		{
			get { return fSaveProject; }
			set { fSaveProject = value; }
		}
		string fSaveProject = "Save Project";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string SaveProjectAs
		{
			get { return fSaveProjectAs; }
			set { fSaveProjectAs = value; }
		}
		string fSaveProjectAs = "Save Project As";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string CreateDungeonDelve
		{
			get { return fCreateDungeonDelve; }
			set { fCreateDungeonDelve = value; }
		}
		string fCreateDungeonDelve = "Create a Dungeon Delve";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Exit
		{
			get { return fExit; }
			set { fExit = value; }
		}
		string fExit = "Exit";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Project
		{
			get { return fProject; }
			set { fProject = value; }
		}
		string fProject = "Project";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ProjectProperties
		{
			get { return fProjectProperties; }
			set { fProjectProperties = value; }
		}
		string fProjectProperties = "Project Properties";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ProjectOverview
		{
			get { return fProjectOverview; }
			set { fProjectOverview = value; }
		}
		string fProjectOverview = "Project Overview";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ProjectChecklist
		{
			get { return fProjectChecklist; }
			set { fProjectChecklist = value; }
		}
		string fProjectChecklist = "Project Checklist";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ProjectCampaignSettings
		{
			get { return fProjectCampaignSettings; }
			set { fProjectCampaignSettings = value; }
		}
		string fProjectCampaignSettings = "Campaign Settings";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PasswordProtection
		{
			get { return fPasswordProtection; }
			set { fPasswordProtection = value; }
		}
		string fPasswordProtection = "Password Protection";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string TacticalMaps
		{
			get { return fTacticalMaps; }
			set { fTacticalMaps = value; }
		}
		string fTacticalMaps = "Tactical Maps";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string RegionalMaps
		{
			get { return fRegionalMaps; }
			set { fRegionalMaps = value; }
		}
		string fRegionalMaps = "Regional Maps";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PlayerCharacters
		{
			get { return fPlayerCharacters; }
			set { fPlayerCharacters = value; }
		}
		string fPlayerCharacters = "Player Characters";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string TreasureParcels
		{
			get { return fTreasureParcels; }
			set { fTreasureParcels = value; }
		}
		string fTreasureParcels = "Treasure Parcels";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string EncounterDecks
		{
			get { return fEncounterDecks; }
			set { fEncounterDecks = value; }
		}
		string fEncounterDecks = "Encounter Decks";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string CustomCreaturesNPC
		{
			get { return fCustomCreaturesNPC; }
			set { fCustomCreaturesNPC = value; }
		}
		string fCustomCreaturesNPC = "Custom Creatures and NPCs";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Calendars
		{
			get { return fCalendars; }
			set { fCalendars = value; }
		}
		string fCalendars = "Calendars";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PausedEncounters
		{
			get { return fPausedEncounters; }
			set { fPausedEncounters = value; }
		}
		string fPausedEncounters = "Paused Encounters";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PlayerView
		{
			get { return fPlayerView; }
			set { fPlayerView = value; }
		}
		string fPlayerView = "Player View";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Show
		{
			get { return fShow; }
			set { fShow = value; }
		}
		string fShow = "Show";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Clear
		{
			get { return fClear; }
			set { fClear = value; }
		}
		string fClear = "Clear";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Tools
		{
			get { return fTools; }
			set { fTools = value; }
		}
		string fTools = "Tools";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ImportProject
		{
			get { return fImportProject; }
			set { fImportProject = value; }
		}
		string fImportProject = "Import Project";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExportProject
		{
			get { return fExportProject; }
			set { fExportProject = value; }
		}
		string fExportProject = "Export Project";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExportHandout
		{
			get { return fExportHandout; }
			set { fExportHandout = value; }
		}
		string fExportHandout = "Export Handout";

		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Libraries
		{
			get { return fLibraries; }
			set { fLibraries = value; }
		}
		string fLibraries = "Libraries";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string AddIns
		{
			get { return fAddIns; }
			set { fAddIns = value; }
		}
		string fAddIns = "Add-Ins";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string TAddins
		{
			get { return fTAddins; }
			set { fTAddins = value; }
		}
		string fTAddins = "[add-ins]";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Preferences
		{
			get { return fPreferences; }
			set { fPreferences = value; }
		}
		string fPreferences = "Preferences";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string TextSize
		{
			get { return fTextSize; }
			set { fTextSize = value; }
		}
		string fTextSize = "Text Size";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Small
		{
			get { return fSmall; }
			set { fSmall = value; }
		}
		string fSmall = "Small";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Medium
		{
			get { return fMedium; }
			set { fMedium = value; }
		}
		string fMedium = "Medium";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Large
		{
			get { return fLarge; }
			set { fLarge = value; }
		}
		string fLarge = "Large";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ShowOtherDisplay
		{
			get { return fShowOtherDisplay; }
			set { fShowOtherDisplay = value; }
		}
		string fShowOtherDisplay = "Show on Other Display";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Help
		{
			get { return fHelp; }
			set { fHelp = value; }
		}
		string fHelp = "Help";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Manual
		{
			get { return fManual; }
			set { fManual = value; }
		}
		string fManual = "Manual";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string About
		{
			get { return fAbout; }
			set { fAbout = value; }
		}
		string fAbout = "About";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string SearchFor
		{
			get { return fSearchFor; }
			set { fSearchFor = value; }
		}
		string fSearchFor = "Search for";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string EditPlotPoint
		{
			get { return fEditPlotPoint; }
			set { fEditPlotPoint = value; }
		}
		string fEditPlotPoint = "Edit Plot Point";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Share
		{
			get { return fShare; }
			set { fShare = value; }
		}
		string fShare = "Share";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string SendPlayerView
		{
			get { return fSendPlayerView; }
			set { fSendPlayerView = value; }
		}
		string fSendPlayerView = "Send to Player View";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExportHTML
		{
			get { return fExportHTML; }
			set { fExportHTML = value; }
		}
		string fExportHTML = "Export to HTML";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExportFile
		{
			get { return fExportFile; }
			set { fExportFile = value; }
		}
		string fExportFile = "Export to File";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PlotWorkspace
		{
			get { return fPlotWorkspace; }
			set { fPlotWorkspace = value; }
		}
		string fPlotWorkspace = "Plot Workspace";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Background
		{
			get { return fBackground; }
			set { fBackground = value; }
		}
		string fBackground = "Background";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Information
		{
			get { return fInfoHdr; }
			set { fInfoHdr = value; }
		}
		string fInfoHdr = "Information";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string MoveUp
		{
			get { return fMoveUp; }
			set { fMoveUp = value; }
		}
		string fMoveUp = "Move Up";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string MoveDown
		{
			get { return fMoveDown; }
			set { fMoveDown = value; }
		}
		string fMoveDown = "Move Down";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string SelectedItem
		{
			get { return fSelectedItem; }
			set { fSelectedItem = value; }
		}
		string fSelectedItem = "Selected Item";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string AllItems
		{
			get { return fAllItems; }
			set { fAllItems = value; }
		}
		string fAllItems = "All Items";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Import
		{
			get { return fImport; }
			set { fImport = value; }
		}
		string fImport = "Import";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Publish
		{
			get { return fPublish; }
			set { fPublish = value; }
		}
		string fPublish = "Publish";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Encyclopedia
		{
			get { return fEncyclopedia; }
			set { fEncyclopedia = value; }
		}
		string fEncyclopedia = "Encyclopedia";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Entries
		{
			get { return fEntries; }
			set { fEntries = value; }
		}
		string fEntries = "Entries";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string AddEntry
		{
			get { return fAddEntry; }
			set { fAddEntry = value; }
		}
		string fAddEntry = "Add an Entry";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string AddGroup
		{
			get { return fAddGroup; }
			set { fAddGroup = value; }
		}
		string fAddGroup = "Add a Group";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string CampaignRules
		{
			get { return fCampaignRules; }
			set { fCampaignRules = value; }
		}
		string fCampaignRules = "Campaign Rules";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Races
		{
			get { return fRaces; }
			set { fRaces = value; }
		}
		string fRaces = "Races";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Classes
		{
			get { return fClasses; }
			set { fClasses = value; }
		}
		string fClasses = "Classes";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Themes
		{
			get { return fThemes; }
			set { fThemes = value; }
		}
		string fThemes = "Themes";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ParagonPaths
		{
			get { return fParagonPaths; }
			set { fParagonPaths = value; }
		}
		string fParagonPaths = "Paragon Paths";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string EpicDestinies
		{
			get { return fEpicDestinies; }
			set { fEpicDestinies = value; }
		}
		string fEpicDestinies = "Epic Destinies";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Backgrounds
		{
			get { return fBackgrounds; }
			set { fBackgrounds = value; }
		}
		string fBackgrounds = "Backgrounds";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string FeatsHeroicTier
		{
			get { return fFeatsHeroicTier; }
			set { fFeatsHeroicTier = value; }
		}
		string fFeatsHeroicTier = "Feats (heroic tier)";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string FeatsParagonTier
		{
			get { return fFeatsParagonTier; }
			set { fFeatsParagonTier = value; }
		}
		string fFeatsParagonTier = "Feats (paragon tier)";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string FeatsEpicTier
		{
			get { return fFeatsEpicTier; }
			set { fFeatsEpicTier = value; }
		}
		string fFeatsEpicTier = "Feats (epic tier)";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Weapons
		{
			get { return fWeapons; }
			set { fWeapons = value; }
		}
		string fWeapons = "Weapons";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Rituals
		{
			get { return fRituals; }
			set { fRituals = value; }
		}
		string fRituals = "Rituals";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string CreatureLore
		{
			get { return fCreatureLore; }
			set { fCreatureLore = value; }
		}
		string fCreatureLore = "Creature Lore";


		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Diseases
		{
			get { return fDiseases; }
			set { fDiseases = value; }
		}
		string fDiseases = "Diseases";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Poisons
		{
			get { return fPoisons; }
			set { fPoisons = value; }
		}
		string fPoisons = "Poisons";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string RulesElements
		{
			get { return fRulesElements; }
			set { fRulesElements = value; }
		}
		string fRulesElements = "Rules Elements";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Race
		{
			get { return fRace; }
			set { fRace = value; }
		}
		string fRace = "Race";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Class
		{
			get { return fClass; }
			set { fClass = value; }
		}
		string fClass = "Class";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Theme
		{
			get { return fTheme; }
			set { fTheme = value; }
		}
		string fTheme = "Theme";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ParagonPath
		{
			get { return fParagonPath; }
			set { fParagonPath = value; }
		}
		string fParagonPath = "Paragon Path";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string EpicDestiny
		{
			get { return fEpicDestiny; }
			set { fEpicDestiny = value; }
		}
		string fEpicDestiny = "Epic Destiny";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Feat
		{
			get { return fAddFeat; }
			set { fAddFeat = value; }
		}
		string fAddFeat = "Feat";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Weapon
		{
			get { return fWeapon; }
			set { fWeapon = value; }
		}
		string fWeapon = "Weapon";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Ritual
		{
			get { return fRitual; }
			set { fRitual = value; }
		}
		string fRitual = "Ritual";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Disease
		{
			get { return fAddDisease; }
			set { fAddDisease = value; }
		}
		string fAddDisease = "Disease";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Poison
		{
			get { return fAddPoison; }
			set { fAddPoison = value; }
		}
		string fAddPoison = "Poison";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string EncyclopediaEntry
		{
			get { return fEncyclopediaEntry; }
			set { fEncyclopediaEntry = value; }
		}
		string fEncyclopediaEntry = "Encyclopedia Entry";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Attachments
		{
			get { return fAttachments; }
			set { fAttachments = value; }
		}
		string fAttachments = "Attachments";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Attachment
		{
			get { return fAttachment; }
			set { fAttachment = value; }
		}
		string fAttachment = "Attachment";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		string fSize = "Size";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Extract
		{
			get { return fExtract; }
			set { fExtract = value; }
		}
		string fExtract = "Extract";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExtractToDesktop
		{
			get { return fExtractToDesktop; }
			set { fExtractToDesktop = value; }
		}
		string fExtractToDesktop = "Extract to Desktop";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExtractToDesktopAndOpen
		{
			get { return fExtractToDesktopAndOpen; }
			set { fExtractToDesktopAndOpen = value; }
		}
		string fExtractToDesktopAndOpen = "Extract to Desktop and Open";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Jotter
		{
			get { return fJotter; }
			set { fJotter = value; }
		}
		string fJotter = "Jotter";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Issues
		{
			get { return fIssues; }
			set { fIssues = value; }
		}
		string fIssues = "Issues";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Notes
		{
			get { return fNotes; }
			set { fNotes = value; }
		}
		string fNotes = "Notes";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string AddNote
		{
			get { return fAddNote; }
			set { fAddNote = value; }
		}
		string fAddNote = "Add Note";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string RemoveNote
		{
			get { return fRemoveNote; }
			set { fRemoveNote = value; }
		}
		string fRemoveNote = "Remove Note";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string SetCategory
		{
			get { return fSetCategory; }
			set { fSetCategory = value; }
		}
		string fSetCategory = "Set Category";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string InSessionReference
		{
			get { return fInSessionReference; }
			set { fInSessionReference = value; }
		}
		string fInSessionReference = "In-Session Reference";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PartyBreakdown
		{
			get { return fPartyBreakdown; }
			set { fPartyBreakdown = value; }
		}
		string fPartyBreakdown = "Party Breakdown";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string RandomGenerators
		{
			get { return fRandomGenerators; }
			set { fRandomGenerators = value; }
		}
		string fRandomGenerators = "Random Generators";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Generators
		{
			get { return fGenerators; }
			set { fGenerators = value; }
		}
		string fGenerators = "Generators";


		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string toolStrip1
		{
			get { return ftoolStrip1; }
			set { ftoolStrip1 = value; }
		}
		string ftoolStrip1 = "toolStrip1";


		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ElvishNames
		{
			get { return fElvishNames; }
			set { fElvishNames = value; }
		}
		string fElvishNames = "Elvish Names";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string DwarvishNames
		{
			get { return fDwarvishNames; }
			set { fDwarvishNames = value; }
		}
		string fDwarvishNames = "Dwarvish Names";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string HalflingNames
		{
			get { return fHalflingNames; }
			set { fHalflingNames = value; }
		}
		string fHalflingNames = "Halfling Names";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExoticNames
		{
			get { return fExoticNames; }
			set { fExoticNames = value; }
		}
		string fExoticNames = "Exotic Names";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ArtObjects
		{
			get { return fArtObjects; }
			set { fArtObjects = value; }
		}
		string fArtObjects = "Art Objects";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string BookTitles
		{
			get { return fBookTitles; }
			set { fBookTitles = value; }
		}
		string fBookTitles = "Book Titles";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string Potions
		{
			get { return fPotions; }
			set { fPotions = value; }
		}
		string fPotions = "Potions";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string NPCDescription
		{
			get { return fNPCDescription; }
			set { fNPCDescription = value; }
		}
		string fNPCDescription = "NPC Description";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string RoomDescription
		{
			get { return fRoomDescription; }
			set { fRoomDescription = value; }
		}
		string fRoomDescription = "Room Description";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ElvishText
		{
			get { return fElvishText; }
			set { fElvishText = value; }
		}
		string fElvishText = "Elvish Text";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string DwarvishText
		{
			get { return fDwarvishText; }
			set { fDwarvishText = value; }
		}
		string fDwarvishText = "Dwarvish Text";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string PrimordialText
		{
			get { return fPrimordialText; }
			set { fPrimordialText = value; }
		}
		string fPrimordialText = "Primordial Text";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string DieRoller
		{
			get { return fDieRoller; }
			set { fDieRoller = value; }
		}
		string fDieRoller = "Die Roller";

		
		/// <summary>
		/// No Comment default value.
		/// MainForm.Designer.cs
		/// </summary>
		public string ExtraLarge
		{
			get { return fExtraLarge; }
			set { fExtraLarge = value; }
		}
		string fExtraLarge = "Extra Large";

		
		/// <summary>
		/// No Comment default value.
		/// </summary>
		public string Cancel
		{
			get { return fCancel; }
			set { fCancel = value; }
		}
		string fCancel = "Cancel";


		/// <summary>
		/// No Comment default value.
		/// Data/Artifact.cs
		/// </summary>
		public string Pleased
		{
			get { return fPleased; }
			set { fPleased = value; }
		}
		string fPleased = "Pleased";


		/// <summary>
		/// No Comment default value.
		/// Data/Artifact.cs
		/// </summary>
		public string Satisfied
		{
			get { return fSatisfied; }
			set { fSatisfied = value; }
		}
		string fSatisfied = "Satisfied";


		/// <summary>
		/// No Comment default value.
		/// Data/Artifact.cs
		/// </summary>
		public string Unsatisfied
		{
			get { return fUnsatisfied; }
			set { fUnsatisfied = value; }
		}
		string fUnsatisfied = "Unsatisfied";


		/// <summary>
		/// No Comment default value.
		/// Data/Artifact.cs
		/// </summary>
		public string Angered
		{
			get { return fAngered; }
			set { fAngered = value; }
		}
		string fAngered = "Angered";


		/// <summary>
		/// No Comment default value.
		/// Data/Artifact.cs
		/// </summary>
		public string MovingOn
		{
			get { return fMovingOn; }
			set { fMovingOn = value; }
		}
		string fMovingOn = "Moving On";


		/// <summary>
		/// No Comment default value.
		/// Data/CombatState.cs
		/// </summary>
		public string At
		{
			get { return fDateAt; }
			set { fDateAt = value; }
		}
		string fDateAt = "at";


		/// <summary>
		/// No Comment default value.
		/// Data/Conditions.cs
		/// </summary>
		public string OngoingDamage
		{
			get { return fOngoingDamage; }
			set { fOngoingDamage = value; }
		}
		string fOngoingDamage = "ongoing damage";


		/// <summary>
		/// No Comment default value.
		/// Data/Conditions.cs
		/// </summary>
		public string Ongoing
		{
			get { return fOngoing; }
			set { fOngoing = value; }
		}
		string fOngoing = "ongoing";


		/// <summary>
		/// No Comment default value.
		/// Data/Conditions.cs
		/// </summary>
		public string Damage
		{
			get { return fDamage; }
			set { fDamage = value; }
		}
		string fDamage = "damage";


		/// <summary>
		/// No Comment default value.
		/// Data/Conditions.cs
		/// </summary>
		public string OngoingDefences
		{
			get { return fOngoingDefences; }
			set { fOngoingDefences = value; }
		}
		string fOngoingDefences = "defences";


		/// <summary>
		/// No Comment default value.
		/// Data/Conditions.cs
		/// </summary>
		public string To
		{
			get { return fTo; }
			set { fTo = value; }
		}
		string fTo = "to";


		/// <summary>
		/// No Comment default value.
		/// Data/Conditions.cs
		/// </summary>
		public string Regeneration
		{
			get { return fRegeneration; }
			set { fRegeneration = value; }
		}
		string fRegeneration = "Regeneration";


		/// <summary>
		/// No Comment default value.
		/// Data/Conditions.cs
		/// </summary>
		public string Aura
		{
			get { return fAura; }
			set { fAura = value; }
		}
		string fAura = "Aura";


		/// <summary>
		/// No Comment default value.
		/// Data/Creature.cs
		/// </summary>
		public string Squares
		{
			get { return fSquares; }
			set { fSquares = value; }
		}
		string fSquares = "squares";


		/// <summary>
		/// No Comment default value.
		/// Data/Creature.cs
		/// </summary>
		public string Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		string fLevel = "Level";


		/// <summary>
		/// No Comment default value.
		/// Data/Creature.cs
		/// </summary>
		public string MagicalBeast
		{
			get { return fMagicalBeast; }
			set { fMagicalBeast = value; }
		}
		string fMagicalBeast = "magical beast";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LowerMelee
		{
			get { return fLowerMelee; }
			set { fLowerMelee = value; }
		}
		string fLowerMelee = "melee";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LowerRanged
		{
			get { return fLowerRanged; }
			set { fLowerRanged = value; }
		}
		string fLowerRanged = "ranged";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LowerArea
		{
			get { return fLowerArea; }
			set { fLowerArea = value; }
		}
		string fLowerArea = "area";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LowerClose
		{
			get { return fLowerClose; }
			set { fLowerClose = value; }
		}
		string fLowerClose = "close";

		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LowerDouble
		{
			get { return fLowerDouble; }
			set { fLowerDouble = value; }
		}
		string fLowerDouble = "double";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Actions
		{
			get { return fActions; }
			set { fActions = value; }
		}
		string fActions = "Actions";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Traits
		{
			get { return fTraits; }
			set { fTraits = value; }
		}
		string fTraits = "Traits";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string StandardActions
		{
			get { return fStandardActions; }
			set { fStandardActions = value; }
		}
		string fStandardActions = "Standard Actions";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string MoveActions
		{
			get { return fMoveActions; }
			set { fMoveActions = value; }
		}
		string fMoveActions = "Move Actions";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string MinorActions
		{
			get { return fMinorActions; }
			set { fMinorActions = value; }
		}
		string fMinorActions = "Minor Actions";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string FreeActions
		{
			get { return fFreeActions; }
			set { fFreeActions = value; }
		}
		string fFreeActions = "Free Actions";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string TriggeredActions
		{
			get { return fTriggeredActions; }
			set { fTriggeredActions = value; }
		}
		string fTriggeredActions = "Triggered Actions";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string OtherActions
		{
			get { return fOtherActions; }
			set { fOtherActions = value; }
		}
		string fOtherActions = "Other Actions";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelChangeAction
		{
			get { return fLabelChangeAction; }
			set { fLabelChangeAction = value; }
		}
		string fLabelChangeAction = "click here to change the action";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelRechargePower
		{
			get { return fLabelRechargePower; }
			set { fLabelRechargePower = value; }
		}
		string fLabelRechargePower = "recharge this power";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelUsePower
		{
			get { return fLabelUsePower; }
			set { fLabelUsePower = value; }
		}
		string fLabelUsePower = "use this power";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Note
		{
			get { return fNote; }
			set { fNote = value; }
		}
		string fNote = "Note";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelNotePower
		{
			get { return fLabelNotePower; }
			set { fLabelNotePower = value; }
		}
		string fLabelNotePower = "This power is part of a functional template, and so its attack bonus will be increased by the level of the creature it is applied to.";
		
		
		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelReadAloud
		{
			get { return fLabelReadAloud; }
			set { fLabelReadAloud = value; }
		}
		string fLabelReadAloud = "Set read-aloud description(optional)";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string ImmediateInterrupt
		{
			get { return fImmediateInterrupt; }
			set { fImmediateInterrupt = value; }
		}
		string fImmediateInterrupt = "immediate interrupt";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string NoAction
		{
			get { return fNoAction; }
			set { fNoAction = value; }
		}
		string fNoAction = "no action";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string ImmediateReaction
		{
			get { return fImmediateReaction; }
			set { fImmediateReaction = value; }
		}
		string fImmediateReaction = "immediate reaction";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Action
		{
			get { return fAction; }
			set { fAction = value; }
		}
		string fAction = "action";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string NoPrerequisite
		{
			get { return fNoPrerequisite; }
			set { fNoPrerequisite = value; }
		}
		string fNoPrerequisite = "No prerequisite";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Prerequisite
		{
			get { return fPrerequisite; }
			set { fPrerequisite = value; }
		}
		string fPrerequisite = "Prerequisite";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelNoRange
		{
			get { return fLabelNoRange; }
			set { fLabelNoRange = value; }
		}
		string fLabelNoRange = "The power's range and its target(s) are not set";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelSetAttack
		{
			get { return fLabelSetAttack; }
			set { fLabelSetAttack = value; }
		}
		string fLabelSetAttack = "Click here to make this an attack power";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string ClearAttack
		{
			get { return fClearAttack; }
			set { fClearAttack = value; }
		}
		string fClearAttack = "clear attack";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Range
		{
			get { return fRange; }
			set { fRange = value; }
		}
		string fRange = "Range";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string LabelSpecPowEff
		{
			get { return fLabelSpecPowEff; }
			set { fLabelSpecPowEff = value; }
		}
		string fLabelSpecPowEff = "Specify the power's effects";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string NoDetails
		{
			get { return fNoDetails; }
			set { fNoDetails = value; }
		}
		string fNoDetails = "no details";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string AC
		{
			get { return fAC; }
			set { fAC = value; }
		}
		string fAC = "AC";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Fort
		{
			get { return fFort; }
			set { fFort = value; }
		}
		string fFort = "Fort";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Ref
		{
			get { return fRef; }
			set { fRef = value; }
		}
		string fRef = "Ref";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Will
		{
			get { return fWill; }
			set { fWill = value; }
		}
		string fWill = "Will";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string RechargesOn
		{
			get { return fRechargesOn; }
			set { fRechargesOn = value; }
		}
		string fRechargesOn = "Recharges on";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string AtWill
		{
			get { return fAtWill; }
			set { fAtWill = value; }
		}
		string fAtWill = "At-Will";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string BasicAttack
		{
			get { return fBasicAttack; }
			set { fBasicAttack = value; }
		}
		string fBasicAttack = "(basic attack)";

		
		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Daily
		{
			get { return fDaily; }
			set { fDaily = value; }
		}
		string fDaily = "Daily";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Attack
		{
			get { return fAttack; }
			set { fAttack = value; }
		}
		string fAttack = "Attack";


		/// <summary>
		/// No Comment default value.
		/// Data/CreaturePower.cs
		/// </summary>
		public string Sustain
		{
			get { return fSustain; }
			set { fSustain = value; }
		}
		string fSustain = "Sustain";


		/// <summary>
		/// No Comment default value.
		/// Data/CreatureTemplate.cs
		/// </summary>
		public string Elite
		{
			get { return fElite; }
			set { fElite = value; }
		}
		string fElite = "Elite";


		/// <summary>
		/// No Comment default value.
		/// Data/Damage.cs
		/// </summary>
		public string ImmuneTo
		{
			get { return fImmuneTo; }
			set { fImmuneTo = value; }
		}
		string fImmuneTo = "Immune to";


		/// <summary>
		/// No Comment default value.
		/// Data/Damage.cs
		/// </summary>
		public string Resist
		{
			get { return fResist; }
			set { fResist = value; }
		}
		string fResist = "Resist";


		/// <summary>
		/// No Comment default value.
		/// Data/Damage.cs
		/// </summary>
		public string Vulnerable
		{
			get { return fVulnerable; }
			set { fVulnerable = value; }
		}
		string fVulnerable = "Vulnerable";


		/// <summary>
		/// No Comment default value.
		/// Data/Encounter.cs
		/// </summary>
		public string Illumination
		{
			get { return fIllumination; }
			set { fIllumination = value; }
		}
		string fIllumination = "Illumination";


		/// <summary>
		/// No Comment default value.
		/// Data/Encounter.cs
		/// </summary>
		public string LabelFeaturesArea
		{
			get { return fLabelFeaturesArea; }
			set { fLabelFeaturesArea = value; }
		}
		string fLabelFeaturesArea = "Features of the Area";


		/// <summary>
		/// No Comment default value.
		/// Data/Encounter.cs
		/// </summary>
		public string Setup
		{
			get { return fSetup; }
			set { fSetup = value; }
		}
		string fSetup = "Setup";


		/// <summary>
		/// No Comment default value.
		/// Data/Encounter.cs
		/// </summary>
		public string Tactics
		{
			get { return fTactics; }
			set { fTactics = value; }
		}
		string fTactics = "Tactics";


		/// <summary>
		/// No Comment default value.
		/// Data/Encounter.cs
		/// </summary>
		public string VictoryConditions
		{
			get { return fVictoryConditions; }
			set { fVictoryConditions = value; }
		}
		string fVictoryConditions = "Victory Conditions";


		/// <summary>
		/// No Comment default value.
		/// Data/EncounterLog.cs
		/// </summary>
		public string Creature
		{
			get { return fCreature; }
			set { fCreature = value; }
		}
		string fCreature = "Creature";


		/// <summary>
		/// No Comment default value.
		/// Controls/WelcomePanel.cs
		/// </summary>
		public string GettingStarted
		{
			get { return fGettingStarted; }
			set { fGettingStarted = value; }
		}
		string fGettingStarted = "Getting Started";

	}
}
