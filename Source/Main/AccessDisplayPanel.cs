
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
	public partial class AccessDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		private const string CODE1 = "0000";
		private const string CODE2 = "0000";

		#endregion

		#region ================== Variables

		private bool flashstate;
		private string backpanel;
		private string continuepanel;
		private string typedcode;
		private int enablestate;

		#endregion

		#region ================== Properties

		public string ContinuePanel { get { return continuepanel; } set { continuepanel = value; } }
		public string BackPanel { get { return backpanel; } set { backpanel = value; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public AccessDisplayPanel()
		{
			InitializeComponent();
		}
		
		#endregion

		#region ================== Methods

		// This updates colors of some controls
		private void UpdateColors()
		{
			progress1.SetupColors(General.Colors);
			progress2.SetupColors(General.Colors);
			progress3.SetupColors(General.Colors);
			progress4.SetupColors(General.Colors);
			progress5.SetupColors(General.Colors);
			accesslabel.SetupColors(General.Colors);
			grantedlabel.SetupColors(General.Colors);
		}
		
		#endregion

		#region ================== Events

		// When shown
		public override void OnShow()
		{
			accesslabel.Text = "ACCESS";
			grantedlabel.Text = "DENIED";
			accesslabel.Visible = true;
			grantedlabel.Visible = true;
			accesslabel.ColorText = ColorIndex.ControlColorNegative;
			grantedlabel.ColorText = ColorIndex.ControlColorNegative;
			progress1.ColorBackground = ColorIndex.ControlColorNegative;
			progress2.ColorBackground = ColorIndex.ControlColorNegative;
			progress3.ColorBackground = ColorIndex.ControlColorNegative;
			progress4.ColorBackground = ColorIndex.ControlColorNegative;
			progress5.ColorBackground = ColorIndex.ControlColorNegative;
			UpdateColors();
			
			base.OnShow();

			General.Sounds.Play("accessdenied");
			flashstate = false;
			typedcode = "";
			texttimer.Start();
			enablestate = 0;
			enabletimer.Start();
		}
		
		// When leaving
		public override void OnHide()
		{
			base.OnHide();
			texttimer.Stop();
			enabletimer.Stop();
		}

		// This adds the code on the object tag to the string
		private void codebutton_Click(object sender, EventArgs e)
		{
			typedcode += (sender as Control).Tag.ToString();
		}
		
		// This flashes the text
		private void texttimer_Tick(object sender, EventArgs e)
		{
			if(flashstate)
			{
				accesslabel.ColorText = ColorIndex.ControlColorNegative;
				grantedlabel.ColorText = ColorIndex.ControlColorNegative;
				flashstate = false;
			}
			else
			{
				accesslabel.ColorText = ColorIndex.WindowText;
				grantedlabel.ColorText = ColorIndex.WindowText;
				flashstate = true;
			}
			
			accesslabel.SetupColors(General.Colors);
			grantedlabel.SetupColors(General.Colors);
		}

		// Go back
		private void backbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel(backpanel);
		}

		// Enable?
		private void enablebutton_Click(object sender, EventArgs e)
		{
			// Check if the code is OK
			General.AccessEnabled = typedcode.EndsWith(CODE1) || typedcode.EndsWith(CODE2);
			typedcode = "";

			if(General.AccessEnabled)
			{
				General.Sounds.Play("accessgranted");
				grantedlabel.Text = "ENABLED";
			}
			else
			{
				General.Sounds.Play("accessdenied");
				grantedlabel.Text = "DENIED";
			}

			texttimer.Stop();
			flashstate = false;
			accesslabel.Visible = false;
			grantedlabel.Visible = false;
			progress1.ColorBackground = ColorIndex.ControlColorNegative;
			progress2.ColorBackground = ColorIndex.ControlColorNegative;
			progress3.ColorBackground = ColorIndex.ControlColorNegative;
			progress4.ColorBackground = ColorIndex.ControlColorNegative;
			progress5.ColorBackground = ColorIndex.ControlColorNegative;
			accesslabel.ColorText = ColorIndex.ControlColorNegative;
			grantedlabel.ColorText = ColorIndex.ControlColorNegative;
			UpdateColors();
			
			enablestate = 0;
			enabletimer.Start();
		}

		// Fancy enable sequence
		private void enabletimer_Tick(object sender, EventArgs e)
		{
			if(!General.AccessEnabled)
			{
				switch(enablestate)
				{
					case 0:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.ControlColorNegative;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 1:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 2:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 3:
						accesslabel.Visible = true;
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 4:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 5:
						grantedlabel.Visible = true;
						texttimer.Start();
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 6:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 7:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 8:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 9:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.WindowText;
						progress3.ColorBackground = ColorIndex.ControlColorNegative;
						progress4.ColorBackground = ColorIndex.ControlColorNegative;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 10:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.ControlColorNegative;
						progress4.ColorBackground = ColorIndex.ControlColorNegative;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 11:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.WindowText;
						progress3.ColorBackground = ColorIndex.ControlColorNegative;
						progress4.ColorBackground = ColorIndex.ControlColorNegative;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 12:
						enabletimer.Stop();
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.ControlColorNegative;
						progress4.ColorBackground = ColorIndex.ControlColorNegative;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

				}
			}
			else
			{
				switch(enablestate)
				{
					case 0:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.ControlColorNegative;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 1:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 2:
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.ControlColorNegative;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 3:
						accesslabel.Visible = true;
						progress1.ColorBackground = ColorIndex.ControlColorNegative;
						progress2.ColorBackground = ColorIndex.WindowText;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;

					case 4:
						progress1.ColorBackground = ColorIndex.WindowText;
						progress2.ColorBackground = ColorIndex.WindowText;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.ControlColorNegative;
						break;
					
					case 5:
						grantedlabel.Visible = true;
						progress1.ColorBackground = ColorIndex.WindowText;
						progress2.ColorBackground = ColorIndex.WindowText;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.WindowText;
						break;
					
					case 6:
					case 7:
					case 8:
					case 9:
						break;
						
					case 10:
						accesslabel.ColorText = ColorIndex.WindowText;
						grantedlabel.ColorText = ColorIndex.WindowText;
						progress1.ColorBackground = ColorIndex.WindowText;
						progress2.ColorBackground = ColorIndex.WindowText;
						progress3.ColorBackground = ColorIndex.WindowText;
						progress4.ColorBackground = ColorIndex.WindowText;
						progress5.ColorBackground = ColorIndex.WindowText;
						break;

					case 11:
					case 12:
					case 13:
					case 14:
					case 15:
					case 16:
					case 17:
					case 18:
					case 19:
					case 20:
					case 21:
					case 22:
					case 23:
						break;

					case 24:
						General.Sounds.Play("210");
						enabletimer.Stop();
						General.MainWindow.ShowTaggedPanel(continuepanel);
						break;
				}
			}
			
			// Update
			UpdateColors();
			
			// Next state
			enablestate++;
		}

		#endregion
	}
}
