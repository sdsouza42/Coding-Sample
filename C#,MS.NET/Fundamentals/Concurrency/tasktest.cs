using System;
using System.Threading.Tasks;

static class Program
{
	private static string HandleJob(object id)
	{
		Console.WriteLine("Task<{0}> has accepted job:{1}", Task.CurrentId ?? 0, id);
		Worker.DoWork((int)id);
		Console.WriteLine("Task<{0}> has finished job:{1}", Task.CurrentId ?? 0, id);
		
		return DateTime.Now.ToString();
	}

	public static void Main(string[] args)
	{
		int n = args.Length > 0 ? Convert.ToInt32(args[0]) : 50;
		
		//Task - unit of work assigned to a worker-thread in CLR's thread-pool
		Task<string> child = new Task<string>(HandleJob, n);
		child.Start();

		HandleJob(40);

		if(n <= 70)
			Console.WriteLine(child.Result); //child.Wait();
		
	}
}
