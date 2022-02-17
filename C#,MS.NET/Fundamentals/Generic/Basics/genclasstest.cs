using System;

class SimpleStack<V>
{
	private class Node
	{
		internal V value;
		internal Node previous;

		internal Node(V val, Node prev)
		{
			value = val;
			previous = prev;
		}
	}

	private Node top;

	public void Push(V value)
	{
		top = new Node(value, top);
	}

	public V Pop()
	{
		V result = top.value;
		top = top.previous;
		return result;
	}

	public bool Empty()
	{
		return top == null;
	}
}

static class Program
{
	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");
		//a.Push(6.78);

		var b = new SimpleStack<string>();
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");

		SimpleStack<Interval> c = new SimpleStack<Interval>();
		c.Push(new Interval(7, 31));
		c.Push(new Interval(4, 52));
		c.Push(new Interval(5, 23));
		c.Push(new Interval(6, 14));
		c.Push(new Interval(3, 45));

		SimpleStack<object> d = new SimpleStack<object>();
		d.Push("Saturday");
		d.Push(6.78);
		d.Push(new Interval(2, 40));

		while(!a.Empty())
			Console.WriteLine(a.Pop());
		Console.WriteLine();

		while(!b.Empty())
			Console.WriteLine(b.Pop());
		Console.WriteLine();

		while(!c.Empty())
			Console.WriteLine(c.Pop());
		Console.WriteLine();

		while(!d.Empty())
			Console.WriteLine(d.Pop());

	}
}
