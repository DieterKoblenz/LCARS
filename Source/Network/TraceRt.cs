#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

#endregion

namespace CodeImp.Gluon
{
	internal class TraceRt
	{
		#region ================== Constants

		private readonly byte[] pingdata = new byte[8] { 0x65, 0x65, 0x65, 0x65, 0x65, 0x65, 0x65, 0x65 };
		
		#endregion

		#region ================== Variables

		private string destaddr;
		private int pingtimeout = 1000;
		private int flooddelay = 500;
		private int maxhops = 30;
		private List<TraceRtNode> nodes;
		private bool destreached;
		private bool destresponse;
		private Thread tracethread;
		
		#endregion

		#region ================== Events

		public event EventHandler TraceComplete;
		public event EventHandler<RouteNodeFoundEventArgs> TraceNodeFound;

		#endregion

		#region ================== Properties

		public string DestAddress { get { return destaddr; } }
		public int PingTimeout { get { return pingtimeout; } set { pingtimeout = value; } }
		public int FloodDelay { get { return flooddelay; } set { flooddelay = value; } }
		public int MaxHops { get { return maxhops; } set { maxhops = value; } }
		public bool IsTracing { get { return (tracethread != null); } }
		public bool DestReached { get { return destreached; } }
		public bool DestResponse { get { return destresponse; } }
		public ReadOnlyCollection<TraceRtNode> Nodes { get { lock(this) { return nodes.AsReadOnly(); } } }

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		public TraceRt()
		{
			// Initialize
			nodes = new List<TraceRtNode>();
		}

		#endregion

		#region ================== Private Methods

		// This performs the trace
		private void TraceThread()
		{
			Random rnd = new Random();
			PingReply pingreply;
			IPHostEntry hostentry;
			bool routecomplete = false;
			Ping ping = new Ping();
			PingOptions pingoptions;
			IPAddress destip = null;
			
			try
			{
				// Resolve target address
				IPHostEntry destentry = Dns.GetHostEntry(destaddr);
				destip = destentry.AddressList[rnd.Next(destentry.AddressList.Length)];

				// Check if destination responds
				pingoptions = new PingOptions(maxhops, true);
				pingreply = ping.Send(destip, pingtimeout, pingdata, pingoptions);
				destresponse = (pingreply.Status == IPStatus.Success);
			}
			catch(Exception)
			{
				destresponse = false;
			}

			if(destip != null)
			{
				// Start tracing
				int routedepth = 1;
				do
				{
					DateTime starttime = DateTime.Now;

					// Send ping to destination
					// The routedepth will limit the number of hops the ping will take
					pingoptions = new PingOptions(routedepth, true);
					pingreply = ping.Send(destip, pingtimeout, pingdata, pingoptions);

					if(pingreply.Address != null)
					{
						if(pingreply.Status == IPStatus.Success)
						{
							// Destination reached
							routecomplete = true;
						}
						else
						{
							// Now we need to ping the address returned to figure out the RTT
							// Stupid how the Ping calss can't measure the time even when the TTL expired
							pingoptions = new PingOptions(maxhops, true);
							pingreply = ping.Send(pingreply.Address, pingtimeout, pingdata, pingoptions);
						}

						try
						{
							// Find the hostname for the address
							hostentry = Dns.GetHostEntry(pingreply.Address);
						}
						catch(Exception)
						{
							hostentry = null;
						}
					}
					else
					{
						hostentry = null;
					}

					// Store the node
					TraceRtNode n = new TraceRtNode(pingreply, hostentry);
					lock(this)
					{
						nodes.Add(n);
					}

					try
					{
						// Delay until next ping to prevent flooding the network
						DateTime endtime = DateTime.Now;
						TimeSpan deltatime = endtime - starttime;
						if((int)deltatime.TotalMilliseconds < flooddelay)
							Thread.Sleep(flooddelay - (int)deltatime.TotalMilliseconds);
					}
					catch(ThreadInterruptedException e)
					{
						return;
					}

					routedepth++;
				}
				while(!routecomplete && (routedepth <= maxhops));
			}
			
			// Done!
			this.destreached = routecomplete;
			this.tracethread = null;
			if(TraceComplete != null)
				TraceComplete(this, EventArgs.Empty);
		}

		#endregion

		#region ================== Public Methods

		// This starts a trace
		public void Trace(string destaddr)
		{
			if(IsTracing)
				throw new Exception("Trace already in progress.");

			this.destaddr = destaddr;
			this.nodes = new List<TraceRtNode>();
			this.destreached = false;
			
			this.tracethread = new Thread(TraceThread);
			this.tracethread.Name = "Trace Thread";
			this.tracethread.Start();
		}

		// This aborts a trace
		public void Abort()
		{
			if(IsTracing)
			{
				try
				{
					tracethread.Interrupt();
					tracethread.Join();
				}
				catch(Exception e) { }

				destreached = false;
				tracethread = null;
			}
		}

		#endregion
	}
}
