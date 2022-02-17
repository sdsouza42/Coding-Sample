using System;

static class Test
{
	private static double GetIncome(double invest, int period=3, float rate=8)
	{
		double amount = invest * Math.Pow(1 + rate / 100, period);

		return amount - invest;
	}

	public static void Main(string[] args)
	{
		try
		{
			double p = Convert.ToDouble(args[0]);
			Console.WriteLine("Income in GOLD scheme: {0:0.00}", GetIncome(p, 4, 9));
			Console.WriteLine("Income in SILVER scheme: {0:0.00}", GetIncome(p));
			Console.WriteLine("Income in PLATINUM scheme: {0:0.00}", GetIncome(p, rate:10)); //passing argument by parameter name
		}
		catch(IndexOutOfRangeException)
		{
			Console.WriteLine("USAGE: optparamtest amount-to-invest");
		}
		catch(Exception ex)
		{
			Console.WriteLine("ERROR: {0}", ex.Message);
		}
	}
}
