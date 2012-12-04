
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
	public struct AgendaItem
	{
		public long id;
		public ColorIndex color;
		public string description;
		public DateTime originstartdate;
		public DateTime startdate;
		public TimeSpan duration;
		public bool alarm;
		public DateTime alarmdate;		// Only needed when alarm is true
		public AgendaItemRecur recur;
		public int recursions;
		
		// String representation
		public override string ToString()
		{
			if(recur == AgendaItemRecur.Annually)
				return description + " - " + recursions;
			else
				return description;
		}
		
		// This updates the database with this entry
		public bool SqlUpdate()
		{
			if(id <= 0)
				throw new Exception("Item must have an ID assigned by the database!");
			
			string q = "UPDATE `agenda` SET " +
						   "`color` = '" + (int)color + "', " +
						   "`description` = '" + description + "', " +
						   "`startdate` = '" + startdate.Ticks + "', " +
						   "`duration` = '" + duration.Ticks + "', " +
						   "`alarm` = '" + Tools.Bool2Int(alarm) + "', " +
						   "`alarmdate` = '" + alarmdate.Ticks + "', " +
						   "`recur` = '" + (int)recur + "', " +
						   "`dayofweek` = '" + startdate.DayOfWeek + "', " +
						   "`dayofmonth` = '" + startdate.Day + "', " +
						   "`month` = '" + startdate.Month + "' " +
					   "WHERE `id` = '" + id + "' LIMIT 1;";

			General.DB.ConnectSafe();
			int result = General.DB.Update(q);
			General.DB.Disconnect();
			return (result == 1);
		}

		// This inserts this entry into the database and sets the id
		public bool SqlInsert()
		{
			string q = "INSERT INTO `agenda` " +
							"(`color`, `description`, `startdate`, `duration`, `alarm`, `alarmdate`, " +
						    "`recur`, `dayofweek`, `dayofmonth`, `month`) " +
					   "VALUES " +
							"('" + (int)color + "', '" + description + "', '" + startdate.Ticks + "', " +
							"'" + duration.Ticks + "', '" + Tools.Bool2Int(alarm) + "', '" + alarmdate.Ticks + "', " +
							"'" + (int)recur + "', '" + startdate.DayOfWeek + "', '" + startdate.Day + "', '" + startdate.Month + "');";

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
			if(id <= 0)
				throw new Exception("Item must have an ID assigned by the database!");

			string q = "DELETE FROM `agenda` WHERE `id` = '" + id + "' LIMIT 1;";

			General.DB.ConnectSafe();
			int result = General.DB.Update(q);
			General.DB.Disconnect();
			return (result == 1);
		}

		// This reads from a data row
		public static AgendaItem FromDataRow(DataTableRow r)
		{
			AgendaItem i = new AgendaItem();
			i.id = r.GetLong("id");
			i.color = (ColorIndex)r.GetInt("color");
			i.description = r.GetString("description");
			i.startdate = new DateTime(r.GetLong("startdate"));
			i.originstartdate = i.startdate;
			i.duration = new TimeSpan(r.GetLong("duration"));
			i.alarm = r.GetBool("alarm");
			i.alarmdate = new DateTime(r.GetLong("alarmdate"));
			i.recur = (AgendaItemRecur)r.GetInt("recur");
			i.recursions = 0;
			return i;
		}
	}
}

