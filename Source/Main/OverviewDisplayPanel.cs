
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
	public partial class OverviewDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		private const int NUM_AGENDA_ITEMS = 10;
		private const int NUM_NOTES_ITEMS = 10;

		#endregion

		#region ================== Variables

		private DateTime previousdate;

		private DisplayLabel[] agendatimes;
		private DisplayLabel[] agendaitems;
		private DisplayLabel[] notesitems;
		private int noteitemspacing;

		private int agendaitemindex;		// for animation
		private int agendadisplayindex;		// for animation
		private int notesitemindex;			// for animation
		private int lastagendaitemday;

		private List<AgendaItem> agendadata;
		private bool agendaupdateneeded;
		private List<NoteItem> notesdata;
		private bool notesupdateneeded;

		private List<Control> techpanels;
		private int techpanelindex;
		
		#endregion
		
		#region ================== Properties
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public OverviewDisplayPanel()
		{
			InitializeComponent();
			techpanels = new List<Control>();
			previousdate = DateTime.Now;
			environmentframe.Location = overviewframe.Location;
			multimediaframe.Location = overviewframe.Location;
			technicalframe.Location = overviewframe.Location;
			agendaupdateneeded = true;
			notesupdateneeded = true;
			noteitemspacing = agendaitem2.Top - agendaitem1.Bottom;

			// Tech panels
			if(General.AppRunning)
			{
				AddTechPanel(new NetPingTechPanel());
				AddTechPanel(new OverviewTechPanel1());
			}
			
			// Make array
			agendaitems = new DisplayLabel[NUM_AGENDA_ITEMS];
			agendaitems[0] = agendaitem1;
			agendaitems[1] = agendaitem2;
			agendaitems[2] = agendaitem3;
			agendaitems[3] = agendaitem4;
			agendaitems[4] = agendaitem5;
			agendaitems[5] = agendaitem6;
			agendaitems[6] = agendaitem7;
			agendaitems[7] = agendaitem8;
			agendaitems[8] = agendaitem9;
			agendaitems[9] = agendaitem10;

			// Make array
			agendatimes = new DisplayLabel[NUM_AGENDA_ITEMS];
			agendatimes[0] = agendatime1;
			agendatimes[1] = agendatime2;
			agendatimes[2] = agendatime3;
			agendatimes[3] = agendatime4;
			agendatimes[4] = agendatime5;
			agendatimes[5] = agendatime6;
			agendatimes[6] = agendatime7;
			agendatimes[7] = agendatime8;
			agendatimes[8] = agendatime9;
			agendatimes[9] = agendatime10;

			// Make array
			notesitems = new DisplayLabel[NUM_NOTES_ITEMS];
			notesitems[0] = noteitem1;
			notesitems[1] = noteitem2;
			notesitems[2] = noteitem3;
			notesitems[3] = noteitem4;
			notesitems[4] = noteitem5;
			notesitems[5] = noteitem6;
			notesitems[6] = noteitem7;
			notesitems[7] = noteitem8;
			notesitems[8] = noteitem9;
			notesitems[9] = noteitem10;

			#if DEBUG
				exitbutton.Visible = true;
			#endif
		}
		
		#endregion

		#region ================== Methods
		
		// This adds a tech panel
		private void AddTechPanel(Control panel)
		{
			techpanels.Add(panel);
			Controls.Add(panel);
			panel.SuspendLayout();
			panel.Location = techpanelpos.Location;
			panel.Size = techpanelpos.Size;
			panel.Visible = false;
			panel.ResumeLayout(true);
		}

		// This shows the specified tech panel index
		public void ShowTechPanel(int index)
		{
			// Hide visible panels we don't want to see
			for(int i = 0; i < techpanels.Count; i++)
			{
				if(techpanels[i].Visible && (i != index))
				{
					techpanels[i].Hide();
					(techpanels[i] as DisplayPanel).OnHide();
				}
			}
			
			// Show panel
			for(int i = 0; i < techpanels.Count; i++)
			{
				if(!techpanels[i].Visible && (i == index))
				{
					(techpanels[i] as DisplayPanel).OnShow();
					techpanels[i].Show();
				}
			}
		}

		// This updates the access button
		private void UpdateAccessButton()
		{
			if(General.AccessEnabled)
			{
				accessbutton.Text = "Access Enabled";
				accessbutton.ColorNormal = ColorIndex.ControlColorAffirmative;
			}
			else
			{
				accessbutton.Text = "Access Disabled";
				accessbutton.ColorNormal = ColorIndex.ControlColorNegative;
			}

			accessbutton.SetupColors(General.Colors);
		}

		// This updates the agendaitems
		public void UpdateAgenda()
		{
			if(General.Power.IsSleepTime() || !this.Visible)
			{
				// We don't want to update the agenda when the computer is
				// asleep, because it would spin up the harddisk
				agendaupdateneeded = true;
			}
			else
			{
				DateTime today = DateTime.Today;
				DateTime nextweek = today + new TimeSpan(5, 23, 59, 59);
				agendadata = General.Agenda.GetItems(today, nextweek);
				agendaupdateneeded = false;
			}
		}

		// This updates the notesitems
		public void UpdateNotes()
		{
			if(General.Power.IsSleepTime() || !this.Visible)
			{
				// We don't want to update the notes when the computer is
				// asleep, because it would spin up the harddisk
				notesupdateneeded = true;
			}
			else
			{
				notesdata = General.Notes.GetAllItems();
				notesupdateneeded = false;
			}
		}
		
		#endregion
		
		#region ================== Events

		// Update and animate items at the top
		private void animatetoptimer_Tick(object sender, EventArgs e)
		{
			animatetoptimer.Stop();

			if(agendaupdateneeded)
				UpdateAgenda();
			
			if(notesupdateneeded)
				UpdateNotes();
			
			// A negative value means we must clear the list
			if(agendadisplayindex < 0)
			{
				agendaitemindex = 0;
				lastagendaitemday = 0;
				for(int i = 0; i < NUM_AGENDA_ITEMS; i++)
				{
					agendaitems[i].Visible = false;
					agendatimes[i].Visible = false;
				}
			}
			
			// A negative value means we must clear the list
			if(notesitemindex < 0)
			{
				for(int i = 0; i < NUM_NOTES_ITEMS; i++)
					notesitems[i].Visible = false;
			}
			
			// We animate in sequence: We do the agenda items first, then the notes.
			if((agendadata != null) && (agendadisplayindex < NUM_AGENDA_ITEMS))
			{
				// Show next item?
				if(agendadisplayindex >= 0)
				{
					if(agendaitemindex < agendadata.Count)
					{
						// Setup time
						AgendaItem itemdata = agendadata[agendaitemindex];
						if(itemdata.startdate.Day != lastagendaitemday)
						{
							// Use an item for the date
							if(agendadisplayindex < (NUM_AGENDA_ITEMS - 1))
							{
								lastagendaitemday = itemdata.startdate.Day;
								
								// Time
								agendatimes[agendadisplayindex].Text = " ";
								agendatimes[agendadisplayindex].ColorText = ColorIndex.ControlColor4;
								agendatimes[agendadisplayindex].SetupColors(General.Colors);
								agendatimes[agendadisplayindex].Visible = true;

								// Description
								if(lastagendaitemday == DateTime.Today.Day)
									agendaitems[agendadisplayindex].Text = "Today";
								else
									agendaitems[agendadisplayindex].Text = itemdata.startdate.ToString("dddd, MMMM d");
								agendaitems[agendadisplayindex].ColorText = ColorIndex.ControlColor4;
								agendaitems[agendadisplayindex].SetupColors(General.Colors);
								agendaitems[agendadisplayindex].Visible = true;
							}
							
							agendadisplayindex++;
						}

						if(agendadisplayindex < NUM_AGENDA_ITEMS)
						{
							// Time
							if(itemdata.recur == AgendaItemRecur.Annually)
								agendatimes[agendadisplayindex].Text = "-";
							else
								agendatimes[agendadisplayindex].Text = itemdata.startdate.Hour + ":" + itemdata.startdate.Minute.ToString("00");
							agendatimes[agendadisplayindex].ColorText = ColorIndex.ControlColor3;
							agendatimes[agendadisplayindex].SetupColors(General.Colors);
							agendatimes[agendadisplayindex].Visible = true;
							
							// Description
							agendaitems[agendadisplayindex].Text = itemdata.ToString();
							agendaitems[agendadisplayindex].ColorText = itemdata.color;
							agendaitems[agendadisplayindex].SetupColors(General.Colors);
							agendaitems[agendadisplayindex].Visible = true;
						}
					}
					else
					{
						// No item
						agendaitems[agendadisplayindex].Visible = false;
						agendatimes[agendadisplayindex].Visible = false;
					}
					
					agendaitemindex++;
				}

				agendadisplayindex++;
				animatetoptimer.Interval = 100;
			}
			else if((notesdata != null) && (notesitemindex < notesdata.Count) && (notesitemindex < NUM_NOTES_ITEMS))
			{
				// Show next item?
				if(notesitemindex >= 0)
				{
					int toppos;
					if(notesitemindex == 0)
						toppos = noteitem1.Top;
					else
						toppos = notesitems[notesitemindex - 1].Bottom + noteitemspacing;

					if(toppos - noteitemspacing < noteitem10.Bottom)
					{
						string text = notesdata[notesitemindex].note;
						text = text.Replace("\n", "\n    ");
						notesitems[notesitemindex].AutoSizeHeight = true;
						notesitems[notesitemindex].Top = toppos;
						notesitems[notesitemindex].Text = "•  " + text;
						notesitems[notesitemindex].Visible = true;
						if(notesitems[notesitemindex].Bottom > noteitem10.Bottom)
						{
							notesitems[notesitemindex].AutoSizeHeight = false;
							notesitems[notesitemindex].Height = noteitem10.Bottom - notesitems[notesitemindex].Top;

							// End animation
							notesitemindex += 999999;
						}
					}
					else
					{
						// End animation
						notesitemindex += 999999;
					}
				}
				
				notesitemindex++;
				animatetoptimer.Interval = 100;
			}
			// Animation ended?
			else
			{
				// Set the timer to restart later
				agendadisplayindex = -5;
				notesitemindex = -1;
				animatetoptimer.Interval = 10000;
			}
			
			animatetoptimer.Start();
		}
		
		// Showing the overview
		public override void OnShow()
		{
			UpdateAccessButton();

			ShowTechPanel(0);

			agendadisplayindex = -5;
			notesitemindex = -1;
			animatetoptimer.Interval = 100;
			animatetoptimer.Start();

			for(int i = 0; i < NUM_AGENDA_ITEMS; i++)
			{
				agendaitems[i].Visible = false;
				agendatimes[i].Visible = false;
			}

			for(int i = 0; i < NUM_NOTES_ITEMS; i++)
				notesitems[i].Visible = false;

			// Show first tech panel
			techpanelindex = 0;
			for(int i = 0; i < techpanels.Count; i++)
				techpanels[i].Visible = (techpanelindex == i);
			
			base.OnShow();
		}
		
		// Leaving the overview
		public override void OnHide()
		{
			base.OnHide();
			overviewbutton_Click(this, EventArgs.Empty);
			animatetoptimer.Stop();
		}
		
		// Layout changed
		protected override void OnLayout(LayoutEventArgs e)
		{
			base.OnLayout(e);
			clocktimer_Tick(this, EventArgs.Empty);
		}
		
		// Show Environment
		private void environmentbutton_Click(object sender, EventArgs e)
		{
			environmentframe.Visible = true;
			overviewframe.Visible = false;
		}

		// Show Multimedia
		private void multimediabutton_Click(object sender, EventArgs e)
		{
			multimediaframe.Visible = true;
			overviewframe.Visible = false;
		}

		// Show Technical
		private void technicalbutton_Click(object sender, EventArgs e)
		{
			technicalframe.Visible = true;
			overviewframe.Visible = false;
		}
		
		// Go to internet
		private void internetbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("internet");
		}

		// Go to groceries
		private void groceriesbutton_Click(object sender, EventArgs e)
		{
			if(General.AccessEnabled)
			{
				General.MainWindow.ShowTaggedPanel("groceries");
			}
			else
			{
				General.MainWindow.AccessPanel.ContinuePanel = "groceries";
				General.MainWindow.AccessPanel.BackPanel = "overview";
				General.MainWindow.ShowTaggedPanel("accessport");
			}
		}
		
		// Go to agenda
		private void agendabutton_Click(object sender, EventArgs e)
		{
			if(General.AccessEnabled)
			{
				General.MainWindow.ShowTaggedPanel("agenda");
			}
			else
			{
				General.MainWindow.AccessPanel.ContinuePanel = "agenda";
				General.MainWindow.AccessPanel.BackPanel = "overview";
				General.MainWindow.ShowTaggedPanel("accessport");
			}
		}
		
		// Go to treintijden
		private void nsbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("treintijden");
		}
		
		// Go to buienradar
		private void radarbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("buienradar");
		}
		
		// Hide all subsections and show overview frame
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			overviewframe.Visible = true;
			environmentframe.Visible = false;
			multimediaframe.Visible = false;
			technicalframe.Visible = false;
		}
		
		// Date/time
		private void clocktimer_Tick(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;

			string datestr = now.ToLongDateString();
			datestr = datestr.Replace(",", ", ").ToUpper();
			if(datestr != datelabel.Text)
				datelabel.Text = datestr;

			string timestr = now.Hour + " : " + now.Minute.ToString("00") + " . " + now.Second.ToString("00");
			if(timestr != timelabel.Text)
				timelabel.Text = timestr;

			// Next day?
			if(now.DayOfYear != previousdate.DayOfYear)
			{
				// Update mini agenda!
				UpdateAgenda();
			}
		}

		// Disable access
		private void accessbutton_Click(object sender, EventArgs e)
		{
			if(General.AccessEnabled)
			{
				General.Sounds.Play("208");
				General.AccessEnabled = false;
				UpdateAccessButton();
			}
			else
			{
				General.MainWindow.AccessPanel.ContinuePanel = "overview";
				General.MainWindow.AccessPanel.BackPanel = "overview";
				General.MainWindow.ShowTaggedPanel("accessport");
			}
		}

		// Notes
		private void notesbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.NotesPanel.AddNew = false;
			
			if(General.AccessEnabled)
			{
				General.MainWindow.ShowTaggedPanel("notes");
			}
			else
			{
				General.MainWindow.AccessPanel.ContinuePanel = "notes";
				General.MainWindow.AccessPanel.BackPanel = "overview";
				General.MainWindow.ShowTaggedPanel("accessport");
			}
		}

		// Add note
		private void addnotebutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.NotesPanel.AddNew = true;
			
			if(General.AccessEnabled)
			{
				General.MainWindow.ShowTaggedPanel("notes");
			}
			else
			{
				General.MainWindow.AccessPanel.ContinuePanel = "notes";
				General.MainWindow.AccessPanel.BackPanel = "overview";
				General.MainWindow.ShowTaggedPanel("accessport");
			}
		}

		// Library
		private void librarybutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.LibraryBrowser.ResetDirectory();
			General.MainWindow.ShowTaggedPanel("librarybrowser");
		}

		// Media player
		private void playerbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("mediaplayer");
		}

		// For debug only
		private void exitbutton_Click(object sender, EventArgs e)
		{
			#if DEBUG
				Application.Exit();
			#endif
		}

		// Show net tech panel
		private void netbutton_Click(object sender, EventArgs e)
		{
			ShowTechPanel(0);
		}

		// Show system tech panel
		private void systembutton_Click(object sender, EventArgs e)
		{
			ShowTechPanel(1);
		}
		
		#endregion
	}
}
