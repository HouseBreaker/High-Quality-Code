namespace WalkInMatrix.Tests
{
	using System.Diagnostics.CodeAnalysis;
	using System.Text;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using WalkInMatrix;

	[TestClass]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public class RotatingMatrixTest
	{
		[TestMethod]
		public void MatrixGenerator_4()
		{
			int n = 4;
			int[,] expectedMatrix =
				{
					{ 1, 10, 11, 12 },
					{ 9, 2, 15, 13 },
					{ 8, 16, 3, 14 },
					{ 7, 6, 5, 4 }
				};

			string expected = this.MatrixAsString(expectedMatrix);
			int[,] actualMatrix = MatrixGenerator.GenerateRotationalWalkInMatrix(n);
			string actual = this.MatrixAsString(actualMatrix);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MatrixGenerator_5()
		{
			int n = 5;
			int[,] expectedMatrix =
				{
					{ 1, 13, 14, 15, 16 },
					{ 12, 2, 21, 22, 17 },
					{ 11, 23, 3, 20, 18 },
					{ 10, 25, 24, 4, 19 },
					{ 9, 8, 7, 6, 5 }
				};

			int[,] actualMatrix = MatrixGenerator.GenerateRotationalWalkInMatrix(n);

			string expected = this.MatrixAsString(expectedMatrix);
			string actual = this.MatrixAsString(actualMatrix);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void MatrixGenerator_7()
		{
			int n = 7;
			int[,] expectedMatrix =
				{
					{ 1, 19, 20, 21, 22, 23, 24 },
					{ 18, 2, 33, 34, 35, 36, 25 },
					{ 17, 40, 3, 32, 39, 37, 26 },
					{ 16, 48, 41, 4, 31, 38, 27 },
					{ 15, 47, 49, 42, 5, 30, 28 },
					{ 14, 46, 45, 44, 43, 6, 29 },
					{ 13, 12, 11, 10, 9, 8, 7 }
				};

			string expected = this.MatrixAsString(expectedMatrix);
			int[,] actualMatrix = MatrixGenerator.GenerateRotationalWalkInMatrix(n);
			string actual = this.MatrixAsString(actualMatrix);
			Assert.AreEqual(expected, actual);
		}

		private string MatrixAsString(int[,] matrix)
		{
			StringBuilder result = new StringBuilder();

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					result.Append(matrix[row, col] + " ");
				}
			}

			result.Length--;
			return result.ToString();
		}
	}
}