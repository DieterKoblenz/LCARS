
#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;

#endregion

namespace CodeImp.Gluon
{
	public partial class ColorsForm : Form
	{
		#region ================== Variables
		
		#endregion

		#region ================== Properties
		
		#endregion

		#region ================== Constructor
		
		// Constructor
		public ColorsForm()
		{
			InitializeComponent();
			
			General.MainWindow.DisableScreensaver();

			ReadColors(this);
		}
		
		#endregion

		#region ================== Methods
		
		// This recursively reads the colors
		private void ReadColors(Control pc)
		{
			// Go for all color controls
			foreach(Control c in pc.Controls)
			{
				if(c is ColorControl)
				{
					ColorControl cc = (c as ColorControl);

					// Apply current color to control
					cc.Color = General.Colors.GetNormalColor(cc.ColorIndex);
				}

				ReadColors(c);
			}
		}
		
		// This recursively writes the colors
		private void WriteColors(Control pc)
		{
			// Go for all color controls
			foreach(Control c in pc.Controls)
			{
				if(c is ColorControl)
				{
					ColorControl cc = (c as ColorControl);
					
					// Apply color to palette
					General.Colors.SetNormalColor(cc.ColorIndex, cc.Color);
				}

				WriteColors(c);
			}
		}
		
		// This applies all colors
		private void ApplyColors()
		{
			WriteColors(this);
			
			// Refresh
			General.Colors.SetupDarkScheme();
			General.Images.BuildImages();
			General.Colors.SetupNormalScheme();
			General.Images.BuildImages();
			General.MainWindow.SetupColors(General.Colors);
		}
		
		#endregion
		
		#region ================== Events
		
		// Apply
		private void buttonapply_Click(object sender, EventArgs e)
		{
			ApplyColors();
		}
		
		// OK
		private void buttonok_Click(object sender, EventArgs e)
		{
			ApplyColors();
			DialogResult = DialogResult.OK;
			General.MainWindow.EnableScreensaver();
			Close();
		}
		
		// Close
		private void buttonclose_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			General.MainWindow.EnableScreensaver();
			Close();
		}
		
		#endregion
	}
}