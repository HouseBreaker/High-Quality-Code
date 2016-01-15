namespace Methods
{
	using System;

	using Methods.Utils;

	public static class MethodsMain
	{
		public static void Main()
		{
			Console.WriteLine(CalcUtils.CalculateTriangleArea(3, 4, 5));

			Console.WriteLine(PrintUtils.PrintDigitAsWord(5));

			Console.WriteLine(CalcUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

			PrintUtils.PrintDigitAsNumber(1.3, "f");
			PrintUtils.PrintDigitAsNumber(0.75, "%");
			PrintUtils.PrintDigitAsNumber(2.30, "r");

			const double X1 = 3;
			const double Y1 = -1;
			const double X2 = 3;
			const double Y2 = 2.5;
			Console.WriteLine(CalcUtils.CalcDistanceBetweenTwo2DPoints(X1, Y1, X2, Y2));
			Console.WriteLine("Horizontal? " + CalcUtils.IsHorizontalLine(X1, X2));
			Console.WriteLine("Vertical? " + CalcUtils.IsVerticalLine(Y1, Y2));

			Student peter = new Student("Peter", "Ivanov", "From Sofia", DateTime.Parse("17.03.1992"));

			Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results", DateTime.Parse("03.11.1993"));

			Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
		}
	}
}