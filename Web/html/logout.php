<?php
	session_start();
	$custid = $_SESSION['CustomerId'];

	setcookie("CustomerID", "$custid", time() + 24 * 24 * 60 * 5);

	session_destroy();

	header("Location: index.php");
?>

