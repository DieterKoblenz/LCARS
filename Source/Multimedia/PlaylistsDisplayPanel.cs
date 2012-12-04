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
	public partial class PlaylistsDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		private enum PlaylistOperation
		{
			None = 0,
			SaveAs = 1,
			Rename = 2
		}

		#endregion
		
		#region ================== Variables

		private PlaylistOperation operation;
		private DisplayButton[] listitems;
		private int listoffset;
		private int selecteditem = -1;
		private int scrolldelta;
		private string renamefile;
		private List<string> files;
		private List<string> saveplaylist;
		
		#endregion
		
		#region ================== Properties
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public PlaylistsDisplayPanel()
		{
			InitializeComponent();

			// Make playlist array
			listitems = new DisplayButton[14];
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
		}
		
		#endregion
		
		#region ================== Methods

		// Setup colors
		public override void SetupColors(ColorPalette c)
		{
			base.SetupColors(c);

			inputname.BackColor = General.Colors[ColorIndex.ControlNormal];
			inputname.ForeColor = General.Colors[ColorIndex.ControlNormalText];
		}

		// This initiates a Rename operation
		public void SetupNormal()
		{
			operation = PlaylistOperation.None;
			inputlabel.Visible = false;
			inputbar.Visible = false;
			playlistlabel.Visible = false;
			namelabel.Visible = false;
		}
		
		// This initiates a Save As operation
		public void SetupSaveAs(List<string> playlist)
		{
			operation = PlaylistOperation.SaveAs;
			saveplaylist = new List<string>(playlist);
			inputlabel.Text = "Save current playlist as:";
			inputlabel.Visible = true;
			inputname.Text = "";
			inputbar.Visible = true;
			playlistlabel.Visible = false;
			namelabel.Visible = false;
			selecteditem = -1;
		}
		
		// This initiates a Rename operation
		private void SetupRename()
		{
			operation = PlaylistOperation.Rename;
			inputlabel.Text = "Rename playlist as:";
			inputlabel.Visible = true;
			inputname.Text = "";
			inputbar.Visible = true;
			playlistlabel.Visible = true;
			renamefile = files[selecteditem];
			namelabel.Text = Path.GetFileNameWithoutExtension(renamefile);
			namelabel.Visible = true;
			selecteditem = -1;
		}

		// This updates the list of playlist files
		private void UpdateFilesList()
		{
			for(int i = 0; i < listitems.Length; i++)
			{
				int realindex = listoffset + i;
				if(realindex < files.Count)
				{
					listitems[i].Visible = true;
					listitems[i].Text = Path.GetFileNameWithoutExtension(files[realindex]);

					if(realindex == selecteditem)
						listitems[i].StartInfoFlash();
					else
						listitems[i].StopInfoFlash();
				}
				else
				{
					listitems[i].Visible = false;
					listitems[i].StopInfoFlash();
				}
			}
		}

		// This updates the buttons
		public void UpdateButtons()
		{
			openbutton.StopWarningFlash();
			okbutton.StopWarningFlash();
			
			okbutton.Enabled = (operation != PlaylistOperation.None);
			cancelbutton.Enabled = (operation != PlaylistOperation.None);
			openbutton.Enabled = (selecteditem > -1);
			renamebutton.Enabled = (selecteditem > -1);
			deletebutton.Enabled = (selecteditem > -1);

			okbutton.SetupColors(General.Colors);
			cancelbutton.SetupColors(General.Colors);
			openbutton.SetupColors(General.Colors);
			renamebutton.SetupColors(General.Colors);
			deletebutton.SetupColors(General.Colors);

			inputname_TextChanged(null, EventArgs.Empty);
		}
		
		#endregion
		
		#region ================== Events

		// When shown
		public override void OnShow()
		{
			// Find files
			files = new List<string>(Directory.GetFiles(General.Settings.PlaylistsPath, "*.m3u"));
			selecteditem = -1;
			UpdateFilesList();
			UpdateButtons();
			
			base.OnShow();
		}

		// When completely shown
		protected override void OnShowFinished()
		{
			base.OnShowFinished();

			if(inputbar.Visible)
				inputname.Focus();
		}

		// When closed
		public override void OnHide()
		{
			base.OnHide();

			SetupNormal();
		}

		// Scroll list
		private void scrolltimer_Tick(object sender, EventArgs e)
		{
			listoffset += scrolldelta;

			if(listoffset > (files.Count - listitems.Length))
			{
				listoffset = files.Count - listitems.Length;
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

			UpdateFilesList();
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
			if(scrolltimer.Enabled || scrolltimer.Enabled)
			{
				General.Sounds.Play("214");
				scrolltimer.Stop();
				scrolltimer.Stop();
			}
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

			if(operation != PlaylistOperation.None)
			{
				selecteditem = -1;
				inputname.Text = listitems[clickedindex].Text;
			}
			else
			{
				// Toggle select
				if(selecteditem == (listoffset + clickedindex))
					selecteditem = -1;
				else
					selecteditem = listoffset + clickedindex;

				UpdateFilesList();
			}
			
			UpdateButtons();
		}

		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}

		// To Media Player
		private void playerbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("mediaplayer");
		}

		// Input name for playlist
		private void inputname_TextChanged(object sender, EventArgs e)
		{
			// Validate input
			if(string.IsNullOrEmpty(inputname.Text) || (inputname.Text.IndexOfAny(Path.GetInvalidFileNameChars()) > -1))
				return;

			// Make new filename
			string newfilepathname = Path.Combine(General.Settings.PlaylistsPath, inputname.Text + ".m3u");

			// If the file exists, color the button red
			if(File.Exists(newfilepathname))
				okbutton.ColorNormal = ColorIndex.ControlColorNegative;
			else
				okbutton.ColorNormal = ColorIndex.ControlColorAffirmative;

			okbutton.SetupColors(General.Colors);
		}
		
		// Perform operation
		private void okbutton_Click(object sender, EventArgs e)
		{
			if(!okbutton.Enabled) return;
			
			// Validate input
			if(string.IsNullOrEmpty(inputname.Text) || (inputname.Text.IndexOfAny(Path.GetInvalidFileNameChars()) > -1))
			{
				General.Sounds.Play("error");
				okbutton.StartWarningFlash();
				return;
			}
			
			// Make new filename
			string newfilepathname = Path.Combine(General.Settings.PlaylistsPath, inputname.Text + ".m3u");
			
			try
			{
				if(operation == PlaylistOperation.SaveAs)
				{
					if(File.Exists(newfilepathname))
					{
						if(General.AccessEnabled)
						{
							File.Delete(newfilepathname);
						}
						else
						{
							General.Sounds.Play("error");
							return;
						}
					}
					
					// Make paths relative to playlist root
					string[] lines = new string[saveplaylist.Count];
					for(int i = 0; i < saveplaylist.Count; i++)
					{
						if(saveplaylist[i].StartsWith(General.Settings.LibraryRoot, StringComparison.InvariantCultureIgnoreCase))
						{
							lines[i] = Path.Combine("..", saveplaylist[i].Substring(General.Settings.LibraryRoot.Length));
						}
						else
						{
							// Can't make path relative, because it doesnt begin with library root
							lines[i] = saveplaylist[i];
						}
					}

					File.WriteAllLines(newfilepathname, lines);
				}
				else if(operation == PlaylistOperation.Rename)
				{
					if(File.Exists(newfilepathname))
					{
						if(General.AccessEnabled)
						{
							File.Delete(newfilepathname);
						}
						else
						{
							General.Sounds.Play("error");
							return;
						}
					}
					
					// Rename a file
					File.Move(renamefile, newfilepathname);
				}
			}
			catch(Exception)
			{
				General.Sounds.Play("error");
				okbutton.StartWarningFlash();
				return;
			}

			// Refresh playlists
			files = new List<string>(Directory.GetFiles(General.Settings.PlaylistsPath, "*.m3u"));
			selecteditem = -1;
			SetupNormal();
			UpdateFilesList();
			UpdateButtons();
		}

		// Start rename operation
		private void renamebutton_Click(object sender, EventArgs e)
		{
			if(!renamebutton.Enabled) return;
			
			SetupRename();
			selecteditem = -1;
			UpdateFilesList();
			UpdateButtons();
			inputname.Focus();
		}

		// Cancel operation
		private void cancelbutton_Click(object sender, EventArgs e)
		{
			if(!cancelbutton.Enabled) return;
			
			SetupNormal();
			UpdateButtons();
		}

		// Delete playlist
		private void deletebutton_Click(object sender, EventArgs e)
		{
			if(!deletebutton.Enabled) return;
			
			if(General.AccessEnabled)
			{
				try
				{
					File.Delete(files[selecteditem]);
					selecteditem = -1;
					General.Sounds.Play("208");
				}
				catch(Exception)
				{
					General.Sounds.Play("error");
				}
			}
			else
			{
				General.Sounds.Play("error");
			}

			// Refresh playlists
			files = new List<string>(Directory.GetFiles(General.Settings.PlaylistsPath, "*.m3u"));
			SetupNormal();
			UpdateFilesList();
			UpdateButtons();
		}

		// Open selected playlist
		private void openbutton_Click(object sender, EventArgs e)
		{
			if(!openbutton.Enabled) return;
			
			General.MainWindow.MediaPlayerPanel.OpenPlaylist(files[selecteditem], false);
			General.MainWindow.ShowTaggedPanel("mediaplayer");
		}
		
		#endregion
	}
}
