#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	public class RemoteClient
	{
		#region ================== Constants

		private const int RESPONSE_TIMEOUT = 5000;
		private const int SEND_RECEIVE_SIZE = 1024;

		#endregion

		#region ================== Variables

		private Socket socket;
		private IPEndPoint remoteaddr;
		private DateTime lastreponse;

		private MemoryStream receivebuffer;
		private MemoryStream sendbuffer;
		private RemoteCommand receivecommand;
		
		#endregion

		#region ================== Properties

		public Socket Socket { get { return socket; } }
		public IPEndPoint RemoteAddr { get { return remoteaddr; } }
		public MemoryStream ReceiveBuffer { get { return receivebuffer; } }

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		public RemoteClient(Socket s)
		{
			// Initialize
			socket = s;
			socket.Blocking = false;
			remoteaddr = (IPEndPoint)s.RemoteEndPoint;
			receivebuffer = new MemoryStream(SEND_RECEIVE_SIZE);
			sendbuffer = new MemoryStream(SEND_RECEIVE_SIZE);
			NotifyResponse();
		}

		// Disposer
		public void Dispose()
		{
			socket.Close();
			receivebuffer.Dispose();
			sendbuffer.Dispose();
		}

		#endregion

		#region ================== Private Methods

		#endregion

		#region ================== Public Methods

		// This sends a command to the client
		public void SendCommand(RemoteCommand cmd)
		{
			cmd.WriteTo(sendbuffer);
		}

		// This processes the client.
		// Returns false when the connection was closed.
		public bool Process(RemoteManager manager)
		{
			// Send data
			int maxsendbytes = Math.Min(SEND_RECEIVE_SIZE, (int)sendbuffer.Length);
			int bytessent = socket.Send(sendbuffer.ToArray(), 0, maxsendbytes, SocketFlags.None);
			int bytesremaining = (int)sendbuffer.Length - bytessent;
			MemoryStream oldbuffer = sendbuffer;
			sendbuffer = new MemoryStream(Math.Max(bytesremaining, SEND_RECEIVE_SIZE));
			if(bytesremaining > 0)
				sendbuffer.Write(oldbuffer.ToArray(), bytessent, bytesremaining);
			oldbuffer.Dispose();
			
			// Receive data
			byte[] datablock = new byte[SEND_RECEIVE_SIZE];
			int bytesreceived = socket.Receive(datablock);
			if(bytesreceived == 0)
			{
				// When Receive returns 0 bytes the connection was closed
				return false;
			}
			else
			{
				// Receive new data from client
				NotifyResponse();
				ReceiveData(datablock, bytesreceived);

				// Parse and process commands
				RemoteCommand c = TryParseCommand();
				while(c != null)
				{
					manager.ProcessCommand(c);
					c = TryParseCommand();
				}

				return true;
			}
		}
		
		// This resets the response timer
		public void NotifyResponse()
		{
			lastreponse = DateTime.Now;
		}

		// This checks if the client has not responded or a while
		public bool CheckTimeout()
		{
			TimeSpan timeout = new TimeSpan(0, 0, 0, 0, RESPONSE_TIMEOUT);
			return (lastreponse + timeout) < DateTime.Now;
		}

		// This receives data
		public void ReceiveData(byte[] data, int bytes)
		{
			receivebuffer.Seek(0, SeekOrigin.End);
			receivebuffer.Write(data, 0, bytes);
		}

		// This attempts to parse a command and returns the command when complete
		public RemoteCommand TryParseCommand()
		{
			// If we're not working on a command yet, make one now
			if(receivecommand == null)
				receivecommand = new RemoteCommand(this);

			// Try parsing
			if(receivecommand.TryParse(ref receivebuffer))
			{
				// When complete, return the command and forget about this command
				RemoteCommand cmd = receivecommand;
				receivecommand = null;
				return cmd;
			}
			else
			{
				return null;
			}
		}

		// String representation
		public override string ToString()
		{
			return remoteaddr.ToString();
		}
		
		#endregion
	}
}
