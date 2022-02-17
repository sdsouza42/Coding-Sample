using System;

static class Program
{
	public static void Main()
	{
		Console.Write("Length : ");
		int l = Convert.ToInt32(Console.ReadLine());
		Console.Write("Breadth: ");
		int b = Convert.ToInt32(Console.ReadLine());
		Console.Write("Height : ");
		int h = Convert.ToInt32(Console.ReadLine());

		var box = new Legacy.Box(l, b, h);

		Console.WriteLine("Inner volume: {0}", box.GetInnerVolume(1));
	}
}
