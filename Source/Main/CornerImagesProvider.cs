
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
	public class CornerImagesProvider
	{
		#region ================== Variables
		
		private InterfaceImage ltimage = InterfaceImage.None;
		private InterfaceImage rtimage = InterfaceImage.None;
		private InterfaceImage rbimage = InterfaceImage.None;
		private InterfaceImage lbimage = InterfaceImage.None;
		
		private float ltscale = 0.25f;
		private float rtscale = 0.25f;
		private float rbscale = 0.25f;
		private float lbscale = 0.25f;
		private bool scalefixedwidth = false;

		private Rectangle ltr, rtr, rbr, lbr;
		
		#endregion
		
		#region ================== Properties
		
		public InterfaceImage ImageLeftTop { get { return ltimage; } set { ltimage = value; } }
		public InterfaceImage ImageRightTop { get { return rtimage; } set { rtimage = value; } }
		public InterfaceImage ImageRightBottom { get { return rbimage; } set { rbimage = value; } }
		public InterfaceImage ImageLeftBottom { get { return lbimage; } set { lbimage = value; } }
		
		public float ScaleLeftTop { get { return ltscale; } set { ltscale = value; } }
		public float ScaleRightTop { get { return rtscale; } set { rtscale = value; } }
		public float ScaleRightBottom { get { return rbscale; } set { rbscale = value; } }
		public float ScaleLeftBottom { get { return lbscale; } set { lbscale = value; } }
		
		public bool ScaleFixedWidth { get { return scalefixedwidth; } set { scalefixedwidth = value; } }
		
		#endregion
		
		#region ================== Methods
		
		// This makes/updates the rectangles where the images will align to
		private void UpdateRectangles(Control c)
		{
			Rectangle cr = c.ClientRectangle;
			float usewidth = scalefixedwidth ? (float)cr.Height : (float)cr.Width;

			if(ltimage != InterfaceImage.None)
				ltr = new Rectangle(0, 0, (int)(usewidth * ltscale), (int)(cr.Height * ltscale));
			else
				ltr = new Rectangle(0, 0, 0, 0);

			if(rtimage != InterfaceImage.None)
			{
				int w = (int)(usewidth * rtscale);
				rtr = new Rectangle(cr.Width - w, 0, w, (int)(cr.Height * rtscale));
			}
			else
				rtr = new Rectangle(cr.Width, 0, 0, 0);

			if(rbimage != InterfaceImage.None)
			{
				int w = (int)(usewidth * rbscale);
				int h = (int)((float)cr.Height * rbscale);
				rbr = new Rectangle(cr.Width - w, cr.Height - h, w, h);
			}
			else
				rbr = new Rectangle(cr.Width, cr.Height, 0, 0);

			if(lbimage != InterfaceImage.None)
			{
				int h = (int)((float)cr.Height * lbscale);
				lbr = new Rectangle(0, cr.Height - h, (int)(usewidth * lbscale), h);
			}
			else
				lbr = new Rectangle(0, cr.Height, 0, 0);
		}
		
		// Add snap lines that other controls can align to
		public void AddSnapLines(IList snaplines, Control c)
		{
			UpdateRectangles(c);
			
			if(ltr.Height > 0)
				snaplines.Add(new SnapLine(SnapLineType.Horizontal, ltr.Bottom, SnapLinePriority.Always));

			if(rtr.Height > 0)
				snaplines.Add(new SnapLine(SnapLineType.Horizontal, rtr.Bottom, SnapLinePriority.Always));

			if(rbr.Height > 0)
				snaplines.Add(new SnapLine(SnapLineType.Horizontal, rbr.Top, SnapLinePriority.Always));

			if(lbr.Height > 0)
				snaplines.Add(new SnapLine(SnapLineType.Horizontal, lbr.Top, SnapLinePriority.Always));

			if(ltr.Width > 0)
				snaplines.Add(new SnapLine(SnapLineType.Vertical, ltr.Right, SnapLinePriority.Always));

			if(rtr.Width > 0)
				snaplines.Add(new SnapLine(SnapLineType.Vertical, rtr.Left, SnapLinePriority.Always));

			if(rbr.Width > 0)
				snaplines.Add(new SnapLine(SnapLineType.Vertical, rbr.Left, SnapLinePriority.Always));

			if(lbr.Width > 0)
				snaplines.Add(new SnapLine(SnapLineType.Vertical, lbr.Right, SnapLinePriority.Always));
		}

		// Paint the corner images
		public void PaintCorners(Graphics g, Control c)
		{
			bool designmode = (General.Images == null);

			UpdateRectangles(c);

			g.CompositingQuality = CompositingQuality.HighSpeed;
			g.InterpolationMode = InterpolationMode.Bicubic;
			g.SmoothingMode = SmoothingMode.Default;
			
			if(ltimage != InterfaceImage.None)
			{
				if(!designmode)
				{
					Image i = General.Images.GetImage(ltimage);
					g.DrawImage(i, ltr);
				}
				else
					g.DrawRectangle(SystemPens.WindowText, ltr);
			}
			
			if(rtimage != InterfaceImage.None)
			{
				if(!designmode)
				{
					Image i = General.Images.GetImage(rtimage);
					g.DrawImage(i, rtr);
				}
				else
					g.DrawRectangle(SystemPens.WindowText, rtr);
			}
			
			if(rbimage != InterfaceImage.None)
			{
				if(!designmode)
				{
					Image i = General.Images.GetImage(rbimage);
					g.DrawImage(i, rbr);
				}
				else
					g.DrawRectangle(SystemPens.WindowText, rbr);
			}
			
			if(lbimage != InterfaceImage.None)
			{
				if(!designmode)
				{
					Image i = General.Images.GetImage(lbimage);
					g.DrawImage(i, lbr);
				}
				else
					g.DrawRectangle(SystemPens.WindowText, lbr);
			}
		}

		#endregion
	}
}
