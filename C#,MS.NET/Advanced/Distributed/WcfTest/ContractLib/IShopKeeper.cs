using System.ServiceModel;

namespace ContractLib
{
    [ServiceContract]
    public interface IShopKeeper
    {
        [OperationContract]
        ItemInfo GetItemInfo(string name);

        [OperationContract]
        float GetBulkDiscount(int quantity);
    }
}
