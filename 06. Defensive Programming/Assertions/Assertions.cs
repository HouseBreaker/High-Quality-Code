namespace Assertions_Homework
{
	using System;

	public class Assertions
	{
		public static void Main()
		{
			int[] arr = { 3, -1, 15, 4, 17, 2, 33, 0 };
			Console.WriteLine("arr = [{0}]", string.Join(", ", arr));

			CollectionUtils.SelectionSort(arr);
			Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

			CollectionUtils.SelectionSort(new int[0]); // Test sorting empty array
			CollectionUtils.SelectionSort(new int[1]); // Test sorting single element array

			Console.WriteLine(CollectionUtils.BinarySearch(arr, -1000));
			Console.WriteLine(CollectionUtils.BinarySearch(arr, 0));
			Console.WriteLine(CollectionUtils.BinarySearch(arr, 17));
			Console.WriteLine(CollectionUtils.BinarySearch(arr, 10));
			Console.WriteLine(CollectionUtils.BinarySearch(arr, 1000));
		}
	}
}
