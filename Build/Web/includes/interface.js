
var blinkblue_objects = new Array();
var blinkblue_orig_colors = new Array();
var blinkblue_items = 0;
var blinkblue_started = false;
var blinkblue_state = false;


function ToggleBlinkingBlue(id)
{
	var obj = document.getElementById(id);
	if(obj)
	{
		// Find item in array
		var foundindex = -1;
		for(i = 0; i < blinkblue_items; i++)
		{
			if(blinkblue_objects[i] == obj)
				foundindex = i;
		}
		
		// Toggle
		if(foundindex > -1)
			StopBlinkingBlue(id);
		else
			StartBlinkingBlue(id);
	}
}


function StartBlinkingBlue(id)
{
	var obj = document.getElementById(id);
	if(obj)
	{
		blinkblue_objects[blinkblue_items] = obj;
		blinkblue_orig_colors[blinkblue_items] = obj.style.backgroundColor;
		blinkblue_items++;
		
		if(blinkblue_state)
			obj.style.backgroundColor = "#3399FF";
		else
			obj.style.backgroundColor = "#00509F";
	}
}


function StopBlinkingBlue(id)
{
	var obj = document.getElementById(id);
	if(obj)
	{
		// Find item in array
		var foundindex = -1;
		for(i = 0; i < blinkblue_items; i++)
		{
			if(blinkblue_objects[i] == obj)
				foundindex = i;
		}
		
		if(foundindex > -1)
		{
			// Reset color
			obj.style.backgroundColor = blinkblue_orig_colors[foundindex];
			
			// Remove from list
			if(foundindex < (blinkblue_items - 1))
			{
				blinkblue_objects[foundindex] = blinkblue_objects[blinkblue_items - 1];
				blinkblue_orig_colors[foundindex] = blinkblue_orig_colors[blinkblue_items - 1];
			}
			
			blinkblue_items--;
		}
	}
}


function BlinkBlueTimer()
{
	if(blinkblue_state)
	{
		// Reset to original color
		for(i = 0; i < blinkblue_items; i++)
			blinkblue_objects[i].style.backgroundColor = "#00509F";
		
		blinkblue_state = false;
	}
	else
	{
		// Set color to blue
		for(i = 0; i < blinkblue_items; i++)
			blinkblue_objects[i].style.backgroundColor = "#3399FF";
		
		blinkblue_state = true;
	}
	
	setTimeout("BlinkBlueTimer()", 1000);
}

