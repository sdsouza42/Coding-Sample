using System;

delegate object Convert(string text);

static class Algorithm
{
	public static void PrintConverted(string[] values, Convert change)
	{
		foreach(string value in values)
		{
			Console.WriteLine(change(value));
		}
	}


}

static class Program
{
	private static string Enquote(object obj)
	{
		return "'" + obj.ToString() + "'";
	}

	public static void Main(string[] args)
	{
		Algorithm.PrintConverted(args, Enquote);
	}
}
