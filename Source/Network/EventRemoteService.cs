#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	public class EventRemoteService : RemoteService
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		public delegate void ReceiveCommandDelegate(RemoteCommand cmd);
		public delegate void UpdateDelegate();

		public event ReceiveCommandDelegate ReceiveCommandEvent;
		public event UpdateDelegate UpdateEvent;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		public EventRemoteService(string name) : base(name)
		{
			// Initialize
		}

		#endregion

		#region ================== Private Methods

		#endregion

		#region ================== Public Methods

		// Reqular update on network thread
		public override void UpdateNetworkThread()
		{
			// Raise event
			if(UpdateEvent != null)
				UpdateEvent();
		}
		
		// When a command is received
		public override void ReceiveCommand(RemoteCommand cmd)
		{
			// Raise event
			if(ReceiveCommandEvent != null)
				ReceiveCommandEvent(cmd);
		}
		
		#endregion
	}
}
