
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
	public class ObexTransferObject
	{
		#region ================== Variables
		
		private ObexBluetoothDevice target;
		private string filename;
		private string minetype;
		private byte[] data;
		
		#endregion

		#region ================== Properties

		public ObexBluetoothDevice Target { get { return target; } set { target = value; } }
		public string Filename { get { return filename; } set { filename = value; } }
		public string MimeType { get { return minetype; } set { minetype = value; } }
		public byte[] Data { get { return data; } }
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public ObexTransferObject(byte[] data)
		{
			this.data = new byte[data.Length];
			data.CopyTo(this.data, 0);
		}
		
		#endregion
	}
}
