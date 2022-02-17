<?php
	session_start();
	$pcode = $_SESSION['ProductCode'];
?>

<html>
	<head>
		<title>Product Information - TestApp</title>
	</head>
	<body>		
		<h1 align="center">Product information for product <?php echo $pcode ?> </h1>
	</body>
</html>

