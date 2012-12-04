
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
	public class AgendaItemSorter : IComparer<AgendaItem>
	{
		// Constructor
		public AgendaItemSorter()
		{
		}
		
		// Comparer
		public int Compare(AgendaItem x, AgendaItem y)
		{
			return x.startdate.CompareTo(y.startdate);
		}
	}
}

