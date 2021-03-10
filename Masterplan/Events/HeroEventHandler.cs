using System;

using Masterplan.Data;

namespace Masterplan.Events
{
	/// <summary>
	/// Event arguments containing a Hero object.
	/// </summary>
	public class HeroEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor taking a Hero parameter.
		/// </summary>
		/// <param name="hero">The hero.</param>
		public HeroEventArgs(Hero hero)
		{
			fHero = hero;
		}

		/// <summary>
		/// Gets the Hero object.
		/// </summary>
		public Hero Hero
		{
			get { return fHero; }
		}
		Hero fHero = null;
	}

	/// <summary>
	/// Delegate taking a Hero as a parameter.
	/// </summary>
	/// <param name="sender">The sender of the request.</param>
	/// <param name="e">The hero.</param>
	public delegate void HeroEventHandler(object sender, HeroEventArgs e);
}
