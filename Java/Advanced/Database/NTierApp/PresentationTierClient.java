import sales.client.*;
import java.util.*;

class PresentationTierClient{

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		System.out.print("CUSTOMER ID: ");
		String customerId = input.next();
		System.out.print("PRODUCT NO : ");
		int productNo = input.nextInt();
		System.out.print("QUANTITY   : ");
		int quantity = input.nextInt();
		OrderManagerService service = new OrderManagerService();
		OrderManager client = service.getOrderManagerPort();
		try{
			int orderNo = client.placeOrder(customerId, productNo, quantity);
			System.out.printf("NEW ORDER NUMBER: %d%n", orderNo);
		}catch(Exception e){
			System.out.printf("ORDER FAILED: %s%n", e.getMessage()); 
		}
	}
}

