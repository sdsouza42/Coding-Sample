using System;

partial class Interval
{
	private static int count;

	partial void OnInit()
	{
		Console.WriteLine("Interval instance<{0}> initialized", ++count);
	}

	public static bool operator==(Interval lhs, Interval rhs)
	{
		return (lhs.GetHashCode() == rhs.GetHashCode()) && lhs.Equals(rhs);
	}

	public static bool operator!=(Interval lhs, Interval rhs)
	{
		return !(lhs == rhs);
	}

}

static class Program
{
	public static void Main()
	{
		Interval a = new Interval(3, 45);
		Interval b = new Interval(2, 30);
		Interval c = new Interval(2, 105);
		Interval d = b;

		Console.WriteLine("Interval a = {0}", a);
		Console.WriteLine("Interval b = {0}", b);
		Console.WriteLine("Interval c = {0}", c);
		Console.WriteLine("Interval d = {0}", d);

		Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
		Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
		Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));

		Console.WriteLine("Hash-code of a = {0:X}", a.GetHashCode());
		Console.WriteLine("Hash-code of b = {0:X}", b.GetHashCode());
		Console.WriteLine("Hash-code of c = {0:X}", c.GetHashCode());
		Console.WriteLine("Hash-code of d = {0:X}", d.GetHashCode());

		Console.WriteLine("a is equal to b: {0}", a.Equals(b));
		Console.WriteLine("a is equal to c: {0}", a == c);
		Console.WriteLine("d is equal to b: {0}", d == b);


	}
}
