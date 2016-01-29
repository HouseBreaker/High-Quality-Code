namespace WalkInMatrix
{
	public static class MatrixGenerator
	{
		public static int[,] GenerateRotationalWalkInMatrix(int n)
		{
			int[,] matrix = new int[n, n];
			int nextNumber = 1;
			int currentRow = 0;
			int currentCol = 0;
			int directionRow = 1;
			int directionCol = 1;

			while (true)
			{
				matrix[currentRow, currentCol] = nextNumber;

				if (!CheckForAvailableCell(matrix, currentRow, currentCol))
				{
					FindCell(matrix, out currentRow, out currentCol);

					nextNumber++;

					if (currentRow != 0 && currentCol != 0)
					{
						directionRow = 1;
						directionCol = 1;

						while (true)
						{
							matrix[currentRow, currentCol] = nextNumber;

							if (!CheckForAvailableCell(matrix, currentRow, currentCol))
							{
								break;
							}

							while (NextDestinationIsntAvailable(matrix, currentRow, currentCol, directionRow, directionCol))
							{
								RotateUntilFindAvailableDestination(ref directionRow, ref directionCol);
							}

							currentRow += directionRow;
							currentCol += directionCol;
							nextNumber++;
						}
					}

					break;
				}

				while (NextDestinationIsntAvailable(matrix, currentRow, currentCol, directionRow, directionCol))
				{
					RotateUntilFindAvailableDestination(ref directionRow, ref directionCol);
				}

				currentRow += directionRow;
				currentCol += directionCol;
				nextNumber++;
			}

			return matrix;
		}

		private static bool NextDestinationIsntAvailable(
			int[,] matrix,
			int currectRow,
			int currectCol,
			int directionRow,
			int directionCol)
		{
			var hasInvalidRow = HasInvalidRow(matrix, currectRow, directionRow);
			var hasInvalidCol = HasInvalidCol(matrix, currectCol, directionCol);

			return hasInvalidRow || hasInvalidCol
					|| IsNextCellUnavailable(matrix, currectRow, currectCol, directionRow, directionCol);
		}

		private static bool IsNextCellUnavailable(
			int[,] matrix,
			int currentRow,
			int currentCol,
			int directionRow,
			int directionCol)
		{
			return matrix[currentRow + directionRow, currentCol + directionCol] != 0;
		}

		private static bool HasInvalidRow(int[,] matrix, int currectRow, int directionRow)
		{
			return currectRow + directionRow >= matrix.GetLength(0) || currectRow + directionRow < 0;
		}

		private static bool HasInvalidCol(int[,] matrix, int currectCol, int directionCol)
		{
			return currectCol + directionCol >= matrix.GetLength(1) || currectCol + directionCol < 0;
		}

		private static bool CheckForAvailableCell(int[,] arr, int row, int col)
		{
			int[] dirRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
			int[] dirCol = { 1, 0, -1, -1, -1, 0, 1, 1 };

			for (int i = 0; i < dirRow.Length; i++)
			{
				if (row + dirRow[i] >= arr.GetLength(0) || row + dirRow[i] < 0)
				{
					dirRow[i] = 0;
				}

				if (col + dirCol[i] >= arr.GetLength(0) || col + dirCol[i] < 0)
				{
					dirCol[i] = 0;
				}
			}

			for (int i = 0; i < dirRow.Length; i++)
			{
				if (arr[row + dirRow[i], col + dirCol[i]] == 0)
				{
					return true;
				}
			}

			return false;
		}

		private static void RotateUntilFindAvailableDestination(ref int dx, ref int dy)
		{
			int[] dirRow = { 1, 1, 1, 0, -1, -1, -1, 0 };
			int[] dirCol = { 1, 0, -1, -1, -1, 0, 1, 1 };
			int cd = 0;

			for (int count = 0; count < dirRow.Length; count++)
			{
				if (dirRow[count] == dx && dirCol[count] == dy)
				{
					cd = count;
					break;
				}
			}

			if (cd == 7)
			{
				dx = dirRow[0];
				dy = dirCol[0];
				return;
			}

			dx = dirRow[cd + 1];
			dy = dirCol[cd + 1];
		}

		private static void FindCell(int[,] arr, out int row, out int col)
		{
			row = 0;
			col = 0;

			for (int i = 0; i < arr.GetLength(0); i++)
			{
				for (int j = 0; j < arr.GetLength(1); j++)
				{
					if (arr[i, j] == 0)
					{
						row = i;
						col = j;
						return;
					}
				}
			}
		}
	}
}