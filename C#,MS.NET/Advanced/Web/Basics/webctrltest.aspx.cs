using System;

namespace BasicWebApp
{
	partial class WebCtrlTestPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GreetOutput.Text = "Welcome Visitor " + Request.QueryString["name"];
			ClockLabel.Text = DateTime.Now.ToString();
		}

	}
}
