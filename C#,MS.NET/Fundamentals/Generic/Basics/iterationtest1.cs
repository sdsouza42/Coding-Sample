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

	public SimpleEnumerator GetEnumerator()
	{
		return new SimpleEnumerator(this);
	}

	public class SimpleEnumerator
	{
		private Node current;

		internal SimpleEnumerator(SimpleStack<V> stack)
		{
			current = stack.top;
		}

		public bool MoveNext()
		{
			return current != null;
		}

		public V Current
		{
			get
			{
				V result = current.value;
				current = current.previous;
				return result;
			}
		}
	}
}

static class Program
{
	public static void Main()
	{
		
		//Interval[] store = {new Interval(1, 23), new Interval(2, 34), new Interval(3, 45)};

		SimpleStack<Interval> store = new SimpleStack<Interval>();
		store.Push(new Interval(7, 31));
		store.Push(new Interval(4, 52));
		store.Push(new Interval(5, 23));
		store.Push(new Interval(6, 14));
		store.Push(new Interval(3, 45));
		
		foreach(Interval i in store)
			Console.WriteLine(i);


	}
}
