
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
	public class DisplayTextBox : TextBox, IColorable, IVisibleInfo
	{
		#region ================== Variables

		private ColorIndex backcolor;
		private ColorIndex forecolor;
		private Control focuscontrol = null;
		private bool iswantedvisible = true;
		private string clicksound;

		#endregion

		#region ================== Properties

		public ColorIndex ColorBackground { get { return backcolor; } set { backcolor = value; } }
		public ColorIndex ColorText { get { return forecolor; } set { forecolor = value; } }
		public Control FocusControl { get { return focuscontrol; } set { focuscontrol = value; } }
		public string ClickSound { get { return clicksound; } set { clicksound = value; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public DisplayTextBox()
		{
			backcolor = ColorIndex.WindowBackground;
			forecolor = ColorIndex.WindowText;
		}

		#endregion

		#region ================== Methods

		// Setup colors
		public virtual void SetupColors(ColorPalette c)
		{
			this.BackColor = c[backcolor];
			this.ForeColor = c[forecolor];

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
