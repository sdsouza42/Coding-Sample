using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using System.Transactions;

namespace PresentationTierApp
{
    using ContractLib;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            string customerId = customerTextBox.Text.ToUpper();
            int productNo = Convert.ToInt32(productTextBox.Text);
            int quantity = Convert.ToInt32(quantityTextBox.Text);

            ChannelFactory<IOrderManager> service = new ChannelFactory<IOrderManager>("OrderManagerTcp");
            IOrderManager client = service.CreateChannel();

            try
            {
                int orderNo;
                decimal payment;

                using (TransactionScope tx = new TransactionScope())
                {
                    orderNo = client.PlaceOrder(customerId, productNo, quantity);
                    payment = client.SellProduct(productNo, quantity);
                    tx.Complete();
                }

                service.Close();

                MessageBox.Show($"New order number is {orderNo} and payment is {payment:0.00}.", "Order Placed", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                service.Abort();

                MessageBox.Show("Order cannot be placed with the specified input.", "Order Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
    }
}
