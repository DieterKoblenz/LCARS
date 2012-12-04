
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
	public sealed class DisplayManager
	{
		#region ================== API Declarations

		[DllImport("nvcpl.dll")]
		internal static extern int dtcfgex(string cmdline);

		[DllImport("nvcpl.dll")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		internal static extern string NvGetLastErrorMessageW();
		
		#endregion

		#region ================== Constants

		#endregion

		#region ================== Variables

		// Display mode
		private DisplayMode displaymode;

		// Process that runs on the other display
		private Process displayproc;

		#endregion

		#region ================== Properties

		public DisplayMode DisplayMode { get { return displaymode; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public DisplayManager()
		{
			displaymode = DisplayMode.Single;
		}

		// Destructor
		~DisplayManager()
		{
			Dispose();
		}

		// Disposer
		public void Dispose()
		{
			CloseDisplay();
		}
		
		#endregion

		#region ================== Private Methods

		// This runs a video driver command
		private void RunVideoCmd(string cmd)
		{
			int result = dtcfgex(cmd);
			string resultmsg = NvGetLastErrorMessageW();
			General.WriteLogLine("dtcfgex command '" + cmd + "' returned code " + result + ": " + resultmsg);
		}

		// This changes display mode
		private void SetDisplayMode(DisplayMode mode)
		{
			if(mode == displaymode)
				return;

			/*
			General.WriteLogLine("Changing display mode to '" + mode + "'");
			
			// Show a blank screen while switching
			BlankScreen bs = new BlankScreen();
			bs.Location = new Point(0, 0);
			bs.Show(General.MainWindow);
			bs.Update();

			if(General.Settings.LiveEnvironment)
			{
				switch(mode)
				{
					case DisplayMode.Single:
						RunVideoCmd("setview 1 standard A0");
						RunVideoCmd("primary 1");
						break;

					case DisplayMode.Clone:
						RunVideoCmd("setview 1 clone A0 D0");
						RunVideoCmd("primary 1");
						break;

					case DisplayMode.Separate:
						RunVideoCmd("setview 1 dualview A0 D0");
						RunVideoCmd("primary 1");
						while(Screen.AllScreens.Length == 1)
						{
							Thread.Sleep(20);
						}
						break;

					default:
						General.WriteLogLine("Invalid DisplayMode specified!");
						return;
				}
			}
			
			Thread.Sleep(500);
			bs.Dispose();
			*/
			
			displaymode = mode;
		}

		// This closes all windows on the secondary display
		public void CloseDisplay()
		{
			if(displayproc != null)
			{
				try
				{
					displayproc.Kill();
				}
				catch(Exception)
				{
				}
				
				displayproc = null;
			}
		}

		// This returns a location for a form on the secondary display
		public int GetSecondaryLeftPosition()
		{
			return General.Settings.LiveEnvironment ? 2000 : 10;
		}

		// This runs the display process
		public void OpenDisplay(string cmdargs)
		{
			CloseDisplay();

			General.Sounds.SetAudioOutputSecondary();

			ProcessStartInfo proc = new ProcessStartInfo();
			proc.Arguments = "-hwnd " + General.MainWindow.Handle + " " + cmdargs;
			proc.ErrorDialog = false;
			proc.FileName = Path.Combine(General.AppPath, "Display.exe");
			proc.LoadUserProfile = true;
			//proc.UserName = "Pascal";
			proc.UseShellExecute = false;
			proc.WorkingDirectory = General.AppPath;

			displayproc = Process.Start(proc);
			displayproc.WaitForInputIdle();

			General.MainWindow.Focus();
		}

		#endregion

		#region ================== Public Methods

		// This turns off the separate display and closes anything displayed on it
		public void ShowNothing()
		{
			SetDisplayMode(DisplayMode.Single);
			CloseDisplay();
		}
		
		/*
		// This shows a clone of the primary screen on the secondary screen
		public void ShowClone()
		{
			SetDisplayMode(DisplayMode.Clone);
			CloseDisplay();
		}
		*/
		
		// This shows HTML code in a browser on a separate display
		public void ShowHTML(string html)
		{
			SetDisplayMode(DisplayMode.Separate);
			string htmlfilename = Tools.MakeTempFilename(General.TempPath, "html");
			File.WriteAllText(htmlfilename, html);
			int leftpos = GetSecondaryLeftPosition();
			OpenDisplay("-left " + leftpos + " -showurl \"file://" + htmlfilename + "\"");
		}

		// This shows HTML code in a browser on a separate display
		public void ShowURL(string url)
		{
			SetDisplayMode(DisplayMode.Separate);
			int leftpos = GetSecondaryLeftPosition();
			OpenDisplay("-left " + leftpos + " -showurl \"" + url + "\"");
		}

		// This runs the media player
		public void ShowMediaPlayer(string playfilename, int startpos, string muxfilename)
		{
			SetDisplayMode(DisplayMode.Separate);
			int leftpos = GetSecondaryLeftPosition();
			if(string.IsNullOrEmpty(playfilename))
			{
				OpenDisplay("-left " + leftpos + " -playmedia");
			}
			else
			{
				if(string.IsNullOrEmpty(muxfilename))
				{
					OpenDisplay("-left " + leftpos + " -playmedia \"" + playfilename + "\" -startpos " + startpos);
				}
				else
				{
					OpenDisplay("-left " + leftpos + " -playmedia \"" + playfilename + "\" -startpos " + startpos + " -mux \"" + muxfilename + "\"");
				}
			}
		}
		
		#endregion
	}
}