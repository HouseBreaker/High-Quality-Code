namespace CohesionAndCoupling.Utils
{
	using System;

	public class FilenameUtils
	{
		public static string GetFileExtension(string fileName)
		{
			int indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
			if (indexOfLastDot == -1)
			{
				throw new InvalidOperationException("Filename has no extension.");
			}

			string extension = fileName.Substring(indexOfLastDot + 1);
			return extension;
		}

		public static string GetFileNameWithoutExtension(string fileName)
		{
			int indexOfLastDot = fileName.LastIndexOf(".", StringComparison.Ordinal);
			if (indexOfLastDot == -1)
			{
				return fileName;
			}

			string extension = fileName.Substring(0, indexOfLastDot);
			return extension;
		}
	}
}
