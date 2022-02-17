using System;
using System.Reflection;

static class Program
{
	private static void PrintAsXml(object obj)
	{
		Type t = obj.GetType();

		Console.WriteLine("<{0}>", t.Name);
		foreach(PropertyInfo pi in t.GetProperties())
		{
			Console.WriteLine("  <{0}>{1}</{0}>", pi.Name, pi.GetValue(obj, null));
		}
		Console.WriteLine("</{0}>", t.Name);

		Console.WriteLine();
	}

	public static void Main()
	{
		PrintAsXml(new Interval(3, 45));

		PrintAsXml(new Payroll.Employee(185, 53));
	}
}
