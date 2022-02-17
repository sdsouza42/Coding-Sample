<?php
	$code = 0;

	if(isset($_GET['pcode']))
		$code = $_GET['pcode']
?>

<html>
	<head>
		<title>$_GET Test - TestApp</title>
	</head>
	<body>		
		<h1 align="center">Product Information</h1>
		<b>Product code : </b> <?php echo $code?>
	</body>
</html>

