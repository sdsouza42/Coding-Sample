using System;

static class Test
{
	private static T Select<T>(int sign, T first, T second)
	{
		if(sign < 0)
			return first;
		
		return second;
	}

	public static void Main(string[] args)
	{
		int s = Convert.ToInt32(args[0]);

		string ss = Select(s, "Monday", "Tuesday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = Select(s, 8.25, 9.75);
		Console.WriteLine("Selected double = {0}", sd);

		long sl = Select(s, 123456L, 0xABCDEFL);
		Console.WriteLine("Selected long = {0}", sl);

	}
}
