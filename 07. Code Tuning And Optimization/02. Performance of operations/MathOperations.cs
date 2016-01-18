using System;

namespace _02.Performance_of_operations
{
	public static class MathOperations
	{
		public static void Add(int num1, int num2)
		{
			int result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 + num2;
			}
		}

		public static void Add(long num1, long num2)
		{
			long result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 + num2;
			}
		}

		public static void Add(double num1, double num2)
		{
			double result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 + num2;
			}
		}

		public static void Add(decimal num1, decimal num2)
		{
			decimal result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 + num2;
			}
		}

		public static void Subtract(int num1, int num2)
		{
			int result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 - num2;
			}
		}

		public static void Subtract(long num1, long num2)
		{
			long result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 - num2;
			}
		}

		public static void Subtract(double num1, double num2)
		{
			double result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 - num2;
			}
		}

		public static void Subtract(decimal num1, decimal num2)
		{
			decimal result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 - num2;
			}
		}

		public static void IncrementPrefix(int num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				++num;
			}
		}

		public static void IncrementPrefix(long num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				++num;
			}
		}

		public static void IncrementPrefix(double num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				++num;
			}
		}

		public static void IncrementPrefix(decimal num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				++num;
			}
		}

		public static void IncrementPostfix(int num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num++;
			}
		}

		public static void IncrementPostfix(long num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num++;
			}
		}

		public static void IncrementPostfix(double num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num++;
			}
		}

		public static void IncrementPostfix(decimal num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num++;
			}
		}

		public static void IncrementByOne(int num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num += 1;
			}
		}

		public static void IncrementByOne(long num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num += 1;
			}
		}

		public static void IncrementByOne(double num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num += 1;
			}
		}

		public static void IncrementByOne(decimal num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				num += 1;
			}
		}

		public static void Multiply(int num1, int num2)
		{
			int result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 * num2;
			}
		}

		public static void Multiply(long num1, long num2)
		{
			long result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 * num2;
			}
		}

		public static void Multiply(double num1, double num2)
		{
			double result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 * num2;
			}
		}

		public static void Multiply(decimal num1, decimal num2)
		{
			decimal result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 * num2;
			}
		}

		public static void Divide(int num1, int num2)
		{
			int result;

			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 / num2;
			}
		}

		public static void Divide(long num1, long num2)
		{
			long result;

			for (long i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 / num2;
			}
		}

		public static void Divide(double num1, double num2)
		{
			double result;

			for (double i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 / num2;
			}
		}

		public static void Divide(decimal num1, decimal num2)
		{
			decimal result;

			for (decimal i = 0; i < TestValues.NumberOfTests; i++)
			{
				result = num1 / num2;
			}
		}

		public static void Sqrt(double num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				Math.Sqrt(num);
			}
		}

		public static void Sqrt(decimal num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				Math.Sqrt((double)num);
			}
		}

		public static void Log(double num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				Math.Log(num);
			}
		}

		public static void Log(decimal num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				Math.Log((double)num);
			}
		}

		public static void Sin(double num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				Math.Sin(num);
			}
		}

		public static void Sin(decimal num)
		{
			for (int i = 0; i < TestValues.NumberOfTests; i++)
			{
				Math.Sin((double)num);
			}
		}
	}
}