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
using WMPLib;

#endregion

namespace CodeImp.Gluon
{
	public partial class MediaPlayerDisplayPanel : DisplayPanel
	{
		#region ================== Constants
		
		#endregion
		
		#region ================== Variables

		private DisplayButton[] listitems;
		private DisplayButton[] muxlistitems;
		private List<string> playlist = new List<string>();
		private int listoffset;
		private int currentitem = -1;			// -1 when file is not in the playlist
		private int lastplaylistitem = -1;
		private int selecteditem = -1;
		private int scrolldelta;
		private bool onscreen = false;
		private bool stopintended = false;
		private bool stopeventblocker = false;
		private Random rnd = new Random();
		private int currentmediapos = 0;
		private int medialength = 0;
		private bool seekbardragged = false;
		private bool isplaying = false;
		private bool ispaused = false;
		private string playingfile = "";

		private int muxlistoffset;
		private int muxscrolldelta;
		private string[] muxfileitems;
		private string muxingfile = "";
		private string muxingfileplaying = "";
		
		#endregion
		
		#region ================== Properties
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public MediaPlayerDisplayPanel()
		{
			InitializeComponent();

			if(General.AppRunning)
			{
				InterProcess.MessageHandler += MessageHandler;
			}

			// Setup player
			player.uiMode = "none";
			player.stretchToFit = true;
			player.Ctlenabled = false;
			player.enableContextMenu = false;
			player.TabIndex = 20;
			player.windowlessVideo = true;
			player.settings.volume = 100;
			player.settings.enableErrorDialogs = false;
			muxplayer.uiMode = "none";
			muxplayer.stretchToFit = true;
			muxplayer.Ctlenabled = false;
			muxplayer.enableContextMenu = false;
			muxplayer.TabIndex = 20;
			muxplayer.windowlessVideo = true;
			muxplayer.settings.volume = 0;
			muxplayer.settings.enableErrorDialogs = false;
			muxplayer.settings.playCount = 99999999;
			muxplayer.Visible = false;

			// Make playlist array
			listitems = new DisplayButton[19];
			listitems[0] = listitem1;
			listitems[1] = listitem2;
			listitems[2] = listitem3;
			listitems[3] = listitem4;
			listitems[4] = listitem5;
			listitems[5] = listitem6;
			listitems[6] = listitem7;
			listitems[7] = listitem8;
			listitems[8] = listitem9;
			listitems[9] = listitem10;
			listitems[10] = listitem11;
			listitems[11] = listitem12;
			listitems[12] = listitem13;
			listitems[13] = listitem14;
			listitems[14] = listitem15;
			listitems[15] = listitem16;
			listitems[16] = listitem17;
			listitems[17] = listitem18;
			listitems[18] = listitem19;

			// Make mux array
			muxlistitems = new DisplayButton[11];
			muxlistitems[0] = videoitem0;
			muxlistitems[1] = videoitem1;
			muxlistitems[2] = videoitem2;
			muxlistitems[3] = videoitem3;
			muxlistitems[4] = videoitem4;
			muxlistitems[5] = videoitem5;
			muxlistitems[6] = videoitem6;
			muxlistitems[7] = videoitem7;
			muxlistitems[8] = videoitem8;
			muxlistitems[9] = videoitem9;
			muxlistitems[10] = videoitem10;
		}
		
		#endregion
		
		#region ================== Methods
		
		// Add file to playlist
		public void Enqueue(string filepathname)
		{
			playlist.Add(filepathname);

			UpdatePlaylistItems();
		}

		// This clears the playlist
		public void ClearPlaylist()
		{
			playlist.Clear();
			currentitem = -1;
			lastplaylistitem = -1;
			selecteditem = -1;
			shufflebutton.StopInfoFlash();
			UpdatePlaylistItems();
			UpdateButtons();
		}

		// This changes or adds to the playlist
		public void OpenPlaylist(string filepathname, bool additive)
		{
			if(!additive)
			{
				playlist.Clear();
				currentitem = -1;
				lastplaylistitem = -1;
				selecteditem = -1;
			}

			// Read playlist
			string[] lines = File.ReadAllLines(filepathname);
			playlist = new List<string>(lines.Length);
			foreach(string f in lines)
			{
				string file = f.Trim();
				if(!string.IsNullOrEmpty(file) && !file.StartsWith("#"))
				{
					// Expand path if relative
					if(!Path.IsPathRooted(file))
						file = Path.GetFullPath(Path.Combine(General.Settings.PlaylistsPath, file));

					playlist.Add(file);
				}
			}

			UpdatePlaylistItems();
		}

		// Play file
		public void InsertAndPlay(string filepathname)
		{
			if((playlist.Count == -1) || (currentitem == -1) || (currentitem >= playlist.Count))
			{
				// Just add
				playlist.Add(filepathname);
				currentitem = playlist.Count - 1;
			}
			else
			{
				// Insert
				playlist.Insert(currentitem + 1, filepathname);
				currentitem++;
			}
			
			UpdatePlaylistItems();
			lastplaylistitem = currentitem;
			PlayFile(playlist[currentitem], 0);
		}

		// This tells the player to play a file
		private void PlayFile(string filepathname, int startpos)
		{
			if(!isplaying)
				General.Power.DisablePowerSave();

			// Show the last two directories the file is in
			string displayfilepath = Path.GetFullPath(filepathname);
			string[] pathparts = displayfilepath.Split(Path.DirectorySeparatorChar);
			string displaypathtitle = "";
			if(pathparts.Length > 2)
				displaypathtitle += pathparts[pathparts.Length - 3] + " - ";
			if(pathparts.Length > 1)
				displaypathtitle += pathparts[pathparts.Length - 2] + " - ";
			itemtitle.Text = displaypathtitle + Path.GetFileNameWithoutExtension(filepathname);
			
			timelabel.Visible = false;
			totaltimelabel.Visible = false;
			positionlabel.Visible = false;
			currentmediapos = 0;
			medialength = 0;
			seekbar.MaxValue = 100;
			seekbar.MinValue = 0;
			seekbar.Value = 0;
			seekbar.Visible = true;
			stopbutton.Visible = true;
			pausebutton.StopInfoFlash();
			pausebutton.Text = "Pause";
			pausebutton.Visible = true;
			stopintended = false;
			isplaying = true;
			ispaused = false;
			playingfile = filepathname;
			player.close();
			
			// Subtitle support!
			try
			{
				string fileext = Path.GetExtension(filepathname);
				string filewithoutext = filepathname.Substring(0, filepathname.Length - fileext.Length);
				string subtitlefile = filewithoutext + ".srt";
				if(File.Exists(subtitlefile))
				{
					// Copy subtitles to the subtitles location
					File.Copy(subtitlefile, General.Settings.SubtitlesFile, true);
				}
				else
				{
					// Make the subtitles file empty
					File.WriteAllText(General.Settings.SubtitlesFile, "");
				}
			}
			catch(Exception e)
			{
				General.WriteLogLine(e.GetType().Name + " while creating subtitles file: " + e.Message);
			}

			if(onscreen)
			{
				// Send message
				onscreeninfo.Visible = true;
				MEDIASTARTDATA startdata = new MEDIASTARTDATA();
				startdata.muxfilename = muxingfile;
				startdata.filename = filepathname;
				startdata.startpos = startpos;
				InterProcess.SendMessage(InterProcess.MSG_MEDIA_START, startdata);
			}
			else
			{
				player.URL = filepathname;

				// Wait for the player to load the file
				while((player.playState == WMPPlayState.wmppsBuffering) ||
					  (player.playState == WMPPlayState.wmppsTransitioning) ||
					  (player.playState == WMPPlayState.wmppsReady))
				{
					Application.DoEvents();
				}

				if(!string.IsNullOrEmpty(muxingfile))
				{
					player.Visible = false;
					muxplayer.Visible = true;

					// Don't interrupt the muxed video if not needed
					if(muxingfile != muxingfileplaying)
					{
						muxingfileplaying = muxingfile;
						muxplayer.URL = muxingfile;

						// Wait for the player to load the file
						while((player.playState == WMPPlayState.wmppsBuffering) ||
							  (player.playState == WMPPlayState.wmppsTransitioning) ||
							  (player.playState == WMPPlayState.wmppsReady))
						{
							Application.DoEvents();
						}

						// Play!
						muxplayer.Ctlcontrols.play();
					}
				}
				else
				{
					player.Visible = true;
					muxplayer.Visible = false;
					muxplayer.close();
					muxingfileplaying = "";
				}

				// Play!
				player.Ctlcontrols.currentPosition = (double)startpos;
				player.Ctlcontrols.play();

				ShowMediaInfo(startpos, (int)player.currentMedia.duration);
				updatetimer.Start();
			}
		}

		// This updates the playlist items
		private void UpdatePlaylistItems()
		{
			for(int i = 0; i < listitems.Length; i++)
			{
				int realindex = listoffset + i;
				if(realindex < playlist.Count)
				{
					listitems[i].Visible = true;
					listitems[i].Text = Path.GetFileNameWithoutExtension(playlist[realindex]);
					listitems[i].BringToFront();

					if(realindex == selecteditem)
					{
						// Selected
						listitems[i].ColorText = ColorIndex.ControlColor1;
						listitems[i].StartInfoFlash();
					}
					else if(realindex == currentitem)
					{
						// Playing
						listitems[i].ColorText = ColorIndex.ControlColorAffirmative;
						listitems[i].StopInfoFlash();
					}
					else
					{
						// Normal
						listitems[i].ColorText = ColorIndex.ControlColor1;
						listitems[i].StopInfoFlash();
					}
					
					listitems[i].SetupColors(General.Colors);
				}
				else
				{
					listitems[i].Visible = false;
					listitems[i].StopInfoFlash();
				}
			}
		}

		// This updates the mux file items
		private void UpdateMuxItems()
		{
			for(int i = 0; i < muxlistitems.Length; i++)
			{
				int realindex = muxlistoffset + i;
				if(realindex < muxfileitems.Length)
				{
					muxlistitems[i].Visible = true;
					muxlistitems[i].Text = Path.GetFileNameWithoutExtension(muxfileitems[realindex]);
				}
				else
				{
					muxlistitems[i].Visible = false;
				}
			}
		}

		// This updates the buttons on the playlist
		private void UpdateButtons()
		{
			savelistbutton.Enabled = (playlist.Count > 0);
			playbutton.Enabled = (selecteditem > -1);
			removebutton.Enabled = (selecteditem > -1);
			moveupbutton.Enabled = (selecteditem > -1);
			movedownbutton.Enabled = (selecteditem > -1);
			savelistbutton.SetupColors(General.Colors);
			playbutton.SetupColors(General.Colors);
			removebutton.SetupColors(General.Colors);
			moveupbutton.SetupColors(General.Colors);
			movedownbutton.SetupColors(General.Colors);
		}

		// This is called when the current file has ended playing
		public void PlayNext()
		{
			// File was not from playlist?
			if(currentitem == -1)
			{
				// Do we still have a last valid playlist position?
				if((lastplaylistitem > -1) && (lastplaylistitem < playlist.Count))
				{
					// For now, consider this the item that was currently playing
					currentitem = lastplaylistitem;
				}
			}

			if(playlist.Count > 0)
			{
				if(shufflebutton.IsInfoFlashing)
				{
					PlayNextRandom();
				}
				else
				{
					// Next!
					currentitem++;
					if(currentitem >= playlist.Count)
					{
						currentitem = 0;
					}

					if(currentitem > -1)
					{
						lastplaylistitem = currentitem;
						PlayFile(playlist[currentitem], 0);
					}
					
					UpdatePlaylistItems();
				}
			}
			else
			{
				// Stop
				currentitem = -1;
				stopbutton_Click(null, EventArgs.Empty);
			}
		}

		// This is called by PlayNext in case Shuffle is on
		private void PlayNextRandom()
		{
			int randomindex;
			
			do
			{
				randomindex = rnd.Next(0, playlist.Count);
			}
			while(randomindex == currentitem);

			currentitem = randomindex;
			lastplaylistitem = currentitem;
			PlayFile(playlist[currentitem], 0);
			UpdatePlaylistItems();
		}

		// This scrolls the list to make sure the given item index is visible
		private void EnsureVisible(int itemindex)
		{
			if(itemindex < listoffset)
				listoffset = itemindex;
			if(itemindex > listoffset + listitems.Length - 1)
				listoffset = itemindex - listitems.Length - 1;
			
			if(listoffset > playlist.Count - listitems.Length)
				listoffset = playlist.Count - listitems.Length;
			if(listoffset < 0)
				listoffset = 0;
			
			UpdatePlaylistItems();
		}

		// This is called to update the media info
		private void ShowMediaInfo(int time, int totaltime)
		{
			if(isplaying)
			{
				TimeSpan tim = new TimeSpan(0, 0, time);
				timelabel.Text = tim.Hours.ToString() + " : " + tim.Minutes.ToString("00");
				timelabel.Visible = true;
				totaltimelabel.Visible = true;
				TimeSpan dur = new TimeSpan(0, 0, totaltime);
				totaltimelabel.Text = dur.Hours.ToString() + " : " + dur.Minutes.ToString("00");
				positionlabel.Visible = true;
				positionlabel.Text = time.ToString("000000");
				seekbar.MaxValue = totaltime;
				seekbar.MinValue = 0;
				seekbar.Value = time;
			}
		}

		// Called when the media has ended playing
		private void MediaEnded()
		{
			ispaused = false;
			updatetimer.Stop();
			PlayNext();
		}

		#endregion

		#region ================== Events

		// When shown
		public override void OnShow()
		{
			playerframe.Visible = true;
			muxframe.Visible = false;
			UpdatePlaylistItems();
			UpdateButtons();
			
			base.OnShow();
		}
		
		// Item clicked
		private void listitem_Click(object sender, EventArgs e)
		{
			// Find out which item is clicked
			int clickedindex = -1;
			for(int i = 0; i < listitems.Length; i++)
			{
				if(listitems[i] == sender)
					clickedindex = i;
			}

			// Toggle select
			if(selecteditem == (listoffset + clickedindex))
				selecteditem = -1;
			else
				selecteditem = listoffset + clickedindex;

			UpdatePlaylistItems();
			UpdateButtons();
		}
		
		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}

		// To Library
		private void librarybutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("librarybrowser");
		}

		// To Playlist Manager
		private void openlistbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.PlaylistsPanel.SetupNormal();
			General.MainWindow.ShowTaggedPanel("playlists");
		}

		// Save Playlist
		private void savelistbutton_Click(object sender, EventArgs e)
		{
			if(!savelistbutton.Enabled) return;
			
			General.MainWindow.PlaylistsPanel.SetupSaveAs(playlist);
			General.MainWindow.ShowTaggedPanel("playlists");
		}
		
		// Pause / Resume
		private void pausebutton_Click(object sender, EventArgs e)
		{
			if(ispaused)
			{
				// Continue playing
				if(onscreen)
					InterProcess.SendMessage(InterProcess.MSG_MEDIA_RESUME, 0);
				else
					player.Ctlcontrols.play();
				
				pausebutton.Text = "Pause";
				pausebutton.StopInfoFlash();
				ispaused = false;
			}
			else
			{
				// Pause
				if(onscreen)
					InterProcess.SendMessage(InterProcess.MSG_MEDIA_PAUSE, 0);
				else
					player.Ctlcontrols.pause();
				
				pausebutton.Text = "Resume";
				pausebutton.StartInfoFlash();
				ispaused = true;
			}
		}
		
		// Stop playing
		private void stopbutton_Click(object sender, EventArgs e)
		{
			if(isplaying)
				General.Power.EnablePowerSave();
			
			updatetimer.Stop();
			stopintended = true;
			currentitem = -1;
			isplaying = false;
			ispaused = false;
			playingfile = "";
			muxingfileplaying = "";
			currentmediapos = 0;
			medialength = 0;
			lastplaylistitem = -1;
			seekbar.Visible = false;
			stopbutton.Visible = false;
			pausebutton.StopInfoFlash();
			pausebutton.Visible = false;
			itemtitle.Text = "";
			timelabel.Visible = false;
			totaltimelabel.Visible = false;
			positionlabel.Visible = false;
			onscreeninfo.Visible = false;
			UpdatePlaylistItems();
			
			if(onscreen)
			{
				InterProcess.SendMessage(InterProcess.MSG_MEDIA_STOP, 0);
			}
			else
			{
				muxplayer.Ctlcontrols.stop();
				muxplayer.close();
				player.Ctlcontrols.stop();
				player.close();
			}
		}

		// Play selected item
		private void playbutton_Click(object sender, EventArgs e)
		{
			if(!playbutton.Enabled) return;
			
			currentitem = selecteditem;
			lastplaylistitem = currentitem;
			PlayFile(playlist[selecteditem], 0);
			UpdatePlaylistItems();
		}

		// Play state changes
		private void player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
		{
			// Media ended
			if((e.newState == (int)WMPPlayState.wmppsStopped) && !stopintended && !stopeventblocker)
			{
				stopeventblocker = true;
				MediaEnded();
			}
			else if(e.newState == (int)WMPPlayState.wmppsPlaying)
			{
				stopeventblocker = false;
			}
		}

		// Clear playlist
		private void clearbutton_Click(object sender, EventArgs e)
		{
			General.Sounds.Play("208");
			ClearPlaylist();
		}

		// Toggle shuffle
		private void shufflebutton_Click(object sender, EventArgs e)
		{
			if(shufflebutton.IsInfoFlashing)
				shufflebutton.StopInfoFlash();
			else
				shufflebutton.StartInfoFlash();
		}

		// Remove item from list
		private void removebutton_Click(object sender, EventArgs e)
		{
			if(!removebutton.Enabled) return;
			
			if(selecteditem == currentitem)
				currentitem = -1;
			else if(currentitem > selecteditem)
				currentitem--;

			playlist.RemoveAt(selecteditem);
			selecteditem = -1;
			
			UpdatePlaylistItems();
			UpdateButtons();
		}

		// Move selected item up
		private void moveupbutton_Click(object sender, EventArgs e)
		{
			if(!moveupbutton.Enabled) return;
			
			if(selecteditem > 0)
			{
				if(currentitem == selecteditem)
				{
					currentitem--;
					lastplaylistitem = currentitem;
				}
				string filepathname = playlist[selecteditem];
				playlist.RemoveAt(selecteditem);
				selecteditem--;
				playlist.Insert(selecteditem, filepathname);
			}
			EnsureVisible(selecteditem);
		}

		// Move selected item down
		private void movedownbutton_Click(object sender, EventArgs e)
		{
			if(!movedownbutton.Enabled) return;
			
			if(selecteditem < (playlist.Count - 1))
			{
				if(currentitem == selecteditem)
				{
					currentitem++;
					lastplaylistitem = currentitem;
				}
				string filepathname = playlist[selecteditem];
				playlist.RemoveAt(selecteditem);
				selecteditem++;
				playlist.Insert(selecteditem, filepathname);
			}
			EnsureVisible(selecteditem);
		}

		// Scroll list
		private void scrolltimer_Tick(object sender, EventArgs e)
		{
			listoffset += scrolldelta;

			if(listoffset > (playlist.Count - listitems.Length))
			{
				listoffset = playlist.Count - listitems.Length;
				scrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			if(listoffset < 0)
			{
				listoffset = 0;
				scrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			UpdatePlaylistItems();
		}

		// Scroll up
		private void quickscrollup_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = -1;
			scrolltimer.Start();
			scrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Scroll down
		private void quickscrolldown_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = 1;
			scrolltimer.Start();
			scrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Release scroll button
		private void scrollbutton_MouseUp(object sender, MouseEventArgs e)
		{
			General.Sounds.Stop("list");
			if(scrolltimer.Enabled)
			{
				General.Sounds.Play("214");
				scrolltimer.Stop();
			}
		}

		// Scroll list
		private void muxscrolltimer_Tick(object sender, EventArgs e)
		{
			muxlistoffset += muxscrolldelta;

			if(muxlistoffset > (muxfileitems.Length - muxlistitems.Length))
			{
				muxlistoffset = muxfileitems.Length - muxlistitems.Length;
				muxscrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			if(muxlistoffset < 0)
			{
				muxlistoffset = 0;
				muxscrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			UpdateMuxItems();
		}

		// Scroll up
		private void muxscrollup_MouseDown(object sender, MouseEventArgs e)
		{
			muxscrolldelta = -1;
			muxscrolltimer.Start();
			muxscrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Scroll down
		private void muxscrolldown_MouseDown(object sender, MouseEventArgs e)
		{
			muxscrolldelta = 1;
			muxscrolltimer.Start();
			muxscrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Release scroll button
		private void muxscrollbutton_MouseUp(object sender, MouseEventArgs e)
		{
			General.Sounds.Stop("list");
			if(muxscrolltimer.Enabled)
			{
				General.Sounds.Play("214");
				muxscrolltimer.Stop();
			}
		}
		
		// Update local media info
		private void updatetimer_Tick(object sender, EventArgs e)
		{
			currentmediapos = (int)player.Ctlcontrols.currentPosition;
			medialength = (int)player.currentMedia.duration;
			ShowMediaInfo(currentmediapos, medialength);
		}

		// Mouse down on seek bar
		private void seekbar_MouseDown(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{
				seekbardragged = true;
				seekbar_MouseMove(sender, e);
			}
		}

		// Mouse move over seek bar
		private void seekbar_MouseMove(object sender, MouseEventArgs e)
		{
			if((e.Button == MouseButtons.Left) && seekbardragged)
			{
				if((e.Y >= 0) && (e.Y < seekbar.ClientRectangle.Height))
				{
					double u = Tools.Clamp((double)e.X / (double)seekbar.ClientRectangle.Width, 0.0d, 1.0d);
					int dragtime = (int)((double)medialength * u);
					ShowMediaInfo(dragtime, medialength);
				}
				else
				{
					ShowMediaInfo(currentmediapos, medialength);
				}
			}
		}

		// Mouse up on seek bar
		private void seekbar_MouseUp(object sender, MouseEventArgs e)
		{
			if((e.Button == MouseButtons.Left) && seekbardragged)
			{
				if((e.Y >= 0) && (e.Y < seekbar.ClientRectangle.Height))
				{
					// Seek!
					double u = Tools.Clamp((double)e.X / (double)seekbar.ClientRectangle.Width, 0.0d, 1.0d);
					double dragtime = (double)medialength * u;
					
					if(onscreen)
						InterProcess.SendMessage(InterProcess.MSG_MEDIA_SEEK, (int)dragtime);
					else
						player.Ctlcontrols.currentPosition = dragtime;
				}
				
				seekbardragged = false;
			}
		}

		// Switch on screen
		private void screenbutton_Click(object sender, EventArgs e)
		{
			this.Visible = false;
			
			if(onscreen)
			{
				onscreen = false;
				screenbutton.StopInfoFlash();
				General.Display.ShowNothing();
				onscreeninfo.Visible = false;
				
				if(isplaying)
				{
					// Continue playing media here
					PlayFile(playingfile, currentmediapos);
				}
			}
			else
			{
				onscreen = true;
				screenbutton.StartInfoFlash();
				updatetimer.Stop();
				
				if(isplaying)
				{
					// Stop playing media here
					stopintended = true;
					muxplayer.Ctlcontrols.stop();
					muxplayer.close();
					player.Ctlcontrols.stop();
					player.close();
					ispaused = false;
					muxingfileplaying = "";
					pausebutton.StopInfoFlash();
					pausebutton.Text = "Pause";
					onscreeninfo.Visible = true;

					// Show media player and continue media
					General.Display.ShowMediaPlayer(playingfile, currentmediapos, muxingfile);
				}
				else
				{
					// Show media player without content
					General.Display.ShowMediaPlayer(null, 0, null);
				}
			}

			this.Visible = true;
		}
		
		// Receive messages
		public void MessageHandler(int msgtype, IntPtr msgdata)
		{
			switch(msgtype)
			{
				case (int)InterProcess.MSG_MEDIA_ENDED:
					MediaEnded();
					break;

				case (int)InterProcess.MSG_MEDIA_LENGTH:
					medialength = InterProcess.GetMessageData<int>(msgdata);
					ShowMediaInfo(currentmediapos, medialength);
					break;
					
				case (int)InterProcess.MSG_MEDIA_POSITION:
					currentmediapos = InterProcess.GetMessageData<int>(msgdata);
					ShowMediaInfo(currentmediapos, medialength);
					break;
			}
		}

		// Receive messages from remote service
		private void remote_ReceiveCommand(RemoteCommand cmd)
		{
			RemoteCommand reply;
			
			// Title requested
			switch(cmd.Command)
			{
				case "STATUS":
					reply = cmd.CreateReply("STATUS");
					string statusinfo;
					if(isplaying)
					{
						if(ispaused)
							statusinfo = "PAUSED\r\n";
						else
							statusinfo = "PLAYING\r\n";
						
						statusinfo += itemtitle.Text + "\r\n";
						statusinfo += medialength + "\r\n";
						statusinfo += currentmediapos + "\r\n";
					}
					else
					{
						statusinfo = "STOPPED\r\n";
					}
					reply.SetData(statusinfo);
					remote.SendCommand(reply);
					break;

				case "STOP":
					reply = cmd.CreateReply("OK");
					remote.SendCommand(reply);
					stopbutton_Click(stopbutton, EventArgs.Empty);
					break;

				case "PAUSE":
					reply = cmd.CreateReply("OK");
					remote.SendCommand(reply);
					pausebutton_Click(pausebutton, EventArgs.Empty);
					break;
			}
		}
		
		// Show mux frame
		private void muxbutton_Click(object sender, EventArgs e)
		{
			if(muxframe.Visible)
			{
				cancelbutton_Click(sender, e);
			}
			else
			{
				muxfileitems = Directory.GetFiles(General.Settings.MultiplexRoot);
				muxlistoffset = 0;
				UpdateMuxItems();
				playerframe.Visible = false;
				muxframe.Visible = true;
			}
		}

		// Cancel mux display
		private void cancelbutton_Click(object sender, EventArgs e)
		{
			playerframe.Visible = true;
			muxframe.Visible = false;
		}

		// Disable muxing
		private void nomuxbutton_Click(object sender, EventArgs e)
		{
			playerframe.Visible = true;
			muxframe.Visible = false;
			muxingfile = "";
			muxbutton.Text = "None";
			muxbutton.StopInfoFlash();
			
			if(isplaying)
				PlayFile(playingfile, currentmediapos);
		}

		private void videoitem_Click(object sender, EventArgs e)
		{
			// Determine index
			int clickedindex = -1;
			for(int i = 0; i < muxlistitems.Length; i++)
			{
				if(muxlistitems[i] == sender)
					clickedindex = muxlistoffset + i;
			}
			
			muxingfile = muxfileitems[clickedindex];
			muxbutton.Text = Path.GetFileNameWithoutExtension(muxingfile);
			
			if(isplaying)
				PlayFile(playingfile, currentmediapos);

			playerframe.Visible = true;
			muxframe.Visible = false;
			muxbutton.StartInfoFlash();
		}

		#endregion
	}
}
