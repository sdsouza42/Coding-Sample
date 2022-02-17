using System;
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

		SqlCommand cmd = con.CreateCommand();
		cmd.Transaction = con.BeginTransaction();
		try
		{
			cmd.CommandText = "UPDATE Counters SET CurrentValue=CurrentValue+1 WHERE Id='order'";
			cmd.ExecuteNonQuery();
			cmd.CommandText = "SELECT CurrentValue+1000 FROM Counters WHERE Id='order'";
			int orderNo = (int)cmd.ExecuteScalar();
			cmd.CommandText = "INSERT INTO OrderDetail VALUES(@OrdNo, @OrdDt, @CustId, @PNo, @Qty)";
			cmd.Parameters.AddWithValue("@OrdNo", orderNo);
			cmd.Parameters.AddWithValue("@OrdDt", DateTime.Today);
			cmd.Parameters.AddWithValue("@CustId", customerId);
			cmd.Parameters.AddWithValue("@PNo", productNo);
			cmd.Parameters.AddWithValue("@Qty", quantity);
			cmd.ExecuteNonQuery();
			cmd.Transaction.Commit();
			Console.WriteLine("New Order Number: {0}", orderNo);
		}
		catch(SqlException ex)
		{
			cmd.Transaction.Rollback();
			Console.WriteLine("Order Failed: {0}", ex.Message); 
		}

		con.Close();
	}
}
