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

			BinaryWriter writer = new BinaryWriter(File.Create("product.dat"));
			writer.Write(price);
			writer.Write(stock);
			writer.Write(name);
			writer.Close();
		}
		else
		{
			BinaryReader reader = new BinaryReader(File.OpenRead("product.dat"));
			float price = reader.ReadSingle();
			short stock = reader.ReadInt16();
			string name = reader.ReadString();		
			reader.Close();

			Console.WriteLine($"Price={price}, Stock={stock} and Name={name}");
		}
	}
}
