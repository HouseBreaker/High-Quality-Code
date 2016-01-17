using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions_Homework
{
	using Exceptions_Homework.Exams;

	internal class ExceptionsMain
	{
		internal static void Main()
		{
			var substr = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
			Console.WriteLine(substr);

			var subarr = Utils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
			Console.WriteLine(string.Join(" ", subarr));

			var allarr = Utils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
			Console.WriteLine(string.Join(" ", allarr));

			var emptyarr = Utils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
			Console.WriteLine(string.Join(" ", emptyarr));

			var brokenarr = Utils.Subsequence(new[] { 1, 2, 3, 4 }, 1, 4);
			Console.WriteLine(string.Join(" ", brokenarr));

			Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
			Console.WriteLine(Utils.ExtractEnding("Nakov", 4));
			Console.WriteLine(Utils.ExtractEnding("beer", 4));

			try
			{
				Console.WriteLine(Utils.ExtractEnding("Hi", 100));
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
			}

			try
			{
				Console.WriteLine(Utils.ExtractEnding(string.Empty, 5));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			PrintPrimeStatusOfNumber(23);
			PrintPrimeStatusOfNumber(33);

			List<Exam> peterExams = new List<Exam>
										{
											new SimpleMathExam(2), 
											new CSharpExam(55), 
											new CSharpExam(100), 
											new SimpleMathExam(1), 
											new CSharpExam(0), 
										};

			Student peter = new Student("Peter", "Petrov", peterExams);
			double peterAverageResult = peter.CalcAverageExamResultInPercents();
			Console.WriteLine("Average results = {0:p0}", peterAverageResult);
		}

		private static void PrintPrimeStatusOfNumber(int number)
		{
			string isOrIsNotPrime = Utils.IsPrime(number) ? "is" : "is not";
			Console.WriteLine($"{number} {isOrIsNotPrime} prime");
		}
	}
}