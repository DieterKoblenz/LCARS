
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
	public partial class AgendaItemDisplayPanel : DisplayPanel
	{
		#region ================== Variables

		private string returnpanel;
		
		private int assigned;		// 0 = unassigned, 1 = pascal, 2 = marlies

		private AgendaItem result;

		public event VoidEventHandler AcceptEvent;
		public event VoidEventHandler CancelEvent;

		#endregion

		#region ================== Properties

		public string ReturnPanel { get { return returnpanel; } set { returnpanel = value; } }

		public AgendaItem AgendaItem { get { return result; } set { result = value; } }
		
		#endregion

		#region ================== Constructor

		// Constructor
		public AgendaItemDisplayPanel()
		{
			InitializeComponent();
		}

		#endregion
		
		#region ================== Methods

		// Setup colors
		public override void SetupColors(ColorPalette c)
		{
			base.SetupColors(c);

			// Do we still need this here? These controls are DisplayTextboxes and should be able to set their own colors.
			description.BackColor = General.Colors[ColorIndex.ControlNormal];
			description.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			startday.BackColor = General.Colors[ColorIndex.ControlNormal];
			startday.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			startmonth.BackColor = General.Colors[ColorIndex.ControlNormal];
			startmonth.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			startyear.BackColor = General.Colors[ColorIndex.ControlNormal];
			startyear.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			starthour.BackColor = General.Colors[ColorIndex.ControlNormal];
			starthour.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			startminute.BackColor = General.Colors[ColorIndex.ControlNormal];
			startminute.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			durdays.BackColor = General.Colors[ColorIndex.ControlNormal];
			durdays.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			durhours.BackColor = General.Colors[ColorIndex.ControlNormal];
			durhours.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			durminutes.BackColor = General.Colors[ColorIndex.ControlNormal];
			durminutes.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			endday.BackColor = General.Colors[ColorIndex.ControlNormal];
			endday.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			endmonth.BackColor = General.Colors[ColorIndex.ControlNormal];
			endmonth.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			endyear.BackColor = General.Colors[ColorIndex.ControlNormal];
			endyear.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			endhour.BackColor = General.Colors[ColorIndex.ControlNormal];
			endhour.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			endminute.BackColor = General.Colors[ColorIndex.ControlNormal];
			endminute.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			alarmminutes.BackColor = General.Colors[ColorIndex.ControlNormal];
			alarmminutes.ForeColor = General.Colors[ColorIndex.ControlNormalText];
		}
		
		// This clears the dialog for a new item
		public void Clear()
		{
			result = new AgendaItem();
			assigned = 0;
			pascalbutton.StopInfoFlash();
			marliesbutton.StopInfoFlash();
			birthdaybutton.StopInfoFlash();
			description.Clear();
			startday.Clear();
			startmonth.Clear();
			startyear.Clear();
			starthour.Clear();
			startminute.Clear();
			durdays.Clear();
			durhours.Clear();
			durminutes.Clear();
			endday.Clear();
			endmonth.Clear();
			endyear.Clear();
			endhour.Clear();
			endminute.Clear();
			alarmminutes.Clear();
			alarmbutton.StopInfoFlash();
			recurbutton.Text = AgendaItemRecur.None.ToString();
		}

		// This fills the dialog with info about an item
		public void SetupItem(AgendaItem item)
		{
			Clear();

			result = item;
			
			// Assigned
			if(item.color == ColorIndex.ControlColorPascal)
			{
				assigned = 1;
				pascalbutton.StartInfoFlash();
			}
			else if(item.color == ColorIndex.ControlColorMarlies)
			{
				assigned = 2;
				marliesbutton.StartInfoFlash();
			}
			else if(item.color == ColorIndex.ControlColorAffirmative)
			{
				assigned = 3;
				birthdaybutton.StartInfoFlash();
			}

			// Description
			description.Text = item.description;

			// Start
			startday.Text = item.originstartdate.Day.ToString();
			startmonth.Text = item.originstartdate.Month.ToString();
			startyear.Text = item.originstartdate.Year.ToString();
			starthour.Text = item.originstartdate.Hour.ToString();
			startminute.Text = item.originstartdate.Minute.ToString("00");
			
			// Duration
			int days = (int)Math.Floor(item.duration.TotalDays);
			durdays.Text = days.ToString();
			durhours.Text = item.duration.Hours.ToString();
			durminutes.Text = item.duration.Minutes.ToString("00");
			
			// End
			CalculateEndDateFromDuration();
			
			// Alarm
			TimeSpan alarmdur = item.startdate - item.alarmdate;
			alarmdur = alarmdur.Duration();
			int alarmmin = (int)alarmdur.TotalMinutes;
			alarmminutes.Text = alarmmin.ToString();
			if(item.alarm) alarmbutton.StartInfoFlash();

			// Recurring
			recurbutton.Text = item.recur.ToString();
		}

		// This ills the dialog with a specific start date
		public void SetupDate(DateTime startdate)
		{
			Clear();

			// Start
			startday.Text = startdate.Day.ToString();
			startmonth.Text = startdate.Month.ToString();
			startyear.Text = startdate.Year.ToString();
			
			// Duration
			durdays.Text = "0";
			durhours.Text = "1";
			durminutes.Text = "00";
			
			// End
			endday.Text = startdate.Day.ToString();
			endmonth.Text = startdate.Month.ToString();
			endyear.Text = startdate.Year.ToString();

			// Alarm
			alarmminutes.Text = "5";
		}

		// Shown
		public override void OnShow()
		{
			ShowValidation();
			base.OnShow();
			description.Focus();
			description.SelectionStart = description.Text.Length;
		}

		// Done showing
		protected override void OnShowFinished()
		{
			description.Focus();
		}

		// Hidden
		public override void OnHide()
		{
			base.OnHide();
			Clear();
			AcceptEvent = null;
			CancelEvent = null;
		}
		
		// This shows the start day name
		private void ShowValidation()
		{
			DateTime dt;
			
			// Start date
			if(DateFromInput(startday.Text, startmonth.Text, startyear.Text, out dt))
			{
				startdaylabel.Text = dt.DayOfWeek.ToString();
				startdaylabel.ColorText = ColorIndex.ControlNormal;
				startdaylabel.SetupColors(General.Colors);
			}
			else
			{
				startdaylabel.Text = "Invalid";
				startdaylabel.ColorText = ColorIndex.WarningLight;
				startdaylabel.SetupColors(General.Colors);
			}
			
			// End date
			if(DateFromInput(endday.Text, endmonth.Text, endyear.Text, out dt))
			{
				enddaylabel.Text = dt.DayOfWeek.ToString();
				enddaylabel.ColorText = ColorIndex.ControlNormal;
				enddaylabel.SetupColors(General.Colors);
			}
			else
			{
				enddaylabel.Text = "Invalid";
				enddaylabel.ColorText = ColorIndex.WarningLight;
				enddaylabel.SetupColors(General.Colors);
			}
		}
		
		// This converts a string to date
		private bool DateFromInput(string day, string month, string year, out DateTime date)
		{
			date = new DateTime();
			try
			{
				int nd = int.Parse(day);
				int nm = int.Parse(month);
				int ny = int.Parse(year);
				date = new DateTime(ny, nm, nd);
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

		// This converts a string to time
		private bool TimeFromInput(string hour, string minute, out TimeSpan time)
		{
			time = new TimeSpan();
			try
			{
				int nh = int.Parse(hour);
				int nm = int.Parse(minute);
				time = new TimeSpan(nh, nm, 0);
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

		// This returns the entered duration
		private bool GetDuration(out TimeSpan duration)
		{
			duration = new TimeSpan();
			try
			{
				int nd = int.Parse(durdays.Text);
				int nh = int.Parse(durhours.Text);
				int nm = int.Parse(durminutes.Text);
				duration = new TimeSpan(nd, nh, nm, 0);
				return true;
			}
			catch(Exception)
			{
				return false;
			}
		}

		// This sets the end date depending on duration
		private void CalculateEndDateFromDuration()
		{
			DateTime date;
			TimeSpan stime;
			if(!DateFromInput(startday.Text, startmonth.Text, startyear.Text, out date)) return;
			if(!TimeFromInput(starthour.Text, startminute.Text, out stime)) return;
			date = date.Add(stime);

			TimeSpan dur;
			if(!GetDuration(out dur)) return;

			date = date.Add(dur);

			endday.Text = date.Day.ToString();
			endmonth.Text = date.Month.ToString();
			endyear.Text = date.Year.ToString();
			endhour.Text = date.Hour.ToString();
			endminute.Text = date.Minute.ToString("00");
		}

		// This sets the duration depending on the end date
		private void CalculateDurationFromEndDate()
		{
			DateTime sdate;
			TimeSpan stime;
			if(!DateFromInput(startday.Text, startmonth.Text, startyear.Text, out sdate)) return;
			if(!TimeFromInput(starthour.Text, startminute.Text, out stime)) return;
			sdate = sdate.Add(stime);
			
			DateTime edate;
			TimeSpan etime;
			if(!DateFromInput(endday.Text, endmonth.Text, endyear.Text, out edate)) return;
			if(!TimeFromInput(endhour.Text, endminute.Text, out etime)) return;
			edate = edate.Add(etime);

			TimeSpan dur = edate - sdate;
			dur = dur.Duration();

			int days = (int)Math.Floor(dur.TotalDays);
			durdays.Text = days.ToString();
			durhours.Text = dur.Hours.ToString();
			durminutes.Text = dur.Minutes.ToString("00");
		}

		private void PlayFailSound()
		{
			General.Sounds.Play("error");
		}
		
		#endregion
		
		#region ================== Events
		
		private void backbutton_Click(object sender, EventArgs e)
		{
			if(CancelEvent != null)
				CancelEvent();
			
			General.MainWindow.ShowTaggedPanel(returnpanel);
			AcceptEvent = null;
			CancelEvent = null;
			Clear();
		}

		private void overviewbutton_Click(object sender, EventArgs e)
		{
			if(CancelEvent != null)
				CancelEvent();

			General.MainWindow.ShowTaggedPanel("overview");
			AcceptEvent = null;
			CancelEvent = null;
			Clear();
		}
		
		private void acceptbutton_Click(object sender, EventArgs e)
		{
			// General
			result.description = description.Text;
			if(assigned == 1)
				result.color = ColorIndex.ControlColorPascal;
			else if(assigned == 2)
				result.color = ColorIndex.ControlColorMarlies;
			else if(assigned == 3)
				result.color = ColorIndex.ControlColorAffirmative;
			else
				result.color = ColorIndex.WindowText;
			
			// Start
			DateTime date;
			TimeSpan stime;
			if(!DateFromInput(startday.Text, startmonth.Text, startyear.Text, out date)) { PlayFailSound(); return; }
			if(!TimeFromInput(starthour.Text, startminute.Text, out stime)) { PlayFailSound(); return; }
			result.startdate = date.Add(stime);

			// Duration
			TimeSpan dur;
			if(!GetDuration(out dur))
			{
				PlayFailSound();
				return;
			}
			result.duration = dur;
			
			// Alarm
			result.alarm = alarmbutton.IsInfoFlashing;
			result.alarmdate = result.startdate;
			try
			{
				TimeSpan advance = new TimeSpan(0, int.Parse(alarmminutes.Text), 0);
				result.alarmdate = result.startdate.Subtract(advance);
			}
			catch(Exception) { PlayFailSound(); return; }

			// Recurring
			try
			{
				result.recur = (AgendaItemRecur)Enum.Parse(typeof(AgendaItemRecur), recurbutton.Text);
			}
			catch(Exception) { PlayFailSound(); return; }
			
			// Store in database
			General.Agenda.AddOrUpdateItem(result);

			General.MainWindow.OverviewPanel.UpdateAgenda();
			
			if(AcceptEvent != null)
				AcceptEvent();

			// Close
			General.MainWindow.ShowTaggedPanel(returnpanel);
			AcceptEvent = null;
			CancelEvent = null;
			Clear();
		}
		
		private void TextBox_Enter(object sender, EventArgs e)
		{
			(sender as TextBox).SelectAll();
		}

		private void TextBox_MouseUp(object sender, MouseEventArgs e)
		{
			(sender as TextBox).SelectAll();
		}
		
		private void descriptionbar_Click(object sender, EventArgs e)
		{
			description.Focus();
		}

		private void startdatebar_Click(object sender, EventArgs e)
		{
			startday.Focus();
		}

		private void starttimebar_Click(object sender, EventArgs e)
		{
			starthour.Focus();
		}

		private void durationbar_Click(object sender, EventArgs e)
		{
			durdays.Focus();
		}

		private void enddatebar_Click(object sender, EventArgs e)
		{
			endday.Focus();
		}

		private void endtimebar_Click(object sender, EventArgs e)
		{
			endhour.Focus();
		}
		
		private void alarmbar_Click(object sender, EventArgs e)
		{
			alarmminutes.Focus();
		}
		
		private void startday_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(startday.Text.Length == 2)
				startmonth.Focus();
		}

		private void startmonth_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(startmonth.Text.Length == 2)
				startyear.Focus();
		}

		private void startyear_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(startyear.Text.Length == 4)
				starthour.Focus();
		}

		private void starthour_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(starthour.Text.Length == 2)
				startminute.Focus();
		}

		private void startminute_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(startminute.Text.Length == 2)
				durdays.Focus();
		}

		private void durdays_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(durdays.Text.Length == 2)
				durhours.Focus();
		}

		private void durhours_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(durhours.Text.Length == 2)
				durminutes.Focus();
		}

		private void durminutes_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateEndDateFromDuration();
			ShowValidation();
			if(durminutes.Text.Length == 2)
				endday.Focus();
		}

		private void endday_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateDurationFromEndDate();
			ShowValidation();
			if(endday.Text.Length == 2)
				endmonth.Focus();
		}

		private void endmonth_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateDurationFromEndDate();
			ShowValidation();
			if(endmonth.Text.Length == 2)
				endyear.Focus();
		}

		private void endyear_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateDurationFromEndDate();
			ShowValidation();
			if(endyear.Text.Length == 4)
				endhour.Focus();
		}

		private void endhour_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateDurationFromEndDate();
			ShowValidation();
			if(endhour.Text.Length == 2)
				endminute.Focus();
		}

		private void endminute_KeyUp(object sender, KeyEventArgs e)
		{
			CalculateDurationFromEndDate();
			ShowValidation();
			if(endminute.Text.Length == 2)
				alarmminutes.Focus();
		}

		private void unassignbutton_Click(object sender, EventArgs e)
		{
			assigned = 0;
			if(description.Text.StartsWith("marlies ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(8);
			if(description.Text.StartsWith("pascal ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(7);
			if(description.Text.StartsWith("verjaardag ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(11);
			pascalbutton.StopInfoFlash();
			marliesbutton.StopInfoFlash();
			birthdaybutton.StopInfoFlash();
			description.SelectionStart = description.Text.Length + 1;
			description.Focus();
		}

		private void pascalbutton_Click(object sender, EventArgs e)
		{
			assigned = 1;
			if(description.Text.StartsWith("marlies ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(8);
			if(description.Text.StartsWith("verjaardag ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(11);
			if(!description.Text.StartsWith("pascal", StringComparison.InvariantCultureIgnoreCase))
				description.Text = "Pascal " + description.Text;
			pascalbutton.StartInfoFlash();
			marliesbutton.StopInfoFlash();
			birthdaybutton.StopInfoFlash();
			description.SelectionStart = description.Text.Length + 1;
			description.Focus();
		}

		private void marliesbutton_Click(object sender, EventArgs e)
		{
			assigned = 2;
			if(description.Text.StartsWith("pascal ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(7);
			if(description.Text.StartsWith("verjaardag ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(11);
			if(!description.Text.StartsWith("marlies", StringComparison.InvariantCultureIgnoreCase))
				description.Text = "Marlies " + description.Text;
			marliesbutton.StartInfoFlash();
			pascalbutton.StopInfoFlash();
			birthdaybutton.StopInfoFlash();
			description.SelectionStart = description.Text.Length + 1;
			description.Focus();
		}

		private void birthdaybutton_Click(object sender, EventArgs e)
		{
			assigned = 3;
			if(description.Text.StartsWith("pascal ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(7);
			if(description.Text.StartsWith("marlies ", StringComparison.InvariantCultureIgnoreCase))
				description.Text = description.Text.Substring(8);
			if(!description.Text.StartsWith("verjaardag", StringComparison.InvariantCultureIgnoreCase))
				description.Text = "Verjaardag " + description.Text;
			marliesbutton.StopInfoFlash();
			pascalbutton.StopInfoFlash();
			birthdaybutton.StartInfoFlash();
			description.SelectionStart = description.Text.Length + 1;
			description.Focus();
		}

		private void alarmbutton_Click(object sender, EventArgs e)
		{
			if(alarmbutton.IsInfoFlashing)
				alarmbutton.StopInfoFlash();
			else
				alarmbutton.StartInfoFlash();
		}

		private void recurbutton_Click(object sender, EventArgs e)
		{
			// Next!
			AgendaItemRecur c = (AgendaItemRecur)Enum.Parse(typeof(AgendaItemRecur), recurbutton.Text);
			int nc = (int)c + 1;
			if(!Enum.IsDefined(typeof(AgendaItemRecur), nc))
				nc = 0;
			c = (AgendaItemRecur)nc;
			recurbutton.Text = c.ToString();
		}

		#endregion
	}
}
