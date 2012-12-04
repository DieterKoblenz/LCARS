<?

function OutputHeaders()
{
	?>
	<script type="text/javascript">
	
	// Events
	function OnPauseButtonClick()
	{
		SendGluonCommand("MEDIAPLAYER", "PAUSE", "");
		ToggleBlinkingBlue("pausebutton");
	}
	
	</script>
	<?
}


function OutputPageContent()
{
	SendGluonCommand("MEDIAPLAYER", "STATUS", "");
	$status = ReceiveGluonCommand();
	if($status)
	{
		?><div class="interface" style="left: 20px; top: 20px; color: #A6846F; font-size: 14pt;"><?
		$info = explode("\r\n", $status[4]);
		?>
		Status: <?=$info[0]?><br>
		<?
		if($info[0] != "STOPPED")
		{
			?>
			Track: <?=$info[1]?><br>
			Length: <?=$info[2]?><br>
			Position: <?=$info[3]?><br>
			<?
		}
		?></div><?
	}
	
	CreateRoundButton("pausebutton", 50, 200, 200, CLR_NORMAL, "s214", "Pause", "OnPauseButtonClick()");
}

?>