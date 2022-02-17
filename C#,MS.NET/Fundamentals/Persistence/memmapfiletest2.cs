using System;
using System.IO;
using System.IO.MemoryMappedFiles;

static class Program
{
	private static void RunWriter(string text)
	{
		using(var mapping = MemoryMappedFile.CreateNew("testshm", 4096))
		{
			using(var view = mapping.CreateViewStream())
			{
				StreamWriter writer = new StreamWriter(view);
				writer.WriteLine(text);
				writer.Close();
			}

			Console.WriteLine("Text shared, press any key to exit...");
			Console.ReadKey(true);
		}
	}

	private static void RunReader()
	{
		using(var mapping = MemoryMappedFile.OpenExisting("testshm"))
		{
			using(var view = mapping.CreateViewStream())
			{
				StreamReader reader = new StreamReader(view);
				Console.WriteLine("Shared text: {0}", reader.ReadLine());
				reader.Close();
			}
		}
	}

	public static void Main(string[] args)
	{
		if(args.Length > 0)
			RunWriter(args[0]);
		else
			RunReader();
	}
}
