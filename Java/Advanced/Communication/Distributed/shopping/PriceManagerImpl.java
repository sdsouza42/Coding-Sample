package shopping;

import java.rmi.*;

public class PriceManagerImpl extends java.rmi.server.UnicastRemoteObject implements PriceManager{

	public PriceManagerImpl() throws RemoteException{
		super(); //exports this object
	}

	public double getUnitPrice(String item){
		int id = Store.findItem(item);
		if(id < 0)
			throw new IllegalArgumentException("No such item");
		return 1.05 * Store.priceOf(id);
	}

	public float getBulkDiscount(int quantity){
		return quantity < 6 ? 0 : 5;
	}
}

