using System;

interface IPlugin
{
	void Execute(string command);
}

//[Serializable]
class SimplePlugin : MarshalByRefObject, IPlugin
{
	private static int count;
	private int id;

	static SimplePlugin()
	{
		Console.WriteLine("SimplePlugin type initialized in AppDomain<{0}>", AppDomain.CurrentDomain.Id);
	}

	public SimplePlugin()
	{
		id = ++count;
		Console.WriteLine("SimplePlugin instance<{1}> initialized in AppDomain<{0}>", AppDomain.CurrentDomain.Id, id);

	}

	public void Execute(string command)
	{
		Console.WriteLine("SimplePlugin instance<{1}> executed {2} in AppDomain<{0}>", AppDomain.CurrentDomain.Id, id, command);
	}

	~SimplePlugin()
	{
		Console.WriteLine("SimplePlugin instance<{1}> finalized in AppDomain<{0}>", AppDomain.CurrentDomain.Id, id);
	}
}


static class Program
{
	public static void Main()
	{
		//IPlugin sp = new SimplePlugin();

		AppDomain dom = AppDomain.CreateDomain("second");
		IPlugin sp = (IPlugin)dom.CreateInstanceAndUnwrap("remotingtest", "SimplePlugin");
		sp.Execute("print");
		AppDomain.Unload(dom);
		
		Console.WriteLine("Press any key to exit...");
		Console.ReadKey(true);
	}
}
