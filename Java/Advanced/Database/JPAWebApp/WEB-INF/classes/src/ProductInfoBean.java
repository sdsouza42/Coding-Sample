package edu.met.sales;

import java.util.*;
import javax.faces.bean.*;
import javax.persistence.*;

@ManagedBean(name="productInfo")
@RequestScoped
public class ProductInfoBean{

	@PersistenceUnit
	private EntityManagerFactory emf;

	public List<ProductEntity> getProducts(){
		EntityManager em = emf.createEntityManager();
		try{
			TypedQuery<ProductEntity> query = em.createQuery("SELECT e FROM ProductEntity e WHERE e.stock>?1 ORDER BY e.productNo", ProductEntity.class);
			query.setParameter(1, 0);
			return query.getResultList();
		}finally{
			em.close();
		}
	}

	private ProductEntity selectedProduct;

	public ProductEntity getSelectedProduct(){
		return selectedProduct;
	}

	public String selectProduct(ProductEntity product){
		selectedProduct = product;
		return "details";
	}
}

