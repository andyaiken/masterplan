#nullable disable

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Masterplan.Data
{
    /// <summary>
    /// Class representing a creature aura.
    /// </summary>
    /// <remarks>
    /// <para><b>One stored text.</b> An aura's keywords have a field of their own (<see cref="Keywords"/>),
    /// but its radius and description are stored together in <see cref="Details"/>. Masterplan's own
    /// Aura window writes "3: Enemies grant combat advantage." Many imported auras are written the way
    /// the rule books print them, keywords included: "(Fire) aura 3; creatures that ...".</para>
    /// <para><b>Reading</b> (14.1.1.2). <see cref="Radius"/>, <see cref="Description"/> and
    /// <see cref="ShownKeywords"/> are worked out from the stored text. Reading never changes what is
    /// stored.</para>
    /// <para>Until 14.1.1.1 the first number anywhere in the text was taken as the radius and only the
    /// text after it was kept as the description. "(Fire) aura 3; creatures ..." showed no "Fire" and a
    /// description beginning with ";", and a sentence such as "Alaria teleports 5 squares ..." lost
    /// everything before the 5.</para>
    /// </remarks>
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
        /// Gets or sets the aura keywords as stored in their own field. To show an aura's keywords use
        /// <see cref="ShownKeywords"/>, which also finds keywords written in the details.
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

        /// <summary>
        /// The text of <see cref="Details"/> without the radius and without any keywords in front of it.
        /// </summary>
        internal string Description
        {
            get
            {
                if (!fExtractedData)
                    extract();

                return fDescription;
            }
        }

        /// <summary>
        /// The radius written in <see cref="Details"/>; 0 when the text states none where a radius
        /// belongs (the stat block then shows no "Aura N").
        /// </summary>
        internal int Radius
        {
            get
            {
                if (!fExtractedData)
                    extract();

                return fRadius;
            }
        }

        /// <summary>
        /// The keywords to show: those of the <see cref="Keywords"/> field, followed by any written in
        /// front of the radius in <see cref="Details"/> that the field does not have.
        /// </summary>
        internal string ShownKeywords
        {
            get
            {
                if (!fExtractedData)
                    extract();

                return MergeKeywords(fKeywords, fKeywordsInDetails);
            }
        }

        // ----- Reading the stored text -----

        // The three forms below are "regular expressions": patterns that a text is matched against.
        // In them "\s*" is any spaces, "(?<name> ...)" gives a part of the match a name, "?" makes the
        // part before it optional, and "(?!\w)" means "no letter or digit follows" (so that "2d6" is
        // not read as the radius 2).

        // The rule books' form: optional "(keywords)", the word "aura", the radius, optional ";" or ":".
        static readonly Regex fLabelledStart = new Regex(
            @"^\s*(?:\((?<keywords>[^()]*)\)\s*)?aura\s*(?<radius>\d+)(?!\w)\s*[:;]?\s*",
            RegexOptions.IgnoreCase);

        // Masterplan's form: the radius first (optionally after keywords), optional ":" or ";".
        static readonly Regex fNumberStart = new Regex(
            @"^\s*(?:\((?<keywords>\s*[A-Za-z]+(?:\s*,\s*[A-Za-z]+)*\s*)\)\s*)?(?<radius>\d+)(?!\w)\s*[:;]?\s*");

        // Keywords alone, for a text without a radius: "(Fire) Any enemy ...". Only single words,
        // separated by commas, count: "(while bloodied) ..." stays in the description.
        static readonly Regex fKeywordStart = new Regex(
            @"^\s*\((?<keywords>\s*[A-Za-z]+(?:\s*,\s*[A-Za-z]+)*\s*)\)\s*");

        /// <summary>
        /// Reads the rule books' form at the start of a text: "(Fire) aura 3; the rest". The keywords
        /// are optional; the word "aura" and the number are not, so that an ordinary description that
        /// begins with a number ("5 fire damage ...") is never taken apart.
        /// </summary>
        /// <param name="text">The text to read.</param>
        /// <param name="keywords">The keywords found, or "".</param>
        /// <param name="radius">The radius found, or 0.</param>
        /// <param name="rest">What follows, or the whole text if it does not start this way.</param>
        /// <returns>True if the text starts this way.</returns>
        internal static bool TryReadLabelledStart(string text, out string keywords, out int radius, out string rest)
        {
            return try_read(fLabelledStart, text, out keywords, out radius, out rest);
        }

        static bool try_read(Regex form, string text, out string keywords, out int radius, out string rest)
        {
            keywords = "";
            radius = 0;
            rest = text ?? "";

            Match match = form.Match(rest);
            if (!match.Success)
                return false;

            // A number too large to hold is no radius. (A form without a number has none to read.)
            Group number = match.Groups["radius"];
            if (number.Success && !int.TryParse(number.Value, out radius))
                return false;

            keywords = match.Groups["keywords"].Value.Trim();
            rest = rest.Substring(match.Length);
            return true;
        }

        /// <summary>
        /// The keywords of <paramref name="first"/>, followed by those of <paramref name="more"/> that
        /// it does not have yet (not case-sensitive). Both are lists separated by commas.
        /// </summary>
        internal static string MergeKeywords(string first, string more)
        {
            string result = first ?? "";

            List<string> have = new List<string>();
            foreach (string word in result.Split(','))
                have.Add(word.Trim().ToLowerInvariant());

            foreach (string word in (more ?? "").Split(','))
            {
                string trimmed = word.Trim();
                if ((trimmed == "") || have.Contains(trimmed.ToLowerInvariant()))
                    continue;

                result = (result.Trim() == "") ? trimmed : result + ", " + trimmed;
                have.Add(trimmed.ToLowerInvariant());
            }

            return result;
        }

        void extract()
        {
            string text = fDetails ?? "";

            string keywords;
            int radius;
            string rest;

            if (text.Trim() == "")
            {
                // Nothing is stored: the radius is 1, as it always was.
                keywords = "";
                radius = 1;
                rest = "";
            }
            else if (!try_read(fLabelledStart, text, out keywords, out radius, out rest)
                && !try_read(fNumberStart, text, out keywords, out radius, out rest))
            {
                // No radius where one belongs. All the text is the description (after any keywords),
                // and no number further on is mistaken for the radius.
                try_read(fKeywordStart, text, out keywords, out radius, out rest);
            }

            // A radius may be followed by the rule books' form again: "3: (Fire) aura 3; ..." is what
            // saving that text in 14.1.1.1 and earlier made of it. The first radius counts; the
            // keywords of the repeated start are kept.
            string more_keywords;
            int repeated_radius;
            string shorter;
            while (try_read(fLabelledStart, rest, out more_keywords, out repeated_radius, out shorter))
            {
                keywords = MergeKeywords(keywords, more_keywords);
                rest = shorter;
            }

            // Everything is set on every reading, so nothing of an earlier text can be left over.
            fKeywordsInDetails = keywords;
            fRadius = radius;
            fDescription = rest.Trim();
            fExtractedData = true;
        }

        bool fExtractedData = false;

        int fRadius = int.MinValue;
        string fDescription = "";
        string fKeywordsInDetails = "";
    }
}
