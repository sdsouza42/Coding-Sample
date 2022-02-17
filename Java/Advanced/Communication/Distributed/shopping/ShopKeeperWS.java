package shopping;

import javax.jws.*;

@WebService(name="ShopKeeper", serviceName="ShopKeeperService", portName="ShopKeeperHttp")
public class ShopKeeperWS{

	@WebMethod(operationName="GetItemInfo")
	public ItemDetail getItemDetail(String name){
		int id = Store.findItem(name);
		if(id >= 0){
			ItemDetail detail = new ItemDetail();
			detail.price = 1.05 * Store.priceOf(id);
			detail.stock = Store.stockOf(id);
			return detail;
		}
		return null;
	}

	@WebMethod(operationName="GetBulkDiscount")
	public float getDiscountRate(int quantity){
		return quantity < 6 ? 0 : 5;
	}
}

