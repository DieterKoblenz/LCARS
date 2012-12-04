
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
	public partial class GroceriesDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		private const int NUM_MAIN_ITEM_CONTROLS = 19;
		private const int NUM_QUICK_ITEM_CONTROLS = 19;
		private const int NUM_LISTS = 3;

		#endregion

		#region ================== Variables

		private GroceriesItem[] items;
		private GroceriesItem[] used;
		private DisplayButton[] mainitems;
		private DisplayButton[] quickitems;
		private DisplayButton[] listbuttons;

		private int selectedlist;
		private int scrolloffset;
		private int quickscrolloffset;
		private int selectedindex;

		private int scrolldelta;
		private int scrollbarofset;
		private int scrollbeginoffset;
		private bool scrollpressed;
		
		#endregion

		#region ================== Properties

		public int SelectedList { get { return selectedlist; } set { selectedlist = value; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public GroceriesDisplayPanel()
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
			mainitems[10] = mainitem11;
			mainitems[11] = mainitem12;
			mainitems[12] = mainitem13;
			mainitems[13] = mainitem14;
			mainitems[14] = mainitem15;
			mainitems[15] = mainitem16;
			mainitems[16] = mainitem17;
			mainitems[17] = mainitem18;
			mainitems[18] = mainitem19;

			// Make quick list array
			quickitems = new DisplayButton[NUM_QUICK_ITEM_CONTROLS];
			quickitems[0] = quickitem1;
			quickitems[1] = quickitem2;
			quickitems[2] = quickitem3;
			quickitems[3] = quickitem4;
			quickitems[4] = quickitem5;
			quickitems[5] = quickitem6;
			quickitems[6] = quickitem7;
			quickitems[7] = quickitem8;
			quickitems[8] = quickitem9;
			quickitems[9] = quickitem10;
			quickitems[10] = quickitem11;
			quickitems[11] = quickitem12;
			quickitems[12] = quickitem13;
			quickitems[13] = quickitem14;
			quickitems[14] = quickitem15;
			quickitems[15] = quickitem16;
			quickitems[16] = quickitem17;
			quickitems[17] = quickitem18;
			quickitems[18] = quickitem19;

			// Make lists array
			listbuttons = new DisplayButton[NUM_LISTS];
			listbuttons[0] = listbutton1;
			listbuttons[1] = listbutton2;
			listbuttons[2] = listbutton3;
		}

		#endregion

		#region ================== Methods

		// Refills the quick items list
		public void RefreshQuickItems()
		{
			// Fetch most used items
			for(int i = 0; i < NUM_QUICK_ITEM_CONTROLS; i++)
			{
				int realindex = i + quickscrolloffset;
				if(realindex > (used.Length - 1))
				{
					quickitems[i].Visible = false;
				}
				else
				{
					quickitems[i].Visible = true;
					quickitems[i].Text = used[realindex].name;
				}
			}
		}

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
					if(items[realindex].count > 1)
						mainitems[i].Text = items[realindex].name + " • " + items[realindex].count;
					else
						mainitems[i].Text = items[realindex].name;

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
				scrollupbutton.StartInfoFlash();
			else
				scrollupbutton.StopInfoFlash();

			if(scrolloffset < (items.Length - NUM_MAIN_ITEM_CONTROLS))
				scrolldownbutton.StartInfoFlash();
			else
				scrolldownbutton.StopInfoFlash();
		}
		
		// This returns one of the items by name
		// Returns -1 when the item is not in the list
		private int GetIndexByName(string name)
		{
			// Find the item
			for(int i = 0; i < items.Length; i++)
			{
				if(string.Compare(items[i].name, name, true) == 0)
					return i;
			}
			
			return -1;
		}

		// This deselects
		public void Deselect()
		{
			selectedindex = -1;
			removeonebutton.Enabled = false;
			removeallbutton.Enabled = false;
			increasebutton.Enabled = false;
			removeonebutton.SetupColors(General.Colors);
			removeallbutton.SetupColors(General.Colors);
			increasebutton.SetupColors(General.Colors);
			for(int i = 0; i < NUM_MAIN_ITEM_CONTROLS; i++)
				mainitems[i].StopInfoFlash();
		}

		// Select a list and refresh items
		public void SelectList(int index)
		{
			// Update buttons
			for(int i = 0; i < NUM_LISTS; i++)
			{
				if(i == index)
				{
					listbuttons[i].ColorNormal = ColorIndex.InfoLight;
					listbuttons[i].ColorText = ColorIndex.InfoLightText;
				}
				else
				{
					listbuttons[i].ColorNormal = ColorIndex.ControlNormal;
					listbuttons[i].ColorText = ColorIndex.ControlNormalText;
				}
				
				listbuttons[i].SetupColors(General.Colors);
			}

			Deselect();
			
			// Update list
			selectedlist = index;
			items = General.Groceries.GetAllItems(selectedlist).ToArray();
			scrolloffset = 0;
			quickscrolloffset = 0;
			RefreshMainItems();
		}

		#endregion

		#region ================== Events

		// When panel is shown
		public override void OnShow()
		{
			used = General.Groceries.GetMostUsedItems().ToArray();
			
			Deselect();
			
			// Fetch list items
			SelectList(selectedlist);
			RefreshQuickItems();
			
			base.OnShow();
		}

		// When leaving this panel
		public override void OnHide()
		{
			Deselect();

			SelectList(-1);
			selectedlist = 0;
			scrolltimer.Stop();
			General.Sounds.Stop("list");
			
			base.OnHide();
		}

		// A quick item is clicked
		private void quickitem_Click(object sender, EventArgs e)
		{
			DisplayButton quickitembutton = (DisplayButton)sender;

			int index = GetIndexByName(quickitembutton.Text);
			if(index > -1)
			{
				items[index].count++;
				items[index].SqlUpdateOrInsert(false);
			}
			else
			{
				GroceriesItem newitem = new GroceriesItem();
				newitem.name = quickitembutton.Text;
				newitem.count = 1;
				newitem.list = selectedlist;
				newitem.SqlUpdateOrInsert(true);
				items = General.Groceries.GetAllItems(selectedlist).ToArray();
			}
			
			RefreshMainItems();
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
						selectedindex = i + scrolloffset;
						removeonebutton.Enabled = true;
						removeallbutton.Enabled = true;
						increasebutton.Enabled = true;
						mainitems[i].StartInfoFlash();
					}

					// Update buttons
					removeonebutton.SetupColors(General.Colors);
					removeallbutton.SetupColors(General.Colors);
					increasebutton.SetupColors(General.Colors);
				}
				else
				{
					// Not selected
					mainitems[i].StopInfoFlash();
				}
			}
		}
		
		// Remove One clicked
		private void removeonebutton_Click(object sender, EventArgs e)
		{
			if(selectedindex < 0) return;

			if(items[selectedindex].count > 0)
			{
				// Decrease count
				items[selectedindex].count--;

				// Update database
				items[selectedindex].SqlUpdateOrInsert(false);
			}

			RefreshMainItems();
		}

		// Remove All clicked
		private void removeallbutton_Click(object sender, EventArgs e)
		{
			if(selectedindex < 0) return;

			// Update database
			items[selectedindex].SqlDelete();
			items = General.Groceries.GetAllItems(selectedlist).ToArray();
			
			Deselect();

			RefreshMainItems();
		}

		// Increase clicked
		private void increasebutton_Click(object sender, EventArgs e)
		{
			if(selectedindex < 0) return;

			// Increase count
			items[selectedindex].count++;

			// Update database
			items[selectedindex].SqlUpdateOrInsert(false);
			
			RefreshMainItems();
		}

		// Clear!
		private void clearbutton_Click(object sender, EventArgs e)
		{
			General.Sounds.Play("208");
			
			Deselect();
			
			// Clear DB
			General.Groceries.DeleteAllItems(selectedlist);
			items = new GroceriesItem[0];
			
			RefreshMainItems();
		}

		// Add clicked
		private void addbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.AddGroceriesPanel.SelectedList = selectedlist;
			General.MainWindow.ShowTaggedPanel("addgroceries");
		}

		// Overview clicked
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}

		// Scroll up
		private void scrollupbutton_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = -1;
			scrolltimer.Start();
			scrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Scroll down
		private void scrolldownbutton_MouseDown(object sender, MouseEventArgs e)
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
			if(scrolltimer.Enabled || quickscrolltimer.Enabled)
			{
				General.Sounds.Play("214");
				quickscrolltimer.Stop();
				scrolltimer.Stop();
			}
		}

		// Pressed on scrollbar
		private void scrollbar_MouseDown(object sender, MouseEventArgs e)
		{
			General.Sounds.PlayLoop("list");
			scrollbarofset = e.Y;
			scrollpressed = true;
			scrollbeginoffset = scrolloffset;
		}

		// Dragging scrollbar
		private void scrollbar_MouseMove(object sender, MouseEventArgs e)
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

		// Releasing scrollbar
		private void scrollbar_MouseUp(object sender, MouseEventArgs e)
		{
			if(scrollpressed)
			{
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
				scrollpressed = false;
			}
		}

		// Scroller
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

		// Scroll quick list up
		private void quickscrollup_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = -1;
			quickscrolltimer.Start();
			quickscrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Scroll quick list down
		private void quickscrolldown_MouseDown(object sender, MouseEventArgs e)
		{
			scrolldelta = 1;
			quickscrolltimer.Start();
			quickscrolltimer_Tick(sender, EventArgs.Empty);
			General.Sounds.PlayLoop("list");
		}

		// Quick list scroller
		private void quickscrolltimer_Tick(object sender, EventArgs e)
		{
			quickscrolloffset += scrolldelta;

			if(quickscrolloffset > (used.Length - NUM_QUICK_ITEM_CONTROLS))
			{
				quickscrolloffset = used.Length - NUM_QUICK_ITEM_CONTROLS;
				quickscrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			if(quickscrolloffset < 0)
			{
				quickscrolloffset = 0;
				quickscrolltimer.Stop();
				General.Sounds.Stop("list");
				General.Sounds.Play("214");
			}

			RefreshQuickItems();
		}

		// Transfer over bluetooth
		private void transferbutton_Click(object sender, EventArgs e)
		{
			string html = Properties.Resources.grocerieshtml;
			int itembeginpos = html.IndexOf("$ITEMBEGIN$");
			int itemendpos = html.IndexOf("$ITEMEND$");
			string itemtemplate = html.Substring(itembeginpos + 11, itemendpos - (itembeginpos + 11));
			html = html.Replace(itemtemplate, "");
			html = html.Replace("$ITEMEND$", "");

			string itemlist = "";
			for(int i = 0; i < items.Length; i++)
			{
				string itemname = items[i].name;
				if(items[i].count > 1)
					itemname += "  " + items[i].count + "x";
				
				string itemstr = itemtemplate;
				itemstr = itemstr.Replace("$ITEMNAME$", itemname);
				itemlist += itemstr;
			}
			html = html.Replace("$ITEMBEGIN$", itemlist);

			byte[] data = Encoding.ASCII.GetBytes(html);
			ObexTransferObject obj = new ObexTransferObject(data);
			obj.Filename = "Groceries-" + DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + ".html";
			obj.MimeType = "text/plain";
			General.MainWindow.ObexTransferPanel.TransferSingleObject(obj);
			General.MainWindow.ObexTransferPanel.ReturnPanel = "groceries";
			General.MainWindow.ShowTaggedPanel("transferobex");
		}

		// List selected
		private void listbutton_Click(object sender, EventArgs e)
		{
			int listindex;
			DisplayButton c = (DisplayButton)sender;
			if(int.TryParse(c.Tag.ToString(), out listindex))
				SelectList(listindex);
		}

		#endregion
	}
}
