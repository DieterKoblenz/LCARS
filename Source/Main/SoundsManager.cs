
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Media;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;

#endregion

namespace CodeImp.Gluon
{
	public class SoundsManager
	{
		#region ================== API Declarations
		
		[DllImport("winmm.dll")]
		public static extern int waveOutGetNumDevs();

		[DllImport("winmm.dll")]
		public static extern int waveOutGetDevCaps(int uDeviceID, ref WaveOutCaps lpCaps, int uSize);
		
		#endregion

		#region ================== Constants

		#endregion

		#region ================== Variables
		
		// Audio devices
		private WaveOutCaps[] devices;
		private string primarydevice;
		private string secondarydevice;
		
		// Players for sound files
		private Dictionary<string, SoundPlayer> sounds;

		#endregion

		#region ================== Properties

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public SoundsManager()
		{
			sounds = new Dictionary<string, SoundPlayer>();

			// Find all devices
			int numdevices = waveOutGetNumDevs();
			devices = new WaveOutCaps[numdevices];
			for(int i = 0; i < numdevices; i++)
			{
				devices[i] = new WaveOutCaps();
				waveOutGetDevCaps(i, ref devices[i], Marshal.SizeOf(typeof(WaveOutCaps)));
			}

			// Determine primary and secondary audio device to use
			if(General.Settings.LiveEnvironment)
			{
				primarydevice = FindDeviceName("SigmaTel");
				secondarydevice = FindDeviceName("SB X-Fi");
			}
			else
			{
				primarydevice = FindDeviceName("Realtek");
				secondarydevice = FindDeviceName("Realtek");
			}
		}

		// Disposer
		public void Dispose()
		{
			foreach(KeyValuePair<string, SoundPlayer> s in sounds)
				s.Value.Dispose();

			sounds.Clear();
		}

		#endregion

		#region ================== Private Methods

		// This finds a device name
		private string FindDeviceName(string partofname)
		{
			foreach(WaveOutCaps c in devices)
			{
				if(c.szPname.ToLowerInvariant().Contains(partofname.ToLowerInvariant()))
					return c.szPname;
			}

			return null;
		}

		#endregion

		#region ================== Public Methods

		// This checks of the audio output is the primary device
		public bool CheckAudioOutputPrimary()
		{
			string value = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Multimedia\\Sound Mapper", "Playback", secondarydevice);
			return (value == primarydevice);
		}
		
		// This switches sound output to the primary device
		public void SetAudioOutputPrimary()
		{
			if(primarydevice != null)
			{
				Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Multimedia\\Sound Mapper", "Playback", primarydevice, RegistryValueKind.String);
				General.WriteLogLine("Default audio device set to primary: " + primarydevice);
			}
		}

		// This switches sound output to the secondary device
		public void SetAudioOutputSecondary()
		{
			if(secondarydevice != null)
			{
				Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Multimedia\\Sound Mapper", "Playback", secondarydevice, RegistryValueKind.String);
				General.WriteLogLine("Default audio device set to secondary: " + secondarydevice);
			}
		}

		// This loads all sounds
		public void LoadSounds()
		{
			string pathname = Path.Combine(General.AppPath, "Sounds");
			string[] soundfiles = Directory.GetFiles(pathname, "*.wav", SearchOption.TopDirectoryOnly);
			foreach(string sndfile in soundfiles)
			{
				string filetitle = Path.GetFileNameWithoutExtension(sndfile);
				SoundPlayer player = new SoundPlayer(sndfile);
				player.Load();
				sounds.Add(filetitle, player);
			}
		}
		
		// This plays the sound with the specified file title
		public void Play(string title)
		{
			if(sounds.ContainsKey(title))
				sounds[title].Play();
		}

		// This plays the sound with the specified file title
		public void PlayLoop(string title)
		{
			if(sounds.ContainsKey(title))
				sounds[title].PlayLooping();
		}
		
		// This stops playing the sound with the specified title
		public void Stop(string title)
		{
			if(sounds.ContainsKey(title))
				sounds[title].Stop();
		}
		
		#endregion
	}
}
