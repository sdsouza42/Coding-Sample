using System;
using System.Runtime.InteropServices;

static class Program
{
	[STAThread]
	public static void Main()
	{
		Console.Write("Weight  : ");
		double w = Convert.ToDouble(Console.ReadLine());
		Console.Write("Distance: ");
		int d = Convert.ToInt32(Console.ReadLine());

		Type t = Type.GetTypeFromProgID("METLogistics.AirCargo");
		dynamic rcw = Activator.CreateInstance(t);

		Console.WriteLine("Tariff: {0:0.00}", rcw.QuoteTariff(w, d));
		Console.WriteLine("Time  : {0:0.0}", rcw.EstimateTime(d));
	}
}
