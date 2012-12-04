
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace CodeImp.Gluon
{
	public class DisplayProgressBar : DisplayButton
	{
		#region ================== Variables

		private double minvalue;
		private double maxvalue;
		private double value;
		
		#endregion

		#region ================== Properties

		public double MinValue { get { return minvalue; } set { minvalue = value; Invalidate(); } }
		public double MaxValue { get { return maxvalue; } set { maxvalue = value; Invalidate(); } }
		public double Value { get { return value; } set { this.value = value; Invalidate(); } }
		
		#endregion

		#region ================== Constructor

		// Constructor
		public DisplayProgressBar()
		{
		}

		#endregion

		#region ================== Methods
		
		#endregion

		#region ================== Events

		// Draw
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			double u;
			Rectangle r = this.ClientRectangle;

			if((maxvalue - minvalue) == 0.0d)
				u = 0.0d;
			else
				u = (value - minvalue) / (maxvalue - minvalue);
			
			int xdelta = (int)((double)r.Width * u);
			Rectangle r1 = new Rectangle(r.Left, r.Top, xdelta, r.Height);
			Rectangle r2 = new Rectangle(r.Left + xdelta, r.Top, r.Width - xdelta, r.Height);
			Brush progresscolor = new SolidBrush(base.ForeColor);
			Brush backcolor = new SolidBrush(base.BackColor);
			pevent.Graphics.FillRectangle(progresscolor, r1);
			pevent.Graphics.FillRectangle(backcolor, r2);
			
			if((corners != null) && (pevent != null))
				corners.PaintCorners(pevent.Graphics, this);
		}
		
		#endregion
	}
}
