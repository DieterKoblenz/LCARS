
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
using System.Threading;
using System.Windows.Forms;

#endregion

namespace CodeImp.Gluon
{
	public partial class LoadingDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private bool flashstate;
		private int enablestate;

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public LoadingDisplayPanel()
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
			systemlabel.SetupColors(General.Colors);
			initlabel.SetupColors(General.Colors);
		}

		// This shows the current status
		private void DisplayStatus(string description)
		{
			descriptionlabel.Text = description;
			this.Update();
		}
		
		// This does the loading
		private void Load()
		{
			DisplayStatus("Waiting for database service connection . . .");
			while(!General.DB.Connect())
			{
				Application.DoEvents();
				Thread.Sleep(600);
			}

			ShowLights(1);
			DisplayStatus("Scanning for bluetooth devices . . .");
			General.Obex.Initialize();

			ShowLights(3);
			DisplayStatus("Activating network data monitoring . . .");
			General.PCap.Start();
			
			
			// Done!
			ShowLights(5);
			General.MainWindow.ShowTaggedPanel("overview");
		}
		

		// This shows the progress status
		private void ShowLights(int lights)
		{
			General.Sounds.Play("list");
			progress1.ColorBackground = (lights > 0) ? ColorIndex.WindowText : ColorIndex.ControlColorNegative;
			progress2.ColorBackground = (lights > 1) ? ColorIndex.WindowText : ColorIndex.ControlColorNegative;
			progress3.ColorBackground = (lights > 2) ? ColorIndex.WindowText : ColorIndex.ControlColorNegative;
			progress4.ColorBackground = (lights > 3) ? ColorIndex.WindowText : ColorIndex.ControlColorNegative;
			progress5.ColorBackground = (lights > 4) ? ColorIndex.WindowText : ColorIndex.ControlColorNegative;
			UpdateColors();
			this.Update();
			Thread.Sleep(100);
		}
		
		#endregion

		#region ================== Events

		// When shown
		public override void OnShow()
		{
			systemlabel.Visible = true;
			initlabel.Visible = true;
			systemlabel.ColorText = ColorIndex.ControlColorNegative;
			initlabel.ColorText = ColorIndex.ControlColorNegative;
			progress1.ColorBackground = ColorIndex.ControlColorNegative;
			progress2.ColorBackground = ColorIndex.ControlColorNegative;
			progress3.ColorBackground = ColorIndex.ControlColorNegative;
			progress4.ColorBackground = ColorIndex.ControlColorNegative;
			progress5.ColorBackground = ColorIndex.ControlColorNegative;
			UpdateColors();

			base.OnShow();

			flashstate = false;
			texttimer.Start();
			enablestate = 0;
			enabletimer.Start();
		}
		
		// When leaving
		public override void OnHide()
		{
			General.Sounds.Play("210");
			base.OnHide();
			texttimer.Stop();
			enabletimer.Stop();
		}

		// This flashes the text
		private void texttimer_Tick(object sender, EventArgs e)
		{
			if(flashstate)
			{
				systemlabel.ColorText = ColorIndex.ControlColorNegative;
				initlabel.ColorText = ColorIndex.ControlColorNegative;
				flashstate = false;
			}
			else
			{
				systemlabel.ColorText = ColorIndex.WindowText;
				initlabel.ColorText = ColorIndex.WindowText;
				flashstate = true;
			}
			
			systemlabel.SetupColors(General.Colors);
			initlabel.SetupColors(General.Colors);
		}

		// Restart software
		private void quickrestartbutton_Click(object sender, EventArgs e)
		{
			Tools.RunBatch("restart_software.bat");
			Application.Exit();
		}

		// Restart computer
		private void fullrestartbutton_Click(object sender, EventArgs e)
		{
			Tools.RunBatch("restart_computer.bat");
			Application.Exit();
		}
		
		// Fancy enable sequence
		private void enabletimer_Tick(object sender, EventArgs e)
		{
			switch(enablestate)
			{
				case 0:
					General.Sounds.Play("list");
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
					General.Sounds.Play("list");
					systemlabel.Visible = true;
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
					General.Sounds.Play("list");
					initlabel.Visible = true;
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
					General.Sounds.Play("list");
					progress1.ColorBackground = ColorIndex.ControlColorNegative;
					progress2.ColorBackground = ColorIndex.WindowText;
					progress3.ColorBackground = ColorIndex.ControlColorNegative;
					progress4.ColorBackground = ColorIndex.ControlColorNegative;
					progress5.ColorBackground = ColorIndex.ControlColorNegative;
					break;

				case 10:
					General.Sounds.Play("list");
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
					General.Sounds.Play("list");
					progress1.ColorBackground = ColorIndex.ControlColorNegative;
					progress2.ColorBackground = ColorIndex.ControlColorNegative;
					progress3.ColorBackground = ColorIndex.ControlColorNegative;
					progress4.ColorBackground = ColorIndex.ControlColorNegative;
					progress5.ColorBackground = ColorIndex.ControlColorNegative;
					UpdateColors();

					enabletimer.Stop();
					Load();
					
					break;

			}
			
			// Update
			UpdateColors();
			
			// Next state
			enablestate++;
		}

		#endregion
	}
}
