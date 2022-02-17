import java.io.*;
import java.sql.*;
import java.util.*;

class QueryTest2{

	public static void main(String[] args) throws Exception{
		FileInputStream fin = new FileInputStream("db.properties");
		Properties settings = new Properties();
		settings.load(fin);
		fin.close();
		String dvr = settings.getProperty(args[0] + ".driver");
		String url = settings.getProperty(args[0] + ".url");
		String usr = settings.getProperty(args[0] + ".user");
		String pwd = settings.getProperty(args[0] + ".password");
		Class.forName(dvr);
		Connection con = DriverManager.getConnection(url, usr, pwd);
		Statement stmt = con.createStatement();
		ResultSet rs = stmt.executeQuery("select pno,price,stock from products");
		while(rs.next())
			System.out.printf("%s\t%.2f\t%d%n", rs.getInt(1), rs.getDouble(2), rs.getInt("stock"));
		rs.close();
		stmt.close();
		con.close();
	}
}


