using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThinClientApp.Protected
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerIdLabel.Text = User.Identity.Name;
        }

        protected void OrderButton_Click(object sender, EventArgs e)
        {
            string customerId = CustomerIdLabel.Text;
            int productNo = Convert.ToInt32(ProductNoDropDownList.Text);
            int quantity = Convert.ToInt32(QuantityTextBox.Text);
            int? orderNo = 0;

            using (var shop = new Models.ShopDataSetTableAdapters.QueriesTableAdapter())
                shop.PlaceOrder(customerId, productNo, quantity, ref orderNo);

            string script = $"alert('New order number is {orderNo}.');";
            ClientScript.RegisterStartupScript(this.GetType(), "ShowOrder", script, true);
        }
    }
}