using System;
using System.ServiceModel;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ShoppingCartService));

            host.AddServiceEndpoint(typeof(ContractLib.IShoppingCart), new NetHttpBinding(), "http://localhost:8055/shoppingcart");

            host.Open();
            Console.ReadKey(true);
            host.Close();
        }
    }
}
