using System;
using System.Threading;
using System.Threading.Tasks;

partial class Computation
{
	public Task<long> ComputeAsync(int low, int high)
	{
		return Task<long>.Run(() => Compute(low, high));
	}

}

static class Program
{
	//This method will return control to the caller using await
	private async static Task DoComputation()
	{
		Console.Write("Computing...");

		Computation c = new Computation();

		//control is returned to the caller while the awaited task executes
		long result = await c.ComputeAsync(1, 20);
		//following code will execute after awaited task is completed

		Console.WriteLine("Done!");
		Console.WriteLine("Result = {0}", result);

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