using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		var store = new List<Interval> //list initializer
		{
			new Interval(7, 31),
			new Interval(4, 52),
			new Interval(5, 23),
			new Interval(6, 14),
			new Interval(3, 45)
		};

		//store.Sort();
		store.Sort((a, b) => a.Seconds - b.Seconds);

		foreach(Interval i in store)
			Console.WriteLine(i);
	}
}
