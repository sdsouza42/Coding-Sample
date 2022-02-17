<%@ Page Inherits="BasicWebApp.WebFormTestPage" %>

<html>

	<head>
		<title>BasicWebApp</title>
	</head>

	<body>
		<h1><asp:Label ID="GreetLabel" Text="Welcome Visitor" runat="server" /></h1>
		<form runat="server">
			<asp:Label Text="Name: " runat="server" />
			<asp:TextBox ID="NameTextBox" runat="server" />
			<asp:Button ID="GreetButton" Text="Greet" OnClick="GreetButton_Click" runat="server" />
		</form>
	</body>

</html>