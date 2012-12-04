
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
	public class DisplayFrame : Panel, IColorable, IVisibleInfo
	{
		#region ================== Variables

		private ColorIndex backcolor;
		private bool iswantedvisible = true;

		#endregion

		#region ================== Properties

		public ColorIndex ColorBackground { get { return backcolor; } set { backcolor = value; } }
		
		#endregion

		#region ================== Constructor

		// Constructor
		public DisplayFrame()
		{
			backcolor = ColorIndex.WindowBackground;
		}

		#endregion

		#region ================== Methods

		// Setup colors
		public virtual void SetupColors(ColorPalette c)
		{
			this.BackColor = c[backcolor];
			this.ForeColor = c[ColorIndex.WindowText];

			// Setup colors on child controls
			foreach(Control cc in base.Controls)
			{
				if(cc is IColorable)
					(cc as IColorable).SetupColors(c);
			}
		}
		
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

		// Windows Messages
		protected override void WndProc(ref Message m)
		{
			// Don't process these messages here, because they will change the focus to this control
			if((m.Msg == General.WM_LBUTTONDOWN) || (m.Msg == General.WM_LBUTTONDBLCLK) ||
			   (m.Msg == General.WM_MBUTTONDOWN) || (m.Msg == General.WM_MBUTTONDBLCLK) ||
				(m.Msg == General.WM_RBUTTONDOWN) || (m.Msg == General.WM_RBUTTONDBLCLK))
				return;

			base.WndProc(ref m);
		}
		
		#endregion
	}
}
