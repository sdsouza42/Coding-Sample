using System.ServiceModel;

namespace ServerApp
{
    using ContractLib;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ShopKeeperService : IShopKeeper
    {
        public float GetBulkDiscount(int quantity)
        {
            return quantity < 6 ? 0 : 5;
        }

        public ItemInfo GetItemInfo(string name)
        {
            int item = Store.Find(name);

            if(item >= 0)
            {
                ItemInfo info = new ItemInfo();
                info.UnitPrice = Store.PriceOf(item);
                info.CurrentStock = Store.StockOf(item);
                return info;
            }

            return null;
        }
    }
}
