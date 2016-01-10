namespace _02.Reformat_Your_Own_Code
{
	using System;

	public static class ReformatMain
	{
		public static void Main()
		{
			var pesho = new Student("pesho", "peshov", "488488");
			var gosho = new StudentReformatted("gosho", "goshov", "588588");

			Console.WriteLine(pesho);
			Console.WriteLine(gosho);
		}
	}
}
