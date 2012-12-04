<?
	// Includes
	include("includes/common.php");
	
	ConnectGluon();
	
	// Include the page
	include(GetCurrentPage());
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<title>Gluon Remote Terminal</title>
	<meta name="description" content="Gluon Remote Terminal" />
	<meta name="Content-Language" content="english" />
	<meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
	<meta name="viewport" content="user-scalable=no">
	<link rel="stylesheet" type="text/css" href="default.css" media="screen" title="Default" />
	<link rel="apple-touch-icon" href="apple-touch-icon.png"/>
	<script type="text/javascript" src="includes/common.js"></script>
	<script type="text/javascript" src="includes/interface.js"></script>
	<?
		OutputHeaders();
	?>
</head>

<body onload="OnPageLoad();">
<audio id="s214" src="sounds/214.wav" preload="preload"></audio>
<iframe id="hiddenframe" style="background-color: white;" src="" width="100%" height="0" frameborder="0" scrolling="no"></iframe>
<?
	OutputPageContent();
?>
</body>
</html>
