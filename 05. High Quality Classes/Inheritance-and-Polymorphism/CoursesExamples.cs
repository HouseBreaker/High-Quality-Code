using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
	using System.Linq;
	using System.Text;

	using InheritanceAndPolymorphism.Courses;

	public class CoursesExamples
	{
		public static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;

			LocalCourse localCourse = new LocalCourse(
				"Databases", 
				"Svetlin Nakov", 
				new List<string> { "Peter", "Maria", "Milena", "Todor" }, 
				"Enterprise");
			Console.WriteLine(localCourse);

			Console.WriteLine();

			OffsiteCourse offsiteCourse = new OffsiteCourse(
				"PHP and WordPress Development", 
				"Mario Peshev", 
				new List<string>() { "Thomas", "Ani", "Steve" },
				"Sofia");
			Console.WriteLine(offsiteCourse);
		}
	}
}