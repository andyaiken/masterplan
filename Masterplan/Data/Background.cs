using System;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing some project background information.
	/// </summary>
	[Serializable]
	public class Background
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public Background()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="title">The title of the background information</param>
		public Background(string title)
		{
			fTitle = title;
		}

		/// <summary>
		/// Gets or sets the unique ID of the background.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the title of the background information.
		/// </summary>
		public string Title
		{
			get { return fTitle; }
			set { fTitle = value; }
		}
		string fTitle = "";

		/// <summary>
		/// Gets or sets the background information details.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set { fDetails = value; }
		}
		string fDetails = "";

		/// <summary>
		/// Creates a copy of the Background.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Background Copy()
		{
			Background b = new Background();

			b.ID = fID;
			b.Title = fTitle;
			b.Details = fDetails;

			return b;
		}

		/// <summary>
		/// Returns the background item title.
		/// </summary>
		/// <returns>Returns the background item title.</returns>
		public override string ToString()
		{
			return fTitle;
		}
	}
}
