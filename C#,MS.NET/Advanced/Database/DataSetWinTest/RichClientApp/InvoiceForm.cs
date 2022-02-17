using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichClientApp
{
    public partial class InvoiceForm : Form
    {
        internal string CustomerId;

        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            this.Text = $"{CustomerId} - Invoice - RichClientApp";
            this.invoiceTableAdapter.Fill(shopDataSet.Invoice, CustomerId);

            decimal payment = shopDataSet.Invoice.Sum(column => column.Amount);
            paymentLabel.Text = $"Total Payment: {payment}";
        }
    }
}
