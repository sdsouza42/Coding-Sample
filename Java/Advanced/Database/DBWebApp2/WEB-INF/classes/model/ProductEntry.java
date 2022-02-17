package model;

import java.sql.*;

public class ProductEntry{

	private int productNo;
	private double price;
	private int stock;

	ProductEntry(ResultSet rs) throws SQLException{
		productNo = rs.getInt("pno");
		price = rs.getDouble("price");
		stock = rs.getInt("stock");
	}

	public final int getProductNo(){
		return productNo;
	}

	public final double getPrice(){
		return price;
	}

	public final int getStock(){
		return stock;
	}
}

