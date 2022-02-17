using System;
using System.Threading;

static class Program
{
	private static IAsyncResult DoComputation()
	{
		Console.Write("Computing...");

		Computation c = new Computation();
		Func<int, int, long> cf = c.Compute;

		return cf.BeginInvoke(1, 20, delegate(IAsyncResult ticket)
		{
			long result = cf.EndInvoke(ticket);
		
			Console.WriteLine(ticket.AsyncState);
			Console.WriteLine("Result = {0}", result);
		}, "Done!");

	}

	public static void Main()
	{
		var job = DoComputation();

		while(!job.IsCompleted)
		{
			Thread.Sleep(300);
			Console.Write(".");
		}
	}
}