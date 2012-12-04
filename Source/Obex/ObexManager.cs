
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
using InTheHand.Net;
using InTheHand.Net.Mime;
using InTheHand.Net.Sockets;

#endregion

namespace CodeImp.Gluon
{
	public sealed class ObexManager
	{
		#region ================== Constants
		
		#endregion
		
		#region ================== Variables
		
		// Found devices
		private ObexBluetoothDevice[] devicesinfo;

		// Objects to transfer
		private Queue<ObexTransferObject> transferobjects;
		
		// Processing
		private Thread updatethread;
		private Thread sendthread;
		private bool hasobjectaccess;
		
		#endregion
		
		#region ================== Properties
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public ObexManager()
		{
			transferobjects = new Queue<ObexTransferObject>();
			devicesinfo = new ObexBluetoothDevice[0];
			hasobjectaccess = false;
		}

		public void Dispose()
		{
			if(updatethread != null)
			{
				updatethread.Interrupt();
				updatethread.Join();
				updatethread = null;
			}
		}
		
		#endregion
		
		#region ================== Private Methods
		
		// This finds and updates the available bluetooth devices
		private void UpdateThread()
		{
			BluetoothClient cli;
			
			while(true)
			{
				// This is allowed to fail when there are no bluetooth devices connected
				try { cli = new BluetoothClient(); }
				catch(ThreadInterruptedException)
				{
					return;
				}
				catch(Exception e)
				{
					General.WriteLogLine(e.GetType().Name + " while updating bluetooth manager: " + e.Message + "\r\n" + e.StackTrace);
					return;
				}

				List<ObexBluetoothDevice> newdevices = null;
				
				try
				{
					cli.Client.ReceiveTimeout = 1000;
					cli.Client.SendTimeout = 1000;
					BluetoothDeviceInfo[] peers = cli.DiscoverDevices(ObexTransferDisplayPanel.NUM_DEVICE_BUTTONS, true, true, true);
					string p = "Found " + peers.Length + " peers: ";
					int index = 0;
					newdevices = new List<ObexBluetoothDevice>();
					foreach(BluetoothDeviceInfo bdi in peers)
					{
						// Make sure the information on this device is accurate!
						string addrname = bdi.DeviceName.Replace(":", "");
						if(addrname == bdi.DeviceAddress.ToString())
						{
							bdi.Refresh();
							bdi.Update();
						}

						p += bdi.DeviceName + " ";

						// Make info struct
						newdevices.Add(new ObexBluetoothDevice(bdi));
					}

					General.WriteLogLine(p);
				}
				catch(ThreadInterruptedException)
				{
					return;
				}
				#if !DEBUG
				catch(NotImplementedException e)
				{
					// Ignore this, it's probably due to outdated code in the Bluetooth classes made by 'In The Hand'
					//General.WriteLogLine(e.GetType().Name + " while updating bluetooth devices: " + e.Message);
				}
				#endif
				catch(Exception e)
				{
					General.Fail(e, "while updating bluetooth devices");
				}

				// Make the new devices array on success
				if(newdevices != null)
				{
					lock(this)
					{
						devicesinfo = newdevices.ToArray();
					}
				}

				try
				{
					Queue<ObexTransferObject> dotransfers = new Queue<ObexTransferObject>();
					lock(transferobjects)
					{
						while(transferobjects.Count > 0)
							dotransfers.Enqueue(transferobjects.Dequeue());
					}
					
					while(dotransfers.Count > 0)
					{
						ObexTransferObject obj = dotransfers.Peek();
						Transfer(obj);
						dotransfers.Dequeue();
					}
				}
				catch(ThreadInterruptedException)
				{
					return;
				}
				#if !DEBUG
				catch(NotImplementedException e)
				{
					// Ignore this, it's probably due to outdated code in the Bluetooth classes made by 'In The Hand'
					//General.WriteLogLine(e.GetType().Name + " while updating bluetooth devices: " + e.Message);
				}
				#endif
				catch(Exception e)
				{
					General.Fail(e, "while transferring bluetooth data");
				}

				try { Thread.Sleep(300); }
				catch(ThreadInterruptedException)
				{
					return;
				}
			}
		}
		
		private void Transfer(ObexTransferObject obj)
		{
			ObexWebResponse rsp = null;
			ObexWebRequest req;
			
			try
			{
				Uri uri = new Uri("obex://" + obj.Target.address.ToString() + "/" + obj.Filename);
				req = new ObexWebRequest(uri);
				req.Timeout = 15000;
				using(Stream content = req.GetRequestStream())
				{
					content.Write(obj.Data, 0, obj.Data.Length);
					content.Flush();
					req.ContentLength = obj.Data.Length;
					req.ContentType = obj.MimeType;
				}
				rsp = (req.GetResponse() as ObexWebResponse);
			}
			catch(Exception e)
			{
				General.WriteLogLine(e.GetType().Name + " while transferring '" + obj.Filename + "' data to " + obj.Target.address.ToString() + ": " + e.Message);
			}
			
			if((rsp != null) && (rsp.StatusCode != ObexStatusCode.OK))
				General.WriteLogLine("Received response code: " + rsp.StatusCode + " while transferring '" + obj.Filename + "' data to " + obj.Target.address.ToString());

			if(rsp != null)
				rsp.Close();
		}
		
		#endregion
		
		#region ================== Public Methods

		// This starts the update thread
		public void Initialize()
		{
			// Start update
			updatethread = new Thread(new ThreadStart(UpdateThread));
			updatethread.Name = "Obex Bluetooth Update";
			updatethread.Priority = ThreadPriority.Lowest;
			updatethread.Start();
		}
		
		// Get bluetooth devices info. Returns false when access is locked. (during updates)
		public bool GetBluetoothDevices(ref ObexBluetoothDevice[] devices)
		{
			lock(this)
			{
				devices = (ObexBluetoothDevice[])devicesinfo.Clone();
			}
			return true;
		}

		// This sends an object to a device
		public bool SendObject(ObexTransferObject obj)
		{
			lock(transferobjects)
			{
				transferobjects.Enqueue(obj);
			}
			return true;
		}
		
		#endregion
	}
}