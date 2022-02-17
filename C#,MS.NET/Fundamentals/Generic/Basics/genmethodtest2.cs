using System;

static class Test
{
	private static T Greater<T>(T first, T second) where T : IComparable<T>
	{
		if(first.CompareTo(second) > 0)
			return first;

		return second;
	}

	public static void Main(string[] args)
	{
		string gs = Greater("Monday", "Tuesday");
		Console.WriteLine("Greater string = {0}", gs);

		double gd = Greater(9.75, 8.25);
		Console.WriteLine("Greater double = {0}", gd);

		Interval gi = Greater(new Interval(3, 45), new Interval(2, 30));
		Console.WriteLine("Greater Interval = {0}", gi);

	}
}
