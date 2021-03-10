using System;

namespace Utils
{
	/// <summary>
	/// Class representing a pair of linked objects.
	/// </summary>
	/// <typeparam name="T1">The type of object contained in the First property.</typeparam>
	/// <typeparam name="T2">The type of object contained in the First property.</typeparam>
	[Serializable]
	public class Pair<T1, T2> : IComparable<Pair<T1, T2>>
	{
		/// <summary>
		/// The default constructor.
		/// </summary>
		public Pair()
		{
		}

		/// <summary>
		/// Constructor which initialises the Pair object.
		/// </summary>
		/// <param name="first">The first part.</param>
		/// <param name="second">The second part.</param>
		public Pair(T1 first, T2 second)
		{
			First = first;
			Second = second;
		}

		/// <summary>
		/// The first part of the Pair.
		/// </summary>
		public T1 First
		{
			get { return fFirst; }
			set { fFirst = value; }
		}
		T1 fFirst = default(T1);

		/// <summary>
		/// The second part of the Pair.
		/// </summary>
		public T2 Second
		{
			get { return fSecond; }
			set { fSecond = value; }
		}
		T2 fSecond = default(T2);

		/// <summary>
		/// Returns a string representation of the Pair object in the format [first], [second].
		/// </summary>
		/// <returns>Returns a string representation of the Pair object.</returns>
		public override string ToString()
		{
			return fFirst + ", " + fSecond;
		}

		/// <summary>
		/// Compares this Pair object to another by the contents of their First property.
		/// </summary>
		/// <param name="rhs">The Pair object to compare to.</param>
		/// <returns>Returns -1 if this object should be sorted before the other, +1 if it should be sorted after the other, or 0 if they are identical.</returns>
		public int CompareTo(Pair<T1, T2> rhs)
		{
			string str_a = fFirst.ToString();
			string str_b = rhs.First.ToString();

			return str_a.CompareTo(str_b);
		}
	}
}
