#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

#endregion

namespace CodeImp.Gluon
{
	/* Remoting Protocol
	 * ------------------------------------------------------------
	 * 
	 * Every message contains 4 or 5 data blocks. Each block is
	 * seperated by a single space. Service and command names
	 * are case-insensitive and generally expressed in uppercase.
	 * 
	 * [sourceservice] [targetservice] [command] [datalength] [data]
	 * 
	 * sourceservice:
	 * The name of the service sending the command.
	 * Max length is 128 bytes and may not contain spaces.
	 * 
	 * targetservice:
	 * The name of the service to which to send the command.
	 * Max length is 128 bytes and may not contain spaces.
	 * 
	 * command:
	 * The command for the service.
	 * Max length is 128 bytes and may not contain spaces.
	 * 
	 * datalength:
	 * The length of additional data for the command.
	 * Must be a positive decimal number. Max length is 32 bytes.
	 * 
	 * data:
	 * The additional data for the command. This length of this
	 * data in bytes must equal the number given in 'datalength'.
	 * When 'datalength' is 0 then this block may be omitted, but
	 * the space after 'datalength' is still required!
	 * 
	 */

	public class RemoteManager
	{
		#region ================== Constants

		private int LISTEN_PORT = 666;

		#endregion

		#region ================== Variables

		private TcpListener listener;
		private Thread workthread;

		private List<RemoteClient> clients;
		private Dictionary<string, RemoteService> services;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		public RemoteManager()
		{
			// Initialize
			services = new Dictionary<string, RemoteService>();
			clients = new List<RemoteClient>();
			listener = new TcpListener(IPAddress.Any, LISTEN_PORT);
			listener.Start();

			workthread = new Thread(ProcessingThread);
			workthread.Name = "Web Thread";
			workthread.Priority = ThreadPriority.Normal;
			workthread.Start();
		}

		// Disposer
		public void Dispose()
		{
			workthread.Interrupt();
			workthread.Join();
			
			listener.Stop();

			foreach(RemoteClient c in clients)
				c.Dispose();

			clients.Clear();
			services.Clear();
		}

		#endregion

		#region ================== Private Methods

		// Callback to accept a new connection
		private void ProcessingThread()
		{
			while(true)
			{
				// Accept incoming connections
				if(listener.Pending())
				{
					Socket s = listener.AcceptSocket();
					RemoteClient rc = new RemoteClient(s);
					clients.Add(rc);
					General.WriteLogLine("Remote client " + rc + " connected.");
				}

				// Process clients
				for(int i = clients.Count - 1; i >= 0; i--)
				{
					RemoteClient rc = clients[i];

					try
					{
						// Process the client. This will call ProcessCommand for any incoming commands.
						if(!rc.Process(this))
						{
							// Connection lost.
							DisconnectClient(rc, null);
						}
					}
					catch(InvalidDataException e)
					{
						// Invalid data received
						DisconnectClient(rc, "Client sent invalid protocol data; " + e.Message);
					}
					catch(SocketException e)
					{
						switch(e.SocketErrorCode)
						{
							// This exception simply means there is no data to read.
							// Check if the client is timing out (then disconnect).
							case SocketError.WouldBlock:
								if(rc.CheckTimeout())
									DisconnectClient(rc, "Connection timed out.");
								break;

							// Some unknown exception
							default:
								DisconnectClient(rc, SocketErrorDesc.GetDesc(e.SocketErrorCode) + " (" + e.SocketErrorCode + ")");
								break;
						}
					}
					catch(Exception e)
					{
						// This is horrible
						DisconnectClient(rc, "Client caused " + e.GetType().Name + ": " + e.Message);
					}
				}

				// Process services
				foreach(KeyValuePair<string, RemoteService> svc in services)
					svc.Value.UpdateNetworkThread();
				
				// Sleep
				try { Thread.Sleep(2); }
				catch(ThreadInterruptedException e) { return; }
			}
		}

		// This disposes (disconnects) a client
		private void DisconnectClient(RemoteClient rc, string message)
		{
			if(message != null)
				General.WriteLogLine("Remote client " + rc + " disconnected with error: " + message);
			else
				General.WriteLogLine("Remote client " + rc + " disconnected.");
			
			rc.Dispose();
			clients.Remove(rc);
		}

		#endregion

		#region ================== Public Methods

		// This registers a service
		public void RegisterService(RemoteService svc)
		{
			if(!services.ContainsKey(svc.Name))
				services.Add(svc.Name, svc);
			else
				throw new Exception("Service with that name already registered.");
		}

		// This removes a registered service
		public void UnregisterService(RemoteService svc)
		{
			if(services.ContainsKey(svc.Name))
				services.Remove(svc.Name);
		}

		// This processes a command
		public void ProcessCommand(RemoteCommand cmd)
		{
			// Verify that the target service exists
			if(!services.ContainsKey(cmd.Target))
				throw new InvalidDataException("Target service '" + cmd.Target + "' is not known.");

			RemoteService svc = services[cmd.Target];
			svc.ReceiveCommand(cmd);
		}

		#endregion
	}
}
