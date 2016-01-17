namespace Assertions_Homework
{
	using System;
	using System.Diagnostics;

	public static class CollectionUtils
	{
		public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
		{
			Debug.Assert(arr.Length > 0, "Cannot sort collection with less than one element.");

			if (arr.Length == 1)
			{
				return;
			}

			for (int index = 0; index < arr.Length - 1; index++)
			{
				int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
				Swap(ref arr[index], ref arr[minElementIndex]);
			}

			for (int i = 1; i < arr.Length; i++)
			{
				Debug.Assert(arr[i - 1].CompareTo(arr[i]) < 0, "Collection is not properly sorted.");
			}
		}

		private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
			where T : IComparable<T>
		{
			int minElementIndex = startIndex;
			for (int i = startIndex + 1; i <= endIndex; i++)
			{
				if (arr[i].CompareTo(arr[minElementIndex]) < 0)
				{
					minElementIndex = i;
				}
			}

			return minElementIndex;
		}

		public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
		{
			return BinarySearch(arr, value, 0, arr.Length - 1);
		}

		private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
			where T : IComparable<T>
		{
			while (startIndex <= endIndex)
			{
				int midIndex = (startIndex + endIndex) / 2;
				if (arr[midIndex].Equals(value))
				{
					return midIndex;
				}

				if (arr[midIndex].CompareTo(value) < 0)
				{
					// Search on the right half
					startIndex = midIndex + 1;
				}
				else
				{
					// Search on the right half
					endIndex = midIndex - 1;
				}
			}

			// Searched value not found
			return -1;
		}

		private static void Swap<T>(ref T x, ref T y)
		{
			T oldX = x;
			x = y;
			y = oldX;
		}
	}
}
