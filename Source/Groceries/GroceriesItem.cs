
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
	public struct GroceriesItem
	{
		public string name;
		public long count;
		public int list;

		// This updates the database with this entry
		public bool SqlUpdateOrInsert(bool increasecount)
		{
			string q = "INSERT INTO `groceries` " +
							"(`name`, `list`, `count`) " +
					   "VALUES " +
							"('" + name + "', '" + list + "', '" + count + "') " +
					   "ON DUPLICATE KEY UPDATE `count` = '" + count + "';";

			General.DB.ConnectSafe();
			int result = General.DB.Update(q);
			bool success = (result > 0);
			
			// Update the count
			if(success && increasecount)
				success = SqlUpdateOrInsertCount();

			General.DB.Disconnect();
			return success;
		}

		// This deletes this entry from the database
		public bool SqlDelete()
		{
			string q = "DELETE FROM `groceries` WHERE `name` = '" + name + "' AND `list` = '" + list + "' LIMIT 1;";

			General.DB.ConnectSafe();
			int result = General.DB.Update(q);
			General.DB.Disconnect();
			return (result == 1);
		}
		
		// This updates the database with this entry
		// Expects the database to be connected!
		private bool SqlUpdateOrInsertCount()
		{
			string q = "INSERT INTO `groceries_count` " +
							"(`name`, `count`, `lastused`) " +
					   "VALUES " +
							"('" + name + "', '1', '" + DateTime.Now.Ticks + "') " +
					   "ON DUPLICATE KEY UPDATE `count` = `count` + '1', `lastused` = '" + DateTime.Now.Ticks + "';";

			int result = General.DB.Update(q);
			return (result > 0);
		}

		// This reads from a data row
		public static GroceriesItem FromDataRow(DataTableRow r)
		{
			GroceriesItem i = new GroceriesItem();
			i.name = r.GetString("name");
			i.count = r.GetLong("count");
			i.list = r.GetInt("list");
			return i;
		}

		// String representation
		public override string ToString()
		{
			return name;
		}
	}
}

