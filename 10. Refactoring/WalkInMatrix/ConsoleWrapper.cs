namespace WalkInMatrix
{
	using System;

	public static class ConsoleWrapper
	{
		private static void Main()
		{
			Console.Write("Enter a positive number: ");
			string input = Console.ReadLine();

			int n;
			while (!int.TryParse(input, out n))
			{
				input = Console.ReadLine();
			}

			int[,] matrix = MatrixGenerator.GenerateRotationalWalkInMatrix(n);

			PrintMatrix(matrix);
		}

		private static void PrintMatrix(int[,] matix)
		{
			for (int row = 0; row < matix.GetLength(0); row++)
			{
				for (int col = 0; col < matix.GetLength(1); col++)
				{
					Console.Write("{0,4}", matix[row, col]);
				}

				Console.WriteLine();
			}
		}
	}
}