<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<%
		String name = request.getParameter("visitor");
		if(name == null) name = "";
	%>
	<body>
		<h1>Welcome Visitor <%=name%></h1>
		<b>Time on server: </b><%=new java.util.Date()%>
	</body>
</html>

