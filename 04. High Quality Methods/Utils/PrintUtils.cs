namespace Methods.Utils
{
	using System;

	public static class PrintUtils
	{
		public static string PrintDigitAsWord(int digit)
		{
			switch (digit)
			{
				case 0: return "zero";
				case 1: return "one";
				case 2: return "two";
				case 3: return "three";
				case 4: return "four";
				case 5: return "five";
				case 6: return "six";
				case 7: return "seven";
				case 8: return "eight";
				case 9: return "nine";
				default:
					throw new ArgumentOutOfRangeException(nameof(digit), "Invalid number!");
			}

		}

		public static void PrintDigitAsNumber(object number, string format)
		{
			switch (format)
			{
				case "f":
					Console.WriteLine("{0:f2}", number);
					break;
				case "%":
					Console.WriteLine("{0:p0}", number);
					break;
				case "r":
					Console.WriteLine("{0,8}", number);
					break;
				default:
					throw new ArgumentException("Invalid format. Valid formats are : \"f\", \"%\", \"r\"");
			}
		}
	}
}