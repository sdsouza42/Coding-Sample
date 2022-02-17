package edu.met.sales;

import java.sql.*;
import javax.persistence.*;

@Entity
@Table(name="orders")
public class OrderEntity implements java.io.Serializable{

	@Id
	@Column(name="ord_no")
	private int orderNo;

	@Column(name="ord_date")
	private Date orderDate;

	@Column(name="cust_id")
	private String customerId;

	@Column(name="pno")
	private int productNo;

	@Column(name="qty")
	private int quantity;

	public int getOrderNo(){
		return orderNo;
	}

	public Date getOrderDate(){
		return orderDate;
	}

	public String getCustomerId(){
		return customerId;
	}

	public int getProductNo(){
		return productNo;
	}

	public int getQuantity(){
		return quantity;
	}

}


