using System;
using System.Collections.Generic;

using Masterplan.Data;
using Masterplan.Controls;
using System.Drawing;

namespace Masterplan.Events
{
	/// <summary>
	/// Event arguments containing a map token.
	/// </summary>
	public class TokenEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor taking an IToken.
		/// </summary>
		/// <param name="token">The map token.</param>
		public TokenEventArgs(IToken token)
		{
			fToken = token;
		}

		/// <summary>
		/// Gets the map token.
		/// </summary>
		public IToken Token
		{
			get { return fToken; }
		}
		IToken fToken = null;
	}

	/// <summary>
	/// Event arguments containing a list of map tokens.
	/// </summary>
	public class TokenListEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor taking a list of IToken objects.
		/// </summary>
		/// <param name="tokens">The map tokens.</param>
		public TokenListEventArgs(List<IToken> tokens)
		{
			fTokenLink = tokens;
		}

		/// <summary>
		/// Gets the list of map tokens.
		/// </summary>
		public List<IToken> Tokens
		{
			get { return fTokenLink; }
		}
		List<IToken> fTokenLink = new List<IToken>();
	}

	/// <summary>
	/// Event arguments containing a DraggedToken object.
	/// </summary>
	public class DraggedTokenEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		// /// <param name="token">The map token.</param>
		public DraggedTokenEventArgs(Point old_location, Point new_location)
		{
			fOldLocation = old_location;
			fNewLocation = new_location;
		}

		/// <summary>
		/// Gets the map token.
		/// </summary>
		public Point OldLocation
		{
			get { return fOldLocation; }
		}
		Point fOldLocation = CombatData.NoPoint;

		/// <summary>
		/// Gets the map token.
		/// </summary>
		public Point NewLocation
		{
			get { return fNewLocation; }
		}
		Point fNewLocation = CombatData.NoPoint;
	}

	/// <summary>
	/// Event arguments containing a token link.
	/// </summary>
	public class TokenLinkEventArgs : EventArgs
	{
		/// <summary>
		/// Constructor taking a TokenLink.
		/// </summary>
		/// <param name="link">The token link.</param>
		public TokenLinkEventArgs(TokenLink link)
		{
			fLink = link;
		}

		/// <summary>
		/// Gets the token link.
		/// </summary>
		public TokenLink Link
		{
			get { return fLink; }
		}
		TokenLink fLink = null;
	}

	/// <summary>
	/// Delegate with a TokenEventArgs parameter.
	/// </summary>
	/// <param name="sender">The sender of the request.</param>
	/// <param name="e">The token.</param>
	public delegate void TokenEventHandler(object sender, TokenEventArgs e);

	/// <summary>
	/// Delegate used when creating a TokenLink object.
	/// </summary>
	/// <param name="sender">The sender of the request.</param>
	/// <param name="e">The list of tokens for the link.</param>
	/// <returns>Returns the new link, if one was created; false otherwise.</returns>
	public delegate TokenLink CreateTokenLinkEventHandler(object sender, TokenListEventArgs e);

	/// <summary>
	/// Delegate with a DraggedTokenEventArgs parameter.
	/// </summary>
	/// <param name="sender">The sender of the request.</param>
	/// <param name="e">The DraggedToken object.</param>
	public delegate void DraggedTokenEventHandler(object sender, DraggedTokenEventArgs e);

	/// <summary>
	/// Delegate with a TokenLinkEventArgs parameter.
	/// </summary>
	/// <param name="sender">The sender of the request.</param>
	/// <param name="e">The TokenLink object.</param>
	public delegate TokenLink TokenLinkEventHandler(object sender, TokenLinkEventArgs e);
}
