<?php
	function loadAccountDetails(){
		$con = mysqli_connect("localhost", "root", "", "bank");
		$rs = $con->query("select accountId, balance from account");
		while($row = $rs->fetch_row()){
			echo "<tr>";
			echo "<td>$row[0]</td>";
			echo "<td align='right'>$row[1]</td>";
			echo "</tr>";
		}

		$rs->free();
		$con->close();
	}
?>

<html>
	<head>
		<title>PHP</title>
	</head>
	<body>
		<h1>MET Bank Ltd</h1>
		<a href="deposit.php">Deposit</a>
		<table border="1">
			<tr>
				<th>Account Id</th>
				<th>Account Balance</th>
			</tr>
			<?php
				loadAccountDetails();
			?>
		</table>
	</body>
</html>



