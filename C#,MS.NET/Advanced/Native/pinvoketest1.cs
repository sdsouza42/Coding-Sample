using System;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport("legacy\\x86\\asset.dll", EntryPoint="SYD", CallingConvention=CallingConvention.Cdecl)]
	private extern static double GetPriceAfter(double cost, short life, short after);

	public static void Main()
	{
		Console.Write("Original Cost: ");
		double cost = Convert.ToDouble(Console.ReadLine());
		Console.Write("Userful Life : ");
		short life = Convert.ToInt16(Console.ReadLine());

		for(short after = 1; after <= life; ++after)
			Console.WriteLine("{0}\t{1:0.00}", after, GetPriceAfter(cost, life, after));
	}
}
