using System;
using System.Collections;
using System.Collections.Generic;

class SimpleStack<V> : IEnumerable<V>
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

	public IEnumerator<V> GetEnumerator()
	{
		for(Node n = top; n != null; n = n.previous)
			yield return n.value;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

}

static class Iteration
{
	public static void Consume<T>(this IEnumerable<T> source, Action<T> process)
	{
		foreach(T entry in source)
			process(entry);
	}

	public static IEnumerable<T> Choose<T>(this IEnumerable<T> source, Func<T, bool> check)
	{
		foreach(T entry in source)
		{
			if(check(entry))
				yield return entry;
		}
	}
}

static class Program
{
	public static void Main()
	{
		int[] numbers = {1, 2, 3, 4, 5, 6};
		numbers.Choose(n => (n % 2) == 1).Consume(Console.WriteLine);
		Console.WriteLine();

		SimpleStack<Interval> store = new SimpleStack<Interval>();
		store.Push(new Interval(7, 31));
		store.Push(new Interval(4, 52));
		store.Push(new Interval(5, 23));
		store.Push(new Interval(6, 14));
		store.Push(new Interval(3, 45));		
		store.Choose(i => i.Time > 300).Consume(Console.WriteLine);

	}
}
