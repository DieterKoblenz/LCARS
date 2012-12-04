
// Some global information
var currentdomain;


// This is for button presses
var oldbuttoncolor;
var buttonpressed;


// This is for debug logging
var debuglogdata;


// When the page is loaded or refreshed
function OnPageLoad()
{
	BlinkBlueTimer();
	
	buttonpressed = false;
	
	currentdomain = location.protocol + '//' +
					location.hostname +
					location.pathname.substring(0, location.pathname.lastIndexOf('/')); // + '/index.php';

	debuglogdata = "<html><head></head><body style=\"background: #FFFFFF; color: #000000;\">";
}


// When a button is pressed
function OnButtonPress(id)
{
	var button = document.getElementById(id);
	oldbuttoncolor = button.style.backgroundColor;
	button.style.backgroundColor = "#FFFFFF";
	button.style.color = "#C0C0C0";
	buttonpressed = true;
}


// When a button is released
function OnButtonRelease(id, event)
{
	var button = document.getElementById(id);
	button.style.backgroundColor = oldbuttoncolor;
	button.style.color = "#000000";
	
	if(buttonpressed)
	{
		buttonpressed = false;
		eval(event);
	}
}


// This can be used to send a command to Gluon (without the need for an answer)
function SendGluonCommand(service, command, data)
{
	var ifrm = document.getElementById("hiddenframe");
	ifrm = (ifrm.contentWindow) ? ifrm.contentWindow : (ifrm.contentDocument.document) ? ifrm.contentDocument.document : ifrm.contentDocument;
	// Create a timestamp in the URL so that the page is not retreived from chache
	var timestamp = GetMilliseconds();
	ifrm.location.replace(currentdomain + "/sendgluon.php?s=" + escape(service) + "&c=" + escape(command) + "&d=" + escape(data) + "&timestamp=" + escape(timestamp));
}


// Play HTML5 audio
function PlaySound(id)
{
	var sound = document.getElementById(id);
	sound.play();
}


// This returns the time in milliseconds
function GetMilliseconds()
{
	var dt = new Date();
	var timestamp = Date.UTC(dt.getFullYear(), dt.getMonth(), dt.getDay(), dt.getHours(), dt.getMinutes(), dt.getSeconds(), dt.getMilliseconds());
	return timestamp;
}
