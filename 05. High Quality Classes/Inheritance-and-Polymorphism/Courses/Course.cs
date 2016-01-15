namespace InheritanceAndPolymorphism.Courses
{
	using System.Collections.Generic;
	using System.Text;

	public abstract class Course
	{
		protected Course(string name, string teacherName, IList<string> students)
		{
			this.Name = name;
			this.TeacherName = teacherName;
			this.Students = students;
		}

		public string Name { get; set; }

		public string TeacherName { get; set; }

		public IList<string> Students { get; set; }

		public override string ToString()
		{
			StringBuilder result = new StringBuilder();

			result.AppendFormat("{0}: {1}", this.GetType().Name, this.Name);
			result.AppendLine();

			result.AppendLine($"\tTeacher: {this.TeacherName}");
			result.Append($"\tStudents: {this.GetStudentsAsString()}");
			return result.ToString();
		}

		protected string GetStudentsAsString()
		{
			var studentsAsString = string.Join(", ", this.Students);
			return studentsAsString;
		}
	}
}