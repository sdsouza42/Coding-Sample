using System;

class SomeResource : IDisposable
{
	private string id;

	static SomeResource()
	{
		#if TESTING
		Console.WriteLine("SomeResource type initialized.");
		#endif
	}

	public SomeResource(string name)
	{
		id = name;

		#if TESTING
		Console.WriteLine("{0} resource acquired.", id);
		#endif
	}

	public string Id
	{
		get {return id;}
	}

	public void Consume()
	{
		if(id != null)
			Console.WriteLine("{0} resource consumed.", id);
	}

	public void Dispose()
	{

		#if TESTING
		Console.WriteLine("{0} resource disposed.", id);
		#endif

		id = null;		
		GC.SuppressFinalize(this);
	}

	~SomeResource()
	{
		#if TESTING
		Console.WriteLine("{0} resource finalized.", id);
		#endif

		id = null;
	}
}


static class Test
{
	private static void Run()
	{
		SomeResource b = new SomeResource("Second");
		b.Consume();
	}

	public static void Main()
	{
		SomeResource a = new SomeResource("First");
		a.Consume();

		Run();

		Console.WriteLine("Before garbage-collection {0} resource is in generation:{1}", a.Id, GC.GetGeneration(a));
		GC.Collect(); //forcing garbage-collection
		GC.WaitForPendingFinalizers();
		Console.WriteLine("After garbage-collection {0} resource is in generation:{1}", a.Id, GC.GetGeneration(a));

		SomeResource c = new SomeResource("Third");
		c.Consume();
		c.Dispose();

		using(SomeResource d = new SomeResource("Fourth"))
		{
			d.Consume();
		}
	}
}
