using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		if(args.Length > 2)
		{
			float price = Convert.ToSingle(args[0]);
			short stock = Convert.ToInt16(args[1]);
			string name = args[2].ToUpper();

			StreamWriter writer = new StreamWriter(File.Create("product.txt"));
			writer.WriteLine(price);
			writer.WriteLine(stock);
			writer.WriteLine(name);
			writer.Close();
		}
		else
		{
			StreamReader reader = new StreamReader(File.OpenRead("product.txt"));
			float price = Convert.ToSingle(reader.ReadLine());
			short stock = Convert.ToInt16(reader.ReadLine());
			string name = reader.ReadLine();		
			reader.Close();

			Console.WriteLine($"Price={price}, Stock={stock} and Name={name}");
		}
	}
}
