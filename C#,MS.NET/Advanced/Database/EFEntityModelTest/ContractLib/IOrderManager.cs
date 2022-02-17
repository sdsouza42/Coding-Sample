using System.ServiceModel;

namespace ContractLib
{
    [ServiceContract]
    public interface IOrderManager
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int PlaceOrder(string customerId, int productNo, int quantity);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        decimal SellProduct(int productNo, int quantity);
    }
}
