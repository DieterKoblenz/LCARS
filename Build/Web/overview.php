<?

function OutputHeaders()
{
	?>
	<script type="text/javascript">

	// Events
	function OnMediaButtonClick()
	{
		window.location = "?p=mediaplayer";
	}
	
	</script>
	<?
}


function OutputPageContent()
{
	SendGluonCommand("MEDIAPLAYER", "STATUS", "");
	$response = ReceiveGluonCommand();
	$online = ($response[0] == "MEDIAPLAYER");
	
	// Left column
	CreateBigColCorner("", 20, 20, CLR_NORMAL, true, false);
	CreateBigColPiece("", 20, 85, 61, CLR_NORMAL, "");
	CreateBigColButton("mediabutton", 20, 151, 80, CLR_NORMAL, "s214", "Media Player", "OnMediaButtonClick()");
	CreateBigColPiece("", 20, 236, 219, CLR_NORMAL, "");
	CreateBigColPiece("", 20, 460, 101, CLR_NORMAL, "");
	CreateBigColCorner("", 20, 560, CLR_NORMAL, false, false);
	
	// Top row
	CreateSmallRowPiece("", 220, 20, 102, CLR_NORMAL, "");
	CreateSmallRowPiece("", 327, 20, 100, CLR_DARK, "");
	CreateSmallRowPiece("", 432, 20, 300, CLR_NORMAL, "");
	CreateSmallRowEndPiece("", 737, 20, 220, CLR_NORMAL, "", false);
	
	// Bottom row
	CreateSmallRowPiece("", 220, 582, 102, CLR_NORMAL, "");
	CreateSmallRowPiece("", 327, 582, 100, CLR_DARK, "");
	CreateSmallRowPiece("", 432, 582, 300, CLR_NORMAL, "");
	CreateSmallRowEndPiece("", 737, 582, 220, CLR_NORMAL, "", false);
	
	// Content
	?>
	<div class="interface" style="left: 230px; top: 75px; color: #A6846F; font-size: 24pt;">GLUON REMOTE TERMINAL</div>
	<?
	
	if(!$online)
	{
		?>
		<div class="interface" style="left: 280px; top: 175px; color: #CC0033; font-size: 24pt;">SYSTEM OFFLINE</div>
		<?
	}
}

?>