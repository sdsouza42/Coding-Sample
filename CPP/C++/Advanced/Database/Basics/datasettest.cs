using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{
		DataSet ds = new DataSet("Products");

		if(args.Length == 0)
		{
			SqlDataAdapter da = new SqlDataAdapter("SELECT ProductNo, Price, Stock FROM Product", 
				new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=true"));
			da.Fill(ds, "Product");
			ds.WriteXml("shop.xml");
		}
		else
			ds.ReadXml(args[0]);

		foreach(DataRow row in ds.Tables["Product"].Rows)
		{
			Console.WriteLine("{0}\t{1}\t{2}", row[0], row[1], row["Stock"]);
			Console.ReadKey(true);
		}

	}
}
