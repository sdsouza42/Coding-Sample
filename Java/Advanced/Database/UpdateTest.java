import java.sql.*;

class UpdateTest{

	public static void main(String[] args) throws Exception{
		String sql = "update products set stock=stock+5";
		if(args.length > 0)
			sql += " where pno=" + Integer.parseInt(args[0]);
		Class.forName("oracle.jdbc.OracleDriver");
		Connection con = DriverManager.getConnection("jdbc:oracle:thin:@//localhost/xe", "scott", "tiger");
		Statement stmt = con.createStatement();
		int n = stmt.executeUpdate(sql);
		System.out.printf("Number of updated products: %d%n", n);
		stmt.close();
		con.close();
	}
}

