using System;
using System.Collections.Generic;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a link between map tokens.
	/// </summary>
	[Serializable]
	public class TokenLink
	{
		/// <summary>
		/// Gets or sets the text of the link.
		/// </summary>
		public string Text
		{
			get { return fText; }
			set { fText = value; }
		}
		string fText = "";

		/// <summary>
		/// Gets or sets the list of IToken objects.
		/// </summary>
		public List<IToken> Tokens
		{
			get { return fTokens; }
			set { fTokens = value; }
		}
		List<IToken> fTokens = new List<IToken>();

		/// <summary>
		/// Creates a copy of the link.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public TokenLink Copy()
		{
			TokenLink link = new TokenLink();

			link.Text = fText;

			foreach (IToken token in fTokens)
				link.Tokens.Add(token);

			return link;
		}
	}
}
