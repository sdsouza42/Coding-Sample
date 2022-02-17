<jsp:useBean id="userCtr" class="basicwebapp.CounterBean" scope="session" />
<jsp:useBean id="appCtr" class="basicwebapp.CounterBean" scope="application" />
<jsp:setProperty name="appCtr" property="step" value="3" />
<html>
	<head>
		<title>BasicWebApp</title>
	</head>
	<body>
		<h1>Welcome Visitor</h1>
		<b>Number of requests: </b>${userCtr.nextCount} / ${appCtr.nextCount}
	</body>
</html>

