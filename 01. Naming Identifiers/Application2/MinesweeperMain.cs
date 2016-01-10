using System;
using System.Collections.Generic;

namespace Application2
{
	public class Minesweeper
	{
		private const int Rows = 5;
		private const int Cols = 10;
		private const int MineCount = 35;

		private static char[,] field;
		private static char[,] bombs;
		private static int points;
		private static bool hasExploded;
		private static bool isGameRunning;

		private static void Main()
		{
			string command;

			InitializeGameState();

			var scoreboard = new List<ScoreboardEntry>(6);

			var currentRow = 0;
			var currentCol = 0;

			var hasPlayerWon = false;

			do
			{
				if (isGameRunning)
				{
					Console.WriteLine(
						"Let's play Minesweeper. Try to find the cells without mines."
						+ "\nThe command 'top' shows the scoreboard, 'restart' starts a new game, 'exit' quits.");
					
					PrintPlayingField(field);

					isGameRunning = false;
				}

				Console.Write("Input row and column: ");
				
				command = Console.ReadLine().Trim();

				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out currentRow) 
						&& int.TryParse(command[2].ToString(), out currentCol)
						&& currentRow <= field.GetLength(0) && currentCol <= field.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						PrintScoreboard(scoreboard);
						break;
					
					case "restart":
						field = GeneratePlayingField();
						bombs = GenerateBombs();
						PrintPlayingField(field);
						break;

					case "exit":
						Console.WriteLine("Bye bye!");
						break;
					
					case "turn":
						if (bombs[currentRow, currentCol] != '*')
						{
							if (bombs[currentRow, currentCol] == '-')
							{
								ProcessTurn(field, bombs, currentRow, currentCol);
								points++;
							}

							if (MineCount == points)
							{
								hasPlayerWon = true;
							}
							else
							{
								PrintPlayingField(field);
							}
						}
						else
						{
							hasExploded = true;
						}

						break;
					default:
						Console.WriteLine("\nError: Invalid Command!n");
						break;
				}

				if (hasExploded)
				{
					PrintPlayingField(bombs);

					Console.Write($"\nDied a hero's death with {points} points.");

					var nickname = Console.ReadLine();
					var scoreboardEntry = new ScoreboardEntry(nickname, points);

					if (scoreboard.Count < 5)
					{
						scoreboard.Add(scoreboardEntry);
					}
					else
					{
						for (var i = 0; i < scoreboard.Count; i++)
						{
							if (scoreboard[i].Points < scoreboardEntry.Points)
							{
								scoreboard.Insert(i, scoreboardEntry);
								scoreboard.RemoveAt(scoreboard.Count - 1);
								break;
							}
						}
					}

					scoreboard.Sort((r1, r2) => string.Compare(r2.Name, r1.Name, StringComparison.Ordinal));
					scoreboard.Sort((r1, r2) => r2.Points.CompareTo(r1.Points));
					PrintScoreboard(scoreboard);

					InitializeGameState();
				}

				if (hasPlayerWon)
				{
					Console.WriteLine($"\nGreat job! You uncovered {MineCount} cells without a drop of blood.");
					PrintPlayingField(bombs);
					Console.WriteLine("Please input your name: ");

					var playerName = Console.ReadLine();
					var scoreboardEntry = new ScoreboardEntry(playerName, points);
					scoreboard.Add(scoreboardEntry);
					PrintScoreboard(scoreboard);

					InitializeGameState();
				}
			}
			while (command != "exit");

			Console.WriteLine("Made in Bulgaria!");
			Console.Read();
		}

		private static void InitializeGameState()
		{
			field = GeneratePlayingField();
			bombs = GenerateBombs();
			points = 0;
			hasExploded = false;
			isGameRunning = true;
		}

		private static void PrintScoreboard(List<ScoreboardEntry> scoreboard)
		{
			Console.WriteLine("\nScoreboard:");

			if (scoreboard.Count > 0)
			{
				for (var i = 0; i < scoreboard.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} cells", i + 1, scoreboard[i].Name, scoreboard[i].Points);
				}

				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty scoreboard!\n");
			}
		}

		private static void ProcessTurn(char[,] playingField, char[,] minefield, int row, int col)
		{
			var bombAtPosition = CalculateMines(minefield, row, col);
			minefield[row, col] = bombAtPosition;
			playingField[row, col] = bombAtPosition;
		}

		private static void PrintPlayingField(char[,] board)
		{
			var rows = board.GetLength(0);
			var cols = board.GetLength(1);

			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			
			const string separator = "   ---------------------";
			Console.WriteLine(separator);

			for (var row = 0; row < rows; row++)
			{
				Console.Write("{0} | ", row);
				for (var col = 0; col < cols; col++)
				{
					Console.Write("{0} ", board[row, col]);
				}

				Console.Write("|");
				Console.WriteLine();
			}

			Console.WriteLine(separator);
			Console.WriteLine();
		}

		private static char[,] GeneratePlayingField()
		{
			var playingField = new char[Rows, Cols];

			for (var row = 0; row < Rows; row++)
			{
				for (var col = 0; col < Cols; col++)
				{
					playingField[row, col] = '?';
				}
			}

			return playingField;
		}

		private static char[,] GenerateBombs()
		{
			const int rows = 5;
			const int cols = 10;

			var minefield = new char[rows, cols];

			for (var row = 0; row < rows; row++)
			{
				for (var col = 0; col < cols; col++)
				{
					minefield[row, col] = '-';
				}
			}

			var mines = new List<int>();
			while (mines.Count < 15)
			{
				var random = new Random();
				var randomNumber = random.Next(50);
				if (!mines.Contains(randomNumber))
				{
					mines.Add(randomNumber);
				}
			}

			foreach (var mine in mines)
			{
				var row = mine % cols;
				var col = mine / cols;

				if (row == 0 && mine != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}

				minefield[col, row - 1] = '*';
			}

			return minefield;
		}

		private static char CalculateMines(char[,] board, int row, int col)
		{
			var count = 0;
			
			var rows = board.GetLength(0);
			var cols = board.GetLength(1);

			if (row - 1 >= 0)
			{
				if (board[row - 1, col] == '*')
				{
					count++;
				}
			}

			if (row + 1 < rows)
			{
				if (board[row + 1, col] == '*')
				{
					count++;
				}
			}

			if (col - 1 >= 0)
			{
				if (board[row, col - 1] == '*')
				{
					count++;
				}
			}

			if (col + 1 < cols)
			{
				if (board[row, col + 1] == '*')
				{
					count++;
				}
			}

			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (board[row - 1, col - 1] == '*')
				{
					count++;
				}
			}

			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (board[row - 1, col + 1] == '*')
				{
					count++;
				}
			}

			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (board[row + 1, col - 1] == '*')
				{
					count++;
				}
			}

			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (board[row + 1, col + 1] == '*')
				{
					count++;
				}
			}

			return char.Parse(count.ToString());
		}
	}
}