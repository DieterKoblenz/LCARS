
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace CodeImp.Gluon
{
	public class DisplayWebBrowser : WebBrowser, IVisibleInfo
	{
		#region ================== Variables

		private bool iswantedvisible = true;
		
		#endregion
		
		#region ================== Properties

		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public DisplayWebBrowser()
		{
		}
		
		#endregion
		
		#region ================== Methods

		protected override void SetVisibleCore(bool value)
		{
			base.SetVisibleCore(value);
			iswantedvisible = value;
		}

		public bool GetCoreVisible()
		{
			return iswantedvisible;
		}
		
		#endregion
		
		#region ================== Events
		
		#endregion
	}
}
