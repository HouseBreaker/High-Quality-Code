﻿namespace GameFifteen
{
	using System;

	internal static class WalkInMatrica
	{
		internal static void Change(ref int dx, ref int dy)
		{
			int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };

			int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
			int cd = 0;
			for (int count = 0; count < 8; count++)
			{
				if (dirX[count] == dx && dirY[count] == dy)
				{
					cd = count;
					break;
				}
			}

			if (cd == 7)
			{
				dx = dirX[0];
				dy = dirY[0];
				return;
			}

			dx = dirX[cd + 1];

			dy = dirY[cd + 1];
		}

		internal static bool Proverka(int[,] arr, int x, int y)
		{
			int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
			int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
			for (int i = 0; i < 8; i++)
			{
				if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
				{
					dirX[i] = 0;
				}

				if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
				{
					dirY[i] = 0;
				}
			}

			for (int i = 0; i < 8; i++)
			{
				if (arr[x + dirX[i], y + dirY[i]] == 0)
				{
					return true;
				}
			}

			return false;
		}

		internal static void FindCell(int[,] arr, out int x, out int y)
		{
			x = 0;
			y = 0;
			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(0); j++)
				{
					if (arr[i, j] == 0)
					{
						x = i;
						y = j;
						return;
					}
				}
			}
		}

		internal static void Main(string[] args)
		{
			// Console.WriteLine( "Enter a positive number " );
			// string input = Console.ReadLine(  );
			// int n = 0;
			// while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
			// {
			// Console.WriteLine( "You haven't entered a correct positive number" );
			// input = Console.ReadLine(  );
			// }
			int n = 6;
			int[,] matrix = new int[n, n];
			int k = 1, i = 0, j = 0, dx = 1, dy = 1;
			while (true)
			{
				// malko e kofti tova uslovie, no break-a raboti 100% : )
				matrix[i, j] = k;

				if (!Proverka(matrix, i, j))
				{
					break;
				}

				// prekusvame ako sme se zadunili
				if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
				{
					while (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
					{
						Change(ref dx, ref dy);
					}
				}

				i += dx;
				j += dy;
				k++;
			}

			FindCell(matrix, out i, out j);
			if (i != 0 && j != 0)
			{
				// taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
				dx = 1;
				dy = 1;

				while (true)
				{
					// malko e kofti tova uslovie, no break-a raboti 100% : )
					matrix[i, j] = k;
					if (!Proverka(matrix, i, j))
					{
						break;
					}

					// prekusvame ako sme se zadunili
					if (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
					{
						while (i + dx >= n || i + dx < 0 || j + dy >= n || j + dy < 0 || matrix[i + dx, j + dy] != 0)
						{
							Change(ref dx, ref dy);
						}
					}

					i += dx;
					j += dy;
					k++;
				}
			}

			PrintMatrix(matrix);
		}

		private static void PrintMatrix(int[,] matrix)
		{
			var rows = matrix.GetLength(0);
			var cols = matrix.GetLength(1);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					Console.Write("{0,3}", matrix[row, col]);
				}

				Console.WriteLine();
			}
		}
	}
}