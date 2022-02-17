import java.rmi.*;

class RMIServerTest1{

	public static void main(String[] args) throws Exception{
		Naming.rebind("priceManager", new shopping.PriceManagerImpl());
	}
}

