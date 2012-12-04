
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Threading;

#endregion

namespace CodeImp.Gluon
{
	public sealed class SettingsManager
	{
		#region ================== Constants

		#endregion

		#region ================== Variables

		// Config
		private Configuration cfg;
		private static string settingsfile;

		// Settings
		private bool liveenvironment;
		private string libraryroot;
		private string playlistspath;
		private string subtitlesfile;
		private string multiplexroot;
		
		#endregion

		#region ================== Properties

		public Configuration Config { get { return cfg; } }
		public bool LiveEnvironment { get { return liveenvironment; } }
		public string LibraryRoot { get { return libraryroot; } }
		public string PlaylistsPath { get { return playlistspath; } }
		public string SubtitlesFile { get { return subtitlesfile; } }
		public string MultiplexRoot { get { return multiplexroot; } }

		#endregion

		#region ================== Constructor

		// Constructor
		public SettingsManager()
		{
			// Load the configuration
			settingsfile = Path.Combine(General.SettingsPath, "Settings.cfg");
			if(File.Exists(settingsfile))
				cfg = new Configuration(settingsfile, true);
			else
				cfg = new Configuration(true);

			ReadSettings();
		}

		#endregion

		#region ================== Private Methods

		// This reads the settings
		private void ReadSettings()
		{
			liveenvironment = cfg.ReadSetting("liveenvironment", false);
			libraryroot = cfg.ReadSetting("libraryroot", "");
			subtitlesfile = cfg.ReadSetting("subtitlesfile", "");
			multiplexroot = cfg.ReadSetting("multiplexroot", "");

			playlistspath = Path.Combine(libraryroot, "Playlists");
		}

		#endregion

		#region ================== Public Methods

		// This saves the settings
		public void SaveSettings()
		{
			// Let other classes write their settings here
			General.Colors.SaveColors();

			// Write out configuration
			if(File.Exists(settingsfile + "b")) File.Delete(settingsfile + "b");
			if(File.Exists(settingsfile)) File.Move(settingsfile, settingsfile + "b");
			cfg.SaveConfiguration(settingsfile);
		}
		
		#endregion
	}
}