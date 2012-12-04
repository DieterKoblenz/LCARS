#region === Copyright (c) 2010 Pascal van der Heiden ===

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

#endregion

namespace CodeImp.Gluon
{
	internal struct DirectoryEntry
	{
		// Example for full name:       C:\WADs\Foo\Bar.WAD

		// Members
		public bool isdirectory;
		public string filename;			// Bar.WAD
		public string filetitle;		// Bar
		public string extension;		// WAD
		public string path;				// C:\WADs\Foo
		public string filepathname;		// C:\WADs\Foo\Bar.WAD

		// Constructor
		public DirectoryEntry(string fullname)
		{
			isdirectory = !File.Exists(fullname);
			
			filename = Path.GetFileName(fullname);
			
			if(isdirectory)
			{
				filetitle = Path.GetFileName(fullname);
				extension = "";
			}
			else
			{
				filetitle = Path.GetFileNameWithoutExtension(fullname);
				extension = Path.GetExtension(fullname);
			}
			
			if(extension.Length > 1)
				extension = extension.Substring(1);
			else
				extension = "";
			
			path = Path.GetDirectoryName(fullname);
			
			filepathname = Path.Combine(path, filename);
		}
	}
}
