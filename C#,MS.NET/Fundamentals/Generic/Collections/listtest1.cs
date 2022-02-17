using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		IList<Interval> store = new List<Interval>();
		store.Add(new Interval(7, 31));
		store.Add(new Interval(4, 52));
		store.Add(new Interval(5, 23));
		store.Add(new Interval(6, 14));
		store.Add(new Interval(3, 45));
		store.Add(new Interval(2, 105));

		foreach(Interval i in store)
			Console.WriteLine(i);

		Console.WriteLine("Fourth Interval = {0}", store[3]);
	}
}
