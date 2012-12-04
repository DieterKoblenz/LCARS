
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
	public sealed class DataTableRow
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private Dictionary<string, object> cells;
		
		#endregion

		#region ================== Properties

		public object this[string name] { get { return cells[name]; } }
		
		#endregion

		#region ================== Constructor

		// Constructor
		public DataTableRow(IDataRecord r)
		{
			cells = new Dictionary<string, object>(r.FieldCount);
			for(int i = 0; i < r.FieldCount; i++)
			{
				cells.Add(r.GetName(i), r.GetValue(i));
			}
		}

		#endregion

		#region ================== Private Methods

		#endregion

		#region ================== Public Methods

		public int GetInt(string name) { return (int)cells[name]; }
		public string GetString(string name) { return (string)cells[name]; }
		public double GetDouble(string name) { return (double)cells[name]; }
		public bool GetBool(string name) { return (bool)cells[name]; }
		public long GetLong(string name) { return (long)cells[name]; }
		public short GetShort(string name) { return (short)cells[name]; }
		public T Get<T>(string name) { return (T)cells[name]; }

		#endregion
	}
}
