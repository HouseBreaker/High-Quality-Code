using System;

namespace ConsoleApplication1
{
	class MatrixProductSumCalculator
	{
		static void Main()
		{
			var matrix1 = new double[,]
			{
				{ 1, 3 }, 
				{ 5, 7 }
			};

			var matrix2 = new double[,]
			{
				{ 4, 2 }, 
				{ 1, 5 }
			};

			var summedProductsMatrix = SumProductsOfMatrixElements(matrix1, matrix2);

			PrintMatrix(summedProductsMatrix);
		}

		static void PrintMatrix(double[,] matrix)
		{
			var rows = matrix.GetLength(0);
			var cols = matrix.GetLength(1);

			for (var row = 0; row < rows; row++)
			{
				for (var col = 0; col < cols; col++)
				{
					Console.Write(matrix[row, col] + " ");
				}
				Console.WriteLine();
			}
		}

		static double[,] SumProductsOfMatrixElements(double[,] matrix1, double[,] matrix2)
		{
			var matrix1Rows = matrix1.GetLength(0);
			var matrix1Cols = matrix1.GetLength(1);
			
			var matrix2Rows = matrix2.GetLength(0);
			var matrix2Cols = matrix2.GetLength(1);

			if (matrix1Cols != matrix2Rows)
			{
				throw new ArgumentException("Different matrix lengths! Lengths of the 2 matrices must be the same.");
			}

			var summedMatrix = new double[matrix1Rows, matrix2Cols];

			var rows = summedMatrix.GetLength(0);
			var cols = summedMatrix.GetLength(1);
			
			for (var row = 0; row < rows; row++)
			{
				for (var col = 0; col < cols; col++)
				{
					for (var i = 0; i < matrix1Cols; i++)
					{
						summedMatrix[row, col] += matrix1[row, i] * matrix2[i, col];
					}
				}
			}

			return summedMatrix;
		}
	}
}