using QuartzTypeLib;
using System;
using System.Runtime.InteropServices;

static class Program
{
	[STAThread]
	public static void Main(string[] args)
	{
		try
		{
			FilgraphManagerClass rcw = new FilgraphManagerClass();
			rcw.RenderFile(args[0]);
			rcw.Run();
			
			int evcode;
			rcw.WaitForCompletion(-1, out evcode);
		}
		catch(COMException ex)
		{
			Console.WriteLine("ERROR: {0}", ex.Message);
		}	
	}
}
