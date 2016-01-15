namespace InheritanceAndPolymorphism.Courses
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class OffsiteCourse : Course
	{
		private string town;

		public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
			: base(courseName, teacherName, students)
		{
			this.Town = town;
		}

		public string Town
		{
			get
			{
				return this.town;
			}

			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Lab", "Lab cannot be null or whitespace.");
				}

				this.town = value;
			}
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder(base.ToString());
			result.Append($"\n\tTown: {this.Town}");

			return result.ToString();
		}
	}
}