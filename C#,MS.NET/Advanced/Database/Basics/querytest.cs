using System;
using System.Data.Common;
using System.Configuration;

static class Program
{
	public static void Main()
	{
		ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ShopDB"];
		DbProviderFactory provider = DbProviderFactories.GetFactory(settings.ProviderName);
		DbConnection con = provider.CreateConnection();
		con.ConnectionString = settings.ConnectionString;
		con.Open();

		DbCommand cmd = con.CreateCommand();
		cmd.CommandText = "SELECT ProductNo, Price, Stock FROM Product";
		
		DbDataReader rdr = cmd.ExecuteReader();
		while(rdr.Read())
			Console.WriteLine("{0}\t{1}\t{2}", rdr.GetInt32(0), rdr[1], rdr["Stock"]);
		rdr.Close();

		con.Close();
	}
}
