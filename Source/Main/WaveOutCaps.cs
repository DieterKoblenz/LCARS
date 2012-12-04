
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
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct WaveOutCaps
	{
		private const int MAXPNAMELEN = 32;
		
		public short wMid;
		public short wPid;
		public int vDriverVersion;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
		public string szPname;
		public int dwFormats;
		public short wChannels;
		public short wReserved1;
		public int dwSupport;
	}
}
