<?php
	session_start();
	if(empty($_SESSION['RequestCount']))
		$_SESSION['RequestCount'] = 0;

	$_SESSION['RequestCount'] = $_SESSION['RequestCount'] + 1;
?>

<html>
	<head>
		<title>State Management - TestApp</title>
	</head>
	<body>		
		<h1 align="center">Welcome Visitor</h1>
		<b>Number of requests : </b> <?php echo $_SESSION['RequestCount'] ?>
	</body>
</html>

