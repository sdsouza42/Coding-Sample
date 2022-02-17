<%@ Page Inherits="BasicWebApp.WebCtrlTestPage" CodeFile="webctrltest.aspx.cs" %>
<%@ Register TagPrefix="bwa" Namespace="BasicWebApp" Assembly="basicwebapp" %>

<html>

	<head>
		<title>BasicWebApp</title>
	</head>

	<body>
		<h1><bwa:RainbowOutput ID="GreetOutput" runat="server" /></h1>
		<b>Time on server: </b><asp:Label ID="ClockLabel" runat="server" />
	</body>

</html>