
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

#endregion

namespace CodeImp.Gluon
{
	public partial class RemoteServiceControl : Component
	{
		#region ================== Events

		public event EventRemoteService.ReceiveCommandDelegate ReceiveCommand;

		#endregion

		#region ================== Variables

		private ContainerControl container;
		private string servicename;
		private EventRemoteService service;
		private Queue<RemoteCommand> sendcommands;
		
		#endregion
		
		#region ================== Properties

		public string ServiceName { get { return servicename; } set { servicename = value; RegisterService(); } }
		public ContainerControl ContainerControl { get { return container; } set { container = value; } }

		// This, along with the ContainerControl property, is so for
		// the designer so that we can find our parent container
		public override ISite Site
		{
			get { return base.Site; }
			set
			{
				base.Site = value;
				if(value == null)
					return;
				
				IDesignerHost host = value.GetService(typeof(IDesignerHost)) as IDesignerHost;
				if(host != null)
				{
					IComponent componentHost = host.RootComponent;
					if(componentHost is ContainerControl)
						ContainerControl = componentHost as ContainerControl;
				}
			}
		}
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public RemoteServiceControl()
		{
			InitializeComponent();
			sendcommands = new Queue<RemoteCommand>();
		}

		#endregion
		
		#region ================== Methods

		// This registers the service
		private void RegisterService()
		{
			if(General.AppRunning)
			{
				if(service != null)
					General.Remote.UnregisterService(service);

				service = new EventRemoteService(servicename);
				service.ReceiveCommandEvent += service_ReceiveCommandEvent;
				service.UpdateEvent += service_UpdateEvent;

				General.Remote.RegisterService(service);
			}
		}

		// This queues a command for sending
		public void SendCommand(RemoteCommand cmd)
		{
			lock(sendcommands)
			{
				sendcommands.Enqueue(cmd);
			}
		}
		
		#endregion
		
		#region ================== Events

		// Internal update on network thread
		private void service_UpdateEvent()
		{
			lock(sendcommands)
			{
				// Send queued commands
				while(sendcommands.Count > 0)
				{
					RemoteCommand cmd = sendcommands.Dequeue();
					service.SendCommand(cmd);
				}
			}
		}
		
		// Internal receive command event
		private void service_ReceiveCommandEvent(RemoteCommand cmd)
		{
			if(container.InvokeRequired)
			{
				container.Invoke(new EventRemoteService.ReceiveCommandDelegate(service_ReceiveCommandEvent), cmd);
			}
			else
			{
				if(ReceiveCommand != null)
					ReceiveCommand(cmd);
			}
		}
		
		#endregion
	}
}
