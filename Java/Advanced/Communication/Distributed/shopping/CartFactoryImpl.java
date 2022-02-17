package shopping;

import java.rmi.*;

public class CartFactoryImpl extends javax.rmi.PortableRemoteObject implements CartFactory{

	public CartFactoryImpl() throws RemoteException{}

	public Cart create() throws RemoteException{
		return new CartImpl();
	}
}

