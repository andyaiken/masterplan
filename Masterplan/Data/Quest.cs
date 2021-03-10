using System;
using Masterplan.Tools;

namespace Masterplan.Data
{
	/// <summary>
	/// Quest type (major or minor).
	/// </summary>
	public enum QuestType
	{
		/// <summary>
		/// A major quest.
		/// </summary>
		Major,

		/// <summary>
		/// A minor quest.
		/// </summary>
		Minor
	}

	/// <summary>
	/// Class representing a quest element.
	/// </summary>
	[Serializable]
	public class Quest : IElement
	{
		/// <summary>
		/// The level of the quest.
		/// </summary>
		public int Level
		{
			get { return fLevel; }
			set { fLevel = value; }
		}
		int fLevel = Session.Project.Party.Level;

		/// <summary>
		/// The type of quest.
		/// </summary>
		public QuestType Type
		{
			get { return fType; }
			set { fType = value; }
		}
		QuestType fType = QuestType.Minor;

		/// <summary>
		/// Gets or sets the XP value for the quest, to be awarded to each party member.
		/// If the quest is a major quest, this value is can't be set using this property; major quests have a set XP value.
		/// </summary>
		public int XP
		{
			get
			{
				switch (fType)
				{
					case QuestType.Major:
						return Experience.GetCreatureXP(fLevel);
					case QuestType.Minor:
						return fXP;
				}

				return int.MinValue;
			}
			set
			{
				if (fType == QuestType.Minor)
					fXP = value;
			}
		}
		int fXP = 0;

		/// <summary>
		/// Calculates the XP value of the quest.
		/// </summary>
		/// <returns>Returns the XP value.</returns>
		public int GetXP()
		{
			// Each party member gets the full XP amount
			return XP * Session.Project.Party.Size;
		}

		/// <summary>
		/// Calculates the difficulty of the quest.
		/// </summary>
		/// <param name="party_level">The party level.</param>
		/// <param name="party_size">The party size.</param>
		/// <returns>Returns the difficulty.</returns>
		public Difficulty GetDifficulty(int party_level, int party_size)
		{
			Party p = new Party();
			p.Level = party_level;
			p.Size = party_size;

			return p.GetDifficulty(fLevel);
		}

		/// <summary>
		/// Creates a copy of the Quest.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public IElement Copy()
		{
			Quest q = new Quest();

			q.Level = fLevel;
			q.Type = fType;
			q.XP = fXP;

			return q;
		}
	}
}
