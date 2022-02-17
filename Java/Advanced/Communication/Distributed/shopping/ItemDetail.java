package shopping;

import javax.xml.bind.annotation.*;

@XmlType(name="ItemInfo")
public class ItemDetail{

	double price;
	int stock;

	@XmlElement(name="UnitPrice")
	public double getPrice(){
		return price;
	}

	public void setPrice(double value){
		price = value;
	}

	@XmlElement(name="CurrentStock")
	public int getStock(){
		return stock;
	}

	public void setStock(int value){
		stock = value;
	}
}

