<?php
	$code = 0;
	if(isset($_POST['submit']))
		$code = $_POST['pcode'];
?>

<html>
	<head>
		<title>$_POST Test - TestApp</title>
	</head>
	<body>		
		<h1 align="center">Product Information</h1>
		<form method="POST">
			Enter product code : <input type="text" name="pcode" value="<?php echo $_POST['pcode']?>"/>
			<input type="submit" name="submit" value="Lookup" /><br />
		</form>
		<b>Product code : </b> <?php echo $code?>
	</body>
</html>

