using System;

static class Program
{
	private static double Average(double first, double second)
	{
		return (first + second) / 2;
	}

	private static double Average(double first, double second, double third)
	{
		return (first + second + third) / 3;
	}

	private static double Average(double first, double second, params double[] remaining)
	{
		double total = first + second;

		foreach(double value in remaining)
		{
			total += value;
		}

		return total / (remaining.Length + 2);
	}

	public static void Main()
	{
		Console.WriteLine("Average of two values = {0}", Average(23.4, 31.7));
		Console.WriteLine("Average of three values = {0}", Average(23.4, 31.7, 27.5));
		Console.WriteLine("Average of five values = {0}", Average(23.4, 31.7, 27.5, 21.6, 34.8));

	}
}