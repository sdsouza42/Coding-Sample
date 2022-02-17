package model;

import java.sql.*;

public class ProductEntry{
	
	
	private int productNo;
	private String productNa;
	private double price;
	private int stock;

	ProductEntry(ResultSet rs) throws SQLException{
		productNo = rs.getInt("pno");
		productNa = rs.getString("pname");
		price = rs.getDouble("price");
		stock = rs.getInt("stock");
	}

	public final int getProductNo(){
		return productNo;
	}

	public final String getProductNa(){
		return productNa;
	}

	public final double getPrice(){
		return price;
	}

	public final int getStock(){
		return stock;
	}
}


