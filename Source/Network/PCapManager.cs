
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Threading;
using SharpPcap;

#endregion

namespace CodeImp.Gluon
{
	public sealed class PCapManager
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		PcapDevice trackdevice;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public PCapManager()
		{
		}

		// Disposer
		public void Dispose()
		{
			if(trackdevice != null)
			{
				// Stop capturing packets
				try { trackdevice.StopCapture(); } catch(Exception) { };
				try { trackdevice.Close(); } catch(Exception) { };
				trackdevice = null;
			}
		}

		#endregion

		#region ================== Private Methods

		// This handles every incoming packet
		private void PacketHandler(object sender, PcapCaptureEventArgs e)
		{
		}

		#endregion

		#region ================== Public Methods
		
		// This starts the capturing
		public void Start()
		{
			// DISABLED
			return;
			
			List<PcapDevice> devices = Pcap.GetAllDevices();
			
			if(devices.Count < 1)
			{
				General.Fail("No network devices connected.");
				return;
			}

			// Find the device we want to track traffic on
			foreach(PcapDevice dev in devices)
			{
				// Just pick any device that has an address
				if(dev.Addresses.Count > 0)
					trackdevice = dev;
			}

			string addrstr = "";
			for(int i = 0; i < trackdevice.Addresses.Count; i++)
			{
				if(trackdevice.Addresses[i].Addr.type != SharpPcap.Containers.Sockaddr.Type.HARDWARE)
				{
					if(addrstr.Length > 0) addrstr += ", ";
					addrstr += "'" + trackdevice.Addresses[i].Addr.ipAddress + "'";
				}
			}
			General.WriteLogLine("Tracking network on device '" + trackdevice.Description.Trim() + "' with address " + addrstr);
			
			// Start capturing packets
			trackdevice.Open(true, 1000);
			trackdevice.OnPacketArrival += PacketHandler;
			trackdevice.StartCapture();
		}
		
		#endregion
	}
}