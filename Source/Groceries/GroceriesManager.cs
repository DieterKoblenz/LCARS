
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
	public class GroceriesManager
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public GroceriesManager()
		{
		}

		// Disposer
		public void Dispose()
		{
		}

		#endregion

		#region ================== Methods

		// This deletes all items in the main list
		public bool DeleteAllItems(int list)
		{
			General.DB.ConnectSafe();
			int result = General.DB.Update("DELETE FROM `groceries` WHERE `list` = '" + list + "';");
			General.DB.Disconnect();
			return (result > -1);
		}

		// This returns all items in the main list
		public List<GroceriesItem> GetAllItems(int list)
		{
			return SelectItems("SELECT * FROM `groceries` WHERE `list` = '" + list + "' ORDER BY `name`;");
		}

		// This returns all most used items
		public List<GroceriesItem> GetMostUsedItems()
		{
			return SelectItems("SELECT * FROM `groceries_count` WHERE 1 ORDER BY `count` DESC;");
		}

		// This returns all recently used items
		public List<GroceriesItem> GetRecentlyUsedItems()
		{
			return SelectItems("SELECT * FROM `groceries_count` WHERE 1 ORDER BY `lastused` DESC;");
		}

		// This returns all items by sql query
		private List<GroceriesItem> SelectItems(string sql)
		{
			General.DB.ConnectSafe();
			
			DataTable t = General.DB.Query(sql);
			if(t != null)
			{
				List<GroceriesItem> list = new List<GroceriesItem>(t.Count);

				foreach(DataTableRow r in t)
					list.Add(GroceriesItem.FromDataRow(r));

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

		// This adds or updates an item in the main list
		public void AddOrUpdateItem(GroceriesItem item, bool increasecount)
		{
			item.SqlUpdateOrInsert(increasecount);
		}
		
		#endregion
	}
}
