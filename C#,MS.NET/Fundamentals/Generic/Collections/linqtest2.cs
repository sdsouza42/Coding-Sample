using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
	private static Interval CombineIntervals(Interval a, Interval b)
	{
		return new Interval(a.Minutes + b.Minutes, a.Seconds + b.Seconds);
	}

	public static void Main(string[] args)
	{
		int l = args.Length > 0 ? Convert.ToInt32(args[0]) : 0;
		double distance = 500;

		var store = new List<Interval> 
		{
			new Interval(7, 31),
			new Interval(4, 52),
			new Interval(5, 23),
			new Interval(6, 14),
			new Interval(3, 45),
			new Interval(8, 26)
		};
	
		var selection = from i in store
				where i.Time > l
				orderby i.Seconds descending
				select new
				{
					Duration = i,
					Speed = 3.6 * distance / i.Time
				};

		foreach(var entry in selection)
			Console.WriteLine("{0}\t{1:0.00}", entry.Duration, entry.Speed);

		
		Interval result = (from i in store where i.Time > l select i).Aggregate(CombineIntervals);
		Console.WriteLine("Total Interval = {0}", result);

	}
}
