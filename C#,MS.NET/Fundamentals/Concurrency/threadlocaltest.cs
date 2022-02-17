using System;
using System.Threading;

static class PrintItem
{
	[ThreadStatic]
	private static string text;

	public static void Write(string value)
	{
		text = value;
	}

	public static string Read()
	{
		return text;
	}
}

static class Printer
{
	public static void Print(int copies)
	{
		for(int i = 1; i <= copies; ++i)
		{
			Console.WriteLine("{0}:{1} from thread<{2}>", i, PrintItem.Read(), Thread.CurrentThread.ManagedThreadId);
			Worker.DoWork(i);
		}
	}
}

static class Program
{
	public static void Main()
	{
		Thread child = new Thread(() =>
		{
			PrintItem.Write("Monday");
			Printer.Print(5);
		});
		child.Start();

		PrintItem.Write("Tuesday");
		Printer.Print(5);
	}
}