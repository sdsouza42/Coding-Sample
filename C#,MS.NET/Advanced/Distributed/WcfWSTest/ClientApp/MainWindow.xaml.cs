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

namespace ClientApp
{
    using JwsSurvey;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FeedbackClient client;

        public MainWindow()
        {
            InitializeComponent();

            client = new FeedbackClient();
        }

        private void readButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FeedbackInfo info = client.ReadFeedback(nameTextBox.Text);
                commentTextBox.Text = info.Comment;
            }
            catch(Exception ex)
            {
                commentTextBox.Text = ex.Message;
            }
        }

        private void writeButton_Click(object sender, RoutedEventArgs e)
        {
            FeedbackInfo info = new FeedbackInfo { From = nameTextBox.Text, Comment = commentTextBox.Text };
            commentTextBox.Text = client.WriteFeedback(info);
        }
    }
}
