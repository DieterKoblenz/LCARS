
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
	public partial class ObexTransferDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		public const int NUM_DEVICE_BUTTONS = 12;

		#endregion

		#region ================== Variables

		// Interface
		private DisplayButton[] devicebuttons;
		private DisplayButton[] transferbuttons;
		private int selecteddevice;
		
		// Transfer items
		private List<ObexTransferObject> transferobjs;

		private string returnpanel;
		public event VoidEventHandler BackEvent;
		
		#endregion

		#region ================== Properties

		public string ReturnPanel { get { return returnpanel; } set { returnpanel = value; } }
		
		#endregion
		
		#region ================== Constructor

		// Constructor
		public ObexTransferDisplayPanel()
		{
			InitializeComponent();

			// Make device buttons array
			devicebuttons = new DisplayButton[NUM_DEVICE_BUTTONS];
			devicebuttons[0] = devicebutton0;
			devicebuttons[1] = devicebutton1;
			devicebuttons[2] = devicebutton2;
			devicebuttons[3] = devicebutton3;
			devicebuttons[4] = devicebutton4;
			devicebuttons[5] = devicebutton5;
			devicebuttons[6] = devicebutton6;
			devicebuttons[7] = devicebutton7;
			devicebuttons[8] = devicebutton8;
			devicebuttons[9] = devicebutton9;
			devicebuttons[10] = devicebutton10;
			devicebuttons[11] = devicebutton11;

			// Make transfer buttons array
			transferbuttons = new DisplayButton[NUM_DEVICE_BUTTONS];
			transferbuttons[0] = transferbutton0;
			transferbuttons[1] = transferbutton1;
			transferbuttons[2] = transferbutton2;
			transferbuttons[3] = transferbutton3;
			transferbuttons[4] = transferbutton4;
			transferbuttons[5] = transferbutton5;
			transferbuttons[6] = transferbutton6;
			transferbuttons[7] = transferbutton7;
			transferbuttons[8] = transferbutton8;
			transferbuttons[9] = transferbutton9;
			transferbuttons[10] = transferbutton10;
			transferbuttons[11] = transferbutton11;
		}

		#endregion

		#region ================== Methods

		// This sets the object to be transferred
		public void TransferSingleObject(ObexTransferObject obj)
		{
			List<ObexTransferObject> objs = new List<ObexTransferObject>(1);
			objs.Add(obj);
			TransferObjects(objs);
		}

		// This sets the objects to be transferred
		public void TransferObjects(List<ObexTransferObject> objs)
		{
			transferobjs = new List<ObexTransferObject>(objs.Count);
			transferobjs.AddRange(objs);
		}

		// Deselect device
		private void Deselect()
		{
			if(selecteddevice > -1)
			{
				devicebuttons[selecteddevice].StopInfoFlash();
				transferbuttons[selecteddevice].Enabled = false;
				devicebuttons[selecteddevice].SetupColors(General.Colors);
				transferbuttons[selecteddevice].SetupColors(General.Colors);
				selecteddevice = -1;
			}
		}

		#endregion

		#region ================== Events

		// Shown
		public override void OnShow()
		{
			transmitterstatus.StartInfoFlash();
			datastatus.StartInfoFlash();
			selecteddevice = -1;

			// Examine transferobjs and show info
			if(transferobjs.Count == 1)
			{
				numberlabel.Text = transferobjs.Count.ToString() + "  Object:";
				filenamelabel.Text = transferobjs[0].Filename;
			}
			else
			{
				numberlabel.Text = transferobjs.Count.ToString() + "  Objects";
				filenamelabel.Text = "";
			}

			int totalsize = 0;
			for(int i = 0; i < transferobjs.Count; i++)
				totalsize += transferobjs[i].Data.Length;
			sizelabel.Text = totalsize.ToString("n", CultureInfo.CurrentCulture.NumberFormat) + " bytes";

			// Hide device buttons
			for(int i = 0; i < NUM_DEVICE_BUTTONS; i++)
			{
				devicebuttons[i].Visible = false;
				transferbuttons[i].Visible = false;
			}

			updatetimer_Tick(this, EventArgs.Empty);
			updatetimer.Start();
			
			base.OnShow();
		}

		// Hidden
		public override void OnHide()
		{
			Deselect();
			updatetimer.Stop();
			transmitterstatus.StopInfoFlash();
			datastatus.StopInfoFlash();
			base.OnHide();
		}
		
		// Back
		private void backbutton_Click(object sender, EventArgs e)
		{
			if(BackEvent != null)
				BackEvent();

			General.MainWindow.ShowTaggedPanel(returnpanel);
			BackEvent = null;
		}

		// Overview
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
			BackEvent = null;
		}

		// Device selected
		private void devicebutton_Click(object sender, EventArgs e)
		{
			// Find the index
			int thisindex = -1;
			for(int i = 0; i < NUM_DEVICE_BUTTONS; i++)
				if(sender == devicebuttons[i]) thisindex = i;
			
			if(thisindex == selecteddevice)
			{
				Deselect();
			}
			else
			{
				Deselect();
				selecteddevice = thisindex;
				devicebuttons[selecteddevice].StartInfoFlash();
				devicebuttons[selecteddevice].SetupColors(General.Colors);
				transferbuttons[selecteddevice].Enabled = true;
				transferbuttons[selecteddevice].SetupColors(General.Colors);
			}
		}

		// Transfer clicked
		private void transferbutton_Click(object sender, EventArgs e)
		{
			ObexBluetoothDevice dev = (ObexBluetoothDevice)devicebuttons[selecteddevice].Tag;
			foreach(ObexTransferObject obj in transferobjs)
			{
				obj.Target = dev;
				General.Obex.SendObject(obj);
			}

			Deselect();
		}

		// Update devices
		private void updatetimer_Tick(object sender, EventArgs e)
		{
			if(selecteddevice == -1)
			{
				ObexBluetoothDevice[] devices = new ObexBluetoothDevice[0];
				if(General.Obex.GetBluetoothDevices(ref devices))
				{
					for(int i = 0; i < NUM_DEVICE_BUTTONS; i++)
					{
						if(i < devices.Length)
						{
							ObexBluetoothDevice d = devices[i];
							devicebuttons[i].Text = d.name;
							devicebuttons[i].Tag = d;
							devicebuttons[i].SetupColors(General.Colors);
							devicebuttons[i].Visible = true;
							transferbuttons[i].Enabled = false;
							transferbuttons[i].SetupColors(General.Colors);
							transferbuttons[i].Visible = true;
						}
						else
						{
							devicebuttons[i].Visible = false;
							transferbuttons[i].Visible = false;
						}
					}
				}
			}
		}

		#endregion
	}
}
