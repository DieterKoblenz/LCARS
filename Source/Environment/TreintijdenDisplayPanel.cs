
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
using System.Net;
using System.Net.Cache;
using System.Xml;

#endregion

namespace CodeImp.Gluon
{
	public partial class TreintijdenDisplayPanel : DisplayPanel
	{
		#region ================== Constants
		
		private const string STATION_NAME = "your_city";
		private const string POST_DATA = "POST_AUTOCOMPLETE=%2Freisplanner-v2%2Fautocomplete.ajax&POST_VALIDATE=%2Freisplanner-v2%2FtravelAdviceValidation.ajax&SITESTAT_ELEMENTS=sitestatElements&van_heen_station=" + STATION_NAME + "&";
		private const string ADDRESS = "http://ns.nl/actuele-vertrektijden/main.action?xml=true";
		private const string REFERRER = "http://ns.nl/actuele-vertrektijden/main.action";
		private const string COOKIES = "ns_cookietest=true; userInformation=\"false,false,false,false,TILL5,OPTIMAL\"; rl-sticky-key-0a=ae54bd578471f12619a36f81f2beb077; ns_cookietest=true; ns_session=true; SS_X_JSESSIONID=D25383C6495B33F1193876881AB5E4A7; rl-sticky-key-2=d4c8774f4c00988eb183dcba3310a907; JSESSIONID=51035DD03C54FA8148A31BC102E394C6; rl-sticky-key-1=b05eaddb4e3dbbd21915bc7d3cbd1c4a; r1-sticky-key-4=b05eaddb4e3dbbd21915bc7d3cbd1c4a";
		private const int WALK_MINUTES = 6;

		// Note that the QUICK delay, when multiplied by 2, never reaches the NORMAL delay exactly,
		// so that the delay is further increased and not reset to the QUICK delay again (see HandleFail)
		private const int NORMAL_UPDATE_DELAY = 20000;
		private const int QUICK_UPDATE_DELAY = 6000;
		private const int MAX_UPDATE_DELAY = 600000;
		
		#endregion
		
		#region ================== Variables
		
		private Thread updatethread;
		private int nextupdatedelay;
		private XmlDocument xml;
		private DisplayButton[,] items;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public TreintijdenDisplayPanel()
		{
			InitializeComponent();
			nextupdatedelay = QUICK_UPDATE_DELAY;
			
			// Make array: 10 rows, 6 columns
			items = new DisplayButton[10, 6];
			items[0, 0] = time0; items[0, 1] = delay0; items[0, 2] = direction0; items[0, 3] = spoor0; items[0, 4] = type0; items[0, 5] = warning0;
			items[1, 0] = time1; items[1, 1] = delay1; items[1, 2] = direction1; items[1, 3] = spoor1; items[1, 4] = type1; items[1, 5] = warning1;
			items[2, 0] = time2; items[2, 1] = delay2; items[2, 2] = direction2; items[2, 3] = spoor2; items[2, 4] = type2; items[2, 5] = warning2;
			items[3, 0] = time3; items[3, 1] = delay3; items[3, 2] = direction3; items[3, 3] = spoor3; items[3, 4] = type3; items[3, 5] = warning3;
			items[4, 0] = time4; items[4, 1] = delay4; items[4, 2] = direction4; items[4, 3] = spoor4; items[4, 4] = type4; items[4, 5] = warning4;
			items[5, 0] = time5; items[5, 1] = delay5; items[5, 2] = direction5; items[5, 3] = spoor5; items[5, 4] = type5; items[5, 5] = warning5;
			items[6, 0] = time6; items[6, 1] = delay6; items[6, 2] = direction6; items[6, 3] = spoor6; items[6, 4] = type6; items[6, 5] = warning6;
			items[7, 0] = time7; items[7, 1] = delay7; items[7, 2] = direction7; items[7, 3] = spoor7; items[7, 4] = type7; items[7, 5] = warning7;
			items[8, 0] = time8; items[8, 1] = delay8; items[8, 2] = direction8; items[8, 3] = spoor8; items[8, 4] = type8; items[8, 5] = warning8;
			items[9, 0] = time9; items[9, 1] = delay9; items[9, 2] = direction9; items[9, 3] = spoor9; items[9, 4] = type9; items[9, 5] = warning9;
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
			
			updatethread = new Thread(new ThreadStart(UpdateThread));
			updatethread.Name = "Treintijden Update";
			updatethread.Priority = ThreadPriority.BelowNormal;
			updatethread.Start();
		}
		
		// This handles failures
		private void HandleFail(string message)
		{
			General.WriteLogLine(message);
			
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
			
			xml = null;
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
				try
				{
					// Size label, totally useless, purely decorative
					float xmllen = (float)xml.InnerText.Length * 13.117f;
					sizelabel.Text = xmllen.ToString("0 . 000 B");
					
					// Received as "Dordrecht - 15:34"
					string titletext = xml.DocumentElement.FirstChild.InnerText;
					
					// Determine current time plus walk time to compare with
					int lastspace = titletext.TrimEnd().LastIndexOf(' ');
					int separator = titletext.IndexOf(':');
					string hourstr = titletext.Substring(lastspace + 1, separator - lastspace - 1);
					string minutestr = titletext.Substring(separator + 1).TrimEnd();
					int hourint = int.Parse(hourstr);
					int minuteint = int.Parse(minutestr);
					DateTime statstime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourint, minuteint, 1);
					statstime = statstime.AddMinutes(WALK_MINUTES);
					titlelabel.Text = hourstr + ":" + minuteint.ToString("00");
					
					// Move to the first <tr> element for the first item
					XmlNode xmlitem = xml.DocumentElement.FirstChild.NextSibling;
					xmlitem = xmlitem.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.FirstChild;
					
					// Setup the items on screen using the XML data
					for(int i = 0; i < items.GetLength(0); i++)
					{
						if(xmlitem != null)
						{
							string warning = "";
							bool warningserious = false;
							
							// Show all cells in normal state
							for(int c = 0; c < items.GetLength(1); c++)
							{
								items[i, c].StopInfoFlash();
								items[i, c].StopWarningFlash();
							}
							
							// Time and delay (received in a format like "16:45 + 2 min.")
							string xmltime = xmlitem.FirstChild.InnerText.Trim();
							int pluspos = xmltime.IndexOf('+');
							string timeonly = xmltime;
							string delayonly = "";
							if(pluspos > -1)
							{
								timeonly = timeonly.Substring(0, pluspos - 1);
								int minpos = xmltime.IndexOf("min.");
								delayonly = xmltime.Substring(pluspos, (minpos - pluspos) - 1);
								items[i, 1].StartWarningFlash();
							}
							items[i, 0].Text = timeonly;
							items[i, 1].Text = delayonly;
							items[i, 0].Visible = true;
							items[i, 1].Visible = true;

							// Determine time for comparison
							int firstspace = xmltime.IndexOf(' ');
							if(firstspace == -1) firstspace = xmltime.Length;
							separator = xmltime.IndexOf(':');
							hourstr = xmltime.Substring(0, separator);
							minutestr = xmltime.Substring(separator + 1, firstspace - separator - 1);
							hourint = int.Parse(hourstr);
							minuteint = int.Parse(minutestr);
							DateTime itemtime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hourint, minuteint, 0);
							if(itemtime.Ticks < statstime.Ticks)
								items[i, 0].StartInfoFlash();
							
							// Direction
							string direction = xmlitem.FirstChild.NextSibling.InnerText;
							items[i, 2].Text = direction.Trim();
							items[i, 2].Visible = true;

							// Spoor
							XmlNode spoorxml = xmlitem.FirstChild.NextSibling.NextSibling;
							items[i, 3].Text = spoorxml.InnerText.Trim();
							items[i, 3].Visible = true;
							XmlNode spoorclassxml = spoorxml.Attributes.GetNamedItem("class");
							if(spoorclassxml != null)
								items[i, 3].StartWarningFlash();

							// Type (try finding a warning in here as well)
							XmlNode typexml = xmlitem.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling;
							string type = typexml.InnerText.TrimStart();
							int spacepos = type.IndexOf(' ');
							if(spacepos > -1)
							{
								string beforespace = type.Substring(0, spacepos).Trim();
								
								// In case of "Rijdt vandaag niet" there is no train type
								if(string.Compare(beforespace, "Rijdt", true) == 0)
								{
									spacepos = 0;
									beforespace = "N/A";
									warningserious = true;
									
									// Make the entire row flash
									for(int c = 0; c < items.GetLength(1); c++)
										items[i, c].StartWarningFlash();
								}
								
								string afterspace = type.Substring(spacepos).Trim();
								type = Tools.StripExcessiveWhitespace(beforespace.Replace(",", ""));
								
								if(afterspace.Length > 0)
								{
									afterspace = afterspace.TrimStart(',');
									warning = Tools.StripExcessiveWhitespace(afterspace.Trim());

									// If the site indicates the text in red, so do we (exceptions below)
									warningserious = (typexml.FirstChild.NextSibling != null) && (typexml.FirstChild.NextSibling.Name == "span");

									if(warning.StartsWith("extra", StringComparison.InvariantCultureIgnoreCase))
										warningserious = false;
								}
							}
							items[i, 4].Text = type.Trim();
							items[i, 4].Visible = true;

							// Determine row color
							ColorIndex rowcolor = ColorIndex.ControlNormal;
							if(type.StartsWith("Sneltrein"))
								rowcolor = ColorIndex.ControlColor3;
							else if(type.StartsWith("Stoptrein"))
								rowcolor = ColorIndex.ControlColor4;
							else if(type.StartsWith("Sprinter"))
								rowcolor = ColorIndex.ControlColor4;
							
							// Give the entire row a color
							for(int c = 0; c < items.GetLength(1); c++)
							{
								items[i, c].ColorNormal = rowcolor;
								items[i, c].SetupColors(General.Colors);
							}

							// Any warning to show?
							if(warning.Length > 0)
							{
								Font f;
								if(warning.Length < 20)
									f = items[i, 4].Font;
								else
									f = smallfontexample.Font;
								items[i, 5].Font = f;
								items[i, 5].Text = warning;
								if(warningserious)
									items[i, 5].StartWarningFlash();
								else
									items[i, 5].StartInfoFlash();
								items[i, 5].Visible = true;
							}
							else
							{
								items[i, 5].Visible = false;
							}
							
							// Move to the next <tr> element
							xmlitem = xmlitem.NextSibling;
						}
						else
						{
							// No more items, so hide these cells
							for(int c = 0; c < items.GetLength(1); c++)
							{
								items[i, c].StopInfoFlash();
								items[i, c].StopWarningFlash();
								items[i, c].Visible = false;
							}
						}
					}
				}
				catch(Exception e)
				{
					HandleFail("Failed to update treintijden. " + e.GetType().Name + ": " + e.Message);
				}
				
				// Start timer for next update
				updatetimer.Interval = nextupdatedelay;
				updatetimer.Start();
			}
		}
		
		// Background downloading and processing
		private void UpdateThread()
		{
			HttpWebResponse webresponse = null;
			bool failed = false;
			string failmsg = "";
			
			ASCIIEncoding encoding = new ASCIIEncoding();
			byte[] bytedata = encoding.GetBytes(POST_DATA);
			
			// Make the POST request
			HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(ADDRESS);
			webrequest.Referer = REFERRER;
			webrequest.Method = "POST";
			webrequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
			webrequest.ContentLength = POST_DATA.Length;
			webrequest.KeepAlive = true;
			webrequest.Timeout = 4000;
			webrequest.Accept = "text/xml,application/xml";
			webrequest.UserAgent = "User-Agent: Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.14) Gecko/2009082707 Firefox/3.0.14 GTB5 (.NET CLR 3.5.30729)";
			webrequest.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
			
			try
			{
				// Add the POST data
				Stream webrequeststream = webrequest.GetRequestStream();
				webrequeststream.Write(bytedata, 0, POST_DATA.Length);
				webrequeststream.Close();
				
				// Download!
				webresponse = (HttpWebResponse)webrequest.GetResponse();
			}
			catch(Exception e)
			{
				failed = true;
				failmsg = "Failed to receive treintijden. Web request " + e.GetType().Name + ": " + e.Message;
				webresponse = null;
			}
			
			// Check result
			if(!failed)
			{
				if((webresponse != null) && (webresponse.StatusCode == HttpStatusCode.OK))
				{
					// Read entire response
					StreamReader reader = new StreamReader(webresponse.GetResponseStream());
					string xmltext = reader.ReadToEnd();
					
					// Done with the link
					webresponse.Close();
					
					XmlDocument newxml = new XmlDocument();
					XmlDocument newhtml = new XmlDocument();
					try
					{
						newxml.LoadXml(xmltext);
						string htmltext = "<html>" + newxml.DocumentElement.InnerText + "</html>";

						// Fix what the parser doesn't like
						htmltext = htmltext.Replace("&copy;", "");
						htmltext = htmltext.Replace("ns:sitestat", "title");
						htmltext = htmltext.Replace("<p>", "");
						htmltext = htmltext.Replace("</p>", "");
						
						newhtml.LoadXml(htmltext);
						
						xml = newhtml;
						
						// 20 sec delay until next update
						nextupdatedelay = NORMAL_UPDATE_DELAY;
					}
					catch(Exception e)
					{
						failed = true;
						failmsg = "Failed to parse treintijden. Web response parse " + e.GetType().Name + ": " + e.Message;
					}
				}
				else
				{
					failed = true;
					if(webresponse != null)
						failmsg = "Failed to receive treintijden. Web response code " + webresponse.StatusCode + ": " + webresponse.StatusDescription;
					else
						failmsg = "Failed to receive treintijden. Web response is NULL.";
				}
			}
			
			// Handle failure
			if(failed)
				HandleFail(failmsg);
			
			// We're done updating (either successful or failed)
			UpdateComplete();
		}
		
		#endregion

		#region ================== Events
		
		// When panel is shown
		public override void OnShow()
		{
			base.OnShow();
		}
		
		// When panel is hidden
		public override void OnHide()
		{
			base.OnHide();
		}
		
		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}
		
		// Update!
		private void updatetimer_Tick(object sender, EventArgs e)
		{
			RefreshList();
		}
		
		#endregion
	}
}
