using System;
using System.Threading.Tasks;

static class Program
{
	public static void Main()
	{
		long result = 0;

		/*
		for(int i = 1; i < 21; ++i)
		{
			Console.WriteLine("Processing value {0} in task<{1}>", i, Task.CurrentId ?? 0);
			Worker.DoWork(i);
			result += i * i;
		}
		*/

		Parallel.For(1, 21, i =>
		{
			Console.WriteLine("Processing value {0} in task<{1}>", i, Task.CurrentId ?? 0);
			Worker.DoWork(i);
			result += i * i;
		});

		Console.WriteLine("Result = {0}", result);
	}
}
