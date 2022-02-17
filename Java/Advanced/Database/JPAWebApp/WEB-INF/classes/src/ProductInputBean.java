package edu.met.sales;

import javax.ejb.*;
import javax.faces.bean.*;
import javax.validation.constraints.*;

@ManagedBean(name="productInput")
@ViewScoped
public class ProductInputBean{

	@NotNull
	private double price;

	@NotNull
	@Min(5)
	private int stock;

	public double getPrice(){
		return price;
	}

	public void setPrice(double value){
		price = value;
	}

	public int getStock(){
		return stock;
	}

	public void setStock(int value){
		stock = value;
	}

	@EJB
	private ProductMakerEJB productMaker;

	public String createProduct(){
		productMaker.addNewProduct(price, stock);
		return "index";
	}

}
