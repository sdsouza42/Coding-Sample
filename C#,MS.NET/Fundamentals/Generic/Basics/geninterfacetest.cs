using System;

interface IStackReader<out V>
{
	V Pop();

	bool Empty();
}

interface IStackWriter<in V>
{
	void Push(V value);
}

class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
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

	public void Copy(IStackWriter<V> target)
	{
		for(Node n = top; n != null; n = n.previous)
			target.Push(n.value);
	}
}

class FiniteStack<V> : IStackReader<V>, IStackWriter<V>
{
	private V[] store;
	private int count;

	public FiniteStack(int size)
	{
		store = new V[size];
	}

	public void Push(V value)
	{
		store[count++] = value;
	}

	public V Pop()
	{
		return store[--count];
	}

	public bool Empty()
	{
		return count == 0;
	}
}

static class Program
{
	private static void PrintStack(IStackReader<object> stack)
	{
		for(int i = 0; !stack.Empty(); ++i)
		{
			if(i > 0) Console.Write(", ");
			Console.Write("{0}", stack.Pop());
		}

		Console.WriteLine();
	}


	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");

		FiniteStack<string> b = new FiniteStack<string>(10);
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");
		a.Copy(b);

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
		c.Copy(d);

		PrintStack(a);		
		PrintStack(b);
		PrintStack(c);
		PrintStack(d);

	}
}
