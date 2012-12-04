
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
using System.Drawing.Drawing2D;

#endregion

namespace CodeImp.Gluon
{
	public partial class DisplayCorner : DisplayUserControl, IColorable
	{
		#region ================== Variables

		private ColorIndex backcolor;
		private int curvedetail;
		private bool flipx;
		private bool flipy;
		
		#endregion
		
		#region ================== Properties

		public ColorIndex ColorBackground { get { return backcolor; } set { backcolor = value; } }
		public int CurveDetail { get { return curvedetail; } set { curvedetail = value; UpdateRegion(); } }
		public bool FlipX { get { return flipx; } set { flipx = value; UpdateRegion(); } }
		public bool FlipY { get { return flipy; } set { flipy = value; UpdateRegion(); } }

		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public DisplayCorner()
		{
			backcolor = ColorIndex.WindowBackground;
			curvedetail = 10;
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
		
		// This updates the control shape
		private void UpdateRegion()
		{
			Rectangle r = this.ClientRectangle;
			Point[] points = new Point[curvedetail + 3];
			byte[] types = new byte[curvedetail + 3];
			
			// First make the points along the right edges
			points[0] = new Point(0, r.Height);
			points[1] = new Point(0, 0);
			points[2] = new Point(r.Width, 0);
			types[0] = 0;	// start
			types[1] = 1;	// line
			types[2] = 1;	// line
			
			// Make the curve
			Point center = new Point(r.Width, r.Height);
			float startangle = 0;
			float endangle = -((float)Math.PI * 0.5f);
			for(int p = 0; p < curvedetail; p++)
			{
				float u = (float)(p + 1) / (float)(curvedetail + 1);
				float a = startangle + u * (endangle - startangle);
				float x = (float)Math.Sin(a) * (float)r.Width;
				float y = -(float)Math.Cos(a) * (float)r.Height;
				points[p + 3] = new Point(center.X + (int)x, center.Y + (int)y);
				types[p + 3] = 1;	// line
			}
			
			// Flip if needed
			if(flipx)
			{
				for(int p = 0; p < curvedetail + 3; p++)
					points[p].X = r.Width - 1 - points[p].X;
			}		
			if(flipy)
			{
				for(int p = 0; p < curvedetail + 3; p++)
					points[p].Y = r.Height - 1 - points[p].Y;
			}
			
			GraphicsPath path = new GraphicsPath(points, types);
			this.Region = new Region(path);
		}
		
		#endregion
		
		#region ================== Events
		
		// When resized
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			UpdateRegion();
		}

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
