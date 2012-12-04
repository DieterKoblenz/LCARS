
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
	public partial class AgendaEditDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		private const int NUM_ITEMS = 18;

		#endregion

		#region ================== Variables

		private DateTime thisday;
		private DisplayButton[] itembuttons;
		private DisplayLabel[] itemlabels;
		private DisplayLabel[] itemends;
		private string returnpanel;
		private int selectedindex;

		private AgendaItemDisplayPanel itemeditor;

		#endregion

		#region ================== Properties

		public string ReturnPanel { get { return returnpanel; } set { returnpanel = value; } }
		public AgendaItemDisplayPanel ItemEditor { get { return itemeditor; } set { itemeditor = value; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public AgendaEditDisplayPanel()
		{
			InitializeComponent();

			// No selection
			selectedindex = -1;
			editbutton.Enabled = false;
			deletebutton.Enabled = false;
			
			// Make array
			itembuttons = new DisplayButton[NUM_ITEMS];
			itembuttons[0] = itembutton0;
			itembuttons[1] = itembutton1;
			itembuttons[2] = itembutton2;
			itembuttons[3] = itembutton3;
			itembuttons[4] = itembutton4;
			itembuttons[5] = itembutton5;
			itembuttons[6] = itembutton6;
			itembuttons[7] = itembutton7;
			itembuttons[8] = itembutton8;
			itembuttons[9] = itembutton9;
			itembuttons[10] = itembutton10;
			itembuttons[11] = itembutton11;
			itembuttons[12] = itembutton12;
			itembuttons[13] = itembutton13;
			itembuttons[14] = itembutton14;
			itembuttons[15] = itembutton15;
			itembuttons[16] = itembutton16;
			itembuttons[17] = itembutton17;

			// Make array
			itemlabels = new DisplayLabel[NUM_ITEMS];
			itemlabels[0] = itemlabel0;
			itemlabels[1] = itemlabel1;
			itemlabels[2] = itemlabel2;
			itemlabels[3] = itemlabel3;
			itemlabels[4] = itemlabel4;
			itemlabels[5] = itemlabel5;
			itemlabels[6] = itemlabel6;
			itemlabels[7] = itemlabel7;
			itemlabels[8] = itemlabel8;
			itemlabels[9] = itemlabel9;
			itemlabels[10] = itemlabel10;
			itemlabels[11] = itemlabel11;
			itemlabels[12] = itemlabel12;
			itemlabels[13] = itemlabel13;
			itemlabels[14] = itemlabel14;
			itemlabels[15] = itemlabel15;
			itemlabels[16] = itemlabel16;
			itemlabels[17] = itemlabel17;
			
			// Make array
			itemends = new DisplayLabel[NUM_ITEMS];
			itemends[0] = itemend0;
			itemends[1] = itemend1;
			itemends[2] = itemend2;
			itemends[3] = itemend3;
			itemends[4] = itemend4;
			itemends[5] = itemend5;
			itemends[6] = itemend6;
			itemends[7] = itemend7;
			itemends[8] = itemend8;
			itemends[9] = itemend9;
			itemends[10] = itemend10;
			itemends[11] = itemend11;
			itemends[12] = itemend12;
			itemends[13] = itemend13;
			itemends[14] = itemend14;
			itemends[15] = itemend15;
			itemends[16] = itemend16;
			itemends[17] = itemend17;
		}

		#endregion

		#region ================== Methods

		// This sets up the panel for a specific day
		public void SetupDay(DateTime day)
		{
			thisday = day;

			string datestr = day.ToLongDateString();
			datelabel.Text = datestr.Replace(",", " ").ToUpper();
			Deselect();

			// Determine begin and end date for this day
			DateTime dstart = new DateTime(day.Year, day.Month, day.Day);
			DateTime dend = new DateTime(dstart.Year, dstart.Month, dstart.Day);
			dend = dend.AddDays(1);
			dend = dend.AddTicks(-1);
			
			// Setup items
			List<AgendaItem> items = General.Agenda.GetItems(dstart, dend);
			for(int i = 0; i < NUM_ITEMS; i++)
			{
				// Within range of items or this day?
				if(i < items.Count)
				{
					AgendaItem ditem = items[i];
					DateTime itemend = ditem.startdate + ditem.duration;
					itemlabels[i].Text = ditem.startdate.Hour + ":" + ditem.startdate.Minute.ToString("00") + "      -";
					itemlabels[i].Visible = true;
					itemends[i].Text = itemend.Hour + ":" + itemend.Minute.ToString("00");
					itemends[i].Visible = true;
					itembuttons[i].Text = ditem.ToString();
					itembuttons[i].ColorText = ditem.color;
					itembuttons[i].SetupColors(General.Colors);
					itembuttons[i].Tag = ditem;
					itembuttons[i].Visible = true;
				}
				else
				{
					itembuttons[i].Tag = null;
					itemlabels[i].Visible = false;
					itembuttons[i].Visible = false;
					itemends[i].Visible = false;
				}
			}
		}

		private void RefreshDay()
		{
			SetupDay(thisday);
		}

		// This deselects
		public void Deselect()
		{
			selectedindex = -1;
			editbutton.Enabled = false;
			deletebutton.Enabled = false;
			editbutton.SetupColors(General.Colors);
			deletebutton.SetupColors(General.Colors);
			for(int i = 0; i < NUM_ITEMS; i++)
				itembuttons[i].StopInfoFlash();
		}
		
		#endregion

		#region ================== Events

		// Showing panel
		public override void OnShow()
		{
			base.OnShow();
		}
		
		// Back clicked
		private void backbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel(returnpanel);
		}

		// Overview clicked
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}
		
		// Item clicked
		private void Item_Click(object sender, EventArgs e)
		{
			// Go for all items to update selection
			for(int i = 0; i < NUM_ITEMS; i++)
			{
				if(itembuttons[i] == sender)
				{
					if(selectedindex == i)
					{
						// Already selected, de-select now
						Deselect();
					}
					else
					{
						// Select this one
						selectedindex = i;
						editbutton.Enabled = true;
						deletebutton.Enabled = true;
						itembuttons[i].StartInfoFlash();
					}
					
					// Update buttons
					editbutton.SetupColors(General.Colors);
					deletebutton.SetupColors(General.Colors);
				}
				else
				{
					// Not selected
					itembuttons[i].StopInfoFlash();
				}
			}
		}

		// Add clicked
		private void addbutton_Click(object sender, EventArgs e)
		{
			itemeditor.ReturnPanel = "agendaday";
			itemeditor.AcceptEvent += RefreshDay;
			itemeditor.SetupDate(thisday);
			General.MainWindow.ShowTaggedPanel("agendaitem");
		}

		// Edit clicked
		private void editbutton_Click(object sender, EventArgs e)
		{
			AgendaItem item = (AgendaItem)itembuttons[selectedindex].Tag;
			itemeditor.ReturnPanel = "agendaday";
			itemeditor.AcceptEvent += RefreshDay;
			itemeditor.SetupItem(item);
			General.MainWindow.ShowTaggedPanel("agendaitem");
		}

		// Delete clicked
		private void deletebutton_Click(object sender, EventArgs e)
		{
			AgendaItem item = (AgendaItem)itembuttons[selectedindex].Tag;
			General.Sounds.Play("208");
			General.Agenda.RemoveItem(item);
			General.MainWindow.OverviewPanel.UpdateAgenda();
			RefreshDay();
		}

		#endregion
	}
}
