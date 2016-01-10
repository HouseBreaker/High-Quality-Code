namespace _02.Reformat_Your_Own_Code
{
	using System;

	using _02.Reformat_Your_Own_Code.Dependencies;

	public class StudentReformatted : Human
	{
		private const int FacultyNumberLowerBound = 5;

		private const int FacultyNumberUpperBound = 10;

		private string facultyNumber;

		public StudentReformatted(string firstName, string lastName, string facultyNumber)
			: base(firstName, lastName)
		{
			this.FacultyNumber = facultyNumber;
		}

		private string FacultyNumber
		{
			get
			{
				return this.facultyNumber;
			}

			set
			{
				if (value.Length < FacultyNumberLowerBound || value.Length > FacultyNumberUpperBound)
				{
					throw new ArgumentOutOfRangeException(nameof(value), "Faculty number should be in the range [5...10]");
				}

				this.facultyNumber = value;
			}
		}

		public override string ToString()
		{
			return base.ToString() + $" Faculty number: {this.FacultyNumber}";
		}
	}
}