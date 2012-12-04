
#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

#endregion

namespace CodeImp.Gluon
{
	public partial class MainForm : Form
	{
		#region ================== Constants
		
		private const int ORIG_RES_HEIGHT = 1024;
		
		#endregion

		#region ================== Events
		
		public delegate void FlashWarningDelegate();
		public delegate void FlashInfoDelegate();

		public event FlashWarningDelegate FlashWarning;
		public event FlashInfoDelegate FlashInfo;
		
		#endregion

		#region ================== Variables

		// Screensaver
		private bool savingmode;
		private int disablecounter;
		private Point lastmousepos;
		
		// Flashing
		private bool warningflashstate;
		private bool infoflashstate;
		
		// View panels
		private string nextpaneltag;
		private string currentpaneltag;
		
		#endregion

		#region ================== Properties

		public bool WarningFlashState { get { return warningflashstate; } }
		public bool InfoFlashState { get { return infoflashstate; } }
		public string NextPanelTag { get { return nextpaneltag; } }
		public string CurrentPanelTag { get { return currentpaneltag; } }
		public AccessDisplayPanel AccessPanel { get { return accesspanel; } }
		public ErrorDisplayPanel ErrorPanel { get { return errorpanel; } }
		public OverviewDisplayPanel OverviewPanel { get { return overviewpanel; } }
		public ObexTransferDisplayPanel ObexTransferPanel { get { return transferobexpanel; } }
		public NotesDisplayPanel NotesPanel { get { return notespanel; } }
		public GroceriesDisplayPanel GroceriesPanel { get { return groceriespanel; } }
		public AddGroceriesDisplayPanel AddGroceriesPanel { get { return addgroceriespanel; } }
		public MediaPlayerDisplayPanel MediaPlayerPanel { get { return mediaplayerpanel; } }
		public PlaylistsDisplayPanel PlaylistsPanel { get { return playlistspanel; } }
		public LibraryBrowserDisplayPanel LibraryBrowser { get { return librarybrowserpanel; } }

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public MainForm()
		{
			InitializeComponent();
			
			#if DEBUG
				this.TopMost = false;
			#else
				this.TopMost = true;
				Cursor.Hide();
			#endif

			// Position window on primary display
			if(General.Settings.LiveEnvironment)
				this.Left = 10;
			else
				this.Left = -2000;
			
			// Exchange some references
			agendapanel.DayEditor = agendadaypanel;
			agendapanel.ItemEditor = agendaitempanel;
			agendadaypanel.ItemEditor = agendaitempanel;

			this.SuspendLayout();
			
			// Arrange panels
			foreach(Control c in base.Controls)
			{
				if(c is DisplayPanel)
				{
					DisplayPanel dp = (c as DisplayPanel);
					dp.Location = new Point(0, 0);
					dp.Size = this.ClientSize;
					dp.Hide();
				}
			}
			
			// Scale to resolution
			//float scale = (float)Screen.PrimaryScreen.Bounds.Height / (float)ORIG_RES_HEIGHT;
			//this.Scale(new SizeF(scale, scale));
			
			this.ResumeLayout(true);
			
			SetupColors(General.Colors);
			
			// Start stuff up
			treintijdenpanel.RefreshList();
			buienradarpanel.RefreshList();
		}
		
		#endregion
		
		#region ================== Methods

		public delegate void StringEventHandler(string s);
		
		public void ShowLogLine(string text)
		{
			/*
			if(this.InvokeRequired)
			{
				StringEventHandler d = new StringEventHandler(ShowLogLine);
				this.Invoke(d, text);
			}
			else
			{
				logbox.Text = logbox.Text + text + "\r\n";
				logbox.SelectionStart = logbox.Text.Length - 2;
				logbox.ScrollToCaret();
			}
			*/
		}

		// This shows the panel with the given tag
		public void ShowTaggedPanel(string tag)
		{
			nextpaneltag = tag;
			
			// First hide any panels
			foreach(Control c in base.Controls)
			{
				if(c is DisplayPanel)
				{
					if((c.Visible) && (string.Compare(c.Tag.ToString(), tag, true) != 0))
					{
						c.Hide();
						(c as DisplayPanel).OnHide();
					}
				}
			}
			
			// Now show the panel we need
			foreach(Control c in base.Controls)
			{
				if(c is DisplayPanel)
				{
					if((!c.Visible) && (string.Compare(c.Tag.ToString(), tag, true) == 0))
					{
						(c as DisplayPanel).OnShow();
						c.Show();
						currentpaneltag = c.Tag.ToString();
					}
				}
			}
		}
		
		// This must set up all the colors
		// Also call this function on child controls
		public void SetupColors(ColorPalette c)
		{
			General.LockWindowUpdate(this.Handle);
			
			this.BackColor = c[ColorIndex.WindowBackground];

			// Setup colors on child controls
			foreach(Control cc in base.Controls)
			{
				if(cc is IColorable)
					(cc as IColorable).SetupColors(c);
			}
			
			General.LockWindowUpdate(IntPtr.Zero);
		}
		
		// This reports user input, so that the screensaver
		// is not kicking in too soon
		public void UserActivity()
		{
			// Restart screensaver timing, if running
			if(disablecounter == 0)
			{
				screensaver.Stop();
				screensaver.Start();
			}
			
			// If in saving mode, then go back to normal
			if(savingmode)
			{
				savingmode = false;
				General.Colors.SetupNormalScheme();
				SetupColors(General.Colors);
			}
			
			// Keep last mouse position
			lastmousepos = Cursor.Position;
		}
		
		// This disables the screensaver
		public void DisableScreensaver()
		{
			disablecounter++;
			
			if(disablecounter == 1)
			{
				UserActivity();
				screensaver.Stop();
			}
		}
		
		// This enables the screensaver
		public void EnableScreensaver()
		{
			disablecounter--;
			
			if(disablecounter < 0) disablecounter = 0;
			if(disablecounter == 0)
			{
				screensaver.Start();
			}
		}
		
		#endregion
		
		#region ================== Events
		
		// Screensaver kicks in!
		private void screensaver_Tick(object sender, EventArgs e)
		{
			if(disablecounter == 0)
			{
				if(!savingmode)
				{
					// Return to overview
					ShowTaggedPanel("overview");
					overviewpanel.ShowTechPanel(0);
					
					// Darken the screen
					savingmode = true;
					General.Colors.SetupDarkScheme();
					SetupColors(General.Colors);
				}
			}
		}
		
		// Special keypresses
		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			UserActivity();
			
			// CTRL+SHIFT+C to change colors
			if((e.KeyCode == Keys.C) && e.Control && e.Shift && !e.Alt)
			{
				ColorsForm f = new ColorsForm();
				f.ShowDialog(this);
				f.Dispose();
				General.Settings.SaveSettings();
				e.Handled = true;
			}
			
			// CTRL+SHIFT+X closes the program
			if((e.KeyCode == Keys.X) && e.Control && e.Shift && !e.Alt)
			{
				Application.Exit();
			}
		}
		
		// Warning flasher
		private void warningflasher_Tick(object sender, EventArgs e)
		{
			warningflashstate = !warningflashstate;
			if(FlashWarning != null) FlashWarning();
		}
		
		// Info flasher
		private void infoflasher_Tick(object sender, EventArgs e)
		{
			infoflashstate = !infoflashstate;
			if(FlashInfo != null) FlashInfo();
		}

		// Activity checking
		private void activitychecker_Tick(object sender, EventArgs e)
		{
			Cursor.Show();
			#if !DEBUG
			this.Cursor = Cursors.No;
			this.Cursor = Cursors.Default;
			Cursor.Hide();
			#endif
			
			// Check if the mouse moved
			if(Cursor.Position != lastmousepos)
				UserActivity();

			// Process power management
			General.Power.Process();
		}
		
		// Receive messages
		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
				// Display sends us its HWND
				case (int)InterProcess.MSG_HWND:
					InterProcess.otherhwnd = m.WParam;
					break;

				// Data message
				case (int)InterProcess.WM_COPYDATA:
					InterProcess.HandleDataMessage(ref m);
					break;
					
				default:
					base.WndProc(ref m);
					break;
			}
		}
		
		#endregion
	}
}