
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;

#endregion

namespace CodeImp.Gluon
{
	public enum MessageBeepType : int
	{
		Default = -1,
		Ok = 0x00000000,
		Error = 0x00000010,
		Question = 0x00000020,
		Warning = 0x00000030,
		Information = 0x00000040,
	}
}
