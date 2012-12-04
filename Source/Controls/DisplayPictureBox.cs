
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
	public class DisplayPictureBox : PictureBox, IVisibleInfo
	{
		private bool iswantedvisible = true;
		int tabindex = 0;
		
		protected override void SetVisibleCore(bool value)
		{
			iswantedvisible = value;
			base.SetVisibleCore(value);
		}
		
		public bool GetCoreVisible()
		{
			return iswantedvisible;
		}
		
		new public int TabIndex { get { return tabindex; } set { tabindex = value; } }
	}
}
