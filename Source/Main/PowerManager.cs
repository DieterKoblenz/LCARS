
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
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

#endregion

namespace CodeImp.Gluon
{
	public sealed class PowerManager
	{
		#region ================== Constants

		// These constants support the sleep time determination in IsSleepTime()
		private const int WAKEUP_HOUR = 6;		// Sleep before 6 in the morning
		private const int SLEEP_HOUR = 0;		// Sleep after 0 in the night

		#endregion

		#region ================== Variables
		
		// This is true when the machine has been configured to go to sleep ASAP
		private bool sleepconfigured;
		
		// This keeps track of requests to keep the computer from going to sleep (power save mode)
		private int keepawake;

		// First check?
		private bool firstcheck;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public PowerManager()
		{
			keepawake = 0;
			firstcheck = true;
		}

		#endregion

		#region ================== Private Methods

		// This configures the machine to stay awake
		private void ConfigureStayAwake()
		{
			sleepconfigured = false;
			General.WriteLogLine("System is now configured to stay awake.");
			if(General.Settings.LiveEnvironment)
				Tools.RunBatch("power_on.bat");
		}

		// This configures the machine to sleep ASAP
		private void ConfigureSleepNow()
		{
			sleepconfigured = true;
			General.WriteLogLine("System is now configured for sleeping.");
			if(General.Settings.LiveEnvironment)
				Tools.RunBatch("shutdown_computer.bat");
				//Tools.RunBatch("power_sleep.bat");
		}
		
		#endregion

		#region ================== Public Methods

		// This checks if it is the time of the day to go to sleep
		public bool IsSleepTime()
		{
			if(General.Settings.LiveEnvironment)
			{
				DateTime now = DateTime.Now;

				// Sleep at...
				if((now.Hour == SLEEP_HOUR) && (now.Minute == 0))
					return true;
			}
			
			// No time to sleep
			return false;
		}
		
		// This disables the ability to go into power save
		public void DisablePowerSave()
		{
			keepawake++;
			
			if((keepawake == 1) && sleepconfigured)
				ConfigureStayAwake();
		}
		
		// This enables the ability to go into power save
		public void EnablePowerSave()
		{
			keepawake--;
			if(keepawake < 0) keepawake = 0;
		}

		// This is called to process automatic sleep control
		public void Process()
		{
			// First time checking since program start?
			if(firstcheck)
			{
				if((keepawake == 0) && IsSleepTime())
					ConfigureSleepNow();
				else
					ConfigureStayAwake();
				
				firstcheck = false;
			}
			else
			{
				// Going to sleep?
				if(sleepconfigured)
				{
					if(!IsSleepTime())
						ConfigureStayAwake();
				}
				// Awake
				else
				{
					if((keepawake == 0) && IsSleepTime())
						ConfigureSleepNow();
				}
			}
		}

		// This moves the mouse to turn on the screen
		public void TurnOnScreen()
		{
			Point oldpos = Cursor.Position;
			Cursor.Position = new Point(oldpos.X + 20, oldpos.Y + 20);
			Thread.Sleep(10);
			Cursor.Position = new Point(oldpos.X - 20, oldpos.Y - 20);
			Thread.Sleep(10);
			Cursor.Position = oldpos;
		}

		#endregion
	}
}