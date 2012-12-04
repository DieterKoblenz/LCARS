
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

#endregion

namespace CodeImp.Gluon
{
	public struct NoteItem
	{
		public long id;
		public string note;

		// This updates the database with this entry
		public bool SqlInsert()
		{
			string q = "INSERT INTO `notes` " +
							"(`note`) " +
					   "VALUES " +
							"('" + note + "');";

			General.DB.ConnectSafe();
			int result = General.DB.Update(q);
			General.DB.Disconnect();
			
			// Query was successful when 1 row was modified
			if(result == 1)
			{
				// Get the ID
				id = General.DB.LastInsertID;
				return true;
			}
			else
			{
				// One row should have been inserted!
				return false;
			}
		}

		// This deletes this entry from the database
		public bool SqlDelete()
		{
			string q = "DELETE FROM `notes` WHERE `id` = '" + id + "' LIMIT 1;";

			General.DB.ConnectSafe();
			int result = General.DB.Update(q);
			General.DB.Disconnect();
			return (result == 1);
		}

		// This updates the database with this entry
		public bool SqlUpdate()
		{
			string q = "UPDATE `notes` SET " +
							"`note` = '" + note + "' " +
					   "WHERE `id` = '" + id + "' LIMIT 1;";

			General.DB.ConnectSafe();
			int result = General.DB.Update(q);
			General.DB.Disconnect();
			return (result > 0);
		}

		// This updates the database with this entry
		public static bool SqlSwap(NoteItem first, NoteItem second)
		{
			string q;
			int result;

			General.DB.ConnectSafe();
			// TODO: Add locking mechanism so that this is perfored as a single operation
			
			q = "UPDATE `notes` SET " +
						"`id` = '-1' " +
				"WHERE `id` = '" + first.id + "' LIMIT 1;";

			result = General.DB.Update(q);
			if(result <= 0) return false;

			q = "UPDATE `notes` SET " +
						"`id` = '" + first.id + "' " +
				"WHERE `id` = '" + second.id + "' LIMIT 1;";

			result = General.DB.Update(q);
			if(result <= 0) return false;

			q = "UPDATE `notes` SET " +
						"`id` = '" + second.id + "' " +
				"WHERE `id` = '-1' LIMIT 1;";

			result = General.DB.Update(q);
			if(result <= 0) return false;

			General.DB.Disconnect();
			return true;
		}

		// This reads from a data row
		public static NoteItem FromDataRow(DataTableRow r)
		{
			NoteItem i = new NoteItem();
			i.id = r.GetLong("id");
			i.note = r.GetString("note");
			return i;
		}

		// String representation
		public override string ToString()
		{
			return note;
		}
	}
}

