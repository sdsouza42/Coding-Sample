using System;

namespace ServerApp
{
	static class Store
	{
		private static Random rdm = new Random();

		internal static int Find(string item)
		{
			string[] items = {"apple", "mango", "orange", "peach", "pear"};

			return Array.IndexOf(items, item.ToLower());
		}

		internal static double PriceOf(int id)
		{
			double[] prices = {21.75, 24.50, 9.25, 5.75, 6.50};

			return prices[id];
		}

		internal static int StockOf(int id)
		{
			return rdm.Next(100, 501);
		}
	}
}
