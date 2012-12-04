
#region ================== Defines

#if !DEBUG
#define CATCH_EXCEPTIONS
#define HIGH_PRIORITY_PROCESS
#endif

#endregion

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
	public static class General
	{
		#region ================== API Declarations

		[DllImport("user32.dll")]
		internal static extern bool LockWindowUpdate(IntPtr hwnd);

		[DllImport("kernel32.dll", EntryPoint = "RtlZeroMemory", SetLastError = false)]
		internal static extern void ZeroMemory(IntPtr dest, int size);

		[DllImport("kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
		internal static extern unsafe void CopyMemory(void* dst, void* src, uint length);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern uint GetShortPathName([MarshalAs(UnmanagedType.LPTStr)] string longpath, [MarshalAs(UnmanagedType.LPTStr)]StringBuilder shortpath, uint buffersize);
		
		#endregion

		#region ================== Constants

		// Window messages
		internal const int WM_USER = 0x400;
		internal const int WM_SYSCOMMAND = 0x112;
		internal const int WM_LBUTTONDOWN = 0x0201;
		internal const int WM_LBUTTONUP = 0x0202;
		internal const int WM_LBUTTONDBLCLK = 0x0203;
		internal const int WM_RBUTTONDOWN = 0x0204;
		internal const int WM_RBUTTONUP = 0x0205;
		internal const int WM_RBUTTONDBLCLK = 0x0206;
		internal const int WM_MBUTTONDOWN = 0x0207;
		internal const int WM_MBUTTONUP = 0x0208;
		internal const int WM_MBUTTONDBLCLK = 0x0209;
		internal const int SC_KEYMENU = 0xF100;
		internal const int CB_SETITEMHEIGHT = 0x153;
		internal const int CB_SHOWDROPDOWN = 0x14F;
		internal const int EM_GETSCROLLPOS = WM_USER + 221;
		internal const int EM_SETSCROLLPOS = WM_USER + 222;
		
		#endregion
		
		#region ================== Variables
		
		// State
		private static bool apprunning;
		
		// Files and Folders
		private static string apppath;
		private static string temppath;
		private static string settingspath;
		private static string logfile;
		
		// Main objects
		private static Assembly thisasm;
		private static MainForm mainwindow;
		private static SettingsManager settings;
		private static ColorPalette colors;
		private static Clock clock;
		private static Mutex appmutex;
		private static InterfaceImageProvider images;
		private static SoundsManager sounds;
		private static AgendaManager agenda;
		private static PowerManager power;
		private static DatabaseManager db;
		private static ObexManager obex;
		private static GroceriesManager groceries;
		private static PCapManager pcap;
		private static NotesManager notes;
		private static DisplayManager display;
		private static RemoteManager remote;
		
		// Locking
		private static bool accessenabled;

		// Error report
		private static string errormessage;
		
		#endregion

		#region ================== Properties
		
		public static bool AppRunning { get { return apprunning; } }
		public static string AppPath { get { return apppath; } }
		public static string TempPath { get { return temppath; } }
		public static string SettingsPath { get { return settingspath; } }

		public static Assembly ThisAssembly { get { return thisasm; } }
		public static MainForm MainWindow { get { return mainwindow; } }
		public static SettingsManager Settings { get { return settings; } }
		public static ColorPalette Colors { get { return colors; } }
		public static Clock Clock { get { return clock; } }
		public static InterfaceImageProvider Images { get { return images; } }
		public static SoundsManager Sounds { get { return sounds; } }
		public static AgendaManager Agenda { get { return agenda; } }
		public static PowerManager Power { get { return power; } }
		public static DatabaseManager DB { get { return db; } }
		public static ObexManager Obex { get { return obex; } }
		public static GroceriesManager Groceries { get { return groceries; } }
		public static PCapManager PCap { get { return pcap; } }
		public static NotesManager Notes { get { return notes; } }
		public static DisplayManager Display { get { return display; } }
		public static RemoteManager Remote { get { return remote; } }

		public static bool AccessEnabled { get { return accessenabled; } set { accessenabled = value; } }
		public static string ErrorMessage { get { return errormessage; } set { if(string.IsNullOrEmpty(errormessage)) errormessage = value; } }
		
		#endregion

		#region ================== Startup

		// The main entry point for the application.
		[STAThread]
		public static void Main()
		{
			// Enable visual styles
			//Application.EnableVisualStyles();
			//Application.DoEvents();		// This must be here to work around a .NET bug
			Application.SetCompatibleTextRenderingDefault(true);
			
			// Set current thread name
			Thread.CurrentThread.Name = "Main Application";
			
			// Application is running
			appmutex = new Mutex(false, "gluon");
			apprunning = true;
			
			// Get a reference to this assembly
			thisasm = Assembly.GetExecutingAssembly();
			Version thisversion = thisasm.GetName().Version;
			
			// Find paths
			Uri localpath = new Uri(Path.GetDirectoryName(thisasm.GetName().CodeBase));
			apppath = Uri.UnescapeDataString(localpath.AbsolutePath);
			temppath = Path.GetTempPath();
			settingspath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gluon");
			logfile = Path.Combine(settingspath, "Log.txt");
			
			// Make program settings directory if missing
			if(!Directory.Exists(settingspath)) Directory.CreateDirectory(settingspath);
			
			// Remove the previous log file and start logging
			//if(File.Exists(logfile)) File.Delete(logfile);
			General.WriteLogLine("===============================================================================================");
			General.WriteLogLine("Gluon " + thisversion.Major + "." + thisversion.Minor + "." + thisversion.Build + "." + thisversion.Revision + " startup.");
			
			#if HIGH_PRIORITY_PROCESS
				Process thisproc = Process.GetCurrentProcess();
				thisproc.PriorityClass = ProcessPriorityClass.AboveNormal;
			#endif
			Thread thisthread = Thread.CurrentThread;
			thisthread.Priority = ThreadPriority.Highest;

			// Load settings
			settings = new SettingsManager();
			
			#if DEBUG
				if(!settings.LiveEnvironment)
					accessenabled = true;
			#endif

			// Make me a clock
			clock = new Clock();
			
			// Make the power managment
			power = new PowerManager();
			
			// Load sounds
			sounds = new SoundsManager();
			sounds.LoadSounds();

			// If audio is not set to primary device, we must make it so and restart Gluon
			if(!sounds.CheckAudioOutputPrimary())
			{
				sounds.SetAudioOutputPrimary();
				
				// Restart Gluon
				ProcessStartInfo proc = new ProcessStartInfo();
				proc.ErrorDialog = false;
				proc.FileName = Path.Combine(General.AppPath, "Gluon.exe");
				proc.LoadUserProfile = true;
				//proc.UserName = "Pascal";
				proc.UseShellExecute = false;
				proc.WorkingDirectory = General.AppPath;
				Process.Start(proc);
				return;
			}
			
			// Load color palette
			colors = new ColorPalette();
			
			// Load interface images
			images = new InterfaceImageProvider();
			
			// Build images for all color schemes
			colors.SetupDarkScheme();
			images.BuildImages();
			colors.SetupNormalScheme();
			images.BuildImages();

			// Managers
			remote = new RemoteManager();
			display = new DisplayManager();
			pcap = new PCapManager();
			obex = new ObexManager();
			agenda = new AgendaManager();
			notes = new NotesManager();
			groceries = new GroceriesManager();
			db = new DatabaseManager();

			// Load main window
			mainwindow = new MainForm();
			mainwindow.ShowTaggedPanel("loading");
			
			// See LoadingDisplaypanel::Load() for connect/setup stuff
			
			#if CATCH_EXCEPTIONS
					
				// Add exception handlers
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
				Application.ThreadException += Application_ThreadException;
			
			#endif
			
			bool failed;
			
			do
			{
				failed = false;
				
				#if CATCH_EXCEPTIONS
				
				try
				{
				
				#endif
					
					// Show main window
					Application.Run(mainwindow);
					
				#if CATCH_EXCEPTIONS
				
				}
				catch(Exception e)
				{
					Application.ExitThread();
					failed = true;
					mainwindow = new MainForm();
					General.ErrorMessage = e.GetType().Name + ": " + e.Message + "\r\n" + e.StackTrace;
					General.WriteLogLine(General.ErrorMessage);
					mainwindow.ShowTaggedPanel("error");
				}
				
				#endif
			}
			while(failed);

			// Clean stuff up
			sounds.SetAudioOutputPrimary();
			display.Dispose();
			obex.Dispose();
			pcap.Dispose();
			db.Dispose();
			remote.Dispose();
		}

		#if CATCH_EXCEPTIONS
		
		static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Exception ex = e.Exception;
			General.ErrorMessage = ex.GetType().Name + ": " + ex.Message + "\r\n" + ex.StackTrace;
			General.WriteLogLine(General.ErrorMessage);
			mainwindow.ShowTaggedPanel("error");
		}

		static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			Exception ex;
			if(e.ExceptionObject is Exception)
				ex = (Exception)e.ExceptionObject;
			else
				ex = new Exception(e.ToString());
			
			General.ErrorMessage = ex.GetType().Name + ": " + ex.Message + "\r\n" + ex.StackTrace;
			General.WriteLogLine(General.ErrorMessage);
			mainwindow.ShowTaggedPanel("error");
		}

		#endif
		
		#endregion
		
		#region ================== Methods

		// This crashes
		public static void Fail(string description)
		{
			#if !CATCH_EXCEPTIONS
				//throw new Exception(description);
			#endif
			
			General.ErrorMessage = description;
			General.WriteLogLine(General.ErrorMessage);
			mainwindow.ShowTaggedPanel("error");
		}

		// This crashes
		public static void Fail(Exception ex)
		{
			#if !CATCH_EXCEPTIONS
				//throw ex;
			#endif
			
			General.ErrorMessage = ex.GetType().Name + ": " + ex.Message + "\r\n" + ex.StackTrace;
			General.WriteLogLine(General.ErrorMessage);
			mainwindow.ShowTaggedPanel("error");
		}

		// This crashes
		public static void Fail(Exception ex, string when)
		{
			#if !CATCH_EXCEPTIONS
				//throw ex;
			#endif
			
			General.ErrorMessage = ex.GetType().Name + " " + when.Trim() + ": " + ex.Message + "\r\n" + ex.StackTrace;
			General.WriteLogLine(General.ErrorMessage);
			mainwindow.ShowTaggedPanel("error");
		}
		
		// This outputs log information
		public static void WriteLogLine(string line)
		{
			DateTime now = DateTime.Now;
			
			// Prefix with date and time
			string fullline = "[" + now.Year.ToString().PadLeft(4) + "-" + now.Month.ToString().PadLeft(2) + "-" + now.Day.ToString().PadLeft(2) + "] [" +
							  now.Hour.ToString().PadLeft(2) + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00") + "] " + line;
			
			// Output to console
			Console.WriteLine(fullline);

			if(mainwindow != null)
				mainwindow.ShowLogLine("[" + now.Millisecond.ToString("000") + "] " + line);

			// Write to log file
			try { File.AppendAllText(logfile, fullline + Environment.NewLine); }
			catch(Exception) { }
		}
		
		#endregion
	}
}