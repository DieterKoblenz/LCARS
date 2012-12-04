
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Media;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

#endregion

namespace CodeImp.Gluon
{
	public class GroceriesItemSorter : IComparer<GroceriesItem>
	{
		// Constructor
		public GroceriesItemSorter()
		{
		}
		
		// Comparer
		public int Compare(GroceriesItem x, GroceriesItem y)
		{
			return x.name.CompareTo(y.name);
		}
	}
}

