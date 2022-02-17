package edu.met.sales;

import javax.ejb.*;
import javax.persistence.*;

@LocalBean
@Stateless
public class ProductMakerEJB{

	@PersistenceContext
	private EntityManager em;

	public int addNewProduct(double price, int stock){
		CounterEntity ctr = em.find(CounterEntity.class, "products");
		int productNo = ctr.getNextValue() + 100;
		ProductEntity product = new ProductEntity();
		product.setProductNo(productNo);
		product.setPrice(price);
		product.setStock(stock);
		em.persist(product);
		return productNo;
	}

}

