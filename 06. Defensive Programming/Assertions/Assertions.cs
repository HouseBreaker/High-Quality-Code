namespace Assertions_Homework
{
	using System;

	public class Assertions
	{
		public static void Main()
		{
			int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
			Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
			SortUtils.SelectionSort(arr);
			Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

			SortUtils.SelectionSort(new int[0]); // Test sorting empty array
			SortUtils.SelectionSort(new int[1]); // Test sorting single element array

			Console.WriteLine(SortUtils.BinarySearch(arr, -1000));
			Console.WriteLine(SortUtils.BinarySearch(arr, 0));
			Console.WriteLine(SortUtils.BinarySearch(arr, 17));
			Console.WriteLine(SortUtils.BinarySearch(arr, 10));
			Console.WriteLine(SortUtils.BinarySearch(arr, 1000));
		}
	}
}
