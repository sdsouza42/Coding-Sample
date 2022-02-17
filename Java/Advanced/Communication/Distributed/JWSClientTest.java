import shopping.client.*;
import java.util.*;

class JWSClientTest{
	
	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		ShopKeeperService service = new ShopKeeperService();
		ShopKeeper client = service.getShopKeeperHttp();
		System.out.print("Item: ");
		String i = input.next();
		ItemInfo info = client.getItemInfo(i);
		if(info != null){
			System.out.printf("Available stock: %d%n", info.getCurrentStock());
			double p = info.getUnitPrice();
			System.out.print("Quantity: ");
			int q = input.nextInt();
			float r = client.getBulkDiscount(q);
			System.out.printf("Total payment: %.2f%n", p * q * (1 - r / 100));
		}else{
			System.out.println("No such item!");
		}
	}
}

