using System;

delegate void Consumer<V>(V entry);

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

	public void Consume(Consumer<V> process)
	{
		for(Node n = top; n != null; n = n.previous)
			process(n.value);
	}
}

static class Program
{
	public static void Main()
	{

		SimpleStack<Interval> c = new SimpleStack<Interval>();
		c.Push(new Interval(7, 31));
		c.Push(new Interval(4, 52));
		c.Push(new Interval(5, 23));
		c.Push(new Interval(6, 14));
		c.Push(new Interval(3, 45));

		c.Consume(Console.WriteLine);
	
		Console.WriteLine();

		c.Consume(i => Console.WriteLine(i.Time));
	
	}
}
