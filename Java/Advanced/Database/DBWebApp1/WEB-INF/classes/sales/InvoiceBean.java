package sales;

import java.util.*;
import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class InvoiceBean implements java.io.Serializable{

	private String customerId;

	public final String getCustomerId(){
		return customerId;
	}

	public final void setCustomerId(String value){
		customerId = value;
	}

	public List<InvoiceEntry> getEntries(){
		List<InvoiceEntry> entries = new ArrayList<>();
		try{
			Context naming = new InitialContext();
			DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
			try(Connection con = ds.getConnection()){
				PreparedStatement pstmt = con.prepareStatement("select ord_date, pno, qty, amt from invoices where cust_id=?");
				pstmt.setString(1, customerId);
				ResultSet rs = pstmt.executeQuery();
				while(rs.next())
					entries.add(new InvoiceEntry(rs));
				rs.close();
				pstmt.close();
				return entries;
			}
		}catch(Exception e){
			throw new RuntimeException(e);
		}
	}
}

