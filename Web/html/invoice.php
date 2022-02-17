<?php
	session_start();
	$custid = $_SESSION['CustomerId'];

	if(empty($custid))
		header("Location: login.php");

	include("db.inc");
?>

<?php
	function loadOrders(){
		$con = salesConnect();
		$custid = $GLOBALS['custid'];
		$rs = $con->query("select ord_no,ord_date,pno,qty,amt from ord_view where cust_id='$custid'");

		$total = 0;

		while($row = $rs->fetch_row()){
			echo "<tr>";
			echo "<td>$row[0]</td>";
			echo "<td>$row[1]</td>";
			echo "<td>$row[2]</td>";
			echo "<td>$row[3]</td>";
			echo "<td align='right'>$row[4]</td>";
			echo "</tr>";

			$total += $row[4];
		}
		echo "<tr>";
		echo "<th align='right' colspan='4'>Total Payment : </th>";
		echo "<td>" . number_format($total, 2) . "</td>";
		echo "</tr>";

		$rs->free();
		$con->close();
	}
?>


<html>
	<head>
		<title>Invoice - SalesApp</title>
	</head>
	<body>		
		<h1>Welcome Customer <?php echo $custid ?></h1>
		<table border="1">
			<tr>
				<th>Order No</th>
				<th>Order Date</th>
				<th>Product No</th>
				<th>Quantity</th>
				<th>Amount</th>
			</tr>
			<?php
				loadOrders();
			?>
		</table>
		<p>
			<a href="logout.php">Logout</a>
		</p>
	</body>
</html>









