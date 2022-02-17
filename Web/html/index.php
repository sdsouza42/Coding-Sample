<?php
	function loadProducts(){
		include("db.inc");
		$con = salesConnect(); 
		$rs = $con->query("select pno,price,stock from products");
		while($row = $rs->fetch_row()){
			echo "<tr>";
			echo "<td>$row[0]</td>";
			echo "<td>$row[1]</td>";
			echo "<td>$row[2]</td>";
			echo "</tr>";
		}

		$rs->free();
		$con->close();
	}
?>

<html>
	<head>
		<title>Index - SalesApp</title>
	</head>
	<body>		
		<h1>List of Products</h1>
		<table border="1">
			<tr>
				<th>Product No</th>
				<th>Unit Price</th>
				<th>Current Stock</th>
			</tr>
			<?php
				loadProducts();
			?>
		</table>
		<p>
			<a href="login.php">Customer Login</a>
		</p>
	</body>
</html>









