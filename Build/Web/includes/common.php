<?
	include("gluon.php");
	
	// Detect which platform we are on and adjust settings accordingly
	if((bool)strpos($_SERVER['HTTP_USER_AGENT'],'iPad'))
	{
		$mousedownevent = "ontouchstart";
		$mouseupevent = "ontouchend";
	}
	else
	{
		$mousedownevent = "onmousedown";
		$mouseupevent = "onmouseup";
	}
	
	// This determines the page to include
	function GetCurrentPage()
	{
		if(isset($_POST['p'])) $p = $_POST['p'];
		else if(isset($_GET['p'])) $p = $_GET['p'];
		
		// No page name specified?
		if(!isset($p) || (trim($p) == ""))
		{
			// Select the main page
			return "overview.php";
		}
		// Valid page name specified?
		else if(file_exists($p . ".php"))
		{
			// Select the file with this page name
			return $p . ".php";
		}
		else
		{
			// Invalid page
			return "overview.php";
		}
	}
	
	include("interface.php");
?>
