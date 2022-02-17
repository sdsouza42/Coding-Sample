using System;
using System.Windows;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ClientApp
{
    using ContractLib;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShoppingCartClient client;

        public MainWindow()
        {
            InitializeComponent();

            client = new ShoppingCartClient();
        }


        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string item = itemTextBox.Text;
                await client.AddItemAsync(item);
                cartListBox.Items.Add(item);
            }
            catch (FaultException<MissingItem> ex)
            {
                MessageBox.Show($"Cannot add {ex.Detail.Id}", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void checkoutButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double payment = await client.CheckoutAsync();
                MessageBox.Show($"Total payment is {payment:0.00}", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            client.Close();
        }
    }

    class ShoppingCartClient : ClientBase<IShoppingCart>
    {
        public ShoppingCartClient() : base(new NetHttpBinding(), new EndpointAddress("http://localhost:8055/shoppingcart"))
        {
        }

        public Task AddItemAsync(string name)
        {
            return Task.Run(() => Channel.AddItem(name));
        }

        public Task<double> CheckoutAsync()
        {
            return Task<double>.Run(() => Channel.Checkout());
        }
    }
}
