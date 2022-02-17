<?php
	function insertRecord(){
		$accId = $_POST['accountId'];
		$balance = $_POST['balance'];

		$con = mysqli_connect("localhost", "root", "", "bank");
		$con->query("insert into account(accountId, balance) values($accId, $balance)");		
		$con->close();
		echo "<b>Record Saved</b>";
	}
?>

<html>
	<head>
		<title>PHP</title>
		<script type="text/javascript">
			function validate(frm){
				var accId = frm.accountId.value;
				var bal = frm.balance.value;
				if(accId == "" || bal == ""){
					alert("Mandatory Fields");
					return false;
				}
			}
		</script>
	</head>
	<body>
		<h1>MET Bank Ltd</h1>
		<form name="frmBank" method="POST">
			AccountId : <input type="text" name="accountId" /><br />
			Balance : <input type="text" name="balance" /> <br />
			<input type="submit" name="submit" value="Deposit" onClick="return validate(frmBank)" />
		</form>
		<?php
			if(isset($_POST['submit'])){
				insertRecord();
			}
		?>
		<a href="accounts.php">List of Accounts</a>
	</body>
</html>



