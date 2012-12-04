<?
	include("includes/common.php");
	
	ConnectGluon();
	
	$service = strtoupper($_GET["s"]);
	$command = strtoupper($_GET["c"]);
	$data = $_GET["d"];
	
	SendGluonCommand($service, $command, $data);
	print(implode(" ", ReceiveGluonCommand()));
?>