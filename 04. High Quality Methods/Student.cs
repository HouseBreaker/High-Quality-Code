namespace Methods
{
	using System;

	public class Student
	{
		private string firstName;

		private string lastName;

		private DateTime birthDate;

		public Student(string firstName, string lastName, string otherInfo, DateTime birthDate)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.OtherInfo = otherInfo;
			this.BirthDate = birthDate;
		}

		public DateTime BirthDate
		{
			get
			{
				return this.birthDate;
			}

			set
			{
				const int MaximumStudentAge = 100;
				var calculatedAge = DateTime.Now.Year - value.Year;
				var isOlderThanMaximumAge = calculatedAge >= MaximumStudentAge;

				if (isOlderThanMaximumAge)
				{
					throw new ArgumentOutOfRangeException(
						"birthDate", 
						$"Tried to create a {calculatedAge} year old Student. Student must not be over 100 years old.");
				}

				this.birthDate = value;
			}
		}

		public string FirstName
		{
			get
			{
				return this.firstName;
			}

			set
			{
				this.firstName = ValidateString(value, "First name");
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
				this.lastName = ValidateString(value, "Last name");
			}
		}

		public string OtherInfo { get; set; }

		public bool IsOlderThan(Student other)
		{
			return this.BirthDate < other.BirthDate;
		}

		private static string ValidateString(string name, string paramName)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException($"{paramName} cannot be null or whitespace");
			}

			return name;
		}
	}
}