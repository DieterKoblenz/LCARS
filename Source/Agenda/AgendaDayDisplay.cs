
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

#endregion

namespace CodeImp.Gluon
{
	public partial class AgendaDayDisplay : UserControl, IColorable
	{
		#region ================== Variables

		// Dynamic controls
		private List<DisplayLabel> labels;

		public event EventHandler ViewClicked;
		public event EventHandler AddClicked;

		private DateTime day;
		
		#endregion
		
		#region ================== Properties

		public DateTime Day { get { return day; } }

		#endregion
		
		#region ================== Constructor
		
		// Constructor
		public AgendaDayDisplay()
		{
			InitializeComponent();
			labels = new List<DisplayLabel>();
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			CleanupControls();
			
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			
			base.Dispose(disposing);
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
		
		// This sets the date that this control represents
		public void SetupDate(DateTime date)
		{
			day = date;
			
			// Day number and name
			daylabel.Text = date.Day.ToString();
			daynamelabel.Text = date.DayOfWeek.ToString();
			
			// Give today a special color
			DateTime now = DateTime.Now;
			if((date.Year == now.Year) && (date.Month == now.Month) && (date.Day == now.Day))
			{
				daybar.ColorNormal = ColorIndex.InfoLight;
				daylabel.ColorBackground = ColorIndex.InfoLight;
				daynamelabel.ColorBackground = ColorIndex.InfoLight;
				viewbutton.ColorNormal = ColorIndex.InfoDark;
				addbutton.ColorNormal = ColorIndex.InfoDark;
			}
			else
			{
				daybar.ColorNormal = ColorIndex.ControlNormal;
				daylabel.ColorBackground = ColorIndex.ControlNormal;
				daynamelabel.ColorBackground = ColorIndex.ControlNormal;
				viewbutton.ColorNormal = ColorIndex.ControlNormal;
				addbutton.ColorNormal = ColorIndex.ControlNormal;
			}
			
			// Update colors
			SetupColors(General.Colors);
		}
		
		// This sets up the control to show the given items
		public void SetupItems(List<AgendaItem> items, DateTime date)
		{
			DisplayLabel l1 = null;
			DisplayLabel l2 = null;
			
			CleanupControls();
			
			// Make labels
			int top = textlabel1.Top;
			foreach(AgendaItem i in items)
			{
				string timestr;
				
				// Determine how to display this item
				if((i.startdate.Year == date.Year) && (i.startdate.Month == date.Month) && (i.startdate.Day == date.Day))
				{
					if(i.recur == AgendaItemRecur.Annually)
						timestr = "";
					else
						timestr = i.startdate.Hour + ":" + i.startdate.Minute.ToString("00");
				}
				else if(i.recur == AgendaItemRecur.None)
					timestr = "";
				else
					continue;
				
				// Will this item reach the end of the control?
				if(((top + textlabel1.Height) >= this.ClientRectangle.Height) && (l1 != null) && (l2 != null))
				{
					// Make the previous item display "More"
					l1.Text = "";
					l2.Text = "More...";
					l2.ColorText = ColorIndex.ControlNormal;
					l2.SetupColors(General.Colors);
					
					// We can't go any further
					break;
				}
				else
				{
					// Time
					l1 = new DisplayLabel();
					l1.AutoSize = timelabel1.AutoSize;
					l1.ColorBackground = timelabel1.ColorBackground;
					l1.ColorText = i.color;
					l1.Font = timelabel1.Font;
					l1.Location = new Point(timelabel1.Left, top);
					l1.Size = timelabel1.Size;
					l1.Text = timestr;
					l1.TextAlign = timelabel1.TextAlign;
					l1.Visible = true;
					l1.SetupColors(General.Colors);
					Controls.Add(l1);
					labels.Add(l1);
					l1.BringToFront();
					
					// Description
					l2 = new DisplayLabel();
					l2.AutoSize = textlabel1.AutoSize;
					l2.AutoEllipsis = textlabel1.AutoEllipsis;
					l2.Anchor = textlabel1.Anchor;
					l2.ColorBackground = textlabel1.ColorBackground;
					l2.ColorText = i.color;
					l2.Font = textlabel1.Font;
					l2.Location = new Point(textlabel1.Left, top);
					l2.Size = textlabel1.Size;
					l2.Text = "\u2022  " + i.ToString();
					l2.TextAlign = textlabel1.TextAlign;
					l2.UseMnemonic = textlabel1.UseMnemonic;
					l2.Visible = true;
					l2.SetupColors(General.Colors);
					Controls.Add(l2);
					labels.Add(l2);
					l2.BringToFront();
					
					// Position for next labels
					top += textlabel1.Height + textlabel1.Margin.Bottom + textlabel1.Margin.Top;
				}
			}
		}
		
		// This cleans up the dynamic controls
		private void CleanupControls()
		{
			foreach(DisplayLabel lbl in labels)
			{
				this.Controls.Remove(lbl);
				lbl.Dispose();
			}
			
			labels.Clear();
		}

		// View clicked
		private void viewbutton_Click(object sender, EventArgs e)
		{
			if(ViewClicked != null)
				ViewClicked(this, e);
		}

		// Add clicked
		private void addbutton_Click(object sender, EventArgs e)
		{
			if(AddClicked != null)
				AddClicked(this, e);
		}
		
		
		#endregion
		
		#region ================== Events
		
		#endregion
	}
}
