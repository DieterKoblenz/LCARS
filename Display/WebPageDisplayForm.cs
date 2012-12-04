
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
	public partial class WebPageDisplayForm : Form
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public WebPageDisplayForm()
		{
			InitializeComponent();
		}

		#endregion

		#region ================== Methods

		public void ShowURL(string url)
		{
			browser.Navigate(url);
		}
		
		#endregion

		#region ================== Events

		#endregion
	}
}
