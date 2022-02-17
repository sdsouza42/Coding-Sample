using System;
using System.Linq;

static class Program
{
	public static void Main()
	{
		int[] numbers = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

		var selection = from n in numbers where (n % 2) == 1 select n * n;
		foreach(var entry in selection)
			Console.WriteLine(entry);
	}
}
