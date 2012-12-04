
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
	public struct ObexBluetoothDevice
	{
		// Members
		public string name;
		public BluetoothAddress address;
		
		// Constructor
		public ObexBluetoothDevice(BluetoothDeviceInfo info)
		{
			this.name = info.DeviceName;
			this.address = info.DeviceAddress;
		}
		
		// Methods
		public override string ToString()
		{
			return name;
		}
	}
}
