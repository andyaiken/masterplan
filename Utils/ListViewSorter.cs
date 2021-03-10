using System;
using System.Collections;
using System.Windows.Forms;

namespace Utils
{
	/// <summary>
	/// Provides methods for sorting ListView contents by column.
	/// An instance of this class should be set as the ListView's ListViewItemSorter property.
	/// </summary>
	public class ListViewSorter : IComparer
	{
		/// <summary>
		/// Gets or sets a value indicating the column the ListView contents should be sorted by.
		/// </summary>
		public int Column
		{
			get {return fColumn;}
			set {fColumn = value;}
		}
		private int fColumn = 0;

		/// <summary>
		/// Gets or sets a value indicating whether the ListView contents should be sorted in ascending order.
		/// </summary>
		public bool Ascending
		{
			get {return fAscending;}
			set {fAscending = value;}
		}
		private bool fAscending = true;

		/// <summary>
		/// Sets the column used for sorting.
		/// If this method is called multiple times with the same column, the value of the Ascending property is toggled on and off.
		/// </summary>
		/// <param name="col">The column to be used for sorting.</param>
		public void SetColumn(int col)
		{
			if (fColumn == col)
			{
				fAscending = !fAscending;
			}
			else
			{
				fColumn = col;
				fAscending = true;
			}
		}

		/// <summary>
		/// Compares two ListViewItem objects, given the values of the Column and Ascending properties.
		/// </summary>
		/// <param name="x">The first ListViewItem object to compare.</param>
		/// <param name="y">The second ListViewItem object to compare.</param>
		/// <returns>Returns -1 if x should be sorted before y, +1 if y should be sorted before x, and 0 if they are identical.</returns>
		public int Compare(object x, object y)
		{
			ListViewItem lhs = x as ListViewItem;
			ListViewItem rhs = y as ListViewItem;

			if ((lhs == null) || (rhs == null))
				throw new ArgumentException();

			string lhs_str = lhs.SubItems[Column].Text;
			string rhs_str = rhs.SubItems[Column].Text;

			// Try integers
			try
			{
				int lhs_int = int.Parse(lhs_str);
				int rhs_int = int.Parse(rhs_str);

				return lhs_int.CompareTo(rhs_int) * (fAscending ? 1 : -1);
			}
			catch
			{
			}

			// Try floating point
			try
			{
				float lhs_flt = float.Parse(lhs_str);
				float rhs_flt = float.Parse(rhs_str);

				return lhs_flt.CompareTo(rhs_flt) * (fAscending ? 1 : -1);
			}
			catch
			{
			}

			// Try dates
			try
			{
				DateTime lhs_dt = DateTime.Parse(lhs_str);
				DateTime rhs_dt = DateTime.Parse(rhs_str);

				return lhs_dt.CompareTo(rhs_dt) * (fAscending ? 1 : -1);
			}
			catch
			{
			}

			// Must just be a string then
			return lhs_str.CompareTo(rhs_str) * (fAscending ? 1 : -1);
		}

		/// <summary>
		/// Sorts the contents of a ListView control.
		/// This method should be called in response to a ListView.ColumnClicked event.
		/// </summary>
		/// <param name="list">The ListView control to be sorted.</param>
		/// <param name="column">The column to sort by.</param>
		public static void Sort(ListView list, int column)
		{
			ListViewSorter sorter = list.ListViewItemSorter as ListViewSorter;
			if (sorter != null)
			{
				sorter.SetColumn(column);
				list.Sort();
			}
		}
	}
}