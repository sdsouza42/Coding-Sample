using System;

static class Test
{	
	//private static Nullable<double> GetSharePrice(string symbol)
	private static double? GetSharePrice(string symbol)
	{
		string[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		
		if(Array.IndexOf(symbols, symbol) >= 0)
		{
			double price = 0.01 * (1000 + Environment.TickCount % 9000);
			return price;
		}

		return null;
		

	}

	public static void Main(string[] args)
	{
		//Nullable<double> price = GetSharePrice(args[0]);
		double? price = GetSharePrice(args[0]);

		//if(price.HasValue)
		if(price != null)
			//Console.WriteLine("Share-price: {0:0.00}", price.Value);
			Console.WriteLine("Share-price: {0:0.00}", price);
		else
			Console.WriteLine("No such symbol!");

		//Console.WriteLine("Brokerage: {0:0.00}", 0.03 * price.GetValueOrDefault());
		Console.WriteLine("Brokerage: {0:0.00}", 0.03 * price ?? 0);
	}
}
