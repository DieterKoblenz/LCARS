
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
	public partial class ErrorDisplayPanel : DisplayPanel
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
		public ErrorDisplayPanel()
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
			failurelabel.SetupColors(General.Colors);
		}
		
		#endregion

		#region ================== Events

		// When shown
		public override void OnShow()
		{
			if(General.ErrorMessage != descriptionlabel.Text)
			{
				descriptionlabel.Text = General.ErrorMessage;
				systemlabel.Visible = true;
				failurelabel.Visible = true;
				systemlabel.ColorText = ColorIndex.ControlColorNegative;
				failurelabel.ColorText = ColorIndex.ControlColorNegative;
				progress1.ColorBackground = ColorIndex.ControlColorNegative;
				progress2.ColorBackground = ColorIndex.ControlColorNegative;
				progress3.ColorBackground = ColorIndex.ControlColorNegative;
				progress4.ColorBackground = ColorIndex.ControlColorNegative;
				progress5.ColorBackground = ColorIndex.ControlColorNegative;
				UpdateColors();

				base.OnShow();

				General.Sounds.Play("accessdenied");
				General.AccessEnabled = false;
				flashstate = false;
				texttimer.Start();
				enablestate = 0;
				enabletimer.Start();

				General.MainWindow.DisableScreensaver();
			}
		}
		
		// When leaving
		public override void OnHide()
		{
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
				failurelabel.ColorText = ColorIndex.ControlColorNegative;
				flashstate = false;
			}
			else
			{
				systemlabel.ColorText = ColorIndex.WindowText;
				failurelabel.ColorText = ColorIndex.WindowText;
				flashstate = true;
			}
			
			systemlabel.SetupColors(General.Colors);
			failurelabel.SetupColors(General.Colors);
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
					failurelabel.Visible = true;
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
			
			// Update
			UpdateColors();
			
			// Next state
			enablestate++;
		}

		#endregion
	}
}
