
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
	public partial class InternetDisplayPanel : DisplayPanel
	{
		#region ================== Variables
		
		private int scrolldelta;
		private int scrolloffset;
		private bool scrollpressed;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public InternetDisplayPanel()
		{
			InitializeComponent();
		}

		#endregion

		#region ================== Methods
		
		// Setup colors
		public override void SetupColors(ColorPalette c)
		{
			base.SetupColors(c);
			
			addressbox.BackColor = General.Colors[ColorIndex.ControlNormal];
			addressbox.ForeColor = General.Colors[ColorIndex.ControlNormalText];
		}

		// Show links panel
		public void ShowLinks()
		{
			browserframe.Height = inputframe.Bottom - linksframe.Height - browserframe.Top - (inputbutton.Top - inputframe.Bottom);
			linksbutton.StartInfoFlash();
			inputbutton.StopInfoFlash();
			optionsbutton.StopInfoFlash();
			inputframe.Hide();
			optionsframe.Hide();
			linksframe.Left = inputframe.Left;
			linksframe.Top = inputframe.Bottom - linksframe.Height;
			linksframe.Show();
		}

		// Show options panel
		public void ShowOptions()
		{
			browserframe.Height = inputframe.Bottom - optionsframe.Height - browserframe.Top - (inputbutton.Top - inputframe.Bottom);
			linksbutton.StopInfoFlash();
			inputbutton.StopInfoFlash();
			optionsbutton.StartInfoFlash();
			inputframe.Hide();
			linksframe.Hide();
			optionsframe.Left = inputframe.Left;
			optionsframe.Top = inputframe.Bottom - optionsframe.Height;
			optionsframe.Show();
		}

		// Show input panel
		public void ShowInput()
		{
			browserframe.Height = inputframe.Top - browserframe.Top - (inputbutton.Top - inputframe.Bottom);
			inputbutton.StartInfoFlash();
			linksbutton.StopInfoFlash();
			optionsbutton.StopInfoFlash();
			optionsframe.Hide();
			linksframe.Hide();
			inputframe.Show();
		}

		// Show browser only
		public void MaximizeBrowser()
		{
			browserframe.Height = inputbutton.Top - browserframe.Top - (inputbutton.Top - inputframe.Bottom);
			inputbutton.StopInfoFlash();
			linksbutton.StopInfoFlash();
			optionsbutton.StopInfoFlash();
			optionsframe.Hide();
			inputframe.Hide();
			linksframe.Hide();
		}
		
		// This resets the page
		public void Reset()
		{
			ShowLinks();

			browser.Stop();
			
			if((browser.Url == null) || (browser.Url.AbsoluteUri != "about:blank"))
				browser.Navigate("about:blank");

			double starttime = General.Clock.GetCurrentTime();
			while(browser.IsBusy && (General.Clock.GetCurrentTime() < starttime + 200))
				Thread.Sleep(10);
			
			browser.Document.BackColor = General.Colors.GetNormalColor(ColorIndex.ControlColor3);
		}

		// This updates the option buttons
		private void UpdateOptionButtons()
		{
			bool downloadable = false;
			bool videoshowable = false;

			showvideobutton.Enabled = videoshowable;
			showvideobutton.SetupColors(General.Colors);
			showvideobutton.StopWarningFlash();
		}
		
		#endregion

		#region ================== Events
		
		// When panel is shown
		public override void OnShow()
		{
			General.Sounds.SetAudioOutputPrimary();

			// Create the browser
			browser = new DisplayWebBrowser();
			browser.AllowWebBrowserDrop = false;
			browser.IsWebBrowserContextMenuEnabled = false;
			browser.Location = new System.Drawing.Point(0, 0);
			browser.Dock = DockStyle.Fill;
			browser.MinimumSize = new System.Drawing.Size(20, 20);
			browser.Name = "browser";
			browser.ScriptErrorsSuppressed = true;
			browser.ScrollBarsEnabled = false;
			browser.TabIndex = 999;
			browser.WebBrowserShortcutsEnabled = true;
			browser.ProgressChanged += browser_ProgressChanged;
			browser.Navigating += browser_Navigating;
			browser.NewWindow += browser_NewWindow;
			browser.DocumentCompleted += browser_DocumentCompleted;
			browser.Navigated += browser_Navigated;
			browser.FileDownload += browser_FileDownload;
			browserframe.Controls.Add(browser);
			browser.SendToBack();
			
			Reset();
			
			base.OnShow();
			
			General.MainWindow.DisableScreensaver();
		}
		
		// When panel is hidden
		public override void OnHide()
		{
			onscreenbutton.StopInfoFlash();
			scrolltimer.Stop();
			General.Sounds.Stop("list");
			
			if(General.Display.DisplayMode == DisplayMode.Clone)
				General.Display.ShowNothing();
			
			base.OnHide();

			Reset();

			General.Sounds.SetAudioOutputPrimary();
			General.MainWindow.EnableScreensaver();
			
			// Remove the browser
			browserframe.Controls.Remove(browser);
			browser.Dispose();
			browser = null;
		}
		
		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}
		
		// Navigate to given address
		private void gobutton_Click(object sender, EventArgs e)
		{
			General.Sounds.SetAudioOutputPrimary();
			browser.Navigate(addressbox.Text);
		}
		
		// Back to previous page
		private void backbutton_Click(object sender, EventArgs e)
		{
			General.Sounds.SetAudioOutputPrimary();
			browser.GoBack();
		}
		
		// Show/hide Input
		private void inputbutton_Click(object sender, EventArgs e)
		{
			if(!inputframe.Visible)
				ShowInput();
			else
				MaximizeBrowser();
		}
		
		// Show/hide links
		private void linksbutton_Click(object sender, EventArgs e)
		{
			if(!linksframe.Visible)
				ShowLinks();
			else
				MaximizeBrowser();
		}
		
		// Browser navigates to different page
		private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			Uri url = (browser.Document != null) ? browser.Document.Url : e.Url;

			General.Sounds.SetAudioOutputPrimary();

			// Ignore everything that startswith about:
			if(url.Scheme.ToLowerInvariant() != "about")
			{
				// When the website address begins with http: then hide that part
				if(url.Scheme.ToLowerInvariant() == "http")
					addressbox.Text = url.ToString().Substring(7);
				else
					addressbox.Text = url.ToString();
			}
		}
		
		// Browser navigates to different page
		private void browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			UpdateOptionButtons();
			
			// Loop the loading sound
			//General.Sounds.PlayLoop("226");
		}
		
		// Browser downloads page
		private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
		{
			if(browser.DocumentText != null)
				sizelabel.Text = browser.DocumentText.Length.ToString();
		}
		
		// Browser is done doanloading page
		private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			UpdateOptionButtons();
			
			// Stop the loading sound
			//General.Sounds.Stop("226");
		}

		// Browser downloads a file
		private void browser_FileDownload(object sender, EventArgs e)
		{
		}
		
		// Browser wants to open a new window
		private void browser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// We won't let it.
			e.Cancel = true;
		}
		
		// Link button event handler
		private void TaggedLinkClick(object sender, EventArgs e)
		{
			string tag = (string)((sender as Control).Tag);
			addressbox.Text = tag;
			MaximizeBrowser();
			gobutton_Click(sender, e);
		}

		// Press on scrollbar
		private void scrollbar_MouseDown(object sender, MouseEventArgs e)
		{
			General.Sounds.PlayLoop("list");
			scrolloffset = e.Y;
			scrollpressed = true;
		}
		
		// Mouse over scrollbar
		private void scrollbar_MouseMove(object sender, MouseEventArgs e)
		{
			// Document loaded?
			if(browser.Document != null)
			{
				// Dragging?
				if(scrollpressed)
				{
					/*
					// Determine percentage
					float u = Tools.Clamp((float)(e.Y - (scrollupbutton.Height / 2))  / (float)(scrollbar.ClientRectangle.Height - scrollupbutton.Height), 0.0f, 1.0f);
					
					// Scroll
					int range = browser.Document.Window.Size.Height - browser.ClientRectangle.Height;
					browser.Document.Window.ScrollTo(0, (int)((float)range * u));
					*/
					
					int pos = browser.Document.Body.Parent.ScrollTop;
					browser.Document.Window.ScrollTo(0, pos + (e.Y - scrolloffset) * 3);
					scrolloffset = e.Y;
				}
			}
		}

		// Release scrollbar
		private void scrollbar_MouseUp(object sender, MouseEventArgs e)
		{
			if(scrollpressed)
			{
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
				scrollpressed = false;
			}
		}
		
		// Handle keypresses in address box
		private void addressbox_KeyDown(object sender, KeyEventArgs e)
		{
			// Go when enter is pressed
			if((e.KeyCode == Keys.Enter) && !e.Shift && !e.Control && !e.Alt)
			{
				gobutton_Click(sender, EventArgs.Empty);
				e.Handled = true;
			}
		}
		
		// Start scrolling up
		private void scrollupbutton_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = -50;
			scrolltimer.Start();
			scrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}
		
		// Start scrolling down
		private void scrolldownbutton_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = 50;
			scrolltimer.Start();
			scrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}
		
		// Stop scrolling
		private void scrollbutton_MouseUp(object sender, MouseEventArgs e)
		{
			scrolltimer.Stop();
			General.Sounds.Stop("list");
			General.Sounds.Play("214");
		}
		
		// Scroll!
		private void scrolltimer_Tick(object sender, EventArgs e)
		{
			// Document loaded?
			if(browser.Document != null)
			{
				int pos = browser.Document.Body.Parent.ScrollTop;
				browser.Document.Window.ScrollTo(0, pos + scrolldelta);
			}
		}
		
		// Show/hide options
		private void optionsbutton_Click(object sender, EventArgs e)
		{
			if(!optionsframe.Visible)
				ShowOptions();
			else
				MaximizeBrowser();
		}

		// Clone screen
		private void onscreenbutton_Click(object sender, EventArgs e)
		{
			// Just clone the screen
			//General.Display.ShowClone();
			onscreenbutton.StartInfoFlash();
		}

		// Show video
		private void showvideobutton_Click(object sender, EventArgs e)
		{
			if((browser == null) || (browser.Document == null))
				return;

			Uri url = browser.Document.Url;

			// Check if we're at a youtube video page
			if(url.ToString().ToLowerInvariant().Contains("youtube.com/watch"))
			{
				// Find the youtube video ID from the url query (it is right after v=)
				int vpos = url.Query.IndexOf("v=");
				if(vpos > -1)
				{
					string id;
					int endpos = url.Query.IndexOf("&", vpos + 1);
					if(endpos == -1)
						id = url.Query.Substring(vpos + 2);
					else
						id = url.Query.Substring(vpos + 2, endpos - (vpos + 2));

					// Play this youtube video fullscreen
					// TODO: Try using an iframe with http://www.youtube.com/v/videoid in it and a javascript to autoplay.
					onscreenbutton.StopInfoFlash();
					string html = Properties.Resources.youtubehtml;
					html = html.Replace("%width", "1920");
					html = html.Replace("%height", "1080");
					html = html.Replace("%id", id);
					General.Display.ShowHTML(html);
					showvideobutton.StopWarningFlash();
				}
				else
				{
					// Unable to find the movie id
					showvideobutton.StartWarningFlash();
				}
			}
		}
		
		#endregion
	}
}
