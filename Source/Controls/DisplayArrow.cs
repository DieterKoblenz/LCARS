
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
	public partial class DisplayArrow : DisplayUserControl, IColorable
	{
		#region ================== Variables
		
		private ColorIndex color;
		private int direction;
		
		#endregion
		
		#region ================== Properties
		
		public ColorIndex Color { get { return color; } set { color = value; } }
		public int Direction { get { return direction; } set { direction = value; UpdateRegion(); } }
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public DisplayArrow()
		{
			color = ColorIndex.ControlColor1;
			direction = 0;
		}
		
		#endregion
		
		#region ================== Methods
		
		// Setup colors
		public virtual void SetupColors(ColorPalette c)
		{
			this.BackColor = c[color];
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
			Point[] points = new Point[3];
			byte[] types = new byte[3];
			types[0] = 0;	// start
			types[1] = 1;	// line
			types[2] = 1;	// line
			
			switch(direction)
			{
				case 0:
					points[0] = new Point(0, r.Height);
					points[1] = new Point(r.Width, r.Height);
					points[2] = new Point(r.Width / 2, 0);
					break;
				
				case 1:
					points[0] = new Point(0, r.Height);
					points[1] = new Point(0, 0);
					points[2] = new Point(r.Width, r.Height / 2);
					break;
				
				case 2:
					points[0] = new Point(0, 0);
					points[1] = new Point(r.Width, 0);
					points[2] = new Point(r.Width / 2, r.Height);
					break;

				case 3:
					points[0] = new Point(r.Width, r.Height);
					points[1] = new Point(r.Width, 0);
					points[2] = new Point(0, r.Height / 2);
					break;

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

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// DisplayArrow
			// 
			this.DoubleBuffered = true;
			this.Name = "DisplayArrow";
			this.ResumeLayout(false);

		}
	}
}
