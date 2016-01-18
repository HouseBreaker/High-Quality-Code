namespace _02.Performance_of_operations
{
	using System;
	using System.Diagnostics;
	using System.Linq;

	public static class PerformanceTestMain
	{
		private static readonly Stopwatch stopwatch = new Stopwatch();

		const int Int1 = int.MinValue;
		const int Int2 = int.MaxValue;

		const long Long1 = long.MaxValue;
		const long Long2 = long.MinValue;

		const double Double1 = double.MaxValue;
		const double Double2 = double.MinValue;

		const decimal Decimal1 = 0M;
		const decimal Decimal2 = 100M;

		public static void Main()
		{
			TestOperation(MathOperations.Add, $"Add {TestValues.NumberOfTests} Ints", Int1, Int2);
			TestOperation(MathOperations.Add, $"Add {TestValues.NumberOfTests} Longs", Long1, Long2);
			TestOperation(MathOperations.Add, $"Add {TestValues.NumberOfTests} Doubles", Double1, Double2);
			TestOperation(MathOperations.Add, $"Add {TestValues.NumberOfTests} Decimals", Decimal1, Decimal2);

			Console.WriteLine();
			TestOperation(MathOperations.Subtract, $"Subtract {TestValues.NumberOfTests} Ints", Int1, Int2);
			TestOperation(MathOperations.Subtract, $"Subtract {TestValues.NumberOfTests} Longs", Long1, Long2);
			TestOperation(MathOperations.Subtract, $"Subtract {TestValues.NumberOfTests} Doubles", Double1, Double2);
			TestOperation(MathOperations.Subtract, $"Subtract {TestValues.NumberOfTests} Decimals", Decimal1, Decimal2);

			Console.WriteLine();
			TestOperation(MathOperations.IncrementPrefix, $"Increment Int     (prefix) {TestValues.NumberOfTests} times", Int1);
			TestOperation(MathOperations.IncrementPrefix, $"Increment Long    (prefix) {TestValues.NumberOfTests} times", Long1);
			TestOperation(MathOperations.IncrementPrefix, $"Increment Double  (prefix) {TestValues.NumberOfTests} times", Double1);
			TestOperation(MathOperations.IncrementPrefix, $"Increment Decimal (prefix) {TestValues.NumberOfTests} times", Decimal1);

			Console.WriteLine();
			TestOperation(MathOperations.IncrementPostfix, $"Increment Int     (postfix) {TestValues.NumberOfTests} times", Int1);
			TestOperation(MathOperations.IncrementPostfix, $"Increment Long    (postfix) {TestValues.NumberOfTests} times", Long1);
			TestOperation(MathOperations.IncrementPostfix, $"Increment Double  (postfix) {TestValues.NumberOfTests} times", Double1);
			TestOperation(MathOperations.IncrementPostfix, $"Increment Decimal (postfix) {TestValues.NumberOfTests} times", Decimal1);

			Console.WriteLine();
			TestOperation(MathOperations.IncrementByOne, $"Increment Int {TestValues.NumberOfTests} times", Int1);
			TestOperation(MathOperations.IncrementByOne, $"Increment Long {TestValues.NumberOfTests} times", Long1);
			TestOperation(MathOperations.IncrementByOne, $"Increment Double {TestValues.NumberOfTests} times", Double1);
			TestOperation(MathOperations.IncrementByOne, $"Increment Decimal {TestValues.NumberOfTests} times", Decimal1);

			Console.WriteLine();
			TestOperation(MathOperations.Multiply, $"Multiply 2 Ints     {TestValues.NumberOfTests} times", Int1, Int2);
			TestOperation(MathOperations.Multiply, $"Multiply 2 Longs    {TestValues.NumberOfTests} times", Long1, Long2);
			TestOperation(MathOperations.Multiply, $"Multiply 2 Doubles  {TestValues.NumberOfTests} times", Double1, Double2);
			TestOperation(MathOperations.Multiply, $"Multiply 2 Decimals {TestValues.NumberOfTests} times", Decimal1, Decimal2);

			Console.WriteLine();
			TestOperation(MathOperations.Divide, $"Divide 2 Ints     {TestValues.NumberOfTests} times", Int1, Int2);
			TestOperation(MathOperations.Divide, $"Divide 2 Longs    {TestValues.NumberOfTests} times", Long1, Long2);
			TestOperation(MathOperations.Divide, $"Divide 2 Doubles  {TestValues.NumberOfTests} times", Double1, Double2);
			TestOperation(MathOperations.Divide, $"Divide 2 Decimals {TestValues.NumberOfTests} times", Decimal1, Decimal2);

			Console.WriteLine();
			TestOperation(MathOperations.Sqrt, $"Square root of Double  {TestValues.NumberOfTests} times", Double1);
			TestOperation(MathOperations.Sqrt, $"Square root of Decimal {TestValues.NumberOfTests} times", Decimal1);

			Console.WriteLine();
			TestOperation(MathOperations.Log, $"Logarithm of Double  {TestValues.NumberOfTests} times", Double1);
			TestOperation(MathOperations.Log, $"Logarithm of Decimal {TestValues.NumberOfTests} times", Decimal1);

			Console.WriteLine();
			TestOperation(MathOperations.Sin, $"Sine of Double  {TestValues.NumberOfTests} times", Double1);
			TestOperation(MathOperations.Sin, $"Sine of Decimal {TestValues.NumberOfTests} times", Decimal1);
		}

		private static void TestOperation<T>(Action<T, T> operation, string description, params T[] parameters)
		{
			double[] testResults = new double[TestValues.NumberOfTestsForAveraging];

			for (int i = 0; i < TestValues.NumberOfTestsForAveraging; i++)
			{
				var firstParam = parameters[0];
				var secondParam = parameters[1];

				stopwatch.Restart();
				operation.Invoke(firstParam, secondParam);
				stopwatch.Stop();

				testResults[i] = stopwatch.Elapsed.TotalMilliseconds;
			}

			double averageMs = testResults.Average();
			PrintAverageMs(description, averageMs);
		}

		private static void TestOperation<T>(Action<T> operation, string description, params T[] parameters)
		{
			double[] testResults = new double[TestValues.NumberOfTestsForAveraging];

			for (int i = 0; i < TestValues.NumberOfTestsForAveraging; i++)
			{
				var firstParam = parameters[0];

				stopwatch.Restart();
				operation.Invoke(firstParam);
				stopwatch.Stop();

				testResults[i] = stopwatch.Elapsed.TotalMilliseconds;
			}

			double averageMs = testResults.Average();
			PrintAverageMs(description, averageMs);
		}

		private static void PrintAverageMs(string description, double averageMs)
		{
			Console.WriteLine(
				$"{description} derived from {TestValues.NumberOfTestsForAveraging} tests:".PadRight(80) + $"{averageMs:F3}ms");
		}
	}
}