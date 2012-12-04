
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;

#endregion

namespace CodeImp.Gluon
{
	public class ColorPalette
	{
		#region ================== Colors

		private int numcolors;
		private Color[] normalcolors;
		private Color[] darkcolors;
		private Color[] currentcolors;
		private bool darkmode;
		
		// How to change the colors for the dark scheme
		private const float DARK_MULTIPLIER = 0.4f;
		private const float DARK_ADDITION = 0.0f;
		
		#endregion
		
		#region ================== Properties

		public Color this[ColorIndex colorindex] { get { return currentcolors[(int)colorindex]; } }
		public bool InDarkMode { get { return darkmode; } }

		#endregion
		
		#region ================== Load / Save
		
		// Constructor
		public ColorPalette()
		{
			numcolors = Enum.GetValues(typeof(ColorIndex)).Length;
			normalcolors = new Color[numcolors];
			currentcolors = new Color[numcolors];
			darkcolors = new Color[numcolors];
			
			// Load normal colors from settings
			for(int i = 0; i < numcolors; i++)
				normalcolors[i] = ReadColorSetting(i);

			MakeDarkScheme();
		}
		
		// Save
		public void SaveColors()
		{
			// Save colors to settings
			for(int i = 0; i < numcolors; i++)
				WriteColorSetting(i, normalcolors[i]);
		}
		
		#endregion
		
		#region ================== Methods
		
		// This reads a color from settings
		private Color ReadColorSetting(int index)
		{
			return Color.FromArgb(General.Settings.Config.ReadSetting("colors." + index, Color.Magenta.ToArgb()));
		}
		
		// This stores a color to settings
		private void WriteColorSetting(int index, Color color)
		{
			General.Settings.Config.WriteSetting("colors." + index, color.ToArgb());
		}

		// This makes the dark colors
		private void MakeDarkScheme()
		{
			for(int i = 0; i < numcolors; i++)
			{
				// We don't want to darken all colors!
				if((i != (int)ColorIndex.WarningLight) && (i != (int)ColorIndex.WarningLightText) &&
				   (i != (int)ColorIndex.WarningDark) && (i != (int)ColorIndex.WarningDarkText))
				{
					// Make dark version of color
					float r = (float)normalcolors[i].R / 255.0f;
					float g = (float)normalcolors[i].G / 255.0f;
					float b = (float)normalcolors[i].B / 255.0f;

					r = Tools.Clamp(r * DARK_MULTIPLIER + DARK_ADDITION, 0.0f, 1.0f);
					g = Tools.Clamp(g * DARK_MULTIPLIER + DARK_ADDITION, 0.0f, 1.0f);
					b = Tools.Clamp(b * DARK_MULTIPLIER + DARK_ADDITION, 0.0f, 1.0f);

					darkcolors[i] = Color.FromArgb((int)(r * 255.0f), (int)(g * 255.0f), (int)(b * 255.0f));
				}
				else
				{
					// Use original color
					darkcolors[i] = normalcolors[i];
				}
			}
		}
		
		// This sets up colors for the normal scheme
		public void SetupNormalScheme()
		{
			for(int i = 0; i < numcolors; i++)
				currentcolors[i] = normalcolors[i];

			darkmode = false;
		}
		
		// This sets up colors for the dark scheme
		public void SetupDarkScheme()
		{
			for(int i = 0; i < numcolors; i++)
				currentcolors[i] = darkcolors[i];

			darkmode = true;
		}
		
		// This returns a color by index
		public Color GetNormalColor(ColorIndex index)
		{
			return normalcolors[(int)index];
		}

		// This sets a color by index
		public void SetNormalColor(ColorIndex index, Color c)
		{
			normalcolors[(int)index] = c;
		}
		
		#endregion
	}
}
