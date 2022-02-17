using System;
using System.Threading;

static class Program
{
	class GreetArg
	{
		public string Message;

		public int Count;
	}

	private static void GreetStart(object arg)
	{
		GreetArg ga = (GreetArg)arg;

		for(int i = 1; i <= ga.Count; ++i)
		{
			Console.WriteLine("{0}:{1} from thread<{2}>", ga.Message, i, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(i);
		}

		try
		{
			Thread.Sleep(10000);
		}
		catch(ThreadInterruptedException)
		{
			Console.WriteLine("Sleep interrupted!");
		}

		Console.WriteLine("Goodbye.");
	}

	public static void Main()
	{
		Thread child = new Thread(GreetStart);
		child.Start(new GreetArg{Message="Hello", Count=10});

		for(int i = 15; i > 0; i--)
		{
			Console.WriteLine("Welcome:{0} from thread<{1}>", i, Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(i);
		}

		child.Interrupt();
	}
}
