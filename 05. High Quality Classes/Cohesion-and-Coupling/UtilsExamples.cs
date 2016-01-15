namespace CohesionAndCoupling
{
	using System;

	using CohesionAndCoupling.Utils;

	public class UtilsExamples
	{
		public static void Main()
		{
			// throws InvalidOperationException
			// Console.WriteLine(FilenameUtils.GetFileExtension("example"));
			Console.WriteLine(FilenameUtils.GetFileExtension("example.pdf"));
			Console.WriteLine(FilenameUtils.GetFileExtension("example.new.pdf"));

			Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example"));
			Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.pdf"));
			Console.WriteLine(FilenameUtils.GetFileNameWithoutExtension("example.new.pdf"));

			Console.WriteLine("Distance in the 2D space = {0:f2}", GeometryUtils.CalcDistance2D(1, -2, 3, 4));
			Console.WriteLine("Distance in the 3D space = {0:f2}", GeometryUtils.CalcDistance3D(5, 2, -1, 3, -6, 4));

			const double Width = 3;
			const double Height = 4;
			const double Depth = 5;

			Console.WriteLine("Volume = {0:f2}", GeometryUtils.CalcVolume(Width, Height, Depth));

			Console.WriteLine("Diagonal XYZ = {0:f2}", GeometryUtils.CalcDiagonal3Sides(Width, Height, Depth));
			Console.WriteLine("Diagonal XY  = {0:f2}", GeometryUtils.CalcDiagonal2Sides(Width, Height));
			Console.WriteLine("Diagonal XZ  = {0:f2}", GeometryUtils.CalcDiagonal2Sides(Width, Depth));
			Console.WriteLine("Diagonal YZ  = {0:f2}", GeometryUtils.CalcDiagonal2Sides(Height, Depth));
		}
	}
}