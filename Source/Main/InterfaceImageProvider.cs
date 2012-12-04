
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

#endregion

namespace CodeImp.Gluon
{
	public class InterfaceImageProvider
	{
		#region ================== Variables
		
		private Dictionary<InterfaceImage, Image> normalimages;
		private Dictionary<InterfaceImage, Image> darkimages;
		
		#endregion
		
		#region ================== Properties
		
		#endregion
		
		#region ================== Constructor / Disposer
		
		// Constructor
		public InterfaceImageProvider()
		{
			normalimages = new Dictionary<InterfaceImage, Image>();
			darkimages = new Dictionary<InterfaceImage, Image>();
		}
		
		// Disposer
		public void Dispose()
		{
			// Dispose any loaded images
			foreach(KeyValuePair<InterfaceImage, Image> i in normalimages)
				i.Value.Dispose();

			foreach(KeyValuePair<InterfaceImage, Image> i in darkimages)
				i.Value.Dispose();

			normalimages.Clear();
			darkimages.Clear();
		}
		
		#endregion
		
		#region ================== Methods
		
		// This returns an image
		public Image GetImage(InterfaceImage interfaceimage)
		{
			return General.Colors.InDarkMode ? darkimages[interfaceimage] : normalimages[interfaceimage];
		}

		// This rebuilds all images
		public void BuildImages()
		{
			Bitmap a, b;
			
			Dictionary<InterfaceImage, Image> collection = General.Colors.InDarkMode ? darkimages : normalimages;
			
			Bitmap curve = new Bitmap(Properties.Resources.Curve);
			if(curve.PixelFormat != PixelFormat.Format32bppArgb)
				throw new Exception("Image is in invalid format!");
			
			// Clear the collection
			foreach(KeyValuePair<InterfaceImage, Image> i in collection)
				i.Value.Dispose();
			collection.Clear();
			
			// Curves with Window background color, not inverted
			a = new Bitmap(curve);
			RecolorRedToAlpha(a, General.Colors[ColorIndex.WindowBackground]);
			collection[InterfaceImage.WindowCurveNormal] = a;
			
			b = new Bitmap(a);
			b.RotateFlip(RotateFlipType.RotateNoneFlipX);
			collection[InterfaceImage.WindowCurveFlipX] = b;

			b = new Bitmap(a);
			b.RotateFlip(RotateFlipType.RotateNoneFlipY);
			collection[InterfaceImage.WindowCurveFlipY] = b;

			b = new Bitmap(a);
			b.RotateFlip(RotateFlipType.RotateNoneFlipXY);
			collection[InterfaceImage.WindowCurveFlipXY] = b;
			
			
			// Curves with Window background color, inverted
			a = new Bitmap(curve);
			InvertRGB(a);
			RecolorRedToAlpha(a, General.Colors[ColorIndex.WindowBackground]);
			collection[InterfaceImage.WindowCurveInverse] = a;

			b = new Bitmap(a);
			b.RotateFlip(RotateFlipType.RotateNoneFlipX);
			collection[InterfaceImage.WindowCurveInverseFlipX] = b;

			b = new Bitmap(a);
			b.RotateFlip(RotateFlipType.RotateNoneFlipY);
			collection[InterfaceImage.WindowCurveInverseFlipY] = b;

			b = new Bitmap(a);
			b.RotateFlip(RotateFlipType.RotateNoneFlipXY);
			collection[InterfaceImage.WindowCurveInverseFlipXY] = b;
		}
		
		// This re-arranges the channels of an image
		// The red channel is moved to the alpha channel.
		// The specified color overwrites the red, green and blue channels.
		private unsafe void RecolorRedToAlpha(Bitmap img, Color c)
		{
			Rectangle lockrect = new Rectangle(0, 0, img.Size.Width, img.Size.Height);
			BitmapData data = img.LockBits(lockrect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			int* p = (int*)data.Scan0.ToPointer();
			for(int i = 0; i < data.Width * data.Height; i++)
			{
				byte* b = (byte*)p + 0;
				byte* g = (byte*)p + 1;
				byte* r = (byte*)p + 2;
				byte* a = (byte*)p + 3;
				
				// Move red channel data to alpha channel
				*a = *r;
				
				// Set the color channels to the specified color
				*r = c.R;
				*g = c.G;
				*b = c.B;
				
				p++;
			}
			img.UnlockBits(data);
		}

		// This inverts the color channels of an image
		private unsafe void InvertRGB(Bitmap img)
		{
			Rectangle lockrect = new Rectangle(0, 0, img.Size.Width, img.Size.Height);
			BitmapData data = img.LockBits(lockrect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			int* p = (int*)data.Scan0.ToPointer();
			for(int i = 0; i < data.Width * data.Height; i++)
			{
				byte* b = (byte*)p + 0;
				byte* g = (byte*)p + 1;
				byte* r = (byte*)p + 2;
				byte* a = (byte*)p + 3;
				
				// Invert RGB channels
				*r = (byte)(255 - *r);
				*g = (byte)(255 - *g);
				*b = (byte)(255 - *b);
				
				p++;
			}
			img.UnlockBits(data);
		}
		
		
		#endregion
	}
}
