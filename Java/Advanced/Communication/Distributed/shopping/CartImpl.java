package shopping;

import java.rmi.*;

public class CartImpl extends javax.rmi.PortableRemoteObject implements Cart{

	private double payment = 0;

	public CartImpl() throws RemoteException{}

	public boolean addItem(String item){
		int id = Store.findItem(item);
		if(id >= 0){
			payment += 1.05 * Store.priceOf(id);
			return true;
		}
		return false;
	}

	public double checkout() throws RemoteException{
		unexportObject(this);
		return payment;
	}

}

