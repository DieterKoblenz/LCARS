
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
	public enum ColorIndex : int
	{
		WindowBackground,
		WindowText,
		ControlNormal,
		ControlNormalText,
		ControlPressed,
		ControlPressedText,
		WarningDark,
		WarningDarkText,
		WarningLight,
		WarningLightText,
		InfoDark,
		InfoDarkText,
		InfoLight,
		InfoLightText,
		ControlColor1,
		ControlColor2,
		ControlColorAffirmative,
		ControlColorNegative,
		ControlDisabled,
		ControlDisabledText,
		ControlColor3,
		ControlColorPascal,
		ControlColorMarlies,
		ControlColor4,
	}
}
