
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

#endregion

namespace CodeImp.Gluon
{
	public partial class AgendaDisplayPanel : DisplayPanel
	{
		#region ================== Variables
		
		// Day displays
		private AgendaDayDisplay[] daydisplays;
		
		// Current view
		private DateTime weekstart;
		private DateTime weekend;
		
		// Editors
		private AgendaEditDisplayPanel dayeditor;
		private AgendaItemDisplayPanel itemeditor;
		
		#endregion
		
		#region ================== Properties

		public AgendaEditDisplayPanel DayEditor { get { return dayeditor; } set { dayeditor = value; } }
		public AgendaItemDisplayPanel ItemEditor { get { return itemeditor; } set { itemeditor = value; } }

		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public AgendaDisplayPanel()
		{
			InitializeComponent();

			// Make array from day displays
			daydisplays = new AgendaDayDisplay[7];
			daydisplays[0] = day1;
			daydisplays[1] = day2;
			daydisplays[2] = day3;
			daydisplays[3] = day4;
			daydisplays[4] = day5;
			daydisplays[5] = day6;
			daydisplays[6] = day7;
		}
		
		#endregion
		
		#region ================== Methods
		
		// This sets up the days for the given week
		public void SetupWeek(DateTime week)
		{
			GregorianCalendar calendar = new GregorianCalendar();
			weekstart = new DateTime(week.Year, week.Month, week.Day);
			weekstart = weekstart.AddDays(-Tools.DayOfWeekInt(week.DayOfWeek));
			weekend = new DateTime(weekstart.Year, weekstart.Month, weekstart.Day);
			weekend = weekend.AddDays(7);
			weekend = weekend.AddTicks(-1);
			
			// Setup interface
			yearlabel.Text = weekstart.Year.ToString();
			monthlabel.Text = weekstart.ToString("MMMM");
			weeklabel.Text = calendar.GetWeekOfYear(weekstart, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();
			
			// Fetch the agenda items for this week
			List<AgendaItem> items = General.Agenda.GetItems(weekstart, weekend);
			
			// Go for all days in the week
			for(int wd = 0; wd < 7; wd++)
			{
				// Determine begin and end date for this day
				DateTime dstart = new DateTime(weekstart.Year, weekstart.Month, weekstart.Day);
				dstart = dstart.AddDays(wd);
				DateTime dend = new DateTime(dstart.Year, dstart.Month, dstart.Day);
				dend = dend.AddDays(1);
				dend = dend.AddTicks(-1);
				
				// Find the items for this day
				List<AgendaItem> dayitems = new List<AgendaItem>();
				AgendaItemSorter sorter = new AgendaItemSorter();
				foreach(AgendaItem i in items)
					if(((i.startdate + i.duration) >= dstart) && (i.startdate <= dend))
						dayitems.Add(i);
				
				dayitems.Sort(sorter);
				
				// Setup control
				daydisplays[wd].SetupDate(dstart);
				daydisplays[wd].SetupItems(dayitems, dstart);
				daydisplays[wd].Visible = false;
			}

			showtimer.Start();
		}

		// This refreshes
		private void RefreshWeek()
		{
			SetupWeek(weekstart);
		}
		
		#endregion
		
		#region ================== Events

		// When Shown
		public override void OnShow()
		{
			base.OnShow();

			// Coming from overview?
			if((string.Compare(General.MainWindow.CurrentPanelTag, "overview", true) == 0) ||
			   (string.Compare(General.MainWindow.CurrentPanelTag, "accessport", true) == 0))
			{
				// Set up for current week
				SetupWeek(DateTime.Now);
			}
			else
			{
				// Refresh current week
				RefreshWeek();
			}
		}
		
		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			showtimer.Stop();
			General.MainWindow.ShowTaggedPanel("overview");
		}
		
		// Next week
		private void nextweekbutton_Click(object sender, EventArgs e)
		{
			DateTime newdate = weekstart.AddDays(7);
			SetupWeek(newdate);
		}
		
		// Next month
		private void nextmonthbutton_Click(object sender, EventArgs e)
		{
			DateTime newdate = weekstart.AddMonths(1);
			SetupWeek(newdate);
		}
		
		// Prev week
		private void prevweekbutton_Click(object sender, EventArgs e)
		{
			DateTime newdate = weekstart.AddDays(-7);
			SetupWeek(newdate);
		}
		
		// Prev month
		private void prevmonthbutton_Click(object sender, EventArgs e)
		{
			DateTime newdate = weekstart.AddMonths(-1);
			SetupWeek(newdate);
		}
		
		// View clicked on a day
		private void View_Click(object sender, EventArgs e)
		{
			showtimer.Stop();
			AgendaDayDisplay dd = (sender as AgendaDayDisplay);
			dayeditor.ReturnPanel = "agenda";
			dayeditor.SetupDay(dd.Day);
			General.MainWindow.ShowTaggedPanel("agendaday");
		}

		// Add clicked on a day
		private void Add_Click(object sender, EventArgs e)
		{
			showtimer.Stop();
			AgendaDayDisplay dd = (sender as AgendaDayDisplay);
			DateTime day = dd.Day;
			itemeditor.ReturnPanel = "agenda";
			itemeditor.AcceptEvent += RefreshWeek;
			itemeditor.SetupDate(day);
			General.MainWindow.ShowTaggedPanel("agendaitem");
		}

		// This shows the items one by one
		private void showtimer_Tick(object sender, EventArgs e)
		{
			for(int i = 0; i < daydisplays.Length; i++)
			{
				if(!daydisplays[i].Visible)
				{
					General.Sounds.Play("list");
					daydisplays[i].Visible = true;
					return;
				}
			}

			showtimer.Stop();
		}

		#endregion
	}
}
