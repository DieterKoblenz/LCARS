#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	public abstract class RemoteService
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private string name;

		#endregion

		#region ================== Properties

		public string Name { get { return name; } }

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		protected RemoteService(string name)
		{
			// Initialize
			this.name = name.ToUpperInvariant();
		}

		#endregion

		#region ================== Private Methods

		#endregion

		#region ================== Public Methods
		
		// Updates called from the network thread
		public virtual void UpdateNetworkThread()
		{
		}

		// Receiving a command!
		// The service should implement this to handle the command.
		public virtual void ReceiveCommand(RemoteCommand cmd)
		{
		}

		// This sends a command!
		public void SendCommand(RemoteCommand cmd)
		{
			cmd.Client.SendCommand(cmd);
		}
		
		#endregion
	}
}
