#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	public class TraceRtNode
	{
		#region ================== Variables

		private string hostname;
		private IPAddress hostaddr;
		private int roundtriptime;
		private IPStatus status;
		
		#endregion

		#region ================== Properties

		public string HostName { get { return hostname; } }
		public IPAddress HostAddress { get { return hostaddr; } }
		public int RoundTripTime { get { return roundtriptime; } }
		public IPStatus Status { get { return status; } }

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		public TraceRtNode(PingReply ping, IPHostEntry host)
		{
			hostaddr = ping.Address;
			
			status = ping.Status;
			
			if(host != null)
				hostname = host.HostName;
			else
				hostname = "";
			
			roundtriptime = (int)ping.RoundtripTime;
		}

		#endregion
		
		#region ================== Methods

		// String representation
		public override string ToString()
		{
			if(!string.IsNullOrEmpty(hostname))
				return hostname;
			else if(hostaddr != null)
				return hostaddr.ToString();
			else
				return "(" + status + ")";
		}

		#endregion
	}
}
