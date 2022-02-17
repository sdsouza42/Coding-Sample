using System;

static class Test
{
	private static object Select(int sign, object first, object second)
	{
		if(sign < 0)
			return first;
		
		return second;
	}

	public static void Main(string[] args)
	{
		int s = Convert.ToInt32(args[0]);

		string ss = (string)Select(s, "Monday", "Tuesday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = (double)Select(s, 8.25, 9.75);
		Console.WriteLine("Selected double = {0}", sd);

		long sl = (long)Select(s, 123456L, "ABCDEFL");
		Console.WriteLine("Selected long = {0}", sl);

	}
}
