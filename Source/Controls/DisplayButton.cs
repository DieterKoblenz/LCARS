
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
	public class DisplayButton : Label, IColorable, IVisibleInfo
	{
		#region ================== Variables

		protected bool flashwarning;
		protected bool flashinfo;
		protected bool inverseflash;
		protected ColorIndex normalcolor;
		protected ColorIndex textcolor;
		protected bool localenabled;
		protected CornerImagesProvider corners;
		protected bool clickable;
		protected Timer releasetimer;
		protected bool ismousedown;
		protected string clicksound;

		protected bool iswantedvisible = true;

		#endregion
		
		#region ================== Properties
		
		new public FlatStyle FlatStyle { get { return FlatStyle.Flat; } set { } }
		public virtual bool IsWarningFlashing { get { return flashwarning; } }
		public virtual bool IsInfoFlashing { get { return flashinfo; } }
		public virtual bool InverseFlash { get { return inverseflash; } set { inverseflash = value; } }
		public ColorIndex ColorNormal { get { return normalcolor; } set { normalcolor = value; } }
		public ColorIndex ColorText { get { return textcolor; } set { textcolor = value; } }
		new public bool Enabled { get { return localenabled; } set { localenabled = value; } }
		public bool Clickable { get { return clickable; } set { clickable = value; } }

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

		public string ClickSound { get { return clicksound; } set { clicksound = value; } }

		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public DisplayButton()
		{
			textcolor = ColorIndex.ControlNormalText;
			base.FlatStyle = FlatStyle.Flat;
			corners = new CornerImagesProvider();
			corners.ScaleFixedWidth = true;
			localenabled = true;
			clicksound = "207";		// short subtile beep
			clickable = true;
			normalcolor = ColorIndex.ControlNormal;
			releasetimer = new Timer();
			releasetimer.Interval = 100;
			releasetimer.Tick += releasetimer_Tick;
		}
		
		#endregion
		
		#region ================== Methods
		
		// Setup colors
		public virtual void SetupColors(ColorPalette c)
		{
			SetupColorsLocal(c);
			
			// Setup colors on child controls
			foreach(Control cc in base.Controls)
			{
				if(cc is IColorable)
					(cc as IColorable).SetupColors(c);
			}
		}
		
		// Setup colors locally only
		private void SetupColorsLocal(ColorPalette c)
		{
			// Disabled?
			if(!localenabled)
			{
				// Disabled color
				this.BackColor = c[ColorIndex.ControlDisabled];
				this.ForeColor = c[ColorIndex.ControlDisabledText];
			}
			// Info color?
			else if(!flashwarning && flashinfo)
			{
				if(General.MainWindow.InfoFlashState ^ inverseflash)
				{
					this.BackColor = c[ColorIndex.InfoLight];
					this.ForeColor = c[ColorIndex.InfoLightText];
				}
				else
				{
					this.BackColor = c[ColorIndex.InfoDark];
					this.ForeColor = c[ColorIndex.InfoDarkText];
				}
			}
			// Warning color?
			else if(flashwarning)
			{
				if(General.MainWindow.WarningFlashState ^ inverseflash)
				{
					this.BackColor = c[ColorIndex.WarningLight];
					this.ForeColor = c[ColorIndex.WarningLightText];
				}
				else
				{
					this.BackColor = c[ColorIndex.WarningDark];
					this.ForeColor = c[ColorIndex.WarningDarkText];
				}
			}
			else
			{
				// Normal color
				this.BackColor = c[normalcolor];
				this.ForeColor = c[textcolor];
			}
		}
		
		// Start flashing
		public virtual void StartWarningFlash()
		{
			if(!flashwarning)
			{
				flashwarning = true;
				General.MainWindow.FlashWarning += OnFlashWarning;
				SetupColorsLocal(General.Colors);
				this.Invalidate();
			}
		}
		
		// Stop flashing
		public virtual void StopWarningFlash()
		{
			if(flashwarning)
			{
				flashwarning = false;
				General.MainWindow.FlashWarning -= OnFlashWarning;
				SetupColorsLocal(General.Colors);
				this.Invalidate();
			}
		}
		
		// Start flashing
		public virtual void StartInfoFlash()
		{
			if(!flashinfo)
			{
				flashinfo = true;
				General.MainWindow.FlashInfo += OnFlashInfo;
				SetupColorsLocal(General.Colors);
				this.Invalidate();
			}
		}
		
		// Stop flashing
		public virtual void StopInfoFlash()
		{
			if(flashinfo)
			{
				flashinfo = false;
				General.MainWindow.FlashInfo -= OnFlashInfo;
				SetupColorsLocal(General.Colors);
				this.Invalidate();
			}
		}
		
		// Warning flash timer
		public virtual void OnFlashWarning()
		{
			SetupColorsLocal(General.Colors);
			this.Invalidate();
		}
		
		// Info flash timer
		public virtual void OnFlashInfo()
		{
			SetupColorsLocal(General.Colors);
			this.Invalidate();
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
		
		// Pressed on button
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			if(General.MainWindow == null)
				return;

			if(localenabled)
			{
				if(clickable)
				{
					ismousedown = true;
					General.Sounds.Play(clicksound);
					this.BackColor = General.Colors[ColorIndex.ControlPressed];
					this.ForeColor = General.Colors[ColorIndex.ControlPressedText];
					this.Refresh();
					releasetimer.Start();
				}
				
				General.MainWindow.UserActivity();
				base.OnMouseDown(mevent);
			}
		}
		
		// Mouse leaves the button
		protected override void OnMouseLeave(EventArgs e)
		{
			if(General.MainWindow == null)
				return;
			
			// Reset colors
			if(clickable)
			{
				ismousedown = false;
				SetupColorsLocal(General.Colors);
				releasetimer.Stop();
			}
			
			base.OnMouseLeave(e);
		}
		
		// Button released
		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			if(General.MainWindow == null)
				return;

			if(localenabled)
			{
				if(clickable)
				{
					ismousedown = false;
					
					if(!releasetimer.Enabled)
						SetupColorsLocal(General.Colors);
				}
				
				General.MainWindow.UserActivity();
				base.OnMouseUp(mevent);
			}
		}
		
		// Paint
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			
			if((corners != null) && (pevent != null))
				corners.PaintCorners(pevent.Graphics, this);
		}

		// Doubleclicks
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			OnClick(e);
		}

		// Release timer
		protected void releasetimer_Tick(object sender, EventArgs e)
		{
			releasetimer.Stop();
			
			if(localenabled)
			{
				if(clickable)
				{
					if(!ismousedown)
						SetupColorsLocal(General.Colors);
				}
			}
		}
		
		#endregion
	}
}
