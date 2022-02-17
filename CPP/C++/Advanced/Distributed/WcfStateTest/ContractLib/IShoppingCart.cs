using System.ServiceModel;

namespace ContractLib
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IShoppingCart
    {
        [OperationContract]
        [FaultContract(typeof(MissingItem))]
        void AddItem(string name);

        [OperationContract(IsTerminating = true)]
        double Checkout();
    }
}
