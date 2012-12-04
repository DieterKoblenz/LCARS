
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
using System.Drawing.Imaging;
using System.Net;
using System.Net.Cache;

#endregion

namespace CodeImp.Gluon
{
	public partial class BuienradarDisplayPanel : DisplayPanel
	{
		#region ================== Constants
		
		private const string ADDRESS = "http://www2.buienradar.nl/forecast/nl-eu-forecast/loop.gif";
		private const string REFERRER = "http://www.buienradar.nl/buienradar-3-uur-vooruit.aspx";
		
		// Note that the QUICK delay, when multiplied by 2, never reaches the NORMAL delay exactly,
		// so that the delay is further increased and not reset to the QUICK delay again (see HandleFail)
		private const int NORMAL_UPDATE_DELAY = 240000;
		private const int QUICK_UPDATE_DELAY = 25000;
		private const int MAX_UPDATE_DELAY = 1200000;
		private const int IMMEDIATE_UPDATE_DELAY = 5000;

		// Ugly adjustment to match our local clock with the image time
		private const int ADJUST_TIME_MINUTES = -6;
		
		// Current location in pixel coordinates
		private const int LOCATION_X = 335;
		private const int LOCATION_Y = 465;
		private const int LOCATION_RADIUS = 2;
		
		// Frames needed to show a clear
		private const int CLEAR_FRAMES = 3;
		
		#endregion
		
		#region ================== Variables

		private Thread updatethread;
		private volatile bool updatefailed;
		private int nextupdatedelay;
		private Image[] images;
		private Size[] arrowlocations;
		private int imageindex;
		private DateTime firstimagetime;
		private string incomingtext = "";
		private string cleartext = "";
		private bool flashincoming;
		private bool flashclear;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public BuienradarDisplayPanel()
		{
			InitializeComponent();
			nextupdatedelay = 1;
			radar.TabIndex = 20;
		}

		#endregion

		#region ================== Methods
		
		// Setup colors
		public override void SetupColors(ColorPalette c)
		{
			base.SetupColors(c);
		}

		// This performs a new request
		public void RefreshList()
		{
			updatetimer.Stop();
			movearrowstimer.Stop();
			
			updatethread = new Thread(new ThreadStart(UpdateThread));
			updatethread.Name = "Buienradar Update";
			updatethread.Priority = ThreadPriority.BelowNormal;
			updatethread.Start();
		}
		
		// This handles failures
		private void HandleFail(string message)
		{
			General.WriteLogLine(message);
			updatefailed = true;
			
			// First error after success?	
			if(nextupdatedelay == NORMAL_UPDATE_DELAY)
			{
				// Try again earlier
				nextupdatedelay = QUICK_UPDATE_DELAY;
			}
			else
			{
				// Increase the delay
				nextupdatedelay = nextupdatedelay * 2;
				
				// Limit delay to 10 min
				if(nextupdatedelay > MAX_UPDATE_DELAY)
				{
					nextupdatedelay = MAX_UPDATE_DELAY;
					// TODO: Something is obviously wrong. Sound the alarm!
				}
			}
		}
		
		// This is called when an update completes
		private void UpdateComplete()
		{
			if(this.InvokeRequired)
			{
				VoidEventHandler d = new VoidEventHandler(UpdateComplete);
				this.BeginInvoke(d);
			}
			else
			{
				if(updatefailed)
				{
					failbutton.Text = "Scan Failed";
					failbutton.StartWarningFlash();
					incomingbutton.Text = "N / A";
					incomingbutton.StopWarningFlash();
					clearbutton.Text = "N / A";
					clearbutton.StopInfoFlash();
				}
				else
				{
					failbutton.Text = "Scan OK";
					failbutton.StopWarningFlash();
					incomingbutton.Text = incomingtext;
					if(flashincoming)
						incomingbutton.StartWarningFlash();
					else
						incomingbutton.StopWarningFlash();
					clearbutton.Text = cleartext;
					if(flashclear)
						clearbutton.StartInfoFlash();
					else
						clearbutton.StopInfoFlash();
				}
				
				// Start timer for next update
				updatetimer.Interval = nextupdatedelay;
				updatetimer.Start();
			}
		}
		
		// Background downloading and processing
		private unsafe void UpdateThread()
		{
			HttpWebResponse webresponse = null;
			bool failed = false;
			string failmsg = "";
			Image downloadimg = null;
			DateTime starttime = new DateTime();
			
			// Make the GET request
			HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(ADDRESS);
			webrequest.Referer = REFERRER;
			webrequest.Method = "GET";
			webrequest.KeepAlive = false;
			webrequest.Timeout = 5000;
			webrequest.UserAgent = "User-Agent: Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.14) Gecko/2009082707 Firefox/3.0.14 GTB5 (.NET CLR 3.5.30729)";
			webrequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
			
			try
			{
				// Download!
				webresponse = (HttpWebResponse)webrequest.GetResponse();
			}
			catch(Exception e)
			{
				failed = true;
				failmsg = "Failed to update buienradar. Web request " + e.GetType().Name + ": " + e.Message;
				webresponse = null;
			}
			
			if(!failed)
			{
				try
				{
					// Make image
					downloadimg = Image.FromStream(webresponse.GetResponseStream());
					webresponse.Close();
				}
				catch(Exception e)
				{
					failed = true;
					failmsg = "Failed to update buienradar. Image read " + e.GetType().Name + ": " + e.Message;
					downloadimg = null;
				}
			}
			
			if(!failed)
			{
				// Dispose old images
				if(images != null)
				{
					for(int i = 0; i < images.Length; i++)
						if(images[i] != null) images[i].Dispose();
				}
				
				images = null;
				arrowlocations = null;
				
				//#if !DEBUG
				try
				{
				//#endif
					// Time at which the animation starts
					DateTime now = DateTime.Now.AddMinutes(ADJUST_TIME_MINUTES);			
					int nearest5min = (int)(Math.Round((double)now.Minute / (double)5) * (double)5);
					starttime = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
					starttime = starttime.AddMinutes(nearest5min);
					
					// Prepare variables to track the rain
					DateTime incomingtime = new DateTime();
					bool isincoming = false;
					DateTime cleartime = new DateTime();
					int clearframecount = 0;
					
					// Disassemble the image into separate images
					FrameDimension fd = new FrameDimension(downloadimg.FrameDimensionsList[0]);
					int numimages = downloadimg.GetFrameCount(fd);
					images = new Image[numimages];
					downloadimg.SelectActiveFrame(fd, 0);
					Bitmap firstbmp = new Bitmap(downloadimg);
					Size sz = firstbmp.Size;
					BitmapData firstbmpdata = firstbmp.LockBits(new Rectangle(0, 0, sz.Width, sz.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
					for(int i = 0; i < numimages; i++)
					{
						downloadimg.SelectActiveFrame(fd, i);
						Bitmap imgbmp = new Bitmap(downloadimg);
						Bitmap newbmp = new Bitmap(sz.Width, sz.Height, PixelFormat.Format32bppArgb);
						
						// Start processing the image
						BitmapData imgbmpdata = imgbmp.LockBits(new Rectangle(0, 0, sz.Width, sz.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
						BitmapData newbmpdata = newbmp.LockBits(new Rectangle(0, 0, sz.Width, sz.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
						PixelColor* fpixels = (PixelColor*)(firstbmpdata.Scan0.ToPointer());
						PixelColor* ipixels = (PixelColor*)(imgbmpdata.Scan0.ToPointer());
						PixelColor* npixels = (PixelColor*)(newbmpdata.Scan0.ToPointer());
						
						// Go for all pixels
						bool wholeframeclear = true;
						for(int y = 0; y < sz.Height; y++)
						for(int x = 0; x < sz.Width; x++)
						{
							// We compare the pixel of the first image (no clouds) with
							// the current image to determine if there are clouds here
							bool isclear = (ipixels->b == fpixels->b) &&
										   (ipixels->g == fpixels->g) &&
										   (ipixels->r == fpixels->r);
							
							// Detect rain at current location
							if(!isclear && (x >= LOCATION_X - LOCATION_RADIUS) && (x <= LOCATION_X + LOCATION_RADIUS) &&
							               (y >= LOCATION_Y - LOCATION_RADIUS) && (y <= LOCATION_Y + LOCATION_RADIUS) && (i > 0))
							{
								wholeframeclear = false;
								
								if(!isincoming)
								{
									// Rain!
									incomingtime = starttime.AddMinutes(i * 10);
									isincoming = true;
									clearframecount = 0;
								}
								
								if(clearframecount < CLEAR_FRAMES)
									clearframecount = 0;
							}
							
							// Clear pixel?
							if(isclear)
							{
								// This pixel is normal.
								PixelColor ds = PixelColor.Desaturate(*ipixels);
								*npixels = PixelColor.Lerp(ds, *ipixels, 0.1f);
								*npixels = PixelColor.Scale(*npixels, 1.1f);
								PixelColor add = new PixelColor(0, 10, 10, 10);
								*npixels = PixelColor.Add(*npixels, add);
							}
							else
							{
								// This pixel is a cloud.
								PixelColor mod = new PixelColor(255, 160, 160, 250);
								*npixels = PixelColor.Modulate(*ipixels, mod);
								*npixels = PixelColor.Scale(*npixels, 1.8f);
							}
							
							// Next pixel
							fpixels++;
							ipixels++;
							npixels++;
						}

						// Whole frame clear of rain at current location?
						if(wholeframeclear)
						{
							// Count this frame as a clear frame
							clearframecount++;

							if(clearframecount == CLEAR_FRAMES)
							{
								// The clear time is 3 frames ago
								cleartime = starttime.AddMinutes((i - 3) * 10);
							}
						}
						
						// Clean up
						imgbmp.UnlockBits(imgbmpdata);
						newbmp.UnlockBits(newbmpdata);
						images[i] = newbmp;
						imgbmp.Dispose();
						imgbmp = null;
					}
					
					// Show incoming time
					if(isincoming)
					{
						incomingtext = incomingtime.Hour + ":" + incomingtime.Minute.ToString("00");
						flashincoming = true;
					}
					else
					{
						incomingtext = "N / A";
						flashincoming = false;
					}
					
					// Show clear time
					if(clearframecount >= CLEAR_FRAMES)
					{
						cleartext = cleartime.Hour + ":" + cleartime.Minute.ToString("00");
						flashclear = true;
					}
					else
					{
						cleartext = "N / A";
						flashclear = false;
					}
					
					// Clean up
					firstbmp.UnlockBits(firstbmpdata);
					firstbmp.Dispose();
					firstbmp = null;
					downloadimg.Dispose();
					downloadimg = null;
				//#if !DEBUG
				}
				catch(Exception e)
				{
					failed = true;
					failmsg = "Failed to update buienradar. Image processing " + e.GetType().Name + ": " + e.Message;
					downloadimg = null;
				}
				//#endif
				
				if(images != null)
				{
					// Set up some random arrow locations, for decorative reason
					Random rnd = new Random();
					arrowlocations = new Size[images.Length];
					Size offset = new Size(radar.Left + 100 + rnd.Next(radar.Width - movearrow1.Width - 100), radar.Top + 100 + rnd.Next(radar.Height - movearrow1.Height - 100));
					for(int i = 0; i < images.Length; i++)
						arrowlocations[i] = offset + new Size(rnd.Next(100) - 50, rnd.Next(100) - 50);
				}
				
				// Done
				firstimagetime = starttime;
				nextupdatedelay = NORMAL_UPDATE_DELAY;
			}
			
			// Handle failure
			if(failed)
				HandleFail(failmsg);
			else
				updatefailed = false;
			
			// We're done updating (either successful or failed)
			UpdateComplete();
		}
		
		// This shows a specific frame by index
		private void ShowIndex(int index)
		{
			imageindex = index;
			
			// Labels
			DateTime frametime = firstimagetime.AddMinutes(imageindex * 10);
			timelabel.Text = frametime.Hour + ":" + frametime.Minute.ToString("00");
			framelabel.Text = imageindex.ToString("00");
			
			// Image
			if(images != null)
				radar.Image = images[imageindex];
			radar.Update();
		}
		
		#endregion

		#region ================== Events
		
		// When panel is shown
		public override void OnShow()
		{
			base.OnShow();
			
			// Wait for any update to complete
			if(updatethread != null)
				updatethread.Join();
			
			// Setup animation
			ShowIndex(0);
			animatetimer.Start();
			holdbutton.StopInfoFlash();
			movearrowstimer.Start();
		}
		
		// When panel is hidden
		public override void OnHide()
		{
			base.OnHide();
			animatetimer.Stop();
			movearrowstimer.Stop();
			holdbutton.StopInfoFlash();
		}
		
		// Update!
		private void updatetimer_Tick(object sender, EventArgs e)
		{
			updatetimer.Stop();
			
			// We don't want to update while watching
			if(!this.Visible)
			{
				RefreshList();
			}
			else
			{
				updatetimer.Interval = IMMEDIATE_UPDATE_DELAY;
				updatetimer.Start();
			}
		}
		
		// Toggle animation
		private void holdbutton_Click(object sender, EventArgs e)
		{
			if(!holdbutton.IsInfoFlashing)
			{
				animatetimer.Stop();
				holdbutton.StartInfoFlash();
			}
			else
			{
				animatetimer.Start();
				holdbutton.StopInfoFlash();
			}
		}
		
		// Animate
		private void animatetimer_Tick(object sender, EventArgs e)
		{
			if(images == null)
				return;
			
			imageindex++;
			if(imageindex == images.Length)
				imageindex = 0;
			
			ShowIndex(imageindex);
		}
		
		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}
		
		// One frame back
		private void backbutton_Click(object sender, EventArgs e)
		{
			if(images == null)
				return;

			imageindex--;
			if(imageindex < 0)
				imageindex = 0;
			
			ShowIndex(imageindex);
		}
		
		// One frame forward
		private void forwardbutton_Click(object sender, EventArgs e)
		{
			if(images == null)
				return;
			
			imageindex++;
			if(imageindex == images.Length)
				imageindex = images.Length - 1;
			
			ShowIndex(imageindex);
		}
		
		// Move arrows (purely decorative)
		private void movearrowstimer_Tick(object sender, EventArgs e)
		{
			if(arrowlocations != null)
			{
				Size dest = arrowlocations[imageindex];
				movearrow1.Left = (dest.Width + movearrow1.Left) / 2;
				movearrow2.Top = (dest.Height + movearrow2.Top) / 2;
			}
		}
		
		#endregion
	}
}
