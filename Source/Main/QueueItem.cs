
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
using MySql.Data.MySqlClient;

#endregion

namespace CodeImp.Gluon
{
	/// <summary>
	/// A queue item is a single item that can be transferred to
	/// another location. The filename allows grouping of items
	/// that the manager can group together for a specific device
	/// (such as agenda items over obex).
	/// </summary>
	public sealed class QueueItem
	{
		#region ================== Variables

		private long id;
		private int queue;
		private string filename;
		private string minetype;
		private byte[] data;

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public QueueItem()
		{
		}

		#endregion

		#region ================== Private Methods

		#endregion

		#region ================== Public Methods

		#endregion
	}
}