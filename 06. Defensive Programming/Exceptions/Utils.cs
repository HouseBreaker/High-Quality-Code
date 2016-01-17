namespace Exceptions_Homework
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public static class Utils
	{
		/// <summary>
		/// Takes a number of elements from an array starting from a specified index.
		/// If the specified count can't be returned, it returns as many elements as it can.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="arr">The input array</param>
		/// <param name="startIndex">The index to start from</param>
		/// <param name="count">How many elements to take</param>
		public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
		{
			if (startIndex < 0)
			{
				throw new IndexOutOfRangeException("Start index cannot be negative.");
			}

			if (count < 0)
			{
				throw new IndexOutOfRangeException("Count of elements to take cannot be negative.");
			}

			int lastIndex = arr.Length - 1;

			bool countReachesEndOfArray = startIndex + count - 1 > lastIndex;
			if (countReachesEndOfArray)
			{
				count = lastIndex - startIndex + 1;
			}
			
			List<T> result = new List<T>();
			for (int i = startIndex; i < startIndex + count; i++)
			{
				result.Add(arr[i]);
			}

			return result.ToArray();
		}

		public static string ExtractEnding(string str, int count)
		{
			if (str == string.Empty)
			{
				throw new ArgumentNullException(nameof(str), "Cannot extract ending from an empty string.");
			}

			if (count > str.Length || count < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(str), "Count must not be less than 0 or bigger than string length.");
			}

			StringBuilder result = new StringBuilder();
			for (int i = str.Length - count; i < str.Length; i++)
			{
				result.Append(str[i]);
			}

			return result.ToString();
		}

		public static bool IsPrime(int number)
		{
			for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
			{
				if (number % divisor == 0)
				{
					return false;
				}
			}

			return true;
		}
	}
}
