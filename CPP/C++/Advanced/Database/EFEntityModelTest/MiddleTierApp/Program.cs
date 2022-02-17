using System;
using System.ServiceModel;

namespace MiddleTierApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderManagerService : ContractLib.IOrderManager
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public int PlaceOrder(string customerId, int productNo, int quantity)
        {
            using (ShopEntities db = new ShopEntities())
            {
                Counter ctr = db.Counters.Find("order");
                OrderDetail entry = new OrderDetail
                {
                    OrderNo = ++ctr.CurrentValue + 1000,
                    OrderDate = DateTime.Today,
                    CustomerId = customerId,
                    ProductNo = productNo,
                    Quantity = quantity
                };

                db.OrderDetails.Add(entry);
                db.SaveChanges();

                return entry.OrderNo;
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public decimal SellProduct(int productNo, int quantity)
        {
            using (ShopEntities db = new ShopEntities())
            {
                Product entry = db.Products.Find(productNo);
                entry.Stock -= quantity;

                db.SaveChanges();

                return quantity * entry.Price;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(OrderManagerService));

            host.Open();
            Console.ReadKey(true);
            host.Close();
        }
    }
}
