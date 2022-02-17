using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThinClientApp
{
    public partial class ShopSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FooterLabel.Text = $"Hosted on {Environment.MachineName} Copyright {DateTime.Now.Year}";
        }
    }
}