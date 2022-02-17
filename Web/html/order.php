<?php
	session_start();
	$custid = $_SESSION['CustomerId'];

	if(empty($custid))
		header("Location: login.php");

	include("db.inc");
?>

<?php
	function loadProducts(){
		$con = salesConnect();
		$rs = $con->query("select pno from products");
		while($row = $rs->fetch_row()){
			if($_POST['pno'] == $row[0])
				echo "<option selected>$row[0]</option>";
			else
				echo "<option>$row[0]</option>";
		}

		$rs->free();
		$con->close();
	}
?>

<?php
	function placeOrder(){
		$qty = $_POST['qty'];
		$flag = $_POST['valid'];

		if(!is_numeric($qty) && $flag == "no"){
			echo "<b>Please enter integer value for quantity!</b>";
		}else{
		  $con = salesConnect();

		  $custid = $GLOBALS['custid'];
		  $pno = $_POST['pno'];
		  $today = date('Y-m-d h:i:s');

		  $con->query("update ord_ctl set ord_no=ord_no+1");
		  $rs = $con->query("select ord_no from ord_ctl");
		  $row = $rs->fetch_row();
		  $orderNo = $row[0];

		  $con->query("insert into orders(ord_no,ord_date,cust_id,pno,qty) values($orderNo, '$today', '$custid', $pno, $qty)");

		  $rs->free();
		  $con->close();

		  mail("unipro@localhost", "Order placed for order no $orderNo", "Order placed for product $pno with quantity $qty and order number $orderNo", "unipro@localhost");

		  echo "<b>New order number : </b>$orderNo";
		}
	}
?>

<html>
	<head>
		<title>Order - SalesApp</title>
		<script type="text/javascript">
			function validate(frmOrder){
				var qty = frmOrder.qty.value;
				if(isNaN(qty)){
					alert("Please enter integer value for quantity!");
					return false;
				}
				frmOrder.valid.value = "yes";
			}
		</script>
	</head>
	<body>		
		<h1>Welcome Customer <?php echo $custid ?></h1>
		<form name="frmOrder" method="POST">
		    <table border="1">
			<tr>
				<td>Product No: </td>
				<td>
					<select name="pno">
						<?php
							loadProducts();
						?>
					</select>
				</td>
			</tr>
			<tr>
				<td>Quantity: </td>
				<td><input type="text" name="qty" value="<?php echo $_POST['qty']?>"/></td>
			</tr>
			<tr>
				<td><input type="hidden" name="valid" value="no"/></td>
			</tr>

			<tr align="center">
				<td colspan="2">
					<input type="submit" name="submit" value="Order" onClick="return validate(frmOrder)" />
				</td>
			</tr>
		    </table>
		</form>
		<p>
			<?php
				if(isset($_POST['submit']))
					placeOrder();
			?>
		</p>
		<p>
			<a href="invoice.php">Invoice</a>&nbsp;&nbsp;
			<a href="logout.php">Logout</a>
		</p>
	</body>
</html>









