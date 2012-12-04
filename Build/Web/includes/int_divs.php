<?
	// This creates a column piece
	// For $top: True is on the top of a column, False is on the bottom.
	// For $left: True is a row on the left of the column, False is a row on the right of the column.
	function CreateBigColCorner($id, $x, $y, $color, $top, $left)
	{
		// Determine images to use and position
		if($left)
		{
			$sisrc = "l";
			$bisrc = "r";
			$bileft = BIG_COL_WIDTH + SMALL_CORNER_SIZE - 66;
			$sileft = -1;
		}
		else
		{
			$sisrc = "r";
			$bisrc = "l";
			$bileft = -1;
			$sileft = BIG_COL_WIDTH + SMALL_CORNER_SIZE - 22;
		}
		
		if($top)
		{
			$sisrc .= "b";
			$bisrc .= "t";
			$sitop = SMALL_ROW_HEIGHT;
			$bitop = -1;
		}
		else
		{
			$sisrc .= "t";
			$bisrc .= "b";
			$sitop = -1;
			$bitop = 0;
		}
		
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=BIG_COL_WIDTH + SMALL_CORNER_SIZE?>px;
				height: <?=SMALL_ROW_HEIGHT + SMALL_CORNER_SIZE?>px;
				background: <?=$color?>;"
		>
		<img src="images/sc_<?=$sisrc?>.png" style="position: absolute; top: <?=$sitop?>px; left: <?=$sileft?>px;"/>
		<img src="images/bb_<?=$bisrc?>.png" style="position: absolute; top: <?=$bitop?>px; left: <?=$bileft?>px;"/>
		</div>
		<?
	}
	
	// This creates a column piece
	function CreateBigColPiece($id, $x, $y, $height, $color, $text)
	{
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=BIG_COL_WIDTH?>px;
				height: <?=$height?>px;
				background: <?=$color?>;
				text-align: right;"
		>
		<span style="position: relative; top: <?=$height-35?>px; padding-right: 10px;"><?=$text?></span>
		</div>
		<?
	}
	
	// This creates a row piece
	function CreateSmallRowPiece($id, $x, $y, $width, $color, $text)
	{
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=$width?>px;
				height: <?=SMALL_ROW_HEIGHT?>px;
				background: <?=$color?>;
				color: #000000;"
		>
		<span style="position: relative; top: 5px; padding-right: 10px;"><?=$text?></span>
		</div>
		<?
	}
	
	// This creates a row ending
	function CreateSmallRowEndPiece($id, $x, $y, $width, $color, $text, $left)
	{
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=$width?>px;
				height: <?=SMALL_ROW_HEIGHT?>px;
				background: <?=$color?>;
				color: #000000;"
		>
		<? if($left) { ?><img src="images/sb_left.png" style="position: absolute; top: -1px; left: -1px;"/><? } ?>
		<span style="position: relative; top: 5px; padding-right: 10px;"><?=$text?></span>
		<? if(!$left) { ?><img src="images/sb_right.png" style="position: absolute; top: -1px; left: <?=$width-22?>px;"/><? } ?>
		</div>
		<?
	}
	
	// This creates a column button
	function CreateBigColButton($id, $x, $y, $height, $color, $sound, $text, $event)
	{
		global $mousedownevent, $mouseupevent;
		
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=BIG_COL_WIDTH?>px;
				height: <?=$height?>px;
				background: <?=$color?>;
				text-align: right;"
			<?=$mousedownevent?>="PlaySound('<?=$sound?>'); OnButtonPress('<?=$id?>');"
			<?=$mouseupevent?>="OnButtonRelease('<?=$id?>', '<?=$event?>');"
		>
		<span style="position: relative; top: <?=$height-35?>px; padding-right: 10px;"><?=$text?></span>
		</div>
		<?
	}
	
	// This creates a bar button
	function CreateBigRowButton($id, $x, $y, $width, $color, $sound, $text, $event)
	{
		global $mousedownevent, $mouseupevent;
		
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=$width?>px;
				height: <?=BIG_ROW_HEIGHT?>px;
				background: <?=$color?>;
				text-align: right;"
			<?=$mousedownevent?>="PlaySound('<?=$sound?>'); OnButtonPress('<?=$id?>');"
			<?=$mouseupevent?>="OnButtonRelease('<?=$id?>', '<?=$event?>');"
		>
		<span style="position: relative; top: 45px; padding-right: 10px;"><?=$text?></span>
		</div>
		<?
	}
	
	// This creates a bar button
	function CreateSmallRowButton($id, $x, $y, $width, $color, $sound, $text, $event)
	{
		global $mousedownevent, $mouseupevent;
		
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=$width?>px;
				height: <?=SMALL_ROW_HEIGHT?>px;
				background: <?=$color?>;
				color: #000000;"
			<?=$mousedownevent?>="PlaySound('<?=$sound?>'); OnButtonPress('<?=$id?>');"
			<?=$mouseupevent?>="OnButtonRelease('<?=$id?>', '<?=$event?>');"
		>
		<span style="position: relative; top: 5px; padding-right: 10px;"><?=$text?></span>
		</div>
		<?
	}
	
	// This creates a button with rounded corners
	function CreateRoundButton($id, $x, $y, $width, $color, $sound, $text, $event)
	{
		global $mousedownevent, $mouseupevent;
		
		?>
		<div
			id="<?=$id?>"
			class="interface"
			style="
				top: <?=$y?>px;
				left: <?=$x?>px;
				width: <?=$width?>px;
				height: <?=SMALL_ROW_HEIGHT?>px;
				background: <?=$color?>;
				text-align: center;"
			<?=$mousedownevent?>="PlaySound('<?=$sound?>'); OnButtonPress('<?=$id?>');"
			<?=$mouseupevent?>="OnButtonRelease('<?=$id?>', '<?=$event?>');"
		>
		<img src="images/sb_left.png" style="position: absolute; top: -1px; left: -1px;"/>
		<span style="position: relative; top: 5px;"><?=$text?></span>
		<img src="images/sb_right.png" style="position: absolute; top: -1px; left: <?=$width-22?>px;"/>
		</div>
		<?
	}
?>