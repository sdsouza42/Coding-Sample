package model;

import java.util.*;
import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class ProductBean implements java.io.Serializable{

	public List<ProductEntry> getEntries(){
		List<ProductEntry> entries = new ArrayList<>();
		try{
			Context naming = new InitialContext();
			DataSource ds = (DataSource)naming.lookup("jdbc/Icecreamora");
			try(Connection con = ds.getConnection()){
				Statement stmt = con.createStatement();
				ResultSet rs = stmt.executeQuery("select pno,pname,price,stock from jproducts");
				while(rs.next())
					entries.add(new ProductEntry(rs));
			}
			return entries;
		}catch(Exception e){
			throw new RuntimeException(e);
		}	
	}
}


