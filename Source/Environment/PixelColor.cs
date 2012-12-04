
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
using System.Drawing.Imaging;
using System.Net;
using System.Net.Cache;

#endregion

namespace CodeImp.Gluon
{
	public struct PixelColor
	{
		#region ================== Constants

		public const float BYTE_TO_FLOAT = 0.00392156862745098f;

		#endregion

		#region ================== Statics

		public static readonly PixelColor Transparent = new PixelColor(0, 0, 0, 0);

		#endregion

		#region ================== Variables

		// Members
		public byte b;
		public byte g;
		public byte r;
		public byte a;

		#endregion

		#region ================== Constructors

		// Constructor
		public PixelColor(byte a, byte r, byte g, byte b)
		{
			// Initialize
			this.a = a;
			this.r = r;
			this.g = g;
			this.b = b;
		}

		// Constructor
		public PixelColor(PixelColor p, byte a)
		{
			// Initialize
			this.a = a;
			this.r = p.r;
			this.g = p.g;
			this.b = p.b;
		}

		#endregion

		#region ================== Methods

		// Construct from color
		public static PixelColor FromColor(Color c)
		{
			return new PixelColor(c.A, c.R, c.G, c.B);
		}

		// Construct from int
		public static PixelColor FromInt(int c)
		{
			return FromColor(Color.FromArgb(c));
		}

		// Return the inverse color
		public PixelColor Inverse()
		{
			return new PixelColor((byte)(255 - a), (byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
		}

		// Return the inverse color, but keep same alpha
		public PixelColor InverseKeepAlpha()
		{
			return new PixelColor(a, (byte)(255 - r), (byte)(255 - g), (byte)(255 - b));
		}

		// To int
		public int ToInt()
		{
			return Color.FromArgb(a, r, g, b).ToArgb();
		}

		// To Color
		public Color ToColor()
		{
			return Color.FromArgb(a, r, g, b);
		}

		// To ColorRef (alpha-less)
		public int ToColorRef()
		{
			return ((int)r + ((int)b << 16) + ((int)g << 8));
		}

		// This returns a new PixelColor with adjusted alpha
		public PixelColor WithAlpha(byte a)
		{
			return new PixelColor(this, a);
		}

		// This blends two colors with respect to alpha
		public PixelColor Blend(PixelColor a, PixelColor b)
		{
			PixelColor c = new PixelColor();
			float ba;

			ba = (float)a.a * BYTE_TO_FLOAT;
			c.r = (byte)((float)a.r * (1f - ba) + (float)b.r * ba);
			c.g = (byte)((float)a.g * (1f - ba) + (float)b.g * ba);
			c.b = (byte)((float)a.b * (1f - ba) + (float)b.b * ba);
			c.a = (byte)((float)a.a * (1f - ba) + ba);

			return c;
		}

		// This modulates two colors
		public static PixelColor Modulate(PixelColor a, PixelColor b)
		{
			float aa = (float)a.a * BYTE_TO_FLOAT;
			float ar = (float)a.r * BYTE_TO_FLOAT;
			float ag = (float)a.g * BYTE_TO_FLOAT;
			float ab = (float)a.b * BYTE_TO_FLOAT;
			float ba = (float)b.a * BYTE_TO_FLOAT;
			float br = (float)b.r * BYTE_TO_FLOAT;
			float bg = (float)b.g * BYTE_TO_FLOAT;
			float bb = (float)b.b * BYTE_TO_FLOAT;
			PixelColor c = new PixelColor();
			c.a = (byte)((aa * ba) * 255.0f);
			c.r = (byte)((ar * br) * 255.0f);
			c.g = (byte)((ag * bg) * 255.0f);
			c.b = (byte)((ab * bb) * 255.0f);
			return c;
		}

		// This modulates two colors
		public static PixelColor Scale(PixelColor a, float scalar)
		{
			float ar = (float)a.r * BYTE_TO_FLOAT;
			float ag = (float)a.g * BYTE_TO_FLOAT;
			float ab = (float)a.b * BYTE_TO_FLOAT;
			PixelColor c = new PixelColor();
			c.a = a.a;
			c.r = (byte)(Tools.Clamp(ar * scalar, 0.0f, 1.0f) * 255.0f);
			c.g = (byte)(Tools.Clamp(ag * scalar, 0.0f, 1.0f) * 255.0f);
			c.b = (byte)(Tools.Clamp(ab * scalar, 0.0f, 1.0f) * 255.0f);
			return c;
		}

		// This modulates two colors
		public static PixelColor Add(PixelColor a, PixelColor b)
		{
			float aa = (float)a.a * BYTE_TO_FLOAT;
			float ar = (float)a.r * BYTE_TO_FLOAT;
			float ag = (float)a.g * BYTE_TO_FLOAT;
			float ab = (float)a.b * BYTE_TO_FLOAT;
			float ba = (float)b.a * BYTE_TO_FLOAT;
			float br = (float)b.r * BYTE_TO_FLOAT;
			float bg = (float)b.g * BYTE_TO_FLOAT;
			float bb = (float)b.b * BYTE_TO_FLOAT;
			PixelColor c = new PixelColor();
			c.a = (byte)(Tools.Clamp(aa + ba, 0.0f, 1.0f) * 255.0f);
			c.r = (byte)(Tools.Clamp(ar + br, 0.0f, 1.0f) * 255.0f);
			c.g = (byte)(Tools.Clamp(ag + bg, 0.0f, 1.0f) * 255.0f);
			c.b = (byte)(Tools.Clamp(ab + bb, 0.0f, 1.0f) * 255.0f);
			return c;
		}

		// This makes a color gray
		public static PixelColor Desaturate(PixelColor a)
		{
			float ar = (float)a.r * BYTE_TO_FLOAT;
			float ag = (float)a.g * BYTE_TO_FLOAT;
			float ab = (float)a.b * BYTE_TO_FLOAT;
			float l = (ar * 0.3f) + (ag * 0.59f) + (ab * 0.11f);
			PixelColor c = new PixelColor();
			c.a = a.a;
			c.r = (byte)(l * 255.0f);
			c.g = (byte)(l * 255.0f);
			c.b = (byte)(l * 255.0f);
			return c;
		}
		
		// Linear interpolation
		public static PixelColor Lerp(PixelColor a, PixelColor b, float u)
		{
			float aa = (float)a.a * BYTE_TO_FLOAT;
			float ar = (float)a.r * BYTE_TO_FLOAT;
			float ag = (float)a.g * BYTE_TO_FLOAT;
			float ab = (float)a.b * BYTE_TO_FLOAT;
			float ba = (float)b.a * BYTE_TO_FLOAT;
			float br = (float)b.r * BYTE_TO_FLOAT;
			float bg = (float)b.g * BYTE_TO_FLOAT;
			float bb = (float)b.b * BYTE_TO_FLOAT;
			PixelColor c = new PixelColor();
			c.a = (byte)(((ba * u) + (aa * (1.0f - u))) * 255.0f);
			c.r = (byte)(((br * u) + (ar * (1.0f - u))) * 255.0f);
			c.g = (byte)(((bg * u) + (ag * (1.0f - u))) * 255.0f);
			c.b = (byte)(((bb * u) + (ab * (1.0f - u))) * 255.0f);
			return c;
		}
		
		#endregion
	}
}
