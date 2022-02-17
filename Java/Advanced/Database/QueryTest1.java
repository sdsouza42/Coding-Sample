import java.sql.*;
import java.util.*;

class QueryTest1{

	public static void main(String[] args) throws Exception{
		Properties login = new Properties();
		login.put("user", "dbviewer");
		login.put("password", "dbviewer");
		Driver dvr = new oracle.jdbc.OracleDriver();
		Connection con = dvr.connect("jdbc:oracle:thin:@//192.168.4.31/orcl11g", login);
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery("select pno,price,stock from products");
		while(rs.next())
			System.out.printf("%s\t%.2f\t%d%n", rs.getInt(1), rs.getDouble(2), rs.getInt("stock"));
		rs.close();
		stmt.close();
		con.close();
	}
}


