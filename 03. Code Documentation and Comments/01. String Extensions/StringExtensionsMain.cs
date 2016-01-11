namespace _01.String_Extensions
{
	using System;
	using System.Text;

	public static class StringExtensionsMain
	{
		public static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;
			const string Gosho = "гошо";

			Console.WriteLine(Gosho.ConvertCyrillicToLatinLetters());
		}
	}
}
