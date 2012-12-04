<?php
	
	include_once("socket.php");
	
	// This opens a connection with Gluon
	function ConnectGluon()
	{
		global $gluonconnected, $gluonsocket;
		
		if($gluonconnected)
			return true;
			
		$gluonsocket = new socket();
		if($gluonsocket->connect("127.0.0.1", 666, 2, true))
		{
			$gluonconnected = true;
			return true;
		}
		else
		{
			$gluonconnected = false;
			return false;
		}
	}
	
	// This sends a command to Gluon
	function SendGluonCommand($servicename, $command, $data)
	{
		global $gluonconnected, $gluonsocket;
		
		if($gluonconnected)
		{
			$datalength = strlen($data);
			$fullstring = "WEBSITE " . strtoupper($servicename) . " " . strtoupper($command) . " " . $datalength . " " . $data;
			
			$gluonsocket->write($fullstring, true, 2);
		
			return true;
		}
		else
		{
			return false;
		}
	}
	
	// This receives a command from Gluon
	// Returns an array with 5 elements (0=sourceservice, 1=targetservice, 2=command, 3=length, 4=data)
	function ReceiveGluonCommand()
	{
		global $gluonconnected, $gluonsocket;
		
		if($gluonconnected)
		{
			$starttime = time();
			$alldata = "";
			while(true)
			{
				$readdata = $gluonsocket->read(1024, false, 1);
				$alldata = $alldata . $readdata;
				
				$splitdata = explode(" ", $alldata, 5);
				if(count($splitdata) == 5)
				{
					$datalength = 0 + $splitdata[3];
					if(strlen($splitdata[4]) == $datalength)
					{
						// Data complete!
						$splitdata[0] = strtoupper($splitdata[0]);
						$splitdata[1] = strtoupper($splitdata[1]);
						$splitdata[2] = strtoupper($splitdata[2]);
						return $splitdata;
					}
				}
				
				if((strlen($readdata) == 0) && (($starttime + 2) < time()))
					return false;
			}
		}
		else
		{
			return false;
		}
	}
?>