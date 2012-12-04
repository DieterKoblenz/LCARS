
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Media;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

#endregion

namespace CodeImp.Gluon
{
	public class NotesManager
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public NotesManager()
		{
		}

		// Disposer
		public void Dispose()
		{
		}

		#endregion

		#region ================== Methods

		// This returns all items in the main list
		public List<NoteItem> GetAllItems()
		{
			return SelectItems("SELECT * FROM `notes` WHERE 1 ORDER BY `id`;");
		}

		// This returns items
		private List<NoteItem> SelectItems(string sql)
		{
			General.DB.ConnectSafe();
			
			DataTable t = General.DB.Query(sql);
			if(t != null)
			{
				List<NoteItem> list = new List<NoteItem>(t.Count);

				foreach(DataTableRow r in t)
					list.Add(NoteItem.FromDataRow(r));

				General.DB.Disconnect();
				return list;
			}
			else
			{
				// Failed!
				General.DB.Disconnect();
				return null;
			}
		}

		// This removes empty notes
		public bool DeleteEmptyNotes()
		{
			string sql = "DELETE FROM `notes` WHERE `note` = ''";
			General.DB.ConnectSafe();
			int result = General.DB.Update(sql);
			General.DB.Disconnect();
			return (result > 0);
		}

		#endregion
	}
}
