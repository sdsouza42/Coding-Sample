import shopping.*;
import java.rmi.*;
import java.util.*;

class RMIClientTest1{

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		PriceManager pm = (PriceManager)Naming.lookup("rmi://localhost/priceManager");
		try{
			System.out.print("Item    : ");
			String i = input.next();
			double p = pm.getUnitPrice(i);
			System.out.print("Quantity: ");
			int q = input.nextInt();
			float r = pm.getBulkDiscount(q);
			System.out.printf("Total payment: %.2f%n", p * q * (1 - r / 100));
		}catch(Exception e){
			System.out.printf("ERROR: %s%n", e.getMessage());
		}
	}
}

