
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
	public partial class BlankScreen : Form
	{
		public BlankScreen()
		{
			InitializeComponent();
			calibratinglabel.SetupColors(General.Colors);
		}
	}
}
