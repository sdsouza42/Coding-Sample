using System;
using System.Reflection;

static class Test
{
	public static void Main()
	{
		for(;;)
		{
			Console.Write("COMMAND: ");
			string cmd = Console.ReadLine();
			if(cmd.ToLower() == "quit") break;

			try
			{
				Assembly asm = Assembly.LoadFrom("commands\\" + cmd + ".exe");
				asm.EntryPoint.Invoke(null, null);
			}
			catch(Exception ex)
			{
				Console.WriteLine("ERROR: {0}", ex.Message);
			}

			Console.WriteLine();
		}
	}
}
