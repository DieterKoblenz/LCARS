
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
	public partial class DisplayPanel : UserControl, IColorable
	{
		#region ================== Variables
		
		private List<Control> showcontrols;
		private string animationendsound;
		
		#endregion
		
		#region ================== Properties

		public string AnimationEndSound { get { return animationendsound; } set { animationendsound = value; } }

		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public DisplayPanel()
		{
			this.DoubleBuffered = true;
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			InitializeComponent();
		}
		
		#endregion
		
		#region ================== Methods
		
		// Setup colors
		public virtual void SetupColors(ColorPalette c)
		{
			this.BackColor = c[ColorIndex.WindowBackground];
			this.ForeColor = c[ColorIndex.WindowText];
			
			// Setup colors on child controls
			foreach(Control cc in base.Controls)
			{
				if(cc is IColorable)
					(cc as IColorable).SetupColors(c);
			}
		}

		// This shows the next control
		// Returns False when no more controls to show
		private bool ShowNextControl()
		{
			if(showcontrols.Count > 0)
			{
				int tabindex = showcontrols[showcontrols.Count - 1].TabIndex;
				while((showcontrols.Count > 0) && (showcontrols[showcontrols.Count - 1].TabIndex == tabindex))
				{
					Control c = showcontrols[showcontrols.Count - 1];
					c.Show();
					showcontrols.RemoveAt(showcontrols.Count - 1);
				}

				return (showcontrols.Count > 0);
			}
			else
			{
				return false;
			}
		}
		
		#endregion
		
		#region ================== Events
		
		// This hides all controls and lists them for showing in order determined by the TabIndex
		public virtual void OnShow()
		{
			ControlTabIndexSorter sorter = new ControlTabIndexSorter();
			showcontrols = new List<Control>();
			ListShowControls(this);
			showcontrols.Sort(sorter);
			showtimer.Start();
		}

		// This is called when the controls animation finished
		protected virtual void OnShowFinished()
		{
		}

		// This hides all controls and lists them for showing in order determined by the TabIndex
		// Works recursively for control containers
		private void ListShowControls(Control basec)
		{
			foreach(Control c in basec.Controls)
			{
				if(c is IVisibleInfo)
				{
					IVisibleInfo ci = (IVisibleInfo)c;
					
					if((c.TabIndex > 0) && ci.GetCoreVisible())
					{
						c.Visible = false;
						showcontrols.Add(c);
					}
				}
				
				ListShowControls(c);
			}
		}
		
		// When hiding the panel
		public virtual void OnHide()
		{
			// Quickly finish the animation to prevent problems in the future
			while(ShowNextControl()) ;
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
		
		// Show controls
		private void showtimer_Tick(object sender, EventArgs e)
		{
			if(!ShowNextControl())
			{
				// Done
				if(!string.IsNullOrEmpty(animationendsound))
					General.Sounds.Play(animationendsound);
				
				showtimer.Stop();

				OnShowFinished();
			}
		}
		
		#endregion
	}
}
