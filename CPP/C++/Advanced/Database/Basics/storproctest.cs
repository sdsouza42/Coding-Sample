using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{
		string customerId = args[0].ToUpper();
		int productNo = Convert.ToInt32(args[1]);
		int quantity = Convert.ToInt32(args[2]);		

		SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Shop;Integrated Security=true");
		con.Open();

		SqlCommand cmd = new SqlCommand("PlaceOrder", con);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@Customer", customerId);
		cmd.Parameters.AddWithValue("@Product", productNo);
		cmd.Parameters.AddWithValue("@Quantity", quantity);
		SqlParameter paramOrderNo = cmd.Parameters.Add("@OrderNo", SqlDbType.Int);
		paramOrderNo.Direction = ParameterDirection.Output;
		try
		{
			cmd.ExecuteNonQuery();
			Console.WriteLine("New Order Number: {0}", paramOrderNo.Value);
		}
		catch(SqlException ex)
		{
			Console.WriteLine("Order Failed: {0}", ex.Message); 
		}

		con.Close();
	}
}
