
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
using WMPLib;

#endregion

namespace CodeImp.Gluon
{
	public partial class MediaPlayerDisplayForm : Form
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private bool stopeventblocker = false;
		private bool stopintended = false;

		private string muxingfile = "";
		private string muxingfileplaying = "";
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Destructor

		// Constructor
		public MediaPlayerDisplayForm()
		{
			InitializeComponent();
			
			// Setup player
			player.uiMode = "none";
			player.stretchToFit = true;
			player.Ctlenabled = false;
			player.enableContextMenu = false;
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
			
			// Hook up inter-process communcation
			InterProcess.SendHWND(this.Handle);
			InterProcess.MessageHandler += MessageHandler;
		}

		#endregion

		#region ================== Methods
		
		// This sets the video to use for muxing
		public void SetMuxingFile(string filename)
		{
			muxingfile = filename;
		}
		
		// This starts playing a file
		public void PlayFile(string filename, int startpos)
		{
			stopintended = false;
			player.URL = filename;

			// Wait for the player to load the file
			while((player.playState == WMPPlayState.wmppsBuffering) ||
				  (player.playState == WMPPlayState.wmppsTransitioning) ||
				  (player.playState == WMPPlayState.wmppsReady))
			{
				Application.DoEvents();
			}

			// Send media length to gluon
			InterProcess.SendMessage(InterProcess.MSG_MEDIA_LENGTH, (int)player.currentMedia.duration);
			
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
			
			updatetimer.Start();
		}

		#endregion

		#region ================== Events

		// State changes
		private void player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
		{
			// Media ended
			if((e.newState == (int)WMPPlayState.wmppsStopped) && !stopintended && !stopeventblocker)
			{
				stopeventblocker = true;
				updatetimer.Stop();
				
				// Let Gluon know the media has ended
				InterProcess.SendMessage(InterProcess.MSG_MEDIA_ENDED, 0);
			}
			else if(e.newState == (int)WMPPlayState.wmppsPlaying)
			{
				stopeventblocker = false;
			}
		}

		// Send position updates to Gluon
		private void updatetimer_Tick(object sender, EventArgs e)
		{
			InterProcess.SendMessage(InterProcess.MSG_MEDIA_POSITION, (int)player.Ctlcontrols.currentPosition);
		}

		// Custom message handler
		private void MessageHandler(int msgtype, IntPtr msgdata)
		{
			switch(msgtype)
			{
				case (int)InterProcess.MSG_MEDIA_PAUSE:
					player.Ctlcontrols.pause();
					break;
					
				case (int)InterProcess.MSG_MEDIA_RESUME:
					player.Ctlcontrols.play();
					break;
					
				case (int)InterProcess.MSG_MEDIA_SEEK:
					int pos = InterProcess.GetMessageData<int>(msgdata);
					player.Ctlcontrols.currentPosition = (double)pos;
					break;
					
				case (int)InterProcess.MSG_MEDIA_START:
					MEDIASTARTDATA startdata = InterProcess.GetMessageData<MEDIASTARTDATA>(msgdata);
					muxingfile = startdata.muxfilename;
					PlayFile(startdata.filename, startdata.startpos);
					break;

				case (int)InterProcess.MSG_MEDIA_STOP:
					stopintended = true;
					updatetimer.Stop();
					muxingfileplaying = "";
					muxplayer.Ctlcontrols.stop();
					muxplayer.close();
					player.Ctlcontrols.stop();
					player.close();
					break;
			}
		}

		// Receive messages
		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
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
