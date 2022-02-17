using System;
using System.Threading;

static class Program
{
	private static void HandleJob(int id)
	{
		Console.WriteLine("Thread<{0}> has accepted job:{1}", Thread.CurrentThread.ManagedThreadId, id);
		Worker.DoWork(id);
		Console.WriteLine("Thread<{0}> has finished job:{1}", Thread.CurrentThread.ManagedThreadId, id);
	}

	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? Convert.ToInt32(args[0]) : 50;

		Thread child = new Thread(delegate()
		{
			HandleJob(n);
		});
		child.IsBackground = n > 70;
		child.Start();

		HandleJob(40);
	}
}
