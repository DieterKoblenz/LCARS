
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;

#endregion

namespace CodeImp.Gluon
{
	public delegate void VoidEventHandler();

	public static class Tools
	{
		// This removes excessive whitespace from a string and keeps only a sinlge space, like HTML browsers do.
		public static string StripExcessiveWhitespace(string str)
		{
			string newstr = str;

			do
			{
				str = newstr;
				newstr = newstr.Replace("\t", " ");
				newstr = newstr.Replace("\n", " ");
				newstr = newstr.Replace("\r", " ");
				newstr = newstr.Replace("  ", " ");
			}
			while(newstr.Length != str.Length);

			return newstr;
		}

		// This runs a batch script
		public static Process RunBatch(string name)
		{
			ProcessStartInfo processinfo = new ProcessStartInfo();
			processinfo.FileName = Path.Combine(General.AppPath, "Scripts\\" + name);
			processinfo.CreateNoWindow = false;
			processinfo.ErrorDialog = false;
			processinfo.UseShellExecute = true;
			processinfo.WindowStyle = ProcessWindowStyle.Hidden;
			processinfo.WorkingDirectory = Path.Combine(General.AppPath, "Scripts");
			Process p = System.Diagnostics.Process.Start(processinfo);
			return p;
		}

		// This returns a non-primary screen.
		public static Screen NonPrimaryScreen(int index)
		{
			int nonprimarycounter = 0;
			foreach(Screen s in Screen.AllScreens)
			{
				if(!s.Primary)
				{
					nonprimarycounter++;
					if(nonprimarycounter == index)
						return s;
				}
			}
			
			return null;
		}

		// This returns a non-primary screen index.
		public static int NonPrimaryScreenIndex(int index)
		{
			int nonprimarycounter = 0;
			for(int realindex = 0; realindex < Screen.AllScreens.Length; realindex++)
			{
				if(!Screen.AllScreens[realindex].Primary)
				{
					nonprimarycounter++;
					if(nonprimarycounter == index)
						return realindex;
				}
			}

			return -1;
		}

		// This casts an object that can be int or long to a long
		public static long ToLong(object obj)
		{
			if(obj is int)
				return (long)(int)obj;
			else if(obj is long)
				return (long)obj;
			else
				throw new ArgumentException("Invalid object type. Long or int was expected.");
		}
		
		// This returns the zero-based index for the day of the week
		// We can use this to change default first day of the week (Sunday)
		public static int DayOfWeekInt(DayOfWeek dw)
		{
			switch(dw)
			{
				case DayOfWeek.Sunday: return 6;
				case DayOfWeek.Monday: return 0;
				case DayOfWeek.Tuesday: return 1;
				case DayOfWeek.Wednesday: return 2;
				case DayOfWeek.Thursday: return 3;
				case DayOfWeek.Friday: return 4;
				case DayOfWeek.Saturday: return 5;
				default: throw new ArgumentOutOfRangeException("Invalid day of week specified.");
			}
		}

		// This outputs 'True' or 'False'
		public static string Bool2String(bool v)
		{
			return v ? "True" : "False";
		}
		
		// This swaps two pointers
		public static void Swap<T>(ref T a, ref T b)
		{
			T t = a;
			a = b;
			b = t;
		}

		// This calculates the bits needed for a number
		public static int BitsForInt(int v)
		{
			int[] LOGTABLE = new int[] {
			  0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3,
			  4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
			  5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			  5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5,
			  6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			  6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			  6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			  6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
			  7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 };

			int r;	// r will be lg(v)
			int t, tt;

			if(Int2Bool(tt = v >> 16))
			{
				r = Int2Bool(t = tt >> 8) ? 24 + LOGTABLE[t] : 16 + LOGTABLE[tt];
			}
			else
			{
				r = Int2Bool(t = v >> 8) ? 8 + LOGTABLE[t] : LOGTABLE[v];
			}

			return r;
		}

		// This clamps a value
		public static double Clamp(double value, double min, double max)
		{
			return Math.Min(Math.Max(min, value), max);
		}

		// This clamps a value
		public static float Clamp(float value, float min, float max)
		{
			return Math.Min(Math.Max(min, value), max);
		}

		// This clamps a value
		public static int Clamp(int value, int min, int max)
		{
			return Math.Min(Math.Max(min, value), max);
		}

		// This clamps a value
		public static byte Clamp(byte value, byte min, byte max)
		{
			return Math.Min(Math.Max(min, value), max);
		}

		// This returns an element from a collection by index
		public static T GetByIndex<T>(ICollection<T> collection, int index)
		{
			IEnumerator<T> e = collection.GetEnumerator();
			for(int i = -1; i < index; i++) e.MoveNext();
			return e.Current;
		}

		// This returns the next power of 2
		public static int NextPowerOf2(int v)
		{
			int p = 0;

			// Continue increasing until higher than v
			while(Math.Pow(2, p) < v) p++;

			// Return power
			return (int)Math.Pow(2, p);
		}

		// Convert bool to integer
		public static int Bool2Int(bool v)
		{
			return v ? 1 : 0;
		}

		// Convert integer to bool
		public static bool Int2Bool(int v)
		{
			return (v != 0);
		}

		// This shows a message and logs the message
		public static DialogResult ShowErrorMessage(string message, MessageBoxButtons buttons)
		{
			Cursor oldcursor;
			DialogResult result;

			// Log the message
			General.WriteLogLine(message);

			// Use normal cursor
			oldcursor = Cursor.Current;
			Cursor.Current = Cursors.Default;

			// Show message
			IWin32Window window = null;
			if((Form.ActiveForm != null) && Form.ActiveForm.Visible) window = Form.ActiveForm;
			result = MessageBox.Show(window, message, Application.ProductName, buttons, MessageBoxIcon.Error);

			// Restore old cursor
			Cursor.Current = oldcursor;

			// Return result
			return result;
		}

		// This shows a message and logs the message
		public static DialogResult ShowWarningMessage(string message, MessageBoxButtons buttons)
		{
			return ShowWarningMessage(message, buttons, MessageBoxDefaultButton.Button1);
		}

		// This shows a message and logs the message
		public static DialogResult ShowWarningMessage(string message, MessageBoxButtons buttons, MessageBoxDefaultButton defaultbutton)
		{
			Cursor oldcursor;
			DialogResult result;

			// Log the message
			General.WriteLogLine(message);

			// Use normal cursor
			oldcursor = Cursor.Current;
			Cursor.Current = Cursors.Default;

			// Show message
			IWin32Window window = null;
			if((Form.ActiveForm != null) && Form.ActiveForm.Visible) window = Form.ActiveForm;
			result = MessageBox.Show(window, message, Application.ProductName, buttons, MessageBoxIcon.Warning, defaultbutton);

			// Restore old cursor
			Cursor.Current = oldcursor;

			// Return result
			return result;
		}

		// This returns a unique temp filename
		internal static string MakeTempFilename(string tempdir)
		{
			return MakeTempFilename(tempdir, "tmp");
		}

		// This returns a unique temp filename
		internal static string MakeTempFilename(string tempdir, string extension)
		{
			string filename;
			string chars = "abcdefghijklmnopqrstuvwxyz1234567890";
			Random rnd = new Random();
			int i;

			do
			{
				// Generate a filename
				filename = "";
				for(i = 0; i < 8; i++) filename += chars[rnd.Next(chars.Length)];
				filename = Path.Combine(tempdir, filename + "." + extension);
			}
			// Continue while file is not unique
			while(File.Exists(filename) || Directory.Exists(filename));

			// Return the filename
			return filename;
		}

		// This returns a unique temp directory name
		internal static string MakeTempDirname()
		{
			string dirname;
			const string chars = "abcdefghijklmnopqrstuvwxyz1234567890";
			Random rnd = new Random();
			int i;

			do
			{
				// Generate a filename
				dirname = "";
				for(i = 0; i < 8; i++) dirname += chars[rnd.Next(chars.Length)];
				dirname = Path.Combine(General.TempPath, dirname);
			}
			// Continue while file is not unique
			while(File.Exists(dirname) || Directory.Exists(dirname));

			// Return the filename
			return dirname;
		}

		// This shows an image in a panel either zoomed or centered depending on size
		public static void DisplayZoomedImage(Panel panel, Image image)
		{
			// Set the image
			panel.BackgroundImage = image;

			// Image not null?
			if(image != null)
			{
				// Small enough to fit in panel?
				if((image.Size.Width < panel.ClientRectangle.Width) &&
				   (image.Size.Height < panel.ClientRectangle.Height))
				{
					// Display centered
					panel.BackgroundImageLayout = ImageLayout.Center;
				}
				else
				{
					// Display zoomed
					panel.BackgroundImageLayout = ImageLayout.Zoom;
				}
			}
		}

		// This calculates the new rectangle when one is scaled into another keeping aspect ratio
		public static RectangleF MakeZoomedRect(Size source, RectangleF target)
		{
			return MakeZoomedRect(new SizeF((int)source.Width, (int)source.Height), target);
		}

		// This calculates the new rectangle when one is scaled into another keeping aspect ratio
		public static RectangleF MakeZoomedRect(Size source, Rectangle target)
		{
			return MakeZoomedRect(new SizeF((int)source.Width, (int)source.Height),
								  new RectangleF((int)target.Left, (int)target.Top, (int)target.Width, (int)target.Height));
		}

		// This calculates the new rectangle when one is scaled into another keeping aspect ratio
		public static RectangleF MakeZoomedRect(SizeF source, RectangleF target)
		{
			float scale;

			// Image fits?
			if((source.Width <= target.Width) &&
			   (source.Height <= target.Height))
			{
				// Just center
				scale = 1.0f;
			}
			// Image is wider than tall?
			else if((source.Width - target.Width) > (source.Height - target.Height))
			{
				// Scale down by width
				scale = target.Width / source.Width;
			}
			else
			{
				// Scale down by height
				scale = target.Height / source.Height;
			}

			// Return centered and scaled
			return new RectangleF(target.Left + (target.Width - source.Width * scale) * 0.5f,
								  target.Top + (target.Height - source.Height * scale) * 0.5f,
								  source.Width * scale, source.Height * scale);
		}

		// This returns the short path name for a file
		public static string GetShortFilePath(string longpath)
		{
			int maxlen = 256;
			StringBuilder shortname = new StringBuilder(maxlen);
			uint len = General.GetShortPathName(longpath, shortname, (uint)maxlen);
			return shortname.ToString();
		}
		
		// This returns the active child control in the specified container
		public static Control FindActiveControl(IContainerControl container)
		{
			Control c = container.ActiveControl;

			while(c is IContainerControl)
			{
				IContainerControl cc = (c as IContainerControl);
				if(cc.ActiveControl != null)
					c = cc.ActiveControl;
				else
					break;
			}

			return c;
		}
	}
}
