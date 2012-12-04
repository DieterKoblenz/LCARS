using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CodeImp.Gluon
{
	public partial class OverviewTechPanel1 : DisplayPanel
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor

		// Constructor
		public OverviewTechPanel1()
		{
			InitializeComponent();

			interfacenumberlabel.Text = General.ThisAssembly.GetName().Version.Revision.ToString();
		}

		#endregion

		#region ================== Methods

		#endregion

		#region ================== Events

		private void updatetimer_Tick(object sender, EventArgs e)
		{
			ObjectQuery query;
			ManagementObjectSearcher searcher;
			ManagementObjectCollection collection;

			ulong disk_free = 0;
			ulong disk_size = 0;
			query = new ObjectQuery("SELECT FreeSpace, Size FROM Win32_LogicalDisk WHERE Name=\"D:\"");
			searcher = new ManagementObjectSearcher(query);
			collection = searcher.Get();
			foreach(ManagementObject obj in collection)
			{
				disk_free = (ulong)obj["FreeSpace"];
				disk_size = (ulong)obj["Size"];
			}

			ulong mem_free = 0;
			query = new ObjectQuery("SELECT AvailableBytes FROM Win32_PerfRawData_PerfOS_Memory");
			searcher = new ManagementObjectSearcher(query);
			collection = searcher.Get();
			foreach(ManagementObject obj in collection)
			{
				mem_free += (ulong)obj["AvailableBytes"];
			}

			ulong mem_size = 0;
			query = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
			searcher = new ManagementObjectSearcher(query);
			collection = searcher.Get();
			foreach(ManagementObject obj in collection)
			{
				mem_size += (ulong)obj["Capacity"];
			}

			ulong disk_used = disk_size - disk_free;
			double disk_size_gb = (double)disk_size / 1000000000.0d;
			double disk_free_gb = (double)disk_free / 1000000000.0d;
			double disk_used_gb = (double)disk_used / 1000000000.0d;
			double disk_pfree = ((double)disk_free / (double)disk_size) * 100.0d;
			double disk_pused = ((double)disk_used / (double)disk_size) * 100.0d;
			librarysizelabel.Text = disk_size_gb.ToString("0.00") + " GB";
			libraryfreelabel.Text = disk_free_gb.ToString("0.00") + " GB";
			libraryusedlabel.Text = disk_used_gb.ToString("0.00") + " GB";
			libraryfreeplabel.Text = disk_pfree.ToString("0.0") + "%";
			libraryusedplabel.Text = disk_pused.ToString("0.0") + "%";

			ulong mem_used = mem_size - mem_free;
			double mem_size_mb = (double)mem_size / 1000000.0d;
			double mem_free_mb = (double)mem_free / 1000000.0d;
			double mem_used_mb = (double)mem_used / 1000000.0d;
			double mem_pfree = ((double)mem_free / (double)mem_size) * 100.0d;
			double mem_pused = ((double)mem_used / (double)mem_size) * 100.0d;
			memorysizelabel.Text = mem_size_mb.ToString("0") + " MB";
			memoryfreelabel.Text = mem_free_mb.ToString("0") + " MB";
			memoryusedlabel.Text = mem_used_mb.ToString("0") + " MB";
			memoryfreeplabel.Text = mem_pfree.ToString("0.0") + "%";
			memoryusedplabel.Text = mem_pused.ToString("0.0") + "%";
		}

		#endregion
	}
}
