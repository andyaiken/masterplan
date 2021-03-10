using System;

using Masterplan.Data;

namespace Masterplan.Events
{
	/// <summary>
	/// Event arguments concerning map movement.
	/// </summary>
	public class MovementEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor taking a distance parameter.
		/// </summary>
		/// <param name="distance">The distance moved.</param>
		public MovementEventArgs(int distance)
		{
			fDistance = distance;
		}

		/// <summary>
		/// Gets the distance moved.
		/// </summary>
		public int Distance
		{
			get { return fDistance; }
		}
		int fDistance = 0;
	}

	/// <summary>
	/// Delegate taking a MovementEventArgs as a parameter.
	/// </summary>
	/// <param name="sender">The sender of the request.</param>
	/// <param name="e">The movement data.</param>
	public delegate void MovementEventHandler(object sender, MovementEventArgs e);
}
