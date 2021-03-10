using System;

namespace Masterplan.Data
{
	/// <summary>
	/// Class representing a creature aura.
	/// </summary>
	[Serializable]
	public class Aura
	{
		/// <summary>
		/// Gets or sets the unique ID of the aura.
		/// </summary>
		public Guid ID
		{
			get { return fID; }
			set { fID = value; }
		}
		Guid fID = Guid.NewGuid();

		/// <summary>
		/// Gets or sets the name of the aura.
		/// </summary>
		public string Name
		{
			get { return fName; }
			set { fName = value; }
		}
		string fName = "";

		/// <summary>
		/// Gets or sets the aura keywords.
		/// </summary>
		public string Keywords
		{
			get { return fKeywords; }
			set { fKeywords = value; }
		}
		string fKeywords = "";

		/// <summary>
		/// Gets or sets the details of the aura, including the radius size.
		/// </summary>
		public string Details
		{
			get { return fDetails; }
			set
			{
				fDetails = value;
				extract();
			}
		}
		string fDetails = "";

		/// <summary>
		/// Creates a copy of the aura.
		/// </summary>
		/// <returns>Returns the copy.</returns>
		public Aura Copy()
		{
			Aura a = new Aura();

			a.ID = fID;
			a.Name = fName;
			a.Keywords = fKeywords;
			a.Details = fDetails;

			return a;
		}

		internal string Description
		{
			get
			{
				if (!fExtractedData)
					extract();

				return fDescription;
			}
		}

		internal int Radius
		{
			get
			{
				if (!fExtractedData)
					extract();

				return fRadius;
			}
		}

		void extract()
		{
			string val_str = "";

			bool started_value = false;
			for (int n = 0; n != fDetails.Length; ++n)
			{
				char ch = fDetails[n];
				started_value = char.IsDigit(ch);

				if (!started_value && (val_str != ""))
				{
					fDescription = fDetails.Substring(n);
					break;
				}

				if (started_value)
					val_str += ch;
			}

			int radius = 1;
			try
			{
				radius = int.Parse(val_str);
			}
			catch
			{
				radius = 1;
			}

			if (fDescription == null)
				fDescription = "";
			else
			{
				if (fDescription.StartsWith(":"))
					fDescription = fDescription.Substring(1);
				fDescription = fDescription.Trim();
			}

			fRadius = radius;
			fExtractedData = true;
		}

		bool fExtractedData = false;

		int fRadius = int.MinValue;
		string fDescription = "";
	}
}
