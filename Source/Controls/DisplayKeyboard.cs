
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace CodeImp.Gluon
{
	public partial class DisplayKeyboard : DisplayUserControl, IColorable
	{
		#region ================== Variables
		
		private ColorIndex backcolor;
		
		private bool shift;
		
		#endregion
		
		#region ================== Properties
		
		public ColorIndex ColorBackground { get { return backcolor; } set { backcolor = value; } }
		
		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public DisplayKeyboard()
		{
			InitializeComponent();
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

		// This changes symbol and numeric buttons according to the shift state
		private void UpdateButtons()
		{
			if(shift)
			{
				num0.Text = ")"; num0.Tag = "{)}";
				num1.Text = "!"; num1.Tag = "!";
				num2.Text = "@"; num2.Tag = "@";
				num3.Text = "#"; num3.Tag = "#";
				num4.Text = "$"; num4.Tag = "$";
				num5.Text = "%"; num5.Tag = "{%}";
				num6.Text = "^"; num6.Tag = "{^}";
				num7.Text = "&"; num7.Tag = "&";
				num8.Text = "*"; num8.Tag = "*";
				num9.Text = "("; num9.Tag = "{(}";
				sym0.Text = ";"; sym0.Tag = ":";
				sym1.Text = "?"; sym1.Tag = "?";
				sym2.Text = "="; sym2.Tag = "=";
				sym3.Text = "_"; sym3.Tag = "_";
				sym4.Text = ","; sym4.Tag = ",";
			}
			else
			{
				num0.Text = "0"; num0.Tag = "0";
				num1.Text = "1"; num1.Tag = "1";
				num2.Text = "2"; num2.Tag = "2";
				num3.Text = "3"; num3.Tag = "3";
				num4.Text = "4"; num4.Tag = "4";
				num5.Text = "5"; num5.Tag = "5";
				num6.Text = "6"; num6.Tag = "6";
				num7.Text = "7"; num7.Tag = "7";
				num8.Text = "8"; num8.Tag = "8";
				num9.Text = "9"; num9.Tag = "9";
				sym0.Text = ":"; sym0.Tag = ":";
				sym1.Text = "/"; sym1.Tag = "/";
				sym2.Text = "+"; sym2.Tag = "{+}";
				sym3.Text = "-"; sym3.Tag = "-";
				sym4.Text = "."; sym4.Tag = ".";
			}
		}

		// This turns Shift off if it is on
		private void TurnShiftOff()
		{
			if(shift)
			{
				shift = false;
				buttonshiftleft.StopInfoFlash();
				UpdateButtons();
			}
		}
		
		#endregion
		
		#region ================== Events
		
		// Resize
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			
			// Fixed size
			this.Size = new Size(buttondelete.Right, buttondelete.Bottom);
		}
		
		// For basic keys we have a generalized event handler
		private void TaggedButtonPressUpperLower(object sender, MouseEventArgs e)
		{
			string tag = (string)((sender as Control).Tag);
			if(shift) tag = tag.ToUpperInvariant();
			if(!shift) tag = tag.ToLowerInvariant();
			SendKeys.Send(tag);
			TurnShiftOff();
		}

		// For basic keys we have a generalized event handler
		private void TaggedButtonPress(object sender, MouseEventArgs e)
		{
			string tag = (string)((sender as Control).Tag);
			SendKeys.Send(tag);
			TurnShiftOff();
		}
		
		// Click handler for both shift keys
		private void buttonshift_Click(object sender, EventArgs e)
		{
			if(!shift)
			{
				buttonshiftleft.StartInfoFlash();
				shift = true;
			}
			else
			{
				buttonshiftleft.StopInfoFlash();
				shift = false;
			}

			UpdateButtons();
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
