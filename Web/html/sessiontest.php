<?php
	if(isset($_POST['submit'])){
		session_start();
		$_SESSION['ProductCode'] = $_POST['pcode'];
		header("Location: productinfo.php");
	}
?>

<html>
	<head>
		<title>$_SESSION Test - TestApp</title>
	</head>
	<body>		
		<h1 align="center">Product Information</h1>
		<form method="POST">
			Enter product code : <input type="text" name="pcode" />
			<input type="submit" name="submit" value="Submit" />
		</form>
	</body>
</html>

