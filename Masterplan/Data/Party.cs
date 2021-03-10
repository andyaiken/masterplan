using System;

namespace Masterplan.Data
{
	/// <summary>
	/// Class holding information on a party of heroes.
	/// </summary>
	[Serializable]
	public class Party
	{
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Party()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="size">The number of heroes in the party.</param>
        /// <param name="level">The average level of the heroes in the party.</param>
        public Party(int size, int level)
        {
            fSize = size;
            fLevel = level;
        }

		/// <summary>
		/// Gets or sets the number of heroes in the party.
		/// </summary>
		public int Size
		{
			get { return fSize; }
			set { fSize = value; }
		}
		int fSize = 5;

        /// <summary>
        /// Gets or sets the average XP of the party.
        /// </summary>
        public int XP
        {
            get { return fXP; }
            set { fXP = value; }
        }
        int fXP = 0;

        /// <summary>
        /// Gets or sets the average level of the party.
        /// </summary>
        public int Level
        {
            get { return fLevel; }
            set { fLevel = value; }
        }
        int fLevel = 1;

		/// <summary>
		/// Calculates the relative difficulty of an item of the given level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>Returns the difficulty.</returns>
		public Difficulty GetDifficulty(int level)
		{
			if (level <= fLevel - 3)
				return Difficulty.Trivial;

			if (level <= fLevel - 1)
				return Difficulty.Easy;

			if (level <= fLevel + 1)
				return Difficulty.Moderate;

			if (level <= fLevel + 4)
				return Difficulty.Hard;

			return Difficulty.Extreme;
		}

		/// <summary>
		/// Creates a copy of the party information.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Party Copy()
		{
			Party p = new Party();

			p.Size = fSize;
			p.Level = fLevel;
            p.XP = fXP;

			return p;
		}
	}
}
