// ReSharper disable CompareOfFloatsByEqualityOperator
namespace Methods.Utils
{
	using System;

	public static class CalcUtils
	{
		public static double CalculateTriangleArea(double a, double b, double c)
		{
			if (a <= 0 || b <= 0 || c <= 0)
			{
				throw new ArgumentException("Side a should be positive.");
			}

			double s = (a + b + c) / 2;
			double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
			return area;
		}

		public static int FindMax(params int[] elements)
		{
			if (elements == null || elements.Length == 0)
			{
				throw new ArgumentException("Elements cannot be null or zero.");
			}

			int largestElement = elements[0];
			for (int i = 1; i < elements.Length; i++)
			{
				if (elements[i] > largestElement)
				{
					largestElement = elements[i];
				}
			}

			return largestElement;
		}

		public static double CalcDistanceBetweenTwo2DPoints(double x1, double y1, double x2, double y2)
		{
			double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			return distance;
		}

		public static bool IsHorizontalLine(double x1, double x2)
		{
			return x1 == x2;
		}

		public static bool IsVerticalLine(double y1, double y2)
		{
			return y1 == y2;
		}
	}
}