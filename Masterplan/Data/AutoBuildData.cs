using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Class holding data for the Encounter AutoBuild feature.
	/// </summary>
	[Serializable]
	public class AutoBuildData
	{
		/// <summary>
		/// Gets or sets the desired difficulty.
		/// </summary>
		public Difficulty Difficulty
		{
			get { return fDifficulty; }
			set { fDifficulty = value; }
		}
		Difficulty fDifficulty = Masterplan.Data.Difficulty.Random;

		/// <summary>
		/// Gets or sets the desired level.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = Session.Project.Party.Level;

		/// <summary>
		/// Gets or sets the party size.
		/// </summary>
		public int Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		int fSize = Session.Project.Party.Size;

		/// <summary>
		/// Gets or sets the name of the encounter template group to use.
		/// </summary>
		public string Type
		{
			get { return fType; }
			set { fType = value; }
		}
		string fType = "";

		/// <summary>
		/// Gets or sets the list of creature categories to use.
		/// If blank, AutoBuild will use all creatures.
		/// </summary>
		public List<string> Categories
		{
			get { return fCategories; }
			set { fCategories = value; }
		}
		List<string> fCategories = null;

		/// <summary>
		/// Gets or sets the keywords to select creatures with.
		/// If blank, AutoBuild will use all creatures.
		/// </summary>
		public List<string> Keywords
		{
			get { return fKeywords; }
			set { fKeywords = value; }
		}
		List<string> fKeywords = new List<string>();

		/// <summary>
		/// Creates a copy of the data.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public AutoBuildData Copy()
		{
			AutoBuildData data = new AutoBuildData();

			data.Difficulty = fDifficulty;
			data.Level = fLevel;
			data.Size = fSize;
			data.Type = fType;

			if (fKeywords != null)
			{
				data.Keywords = new List<string>();
				data.Keywords.AddRange(fKeywords);
			}

			if (fCategories != null)
			{
				data.Categories = new List<string>();
				data.Categories.AddRange(fCategories);
			}

			return data;
		}
	}
}
