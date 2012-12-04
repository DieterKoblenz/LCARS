
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
	public sealed class DataTable : IEnumerable<DataTableRow>, IList<DataTableRow>, ICollection<DataTableRow>
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private List<DataTableRow> rows;
		
		#endregion

		#region ================== Properties

		public DataTableRow this[int index] { get { return rows[index]; } set { throw new NotSupportedException(); } }
		public int Count { get { return rows.Count; } }
		public bool IsReadOnly { get { return true; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public DataTable(IDataReader r)
		{
			rows = new List<DataTableRow>();
			while(r.Read())
			{
				rows.Add(new DataTableRow(r));
			}
		}

		#endregion

		#region ================== Private Methods

		#endregion

		#region ================== Public Methods

		IEnumerator<DataTableRow> IEnumerable<DataTableRow>.GetEnumerator() { return rows.GetEnumerator(); }
		IEnumerator IEnumerable.GetEnumerator() { return rows.GetEnumerator(); }
		public int IndexOf(DataTableRow item) { return rows.IndexOf(item); }
		public void Insert(int index, DataTableRow item) { throw new NotSupportedException(); }
		public void RemoveAt(int index) { throw new NotSupportedException(); }
		public void Add(DataTableRow item) { throw new NotSupportedException(); }
		public void Clear() { throw new NotSupportedException(); }
		public bool Contains(DataTableRow item) { return rows.Contains(item); }
		public void CopyTo(DataTableRow[] array, int arrayIndex) { rows.CopyTo(array, arrayIndex); }
		public bool Remove(DataTableRow item) { throw new NotSupportedException(); }
		
		#endregion
	}
}
