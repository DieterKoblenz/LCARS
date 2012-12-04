
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Text;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace CodeImp.Gluon
{
	public class DisplayLabel : Label, IColorable, IVisibleInfo
	{
		#region ================== Variables

		private ColorIndex backcolor;
		private ColorIndex forecolor;
		private Control focuscontrol = null;
		private bool iswantedvisible = true;
		private string clicksound;
		private bool autosizeheight = false;
		private int maxheight = 0;
		
		#endregion

		#region ================== Properties
		
		public ColorIndex ColorBackground { get { return backcolor; } set { backcolor = value; } }
		public ColorIndex ColorText { get { return forecolor; } set { forecolor = value; } }
		public Control FocusControl { get { return focuscontrol; } set { focuscontrol = value; } }
		public string ClickSound { get { return clicksound; } set { clicksound = value; } }
		public override bool AutoSize { get { return base.AutoSize; } set { base.AutoSize = value; if(value) this.AutoSizeHeight = false; } }
		public bool AutoSizeHeight { get { return autosizeheight; } set { autosizeheight = value; if(value) this.AutoSize = false; ApplyHeightForText(); } }
		public int MaximumHeight { get { return maxheight; } set { maxheight = value; ApplyHeightForText(); } }
		
		#endregion

		#region ================== Constructor

		// Constructor
		public DisplayLabel()
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

		public int GetHeightForText()
		{
			Graphics g = this.CreateGraphics();
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			Size region = new Size(this.Width, int.MaxValue);
			Size textsize = TextRenderer.MeasureText(g, this.Text, this.Font, region, TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.WordBreak);
			return (maxheight > 0) ? Math.Min(textsize.Height, maxheight) : textsize.Height;
		}

		private void ApplyHeightForText()
		{
			if(autosizeheight)
				this.Height = GetHeightForText();
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

		// Resize
		protected override void OnResize(EventArgs e)
		{
			ApplyHeightForText();
			
			base.OnResize(e);
		}

		// Text changes
		protected override void OnTextChanged(EventArgs e)
		{
			ApplyHeightForText();
			
			base.OnTextChanged(e);
		}
		
		#endregion
	}
}
