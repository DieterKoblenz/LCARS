
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Windows.Forms.Design.Behavior;

#endregion

namespace CodeImp.Gluon
{
	public class ControlTabIndexSorter : IComparer<Control>
	{
		// Constructor
		public ControlTabIndexSorter()
		{
		}
		
		// Comparer
		public int Compare(Control x, Control y)
		{
			return y.TabIndex.CompareTo(x.TabIndex);
		}
	}
}