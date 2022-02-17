<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:useBean id="invoice" class="sales.InvoiceBean" />
<jsp:setProperty name="invoice" property="customerId" param="customer" />
<html>
	<head>
		<title>DBWebApp1</title>
	</head>

	<body>
		<h1>Invoice Viewer</h1>
		<p>
			<form method="POST" action="invoice.jsp">
				<b>Customer ID: </b>
				<input type="text" name="customer" value="${param.customer}"/>
				<input type="submit" value="Show"/>
			</form>
		</p>
		<p>
			<table border="1">
				<tr>
					<th>Order Date</th>
					<th>Product No</th>
					<th>Quantity</th>
					<th>Amount</th>
				</tr>
				<c:forEach var="entry" items="${invoice.entries}">
					<tr>
						<td>${entry.orderDate}</td>
						<td>${entry.productNo}</td>
						<td>${entry.quantity}</td>
						<td>${entry.amount}</td>
					</tr>
				</c:forEach>
			</table>
		</p>
	</body>
</html>

