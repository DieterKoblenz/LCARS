
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
using Microsoft.Win32;

#endregion

namespace CodeImp.Gluon
{
	public partial class LibraryBrowserDisplayPanel : DisplayPanel
	{
		#region ================== Constants
		
		private const int SINGLE_COL_NUM_BUTTONS = 18;
		private const int DOUBLE_COL_NUM_BUTTONS = SINGLE_COL_NUM_BUTTONS * 2;
		
		private const string SUPPORTFORMATS = ".mp3 .ogg .avi .mkv .mpg .mpeg .mp4 .divx .wma .wmv .wav .m3u .m4v";
		
		#endregion

		#region ================== Variables

		private DisplayButton[] filebuttons;
		private DisplayButton[] dirbuttons;

		private string currentpath;
		private int listoffset;
		private DirectoryList allitems;
		private bool[] itemselected;
		private int scrolldelta;
		private int scrolloffset;
		private bool scrollpressed;
		private bool searchresults;
		private string searchstring;
		private bool searchbuttonplaced;
		private int numbuttons;
		
		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public LibraryBrowserDisplayPanel()
		{
			InitializeComponent();

			// Make file buttons array
			filebuttons = new DisplayButton[DOUBLE_COL_NUM_BUTTONS];
			filebuttons[0] = filebutton0;
			filebuttons[1] = filebutton1;
			filebuttons[2] = filebutton2;
			filebuttons[3] = filebutton3;
			filebuttons[4] = filebutton4;
			filebuttons[5] = filebutton5;
			filebuttons[6] = filebutton6;
			filebuttons[7] = filebutton7;
			filebuttons[8] = filebutton8;
			filebuttons[9] = filebutton9;
			filebuttons[10] = filebutton10;
			filebuttons[11] = filebutton11;
			filebuttons[12] = filebutton12;
			filebuttons[13] = filebutton13;
			filebuttons[14] = filebutton14;
			filebuttons[15] = filebutton15;
			filebuttons[16] = filebutton16;
			filebuttons[17] = filebutton17;
			filebuttons[18] = filebutton18;
			filebuttons[19] = filebutton19;
			filebuttons[20] = filebutton20;
			filebuttons[21] = filebutton21;
			filebuttons[22] = filebutton22;
			filebuttons[23] = filebutton23;
			filebuttons[24] = filebutton24;
			filebuttons[25] = filebutton25;
			filebuttons[26] = filebutton26;
			filebuttons[27] = filebutton27;
			filebuttons[28] = filebutton28;
			filebuttons[29] = filebutton29;
			filebuttons[30] = filebutton30;
			filebuttons[31] = filebutton31;
			filebuttons[32] = filebutton32;
			filebuttons[33] = filebutton33;
			filebuttons[34] = filebutton34;
			filebuttons[35] = filebutton35;
			for(int i = 0; i < DOUBLE_COL_NUM_BUTTONS; i++)
				filebuttons[i].Visible = false;

			// Make directory buttons array
			dirbuttons = new DisplayButton[9];
			dirbuttons[0] = directorybutton0;
			dirbuttons[1] = directorybutton1;
			dirbuttons[2] = directorybutton2;
			dirbuttons[3] = directorybutton3;
			dirbuttons[4] = directorybutton4;
			dirbuttons[5] = directorybutton5;
			dirbuttons[6] = directorybutton6;
			dirbuttons[7] = directorybutton7;
			dirbuttons[8] = directorybutton8;

			// Setup root path
			if(General.AppRunning)
			{
				currentpath = General.Settings.LibraryRoot;
				RefreshDirButtons();
			}
		}

		#endregion

		#region ================== Methods

		// This resets the directory to the library root
		public void ResetDirectory()
		{
			currentpath = General.Settings.LibraryRoot;
			searchresults = false;
			RefreshDirButtons();
			if(this.Visible)
				RefreshFilesList(true);
		}

		// This shows search results in the browser
		public void ShowSearchResults(string searchword, List<string> searchdirectories)
		{
			currentpath = General.Settings.LibraryRoot;
			searchstring = searchword;
			searchresults = true;
			numbuttons = SINGLE_COL_NUM_BUTTONS;
			
			// Combine search results from all given directories
			allitems = null;
			foreach(string dirname in searchdirectories)
			{
				DirectoryList dirlist = new DirectoryList(dirname, SUPPORTFORMATS, true, "*" + searchword + "*");
				if(allitems == null)
					allitems = dirlist;
				else
					allitems += dirlist;
			}

			RefreshDirButtons();
			if(this.Visible)
				RefreshFilesList(true);
		}

		// Setup colors
		public override void SetupColors(ColorPalette c)
		{
			base.SetupColors(c);
		}

		// This updates the file buttons
		private void UpdateFileItems()
		{
			// Presume we don't need these buttons
			searchbuttonplaced = false;
			searchbutton.Visible = false;
			for(int i = 0; i < numbuttons; i++)
			{
				filebuttons[i].Text = "";
				filebuttons[i].Visible = false;
			}

			// Determine if we are in the library root
			bool inrootpath = (currentpath.Length == General.Settings.LibraryRoot.Length) && !searchresults;
			
			// If we're in the library root, we want to use the large buttons! yay
			if(inrootpath)
			{
				filebuttons[0] = largebutton0;
				filebuttons[1] = largebutton1;
				filebuttons[2] = largebutton2;
				filebuttons[3] = largebutton3;
				filebuttons[4] = largebutton4;
				filebuttons[5] = largebutton5;
				filebuttons[6] = largebutton6;
				filebuttons[7] = largebutton7;
				filebuttons[8] = largebutton8;
			}
			else
			{
				filebuttons[0] = filebutton0;
				filebuttons[1] = filebutton1;
				filebuttons[2] = filebutton2;
				filebuttons[3] = filebutton3;
				filebuttons[4] = filebutton4;
				filebuttons[5] = filebutton5;
				filebuttons[6] = filebutton6;
				filebuttons[7] = filebutton7;
				filebuttons[8] = filebutton8;
			}
			
			// Update buttons
			int itemindex = listoffset;
			for(int i = 0; i < numbuttons; i++)
			{
				if(itemindex < allitems.TotalCount)
				{
					DirectoryEntry de = allitems[itemindex];

					filebuttons[i].Text = de.filetitle;
					filebuttons[i].Tag = itemindex;
					filebuttons[i].Clickable = true;
					
					if(de.isdirectory)
						filebuttons[i].ColorText = ColorIndex.InfoLight;
					else
						filebuttons[i].ColorText = ColorIndex.WindowText;

					if(!itemselected[itemindex])
						filebuttons[i].StopInfoFlash();
					else
						filebuttons[i].StartInfoFlash();
					
					filebuttons[i].SetupColors(General.Colors);
					filebuttons[i].Visible = true;

					// In search results, we show the directory parts in the buttons next to the results
					if(searchresults)
					{
						// Figure out path parts
						string pathfromroot = de.path.Substring(General.Settings.LibraryRoot.Length);
						pathfromroot.Trim(Path.DirectorySeparatorChar);
						
						string[] pathparts;
						string pathinfo = "";
						if(pathfromroot.Length > 0)
							pathparts = pathfromroot.Split(Path.DirectorySeparatorChar);
						else
							pathparts = new string[0];

						// Make path info description
						foreach(string pp in pathparts)
						{
							if(pathinfo.Length > 0)
								pathinfo = pp + " - " + pathinfo;
							else
								pathinfo = pp;
						}
						
						int detailsindex = i + SINGLE_COL_NUM_BUTTONS;
						filebuttons[detailsindex].Clickable = false;
						filebuttons[detailsindex].ColorText = ColorIndex.ControlColor3;
						filebuttons[detailsindex].Text = pathinfo;
						filebuttons[detailsindex].Tag = -1;
						filebuttons[detailsindex].SetupColors(General.Colors);
						filebuttons[detailsindex].Visible = true;
					}
				}
				else
				{
					filebuttons[i].Text = "";
					filebuttons[i].Visible = false;
					
					// If we're in the library root, we always want the search button shown on the first next unused place
					if(inrootpath && !searchbuttonplaced)
					{
						searchbutton.Text = "Search";
						searchbutton.StopInfoFlash();
						searchbutton.ColorText = ColorIndex.WindowText;
						searchbutton.SetupColors(General.Colors);
						searchbutton.Location = filebuttons[i].Location;
						searchbutton.Visible = true;
						searchbuttonplaced = true;
					}
				}
				
				itemindex++;
			}
		}

		// This shows all files/directories in the list for the given directory and offset
		private void RefreshFilesList(bool animate)
		{
			animatefilestimer.Stop();

			// Make list of files
			if(!searchresults)
			{
				numbuttons = DOUBLE_COL_NUM_BUTTONS;
				allitems = new DirectoryList(currentpath, SUPPORTFORMATS, false);
			}
			
			if(listoffset > (allitems.TotalCount - filebuttons.Length))
				listoffset = allitems.TotalCount - filebuttons.Length;
			if(listoffset < 0)
				listoffset = 0;

			// Make matching array for selection
			itemselected = new bool[allitems.TotalCount];
			
			UpdateFileItems();
			
			// Update visibility
			searchbutton.Visible = false;
			for(int i = 0; i < filebuttons.Length; i++)
			{
				filebuttons[i].Visible = !animate && !string.IsNullOrEmpty(filebuttons[i].Text);
				filebuttons[i].StopInfoFlash();
			}
			
			if(animate)
				animatefilestimer.Start();

			UpdateButtons();
		}

		// This sets up the directory buttons for the current path
		private void RefreshDirButtons()
		{
			bool titlehidden = false;
			DisplayButton lastdirbutton = rootbutton;
			
			if(searchresults)
			{
				// Hide all buttons
				for(int i = 0; i < dirbuttons.Length; i++)
					dirbuttons[i].Visible = false;
				
				// Setup buttons for search results
				dirbuttons[0].Visible = true;
				dirbuttons[0].Text = "Search results for \"" + searchstring + "\"";
				dirsizelabel.Text = dirbuttons[0].Text;
				dirbuttons[0].Width = Math.Min(dirsizelabel.Width, titlelabel.Left - dirbuttons[0].Left - 20);
				dirbuttons[0].Clickable = false;
				lastdirbutton = dirbuttons[0];
			}
			else
			{
				// Figure out path parts
				string proot = Path.GetFullPath(General.Settings.LibraryRoot);
				string pcur = Path.GetFullPath(currentpath);
				
				if(!pcur.StartsWith(proot))
					throw new Exception("Current path does not contain root path. Fix me!");
				
				string relpath = pcur.Substring(proot.Length);
				relpath.Trim(Path.DirectorySeparatorChar);
				
				string[] pathparts;
				if(relpath.Length > 0)
					pathparts = relpath.Split(Path.DirectorySeparatorChar);
				else
					pathparts = new string[0];
				
				if(pathparts.Length > dirbuttons.Length)
					throw new Exception("Paths longer than " + dirbuttons.Length + " directories deep are not supported. Fix me!");
				
				// Setup buttons
				for(int i = 0; i < dirbuttons.Length; i++)
				{
					if(i < pathparts.Length)
					{
						dirsizelabel.Text = pathparts[i];
						int width = Math.Min(dirsizelabel.Width, 300);
						dirbuttons[i].Text = pathparts[i];
						dirbuttons[i].Visible = true;
						dirbuttons[i].Width = width;
						dirbuttons[i].Clickable = true;
						if(i > 0) dirbuttons[i].Left = dirbuttons[i - 1].Right + dirbuttons[i].Margin.Left + dirbuttons[i - 1].Margin.Right;
						if(dirbuttons[i].Right > 777)
						{
							if(dirbuttons[i].Left > 1150)
							{
								// No room to display this button
								dirbuttons[i].Visible = false;
							}
							else
							{
								// We have to hide the title to make room or the directory buttons
								titlehidden = true;
								if(dirbuttons[i].Right > barend.Left)
									dirbuttons[i].Width = barend.Left - dirbuttons[i].Left - barend.Margin.Left - barend.Margin.Right;
								lastdirbutton = dirbuttons[i];
							}
						}
						else
						{
							lastdirbutton = dirbuttons[i];
						}
					}
					else
					{
						dirbuttons[i].Visible = false;
					}
				}
			}
			
			// Adjust title label and directory filler
			titlelabel.Visible = !titlehidden;
			int fillerrightalign = titlehidden ? barend.Left : fillerright.Left;
			directoryfiller.Left = lastdirbutton.Right + directoryfiller.Margin.Left + lastdirbutton.Margin.Right;
			directoryfiller.Width = fillerrightalign - directoryfiller.Left;
		}

		// This updates the file buttons
		private void UpdateButtons()
		{
			int numselected = 0;
			foreach(bool s in itemselected)
				if(s) numselected++;

			playnowbutton.Enabled = (numselected == 1);
			enqueuebutton.Enabled = (numselected > 0);
			transferbutton.Enabled = (numselected == 1);
			playnowbutton.SetupColors(General.Colors);
			enqueuebutton.SetupColors(General.Colors);
			transferbutton.SetupColors(General.Colors);
		}

		#endregion

		#region ================== Events

		// Panel is shown
		public override void OnShow()
		{
			listoffset = 0;
			RefreshDirButtons();
			RefreshFilesList(true);
			
			base.OnShow();
		}

		// Play selected file now
		private void playnowbutton_Click(object sender, EventArgs e)
		{
			if(!playnowbutton.Enabled) return;
			
			for(int i = 0; i < allitems.TotalCount; i++)
			{
				if(itemselected[i])
				{
					string filepathname = allitems[i].filepathname;

					// What to do with the file?
					string ext = allitems[i].extension.ToLowerInvariant();
					switch(ext)
					{
						// PLAYLIST
						case ".m3u":
							General.MainWindow.MediaPlayerPanel.OpenPlaylist(filepathname, false);
							General.MainWindow.MediaPlayerPanel.PlayNext();
							break;

						// EVERYTHING ELSE IS JUST MEDIA
						default:
							General.MainWindow.MediaPlayerPanel.InsertAndPlay(filepathname);
							break;
					}
				}
			}
		}

		// Enqueue selected file
		private void enqueuebutton_Click(object sender, EventArgs e)
		{
			if(!enqueuebutton.Enabled) return;
			
			for(int i = 0; i < allitems.TotalCount; i++)
			{
				if(itemselected[i])
				{
					string filepathname = allitems[i].filepathname;

					// What to do with the file?
					string ext = allitems[i].extension.ToLowerInvariant();
					switch(ext)
					{
						// PLAYLIST
						case ".m3u":
							General.MainWindow.MediaPlayerPanel.OpenPlaylist(filepathname, true);
							break;

						// EVERYTHING IS JUST MEDIA
						default:
							General.MainWindow.MediaPlayerPanel.Enqueue(filepathname);
							break;
					}
				}
			}
		}

		// Transfer selected file
		private void transferbutton_Click(object sender, EventArgs e)
		{
			if(!transferbutton.Enabled) return;

			for(int i = 0; i < allitems.TotalCount; i++)
			{
				if(itemselected[i])
				{
					string filepathname = allitems[i].filepathname;
					FileInfo fi = new FileInfo(filepathname);
					if(fi.Length < 100000000)
					{
						// Determine mime type from file extension
						string mimetype = "application/unknown";
						string ext = allitems[i].extension.ToLower();
						RegistryKey regkey = Registry.ClassesRoot.OpenSubKey(ext);
						if(regkey != null && regkey.GetValue("Content Type") != null)
							mimetype = regkey.GetValue("Content Type").ToString();

						// Load the file in memory and queue for sending
						byte[] data = File.ReadAllBytes(filepathname);
						ObexTransferObject obj = new ObexTransferObject(data);
						obj.Filename = allitems[i].filename;
						obj.MimeType = mimetype;
						General.MainWindow.ObexTransferPanel.TransferSingleObject(obj);
						General.MainWindow.ObexTransferPanel.ReturnPanel = "librarybrowser";
						General.MainWindow.ShowTaggedPanel("transferobex");
					}
					else
					{
						General.Sounds.Play("error");
					}
				}
			}
		}
		
		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}

		// To player
		private void playerbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("mediaplayer");
		}
		
		// Back to root
		private void rootbutton_Click(object sender, EventArgs e)
		{
			listoffset = 0;
			searchresults = false;
			currentpath = General.Settings.LibraryRoot;
			RefreshDirButtons();
			RefreshFilesList(true);
		}

		// File clicked
		private void filebutton_Click(object sender, EventArgs e)
		{
			// Check if this is a directory
			DisplayButton button = (sender as DisplayButton);
			int itemindex = (int)(button.Tag);
			if((itemindex >= 0) && (itemindex < allitems.TotalCount))
			{
				if(allitems[itemindex].isdirectory)
				{
					currentpath = allitems[itemindex].filepathname;
					searchresults = false;
					RefreshDirButtons();
					RefreshFilesList(true);
				}
				else
				{
					// Select the file
					for(int i = 0; i < numbuttons; i++)
					{
						if(filebuttons[i] == button)
						{
							if(itemselected[itemindex])
							{
								// Deselect
								filebuttons[i].StopInfoFlash();
								itemselected[itemindex] = false;
							}
							else
							{
								// Select
								filebuttons[i].StartInfoFlash();
								itemselected[itemindex] = true;
							}

							break;
						}
					}

					UpdateButtons();
				}
			}
		}

		// Doubleclicking a file
		private void filebutton_DoubleClick(object sender, EventArgs e)
		{
			// Determine index
			DisplayButton button = (sender as DisplayButton);
			int realindex = (int)(button.Tag);
			
			// Make selected state the same for all items
			bool thisstate = itemselected[realindex];
			for(int i = allitems.DirectoryCount; i < allitems.TotalCount; i++)
				itemselected[i] = thisstate;

			// After doubleclick there is another click event which must select this one
			itemselected[realindex] = !itemselected[realindex];

			UpdateFileItems();
			UpdateButtons();
		}
		
		// Directory button clicked
		private void directorybutton_Click(object sender, EventArgs e)
		{
			listoffset = 0;

			if(!searchresults)
			{
				// Found out the index of the button
				string newpath = General.Settings.LibraryRoot;
				for(int i = 0; i < dirbuttons.Length; i++)
				{
					newpath = Path.Combine(newpath, dirbuttons[i].Text);
					if(dirbuttons[i] == sender)
					{
						currentpath = newpath;
						RefreshDirButtons();
						RefreshFilesList(true);
						return;
					}
				}
			}
		}

		// Search button clicked
		private void searchbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("searchlibrary");
		}
		
		// This animates all file items
		private void animatefilestimer_Tick(object sender, EventArgs e)
		{
			// Make the next item visible
			int cnt = 0;
			for(int i = 0; i < numbuttons; i++)
			{
				if(!filebuttons[i].Visible && !string.IsNullOrEmpty(filebuttons[i].Text))
				{
					General.Sounds.Play("list");
					
					filebuttons[i].Visible = true;
					filebuttons[i].SetupColors(General.Colors);

					if(searchresults)
					{
						filebuttons[i + SINGLE_COL_NUM_BUTTONS].Visible = true;
						filebuttons[i + SINGLE_COL_NUM_BUTTONS].SetupColors(General.Colors);
					}

					if(cnt == 3)
						return;
					else
						cnt++;
				}
			}

			if(searchbuttonplaced)
				searchbutton.Visible = true;
			
			animatefilestimer.Stop();
		}

		// Scroll up
		private void scrollupbutton_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = -2;
			scrolltimer.Start();
			scrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Scroll down
		private void scrolldownbutton_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = 2;
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
			// Dragging?
			if(scrollpressed)
			{
				if(Math.Abs(e.Y - scrolloffset) > 1)
				{
					listoffset += (e.Y - scrolloffset) / 2;
					if(listoffset > (allitems.TotalCount - filebuttons.Length))
						listoffset = allitems.TotalCount - filebuttons.Length;
					if(listoffset < 0)
						listoffset = 0;

					UpdateFileItems();

					for(int i = 0; i < filebuttons.Length; i++)
						filebuttons[i].Update();
					
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
		
		// This makes the list scroll
		private void scrolltimer_Tick(object sender, EventArgs e)
		{
			listoffset += scrolldelta;
			if(listoffset > (allitems.TotalCount - filebuttons.Length))
				listoffset = allitems.TotalCount - filebuttons.Length;
			if(listoffset < 0)
				listoffset = 0;
			
			UpdateFileItems();
		}
		
		#endregion
	}
}
