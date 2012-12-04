<? if(!defined("__SOCKETCLASS__")) {
	
	
	/******************************************************************************\
		
		PHP Socket Class
		by Pascal "Gherkin" vd Heiden (9/16/2002)
		gherkin@xodemultimedia.com
		www.xodemultimedia.com
		
		Usage:
		Include this file in your PHP code and create a
		Class Object Variable from the socket Class. This will be your socket.
		You can use the functions described below to control the socket.
		
	\******************************************************************************/
	
	
	// Unique definition
	define("__SOCKETCLASS__", true);
	
	
	// Socket Class
	class socket
	{
		var $sck;				// Socket Handle
		var $state;				// Status (0=unused, 1=connected)
		var $ispersistent;
		
		// Constructor
		function __construct()
		{
		}
		
		// Destructor
		function __destruct()
		{
			if(!$this->ispersistent)
				$this->close();
		}
		
		// connect: Initiates a connection to a remote host
		// This function returns true on success, false on failure
		function connect($ip, $port, $timeout = 20, $persistent = false)
		{
			// Connect to remote host
			$this->ispersistent = $persistent;
			if($persistent)
				$this->sck = @pfsockopen($ip, $port, $errno, $errstr, $timeout);
			else
				$this->sck = @fsockopen($ip, $port, $errno, $errstr, $timeout);
			
			// Return result
			if((!$this->sck) && ($errno <> 0))
			{
				// It didnt work
				$this->state = 0;
				return false;
			}
			else
			{
				// It worked w00t
				$this->state = 1;
				return true;
			}
		}
		
		// close: Closes this socket.
		// Note that if you sent data in non-blocking mode before this,
		// that data may not arrive correctly or not at all.
		function close()
		{
			// Close this socket
			@fclose($this->sck);
			
			// Return success
			$this->state = 0;
			return true;
		}
		
		// write: Writes data onto this socket for sending
		// Set $block to true to wait until the data is sent.
		// Returns the number of bytes written, or -1 on failure.
		function write($data, $block = true, $timeout = 20)
		{
			// Set the timeout
			@socket_set_timeout($this->sck, $timeout, 0);
			
			// Set the blocking state
			@socket_set_blocking($this->sck, $block);
			
			// Send the data and return result
			return fwrite($this->sck, $data);
		}
		
		// read: Reads data from this socket that was received
		// Set $block to true to wait for the specified number
		// of bytes to receive, or return immediately.
		// Returns the data read from the socket.
		function read($length, $block = true, $timeout = 20)
		{
			// Set the timeout
			@socket_set_timeout($this->sck, $timeout, 0);
			
			// Set the blocking state
			@socket_set_blocking($this->sck, $block);
			
			// Read from the socket and return it
			return fread($this->sck, $length);
		}
	}
} ?>