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

#endregion

namespace CodeImp.Gluon
{
	public partial class AddGroceriesDisplayPanel : DisplayPanel
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		private int selectedlist;
		
		#endregion

		#region ================== Properties

		public int SelectedList { get { return selectedlist; } set { selectedlist = value; } }
		
		#endregion

		#region ================== Constructor

		// Constructor
		public AddGroceriesDisplayPanel()
		{
			InitializeComponent();
		}

		#endregion

		#region ================== Methods

		// Setup colors
		public override void SetupColors(ColorPalette c)
		{
			base.SetupColors(c);

			itemname.BackColor = General.Colors[ColorIndex.ControlNormal];
			itemname.ForeColor = General.Colors[ColorIndex.ControlNormalText];
			itemcount.BackColor = General.Colors[ColorIndex.ControlNormal];
			itemcount.ForeColor = General.Colors[ColorIndex.ControlNormalText];
		}
		
		private void PlayFailSound()
		{
			General.Sounds.Play("error");
		}
		
		#endregion

		#region ================== Events

		// When shown
		public override void OnShow()
		{
			itemname.Text = "";
			itemcount.Text = "1";

			int listnumber = selectedlist + 1;
			listlabel.Text = listnumber.ToString();
			
			base.OnShow();
		}

		// When done showing
		protected override void OnShowFinished()
		{
			itemname.Focus();
		}

		private void TextBox_Enter(object sender, EventArgs e)
		{
			(sender as TextBox).SelectAll();
		}

		private void TextBox_MouseUp(object sender, MouseEventArgs e)
		{
			(sender as TextBox).SelectAll();
		}

		private void itemnamebar_Click(object sender, EventArgs e)
		{
			itemname.Focus();
		}

		private void itemcountbar_Click(object sender, EventArgs e)
		{
			itemcount.Focus();
		}

		// Accept pressed
		private void acceptbutton_Click(object sender, EventArgs e)
		{
			GroceriesItem newitem = new GroceriesItem();

			if(itemname.Text.Length == 0)
			{
				PlayFailSound();
				itemname.Focus();
				return;
			}

			newitem.name = itemname.Text;
			newitem.list = selectedlist;
			
			if(long.TryParse(itemcount.Text, out newitem.count))
			{
				General.Groceries.AddOrUpdateItem(newitem, true);
				General.MainWindow.GroceriesPanel.SelectedList = selectedlist;
				General.MainWindow.ShowTaggedPanel("groceries");
			}
			else
			{
				PlayFailSound();
				itemcount.Focus();
			}
		}

		// Back pressed
		private void backbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.GroceriesPanel.SelectedList = selectedlist;
			General.MainWindow.ShowTaggedPanel("groceries");
		}

		// Overview pressed
		private void overviewbutton_Click(object sender, EventArgs e)
		{
			General.MainWindow.ShowTaggedPanel("overview");
		}
		
		#endregion
	}
}
