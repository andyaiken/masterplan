using System;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a user note.
	/// </summary>
	[Serializable]
	public class Note : IComparable<Note>
	{
		/// <summary>
		/// Gets or sets the unique ID.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the content of the note.
		/// </summary>
		public string Content
		{
			get { return fContent; }
			set { fContent = value; }
		}
		string fContent = "";

		/// <summary>
		/// Gets or sets the category of the note.
		/// </summary>
		public string Category
		{
			get { return fCategory; }
			set { fCategory = value; }
		}
		string fCategory = "";

		/// <summary>
		/// Gets the name of the note.
		/// </summary>
		public string Name
		{
			get
			{
				string[] breaks = new string[] { Environment.NewLine };
				string[] lines = fContent.Split(breaks, StringSplitOptions.RemoveEmptyEntries);

				if (lines.Length == 0)
					return "(blank note)";

				return lines[0];
			}
		}

		/// <summary>
		/// Returns the text of the note.
		/// </summary>
		/// <returns>Returns the text of the note.</returns>
		public override string ToString()
		{
			return fContent;
		}

		/// <summary>
		/// Creates a copy of the note.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Note Copy()
		{
			Note n = new Note();

			n.ID = fID;
			n.Content = fContent;
			n.Category = fCategory;

			return n;
		}

		/// <summary>
		/// Compares this note to another.
		/// </summary>
		/// <param name="rhs">The other note.</param>
		/// <returns>Returns -1 if this note should be sorted before the other, +1 if the other should be sorted before this; 0 otherwise.</returns>
		public int CompareTo(Note rhs)
		{
			return Name.CompareTo(rhs.Name);
		}
	}
}
