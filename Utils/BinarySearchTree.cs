using System;
using System.Collections.Generic;

namespace Utils
{
	/// <summary>
	/// Utility class for performing quick searches.
	/// </summary>
	/// <typeparam name="T">Type to create the tree for; must implement the IComparable interface.</typeparam>
	public class BinarySearchTree<T> where T:IComparable<T>
	{
		T fData = default(T);

		BinarySearchTree<T> fLeft = null;
		BinarySearchTree<T> fRight = null;

		#region Constructors

		/// <summary>
		/// Default constructor.
		/// </summary>
		public BinarySearchTree()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="item">The item to begin the tree with.</param>
		public BinarySearchTree(T item)
		{
			fData = item;
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="list">The list of items to build the tree with.</param>
		public BinarySearchTree(IEnumerable<T> list)
		{
			Add(list);
		}

		#endregion

		#region Add methods

		/// <summary>
		/// Adds an item to the tree.
		/// </summary>
		/// <param name="item">The item to add to the tree.</param>
		public void Add(T item)
		{
			if (fData == null)
			{
				fData = item;
				return;
			}

			int n = fData.CompareTo(item);

			if (n > 0)
			{
				if (fLeft == null)
					fLeft = new BinarySearchTree<T>(item);
				else
					fLeft.Add(item);
			}

			if (n < 0)
			{
				if (fRight == null)
					fRight = new BinarySearchTree<T>(item);
				else
					fRight.Add(item);
			}
		}

		/// <summary>
		/// Adds a list of items to the tree.
		/// </summary>
		/// <param name="list">The items to add to the tree.</param>
		public void Add(IEnumerable<T> list)
		{
			foreach (T item in list)
				Add(item);
		}

		#endregion

		/// <summary>
		/// Gets the number of items in the tree.
		/// </summary>
		public int Count
		{
			get
			{
				if (fData == null)
					return 0;

				int count = 1;

				if (fLeft != null)
					count += fLeft.Count;

				if (fRight != null)
					count += fRight.Count;

				return count;
			}
		}

		/// <summary>
		/// Gets a List containing all the items in the tree in sorted order.
		/// </summary>
		public List<T> SortedList
		{
			get
			{
				List<T> list = new List<T>();

				if (fData != null)
				{
					if (fLeft != null)
						list.AddRange(fLeft.SortedList);

					list.Add(fData);

					if (fRight != null)
						list.AddRange(fRight.SortedList);
				}

				return list;
			}
		}

		/// <summary>
		/// Searches the tree for the given item.
		/// </summary>
		/// <param name="item">The item to look for.</param>
		/// <returns>Returns true if the item is present in the tree; false otherwise.</returns>
		public bool Contains(T item)
		{
			if (fData == null)
				return false;

			int n = fData.CompareTo(item);

			if (n > 0)
				return (fLeft != null) ? fLeft.Contains(item) : false;

			if (n < 0)
				return (fRight != null) ? fRight.Contains(item) : false;

			return true;
		}
	}
}
