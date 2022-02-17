using System;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;

[Table(Name = "Product")]
class ProductInfo
{
	[Column(Name = "ProductNo", IsPrimaryKey = true)]
	public int Id {get; set;}

	[Column(Name = "Price")]
	public decimal Cost {get; set;}

	[Column]
	public int Stock {get; set;}
}


static class Program
{
	public static void Main(string[] args)
	{
		int m = Convert.ToInt32(args[0]);

		using(DataContext db = new DataContext("Data Source=.;Initial Catalog=Shop;Integrated Security=true"))
		{
			var selection = from p in db.GetTable<ProductInfo>()
					where p.Stock > m
					select p;

			foreach(var entry in selection)
				entry.Cost *= 0.95M;

			db.SubmitChanges();

			Console.WriteLine("Number of updated products: {0}", selection.Count());
		}	
		
	}
}
