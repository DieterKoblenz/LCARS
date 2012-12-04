
#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace CodeImp.Gluon
{
	public class DisplayUserControl : UserControl, IVisibleInfo
	{
		private bool iswantedvisible = true;
		
		protected override void SetVisibleCore(bool value)
		{
			iswantedvisible = value;
			base.SetVisibleCore(value);
		}
		
		public bool GetCoreVisible()
		{
			return iswantedvisible;
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// DisplayUserControl
			// 
			this.DoubleBuffered = true;
			this.Name = "DisplayUserControl";
			this.ResumeLayout(false);

		}
	}
}
