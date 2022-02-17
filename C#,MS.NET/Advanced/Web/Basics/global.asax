<script language="C#" runat="server">

	private void Application_Start(object sender, EventArgs e)
	{
		Application["Users"] = 0;
	}

	private void Session_Start(object sender, EventArgs e)
	{
		Application.Lock();	
		Application["Users"] = (int)Application["Users"] + 1;
		Application.UnLock();

		Session["Requests"] = 0;
	}

	private void Session_End(object sender, EventArgs e)
	{
		Application.Lock();	
		Application["Users"] = (int)Application["Users"] - 1;
		Application.UnLock();

	}

</script>