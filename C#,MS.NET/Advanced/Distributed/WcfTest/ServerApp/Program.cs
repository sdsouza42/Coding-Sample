using System;
using System.ServiceModel;

namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ShopKeeperService));

            host.Open();
            Console.ReadKey(true);
            host.Close();
        }
    }
}
