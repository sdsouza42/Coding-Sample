using System;

delegate bool Filter(int value);

static class Algorithm
{
	public static void PrintSquares(string label, int[] values)
	{
		Console.Write("{0}:", label);

		foreach(int value in values)
		{
			Console.Write(" {0}", value * value);
		}

		Console.WriteLine();	
	}

	public static void PrintSquaresIf(string label, int[] values, Filter check)
	{
		Console.Write("{0}:", label);

		foreach(int value in values)
		{
			if(check(value)) //check.Invoke(value)
				Console.Write(" {0}", value * value);
		}

		Console.WriteLine();	
	}
}

static class Program
{
	private static bool IsOdd(int n)
	{
		return (n % 2) == 1;
	}

	//nested class
	class IsBetween
	{
		private int low, high;

		internal IsBetween(int l, int h)
		{
			low = l;
			high = h;
		}

		public bool Test(int entry)
		{
			return (entry > low) && (entry < high);
		}
	}

	public static void Main()
	{
		int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

		Algorithm.PrintSquares("All squares", numbers);

		Algorithm.PrintSquaresIf("Odd squares", numbers, IsOdd); //passing method-group

		Algorithm.PrintSquaresIf("Mid squares", numbers, new IsBetween(3, 8).Test); 

	}
}
