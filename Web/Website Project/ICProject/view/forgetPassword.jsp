<html>
<head>
<link rel="stylesheet" type="text/css"
	href="<%=request.getContextPath()%>/css/icecream.css">
<link rel="stylesheet" type="text/css"
	href="<%=request.getContextPath()%>/css/main.css">
</head>
<body>
<form action="forgetPassword.jlc" method="post">
<center>
<table class="textStyle">
	<tr>
		<td align="center" colspan="3"><font size="7"><b>Retrieve
		Your Password</b></font></td>
	</tr>
	<tr>
		<td align="center" colspan="3"><font size="4" color="red"> </font></td>
	</tr>
	<tr>
		<td><br />
		</td>
	</tr>
	
		<tr>
			<td align="center" height=""><font size="5"><b>Username</b></font></td>
			<td><input type="text" size="35"
				style="color: black; background-color: #b4e0d2; font-size: 20"
				name="uname"></td>
			<td><font size="4" color="red"></font></td>
		</tr>
		<tr>
			<td colspan="3"><br />
			</td>
		</tr>
		<tr>
			<td align="center"><font size="5"><b>Email</b></font></td>
			<td><input type="text" size="35"
				style="color: black; background-color: #b4e0d2; font-size: 20"
				name="email"></td>
			<td><font size="4" color="red"></font></td>
		</tr>
		<tr>
			<td align="center" colspan="3"><br />
			<input type="submit" size="35"
				style="color: white; background-color: maroon; font-size: 35"
				value="Show Password"></td>
		</tr>
		<tr>
			<td align="center" colspan="3"><b><font size="5">New
			User</font>&nbsp;<a href="registerDef.jsp"><font size="5">Signup
			Here</font></a></b></td>
		</tr>
	
		<tr>
			<td align="center" colspan="3"><b><font color="green"
				size="5">Your Password is:</font><font color="red" size="6">
			</font></b></td>
		</tr>
	
	<tr>
		<td align="center" colspan="3"><b><font size="5">Login</font>&nbsp;<a
			href="index.jsp"><font size="5">Click Here</font></a></b></td>
	</tr>
</table>
</center>
</form>
</body>
</html>
