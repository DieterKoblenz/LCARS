
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
	public partial class LibrarySearchDisplayPanel : DisplayPanel
	{
		#region ================== Constants
		
		#endregion
		
		#region ================== Variables

		private DisplayButton[] dirbuttons;
		
		#endregion
		
		#region ================== Properties
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public LibrarySearchDisplayPanel()
		{
			InitializeComponent();
			
			// Make directory buttons array
			dirbuttons = new DisplayButton[8];
			dirbuttons[0] = dirbutton0;
			dirbuttons[1] = dirbutton1;
			dirbuttons[2] = dirbutton2;
			dirbuttons[3] = dirbutton3;
			dirbuttons[4] = dirbutton4;
			dirbuttons[5] = dirbutton5;
			dirbuttons[6] = dirbutton6;
			dirbuttons[7] = dirbutton7;
		}
		
		#endregion
		
		#region ================== Methods

		// Setup colors
		public override void SetupColors(ColorPalette c)
		{
			base.SetupColors(c);

			searchtext.BackColor = General.Colors[ColorIndex.ControlNormal];
			searchtext.ForeColor = General.Colors[ColorIndex.ControlNormalText];
		}

		private void PlayFailSound()
		{
			General.Sounds.Play("error");
		}

		private void UpdateSearchButton()
		{
			bool searchinfocomplete = true;
			
			if(searchtext.Text.Length < 2)
				searchinfocomplete = false;

			bool dirbuttonschosen = false;
			for(int i = 0; i < dirbuttons.Length; i++)
			{
				if(dirbuttons[i].IsInfoFlashing)
					dirbuttonschosen = true;
			}
			if(!dirbuttonschosen)
				searchinfocomplete = false;

			if(searchinfocomplete)
				acceptbutton.ColorNormal = ColorIndex.ControlColorAffirmative;
			else
				acceptbutton.ColorNormal = ColorIndex.ControlColorNegative;

			acceptbutton.SetupColors(General.Colors);
		}
		
		#endregion
		
		#region ================== Events

		// When panel is about to be shown
		public override void OnShow()
		{
			searchingframe.Visible = false;
			inputframe.Visible = true;
			
			// Setup directory buttons
			DirectoryList dirs = new DirectoryList(General.Settings.LibraryRoot, null, false);
			for(int i = 0; i < dirbuttons.Length; i++)
			{
				if(i < dirs.DirectoryCount)
				{
					dirbuttons[i].Visible = true;
					dirbuttons[i].Text = dirs[i].filetitle;
					dirbuttons[i].Tag = dirs[i].filepathname;
				}
				else
				{
					dirbuttons[i].Visible = false;
				}
			}

			searchtext.Text = "";
			
			UpdateSearchButton();
			
			base.OnShow();
		}

		// When done showing
		protected override void OnShowFinished()
		{
			searchtext.Focus();
		}

		// Perform the search
		private void acceptbutton_Click(object sender, EventArgs e)
		{
			if(acceptbutton.ColorNormal == ColorIndex.ControlColorAffirmative)
			{
				inputframe.Visible = false;
				searchingframe.Visible = true;
				this.Refresh();
				
				// Make list of directories to search in
				List<string> searchdirs = new List<string>(dirbuttons.Length);
				for(int i = 0; i < dirbuttons.Length; i++)
				{
					if(dirbuttons[i].IsInfoFlashing)
						searchdirs.Add(dirbuttons[i].Tag.ToString());
				}

				// Show search results in library browser
				General.MainWindow.LibraryBrowser.ShowSearchResults(searchtext.Text, searchdirs);
				General.MainWindow.ShowTaggedPanel("librarybrowser");
			}
			else
			{
				PlayFailSound();
				searchtext.Focus();
			}
		}
		
		// Back to overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}

		// Back to library
		private void backbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("librarybrowser");
		}

		// Directory button clicked
		private void dirbutton_Click(object sender, EventArgs e)
		{
			DisplayButton thisbutton = (DisplayButton)sender;

			if(thisbutton.IsInfoFlashing)
				thisbutton.StopInfoFlash();
			else
				thisbutton.StartInfoFlash();

			UpdateSearchButton();
		}

		// Text typed in search text box
		private void searchtext_TextChanged(object sender, EventArgs e)
		{
			UpdateSearchButton();
		}
		
		#endregion
	}
}
