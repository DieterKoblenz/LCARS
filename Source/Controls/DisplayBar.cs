
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
	//[Designer(typeof(DisplayBarDesigner))]
	public class DisplayBar : Panel, IColorable, IVisibleInfo
	{
		#region ================== Variables

		private ColorIndex normalcolor;
		private CornerImagesProvider corners;
		private bool blockmouseinput = true;
		private bool iswantedvisible = true;
		private Control focuscontrol = null;
		private string clicksound;

		#endregion
		
		#region ================== Properties

		public ColorIndex ColorNormal { get { return normalcolor; } set { normalcolor = value; } }
		
		// Corner images
		public InterfaceImage ImageLeftTop { get { return corners.ImageLeftTop; } set { corners.ImageLeftTop = value; this.Invalidate(); } }
		public InterfaceImage ImageRightTop { get { return corners.ImageRightTop; } set { corners.ImageRightTop = value; this.Invalidate(); } }
		public InterfaceImage ImageRightBottom { get { return corners.ImageRightBottom; } set { corners.ImageRightBottom = value; this.Invalidate(); } }
		public InterfaceImage ImageLeftBottom { get { return corners.ImageLeftBottom; } set { corners.ImageLeftBottom = value; this.Invalidate(); } }
		public float ScaleLeftTop { get { return corners.ScaleLeftTop; } set { corners.ScaleLeftTop = value; this.Invalidate(); } }
		public float ScaleRightTop { get { return corners.ScaleRightTop; } set { corners.ScaleRightTop = value; this.Invalidate(); } }
		public float ScaleRightBottom { get { return corners.ScaleRightBottom; } set { corners.ScaleRightBottom = value; this.Invalidate(); } }
		public float ScaleLeftBottom { get { return corners.ScaleLeftBottom; } set { corners.ScaleLeftBottom = value; this.Invalidate(); } }
		public bool ScaleFixedWidth { get { return corners.ScaleFixedWidth; } set { corners.ScaleFixedWidth = value; this.Invalidate(); } }
		public CornerImagesProvider CornerImagesProvider { get { return corners; } }
		public bool BlockMouseInput { get { return blockmouseinput; } set { blockmouseinput = value; } }
		public Control FocusControl { get { return focuscontrol; } set { focuscontrol = value; } }
		public string ClickSound { get { return clicksound; } set { clicksound = value; } }
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public DisplayBar()
		{
			corners = new CornerImagesProvider();
			normalcolor = ColorIndex.ControlNormal;
			blockmouseinput = true;
		}
		
		#endregion
		
		#region ================== Methods
		
		// Setup colors
		public virtual void SetupColors(ColorPalette c)
		{
			this.BackColor = c[normalcolor];
			this.ForeColor = c[ColorIndex.ControlNormalText];
			
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

		// Paint
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			base.OnPaintBackground(e);

			if((corners != null) && (e != null))
				corners.PaintCorners(e.Graphics, this);
		}
		
		// Windows Messages
		protected override void WndProc(ref Message m)
		{
			if(blockmouseinput)
			{
				// Don't process these messages here, because they will change the focus to this control
				if((m.Msg == General.WM_LBUTTONDOWN) || (m.Msg == General.WM_LBUTTONDBLCLK) ||
				   (m.Msg == General.WM_MBUTTONDOWN) || (m.Msg == General.WM_MBUTTONDBLCLK) ||
					(m.Msg == General.WM_RBUTTONDOWN) || (m.Msg == General.WM_RBUTTONDBLCLK))
					return;
			}
			
			base.WndProc(ref m);
		}

		// Mouse down
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if(!string.IsNullOrEmpty(clicksound))
				General.Sounds.Play(clicksound);
			
			base.OnMouseDown(e);
		}

		// Mouse click
		protected override void OnClick(EventArgs e)
		{
			if(focuscontrol != null)
				focuscontrol.Focus();
			
			base.OnClick(e);
		}
		
		#endregion
	}
}
