using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

static class Test
{
	private static long Processed(int value)
	{
		Console.WriteLine("Processing value {0} in task<{1}>", value, Task.CurrentId ?? 0);
		Worker.DoWork(value);

		return value * value;
	}

	public static void Main()
	{
		IEnumerable<int> numbers = Enumerable.Range(1, 20);
		long result = (from n in numbers.AsParallel() select Processed(n)).Sum();

		Console.WriteLine("Result = {0}", result);
	}
}
