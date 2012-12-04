using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CodeImp.Gluon
{
	public partial class NetPingTechPanel : DisplayPanel
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private DisplayLabel[] hostlabels;
		private DisplayLabel[] addresslabels;
		private DisplayLabel[] pinglabels;
		private DisplayButton[] routebuttons;

		private TraceRt tracert;

		private TraceJob[] jobs;
		private int displayjobindex;
		private int workingjobindex;

		private int arrowposindex;

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public NetPingTechPanel()
		{
			InitializeComponent();
			tracert = new TraceRt();
			tracert.MaxHops = 20;
			tracert.TraceComplete += tracert_TraceComplete;

			// Make array
			routebuttons = new DisplayButton[4];
			routebuttons[0] = routebutton0;
			routebuttons[1] = routebutton1;
			routebuttons[2] = routebutton2;
			routebuttons[3] = routebutton3;
			
			// Make array
			hostlabels = new DisplayLabel[11];
			hostlabels[0] = hostlabel0;
			hostlabels[1] = hostlabel1;
			hostlabels[2] = hostlabel2;
			hostlabels[3] = hostlabel3;
			hostlabels[4] = hostlabel4;
			hostlabels[5] = hostlabel5;
			hostlabels[6] = hostlabel6;
			hostlabels[7] = hostlabel7;
			hostlabels[8] = hostlabel8;
			hostlabels[9] = hostlabel9;
			hostlabels[10] = hostlabel10;

			// Make array
			addresslabels = new DisplayLabel[11];
			addresslabels[0] = addresslabel0;
			addresslabels[1] = addresslabel1;
			addresslabels[2] = addresslabel2;
			addresslabels[3] = addresslabel3;
			addresslabels[4] = addresslabel4;
			addresslabels[5] = addresslabel5;
			addresslabels[6] = addresslabel6;
			addresslabels[7] = addresslabel7;
			addresslabels[8] = addresslabel8;
			addresslabels[9] = addresslabel9;
			addresslabels[10] = addresslabel10;

			// Make array
			pinglabels = new DisplayLabel[11];
			pinglabels[0] = pinglabel0;
			pinglabels[1] = pinglabel1;
			pinglabels[2] = pinglabel2;
			pinglabels[3] = pinglabel3;
			pinglabels[4] = pinglabel4;
			pinglabels[5] = pinglabel5;
			pinglabels[6] = pinglabel6;
			pinglabels[7] = pinglabel7;
			pinglabels[8] = pinglabel8;
			pinglabels[9] = pinglabel9;
			pinglabels[10] = pinglabel10;

			// The jobs we do
			jobs = new TraceJob[routebuttons.Length];
			for(int i = 0; i < routebuttons.Length; i++)
				jobs[i] = new TraceJob(routebuttons[i].Tag.ToString());
		}

		// Clean up any resources being used.
		protected override void Dispose(bool disposing)
		{
			tracert.Abort();
			
			if(disposing && (components != null))
			{
				components.Dispose();
			}

			base.Dispose(disposing);
		}
		
		#endregion

		#region ================== Methods

		// This displays the specified job index
		private void DisplayJob(int displayindex)
		{
			routearrow.Visible = false;
			
			// Update buttons
			for(int i = 0; i < routebuttons.Length; i++)
			{
				if(i == displayindex)
				{
					if(jobs[displayindex].targetreachable)
						routebuttons[i].StartInfoFlash();
					else
						routebuttons[i].StartWarningFlash();
				}
				else
				{
					routebuttons[i].StopInfoFlash();
					routebuttons[i].StopWarningFlash();
				}
			}

			TraceJob j = jobs[displayindex];
			int offset = (j.nodes.Count <= 11) ? 0 : j.nodes.Count - addresslabels.Length;
			while((offset > 0) && (j.nodes[offset + 10].HostAddress == null))
				offset--;

			if(j.nodes.Count == 0)
			{
				// Setup all labels
				for(int i = 0; i < addresslabels.Length; i++)
				{
					hostlabels[i].Visible = false;
					addresslabels[i].Visible = false;
					pinglabels[i].Visible = false;
					hostlabels[i].Text = "";
					addresslabels[i].Text = "";
					pinglabels[i].Text = "";
				}
				hostlabels[1].Text = "        Trace route not available.";
				addresslabels[1].Text = "";
				pinglabels[1].Text = "";
			}
			else
			{
				// Setup all labels
				for(int i = 0; i < addresslabels.Length; i++)
				{
					hostlabels[i].Visible = false;
					addresslabels[i].Visible = false;
					pinglabels[i].Visible = false;

					int nindex = offset + i;
					if(nindex < j.nodes.Count)
					{
						TraceRtNode n = j.nodes[nindex];

						if(!string.IsNullOrEmpty(n.HostName))
							hostlabels[i].Text = n.HostName;
						else
							hostlabels[i].Text = "(Unknown Routepoint)";

						if(n.HostAddress != null)
						{
							addresslabels[i].Text = n.HostAddress.ToString();
							addresslabels[i].ColorText = ColorIndex.ControlColor4;

							pinglabels[i].Text = n.RoundTripTime + " ms";
							if(n.RoundTripTime > 500)
								pinglabels[i].ColorText = ColorIndex.ControlColorNegative;
							else
								pinglabels[i].ColorText = ColorIndex.ControlColor3;
						}
						else
						{
							pinglabels[i].Text = "N/A";
							pinglabels[i].ColorText = ColorIndex.ControlColorNegative;
							addresslabels[i].Text = "(Unreachable)";
							addresslabels[i].ColorText = ColorIndex.ControlColorNegative;
						}

						addresslabels[i].SetupColors(General.Colors);
						pinglabels[i].SetupColors(General.Colors);
					}
					else
					{
						hostlabels[i].Text = "";
						addresslabels[i].Text = "";
						pinglabels[i].Text = "";
					}
				}
			}
		}

		#endregion

		#region ================== Events

		// Panel showns
		public override void OnShow()
		{
			DisplayJob(displayjobindex);
			
			base.OnShow();
		}
		
		// This works on the jobs
		private void tracetimer_Tick(object sender, EventArgs e)
		{
			tracetimer.Stop();

			// Next job
			workingjobindex++;
			if(workingjobindex >= jobs.Length)
				workingjobindex = 0;

			// Start
			tracert.Trace(jobs[workingjobindex].targetaddress);
		}

		// Trace complete
		private void tracert_TraceComplete(object sender, EventArgs e)
		{
			if(this.InvokeRequired)
			{
				this.Invoke(new EventHandler(tracert_TraceComplete), sender, e);
			}
			else
			{
				// Save current job results
				TraceJob j = jobs[workingjobindex];
				j.nodes = new List<TraceRtNode>(tracert.Nodes);
				j.jobcomplete = true;
				j.targetreachable = tracert.DestResponse;

				// Update button
				if(j.targetreachable)
					routebuttons[workingjobindex].ColorNormal = ColorIndex.ControlColor3;
				else
					routebuttons[workingjobindex].ColorNormal = ColorIndex.ControlColorNegative;

				routebuttons[workingjobindex].SetupColors(General.Colors);

				// Next one after small delay
				tracetimer.Start();
			}
		}

		// Show next trace
		private void cycletimer_Tick(object sender, EventArgs e)
		{
			// Show next job
			int jobschecked = 0;
			do
			{
				displayjobindex++;
				jobschecked++;
				if(displayjobindex >= jobs.Length)
					displayjobindex = 0;
			}
			while(!jobs[displayjobindex].jobcomplete && (jobschecked <= jobs.Length));

			DisplayJob(displayjobindex);
		}

		// Animate the labels
		private void animatetimer_Tick(object sender, EventArgs e)
		{
			// Show the next labels row
			for(int i = 0; i < addresslabels.Length; i++)
			{
				if(!hostlabels[i].Visible && !string.IsNullOrEmpty(hostlabels[i].Text))
				{
					hostlabels[i].Visible = true;
					addresslabels[i].Visible = true;
					pinglabels[i].Visible = true;
					return;
				}
			}

			// Animate arrow
			routearrow.BringToFront();
			int arrowdesttop = pinglabels[arrowposindex].Top + 6;
			routearrow.Top = (routearrow.Top + arrowdesttop) / 2;
		}

		// Route button clicked
		private void routebutton_Click(object sender, EventArgs e)
		{
			// Determine index
			int clickedindex = 0;
			for(int i = 0; i < routebuttons.Length; i++)
			{
				if(routebuttons[i] == sender)
					clickedindex = i;
			}

			// Restart timer
			cycletimer.Stop();
			cycletimer.Start();

			DisplayJob(clickedindex);
		}

		// Change arrow pos index
		private void movearrowtimer_Tick(object sender, EventArgs e)
		{
			Random rnd = new Random();
			
			int numvisible = 0;
			for(int i = 0; i < addresslabels.Length; i++)
			{
				if(addresslabels[i].Visible)
					numvisible = i + 1;
			}

			if(numvisible > 1)
			{
				routearrow.Visible = true;
				
				int newposindex;
				do
				{
					newposindex = rnd.Next(numvisible);
				}
				while(newposindex == arrowposindex);
				arrowposindex = newposindex;
			}
			else
			{
				routearrow.Visible = false;
			}
		}

		#endregion
	}
}
