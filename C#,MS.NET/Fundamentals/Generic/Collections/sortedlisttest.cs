using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		IDictionary<string, Interval> store = new SortedList<string, Interval>();
		store.Add("monday", new Interval(7, 31));
		store.Add("tuesday", new Interval(4, 52));
		store.Add("wednesday", new Interval(5, 23));
		store.Add("thursday", new Interval(6, 14));
		store.Add("friday", new Interval(3, 45));

		foreach(KeyValuePair<string, Interval> e in store)
			Console.WriteLine("{0} = {1}", e.Key, e.Value);

		Console.Write("Key: ");
		string key = Console.ReadLine();
		
		Interval val;
		if(store.TryGetValue(key, out val))
		{
			Console.WriteLine("Value = {0}", val);
		}
		else
		{
			Console.WriteLine("No such key!");
		}

	}
}
