using System.ServiceModel;

namespace ServerApp
{
    using ContractLib;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ShoppingCartService : IShoppingCart
    {
        private double payment = 0;

        public void AddItem(string name)
        {
            int item = Store.Find(name);

            if(item < 0)
            {
                MissingItem mi = new MissingItem { Id = name, IsOutOfStock = false };
                throw new FaultException<MissingItem>(mi);
            }

            payment += Store.PriceOf(item);                
        }

        public double Checkout()
        {
            return payment;
        }
    }
}
