
#region ================== Namespaces

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Forms.Design;

#endregion

namespace CodeImp.Gluon
{
	internal class DisplayBarDesigner : ControlDesigner
	{
		public override IList SnapLines
		{
			get
			{
				IList snaplines = base.SnapLines;
				
				DisplayBar control = base.Control as DisplayBar;
				if(control == null) { return snaplines; }

				IDesigner designer = TypeDescriptor.CreateDesigner(control, typeof(IDesigner));
				if(designer == null) { return snaplines; }
				designer.Initialize(control);

				using(designer)
				{
					ControlDesigner boxdesigner = designer as ControlDesigner;
					if(boxdesigner == null) { return snaplines; }

					CornerImagesProvider corners = control.CornerImagesProvider;
					corners.AddSnapLines(snaplines, control);
				}

				return snaplines;
			}
		}
	}
}
