<?php
	$custid = $_COOKIE['CustomerID'];
?>

<?php
	function authenticate(){
		include("db.inc");
		$con = salesConnect(); 
		$custid = $_POST['custid'];
		$pwd = $_POST['pwd'];

		$rs = $con->query("select count(cust_id) from customers where cust_id='$custid' and pwd='$pwd'");
		$row = $rs->fetch_row();
		$n = $row[0];
		$rs->free();
		$con->close();

		if($n <> 0){
			session_start();
			$_SESSION['CustomerId'] = $custid;
			header("Location: order.php");
		}else{
			echo "<b>Authentication Failed!</b>";
		}
	}
?>

<html>
	<head>
		<title>Login - SalesApp</title>
	</head>
	<body>		
		<h1>Welcome Customer</h1>
		<form method="POST">
		    <table border="1">
			<tr>
				<td>Customer Id: </td>
				<td><input type="text" name="custid" value="<?php echo $custid?>"/></td>
			</tr>
			<tr>
				<td>Password: </td>
				<td><input type="password" name="pwd" /></td>
			</tr>
			<tr align="center">
				<td colspan="2">
					<input type="submit" name="submit" value="Login" />
				</td>
			</tr>
		    </table>
		</form>
		<p>
			<?php
				if(isset($_POST['submit']) && $_POST['submit'] == "Login")
					authenticate();
			?>
		</p>
	</body>
</html>









