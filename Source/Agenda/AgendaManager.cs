
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Media;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

#endregion

namespace CodeImp.Gluon
{
	public class AgendaManager
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public AgendaManager()
		{
		}
		
		#endregion

		#region ================== Methods
		
		// This returns all agenda items in the given range
		// Returns null on database error
		public List<AgendaItem> GetItems(DateTime from, DateTime to)
		{
			TimeSpan span = to - from;
			General.DB.ConnectSafe();
			
			// Make the WHERE clause for weekly recurring items
			string ww = "(`recur` = '" + (int)AgendaItemRecur.Weekly + "')";
			if(span.Days < 7)
			{
				// Add limitations for the days of the weeks between 'from' and 'to'
				if(to.DayOfWeek >= from.DayOfWeek)
				{
					// Range within a single week
					ww += " AND (`dayofweek` >= '" + from.DayOfWeek + "' AND `dayofweek` <= '" + to.DayOfWeek + "')";
				}
				else
				{
					// Range crossing into the next week
					ww += " AND (`dayofweek` >= '" + to.DayOfWeek + "' OR `dayofweek` <= '" + from.DayOfWeek + "')";
				}
			}

			// Make the WHERE clause for monthly recurring items
			string wm = "(`recur` = '" + (int)AgendaItemRecur.Monthly + "')";
			if(span.Days < 31)
			{
				// Add limitations for the days of the month between 'from' and 'to'
				if(to.Day >= from.Day)
				{
					// Range within a single month
					wm += " AND (`dayofmonth` >= '" + from.Day + "' AND `dayofmonth` <= '" + to.Day + "')";
				}
				else
				{
					// Range crossing into the next month
					wm += " AND (`dayofmonth` >= '" + to.Day + "' OR `dayofmonth` <= '" + from.Day + "')";
				}
			}

			// Make the WHERE clause for annually recurring items
			string wa = "(`recur` = '" + (int)AgendaItemRecur.Annually + "')";
			if(span.Days < 366)
			{
				// Add limitations for the months of the year between 'from' and 'to'
				if(to.Month >= from.Month)
				{
					// Range within a single year
					wa += " AND (`month` >= '" + from.Month + "' AND `month` <= '" + to.Month + "')";
				}
				else
				{
					// Range crossing into the next year
					wa += " AND (`month` >= '" + to.Month + "' OR `month` <= '" + from.Month + "')";
				}
				
				// Shorter than a month? Add limitations for the day of the month.
				if(span.Days < 31)
				{
					// Add limitations for the days of the month between 'from' and 'to'
					if(to.Day >= from.Day)
					{
						// Range within a single month
						wa += " AND (`dayofmonth` >= '" + from.Day + "' AND `dayofmonth` <= '" + to.Day + "')";
					}
					else
					{
						// Range crossing into the next month
						wa += " AND (`dayofmonth` >= '" + to.Day + "' OR `dayofmonth` <= '" + from.Day + "')";
					}
				}
			}
			
			
			string q = "SELECT * FROM `agenda` WHERE " +
							"((`startdate` + `duration`) >= '" + from.Ticks + "') AND " +
							"(`startdate` <= '" + to.Ticks + "') AND ((`recur` = '0') OR (" + ww + ") OR (" + wm + ") OR (" + wa + "));";

			DataTable t = General.DB.Query(q);
			if(t != null)
			{
				List<AgendaItem> list = new List<AgendaItem>(t.Count);

				// Make the full list (expand recurring items)
				foreach(DataTableRow r in t)
				{
					AgendaItem item = AgendaItem.FromDataRow(r);
					if(item.recur != AgendaItemRecur.None)
						AddRecurringItem(list, item, from, to);
					else
						list.Add(item);
				}

				// Sort by startdate
				AgendaItemSorter sorter = new AgendaItemSorter();
				list.Sort(sorter);

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

		// This adds a recurring item to the list as many times as needed (and with proper dates)
		private void AddRecurringItem(ICollection<AgendaItem> list, AgendaItem item, DateTime from, DateTime to)
		{
			GregorianCalendar calendar = new GregorianCalendar();
			TimeSpan alarmoffset = item.startdate - item.alarmdate;
			DateTime d = from;

			// Advance d to the first occurence of the item within this time period
			switch(item.recur)
			{
				case AgendaItemRecur.Weekly:
					if((int)d.DayOfWeek < (int)item.startdate.DayOfWeek)
						d = d.AddDays((int)item.startdate.DayOfWeek - (int)d.DayOfWeek);
					else if((int)d.DayOfWeek > (int)item.startdate.DayOfWeek)
						d = d.AddDays((7 - (int)d.DayOfWeek) + (int)item.startdate.DayOfWeek);
					
					break;

				case AgendaItemRecur.Monthly:
					if(d.Day < item.startdate.Day)
						d = d.AddDays(item.startdate.Day - d.Day);
					else if(d.Day > item.startdate.Day)
						d = d.AddDays((calendar.GetDaysInMonth(d.Year, d.Month) - d.Day) + item.startdate.Day);
					
					break;

				case AgendaItemRecur.Annually:
					// First advance to the correct day in the month
					// so that we don't skip over the day when advancing by months
					if(d.Day < item.startdate.Day)
						d = d.AddDays(item.startdate.Day - d.Day);
					else if(d.Day > item.startdate.Day)
						d = d.AddDays((calendar.GetDaysInMonth(d.Year, d.Month) - d.Day) + item.startdate.Day);

					// Now advance by months
					if(d.Month < item.startdate.Month)
						d = d.AddMonths(item.startdate.Month - d.Month);
					else if(d.Month > item.startdate.Month)
						d = d.AddMonths((12 - d.Month) + item.startdate.Month);
					
					break;
			}
			
			// We check how many times we can repeat the item within the
			// given timespan and add the item repeatedly
			while(d.Ticks <= to.Ticks)
			{
				// Add item with proper dates
				AgendaItem newitem = item;
				newitem.startdate = d.AddHours(item.startdate.Hour).AddMinutes(item.startdate.Minute);
				newitem.alarmdate = newitem.startdate.Subtract(alarmoffset);
				TimeSpan span = newitem.startdate - newitem.originstartdate;
				switch(item.recur)
				{
					case AgendaItemRecur.Weekly: newitem.recursions = (int)Math.Round(span.TotalDays / 7.0d); break;
					case AgendaItemRecur.Monthly: newitem.recursions = (int)Math.Round(span.TotalDays / 30.4375d); break;
					case AgendaItemRecur.Annually: newitem.recursions = (int)Math.Round(span.TotalDays / 365.25d); break;
				}
				list.Add(newitem);
				
				// Advance date to the next date when the item recurs
				switch(item.recur)
				{
					case AgendaItemRecur.Weekly:
						d = d.AddDays(7);
						break;
						
					case AgendaItemRecur.Monthly:
						//d = d.AddDays(calendar.GetDaysInMonth(d.Year, d.Month));
						d = d.AddMonths(1);
						break;
						
					case AgendaItemRecur.Annually:
						d = d.AddYears(1);
						break;
				}
			}
		}
		
		// This adds an agenda item or updates an existing one
		public bool AddOrUpdateItem(AgendaItem i)
		{
			if(i.id <= 0)
				return i.SqlInsert();
			else
				return i.SqlUpdate();
		}
		
		// This removes an agenda item
		public bool RemoveItem(AgendaItem i)
		{
			return i.SqlDelete();
		}
		
		#endregion
	}
}
