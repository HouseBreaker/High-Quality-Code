namespace CohesionAndCoupling.Utils
{
	using System;

	public static class GeometryUtils
	{
		public static double CalcVolume(double width, double height, double depth)
		{
			var volume = width * height * depth;
			return volume;
		}

		public static double CalcDistance2D(double x1, double y1, double x2, double y2)
		{
			var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			return distance;
		}

		public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
			return distance;
		}

		public static double CalcDiagonal2Sides(double side1, double side2)
		{
			var diagonal = Math.Sqrt(side1 * side1 + side2 * side2);
			return diagonal;
		}

		public static double CalcDiagonal3Sides(double side1, double side2, double side3)
		{
			var diagonal = Math.Sqrt(side1 * side1 + side2 * side2 + side3 * side3);
			return diagonal;
		}
	}
}