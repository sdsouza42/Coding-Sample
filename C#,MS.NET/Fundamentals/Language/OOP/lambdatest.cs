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

	public static void Main()
	{
		int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

		Algorithm.PrintSquares("All squares", numbers);

		int l = 5;
		Algorithm.PrintSquaresIf("Big squares", numbers, delegate(int n) //passing anonymous method (closure)
		{
			return n > l;
		});

		Algorithm.PrintSquaresIf("Odd squares", numbers, n => (n % 2) == 1); //passing lambda expression
	}
}
