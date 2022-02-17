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

namespace ClientApp
{
    using ContractLib;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IShopKeeper client;

        public MainWindow()
        {
            InitializeComponent();

            ChannelFactory<IShopKeeper> service = new ChannelFactory<IShopKeeper>("ShopKeeperTcp");
            client = service.CreateChannel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            IClientChannel channel = (IClientChannel)client;
            channel.Close();
        }

        private void purchaseButton_Click(object sender, RoutedEventArgs e)
        {
            ItemInfo info = client.GetItemInfo(itemTextBox.Text);
            if (info == null)
                paymentTextBox.Text = "N/A - Item not found";
            else
            {
                int q = Convert.ToInt32(quantityTextBox.Text);
                if (q > info.CurrentStock)
                    paymentTextBox.Text = "N/A - Out of stock";
                else
                {
                    double p = info.UnitPrice;
                    float r = client.GetBulkDiscount(q);
                    double payment = p * q * (1 - r / 100);
                    paymentTextBox.Text = payment.ToString("0.00");
                }
            }
        }
    }
}
