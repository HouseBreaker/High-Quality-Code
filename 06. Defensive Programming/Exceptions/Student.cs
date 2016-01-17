using System;
using System.Collections.Generic;
using System.Linq;

namespace Exceptions_Homework
{
	using Exceptions_Homework.Exams;

	public class Student
	{
		private string firstName;

		private string lastName;

		private IList<Exam> exams; 

		public Student(string firstName, string lastName, IList<Exam> exams)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Exams = exams;
		}

		public string FirstName
		{
			get
			{
				return this.firstName;
			}

			set
			{
				this.firstName = ValidateString(value, nameof(this.FirstName));
			}
		}

		

		public string LastName
		{
			get
			{
				return this.lastName;
			}

			set
			{
				this.lastName = ValidateString(value, nameof(this.LastName));
			}
		}

		public IList<Exam> Exams
		{
			get
			{
				return this.exams;
			}

			set
			{
				if (value == null)
				{
					this.exams = new List<Exam>();
				}

				this.exams = value;
			}
		}

		public IList<ExamResult> CheckExams()
		{
			return this.Exams.Select(e => e.Check()).ToList();
		}

		public double CalcAverageExamResultInPercents()
		{
			if (this.Exams.Count == 0)
			{
				throw new ArgumentNullException(nameof(this.Exams), "Cannot calculate percentage if the student has no exams.");
			}

			double[] examScores = new double[this.Exams.Count];
			IList<ExamResult> examResults = this.CheckExams();
			for (int i = 0; i < examResults.Count; i++)
			{
				examScores[i] = (examResults[i].Grade - examResults[i].MinGrade) / (examResults[i].MaxGrade - examResults[i].MinGrade);
			}

			return examScores.Average();
		}

		private static string ValidateString(string stringToCheck, string paramName)
		{
			if (string.IsNullOrWhiteSpace(stringToCheck))
			{
				throw new ArgumentNullException(paramName, $"{paramName} cannot be null, empty or whitespace.");
			}

			return stringToCheck;
		}
	}
}