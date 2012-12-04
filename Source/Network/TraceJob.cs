using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CodeImp.Gluon
{
	public class TraceJob
	{
		public string targetaddress;
		public List<TraceRtNode> nodes;
		public bool jobcomplete;
		public bool targetreachable;

		// Constructor
		public TraceJob(string targetaddress)
		{
			this.targetaddress = targetaddress;
			nodes = new List<TraceRtNode>();
			jobcomplete = false;
			targetreachable = false;
		}
	}
}
