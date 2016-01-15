namespace InheritanceAndPolymorphism.Courses
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public class LocalCourse : Course
	{
		private string lab;

		public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
			: base(courseName, teacherName, students)
		{
			this.Lab = lab;
		}

		public string Lab
		{
			get
			{
				return this.lab;
			}

			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException("Lab", "Lab cannot be null or whitespace.");
				}

				this.lab = value;
			}
		}

		public override string ToString()
		{
			StringBuilder result = new StringBuilder(base.ToString());
			result.Append($"\n\tLab: {this.Lab}");

			return result.ToString();
		}
	}
}