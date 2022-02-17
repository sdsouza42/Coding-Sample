package shopping;

import java.rmi.*;

public interface Cart extends Remote{
	
	boolean addItem(String item) throws RemoteException;

	double checkout() throws RemoteException;
}

