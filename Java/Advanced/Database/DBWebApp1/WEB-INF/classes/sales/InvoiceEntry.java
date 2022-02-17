package sales;

import java.sql.*;

public class InvoiceEntry{

	private Date orderDate;
	private int productNo;
	private int quantity;
	private double amount;

	InvoiceEntry(ResultSet rs) throws SQLException{
		orderDate = rs.getDate("ord_date");
		productNo = rs.getInt("pno");
		quantity = rs.getInt("qty");
		amount = rs.getDouble("amt");
	}

	public final Date getOrderDate(){
		return orderDate;
	}

	public final int getProductNo(){
		return productNo;
	}

	public final int getQuantity(){
		return quantity;
	}

	public final double getAmount(){
		return amount;
	}


}


