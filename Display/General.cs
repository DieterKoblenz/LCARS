#region ================== Defines

#if !DEBUG
#define CATCH_EXCEPTIONS
#define HIGH_PRIORITY_PROCESS
#endif

#endregion

#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace CodeImp.Gluon
{
	static class General
	{
		[STAThread]
		static void Main()
		{
			int formleftpos = 0;
			string[] options;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			#if HIGH_PRIORITY_PROCESS
				Process thisproc = Process.GetCurrentProcess();
				thisproc.PriorityClass = ProcessPriorityClass.High;
			#endif
			Thread thisthread = Thread.CurrentThread;
			thisthread.Priority = ThreadPriority.Highest;
			
			// HWND of Gluon window
			int hwndint;
			options = GetCommandLineOption("hwnd");
			if(options.Length > 1)
			{
				// Remember HWND for inter-process communcation
				int.TryParse(options[1], out hwndint);
				InterProcess.otherhwnd = new IntPtr(hwndint);
			}
			else
			{
				// We can't start without knowing the HWND of the other app
				return;
			}

			// Form left position specified?
			options = GetCommandLineOption("left");
			if(options.Length > 1)
				int.TryParse(options[1], out formleftpos);

			// Show a URL?
			options = GetCommandLineOption("showurl");
			if(options.Length > 1)
			{
				WebPageDisplayForm f = new WebPageDisplayForm();
				f.Left = formleftpos;
				f.ShowURL(options[1]);
				f.Show();
				Application.Run(f);
			}

			// Play media file?
			options = GetCommandLineOption("playmedia");
			if(options.Length > 0)
			{
				MediaPlayerDisplayForm f = new MediaPlayerDisplayForm();
				f.Left = formleftpos;
				f.Show();
				f.WindowState = FormWindowState.Maximized;
				if(options.Length > 1)
				{
					string filename = options[1];
					int startpos = 0;
					options = GetCommandLineOption("startpos");
					if(options.Length > 1)
						int.TryParse(options[1], out startpos);
					options = GetCommandLineOption("mux");
					if(options.Length > 1)
						f.SetMuxingFile(options[1]);
					f.PlayFile(filename, startpos);
				}
				Application.Run(f);
			}
		}
		
		// Get an option and it's argument. Do not prefix the option with a dash!
		// Returns an empty array (length 0) when the option is not found
		public static string[] GetCommandLineOption(string option)
		{
			string[] args = Environment.GetCommandLineArgs();

			// Parse
			for(int i = 1; i < args.Length; i++)
			{
				// Option found?
				if(string.Compare(args[i], "-" + option, true) == 0)
				{
					// Make an array with all option arguments
					List<string> optionargs = new List<string>();
					optionargs.Add(args[i]);
					for(int k = i + 1; k < args.Length; k++)
					{
						if(!args[k].StartsWith("-"))
							optionargs.Add(args[k]);
						else
							break;
					}
					
					// Return option arguments
					return optionargs.ToArray();
				}
			}
			
			// Option not found, return null;
			return new string[0];
		}
	}
}
