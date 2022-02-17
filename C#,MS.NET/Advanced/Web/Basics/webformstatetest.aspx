<script language="C#" runat="server">

	private void Page_Load(object sender, EventArgs e)
	{
		UserCountLabel.Text = "Number of Users: " + Application["Users"];

		Session["Requests"] = (int)Session["Requests"] + 1;
		RequestCountLabel.Text = "Number of Requests: " + Session["Requests"];

		ViewState["Submits"] = (int)(ViewState["Submits"] ?? -1) + 1;
		SubmitCountLabel.Text = "Number of Submits: " + ViewState["Submits"];

		if(Page.IsPostBack)
			GreetLabel.Text = "Hello " + NameTextBox.Text;
	}

</script>

<html>

	<head>
		<title>BasicWebApp</title>
	</head>

	<body>
		<h1><asp:Label ID="GreetLabel" Text="Welcome Visitor" runat="server" /></h1>
		<form runat="server">
			<asp:Label Text="Name: " runat="server" />
			<asp:TextBox ID="NameTextBox" runat="server" />
			<asp:Button ID="GreetButton" Text="Greet" runat="server" />
		</form>
		<p>
			<asp:Label ID="UserCountLabel" Font-Bold="True" runat="server" />
		</p>
		<p>
			<asp:Label ID="RequestCountLabel" Font-Bold="True" runat="server" />
		</p>
		<p>
			<asp:Label ID="SubmitCountLabel" Font-Bold="True" runat="server" />
		</p>
		<p>
			<a href="webformstatetest.aspx">Reload</a>
		</p>
	</body>

</html>