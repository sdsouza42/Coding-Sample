<?php
	if(isset($_GET['accountId'])){
		$accId = $_GET['accountId'];
		$con = mysqli_connect("localhost", "root", "", "bank");
		$rs = $con->query("select balance from account where accountId=$accId");
		$row = $rs->fetch_row();
		$balance = $row[0];
		$rs->free();
		$con->close();

		echo "({'balance':$balance})";
	}
?>


