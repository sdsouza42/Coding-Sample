import shopping.*;
import java.rmi.*;
import java.util.*;
import javax.rmi.*;
import javax.naming.*;

class RMIClientTest2{
	
	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		Context naming = new InitialContext();
		Object ref = naming.lookup("cartFactory");
		CartFactory factory = (CartFactory)PortableRemoteObject.narrow(ref, CartFactory.class);
		Cart cart = factory.create();
		for(int n = 1; ;++n){
			System.out.printf("Item %d: ", n);
			String i = input.nextLine();
			if(i.length() == 0) break;
			System.out.printf("Adding %s to cart...", i);
			if(cart.addItem(i))
				System.out.println("succeeded.");
			else
				System.out.println("failed!");
		}
		System.out.printf("Total payment: %.2f%n", cart.checkout());
		//cart.addItem("mango");
	}
}


