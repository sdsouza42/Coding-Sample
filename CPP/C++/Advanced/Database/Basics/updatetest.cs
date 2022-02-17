using System;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{
		string sql = "UPDATE Product SET Stock=Stock+5";
		if(args.Length > 0)
			sql += " WHERE ProductNo=" + Convert.ToInt32(args[0]);

		SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Shop;Integrated Security=true");
		con.Open();

		SqlCommand cmd = new SqlCommand(sql, con);
		int n = cmd.ExecuteNonQuery();
		Console.WriteLine("Number of updated products: {0}", n);

		con.Close();
	}
}
