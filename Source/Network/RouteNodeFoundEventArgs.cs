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
	public class RouteNodeFoundEventArgs : EventArgs
	{
		private TraceRtNode node;

		// Property
		public TraceRtNode Node { get { return node; } }
		
		// Constructor
		public RouteNodeFoundEventArgs(TraceRtNode node)
		{
			this.node = node;
		}
	}
}
