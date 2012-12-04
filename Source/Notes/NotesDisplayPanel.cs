
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

#endregion

namespace CodeImp.Gluon
{
	public partial class NotesDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		private const int NUM_MAIN_ITEM_CONTROLS = 10;
		
		#endregion

		#region ================== Variables

		private DisplayButton[] mainitems;
		private NoteItem[] items;

		private int scrolloffset;
		private int selectedindex;
		
		private int scrolldelta;
		private int scrollbarofset;
		private int scrollbeginoffset;
		private bool scrollpressed;

		private bool addnew;
		
		#endregion

		#region ================== Properties

		public bool AddNew { get { return addnew; } set { addnew = value; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public NotesDisplayPanel()
		{
			InitializeComponent();
			
			// Make main list array
			mainitems = new DisplayButton[NUM_MAIN_ITEM_CONTROLS];
			mainitems[0] = mainitem1;
			mainitems[1] = mainitem2;
			mainitems[2] = mainitem3;
			mainitems[3] = mainitem4;
			mainitems[4] = mainitem5;
			mainitems[5] = mainitem6;
			mainitems[6] = mainitem7;
			mainitems[7] = mainitem8;
			mainitems[8] = mainitem9;
			mainitems[9] = mainitem10;
		}

		#endregion

		#region ================== Methods

		// Refills the main items list
		public void RefreshMainItems()
		{
			for(int i = 0; i < NUM_MAIN_ITEM_CONTROLS; i++)
			{
				int realindex = i + scrolloffset;
				if(realindex > (items.Length - 1))
				{
					// Don't show this control
					mainitems[i].StopInfoFlash();
					mainitems[i].Visible = false;
				}
				else
				{
					// Update caption
					string text = items[realindex].note;
					text = text.Replace("\n", "  •  ");
					text = text.Replace("\r", "");
					mainitems[i].Text = "•  " + text;

					// Update selection flash
					if(selectedindex == realindex)
						mainitems[i].StartInfoFlash();
					else
						mainitems[i].StopInfoFlash();

					mainitems[i].Visible = true;
				}
			}

			// Flash buttons when scrolling available
			if(scrolloffset > 0)
				mainup.StartInfoFlash();
			else
				mainup.StopInfoFlash();

			if(scrolloffset < (items.Length - NUM_MAIN_ITEM_CONTROLS))
				maindown.StartInfoFlash();
			else
				maindown.StopInfoFlash();
		}

		// This deselects
		public void Deselect()
		{
			selectedindex = -1;
			removebutton.Enabled = false;
			upbutton.Enabled = false;
			downbutton.Enabled = false;
			updatebutton.Enabled = false;
			removebutton.SetupColors(General.Colors);
			upbutton.SetupColors(General.Colors);
			downbutton.SetupColors(General.Colors);
			updatebutton.SetupColors(General.Colors);
			notetextpanel.Visible = false;
			textup.Visible = false;
			textdown.Visible = false;
			textscroll.Visible = false;
			keyboard.Visible = false;
			deselectedlabel.Visible = true;
			for(int i = 0; i < NUM_MAIN_ITEM_CONTROLS; i++)
				mainitems[i].StopInfoFlash();
		}
		
		// This selects an item by ID
		public void SelectByID(long id)
		{
			Deselect();
			
			for(int i = 0; i < items.Length; i++)
			{
				if(items[i].id == id)
				{
					Select(i);
					break;
				}
			}
		}

		public void Select(int index)
		{
			selectedindex = index;
			removebutton.Enabled = true;
			upbutton.Enabled = true;
			downbutton.Enabled = true;
			updatebutton.Enabled = true;
			removebutton.SetupColors(General.Colors);
			upbutton.SetupColors(General.Colors);
			downbutton.SetupColors(General.Colors);
			updatebutton.SetupColors(General.Colors);
			notetextpanel.Visible = true;
			textup.Visible = true;
			textdown.Visible = true;
			textscroll.Visible = true;
			keyboard.Visible = true;
			deselectedlabel.Visible = false;
			notetext.Text = items[index].note;
			notetext.SelectionStart = notetext.Text.Length + 1;
			notetext.Focus();
			notetext.ScrollToCaret();

			int buttonindex = index - scrolloffset;
			if((buttonindex >= 0) && (buttonindex < NUM_MAIN_ITEM_CONTROLS))
				mainitems[buttonindex].StartInfoFlash();
		}

		#endregion

		#region ================== Events

		// When panel is shown
		public override void OnShow()
		{
			Deselect();

			// Fetch listed items
			items = General.Notes.GetAllItems().ToArray();
			scrolloffset = 0;
			RefreshMainItems();

			// Add new item?
			if(addnew)
				addbutton_Click(this, EventArgs.Empty);
			
			base.OnShow();
		}

		// When panel is fully shown (done animating)
		protected override void OnShowFinished()
		{
			base.OnShowFinished();

			// Focus on text panel
			if(notetextpanel.Visible)
				notetext.Focus();
		}

		// When leaving this panel
		public override void OnHide()
		{
			if(General.Notes.DeleteEmptyNotes())
				General.MainWindow.OverviewPanel.UpdateNotes();
			
			Deselect();

			scrolltimer.Stop();
			General.Sounds.Stop("list");

			base.OnHide();
		}

		// A main item is clicked
		private void mainitem_Click(object sender, EventArgs e)
		{
			// Go for all items to update selection
			for(int i = 0; i < NUM_MAIN_ITEM_CONTROLS; i++)
			{
				if(mainitems[i] == sender)
				{
					if(selectedindex == (i + scrolloffset))
					{
						// Already selected, de-select now
						Deselect();
					}
					else
					{
						// Select this one
						Select(i + scrolloffset);
					}
				}
				else
				{
					// Not selected
					mainitems[i].StopInfoFlash();
				}
			}
		}

		// Add new item
		private void addbutton_Click(object sender, EventArgs e)
		{
			NoteItem newitem = new NoteItem();
			if(!newitem.SqlInsert()) return;

			items = General.Notes.GetAllItems().ToArray();
			RefreshMainItems();
			General.MainWindow.OverviewPanel.UpdateNotes();

			SelectByID(newitem.id);
		}

		// Update selected item
		private void updatebutton_Click(object sender, EventArgs e)
		{
			items[selectedindex].note = notetext.Text;
			if(!items[selectedindex].SqlUpdate()) return;

			General.MainWindow.OverviewPanel.UpdateNotes();

			RefreshMainItems();
		}

		// Delete item
		private void removebutton_Click(object sender, EventArgs e)
		{
			General.Sounds.Play("208");
			
			if(!items[selectedindex].SqlDelete()) return;

			Deselect();

			General.MainWindow.OverviewPanel.UpdateNotes();
			items = General.Notes.GetAllItems().ToArray();
			RefreshMainItems();
		}
		
		// Overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}

		// Scroll timer
		private void scrolltimer_Tick(object sender, EventArgs e)
		{
			scrolloffset += scrolldelta;

			if(scrolloffset > (items.Length - NUM_MAIN_ITEM_CONTROLS))
			{
				scrolloffset = items.Length - NUM_MAIN_ITEM_CONTROLS;
				scrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			if(scrolloffset < 0)
			{
				scrolloffset = 0;
				scrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			RefreshMainItems();
		}

		private void mainup_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = -1;
			scrolltimer.Start();
			scrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		private void maindown_MouseDown(object sender, MouseEventArgs e)
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
			if(scrolltimer.Enabled || textscrolltimer.Enabled)
			{
				General.Sounds.Play("214");
				textscrolltimer.Stop();
				scrolltimer.Stop();
			}
		}

		private void mainscroll_MouseDown(object sender, MouseEventArgs e)
		{
			General.Sounds.PlayLoop("list");
			scrollbarofset = e.Y;
			scrollpressed = true;
			scrollbeginoffset = scrolloffset;
		}

		private void mainscroll_MouseMove(object sender, MouseEventArgs e)
		{
			// Dragging?
			if(scrollpressed)
			{
				int itemheight = mainitem2.Top - mainitem1.Top;
				scrolloffset = scrollbeginoffset + (e.Y - scrollbarofset) / itemheight;

				if(scrolloffset > (items.Length - NUM_MAIN_ITEM_CONTROLS))
					scrolloffset = items.Length - NUM_MAIN_ITEM_CONTROLS;
				if(scrolloffset < 0)
					scrolloffset = 0;

				RefreshMainItems();
			}
		}

		private void mainscroll_MouseUp(object sender, MouseEventArgs e)
		{
			if(scrollpressed)
			{
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
				scrollpressed = false;
			}
		}

		// Text scroll timer
		private void textscrolltimer_Tick(object sender, EventArgs e)
		{
			notetext.Focus();
			if(scrolldelta < 0)
				SendKeys.Send("{UP}");
			else
				SendKeys.Send("{DOWN}");
		}

		private void textup_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = -1;
			textscrolltimer.Start();
			textscrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		private void textdown_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = 1;
			textscrolltimer.Start();
			textscrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Move item up
		private void upbutton_Click(object sender, EventArgs e)
		{
			if(selectedindex > 0)
			{
				NoteItem.SqlSwap(items[selectedindex], items[selectedindex - 1]);
				selectedindex--;

				General.MainWindow.OverviewPanel.UpdateNotes();
				items = General.Notes.GetAllItems().ToArray();
				RefreshMainItems();
			}
		}

		// Move item down
		private void downbutton_Click(object sender, EventArgs e)
		{
			if(selectedindex < (items.Length - 1))
			{
				NoteItem.SqlSwap(items[selectedindex], items[selectedindex + 1]);
				selectedindex++;

				General.MainWindow.OverviewPanel.UpdateNotes();
				items = General.Notes.GetAllItems().ToArray();
				RefreshMainItems();
			}
		}
		
		#endregion
	}
}
