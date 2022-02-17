using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ThinClientApp.Protected
{
    public partial class Invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerIdLabel.Text = User.Identity.Name;
        }

        protected void LogoutLinkButton_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Server.Transfer("~/Default.aspx");
        }

        protected void InvoiceDataSource_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            var invoiceDataTable = e.ReturnValue as Models.ShopDataSet.InvoiceDataTable;
            decimal payment = invoiceDataTable.Sum(column => column.Amount);
            PaymentLabel.Text = $"Total Payment: {payment}";
        }
    }
}