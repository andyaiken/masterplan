using System;

using Masterplan.Data;

namespace Masterplan.Events
{
	/// <summary>
	/// Event arguments including a TileData object.
	/// </summary>
	public class TileEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor taking a TileData object
		/// </summary>
		/// <param name="tile">The tile.</param>
		public TileEventArgs(TileData tile)
		{
			fTile = tile;
		}

		/// <summary>
		/// Gets the tile.
		/// </summary>
		public TileData Tile
		{
			get { return fTile; }
		}
		TileData fTile = null;
	}

	/// <summary>
	/// Delegate with a TileEventArgs parameter.
	/// </summary>
	/// <param name="sender">The sender of the request.</param>
	/// <param name="e">The tile.</param>
	public delegate void TileEventHandler(object sender, TileEventArgs e);
}
